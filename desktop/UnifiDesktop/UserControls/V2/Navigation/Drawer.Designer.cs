namespace UnifiDesktop.UserControls.V2
{
    partial class Drawer
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
            this.pnlDrawer = new System.Windows.Forms.Panel();
            this.pnlCloseMenu = new System.Windows.Forms.Panel();
            this.lblCloseDrawer = new System.Windows.Forms.Label();
            this.pnlCloseMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlDrawer
            // 
            this.pnlDrawer.BackColor = System.Drawing.SystemColors.Control;
            this.pnlDrawer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDrawer.Location = new System.Drawing.Point(0, 32);
            this.pnlDrawer.Name = "pnlDrawer";
            this.pnlDrawer.Size = new System.Drawing.Size(180, 506);
            this.pnlDrawer.TabIndex = 1;
            // 
            // pnlCloseMenu
            // 
            this.pnlCloseMenu.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlCloseMenu.Controls.Add(this.lblCloseDrawer);
            this.pnlCloseMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCloseMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlCloseMenu.Name = "pnlCloseMenu";
            this.pnlCloseMenu.Size = new System.Drawing.Size(180, 32);
            this.pnlCloseMenu.TabIndex = 3;
            this.pnlCloseMenu.Resize += new System.EventHandler(this.pnlCloseMenu_Resize);
            // 
            // lblCloseDrawer
            // 
            this.lblCloseDrawer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCloseDrawer.AutoSize = true;
            this.lblCloseDrawer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblCloseDrawer.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCloseDrawer.Location = new System.Drawing.Point(146, 7);
            this.lblCloseDrawer.Name = "lblCloseDrawer";
            this.lblCloseDrawer.Size = new System.Drawing.Size(19, 18);
            this.lblCloseDrawer.TabIndex = 0;
            this.lblCloseDrawer.Text = "<";
            this.lblCloseDrawer.Click += new System.EventHandler(this.lblCloseDrawer_Click);
            // 
            // Drawer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.pnlDrawer);
            this.Controls.Add(this.pnlCloseMenu);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Drawer";
            this.Size = new System.Drawing.Size(180, 538);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SwipablePanel_KeyDown);
            this.pnlCloseMenu.ResumeLayout(false);
            this.pnlCloseMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlDrawer;
        private System.Windows.Forms.Panel pnlCloseMenu;
        private System.Windows.Forms.Label lblCloseDrawer;
    }
}
