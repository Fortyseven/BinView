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
        protected Control CreatedOptionsPage { get; set; }

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
            CreatedOptionsPage = BuildOptions();
            if( CreatedOptionsPage != null ) {
                OptionsPanel = new Panel();
                OptionsPanel.Dock = DockStyle.Fill;
                OptionsPanel.Controls.Add( BuildOptions() );
            }

            Owner.SubTabPanel.TabPages[ 0 ].KeyDown += ( object sender, KeyEventArgs e ) => { };
            Owner.SubTabPanel.TabPages[ 0 ].PreviewKeyDown += ( object sender, PreviewKeyDownEventArgs e ) => { };
            Owner.SubTabPanel.TabPages[ 0 ].KeyPress += ( object sender, KeyPressEventArgs e ) => { };
            Owner.SubTabPanel.TabPages[ 0 ].KeyUp += ( object sender, KeyEventArgs e ) => { };

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

        public virtual Control BuildOptions()
        {
            return null;
        }

        public virtual void UpdateOptions()
        {
            Invalidate();
        }

        public virtual void PagePaint( object sender, PaintEventArgs p )
        {

        }

        public virtual void OnEnter()
        {

        }

        public virtual void OnLeave()
        {

        }

        public virtual void OnSelectionUpdated( long start, long end )
        {
            Invalidate();
        }

        public virtual void OnDataLoaded( byte[] data )
        {
            Data = data;
            OnSelectionUpdated( 0, Data.Length );
        }

        public virtual void OnMapClick( long offset )
        {
            Invalidate();
        }

        protected override void OnMouseMove( MouseEventArgs e )
        {
            Console.WriteLine( "What" );
            base.OnMouseMove( e );
        }
    }
}
