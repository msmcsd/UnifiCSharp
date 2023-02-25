namespace UnifiDesktop.UserControls.V2
{
    partial class DosCommandsTabControl
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
            this.tabCommands = new System.Windows.Forms.TabControl();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.lblUnderline = new System.Windows.Forms.Label();
            this.pnlContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabCommands
            // 
            this.tabCommands.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabCommands.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabCommands.ItemSize = new System.Drawing.Size(0, 1);
            this.tabCommands.Location = new System.Drawing.Point(0, 0);
            this.tabCommands.Name = "tabCommands";
            this.tabCommands.SelectedIndex = 0;
            this.tabCommands.Size = new System.Drawing.Size(362, 424);
            this.tabCommands.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabCommands.TabIndex = 0;
            this.tabCommands.SelectedIndexChanged += new System.EventHandler(this.tabCommands_SelectedIndexChanged);
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.SystemColors.Control;
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(362, 32);
            this.pnlHeader.TabIndex = 1;
            // 
            // pnlContainer
            // 
            this.pnlContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlContainer.Controls.Add(this.tabCommands);
            this.pnlContainer.Location = new System.Drawing.Point(0, 38);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(362, 424);
            this.pnlContainer.TabIndex = 2;
            // 
            // lblUnderline
            // 
            this.lblUnderline.BackColor = System.Drawing.SystemColors.Highlight;
            this.lblUnderline.Location = new System.Drawing.Point(4, 31);
            this.lblUnderline.Name = "lblUnderline";
            this.lblUnderline.Size = new System.Drawing.Size(100, 2);
            this.lblUnderline.TabIndex = 3;
            // 
            // DosCommandsTabControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.lblUnderline);
            this.Controls.Add(this.pnlContainer);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "DosCommandsTabControl";
            this.Size = new System.Drawing.Size(362, 462);
            this.pnlContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabCommands;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlContainer;
        private System.Windows.Forms.Label lblUnderline;
    }
}
