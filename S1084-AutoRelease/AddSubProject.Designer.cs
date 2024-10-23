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
            label2 = new Label();
            CancelButton = new Button();
            AddButton = new Button();
            OutputPathTextBox = new TextBox();
            label1 = new Label();
            OutputTypeTextBox = new TextBox();
            label6 = new Label();
            AddSubProjectToolTip = new ToolTip(components);
            SoftwareNameTextBox = new TextBox();
            label7 = new Label();
            DescriptionTextBox = new TextBox();
            label8 = new Label();
            PlaftormTextBox = new TextBox();
            label9 = new Label();
            label12 = new Label();
            label13 = new Label();
            SoftwareNumberLabel = new Label();
            ActiveCheckBox = new CheckBox();
            SuspendLayout();
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
            CancelButton.TabIndex = 10;
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
            AddButton.TabIndex = 9;
            AddButton.Text = "Save and Close";
            AddButton.UseVisualStyleBackColor = false;
            AddButton.Click += AddButton_Click;
            // 
            // OutputPathTextBox
            // 
            OutputPathTextBox.Font = new Font("Segoe UI", 9.75F);
            OutputPathTextBox.ForeColor = SystemColors.WindowFrame;
            OutputPathTextBox.Location = new Point(201, 205);
            OutputPathTextBox.Name = "OutputPathTextBox";
            OutputPathTextBox.Size = new Size(552, 25);
            OutputPathTextBox.TabIndex = 5;
            AddSubProjectToolTip.SetToolTip(OutputPathTextBox, "Directory path where executable/build output is located (after being built)");
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(22, 205);
            label1.Name = "label1";
            label1.Size = new Size(96, 21);
            label1.TabIndex = 14;
            label1.Text = "Output Path:";
            AddSubProjectToolTip.SetToolTip(label1, "Directory path where executable/build output is located (after being built)");
            // 
            // OutputTypeTextBox
            // 
            OutputTypeTextBox.Font = new Font("Segoe UI", 9.75F);
            OutputTypeTextBox.ForeColor = SystemColors.WindowFrame;
            OutputTypeTextBox.Location = new Point(672, 115);
            OutputTypeTextBox.Name = "OutputTypeTextBox";
            OutputTypeTextBox.Size = new Size(81, 25);
            OutputTypeTextBox.TabIndex = 4;
            AddSubProjectToolTip.SetToolTip(OutputTypeTextBox, "File extension of the executable/build output, like, EG, \".bin\" or \".hex\", etc");
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(483, 114);
            label6.Name = "label6";
            label6.Size = new Size(160, 21);
            label6.TabIndex = 20;
            label6.Text = "Output File Extension:";
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
            SoftwareNameTextBox.Location = new Point(201, 70);
            SoftwareNameTextBox.Name = "SoftwareNameTextBox";
            SoftwareNameTextBox.Size = new Size(244, 25);
            SoftwareNameTextBox.TabIndex = 1;
            AddSubProjectToolTip.SetToolTip(SoftwareNameTextBox, "Short decription name such as 'Control' or 'BITE'");
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(22, 70);
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
            DescriptionTextBox.Location = new Point(201, 160);
            DescriptionTextBox.Name = "DescriptionTextBox";
            DescriptionTextBox.Size = new Size(552, 25);
            DescriptionTextBox.TabIndex = 3;
            AddSubProjectToolTip.SetToolTip(DescriptionTextBox, "Please enter a short description");
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(22, 160);
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
            PlaftormTextBox.Location = new Point(201, 115);
            PlaftormTextBox.Name = "PlaftormTextBox";
            PlaftormTextBox.Size = new Size(244, 25);
            PlaftormTextBox.TabIndex = 2;
            AddSubProjectToolTip.SetToolTip(PlaftormTextBox, "Short decription name such as 'Control' or 'BITE'");
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(22, 115);
            label9.Name = "label9";
            label9.Size = new Size(73, 21);
            label9.TabIndex = 26;
            label9.Text = "Platform:";
            AddSubProjectToolTip.SetToolTip(label9, "Short decription name such as 'Control' or 'BITE'");
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label12.ForeColor = Color.Red;
            label12.Location = new Point(649, 115);
            label12.Name = "label12";
            label12.Size = new Size(17, 21);
            label12.TabIndex = 29;
            label12.Text = "*";
            AddSubProjectToolTip.SetToolTip(label12, "Enter ONLY the 'S' numner allocated to this software project");
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label13.ForeColor = Color.Red;
            label13.Location = new Point(180, 203);
            label13.Name = "label13";
            label13.Size = new Size(17, 21);
            label13.TabIndex = 30;
            label13.Text = "*";
            AddSubProjectToolTip.SetToolTip(label13, "Enter ONLY the 'S' numner allocated to this software project");
            // 
            // SoftwareNumberLabel
            // 
            SoftwareNumberLabel.AutoSize = true;
            SoftwareNumberLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            SoftwareNumberLabel.Location = new Point(201, 23);
            SoftwareNumberLabel.Name = "SoftwareNumberLabel";
            SoftwareNumberLabel.Size = new Size(113, 21);
            SoftwareNumberLabel.TabIndex = 33;
            SoftwareNumberLabel.Text = "Sxxxx Number ";
            AddSubProjectToolTip.SetToolTip(SoftwareNumberLabel, "Enter ONLY the 'S' numner allocated to this software project");
            // 
            // ActiveCheckBox
            // 
            ActiveCheckBox.AutoSize = true;
            ActiveCheckBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ActiveCheckBox.ForeColor = Color.FromArgb(192, 0, 0);
            ActiveCheckBox.Location = new Point(374, 22);
            ActiveCheckBox.Name = "ActiveCheckBox";
            ActiveCheckBox.Size = new Size(71, 25);
            ActiveCheckBox.TabIndex = 34;
            ActiveCheckBox.Text = "Active";
            AddSubProjectToolTip.SetToolTip(ActiveCheckBox, "Tick if actively part of a parent release");
            ActiveCheckBox.UseVisualStyleBackColor = true;
            // 
            // AddSubProject
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 257);
            Controls.Add(ActiveCheckBox);
            Controls.Add(SoftwareNumberLabel);
            Controls.Add(label13);
            Controls.Add(label12);
            Controls.Add(label9);
            Controls.Add(PlaftormTextBox);
            Controls.Add(DescriptionTextBox);
            Controls.Add(label8);
            Controls.Add(SoftwareNameTextBox);
            Controls.Add(label7);
            Controls.Add(OutputTypeTextBox);
            Controls.Add(label6);
            Controls.Add(OutputPathTextBox);
            Controls.Add(label1);
            Controls.Add(CancelButton);
            Controls.Add(AddButton);
            Controls.Add(label2);
            Name = "AddSubProject";
            Text = "AddSubProject";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label2;
        private Button CancelButton;
        private Button AddButton;
        private TextBox OutputPathTextBox;
        private Label label1;
        private TextBox OutputTypeTextBox;
        private Label label6;
        private ToolTip AddSubProjectToolTip;
        private TextBox SoftwareNameTextBox;
        private Label label7;
        private TextBox DescriptionTextBox;
        private Label label8;
        private TextBox PlaftormTextBox;
        private Label label9;
        private Label label12;
        private Label label13;
        private Label SoftwareNumberLabel;
        private CheckBox ActiveCheckBox;
    }
}