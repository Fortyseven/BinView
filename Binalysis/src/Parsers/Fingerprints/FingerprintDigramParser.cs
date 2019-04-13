using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Binalysis
{
    class FingerprintDigramParser : Parser
    {
        public Bitmap Bitmap { get; set; }
        public bool ForceRedraw { get; set; } = true;
        public Digrams Digrams { get; set; } = new Digrams();
        protected UserControl Canvas { get; set; }

        int m_intensity = 1;
        public int Intensity {
            get {
                return m_intensity;
            }
            set {
                m_intensity = value;
                if( ui_intensitySlider != null )
                    ui_intensitySlider.Value = value;
            }
        }

        protected override string Title {
            get {
                return "Fingerprint 2D";
            }
        }

        private TrackBar ui_intensitySlider;

        /********************************************************************/
        /********************************************************************/
        /********************************************************************/

        public FingerprintDigramParser( MainForm owner, Minimap minimap ) : base( owner, minimap )
        {
        }

        /********************************************************************/
        public override Control Create()
        {
            ForceRedraw = true;
            Canvas = new UserControl();

            //Canvas.BackColor = Color.FromArgb( 0, 0, 0 );
            Canvas.Dock = DockStyle.Fill;

            return Canvas;
        }

        /********************************************************************/
        public virtual void RefreshFingerprintBitmap()
        {
            if( ForceRedraw ) {

                Bitmap = new Bitmap( 256, 256 );

                var brush = new System.Drawing.SolidBrush( System.Drawing.Color.Red );
                var mult = ( Bitmap.Width / Digrams.RESOLUTION );


                using( Graphics gr = Graphics.FromImage( Bitmap ) ) {
                    gr.InterpolationMode = InterpolationMode.NearestNeighbor;
                    //gr.Clear( Color.FromArgb( 32, 32, 32 ) );
                    gr.Clear( Color.Black );
                    var average_density = Digrams.AverageDenisty;

                    if( average_density < ( Digrams.MaxDenisty / 2 ) ) {
                        average_density /= 4;
                    }
                    // render density values
                    for( int y = 0; y < Digrams.RESOLUTION; y++ ) {
                        for( int x = 0; x < Digrams.RESOLUTION; x++ ) {

                            var ox = x * mult;
                            var oy = y * mult;

                            var density = Digrams[ x, y ] * Intensity;

                            if( density >= 255 ) {
                                density = 255;
                            }

                            if( density > 0 ) {
                                if( ( x >= 32 && x <= 125 ) && ( y >= 32 && y <= 125 ) ) {
                                    brush.Color = Color.FromArgb( (int)density, (int)( density / 1.5 ), 0 );
                                }
                                else {
                                    brush.Color = Color.FromArgb( (int)density, (int)density, (int)density );
                                }

                                var pos = new Rectangle( ox, oy, mult, mult );
                                gr.FillRectangle( brush, pos );
                            }
                        }
                    }
                }
                ForceRedraw = false;
            }
            Invalidate();
        }

        /********************************************************************/
        public override Control BuildOptions()
        {
            FlowLayoutPanel panel = new FlowLayoutPanel();

            panel.Dock = DockStyle.Fill;

            ui_intensitySlider = new TrackBar() {
                Name = "Intensity",
                Minimum = 1,
                Maximum = 100,
                Value = 8
            };

            ui_intensitySlider.ValueChanged += OnIntensityChanged;

            panel.Controls.Add( new Label() {
                Text = "Intensity:"
            } );
            panel.Controls.Add( ui_intensitySlider );

            return panel;
        }

        /********************************************************************/
        private void OnIntensityChanged( object sender, EventArgs e )
        {
            Intensity = ui_intensitySlider.Value;
            ForceRedraw = true;
            RefreshFingerprintBitmap();
            Refresh();
        }

        public override void PagePaint( object sender, PaintEventArgs pe )
        {
            using( Graphics gr = pe.Graphics ) {
                //gr.Clear( Color.Black );
                gr.InterpolationMode = InterpolationMode.NearestNeighbor;
                gr.DrawImage( Bitmap, new Rectangle( 0, 0, this.Width, this.Height ) );
                gr.DrawLine( new Pen( Color.Red, 2 ), 0, 0, 100, 100 );
            }
            base.OnPaint( pe );
        }

        public void Redraw( bool force_draw = false )
        {
            if( force_draw ) {
                Digrams.Calculate( Data, Minimap.GetSelectedStartOff, Minimap.GetSelectedEndOff );
                ForceRedraw = true;
            }
            RefreshFingerprintBitmap();
            Invalidate();
        }

        public override void OnDataLoaded( byte[] data )
        {
            base.OnDataLoaded( data );
            Intensity = 8;
            OnSelectionUpdated();
        }

        public override void OnSelectionUpdated()
        {
            Redraw( true );
        }

        public override void OnEnter()
        {
            Redraw( true );
        }

        public override void OnLeave()
        {

        }

        public override void UpdateOptions()
        {
            //throw new NotImplementedException();
        }
    }
}
