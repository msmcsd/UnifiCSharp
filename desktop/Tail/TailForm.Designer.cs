
namespace Tail
{
    partial class TailForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TailForm));
            this.txtOutput = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblErrorCount = new System.Windows.Forms.Label();
            this.chkFollowTail = new System.Windows.Forms.CheckBox();
            this.btnNextError = new System.Windows.Forms.Button();
            this.btnPrevError = new System.Windows.Forms.Button();
            this.grpFileInfo = new System.Windows.Forms.GroupBox();
            this.lblFileNotFound = new System.Windows.Forms.Label();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.lblFile = new System.Windows.Forms.Label();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.lblEnterFilter = new System.Windows.Forms.Label();
            this.lblFilter = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.grpFileInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtOutput
            // 
            this.txtOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtOutput.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOutput.Location = new System.Drawing.Point(0, 64);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.txtOutput.Size = new System.Drawing.Size(1304, 672);
            this.txtOutput.TabIndex = 0;
            this.txtOutput.Text = "";
            this.txtOutput.WordWrap = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblErrorCount);
            this.panel1.Controls.Add(this.chkFollowTail);
            this.panel1.Controls.Add(this.btnNextError);
            this.panel1.Controls.Add(this.btnPrevError);
            this.panel1.Controls.Add(this.grpFileInfo);
            this.panel1.Controls.Add(this.btnStart);
            this.panel1.Controls.Add(this.btnStop);
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1304, 64);
            this.panel1.TabIndex = 1;
            // 
            // lblErrorCount
            // 
            this.lblErrorCount.AutoSize = true;
            this.lblErrorCount.Location = new System.Drawing.Point(432, 25);
            this.lblErrorCount.Name = "lblErrorCount";
            this.lblErrorCount.Size = new System.Drawing.Size(38, 13);
            this.lblErrorCount.TabIndex = 11;
            this.lblErrorCount.Text = "0 Error";
            // 
            // chkFollowTail
            // 
            this.chkFollowTail.AutoSize = true;
            this.chkFollowTail.Checked = true;
            this.chkFollowTail.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFollowTail.Location = new System.Drawing.Point(190, 25);
            this.chkFollowTail.Name = "chkFollowTail";
            this.chkFollowTail.Size = new System.Drawing.Size(43, 17);
            this.chkFollowTail.TabIndex = 10;
            this.chkFollowTail.Text = "Tail";
            this.chkFollowTail.UseVisualStyleBackColor = true;
            // 
            // btnNextError
            // 
            this.btnNextError.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnNextError.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNextError.BackgroundImage")));
            this.btnNextError.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnNextError.Location = new System.Drawing.Point(367, 8);
            this.btnNextError.Name = "btnNextError";
            this.btnNextError.Size = new System.Drawing.Size(48, 48);
            this.btnNextError.TabIndex = 9;
            this.btnNextError.UseVisualStyleBackColor = true;
            this.btnNextError.Click += new System.EventHandler(this.btnNextError_Click);
            // 
            // btnPrevError
            // 
            this.btnPrevError.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnPrevError.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPrevError.BackgroundImage")));
            this.btnPrevError.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPrevError.Location = new System.Drawing.Point(313, 8);
            this.btnPrevError.Name = "btnPrevError";
            this.btnPrevError.Size = new System.Drawing.Size(48, 48);
            this.btnPrevError.TabIndex = 8;
            this.btnPrevError.UseVisualStyleBackColor = true;
            this.btnPrevError.Click += new System.EventHandler(this.btnPrevError_Click);
            // 
            // grpFileInfo
            // 
            this.grpFileInfo.Controls.Add(this.lblFileNotFound);
            this.grpFileInfo.Controls.Add(this.txtFile);
            this.grpFileInfo.Controls.Add(this.lblFile);
            this.grpFileInfo.Controls.Add(this.txtFilter);
            this.grpFileInfo.Controls.Add(this.lblEnterFilter);
            this.grpFileInfo.Controls.Add(this.lblFilter);
            this.grpFileInfo.Location = new System.Drawing.Point(643, 3);
            this.grpFileInfo.Name = "grpFileInfo";
            this.grpFileInfo.Size = new System.Drawing.Size(649, 55);
            this.grpFileInfo.TabIndex = 7;
            this.grpFileInfo.TabStop = false;
            // 
            // lblFileNotFound
            // 
            this.lblFileNotFound.AutoSize = true;
            this.lblFileNotFound.ForeColor = System.Drawing.Color.Red;
            this.lblFileNotFound.Location = new System.Drawing.Point(392, 10);
            this.lblFileNotFound.Name = "lblFileNotFound";
            this.lblFileNotFound.Size = new System.Drawing.Size(71, 13);
            this.lblFileNotFound.TabIndex = 8;
            this.lblFileNotFound.Text = "File not found";
            this.lblFileNotFound.Visible = false;
            // 
            // txtFile
            // 
            this.txtFile.Location = new System.Drawing.Point(83, 7);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(303, 20);
            this.txtFile.TabIndex = 7;
            this.txtFile.TextChanged += new System.EventHandler(this.txtFile_TextChanged);
            // 
            // lblFile
            // 
            this.lblFile.AutoSize = true;
            this.lblFile.Location = new System.Drawing.Point(6, 9);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(71, 13);
            this.lblFile.TabIndex = 6;
            this.lblFile.Text = "Tracking File:";
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(83, 29);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(219, 20);
            this.txtFilter.TabIndex = 3;
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // lblEnterFilter
            // 
            this.lblEnterFilter.AutoSize = true;
            this.lblEnterFilter.ForeColor = System.Drawing.Color.Red;
            this.lblEnterFilter.Location = new System.Drawing.Point(308, 32);
            this.lblEnterFilter.Name = "lblEnterFilter";
            this.lblEnterFilter.Size = new System.Drawing.Size(54, 13);
            this.lblEnterFilter.TabIndex = 5;
            this.lblEnterFilter.Text = "Enter filter";
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Location = new System.Drawing.Point(6, 30);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(32, 13);
            this.lblFilter.TabIndex = 4;
            this.lblFilter.Text = "Filter:";
            // 
            // btnStart
            // 
            this.btnStart.Image = ((System.Drawing.Image)(resources.GetObject("btnStart.Image")));
            this.btnStart.Location = new System.Drawing.Point(125, 8);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(48, 48);
            this.btnStart.TabIndex = 2;
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Image = ((System.Drawing.Image)(resources.GetObject("btnStop.Image")));
            this.btnStop.Location = new System.Drawing.Point(71, 8);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(48, 48);
            this.btnStop.TabIndex = 1;
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClear.BackgroundImage")));
            this.btnClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClear.Location = new System.Drawing.Point(3, 8);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(48, 48);
            this.btnClear.TabIndex = 0;
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // TailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1304, 736);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TailForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Tail";
            this.Shown += new System.EventHandler(this.TailForm_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.grpFileInfo.ResumeLayout(false);
            this.grpFileInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtOutput;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.Label lblEnterFilter;
        private System.Windows.Forms.Label lblFile;
        private System.Windows.Forms.GroupBox grpFileInfo;
        private System.Windows.Forms.Button btnNextError;
        private System.Windows.Forms.Button btnPrevError;
        private System.Windows.Forms.CheckBox chkFollowTail;
        private System.Windows.Forms.Label lblErrorCount;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Label lblFileNotFound;
    }
}

