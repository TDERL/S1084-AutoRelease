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
        private XmlDocument projects = new XmlDocument();
        private List<AddSubProject> addSubProjects = new List<AddSubProject>();
        public ProjectInfo(XmlDocument projects, string name)
        {
            InitializeComponent();
            this.projects = projects;

            if (name != "")
            {
                XmlNode project = projects.GetElementsByTagName(name)[0];
                ProjectNameTextBox.Text = name; //  project.Name;
                RepoPathTextBox.Text = project.Attributes["repoPath"].Value;

                foreach (XmlNode node in project)
                {
                    if (SubProjectsLabel.Text == "None")
                        SubProjectsLabel.Text = node.Name;
                    else
                        SubProjectsLabel.Text += "\n" + node.Name;

                    AddSubProject Sxxxx = new AddSubProject();
                    Sxxxx.number = node.Name;
                    Sxxxx.name = node.InnerText;
                    Sxxxx.outputType = node.Attributes["outputType"].Value;
                    Sxxxx.outputPath = node.Attributes["outputPath"].Value;
                    Sxxxx.versionPath = node.Attributes["versionPath"].Value;
                    Sxxxx.releasesPath = node.Attributes["releasesPath"].Value;
                    Sxxxx.archivePath = node.Attributes["archivePath"].Value;
                    Sxxxx.Refresh();
                    addSubProjects.Add(Sxxxx);

                    Button subProjectButton = new Button();

                    int x = 200;
                    int y = 164;
                    subProjectButton.BackColor = Color.FromArgb(243, 111, 247);
                    subProjectButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
                    subProjectButton.Location = new Point(x, y);
                    subProjectButton.Name = "subProjectButton";
                    subProjectButton.Size = new Size(80, 50);
                    subProjectButton.TabIndex = 0;
                    subProjectButton.Text = node.Name;
                    subProjectButton.UseVisualStyleBackColor = false;
                    subProjectButton.Click += OpenSubProjectButton_Click;
                    Controls.Add(subProjectButton);

                    x = x + 100;
                    if (x > 699)
                    {
                        x = 200;
                        y = y + 70;
                    }
                }
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


            XmlElement newProject = projects.CreateElement(projectName);
            newProject.SetAttribute("repoPath", repoPath);

            foreach (AddSubProject project in addSubProjects)
            {
                XmlElement subProject = projects.CreateElement(project.number);
                subProject.InnerText = project.name;
                subProject.SetAttribute("outputType", project.outputType);
                subProject.SetAttribute("outputPath", project.outputPath);
                subProject.SetAttribute("versionPath", project.versionPath);
                subProject.SetAttribute("releasesPath", project.releasesPath);
                subProject.SetAttribute("archivePath", project.archivePath);
                newProject.AppendChild(subProject);
            }

            XmlElement root = projects.DocumentElement;
            root.AppendChild(newProject);

            string xmlPath = root.GetAttribute("path");
            projects.Save(xmlPath);

            return true;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveProject();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveAndCloseButton_Click(object sender, EventArgs e)
        {
            if (SaveProject())
                this.Close();
        }

        private void AddSubProjectButton_Click(object sender, EventArgs e)
        {
            AddSubProject Sxxxx = new AddSubProject();

            var result = Sxxxx.ShowDialog();
            if (result == DialogResult.OK)
            {
                addSubProjects.Add(Sxxxx);

                if (SubProjectsLabel.Text == "None")
                    SubProjectsLabel.Text = Sxxxx.name;
                else
                    SubProjectsLabel.Text += "\n" + Sxxxx.name;
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
