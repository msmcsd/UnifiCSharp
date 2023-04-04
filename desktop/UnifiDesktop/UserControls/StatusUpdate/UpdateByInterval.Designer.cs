namespace UnifiDesktop.UserControls.StatusUpdate
{
    partial class UpdateByInterval
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
            this.lstItems = new System.Windows.Forms.ListView();
            this.colField1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colField2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblInverval = new System.Windows.Forms.Label();
            this.rbSeconds60 = new System.Windows.Forms.RadioButton();
            this.rbSeconds5 = new System.Windows.Forms.RadioButton();
            this.rbNone = new System.Windows.Forms.RadioButton();
            this.pnlInterval = new System.Windows.Forms.Panel();
            this.pnlInterval.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstItems
            // 
            this.lstItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colField1,
            this.colField2});
            this.lstItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstItems.FullRowSelect = true;
            this.lstItems.HideSelection = false;
            this.lstItems.Location = new System.Drawing.Point(0, 48);
            this.lstItems.MultiSelect = false;
            this.lstItems.Name = "lstItems";
            this.lstItems.Size = new System.Drawing.Size(198, 233);
            this.lstItems.TabIndex = 6;
            this.lstItems.UseCompatibleStateImageBehavior = false;
            this.lstItems.View = System.Windows.Forms.View.Details;
            this.lstItems.DoubleClick += new System.EventHandler(this.lstItems_DoubleClick);
            // 
            // colField1
            // 
            this.colField1.Text = "Field1";
            this.colField1.Width = 83;
            // 
            // colField2
            // 
            this.colField2.Text = "Field2";
            this.colField2.Width = 92;
            // 
            // lblInverval
            // 
            this.lblInverval.AutoSize = true;
            this.lblInverval.Location = new System.Drawing.Point(6, 7);
            this.lblInverval.Name = "lblInverval";
            this.lblInverval.Size = new System.Drawing.Size(55, 13);
            this.lblInverval.TabIndex = 5;
            this.lblInverval.Text = "Intverval:";
            // 
            // rbSeconds60
            // 
            this.rbSeconds60.AutoSize = true;
            this.rbSeconds60.Location = new System.Drawing.Point(120, 25);
            this.rbSeconds60.Name = "rbSeconds60";
            this.rbSeconds60.Size = new System.Drawing.Size(42, 17);
            this.rbSeconds60.TabIndex = 9;
            this.rbSeconds60.Tag = "60";
            this.rbSeconds60.Text = "60s";
            this.rbSeconds60.UseVisualStyleBackColor = true;
            this.rbSeconds60.Click += new System.EventHandler(this.TimerInternvalClick);
            // 
            // rbSeconds5
            // 
            this.rbSeconds5.AutoSize = true;
            this.rbSeconds5.Location = new System.Drawing.Point(63, 25);
            this.rbSeconds5.Name = "rbSeconds5";
            this.rbSeconds5.Size = new System.Drawing.Size(36, 17);
            this.rbSeconds5.TabIndex = 8;
            this.rbSeconds5.Tag = "5";
            this.rbSeconds5.Text = "5s";
            this.rbSeconds5.UseVisualStyleBackColor = true;
            this.rbSeconds5.Click += new System.EventHandler(this.TimerInternvalClick);
            // 
            // rbNone
            // 
            this.rbNone.AutoSize = true;
            this.rbNone.Checked = true;
            this.rbNone.Location = new System.Drawing.Point(63, 5);
            this.rbNone.Name = "rbNone";
            this.rbNone.Size = new System.Drawing.Size(50, 17);
            this.rbNone.TabIndex = 7;
            this.rbNone.TabStop = true;
            this.rbNone.Tag = "0";
            this.rbNone.Text = "None";
            this.rbNone.UseVisualStyleBackColor = true;
            this.rbNone.Click += new System.EventHandler(this.TimerInternvalClick);
            // 
            // pnlInterval
            // 
            this.pnlInterval.Controls.Add(this.lblInverval);
            this.pnlInterval.Controls.Add(this.rbNone);
            this.pnlInterval.Controls.Add(this.rbSeconds5);
            this.pnlInterval.Controls.Add(this.rbSeconds60);
            this.pnlInterval.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlInterval.Location = new System.Drawing.Point(0, 0);
            this.pnlInterval.Name = "pnlInterval";
            this.pnlInterval.Size = new System.Drawing.Size(198, 48);
            this.pnlInterval.TabIndex = 10;
            // 
            // UpdateByInterval
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lstItems);
            this.Controls.Add(this.pnlInterval);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "UpdateByInterval";
            this.Size = new System.Drawing.Size(198, 281);
            this.pnlInterval.ResumeLayout(false);
            this.pnlInterval.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblInverval;
        private System.Windows.Forms.RadioButton rbSeconds60;
        private System.Windows.Forms.RadioButton rbSeconds5;
        private System.Windows.Forms.RadioButton rbNone;
        protected System.Windows.Forms.ColumnHeader colField1;
        protected System.Windows.Forms.ColumnHeader colField2;
        protected System.Windows.Forms.ListView lstItems;
        private System.Windows.Forms.Panel pnlInterval;
    }
}
