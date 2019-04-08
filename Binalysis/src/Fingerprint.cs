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
        Bitmap m_bitmap = null;

        public Digrams Digrams { get; set; } = new Digrams();

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
                Invalidate();
            }
        }

        public void Invalidate()
        {
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
            var mult = ( m_bitmap.Width / Digrams.RESOLUTION );


            using( Graphics gr = Graphics.FromImage( m_bitmap ) ) {
                gr.Clear( Color.FromArgb( 32, 32, 32 ) );
                var average_density = Digrams.AverageDenisty;

                if( average_density < ( Digrams.MaxDenisty / 2 ) ) {
                    average_density /= 4;
                }
                // render density values
                for( int y = 0; y < Digrams.RESOLUTION; y++ ) {
                    for( int x = 0; x < Digrams.RESOLUTION; x++ ) {

                        var ox = x * mult;
                        var oy = y * mult;

                        var density = Digrams[ x, y ] * Intensity;

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
        //public void drawRaw()
        //{
        //    if( !m_force_redraw ) {
        //        return;
        //    }

        //    m_bitmap = new Bitmap( 256, 256 );
        //    Color active = Color.FromArgb( 255, 255, 255, 255 );

        //    for( int y = 0; y < FINGERPRINT_RES; y++ ) {
        //        for( int x = 0; x < FINGERPRINT_RES; x++ ) {

        //            if( m_finger_print[ x, y, 0 ] > 0 ) {
        //                m_bitmap.SetPixel( x, y, active );
        //            }

        //        }
        //    }
        //    m_force_redraw = false;
        //}
    }
}
