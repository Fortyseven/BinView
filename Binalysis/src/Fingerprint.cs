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
        Int32 m_avarage_density = 0;

        /********************************************************************/
        public void calculate( byte[] m_data, int range_start, int range_end )
        {
            if( m_data == null )
                return;

            int x, y;
            int start;
            int end;

            m_max_density = 0;
            m_avarage_density = 0;

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
                    m_avarage_density += m_finger_print[ x, y ];
                }
            }

            m_avarage_density = m_avarage_density / ( FINGERPRINT_RES * FINGERPRINT_RES );
        }

        /********************************************************************/
        public void drawNormalized( Bitmap bm )
        {
            for( int x = 0; x < FINGERPRINT_RES; x++ ) {
                for( int y = 0; y < FINGERPRINT_RES; y++ ) {
                    Int32 density = m_finger_print[ x, y ];
                    byte v_density;

                    /*
                    if (density < m_avarage_density)
                    {
                        v_density = (byte)(((float)180.0 * (float)density) / (float)m_avarage_density);
                    } else {
                        v_density = (byte)(180.0 + ((float)75.0 * (float)density) / (float)m_max_density);
                    }
                    */

                    if( density > 0 ) {
                        v_density = (byte)( (byte)255 - (byte)( 255 / density ) );
                    }
                    else {
                        v_density = 0;
                    }

                    Color co = Color.FromArgb( 255, v_density, v_density, v_density );


                    if( m_finger_print[ x, y ] > 0 ) {
                        bm.SetPixel( x, y, co );
                    }
                }
            }
        }

        /********************************************************************/
        public void drawScaled( Bitmap bm )
        {
            for( int x = 0; x < FINGERPRINT_RES; x++ ) {
                for( int y = 0; y < FINGERPRINT_RES; y++ ) {
                    Int32 density = m_finger_print[ x, y ];
                    byte v_density;

                    if( density < 256 )
                        v_density = (byte)density;
                    else
                        v_density = 255;

                    Color co = Color.FromArgb( 255, v_density, v_density, v_density );

                    if( m_finger_print[ x, y ] > 0 ) {
                        bm.SetPixel( x, y, co );
                    }
                }
            }
        }

        /********************************************************************/
        public void drawRaw( Bitmap bm )
        {
            Color active = Color.FromArgb( 255, 255, 255, 255 );
            //Color iniactive = Color.FromArgb(255, 255, 255, 255);

            for( int x = 0; x < FINGERPRINT_RES; x++ ) {
                for( int y = 0; y < FINGERPRINT_RES; y++ ) {
                    if( m_finger_print[ x, y ] > 0 ) {
                        bm.SetPixel( x, y, active );
                    }
                }
            }
        }
    }
}
