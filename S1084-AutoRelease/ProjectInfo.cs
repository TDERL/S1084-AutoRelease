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
        private int subProjectButton_y = 120;
        private XmlDocument db = new XmlDocument();
        private List<AddSubProject> addSubProjects = new List<AddSubProject>();

        public ProjectInfo(XmlDocument db, string name)
        {
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;
            this.db = db;

            if (name != "") // If editing an existing project then:
            {
                XmlNode project = db.GetElementsByTagName(name)[0];
                ProjectNameTextBox.Text = name; //  project.Name; For example, "DCB1 - Distributed Current Bus 1"
                RepoPathTextBox.Text = project.Attributes["repoPath"].Value;

                foreach (XmlNode node in project)
                {
                    AddSubProject Sxxxx = new AddSubProject(node.Name);
                    Sxxxx.number = node.Name;
                    Sxxxx.shortName = node.InnerText;
                    Sxxxx.outputType = node.Attributes["outputType"].Value;
                    Sxxxx.outputPath = node.Attributes["outputPath"].Value;
                    Sxxxx.versionPath = node.Attributes["versionPath"].Value;
                    Sxxxx.releasesPath = node.Attributes["releasesPath"].Value;
                    Sxxxx.archivePath = node.Attributes["archivePath"].Value;
                    Sxxxx.Refresh();
                    addSubProjects.Add(Sxxxx);

                    AddSubProjectButtonToGroup(node.Name);
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
            string repoPath = RepoPathTextBox.Text;

            if (projectName == "Please enter name")
            {
                MessageBox.Show("Please enter name for the project");
                return false;
            }

            if (repoPath == "Please enter path")
            {
                MessageBox.Show("Please enter a valid [local] directory path for the GIT repository [C:\\...]");
                return false;
            }

            if (addSubProjects.Count == 0)
            {
                MessageBox.Show("There must be at least one Sxxxx sub-project added");
                return false;
            }


            XmlElement xmlProject;

            if (db.GetElementsByTagName(projectName).Count == 0)
            {
                xmlProject = db.CreateElement(projectName);
                xmlProject.SetAttribute("repoPath", repoPath);

                foreach (AddSubProject project in addSubProjects)
                {
                    XmlElement subProject = db.CreateElement(project.number);
                    subProject.InnerText = project.shortName;
                    subProject.SetAttribute("outputType", project.outputType);
                    subProject.SetAttribute("outputPath", project.outputPath);
                    subProject.SetAttribute("versionPath", project.versionPath);
                    subProject.SetAttribute("releasesPath", project.releasesPath);
                    subProject.SetAttribute("archivePath", project.archivePath);
                    xmlProject.AppendChild(subProject);
                }

             }
            else
            {
                xmlProject = (XmlElement)db.GetElementsByTagName(projectName)[0];
                xmlProject.SetAttribute("repoPath", repoPath);

                foreach (AddSubProject subProject in addSubProjects)
                {
                    XmlElement xmlSubProject;

                    if (xmlProject.GetElementsByTagName(subProject.number).Count == 0) 
                        xmlSubProject = db.CreateElement(subProject.number);
                    else
                        xmlSubProject = (XmlElement)db.GetElementsByTagName(subProject.number)[0];
                    
                    xmlSubProject.InnerText = subProject.shortName;
                    xmlSubProject.SetAttribute("outputType", subProject.outputType);
                    xmlSubProject.SetAttribute("outputPath", subProject.outputPath);
                    xmlSubProject.SetAttribute("versionPath", subProject.versionPath);
                    xmlSubProject.SetAttribute("releasesPath", subProject.releasesPath);
                    xmlSubProject.SetAttribute("archivePath", subProject.archivePath);
                    xmlProject.AppendChild(xmlSubProject);
                }
            }

            XmlElement root = db.DocumentElement;
            root.AppendChild(xmlProject);
            string xmlPath = root.GetAttribute("path");
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
            AddSubProject Sxxxx = new AddSubProject("TBD");

            var result = Sxxxx.ShowDialog();
            if (result == DialogResult.OK)
            {
                addSubProjects.Add(Sxxxx);
                AddSubProjectButtonToGroup(Sxxxx.number);
            }
        }

        private void OpenSubProjectButton_Click(object sender, EventArgs e)
        {
            Button subProjectButton = (Button)sender;

            foreach (AddSubProject subProject in addSubProjects)
            {
                if (subProject.number == subProjectButton.Text)
                    subProject.Show();
            }
        }
    }
}
