
using Unifi.UserControls;

namespace Unifi.Forms
{
    partial class TestToolV2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestToolV2));
            this.grpInstallBase = new System.Windows.Forms.GroupBox();
            this.lstInstall = new System.Windows.Forms.ListBox();
            this.grpInstall = new System.Windows.Forms.GroupBox();
            this.grpConfig = new System.Windows.Forms.GroupBox();
            this.rbQa2 = new System.Windows.Forms.RadioButton();
            this.rbR02 = new System.Windows.Forms.RadioButton();
            this.rbR01 = new System.Windows.Forms.RadioButton();
            this.chkDebugBuild = new System.Windows.Forms.CheckBox();
            this.grpRunMode = new System.Windows.Forms.GroupBox();
            this.rbUser = new System.Windows.Forms.RadioButton();
            this.rbAdmin = new System.Windows.Forms.RadioButton();
            this.lblInstallPath = new System.Windows.Forms.Label();
            this.grpProduct = new System.Windows.Forms.GroupBox();
            this.rbOptics = new System.Windows.Forms.RadioButton();
            this.rbProtect = new System.Windows.Forms.RadioButton();
            this.grpInstallMode = new System.Windows.Forms.GroupBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.rbSilent = new System.Windows.Forms.RadioButton();
            this.txtInstallDir = new System.Windows.Forms.TextBox();
            this.grpDownload = new System.Windows.Forms.GroupBox();
            this.pnlTaskBar = new System.Windows.Forms.Panel();
            this.grpReport = new System.Windows.Forms.GroupBox();
            this.grpBatchCommand = new System.Windows.Forms.GroupBox();
            this.grpBatch = new System.Windows.Forms.GroupBox();
            this.grpVersion = new System.Windows.Forms.GroupBox();
            this.grpConsole = new System.Windows.Forms.GroupBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txtDebugger = new System.Windows.Forms.RichTextBox();
            this.txtConsole = new System.Windows.Forms.RichTextBox();
            this.pnlDosCommands = new System.Windows.Forms.Panel();
            this.reportGrid1 = new Unifi.UserControls.ReportGrid();
            this.lstVersion = new UnifiDesktop.UserControls.VersionGrid();
            this.lstBatchCommands = new UnifiDesktop.UserControls.BatchCommandList();
            this.downloadCommandGroup1 = new UnifiDesktop.UserControls.DownloadCommandGroup();
            this.grpInstallBase.SuspendLayout();
            this.grpInstall.SuspendLayout();
            this.grpConfig.SuspendLayout();
            this.grpRunMode.SuspendLayout();
            this.grpProduct.SuspendLayout();
            this.grpInstallMode.SuspendLayout();
            this.grpDownload.SuspendLayout();
            this.grpReport.SuspendLayout();
            this.grpBatchCommand.SuspendLayout();
            this.grpBatch.SuspendLayout();
            this.grpVersion.SuspendLayout();
            this.grpConsole.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpInstallBase
            // 
            this.grpInstallBase.Controls.Add(this.lstInstall);
            this.grpInstallBase.Controls.Add(this.grpInstall);
            this.grpInstallBase.Controls.Add(this.grpDownload);
            this.grpInstallBase.Dock = System.Windows.Forms.DockStyle.Left;
            this.grpInstallBase.Location = new System.Drawing.Point(0, 0);
            this.grpInstallBase.Name = "grpInstallBase";
            this.grpInstallBase.Padding = new System.Windows.Forms.Padding(10);
            this.grpInstallBase.Size = new System.Drawing.Size(173, 684);
            this.grpInstallBase.TabIndex = 0;
            this.grpInstallBase.TabStop = false;
            // 
            // lstInstall
            // 
            this.lstInstall.FormattingEnabled = true;
            this.lstInstall.Location = new System.Drawing.Point(8, 151);
            this.lstInstall.Name = "lstInstall";
            this.lstInstall.Size = new System.Drawing.Size(156, 173);
            this.lstInstall.TabIndex = 16;
            this.lstInstall.Tag = "Install";
            this.lstInstall.DoubleClick += new System.EventHandler(this.lstInstall_DoubleClick);
            this.lstInstall.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lstInstall_MouseDown);
            // 
            // grpInstall
            // 
            this.grpInstall.Controls.Add(this.grpConfig);
            this.grpInstall.Controls.Add(this.chkDebugBuild);
            this.grpInstall.Controls.Add(this.grpRunMode);
            this.grpInstall.Controls.Add(this.lblInstallPath);
            this.grpInstall.Controls.Add(this.grpProduct);
            this.grpInstall.Controls.Add(this.grpInstallMode);
            this.grpInstall.Controls.Add(this.txtInstallDir);
            this.grpInstall.Location = new System.Drawing.Point(0, 0);
            this.grpInstall.Name = "grpInstall";
            this.grpInstall.Size = new System.Drawing.Size(176, 145);
            this.grpInstall.TabIndex = 23;
            this.grpInstall.TabStop = false;
            this.grpInstall.Text = "Install";
            // 
            // grpConfig
            // 
            this.grpConfig.Controls.Add(this.rbQa2);
            this.grpConfig.Controls.Add(this.rbR02);
            this.grpConfig.Controls.Add(this.rbR01);
            this.grpConfig.Location = new System.Drawing.Point(6, 15);
            this.grpConfig.Margin = new System.Windows.Forms.Padding(5);
            this.grpConfig.Name = "grpConfig";
            this.grpConfig.Size = new System.Drawing.Size(162, 43);
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
            this.rbQa2.Tag = "2";
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
            this.rbR02.Tag = "1";
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
            this.rbR01.Tag = "0";
            this.rbR01.Text = "r01";
            this.rbR01.UseVisualStyleBackColor = true;
            this.rbR01.CheckedChanged += new System.EventHandler(this.Venue_CheckedChanged);
            // 
            // chkDebugBuild
            // 
            this.chkDebugBuild.AutoSize = true;
            this.chkDebugBuild.Location = new System.Drawing.Point(13, 61);
            this.chkDebugBuild.Name = "chkDebugBuild";
            this.chkDebugBuild.Size = new System.Drawing.Size(82, 17);
            this.chkDebugBuild.TabIndex = 15;
            this.chkDebugBuild.Tag = "Debug";
            this.chkDebugBuild.Text = "Debug build";
            this.chkDebugBuild.UseVisualStyleBackColor = true;
            // 
            // grpRunMode
            // 
            this.grpRunMode.Controls.Add(this.rbUser);
            this.grpRunMode.Controls.Add(this.rbAdmin);
            this.grpRunMode.Location = new System.Drawing.Point(6, 202);
            this.grpRunMode.Name = "grpRunMode";
            this.grpRunMode.Size = new System.Drawing.Size(162, 44);
            this.grpRunMode.TabIndex = 20;
            this.grpRunMode.TabStop = false;
            this.grpRunMode.Text = "Run Mode";
            // 
            // rbUser
            // 
            this.rbUser.AutoSize = true;
            this.rbUser.Location = new System.Drawing.Point(71, 20);
            this.rbUser.Name = "rbUser";
            this.rbUser.Size = new System.Drawing.Size(47, 17);
            this.rbUser.TabIndex = 1;
            this.rbUser.Text = "User";
            this.rbUser.UseVisualStyleBackColor = true;
            // 
            // rbAdmin
            // 
            this.rbAdmin.AutoSize = true;
            this.rbAdmin.Checked = true;
            this.rbAdmin.Location = new System.Drawing.Point(7, 20);
            this.rbAdmin.Name = "rbAdmin";
            this.rbAdmin.Size = new System.Drawing.Size(54, 17);
            this.rbAdmin.TabIndex = 0;
            this.rbAdmin.TabStop = true;
            this.rbAdmin.Text = "Admin";
            this.rbAdmin.UseVisualStyleBackColor = true;
            // 
            // lblInstallPath
            // 
            this.lblInstallPath.AutoSize = true;
            this.lblInstallPath.Location = new System.Drawing.Point(8, 88);
            this.lblInstallPath.Name = "lblInstallPath";
            this.lblInstallPath.Size = new System.Drawing.Size(56, 13);
            this.lblInstallPath.TabIndex = 14;
            this.lblInstallPath.Text = "Install Dir:";
            // 
            // grpProduct
            // 
            this.grpProduct.Controls.Add(this.rbOptics);
            this.grpProduct.Controls.Add(this.rbProtect);
            this.grpProduct.Location = new System.Drawing.Point(6, 152);
            this.grpProduct.Name = "grpProduct";
            this.grpProduct.Size = new System.Drawing.Size(162, 44);
            this.grpProduct.TabIndex = 19;
            this.grpProduct.TabStop = false;
            this.grpProduct.Text = "Product";
            // 
            // rbOptics
            // 
            this.rbOptics.AutoSize = true;
            this.rbOptics.Location = new System.Drawing.Point(71, 20);
            this.rbOptics.Name = "rbOptics";
            this.rbOptics.Size = new System.Drawing.Size(55, 17);
            this.rbOptics.TabIndex = 1;
            this.rbOptics.Text = "Optics";
            this.rbOptics.UseVisualStyleBackColor = true;
            // 
            // rbProtect
            // 
            this.rbProtect.AutoSize = true;
            this.rbProtect.Checked = true;
            this.rbProtect.Location = new System.Drawing.Point(7, 20);
            this.rbProtect.Name = "rbProtect";
            this.rbProtect.Size = new System.Drawing.Size(60, 17);
            this.rbProtect.TabIndex = 0;
            this.rbProtect.TabStop = true;
            this.rbProtect.Text = "Protect";
            this.rbProtect.UseVisualStyleBackColor = true;
            // 
            // grpInstallMode
            // 
            this.grpInstallMode.Controls.Add(this.radioButton1);
            this.grpInstallMode.Controls.Add(this.rbSilent);
            this.grpInstallMode.Location = new System.Drawing.Point(6, 252);
            this.grpInstallMode.Name = "grpInstallMode";
            this.grpInstallMode.Size = new System.Drawing.Size(162, 44);
            this.grpInstallMode.TabIndex = 21;
            this.grpInstallMode.TabStop = false;
            this.grpInstallMode.Text = "Install Mode";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(71, 20);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(61, 17);
            this.radioButton1.TabIndex = 1;
            this.radioButton1.Text = "With UI";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // rbSilent
            // 
            this.rbSilent.AutoSize = true;
            this.rbSilent.Checked = true;
            this.rbSilent.Location = new System.Drawing.Point(7, 20);
            this.rbSilent.Name = "rbSilent";
            this.rbSilent.Size = new System.Drawing.Size(51, 17);
            this.rbSilent.TabIndex = 0;
            this.rbSilent.TabStop = true;
            this.rbSilent.Text = "Silent";
            this.rbSilent.UseVisualStyleBackColor = true;
            // 
            // txtInstallDir
            // 
            this.txtInstallDir.Location = new System.Drawing.Point(8, 101);
            this.txtInstallDir.Multiline = true;
            this.txtInstallDir.Name = "txtInstallDir";
            this.txtInstallDir.Size = new System.Drawing.Size(156, 34);
            this.txtInstallDir.TabIndex = 13;
            this.txtInstallDir.Text = "C:\\Program Files\\123";
            // 
            // grpDownload
            // 
            this.grpDownload.Controls.Add(this.downloadCommandGroup1);
            this.grpDownload.Location = new System.Drawing.Point(0, 335);
            this.grpDownload.Name = "grpDownload";
            this.grpDownload.Size = new System.Drawing.Size(176, 292);
            this.grpDownload.TabIndex = 22;
            this.grpDownload.TabStop = false;
            this.grpDownload.Text = "Download";
            // 
            // pnlTaskBar
            // 
            this.pnlTaskBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlTaskBar.Location = new System.Drawing.Point(0, 684);
            this.pnlTaskBar.Name = "pnlTaskBar";
            this.pnlTaskBar.Size = new System.Drawing.Size(1339, 69);
            this.pnlTaskBar.TabIndex = 3;
            this.pnlTaskBar.Tag = "Taskbar";
            // 
            // grpReport
            // 
            this.grpReport.Controls.Add(this.reportGrid1);
            this.grpReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpReport.Location = new System.Drawing.Point(463, 17);
            this.grpReport.Name = "grpReport";
            this.grpReport.Size = new System.Drawing.Size(250, 261);
            this.grpReport.TabIndex = 11;
            this.grpReport.TabStop = false;
            this.grpReport.Text = "Report";
            // 
            // grpBatchCommand
            // 
            this.grpBatchCommand.Controls.Add(this.lstBatchCommands);
            this.grpBatchCommand.Dock = System.Windows.Forms.DockStyle.Left;
            this.grpBatchCommand.Location = new System.Drawing.Point(3, 17);
            this.grpBatchCommand.Name = "grpBatchCommand";
            this.grpBatchCommand.Size = new System.Drawing.Size(260, 261);
            this.grpBatchCommand.TabIndex = 13;
            this.grpBatchCommand.TabStop = false;
            this.grpBatchCommand.Text = "Batch Command";
            // 
            // grpBatch
            // 
            this.grpBatch.Controls.Add(this.grpReport);
            this.grpBatch.Controls.Add(this.grpVersion);
            this.grpBatch.Controls.Add(this.grpBatchCommand);
            this.grpBatch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBatch.Location = new System.Drawing.Point(0, 0);
            this.grpBatch.Name = "grpBatch";
            this.grpBatch.Size = new System.Drawing.Size(716, 281);
            this.grpBatch.TabIndex = 14;
            this.grpBatch.TabStop = false;
            // 
            // grpVersion
            // 
            this.grpVersion.Controls.Add(this.lstVersion);
            this.grpVersion.Dock = System.Windows.Forms.DockStyle.Left;
            this.grpVersion.Location = new System.Drawing.Point(263, 17);
            this.grpVersion.Name = "grpVersion";
            this.grpVersion.Size = new System.Drawing.Size(200, 261);
            this.grpVersion.TabIndex = 15;
            this.grpVersion.TabStop = false;
            this.grpVersion.Text = "Version";
            // 
            // grpConsole
            // 
            this.grpConsole.Controls.Add(this.splitContainer1);
            this.grpConsole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpConsole.Location = new System.Drawing.Point(617, 0);
            this.grpConsole.Name = "grpConsole";
            this.grpConsole.Size = new System.Drawing.Size(722, 684);
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
            this.splitContainer1.Panel1.Controls.Add(this.txtConsole);
            this.splitContainer1.Panel1.Controls.Add(this.txtDebugger);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.grpBatch);
            this.splitContainer1.Size = new System.Drawing.Size(716, 664);
            this.splitContainer1.SplitterDistance = 379;
            this.splitContainer1.TabIndex = 2;
            // 
            // txtDebugger
            // 
            this.txtDebugger.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtDebugger.Font = new System.Drawing.Font("Consolas", 9F);
            this.txtDebugger.Location = new System.Drawing.Point(0, 312);
            this.txtDebugger.Name = "txtDebugger";
            this.txtDebugger.ReadOnly = true;
            this.txtDebugger.Size = new System.Drawing.Size(716, 67);
            this.txtDebugger.TabIndex = 0;
            this.txtDebugger.Text = "";
            // 
            // txtConsole
            // 
            this.txtConsole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtConsole.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConsole.Location = new System.Drawing.Point(0, 0);
            this.txtConsole.Name = "txtConsole";
            this.txtConsole.ReadOnly = true;
            this.txtConsole.Size = new System.Drawing.Size(716, 312);
            this.txtConsole.TabIndex = 1;
            this.txtConsole.Text = "";
            // 
            // pnlDosCommands
            // 
            this.pnlDosCommands.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlDosCommands.Location = new System.Drawing.Point(173, 0);
            this.pnlDosCommands.Name = "pnlDosCommands";
            this.pnlDosCommands.Size = new System.Drawing.Size(444, 684);
            this.pnlDosCommands.TabIndex = 17;
            // 
            // reportGrid1
            // 
            this.reportGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportGrid1.DosTasks = null;
            this.reportGrid1.Location = new System.Drawing.Point(3, 17);
            this.reportGrid1.Logger = null;
            this.reportGrid1.Name = "reportGrid1";
            this.reportGrid1.Size = new System.Drawing.Size(244, 241);
            this.reportGrid1.TabIndex = 2;
            // 
            // lstVersion
            // 
            this.lstVersion.Commands = null;
            this.lstVersion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstVersion.FormObject = null;
            this.lstVersion.Location = new System.Drawing.Point(3, 17);
            this.lstVersion.Name = "lstVersion";
            this.lstVersion.Size = new System.Drawing.Size(194, 241);
            this.lstVersion.TabIndex = 14;
            // 
            // lstBatchCommands
            // 
            this.lstBatchCommands.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstBatchCommands.Location = new System.Drawing.Point(3, 17);
            this.lstBatchCommands.Logger = null;
            this.lstBatchCommands.Name = "lstBatchCommands";
            this.lstBatchCommands.Size = new System.Drawing.Size(254, 241);
            this.lstBatchCommands.TabIndex = 2;
            // 
            // downloadCommandGroup1
            // 
            this.downloadCommandGroup1.CommandsRunner = null;
            this.downloadCommandGroup1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.downloadCommandGroup1.Location = new System.Drawing.Point(3, 17);
            this.downloadCommandGroup1.Logger = null;
            this.downloadCommandGroup1.Name = "downloadCommandGroup1";
            this.downloadCommandGroup1.Size = new System.Drawing.Size(170, 272);
            this.downloadCommandGroup1.TabIndex = 24;
            // 
            // TestToolV2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1339, 753);
            this.Controls.Add(this.grpConsole);
            this.Controls.Add(this.pnlDosCommands);
            this.Controls.Add(this.grpInstallBase);
            this.Controls.Add(this.pnlTaskBar);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(1099, 632);
            this.Name = "TestToolV2";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Unifi";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TestTool_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TestTools_KeyDown);
            this.grpInstallBase.ResumeLayout(false);
            this.grpInstall.ResumeLayout(false);
            this.grpInstall.PerformLayout();
            this.grpConfig.ResumeLayout(false);
            this.grpConfig.PerformLayout();
            this.grpRunMode.ResumeLayout(false);
            this.grpRunMode.PerformLayout();
            this.grpProduct.ResumeLayout(false);
            this.grpProduct.PerformLayout();
            this.grpInstallMode.ResumeLayout(false);
            this.grpInstallMode.PerformLayout();
            this.grpDownload.ResumeLayout(false);
            this.grpReport.ResumeLayout(false);
            this.grpBatchCommand.ResumeLayout(false);
            this.grpBatch.ResumeLayout(false);
            this.grpVersion.ResumeLayout(false);
            this.grpConsole.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpInstallBase;
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
        private System.Windows.Forms.GroupBox grpProduct;
        private System.Windows.Forms.RadioButton rbOptics;
        private System.Windows.Forms.RadioButton rbProtect;
        private System.Windows.Forms.GroupBox grpInstallMode;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton rbSilent;
        private System.Windows.Forms.GroupBox grpRunMode;
        private System.Windows.Forms.RadioButton rbUser;
        private System.Windows.Forms.RadioButton rbAdmin;
        private System.Windows.Forms.GroupBox grpDownload;
        private System.Windows.Forms.GroupBox grpInstall;
        private UnifiDesktop.UserControls.VersionGrid lstVersion;
        private System.Windows.Forms.GroupBox grpVersion;
        private UnifiDesktop.UserControls.BatchCommandList lstBatchCommands;
        private UnifiDesktop.UserControls.DownloadCommandGroup downloadCommandGroup1;
        private System.Windows.Forms.RichTextBox txtConsole;
        private System.Windows.Forms.Panel pnlDosCommands;
    }
}

