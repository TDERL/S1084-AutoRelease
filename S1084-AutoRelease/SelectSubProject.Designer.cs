namespace S1084_AutoRelease
{
    partial class SelectSubProject
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
            SubProjectsComboBox = new ComboBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // SubProjectsComboBox
            // 
            SubProjectsComboBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            SubProjectsComboBox.FormattingEnabled = true;
            SubProjectsComboBox.Location = new Point(21, 64);
            SubProjectsComboBox.Name = "SubProjectsComboBox";
            SubProjectsComboBox.Size = new Size(213, 29);
            SubProjectsComboBox.TabIndex = 0;
            SubProjectsComboBox.SelectedIndexChanged += SubProjectsComboBox_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(21, 30);
            label1.Name = "label1";
            label1.Size = new Size(213, 21);
            label1.TabIndex = 1;
            label1.Text = "Select a Sub-Project from list:";
            // 
            // SelectSubProject
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(SubProjectsComboBox);
            Name = "SelectSubProject";
            Text = "SelectSubProject";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox SubProjectsComboBox;
        private Label label1;
    }
}