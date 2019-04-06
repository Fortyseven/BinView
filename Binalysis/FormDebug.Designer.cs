namespace Binalysis
{
    partial class FormDebug
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
            this.debugLogBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // debugLogBox
            // 
            this.debugLogBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.debugLogBox.Location = new System.Drawing.Point(0, 0);
            this.debugLogBox.Name = "debugLogBox";
            this.debugLogBox.ReadOnly = true;
            this.debugLogBox.Size = new System.Drawing.Size(391, 253);
            this.debugLogBox.TabIndex = 1;
            this.debugLogBox.Text = "";
            // 
            // FormDebug
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 253);
            this.Controls.Add(this.debugLogBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormDebug";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Data";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.RichTextBox debugLogBox;
    }
}