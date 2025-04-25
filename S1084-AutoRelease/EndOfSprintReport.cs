using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Management.Automation;
using System.IO;
using System.Collections.ObjectModel;
using System.Security.Policy;
using System.Xml.Linq;
using System.Reflection.Emit;


namespace S1084_AutoRelease
{
    public partial class EndOfSprintReport : Form
    {
        XmlDocument db;
        private string projectName = "";
        private string stage = "";
        private string version = "";
        private int revision = 0;
        // XmlElement project;
        // XmlElement sprints;

        public EndOfSprintReport(XmlDocument db, string name)
        {
            InitializeComponent();

            projectName = name;
            this.db = db;

            XmlElement project = (XmlElement)db.GetElementsByTagName(name)[0];

            stage = project.Attributes["stage"].Value;

            switch (stage)
            {
                case "White":
                case "white":
                    stage = "W";
                    break;

                case "Red":
                case "red":
                    stage = "R";
                    break;

                case "Blue":
                case "blue":
                    stage = "B";
                    break;

                case "Green":
                case "green":
                    stage = "G";
                    break;

                case "Black":
                case "black":
                    stage = "K";
                    break;
            }

            revision = 1;
            XmlElement sprints = (XmlElement)project.GetElementsByTagName("Sprints")[0];

            if ((sprints != null) && (sprints.ChildNodes.Count > 0))
            {
                string last = sprints.ChildNodes[sprints.ChildNodes.Count - 1].Name;

                if (last[0] == stage[0])
                {
                    last = last.Substring(1);
                    revision = Int32.Parse(last);
                    revision += 1;
                }
            }

            version = stage + revision.ToString();

            InitInfoLabel.Text = "You are about to complete " + version + ". Before closing Sprint " + version + ":\n" +
                "1. Enter number of stories and points for project and all components in table below:\n" +
                "2. Ensure GIT Develop is up to date and then tagged with " + version + "\n";

            XmlElement softwareComponents = (XmlElement)project.GetElementsByTagName("Software")[0];
            XmlElement hardwareComponents = (XmlElement)project.GetElementsByTagName("Hardware")[0];

            ComponentsTable.Rows.Add("Whole Project", 0, 0, 0, 0);

            if (softwareComponents != null)
            {
                for (int i = 0; i < softwareComponents.ChildNodes.Count; i++)
                    ComponentsTable.Rows.Add(softwareComponents.ChildNodes[i].Name, 0, 0, 0, 0);
            }

            if (hardwareComponents != null)
            {
                for (int i = 0; i < hardwareComponents.ChildNodes.Count; i++)
                    ComponentsTable.Rows.Add(hardwareComponents.ChildNodes[i].Name, 0, 0, 0, 0);
            }

            var height = 40;
            foreach (DataGridViewRow dr in ComponentsTable.Rows)
            {
                height += dr.Height;
            }

            ComponentsTable.Height = height;
        }



        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OkayButton_Click(object sender, EventArgs e)
        {
            if ((BacklogTextBox.Text == "") ||
                (ToDoTextBox.Text == "") ||
                (InProgressTextBox.Text == "") ||
                (DoneTextBox.Text == ""))
            {
                MessageBox.Show("Numerical value must be entered in all four fields", "ERROR");
                return;
            }

            this.DialogResult = DialogResult.Abort;

            XmlElement project = (XmlElement)db.GetElementsByTagName(projectName)[0];
            XmlNode software = project.GetElementsByTagName("Software")[0];

            //if (software == null)
            //{
            //    MessageBox.Show("Release process aborted: There is no software included in " + projectName);
            //    this.Close();
            //}

            //MessageBox.Show("Please be patient, this may take a few seconds");

            //// STEP 1 - Check out Develop Branch and make sure it is up to date
            //string repoPath = db.GetElementsByTagName(projectName)[0].Attributes["repoPath"].Value;

            //using (PowerShell powershell = PowerShell.Create())
            //{
            //    powershell.AddScript($"cd {repoPath}");
            //    powershell.AddScript(@"git fetch");
            //    powershell.AddScript(@"git checkout Develop");

            //    Collection<PSObject> results = powershell.Invoke();

            //    string[] response = results[0].BaseObject.ToString().Split("'");

            //    if (response[0] == "Your branch is behind ")
            //    {
            //        powershell.AddScript(@"git pull");
            //        powershell.Invoke();
            //        this.DialogResult = DialogResult.OK;
            //    }
            //    else if (response[0] == "Your branch is up to date with ")
            //    {
            //        this.DialogResult = DialogResult.OK;
            //    }
            //    else
            //    {
            //        MessageBox.Show("Release process aborted:\n\n" + response[0]);
            //    }


            //    // STEP 2 - Tag Develop Branch with latest release version
            //    // Only continue if fetching and updating Develop branch was successful
            //    if (this.DialogResult == DialogResult.OK)
            //    {
            //        powershell.AddScript($"git tag {version}");
            //        powershell.AddScript(@"git push origin --tags");
            //        results = powershell.Invoke();

            //        // STEP 3 - Tell user to build: Would be much nicer if we could auto build.
            //        string message = "WARNING: ONLY Click OK AFTER building ALL software!\n\nPlease Build/Compile:\n\n";

            //        XmlElement softwareProjects = (XmlElement)db.GetElementsByTagName("SoftwareProjects")[0];

            //        foreach (XmlNode Sxxxx in software)
            //        {
            //            bool ok = false;

            //            foreach (XmlNode softwareProject in softwareProjects)
            //            {
            //                if (Sxxxx.Name == softwareProject.Name)
            //                {
            //                    ok = true;

            //                    if (softwareProject.Attributes["outputType"].Value != "TBD")
            //                    {
            //                        message += Sxxxx.Name;
            //                        message += "\n";
            //                    }

            //                    break;
            //                }

            //            }

            //            if (ok == false)
            //            {
            //                MessageBox.Show("Release process aborted: Unknown software " + Sxxxx.Name);
            //                this.Close();
            //            }
            //        }

            //        if (MessageBox.Show(message, "Build", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            //        {
            //            MessageBox.Show("Release process aborted: User chose not to build software");
            //        }
            //        else
            //        {
            //            // Here we have to assume user has built all software as requested
            //            // STEP 4 - Archive current releases and save a copy of new output files to the releases folders
            //            foreach (XmlNode Sxxxx in software)
            //            {
            //                foreach (XmlNode softwareProject in softwareProjects)
            //                {
            //                    if (Sxxxx.Name == softwareProject.Name)
            //                    {
            //                        // Found the right Software Project, so can now get all the paths needed to release

            //                        string fileExtension = softwareProject.Attributes["outputType"].Value;
            //                        string outputPath = softwareProject.Attributes["outputPath"].Value;
            //                        //string archivePath = releasesPath + "\\Archive";

            //                        // If ext or output path are TBD then don't try to release it
            //                        //if ((fileExtension != "TBD") && (outputPath != "TBD")) // TODO: Replace this with a active status attribute
            //                        //if (softwareProject.Attributes["active"].Value == "active")
            //                        if (Sxxxx.Attributes["included"].Value == "yes")
            //                        {
            //                            string desc = db.GetElementsByTagName(projectName)[0].Attributes["desName"].Value;
            //                            Paths paths = new Paths(db);
            //                            string releasesPath = paths.GetReleases(projectName) + version + "\\" + Sxxxx.Name + " - " + softwareProject.Attributes["shortName"].Value;
            //                            Directory.CreateDirectory(releasesPath); // Just a little belts 'n' braces

            //                            // STEP 4a - Archive
            //                            //string[] files = Directory.GetFiles(releasesPath, "*" + fileExtension);

            //                            //foreach (var file in files)
            //                            //    File.Move(file, Path.Combine(archivePath, Path.GetFileName(file)));

            //                            // STEP 4 - Release
            //                            string[] files = Directory.GetFiles(outputPath, "*" + fileExtension);

            //                            foreach (var file in files)
            //                            {
            //                                string newFileName = Path.GetFileName(file).Split('.')[0] + "__" + Sxxxx.Name + "-" + version + fileExtension;
            //                                File.Copy(Path.Combine(outputPath, Path.GetFileName(file)), Path.Combine(releasesPath, newFileName));
            //                            }
            //                        }
            //                     }

            //                }
            //            }
            //            

            // Final STEP - Add release to XML DB and generate a new progress/releases report
            XmlElement newRelease = db.CreateElement(version);
            newRelease.SetAttribute("date", DateOnly.FromDateTime(DateTime.Now).ToString());
            newRelease.SetAttribute("unplanned", BacklogTextBox.Text);
            newRelease.SetAttribute("todo", ToDoTextBox.Text);
            newRelease.SetAttribute("inProgress", InProgressTextBox.Text);
            newRelease.SetAttribute("done", DoneTextBox.Text);
            project.GetElementsByTagName("Sprints")[0].AppendChild(newRelease);
            db.Save(db.DocumentElement.GetAttribute("path"));

            GenerateReport generate = new GenerateReport();
            generate.ReportHomePage(db);
            generate.ProjectProgress(db, projectName);
            //     }

            //  }
            // }




            this.Close();
        }

        private void ComponentsTable_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex != 0)
            {
                int i;

                if (!int.TryParse(Convert.ToString(e.FormattedValue), out i))
                {
                    e.Cancel = true;
                    MessageBox.Show("Please enter numeric value only");
                }
            }
        }
    }
}
