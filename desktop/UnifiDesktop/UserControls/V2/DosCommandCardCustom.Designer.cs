namespace UnifiDesktop.UserControls.V2
{
    partial class DosCommandCardCustom
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
            this.lblGroupDesc = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblGroupDesc
            // 
            this.lblGroupDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGroupDesc.BackColor = System.Drawing.SystemColors.Control;
            this.lblGroupDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGroupDesc.Location = new System.Drawing.Point(16, 4);
            this.lblGroupDesc.Name = "lblGroupDesc";
            this.lblGroupDesc.Size = new System.Drawing.Size(138, 36);
            this.lblGroupDesc.TabIndex = 0;
            this.lblGroupDesc.Text = "This is the group description";
            this.lblGroupDesc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DosCommandCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.lblGroupDesc);
            this.Name = "DosCommandCard";
            this.Size = new System.Drawing.Size(170, 192);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.DosCommandCard_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblGroupDesc;
    }
}
