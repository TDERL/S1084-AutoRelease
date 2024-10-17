using System.Xml;
using System.Xml.Linq;

namespace S1084_AutoRelease
{
    public partial class Main : Form
    {
        private XmlDocument db = new XmlDocument();
        public Main()
        {
            InitializeComponent();
            EditProjectButton.Visible = false;

            string xmlPath = "C:\\Projects\\Windows Apps\\S1084-AutoRelease\\XML\\ERL_SW_Projects_DB.xml";
            if (File.Exists(xmlPath) == false)
            {
                XmlTextWriter writer = new XmlTextWriter(xmlPath, null);
                writer.Formatting = Formatting.Indented;
                writer.WriteStartDocument();
                String PItext = "type='text/xsl'";
                writer.WriteProcessingInstruction("xml-stylesheet", PItext);
                //writer.WriteDocType("Projects", null, null, null);
                writer.WriteComment("S1084, Projects DB and Auto Release");
                writer.WriteStartElement("S1084");
                writer.WriteAttributeString("path", xmlPath);
                writer.WriteStartElement("Projects");
                writer.WriteEndElement();   // Projects
                writer.WriteStartElement("SubProjects");
                writer.WriteEndElement();   // SubProjects
                writer.WriteEndElement();   // S1084
                writer.WriteEndDocument();
                writer.Close();
            }

            db.Load(xmlPath);
            RefreshProjectListComboBox();
        }

        private void RefreshProjectListComboBox()
        {
            ProjectListComboBox.Items.Clear();

            foreach (XmlNode node in db.DocumentElement.ChildNodes)
                ProjectListComboBox.Items.Add(node.Name);
        }

        private void CreateProjectButton_Click(object sender, EventArgs e)
        {
            ProjectInfo newProject = new ProjectInfo(db, "");

            var result = newProject.ShowDialog();
            if (result == DialogResult.OK)
                RefreshProjectListComboBox();
        }

        private void EditProjectButton_Click(object sender, EventArgs e)
        {
            ProjectInfo newProject = new ProjectInfo(db, ProjectListComboBox.Text);

            var result = newProject.ShowDialog();
            if (result == DialogResult.OK)
                RefreshProjectListComboBox();
        }

        private void ProjectListComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ProjectListComboBox.Text != "")
                EditProjectButton.Visible = true;
        }

        private void CreateSubProjectButton_Click(object sender, EventArgs e)
        {
            AddSubProject Sxxxx = new AddSubProject();

            var result = Sxxxx.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (db.GetElementsByTagName(Sxxxx.number).Count == 0)
                {
                    XmlElement xmlSubProject = db.CreateElement(Sxxxx.number);
                    xmlSubProject.SetAttribute("shortName", Sxxxx.shortName);
                    xmlSubProject.SetAttribute("platform", Sxxxx.platform);
                    xmlSubProject.SetAttribute("outputType", Sxxxx.outputType);
                    xmlSubProject.SetAttribute("outputPath", Sxxxx.outputPath);
                    xmlSubProject.SetAttribute("versionPath", Sxxxx.versionPath);
                    xmlSubProject.SetAttribute("releasesPath", Sxxxx.releasesPath);
                    xmlSubProject.SetAttribute("archivePath", Sxxxx.archivePath);
                    xmlSubProject.InnerText = Sxxxx.description;
                    db.GetElementsByTagName("SubProjects")[0].AppendChild(xmlSubProject);
                    db.Save(db.DocumentElement.GetAttribute("path"));
                }
                else
                    MessageBox.Show("Sub-Project '" + Sxxxx.number + "' already exists");
            }
        }
    }
}
