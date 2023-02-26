namespace UnifiDesktop.UserControls.V2
{
    partial class NavBarDrawer
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
            this.pnlLeftGap = new System.Windows.Forms.Panel();
            this.pnlMainControlsPanel = new System.Windows.Forms.Panel();
            this.navBar1 = new UnifiDesktop.UserControls.V2.NavBar();
            this.drawer1 = new UnifiDesktop.UserControls.V2.Drawer();
            this.drawer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlLeftGap
            // 
            this.pnlLeftGap.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeftGap.Location = new System.Drawing.Point(180, 32);
            this.pnlLeftGap.Name = "pnlLeftGap";
            this.pnlLeftGap.Size = new System.Drawing.Size(11, 535);
            this.pnlLeftGap.TabIndex = 2;
            // 
            // pnlMainControlsPanel
            // 
            this.pnlMainControlsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainControlsPanel.Location = new System.Drawing.Point(191, 32);
            this.pnlMainControlsPanel.Name = "pnlMainControlsPanel";
            this.pnlMainControlsPanel.Size = new System.Drawing.Size(746, 535);
            this.pnlMainControlsPanel.TabIndex = 3;
            // 
            // navBar1
            // 
            this.navBar1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.navBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.navBar1.Location = new System.Drawing.Point(180, 0);
            this.navBar1.Name = "navBar1";
            this.navBar1.Size = new System.Drawing.Size(757, 32);
            this.navBar1.TabIndex = 1;
            // 
            // drawer1
            // 
            this.drawer1.BackColor = System.Drawing.SystemColors.Control;
            this.drawer1.ClosePanelHeight = 32;
            this.drawer1.Dock = System.Windows.Forms.DockStyle.Left;
            this.drawer1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // drawer1.InnerPanel
            // 
            this.drawer1.InnerPanel.BackColor = System.Drawing.SystemColors.Control;
            this.drawer1.InnerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.drawer1.InnerPanel.Location = new System.Drawing.Point(0, 32);
            this.drawer1.InnerPanel.Name = "InnerPanel";
            this.drawer1.InnerPanel.Size = new System.Drawing.Size(180, 535);
            this.drawer1.InnerPanel.TabIndex = 1;
            this.drawer1.Location = new System.Drawing.Point(0, 0);
            this.drawer1.Name = "drawer1";
            this.drawer1.Size = new System.Drawing.Size(180, 567);
            this.drawer1.TabIndex = 0;
            // 
            // NavBarDrawer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlMainControlsPanel);
            this.Controls.Add(this.pnlLeftGap);
            this.Controls.Add(this.navBar1);
            this.Controls.Add(this.drawer1);
            this.Name = "NavBarDrawer";
            this.Size = new System.Drawing.Size(937, 567);
            this.drawer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Drawer drawer1;
        private NavBar navBar1;
        private System.Windows.Forms.Panel pnlLeftGap;
        private System.Windows.Forms.Panel pnlMainControlsPanel;
    }
}
