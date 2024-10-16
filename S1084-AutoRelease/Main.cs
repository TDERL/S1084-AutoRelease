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

            string xmlPath = "C:\\Projects\\Windows Apps\\S1084-AutoRelease\\XML";
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
            }

            projects.Load(xmlPath);
        }

        private void CreateProjectButton_Click(object sender, EventArgs e)
        {
           NewProject newProject = new NewProject(projects);
           newProject.Show();
        }
    }
}
