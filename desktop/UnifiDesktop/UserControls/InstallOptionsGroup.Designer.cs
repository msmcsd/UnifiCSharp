namespace UnifiDesktop.UserControls
{
    partial class InstallOptionsGroup
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
            this.grpConfig = new System.Windows.Forms.GroupBox();
            this.rbQa2 = new System.Windows.Forms.RadioButton();
            this.rbR02 = new System.Windows.Forms.RadioButton();
            this.rbR01 = new System.Windows.Forms.RadioButton();
            this.chkDebugBuild = new System.Windows.Forms.CheckBox();
            this.lblInstallPath = new System.Windows.Forms.Label();
            this.txtInstallDir = new System.Windows.Forms.TextBox();
            this.grpProduct = new System.Windows.Forms.GroupBox();
            this.rbProtect = new System.Windows.Forms.RadioButton();
            this.rbOptics = new System.Windows.Forms.RadioButton();
            this.grpInstaller = new System.Windows.Forms.GroupBox();
            this.rbBootstrapper = new System.Windows.Forms.RadioButton();
            this.rbCyUpgrade = new System.Windows.Forms.RadioButton();
            this.rbMsi = new System.Windows.Forms.RadioButton();
            this.grpUser = new System.Windows.Forms.GroupBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.rbAdmin = new System.Windows.Forms.RadioButton();
            this.btnInstall = new System.Windows.Forms.Button();
            this.btnUninstall = new System.Windows.Forms.Button();
            this.grpInstallMode = new System.Windows.Forms.GroupBox();
            this.rbWithUi = new System.Windows.Forms.RadioButton();
            this.rbQuiet = new System.Windows.Forms.RadioButton();
            this.grpConfig.SuspendLayout();
            this.grpProduct.SuspendLayout();
            this.grpInstaller.SuspendLayout();
            this.grpUser.SuspendLayout();
            this.grpInstallMode.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpConfig
            // 
            this.grpConfig.Controls.Add(this.rbQa2);
            this.grpConfig.Controls.Add(this.rbR02);
            this.grpConfig.Controls.Add(this.rbR01);
            this.grpConfig.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpConfig.Location = new System.Drawing.Point(0, 0);
            this.grpConfig.Margin = new System.Windows.Forms.Padding(5);
            this.grpConfig.Name = "grpConfig";
            this.grpConfig.Size = new System.Drawing.Size(167, 43);
            this.grpConfig.TabIndex = 7;
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
            // 
            // chkDebugBuild
            // 
            this.chkDebugBuild.AutoSize = true;
            this.chkDebugBuild.Location = new System.Drawing.Point(3, 51);
            this.chkDebugBuild.Name = "chkDebugBuild";
            this.chkDebugBuild.Size = new System.Drawing.Size(83, 17);
            this.chkDebugBuild.TabIndex = 18;
            this.chkDebugBuild.Tag = "Debug";
            this.chkDebugBuild.Text = "Debug build";
            this.chkDebugBuild.UseVisualStyleBackColor = true;
            // 
            // lblInstallPath
            // 
            this.lblInstallPath.AutoSize = true;
            this.lblInstallPath.Location = new System.Drawing.Point(0, 81);
            this.lblInstallPath.Name = "lblInstallPath";
            this.lblInstallPath.Size = new System.Drawing.Size(53, 13);
            this.lblInstallPath.TabIndex = 17;
            this.lblInstallPath.Text = "Install Dir:";
            // 
            // txtInstallDir
            // 
            this.txtInstallDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInstallDir.Location = new System.Drawing.Point(0, 98);
            this.txtInstallDir.Multiline = true;
            this.txtInstallDir.Name = "txtInstallDir";
            this.txtInstallDir.Size = new System.Drawing.Size(166, 34);
            this.txtInstallDir.TabIndex = 16;
            this.txtInstallDir.Text = "C:\\Program Files\\123";
            // 
            // grpProduct
            // 
            this.grpProduct.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpProduct.Controls.Add(this.rbOptics);
            this.grpProduct.Controls.Add(this.rbProtect);
            this.grpProduct.Location = new System.Drawing.Point(0, 140);
            this.grpProduct.Name = "grpProduct";
            this.grpProduct.Size = new System.Drawing.Size(167, 47);
            this.grpProduct.TabIndex = 19;
            this.grpProduct.TabStop = false;
            this.grpProduct.Text = "Product";
            // 
            // rbProtect
            // 
            this.rbProtect.AutoSize = true;
            this.rbProtect.Checked = true;
            this.rbProtect.Location = new System.Drawing.Point(7, 20);
            this.rbProtect.Name = "rbProtect";
            this.rbProtect.Size = new System.Drawing.Size(59, 17);
            this.rbProtect.TabIndex = 0;
            this.rbProtect.Text = "Protect";
            this.rbProtect.UseVisualStyleBackColor = true;
            // 
            // rbOptics
            // 
            this.rbOptics.AutoSize = true;
            this.rbOptics.Location = new System.Drawing.Point(87, 19);
            this.rbOptics.Name = "rbOptics";
            this.rbOptics.Size = new System.Drawing.Size(55, 17);
            this.rbOptics.TabIndex = 1;
            this.rbOptics.Text = "Optics";
            this.rbOptics.UseVisualStyleBackColor = true;
            // 
            // grpInstaller
            // 
            this.grpInstaller.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpInstaller.Controls.Add(this.rbBootstrapper);
            this.grpInstaller.Controls.Add(this.rbCyUpgrade);
            this.grpInstaller.Controls.Add(this.rbMsi);
            this.grpInstaller.Location = new System.Drawing.Point(0, 193);
            this.grpInstaller.Name = "grpInstaller";
            this.grpInstaller.Size = new System.Drawing.Size(167, 66);
            this.grpInstaller.TabIndex = 20;
            this.grpInstaller.TabStop = false;
            this.grpInstaller.Text = "Installer";
            // 
            // rbBootstrapper
            // 
            this.rbBootstrapper.AutoSize = true;
            this.rbBootstrapper.Location = new System.Drawing.Point(70, 19);
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
            this.rbCyUpgrade.Location = new System.Drawing.Point(6, 42);
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
            // grpUser
            // 
            this.grpUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpUser.Controls.Add(this.radioButton1);
            this.grpUser.Controls.Add(this.rbAdmin);
            this.grpUser.Location = new System.Drawing.Point(0, 265);
            this.grpUser.Name = "grpUser";
            this.grpUser.Size = new System.Drawing.Size(167, 44);
            this.grpUser.TabIndex = 21;
            this.grpUser.TabStop = false;
            this.grpUser.Text = "Install as";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(84, 19);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(47, 17);
            this.radioButton1.TabIndex = 3;
            this.radioButton1.Tag = "3";
            this.radioButton1.Text = "User";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // rbAdmin
            // 
            this.rbAdmin.AutoSize = true;
            this.rbAdmin.Checked = true;
            this.rbAdmin.Location = new System.Drawing.Point(6, 19);
            this.rbAdmin.Name = "rbAdmin";
            this.rbAdmin.Size = new System.Drawing.Size(54, 17);
            this.rbAdmin.TabIndex = 1;
            this.rbAdmin.TabStop = true;
            this.rbAdmin.Tag = "0";
            this.rbAdmin.Text = "Admin";
            this.rbAdmin.UseVisualStyleBackColor = true;
            // 
            // btnInstall
            // 
            this.btnInstall.Location = new System.Drawing.Point(6, 369);
            this.btnInstall.Name = "btnInstall";
            this.btnInstall.Size = new System.Drawing.Size(75, 23);
            this.btnInstall.TabIndex = 22;
            this.btnInstall.Text = "Install";
            this.btnInstall.UseVisualStyleBackColor = true;
            this.btnInstall.Click += new System.EventHandler(this.btnInstall_Click);
            // 
            // btnUninstall
            // 
            this.btnUninstall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUninstall.Location = new System.Drawing.Point(87, 369);
            this.btnUninstall.Name = "btnUninstall";
            this.btnUninstall.Size = new System.Drawing.Size(75, 23);
            this.btnUninstall.TabIndex = 23;
            this.btnUninstall.Text = "Uninstall";
            this.btnUninstall.UseVisualStyleBackColor = true;
            // 
            // grpInstallMode
            // 
            this.grpInstallMode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpInstallMode.Controls.Add(this.rbWithUi);
            this.grpInstallMode.Controls.Add(this.rbQuiet);
            this.grpInstallMode.Location = new System.Drawing.Point(0, 314);
            this.grpInstallMode.Name = "grpInstallMode";
            this.grpInstallMode.Size = new System.Drawing.Size(167, 44);
            this.grpInstallMode.TabIndex = 24;
            this.grpInstallMode.TabStop = false;
            this.grpInstallMode.Text = "Install Mode";
            // 
            // rbWithUi
            // 
            this.rbWithUi.AutoSize = true;
            this.rbWithUi.Location = new System.Drawing.Point(84, 19);
            this.rbWithUi.Name = "rbWithUi";
            this.rbWithUi.Size = new System.Drawing.Size(61, 17);
            this.rbWithUi.TabIndex = 3;
            this.rbWithUi.Tag = "3";
            this.rbWithUi.Text = "With UI";
            this.rbWithUi.UseVisualStyleBackColor = true;
            // 
            // rbQuiet
            // 
            this.rbQuiet.AutoSize = true;
            this.rbQuiet.Checked = true;
            this.rbQuiet.Location = new System.Drawing.Point(6, 19);
            this.rbQuiet.Name = "rbQuiet";
            this.rbQuiet.Size = new System.Drawing.Size(50, 17);
            this.rbQuiet.TabIndex = 1;
            this.rbQuiet.TabStop = true;
            this.rbQuiet.Tag = "0";
            this.rbQuiet.Text = "Quiet";
            this.rbQuiet.UseVisualStyleBackColor = true;
            // 
            // InstallOptionsGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpInstallMode);
            this.Controls.Add(this.btnUninstall);
            this.Controls.Add(this.btnInstall);
            this.Controls.Add(this.grpUser);
            this.Controls.Add(this.grpInstaller);
            this.Controls.Add(this.grpProduct);
            this.Controls.Add(this.chkDebugBuild);
            this.Controls.Add(this.lblInstallPath);
            this.Controls.Add(this.txtInstallDir);
            this.Controls.Add(this.grpConfig);
            this.Name = "InstallOptionsGroup";
            this.Size = new System.Drawing.Size(167, 403);
            this.DoubleClick += new System.EventHandler(this.btnInstall_Click);
            this.grpConfig.ResumeLayout(false);
            this.grpConfig.PerformLayout();
            this.grpProduct.ResumeLayout(false);
            this.grpProduct.PerformLayout();
            this.grpInstaller.ResumeLayout(false);
            this.grpInstaller.PerformLayout();
            this.grpUser.ResumeLayout(false);
            this.grpUser.PerformLayout();
            this.grpInstallMode.ResumeLayout(false);
            this.grpInstallMode.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpConfig;
        private System.Windows.Forms.RadioButton rbQa2;
        private System.Windows.Forms.RadioButton rbR02;
        private System.Windows.Forms.RadioButton rbR01;
        private System.Windows.Forms.CheckBox chkDebugBuild;
        private System.Windows.Forms.Label lblInstallPath;
        private System.Windows.Forms.TextBox txtInstallDir;
        private System.Windows.Forms.GroupBox grpProduct;
        private System.Windows.Forms.RadioButton rbOptics;
        private System.Windows.Forms.RadioButton rbProtect;
        private System.Windows.Forms.GroupBox grpInstaller;
        private System.Windows.Forms.RadioButton rbBootstrapper;
        private System.Windows.Forms.RadioButton rbCyUpgrade;
        private System.Windows.Forms.RadioButton rbMsi;
        private System.Windows.Forms.GroupBox grpUser;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton rbAdmin;
        private System.Windows.Forms.Button btnInstall;
        private System.Windows.Forms.Button btnUninstall;
        private System.Windows.Forms.GroupBox grpInstallMode;
        private System.Windows.Forms.RadioButton rbWithUi;
        private System.Windows.Forms.RadioButton rbQuiet;
    }
}
