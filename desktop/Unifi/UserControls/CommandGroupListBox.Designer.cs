
namespace Unifi.UserControls
{
    partial class CommandGroupListBox
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
            this.grpCommand = new System.Windows.Forms.GroupBox();
            this.lstCommand = new System.Windows.Forms.ListBox();
            this.grpCommand.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpCommand
            // 
            this.grpCommand.Controls.Add(this.lstCommand);
            this.grpCommand.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpCommand.Location = new System.Drawing.Point(0, 0);
            this.grpCommand.Name = "grpCommand";
            this.grpCommand.Size = new System.Drawing.Size(150, 150);
            this.grpCommand.TabIndex = 1;
            this.grpCommand.TabStop = false;
            this.grpCommand.Text = "Group Name";
            // 
            // lstCommand
            // 
            this.lstCommand.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstCommand.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.lstCommand.FormattingEnabled = true;
            this.lstCommand.Location = new System.Drawing.Point(3, 16);
            this.lstCommand.Name = "lstCommand";
            this.lstCommand.Size = new System.Drawing.Size(144, 131);
            this.lstCommand.TabIndex = 0;
            this.lstCommand.Click += new System.EventHandler(this.lstCommand_Click);
            this.lstCommand.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lstCommand_DrawItem);
            this.lstCommand.DoubleClick += new System.EventHandler(this.lstCommand_DoubleClick);
            this.lstCommand.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lstCommand_MouseDown);
            // 
            // CommandGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpCommand);
            this.Name = "CommandGroup";
            this.grpCommand.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpCommand;
        private System.Windows.Forms.ListBox lstCommand;
    }
}
