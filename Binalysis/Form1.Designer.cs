namespace Binalysis
{
    partial class MainForm
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
            this.BlockSizeBox = new System.Windows.Forms.TextBox();
            this.FullViewChk = new System.Windows.Forms.CheckBox();
            this.ScaleChk = new System.Windows.Forms.CheckBox();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.FingerprintImg = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.DataOverviewImg = new System.Windows.Forms.PictureBox();
            this.openFileDlg = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolPanel = new System.Windows.Forms.Panel();
            this.intensitySlider = new System.Windows.Forms.TrackBar();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.digramOffsetLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.digramValue = new System.Windows.Forms.ToolStripStatusLabel();
            this.contentPanel.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FingerprintImg)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataOverviewImg)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.toolPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.intensitySlider)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BlockSizeBox
            // 
            this.BlockSizeBox.AccessibleDescription = "";
            this.BlockSizeBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BlockSizeBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.BlockSizeBox.Location = new System.Drawing.Point(843, 6);
            this.BlockSizeBox.Name = "BlockSizeBox";
            this.BlockSizeBox.Size = new System.Drawing.Size(100, 23);
            this.BlockSizeBox.TabIndex = 4;
            this.BlockSizeBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.BlockSizeBox.Leave += new System.EventHandler(this.BlockSizeBox_Leave);
            // 
            // FullViewChk
            // 
            this.FullViewChk.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FullViewChk.AutoSize = true;
            this.FullViewChk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FullViewChk.Location = new System.Drawing.Point(197, 7);
            this.FullViewChk.Name = "FullViewChk";
            this.FullViewChk.Size = new System.Drawing.Size(107, 27);
            this.FullViewChk.TabIndex = 3;
            this.FullViewChk.Text = "Full Range";
            this.FullViewChk.UseVisualStyleBackColor = true;
            this.FullViewChk.CheckedChanged += new System.EventHandler(this.FullViewChk_CheckedChanged);
            // 
            // ScaleChk
            // 
            this.ScaleChk.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ScaleChk.AutoSize = true;
            this.ScaleChk.Checked = true;
            this.ScaleChk.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ScaleChk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ScaleChk.Location = new System.Drawing.Point(12, 7);
            this.ScaleChk.Name = "ScaleChk";
            this.ScaleChk.Size = new System.Drawing.Size(67, 27);
            this.ScaleChk.TabIndex = 1;
            this.ScaleChk.Text = "Scale";
            this.ScaleChk.UseVisualStyleBackColor = true;
            this.ScaleChk.CheckedChanged += new System.EventHandler(this.Scale_CheckedChanged);
            // 
            // contentPanel
            // 
            this.contentPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.contentPanel.Controls.Add(this.panel4);
            this.contentPanel.Controls.Add(this.panel3);
            this.contentPanel.Location = new System.Drawing.Point(3, 31);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(964, 756);
            this.contentPanel.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Black;
            this.panel4.Controls.Add(this.FingerprintImg);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(128, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(836, 756);
            this.panel4.TabIndex = 1;
            // 
            // FingerprintImg
            // 
            this.FingerprintImg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FingerprintImg.Location = new System.Drawing.Point(0, 0);
            this.FingerprintImg.Name = "FingerprintImg";
            this.FingerprintImg.Size = new System.Drawing.Size(836, 756);
            this.FingerprintImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.FingerprintImg.TabIndex = 0;
            this.FingerprintImg.TabStop = false;
            this.FingerprintImg.Paint += new System.Windows.Forms.PaintEventHandler(this.FingerprintImg_Paint);
            this.FingerprintImg.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FingerprintImg_MouseMove);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Navy;
            this.panel3.Controls.Add(this.DataOverviewImg);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(128, 756);
            this.panel3.TabIndex = 0;
            // 
            // DataOverviewImg
            // 
            this.DataOverviewImg.BackColor = System.Drawing.Color.MidnightBlue;
            this.DataOverviewImg.Cursor = System.Windows.Forms.Cursors.Cross;
            this.DataOverviewImg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataOverviewImg.Location = new System.Drawing.Point(0, 0);
            this.DataOverviewImg.Name = "DataOverviewImg";
            this.DataOverviewImg.Size = new System.Drawing.Size(128, 756);
            this.DataOverviewImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.DataOverviewImg.TabIndex = 0;
            this.DataOverviewImg.TabStop = false;
            this.DataOverviewImg.Click += new System.EventHandler(this.DataOverviewImg_Click);
            this.DataOverviewImg.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DataOverviewImg_MouseMove);
            // 
            // openFileDlg
            // 
            this.openFileDlg.FileName = "*.*";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(752, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 23);
            this.label1.TabIndex = 5;
            this.label1.Text = "Block Size";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(970, 28);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(173, 26);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(173, 26);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolPanel
            // 
            this.toolPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.toolPanel.Controls.Add(this.intensitySlider);
            this.toolPanel.Controls.Add(this.ScaleChk);
            this.toolPanel.Controls.Add(this.FullViewChk);
            this.toolPanel.Controls.Add(this.label1);
            this.toolPanel.Controls.Add(this.BlockSizeBox);
            this.toolPanel.Location = new System.Drawing.Point(0, 784);
            this.toolPanel.Name = "toolPanel";
            this.toolPanel.Size = new System.Drawing.Size(970, 35);
            this.toolPanel.TabIndex = 4;
            // 
            // intensitySlider
            // 
            this.intensitySlider.AccessibleDescription = "";
            this.intensitySlider.AccessibleName = "";
            this.intensitySlider.Location = new System.Drawing.Point(310, 6);
            this.intensitySlider.Maximum = 100;
            this.intensitySlider.Minimum = 1;
            this.intensitySlider.Name = "intensitySlider";
            this.intensitySlider.Size = new System.Drawing.Size(209, 56);
            this.intensitySlider.TabIndex = 8;
            this.intensitySlider.TickStyle = System.Windows.Forms.TickStyle.None;
            this.intensitySlider.Value = 1;
            this.intensitySlider.ValueChanged += new System.EventHandler(this.intensitySlider_ValueChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.digramOffsetLabel,
            this.toolStripStatusLabel2,
            this.digramValue});
            this.statusStrip1.Location = new System.Drawing.Point(0, 822);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(970, 25);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(62, 20);
            this.toolStripStatusLabel1.Text = "Digram:";
            // 
            // digramOffsetLabel
            // 
            this.digramOffsetLabel.Name = "digramOffsetLabel";
            this.digramOffsetLabel.Size = new System.Drawing.Size(28, 20);
            this.digramOffsetLabel.Text = "0,0";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(32, 20);
            this.toolStripStatusLabel2.Text = "Val:";
            // 
            // digramValue
            // 
            this.digramValue.Name = "digramValue";
            this.digramValue.Size = new System.Drawing.Size(21, 20);
            this.digramValue.Text = "--";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(970, 847);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.toolPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(640, 640);
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BinView";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MainForm_KeyPress);
            this.contentPanel.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FingerprintImg)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataOverviewImg)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolPanel.ResumeLayout(false);
            this.toolPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.intensitySlider)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.OpenFileDialog openFileDlg;
        private System.Windows.Forms.PictureBox FingerprintImg;
        private System.Windows.Forms.CheckBox ScaleChk;
        private System.Windows.Forms.PictureBox DataOverviewImg;
        private System.Windows.Forms.CheckBox FullViewChk;
        private System.Windows.Forms.TextBox BlockSizeBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.Panel toolPanel;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel digramOffsetLabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel digramValue;
        private System.Windows.Forms.TrackBar intensitySlider;
    }
}

