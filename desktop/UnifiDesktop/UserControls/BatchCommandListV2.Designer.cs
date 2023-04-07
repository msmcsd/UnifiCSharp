namespace UnifiDesktop.UserControls
{
    partial class BatchCommandListV2
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
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lstList = new UnifiDesktop.UserControls.ListBox.ListBoxV2();
            this.lstCommands = new System.Windows.Forms.ListView();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.ItemSize = new System.Drawing.Size(0, 1);
            this.tabControl.Size = new System.Drawing.Size(298, 287);
            this.tabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lstList);
            this.tabPage1.Location = new System.Drawing.Point(4, 5);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(290, 278);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "List";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lstCommands);
            this.tabPage2.Location = new System.Drawing.Point(4, 5);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(290, 278);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Commands";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lstList
            // 
            this.lstList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstList.FormattingEnabled = true;
            this.lstList.Location = new System.Drawing.Point(0, 0);
            this.lstList.Name = "lstList";
            this.lstList.Size = new System.Drawing.Size(290, 278);
            this.lstList.TabIndex = 0;
            // 
            // lstCommands
            // 
            this.lstCommands.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstCommands.HideSelection = false;
            this.lstCommands.Location = new System.Drawing.Point(0, 0);
            this.lstCommands.Name = "lstCommands";
            this.lstCommands.Size = new System.Drawing.Size(290, 278);
            this.lstCommands.TabIndex = 0;
            this.lstCommands.UseCompatibleStateImageBehavior = false;
            this.lstCommands.View = System.Windows.Forms.View.Details;
            // 
            // BatchCommandListV2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "BatchCommandListV2";
            this.Size = new System.Drawing.Size(298, 319);
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private ListBox.ListBoxV2 lstList;
        private System.Windows.Forms.ListView lstCommands;
    }
}
