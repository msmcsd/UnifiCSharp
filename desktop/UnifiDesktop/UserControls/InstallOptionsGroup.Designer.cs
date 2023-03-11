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
            this.rbOptics = new System.Windows.Forms.RadioButton();
            this.rbProtect = new System.Windows.Forms.RadioButton();
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.grpConfig.SuspendLayout();
            this.grpProduct.SuspendLayout();
            this.grpInstaller.SuspendLayout();
            this.grpUser.SuspendLayout();
            this.grpInstallMode.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpConfig
            // 
            this.grpConfig.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpConfig.Controls.Add(this.label1);
            this.grpConfig.Controls.Add(this.rbQa2);
            this.grpConfig.Controls.Add(this.rbR02);
            this.grpConfig.Controls.Add(this.rbR01);
            this.grpConfig.Location = new System.Drawing.Point(5, 86);
            this.grpConfig.Margin = new System.Windows.Forms.Padding(5);
            this.grpConfig.Name = "grpConfig";
            this.grpConfig.Size = new System.Drawing.Size(238, 35);
            this.grpConfig.TabIndex = 7;
            this.grpConfig.TabStop = false;
            // 
            // rbQa2
            // 
            this.rbQa2.AutoSize = true;
            this.rbQa2.Location = new System.Drawing.Point(161, 12);
            this.rbQa2.Name = "rbQa2";
            this.rbQa2.Size = new System.Drawing.Size(43, 17);
            this.rbQa2.TabIndex = 2;
            this.rbQa2.Text = "qa2";
            this.rbQa2.UseVisualStyleBackColor = true;
            // 
            // rbR02
            // 
            this.rbR02.AutoSize = true;
            this.rbR02.Location = new System.Drawing.Point(110, 12);
            this.rbR02.Name = "rbR02";
            this.rbR02.Size = new System.Drawing.Size(41, 17);
            this.rbR02.TabIndex = 1;
            this.rbR02.Text = "r02";
            this.rbR02.UseVisualStyleBackColor = true;
            // 
            // rbR01
            // 
            this.rbR01.AutoSize = true;
            this.rbR01.Checked = true;
            this.rbR01.Location = new System.Drawing.Point(63, 12);
            this.rbR01.Name = "rbR01";
            this.rbR01.Size = new System.Drawing.Size(41, 17);
            this.rbR01.TabIndex = 0;
            this.rbR01.TabStop = true;
            this.rbR01.Text = "r01";
            this.rbR01.UseVisualStyleBackColor = true;
            // 
            // chkDebugBuild
            // 
            this.chkDebugBuild.AutoSize = true;
            this.chkDebugBuild.Location = new System.Drawing.Point(133, 32);
            this.chkDebugBuild.Margin = new System.Windows.Forms.Padding(5, 3, 3, 3);
            this.chkDebugBuild.Name = "chkDebugBuild";
            this.chkDebugBuild.Size = new System.Drawing.Size(82, 17);
            this.chkDebugBuild.TabIndex = 18;
            this.chkDebugBuild.Tag = "Debug";
            this.chkDebugBuild.Text = "Debug build";
            this.chkDebugBuild.UseVisualStyleBackColor = true;
            // 
            // lblInstallPath
            // 
            this.lblInstallPath.Location = new System.Drawing.Point(5, 3);
            this.lblInstallPath.Name = "lblInstallPath";
            this.lblInstallPath.Size = new System.Drawing.Size(42, 34);
            this.lblInstallPath.TabIndex = 17;
            this.lblInstallPath.Text = "Install Dir:";
            this.lblInstallPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtInstallDir
            // 
            this.txtInstallDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInstallDir.Location = new System.Drawing.Point(50, 3);
            this.txtInstallDir.Multiline = true;
            this.txtInstallDir.Name = "txtInstallDir";
            this.txtInstallDir.Size = new System.Drawing.Size(193, 34);
            this.txtInstallDir.TabIndex = 16;
            this.txtInstallDir.Text = "C:\\Program Files\\123";
            // 
            // grpProduct
            // 
            this.grpProduct.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpProduct.Controls.Add(this.label2);
            this.grpProduct.Controls.Add(this.rbOptics);
            this.grpProduct.Controls.Add(this.rbProtect);
            this.grpProduct.Location = new System.Drawing.Point(5, 43);
            this.grpProduct.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.grpProduct.Name = "grpProduct";
            this.grpProduct.Size = new System.Drawing.Size(238, 35);
            this.grpProduct.TabIndex = 19;
            this.grpProduct.TabStop = false;
            // 
            // rbOptics
            // 
            this.rbOptics.AutoSize = true;
            this.rbOptics.Location = new System.Drawing.Point(132, 12);
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
            this.rbProtect.Location = new System.Drawing.Point(63, 12);
            this.rbProtect.Name = "rbProtect";
            this.rbProtect.Size = new System.Drawing.Size(60, 17);
            this.rbProtect.TabIndex = 0;
            this.rbProtect.TabStop = true;
            this.rbProtect.Text = "Protect";
            this.rbProtect.UseVisualStyleBackColor = true;
            // 
            // grpInstaller
            // 
            this.grpInstaller.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpInstaller.Controls.Add(this.label3);
            this.grpInstaller.Controls.Add(this.rbBootstrapper);
            this.grpInstaller.Controls.Add(this.rbCyUpgrade);
            this.grpInstaller.Controls.Add(this.rbMsi);
            this.grpInstaller.Controls.Add(this.chkDebugBuild);
            this.grpInstaller.Location = new System.Drawing.Point(5, 129);
            this.grpInstaller.Name = "grpInstaller";
            this.grpInstaller.Size = new System.Drawing.Size(238, 58);
            this.grpInstaller.TabIndex = 20;
            this.grpInstaller.TabStop = false;
            // 
            // rbBootstrapper
            // 
            this.rbBootstrapper.AutoSize = true;
            this.rbBootstrapper.Location = new System.Drawing.Point(133, 12);
            this.rbBootstrapper.Name = "rbBootstrapper";
            this.rbBootstrapper.Size = new System.Drawing.Size(88, 17);
            this.rbBootstrapper.TabIndex = 3;
            this.rbBootstrapper.Tag = "3";
            this.rbBootstrapper.Text = "Bootstrapper";
            this.rbBootstrapper.UseVisualStyleBackColor = true;
            // 
            // rbCyUpgrade
            // 
            this.rbCyUpgrade.AutoSize = true;
            this.rbCyUpgrade.Location = new System.Drawing.Point(63, 31);
            this.rbCyUpgrade.Name = "rbCyUpgrade";
            this.rbCyUpgrade.Size = new System.Drawing.Size(66, 17);
            this.rbCyUpgrade.TabIndex = 2;
            this.rbCyUpgrade.Tag = "2";
            this.rbCyUpgrade.Text = "Upgrade";
            this.rbCyUpgrade.UseVisualStyleBackColor = true;
            // 
            // rbMsi
            // 
            this.rbMsi.AutoSize = true;
            this.rbMsi.Checked = true;
            this.rbMsi.Location = new System.Drawing.Point(63, 12);
            this.rbMsi.Name = "rbMsi";
            this.rbMsi.Size = new System.Drawing.Size(43, 17);
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
            this.grpUser.Controls.Add(this.label4);
            this.grpUser.Controls.Add(this.radioButton1);
            this.grpUser.Controls.Add(this.rbAdmin);
            this.grpUser.Location = new System.Drawing.Point(5, 193);
            this.grpUser.Name = "grpUser";
            this.grpUser.Size = new System.Drawing.Size(238, 35);
            this.grpUser.TabIndex = 21;
            this.grpUser.TabStop = false;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(141, 12);
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
            this.rbAdmin.Location = new System.Drawing.Point(72, 12);
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
            this.btnInstall.Location = new System.Drawing.Point(5, 284);
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
            this.btnUninstall.Location = new System.Drawing.Point(168, 284);
            this.btnUninstall.Name = "btnUninstall";
            this.btnUninstall.Size = new System.Drawing.Size(75, 23);
            this.btnUninstall.TabIndex = 23;
            this.btnUninstall.Text = "Uninstall";
            this.btnUninstall.UseVisualStyleBackColor = true;
            this.btnUninstall.Click += new System.EventHandler(this.btnUninstall_Click);
            // 
            // grpInstallMode
            // 
            this.grpInstallMode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpInstallMode.Controls.Add(this.label5);
            this.grpInstallMode.Controls.Add(this.rbWithUi);
            this.grpInstallMode.Controls.Add(this.rbQuiet);
            this.grpInstallMode.Location = new System.Drawing.Point(5, 231);
            this.grpInstallMode.Name = "grpInstallMode";
            this.grpInstallMode.Size = new System.Drawing.Size(238, 35);
            this.grpInstallMode.TabIndex = 24;
            this.grpInstallMode.TabStop = false;
            // 
            // rbWithUi
            // 
            this.rbWithUi.AutoSize = true;
            this.rbWithUi.Location = new System.Drawing.Point(141, 12);
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
            this.rbQuiet.Location = new System.Drawing.Point(72, 12);
            this.rbQuiet.Name = "rbQuiet";
            this.rbQuiet.Size = new System.Drawing.Size(51, 17);
            this.rbQuiet.TabIndex = 1;
            this.rbQuiet.TabStop = true;
            this.rbQuiet.Tag = "0";
            this.rbQuiet.Text = "Quiet";
            this.rbQuiet.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "config";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Product";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Installer";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Install as";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Mode";
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
            this.Controls.Add(this.lblInstallPath);
            this.Controls.Add(this.txtInstallDir);
            this.Controls.Add(this.grpConfig);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(248, 312);
            this.Name = "InstallOptionsGroup";
            this.Size = new System.Drawing.Size(248, 312);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}
