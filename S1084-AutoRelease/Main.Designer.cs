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
            SuspendLayout();
            // 
            // CreateProjectButton
            // 
            CreateProjectButton.BackColor = Color.FromArgb(255, 224, 192);
            CreateProjectButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CreateProjectButton.Location = new Point(30, 38);
            CreateProjectButton.Name = "CreateProjectButton";
            CreateProjectButton.Size = new Size(127, 66);
            CreateProjectButton.TabIndex = 0;
            CreateProjectButton.Text = "Create Project";
            CreateProjectButton.UseVisualStyleBackColor = false;
            CreateProjectButton.Click += this.CreateProjectButton_Click;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(CreateProjectButton);
            Name = "Main";
            Text = "S1084 - Auto Release";
            ResumeLayout(false);
        }

        #endregion

        private Button CreateProjectButton;
    }
}
