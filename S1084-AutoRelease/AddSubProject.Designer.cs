namespace S1084_AutoRelease
{
    partial class AddSubProject
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
            ReleasesPathTextBox = new TextBox();
            label3 = new Label();
            ProjectNameTextBox = new TextBox();
            label2 = new Label();
            CancelButton = new Button();
            AddButton = new Button();
            OutputPathTextBox = new TextBox();
            label1 = new Label();
            VersionPathTextBox = new TextBox();
            label4 = new Label();
            ArchivePathTextBox = new TextBox();
            label5 = new Label();
            OutputTypeTextBox = new TextBox();
            label6 = new Label();
            AddSubProjectToolTip = new ToolTip(components);
            SuspendLayout();
            // 
            // ReleasesPathTextBox
            // 
            ReleasesPathTextBox.Font = new Font("Segoe UI", 9.75F);
            ReleasesPathTextBox.ForeColor = SystemColors.WindowFrame;
            ReleasesPathTextBox.Location = new Point(199, 215);
            ReleasesPathTextBox.Name = "ReleasesPathTextBox";
            ReleasesPathTextBox.Size = new Size(552, 25);
            ReleasesPathTextBox.TabIndex = 5;
            ReleasesPathTextBox.Text = "Please enter path";
            AddSubProjectToolTip.SetToolTip(ReleasesPathTextBox, "Directory path where new release of the executable/build output is stored and renamed to Srr version");
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(20, 215);
            label3.Name = "label3";
            label3.Size = new Size(148, 21);
            label3.TabIndex = 10;
            label3.Text = "Sxxxx Releases Path:";
            // 
            // ProjectNameTextBox
            // 
            ProjectNameTextBox.Font = new Font("Segoe UI", 9.75F);
            ProjectNameTextBox.ForeColor = SystemColors.WindowFrame;
            ProjectNameTextBox.Location = new Point(199, 35);
            ProjectNameTextBox.Name = "ProjectNameTextBox";
            ProjectNameTextBox.Size = new Size(552, 25);
            ProjectNameTextBox.TabIndex = 1;
            ProjectNameTextBox.Text = "Please enter name";
            AddSubProjectToolTip.SetToolTip(ProjectNameTextBox, "Sxxxx numbers are allocated in the ERL Catalogue. Enter a name like, EG, \"S1070-Control\"");
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(20, 35);
            label2.Name = "label2";
            label2.Size = new Size(152, 21);
            label2.TabIndex = 9;
            label2.Text = "Sxxxx Project Name: ";
            // 
            // CancelButton
            // 
            CancelButton.BackColor = Color.FromArgb(255, 224, 192);
            CancelButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CancelButton.Location = new Point(628, 357);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(127, 66);
            CancelButton.TabIndex = 8;
            CancelButton.Text = "Cancel";
            CancelButton.UseVisualStyleBackColor = false;
            CancelButton.Click += CancelButton_Click;
            // 
            // AddButton
            // 
            AddButton.BackColor = Color.FromArgb(192, 255, 192);
            AddButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            AddButton.Location = new Point(483, 357);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(127, 66);
            AddButton.TabIndex = 7;
            AddButton.Text = "Add";
            AddButton.UseVisualStyleBackColor = false;
            AddButton.Click += AddButton_Click;
            // 
            // OutputPathTextBox
            // 
            OutputPathTextBox.Font = new Font("Segoe UI", 9.75F);
            OutputPathTextBox.ForeColor = SystemColors.WindowFrame;
            OutputPathTextBox.Location = new Point(199, 125);
            OutputPathTextBox.Name = "OutputPathTextBox";
            OutputPathTextBox.Size = new Size(552, 25);
            OutputPathTextBox.TabIndex = 3;
            OutputPathTextBox.Text = "Please enter path";
            AddSubProjectToolTip.SetToolTip(OutputPathTextBox, "Directory path where executable/build output is located (after being built)");
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(20, 125);
            label1.Name = "label1";
            label1.Size = new Size(137, 21);
            label1.TabIndex = 14;
            label1.Text = "Sxxxx Output Path:";
            // 
            // VersionPathTextBox
            // 
            VersionPathTextBox.Font = new Font("Segoe UI", 9.75F);
            VersionPathTextBox.ForeColor = SystemColors.WindowFrame;
            VersionPathTextBox.Location = new Point(199, 170);
            VersionPathTextBox.Name = "VersionPathTextBox";
            VersionPathTextBox.Size = new Size(552, 25);
            VersionPathTextBox.TabIndex = 4;
            VersionPathTextBox.Text = "Please enter path";
            AddSubProjectToolTip.SetToolTip(VersionPathTextBox, "Directory path where the version define string (usually in \"GitVersion.h\") is saved");
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(20, 170);
            label4.Name = "label4";
            label4.Size = new Size(140, 21);
            label4.TabIndex = 16;
            label4.Text = "Sxxxx Version Path:";
            // 
            // ArchivePathTextBox
            // 
            ArchivePathTextBox.Font = new Font("Segoe UI", 9.75F);
            ArchivePathTextBox.ForeColor = SystemColors.WindowFrame;
            ArchivePathTextBox.Location = new Point(199, 260);
            ArchivePathTextBox.Name = "ArchivePathTextBox";
            ArchivePathTextBox.Size = new Size(552, 25);
            ArchivePathTextBox.TabIndex = 6;
            ArchivePathTextBox.Text = "Please enter path";
            AddSubProjectToolTip.SetToolTip(ArchivePathTextBox, "Directory path where previous release of executable/build output is moved to");
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(20, 260);
            label5.Name = "label5";
            label5.Size = new Size(140, 21);
            label5.TabIndex = 18;
            label5.Text = "Sxxxx Archive Path:";
            // 
            // OutputTypeTextBox
            // 
            OutputTypeTextBox.Font = new Font("Segoe UI", 9.75F);
            OutputTypeTextBox.ForeColor = SystemColors.WindowFrame;
            OutputTypeTextBox.Location = new Point(199, 80);
            OutputTypeTextBox.Name = "OutputTypeTextBox";
            OutputTypeTextBox.Size = new Size(552, 25);
            OutputTypeTextBox.TabIndex = 2;
            OutputTypeTextBox.Text = "Please enter a .extension";
            AddSubProjectToolTip.SetToolTip(OutputTypeTextBox, "File extension of the executable/build output, like, EG, \".bin\" or \".hex\", etc");
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(20, 80);
            label6.Name = "label6";
            label6.Size = new Size(139, 21);
            label6.TabIndex = 20;
            label6.Text = "Sxxxx Output Type:";
            // 
            // AddSubProjectToolTip
            // 
            AddSubProjectToolTip.AutomaticDelay = 100;
            AddSubProjectToolTip.AutoPopDelay = 3000;
            AddSubProjectToolTip.InitialDelay = 100;
            AddSubProjectToolTip.ReshowDelay = 20;
            AddSubProjectToolTip.ShowAlways = true;
            // 
            // AddSubProject
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(OutputTypeTextBox);
            Controls.Add(label6);
            Controls.Add(ArchivePathTextBox);
            Controls.Add(label5);
            Controls.Add(VersionPathTextBox);
            Controls.Add(label4);
            Controls.Add(OutputPathTextBox);
            Controls.Add(label1);
            Controls.Add(CancelButton);
            Controls.Add(AddButton);
            Controls.Add(ReleasesPathTextBox);
            Controls.Add(label3);
            Controls.Add(ProjectNameTextBox);
            Controls.Add(label2);
            Name = "AddSubProject";
            Text = "AddSubProject";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox ReleasesPathTextBox;
        private Label label3;
        private TextBox ProjectNameTextBox;
        private Label label2;
        private Button CancelButton;
        private Button AddButton;
        private TextBox OutputPathTextBox;
        private Label label1;
        private TextBox VersionPathTextBox;
        private Label label4;
        private TextBox ArchivePathTextBox;
        private Label label5;
        private TextBox OutputTypeTextBox;
        private Label label6;
        private ToolTip AddSubProjectToolTip;
    }
}