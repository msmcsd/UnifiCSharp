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
            this.lblJenkins = new System.Windows.Forms.Label();
            this.lblBuild = new System.Windows.Forms.Label();
            this.lblInstaller = new System.Windows.Forms.Label();
            this.grpInstaller.SuspendLayout();
            this.grpBuild.SuspendLayout();
            this.grpJenkin.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpInstaller
            // 
            this.grpInstaller.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpInstaller.Controls.Add(this.lblInstaller);
            this.grpInstaller.Controls.Add(this.rbBootstrapper);
            this.grpInstaller.Controls.Add(this.rbCyUpgrade);
            this.grpInstaller.Controls.Add(this.rbMsi);
            this.grpInstaller.Location = new System.Drawing.Point(5, 148);
            this.grpInstaller.Name = "grpInstaller";
            this.grpInstaller.Size = new System.Drawing.Size(230, 58);
            this.grpInstaller.TabIndex = 5;
            this.grpInstaller.TabStop = false;
            // 
            // rbBootstrapper
            // 
            this.rbBootstrapper.AutoSize = true;
            this.rbBootstrapper.Location = new System.Drawing.Point(118, 12);
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
            this.rbCyUpgrade.Location = new System.Drawing.Point(53, 31);
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
            this.rbMsi.Location = new System.Drawing.Point(53, 12);
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
            this.grpBuild.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBuild.Controls.Add(this.lblBuild);
            this.grpBuild.Controls.Add(this.txtBuildNumber);
            this.grpBuild.Controls.Add(this.cmbVersion);
            this.grpBuild.Controls.Add(this.rbBuildNo);
            this.grpBuild.Controls.Add(this.rbBuildVersion);
            this.grpBuild.Controls.Add(this.rbLatestBuild);
            this.grpBuild.Location = new System.Drawing.Point(5, 62);
            this.grpBuild.Name = "grpBuild";
            this.grpBuild.Size = new System.Drawing.Size(230, 86);
            this.grpBuild.TabIndex = 4;
            this.grpBuild.TabStop = false;
            // 
            // txtBuildNumber
            // 
            this.txtBuildNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuildNumber.Location = new System.Drawing.Point(141, 57);
            this.txtBuildNumber.Name = "txtBuildNumber";
            this.txtBuildNumber.Size = new System.Drawing.Size(83, 20);
            this.txtBuildNumber.TabIndex = 5;
            this.txtBuildNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnControlKeyDown);
            this.txtBuildNumber.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnControlMouseDown);
            // 
            // cmbVersion
            // 
            this.cmbVersion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbVersion.FormattingEnabled = true;
            this.cmbVersion.Location = new System.Drawing.Point(120, 34);
            this.cmbVersion.Name = "cmbVersion";
            this.cmbVersion.Size = new System.Drawing.Size(104, 21);
            this.cmbVersion.TabIndex = 4;
            this.cmbVersion.Click += new System.EventHandler(this.cmbVersion_Click);
            this.cmbVersion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnControlKeyDown);
            this.cmbVersion.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnControlMouseDown);
            // 
            // rbBuildNo
            // 
            this.rbBuildNo.AutoSize = true;
            this.rbBuildNo.Location = new System.Drawing.Point(47, 58);
            this.rbBuildNo.Name = "rbBuildNo";
            this.rbBuildNo.Size = new System.Drawing.Size(88, 17);
            this.rbBuildNo.TabIndex = 3;
            this.rbBuildNo.Text = "Build Number";
            this.rbBuildNo.UseVisualStyleBackColor = true;
            // 
            // rbBuildVersion
            // 
            this.rbBuildVersion.AutoSize = true;
            this.rbBuildVersion.Location = new System.Drawing.Point(47, 35);
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
            this.rbLatestBuild.Location = new System.Drawing.Point(47, 12);
            this.rbLatestBuild.Name = "rbLatestBuild";
            this.rbLatestBuild.Size = new System.Drawing.Size(54, 17);
            this.rbLatestBuild.TabIndex = 1;
            this.rbLatestBuild.TabStop = true;
            this.rbLatestBuild.Text = "Latest";
            this.rbLatestBuild.UseVisualStyleBackColor = true;
            // 
            // grpJenkin
            // 
            this.grpJenkin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpJenkin.Controls.Add(this.lblJenkins);
            this.grpJenkin.Controls.Add(this.cmbReleaseUrls);
            this.grpJenkin.Controls.Add(this.rbReleaseBuild);
            this.grpJenkin.Controls.Add(this.rbBcBuild);
            this.grpJenkin.Controls.Add(this.rbMeBuild);
            this.grpJenkin.Location = new System.Drawing.Point(5, 0);
            this.grpJenkin.Name = "grpJenkin";
            this.grpJenkin.Size = new System.Drawing.Size(230, 62);
            this.grpJenkin.TabIndex = 3;
            this.grpJenkin.TabStop = false;
            // 
            // cmbReleaseUrls
            // 
            this.cmbReleaseUrls.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbReleaseUrls.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReleaseUrls.FormattingEnabled = true;
            this.cmbReleaseUrls.Location = new System.Drawing.Point(120, 33);
            this.cmbReleaseUrls.Name = "cmbReleaseUrls";
            this.cmbReleaseUrls.Size = new System.Drawing.Size(104, 21);
            this.cmbReleaseUrls.TabIndex = 5;
            this.cmbReleaseUrls.SelectedIndexChanged += new System.EventHandler(this.cmbReleaseUrls_SelectedIndexChanged);
            this.cmbReleaseUrls.Click += new System.EventHandler(this.cmbReleaseUrls_Click);
            // 
            // rbReleaseBuild
            // 
            this.rbReleaseBuild.AutoSize = true;
            this.rbReleaseBuild.Location = new System.Drawing.Point(47, 34);
            this.rbReleaseBuild.Name = "rbReleaseBuild";
            this.rbReleaseBuild.Size = new System.Drawing.Size(64, 17);
            this.rbReleaseBuild.TabIndex = 3;
            this.rbReleaseBuild.Text = "Release";
            this.rbReleaseBuild.UseVisualStyleBackColor = true;
            // 
            // rbBcBuild
            // 
            this.rbBcBuild.AutoSize = true;
            this.rbBcBuild.Location = new System.Drawing.Point(120, 12);
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
            this.rbMeBuild.Location = new System.Drawing.Point(47, 12);
            this.rbMeBuild.Name = "rbMeBuild";
            this.rbMeBuild.Size = new System.Drawing.Size(40, 17);
            this.rbMeBuild.TabIndex = 1;
            this.rbMeBuild.TabStop = true;
            this.rbMeBuild.Tag = "TestJobs/job/jshih/job/agent-p-publish-install-test";
            this.rbMeBuild.Text = "Me";
            this.rbMeBuild.UseVisualStyleBackColor = true;
            // 
            // lblJenkins
            // 
            this.lblJenkins.AutoSize = true;
            this.lblJenkins.Location = new System.Drawing.Point(6, 25);
            this.lblJenkins.Name = "lblJenkins";
            this.lblJenkins.Size = new System.Drawing.Size(38, 13);
            this.lblJenkins.TabIndex = 6;
            this.lblJenkins.Text = "Jenkin";
            // 
            // lblBuild
            // 
            this.lblBuild.AutoSize = true;
            this.lblBuild.Location = new System.Drawing.Point(6, 37);
            this.lblBuild.Name = "lblBuild";
            this.lblBuild.Size = new System.Drawing.Size(30, 13);
            this.lblBuild.TabIndex = 7;
            this.lblBuild.Text = "Build";
            // 
            // lblInstaller
            // 
            this.lblInstaller.AutoSize = true;
            this.lblInstaller.Location = new System.Drawing.Point(6, 24);
            this.lblInstaller.Name = "lblInstaller";
            this.lblInstaller.Size = new System.Drawing.Size(43, 13);
            this.lblInstaller.TabIndex = 8;
            this.lblInstaller.Text = "Installer";
            // 
            // DownloadCommandGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpInstaller);
            this.Controls.Add(this.grpBuild);
            this.Controls.Add(this.grpJenkin);
            this.MinimumSize = new System.Drawing.Size(240, 212);
            this.Name = "DownloadCommandGroup";
            this.Size = new System.Drawing.Size(240, 212);
            this.grpInstaller.ResumeLayout(false);
            this.grpInstaller.PerformLayout();
            this.grpBuild.ResumeLayout(false);
            this.grpBuild.PerformLayout();
            this.grpJenkin.ResumeLayout(false);
            this.grpJenkin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

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
        private System.Windows.Forms.ComboBox cmbReleaseUrls;
        private System.Windows.Forms.RadioButton rbReleaseBuild;
        private System.Windows.Forms.RadioButton rbBcBuild;
        private System.Windows.Forms.RadioButton rbMeBuild;
        private System.Windows.Forms.Label lblJenkins;
        private System.Windows.Forms.Label lblInstaller;
        private System.Windows.Forms.Label lblBuild;
    }
}
