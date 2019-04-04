namespace BinView1
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
            this.NormalizeChk = new System.Windows.Forms.CheckBox();
            this.ScaleChk = new System.Windows.Forms.CheckBox();
            this.OpenBtn = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.DataPictureBox = new System.Windows.Forms.PictureBox();
            this.openFileDlg = new System.Windows.Forms.OpenFileDialog();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataPictureBox)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BlockSizeBox
            // 
            this.BlockSizeBox.AccessibleDescription = "";
            this.BlockSizeBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BlockSizeBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BlockSizeBox.Location = new System.Drawing.Point(358, 3);
            this.BlockSizeBox.Name = "BlockSizeBox";
            this.BlockSizeBox.Size = new System.Drawing.Size(100, 27);
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
            this.FullViewChk.Location = new System.Drawing.Point(266, 3);
            this.FullViewChk.Name = "FullViewChk";
            this.FullViewChk.Size = new System.Drawing.Size(86, 28);
            this.FullViewChk.TabIndex = 3;
            this.FullViewChk.Text = "Full View";
            this.FullViewChk.UseVisualStyleBackColor = true;
            this.FullViewChk.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // NormalizeChk
            // 
            this.NormalizeChk.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NormalizeChk.AutoSize = true;
            this.NormalizeChk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NormalizeChk.Location = new System.Drawing.Point(96, 3);
            this.NormalizeChk.Name = "NormalizeChk";
            this.NormalizeChk.Size = new System.Drawing.Size(96, 28);
            this.NormalizeChk.TabIndex = 2;
            this.NormalizeChk.Text = "Normalize";
            this.NormalizeChk.UseVisualStyleBackColor = true;
            this.NormalizeChk.CheckedChanged += new System.EventHandler(this.NormalizeChk_CheckedChanged);
            // 
            // ScaleChk
            // 
            this.ScaleChk.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ScaleChk.AutoSize = true;
            this.ScaleChk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ScaleChk.Location = new System.Drawing.Point(198, 3);
            this.ScaleChk.Name = "ScaleChk";
            this.ScaleChk.Size = new System.Drawing.Size(62, 28);
            this.ScaleChk.TabIndex = 1;
            this.ScaleChk.Text = "Scale";
            this.ScaleChk.UseVisualStyleBackColor = true;
            this.ScaleChk.CheckedChanged += new System.EventHandler(this.Scale_CheckedChanged);
            // 
            // OpenBtn
            // 
            this.OpenBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OpenBtn.Location = new System.Drawing.Point(3, 3);
            this.OpenBtn.Name = "OpenBtn";
            this.OpenBtn.Size = new System.Drawing.Size(87, 28);
            this.OpenBtn.TabIndex = 0;
            this.OpenBtn.Text = "Open File";
            this.OpenBtn.UseVisualStyleBackColor = true;
            this.OpenBtn.Click += new System.EventHandler(this.OpenBtn_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(697, 502);
            this.panel2.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Black;
            this.panel4.Controls.Add(this.pictureBox1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(128, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(569, 502);
            this.panel4.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(569, 502);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Navy;
            this.panel3.Controls.Add(this.DataPictureBox);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(128, 502);
            this.panel3.TabIndex = 0;
            // 
            // DataPictureBox
            // 
            this.DataPictureBox.BackColor = System.Drawing.Color.MidnightBlue;
            this.DataPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataPictureBox.Location = new System.Drawing.Point(0, 0);
            this.DataPictureBox.Name = "DataPictureBox";
            this.DataPictureBox.Size = new System.Drawing.Size(128, 502);
            this.DataPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.DataPictureBox.TabIndex = 0;
            this.DataPictureBox.TabStop = false;
            this.DataPictureBox.Click += new System.EventHandler(this.DataPictureBox_Click);
            this.DataPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DataPictureBox_MouseDown);
            this.DataPictureBox.MouseHover += new System.EventHandler(this.DataPictureBox_MouseHover);
            this.DataPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DataPictureBox_MouseMove);
            // 
            // openFileDlg
            // 
            this.openFileDlg.FileName = "*.*";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Controls.Add(this.OpenBtn);
            this.flowLayoutPanel1.Controls.Add(this.NormalizeChk);
            this.flowLayoutPanel1.Controls.Add(this.ScaleChk);
            this.flowLayoutPanel1.Controls.Add(this.FullViewChk);
            this.flowLayoutPanel1.Controls.Add(this.BlockSizeBox);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(697, 36);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(697, 502);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panel2);
            this.Name = "MainForm";
            this.Text = "BinView";
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataPictureBox)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button OpenBtn;
        private System.Windows.Forms.OpenFileDialog openFileDlg;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox ScaleChk;
        private System.Windows.Forms.CheckBox NormalizeChk;
        private System.Windows.Forms.PictureBox DataPictureBox;
        private System.Windows.Forms.CheckBox FullViewChk;
        private System.Windows.Forms.TextBox BlockSizeBox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}

