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
            InitInfoLabel = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            BacklogTextBox = new TextBox();
            ToDoTextBox = new TextBox();
            InProgressTextBox = new TextBox();
            DoneTextBox = new TextBox();
            OkayButton = new Button();
            CancelButton = new Button();
            SuspendLayout();
            // 
            // InitInfoLabel
            // 
            InitInfoLabel.AutoSize = true;
            InitInfoLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            InitInfoLabel.Location = new Point(29, 18);
            InitInfoLabel.Name = "InitInfoLabel";
            InitInfoLabel.Size = new Size(237, 42);
            InitInfoLabel.TabIndex = 0;
            InitInfoLabel.Text = "Before closing the current Sprint,\r\nenter number of stories in:\r\n";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Silver;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(31, 104);
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
            label3.Location = new Point(31, 144);
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
            label4.Location = new Point(31, 184);
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
            label5.Location = new Point(31, 224);
            label5.Name = "label5";
            label5.Size = new Size(56, 21);
            label5.TabIndex = 4;
            label5.Text = "DONE:";
            // 
            // BacklogTextBox
            // 
            BacklogTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BacklogTextBox.Location = new Point(161, 101);
            BacklogTextBox.Name = "BacklogTextBox";
            BacklogTextBox.Size = new Size(64, 29);
            BacklogTextBox.TabIndex = 5;
            BacklogTextBox.KeyPress += TextBox_KeyPress;
            // 
            // ToDoTextBox
            // 
            ToDoTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ToDoTextBox.Location = new Point(161, 141);
            ToDoTextBox.Name = "ToDoTextBox";
            ToDoTextBox.Size = new Size(64, 29);
            ToDoTextBox.TabIndex = 6;
            ToDoTextBox.KeyPress += TextBox_KeyPress;
            // 
            // InProgressTextBox
            // 
            InProgressTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            InProgressTextBox.Location = new Point(161, 181);
            InProgressTextBox.Name = "InProgressTextBox";
            InProgressTextBox.Size = new Size(64, 29);
            InProgressTextBox.TabIndex = 7;
            InProgressTextBox.KeyPress += TextBox_KeyPress;
            // 
            // DoneTextBox
            // 
            DoneTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            DoneTextBox.Location = new Point(161, 221);
            DoneTextBox.Name = "DoneTextBox";
            DoneTextBox.Size = new Size(64, 29);
            DoneTextBox.TabIndex = 8;
            DoneTextBox.KeyPress += TextBox_KeyPress;
            // 
            // OkayButton
            // 
            OkayButton.Font = new Font("Segoe UI", 12F);
            OkayButton.Location = new Point(139, 279);
            OkayButton.Name = "OkayButton";
            OkayButton.Size = new Size(86, 35);
            OkayButton.TabIndex = 10;
            OkayButton.Text = "Okay";
            OkayButton.UseVisualStyleBackColor = true;
            OkayButton.Click += OkayButton_Click;
            // 
            // CancelButton
            // 
            CancelButton.Font = new Font("Segoe UI", 12F);
            CancelButton.Location = new Point(29, 279);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(86, 35);
            CancelButton.TabIndex = 9;
            CancelButton.Text = "Cancel";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // NormalRelease
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(264, 341);
            Controls.Add(OkayButton);
            Controls.Add(CancelButton);
            Controls.Add(DoneTextBox);
            Controls.Add(InProgressTextBox);
            Controls.Add(ToDoTextBox);
            Controls.Add(BacklogTextBox);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(InitInfoLabel);
            Name = "NormalRelease";
            Text = "Normal, end of Sprint, Release";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label InitInfoLabel;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox BacklogTextBox;
        private TextBox ToDoTextBox;
        private TextBox InProgressTextBox;
        private TextBox DoneTextBox;
        private Button OkayButton;
        private Button CancelButton;
    }
}