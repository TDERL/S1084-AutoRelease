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
            EditSubProjectButton.Visible = false;

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
                writer.WriteStartElement("SoftwareProjects");
                writer.WriteEndElement();   // SoftwareProjects
                writer.WriteEndElement();   // S1084
                writer.WriteEndDocument();
                writer.Close();
            }

            db.Load(xmlPath);
            RefreshProjectListComboBox();
            RefreshSubProjectListComboBox();
        }

        //*********************************************************
        //
        //  [main] Project Additions and Editing
        private void RefreshProjectListComboBox()
        {
            ProjectListComboBox.Items.Clear();
            XmlNode projects = db.GetElementsByTagName("Projects")[0];

            foreach (XmlNode project in projects)
                ProjectListComboBox.Items.Add(project.Name);
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

        //*********************************************************
        //
        //  Sub-Project Additions and Editing
        private void RefreshSubProjectListComboBox()
        {
            SubProjectListComboBox.Items.Clear();

            foreach (XmlNode node in db.GetElementsByTagName("SoftwareProjects")[0])
                SubProjectListComboBox.Items.Add(node.Name);
        }

        private void EditSubProjectButton_Click(object sender, EventArgs e)
        {
            XmlElement SoftwareProjects = (XmlElement)db.GetElementsByTagName("SoftwareProjects")[0];

            if (SoftwareProjects.GetElementsByTagName(SubProjectListComboBox.Text)[0] != null)
            {
                AddSubProject Sxxxx = new AddSubProject(SubProjectListComboBox.Text);
                XmlNode node = SoftwareProjects.GetElementsByTagName(SubProjectListComboBox.Text)[0];
                Sxxxx.number = node.Name;
                Sxxxx.shortName = node.Attributes["shortName"].Value;
                Sxxxx.platform = node.Attributes["platform"].Value;
                Sxxxx.outputType = node.Attributes["outputType"].Value;
                Sxxxx.outputPath = node.Attributes["outputPath"].Value;
                Sxxxx.versionPath = node.Attributes["versionPath"].Value;
                Sxxxx.releasesPath = node.Attributes["releasesPath"].Value;
                Sxxxx.archivePath = node.Attributes["archivePath"].Value;
                Sxxxx.description = node.InnerText;
                Sxxxx.Refresh();

                var result = Sxxxx.ShowDialog();
                if (result == DialogResult.OK)
                {
                    node.Attributes["shortName"].Value = Sxxxx.shortName;
                    node.Attributes["platform"].Value = Sxxxx.platform;
                    node.Attributes["outputType"].Value = Sxxxx.outputType;
                    node.Attributes["outputPath"].Value = Sxxxx.outputPath;
                    node.Attributes["versionPath"].Value = Sxxxx.versionPath;
                    node.Attributes["releasesPath"].Value = Sxxxx.releasesPath;
                    node.Attributes["archivePath"].Value = Sxxxx.archivePath;
                    node.InnerText = Sxxxx.description;
                    db.Save(db.DocumentElement.GetAttribute("path"));
                }
            }
        }

        private void SubProjectListComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SubProjectListComboBox.Text != "")
                EditSubProjectButton.Visible = true;
        }

        private string CalculateNewSubProjectNumber()
        {
            var noOfSubProjects = SubProjectListComboBox.Items.Count;

            if (noOfSubProjects == 0)
                return "S1049";

            string last = SubProjectListComboBox.Items[noOfSubProjects - 1].ToString();
            last = last.Substring(1); // Remove 1st char (IE remove the 'S')
            int x = Int32.Parse(last);
            x += 1;
            last = "S" + x.ToString();
            return last;
        }

        private void CreateSubProjectButton_Click(object sender, EventArgs e)
        {
            AddSubProject Sxxxx = new AddSubProject(CalculateNewSubProjectNumber());
            var result = Sxxxx.ShowDialog();
            if (result == DialogResult.OK)
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
                db.GetElementsByTagName("SoftwareProjects")[0].AppendChild(xmlSubProject);
                db.Save(db.DocumentElement.GetAttribute("path"));

                RefreshSubProjectListComboBox();
            }
        }

    }
}
