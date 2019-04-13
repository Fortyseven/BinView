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
        protected override void Dispose( bool disposing )
        {
            if( disposing && ( components != null ) ) {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            this.mapPanel = new System.Windows.Forms.Panel();
            this.openFileDlg = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.outerContainer = new System.Windows.Forms.SplitContainer();
            this.rightContainer = new System.Windows.Forms.SplitContainer();
            this.contentTabPanel = new System.Windows.Forms.TabControl();
            this.SubTabPanel = new System.Windows.Forms.TabControl();
            this.optionsPage = new System.Windows.Forms.TabPage();
            this.debugPage = new System.Windows.Forms.TabPage();
            this.debugLogBox = new System.Windows.Forms.RichTextBox();
            this.selectionStartValue = new System.Windows.Forms.NumericUpDown();
            this.selectionEndValue = new System.Windows.Forms.NumericUpDown();
            this.widthValue = new System.Windows.Forms.NumericUpDown();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ( (System.ComponentModel.ISupportInitialize)( this.outerContainer ) ).BeginInit();
            this.outerContainer.Panel1.SuspendLayout();
            this.outerContainer.Panel2.SuspendLayout();
            this.outerContainer.SuspendLayout();
            ( (System.ComponentModel.ISupportInitialize)( this.rightContainer ) ).BeginInit();
            this.rightContainer.Panel1.SuspendLayout();
            this.rightContainer.Panel2.SuspendLayout();
            this.rightContainer.SuspendLayout();
            this.SubTabPanel.SuspendLayout();
            this.debugPage.SuspendLayout();
            ( (System.ComponentModel.ISupportInitialize)( this.selectionStartValue ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.selectionEndValue ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.widthValue ) ).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            label2.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left ) ) );
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font( "Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
            label2.Location = new System.Drawing.Point( 2, 823 );
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size( 41, 20 );
            label2.TabIndex = 9;
            label2.Text = "Start";
            // 
            // label3
            // 
            label3.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left ) ) );
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font( "Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
            label3.Location = new System.Drawing.Point( 170, 823 );
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size( 35, 20 );
            label3.TabIndex = 10;
            label3.Text = "End";
            // 
            // label4
            // 
            label4.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left ) ) );
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font( "Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
            label4.Location = new System.Drawing.Point( 335, 823 );
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size( 50, 20 );
            label4.TabIndex = 11;
            label4.Text = "Width";
            // 
            // mapPanel
            // 
            this.mapPanel.BackColor = System.Drawing.Color.Navy;
            this.mapPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapPanel.Location = new System.Drawing.Point( 0, 0 );
            this.mapPanel.Margin = new System.Windows.Forms.Padding( 2 );
            this.mapPanel.Name = "mapPanel";
            this.mapPanel.Size = new System.Drawing.Size( 254, 783 );
            this.mapPanel.TabIndex = 0;
            // 
            // openFileDlg
            // 
            this.openFileDlg.FileName = "*.*";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size( 20, 20 );
            this.menuStrip1.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem} );
            this.menuStrip1.Location = new System.Drawing.Point( 0, 0 );
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size( 1107, 28 );
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.exitToolStripMenuItem} );
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size( 44, 24 );
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ( (System.Windows.Forms.Keys)( ( System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O ) ) );
            this.openToolStripMenuItem.Size = new System.Drawing.Size( 173, 26 );
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler( this.openToolStripMenuItem_Click );
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.exitToolStripMenuItem.ShortcutKeys = ( (System.Windows.Forms.Keys)( ( System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4 ) ) );
            this.exitToolStripMenuItem.Size = new System.Drawing.Size( 173, 26 );
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler( this.exitToolStripMenuItem_Click );
            // 
            // statusStrip1
            // 
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size( 20, 20 );
            this.statusStrip1.Location = new System.Drawing.Point( 0, 818 );
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip1.Size = new System.Drawing.Size( 1107, 30 );
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // outerContainer
            // 
            this.outerContainer.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
            | System.Windows.Forms.AnchorStyles.Left )
            | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.outerContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.outerContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.outerContainer.IsSplitterFixed = true;
            this.outerContainer.Location = new System.Drawing.Point( 0, 31 );
            this.outerContainer.Margin = new System.Windows.Forms.Padding( 2 );
            this.outerContainer.Name = "outerContainer";
            // 
            // outerContainer.Panel1
            // 
            this.outerContainer.Panel1.Controls.Add( this.mapPanel );
            this.outerContainer.Panel1MinSize = 256;
            // 
            // outerContainer.Panel2
            // 
            this.outerContainer.Panel2.Controls.Add( this.rightContainer );
            this.outerContainer.Size = new System.Drawing.Size( 1107, 785 );
            this.outerContainer.SplitterDistance = 256;
            this.outerContainer.SplitterWidth = 2;
            this.outerContainer.TabIndex = 0;
            // 
            // rightContainer
            // 
            this.rightContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rightContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rightContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.rightContainer.Location = new System.Drawing.Point( 0, 0 );
            this.rightContainer.Margin = new System.Windows.Forms.Padding( 2 );
            this.rightContainer.Name = "rightContainer";
            this.rightContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // rightContainer.Panel1
            // 
            this.rightContainer.Panel1.Controls.Add( this.contentTabPanel );
            // 
            // rightContainer.Panel2
            // 
            this.rightContainer.Panel2.Controls.Add( this.SubTabPanel );
            this.rightContainer.Size = new System.Drawing.Size( 849, 785 );
            this.rightContainer.SplitterDistance = 704;
            this.rightContainer.SplitterWidth = 2;
            this.rightContainer.TabIndex = 1;
            // 
            // contentTabPanel
            // 
            this.contentTabPanel.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.contentTabPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentTabPanel.Font = new System.Drawing.Font( "Segoe UI Semibold", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
            this.contentTabPanel.HotTrack = true;
            this.contentTabPanel.Location = new System.Drawing.Point( 0, 0 );
            this.contentTabPanel.Multiline = true;
            this.contentTabPanel.Name = "contentTabPanel";
            this.contentTabPanel.SelectedIndex = 0;
            this.contentTabPanel.ShowToolTips = true;
            this.contentTabPanel.Size = new System.Drawing.Size( 847, 702 );
            this.contentTabPanel.TabIndex = 0;
            // 
            // SubTabPanel
            // 
            this.SubTabPanel.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.SubTabPanel.Controls.Add( this.optionsPage );
            this.SubTabPanel.Controls.Add( this.debugPage );
            this.SubTabPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SubTabPanel.Font = new System.Drawing.Font( "Segoe UI Semibold", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
            this.SubTabPanel.Location = new System.Drawing.Point( 0, 0 );
            this.SubTabPanel.Margin = new System.Windows.Forms.Padding( 0 );
            this.SubTabPanel.Name = "SubTabPanel";
            this.SubTabPanel.Padding = new System.Drawing.Point( 0, 0 );
            this.SubTabPanel.SelectedIndex = 0;
            this.SubTabPanel.Size = new System.Drawing.Size( 847, 77 );
            this.SubTabPanel.TabIndex = 1;
            // 
            // optionsPage
            // 
            this.optionsPage.Location = new System.Drawing.Point( 4, 4 );
            this.optionsPage.Name = "optionsPage";
            this.optionsPage.Padding = new System.Windows.Forms.Padding( 3 );
            this.optionsPage.Size = new System.Drawing.Size( 839, 52 );
            this.optionsPage.TabIndex = 0;
            this.optionsPage.Text = "View Options";
            this.optionsPage.UseVisualStyleBackColor = true;
            // 
            // debugPage
            // 
            this.debugPage.Controls.Add( this.debugLogBox );
            this.debugPage.Location = new System.Drawing.Point( 4, 4 );
            this.debugPage.Margin = new System.Windows.Forms.Padding( 0 );
            this.debugPage.Name = "debugPage";
            this.debugPage.Size = new System.Drawing.Size( 837, 52 );
            this.debugPage.TabIndex = 1;
            this.debugPage.Text = "Debug";
            this.debugPage.UseVisualStyleBackColor = true;
            // 
            // debugLogBox
            // 
            this.debugLogBox.BackColor = System.Drawing.Color.Black;
            this.debugLogBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.debugLogBox.Font = new System.Drawing.Font( "Consolas", 8F );
            this.debugLogBox.ForeColor = System.Drawing.Color.GreenYellow;
            this.debugLogBox.Location = new System.Drawing.Point( 0, 0 );
            this.debugLogBox.Margin = new System.Windows.Forms.Padding( 0 );
            this.debugLogBox.Name = "debugLogBox";
            this.debugLogBox.ReadOnly = true;
            this.debugLogBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.debugLogBox.Size = new System.Drawing.Size( 837, 52 );
            this.debugLogBox.TabIndex = 0;
            this.debugLogBox.Text = "";
            // 
            // selectionStartValue
            // 
            this.selectionStartValue.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left ) ) );
            this.selectionStartValue.Font = new System.Drawing.Font( "Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
            this.selectionStartValue.Location = new System.Drawing.Point( 46, 821 );
            this.selectionStartValue.Margin = new System.Windows.Forms.Padding( 0 );
            this.selectionStartValue.Maximum = new decimal( new int[] {
            1410065407,
            2,
            0,
            0} );
            this.selectionStartValue.Name = "selectionStartValue";
            this.selectionStartValue.Size = new System.Drawing.Size( 120, 25 );
            this.selectionStartValue.TabIndex = 7;
            // 
            // selectionEndValue
            // 
            this.selectionEndValue.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left ) ) );
            this.selectionEndValue.Font = new System.Drawing.Font( "Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
            this.selectionEndValue.Location = new System.Drawing.Point( 209, 821 );
            this.selectionEndValue.Margin = new System.Windows.Forms.Padding( 0 );
            this.selectionEndValue.Maximum = new decimal( new int[] {
            1410065407,
            2,
            0,
            0} );
            this.selectionEndValue.Name = "selectionEndValue";
            this.selectionEndValue.Size = new System.Drawing.Size( 120, 25 );
            this.selectionEndValue.TabIndex = 8;
            // 
            // widthValue
            // 
            this.widthValue.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left ) ) );
            this.widthValue.Font = new System.Drawing.Font( "Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
            this.widthValue.Location = new System.Drawing.Point( 388, 821 );
            this.widthValue.Margin = new System.Windows.Forms.Padding( 0 );
            this.widthValue.Maximum = new decimal( new int[] {
            1410065407,
            2,
            0,
            0} );
            this.widthValue.Name = "widthValue";
            this.widthValue.Size = new System.Drawing.Size( 77, 25 );
            this.widthValue.TabIndex = 12;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 120F, 120F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size( 1107, 848 );
            this.Controls.Add( this.widthValue );
            this.Controls.Add( label4 );
            this.Controls.Add( label3 );
            this.Controls.Add( label2 );
            this.Controls.Add( this.selectionEndValue );
            this.Controls.Add( this.selectionStartValue );
            this.Controls.Add( this.outerContainer );
            this.Controls.Add( this.statusStrip1 );
            this.Controls.Add( this.menuStrip1 );
            this.Font = new System.Drawing.Font( "Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding( 2 );
            this.MinimumSize = new System.Drawing.Size( 639, 638 );
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BinView";
            this.Load += new System.EventHandler( this.MainForm_Load );
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler( this.MainForm_KeyPress );
            this.menuStrip1.ResumeLayout( false );
            this.menuStrip1.PerformLayout();
            this.outerContainer.Panel1.ResumeLayout( false );
            this.outerContainer.Panel2.ResumeLayout( false );
            ( (System.ComponentModel.ISupportInitialize)( this.outerContainer ) ).EndInit();
            this.outerContainer.ResumeLayout( false );
            this.rightContainer.Panel1.ResumeLayout( false );
            this.rightContainer.Panel2.ResumeLayout( false );
            ( (System.ComponentModel.ISupportInitialize)( this.rightContainer ) ).EndInit();
            this.rightContainer.ResumeLayout( false );
            this.SubTabPanel.ResumeLayout( false );
            this.debugPage.ResumeLayout( false );
            ( (System.ComponentModel.ISupportInitialize)( this.selectionStartValue ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.selectionEndValue ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.widthValue ) ).EndInit();
            this.ResumeLayout( false );
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel mapPanel;
        private System.Windows.Forms.OpenFileDialog openFileDlg;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer outerContainer;
        private System.Windows.Forms.SplitContainer rightContainer;
        private System.Windows.Forms.RichTextBox debugLogBox;
        public System.Windows.Forms.TabControl contentTabPanel;
        private System.Windows.Forms.TabPage debugPage;
        private System.Windows.Forms.TabPage optionsPage;
        public System.Windows.Forms.TabControl SubTabPanel;
        public System.Windows.Forms.NumericUpDown selectionStartValue;
        public System.Windows.Forms.NumericUpDown selectionEndValue;
        public System.Windows.Forms.NumericUpDown widthValue;
    }
}

