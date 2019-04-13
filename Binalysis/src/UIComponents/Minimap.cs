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
                m_datadrawer_overview.Data = value;
                m_datadrawer_overview.Invalidate();
                m_datadrawer_mag.Data = value;
                m_datadrawer_mag.ResetSelection();
                m_datadrawer_mag.Invalidate();
            }
        }

        public MainForm Owner { get; private set; }

        /***************************************************************/
        public long GetSelectedStartOff {
            get {
                if( !m_datadrawer_overview.HasSelection )
                    return 0;

                return m_datadrawer_overview.SelectionOffsetStart;
            }
        }
        public long GetSelectedEndOff {
            get {
                if( !m_datadrawer_overview.HasSelection )
                    return m_data.Length;

                return m_datadrawer_overview.IsDragging ?
                    m_datadrawer_overview.LastDragY : //FIXME
                    m_datadrawer_overview.SelectionOffsetEnd;
            }
        }

        /***************************************************************/
        public Minimap( MainForm owner )
        {
            InitializeComponent();
            this.Owner = owner;
            this.Dock = DockStyle.Fill;
            //this.DoubleBuffered = true;

            m_datadrawer_overview = new DataDrawer( this, ref m_data );
            m_datadrawer_mag = new DataDrawer( this, ref m_null_data, true );

            tableLayoutPanel1.Controls.Add( m_datadrawer_overview );
            tableLayoutPanel1.Controls.Add( m_datadrawer_mag );

            //this.KeyDown += Minimap_KeyDown;
        }

        //private void Minimap_KeyDown( object sender, KeyEventArgs e )
        //{
        //    switch( e.KeyCode ) {
        //        // ]
        //        case Keys.OemCloseBrackets:
        //            m_datadrawer_overview.SetWidthRel( 1 );
        //            break;
        //        // [
        //        case Keys.OemOpenBrackets:
        //            m_datadrawer_overview.SetWidthRel( -1 );
        //            break;
        //    }
        //}

        /***************************************************************/
        //public int GetWidth()
        //{
        //    return m_datadrawer_overview.WIDTH;
        //}
        /***************************************************************/
        //public void SetWidth( int width )
        //{
        //    if( width < 0 )
        //        width = 0;
        //    if( width > 2048 )
        //        width = 2048;

        //    m_datadrawer_overview.WIDTH = width;
        //    //m_datadrawer_overview.RefreshTempName();
        //}
        /***************************************************************/
        public void SetBoundStart( long byte_offset )
        {
            //m_datadrawer_overview.SelectionOffsetStart
        }
        /***************************************************************/
        public void SetBoundEnd( long byte_offset )
        {
            //
        }
        /***************************************************************/
        private void UpdateStatus()
        {
            //Owner.Width
            //Owner.startValue
        }
        /***************************************************************/
        /***************************************************************/
        /***************************************************************/
        public void OnSelectionMade( long start, long end, bool is_magview = false )
        {
            Owner.OnSelectionUpdated();

            m_datadrawer_mag.SetByteBounds( start, end );

            if( is_magview ) {
                m_datadrawer_overview.SelectionOffsetStart = start;
                m_datadrawer_overview.SelectionOffsetEnd = end;
                m_datadrawer_overview.Invalidate();
            }
        }

        public void OnClearSelection()
        {
            m_datadrawer_overview.ResetSelection();
            m_datadrawer_mag.NoSelection();
        }

        public void OnResizeEnd( EventArgs e )
        {
            m_datadrawer_overview.OnResizeEnd( e );
            m_datadrawer_mag.OnResizeEnd( e );
        }

        public void OnDeselect()
        {
            m_datadrawer_overview.ResetSelection();
            m_datadrawer_mag.ResetSelection();
            Owner.OnDeselect();
        }
    }
}
