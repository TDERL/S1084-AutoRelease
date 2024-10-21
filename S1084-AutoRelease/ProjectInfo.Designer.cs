namespace S1084_AutoRelease
{
    partial class ProjectInfo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjectInfo));
            label1 = new Label();
            DescriptionTextBox = new TextBox();
            SaveAndCloseButton = new Button();
            ProjectNameTextBox = new TextBox();
            label2 = new Label();
            CloseButton = new Button();
            SaveButton = new Button();
            AddSubProjectButton = new Button();
            SubProjectsGroupBox = new GroupBox();
            RemoveSubProjectButton = new Button();
            StageComboBox = new ComboBox();
            label3 = new Label();
            StatusComboBox = new ComboBox();
            label4 = new Label();
            ProjectInfoToolTip = new ToolTip(components);
            DescriptiveNameTextBox = new TextBox();
            label5 = new Label();
            RepoPathTextBox = new TextBox();
            label6 = new Label();
            label12 = new Label();
            label7 = new Label();
            label8 = new Label();
            ReportPathTextBox = new TextBox();
            label9 = new Label();
            SubProjectsGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(24, 70);
            label1.Name = "label1";
            label1.Size = new Size(142, 21);
            label1.TabIndex = 0;
            label1.Text = "Description (short):";
            // 
            // DescriptionTextBox
            // 
            DescriptionTextBox.Font = new Font("Segoe UI", 9.75F);
            DescriptionTextBox.ForeColor = SystemColors.WindowFrame;
            DescriptionTextBox.Location = new Point(201, 70);
            DescriptionTextBox.Name = "DescriptionTextBox";
            DescriptionTextBox.Size = new Size(552, 25);
            DescriptionTextBox.TabIndex = 2;
            // 
            // SaveAndCloseButton
            // 
            SaveAndCloseButton.BackColor = Color.FromArgb(255, 255, 192);
            SaveAndCloseButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            SaveAndCloseButton.Location = new Point(483, 208);
            SaveAndCloseButton.Name = "SaveAndCloseButton";
            SaveAndCloseButton.Size = new Size(127, 66);
            SaveAndCloseButton.TabIndex = 5;
            SaveAndCloseButton.Text = "Save and Close";
            SaveAndCloseButton.UseVisualStyleBackColor = false;
            SaveAndCloseButton.Click += SaveAndCloseButton_Click;
            // 
            // ProjectNameTextBox
            // 
            ProjectNameTextBox.Font = new Font("Segoe UI", 9.75F);
            ProjectNameTextBox.ForeColor = SystemColors.WindowFrame;
            ProjectNameTextBox.Location = new Point(201, 25);
            ProjectNameTextBox.Name = "ProjectNameTextBox";
            ProjectNameTextBox.Size = new Size(121, 25);
            ProjectNameTextBox.TabIndex = 1;
            ProjectNameTextBox.Text = "Please enter name";
            ProjectInfoToolTip.SetToolTip(ProjectNameTextBox, "Abbreviated name. Usually three charsd and a number");
            ProjectNameTextBox.KeyPress += TextBox_KeyPress;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(24, 26);
            label2.Name = "label2";
            label2.Size = new Size(101, 21);
            label2.TabIndex = 3;
            label2.Text = "Short Name: ";
            // 
            // CloseButton
            // 
            CloseButton.BackColor = Color.FromArgb(255, 224, 192);
            CloseButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CloseButton.Location = new Point(626, 208);
            CloseButton.Name = "CloseButton";
            CloseButton.Size = new Size(127, 66);
            CloseButton.TabIndex = 6;
            CloseButton.Text = "Cancel";
            CloseButton.UseVisualStyleBackColor = false;
            CloseButton.Click += CloseButton_Click;
            // 
            // SaveButton
            // 
            SaveButton.BackColor = Color.FromArgb(192, 255, 192);
            SaveButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            SaveButton.Location = new Point(339, 208);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(127, 66);
            SaveButton.TabIndex = 4;
            SaveButton.Text = "Save";
            SaveButton.UseVisualStyleBackColor = false;
            SaveButton.Click += SaveButton_Click;
            // 
            // AddSubProjectButton
            // 
            AddSubProjectButton.BackColor = Color.FromArgb(192, 255, 255);
            AddSubProjectButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            AddSubProjectButton.Image = (Image)resources.GetObject("AddSubProjectButton.Image");
            AddSubProjectButton.Location = new Point(20, 37);
            AddSubProjectButton.Name = "AddSubProjectButton";
            AddSubProjectButton.Size = new Size(75, 75);
            AddSubProjectButton.TabIndex = 3;
            AddSubProjectButton.UseVisualStyleBackColor = false;
            AddSubProjectButton.Click += AddSubProjectButton_Click;
            // 
            // SubProjectsGroupBox
            // 
            SubProjectsGroupBox.Controls.Add(RemoveSubProjectButton);
            SubProjectsGroupBox.Controls.Add(AddSubProjectButton);
            SubProjectsGroupBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            SubProjectsGroupBox.Location = new Point(24, 297);
            SubProjectsGroupBox.Name = "SubProjectsGroupBox";
            SubProjectsGroupBox.Size = new Size(729, 288);
            SubProjectsGroupBox.TabIndex = 11;
            SubProjectsGroupBox.TabStop = false;
            SubProjectsGroupBox.Text = "Sxxxx Sub-Projects";
            // 
            // RemoveSubProjectButton
            // 
            RemoveSubProjectButton.BackColor = Color.FromArgb(192, 255, 255);
            RemoveSubProjectButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            RemoveSubProjectButton.Image = (Image)resources.GetObject("RemoveSubProjectButton.Image");
            RemoveSubProjectButton.Location = new Point(101, 37);
            RemoveSubProjectButton.Name = "RemoveSubProjectButton";
            RemoveSubProjectButton.Size = new Size(75, 75);
            RemoveSubProjectButton.TabIndex = 4;
            RemoveSubProjectButton.UseVisualStyleBackColor = false;
            RemoveSubProjectButton.Click += RemoveSubProjectButton_Click;
            // 
            // StageComboBox
            // 
            StageComboBox.FormattingEnabled = true;
            StageComboBox.Items.AddRange(new object[] { "Red", "Blue", "Green", "Black" });
            StageComboBox.Location = new Point(201, 205);
            StageComboBox.Name = "StageComboBox";
            StageComboBox.Size = new Size(121, 23);
            StageComboBox.TabIndex = 12;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(24, 203);
            label3.Name = "label3";
            label3.Size = new Size(139, 21);
            label3.TabIndex = 13;
            label3.Text = "Current Dev Stage:";
            // 
            // StatusComboBox
            // 
            StatusComboBox.FormattingEnabled = true;
            StatusComboBox.Items.AddRange(new object[] { "Active", "On Hold", "Abandoned", "Complete", "" });
            StatusComboBox.Location = new Point(201, 250);
            StatusComboBox.Name = "StatusComboBox";
            StatusComboBox.Size = new Size(121, 23);
            StatusComboBox.TabIndex = 14;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(24, 248);
            label4.Name = "label4";
            label4.Size = new Size(107, 21);
            label4.TabIndex = 15;
            label4.Text = "Activity Status";
            // 
            // DescriptiveNameTextBox
            // 
            DescriptiveNameTextBox.Font = new Font("Segoe UI", 9.75F);
            DescriptiveNameTextBox.ForeColor = SystemColors.WindowFrame;
            DescriptiveNameTextBox.Location = new Point(495, 25);
            DescriptiveNameTextBox.Name = "DescriptiveNameTextBox";
            DescriptiveNameTextBox.Size = new Size(258, 25);
            DescriptiveNameTextBox.TabIndex = 17;
            ProjectInfoToolTip.SetToolTip(DescriptiveNameTextBox, "Abbreviated name. Usually three charsd and a number");
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(349, 26);
            label5.Name = "label5";
            label5.Size = new Size(140, 21);
            label5.TabIndex = 16;
            label5.Text = "Descriptive Name: ";
            // 
            // RepoPathTextBox
            // 
            RepoPathTextBox.Font = new Font("Segoe UI", 9.75F);
            RepoPathTextBox.ForeColor = SystemColors.WindowFrame;
            RepoPathTextBox.Location = new Point(201, 115);
            RepoPathTextBox.Name = "RepoPathTextBox";
            RepoPathTextBox.Size = new Size(552, 25);
            RepoPathTextBox.TabIndex = 19;
            RepoPathTextBox.Text = "Please enter path";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(24, 116);
            label6.Name = "label6";
            label6.Size = new Size(173, 21);
            label6.TabIndex = 18;
            label6.Text = "Local path to GIT Repo: ";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label12.ForeColor = Color.Red;
            label12.Location = new Point(183, 115);
            label12.Name = "label12";
            label12.Size = new Size(17, 21);
            label12.TabIndex = 30;
            label12.Text = "*";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.Red;
            label7.Location = new Point(183, 25);
            label7.Name = "label7";
            label7.Size = new Size(17, 21);
            label7.TabIndex = 31;
            label7.Text = "*";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.Red;
            label8.Location = new Point(183, 163);
            label8.Name = "label8";
            label8.Size = new Size(17, 21);
            label8.TabIndex = 34;
            label8.Text = "*";
            // 
            // ReportPathTextBox
            // 
            ReportPathTextBox.Font = new Font("Segoe UI", 9.75F);
            ReportPathTextBox.ForeColor = SystemColors.WindowFrame;
            ReportPathTextBox.Location = new Point(201, 160);
            ReportPathTextBox.Name = "ReportPathTextBox";
            ReportPathTextBox.Size = new Size(552, 25);
            ReportPathTextBox.TabIndex = 33;
            ReportPathTextBox.Text = "Please enter path";
            ProjectInfoToolTip.SetToolTip(ReportPathTextBox, "Local directory path where generated reports are to be saved");
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(24, 160);
            label9.Name = "label9";
            label9.Size = new Size(157, 21);
            label9.TabIndex = 32;
            label9.Text = "Local path to Reports";
            ProjectInfoToolTip.SetToolTip(label9, "Local directory path where generated reports are to be saved");
            // 
            // ProjectInfo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 595);
            Controls.Add(label8);
            Controls.Add(ReportPathTextBox);
            Controls.Add(label9);
            Controls.Add(label7);
            Controls.Add(label12);
            Controls.Add(RepoPathTextBox);
            Controls.Add(label6);
            Controls.Add(DescriptiveNameTextBox);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(StatusComboBox);
            Controls.Add(label3);
            Controls.Add(StageComboBox);
            Controls.Add(SubProjectsGroupBox);
            Controls.Add(SaveButton);
            Controls.Add(CloseButton);
            Controls.Add(ProjectNameTextBox);
            Controls.Add(label2);
            Controls.Add(SaveAndCloseButton);
            Controls.Add(DescriptionTextBox);
            Controls.Add(label1);
            Name = "ProjectInfo";
            Text = "Project Info";
            SubProjectsGroupBox.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox DescriptionTextBox;
        private Button SaveAndCloseButton;
        private TextBox ProjectNameTextBox;
        private Label label2;
        private Button CloseButton;
        private Button SaveButton;
        private Button AddSubProjectButton;
        private GroupBox SubProjectsGroupBox;
        private Button RemoveSubProjectButton;
        private ComboBox StageComboBox;
        private Label label3;
        private ComboBox StatusComboBox;
        private Label label4;
        private ToolTip ProjectInfoToolTip;
        private Label label5;
        private TextBox DescriptiveNameTextBox;
        private TextBox RepoPathTextBox;
        private Label label6;
        private Label label12;
        private Label label7;
        private Label label8;
        private TextBox ReportPathTextBox;
        private Label label9;
    }
}