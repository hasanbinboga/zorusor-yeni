using System.Linq;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace BilisselBeceriler.BelgeEditor.Library.Helpers
{
    public static class AntetHelper
    {
        public static Grid YeniOlustur()
        {
            Grid yeniAntet = new Grid();
            yeniAntet.Height = 155;
            yeniAntet.Tag = "Antet";
            yeniAntet.Children.Add(BaslikOlustur());
            yeniAntet.Children.Add(CocukBilgiOlustur());
            yeniAntet.Children.Add(ResimGridOlustur("AntetFoto",
                new Thickness(0, 10, 17, 0),
                HorizontalAlignment.Right,
                VerticalAlignment.Top,
                134, 100, true));
            yeniAntet.Children.Add(ResimGridOlustur("AntetLogo",
                new Thickness(10, 12, 0, 0),
                HorizontalAlignment.Left,
                VerticalAlignment.Top,
                120, 120, false));
            return yeniAntet;
        }
        private static TextBlock BaslikOlustur()
        {
            TextBlock baslik = new TextBlock();
            Canvas.SetLeft(baslik, 3.83);
            baslik.MaxWidth = 540;
            baslik.MaxHeight = 90;
            baslik.Margin = new Thickness(13, 10, 1, 0);
            baslik.HorizontalAlignment = HorizontalAlignment.Center;
            baslik.VerticalAlignment = VerticalAlignment.Top;
            baslik.FontFamily = new FontFamily("Arial Black");
            baslik.FontSize = 30;
            baslik.Foreground = Brushes.Black;
            baslik.Tag = "AntetBaslik";
            baslik.TextAlignment = TextAlignment.Center;
            baslik.TextWrapping = TextWrapping.Wrap;
            return baslik;
        }
        private static StackPanel CocukBilgiOlustur()
        {
            StackPanel cocukBilgi = new StackPanel();
            cocukBilgi.Tag = "AntetCoucukBilgi";
            cocukBilgi.Height = 30;
            cocukBilgi.Margin = new Thickness(140, 100, 0, 0);
            cocukBilgi.HorizontalAlignment = HorizontalAlignment.Left;
            cocukBilgi.VerticalAlignment = VerticalAlignment.Top;
            cocukBilgi.Orientation = Orientation.Horizontal;
            cocukBilgi.Children.Add(BilgiLabelOlustur("", "Adı Soyadı:", true));
            cocukBilgi.Children.Add(BilgiLabelOlustur("AntetAdSoyad", "......................................................", false));
            cocukBilgi.Children.Add(BilgiLabelOlustur("", "Doğum Tarihi:", true));
            cocukBilgi.Children.Add(BilgiLabelOlustur("AntetDogumTarih", "15/05/2006", false));
            return cocukBilgi;
        }
        private static Label BilgiLabelOlustur(string tag, string content, bool Kalin)
        {
            Label bilgi = new Label();
            bilgi.Content = content;
            bilgi.FontFamily = new FontFamily("Arial");
            bilgi.FontSize = 14.667;
            if (string.IsNullOrEmpty(tag) == false)
            {
                bilgi.Tag = tag;
            }
            if (Kalin == true)
            {
                bilgi.FontWeight = FontWeights.Bold;
            }
            return bilgi;
        }
        private static Grid ResimGridOlustur(string tag, Thickness marj,
            HorizontalAlignment yHiza, VerticalAlignment dHiza, double yukseklik, double genislik, bool golge)
        {
            Grid grResim = new Grid();
            grResim.VerticalAlignment = dHiza;
            grResim.HorizontalAlignment = yHiza;
            if (string.IsNullOrEmpty(tag))
            {
                grResim.Tag = tag;
            }
            grResim.Children.Add(ResimBorderOlustur(yukseklik, genislik, golge));
            return grResim;
        }
        private static Border ResimBorderOlustur(double yukseklik, double genislik, bool golge)
        {
            Border brResim = new Border();
            brResim.Width = genislik;
            brResim.Height = yukseklik;
            brResim.BorderThickness = new Thickness(0);
            brResim.Background = Brushes.Bisque;
            if (golge == true)
            {
                DropShadowEffect golgeEfect = new DropShadowEffect();
                golgeEfect.BlurRadius = 14;
                golgeEfect.Direction = 317;
                golgeEfect.ShadowDepth = 3;
                golgeEfect.Color = Colors.Black;

                brResim.Effect = golgeEfect;
            }
            return brResim;
        }
        public static void BaslikDuzenle(Grid seciliAntet, string baslik)
        {
            var txtBaslik = seciliAntet.Children.OfType<TextBlock>().FirstOrDefault();
            if (txtBaslik != null)
            {
                txtBaslik.Text = baslik;
            }
        }
        public static void CocukBilgiDuzenle(Grid seciliAntet, string adSoyad, string dTarih)
        {
            var cocukBilgi = seciliAntet.Children.OfType<StackPanel>().FirstOrDefault(s => s.Tag.ToString() == "AntetCoucukBilgi");
            if (cocukBilgi != null)
            {
                var lbl = cocukBilgi.Children.OfType<Label>().FirstOrDefault(s => s.Tag.ToString() == "AntetAdSoyad");
                lbl.Content = adSoyad;
                lbl = cocukBilgi.Children.OfType<Label>().FirstOrDefault(s => s.Tag.ToString() == "AntetDogumTarih");
                lbl.Content = dTarih;
            }
        }
        public static void LogoDuzenle(Grid seciliAntet, string LogoDosya)
        {
            if (seciliAntet.Tag.ToString() == "Antet")
            {
                var resim = seciliAntet.Children.
                    OfType<Grid>().FirstOrDefault(a => a.Tag.ToString() == "AntetLogo").
                    Children.OfType<Border>().First();
                resim.Background = ImageBrushHelper.Olustur(LogoDosya, resim.Width, resim.Height);
            }
        }
        public static void FotoDuzenle(Grid seciliAntet, string FotoDosya)
        {
            if (seciliAntet.Tag.ToString() == "Antet")
            {
                var resim = seciliAntet.Children.
                    OfType<Grid>().FirstOrDefault(a => a.Tag.ToString() == "AntetFoto").
                    Children.OfType<Border>().First();
                resim.Background = ImageBrushHelper.Olustur(FotoDosya, resim.Width, resim.Height);
            }
        }
    }
}
