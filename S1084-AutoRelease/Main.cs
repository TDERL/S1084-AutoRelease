using Microsoft.PowerShell.Commands;
using Microsoft.VisualBasic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
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
            EditProjectButton.Enabled = false;
            ReleaseButton.Enabled = false;
            EditSubProjectButton.Enabled = false;
            EditHWComponentButton.Enabled = false;


            string drive = "\\\\ENERGYFP\\General";
            if (Directory.Exists(drive) == false)
            {
                drive = "Z:";
                if (Directory.Exists(drive) == false)
                {
                    drive = "G:";
                    if (Directory.Exists(drive) == false)
                    {
                        MessageBox.Show("Server appears to be dissconnected. Please use Sophos to connect, then try again", "ERROR. Server not connected");
                        Environment.Exit(0);
                    }
                }
            }

            string xmlPath = drive + "\\ERL-Software-Products\\ERL_Software_Database.xml";
            if (File.Exists(xmlPath) == false)
            {
                Directory.CreateDirectory(drive + "\\ERL-Software-Products\\"); // Just a little belts 'n' braces
                XmlTextWriter writer = new XmlTextWriter(xmlPath, null);
                writer.Formatting = Formatting.Indented;
                writer.WriteStartDocument();
                String PItext = "type='text/xsl'";
                writer.WriteProcessingInstruction("xml-stylesheet", PItext);
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
            {
                EditProjectButton.Enabled = true;
                ReleaseButton.Enabled = true;
            }
        }


        private void ReleaseButton_Click(object sender, EventArgs e)
        {
            //ReleaseType releaseType = new ReleaseType();

            //var result = releaseType.ShowDialog();
            //if (result == DialogResult.Yes)
            //{
            NormalRelease normalRelease = new NormalRelease(db, ProjectListComboBox.Text);

            if (normalRelease.Required())
                normalRelease.Show();
            //}
            //else if (result == DialogResult.Ignore)
            //{
            // Mid release
            //    result = 0;
            //}
        }

        //*********************************************************
        //
        //  Sub-Project Additions and Editing
        private void RefreshSubProjectListComboBox()
        {
            SubProjectListComboBox.Items.Clear();

            foreach (XmlNode node in db.GetElementsByTagName("SoftwareProjects")[0])
                SubProjectListComboBox.Items.Add(node.Name);


            HardwareComponentsComboBox.Items.Clear();

            foreach (XmlNode node in db.GetElementsByTagName("HardwareProjects")[0])
                HardwareComponentsComboBox.Items.Add(node.Name);
        }

        private void EditSubProjectButton_Click(object sender, EventArgs e)
        {
            XmlElement SoftwareProjects = (XmlElement)db.GetElementsByTagName("SoftwareProjects")[0];

            if (SoftwareProjects.GetElementsByTagName(SubProjectListComboBox.Text)[0] != null)
            {
                EditSoftwareComponent edit = new EditSoftwareComponent(db, SubProjectListComboBox.Text);
            }
        }

        private void SubProjectListComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SubProjectListComboBox.Text != "")
            {
                EditSubProjectButton.Enabled = true;
            }
        }


        // Name is now a little miss-leading. It no longer auto generates the next number, but simply
        // askes user to enter the number, which they get from Excel Catalogue at:
        // C:\Users\<user name>\ENERGY RESEARCH LAB LTD\ENERGY RESEARCH LAB LTD. - Documents\Catalogues
        private void CreateSubProjectButton_Click(object sender, EventArgs e)
        {
            AddSoftwareComponent Sxxxx = new AddSoftwareComponent();
            var result = Sxxxx.ShowDialog();
            if (result == DialogResult.OK)
            {
                XmlElement xmlSoftwareComponent = db.CreateElement(Sxxxx.number);
                xmlSoftwareComponent.SetAttribute("shortName", Sxxxx.shortName);
                xmlSoftwareComponent.SetAttribute("platform", Sxxxx.platform);
                xmlSoftwareComponent.SetAttribute("active", Sxxxx.active);
                xmlSoftwareComponent.InnerText = Sxxxx.description;
                db.GetElementsByTagName("SoftwareProjects")[0].AppendChild(xmlSoftwareComponent);
                db.Save(db.DocumentElement.GetAttribute("path"));

                RefreshSubProjectListComboBox();
            }
        }

        private void GenerateReportButton_Click(object sender, EventArgs e)
        {
            GenerateReport generate = new GenerateReport();
            generate.ReportHomePage(db);

            foreach (string project in ProjectListComboBox.Items)
            {
                generate.ProjectProgress(db, project);
            }
        }

        private void AddHWComponentButton_Click(object sender, EventArgs e)
        {
            AddHardwareComponent Sxxxx = new AddHardwareComponent();
            var result = Sxxxx.ShowDialog();
            if (result == DialogResult.OK)
            {
                XmlElement xmlHardwareComponent = db.CreateElement(Sxxxx.number);
                xmlHardwareComponent.SetAttribute("shortName", Sxxxx.shortName);
                xmlHardwareComponent.SetAttribute("active", Sxxxx.active);
                xmlHardwareComponent.InnerText = Sxxxx.description;
                db.GetElementsByTagName("HardwareProjects")[0].AppendChild(xmlHardwareComponent);
                db.Save(db.DocumentElement.GetAttribute("path"));

                RefreshSubProjectListComboBox();
            }

        }

        private void EditHWComponentButton_Click(object sender, EventArgs e)
        {
            XmlElement HardwareProjects = (XmlElement)db.GetElementsByTagName("HardwareProjects")[0];

            if (HardwareProjects.GetElementsByTagName(HardwareComponentsComboBox.Text)[0] != null)
            {
                EditHardwareComponent edit = new EditHardwareComponent(db, HardwareComponentsComboBox.Text);
            }
        }

        private void HardwareComponentsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (HardwareComponentsComboBox.Text != "")
            {
                EditHWComponentButton.Enabled = true;
            }
        }
    }
}
