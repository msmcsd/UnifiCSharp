namespace UnifiDesktop.UserControls
{
    partial class DownloadCommandGroup
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
            this.rbBootstrapper = new System.Windows.Forms.RadioButton();
            this.rbCyUpgrade = new System.Windows.Forms.RadioButton();
            this.rbMsi = new System.Windows.Forms.RadioButton();
            this.txtBuildNumber = new System.Windows.Forms.TextBox();
            this.cmbVersion = new System.Windows.Forms.ComboBox();
            this.rbBuildNo = new System.Windows.Forms.RadioButton();
            this.rbBuildVersion = new System.Windows.Forms.RadioButton();
            this.rbLatestBuild = new System.Windows.Forms.RadioButton();
            this.cmbReleaseUrls = new System.Windows.Forms.ComboBox();
            this.rbReleaseBuild = new System.Windows.Forms.RadioButton();
            this.rbBcBuild = new System.Windows.Forms.RadioButton();
            this.rbMeBuild = new System.Windows.Forms.RadioButton();
            this.lbJenkins = new System.Windows.Forms.Label();
            this.lblLineJenkins = new System.Windows.Forms.Label();
            this.lblLineBuild = new System.Windows.Forms.Label();
            this.lblBuild = new System.Windows.Forms.Label();
            this.lblLineInstaller = new System.Windows.Forms.Label();
            this.lblInstaller = new System.Windows.Forms.Label();
            this.pnlJenkins = new System.Windows.Forms.Panel();
            this.pnlBuild = new System.Windows.Forms.Panel();
            this.pnlInstaller = new System.Windows.Forms.Panel();
            this.pnlJenkins.SuspendLayout();
            this.pnlBuild.SuspendLayout();
            this.pnlInstaller.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbBootstrapper
            // 
            this.rbBootstrapper.AutoSize = true;
            this.rbBootstrapper.Location = new System.Drawing.Point(92, 3);
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
            this.rbCyUpgrade.Location = new System.Drawing.Point(18, 25);
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
            this.rbMsi.Location = new System.Drawing.Point(18, 3);
            this.rbMsi.Name = "rbMsi";
            this.rbMsi.Size = new System.Drawing.Size(44, 17);
            this.rbMsi.TabIndex = 1;
            this.rbMsi.TabStop = true;
            this.rbMsi.Tag = "0";
            this.rbMsi.Text = "MSI";
            this.rbMsi.UseVisualStyleBackColor = true;
            // 
            // txtBuildNumber
            // 
            this.txtBuildNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuildNumber.Location = new System.Drawing.Point(113, 46);
            this.txtBuildNumber.Name = "txtBuildNumber";
            this.txtBuildNumber.Size = new System.Drawing.Size(103, 20);
            this.txtBuildNumber.TabIndex = 5;
            this.txtBuildNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnControlKeyDown);
            this.txtBuildNumber.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnControlMouseDown);
            // 
            // cmbVersion
            // 
            this.cmbVersion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbVersion.FormattingEnabled = true;
            this.cmbVersion.Location = new System.Drawing.Point(92, 24);
            this.cmbVersion.Name = "cmbVersion";
            this.cmbVersion.Size = new System.Drawing.Size(124, 21);
            this.cmbVersion.TabIndex = 4;
            this.cmbVersion.Click += new System.EventHandler(this.cmbVersion_Click);
            this.cmbVersion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnControlKeyDown);
            this.cmbVersion.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnControlMouseDown);
            // 
            // rbBuildNo
            // 
            this.rbBuildNo.AutoSize = true;
            this.rbBuildNo.Location = new System.Drawing.Point(18, 47);
            this.rbBuildNo.Name = "rbBuildNo";
            this.rbBuildNo.Size = new System.Drawing.Size(88, 17);
            this.rbBuildNo.TabIndex = 3;
            this.rbBuildNo.Text = "Build Number";
            this.rbBuildNo.UseVisualStyleBackColor = true;
            // 
            // rbBuildVersion
            // 
            this.rbBuildVersion.AutoSize = true;
            this.rbBuildVersion.Location = new System.Drawing.Point(18, 25);
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
            this.rbLatestBuild.Location = new System.Drawing.Point(18, 3);
            this.rbLatestBuild.Name = "rbLatestBuild";
            this.rbLatestBuild.Size = new System.Drawing.Size(54, 17);
            this.rbLatestBuild.TabIndex = 1;
            this.rbLatestBuild.TabStop = true;
            this.rbLatestBuild.Text = "Latest";
            this.rbLatestBuild.UseVisualStyleBackColor = true;
            // 
            // cmbReleaseUrls
            // 
            this.cmbReleaseUrls.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbReleaseUrls.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReleaseUrls.FormattingEnabled = true;
            this.cmbReleaseUrls.Location = new System.Drawing.Point(92, 24);
            this.cmbReleaseUrls.Name = "cmbReleaseUrls";
            this.cmbReleaseUrls.Size = new System.Drawing.Size(124, 21);
            this.cmbReleaseUrls.TabIndex = 5;
            this.cmbReleaseUrls.SelectedIndexChanged += new System.EventHandler(this.cmbReleaseUrls_SelectedIndexChanged);
            this.cmbReleaseUrls.Click += new System.EventHandler(this.cmbReleaseUrls_Click);
            // 
            // rbReleaseBuild
            // 
            this.rbReleaseBuild.AutoSize = true;
            this.rbReleaseBuild.Location = new System.Drawing.Point(18, 25);
            this.rbReleaseBuild.Name = "rbReleaseBuild";
            this.rbReleaseBuild.Size = new System.Drawing.Size(64, 17);
            this.rbReleaseBuild.TabIndex = 3;
            this.rbReleaseBuild.Text = "Release";
            this.rbReleaseBuild.UseVisualStyleBackColor = true;
            // 
            // rbBcBuild
            // 
            this.rbBcBuild.AutoSize = true;
            this.rbBcBuild.Location = new System.Drawing.Point(92, 3);
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
            this.rbMeBuild.Location = new System.Drawing.Point(18, 3);
            this.rbMeBuild.Name = "rbMeBuild";
            this.rbMeBuild.Size = new System.Drawing.Size(40, 17);
            this.rbMeBuild.TabIndex = 1;
            this.rbMeBuild.TabStop = true;
            this.rbMeBuild.Tag = "TestJobs/job/jshih/job/agent-p-publish-install-test";
            this.rbMeBuild.Text = "Me";
            this.rbMeBuild.UseVisualStyleBackColor = true;
            // 
            // lbJenkins
            // 
            this.lbJenkins.AutoSize = true;
            this.lbJenkins.Location = new System.Drawing.Point(3, 5);
            this.lbJenkins.Name = "lbJenkins";
            this.lbJenkins.Size = new System.Drawing.Size(43, 13);
            this.lbJenkins.TabIndex = 6;
            this.lbJenkins.Text = "Jenkins";
            // 
            // lblLineJenkins
            // 
            this.lblLineJenkins.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLineJenkins.BackColor = System.Drawing.Color.Orange;
            this.lblLineJenkins.Location = new System.Drawing.Point(49, 12);
            this.lblLineJenkins.Name = "lblLineJenkins";
            this.lblLineJenkins.Size = new System.Drawing.Size(172, 2);
            this.lblLineJenkins.TabIndex = 7;
            // 
            // lblLineBuild
            // 
            this.lblLineBuild.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLineBuild.BackColor = System.Drawing.Color.Orange;
            this.lblLineBuild.Location = new System.Drawing.Point(35, 86);
            this.lblLineBuild.Name = "lblLineBuild";
            this.lblLineBuild.Size = new System.Drawing.Size(186, 2);
            this.lblLineBuild.TabIndex = 9;
            // 
            // lblBuild
            // 
            this.lblBuild.AutoSize = true;
            this.lblBuild.Location = new System.Drawing.Point(3, 80);
            this.lblBuild.Name = "lblBuild";
            this.lblBuild.Size = new System.Drawing.Size(30, 13);
            this.lblBuild.TabIndex = 8;
            this.lblBuild.Text = "Build";
            // 
            // lblLineInstaller
            // 
            this.lblLineInstaller.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLineInstaller.BackColor = System.Drawing.Color.Orange;
            this.lblLineInstaller.Location = new System.Drawing.Point(49, 184);
            this.lblLineInstaller.Name = "lblLineInstaller";
            this.lblLineInstaller.Size = new System.Drawing.Size(172, 2);
            this.lblLineInstaller.TabIndex = 11;
            // 
            // lblInstaller
            // 
            this.lblInstaller.AutoSize = true;
            this.lblInstaller.Location = new System.Drawing.Point(3, 177);
            this.lblInstaller.Name = "lblInstaller";
            this.lblInstaller.Size = new System.Drawing.Size(43, 13);
            this.lblInstaller.TabIndex = 10;
            this.lblInstaller.Text = "Installer";
            // 
            // pnlJenkins
            // 
            this.pnlJenkins.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlJenkins.Controls.Add(this.rbMeBuild);
            this.pnlJenkins.Controls.Add(this.rbBcBuild);
            this.pnlJenkins.Controls.Add(this.rbReleaseBuild);
            this.pnlJenkins.Controls.Add(this.cmbReleaseUrls);
            this.pnlJenkins.Location = new System.Drawing.Point(3, 22);
            this.pnlJenkins.Name = "pnlJenkins";
            this.pnlJenkins.Size = new System.Drawing.Size(221, 46);
            this.pnlJenkins.TabIndex = 12;
            // 
            // pnlBuild
            // 
            this.pnlBuild.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBuild.Controls.Add(this.txtBuildNumber);
            this.pnlBuild.Controls.Add(this.rbLatestBuild);
            this.pnlBuild.Controls.Add(this.rbBuildVersion);
            this.pnlBuild.Controls.Add(this.rbBuildNo);
            this.pnlBuild.Controls.Add(this.cmbVersion);
            this.pnlBuild.Location = new System.Drawing.Point(3, 97);
            this.pnlBuild.Name = "pnlBuild";
            this.pnlBuild.Size = new System.Drawing.Size(221, 70);
            this.pnlBuild.TabIndex = 13;
            // 
            // pnlInstaller
            // 
            this.pnlInstaller.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlInstaller.Controls.Add(this.rbMsi);
            this.pnlInstaller.Controls.Add(this.rbCyUpgrade);
            this.pnlInstaller.Controls.Add(this.rbBootstrapper);
            this.pnlInstaller.Location = new System.Drawing.Point(3, 194);
            this.pnlInstaller.Name = "pnlInstaller";
            this.pnlInstaller.Size = new System.Drawing.Size(221, 46);
            this.pnlInstaller.TabIndex = 14;
            // 
            // DownloadCommandGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlInstaller);
            this.Controls.Add(this.pnlBuild);
            this.Controls.Add(this.pnlJenkins);
            this.Controls.Add(this.lblLineInstaller);
            this.Controls.Add(this.lblInstaller);
            this.Controls.Add(this.lblLineBuild);
            this.Controls.Add(this.lblBuild);
            this.Controls.Add(this.lblLineJenkins);
            this.Controls.Add(this.lbJenkins);
            this.MinimumSize = new System.Drawing.Size(182, 241);
            this.Name = "DownloadCommandGroup";
            this.Size = new System.Drawing.Size(227, 245);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.DownloadCommandGroup_Paint);
            this.pnlJenkins.ResumeLayout(false);
            this.pnlJenkins.PerformLayout();
            this.pnlBuild.ResumeLayout(false);
            this.pnlBuild.PerformLayout();
            this.pnlInstaller.ResumeLayout(false);
            this.pnlInstaller.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RadioButton rbBootstrapper;
        private System.Windows.Forms.RadioButton rbCyUpgrade;
        private System.Windows.Forms.RadioButton rbMsi;
        private System.Windows.Forms.TextBox txtBuildNumber;
        private System.Windows.Forms.ComboBox cmbVersion;
        private System.Windows.Forms.RadioButton rbBuildNo;
        private System.Windows.Forms.RadioButton rbBuildVersion;
        private System.Windows.Forms.RadioButton rbLatestBuild;
        private System.Windows.Forms.ComboBox cmbReleaseUrls;
        private System.Windows.Forms.RadioButton rbReleaseBuild;
        private System.Windows.Forms.RadioButton rbBcBuild;
        private System.Windows.Forms.RadioButton rbMeBuild;
        private System.Windows.Forms.Label lbJenkins;
        private System.Windows.Forms.Label lblLineJenkins;
        private System.Windows.Forms.Label lblLineBuild;
        private System.Windows.Forms.Label lblBuild;
        private System.Windows.Forms.Label lblLineInstaller;
        private System.Windows.Forms.Label lblInstaller;
        private System.Windows.Forms.Panel pnlJenkins;
        private System.Windows.Forms.Panel pnlBuild;
        private System.Windows.Forms.Panel pnlInstaller;
    }
}
