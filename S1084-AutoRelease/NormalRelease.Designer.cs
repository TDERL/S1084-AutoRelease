namespace S1084_AutoRelease
{
    partial class NormalRelease
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            BacklogTextBox = new TextBox();
            ToDoTextBox = new TextBox();
            InProgressTextBox = new TextBox();
            DoneTextBox = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(24, 21);
            label1.Name = "label1";
            label1.Size = new Size(199, 42);
            label1.TabIndex = 0;
            label1.Text = "As of the END of the Sprint,\r\nenter number of stories in:\r\n";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Silver;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(29, 88);
            label2.Name = "label2";
            label2.Size = new Size(81, 21);
            label2.TabIndex = 1;
            label2.Text = "BACKLOG:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Silver;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(29, 128);
            label3.Name = "label3";
            label3.Size = new Size(59, 21);
            label3.TabIndex = 2;
            label3.Text = "TO DO:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.FromArgb(192, 192, 255);
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(29, 168);
            label4.Name = "label4";
            label4.Size = new Size(111, 21);
            label4.TabIndex = 3;
            label4.Text = "IN PROGRESS:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.FromArgb(192, 255, 192);
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(29, 208);
            label5.Name = "label5";
            label5.Size = new Size(56, 21);
            label5.TabIndex = 4;
            label5.Text = "DONE:";
            // 
            // BacklogTextBox
            // 
            BacklogTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BacklogTextBox.Location = new Point(159, 85);
            BacklogTextBox.Name = "BacklogTextBox";
            BacklogTextBox.Size = new Size(64, 29);
            BacklogTextBox.TabIndex = 5;
            BacklogTextBox.KeyPress += TextBox_KeyPress;
            // 
            // ToDoTextBox
            // 
            ToDoTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ToDoTextBox.Location = new Point(159, 125);
            ToDoTextBox.Name = "ToDoTextBox";
            ToDoTextBox.Size = new Size(64, 29);
            ToDoTextBox.TabIndex = 6;
            ToDoTextBox.KeyPress += TextBox_KeyPress;
            // 
            // InProgressTextBox
            // 
            InProgressTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            InProgressTextBox.Location = new Point(159, 165);
            InProgressTextBox.Name = "InProgressTextBox";
            InProgressTextBox.Size = new Size(64, 29);
            InProgressTextBox.TabIndex = 7;
            InProgressTextBox.KeyPress += TextBox_KeyPress;
            // 
            // DoneTextBox
            // 
            DoneTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            DoneTextBox.Location = new Point(159, 205);
            DoneTextBox.Name = "DoneTextBox";
            DoneTextBox.Size = new Size(64, 29);
            DoneTextBox.TabIndex = 8;
            DoneTextBox.KeyPress += TextBox_KeyPress;
            // 
            // NormalRelease
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(DoneTextBox);
            Controls.Add(InProgressTextBox);
            Controls.Add(ToDoTextBox);
            Controls.Add(BacklogTextBox);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "NormalRelease";
            Text = "NormalRelease";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox BacklogTextBox;
        private TextBox ToDoTextBox;
        private TextBox InProgressTextBox;
        private TextBox DoneTextBox;
    }
}