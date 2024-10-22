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


namespace S1084_AutoRelease
{
    public partial class NormalRelease : Form
    {
        XmlDocument db;
        private string projectName = "";
        private string stage = "";
        private string version = "";
        private int revision = 0;
        XmlElement project;
        XmlElement sprints;

        public NormalRelease(XmlDocument db, string name)
        {
            InitializeComponent();

            projectName = name;
            this.db = db;

            project = (XmlElement)db.GetElementsByTagName(name)[0];

            stage = project.Attributes["stage"].Value;

            switch (stage)
            {
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

            sprints = (XmlElement)project.GetElementsByTagName("Sprints")[0];

            if (sprints.ChildNodes.Count == 0)
            {
                revision = 1;
            }
            else
            {
                string last = sprints.ChildNodes[sprints.ChildNodes.Count - 1].Name;
                last = last.Substring(1);
                revision = Int32.Parse(last);
                revision += 1;
            }

            version = stage + revision.ToString();


            // Before closing the current Sprint,
            // enter number of stories in:
            InitInfoLabel.Text = "You are about to release " + version + "\nBefore closing Sprint " + version + "\nenter number of stories in:";
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
           /* XmlElement newRelease = db.CreateElement(version);
            newRelease.SetAttribute("unplanned", BacklogTextBox.Text);
            newRelease.SetAttribute("todo", ToDoTextBox.Text);
            newRelease.SetAttribute("inProgress", InProgressTextBox.Text);
            newRelease.SetAttribute("done", DoneTextBox.Text);
            sprints.AppendChild(newRelease);
            db.Save(db.DocumentElement.GetAttribute("path"));

            GenerateReport gen = new GenerateReport(db, projectName); */

            string repoPath = db.GetElementsByTagName(projectName)[0].Attributes["repoPath"].Value;

            using (PowerShell powershell = PowerShell.Create())
            {
                powershell.AddScript($"cd {repoPath}");
                powershell.AddScript(@"git fetch");
                powershell.AddScript(@"git checkout Develop");

                Collection<PSObject> results = powershell.Invoke();
            }


            this.Close();
        }
    }
}
