using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binalysis
{
    class Fingerprint
    {
        const int FINGERPRINT_RES = 256;

        Int32[,] m_finger_print = new Int32[ FINGERPRINT_RES, FINGERPRINT_RES ];
        Int32 m_max_density = 0;
        Int32 m_average_density = 0;
        Bitmap m_bitmap = null;
        bool m_force_redraw = false;

        int m_intensity = 1;

        public Bitmap Bitmap {
            get {
                return this.m_bitmap;
            }
        }

        public int Intensity {
            get {
                return m_intensity;
            }
            set {
                m_intensity = value;
                ForceRefresh();
            }
        }
        public Int32 DensityAverage {
            get {
                return this.m_average_density;
            }
        }
        public Int32 DensityMax {
            get {
                return this.m_max_density;
            }
        }

        public Int32[,] Digrams {
            get {
                return this.m_finger_print;
            }
        }

        public void ForceRefresh()
        {
            m_force_redraw = true;
        }


        /********************************************************************/
        public void calculate( byte[] m_data, int range_start, int range_end )
        {
            if( m_data == null )
                return;

            int x, y;
            int start;
            int end;

            m_max_density = 0;
            m_average_density = 0;

            // reset values
            for( x = 0; x < FINGERPRINT_RES; x++ )
                for( y = 0; y < FINGERPRINT_RES; y++ )
                    m_finger_print[ x, y ] = 0;

            // set start/end based on range, if present
            if( range_start < range_end ) {
                start = range_start;
                end = range_end;
            }
            else {
                start = range_end;
                end = range_start;
            }

            if( start < 0 ) {
                start = 0;
                if( end < 0 )
                    end = 0;
            }

            if( end >= m_data.Length ) {
                end = m_data.Length - 1;
                if( start >= m_data.Length - 1 )
                    start = m_data.Length - 1;
            }

            // get the first byte?
            y = m_data[ start ];

            // iterate over data range
            for( int i = start + 1; i < end; i++ ) {
                x = y;
                y = m_data[ i ];

                // increment this pair, whatever it is
                m_finger_print[ x, y ]++;

                // is this new incremented value the highest ever? log it 
                // this helps build a range from 0 to max_density
                if( m_max_density < m_finger_print[ x, y ] ) {
                    m_max_density = m_finger_print[ x, y ];
                }
            }

            // calculate the avaerge denisty of the fingerprint
            for( x = 0; x < FINGERPRINT_RES; x++ ) {
                for( y = 0; y < FINGERPRINT_RES; y++ ) {
                    m_average_density += m_finger_print[ x, y ];
                }
            }

            m_average_density = (int)Math.Round( ( (float)m_average_density ) / ( FINGERPRINT_RES * FINGERPRINT_RES ) );

            m_force_redraw = true;
        }

        /********************************************************************/
        public void drawScaled()
        {
            if( !m_force_redraw ) {
                return;
            }

            m_bitmap = new Bitmap( 256, 256 );

            var brush = new System.Drawing.SolidBrush( System.Drawing.Color.Red );
            var mult = ( m_bitmap.Width / FINGERPRINT_RES );


            using( Graphics gr = Graphics.FromImage( m_bitmap ) ) {
                gr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                gr.Clear( Color.FromArgb( 32, 32, 32 ) );
                var average_density = m_average_density;

                if( average_density < ( m_max_density / 2 ) ) {
                    average_density /= 4;
                }
                // render density values
                for( int y = 0; y < FINGERPRINT_RES; y++ ) {
                    for( int x = 0; x < FINGERPRINT_RES; x++ ) {

                        var ox = x * mult;
                        var oy = y * mult;

                        var density = m_finger_print[ x, y ] * Intensity;

                        if( density >= 255 ) {
                            density = 255;
                        }

                        if( density > 0 ) {
                            if( ( x >= 32 && x <= 125 ) && ( y >= 32 && y <= 125 ) ) {
                                brush.Color = Color.FromArgb( density, (int)( density / 1.5 ), 0 );
                            }
                            else {
                                brush.Color = Color.FromArgb( density, density, density );
                            }

                            var pos = new Rectangle( ox, oy, mult, mult );
                            gr.FillRectangle( brush, pos );
                        }
                    }
                }
            }
            m_force_redraw = false;
        }

        /********************************************************************/
        public void drawRaw()
        {
            if( !m_force_redraw ) {
                return;
            }

            m_bitmap = new Bitmap( 256, 256 );
            Color active = Color.FromArgb( 255, 255, 255, 255 );

            for( int y = 0; y < FINGERPRINT_RES; y++ ) {
                for( int x = 0; x < FINGERPRINT_RES; x++ ) {

                    if( m_finger_print[ x, y ] > 0 ) {
                        m_bitmap.SetPixel( x, y, active );
                    }

                }
            }
            m_force_redraw = false;
        }
    }
}
