namespace S1084_AutoRelease
{
    partial class AddHardwareComponent
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
            CancelHWButton = new Button();
            AddHWButton = new Button();
            AddSubProjectToolTip = new ToolTip(components);
            HardwareNameTextBox = new TextBox();
            label7 = new Label();
            HWDescriptionTextBox = new TextBox();
            label8 = new Label();
            ActiveCheckBox = new CheckBox();
            HardwareNumberTextBox = new TextBox();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(22, 23);
            label2.Name = "label2";
            label2.Size = new Size(136, 21);
            label2.TabIndex = 9;
            label2.Text = "EDAxxxx Number: ";
            AddSubProjectToolTip.SetToolTip(label2, "Enter ONLY the 'S' numner allocated to this software project");
            // 
            // CancelHWButton
            // 
            CancelHWButton.BackColor = Color.FromArgb(255, 224, 192);
            CancelHWButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CancelHWButton.Location = new Point(626, 26);
            CancelHWButton.Name = "CancelHWButton";
            CancelHWButton.Size = new Size(127, 66);
            CancelHWButton.TabIndex = 10;
            CancelHWButton.Text = "Cancel";
            CancelHWButton.UseVisualStyleBackColor = false;
            CancelHWButton.Click += CancelButton_Click;
            // 
            // AddHWButton
            // 
            AddHWButton.BackColor = Color.FromArgb(255, 255, 192);
            AddHWButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            AddHWButton.Location = new Point(482, 26);
            AddHWButton.Name = "AddHWButton";
            AddHWButton.Size = new Size(127, 66);
            AddHWButton.TabIndex = 9;
            AddHWButton.Text = "Save and Close";
            AddHWButton.UseVisualStyleBackColor = false;
            AddHWButton.Click += AddButton_Click;
            // 
            // AddSubProjectToolTip
            // 
            AddSubProjectToolTip.AutomaticDelay = 100;
            AddSubProjectToolTip.AutoPopDelay = 3000;
            AddSubProjectToolTip.InitialDelay = 100;
            AddSubProjectToolTip.ReshowDelay = 20;
            AddSubProjectToolTip.ShowAlways = true;
            // 
            // HardwareNameTextBox
            // 
            HardwareNameTextBox.Font = new Font("Segoe UI", 9.75F);
            HardwareNameTextBox.ForeColor = SystemColors.WindowFrame;
            HardwareNameTextBox.Location = new Point(201, 70);
            HardwareNameTextBox.Name = "HardwareNameTextBox";
            HardwareNameTextBox.Size = new Size(244, 25);
            HardwareNameTextBox.TabIndex = 1;
            AddSubProjectToolTip.SetToolTip(HardwareNameTextBox, "Short decription name such as 'Control' or 'BITE'");
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
            // HWDescriptionTextBox
            // 
            HWDescriptionTextBox.Font = new Font("Segoe UI", 9.75F);
            HWDescriptionTextBox.ForeColor = SystemColors.WindowFrame;
            HWDescriptionTextBox.Location = new Point(201, 122);
            HWDescriptionTextBox.Name = "HWDescriptionTextBox";
            HWDescriptionTextBox.Size = new Size(552, 25);
            HWDescriptionTextBox.TabIndex = 3;
            AddSubProjectToolTip.SetToolTip(HWDescriptionTextBox, "Please enter a short description");
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(22, 126);
            label8.Name = "label8";
            label8.Size = new Size(92, 21);
            label8.TabIndex = 24;
            label8.Text = "Description:";
            AddSubProjectToolTip.SetToolTip(label8, "Please enter a short description");
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
            // HardwareNumberTextBox
            // 
            HardwareNumberTextBox.Font = new Font("Segoe UI", 9.75F);
            HardwareNumberTextBox.ForeColor = SystemColors.WindowFrame;
            HardwareNumberTextBox.Location = new Point(201, 19);
            HardwareNumberTextBox.Name = "HardwareNumberTextBox";
            HardwareNumberTextBox.Size = new Size(140, 25);
            HardwareNumberTextBox.TabIndex = 35;
            HardwareNumberTextBox.Text = "EDA";
            AddSubProjectToolTip.SetToolTip(HardwareNumberTextBox, "Short decription name such as 'Control' or 'BITE'");
            // 
            // AddHardwareComponent
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 219);
            Controls.Add(HardwareNumberTextBox);
            Controls.Add(ActiveCheckBox);
            Controls.Add(HWDescriptionTextBox);
            Controls.Add(label8);
            Controls.Add(HardwareNameTextBox);
            Controls.Add(label7);
            Controls.Add(CancelHWButton);
            Controls.Add(AddHWButton);
            Controls.Add(label2);
            Name = "AddHardwareComponent";
            Text = "AddSubProject";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label2;
        private Button CancelHWButton;
        private Button AddHWButton;
        private ToolTip AddSubProjectToolTip;
        private TextBox HardwareNameTextBox;
        private Label label7;
        private TextBox HWDescriptionTextBox;
        private Label label8;
        private CheckBox ActiveCheckBox;
        private TextBox HardwareNumberTextBox;
    }
}