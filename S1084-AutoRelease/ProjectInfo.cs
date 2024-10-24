﻿using System;
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


namespace S1084_AutoRelease
{
    public partial class ProjectInfo : Form
    {
        public struct endOfSprint
        {
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
        private List<string> subProjectNames = new List<string>();

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
                        subProjectNames.Add(node.Name);

                    subProjectNames.Sort();

                    foreach (string subProjectName in subProjectNames)
                        AddSubProjectButtonToGroup(subProjectName);
                }

                XmlElement sprints = (XmlElement)project.GetElementsByTagName("Sprints")[0];

                if (sprints != null)
                {
                    foreach (XmlElement node in sprints)
                    {
                        endOfSprint sprint = new endOfSprint();
                        sprint.name = node.Name; 
                        sprint.unplanned = node.Attributes["unplanned"].Value;
                        sprint.todo = node.Attributes["todo"].Value;
                        sprint.inProgress = node.Attributes["inProgress"].Value;
                        sprint.done = node.Attributes["done"].Value;
                        endOfSprints.Add(sprint);
                    }
                }
            }
        }

        private void AddSubProjectButtonToGroup(string name)
        {
            Button subProjectButton = new Button();
            subProjectButton.BackColor = Color.FromArgb(243, 111, 247);
            subProjectButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            subProjectButton.Location = new Point(subProjectButton_x, subProjectButton_y);
            subProjectButton.Name = "subProjectButton";
            subProjectButton.Size = new Size(80, 50);
            subProjectButton.TabIndex = 0;
            subProjectButton.Text = name;
            subProjectButton.UseVisualStyleBackColor = false;
            subProjectButton.Click += OpenSubProjectButton_Click;
            SubProjectsGroupBox.Controls.Add(subProjectButton);

            subProjectButton_x = subProjectButton_x + 100;
            if (subProjectButton_x > 621)
            {
                subProjectButton_x = 20;
                subProjectButton_y = subProjectButton_y + 70;
            }
        }

        private void ResetGroupOfSubProject()
        {
            SubProjectsGroupBox.Controls.Clear();

            SubProjectsGroupBox.Controls.Add(RemoveSubProjectButton);
            SubProjectsGroupBox.Controls.Add(AddSubProjectButton);
            subProjectButton_x = 20;
            subProjectButton_y = 140;

            subProjectNames.Sort();

            foreach (string subProjectRemaining in subProjectNames)
                AddSubProjectButtonToGroup(subProjectRemaining);
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

            if (subProjectNames.Count > 0)
            {
                XmlElement subProjectElement = db.CreateElement("Software");

                foreach (string subProjectName in subProjectNames)
                    subProjectElement.AppendChild(db.CreateElement(subProjectName));

                project.AppendChild(subProjectElement);
            }


            if (endOfSprints.Count > 0)
            {
                XmlElement sprints = db.CreateElement("Sprints");

                foreach (endOfSprint sprint in endOfSprints)
                {
                    XmlElement xmlSprint = db.CreateElement(sprint.name);
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
                foreach (string subProjectName in subProjectNames)
                {
                    if (subProjectName == Sxxxx.selectedSubProject)
                    {
                        MessageBox.Show(Sxxxx.selectedSubProject + " is already included in project " + ProjectNameTextBox.Text);
                        return;
                    }
                }

                subProjectNames.Add(Sxxxx.selectedSubProject);
                ResetGroupOfSubProject();
            }
        }
        private void RemoveSubProjectButton_Click(object sender, EventArgs e)
        {
            SelectSubProject Sxxxx = new SelectSubProject(db);
            var result = Sxxxx.ShowDialog();
            if (result == DialogResult.OK)
            {
                foreach (string subProjectName in subProjectNames)
                {
                    if (subProjectName == Sxxxx.selectedSubProject)
                    {
                        subProjectNames.Remove(subProjectName);
                        ResetGroupOfSubProject();
                        return; 
                    }
                }

                MessageBox.Show("Cannot remove " + Sxxxx.selectedSubProject + " as is not included in project " + ProjectNameTextBox.Text);
            }
        }

        private void OpenSubProjectButton_Click(object sender, EventArgs e)
        {
            Button subProjectButton = (Button)sender;

            foreach (string subProjectName in subProjectNames)
            {
                if (subProjectName == subProjectButton.Text)
                {
                    EditSubProject edit = new EditSubProject(db, subProjectName);
                }
            }
        }
        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (e.KeyChar == (char)Keys.Space);
        }
    }
}
