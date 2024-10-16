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
            ProjectPathTextBox = new TextBox();
            label3 = new Label();
            ProjectNameTextBox = new TextBox();
            label2 = new Label();
            CancelButton = new Button();
            AddButton = new Button();
            SuspendLayout();
            // 
            // ProjectPathTextBox
            // 
            ProjectPathTextBox.Font = new Font("Segoe UI", 9.75F);
            ProjectPathTextBox.ForeColor = SystemColors.WindowFrame;
            ProjectPathTextBox.Location = new Point(199, 83);
            ProjectPathTextBox.Name = "ProjectPathTextBox";
            ProjectPathTextBox.Size = new Size(552, 25);
            ProjectPathTextBox.TabIndex = 11;
            ProjectPathTextBox.Text = "Please enter path";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(20, 83);
            label3.Name = "label3";
            label3.Size = new Size(136, 21);
            label3.TabIndex = 10;
            label3.Text = "Sxxxx Project Path:";
            // 
            // ProjectNameTextBox
            // 
            ProjectNameTextBox.Font = new Font("Segoe UI", 9.75F);
            ProjectNameTextBox.ForeColor = SystemColors.WindowFrame;
            ProjectNameTextBox.Location = new Point(199, 37);
            ProjectNameTextBox.Name = "ProjectNameTextBox";
            ProjectNameTextBox.Size = new Size(552, 25);
            ProjectNameTextBox.TabIndex = 8;
            ProjectNameTextBox.Text = "Please enter name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(20, 37);
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
            CancelButton.TabIndex = 12;
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
            AddButton.TabIndex = 13;
            AddButton.Text = "Add";
            AddButton.UseVisualStyleBackColor = false;
            AddButton.Click += AddButton_Click;
            // 
            // AddSubProject
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(CancelButton);
            Controls.Add(AddButton);
            Controls.Add(ProjectPathTextBox);
            Controls.Add(label3);
            Controls.Add(ProjectNameTextBox);
            Controls.Add(label2);
            Name = "AddSubProject";
            Text = "AddSubProject";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox ProjectPathTextBox;
        private Label label3;
        private TextBox ProjectNameTextBox;
        private Label label2;
        private Button CancelButton;
        private Button AddButton;
    }
}