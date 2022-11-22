
namespace Unifi.Forms
{
    partial class Report
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
            this.lstReport = new System.Windows.Forms.ListView();
            this.CategoryHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TestHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ResultHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtConsole = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // lstReport
            // 
            this.lstReport.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.CategoryHeader,
            this.TestHeader,
            this.ResultHeader});
            this.lstReport.Dock = System.Windows.Forms.DockStyle.Left;
            this.lstReport.FullRowSelect = true;
            this.lstReport.HideSelection = false;
            this.lstReport.Location = new System.Drawing.Point(0, 0);
            this.lstReport.MultiSelect = false;
            this.lstReport.Name = "lstReport";
            this.lstReport.Size = new System.Drawing.Size(459, 477);
            this.lstReport.TabIndex = 0;
            this.lstReport.UseCompatibleStateImageBehavior = false;
            this.lstReport.View = System.Windows.Forms.View.Details;
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
            // 
            // ResultHeader
            // 
            this.ResultHeader.Text = "Result";
            this.ResultHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtConsole
            // 
            this.txtConsole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtConsole.Location = new System.Drawing.Point(459, 0);
            this.txtConsole.Name = "txtConsole";
            this.txtConsole.Size = new System.Drawing.Size(344, 477);
            this.txtConsole.TabIndex = 1;
            this.txtConsole.Text = "";
            // 
            // Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 477);
            this.Controls.Add(this.txtConsole);
            this.Controls.Add(this.lstReport);
            this.Name = "Report";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report";
            this.Load += new System.EventHandler(this.Report_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lstReport;
        private System.Windows.Forms.ColumnHeader CategoryHeader;
        private System.Windows.Forms.ColumnHeader TestHeader;
        private System.Windows.Forms.ColumnHeader ResultHeader;
        private System.Windows.Forms.RichTextBox txtConsole;
    }
}