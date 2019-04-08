using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binalysis
{
    class Digrams
    {
        public const int RESOLUTION = 256;

        private Int32[,] Values { get; set; } = new Int32[ RESOLUTION, RESOLUTION ];
        public Int32 this[ int x, int y ] { get { return Values[ x, y ]; } }
        public Int32 MaxDenisty { get; set; } = 0;
        public Int32 AverageDenisty { get; set; } = 0;

        public void Calculate( byte[] m_data, int range_start, int range_end )
        {
            if( m_data == null )
                return;

            int x, y;
            int start;
            int end;

            MaxDenisty = 0;
            AverageDenisty = 0;

            // reset values
            for( x = 0; x < RESOLUTION; x++ )
                for( y = 0; y < RESOLUTION; y++ )
                    Values[ x, y ] = 0;

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
                Values[ x, y ]++;

                // is this new incremented value the highest ever? log it 
                // this helps build a range from 0 to max_density
                if( MaxDenisty < Values[ x, y ] ) {
                    MaxDenisty = Values[ x, y ];
                }
            }

            // calculate the avaerge denisty of the fingerprint
            for( x = 0; x < RESOLUTION; x++ ) {
                for( y = 0; y < RESOLUTION; y++ ) {
                    AverageDenisty += Values[ x, y ];
                }
            }

            AverageDenisty = (int)Math.Round( ( (float)AverageDenisty ) / ( RESOLUTION * RESOLUTION ) );

            //m_force_redraw = true;
        }
    }
}
