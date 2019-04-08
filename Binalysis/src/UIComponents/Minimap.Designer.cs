namespace Binalysis
{
    partial class Minimap
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if( disposing && ( components != null ) ) {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.overviewImg = new System.Windows.Forms.PictureBox();
            this.magImg = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.overviewImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.magImg)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Black;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.overviewImg, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.magImg, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(140, 311);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // overviewImg
            // 
            this.overviewImg.Cursor = System.Windows.Forms.Cursors.Cross;
            this.overviewImg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.overviewImg.Location = new System.Drawing.Point(0, 0);
            this.overviewImg.Margin = new System.Windows.Forms.Padding(0);
            this.overviewImg.Name = "overviewImg";
            this.overviewImg.Size = new System.Drawing.Size(70, 311);
            this.overviewImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.overviewImg.TabIndex = 0;
            this.overviewImg.TabStop = false;
            // 
            // magImg
            // 
            this.magImg.Cursor = System.Windows.Forms.Cursors.Cross;
            this.magImg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.magImg.Location = new System.Drawing.Point(70, 0);
            this.magImg.Margin = new System.Windows.Forms.Padding(0);
            this.magImg.Name = "magImg";
            this.magImg.Size = new System.Drawing.Size(70, 311);
            this.magImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.magImg.TabIndex = 1;
            this.magImg.TabStop = false;
            // 
            // Minimap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "Minimap";
            this.Size = new System.Drawing.Size(140, 311);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.overviewImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.magImg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox overviewImg;
        private System.Windows.Forms.PictureBox magImg;
    }
}
