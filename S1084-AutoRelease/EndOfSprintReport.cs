using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Management.Automation;
using System.IO;
using System.Collections.ObjectModel;
using System.Security.Policy;
using System.Xml.Linq;
using System.Reflection.Emit;


namespace S1084_AutoRelease
{
    public partial class EndOfSprintReport : Form
    {
        XmlDocument db;
        private string projectName = "";
        private string stage = "";
        private string version = "";
        private int revision = 0;
        // XmlElement project;
        // XmlElement sprints;

        public EndOfSprintReport(XmlDocument db, string name)
        {
            InitializeComponent();

            projectName = name;
            this.db = db;

            XmlElement project = (XmlElement)db.GetElementsByTagName(name)[0];

            stage = project.Attributes["stage"].Value;

            switch (stage)
            {
                case "White":
                case "white":
                    stage = "W";
                    break;

                case "Red":
                case "red":
                    stage = "R";
                    break;

                case "Blue":
                case "blue":
                    stage = "B";
                    break;

                case "Green":
                case "green":
                    stage = "G";
                    break;

                case "Black":
                case "black":
                    stage = "K";
                    break;
            }

            revision = 1;
            XmlElement sprints = (XmlElement)project.GetElementsByTagName("Sprints")[0];

            if ((sprints != null) && (sprints.ChildNodes.Count > 0))
            {
                string last = sprints.ChildNodes[sprints.ChildNodes.Count - 1].Name;

                if (last[0] == stage[0])
                {
                    last = last.Substring(1);
                    revision = Int32.Parse(last);
                    revision += 1;
                }
            }

            version = stage + revision.ToString();

            InitInfoLabel.Text = "You are about to complete " + version + ". Before closing Sprint " + version + ":\n" +
                "1. Enter number of stories and points for project and all components in table below\n" +
                "2. Ensure GIT Develop is up to date and then tagged with " + version + "\n";

            XmlElement softwareComponents = (XmlElement)project.GetElementsByTagName("Software")[0];
            XmlElement hardwareComponents = (XmlElement)project.GetElementsByTagName("Hardware")[0];

            ComponentsTable.Rows.Add("Whole Project", 0, 0, 0, 0);

            if (softwareComponents != null)
            {
                for (int i = 0; i < softwareComponents.ChildNodes.Count; i++)
                    ComponentsTable.Rows.Add(softwareComponents.ChildNodes[i].Name, 0, 0, 0, 0);
            }

            if (hardwareComponents != null)
            {
                for (int i = 0; i < hardwareComponents.ChildNodes.Count; i++)
                    ComponentsTable.Rows.Add(hardwareComponents.ChildNodes[i].Name, 0, 0, 0, 0);
            }

            var height = 50;
            foreach (DataGridViewRow dr in ComponentsTable.Rows)
            {
                height += dr.Height;
            }

            ComponentsTable.Height = height;
        }



        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OkayButton_Click(object sender, EventArgs e)
        {
            int Row = 0;
            int Name = 0;
            int Backlog = 1;
            int ToDo = 2;
            int InProgress = 3;
            int Done = 4;

            string name = (string)ComponentsTable.Rows[Row].Cells[Name].Value.ToString();
            string backlog = (string)ComponentsTable.Rows[Row].Cells[Backlog].Value.ToString();
            string toDo = (string)ComponentsTable.Rows[Row].Cells[ToDo].Value.ToString();
            string inProgress = (string)ComponentsTable.Rows[Row].Cells[InProgress].Value.ToString();
            string done = (string)ComponentsTable.Rows[Row].Cells[Done].Value.ToString();

            this.DialogResult = DialogResult.Abort;

            XmlElement project = (XmlElement)db.GetElementsByTagName(projectName)[0];
            XmlNode software = project.GetElementsByTagName("Software")[0];

            XmlElement newRelease = db.CreateElement(version);
            newRelease.SetAttribute("date", DateOnly.FromDateTime(DateTime.Now).ToString());
            newRelease.SetAttribute("unplanned", backlog);
            newRelease.SetAttribute("todo", toDo);
            newRelease.SetAttribute("inProgress", inProgress);
            newRelease.SetAttribute("done", done);

            // Now add all the individual components
            for (Row = 1; Row < (ComponentsTable.Rows.Count - 1); Row++)
            {
                name = (string)ComponentsTable.Rows[Row].Cells[Name].Value.ToString();
                backlog = (string)ComponentsTable.Rows[Row].Cells[Backlog].Value.ToString();
                toDo = (string)ComponentsTable.Rows[Row].Cells[ToDo].Value.ToString();
                inProgress = (string)ComponentsTable.Rows[Row].Cells[InProgress].Value.ToString();
                done = (string)ComponentsTable.Rows[Row].Cells[Done].Value.ToString();

                XmlElement comp = db.CreateElement(name);
                comp.SetAttribute("unplanned", backlog);
                comp.SetAttribute("todo", toDo);
                comp.SetAttribute("inProgress", inProgress);
                comp.SetAttribute("done", done);
                newRelease.AppendChild(comp);
            }

            project.GetElementsByTagName("Sprints")[0].AppendChild(newRelease);

            db.Save(db.DocumentElement.GetAttribute("path"));

            GenerateReport generate = new GenerateReport();
            generate.ReportHomePage(db);
            generate.ProjectProgress(db, projectName);

            this.Close();
        }

        private void ComponentsTable_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex != 0)
            {
                int i;

                if (!int.TryParse(Convert.ToString(e.FormattedValue), out i))
                {
                    e.Cancel = true;
                    MessageBox.Show("Please enter numeric value only");
                }
            }
        }
    }
}
