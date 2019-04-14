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

        //protected override CreateParams CreateParams {
        //    get {
        //        CreateParams cp = base.CreateParams;
        //        cp.ExStyle |= 0x02000000;
        //        return cp;
        //    }
        //}

        Minimap m_minimap;

        List<Parser> Parsers { get; set; } = new List<Parser>();

        /********************************************************************/
        public MainForm()
        {
            InitializeComponent();

            DoubleBuffered = true;

            m_minimap = new Minimap( this );

            mapPanel.Controls.Add( m_minimap );

            Parsers.Add( new FingerprintDigramParser( this, m_minimap ) );
            Parsers.Add( new FingerprintDiagramRaw( this, m_minimap ) );
            Parsers.Add( new HexView( this, m_minimap ) );

            Parsers[ 0 ].ChangeTo();

            this.AllowDrop = true;

            selectionStartValue.Maximum = long.MaxValue;
            selectionStartValue.Minimum = 0;
            selectionStartValue.ValueChanged += ( object sender, EventArgs e ) => {
                m_minimap.SetSelectionStart( Convert.ToInt32( selectionStartValue.Value ) );
            };

            selectionEndValue.Maximum = long.MaxValue;
            selectionEndValue.Minimum = 0;
            selectionEndValue.ValueChanged += ( object sender, EventArgs e ) => {
                m_minimap.SetSelectionEnd( Convert.ToInt32( selectionEndValue.Value ) );
            };

            // eat 'em up yum
            contentTabPanel.KeyDown += ( object sender, KeyEventArgs e ) => { };
        }

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

            OnSelectionUpdated( 0, Data.Length );

            refresh( true );

            LogLn( "----------------------------" );
            LogLn( "Opened \"" + filename + "\"" );
            LogLn( "File size: " + flen );
        }

        /********************************************************************/
        public void Log( string msg )
        {
            debugLogBox.AppendText( msg );
            debugLogBox.SelectionStart = debugLogBox.Text.Length;
            debugLogBox.ScrollToCaret();
        }
        public void LogLn( string msg )
        {
            Log( msg + "\n" );
        }

        void refresh( bool full_refresh = false )
        {
            if( Data != null ) {
                foreach( var parser in Parsers ) {
                    parser.Refresh();
                }
                mapPanel.Invalidate();
            }
        }

        public void OnMapClick( long offset )
        {
            foreach( var parser in Parsers ) {
                parser.OnMapClick( offset );
            }
        }

        public void OnSelectionUpdated( long start, long end )
        {
            foreach( var parser in Parsers ) {
                parser.OnSelectionUpdated( start, end );
            }
            selectionStartValue.Value = start;
            selectionEndValue.Value = end;
        }

        internal void OnDeselect()
        {
            OnSelectionUpdated( 0, Data.Length );
        }

        #region winforms callbacks
        /********************************************************************/
        /********************************************************************/
        /********************************************************************/

        private void openToolStripMenuItem_Click( object sender, EventArgs e )
        {
            if( openFileDlg.ShowDialog() == DialogResult.OK ) {
                if( Data != null )
                    Data = null;

                openFile( openFileDlg.FileName );
            }
        }

        private void exitToolStripMenuItem_Click( object sender, EventArgs e )
        {
            this.Close();
        }

        private void MainForm_Load( object sender, EventArgs e )
        {
            //openFile( "d:\\temp\\temp\\Super Mario Bros. (JU) (PRG1).nes" );
            //openFile( "d:\\temp\\temp\\KOAN Sound - Cobalt-3444478263.mp3" );
            //openFile( "D:\\Temp\\halloween\\ripnes\\outfile.nes" );
            openFile( "D:\\Home\\SNES Classic\\toby-hakchi2.30\\hakchi.exe" );
        }

        protected override bool ProcessCmdKey( ref Message msg, Keys keyData )
        {
            switch( keyData ) {

                // QUIT
                case Keys.Escape:
                    this.Close();
                    break;

                // START OFFSET ----------------------------
                case Keys.Up:
                    m_minimap.AdjustSelectionStart( 1 );
                    break;
                case ( Keys.Up | Keys.Control ):
                    m_minimap.AdjustSelectionStart( 4096 );
                    break;
                case Keys.Down:
                    m_minimap.AdjustSelectionStart( -1 );
                    break;
                case ( Keys.Down | Keys.Control ):
                    m_minimap.AdjustSelectionStart( -4096 );
                    break;

                // END OFFSET ------------------------------
                case ( Keys.Up | Keys.Alt ):
                    m_minimap.AdjustSelectionEnd( 1 );
                    break;
                case ( Keys.Up | Keys.Control | Keys.Alt ):
                    m_minimap.AdjustSelectionEnd( 4096 );
                    break;
                case ( Keys.Down | Keys.Alt ):
                    m_minimap.AdjustSelectionEnd( -1 );
                    break;
                case ( Keys.Down | Keys.Control | Keys.Alt ):
                    m_minimap.AdjustSelectionEnd( -4096 );
                    break;

                // MOVE SELECTION WINDOW -------------------
                case Keys.Left:
                    m_minimap.AdjustSelectionStart( -1 );
                    m_minimap.AdjustSelectionEnd( -1 );
                    break;
                case Keys.Right:
                    m_minimap.AdjustSelectionStart( 1 );
                    m_minimap.AdjustSelectionEnd( 1 );
                    break;
                case ( Keys.Left | Keys.Control ):
                    m_minimap.AdjustSelectionStart( -4096 );
                    m_minimap.AdjustSelectionEnd( -4096 );
                    break;
                case ( Keys.Right | Keys.Control ):
                    m_minimap.AdjustSelectionStart( 4096 );
                    m_minimap.AdjustSelectionEnd( 4096 );
                    break;
            }

            return base.ProcessCmdKey( ref msg, keyData );
        }

        protected override void OnDragDrop( DragEventArgs drgevent )
        {
            string[] files = (string[])drgevent.Data.GetData( DataFormats.FileDrop );

            if( files.Length == 1 ) {
                openFile( files[ 0 ] );
            }

            base.OnDragDrop( drgevent );
        }

        protected override void OnDragEnter( DragEventArgs drgevent )
        {
            if( drgevent.Data.GetDataPresent( DataFormats.FileDrop ) ) {
                drgevent.Effect = DragDropEffects.Copy;
            }

            base.OnDragEnter( drgevent );
        }

        protected override void OnResize( EventArgs e )
        {
            if( m_minimap != null )
                m_minimap.OnResizeEnd( e );
            base.OnResize( e );
        }
        #endregion
    }
}
