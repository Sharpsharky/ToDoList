namespace ToDoListApp
{
    partial class MainForm
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
            this.txtTask = new System.Windows.Forms.TextBox();
            this.btnAddTask = new System.Windows.Forms.Button();
            this.lstTasks = new System.Windows.Forms.ListBox();
            this.btnRemoveTask = new System.Windows.Forms.Button();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.btnUpdateStatus = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBoxBottom = new System.Windows.Forms.GroupBox();
            this.btnSort = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBoxBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTask
            // 
            this.txtTask.AccessibleName = "txtTask";
            this.txtTask.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTask.Location = new System.Drawing.Point(48, 20);
            this.txtTask.MaxLength = 120;
            this.txtTask.Name = "txtTask";
            this.txtTask.Size = new System.Drawing.Size(214, 20);
            this.txtTask.TabIndex = 0;
            // 
            // btnAddTask
            // 
            this.btnAddTask.AccessibleName = "btnAddTask";
            this.btnAddTask.Location = new System.Drawing.Point(193, 48);
            this.btnAddTask.Name = "btnAddTask";
            this.btnAddTask.Size = new System.Drawing.Size(69, 21);
            this.btnAddTask.TabIndex = 1;
            this.btnAddTask.Text = "Add";
            this.btnAddTask.UseVisualStyleBackColor = true;
            // 
            // lstTasks
            // 
            this.lstTasks.AccessibleName = "lstTasks";
            this.lstTasks.AllowDrop = true;
            this.lstTasks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstTasks.BackColor = System.Drawing.SystemColors.Window;
            this.lstTasks.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lstTasks.FormattingEnabled = true;
            this.lstTasks.HorizontalScrollbar = true;
            this.lstTasks.Location = new System.Drawing.Point(9, 36);
            this.lstTasks.Margin = new System.Windows.Forms.Padding(10);
            this.lstTasks.Name = "lstTasks";
            this.lstTasks.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lstTasks.Size = new System.Drawing.Size(250, 173);
            this.lstTasks.TabIndex = 2;
            this.lstTasks.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lstTasks_DrawItem);
            this.lstTasks.DragDrop += new System.Windows.Forms.DragEventHandler(this.lstTasks_DragDrop);
            this.lstTasks.DragOver += new System.Windows.Forms.DragEventHandler(this.lstTasks_DragOver);
            this.lstTasks.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lstTasks_MouseDown);
            // 
            // btnRemoveTask
            // 
            this.btnRemoveTask.AccessibleName = "btnRemoveTask";
            this.btnRemoveTask.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveTask.Location = new System.Drawing.Point(166, 230);
            this.btnRemoveTask.Name = "btnRemoveTask";
            this.btnRemoveTask.Size = new System.Drawing.Size(93, 23);
            this.btnRemoveTask.TabIndex = 3;
            this.btnRemoveTask.Text = "Remove";
            this.btnRemoveTask.UseVisualStyleBackColor = true;
            // 
            // cmbStatus
            // 
            this.cmbStatus.AccessibleName = "cmbStatus";
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(9, 48);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(179, 21);
            this.cmbStatus.TabIndex = 4;
            // 
            // btnUpdateStatus
            // 
            this.btnUpdateStatus.AccessibleName = "btnUpdateStatus";
            this.btnUpdateStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUpdateStatus.Location = new System.Drawing.Point(9, 230);
            this.btnUpdateStatus.Name = "btnUpdateStatus";
            this.btnUpdateStatus.Size = new System.Drawing.Size(93, 23);
            this.btnUpdateStatus.TabIndex = 5;
            this.btnUpdateStatus.Text = "Update";
            this.btnUpdateStatus.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Label:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 11F);
            this.label2.Location = new System.Drawing.Point(6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 18);
            this.label2.TabIndex = 7;
            this.label2.Text = "Tasks";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(268, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "To-Do List";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtTask);
            this.groupBox1.Controls.Add(this.cmbStatus);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnAddTask);
            this.groupBox1.Location = new System.Drawing.Point(8, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(268, 84);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Calibri", 11F);
            this.label4.Location = new System.Drawing.Point(6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "New Task";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // groupBoxBottom
            // 
            this.groupBoxBottom.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxBottom.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxBottom.Controls.Add(this.label2);
            this.groupBoxBottom.Controls.Add(this.btnRemoveTask);
            this.groupBoxBottom.Controls.Add(this.btnUpdateStatus);
            this.groupBoxBottom.Controls.Add(this.btnSort);
            this.groupBoxBottom.Controls.Add(this.lstTasks);
            this.groupBoxBottom.Location = new System.Drawing.Point(8, 139);
            this.groupBoxBottom.Name = "groupBoxBottom";
            this.groupBoxBottom.Size = new System.Drawing.Size(268, 263);
            this.groupBoxBottom.TabIndex = 10;
            this.groupBoxBottom.TabStop = false;
            // 
            // btnSort
            // 
            this.btnSort.AccessibleName = "btnUpdateStatus";
            this.btnSort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSort.AutoSize = true;
            this.btnSort.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSort.Location = new System.Drawing.Point(190, 0);
            this.btnSort.MaximumSize = new System.Drawing.Size(120, 23);
            this.btnSort.MinimumSize = new System.Drawing.Size(69, 23);
            this.btnSort.Name = "btnSort";
            this.btnSort.Size = new System.Drawing.Size(69, 23);
            this.btnSort.TabIndex = 9;
            this.btnSort.Text = "Sort";
            this.btnSort.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 411);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxBottom);
            this.MinimumSize = new System.Drawing.Size(300, 450);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBoxBottom.ResumeLayout(false);
            this.groupBoxBottom.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtTask;
        private System.Windows.Forms.Button btnAddTask;
        private System.Windows.Forms.ListBox lstTasks;
        private System.Windows.Forms.Button btnRemoveTask;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Button btnUpdateStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBoxBottom;
        private System.Windows.Forms.Button btnSort;
    }
}