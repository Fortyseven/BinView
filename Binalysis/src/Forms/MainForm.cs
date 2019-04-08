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

        byte[] m_data;

        int m_block_size = DEFAULT_BLOCK_SIZE;

        int m_previous_y = -1;

        Minimap m_minimap;

        /********************************************************************/
        public MainForm()
        {
            InitializeComponent();

            m_fingerprint = new Fingerprint();
            m_minimap = new Minimap( this );
            mapPanel.Controls.Add( m_minimap );

            m_data = null;

            BlockSizeBox.Text = m_block_size.ToString();

            initTooltips();
        }

        /********************************************************************/
        private void initTooltips()
        {
            var tt = new ToolTip();
            tt.SetToolTip( BlockSizeBox, "Block size" );
        }

        /********************************************************************/
        private void redrawFingerprint()
        {
            m_fingerprint.drawScaled();
            this.Refresh();
        }

        /********************************************************************/
        private void resetDefaultSettings()
        {
            intensitySlider.Value = 8;
        }

        /********************************************************************/
        private void openFile( string filename )
        {
            FileStream fs = File.OpenRead( filename );
            m_data = new byte[ fs.Length ];
            fs.Read( m_data, 0, m_data.Length );
            long flen = fs.Length;
            fs.Close();

            string base_name = filename.Split( '\\' ).Last();

            this.Text = APP_NAME + " - " + base_name;

            resetDefaultSettings();

            m_minimap.Data = m_data;
            refresh( true );

            LogLn( "----------------------------" );
            LogLn( "Opened \"" + filename + "\"" );
            LogLn( "File size: " + flen );
            LogLn( "Avg density: " + this.m_fingerprint.Digrams.AverageDenisty );
            LogLn( "Max density: " + this.m_fingerprint.Digrams.MaxDenisty );
        }

        /********************************************************************/
        void Log( string msg )
        {
            debugLogBox.Text += msg;
        }

        /********************************************************************/
        void LogLn( string msg )
        {
            Log( msg + "\n" );
        }

        /********************************************************************/
        void refresh( bool full_refresh = false )
        {
            if( m_data != null ) {
                if( full_refresh ) {
                    m_fingerprint.Digrams.Calculate( m_data, 0, m_data.Length );
                }
                redrawFingerprint();
                mapPanel.Invalidate();

                //DataOverviewImg.Image = m_data_overview.render( m_data );
            }
        }

        /********************************************************************/
        /********************************************************************/
        /********************************************************************/

        /********************************************************************/
        private void DataOverviewImg_MouseMove( object sender, MouseEventArgs e )
        {
            if( m_data != null ) {
                if( m_previous_y != e.Y ) {
                    if( FingerprintImg.Height > 1 ) {
                        int position = (int)( ( (float)e.Y / (float)FingerprintImg.Height ) * (float)m_data.Length );
                        int start = position - m_block_size / 2;
                        int end = position + m_block_size / 2;

                        m_fingerprint.Digrams.Calculate( m_data, start, end );
                        redrawFingerprint();
                        m_previous_y = e.Y;
                    }
                }
            }
        }

        private void BlockSizeBox_TextChanged( object sender, EventArgs e )
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
            LogLn( "* Block size changed to " + m_block_size );
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
            var x = Convert.ToInt16( Math.Round( e.X / ( (double)FingerprintImg.Width / 256 ) ) );
            var y = Convert.ToInt16( Math.Round( e.Y / ( (double)FingerprintImg.Height / 256 ) ) );

            digramOffsetLabel.Text = "$" + x.ToString( "X" ) + ", $" + y.ToString( "X" );

            // occasionally the mouse scans off the window; keep that from
            // giving us an oob
            if( x < 256 && y < 256 ) {
                digramValue.Text = m_fingerprint.Digrams[ x, y ] + "";
            }
        }

        private void MainForm_Load( object sender, EventArgs e )
        {
            //openFile( "d:\\temp\\temp\\Super Mario Bros. (JU) (PRG1).nes" );
            //openFile( "d:\\temp\\temp\\KOAN Sound - Cobalt-3444478263.mp3" );
            //openFile( "D:\\Temp\\halloween\\ripnes\\outfile.nes" );
            openFile( "D:\\Home\\SNES Classic\\toby-hakchi2.30\\hakchi.exe" );
        }

        private void MainForm_KeyPress( object sender, KeyPressEventArgs e )
        {
            if( e.KeyChar == 27 )
                this.Close();
        }

        private void intensitySlider_ValueChanged( object sender, EventArgs e )
        {
            m_fingerprint.Intensity = (int)intensitySlider.Value;
            redrawFingerprint();
        }

        private void DataOverviewImg_Click( object sender, EventArgs e )
        {
            redrawFingerprint();
        }

        private void FingerprintImg_Paint( object sender, PaintEventArgs e )
        {
            //redrawFingerprint();
            e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            e.Graphics.DrawImage( m_fingerprint.Bitmap, new Rectangle( 0, 0, FingerprintImg.Width, FingerprintImg.Height ) );
        }

        private void mapPanel_Paint( object sender, PaintEventArgs e )
        {
            selectionLabel.Text = m_minimap.GetSelectedStartOff.ToString() + " to " + m_minimap.GetSelectedEndOff.ToString();
        }
    }
}
