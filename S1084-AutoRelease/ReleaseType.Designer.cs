namespace S1084_AutoRelease
{
    partial class ReleaseType
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
            CancelButton = new Button();
            MidButton = new Button();
            EndButton = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // CancelButton
            // 
            CancelButton.Font = new Font("Segoe UI", 12F);
            CancelButton.Location = new Point(24, 104);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(86, 35);
            CancelButton.TabIndex = 0;
            CancelButton.Text = "Cancel";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // MidButton
            // 
            MidButton.Font = new Font("Segoe UI", 12F);
            MidButton.Location = new Point(134, 104);
            MidButton.Name = "MidButton";
            MidButton.Size = new Size(86, 35);
            MidButton.TabIndex = 1;
            MidButton.Text = "Ad-Hoc";
            MidButton.UseVisualStyleBackColor = true;
            MidButton.Click += MidButton_Click;
            // 
            // EndButton
            // 
            EndButton.Font = new Font("Segoe UI", 12F);
            EndButton.Location = new Point(243, 104);
            EndButton.Name = "EndButton";
            EndButton.Size = new Size(86, 35);
            EndButton.TabIndex = 2;
            EndButton.Text = "Normal";
            EndButton.UseVisualStyleBackColor = true;
            EndButton.Click += EndButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(24, 20);
            label1.Name = "label1";
            label1.Size = new Size(316, 63);
            label1.TabIndex = 3;
            label1.Text = "Select type of release\r\nSelect Normal for End of Sprint\r\nSelect Ad-Hoc for a Mid-Sprint 'non-release'";
            // 
            // ReleaseType
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(359, 163);
            Controls.Add(label1);
            Controls.Add(EndButton);
            Controls.Add(MidButton);
            Controls.Add(CancelButton);
            Name = "ReleaseType";
            Text = "What Type of Release?";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button CancelButton;
        private Button MidButton;
        private Button EndButton;
        private Label label1;
    }
}