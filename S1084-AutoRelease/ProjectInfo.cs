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


namespace S1084_AutoRelease
{
    public partial class ProjectInfo : Form
    {
        private int subProjectButton_x = 20;
        private int subProjectButton_y = 140;
        private XmlDocument db = new XmlDocument();
        private List<string> subProjectNames = new List<string>();

        public ProjectInfo(XmlDocument db, string name)
        {
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;
            this.db = db;

            if (name != "") // If editing an existing project then:
            {
                XmlElement projects = (XmlElement)db.GetElementsByTagName("Projects")[0];
                XmlNode project = projects.GetElementsByTagName(name)[0];
                ProjectNameTextBox.Text = name; //  For example, "DCB1"
                DescriptiveNameTextBox.Text = project.Attributes["desName"].Value; //  For example, "Distributed Current Bus"
                DescriptionTextBox.Text = project.Attributes["description"].Value;
                RepoPathTextBox.Text = project.Attributes["repoPath"].Value;
                StageComboBox.Text = project.Attributes["stage"].Value;
                StatusComboBox.Text = project.Attributes["status"].Value;

                XmlElement Software = (XmlElement)projects.GetElementsByTagName("Software")[0];
                foreach (XmlNode node in Software)
                {
                    AddSubProjectButtonToGroup(node.Name);
                    subProjectNames.Add(node.Name);
                }
            }
        }

        private void AddSubProjectButtonToGroup(string name)
        {
            Button subProjectButton = new Button();
            subProjectButton.BackColor = Color.FromArgb(243, 111, 247);
            subProjectButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            subProjectButton.Location = new Point(subProjectButton_x, subProjectButton_y);
            subProjectButton.Name = "subProjectButton";
            subProjectButton.Size = new Size(80, 50);
            subProjectButton.TabIndex = 0;
            subProjectButton.Text = name;
            subProjectButton.UseVisualStyleBackColor = false;
            subProjectButton.Click += OpenSubProjectButton_Click;
            SubProjectsGroupBox.Controls.Add(subProjectButton);

            subProjectButton_x = subProjectButton_x + 100;
            if (subProjectButton_x > 621)
            {
                subProjectButton_x = 20;
                subProjectButton_y = subProjectButton_y + 70;
            }
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

            XmlElement projects = (XmlElement)db.GetElementsByTagName("Projects")[0];
            XmlElement xmlProject;

            if (projects.GetElementsByTagName(projectName).Count == 0) // Checking is project doesn't already exist
                xmlProject = db.CreateElement(projectName);
            else
                xmlProject = (XmlElement)db.GetElementsByTagName(projectName)[0];

            xmlProject.SetAttribute("desName", DescriptiveNameTextBox.Text);
            xmlProject.SetAttribute("description", DescriptionTextBox.Text);
            xmlProject.SetAttribute("repoPath", RepoPathTextBox.Text);
            xmlProject.SetAttribute("stage", StageComboBox.Text);
            xmlProject.SetAttribute("status", StatusComboBox.Text);


            if (projects.GetElementsByTagName(projectName).Count == 0) // Checking if project doesn't already exist
            {
                if (subProjectNames.Count > 0)
                {
                    XmlElement subProjectElement = db.CreateElement("Software");

                    foreach (string subProjectName in subProjectNames)
                    {
                        XmlElement newSub = db.CreateElement(subProjectName);
                        subProjectElement.AppendChild(newSub);
                    }

                    xmlProject.AppendChild(subProjectElement);
                }
            }
            else // Else project does exists
            {
                if (subProjectNames.Count > 0)
                {
                    if (projects.GetElementsByTagName("Software").Count == 0)
                    {
                        XmlElement subProjectElement = db.CreateElement("Software");

                        foreach (string subProjectName in subProjectNames)
                        {
                            XmlElement newSub = db.CreateElement(subProjectName);
                            subProjectElement.AppendChild(newSub);
                        }

                        xmlProject.AppendChild(subProjectElement);
                    }
                    else
                    {
                        XmlElement subProjectElement = (XmlElement)projects.GetElementsByTagName("Software")[0];

                        foreach (string subProjectName in subProjectNames)
                        {
                            if (subProjectElement.GetElementsByTagName(subProjectName).Count == 0)
                            {
                                XmlElement newSub = db.CreateElement(subProjectName);
                                subProjectElement.AppendChild(newSub);
                            }
                        }
                    }
                }
            }

            if (projects.GetElementsByTagName(projectName).Count == 0)
                projects.AppendChild(xmlProject);

            //XmlElement root = db.DocumentElement;
            //root.AppendChild(xmlProject);
            string xmlPath = db.DocumentElement.GetAttribute("path");
            db.Save(xmlPath);

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

        private void AddSubProjectButton_Click(object sender, EventArgs e)
        {
            SelectSubProject Sxxxx = new SelectSubProject(db);
            var result = Sxxxx.ShowDialog();
            if (result == DialogResult.OK)
            {
                foreach (string subProjectName in subProjectNames)
                {
                    if (subProjectName == Sxxxx.selectedSubProject)
                    {
                        MessageBox.Show(Sxxxx.selectedSubProject + " is already included in project " + ProjectNameTextBox.Text);
                        return;
                    }
                }

                AddSubProjectButtonToGroup(Sxxxx.selectedSubProject);
                subProjectNames.Add(Sxxxx.selectedSubProject);
            }
        }
        private void RemoveSubProjectButton_Click(object sender, EventArgs e)
        {
            SelectSubProject Sxxxx = new SelectSubProject(db);
            var result = Sxxxx.ShowDialog();
            if (result == DialogResult.OK)
            {
                foreach (string subProjectName in subProjectNames)
                {
                    if (subProjectName == Sxxxx.selectedSubProject)
                    {
                        subProjectNames.Remove(subProjectName);
                        SubProjectsGroupBox.Controls.Clear();

                        SubProjectsGroupBox.Controls.Add(RemoveSubProjectButton);
                        SubProjectsGroupBox.Controls.Add(AddSubProjectButton);
                        subProjectButton_x = 20;
                        subProjectButton_y = 140;

                        foreach (string subProjectRemaining in subProjectNames)
                            AddSubProjectButtonToGroup(subProjectRemaining);

                        return; 
                    }
                }

                MessageBox.Show("Cannot remove " + Sxxxx.selectedSubProject + " as is not included in project " + ProjectNameTextBox.Text);
            }
        }

        private void OpenSubProjectButton_Click(object sender, EventArgs e)
        {
            //Button subProjectButton = (Button)sender;

            //foreach (AddSubProject subProject in addSubProjects)
            //{
            //    if (subProject.number == subProjectButton.Text)
            //        subProject.Show();
            //}
        }
        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (e.KeyChar == (char)Keys.Space);
        }
    }
}
