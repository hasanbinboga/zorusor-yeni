using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Documents;
using System.Windows;

namespace BilisselBeceriler.BelgeEditor.Library.Converters
{
    public class DocumentPagePageToBorder
    {
        public Border border { get { return _border; } }
        private Border _border;
        public DocumentPagePageToBorder(DocumentPage xpsSayfa)
        {
            VisualBrush vb = new VisualBrush(xpsSayfa.Visual);
            vb.Stretch = Stretch.Uniform;
            vb.AlignmentX = AlignmentX.Left;
            vb.AlignmentY = AlignmentY.Top;
            vb.ViewboxUnits = BrushMappingMode.Absolute;
            vb.TileMode = TileMode.None;
            vb.Viewbox = new Rect(0, 0, xpsSayfa.Size.Width, xpsSayfa.Size.Height);
            Border brd = new Border();
            brd.Background = vb;
            brd.Width = vb.Viewbox.Width;
            brd.Height = vb.Viewbox.Height;
            brd.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
            brd.Arrange(new Rect(new Point(0, 0), brd.DesiredSize));
            _border =  brd;
        }
    }
}
