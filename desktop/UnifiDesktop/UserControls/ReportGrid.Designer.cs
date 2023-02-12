
namespace Unifi.UserControls
{
    partial class ReportGrid
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
            this.lstReport = new System.Windows.Forms.ListView();
            this.CategoryHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TestHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.KeywordHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // lstReport
            // 
            this.lstReport.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.CategoryHeader,
            this.TestHeader,
            this.KeywordHeader});
            this.lstReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstReport.FullRowSelect = true;
            this.lstReport.HideSelection = false;
            this.lstReport.Location = new System.Drawing.Point(0, 0);
            this.lstReport.MultiSelect = false;
            this.lstReport.Name = "lstReport";
            this.lstReport.Size = new System.Drawing.Size(436, 256);
            this.lstReport.TabIndex = 3;
            this.lstReport.UseCompatibleStateImageBehavior = false;
            this.lstReport.View = System.Windows.Forms.View.Details;
            this.lstReport.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lstReport_ColumnClick);
            this.lstReport.DoubleClick += new System.EventHandler(this.lstReport_DoubleClick);
            // 
            // CategoryHeader
            // 
            this.CategoryHeader.Text = "Category";
            this.CategoryHeader.Width = 106;
            // 
            // TestHeader
            // 
            this.TestHeader.Text = "Test";
            this.TestHeader.Width = 133;
            // 
            // KeywordHeader
            // 
            this.KeywordHeader.Text = "Keyword";
            this.KeywordHeader.Width = 146;
            // 
            // ReportGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lstReport);
            this.Name = "ReportGrid";
            this.Size = new System.Drawing.Size(436, 256);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lstReport;
        private System.Windows.Forms.ColumnHeader CategoryHeader;
        private System.Windows.Forms.ColumnHeader TestHeader;
        private System.Windows.Forms.ColumnHeader KeywordHeader;
    }
}
