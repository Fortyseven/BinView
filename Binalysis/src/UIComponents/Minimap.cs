using System;
using System.Windows.Forms;

namespace Binalysis
{
    public partial class Minimap : UserControl
    {
        DataDrawer m_datadrawer_overview;
        DataDrawer m_datadrawer_mag;

        byte[] m_data = new byte[ 0 ] { };
        byte[] m_null_data = new byte[ 0 ] { };

        public byte[] Data {
            get {
                return m_data;
            }
            set {
                m_data = value;
                rebuildDrawers();
            }
        }

        public MainForm Owner { get; private set; }

        /***************************************************************/
        public long GetSelectedStartOff {
            get {
                if( !m_datadrawer_overview.HasSubSelection )
                    return 0;

                return m_datadrawer_overview.SelectionOffsetStartInBytes;
            }
        }
        public long GetSelectedEndOff {
            get {
                if( !m_datadrawer_overview.HasSubSelection )
                    return m_data.Length;

                return m_datadrawer_overview.IsDragging ?
                    m_datadrawer_overview.LastDragYInBytes :
                    m_datadrawer_overview.SelectionOffsetEndInBytes;
            }
        }

        /***************************************************************/
        public Minimap( MainForm owner )
        {
            InitializeComponent();
            this.Owner = owner;
            this.Dock = DockStyle.Fill;

            rebuildDrawers();
        }

        /***************************************************************/
        private void rebuildDrawers()
        {
            m_datadrawer_overview = new DataDrawer( this, ref m_data, overviewImg );
            m_datadrawer_mag = new DataDrawer( this, ref m_null_data, magImg );

            Invalidate();

            if( Parent != null ) {
                Parent.Invalidate();
            }
        }

        /***************************************************************/
        /***************************************************************/
        /***************************************************************/
        protected override void OnPaint( PaintEventArgs e )
        {
            if( Data == null )
                return;

            m_datadrawer_overview.Draw();

            if( m_datadrawer_mag != null ) {
                m_datadrawer_mag.Draw();
            }
        }

        /***************************************************************/
        public void onSelectionMade( long start, long end )
        {
            m_datadrawer_mag = new DataDrawer( this, ref m_data, magImg, start, end, true );
            Owner.OnSelectionUpdated();

            //Invalidate();
            //Parent.Invalidate();
        }

        /***************************************************************/
        public void onDeselect()
        {
            rebuildDrawers();
            magImg.Image = null;
        }
    }
}
