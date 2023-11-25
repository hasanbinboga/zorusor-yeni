using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using System.Windows.Documents;

namespace BilisselBeceriler.BelgeEditor.Library.Helpers
{
    public static class VisualBrushHelper
    {
        
        public static VisualBrush Olustur(string dosyaYol, double genislik, double yukseklik)
        {
            XamlHelper oku = new XamlHelper();
            oku.IcerigiYukle(dosyaYol);
            var pn = oku.Content as Panel;
            pn.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
            pn.Arrange(new Rect(new Point(0,0), new Point(pn.DesiredSize.Width, pn.DesiredSize.Height)));
            Visual a = pn as Visual;
            VisualBrush _arkaPlan = new VisualBrush(a);
            _arkaPlan.AutoLayoutContent = true;
            _arkaPlan.Stretch = Stretch.Uniform;
            _arkaPlan.AlignmentX = AlignmentX.Center;
            _arkaPlan.AlignmentY = AlignmentY.Center;
            _arkaPlan.ViewboxUnits = BrushMappingMode.Absolute;
            _arkaPlan.TileMode = TileMode.None;
            _arkaPlan.Viewbox = new Rect(0, 0, genislik, yukseklik);
            return _arkaPlan;
        }
        public static VisualBrush Olustur(Panel Icerik, double genislik, double yukseklik)
        {
            VisualBrush _arkaPlan = new VisualBrush(Icerik);
            _arkaPlan.AutoLayoutContent = true;
            _arkaPlan.Stretch = Stretch.Uniform;
            _arkaPlan.AlignmentX = AlignmentX.Center;
            _arkaPlan.AlignmentY = AlignmentY.Center;
            _arkaPlan.ViewboxUnits = BrushMappingMode.Absolute;
            _arkaPlan.TileMode = TileMode.None;
            _arkaPlan.Viewbox = new Rect(0, 0, genislik, yukseklik);
            return _arkaPlan;
        }
        public static VisualBrush Olustur(PageContent Icerik, double genislik, double yukseklik)
        {
            var pn = Icerik.Child.Children[0];
            pn.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
            pn.Arrange(new Rect(new Point(0, 0), new Point(pn.DesiredSize.Width, pn.DesiredSize.Height)));
            Visual a = pn as Visual;
            VisualBrush _arkaPlan = new VisualBrush(a);
            _arkaPlan.AutoLayoutContent = true;
            _arkaPlan.Stretch = Stretch.Uniform;
            _arkaPlan.AlignmentX = AlignmentX.Center;
            _arkaPlan.AlignmentY = AlignmentY.Center;
            _arkaPlan.ViewboxUnits = BrushMappingMode.Absolute;
            _arkaPlan.TileMode = TileMode.None;
            _arkaPlan.Viewbox = new Rect(0, 0, genislik, yukseklik);
            return _arkaPlan;
        }
        public static VisualBrush Olustur(Panel Icerik)
        {
            VisualBrush _arkaPlan = new VisualBrush(Icerik);
            _arkaPlan.AutoLayoutContent = true;
            _arkaPlan.Stretch = Stretch.Uniform;
            _arkaPlan.AlignmentX = AlignmentX.Center;
            _arkaPlan.AlignmentY = AlignmentY.Center;
            _arkaPlan.ViewboxUnits = BrushMappingMode.Absolute;
            _arkaPlan.TileMode = TileMode.None;
            return _arkaPlan;
        }
    }
}
