using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Binalysis
{
    class DataOverview
    {
        public Image render( byte[] data )
        {
            const int Width = 128;
            int Height = (int)Math.Ceiling( (float)( data.Length ) / (float)( Width ) );

            Bitmap bm = new Bitmap( Width, Height );
            for( int i = 1; i < data.Length; i++ ) {
                bm.SetPixel( i % Width, i / Width, Color.FromArgb( 255, 32, data[ i ], 64 ) );

            }
            return bm;
        }
    }
}
