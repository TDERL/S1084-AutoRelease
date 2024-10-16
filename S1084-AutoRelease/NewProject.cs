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


namespace S1084_AutoRelease
{
    public partial class NewProject : Form
    {
        private List<AddSubProject> addSubProjects = new List<AddSubProject>();
        public NewProject()
        {
            InitializeComponent();
        }


        private bool SaveProject()
        {
            string projectName = ProjectNameTextBox.Text;
            string projectPath = ProjectPathTextBox.Text;
            string repoPath = RepoPathTextBox.Text;

            if (projectName == "Please enter name")
            {
                MessageBox.Show("Please enter name for the project");
                return false;
            }

            if (projectPath == "Please enter path")
            {
                MessageBox.Show("Please enter a valid directory path for the project [C:\\...]");
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

            if (projectPath.Last() != '\\')
                projectPath += '\\';

            XmlTextWriter writer = new XmlTextWriter(projectPath + projectName + ".xml", null);
            writer.Formatting = Formatting.Indented;
            writer.WriteStartDocument();
            String PItext = "type='text/xsl' href='book.xsl'";
            writer.WriteProcessingInstruction("xml-stylesheet", PItext);
            writer.WriteDocType("book", null, null, "<!ENTITY h 'hardcover'>");
            writer.WriteComment("sample XML");
            writer.WriteStartElement(projectName);
            writer.WriteAttributeString("path", projectPath);
            writer.WriteAttributeString("repo", repoPath);

            foreach (AddSubProject project in addSubProjects)
            {
                writer.WriteStartElement(project.name);
                writer.WriteAttributeString("type", project.outputType);
                writer.WriteAttributeString("type", project.outputPath);
                writer.WriteAttributeString("type", project.versionPath);
                writer.WriteAttributeString("type", project.releasesPath);
                writer.WriteAttributeString("type", project.archivePath);
                writer.WriteEndElement();
            }

            writer.WriteEndElement();   // projectName
            writer.WriteEndDocument();
            writer.Close();

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

            addSubProjects.Add(Sxxxx);

            var result = Sxxxx.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (SubProjectsLabel.Text == "None")
                    SubProjectsLabel.Text = Sxxxx.name;
                else
                    SubProjectsLabel.Text += "\n" + Sxxxx.name;
            }
        }
    }
}
