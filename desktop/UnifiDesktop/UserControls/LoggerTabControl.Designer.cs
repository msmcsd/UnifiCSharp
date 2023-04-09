namespace UnifiDesktop.UserControls
{
    partial class LoggerTabControl
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
            this.tabLog = new System.Windows.Forms.TabPage();
            this.LogConsole = new System.Windows.Forms.RichTextBox();
            this.tabErrors = new System.Windows.Forms.TabPage();
            this.tabDebug = new System.Windows.Forms.TabPage();
            this.DebugConsole = new System.Windows.Forms.RichTextBox();
            this.ErrorConsole = new UnifiDesktop.UserControls.ErrorConsole();
            this.tabControl.SuspendLayout();
            this.tabLog.SuspendLayout();
            this.tabErrors.SuspendLayout();
            this.tabDebug.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl.Controls.Add(this.tabLog);
            this.tabControl.Controls.Add(this.tabErrors);
            this.tabControl.Controls.Add(this.tabDebug);
            this.tabControl.ItemSize = new System.Drawing.Size(0, 1);
            this.tabControl.Size = new System.Drawing.Size(429, 341);
            this.tabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            // 
            // tabLog
            // 
            this.tabLog.Controls.Add(this.LogConsole);
            this.tabLog.Location = new System.Drawing.Point(4, 5);
            this.tabLog.Name = "tabLog";
            this.tabLog.Size = new System.Drawing.Size(421, 332);
            this.tabLog.TabIndex = 0;
            this.tabLog.Text = "Log";
            this.tabLog.UseVisualStyleBackColor = true;
            // 
            // LogConsole
            // 
            this.LogConsole.BackColor = System.Drawing.SystemColors.Control;
            this.LogConsole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogConsole.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogConsole.Location = new System.Drawing.Point(0, 0);
            this.LogConsole.Name = "LogConsole";
            this.LogConsole.ReadOnly = true;
            this.LogConsole.Size = new System.Drawing.Size(421, 332);
            this.LogConsole.TabIndex = 2;
            this.LogConsole.Text = "";
            // 
            // tabErrors
            // 
            this.tabErrors.Controls.Add(this.ErrorConsole);
            this.tabErrors.Location = new System.Drawing.Point(4, 5);
            this.tabErrors.Name = "tabErrors";
            this.tabErrors.Size = new System.Drawing.Size(421, 332);
            this.tabErrors.TabIndex = 1;
            this.tabErrors.Text = "Errors";
            this.tabErrors.UseVisualStyleBackColor = true;
            // 
            // tabDebug
            // 
            this.tabDebug.Controls.Add(this.DebugConsole);
            this.tabDebug.Location = new System.Drawing.Point(4, 5);
            this.tabDebug.Name = "tabDebug";
            this.tabDebug.Size = new System.Drawing.Size(260, 229);
            this.tabDebug.TabIndex = 2;
            this.tabDebug.Text = "Debug";
            this.tabDebug.UseVisualStyleBackColor = true;
            // 
            // DebugConsole
            // 
            this.DebugConsole.BackColor = System.Drawing.SystemColors.Control;
            this.DebugConsole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DebugConsole.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DebugConsole.Location = new System.Drawing.Point(0, 0);
            this.DebugConsole.Name = "DebugConsole";
            this.DebugConsole.ReadOnly = true;
            this.DebugConsole.Size = new System.Drawing.Size(260, 229);
            this.DebugConsole.TabIndex = 3;
            this.DebugConsole.Text = "";
            // 
            // ErrorConsole
            // 
            this.ErrorConsole.BackColor = System.Drawing.SystemColors.Control;
            this.ErrorConsole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ErrorConsole.Location = new System.Drawing.Point(0, 0);
            this.ErrorConsole.Name = "ErrorConsole";
            this.ErrorConsole.Size = new System.Drawing.Size(421, 332);
            this.ErrorConsole.TabIndex = 0;
            this.ErrorConsole.Text = "";
            this.ErrorConsole.WordWrap = false;
            // 
            // LoggerTabControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "LoggerTabControl";
            this.Size = new System.Drawing.Size(429, 373);
            this.tabControl.ResumeLayout(false);
            this.tabLog.ResumeLayout(false);
            this.tabErrors.ResumeLayout(false);
            this.tabDebug.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabLog;
        private System.Windows.Forms.TabPage tabErrors;
        public System.Windows.Forms.RichTextBox LogConsole;
        private System.Windows.Forms.TabPage tabDebug;
        public System.Windows.Forms.RichTextBox DebugConsole;
        public ErrorConsole ErrorConsole;
    }
}
