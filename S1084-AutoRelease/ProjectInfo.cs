using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static System.Windows.Forms.AxHost;
using System.Xml.Linq;
using System.Collections;
using static S1084_AutoRelease.ProjectInfo;
using S1084_AutoRelease.Properties;



namespace S1084_AutoRelease
{
    public partial class ProjectInfo : Form
    {
        public struct endOfSprint
        {
            public string date;
            public string name;
            public string unplanned;
            public string todo;
            public string inProgress;
            public string done;
        }

        private List<endOfSprint> endOfSprints = new List<endOfSprint>();

        private int subProjectButton_x = 20;
        private int subProjectButton_y = 140;
        private XmlDocument db = new XmlDocument();

        //struct Sxxxx
        //{
        //    public string name;     // S1070 or S1071, etc --> Name of children elements to 'Project/Software'
        //    public string included; // Attribute to the named Sxxxx element
        //}
        //private List<Sxxxx> subProjects = new List<Sxxxx>();

        public ProjectInfo(XmlDocument db, string name)
        {
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;
            this.db = db;

            DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
            checkColumn.Name = "Included";
            checkColumn.HeaderText = "Included in Build";
            checkColumn.Width = 50;
            checkColumn.ReadOnly = false;
            checkColumn.FillWeight = 10;
            TableOfSxxxx.Columns.Add(checkColumn);

            if (name != "") // If editing an existing project then:
            {
                XmlElement project = (XmlElement)db.GetElementsByTagName(name)[0];
                ProjectNameTextBox.Text = name; //  For example, "DCB1"
                DescriptiveNameTextBox.Text = project.Attributes["desName"].Value; //  For example, "Distributed Current Bus"
                DescriptionTextBox.Text = project.Attributes["description"].Value;
                RepoPathTextBox.Text = project.Attributes["repoPath"].Value;
                StageComboBox.Text = project.Attributes["stage"].Value;
                StatusComboBox.Text = project.Attributes["status"].Value;

                XmlElement Software = (XmlElement)project.GetElementsByTagName("Software")[0];
                if (Software != null)
                {
                    foreach (XmlNode node in Software)
                    {
                        if (node.Attributes["included"].Value == "yes")
                            TableOfSxxxx.Rows.Add(node.Name, GetSxxxxAttributeFromName(node.Name, "shortName"), GetSxxxxAttributeFromName(node.Name, "platform"), true);
                        else
                            TableOfSxxxx.Rows.Add(node.Name, GetSxxxxAttributeFromName(node.Name, "shortName"), GetSxxxxAttributeFromName(node.Name, "platform"), false);
                    }
                }

                XmlElement Hardware = (XmlElement)project.GetElementsByTagName("Hardware")[0];
                if (Hardware != null)
                {
                    foreach (XmlNode node in Hardware)
                    {
                        if (node.Attributes["included"].Value == "yes")
                            TableOfSxxxx.Rows.Add(node.Name, GetEDAxxxxAttributeFromName(node.Name, "shortName"), "NA", true);
                        else
                            TableOfSxxxx.Rows.Add(node.Name, GetEDAxxxxAttributeFromName(node.Name, "shortName"), "NA", false);
                    }
                }

                XmlElement sprints = (XmlElement)project.GetElementsByTagName("Sprints")[0];

                if (sprints != null)
                {
                    foreach (XmlElement node in sprints)
                    {
                        endOfSprint sprint = new endOfSprint();
                        sprint.name = node.Name;
                        sprint.date = node.Attributes["date"].Value;
                        sprint.unplanned = node.Attributes["unplanned"].Value;
                        sprint.todo = node.Attributes["todo"].Value;
                        sprint.inProgress = node.Attributes["inProgress"].Value;
                        sprint.done = node.Attributes["done"].Value;
                        endOfSprints.Add(sprint);
                    }
                }
            }
        }

        private void ProjectInfo_Load(object sender, EventArgs e)
        {
            UpdateTableOfSxxxxSize();
        }

        private void UpdateTableOfSxxxxSize()
        {
            int width = TableOfSxxxx.RowHeadersWidth;

            foreach (DataGridViewColumn col in TableOfSxxxx.Columns)
                width += col.Width;

            TableOfSxxxx.Width = width;

            int height = TableOfSxxxx.ColumnHeadersHeight;

            foreach (DataGridViewRow row in TableOfSxxxx.Rows)
                height += row.Height;

            TableOfSxxxx.Height = height;

            TableOfSxxxx.Sort(TableOfSxxxx.Columns[0], ListSortDirection.Ascending);
            TableOfSxxxx.Columns[0].ReadOnly = true;
            TableOfSxxxx.Columns[1].ReadOnly = true;
            TableOfSxxxx.Columns[2].ReadOnly = true;
            TableOfSxxxx.Columns[3].ReadOnly = false;
        }

        private string GetSxxxxAttributeFromName(string Sxxxx, string attribute)
        {
            string retVal = "";
            foreach (XmlNode softwareProject in db.GetElementsByTagName("SoftwareProjects")[0].ChildNodes)
            {
                if (Sxxxx == softwareProject.Name)
                {
                    if (softwareProject.Attributes[attribute] != null)
                    {
                        retVal = softwareProject.Attributes[attribute].Value;
                        break;
                    }
                }
            }

            return retVal;
        }

