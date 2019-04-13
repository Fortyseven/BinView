using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Binalysis
{
    public abstract partial class Parser : Control
    {
        protected MainForm Owner { get; private set; }
        protected Minimap Minimap { get; private set; }
        public byte[] Data { get; set; }

        protected abstract string Title { get; }

        protected TabPage Page { get; set; }
        protected Panel OptionsPanel { get; set; }
        protected Control CreatedControls { get; set; }

        public Parser( MainForm owner, Minimap minimap )
        {
            Owner = owner;
            Minimap = minimap;
            Data = Owner.Data;

            InitializeComponent();

            // content
            this.Name = Title;
            this.Dock = DockStyle.Fill;
            this.CreatedControls = Create();
            this.CreatedControls.Paint += PagePaint;
            this.Controls.Add( CreatedControls );
            this.DoubleBuffered = true;

            Page = new TabPage( Title );
            Page.Controls.Add( this );
            Page.Enter += Page_Enter;

            Owner.contentTabPanel.TabPages.Add( Page );
            Owner.contentTabPanel.Invalidate();

            // options
            OptionsPanel = new Panel();
            OptionsPanel.Dock = DockStyle.Fill;
            OptionsPanel.Controls.Add( BuildOptions() );

            ChangeTo();
        }

        public void ChangeTo()
        {
            Owner.SubTabPanel.TabPages[ 0 ].Controls.Clear();
            Owner.SubTabPanel.TabPages[ 0 ].Controls.Add( OptionsPanel );
            Owner.SubTabPanel.Invalidate();

            Owner.contentTabPanel.Invalidate();

            OnEnter();
            Invalidate();
        }

        private void Page_Enter( object sender, EventArgs e )
        {
            ChangeTo();
        }

        abstract public Control Create();

        abstract public Control BuildOptions();
        abstract public void UpdateOptions();

        abstract public void PagePaint( object sender, PaintEventArgs p );

        //abstract public void Destroy();

        abstract public void OnEnter();
        abstract public void OnLeave();

        abstract public void OnSelectionUpdated();

        public virtual void OnDataLoaded( byte[] data )
        {
            Data = data;
            OnSelectionUpdated();
        }
    }
}
