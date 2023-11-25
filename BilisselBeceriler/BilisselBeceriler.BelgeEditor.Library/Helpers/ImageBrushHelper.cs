using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows;

namespace BilisselBeceriler.BelgeEditor.Library.Helpers
{
    public static class ImageBrushHelper
    {
        public static ImageBrush Olustur(string resimDosya, double genislik, double yukseklik)
        {
            ImageBrush yeniBrush = new ImageBrush();
            yeniBrush.ImageSource =
                new BitmapImage(new Uri(resimDosya, UriKind.Relative));
            yeniBrush.Stretch = Stretch.Fill;
            yeniBrush.AlignmentX = AlignmentX.Center;
            yeniBrush.AlignmentY = AlignmentY.Center;
            yeniBrush.ViewboxUnits = BrushMappingMode.Absolute;
            yeniBrush.TileMode = TileMode.None;
            yeniBrush.Viewbox = new Rect(0, 0, genislik, yukseklik);
            return yeniBrush;
        }
    }
}
