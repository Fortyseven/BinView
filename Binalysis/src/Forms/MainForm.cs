using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace Binalysis
{
    public partial class MainForm : Form
    {
        const string APP_NAME = "Binalysis";
        const int DEFAULT_BLOCK_SIZE = 10240;

        public byte[] Data { get; set; } = new byte[ 0 ] { };

        int m_block_size = DEFAULT_BLOCK_SIZE;

        Minimap m_minimap;

        List<Parser> Parsers { get; set; } = new List<Parser>();

        /********************************************************************/
        public MainForm()
        {
            InitializeComponent();

            m_minimap = new Minimap( this );

            Parsers.Add( new FingerprintDigramParser( this, m_minimap ) );
            Parsers.Add( new FingerprintDiagramRaw( this, m_minimap ) );

            Parsers[ 0 ].Focus();

            mapPanel.Controls.Add( m_minimap );

            BlockSizeBox.Text = m_block_size.ToString();

            this.AllowDrop = true;
            this.DragEnter += MainForm_DragEnter;
            this.DragDrop += MainForm_DragDrop;
        }

        /********************************************************************/
        private void openFile( string filename )
        {
            FileStream fs = File.OpenRead( filename );
            Data = new byte[ fs.Length ];
            fs.Read( Data, 0, Data.Length );
            long flen = fs.Length;
            fs.Close();

            string base_name = filename.Split( '\\' ).Last();

            this.Text = APP_NAME + " - " + base_name;

            m_minimap.Data = Data;

            foreach( var parser in Parsers ) {
                parser.OnDataLoaded( Data );
            }

            refresh( true );

            Invalidate();

            LogLn( "----------------------------" );
            LogLn( "Opened \"" + filename + "\"" );
            LogLn( "File size: " + flen );
            //LogLn( "Avg density: " + this.m_fingerprint.Digrams.AverageDenisty );
            //LogLn( "Max density: " + this.m_fingerprint.Digrams.MaxDenisty );
        }

        /********************************************************************/
        void Log( string msg )
        {
            debugLogBox.AppendText( msg );
            debugLogBox.SelectionStart = debugLogBox.Text.Length;
            debugLogBox.ScrollToCaret();
        }

        /********************************************************************/
        void LogLn( string msg )
        {
            Log( msg + "\n" );
        }

        /********************************************************************/
        void refresh( bool full_refresh = false )
        {
            if( Data != null ) {
                if( full_refresh ) {
                    //m_fingerprint.Digrams.Calculate( Data, 0, Data.Length );
                }
                foreach( var parser in Parsers ) {
                    parser.Invalidate();
                }
                mapPanel.Invalidate();

                //DataOverviewImg.Image = Data_overview.render( Data );
            }
        }

        /********************************************************************/
        public void OnSelectionUpdated()
        {
            foreach( var parser in Parsers ) {
                parser.OnSelectionUpdated();
            }
        }

        #region winforms callbacks
        /********************************************************************/
        /********************************************************************/
        /********************************************************************/
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

        /********************************************************************/
        private void BlockSizeBox_Leave( object sender, EventArgs e )
        {
            BlockSizeBox.Text = m_block_size.ToString();
            LogLn( "* Block size changed to " + m_block_size );
            refresh( true );
        }

        /********************************************************************/
        private void openToolStripMenuItem_Click( object sender, EventArgs e )
        {
            if( openFileDlg.ShowDialog() == DialogResult.OK ) {
                if( Data != null )
                    Data = null;

                openFile( openFileDlg.FileName );
            }
        }

        /********************************************************************/
        private void exitToolStripMenuItem_Click( object sender, EventArgs e )
        {
            this.Close();
        }

        /********************************************************************/
        //private void FingerprintImg_MouseMove( object sender, MouseEventArgs e )
        //{
        //    var x = Convert.ToInt16( Math.Round( e.X / ( (double)FingerprintImg.Width / 256 ) ) );
        //    var y = Convert.ToInt16( Math.Round( e.Y / ( (double)FingerprintImg.Height / 256 ) ) );

        //    digramOffsetLabel.Text = "$" + x.ToString( "X" ) + ", $" + y.ToString( "X" );

        //    // occasionally the mouse scans off the window; keep that from
        //    // giving us an oob
        //    if( x < 256 && y < 256 ) {
        //        digramValue.Text = m_fingerprint.Digrams[ x, y ] + "";
        //    }
        //}

        /********************************************************************/
        private void MainForm_Load( object sender, EventArgs e )
        {
            //openFile( "d:\\temp\\temp\\Super Mario Bros. (JU) (PRG1).nes" );
            //openFile( "d:\\temp\\temp\\KOAN Sound - Cobalt-3444478263.mp3" );
            //openFile( "D:\\Temp\\halloween\\ripnes\\outfile.nes" );
            openFile( "D:\\Home\\SNES Classic\\toby-hakchi2.30\\hakchi.exe" );
        }

        /********************************************************************/
        private void MainForm_KeyPress( object sender, KeyPressEventArgs e )
        {
            if( e.KeyChar == 27 )
                this.Close();
        }

        /********************************************************************/
        private void mapPanel_Paint( object sender, PaintEventArgs e )
        {
            //selectionLabel.Text = m_minimap.GetSelectedStartOff.ToString() + " to " + m_minimap.GetSelectedEndOff.ToString();

            //FIXME: wire this up in Minimap
        }

        /********************************************************************/
        private void MainForm_DragDrop( object sender, DragEventArgs e )
        {
            string[] files = (string[])e.Data.GetData( DataFormats.FileDrop );
            if( files.Length == 1 )
                openFile( files[ 0 ] );
        }

        /********************************************************************/
        private void MainForm_DragEnter( object sender, DragEventArgs e )
        {
            if( e.Data.GetDataPresent( DataFormats.FileDrop ) )
                e.Effect = DragDropEffects.Copy;
        }
        #endregion
    }
}
