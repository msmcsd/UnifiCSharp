namespace UnifiDesktop.UserControls
{
    partial class VersionGrid
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
            this.lstVersion = new System.Windows.Forms.ListView();
            this.colFile = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // lstVersion
            // 
            this.lstVersion.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colFile,
            this.colVersion});
            this.lstVersion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstVersion.FullRowSelect = true;
            this.lstVersion.HideSelection = false;
            this.lstVersion.Location = new System.Drawing.Point(0, 0);
            this.lstVersion.Name = "lstVersion";
            this.lstVersion.Size = new System.Drawing.Size(314, 194);
            this.lstVersion.TabIndex = 0;
            this.lstVersion.UseCompatibleStateImageBehavior = false;
            this.lstVersion.View = System.Windows.Forms.View.Details;
            // 
            // colFile
            // 
            this.colFile.Text = "File";
            // 
            // colVersion
            // 
            this.colVersion.Text = "Version";
            // 
            // VersionGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lstVersion);
            this.Name = "VersionGrid";
            this.Size = new System.Drawing.Size(314, 194);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lstVersion;
        private System.Windows.Forms.ColumnHeader colFile;
        private System.Windows.Forms.ColumnHeader colVersion;
    }
}
