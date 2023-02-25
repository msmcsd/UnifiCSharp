namespace UnifiDesktop.UserControls.V2
{
    partial class NavDrawer
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
            this.pnlNavBar = new System.Windows.Forms.Panel();
            this.lblAppName = new System.Windows.Forms.Label();
            this.pnlDrawer = new System.Windows.Forms.Panel();
            this.pnlClient = new System.Windows.Forms.Panel();
            this.pnlCloseMenu = new System.Windows.Forms.Panel();
            this.lblCloseDrawer = new System.Windows.Forms.Label();
            this.hamburgerMenu1 = new UnifiDesktop.UserControls.V2.HamburgerMenu();
            this.pnlNavBar.SuspendLayout();
            this.pnlDrawer.SuspendLayout();
            this.pnlCloseMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlNavBar
            // 
            this.pnlNavBar.Controls.Add(this.lblAppName);
            this.pnlNavBar.Controls.Add(this.hamburgerMenu1);
            this.pnlNavBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlNavBar.Location = new System.Drawing.Point(227, 0);
            this.pnlNavBar.Name = "pnlNavBar";
            this.pnlNavBar.Size = new System.Drawing.Size(592, 31);
            this.pnlNavBar.TabIndex = 0;
            // 
            // lblAppName
            // 
            this.lblAppName.AutoSize = true;
            this.lblAppName.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppName.Location = new System.Drawing.Point(32, 5);
            this.lblAppName.Name = "lblAppName";
            this.lblAppName.Size = new System.Drawing.Size(77, 18);
            this.lblAppName.TabIndex = 1;
            this.lblAppName.Text = "App Name";
            // 
            // pnlDrawer
            // 
            this.pnlDrawer.Controls.Add(this.pnlCloseMenu);
            this.pnlDrawer.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlDrawer.Location = new System.Drawing.Point(0, 0);
            this.pnlDrawer.Name = "pnlDrawer";
            this.pnlDrawer.Size = new System.Drawing.Size(227, 538);
            this.pnlDrawer.TabIndex = 1;
            // 
            // pnlClient
            // 
            this.pnlClient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlClient.Location = new System.Drawing.Point(227, 31);
            this.pnlClient.Name = "pnlClient";
            this.pnlClient.Size = new System.Drawing.Size(592, 507);
            this.pnlClient.TabIndex = 2;
            // 
            // pnlCloseMenu
            // 
            this.pnlCloseMenu.Controls.Add(this.lblCloseDrawer);
            this.pnlCloseMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCloseMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlCloseMenu.Name = "pnlCloseMenu";
            this.pnlCloseMenu.Size = new System.Drawing.Size(227, 31);
            this.pnlCloseMenu.TabIndex = 3;
            // 
            // lblCloseDrawer
            // 
            this.lblCloseDrawer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCloseDrawer.AutoSize = true;
            this.lblCloseDrawer.Location = new System.Drawing.Point(203, 9);
            this.lblCloseDrawer.Name = "lblCloseDrawer";
            this.lblCloseDrawer.Size = new System.Drawing.Size(15, 13);
            this.lblCloseDrawer.TabIndex = 0;
            this.lblCloseDrawer.Text = "<";
            // 
            // hamburgerMenu1
            // 
            this.hamburgerMenu1.Location = new System.Drawing.Point(3, 5);
            this.hamburgerMenu1.Name = "hamburgerMenu1";
            this.hamburgerMenu1.Size = new System.Drawing.Size(24, 21);
            this.hamburgerMenu1.TabIndex = 0;
            // 
            // NavDrawer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlClient);
            this.Controls.Add(this.pnlNavBar);
            this.Controls.Add(this.pnlDrawer);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "NavDrawer";
            this.Size = new System.Drawing.Size(819, 538);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SwipablePanel_KeyDown);
            this.pnlNavBar.ResumeLayout(false);
            this.pnlNavBar.PerformLayout();
            this.pnlDrawer.ResumeLayout(false);
            this.pnlCloseMenu.ResumeLayout(false);
            this.pnlCloseMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlNavBar;
        private System.Windows.Forms.Panel pnlDrawer;
        private System.Windows.Forms.Label lblAppName;
        private HamburgerMenu hamburgerMenu1;
        private System.Windows.Forms.Panel pnlClient;
        private System.Windows.Forms.Panel pnlCloseMenu;
        private System.Windows.Forms.Label lblCloseDrawer;
    }
}
