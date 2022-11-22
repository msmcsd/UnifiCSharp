
using Unifi.UserControls;

namespace Unifi.Forms
{
    partial class TestTool
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestTool));
            this.grpInstall = new System.Windows.Forms.GroupBox();
            this.lstDownload = new Unifi.UserControls.DownloadCommandGroup();
            this.lstInstall = new System.Windows.Forms.ListBox();
            this.txtInstallDir = new System.Windows.Forms.TextBox();
            this.lblInstallPath = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkDebugBuild = new System.Windows.Forms.CheckBox();
            this.grpConfig = new System.Windows.Forms.GroupBox();
            this.rbQa2 = new System.Windows.Forms.RadioButton();
            this.rbR02 = new System.Windows.Forms.RadioButton();
            this.rbR01 = new System.Windows.Forms.RadioButton();
            this.btnSetFunctionsToRun = new System.Windows.Forms.Button();
            this.txtFunctionsToRun = new System.Windows.Forms.TextBox();
            this.pnlTaskBar = new System.Windows.Forms.Panel();
            this.txtConsole = new System.Windows.Forms.RichTextBox();
            this.grpCommandGroups = new System.Windows.Forms.GroupBox();
            this.grpRollback = new System.Windows.Forms.GroupBox();
            this.lstRollbackPosition = new System.Windows.Forms.ListBox();
            this.grpReport = new System.Windows.Forms.GroupBox();
            this.reportGrid1 = new Unifi.UserControls.ReportGrid();
            this.lstBatchCommand = new System.Windows.Forms.ListBox();
            this.grpBatchCommand = new System.Windows.Forms.GroupBox();
            this.btnRunBatchCommand = new System.Windows.Forms.Button();
            this.cmbBatchCommand = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grpConsole = new System.Windows.Forms.GroupBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txtDebugger = new System.Windows.Forms.RichTextBox();
            this.grpInstall.SuspendLayout();
            this.grpConfig.SuspendLayout();
            this.grpRollback.SuspendLayout();
            this.grpReport.SuspendLayout();
            this.grpBatchCommand.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.grpConsole.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpInstall
            // 
            this.grpInstall.Controls.Add(this.lstDownload);
            this.grpInstall.Controls.Add(this.lstInstall);
            this.grpInstall.Controls.Add(this.txtInstallDir);
            this.grpInstall.Controls.Add(this.lblInstallPath);
            this.grpInstall.Controls.Add(this.panel1);
            this.grpInstall.Controls.Add(this.chkDebugBuild);
            this.grpInstall.Controls.Add(this.grpConfig);
            this.grpInstall.Dock = System.Windows.Forms.DockStyle.Left;
            this.grpInstall.Location = new System.Drawing.Point(0, 0);
            this.grpInstall.Name = "grpInstall";
            this.grpInstall.Padding = new System.Windows.Forms.Padding(10);
            this.grpInstall.Size = new System.Drawing.Size(176, 699);
            this.grpInstall.TabIndex = 0;
            this.grpInstall.TabStop = false;
            this.grpInstall.Text = "Install";
            // 
            // lstDownload
            // 
            this.lstDownload.CommandsRunner = null;
            this.lstDownload.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstDownload.GroupName = "Group Name";
            this.lstDownload.Location = new System.Drawing.Point(10, 339);
            this.lstDownload.Name = "lstDownload";
            this.lstDownload.Size = new System.Drawing.Size(156, 350);
            this.lstDownload.TabIndex = 17;
            // 
            // lstInstall
            // 
            this.lstInstall.Dock = System.Windows.Forms.DockStyle.Top;
            this.lstInstall.FormattingEnabled = true;
            this.lstInstall.Location = new System.Drawing.Point(10, 153);
            this.lstInstall.Name = "lstInstall";
            this.lstInstall.Size = new System.Drawing.Size(156, 186);
            this.lstInstall.TabIndex = 16;
            this.lstInstall.Tag = "Install";
            this.lstInstall.DoubleClick += new System.EventHandler(this.lstInstall_DoubleClick);
            this.lstInstall.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lstInstall_MouseDown);
            // 
            // txtInstallDir
            // 
            this.txtInstallDir.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtInstallDir.Location = new System.Drawing.Point(10, 119);
            this.txtInstallDir.Multiline = true;
            this.txtInstallDir.Name = "txtInstallDir";
            this.txtInstallDir.Size = new System.Drawing.Size(156, 34);
            this.txtInstallDir.TabIndex = 13;
            this.txtInstallDir.Text = "C:\\Program Files\\123";
            this.txtInstallDir.TextChanged += new System.EventHandler(this.txtInstallDir_TextChanged);
            // 
            // lblInstallPath
            // 
            this.lblInstallPath.AutoSize = true;
            this.lblInstallPath.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblInstallPath.Location = new System.Drawing.Point(10, 106);
            this.lblInstallPath.Name = "lblInstallPath";
            this.lblInstallPath.Size = new System.Drawing.Size(53, 13);
            this.lblInstallPath.TabIndex = 14;
            this.lblInstallPath.Text = "Install Dir:";
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(10, 85);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(156, 21);
            this.panel1.TabIndex = 18;
            // 
            // chkDebugBuild
            // 
            this.chkDebugBuild.AutoSize = true;
            this.chkDebugBuild.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkDebugBuild.Location = new System.Drawing.Point(10, 68);
            this.chkDebugBuild.Name = "chkDebugBuild";
            this.chkDebugBuild.Size = new System.Drawing.Size(156, 17);
            this.chkDebugBuild.TabIndex = 15;
            this.chkDebugBuild.Tag = "Debug";
            this.chkDebugBuild.Text = "Debug build";
            this.chkDebugBuild.UseVisualStyleBackColor = true;
            this.chkDebugBuild.CheckedChanged += new System.EventHandler(this.chkDebugBuild_CheckedChanged);
            // 
            // grpConfig
            // 
            this.grpConfig.Controls.Add(this.rbQa2);
            this.grpConfig.Controls.Add(this.rbR02);
            this.grpConfig.Controls.Add(this.rbR01);
            this.grpConfig.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpConfig.Location = new System.Drawing.Point(10, 23);
            this.grpConfig.Margin = new System.Windows.Forms.Padding(5);
            this.grpConfig.Name = "grpConfig";
            this.grpConfig.Size = new System.Drawing.Size(156, 45);
            this.grpConfig.TabIndex = 6;
            this.grpConfig.TabStop = false;
            this.grpConfig.Text = "config";
            // 
            // rbQa2
            // 
            this.rbQa2.AutoSize = true;
            this.rbQa2.Location = new System.Drawing.Point(87, 20);
            this.rbQa2.Name = "rbQa2";
            this.rbQa2.Size = new System.Drawing.Size(43, 17);
            this.rbQa2.TabIndex = 2;
            this.rbQa2.Text = "qa2";
            this.rbQa2.UseVisualStyleBackColor = true;
            this.rbQa2.CheckedChanged += new System.EventHandler(this.Venue_CheckedChanged);
            // 
            // rbR02
            // 
            this.rbR02.AutoSize = true;
            this.rbR02.Location = new System.Drawing.Point(45, 20);
            this.rbR02.Name = "rbR02";
            this.rbR02.Size = new System.Drawing.Size(40, 17);
            this.rbR02.TabIndex = 1;
            this.rbR02.Text = "r02";
            this.rbR02.UseVisualStyleBackColor = true;
            this.rbR02.CheckedChanged += new System.EventHandler(this.Venue_CheckedChanged);
            // 
            // rbR01
            // 
            this.rbR01.AutoSize = true;
            this.rbR01.Checked = true;
            this.rbR01.Location = new System.Drawing.Point(7, 20);
            this.rbR01.Name = "rbR01";
            this.rbR01.Size = new System.Drawing.Size(40, 17);
            this.rbR01.TabIndex = 0;
            this.rbR01.TabStop = true;
            this.rbR01.Text = "r01";
            this.rbR01.UseVisualStyleBackColor = true;
            this.rbR01.CheckedChanged += new System.EventHandler(this.Venue_CheckedChanged);
            // 
            // btnSetFunctionsToRun
            // 
            this.btnSetFunctionsToRun.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSetFunctionsToRun.Location = new System.Drawing.Point(3, 630);
            this.btnSetFunctionsToRun.Name = "btnSetFunctionsToRun";
            this.btnSetFunctionsToRun.Size = new System.Drawing.Size(141, 23);
            this.btnSetFunctionsToRun.TabIndex = 11;
            this.btnSetFunctionsToRun.Text = "Set Functions";
            this.btnSetFunctionsToRun.UseVisualStyleBackColor = true;
            this.btnSetFunctionsToRun.Click += new System.EventHandler(this.btnSetFunctionsToRun_Click);
            // 
            // txtFunctionsToRun
            // 
            this.txtFunctionsToRun.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtFunctionsToRun.Location = new System.Drawing.Point(3, 653);
            this.txtFunctionsToRun.Multiline = true;
            this.txtFunctionsToRun.Name = "txtFunctionsToRun";
            this.txtFunctionsToRun.Size = new System.Drawing.Size(141, 43);
            this.txtFunctionsToRun.TabIndex = 10;
            this.txtFunctionsToRun.Text = "StartProtectServiceAfterFilesCopied";
            // 
            // pnlTaskBar
            // 
            this.pnlTaskBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlTaskBar.Location = new System.Drawing.Point(0, 699);
            this.pnlTaskBar.Name = "pnlTaskBar";
            this.pnlTaskBar.Size = new System.Drawing.Size(1313, 69);
            this.pnlTaskBar.TabIndex = 3;
            this.pnlTaskBar.Tag = "Taskbar";
            // 
            // txtConsole
            // 
            this.txtConsole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtConsole.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConsole.Location = new System.Drawing.Point(0, 0);
            this.txtConsole.Name = "txtConsole";
            this.txtConsole.ReadOnly = true;
            this.txtConsole.Size = new System.Drawing.Size(815, 363);
            this.txtConsole.TabIndex = 1;
            this.txtConsole.Text = "";
            // 
            // grpCommandGroups
            // 
            this.grpCommandGroups.Dock = System.Windows.Forms.DockStyle.Left;
            this.grpCommandGroups.Location = new System.Drawing.Point(323, 0);
            this.grpCommandGroups.Name = "grpCommandGroups";
            this.grpCommandGroups.Padding = new System.Windows.Forms.Padding(5);
            this.grpCommandGroups.Size = new System.Drawing.Size(169, 699);
            this.grpCommandGroups.TabIndex = 7;
            this.grpCommandGroups.TabStop = false;
            this.grpCommandGroups.Text = "Commands";
            // 
            // grpRollback
            // 
            this.grpRollback.Controls.Add(this.lstRollbackPosition);
            this.grpRollback.Controls.Add(this.btnSetFunctionsToRun);
            this.grpRollback.Controls.Add(this.txtFunctionsToRun);
            this.grpRollback.Dock = System.Windows.Forms.DockStyle.Left;
            this.grpRollback.Location = new System.Drawing.Point(176, 0);
            this.grpRollback.Name = "grpRollback";
            this.grpRollback.Size = new System.Drawing.Size(147, 699);
            this.grpRollback.TabIndex = 10;
            this.grpRollback.TabStop = false;
            this.grpRollback.Text = "Rollback";
            // 
            // lstRollbackPosition
            // 
            this.lstRollbackPosition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstRollbackPosition.FormattingEnabled = true;
            this.lstRollbackPosition.Location = new System.Drawing.Point(3, 16);
            this.lstRollbackPosition.Name = "lstRollbackPosition";
            this.lstRollbackPosition.Size = new System.Drawing.Size(141, 614);
            this.lstRollbackPosition.TabIndex = 0;
            this.lstRollbackPosition.Tag = "Rollback";
            this.lstRollbackPosition.Click += new System.EventHandler(this.lstRollbackPosition_Click);
            // 
            // grpReport
            // 
            this.grpReport.Controls.Add(this.reportGrid1);
            this.grpReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpReport.Location = new System.Drawing.Point(274, 16);
            this.grpReport.Name = "grpReport";
            this.grpReport.Size = new System.Drawing.Size(544, 221);
            this.grpReport.TabIndex = 11;
            this.grpReport.TabStop = false;
            this.grpReport.Text = "Report";
            // 
            // reportGrid1
            // 
            this.reportGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportGrid1.DosTasks = null;
            this.reportGrid1.Location = new System.Drawing.Point(3, 16);
            this.reportGrid1.Name = "reportGrid1";
            this.reportGrid1.Size = new System.Drawing.Size(538, 202);
            this.reportGrid1.TabIndex = 2;
            // 
            // lstBatchCommand
            // 
            this.lstBatchCommand.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstBatchCommand.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.lstBatchCommand.FormattingEnabled = true;
            this.lstBatchCommand.Location = new System.Drawing.Point(55, 37);
            this.lstBatchCommand.Name = "lstBatchCommand";
            this.lstBatchCommand.Size = new System.Drawing.Size(213, 181);
            this.lstBatchCommand.TabIndex = 12;
            this.lstBatchCommand.Tag = "Batch";
            this.lstBatchCommand.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ListBox_DrawItem);
            // 
            // grpBatchCommand
            // 
            this.grpBatchCommand.Controls.Add(this.lstBatchCommand);
            this.grpBatchCommand.Controls.Add(this.btnRunBatchCommand);
            this.grpBatchCommand.Controls.Add(this.cmbBatchCommand);
            this.grpBatchCommand.Dock = System.Windows.Forms.DockStyle.Left;
            this.grpBatchCommand.Location = new System.Drawing.Point(3, 16);
            this.grpBatchCommand.Name = "grpBatchCommand";
            this.grpBatchCommand.Size = new System.Drawing.Size(271, 221);
            this.grpBatchCommand.TabIndex = 13;
            this.grpBatchCommand.TabStop = false;
            this.grpBatchCommand.Text = "Batch Command";
            // 
            // btnRunBatchCommand
            // 
            this.btnRunBatchCommand.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnRunBatchCommand.Location = new System.Drawing.Point(3, 37);
            this.btnRunBatchCommand.Name = "btnRunBatchCommand";
            this.btnRunBatchCommand.Size = new System.Drawing.Size(52, 181);
            this.btnRunBatchCommand.TabIndex = 13;
            this.btnRunBatchCommand.Text = "Run";
            this.btnRunBatchCommand.UseVisualStyleBackColor = true;
            this.btnRunBatchCommand.Click += new System.EventHandler(this.btnRunBatchCommand_Click);
            // 
            // cmbBatchCommand
            // 
            this.cmbBatchCommand.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmbBatchCommand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBatchCommand.FormattingEnabled = true;
            this.cmbBatchCommand.Location = new System.Drawing.Point(3, 16);
            this.cmbBatchCommand.Name = "cmbBatchCommand";
            this.cmbBatchCommand.Size = new System.Drawing.Size(265, 21);
            this.cmbBatchCommand.TabIndex = 14;
            this.cmbBatchCommand.SelectedIndexChanged += new System.EventHandler(this.cmbBatchCommand_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.grpReport);
            this.groupBox1.Controls.Add(this.grpBatchCommand);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(492, 459);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(821, 240);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            // 
            // grpConsole
            // 
            this.grpConsole.Controls.Add(this.splitContainer1);
            this.grpConsole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpConsole.Location = new System.Drawing.Point(492, 0);
            this.grpConsole.Name = "grpConsole";
            this.grpConsole.Size = new System.Drawing.Size(821, 459);
            this.grpConsole.TabIndex = 15;
            this.grpConsole.TabStop = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 16);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.txtConsole);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtDebugger);
            this.splitContainer1.Size = new System.Drawing.Size(815, 440);
            this.splitContainer1.SplitterDistance = 363;
            this.splitContainer1.TabIndex = 2;
            // 
            // txtDebugger
            // 
            this.txtDebugger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDebugger.Font = new System.Drawing.Font("Consolas", 9F);
            this.txtDebugger.Location = new System.Drawing.Point(0, 0);
            this.txtDebugger.Name = "txtDebugger";
            this.txtDebugger.ReadOnly = true;
            this.txtDebugger.Size = new System.Drawing.Size(815, 73);
            this.txtDebugger.TabIndex = 0;
            this.txtDebugger.Text = "";
            // 
            // TestTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1313, 768);
            this.Controls.Add(this.grpConsole);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpCommandGroups);
            this.Controls.Add(this.grpRollback);
            this.Controls.Add(this.grpInstall);
            this.Controls.Add(this.pnlTaskBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(1099, 632);
            this.Name = "TestTool";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Unifi";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TestTool_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TestTools_KeyDown);
            this.grpInstall.ResumeLayout(false);
            this.grpInstall.PerformLayout();
            this.grpConfig.ResumeLayout(false);
            this.grpConfig.PerformLayout();
            this.grpRollback.ResumeLayout(false);
            this.grpRollback.PerformLayout();
            this.grpReport.ResumeLayout(false);
            this.grpBatchCommand.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.grpConsole.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpInstall;
        private System.Windows.Forms.Panel pnlTaskBar;
        private System.Windows.Forms.RichTextBox txtConsole;
        private System.Windows.Forms.GroupBox grpConfig;
        private System.Windows.Forms.RadioButton rbQa2;
        private System.Windows.Forms.RadioButton rbR02;
        private System.Windows.Forms.RadioButton rbR01;
        private System.Windows.Forms.GroupBox grpCommandGroups;
        private System.Windows.Forms.GroupBox grpRollback;
        private System.Windows.Forms.ListBox lstRollbackPosition;
        private System.Windows.Forms.GroupBox grpReport;
        private System.Windows.Forms.ListBox lstBatchCommand;
        private System.Windows.Forms.GroupBox grpBatchCommand;
        private System.Windows.Forms.Button btnRunBatchCommand;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox grpConsole;
        private System.Windows.Forms.Button btnSetFunctionsToRun;
        private System.Windows.Forms.TextBox txtFunctionsToRun;
        private System.Windows.Forms.TextBox txtInstallDir;
        private System.Windows.Forms.Label lblInstallPath;
        private System.Windows.Forms.CheckBox chkDebugBuild;
        private System.Windows.Forms.ListBox lstInstall;
        private DownloadCommandGroup lstDownload;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RichTextBox txtDebugger;
        private System.Windows.Forms.ComboBox cmbBatchCommand;
        private UserControls.ReportGrid reportGrid1;
    }
}

