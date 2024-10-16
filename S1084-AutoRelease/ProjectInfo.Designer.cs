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
            label1 = new Label();
            RepoPathTextBox = new TextBox();
            SaveAndCloseButton = new Button();
            ProjectNameTextBox = new TextBox();
            label2 = new Label();
            CloseButton = new Button();
            SaveButton = new Button();
            AddSubProjectButton = new Button();
            SubProjectsGroupBox = new GroupBox();
            SubProjectsGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(24, 169);
            label1.Name = "label1";
            label1.Size = new Size(173, 21);
            label1.TabIndex = 0;
            label1.Text = "Local path to GIT Repo: ";
            // 
            // RepoPathTextBox
            // 
            RepoPathTextBox.Font = new Font("Segoe UI", 9.75F);
            RepoPathTextBox.ForeColor = SystemColors.WindowFrame;
            RepoPathTextBox.Location = new Point(201, 169);
            RepoPathTextBox.Name = "RepoPathTextBox";
            RepoPathTextBox.Size = new Size(552, 25);
            RepoPathTextBox.TabIndex = 2;
            RepoPathTextBox.Text = "Please enter path";
            // 
            // SaveAndCloseButton
            // 
            SaveAndCloseButton.BackColor = Color.FromArgb(255, 255, 192);
            SaveAndCloseButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            SaveAndCloseButton.Location = new Point(482, 26);
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
            ProjectNameTextBox.Location = new Point(201, 125);
            ProjectNameTextBox.Name = "ProjectNameTextBox";
            ProjectNameTextBox.Size = new Size(552, 25);
            ProjectNameTextBox.TabIndex = 1;
            ProjectNameTextBox.Text = "Please enter name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(25, 125);
            label2.Name = "label2";
            label2.Size = new Size(111, 21);
            label2.TabIndex = 3;
            label2.Text = "Project Name: ";
            // 
            // CloseButton
            // 
            CloseButton.BackColor = Color.FromArgb(255, 224, 192);
            CloseButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CloseButton.Location = new Point(626, 26);
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
            SaveButton.Location = new Point(338, 26);
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
            AddSubProjectButton.Location = new Point(20, 37);
            AddSubProjectButton.Name = "AddSubProjectButton";
            AddSubProjectButton.Size = new Size(127, 66);
            AddSubProjectButton.TabIndex = 3;
            AddSubProjectButton.Text = "Add Sxxxx Sub-Project";
            AddSubProjectButton.UseVisualStyleBackColor = false;
            AddSubProjectButton.Click += AddSubProjectButton_Click;
            // 
            // SubProjectsGroupBox
            // 
            SubProjectsGroupBox.Controls.Add(AddSubProjectButton);
            SubProjectsGroupBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            SubProjectsGroupBox.Location = new Point(34, 216);
            SubProjectsGroupBox.Name = "SubProjectsGroupBox";
            SubProjectsGroupBox.Size = new Size(719, 351);
            SubProjectsGroupBox.TabIndex = 11;
            SubProjectsGroupBox.TabStop = false;
            SubProjectsGroupBox.Text = "Sxxxx Sub-Projects";
            // 
            // ProjectInfo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 596);
            Controls.Add(SubProjectsGroupBox);
            Controls.Add(SaveButton);
            Controls.Add(CloseButton);
            Controls.Add(ProjectNameTextBox);
            Controls.Add(label2);
            Controls.Add(SaveAndCloseButton);
            Controls.Add(RepoPathTextBox);
            Controls.Add(label1);
            Name = "ProjectInfo";
            Text = "Project Info";
            SubProjectsGroupBox.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox RepoPathTextBox;
        private Button SaveAndCloseButton;
        private TextBox ProjectNameTextBox;
        private Label label2;
        private Button CloseButton;
        private Button SaveButton;
        private Button AddSubProjectButton;
        private GroupBox SubProjectsGroupBox;
    }
}