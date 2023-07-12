namespace UnifiDesktop.UserControls
{
    partial class BatchCommandList
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmbList = new System.Windows.Forms.ComboBox();
            this.lstCommands = new System.Windows.Forms.ListView();
            this.colStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCommand = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnRun = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbList
            // 
            this.cmbList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbList.FormattingEnabled = true;
            this.cmbList.Location = new System.Drawing.Point(0, 0);
            this.cmbList.Name = "cmbList";
            this.cmbList.Size = new System.Drawing.Size(179, 21);
            this.cmbList.TabIndex = 0;
            this.cmbList.SelectedIndexChanged += new System.EventHandler(this.cmbList_SelectedIndexChanged);
            // 
            // lstCommands
            // 
            this.lstCommands.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstCommands.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colStatus,
            this.colCommand});
            this.lstCommands.FullRowSelect = true;
            this.lstCommands.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lstCommands.HideSelection = false;
            this.lstCommands.Location = new System.Drawing.Point(0, 23);
            this.lstCommands.MultiSelect = false;
            this.lstCommands.Name = "lstCommands";
            this.lstCommands.Size = new System.Drawing.Size(227, 197);
            this.lstCommands.TabIndex = 1;
            this.lstCommands.UseCompatibleStateImageBehavior = false;
            this.lstCommands.View = System.Windows.Forms.View.Details;
            this.lstCommands.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.lstCommands_DrawItem);
            this.lstCommands.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.lstCommands_DrawSubItem);
            this.lstCommands.DoubleClick += new System.EventHandler(this.lstCommands_DoubleClick);
            // 
            // colStatus
            // 
            this.colStatus.Width = 20;
            // 
            // colCommand
            // 
            this.colCommand.Width = 169;
            // 
            // btnRun
            // 
            this.btnRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRun.Location = new System.Drawing.Point(179, -1);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(48, 23);
            this.btnRun.TabIndex = 2;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // BatchCommandList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.cmbList);
            this.Controls.Add(this.lstCommands);
            this.Name = "BatchCommandList";
            this.Size = new System.Drawing.Size(227, 220);
            this.Resize += new System.EventHandler(this.BatchCommandList_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbList;
        private System.Windows.Forms.ListView lstCommands;
        private System.Windows.Forms.ColumnHeader colStatus;
        private System.Windows.Forms.ColumnHeader colCommand;
        private System.Windows.Forms.Button btnRun;
    }
}
