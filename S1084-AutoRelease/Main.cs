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

            string xmlPath = "C:\\ERL-Software-Products\\ERL_SW_Projects_DB.xml";
            if (File.Exists(xmlPath) == false)
            {
                Directory.CreateDirectory("C:\\ERL-Software-Products\\"); // Just a little belts 'n' braces
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
            ReleaseType releaseType = new ReleaseType();

            var result = releaseType.ShowDialog();
            if (result == DialogResult.Yes)
            {
                NormalRelease normalRelease = new NormalRelease(db, ProjectListComboBox.Text);

                if (normalRelease.Required())
                    normalRelease.Show();
            }
            else if (result == DialogResult.Ignore)
            {
                // Mid release
                result = 0;
            }
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
                EditSubProject edit = new EditSubProject(db, SubProjectListComboBox.Text);
            }
        }

        private void SubProjectListComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SubProjectListComboBox.Text != "")
            {
                EditSubProjectButton.Enabled = true;
            }
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
                xmlSubProject.SetAttribute("releasesPath", Sxxxx.releasesPath);
                xmlSubProject.InnerText = Sxxxx.description;
                db.GetElementsByTagName("SoftwareProjects")[0].AppendChild(xmlSubProject);
                db.Save(db.DocumentElement.GetAttribute("path"));

                RefreshSubProjectListComboBox();
            }
        }

        private void GenerateReportButton_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK)
                {
                    string path = fbd.SelectedPath + "\\";

                    XmlElement softwareProjects = (XmlElement)db.GetElementsByTagName("SoftwareProjects")[0];

                    using (FileStream fs = new FileStream(path + "Software Master Part Number List.html", FileMode.Create))
                    {
                        using (StreamWriter w = new StreamWriter(fs))
                        {
                            w.WriteLine("<!DOCTYPE html>");
                            w.WriteLine("<html>");
                            w.WriteLine("<style>");
                            w.WriteLine("table, th, td {border:1px solid black; border-collapse: collapse; border-color: #96D4D4;}");
                            w.WriteLine("tr:hover {background-color: #D6EEEE;}");
                            w.WriteLine("td {text-align: center;}");
                            w.WriteLine("th {background-color: #D6EEEE;}");
                            w.WriteLine("</style>");
                            w.WriteLine("<body style=\"font-family: verdana\">");
                            w.WriteLine("<h2 style=\"color:orange \">ERL Software Master Part Number List</h2>");
                            w.WriteLine("Generated on: " + DateTime.Now + "<br>");
                            w.WriteLine("Generated by: " + Environment.UserName + ", using S1084");
                            w.WriteLine("<br><br>");
                            w.WriteLine("<table>");
                            w.WriteLine("<tr><th>Number</th><th>Platform</th><th>Short Description</th><th>Description</th></th>");

                            foreach (XmlNode Sxxxx in softwareProjects)
                            {
                                w.WriteLine("<tr>");
                                w.WriteLine("<td style=\"min-width: 200px\">" + Sxxxx.Name + "</td>");
                                w.WriteLine("<td style=\"min-width: 200px\">" + Sxxxx.Attributes["platform"].Value + "</td>");
                                w.WriteLine("<td style=\"min-width: 200px\">" + Sxxxx.Attributes["shortName"].Value + "</td>");
                                w.WriteLine("<td style=\"min-width: 200px\">" + Sxxxx.InnerText + "</td>");
                                w.WriteLine("</tr>");
                            }

                            w.WriteLine("</table>");
                            w.WriteLine("");
                            w.WriteLine("</body>");
                            w.WriteLine("</html>");
                        }
                    }

                    MessageBox.Show("Software Master Part Number List.html generated");
                }
            }
        }
    }
}
