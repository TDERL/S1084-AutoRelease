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

            /* XmlElement newRelease = db.CreateElement(version);
             newRelease.SetAttribute("unplanned", BacklogTextBox.Text);
             newRelease.SetAttribute("todo", ToDoTextBox.Text);
             newRelease.SetAttribute("inProgress", InProgressTextBox.Text);
             newRelease.SetAttribute("done", DoneTextBox.Text);
             sprints.AppendChild(newRelease);
             db.Save(db.DocumentElement.GetAttribute("path"));

             GenerateReport gen = new GenerateReport(db, projectName); */

            XmlNode software = project.GetElementsByTagName("Software")[0];
            if (software == null)
            {
                MessageBox.Show("Release process aborted: There is no software included in " + projectName);
                this.Close();
            }

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
                    //all software and Press Enter when done..."

                    if (MessageBox.Show(message, "Build", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                    {
                        MessageBox.Show("Release process aborted: User chose not to build software");
                    }
                    else
                    {
                        // Here we have to assume user has built all software as requested
                    }
                     
                }
            }




            this.Close();
        }
    }
}
