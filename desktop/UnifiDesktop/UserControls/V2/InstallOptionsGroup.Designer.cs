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
            this.rbQa2 = new System.Windows.Forms.RadioButton();
            this.rbR02 = new System.Windows.Forms.RadioButton();
            this.rbR01 = new System.Windows.Forms.RadioButton();
            this.chkDebugBuild = new System.Windows.Forms.CheckBox();
            this.lblInstallPath = new System.Windows.Forms.Label();
            this.txtInstallDir = new System.Windows.Forms.TextBox();
            this.rbOptics = new System.Windows.Forms.RadioButton();
            this.rbProtect = new System.Windows.Forms.RadioButton();
            this.rbBootstrapper = new System.Windows.Forms.RadioButton();
            this.rbCyUpgrade = new System.Windows.Forms.RadioButton();
            this.rbMsi = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.rbAdmin = new System.Windows.Forms.RadioButton();
            this.btnInstall = new System.Windows.Forms.Button();
            this.btnUninstall = new System.Windows.Forms.Button();
            this.rbWithUi = new System.Windows.Forms.RadioButton();
            this.rbQuiet = new System.Windows.Forms.RadioButton();
            this.lblLineJenkins = new System.Windows.Forms.Label();
            this.lblProduct = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblConfig = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblInstaller = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblInstallAs = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblMode = new System.Windows.Forms.Label();
            this.pnlProduct = new System.Windows.Forms.Panel();
            this.pnlConfig = new System.Windows.Forms.Panel();
            this.pnlInstallMode = new System.Windows.Forms.Panel();
            this.pnlInstaller = new System.Windows.Forms.Panel();
            this.pnlInstallAs = new System.Windows.Forms.Panel();
            this.rbQa2New = new System.Windows.Forms.RadioButton();
            this.pnlProduct.SuspendLayout();
            this.pnlConfig.SuspendLayout();
            this.pnlInstallMode.SuspendLayout();
            this.pnlInstaller.SuspendLayout();
            this.pnlInstallAs.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbQa2
            // 
            this.rbQa2.AutoSize = true;
            this.rbQa2.Location = new System.Drawing.Point(101, 3);
            this.rbQa2.Name = "rbQa2";
            this.rbQa2.Size = new System.Drawing.Size(43, 17);
            this.rbQa2.TabIndex = 2;
            this.rbQa2.Tag = "qa2";
            this.rbQa2.Text = "qa2";
            this.rbQa2.UseVisualStyleBackColor = true;
            // 
            // rbR02
            // 
            this.rbR02.AutoSize = true;
            this.rbR02.Location = new System.Drawing.Point(59, 3);
            this.rbR02.Name = "rbR02";
            this.rbR02.Size = new System.Drawing.Size(41, 17);
            this.rbR02.TabIndex = 1;
            this.rbR02.Tag = "r02";
            this.rbR02.Text = "r02";
            this.rbR02.UseVisualStyleBackColor = true;
            // 
            // rbR01
            // 
            this.rbR01.AutoSize = true;
            this.rbR01.Checked = true;
            this.rbR01.Location = new System.Drawing.Point(18, 3);
            this.rbR01.Name = "rbR01";
            this.rbR01.Size = new System.Drawing.Size(41, 17);
            this.rbR01.TabIndex = 0;
            this.rbR01.TabStop = true;
            this.rbR01.Tag = "r01";
            this.rbR01.Text = "r01";
            this.rbR01.UseVisualStyleBackColor = true;
            // 
            // chkDebugBuild
            // 
            this.chkDebugBuild.AutoSize = true;
            this.chkDebugBuild.Location = new System.Drawing.Point(89, 23);
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
            this.txtInstallDir.Size = new System.Drawing.Size(141, 34);
            this.txtInstallDir.TabIndex = 16;
            this.txtInstallDir.Text = "C:\\Program Files\\Cylance\\Desktop";
            // 
            // rbOptics
            // 
            this.rbOptics.AutoSize = true;
            this.rbOptics.Location = new System.Drawing.Point(87, 3);
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
            this.rbProtect.Location = new System.Drawing.Point(18, 3);
            this.rbProtect.Name = "rbProtect";
            this.rbProtect.Size = new System.Drawing.Size(60, 17);
            this.rbProtect.TabIndex = 0;
            this.rbProtect.TabStop = true;
            this.rbProtect.Text = "Protect";
            this.rbProtect.UseVisualStyleBackColor = true;
            // 
            // rbBootstrapper
            // 
            this.rbBootstrapper.AutoSize = true;
            this.rbBootstrapper.Location = new System.Drawing.Point(89, 3);
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
            this.rbCyUpgrade.Location = new System.Drawing.Point(19, 22);
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
            this.rbMsi.Location = new System.Drawing.Point(19, 3);
            this.rbMsi.Name = "rbMsi";
            this.rbMsi.Size = new System.Drawing.Size(43, 17);
            this.rbMsi.TabIndex = 1;
            this.rbMsi.TabStop = true;
            this.rbMsi.Tag = "0";
            this.rbMsi.Text = "MSI";
            this.rbMsi.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(88, 3);
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
            this.rbAdmin.Location = new System.Drawing.Point(19, 3);
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
            this.btnInstall.Location = new System.Drawing.Point(6, 340);
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
            this.btnUninstall.Location = new System.Drawing.Point(116, 340);
            this.btnUninstall.Name = "btnUninstall";
            this.btnUninstall.Size = new System.Drawing.Size(75, 23);
            this.btnUninstall.TabIndex = 23;
            this.btnUninstall.Text = "Uninstall";
            this.btnUninstall.UseVisualStyleBackColor = true;
            this.btnUninstall.Click += new System.EventHandler(this.btnUninstall_Click);
            // 
            // rbWithUi
            // 
            this.rbWithUi.AutoSize = true;
            this.rbWithUi.Location = new System.Drawing.Point(87, 3);
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
            this.rbQuiet.Location = new System.Drawing.Point(18, 3);
            this.rbQuiet.Name = "rbQuiet";
            this.rbQuiet.Size = new System.Drawing.Size(51, 17);
            this.rbQuiet.TabIndex = 1;
            this.rbQuiet.TabStop = true;
            this.rbQuiet.Tag = "0";
            this.rbQuiet.Text = "Quiet";
            this.rbQuiet.UseVisualStyleBackColor = true;
            // 
            // lblLineJenkins
            // 
            this.lblLineJenkins.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLineJenkins.BackColor = System.Drawing.Color.Orange;
            this.lblLineJenkins.Location = new System.Drawing.Point(49, 57);
            this.lblLineJenkins.Name = "lblLineJenkins";
            this.lblLineJenkins.Size = new System.Drawing.Size(142, 2);
            this.lblLineJenkins.TabIndex = 26;
            // 
            // lblProduct
            // 
            this.lblProduct.AutoSize = true;
            this.lblProduct.Location = new System.Drawing.Point(3, 51);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(44, 13);
            this.lblProduct.TabIndex = 25;
            this.lblProduct.Text = "Product";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.BackColor = System.Drawing.Color.Orange;
            this.label6.Location = new System.Drawing.Point(49, 110);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(142, 2);
            this.label6.TabIndex = 28;
            // 
            // lblConfig
            // 
            this.lblConfig.AutoSize = true;
            this.lblConfig.Location = new System.Drawing.Point(3, 104);
            this.lblConfig.Name = "lblConfig";
            this.lblConfig.Size = new System.Drawing.Size(38, 13);
            this.lblConfig.TabIndex = 27;
            this.lblConfig.Text = "Config";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.BackColor = System.Drawing.Color.Orange;
            this.label7.Location = new System.Drawing.Point(49, 163);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(142, 2);
            this.label7.TabIndex = 30;
            // 
            // lblInstaller
            // 
            this.lblInstaller.AutoSize = true;
            this.lblInstaller.Location = new System.Drawing.Point(3, 157);
            this.lblInstaller.Name = "lblInstaller";
            this.lblInstaller.Size = new System.Drawing.Size(46, 13);
            this.lblInstaller.TabIndex = 29;
            this.lblInstaller.Text = "Installer";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.Orange;
            this.label1.Location = new System.Drawing.Point(54, 235);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 2);
            this.label1.TabIndex = 32;
            // 
            // lblInstallAs
            // 
            this.lblInstallAs.AutoSize = true;
            this.lblInstallAs.Location = new System.Drawing.Point(3, 229);
            this.lblInstallAs.Name = "lblInstallAs";
            this.lblInstallAs.Size = new System.Drawing.Size(50, 13);
            this.lblInstallAs.TabIndex = 31;
            this.lblInstallAs.Text = "Install as";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.Color.Orange;
            this.label2.Location = new System.Drawing.Point(49, 288);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 2);
            this.label2.TabIndex = 34;
            // 
            // lblMode
            // 
            this.lblMode.AutoSize = true;
            this.lblMode.Location = new System.Drawing.Point(3, 282);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(33, 13);
            this.lblMode.TabIndex = 33;
            this.lblMode.Text = "Mode";
            // 
            // pnlProduct
            // 
            this.pnlProduct.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlProduct.Controls.Add(this.rbProtect);
            this.pnlProduct.Controls.Add(this.rbOptics);
            this.pnlProduct.Location = new System.Drawing.Point(0, 67);
            this.pnlProduct.Name = "pnlProduct";
            this.pnlProduct.Size = new System.Drawing.Size(196, 24);
            this.pnlProduct.TabIndex = 35;
            // 
            // pnlConfig
            // 
            this.pnlConfig.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlConfig.Controls.Add(this.rbQa2New);
            this.pnlConfig.Controls.Add(this.rbQa2);
            this.pnlConfig.Controls.Add(this.rbR01);
            this.pnlConfig.Controls.Add(this.rbR02);
            this.pnlConfig.Location = new System.Drawing.Point(0, 120);
            this.pnlConfig.Name = "pnlConfig";
            this.pnlConfig.Size = new System.Drawing.Size(196, 24);
            this.pnlConfig.TabIndex = 36;
            // 
            // pnlInstallMode
            // 
            this.pnlInstallMode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlInstallMode.Controls.Add(this.rbQuiet);
            this.pnlInstallMode.Controls.Add(this.rbWithUi);
            this.pnlInstallMode.Location = new System.Drawing.Point(0, 298);
            this.pnlInstallMode.Name = "pnlInstallMode";
            this.pnlInstallMode.Size = new System.Drawing.Size(196, 24);
            this.pnlInstallMode.TabIndex = 37;
            // 
            // pnlInstaller
            // 
            this.pnlInstaller.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlInstaller.Controls.Add(this.rbMsi);
            this.pnlInstaller.Controls.Add(this.chkDebugBuild);
            this.pnlInstaller.Controls.Add(this.rbCyUpgrade);
            this.pnlInstaller.Controls.Add(this.rbBootstrapper);
            this.pnlInstaller.Location = new System.Drawing.Point(0, 173);
            this.pnlInstaller.Name = "pnlInstaller";
            this.pnlInstaller.Size = new System.Drawing.Size(196, 44);
            this.pnlInstaller.TabIndex = 38;
            // 
            // pnlInstallAs
            // 
            this.pnlInstallAs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlInstallAs.Controls.Add(this.rbAdmin);
            this.pnlInstallAs.Controls.Add(this.radioButton1);
            this.pnlInstallAs.Location = new System.Drawing.Point(0, 245);
            this.pnlInstallAs.Name = "pnlInstallAs";
            this.pnlInstallAs.Size = new System.Drawing.Size(196, 24);
            this.pnlInstallAs.TabIndex = 38;
            // 
            // rbQa2New
            // 
            this.rbQa2New.AutoSize = true;
            this.rbQa2New.Location = new System.Drawing.Point(144, 3);
            this.rbQa2New.Name = "rbQa2New";
            this.rbQa2New.Size = new System.Drawing.Size(49, 17);
            this.rbQa2New.TabIndex = 3;
            this.rbQa2New.Tag = "qa2";
            this.rbQa2New.Text = "qa2n";
            this.rbQa2New.UseVisualStyleBackColor = true;
            // 
            // InstallOptionsGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlInstallAs);
            this.Controls.Add(this.pnlInstaller);
            this.Controls.Add(this.pnlInstallMode);
            this.Controls.Add(this.pnlConfig);
            this.Controls.Add(this.pnlProduct);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblMode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblInstallAs);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblInstaller);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblConfig);
            this.Controls.Add(this.lblLineJenkins);
            this.Controls.Add(this.lblProduct);
            this.Controls.Add(this.btnUninstall);
            this.Controls.Add(this.btnInstall);
            this.Controls.Add(this.lblInstallPath);
            this.Controls.Add(this.txtInstallDir);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(196, 370);
            this.Name = "InstallOptionsGroup";
            this.Size = new System.Drawing.Size(196, 370);
            this.DoubleClick += new System.EventHandler(this.btnInstall_Click);
            this.pnlProduct.ResumeLayout(false);
            this.pnlProduct.PerformLayout();
            this.pnlConfig.ResumeLayout(false);
            this.pnlConfig.PerformLayout();
            this.pnlInstallMode.ResumeLayout(false);
            this.pnlInstallMode.PerformLayout();
            this.pnlInstaller.ResumeLayout(false);
            this.pnlInstaller.PerformLayout();
            this.pnlInstallAs.ResumeLayout(false);
            this.pnlInstallAs.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RadioButton rbQa2;
        private System.Windows.Forms.RadioButton rbR02;
        private System.Windows.Forms.RadioButton rbR01;
        private System.Windows.Forms.CheckBox chkDebugBuild;
        private System.Windows.Forms.Label lblInstallPath;
        private System.Windows.Forms.TextBox txtInstallDir;
        private System.Windows.Forms.RadioButton rbOptics;
        private System.Windows.Forms.RadioButton rbProtect;
        private System.Windows.Forms.RadioButton rbBootstrapper;
        private System.Windows.Forms.RadioButton rbCyUpgrade;
        private System.Windows.Forms.RadioButton rbMsi;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton rbAdmin;
        private System.Windows.Forms.Button btnInstall;
        private System.Windows.Forms.Button btnUninstall;
        private System.Windows.Forms.RadioButton rbWithUi;
        private System.Windows.Forms.RadioButton rbQuiet;
        private System.Windows.Forms.Label lblLineJenkins;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblConfig;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblInstaller;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblInstallAs;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.Panel pnlProduct;
        private System.Windows.Forms.Panel pnlConfig;
        private System.Windows.Forms.Panel pnlInstallMode;
        private System.Windows.Forms.Panel pnlInstaller;
        private System.Windows.Forms.Panel pnlInstallAs;
        private System.Windows.Forms.RadioButton rbQa2New;
    }
}
