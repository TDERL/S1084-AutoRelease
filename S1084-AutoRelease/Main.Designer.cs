namespace S1084_AutoRelease
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            CreateProjectButton = new Button();
            EditProjectButton = new Button();
            ProjectListComboBox = new ComboBox();
            CreateSubProjectButton = new Button();
            SuspendLayout();
            // 
            // CreateProjectButton
            // 
            CreateProjectButton.BackColor = Color.FromArgb(255, 224, 192);
            CreateProjectButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CreateProjectButton.Location = new Point(72, 146);
            CreateProjectButton.Name = "CreateProjectButton";
            CreateProjectButton.Size = new Size(127, 66);
            CreateProjectButton.TabIndex = 0;
            CreateProjectButton.Text = "Add New Project";
            CreateProjectButton.UseVisualStyleBackColor = false;
            CreateProjectButton.Click += CreateProjectButton_Click;
            // 
            // EditProjectButton
            // 
            EditProjectButton.BackColor = Color.FromArgb(255, 224, 192);
            EditProjectButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            EditProjectButton.Location = new Point(218, 146);
            EditProjectButton.Name = "EditProjectButton";
            EditProjectButton.Size = new Size(127, 66);
            EditProjectButton.TabIndex = 1;
            EditProjectButton.Text = "Edit Project";
            EditProjectButton.UseVisualStyleBackColor = false;
            EditProjectButton.Click += EditProjectButton_Click;
            // 
            // ProjectListComboBox
            // 
            ProjectListComboBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ProjectListComboBox.FormattingEnabled = true;
            ProjectListComboBox.Location = new Point(72, 38);
            ProjectListComboBox.Name = "ProjectListComboBox";
            ProjectListComboBox.Size = new Size(127, 29);
            ProjectListComboBox.TabIndex = 2;
            ProjectListComboBox.SelectedIndexChanged += ProjectListComboBox_SelectedIndexChanged;
            // 
            // CreateSubProjectButton
            // 
            CreateSubProjectButton.BackColor = Color.FromArgb(255, 224, 192);
            CreateSubProjectButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CreateSubProjectButton.Location = new Point(366, 146);
            CreateSubProjectButton.Name = "CreateSubProjectButton";
            CreateSubProjectButton.Size = new Size(127, 66);
            CreateSubProjectButton.TabIndex = 3;
            CreateSubProjectButton.Text = "Add New Sxxxx Sub-Project";
            CreateSubProjectButton.UseVisualStyleBackColor = false;
            CreateSubProjectButton.Click += CreateSubProjectButton_Click;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(CreateSubProjectButton);
            Controls.Add(ProjectListComboBox);
            Controls.Add(EditProjectButton);
            Controls.Add(CreateProjectButton);
            Name = "Main";
            Text = "S1084 - Auto Release";
            ResumeLayout(false);
        }

        #endregion

        private Button CreateProjectButton;
        private Button EditProjectButton;
        private ComboBox ProjectListComboBox;
        private Button CreateSubProjectButton;
    }
}
