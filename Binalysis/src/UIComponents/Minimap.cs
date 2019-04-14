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
                //m_datadrawer_overview.Invalidate();

                m_datadrawer_mag.Data = value;
                m_datadrawer_mag.ResetSelection();
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

            Owner = owner;
            Dock = DockStyle.Fill;

            m_datadrawer_overview = new DataDrawer( this, ref m_data );
            m_datadrawer_mag = new DataDrawer( this, ref m_null_data, true );

            tableLayoutPanel1.Controls.Add( m_datadrawer_overview );
            tableLayoutPanel1.Controls.Add( m_datadrawer_mag );
        }

        /***************************************************************/
        public void AdjustSelectionStart( long amount )
        {
            if( !m_datadrawer_overview.HasSelection )
                return;

            var start = m_datadrawer_overview.SelectionOffsetStart;

            if(
                ( ( start + amount ) < m_datadrawer_overview.BoundStart ) ||
                ( ( start + amount ) >= m_datadrawer_overview.SelectionOffsetEnd - 1 )
              ) {
                return;
            }

            m_datadrawer_overview.SelectionOffsetStart += amount;

            OnSelectionMade( m_datadrawer_overview.SelectionOffsetStart, m_datadrawer_overview.SelectionOffsetEnd );
            Console.WriteLine( "Shifting top by..." + amount );
        }
        /***************************************************************/
        public void AdjustSelectionEnd( long amount )
        {
            if( !m_datadrawer_overview.HasSelection )
                return;

            var end = m_datadrawer_overview.SelectionOffsetEnd;

            if(
                ( ( end + amount ) > m_datadrawer_overview.BoundEnd ) ||
                ( ( end + amount ) <= m_datadrawer_overview.SelectionOffsetStart + 1 )
               ) {
                return;
            }

            m_datadrawer_overview.SelectionOffsetEnd += amount;

            OnSelectionMade( m_datadrawer_overview.SelectionOffsetStart, m_datadrawer_overview.SelectionOffsetEnd );
            Console.WriteLine( "Shifting bottom by..." + amount );
        }

        public void SetSelectionStart( long value )
        {
            if( value < 0 ) {
                value = 0;
            }
            if( value > 0 ) {
                m_datadrawer_overview.HasSelection = true;
            }

            m_datadrawer_overview.SelectionOffsetStart = value;
            //m_datadrawer_overview.Invalidate();

            OnSelectionMade( m_datadrawer_overview.SelectionOffsetStart, m_datadrawer_overview.SelectionOffsetEnd );
        }
        public void SetSelectionEnd( long value )
        {
            if( value > Data.Length ) {
                value = Data.Length;
            }

            if( value < Data.Length ) {
                m_datadrawer_overview.HasSelection = true;
            }


            m_datadrawer_overview.SelectionOffsetEnd = value;
            //m_datadrawer_overview.Invalidate();

            OnSelectionMade( m_datadrawer_overview.SelectionOffsetStart, m_datadrawer_overview.SelectionOffsetEnd );
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
            if( is_magview ) {
                m_datadrawer_overview.SelectionOffsetStart = start;
                m_datadrawer_overview.SelectionOffsetEnd = end;
                //m_datadrawer_overview.Invalidate();
            }
            else {
                m_datadrawer_mag.SetByteBounds( start, end );
                if( m_datadrawer_overview.HasSelection ) {
                    m_datadrawer_mag.Show();
                    m_datadrawer_mag.Invalidate();
                    m_datadrawer_overview.Invalidate();
                }
            }
            Owner.OnSelectionUpdated( start, end );
        }

        public void OnClearSelection()
        {
            m_datadrawer_overview.ResetSelection();
            m_datadrawer_mag.ResetSelection();
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

        internal void OnMapClick( long offset )
        {
            Owner.OnMapClick( offset );
        }
    }
}
