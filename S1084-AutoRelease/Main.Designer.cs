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
            groupBox1 = new GroupBox();
            GenerateReportButton = new Button();
            label1 = new Label();
            groupBox2 = new GroupBox();
            label2 = new Label();
            EditSubProjectButton = new Button();
            SubProjectListComboBox = new ComboBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // CreateProjectButton
            // 
            CreateProjectButton.BackColor = Color.FromArgb(255, 255, 192);
            CreateProjectButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CreateProjectButton.Location = new Point(24, 44);
            CreateProjectButton.Name = "CreateProjectButton";
            CreateProjectButton.Size = new Size(119, 66);
            CreateProjectButton.TabIndex = 0;
            CreateProjectButton.Text = "Add New Project";
            CreateProjectButton.UseVisualStyleBackColor = false;
            CreateProjectButton.Click += CreateProjectButton_Click;
            // 
            // EditProjectButton
            // 
            EditProjectButton.BackColor = Color.FromArgb(255, 224, 192);
            EditProjectButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            EditProjectButton.Location = new Point(24, 192);
            EditProjectButton.Name = "EditProjectButton";
            EditProjectButton.Size = new Size(119, 66);
            EditProjectButton.TabIndex = 1;
            EditProjectButton.Text = "Edit Project";
            EditProjectButton.UseVisualStyleBackColor = false;
            EditProjectButton.Click += EditProjectButton_Click;
            // 
            // ProjectListComboBox
            // 
            ProjectListComboBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ProjectListComboBox.FormattingEnabled = true;
            ProjectListComboBox.Location = new Point(24, 148);
            ProjectListComboBox.Name = "ProjectListComboBox";
            ProjectListComboBox.Size = new Size(119, 29);
            ProjectListComboBox.TabIndex = 2;
            ProjectListComboBox.SelectedIndexChanged += ProjectListComboBox_SelectedIndexChanged;
            // 
            // CreateSubProjectButton
            // 
            CreateSubProjectButton.BackColor = Color.FromArgb(255, 255, 192);
            CreateSubProjectButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CreateSubProjectButton.Location = new Point(26, 44);
            CreateSubProjectButton.Name = "CreateSubProjectButton";
            CreateSubProjectButton.Size = new Size(119, 66);
            CreateSubProjectButton.TabIndex = 3;
            CreateSubProjectButton.Text = "Add New Sub-Project";
            CreateSubProjectButton.UseVisualStyleBackColor = false;
            CreateSubProjectButton.Click += CreateSubProjectButton_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(GenerateReportButton);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(CreateProjectButton);
            groupBox1.Controls.Add(EditProjectButton);
            groupBox1.Controls.Add(ProjectListComboBox);
            groupBox1.Location = new Point(24, 26);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(174, 456);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Projects";
            // 
            // GenerateReportButton
            // 
            GenerateReportButton.BackColor = Color.FromArgb(192, 255, 192);
            GenerateReportButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            GenerateReportButton.Location = new Point(24, 279);
            GenerateReportButton.Name = "GenerateReportButton";
            GenerateReportButton.Size = new Size(119, 66);
            GenerateReportButton.TabIndex = 4;
            GenerateReportButton.Text = "Generate Report";
            GenerateReportButton.UseVisualStyleBackColor = false;
            GenerateReportButton.Click += GenerateReportButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(24, 130);
            label1.Name = "label1";
            label1.Size = new Size(103, 15);
            label1.TabIndex = 3;
            label1.Text = "Or select from list:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(EditSubProjectButton);
            groupBox2.Controls.Add(SubProjectListComboBox);
            groupBox2.Controls.Add(CreateSubProjectButton);
            groupBox2.Location = new Point(232, 26);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(174, 288);
            groupBox2.TabIndex = 5;
            groupBox2.TabStop = false;
            groupBox2.Text = "Sub-Projects (Sxxxx)";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(26, 130);
            label2.Name = "label2";
            label2.Size = new Size(103, 15);
            label2.TabIndex = 6;
            label2.Text = "Or select from list:";
            // 
            // EditSubProjectButton
            // 
            EditSubProjectButton.BackColor = Color.FromArgb(255, 224, 192);
            EditSubProjectButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            EditSubProjectButton.Location = new Point(26, 192);
            EditSubProjectButton.Name = "EditSubProjectButton";
            EditSubProjectButton.Size = new Size(119, 66);
            EditSubProjectButton.TabIndex = 5;
            EditSubProjectButton.Text = "Edit Sub-Project";
            EditSubProjectButton.UseVisualStyleBackColor = false;
            EditSubProjectButton.Visible = false;
            EditSubProjectButton.Click += EditSubProjectButton_Click;
            // 
            // SubProjectListComboBox
            // 
            SubProjectListComboBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            SubProjectListComboBox.FormattingEnabled = true;
            SubProjectListComboBox.Location = new Point(26, 148);
            SubProjectListComboBox.Name = "SubProjectListComboBox";
            SubProjectListComboBox.Size = new Size(119, 29);
            SubProjectListComboBox.TabIndex = 4;
            SubProjectListComboBox.SelectedIndexChanged += SubProjectListComboBox_SelectedIndexChanged;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(481, 573);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "Main";
            Text = "S1084 - Auto Release";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button CreateProjectButton;
        private Button EditProjectButton;
        private ComboBox ProjectListComboBox;
        private Button CreateSubProjectButton;
        private GroupBox groupBox1;
        private Label label1;
        private GroupBox groupBox2;
        private Button EditSubProjectButton;
        private ComboBox SubProjectListComboBox;
        private Label label2;
        private Button GenerateReportButton;
    }
}
