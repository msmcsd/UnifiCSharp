
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
            this.pnlTaskBar = new System.Windows.Forms.Panel();
            this.navBarDrawer1 = new UnifiDesktop.UserControls.V2.NavBarDrawer();
            this.grpInstall = new System.Windows.Forms.GroupBox();
            this.grpConfig = new System.Windows.Forms.GroupBox();
            this.rbQa2New = new System.Windows.Forms.RadioButton();
            this.rbQa2 = new System.Windows.Forms.RadioButton();
            this.rbR02 = new System.Windows.Forms.RadioButton();
            this.rbR01 = new System.Windows.Forms.RadioButton();
            this.lstInstall = new System.Windows.Forms.ListBox();
            this.chkDebugBuild = new System.Windows.Forms.CheckBox();
            this.lblInstallPath = new System.Windows.Forms.Label();
            this.txtInstallDir = new System.Windows.Forms.TextBox();
            this.downloadCommandGroup1 = new UnifiDesktop.UserControls.DownloadCommandGroup();
            this.lblDownload = new System.Windows.Forms.Label();
            this.lblInstallOptions = new System.Windows.Forms.Label();
            this.installOptionsGroup1 = new UnifiDesktop.UserControls.InstallOptionsGroup();
            this.grpConsole = new System.Windows.Forms.GroupBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txtConsole = new System.Windows.Forms.RichTextBox();
            this.txtDebugger = new System.Windows.Forms.RichTextBox();
            this.grpBatch = new System.Windows.Forms.GroupBox();
            this.grpReport = new System.Windows.Forms.GroupBox();
            this.reportGrid1 = new Unifi.UserControls.ReportGrid();
            this.grpVersion = new System.Windows.Forms.GroupBox();
            this.updateFileVersion1 = new UnifiDesktop.UserControls.UpdateFileVersion();
            this.grpService = new System.Windows.Forms.GroupBox();
            this.updateServiceState1 = new UnifiDesktop.UserControls.UpdateServiceState();
            this.grpBatchCommand = new System.Windows.Forms.GroupBox();
            this.lstBatchCommands = new UnifiDesktop.UserControls.BatchCommandList();
            this.pnlDosCommands = new System.Windows.Forms.Panel();
            this.navBarDrawer1.DrawerPanel.SuspendLayout();
            this.navBarDrawer1.MainControlsPanel.SuspendLayout();
            this.navBarDrawer1.SuspendLayout();
            this.grpInstall.SuspendLayout();
            this.grpConfig.SuspendLayout();
            this.grpConsole.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.grpBatch.SuspendLayout();
            this.grpReport.SuspendLayout();
            this.grpVersion.SuspendLayout();
            this.grpService.SuspendLayout();
            this.grpBatchCommand.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTaskBar
            // 
            this.pnlTaskBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlTaskBar.Location = new System.Drawing.Point(0, 717);
            this.pnlTaskBar.Name = "pnlTaskBar";
            this.pnlTaskBar.Size = new System.Drawing.Size(1482, 69);
            this.pnlTaskBar.TabIndex = 3;
            this.pnlTaskBar.Tag = "Taskbar";
            // 
            // navBarDrawer1
            // 
            this.navBarDrawer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navBarDrawer1.DrawerBackColor = System.Drawing.SystemColors.InactiveBorder;
            // 
            // navBarDrawer1.DrawerPanel
            // 
            this.navBarDrawer1.DrawerPanel.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.navBarDrawer1.DrawerPanel.Controls.Add(this.downloadCommandGroup1);
            this.navBarDrawer1.DrawerPanel.Controls.Add(this.lblDownload);
            this.navBarDrawer1.DrawerPanel.Controls.Add(this.lblInstallOptions);
            this.navBarDrawer1.DrawerPanel.Controls.Add(this.installOptionsGroup1);
            this.navBarDrawer1.DrawerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navBarDrawer1.DrawerPanel.Location = new System.Drawing.Point(0, 40);
            this.navBarDrawer1.DrawerPanel.Name = "DrawerPanel";
            this.navBarDrawer1.DrawerPanel.Size = new System.Drawing.Size(220, 677);
            this.navBarDrawer1.DrawerPanel.TabIndex = 1;
            this.navBarDrawer1.DrawerVisible = true;
            this.navBarDrawer1.DrawerWidth = 220;
            this.navBarDrawer1.Location = new System.Drawing.Point(0, 0);
            // 
            // navBarDrawer1.MainControlsPanel
            // 
            this.navBarDrawer1.MainControlsPanel.Controls.Add(this.grpConsole);
            this.navBarDrawer1.MainControlsPanel.Controls.Add(this.pnlDosCommands);
            this.navBarDrawer1.MainControlsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navBarDrawer1.MainControlsPanel.Location = new System.Drawing.Point(231, 40);
            this.navBarDrawer1.MainControlsPanel.Name = "MainControlsPanel";
            this.navBarDrawer1.MainControlsPanel.Size = new System.Drawing.Size(1240, 677);
            this.navBarDrawer1.MainControlsPanel.TabIndex = 3;
            this.navBarDrawer1.Name = "navBarDrawer1";
            this.navBarDrawer1.NavBarHeight = 40;
            this.navBarDrawer1.Size = new System.Drawing.Size(1482, 717);
            this.navBarDrawer1.TabIndex = 22;
            // 
            // grpInstall
            // 
            this.grpInstall.Controls.Add(this.grpConfig);
            this.grpInstall.Controls.Add(this.lstInstall);
            this.grpInstall.Controls.Add(this.chkDebugBuild);
            this.grpInstall.Controls.Add(this.lblInstallPath);
            this.grpInstall.Controls.Add(this.txtInstallDir);
            this.grpInstall.Location = new System.Drawing.Point(525, 6);
            this.grpInstall.Name = "grpInstall";
            this.grpInstall.Size = new System.Drawing.Size(200, 372);
            this.grpInstall.TabIndex = 23;
            this.grpInstall.TabStop = false;
            this.grpInstall.Text = "Install";
            this.grpInstall.Visible = false;
            // 
            // grpConfig
            // 
            this.grpConfig.Controls.Add(this.rbQa2New);
            this.grpConfig.Controls.Add(this.rbQa2);
            this.grpConfig.Controls.Add(this.rbR02);
            this.grpConfig.Controls.Add(this.rbR01);
            this.grpConfig.Location = new System.Drawing.Point(6, 15);
            this.grpConfig.Margin = new System.Windows.Forms.Padding(5);
            this.grpConfig.Name = "grpConfig";
            this.grpConfig.Size = new System.Drawing.Size(188, 49);
            this.grpConfig.TabIndex = 6;
            this.grpConfig.TabStop = false;
            this.grpConfig.Text = "config";
            // 
            // rbQa2New
            // 
            this.rbQa2New.AutoSize = true;
            this.rbQa2New.Location = new System.Drawing.Point(127, 20);
            this.rbQa2New.Name = "rbQa2New";
            this.rbQa2New.Size = new System.Drawing.Size(49, 17);
            this.rbQa2New.TabIndex = 4;
            this.rbQa2New.Tag = "qa2";
            this.rbQa2New.Text = "qa2n";
            this.rbQa2New.UseVisualStyleBackColor = true;
            // 
            // rbQa2
            // 
            this.rbQa2.AutoSize = true;
            this.rbQa2.Location = new System.Drawing.Point(87, 20);
            this.rbQa2.Name = "rbQa2";
            this.rbQa2.Size = new System.Drawing.Size(43, 17);
            this.rbQa2.TabIndex = 2;
            this.rbQa2.Tag = "qa2";
            this.rbQa2.Text = "qa2";
            this.rbQa2.UseVisualStyleBackColor = true;
            this.rbQa2.CheckedChanged += new System.EventHandler(this.Venue_CheckedChanged);
            // 
            // rbR02
            // 
            this.rbR02.AutoSize = true;
            this.rbR02.Location = new System.Drawing.Point(45, 20);
            this.rbR02.Name = "rbR02";
            this.rbR02.Size = new System.Drawing.Size(41, 17);
            this.rbR02.TabIndex = 1;
            this.rbR02.Tag = "r02";
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
            this.rbR01.Size = new System.Drawing.Size(41, 17);
            this.rbR01.TabIndex = 0;
            this.rbR01.TabStop = true;
            this.rbR01.Tag = "r01";
            this.rbR01.Text = "r01";
            this.rbR01.UseVisualStyleBackColor = true;
            this.rbR01.CheckedChanged += new System.EventHandler(this.Venue_CheckedChanged);
            // 
            // lstInstall
            // 
            this.lstInstall.FormattingEnabled = true;
            this.lstInstall.Location = new System.Drawing.Point(12, 153);
            this.lstInstall.Name = "lstInstall";
            this.lstInstall.Size = new System.Drawing.Size(176, 199);
            this.lstInstall.TabIndex = 16;
            this.lstInstall.Tag = "Install";
            this.lstInstall.DoubleClick += new System.EventHandler(this.lstInstall_DoubleClick);
            this.lstInstall.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lstInstall_MouseDown);
            // 
            // chkDebugBuild
            // 
            this.chkDebugBuild.AutoSize = true;
            this.chkDebugBuild.Location = new System.Drawing.Point(13, 65);
            this.chkDebugBuild.Name = "chkDebugBuild";
            this.chkDebugBuild.Size = new System.Drawing.Size(82, 17);
            this.chkDebugBuild.TabIndex = 15;
            this.chkDebugBuild.Tag = "Debug";
            this.chkDebugBuild.Text = "Debug build";
            this.chkDebugBuild.UseVisualStyleBackColor = true;
            // 
            // lblInstallPath
            // 
            this.lblInstallPath.AutoSize = true;
            this.lblInstallPath.Location = new System.Drawing.Point(11, 96);
            this.lblInstallPath.Name = "lblInstallPath";
            this.lblInstallPath.Size = new System.Drawing.Size(56, 13);
            this.lblInstallPath.TabIndex = 14;
            this.lblInstallPath.Text = "Install Dir:";
            // 
            // txtInstallDir
            // 
            this.txtInstallDir.Location = new System.Drawing.Point(13, 112);
            this.txtInstallDir.Multiline = true;
            this.txtInstallDir.Name = "txtInstallDir";
            this.txtInstallDir.Size = new System.Drawing.Size(174, 34);
            this.txtInstallDir.TabIndex = 13;
            this.txtInstallDir.Text = "C:\\Program Files\\123";
            // 
            // downloadCommandGroup1
            // 
            this.downloadCommandGroup1.BackColor = System.Drawing.SystemColors.Control;
            this.downloadCommandGroup1.CommandsRunner = null;
            this.downloadCommandGroup1.Location = new System.Drawing.Point(11, 424);
            this.downloadCommandGroup1.Logger = null;
            this.downloadCommandGroup1.MinimumSize = new System.Drawing.Size(182, 241);
            this.downloadCommandGroup1.Name = "downloadCommandGroup1";
            this.downloadCommandGroup1.Size = new System.Drawing.Size(202, 245);
            this.downloadCommandGroup1.TabIndex = 25;
            // 
            // lblDownload
            // 
            this.lblDownload.AutoSize = true;
            this.lblDownload.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDownload.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblDownload.Location = new System.Drawing.Point(10, 407);
            this.lblDownload.Name = "lblDownload";
            this.lblDownload.Size = new System.Drawing.Size(75, 16);
            this.lblDownload.TabIndex = 24;
            this.lblDownload.Text = "DOWNLOAD";
            // 
            // lblInstallOptions
            // 
            this.lblInstallOptions.AutoSize = true;
            this.lblInstallOptions.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstallOptions.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblInstallOptions.Location = new System.Drawing.Point(10, 4);
            this.lblInstallOptions.Name = "lblInstallOptions";
            this.lblInstallOptions.Size = new System.Drawing.Size(55, 16);
            this.lblInstallOptions.TabIndex = 23;
            this.lblInstallOptions.Text = "INSTALL";
            // 
            // installOptionsGroup1
            // 
            this.installOptionsGroup1.BackColor = System.Drawing.SystemColors.Control;
            this.installOptionsGroup1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.installOptionsGroup1.Location = new System.Drawing.Point(11, 23);
            this.installOptionsGroup1.Logger = null;
            this.installOptionsGroup1.MinimumSize = new System.Drawing.Size(196, 370);
            this.installOptionsGroup1.Name = "installOptionsGroup1";
            this.installOptionsGroup1.PrerequisiteTask = null;
            this.installOptionsGroup1.Size = new System.Drawing.Size(202, 370);
            this.installOptionsGroup1.TabIndex = 0;
            // 
            // grpConsole
            // 
            this.grpConsole.Controls.Add(this.splitContainer1);
            this.grpConsole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpConsole.Location = new System.Drawing.Point(397, 0);
            this.grpConsole.Name = "grpConsole";
            this.grpConsole.Size = new System.Drawing.Size(843, 677);
            this.grpConsole.TabIndex = 15;
            this.grpConsole.TabStop = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 17);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.grpInstall);
            this.splitContainer1.Panel1.Controls.Add(this.txtConsole);
            this.splitContainer1.Panel1.Controls.Add(this.txtDebugger);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.grpBatch);
            this.splitContainer1.Size = new System.Drawing.Size(837, 657);
            this.splitContainer1.SplitterDistance = 372;
            this.splitContainer1.TabIndex = 2;
            // 
            // txtConsole
            // 
            this.txtConsole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtConsole.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConsole.Location = new System.Drawing.Point(0, 0);
            this.txtConsole.Name = "txtConsole";
            this.txtConsole.ReadOnly = true;
            this.txtConsole.Size = new System.Drawing.Size(837, 305);
            this.txtConsole.TabIndex = 1;
            this.txtConsole.Text = "";
            // 
            // txtDebugger
            // 
            this.txtDebugger.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtDebugger.Font = new System.Drawing.Font("Consolas", 9F);
            this.txtDebugger.Location = new System.Drawing.Point(0, 305);
            this.txtDebugger.Name = "txtDebugger";
            this.txtDebugger.ReadOnly = true;
            this.txtDebugger.Size = new System.Drawing.Size(837, 67);
            this.txtDebugger.TabIndex = 0;
            this.txtDebugger.Text = "";
            // 
            // grpBatch
            // 
            this.grpBatch.Controls.Add(this.grpReport);
            this.grpBatch.Controls.Add(this.grpVersion);
            this.grpBatch.Controls.Add(this.grpService);
            this.grpBatch.Controls.Add(this.grpBatchCommand);
            this.grpBatch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBatch.Location = new System.Drawing.Point(0, 0);
            this.grpBatch.Name = "grpBatch";
            this.grpBatch.Size = new System.Drawing.Size(837, 281);
            this.grpBatch.TabIndex = 14;
            this.grpBatch.TabStop = false;
            // 
            // grpReport
            // 
            this.grpReport.Controls.Add(this.reportGrid1);
            this.grpReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpReport.Location = new System.Drawing.Point(579, 17);
            this.grpReport.Name = "grpReport";
            this.grpReport.Size = new System.Drawing.Size(255, 261);
            this.grpReport.TabIndex = 11;
            this.grpReport.TabStop = false;
            this.grpReport.Text = "Report";
            // 
            // reportGrid1
            // 
            this.reportGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportGrid1.DosTasks = null;
            this.reportGrid1.Location = new System.Drawing.Point(3, 17);
            this.reportGrid1.Logger = null;
            this.reportGrid1.Name = "reportGrid1";
            this.reportGrid1.Size = new System.Drawing.Size(249, 241);
            this.reportGrid1.TabIndex = 2;
            // 
            // grpVersion
            // 
            this.grpVersion.Controls.Add(this.updateFileVersion1);
            this.grpVersion.Dock = System.Windows.Forms.DockStyle.Left;
            this.grpVersion.Location = new System.Drawing.Point(409, 17);
            this.grpVersion.Name = "grpVersion";
            this.grpVersion.Size = new System.Drawing.Size(170, 261);
            this.grpVersion.TabIndex = 15;
            this.grpVersion.TabStop = false;
            this.grpVersion.Text = "Version";
            // 
            // updateFileVersion1
            // 
            this.updateFileVersion1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.updateFileVersion1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateFileVersion1.Location = new System.Drawing.Point(3, 17);
            this.updateFileVersion1.Name = "updateFileVersion1";
            this.updateFileVersion1.Size = new System.Drawing.Size(164, 241);
            this.updateFileVersion1.TabIndex = 15;
            // 
            // grpService
            // 
            this.grpService.Controls.Add(this.updateServiceState1);
            this.grpService.Dock = System.Windows.Forms.DockStyle.Left;
            this.grpService.Location = new System.Drawing.Point(242, 17);
            this.grpService.Name = "grpService";
            this.grpService.Size = new System.Drawing.Size(167, 261);
            this.grpService.TabIndex = 16;
            this.grpService.TabStop = false;
            this.grpService.Text = "Service";
            // 
            // updateServiceState1
            // 
            this.updateServiceState1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.updateServiceState1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateServiceState1.Location = new System.Drawing.Point(3, 17);
            this.updateServiceState1.Name = "updateServiceState1";
            this.updateServiceState1.Size = new System.Drawing.Size(161, 241);
            this.updateServiceState1.TabIndex = 2;
            // 
            // grpBatchCommand
            // 
            this.grpBatchCommand.Controls.Add(this.lstBatchCommands);
            this.grpBatchCommand.Dock = System.Windows.Forms.DockStyle.Left;
            this.grpBatchCommand.Location = new System.Drawing.Point(3, 17);
            this.grpBatchCommand.Name = "grpBatchCommand";
            this.grpBatchCommand.Size = new System.Drawing.Size(239, 261);
            this.grpBatchCommand.TabIndex = 13;
            this.grpBatchCommand.TabStop = false;
            this.grpBatchCommand.Text = "Batch Command";
            // 
            // lstBatchCommands
            // 
            this.lstBatchCommands.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstBatchCommands.Location = new System.Drawing.Point(3, 17);
            this.lstBatchCommands.Logger = null;
            this.lstBatchCommands.Name = "lstBatchCommands";
            this.lstBatchCommands.Size = new System.Drawing.Size(233, 241);
            this.lstBatchCommands.TabIndex = 2;
            // 
            // pnlDosCommands
            // 
            this.pnlDosCommands.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlDosCommands.Location = new System.Drawing.Point(0, 0);
            this.pnlDosCommands.Name = "pnlDosCommands";
            this.pnlDosCommands.Size = new System.Drawing.Size(397, 677);
            this.pnlDosCommands.TabIndex = 17;
            // 
            // TestTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1482, 786);
            this.Controls.Add(this.navBarDrawer1);
            this.Controls.Add(this.pnlTaskBar);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.navBarDrawer1.DrawerPanel.ResumeLayout(false);
            this.navBarDrawer1.DrawerPanel.PerformLayout();
            this.navBarDrawer1.MainControlsPanel.ResumeLayout(false);
            this.navBarDrawer1.ResumeLayout(false);
            this.grpInstall.ResumeLayout(false);
            this.grpInstall.PerformLayout();
            this.grpConfig.ResumeLayout(false);
            this.grpConfig.PerformLayout();
            this.grpConsole.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.grpBatch.ResumeLayout(false);
            this.grpReport.ResumeLayout(false);
            this.grpVersion.ResumeLayout(false);
            this.grpService.ResumeLayout(false);
            this.grpBatchCommand.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlTaskBar;
        private System.Windows.Forms.GroupBox grpConfig;
        private System.Windows.Forms.RadioButton rbQa2;
        private System.Windows.Forms.RadioButton rbR02;
        private System.Windows.Forms.RadioButton rbR01;
        private System.Windows.Forms.GroupBox grpReport;
        private System.Windows.Forms.GroupBox grpBatchCommand;
        private System.Windows.Forms.GroupBox grpBatch;
        private System.Windows.Forms.GroupBox grpConsole;
        private System.Windows.Forms.TextBox txtInstallDir;
        private System.Windows.Forms.Label lblInstallPath;
        private System.Windows.Forms.CheckBox chkDebugBuild;
        private System.Windows.Forms.ListBox lstInstall;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RichTextBox txtDebugger;
        private UserControls.ReportGrid reportGrid1;
        private System.Windows.Forms.GroupBox grpDownload;
        private System.Windows.Forms.GroupBox grpInstall;
        private System.Windows.Forms.GroupBox grpVersion;
        private UnifiDesktop.UserControls.BatchCommandList lstBatchCommands;
        private System.Windows.Forms.RichTextBox txtConsole;
        private System.Windows.Forms.Panel pnlDosCommands;
        private UnifiDesktop.UserControls.V2.NavBarDrawer navBarDrawer1;
        private System.Windows.Forms.GroupBox grpService;
        private UnifiDesktop.UserControls.InstallOptionsGroup installOptionsGroup1;
        private System.Windows.Forms.RadioButton rbQa2New;
        private System.Windows.Forms.Label lblInstallOptions;
        private UnifiDesktop.UserControls.DownloadCommandGroup downloadCommandGroup1;
        private System.Windows.Forms.Label lblDownload;
        private UnifiDesktop.UserControls.UpdateServiceState updateServiceState1;
        private UnifiDesktop.UserControls.UpdateFileVersion updateFileVersion1;
    }
}

