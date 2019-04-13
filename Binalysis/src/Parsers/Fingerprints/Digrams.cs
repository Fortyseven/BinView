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

        private int[,] Values { get; set; } = new int[ RESOLUTION, RESOLUTION ];
        public int this[ int x, int y ] { get { return Values[ x, y ]; } }
        public int MaxDenisty { get; set; } = 0;
        public int AverageDenisty { get; set; } = 0;

        public void Calculate( byte[] m_data, long range_start, long range_end )
        {
            if( m_data == null )
                return;

            int x, y;
            long start;
            long end;

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

            if( end > m_data.Length ) {
                end = m_data.Length;
                if( start > m_data.Length - 1 )
                    start = m_data.Length - 1;
            }
            if( m_data.Length == 0 )
                return;

            // get the first byte?
            y = m_data[ start ];

            // iterate over data range
            for( var i = start + 1; i < end; i++ ) {
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
        }
    }
}
