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
            SoftwareNumberTextBox = new TextBox();
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
            SoftwareNameTextBox = new TextBox();
            label7 = new Label();
            DescriptionTextBox = new TextBox();
            label8 = new Label();
            PlaftormTextBox = new TextBox();
            label9 = new Label();
            SuspendLayout();
            // 
            // ReleasesPathTextBox
            // 
            ReleasesPathTextBox.Font = new Font("Segoe UI", 9.75F);
            ReleasesPathTextBox.ForeColor = SystemColors.WindowFrame;
            ReleasesPathTextBox.Location = new Point(201, 337);
            ReleasesPathTextBox.Name = "ReleasesPathTextBox";
            ReleasesPathTextBox.Size = new Size(552, 25);
            ReleasesPathTextBox.TabIndex = 6;
            ReleasesPathTextBox.Text = "Please enter path";
            AddSubProjectToolTip.SetToolTip(ReleasesPathTextBox, "Directory path where new release of the executable/build output is stored and renamed to Srr version");
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(22, 337);
            label3.Name = "label3";
            label3.Size = new Size(107, 21);
            label3.TabIndex = 10;
            label3.Text = "Releases Path:";
            AddSubProjectToolTip.SetToolTip(label3, "Directory path where new release of the executable/build output is stored and renamed to Srr version");
            // 
            // SoftwareNumberTextBox
            // 
            SoftwareNumberTextBox.Font = new Font("Segoe UI", 9.75F);
            SoftwareNumberTextBox.ForeColor = SystemColors.WindowFrame;
            SoftwareNumberTextBox.Location = new Point(201, 23);
            SoftwareNumberTextBox.Name = "SoftwareNumberTextBox";
            SoftwareNumberTextBox.Size = new Size(244, 25);
            SoftwareNumberTextBox.TabIndex = 1;
            SoftwareNumberTextBox.Text = "Please enter number";
            AddSubProjectToolTip.SetToolTip(SoftwareNumberTextBox, "Enter ONLY the 'S' numner allocated to this software project");
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(22, 23);
            label2.Name = "label2";
            label2.Size = new Size(116, 21);
            label2.TabIndex = 9;
            label2.Text = "Sxxxx Number: ";
            AddSubProjectToolTip.SetToolTip(label2, "Enter ONLY the 'S' numner allocated to this software project");
            // 
            // CancelButton
            // 
            CancelButton.BackColor = Color.FromArgb(255, 224, 192);
            CancelButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CancelButton.Location = new Point(626, 26);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(127, 66);
            CancelButton.TabIndex = 9;
            CancelButton.Text = "Cancel";
            CancelButton.UseVisualStyleBackColor = false;
            CancelButton.Click += CancelButton_Click;
            // 
            // AddButton
            // 
            AddButton.BackColor = Color.FromArgb(255, 255, 192);
            AddButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            AddButton.Location = new Point(482, 26);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(127, 66);
            AddButton.TabIndex = 8;
            AddButton.Text = "Save and Close";
            AddButton.UseVisualStyleBackColor = false;
            AddButton.Click += AddButton_Click;
            // 
            // OutputPathTextBox
            // 
            OutputPathTextBox.Font = new Font("Segoe UI", 9.75F);
            OutputPathTextBox.ForeColor = SystemColors.WindowFrame;
            OutputPathTextBox.Location = new Point(201, 247);
            OutputPathTextBox.Name = "OutputPathTextBox";
            OutputPathTextBox.Size = new Size(552, 25);
            OutputPathTextBox.TabIndex = 4;
            OutputPathTextBox.Text = "Please enter path";
            AddSubProjectToolTip.SetToolTip(OutputPathTextBox, "Directory path where executable/build output is located (after being built)");
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(22, 247);
            label1.Name = "label1";
            label1.Size = new Size(96, 21);
            label1.TabIndex = 14;
            label1.Text = "Output Path:";
            AddSubProjectToolTip.SetToolTip(label1, "Directory path where executable/build output is located (after being built)");
            // 
            // VersionPathTextBox
            // 
            VersionPathTextBox.Font = new Font("Segoe UI", 9.75F);
            VersionPathTextBox.ForeColor = SystemColors.WindowFrame;
            VersionPathTextBox.Location = new Point(201, 292);
            VersionPathTextBox.Name = "VersionPathTextBox";
            VersionPathTextBox.Size = new Size(552, 25);
            VersionPathTextBox.TabIndex = 5;
            VersionPathTextBox.Text = "Please enter path";
            AddSubProjectToolTip.SetToolTip(VersionPathTextBox, "Directory path where the version define string (usually in \"GitVersion.h\") is saved");
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(22, 292);
            label4.Name = "label4";
            label4.Size = new Size(99, 21);
            label4.TabIndex = 16;
            label4.Text = "Version Path:";
            AddSubProjectToolTip.SetToolTip(label4, "Directory path where the version define string (usually in \"GitVersion.h\") is saved");
            // 
            // ArchivePathTextBox
            // 
            ArchivePathTextBox.Font = new Font("Segoe UI", 9.75F);
            ArchivePathTextBox.ForeColor = SystemColors.WindowFrame;
            ArchivePathTextBox.Location = new Point(201, 382);
            ArchivePathTextBox.Name = "ArchivePathTextBox";
            ArchivePathTextBox.Size = new Size(552, 25);
            ArchivePathTextBox.TabIndex = 7;
            ArchivePathTextBox.Text = "Please enter path";
            AddSubProjectToolTip.SetToolTip(ArchivePathTextBox, "Directory path where previous release of executable/build output is moved to");
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(22, 382);
            label5.Name = "label5";
            label5.Size = new Size(99, 21);
            label5.TabIndex = 18;
            label5.Text = "Archive Path:";
            AddSubProjectToolTip.SetToolTip(label5, "Directory path where previous release of executable/build output is moved to");
            // 
            // OutputTypeTextBox
            // 
            OutputTypeTextBox.Font = new Font("Segoe UI", 9.75F);
            OutputTypeTextBox.ForeColor = SystemColors.WindowFrame;
            OutputTypeTextBox.Location = new Point(201, 202);
            OutputTypeTextBox.Name = "OutputTypeTextBox";
            OutputTypeTextBox.Size = new Size(552, 25);
            OutputTypeTextBox.TabIndex = 3;
            OutputTypeTextBox.Text = "Please enter a .extension";
            AddSubProjectToolTip.SetToolTip(OutputTypeTextBox, "File extension of the executable/build output, like, EG, \".bin\" or \".hex\", etc");
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(22, 202);
            label6.Name = "label6";
            label6.Size = new Size(126, 21);
            label6.TabIndex = 20;
            label6.Text = "Output File Type:";
            AddSubProjectToolTip.SetToolTip(label6, "File extension of the executable/build output, like, EG, \".bin\" or \".hex\", etc");
            // 
            // AddSubProjectToolTip
            // 
            AddSubProjectToolTip.AutomaticDelay = 100;
            AddSubProjectToolTip.AutoPopDelay = 3000;
            AddSubProjectToolTip.InitialDelay = 100;
            AddSubProjectToolTip.ReshowDelay = 20;
            AddSubProjectToolTip.ShowAlways = true;
            // 
            // SoftwareNameTextBox
            // 
            SoftwareNameTextBox.Font = new Font("Segoe UI", 9.75F);
            SoftwareNameTextBox.ForeColor = SystemColors.WindowFrame;
            SoftwareNameTextBox.Location = new Point(201, 67);
            SoftwareNameTextBox.Name = "SoftwareNameTextBox";
            SoftwareNameTextBox.Size = new Size(244, 25);
            SoftwareNameTextBox.TabIndex = 2;
            AddSubProjectToolTip.SetToolTip(SoftwareNameTextBox, "Short decription name such as 'Control' or 'BITE'");
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(22, 67);
            label7.Name = "label7";
            label7.Size = new Size(101, 21);
            label7.TabIndex = 22;
            label7.Text = "Short Name: ";
            AddSubProjectToolTip.SetToolTip(label7, "Short decription name such as 'Control' or 'BITE'");
            // 
            // DescriptionTextBox
            // 
            DescriptionTextBox.Font = new Font("Segoe UI", 9.75F);
            DescriptionTextBox.ForeColor = SystemColors.WindowFrame;
            DescriptionTextBox.Location = new Point(201, 158);
            DescriptionTextBox.Name = "DescriptionTextBox";
            DescriptionTextBox.Size = new Size(552, 25);
            DescriptionTextBox.TabIndex = 23;
            AddSubProjectToolTip.SetToolTip(DescriptionTextBox, "Please enter a short description");
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(22, 158);
            label8.Name = "label8";
            label8.Size = new Size(92, 21);
            label8.TabIndex = 24;
            label8.Text = "Description:";
            AddSubProjectToolTip.SetToolTip(label8, "Please enter a short description");
            // 
            // PlaftormTextBox
            // 
            PlaftormTextBox.Font = new Font("Segoe UI", 9.75F);
            PlaftormTextBox.ForeColor = SystemColors.WindowFrame;
            PlaftormTextBox.Location = new Point(201, 111);
            PlaftormTextBox.Name = "PlaftormTextBox";
            PlaftormTextBox.Size = new Size(244, 25);
            PlaftormTextBox.TabIndex = 25;
            AddSubProjectToolTip.SetToolTip(PlaftormTextBox, "Short decription name such as 'Control' or 'BITE'");
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(22, 111);
            label9.Name = "label9";
            label9.Size = new Size(73, 21);
            label9.TabIndex = 26;
            label9.Text = "Platform:";
            AddSubProjectToolTip.SetToolTip(label9, "Short decription name such as 'Control' or 'BITE'");
            // 
            // AddSubProject
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label9);
            Controls.Add(PlaftormTextBox);
            Controls.Add(DescriptionTextBox);
            Controls.Add(label8);
            Controls.Add(SoftwareNameTextBox);
            Controls.Add(label7);
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
            Controls.Add(SoftwareNumberTextBox);
            Controls.Add(label2);
            Name = "AddSubProject";
            Text = "AddSubProject";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox ReleasesPathTextBox;
        private Label label3;
        private TextBox SoftwareNumberTextBox;
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
        private TextBox SoftwareNameTextBox;
        private Label label7;
        private TextBox DescriptionTextBox;
        private Label label8;
        private TextBox PlaftormTextBox;
        private Label label9;
    }
}