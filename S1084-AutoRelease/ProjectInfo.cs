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
using static System.Windows.Forms.AxHost;
using System.Xml.Linq;
using System.Collections;
using static S1084_AutoRelease.ProjectInfo;
using S1084_AutoRelease.Properties;


namespace S1084_AutoRelease
{
    public partial class ProjectInfo : Form
    {
        public struct endOfSprint
        {
            public string date;
            public string name;
            public string unplanned;
            public string todo;
            public string inProgress;
            public string done;
        }

        private List<endOfSprint> endOfSprints = new List<endOfSprint>();

        private int subProjectButton_x = 20;
        private int subProjectButton_y = 140;
        private XmlDocument db = new XmlDocument();

        struct Sxxxx
        {
            public string name;     // S1070 or S1071, etc --> Name of children elements to 'Project/Software'
            public string included; // Attribute to the named Sxxxx element
        }
        private List<Sxxxx> subProjects = new List<Sxxxx>();

        public ProjectInfo(XmlDocument db, string name)
        {
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;
            this.db = db;

            if (name != "") // If editing an existing project then:
            {
                XmlElement project = (XmlElement)db.GetElementsByTagName(name)[0];
                ProjectNameTextBox.Text = name; //  For example, "DCB1"
                DescriptiveNameTextBox.Text = project.Attributes["desName"].Value; //  For example, "Distributed Current Bus"
                DescriptionTextBox.Text = project.Attributes["description"].Value;
                RepoPathTextBox.Text = project.Attributes["repoPath"].Value;
                StageComboBox.Text = project.Attributes["stage"].Value;
                StatusComboBox.Text = project.Attributes["status"].Value;

                XmlElement Software = (XmlElement)project.GetElementsByTagName("Software")[0];
                if (Software != null)
                {
                    foreach (XmlNode node in Software)
                    {
                        Sxxxx sxxxx = new Sxxxx();
                        sxxxx.name = node.Name;
                        sxxxx.included = node.Attributes["included"].Value;
                        subProjects.Add(sxxxx);
                    }

                    //subProjectNames.Sort();

                    foreach (Sxxxx subProject in subProjects)
                        AddSxxxxProductToTable(subProject);
                }

                AddFinalRowToSxxxxTable();

                XmlElement sprints = (XmlElement)project.GetElementsByTagName("Sprints")[0];

                if (sprints != null)
                {
                    foreach (XmlElement node in sprints)
                    {
                        endOfSprint sprint = new endOfSprint();
                        sprint.name = node.Name;
                        sprint.date = node.Attributes["date"].Value;
                        sprint.unplanned = node.Attributes["unplanned"].Value;
                        sprint.todo = node.Attributes["todo"].Value;
                        sprint.inProgress = node.Attributes["inProgress"].Value;
                        sprint.done = node.Attributes["done"].Value;
                        endOfSprints.Add(sprint);
                    }
                }
            }
        }

        private void AddSxxxxProductToTable(Sxxxx sxxxx)
        {
            Button subProjectButton = new Button();
            subProjectButton.BackColor = Color.FromArgb(243, 111, 247);
            subProjectButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            subProjectButton.Location = new Point(subProjectButton_x, subProjectButton_y);
            subProjectButton.Name = "subProjectButton";
            subProjectButton.Size = new Size(80, 50);
            subProjectButton.TabIndex = 0;
            subProjectButton.Text = sxxxx.name;
            subProjectButton.UseVisualStyleBackColor = false;
            subProjectButton.Click += OpenSubProjectButton_Click;

            Button removeSubProjectButton = new Button();
            removeSubProjectButton.Name = "Remove" + sxxxx.name;
            removeSubProjectButton.Size = new Size(50, 50);
            removeSubProjectButton.Image = Image.FromFile("C:\\Projects\\Windows Apps\\S1084-AutoRelease\\Icons\\Remove-50x50.png");
            removeSubProjectButton.Click += RemoveSubProjectButton_Click;

            int width = TableLayoutPanel.Size.Width;
            int height = TableLayoutPanel.Size.Height;

            int row = TableLayoutPanel.RowCount;
            TableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            TableLayoutPanel.RowCount++;

            TableLayoutPanel.Controls.Add(removeSubProjectButton, 0, row);
            TableLayoutPanel.Controls.Add(subProjectButton, 1, row);

            height += 50;
            TableLayoutPanel.Size = new Size(width, height);

            foreach (XmlNode softwareProject in db.GetElementsByTagName("SoftwareProjects")[0].ChildNodes)
            {
                if (sxxxx.name ==  softwareProject.Name)
                {
                    Label desc = new Label();
                    desc.AutoSize = true;
                    desc.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
                    desc.Text = softwareProject.Attributes["shortName"].Value;
                    TableLayoutPanel.Controls.Add(desc, 2, row);
                    break;
                }
            }

            CheckBox incl = new CheckBox();
            incl.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);

            if (sxxxx.included == "yes")
                incl.Checked = true;
            else
                incl.Checked = false;

            TableLayoutPanel.Controls.Add(incl, 3, row);
        }

