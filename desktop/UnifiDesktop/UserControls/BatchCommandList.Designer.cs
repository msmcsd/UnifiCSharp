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
            this.SuspendLayout();
            // 
            // cmbList
            // 
            this.cmbList.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmbList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbList.FormattingEnabled = true;
            this.cmbList.Location = new System.Drawing.Point(0, 0);
            this.cmbList.Name = "cmbList";
            this.cmbList.Size = new System.Drawing.Size(214, 21);
            this.cmbList.TabIndex = 0;
            this.cmbList.SelectedIndexChanged += new System.EventHandler(this.cmbList_SelectedIndexChanged);
            // 
            // lstCommands
            // 
            this.lstCommands.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colStatus,
            this.colCommand});
            this.lstCommands.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstCommands.FullRowSelect = true;
            this.lstCommands.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lstCommands.HideSelection = false;
            this.lstCommands.Location = new System.Drawing.Point(0, 21);
            this.lstCommands.MultiSelect = false;
            this.lstCommands.Name = "lstCommands";
            this.lstCommands.Size = new System.Drawing.Size(214, 190);
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
            // BatchCommandList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lstCommands);
            this.Controls.Add(this.cmbList);
            this.Name = "BatchCommandList";
            this.Size = new System.Drawing.Size(214, 211);
            this.Resize += new System.EventHandler(this.BatchCommandList_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbList;
        private System.Windows.Forms.ListView lstCommands;
        private System.Windows.Forms.ColumnHeader colStatus;
        private System.Windows.Forms.ColumnHeader colCommand;
    }
}
