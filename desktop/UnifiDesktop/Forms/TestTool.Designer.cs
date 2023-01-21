
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
            this.grpInstallBase = new System.Windows.Forms.GroupBox();
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
            this.grpInstaller = new System.Windows.Forms.GroupBox();
            this.rbBootstrapper = new System.Windows.Forms.RadioButton();
            this.rbCyUpgrade = new System.Windows.Forms.RadioButton();
            this.rbMsi = new System.Windows.Forms.RadioButton();
            this.grpBuild = new System.Windows.Forms.GroupBox();
            this.txtBuildNumber = new System.Windows.Forms.TextBox();
            this.cmbVersion = new System.Windows.Forms.ComboBox();
            this.rbBuildNo = new System.Windows.Forms.RadioButton();
            this.rbBuildVersion = new System.Windows.Forms.RadioButton();
            this.rbLatestBuild = new System.Windows.Forms.RadioButton();
            this.grpJenkin = new System.Windows.Forms.GroupBox();
            this.cmbReleaseUrls = new System.Windows.Forms.ComboBox();
            this.rbReleaseBuild = new System.Windows.Forms.RadioButton();
            this.rbBcBuild = new System.Windows.Forms.RadioButton();
            this.rbMeBuild = new System.Windows.Forms.RadioButton();
            this.lstDownload = new Unifi.UserControls.DownloadCommandGroup();
            this.lstInstall = new System.Windows.Forms.ListBox();
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
            this.grpInstallBase.SuspendLayout();
            this.grpInstall.SuspendLayout();
            this.grpConfig.SuspendLayout();
            this.grpRunMode.SuspendLayout();
            this.grpProduct.SuspendLayout();
            this.grpInstallMode.SuspendLayout();
            this.grpDownload.SuspendLayout();
            this.grpInstaller.SuspendLayout();
            this.grpBuild.SuspendLayout();
            this.grpJenkin.SuspendLayout();
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
            // grpInstallBase
            // 
            this.grpInstallBase.Controls.Add(this.lstInstall);
            this.grpInstallBase.Controls.Add(this.grpInstall);
            this.grpInstallBase.Controls.Add(this.grpDownload);
            this.grpInstallBase.Controls.Add(this.lstDownload);
            this.grpInstallBase.Dock = System.Windows.Forms.DockStyle.Left;
            this.grpInstallBase.Location = new System.Drawing.Point(0, 0);
            this.grpInstallBase.Name = "grpInstallBase";
            this.grpInstallBase.Padding = new System.Windows.Forms.Padding(10);
            this.grpInstallBase.Size = new System.Drawing.Size(173, 699);
            this.grpInstallBase.TabIndex = 0;
            this.grpInstallBase.TabStop = false;
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
            // chkDebugBuild
            // 
            this.chkDebugBuild.AutoSize = true;
            this.chkDebugBuild.Location = new System.Drawing.Point(13, 61);
            this.chkDebugBuild.Name = "chkDebugBuild";
            this.chkDebugBuild.Size = new System.Drawing.Size(83, 17);
            this.chkDebugBuild.TabIndex = 15;
            this.chkDebugBuild.Tag = "Debug";
            this.chkDebugBuild.Text = "Debug build";
            this.chkDebugBuild.UseVisualStyleBackColor = true;
            this.chkDebugBuild.CheckedChanged += new System.EventHandler(this.chkDebugBuild_CheckedChanged);
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
            this.lblInstallPath.Size = new System.Drawing.Size(53, 13);
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
            this.rbProtect.Size = new System.Drawing.Size(59, 17);
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
            this.txtInstallDir.TextChanged += new System.EventHandler(this.txtInstallDir_TextChanged);
            // 
            // grpDownload
            // 
            this.grpDownload.Controls.Add(this.grpInstaller);
            this.grpDownload.Controls.Add(this.grpBuild);
            this.grpDownload.Controls.Add(this.grpJenkin);
            this.grpDownload.Location = new System.Drawing.Point(0, 335);
            this.grpDownload.Name = "grpDownload";
            this.grpDownload.Size = new System.Drawing.Size(176, 325);
            this.grpDownload.TabIndex = 22;
            this.grpDownload.TabStop = false;
            this.grpDownload.Text = "Download";
            // 
            // grpInstaller
            // 
            this.grpInstaller.Controls.Add(this.rbBootstrapper);
            this.grpInstaller.Controls.Add(this.rbCyUpgrade);
            this.grpInstaller.Controls.Add(this.rbMsi);
            this.grpInstaller.Location = new System.Drawing.Point(6, 224);
            this.grpInstaller.Name = "grpInstaller";
            this.grpInstaller.Size = new System.Drawing.Size(161, 81);
            this.grpInstaller.TabIndex = 2;
            this.grpInstaller.TabStop = false;
            this.grpInstaller.Text = "Installer";
            // 
            // rbBootstrapper
            // 
            this.rbBootstrapper.AutoSize = true;
            this.rbBootstrapper.Location = new System.Drawing.Point(6, 37);
            this.rbBootstrapper.Name = "rbBootstrapper";
            this.rbBootstrapper.Size = new System.Drawing.Size(85, 17);
            this.rbBootstrapper.TabIndex = 3;
            this.rbBootstrapper.Tag = "3";
            this.rbBootstrapper.Text = "Bootstrapper";
            this.rbBootstrapper.UseVisualStyleBackColor = true;
            // 
            // rbCyUpgrade
            // 
            this.rbCyUpgrade.AutoSize = true;
            this.rbCyUpgrade.Location = new System.Drawing.Point(6, 55);
            this.rbCyUpgrade.Name = "rbCyUpgrade";
            this.rbCyUpgrade.Size = new System.Drawing.Size(78, 17);
            this.rbCyUpgrade.TabIndex = 2;
            this.rbCyUpgrade.Tag = "2";
            this.rbCyUpgrade.Text = "CyUpgrade";
            this.rbCyUpgrade.UseVisualStyleBackColor = true;
            // 
            // rbMsi
            // 
            this.rbMsi.AutoSize = true;
            this.rbMsi.Checked = true;
            this.rbMsi.Location = new System.Drawing.Point(6, 19);
            this.rbMsi.Name = "rbMsi";
            this.rbMsi.Size = new System.Drawing.Size(44, 17);
            this.rbMsi.TabIndex = 1;
            this.rbMsi.TabStop = true;
            this.rbMsi.Tag = "0";
            this.rbMsi.Text = "MSI";
            this.rbMsi.UseVisualStyleBackColor = true;
            // 
            // grpBuild
            // 
            this.grpBuild.Controls.Add(this.txtBuildNumber);
            this.grpBuild.Controls.Add(this.cmbVersion);
            this.grpBuild.Controls.Add(this.rbBuildNo);
            this.grpBuild.Controls.Add(this.rbBuildVersion);
            this.grpBuild.Controls.Add(this.rbLatestBuild);
            this.grpBuild.Location = new System.Drawing.Point(6, 86);
            this.grpBuild.Name = "grpBuild";
            this.grpBuild.Size = new System.Drawing.Size(161, 132);
            this.grpBuild.TabIndex = 1;
            this.grpBuild.TabStop = false;
            this.grpBuild.Text = "Build";
            // 
            // txtBuildNumber
            // 
            this.txtBuildNumber.Location = new System.Drawing.Point(26, 102);
            this.txtBuildNumber.Name = "txtBuildNumber";
            this.txtBuildNumber.Size = new System.Drawing.Size(100, 20);
            this.txtBuildNumber.TabIndex = 5;
            this.txtBuildNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnControlKeyDown);
            this.txtBuildNumber.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnControlMouseDown);
            // 
            // cmbVersion
            // 
            this.cmbVersion.FormattingEnabled = true;
            this.cmbVersion.Location = new System.Drawing.Point(26, 56);
            this.cmbVersion.Name = "cmbVersion";
            this.cmbVersion.Size = new System.Drawing.Size(98, 21);
            this.cmbVersion.TabIndex = 4;
            this.cmbVersion.Click += new System.EventHandler(this.cmbVersion_Click);
            this.cmbVersion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnControlKeyDown);
            this.cmbVersion.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnControlMouseDown);
            // 
            // rbBuildNo
            // 
            this.rbBuildNo.AutoSize = true;
            this.rbBuildNo.Location = new System.Drawing.Point(6, 82);
            this.rbBuildNo.Name = "rbBuildNo";
            this.rbBuildNo.Size = new System.Drawing.Size(88, 17);
            this.rbBuildNo.TabIndex = 3;
            this.rbBuildNo.Text = "Build Number";
            this.rbBuildNo.UseVisualStyleBackColor = true;
            // 
            // rbBuildVersion
            // 
            this.rbBuildVersion.AutoSize = true;
            this.rbBuildVersion.Location = new System.Drawing.Point(6, 37);
            this.rbBuildVersion.Name = "rbBuildVersion";
            this.rbBuildVersion.Size = new System.Drawing.Size(60, 17);
            this.rbBuildVersion.TabIndex = 2;
            this.rbBuildVersion.Text = "Version";
            this.rbBuildVersion.UseVisualStyleBackColor = true;
            // 
            // rbLatestBuild
            // 
            this.rbLatestBuild.AutoSize = true;
            this.rbLatestBuild.Checked = true;
            this.rbLatestBuild.Location = new System.Drawing.Point(6, 19);
            this.rbLatestBuild.Name = "rbLatestBuild";
            this.rbLatestBuild.Size = new System.Drawing.Size(54, 17);
            this.rbLatestBuild.TabIndex = 1;
            this.rbLatestBuild.TabStop = true;
            this.rbLatestBuild.Text = "Latest";
            this.rbLatestBuild.UseVisualStyleBackColor = true;
            // 
            // grpJenkin
            // 
            this.grpJenkin.Controls.Add(this.cmbReleaseUrls);
            this.grpJenkin.Controls.Add(this.rbReleaseBuild);
            this.grpJenkin.Controls.Add(this.rbBcBuild);
            this.grpJenkin.Controls.Add(this.rbMeBuild);
            this.grpJenkin.Location = new System.Drawing.Point(6, 20);
            this.grpJenkin.Name = "grpJenkin";
            this.grpJenkin.Size = new System.Drawing.Size(162, 60);
            this.grpJenkin.TabIndex = 0;
            this.grpJenkin.TabStop = false;
            this.grpJenkin.Text = "Jenkin";
            this.grpJenkin.Enter += new System.EventHandler(this.txtInstallDir_TextChanged);
            // 
            // cmbReleaseUrls
            // 
            this.cmbReleaseUrls.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReleaseUrls.FormattingEnabled = true;
            this.cmbReleaseUrls.Location = new System.Drawing.Point(71, 36);
            this.cmbReleaseUrls.Name = "cmbReleaseUrls";
            this.cmbReleaseUrls.Size = new System.Drawing.Size(85, 21);
            this.cmbReleaseUrls.TabIndex = 5;
            this.cmbReleaseUrls.SelectedIndexChanged += new System.EventHandler(this.cmbReleaseUrls_SelectedIndexChanged);
            this.cmbReleaseUrls.Click += new System.EventHandler(this.cmbReleaseUrls_Click);
            // 
            // rbReleaseBuild
            // 
            this.rbReleaseBuild.AutoSize = true;
            this.rbReleaseBuild.Location = new System.Drawing.Point(6, 37);
            this.rbReleaseBuild.Name = "rbReleaseBuild";
            this.rbReleaseBuild.Size = new System.Drawing.Size(64, 17);
            this.rbReleaseBuild.TabIndex = 3;
            this.rbReleaseBuild.Text = "Release";
            this.rbReleaseBuild.UseVisualStyleBackColor = true;
            // 
            // rbBcBuild
            // 
            this.rbBcBuild.AutoSize = true;
            this.rbBcBuild.Location = new System.Drawing.Point(71, 18);
            this.rbBcBuild.Name = "rbBcBuild";
            this.rbBcBuild.Size = new System.Drawing.Size(39, 17);
            this.rbBcBuild.TabIndex = 2;
            this.rbBcBuild.Tag = "Protect/job/Agent/job/BC/job/agent-b-branch-dna";
            this.rbBcBuild.Text = "BC";
            this.rbBcBuild.UseVisualStyleBackColor = true;
            // 
            // rbMeBuild
            // 
            this.rbMeBuild.AutoSize = true;
            this.rbMeBuild.Checked = true;
            this.rbMeBuild.Location = new System.Drawing.Point(6, 18);
            this.rbMeBuild.Name = "rbMeBuild";
            this.rbMeBuild.Size = new System.Drawing.Size(40, 17);
            this.rbMeBuild.TabIndex = 1;
            this.rbMeBuild.TabStop = true;
            this.rbMeBuild.Tag = "TestJobs/job/jshih/job/agent-p-publish-install-test";
            this.rbMeBuild.Text = "Me";
            this.rbMeBuild.UseVisualStyleBackColor = true;
            // 
            // lstDownload
            // 
            this.lstDownload.CommandsRunner = null;
            this.lstDownload.GroupName = "Group Name";
            this.lstDownload.Location = new System.Drawing.Point(17, 340);
            this.lstDownload.Logger = null;
            this.lstDownload.Name = "lstDownload";
            this.lstDownload.Size = new System.Drawing.Size(156, 67);
            this.lstDownload.TabIndex = 17;
            this.lstDownload.Visible = false;
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
            this.txtConsole.Size = new System.Drawing.Size(818, 363);
            this.txtConsole.TabIndex = 1;
            this.txtConsole.Text = "";
            // 
            // grpCommandGroups
            // 
            this.grpCommandGroups.Dock = System.Windows.Forms.DockStyle.Left;
            this.grpCommandGroups.Location = new System.Drawing.Point(320, 0);
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
            this.grpRollback.Location = new System.Drawing.Point(173, 0);
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
            this.grpReport.Size = new System.Drawing.Size(547, 221);
            this.grpReport.TabIndex = 11;
            this.grpReport.TabStop = false;
            this.grpReport.Text = "Report";
            // 
            // reportGrid1
            // 
            this.reportGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportGrid1.DosTasks = null;
            this.reportGrid1.Location = new System.Drawing.Point(3, 16);
            this.reportGrid1.Logger = null;
            this.reportGrid1.Name = "reportGrid1";
            this.reportGrid1.Size = new System.Drawing.Size(541, 202);
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
            this.groupBox1.Location = new System.Drawing.Point(489, 459);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(824, 240);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            // 
            // grpConsole
            // 
            this.grpConsole.Controls.Add(this.splitContainer1);
            this.grpConsole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpConsole.Location = new System.Drawing.Point(489, 0);
            this.grpConsole.Name = "grpConsole";
            this.grpConsole.Size = new System.Drawing.Size(824, 459);
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
            this.splitContainer1.Size = new System.Drawing.Size(818, 440);
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
            this.txtDebugger.Size = new System.Drawing.Size(818, 73);
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
            this.Controls.Add(this.grpInstallBase);
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
            this.grpInstaller.ResumeLayout(false);
            this.grpInstaller.PerformLayout();
            this.grpBuild.ResumeLayout(false);
            this.grpBuild.PerformLayout();
            this.grpJenkin.ResumeLayout(false);
            this.grpJenkin.PerformLayout();
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

        private System.Windows.Forms.GroupBox grpInstallBase;
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
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RichTextBox txtDebugger;
        private System.Windows.Forms.ComboBox cmbBatchCommand;
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
        private System.Windows.Forms.GroupBox grpInstaller;
        private System.Windows.Forms.RadioButton rbBootstrapper;
        private System.Windows.Forms.RadioButton rbCyUpgrade;
        private System.Windows.Forms.RadioButton rbMsi;
        private System.Windows.Forms.GroupBox grpBuild;
        private System.Windows.Forms.TextBox txtBuildNumber;
        private System.Windows.Forms.ComboBox cmbVersion;
        private System.Windows.Forms.RadioButton rbBuildNo;
        private System.Windows.Forms.RadioButton rbBuildVersion;
        private System.Windows.Forms.RadioButton rbLatestBuild;
        private System.Windows.Forms.GroupBox grpJenkin;
        private System.Windows.Forms.RadioButton rbReleaseBuild;
        private System.Windows.Forms.RadioButton rbBcBuild;
        private System.Windows.Forms.RadioButton rbMeBuild;
        private System.Windows.Forms.GroupBox grpInstall;
        private System.Windows.Forms.ComboBox cmbReleaseUrls;
    }
}