        private void AddFinalRowToSxxxxTable()
        {
            Button addSubProjectButton = new Button();
            addSubProjectButton.Size = new Size(50, 50);
            addSubProjectButton.Image = Image.FromFile("C:\\Projects\\Windows Apps\\S1084-AutoRelease\\Icons\\Add-50x50.png");  //(Image)resources.GetObject("AddSubProjectButton.Image");
            addSubProjectButton.Click += AddSubProjectButton_Click;

            int width = TableLayoutPanel.Size.Width;
            int height = TableLayoutPanel.Size.Height;

            int row = TableLayoutPanel.RowCount;
            TableLayoutPanel.RowCount++;
            TableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            TableLayoutPanel.Controls.Add(addSubProjectButton, 0, row);

            height += 50;
            TableLayoutPanel.Size = new Size(width, height);
        }



        private bool SaveProject()
        {
            string projectName = ProjectNameTextBox.Text;

            if (projectName == "Please enter name")
            {
                MessageBox.Show("Please enter name for the project");
                return false;
            }

            if (RepoPathTextBox.Text == "Please enter path")
            {
                MessageBox.Show("Please enter a valid [local] directory path for the GIT repository [C:\\...]");
                return false;
            }


            // If project already exists in the XML doc, then remove it so it can be re-added afresh
            XmlElement projects = (XmlElement)db.GetElementsByTagName("Projects")[0];

            if (projects.GetElementsByTagName(projectName)[0] != null)
                projects.RemoveChild(projects.GetElementsByTagName(projectName)[0]);

            XmlElement project = db.CreateElement(projectName);
            project.SetAttribute("desName", DescriptiveNameTextBox.Text);
            project.SetAttribute("description", DescriptionTextBox.Text);
            project.SetAttribute("repoPath", RepoPathTextBox.Text);
            project.SetAttribute("stage", StageComboBox.Text);
            project.SetAttribute("status", StatusComboBox.Text);

            if (subProjects.Count > 0)
            {
                XmlElement subProjectElement = db.CreateElement("Software");

                foreach (Sxxxx sxxxx in subProjects)
                {
                    XmlElement sub = db.CreateElement(sxxxx.name);
                    sub.SetAttribute("included", sxxxx.included);
                    subProjectElement.AppendChild(sub);
                }

                project.AppendChild(subProjectElement);
            }


            if (endOfSprints.Count > 0)
            {
                XmlElement sprints = db.CreateElement("Sprints");

                foreach (endOfSprint sprint in endOfSprints)
                {
                    XmlElement xmlSprint = db.CreateElement(sprint.name);
                    xmlSprint.SetAttribute("date", sprint.date);
                    xmlSprint.SetAttribute("unplanned", sprint.unplanned);
                    xmlSprint.SetAttribute("todo", sprint.todo);
                    xmlSprint.SetAttribute("inProgress", sprint.inProgress);
                    xmlSprint.SetAttribute("done", sprint.done);
                    sprints.AppendChild(xmlSprint);
                }

                project.AppendChild(sprints);
            }

            db.GetElementsByTagName("Projects")[0].AppendChild(project);
            db.Save(db.DocumentElement.GetAttribute("path"));
            return true;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveProject();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void SaveAndCloseButton_Click(object sender, EventArgs e)
        {
            if (SaveProject())
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }



        private void AddSubProjectButton_Click(object sender, EventArgs e)
        {
            SelectSubProject Sxxxx = new SelectSubProject(db);
            var result = Sxxxx.ShowDialog();
            if (result == DialogResult.OK)
            {
                foreach (Sxxxx subProject in subProjects)
                {
                    if (subProject.name == Sxxxx.selectedSubProject)
                    {
                        MessageBox.Show(Sxxxx.selectedSubProject + " is already included in project " + ProjectNameTextBox.Text);
                        return;
                    }
                }

            //    subProjectNames.Add(Sxxxx.selectedSubProject);
            //    ResetTableOfSxxxxProducts();
            }
        }
        private void RemoveSubProjectButton_Click(object sender, EventArgs e)
        {
            Button removeButton = (Button)sender;
            Control[] SxxxxButtons = TableLayoutPanel.Controls.Find("subProjectButton", true);
            Sxxxx sxxxx = new Sxxxx();

            for (int rowIndex = 0; rowIndex < TableLayoutPanel.RowCount; rowIndex++)
            {
                sxxxx = subProjects[rowIndex];  

                if (("Remove" + SxxxxButtons[rowIndex].Text) == removeButton.Name)
                {
                    TableLayoutPanel.SuspendLayout();
                    TableLayoutHelper.RemoveArbitraryRow(TableLayoutPanel, rowIndex + 1);
                    TableLayoutPanel.ResumeLayout();

                    subProjects.Remove(sxxxx);
                    break;
                }
            }

            //SelectSubProject Sxxxx = new SelectSubProject(db);
            //var result = Sxxxx.ShowDialog();
            //if (result == DialogResult.OK)
            //{
            //    foreach (string subProjectName in subProjectNames)
            //    {
            //        if (subProjectName == Sxxxx.selectedSubProject)
            //        {
            //            subProjectNames.Remove(subProjectName);
            //            ResetTableOfSxxxxProducts();
            //            return;
            //        }
            //    }

            //    MessageBox.Show("Cannot remove " + Sxxxx.selectedSubProject + " as is not included in project " + ProjectNameTextBox.Text);
            //}
        }

        private void OpenSubProjectButton_Click(object sender, EventArgs e)
        {
            Button subProjectButton = (Button)sender;

            foreach (Sxxxx sxxxx in subProjects)
            {
                if (sxxxx.name == subProjectButton.Text)
                {
                    EditSubProject edit = new EditSubProject(db, sxxxx.name);
                    this.Close();
                }
            }
        }
        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (e.KeyChar == (char)Keys.Space);
        }

    }
}
