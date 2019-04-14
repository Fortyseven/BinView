using System.Drawing;
using System.Windows.Forms;
using Be.Windows.Forms;

namespace Binalysis
{
    class HexView : Parser
    {
        private HexBox HexBox { get; set; }
        public HexView( MainForm owner, Minimap minimap ) : base( owner, minimap )
        {
        }

        protected override string Title {
            get {
                return "Hex";
            }
        }

        public override Control BuildOptions()
        {
            return new Panel() {
                BackColor = Color.FromArgb( 255, 0, 0 ),
                Dock = DockStyle.Fill
            };
        }

        public override Control Create()
        {
            HexBox = new HexBox() {
                Dock = DockStyle.Fill,
                Visible = true,
                UseFixedBytesPerLine = true,
                BytesPerLine = 16,
                ColumnInfoVisible = true,
                LineInfoVisible = true,
                StringViewVisible = true,
                VScrollBarVisible = true,
                BackColor = Color.Black,
                ForeColor = Color.LimeGreen,
                Font = new Font( "Consolas", 10 )
            };

            return HexBox;
        }

        public override void OnEnter()
        {
        }

        public override void OnLeave()
        {
        }

        public override void OnSelectionUpdated( long start, long end )
        {
            HexBox.SelectionStart = start;
        }

        public override void PagePaint( object sender, PaintEventArgs p )
        {
            base.OnPaint( p );
        }

        public override void UpdateOptions()
        {
        }

        public override void OnDataLoaded( byte[] data )
        {
            Data = data;
            HexBox.ByteProvider = new DynamicByteProvider( Data );
        }

        public override void OnMapClick( long offset )
        {
            HexBox.SelectionStart = offset;
        }
    }
}
