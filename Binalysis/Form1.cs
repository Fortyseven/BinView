using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Drawing2D;

namespace Binalysis
{
    public partial class MainForm : Form
    {
        const string APP_NAME = "Binalysis";
        const int DEFAULT_BLOCK_SIZE = 10240;

        Fingerprint m_fingerprint;
        DataOverview m_data_overview;

        byte[] m_data;

        int m_block_size = DEFAULT_BLOCK_SIZE;

        int m_previous_y = -1;



        /********************************************************************/
        public MainForm()
        {
            InitializeComponent();

            m_fingerprint = new Fingerprint();
            m_data_overview = new DataOverview();

            m_data = null;

            BlockSizeBox.Text = m_block_size.ToString();

            initTooltips();
            //openFile( "d:\\temp\\temp\\Super Mario Bros. (JU) (PRG1).nes" );
            //openFile( "d:\\temp\\temp\\KOAN Sound - Cobalt-3444478263.mp3" );


        }

        /********************************************************************/
        private void initTooltips()
        {
            var tt = new ToolTip();
            tt.SetToolTip( BlockSizeBox, "Block size" );

        }



        //private void OldCalculateRangeFingerPrint(int xy, int yy)
        //{
        //    if (m_data != null)
        //    {
        //        int x, y;

        //        m_max_density = 0;
        //        m_avarage_density = 0;

        //        for (x = 0; x < 256; x++)
        //            for (y = 0; y < 256; y++)
        //                m_finger_print[x, y] = 0;

        //        y = m_data[0];

        //        for (int i = 1; i < m_data.Length; i++)
        //        {
        //            x = y;
        //            y = m_data[i];
        //            m_finger_print[x, y]++;

        //            if (m_max_density < m_finger_print[x, y]) m_max_density = m_finger_print[x, y];
        //        }

        //        for (x = 0; x < 256; x++)
        //            for (y = 0; y < 256; y++)
        //                m_avarage_density += m_finger_print[x, y];

        //        m_avarage_density = m_avarage_density / (256 * 256);

        //    }
        //}


        /********************************************************************/
        private void redrawFingerprint()
        {
            // Bitmap bm = new Bitmap( 512, 512);
            Bitmap bm = new Bitmap( 256, 256 );

            bool Scaled = ScaleChk.Checked;
            bool Normalize = NormalizeChk.Checked;

            if( Scaled ) {
                if( Normalize ) {
                    m_fingerprint.drawNormalized( bm );
                }
                else {
                    m_fingerprint.drawScaled( bm );
                }
            }
            else {
                m_fingerprint.drawRaw( bm );
            }

            FingerprintImg.Image = bm;
        }

        /********************************************************************/
        private void resetDefaultSettings()
        {
            ScaleChk.Checked = true;
            NormalizeChk.Checked = false;
            FullViewChk.Checked = true;
        }

        /********************************************************************/
        private void openFile( string filename )
        {

            FileStream fs = File.OpenRead( filename );
            m_data = new byte[ fs.Length ];
            fs.Read( m_data, 0, m_data.Length );
            fs.Close();

            this.Text = APP_NAME + " - " + filename;

            resetDefaultSettings();

            refresh( true );
        }

        /********************************************************************/
        void refresh( bool full_refresh = false )
        {
            if( m_data != null ) {
                if( full_refresh ) {
                    m_fingerprint.calculate( m_data, 0, m_data.Length );
                }
                redrawFingerprint();
                DataOverviewImg.Image = m_data_overview.update( m_data );
            }
        }

        /********************************************************************/
        /********************************************************************/
        /********************************************************************/

        /********************************************************************/
        private void Scale_CheckedChanged( object sender, EventArgs e )
        {
            //DrawData();
            NormalizeChk.Enabled = ScaleChk.Checked;

            redrawFingerprint();
        }

        /********************************************************************/
        private void NormalizeChk_CheckedChanged( object sender, EventArgs e )
        {
            //if( ScaleChk.Checked ) {
            //    //DrawData();
            redrawFingerprint();
            //}
        }

        /********************************************************************/
        private void DataOverviewImg_MouseMove( object sender, MouseEventArgs e )
        {
            if( FullViewChk.Checked )
                return;

            if( m_data != null ) {
                if( m_previous_y != e.Y ) {
                    if( FingerprintImg.Height > 1 ) {
                        int position = (int)( ( (float)e.Y / (float)FingerprintImg.Height ) * (float)m_data.Length );
                        int start = position - m_block_size / 2;
                        int end = position + m_block_size / 2;

                        m_fingerprint.calculate( m_data, start, end );
                        redrawFingerprint();
                        m_previous_y = e.Y;
                    }
                }
            }
        }

        private void checkBox1_CheckedChanged( object sender, EventArgs e )
        {
            Refresh();
        }

        private void textBox1_TextChanged( object sender, EventArgs e )
        {
            if( BlockSizeBox.Text.Length > 0 ) {
                try {
                    m_block_size = Convert.ToInt32( BlockSizeBox.Text );
                }
                catch( Exception ee ) {
                    m_block_size = DEFAULT_BLOCK_SIZE;
                }
            }
        }

        private void BlockSizeBox_Leave( object sender, EventArgs e )
        {
            BlockSizeBox.Text = m_block_size.ToString();
            refresh( true );
        }

        private void openToolStripMenuItem_Click( object sender, EventArgs e )
        {
            if( openFileDlg.ShowDialog() == DialogResult.OK ) {
                if( m_data != null )
                    m_data = null;

                openFile( openFileDlg.FileName );
            }
        }

        private void exitToolStripMenuItem_Click( object sender, EventArgs e )
        {
            this.Close();
        }

        private void FingerprintImg_MouseMove( object sender, MouseEventArgs e )
        {
            var x = Convert.ToInt16(Math.Round( e.X / ( (double)FingerprintImg.Width / 256 ) ));
            var y = Convert.ToInt16(Math.Round( e.Y / ( (double)FingerprintImg.Height / 256 ) ));

            digramOffsetLabel.Text = "$"+x.ToString("X") + ", $" + y.ToString("X");
        }
    }
}
