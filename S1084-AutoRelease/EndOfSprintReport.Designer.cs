namespace S1084_AutoRelease
{
    partial class EndOfSprintReport
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
            OkayButton = new Button();
            CancelButton = new Button();
            ComponentsTable = new DataGridView();
            Component = new DataGridViewTextBoxColumn();
            Backlog = new DataGridViewTextBoxColumn();
            ToDo = new DataGridViewTextBoxColumn();
            InProgress = new DataGridViewTextBoxColumn();
            Done = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)ComponentsTable).BeginInit();
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
            // OkayButton
            // 
            OkayButton.Font = new Font("Segoe UI", 12F);
            OkayButton.Location = new Point(623, 162);
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
            CancelButton.Location = new Point(623, 107);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(86, 35);
            CancelButton.TabIndex = 9;
            CancelButton.Text = "Cancel";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // ComponentsTable
            // 
            ComponentsTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ComponentsTable.Columns.AddRange(new DataGridViewColumn[] { Component, Backlog, ToDo, InProgress, Done });
            ComponentsTable.Location = new Point(29, 107);
            ComponentsTable.Name = "ComponentsTable";
            ComponentsTable.Size = new Size(574, 192);
            ComponentsTable.TabIndex = 11;
            ComponentsTable.CellValidating += ComponentsTable_CellValidating;
            // 
            // Component
            // 
            Component.HeaderText = "Component";
            Component.Name = "Component";
            Component.ReadOnly = true;
            // 
            // Backlog
            // 
            Backlog.HeaderText = "# of Stories in Backlog";
            Backlog.Name = "Backlog";
            // 
            // ToDo
            // 
            ToDo.HeaderText = "# of Points in TO DO";
            ToDo.Name = "ToDo";
            // 
            // InProgress
            // 
            InProgress.HeaderText = "# of Points in IN PROGRESS";
            InProgress.Name = "InProgress";
            // 
            // Done
            // 
            Done.HeaderText = "# of Points in DONE";
            Done.Name = "Done";
            // 
            // EndOfSprintReport
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(721, 625);
            Controls.Add(ComponentsTable);
            Controls.Add(OkayButton);
            Controls.Add(CancelButton);
            Controls.Add(InitInfoLabel);
            Name = "EndOfSprintReport";
            Text = "End of Sprint Report";
            ((System.ComponentModel.ISupportInitialize)ComponentsTable).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label InitInfoLabel;
        private Button OkayButton;
        private Button CancelButton;
        private DataGridView ComponentsTable;
        private DataGridViewTextBoxColumn Component;
        private DataGridViewTextBoxColumn Backlog;
        private DataGridViewTextBoxColumn ToDo;
        private DataGridViewTextBoxColumn InProgress;
        private DataGridViewTextBoxColumn Done;
    }
}