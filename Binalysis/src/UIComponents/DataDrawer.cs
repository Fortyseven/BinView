using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Binalysis
{
    class DataDrawer
    {
        const int WIDTH = 128;
        const int MAX_HEIGHT = 1024;

        public byte[] Data { get; set; }

        public PictureBox ParentControl { get; set; } = null;
        public Minimap Owner { get; set; } = null;
        public long RenderedHeight { get; set; }
        public bool Debug { get; set; }

        private long Stride { get; set; }
        public long LastDragY = 0;
        public bool IsDragging = false;

        private Bitmap m_cached_render = null;


        /**********************************************/
        public long SelectionOffsetStart { get; set; }
        public long SelectionOffsetEnd { get; set; }

        public long SelectionOffsetStartInBytes {
            get {
                return ( SelectionOffsetStart * WIDTH * Stride );
            }
        }
        public long SelectionOffsetEndInBytes {
            get {
                return ( SelectionOffsetEnd * WIDTH * Stride );
            }
        }
        public long LastDragYInBytes {
            get {
                return ( LastDragY * WIDTH * Stride );
            }
        }

        public bool HasSelection {
            get {
                return ( SelectionOffsetStart > -1 && SelectionOffsetEnd > -1 );
            }
        }

        /**********************************************/
        public long BoundStart { get; set; }
        public long BoundEnd { get; set; }
        public long BoundLength {
            get {
                return BoundEnd - BoundStart;
            }
        }

        /**********************************************/
        public DataDrawer( Minimap owner, ref byte[] data, PictureBox parent_control, long bound_start = -1, long bound_end = -1, bool debug = false )
        {
            Data = data;
            Owner = owner;
            ParentControl = parent_control;

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

            Debug = debug;

            ResetSelection();

            parent_control.MouseDown += this.onMouseDown;
            parent_control.MouseUp += this.onMouseUp;
            parent_control.MouseMove += this.onMouseMove;
        }

        /**********************************************/
        public void ResetSelection()
        {
            SelectionOffsetStart = -1;
            SelectionOffsetEnd = -1;
        }

        /**********************************************/
        public void Draw()
        {
            if( Data.Length == 0 ) {
                return;
            }

            if( m_cached_render == null ) {

                RenderedHeight = (int)Math.Ceiling( (float)( BoundLength ) / (float)( WIDTH ) );

                if( RenderedHeight > MAX_HEIGHT )
                    RenderedHeight = MAX_HEIGHT;

                m_cached_render = new Bitmap( WIDTH, (int)RenderedHeight );

                Stride = (int)Math.Ceiling( (float)( BoundLength ) / (float)( RenderedHeight * WIDTH ) );

                long data_ptr = BoundStart;

                for( int i = 0; i < ( WIDTH * RenderedHeight ); i++ ) {
                    data_ptr += Stride;

                    if( data_ptr >= BoundEnd - 2 )
                        continue;

                    Color col = Color.FromArgb( Data[ data_ptr ], Data[ data_ptr + 1 ], Data[ data_ptr + 2 ] );

                    m_cached_render.SetPixel( i % WIDTH, i / WIDTH, col );
                }
            }

            var bmcopy = new Bitmap( m_cached_render );

            renderSelection( bmcopy );

            ParentControl.Image = bmcopy;
        }

        /**********************************************/
        private void renderSelection( Bitmap bm )
        {
            using( var gr = Graphics.FromImage( bm ) ) {
                if( IsDragging ) {
                    var x = 0;
                    var y = SelectionOffsetStart;
                    var w = WIDTH - 1;
                    var h = LastDragY - SelectionOffsetStart;

                    if( LastDragY < SelectionOffsetStart ) {
                        y = LastDragY;
                        h = -h;
                    }

                    gr.DrawRectangle( new Pen( Color.White, 5 ), x, y, w, h );
                }
                else {

                    var brush = new SolidBrush( Color.FromArgb( 128, 255, 0, 255 ) );

                    // draw the top bit
                    if( SelectionOffsetStart >= 0 ) {
                        gr.FillRectangle( brush, 0, 0, WIDTH, SelectionOffsetStart );
                    }

                    // draw the bottom bit
                    if( SelectionOffsetEnd >= 0 ) {
                        gr.FillRectangle( brush, 0, SelectionOffsetEnd, WIDTH, RenderedHeight - SelectionOffsetEnd );
                    }
                }

                gr.DrawLine( new Pen( Color.White, 1 ), 0, LastDragY, WIDTH, LastDragY );
            }
        }

        /**********************************************/
        public long TranslateMouseY( MouseEventArgs e )
        {
            var ypos = e.Y;

            if( ypos < 0 ) {
                ypos = 0;
            }

            if( ypos > ParentControl.Height ) {
                ypos = ParentControl.Height;

            }

            return Convert.ToUInt16(
                    Math.Round(
                        ypos * ( (double)RenderedHeight / ParentControl.Height )
                    )
            );
        }

        /**********************************************/
        /**********************************************/
        /**********************************************/
        //public void onClick( MouseEventArgs e )
        //{
        //    var click_row = TranslateMouseY( e );

        //    // first start, then end...
        //    if( SelectionOffsetStart == -1 ) {
        //        SelectionOffsetStart = click_row;
        //    }
        //    else if( SelectionOffsetEnd == -1 ) {
        //        SelectionOffsetEnd = click_row;
        //    }
        //}

        /**********************************************/
        public void onMouseMove( object sender, MouseEventArgs e )
        {
            LastDragY = TranslateMouseY( e );
            Owner.Invalidate();
            Owner.Parent.Invalidate();
        }

        /**********************************************/
        public void onMouseDown( object sender, MouseEventArgs e )
        {
            if( e.Button == MouseButtons.Right ) {
                Owner.onDeselect();
                return;
            }

            IsDragging = true;
            SelectionOffsetEnd = -1;
            SelectionOffsetStart = TranslateMouseY( e );
            LastDragY = SelectionOffsetStart;

            Owner.Invalidate();
            Owner.Parent.Invalidate();
        }

        /**********************************************/
        public void onMouseUp( object sender, MouseEventArgs e )
        {
            if( !IsDragging )
                return;

            IsDragging = false;

            SelectionOffsetEnd = TranslateMouseY( e );

            if( SelectionOffsetStart == SelectionOffsetEnd ) {
                ResetSelection();
            }

            if( SelectionOffsetStart > SelectionOffsetEnd ) {
                var temp = SelectionOffsetEnd;

                SelectionOffsetEnd = SelectionOffsetStart;
                SelectionOffsetStart = temp;
            }

            if( HasSelection ) {
                Owner.onSelectionMade(
                        SelectionOffsetStartInBytes,
                        SelectionOffsetEndInBytes
                );
            }
            Owner.Invalidate();
            Owner.Parent.Invalidate();
        }
    }
}
