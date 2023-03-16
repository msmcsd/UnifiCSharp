namespace UnifiDesktop.UserControls
{
    partial class ServiceStatus
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
            this.lblInverval = new System.Windows.Forms.Label();
            this.lstService = new System.Windows.Forms.ListView();
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.rbNone = new System.Windows.Forms.RadioButton();
            this.rbSeconds5 = new System.Windows.Forms.RadioButton();
            this.rbSeconds60 = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // lblInverval
            // 
            this.lblInverval.AutoSize = true;
            this.lblInverval.Location = new System.Drawing.Point(5, 6);
            this.lblInverval.Name = "lblInverval";
            this.lblInverval.Size = new System.Drawing.Size(55, 13);
            this.lblInverval.TabIndex = 0;
            this.lblInverval.Text = "Intverval:";
            // 
            // lstService
            // 
            this.lstService.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstService.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colStatus});
            this.lstService.FullRowSelect = true;
            this.lstService.HideSelection = false;
            this.lstService.Location = new System.Drawing.Point(0, 50);
            this.lstService.MultiSelect = false;
            this.lstService.Name = "lstService";
            this.lstService.Size = new System.Drawing.Size(191, 241);
            this.lstService.TabIndex = 1;
            this.lstService.UseCompatibleStateImageBehavior = false;
            this.lstService.View = System.Windows.Forms.View.Details;
            // 
            // colName
            // 
            this.colName.Text = "Service";
            this.colName.Width = 83;
            // 
            // colStatus
            // 
            this.colStatus.Text = "Status";
            this.colStatus.Width = 92;
            // 
            // rbNone
            // 
            this.rbNone.AutoSize = true;
            this.rbNone.Checked = true;
            this.rbNone.Location = new System.Drawing.Point(62, 4);
            this.rbNone.Name = "rbNone";
            this.rbNone.Size = new System.Drawing.Size(50, 17);
            this.rbNone.TabIndex = 2;
            this.rbNone.TabStop = true;
            this.rbNone.Text = "None";
            this.rbNone.UseVisualStyleBackColor = true;
            this.rbNone.Click += new System.EventHandler(this.TimerInternvalClick);
            // 
            // rbSeconds5
            // 
            this.rbSeconds5.AutoSize = true;
            this.rbSeconds5.Location = new System.Drawing.Point(62, 24);
            this.rbSeconds5.Name = "rbSeconds5";
            this.rbSeconds5.Size = new System.Drawing.Size(36, 17);
            this.rbSeconds5.TabIndex = 3;
            this.rbSeconds5.Tag = "5";
            this.rbSeconds5.Text = "5s";
            this.rbSeconds5.UseVisualStyleBackColor = true;
            this.rbSeconds5.Click += new System.EventHandler(this.TimerInternvalClick);
            // 
            // rbSeconds60
            // 
            this.rbSeconds60.AutoSize = true;
            this.rbSeconds60.Location = new System.Drawing.Point(119, 24);
            this.rbSeconds60.Name = "rbSeconds60";
            this.rbSeconds60.Size = new System.Drawing.Size(42, 17);
            this.rbSeconds60.TabIndex = 4;
            this.rbSeconds60.Tag = "60";
            this.rbSeconds60.Text = "60s";
            this.rbSeconds60.UseVisualStyleBackColor = true;
            this.rbSeconds60.Click += new System.EventHandler(this.TimerInternvalClick);
            // 
            // ServiceStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rbSeconds60);
            this.Controls.Add(this.rbSeconds5);
            this.Controls.Add(this.rbNone);
            this.Controls.Add(this.lstService);
            this.Controls.Add(this.lblInverval);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ServiceStatus";
            this.Size = new System.Drawing.Size(191, 291);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblInverval;
        private System.Windows.Forms.ListView lstService;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colStatus;
        private System.Windows.Forms.RadioButton rbNone;
        private System.Windows.Forms.RadioButton rbSeconds5;
        private System.Windows.Forms.RadioButton rbSeconds60;
    }
}
