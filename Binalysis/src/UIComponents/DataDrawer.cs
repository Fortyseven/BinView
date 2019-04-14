using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Binalysis
{
    class DataDrawer : UserControl
    {
        const int WIDTH = 128;
        const int PIXEL_SIZE = 4;

        private byte[] m_data;
        public byte[] Data {
            get {
                return m_data;
            }
            set {
                m_data = value;
                SetByteBounds( 0, m_data.Length );
            }
        }

        public Minimap Owner { get; set; } = null;

        public long RenderedHeight { get; set; }
        public bool Debug { get; set; }

        private long Stride { get; set; }

        /// <summary>
        /// Selection cusror in bytes
        /// </summary>
        public long LastDragY = 0;

        public bool IsDragging = false;

        private Bitmap m_backing_render = null;
        private Bitmap m_cached_render_final = new Bitmap( 1, 1 );

        public bool HasSelection { get; set; }
        public long SelectionOffsetStart { get; set; }
        public long SelectionOffsetEnd { get; set; }


        public long BoundStart { get; set; }
        public long BoundEnd { get; set; }
        public long BoundLength {
            get {
                return BoundEnd - BoundStart;
            }
        }

        bool IsMagView { get; set; }
        long CursorLastAt { get; set; } = -1;
        ToolTip offsetTip;

        /**********************************************/
        public DataDrawer( Minimap owner, ref byte[] data, bool is_magview = false )
        {
            Data = data;
            Owner = owner;
            Dock = DockStyle.Fill;
            DoubleBuffered = true;
            Cursor = Cursors.Cross;
            IsMagView = is_magview;

            // Create the tooltip that shows the offset at the cursor
            offsetTip = new ToolTip();
            offsetTip.AutomaticDelay = 0;
            offsetTip.AutoPopDelay = 0;

            ResetSelection();
        }

        /// <summary>
        /// Sets the virtual data boundaries to display in the view; this represents 
        /// a subset of the full data set. It's used only by a mag view.
        /// </summary>
        /// <param name="bound_start">Starting boundary in bytes</param>
        /// <param name="bound_end">Ending boundary in bytes</param>
        public void SetByteBounds( long bound_start, long bound_end )
        {
            CursorLastAt = -1;
            BoundStart = bound_start;
            BoundEnd = bound_end;

            if( BoundStart > BoundEnd ) {
                var temp = BoundEnd;
                BoundEnd = BoundStart;
                BoundStart = temp;
            }

            if( BoundStart == -1 ) {
                BoundStart = 0;
            }

            if( BoundEnd == -1 || BoundEnd > Data.Length ) {
                BoundEnd = Data.Length;
            }

            if( BoundStart == BoundEnd ) {
                BoundStart = 0;
                BoundEnd = Data.Length;
            }

            redrawBacking();
        }

        /**********************************************/
        public void ResetSelection()
        {
            HasSelection = false;
            SelectionOffsetStart = BoundStart;
            SelectionOffsetEnd = BoundEnd;
            CursorLastAt = -1;
            if( IsMagView ) {
                Hide();
                return;
            }
            redrawBacking();
        }

        /**********************************************/
        public void redrawBacking()
        {
            if( Data.Length == 0 )
                return;

            RenderedHeight = (int)Math.Ceiling( ( (float)( BoundLength ) / (float)( WIDTH ) ) / PIXEL_SIZE );

            if( RenderedHeight < 1 )
                RenderedHeight = 1;

            m_backing_render = new Bitmap( WIDTH, (int)RenderedHeight, PixelFormat.Format32bppRgb );

            Rectangle dims = new Rectangle( 0, 0, WIDTH, (int)RenderedHeight );

            BitmapData picData = m_backing_render.LockBits( dims, ImageLockMode.ReadWrite, m_backing_render.PixelFormat );

            IntPtr pixelStart = picData.Scan0;

            System.Runtime.InteropServices.Marshal.Copy( Data, (int)BoundStart, pixelStart, (int)BoundLength );

            m_backing_render.UnlockBits( picData );
        }

        int c = 0;
        /**********************************************/
        private void renderSelection( Graphics gr )
        {
            if( RenderedHeight == 0 )
                return;

            var selection_start_y = ByteOffsetToControlOffset( SelectionOffsetStart );
            var selection_end_y = ByteOffsetToControlOffset( SelectionOffsetEnd );

            var cursor_control_y = ByteOffsetToControlOffset( LastDragY );

            if( IsDragging ) {

                var x = 0;
                var y = selection_start_y;
                var w = WIDTH - 10;
                var h = cursor_control_y - selection_start_y;

                if( cursor_control_y < selection_start_y ) {
                    y = cursor_control_y;
                    h = -h;
                }
                gr.DrawRectangle( new Pen( Color.White, 5 ), x, y, w, h );
            }
            else if( HasSelection && !IsMagView ) {
                var brush = new SolidBrush( Color.FromArgb( 191, 255, 0, 255 ) );

                // draw the top bit
                if( selection_start_y >= 0 ) {
                    gr.FillRectangle( brush, 0, 0, WIDTH, selection_start_y );
                }

                // draw the bottom bit
                if( selection_end_y >= 0 ) {
                    gr.FillRectangle( brush, 0, selection_end_y, WIDTH, ( RenderedHeight * PIXEL_SIZE ) - selection_end_y );
                }
            }

            if( CursorLastAt > -1 ) {
                var y = ByteOffsetToControlOffset( CursorLastAt );
                var col = ( c % 2 == 0 ) ? 255 : 0;
                gr.DrawRectangle( new Pen( Color.FromArgb( col, col, col ) ), 0, y, WIDTH, 1 );
            }

            gr.DrawLine( new Pen( Color.White, 1 ), 0, cursor_control_y, WIDTH, cursor_control_y );
            c++;
        }

        /**********************************************/
        /// <summary>
        /// Returns current data offset from cursor event Y position
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public long TranslateMouseY( MouseEventArgs e )
        {
            var ypos = e.Y;

            if( ypos < 0 ) {
                ypos = 0;
            }

            if( ypos > Height ) {
                ypos = Height;
            }

            //return ypos;

            return ControlOffsetToByteOffset( ypos );
        }

        private long ControlOffsetToByteOffset( long control_y )
        {
            return Convert.ToUInt32(
                Math.Round(
                    ( control_y * ( (float)( RenderedHeight * PIXEL_SIZE ) / Height ) * WIDTH )
                )
            );
        }
        private long ByteOffsetToControlOffset( long control_y )
        {
            return Convert.ToUInt32(
                Math.Round(
                    ( control_y / ( ( (float)( RenderedHeight * PIXEL_SIZE ) / Height ) * WIDTH ) )
                )
            );
        }

        public void OnResizeEnd( EventArgs e )
        {
            redrawBacking();
        }

        protected override void OnPaint( PaintEventArgs e )
        {
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;

            if( m_backing_render != null )
                e.Graphics.DrawImage( m_backing_render, 0, 0, WIDTH, Height );

            renderSelection( e.Graphics );

            base.OnPaint( e );
        }

        protected override void OnMouseMove( MouseEventArgs e )
        {
            base.OnMouseMove( e );
            LastDragY = TranslateMouseY( e );

            if( RenderedHeight > 0 ) {
                var offs = LastDragY + BoundStart;
                offsetTip.SetToolTip( this, "$" + offs.ToString( "X" ) );
            }

            Invalidate();
        }

        MouseEventArgs m_ondown_click;
        protected override void OnMouseDown( MouseEventArgs e )
        {
            base.OnMouseDown( e );

            if( e.Button == MouseButtons.Right ) {
                Owner.OnDeselect();
                return;
            }

            m_ondown_click = e;

            IsDragging = true;
            SelectionOffsetEnd = BoundLength;
            SelectionOffsetStart = TranslateMouseY( e );
            LastDragY = SelectionOffsetStart;
        }

        protected override void OnMouseUp( MouseEventArgs e )
        {
            base.OnMouseUp( e );

            if( !IsDragging )
                return;

            IsDragging = false;

            if( e.Y == m_ondown_click.Y ) {
                if( !IsMagView ) {
                    Owner.OnDeselect();
                }
                Owner.OnMapClick( TranslateMouseY( e ) );
                CursorLastAt = TranslateMouseY( e );
                return;
            }

            SelectionOffsetEnd = TranslateMouseY( e );

            if( SelectionOffsetStart == SelectionOffsetEnd ) {
                ResetSelection();
            }

            if( SelectionOffsetStart > SelectionOffsetEnd ) {
                var temp = SelectionOffsetEnd;

                SelectionOffsetEnd = SelectionOffsetStart;
                SelectionOffsetStart = temp;
            }

            HasSelection = true;

            if( HasSelection ) {
                Owner.OnSelectionMade(
                        SelectionOffsetStart + BoundStart,
                        SelectionOffsetEnd + BoundStart,
                        IsMagView
                );
            }
        }
    }
}