        private string GetEDAxxxxAttributeFromName(string EDAxxxx, string attribute)
        {
            string retVal = "";
            foreach (XmlNode hardwareProject in db.GetElementsByTagName("HardwareProjects")[0].ChildNodes)
            {
                if (EDAxxxx == hardwareProject.Name)
                {
                    if (hardwareProject.Attributes[attribute] != null)
                    {
                        retVal = hardwareProject.Attributes[attribute].Value;
                        break;
                    }
                }
            }

            return retVal;
        }


        private bool SaveProject()
        {
            string projectName = ProjectNameTextBox.Text;

            if (projectName == "Please enter name")
            {
                MessageBox.Show("Please enter name for the project");
                return false;
            }

            if (RepoPathTextBox.Text == "Please enter path")
            {
                MessageBox.Show("Please enter a valid [local] directory path for the GIT repository [C:\\...]");
                return false;
            }


            // If project already exists in the XML doc, then remove it so it can be re-added afresh
            XmlElement projects = (XmlElement)db.GetElementsByTagName("Projects")[0];

            if (projects.GetElementsByTagName(projectName)[0] != null)
                projects.RemoveChild(projects.GetElementsByTagName(projectName)[0]);

            XmlElement project = db.CreateElement(projectName);
            project.SetAttribute("desName", DescriptiveNameTextBox.Text);
            project.SetAttribute("description", DescriptionTextBox.Text);
            project.SetAttribute("repoPath", RepoPathTextBox.Text);
            project.SetAttribute("stage", StageComboBox.Text);
            project.SetAttribute("status", StatusComboBox.Text);

            XmlElement software = db.CreateElement("Software");
            foreach (DataGridViewRow row in TableOfSxxxx.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    if (row.Cells[0].Value.ToString()[0] == 'S')
                    {
                        XmlElement sub = db.CreateElement(row.Cells[0].Value.ToString());

                        string inc = "no";
                        if ((bool)row.Cells[3].Value)
                            inc = "yes";

                        sub.SetAttribute("included", inc);
                        software.AppendChild(sub);
                    }
                }
            }
            project.AppendChild(software);

            XmlElement hardware = db.CreateElement("Hardware");
            foreach (DataGridViewRow row in TableOfSxxxx.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    if (row.Cells[0].Value.ToString()[0] == 'E')
                    {
                        XmlElement sub = db.CreateElement(row.Cells[0].Value.ToString());

                        string inc = "no";
                        if ((bool)row.Cells[3].Value)
                            inc = "yes";

                        sub.SetAttribute("included", inc);
                        hardware.AppendChild(sub);
                    }
                }
            }
            project.AppendChild(hardware);


            XmlElement sprints = db.CreateElement("Sprints");

            foreach (endOfSprint sprint in endOfSprints)
            {
                XmlElement xmlSprint = db.CreateElement(sprint.name);
                xmlSprint.SetAttribute("date", sprint.date);
                xmlSprint.SetAttribute("unplanned", sprint.unplanned);
                xmlSprint.SetAttribute("todo", sprint.todo);
                xmlSprint.SetAttribute("inProgress", sprint.inProgress);
                xmlSprint.SetAttribute("done", sprint.done);
                sprints.AppendChild(xmlSprint);
            }

            project.AppendChild(sprints);

            db.GetElementsByTagName("Projects")[0].AppendChild(project);
            db.Save(db.DocumentElement.GetAttribute("path"));
            return true;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveProject();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void SaveAndCloseButton_Click(object sender, EventArgs e)
        {
            if (SaveProject())
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }


        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (e.KeyChar == (char)Keys.Space);
        }


        private void RemoveSxxxxButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.TableOfSxxxx.SelectedRows)
            {
                if (item.Index < (TableOfSxxxx.Rows.Count - 1))
                    TableOfSxxxx.Rows.RemoveAt(item.Index);
            }

            UpdateTableOfSxxxxSize();
        }

        private void AddSxxxxButton_Click(object sender, EventArgs e)
        {
            SelectSubProject SxxxxForm = new SelectSubProject(db);
            var result = SxxxxForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                string name = SxxxxForm.selectedSubProject;

                foreach (DataGridViewRow row in TableOfSxxxx.Rows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        if (row.Cells[0].Value.ToString() == name)
                        {
                            MessageBox.Show(SxxxxForm.selectedSubProject + " is already included in project " + ProjectNameTextBox.Text);
                            return;
                        }
                    }
                }


                if (name[0] == 'S')
                    TableOfSxxxx.Rows.Add(name, GetSxxxxAttributeFromName(name, "shortName"), GetSxxxxAttributeFromName(name, "platform"), false);
                else
                    TableOfSxxxx.Rows.Add(name, GetEDAxxxxAttributeFromName(name, "shortName"), "NA", false);

                UpdateTableOfSxxxxSize();
            }
        }


        private void TableOfSxxxx_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView d = (DataGridView)sender;
            
            int rowIndex = d.SelectedCells[0].RowIndex;
            EditSoftwareComponent edit = new EditSoftwareComponent(db, TableOfSxxxx.Rows[rowIndex].Cells[0].Value.ToString());
        }
    }
}
