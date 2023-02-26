namespace UnifiDesktop.UserControls.V2
{
    partial class NavBar
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
            this.lblAppName = new System.Windows.Forms.Label();
            this.hamburgerMenu1 = new UnifiDesktop.UserControls.V2.HamburgerMenu();
            this.SuspendLayout();
            // 
            // lblAppName
            // 
            this.lblAppName.AutoSize = true;
            this.lblAppName.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppName.Location = new System.Drawing.Point(43, 3);
            this.lblAppName.Name = "lblAppName";
            this.lblAppName.Size = new System.Drawing.Size(77, 18);
            this.lblAppName.TabIndex = 1;
            this.lblAppName.Text = "App Name";
            // 
            // hamburgerMenu1
            // 
            this.hamburgerMenu1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hamburgerMenu1.HamburgerForeColor = System.Drawing.SystemColors.ControlText;
            this.hamburgerMenu1.Location = new System.Drawing.Point(13, 3);
            this.hamburgerMenu1.Name = "hamburgerMenu1";
            this.hamburgerMenu1.Size = new System.Drawing.Size(24, 22);
            this.hamburgerMenu1.TabIndex = 0;
            // 
            // NavBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.hamburgerMenu1);
            this.Controls.Add(this.lblAppName);
            this.Name = "NavBar";
            this.Size = new System.Drawing.Size(773, 28);
            this.Resize += new System.EventHandler(this.NavBar_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblAppName;
        private HamburgerMenu hamburgerMenu1;
    }
}
