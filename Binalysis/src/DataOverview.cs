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
        const int WIDTH = 128;

        const int MAX_HEIGHT = 1024;

        public Image render( byte[] data )
        {
            int height = (int)Math.Ceiling( (float)( data.Length ) / (float)( WIDTH ) );

            if( height > MAX_HEIGHT )
                height = MAX_HEIGHT;

            Bitmap bm = new Bitmap( WIDTH, height );

            int stride = (int)Math.Ceiling( (float)( data.Length ) / (float)( height * WIDTH ) );

            for( int i = 1; i < ( WIDTH * height ) - 1; i++ ) {
                int data_off = i * stride;
                if( data_off >= data.Length - 2 )
                    continue;
                Color col = Color.FromArgb( data[ data_off ], data[ data_off + 1 ], data[ data_off + 2 ] );
                bm.SetPixel( i % WIDTH, i / WIDTH, col );
            }
            return bm;
        }
    }
}
