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

        //int m_block_size = DEFAULT_BLOCK_SIZE;

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

            //BlockSizeBox.Text = m_block_size.ToString();

            this.AllowDrop = true;

            widthValue.ValueChanged += onWidthChanged;

            selectionStartValue.Maximum = long.MaxValue;
            selectionStartValue.Minimum = 0;

            selectionEndValue.Maximum = long.MaxValue;
            selectionEndValue.Minimum = 0;
        }

        private void onWidthChanged( object sender, EventArgs e )
        {
            //FIXME : remove control
            //m_minimap.SetWidth( (int)widthValue.Value );
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

            OnSelectionUpdated();
            //widthValue.Value = m_minimap.GetWidth();

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

        /********************************************************************/
        public void LogLn( string msg )
        {
            Log( msg + "\n" );
        }

        /********************************************************************/
        void refresh( bool full_refresh = false )
        {
            if( Data != null ) {
                foreach( var parser in Parsers ) {
                    parser.Refresh();
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
            selectionStartValue.Value = m_minimap.GetSelectedStartOff;
            selectionEndValue.Value = m_minimap.GetSelectedEndOff;
        }

        internal void OnDeselect()
        {
            OnSelectionUpdated();
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

        private void MainForm_KeyPress( object sender, KeyPressEventArgs e )
        {
            if( e.KeyChar == 27 ) {
                this.Close();
            }
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
