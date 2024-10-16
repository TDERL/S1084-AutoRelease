namespace S1084_AutoRelease
{
    partial class NewProject
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
            ProjectPathTextBox = new TextBox();
            label3 = new Label();
            AddSubProjectButton = new Button();
            label4 = new Label();
            SubProjectsLabel = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(24, 139);
            label1.Name = "label1";
            label1.Size = new Size(173, 21);
            label1.TabIndex = 0;
            label1.Text = "Local path to GIT Repo: ";
            // 
            // RepoPathTextBox
            // 
            RepoPathTextBox.Font = new Font("Segoe UI", 9.75F);
            RepoPathTextBox.ForeColor = SystemColors.WindowFrame;
            RepoPathTextBox.Location = new Point(203, 139);
            RepoPathTextBox.Name = "RepoPathTextBox";
            RepoPathTextBox.Size = new Size(552, 25);
            RepoPathTextBox.TabIndex = 3;
            RepoPathTextBox.Text = "Please enter path";
            // 
            // SaveAndCloseButton
            // 
            SaveAndCloseButton.BackColor = Color.FromArgb(255, 255, 192);
            SaveAndCloseButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            SaveAndCloseButton.Location = new Point(483, 357);
            SaveAndCloseButton.Name = "SaveAndCloseButton";
            SaveAndCloseButton.Size = new Size(127, 66);
            SaveAndCloseButton.TabIndex = 4;
            SaveAndCloseButton.Text = "Save and Close";
            SaveAndCloseButton.UseVisualStyleBackColor = false;
            SaveAndCloseButton.Click += SaveAndCloseButton_Click;
            // 
            // ProjectNameTextBox
            // 
            ProjectNameTextBox.Font = new Font("Segoe UI", 9.75F);
            ProjectNameTextBox.ForeColor = SystemColors.WindowFrame;
            ProjectNameTextBox.Location = new Point(203, 45);
            ProjectNameTextBox.Name = "ProjectNameTextBox";
            ProjectNameTextBox.Size = new Size(552, 25);
            ProjectNameTextBox.TabIndex = 2;
            ProjectNameTextBox.Text = "Please enter name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(24, 45);
            label2.Name = "label2";
            label2.Size = new Size(111, 21);
            label2.TabIndex = 3;
            label2.Text = "Project Name: ";
            // 
            // CloseButton
            // 
            CloseButton.BackColor = Color.FromArgb(255, 224, 192);
            CloseButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CloseButton.Location = new Point(628, 357);
            CloseButton.Name = "CloseButton";
            CloseButton.Size = new Size(127, 66);
            CloseButton.TabIndex = 1;
            CloseButton.Text = "Close";
            CloseButton.UseVisualStyleBackColor = false;
            CloseButton.Click += CloseButton_Click;
            // 
            // SaveButton
            // 
            SaveButton.BackColor = Color.FromArgb(192, 255, 192);
            SaveButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            SaveButton.Location = new Point(337, 357);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(127, 66);
            SaveButton.TabIndex = 5;
            SaveButton.Text = "Save";
            SaveButton.UseVisualStyleBackColor = false;
            SaveButton.Click += SaveButton_Click;
            // 
            // ProjectPathTextBox
            // 
            ProjectPathTextBox.Font = new Font("Segoe UI", 9.75F);
            ProjectPathTextBox.ForeColor = SystemColors.WindowFrame;
            ProjectPathTextBox.Location = new Point(203, 91);
            ProjectPathTextBox.Name = "ProjectPathTextBox";
            ProjectPathTextBox.Size = new Size(552, 25);
            ProjectPathTextBox.TabIndex = 7;
            ProjectPathTextBox.Text = "Please enter path";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(24, 91);
            label3.Name = "label3";
            label3.Size = new Size(95, 21);
            label3.TabIndex = 6;
            label3.Text = "Project Path:";
            // 
            // AddSubProjectButton
            // 
            AddSubProjectButton.BackColor = Color.FromArgb(192, 255, 255);
            AddSubProjectButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            AddSubProjectButton.Location = new Point(628, 212);
            AddSubProjectButton.Name = "AddSubProjectButton";
            AddSubProjectButton.Size = new Size(127, 66);
            AddSubProjectButton.TabIndex = 8;
            AddSubProjectButton.Text = "Add Sxxxx Sub-Project";
            AddSubProjectButton.UseVisualStyleBackColor = false;
            AddSubProjectButton.Click += AddSubProjectButton_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(24, 212);
            label4.Name = "label4";
            label4.Size = new Size(142, 21);
            label4.TabIndex = 9;
            label4.Text = "Sxxxx Sub-Projects:";
            // 
            // SubProjectsLabel
            // 
            SubProjectsLabel.AutoSize = true;
            SubProjectsLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            SubProjectsLabel.Location = new Point(203, 212);
            SubProjectsLabel.Name = "SubProjectsLabel";
            SubProjectsLabel.Size = new Size(48, 21);
            SubProjectsLabel.TabIndex = 10;
            SubProjectsLabel.Text = "None";
            // 
            // NewProject
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(SubProjectsLabel);
            Controls.Add(label4);
            Controls.Add(AddSubProjectButton);
            Controls.Add(ProjectPathTextBox);
            Controls.Add(label3);
            Controls.Add(SaveButton);
            Controls.Add(CloseButton);
            Controls.Add(ProjectNameTextBox);
            Controls.Add(label2);
            Controls.Add(SaveAndCloseButton);
            Controls.Add(RepoPathTextBox);
            Controls.Add(label1);
            Name = "NewProject";
            Text = "NewProject";
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
        private TextBox ProjectPathTextBox;
        private Label label3;
        private Button AddSubProjectButton;
        private Label label4;
        private Label SubProjectsLabel;
    }
}