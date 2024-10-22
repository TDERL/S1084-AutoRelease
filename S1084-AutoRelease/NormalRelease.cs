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


namespace S1084_AutoRelease
{
    public partial class NormalRelease : Form
    {
        XmlDocument db;
        private string projectName = "";
        private string stage = "";
        private string version = "";
        private int revision = 0;
        XmlElement project;
        XmlElement sprints;

        public NormalRelease(XmlDocument db, string name)
        {
            InitializeComponent();

            projectName = name;
            this.db = db;

            project = (XmlElement)db.GetElementsByTagName(name)[0];

            stage = project.Attributes["stage"].Value;

            switch (stage)
            {
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

            sprints = (XmlElement)project.GetElementsByTagName("Sprints")[0];

            if (sprints.ChildNodes.Count == 0)
            {
                revision = 1;
            }
            else
            {
                string last = sprints.ChildNodes[sprints.ChildNodes.Count - 1].Name;
                last = last.Substring(1);
                revision = Int32.Parse(last);
                revision += 1;
            }

            version = stage + revision.ToString();


            // Before closing the current Sprint,
            // enter number of stories in:
            InitInfoLabel.Text = "You are about to release " + version + "\nBefore closing Sprint " + version + "\nenter number of stories in:";
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
            this.DialogResult = DialogResult.Abort;

            XmlNode software = project.GetElementsByTagName("Software")[0];
            if (software == null)
            {
                MessageBox.Show("Release process aborted: There is no software included in " + projectName);
                this.Close();
            }

            MessageBox.Show("Please be patient, this may take a few seconds");

            // STEP 1 - Check out Develop Branch and make sure it is up to date
            string repoPath = db.GetElementsByTagName(projectName)[0].Attributes["repoPath"].Value;

            using (PowerShell powershell = PowerShell.Create())
            {
                powershell.AddScript($"cd {repoPath}");
                powershell.AddScript(@"git fetch");
                powershell.AddScript(@"git checkout Develop");

                Collection<PSObject> results = powershell.Invoke();

                string[] response = results[0].BaseObject.ToString().Split("'");

                if (response[0] == "Your branch is behind ")
                {
                    powershell.AddScript(@"git pull");
                    powershell.Invoke();
                    this.DialogResult = DialogResult.OK;
                }
                else if (response[0] == "Your branch is up to date with ")
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Release process aborted:\n\n" + response[0]);
                }

 
                // STEP 2 - Tag Develop Branch with latest release version
                // Only continue if fetching and updating Develop branch was successful
                if (this.DialogResult == DialogResult.OK)
                {
                    powershell.AddScript($"git tag {version}");
                    powershell.AddScript(@"git push origin --tags");
                    results = powershell.Invoke();

                    // STEP 3 - Tell user to build: Would be much nicer if we could auto build.
                    string message = "WARNING: ONLY Click OK AFTER building ALL software!\n\nPlease Build/Compile:\n\n";
                    foreach (XmlNode Sxxxx in software)
                    {
                        message += Sxxxx.Name;
                        message += "\n";
                    }
  
                    if (MessageBox.Show(message, "Build", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                    {
                        MessageBox.Show("Release process aborted: User chose not to build software");
                    }
                    else
                    {
                        // Here we have to assume user has built all software as requested
                        // STEP 4 - Archive current releases and save a copy of new output files to the releases folders

                        XmlElement softwareProjects = (XmlElement)db.GetElementsByTagName("SoftwareProjects")[0];

                        foreach (XmlNode Sxxxx in software)
                        {
                            bool ok = false;

                            foreach (XmlNode softwareProject in softwareProjects)
                            {
                                if (Sxxxx.Name == softwareProject.Name)
                                {
                                    // Found the right Software Project, so can now get all the paths needed to release
                                    ok = true;

                                    string fileExtension = softwareProject.Attributes["outputType"].Value;
                                    string outputPath = softwareProject.Attributes["outputPath"].Value;
                                    string releasesPath = softwareProject.Attributes["releasesPath"].Value;
                                    string archivePath = releasesPath + "\\Archive";


                                    // STEP 4a - Archive
                                    string[] files = Directory.GetFiles(releasesPath, "*" + fileExtension);

                                    foreach (var file in files)
                                        File.Move(file, Path.Combine(archivePath, Path.GetFileName(file)));

                                    // STEP 4b - Release
                                    files = Directory.GetFiles(outputPath, "*" + fileExtension);

                                    foreach (var file in files)
                                    {
                                        string newFileName = Path.GetFileName(file).Split('.')[0] + "__" + Sxxxx.Name + "-" + version + fileExtension;
                                        File.Copy(Path.Combine(outputPath, Path.GetFileName(file)), Path.Combine(releasesPath, newFileName));
                                    }

                                    break;
                                }

                            }

                            if (ok == false)
                            {
                                MessageBox.Show("Release process aborted: Unknown software " + Sxxxx.Name);
                                this.Close();
                            }
                        }


                        // Final STEP - Add release to XML DB and generate a new progress/releases report
                        XmlElement newRelease = db.CreateElement(version);
                        newRelease.SetAttribute("unplanned", BacklogTextBox.Text);
                        newRelease.SetAttribute("todo", ToDoTextBox.Text);
                        newRelease.SetAttribute("inProgress", InProgressTextBox.Text);
                        newRelease.SetAttribute("done", DoneTextBox.Text);
                        sprints.AppendChild(newRelease);
                        db.Save(db.DocumentElement.GetAttribute("path"));

                        GenerateReport gen = new GenerateReport(db, projectName);
                    }

                }
            }




            this.Close();
        }
    }
}
