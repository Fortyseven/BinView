using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Binalysis
{
    class FingerprintDiagramRaw : FingerprintDigramParser
    {
        protected override string Title {
            get {
                return "Fingerprint Raw";
            }
        }

        public FingerprintDiagramRaw( MainForm owner, Minimap minimap ) : base( owner, minimap )
        {
        }

        public override void RefreshFingerprintBitmap()
        {
            if( ForceRedraw ) {

                Bitmap = new Bitmap( 256, 256 );
                Color active = Color.FromArgb( 255, 255, 255, 255 );

                for( int y = 0; y < Digrams.RESOLUTION; y++ ) {
                    for( int x = 0; x < Digrams.RESOLUTION; x++ ) {

                        if( Digrams[ x, y ] > 0 ) {
                            Bitmap.SetPixel( x, y, active );
                        }

                    }
                }
                ForceRedraw = false;
            }

            Owner.Invalidate();
        }

        public override Control BuildOptions()
        {
            return new Panel();
        }
    }
}
