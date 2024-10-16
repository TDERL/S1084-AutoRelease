using System.Xml;
using System.Xml.Linq;

namespace S1084_AutoRelease
{
    public partial class Main : Form
    {
        private XmlDocument projects = new XmlDocument();
        public Main()
        {
            InitializeComponent();
            EditProjectButton.Visible = false;

            string xmlPath = "C:\\Projects\\Windows Apps\\S1084-AutoRelease\\XML\\Projects.xml";
            if (File.Exists(xmlPath) == false)
            {
                XmlTextWriter writer = new XmlTextWriter(xmlPath, null);
                writer.Formatting = Formatting.Indented;
                writer.WriteStartDocument();
                String PItext = "type='text/xsl' href='Projects.xsl'";
                writer.WriteProcessingInstruction("xml-stylesheet", PItext);
                writer.WriteDocType("Projects", null, null, null);
                writer.WriteComment("S1084, Projects for Auto Release");
                writer.WriteStartElement("Projects");
                writer.WriteAttributeString("path", xmlPath);
                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Close();

                ProjectListComboBox.Items.Clear();
            }

            projects.Load(xmlPath);

            foreach (XmlNode node in projects.DocumentElement.ChildNodes)
            {
                ProjectListComboBox.Items.Add(node.Name);
            }
        }

        private void CreateProjectButton_Click(object sender, EventArgs e)
        {
            ProjectInfo newProject = new ProjectInfo(projects, "");
            newProject.Show();
        }

        private void EditProjectButton_Click(object sender, EventArgs e)
        {
            ProjectInfo newProject = new ProjectInfo(projects, ProjectListComboBox.Text);
            newProject.Show();
        }

        private void ProjectListComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ProjectListComboBox.Text != "")
            {
                EditProjectButton.Visible = true;
            }
        }

        
    }
}
