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
    public abstract partial class Parser : UserControl
    {
        protected MainForm Owner { get; private set; }
        protected Minimap Minimap { get; private set; }
        protected byte[] Data { get; private set; }

        protected abstract string Title { get; }

        protected TabPage Page { get; set; }
        protected Panel OptionsPanel { get; set; }

        public Parser( MainForm owner, Minimap minimap )
        {
            Owner = owner;
            Minimap = minimap;
            Data = Owner.Data;

            this.Dock = DockStyle.Fill;

            InitializeComponent();

            this.Name = Title;
            this.Controls.Add( Create() );

            Page = new TabPage( Title );
            Page.Controls.Add( this );
            Page.Paint += Update;
            Owner.contentTabPanel.TabPages.Add( Page );
            Owner.contentTabPanel.Invalidate();

            Page.Enter += Page_Enter;

            OptionsPanel = new Panel();
            OptionsPanel.Dock = DockStyle.Fill;
            OptionsPanel.Controls.Add( BuildOptions() );

            Focus();

            Update();
        }

        private void Page_Enter( object sender, EventArgs e )
        {
            // Insert our settings into the settings panel
            Focus();
        }

        public void Focus()
        {
            Owner.SubTabPanel.TabPages[ 0 ].Controls.Clear();
            Owner.SubTabPanel.TabPages[ 0 ].Controls.Add( OptionsPanel );
            Invalidate();
            Owner.contentTabPanel.Invalidate();
        }

        abstract public Control Create();

        abstract public Control BuildOptions();
        abstract public void UpdateOptions();

        abstract public void Update( object sender, PaintEventArgs p );

        abstract public void Destroy();

        abstract public void OnEnter();
        abstract public void OnLeave();

        abstract public void OnSelectionUpdated();

        public virtual void OnDataLoaded( byte[] data )
        {
            Data = data;
        }
    }
}
