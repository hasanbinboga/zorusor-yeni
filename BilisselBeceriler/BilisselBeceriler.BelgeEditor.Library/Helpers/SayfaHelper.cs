using System;
using System.Printing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using Microsoft.Win32;

namespace BilisselBeceriler.BelgeEditor.Library.Helpers
{
    public static class SayfaHelper
    {
        public static Grid Olustur(Grid yeniSayfa, PageMediaSize sayfaEbat, Thickness marj)
        {
            var sayfaContent = new Grid();

            var a4 = new PageMediaSize(PageMediaSizeName.ISOA4, 793, 1122);

            yeniSayfa.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
            yeniSayfa.Arrange(new Rect(new Point(0, 0), yeniSayfa.DesiredSize));

            yeniSayfa.Width = yeniSayfa.DesiredSize.Width;
            yeniSayfa.Height = yeniSayfa.DesiredSize.Height;

            var kaynak = new Size(793, 1122);

            if (a4.Width != null) sayfaContent.Width = a4.Width.Value;
            if (a4.Height != null) sayfaContent.Height = a4.Height.Value;

            sayfaContent.Children.Add(yeniSayfa);

            #region Scale Page Content

            if (sayfaEbat.Width != null && sayfaEbat.Height != null)
            {
                var targetSize = new Size(sayfaEbat.Width.Value, sayfaEbat.Height.Value);
                double sc = ScaleHesapla(kaynak, targetSize);
                var tg = new TransformGroup();
                var sct = new ScaleTransform(sc, sc) { CenterX = 0, CenterY = 0 };
                tg.Children.Add(sct);
                sayfaContent.LayoutTransform = tg;
            }
            sayfaContent.UpdateLayout();
            #endregion
            return sayfaContent;

        }
        public static Grid KapakOlustur(Grid yeniSayfa, PageMediaSize sayfaEbat)
        {
            var sayfaContent = new Grid();
            var a3 = new PageMediaSize(PageMediaSizeName.ISOA3, 1586, 1122);
            var a4 = new PageMediaSize(PageMediaSizeName.ISOA4, 793, 1122);

            yeniSayfa.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
            yeniSayfa.Arrange(new Rect(new Point(0, 0), yeniSayfa.DesiredSize));

            yeniSayfa.Width = yeniSayfa.DesiredSize.Width;
            yeniSayfa.Height = yeniSayfa.DesiredSize.Height;
            Size kaynak, targetSize = new Size();
            if (yeniSayfa.Width > yeniSayfa.Height)
            {
                kaynak = new Size(1586, 1122);
                if (a3.Width != null) sayfaContent.Width = a3.Width.Value;
                if (a3.Height != null) sayfaContent.Height = a3.Height.Value;
                if (sayfaEbat.Width != null && sayfaEbat.Height!= null) targetSize = new Size(sayfaEbat.Width.Value * 2, sayfaEbat.Height.Value);
            }
            else
            {
                kaynak = new Size(793, 1122);
                if (a4.Width != null) sayfaContent.Width = a4.Width.Value;
                if (a4.Height != null) sayfaContent.Height = a4.Height.Value;
                if (sayfaEbat.Width != null && sayfaEbat.Height != null)
                    targetSize = new Size(sayfaEbat.Width.Value, sayfaEbat.Height.Value);
            }
            sayfaContent.Children.Add(yeniSayfa);

            #region Scale Page Content


            var sc = ScaleHesapla(kaynak, targetSize);
            var tg = new TransformGroup();
            var sct = new ScaleTransform(sc, sc) { CenterX = 0, CenterY = 0 };
            tg.Children.Add(sct);
            sayfaContent.LayoutTransform = tg;
            sayfaContent.UpdateLayout();
            #endregion
            return sayfaContent;

        }

        public static void SayfaEbatUygula(PageContent content, PageMediaSize sayfaEbat)
        {
            var sayfaContent = content.Child.Children[0] as Grid;
            if (sayfaContent != null)
            {
                var kaynak = new Size(sayfaContent.Width, sayfaContent.Height);

                if (sayfaContent.DesiredSize.Width <= sayfaContent.DesiredSize.Height)
                {
                    if (sayfaEbat.Width.HasValue) content.Width = sayfaEbat.Width.Value;
                    if (sayfaEbat.Height.HasValue) content.Height = sayfaEbat.Height.Value;
                }
                else
                {
                    if (sayfaEbat.Width.HasValue) if (sayfaEbat.Height != null) content.Width = sayfaEbat.Height.Value;
                    if (sayfaEbat.Height.HasValue) if (sayfaEbat.Width != null) content.Height = sayfaEbat.Width.Value;
                }
                content.UpdateLayout();

                #region Scale Page Content

                if ((sayfaEbat.Width != null) && (sayfaEbat.Height != null))
                {
                    var targetSize = new Size(sayfaEbat.Width.Value,
                                              sayfaEbat.Height.Value);
                    double sc = ScaleHesapla(kaynak, targetSize);
                    var tg = new TransformGroup();
                    var sct = new ScaleTransform(sc, sc) { CenterX = 0, CenterY = 0 };
                    tg.Children.Add(sct);
                    sayfaContent.LayoutTransform = tg;
                }
                sayfaContent.UpdateLayout();

            }
                #endregion
            content.UpdateLayout();
        }
        private static double ScaleHesapla(Size kaynak, Size hedef)
        {
            double scw = hedef.Width / kaynak.Width;
            double sch = hedef.Height / kaynak.Height;
            if (scw < sch)
            {
                return scw;
            }
            return sch;
        }
        public static void MarjUygula(PageContent content, Thickness marj)
        {
            var sayfaContent = content.Child.Children[0] as Grid;
            if (sayfaContent != null)
            {
                sayfaContent.Margin = marj;
                sayfaContent.UpdateLayout();
            }
        }


        //private static TransformGroup Olcekle(Border sayfa, Grid icerik)
        //{
        //    var olcek = new ScaleTransform(
        //        (icerik.Width / sayfa.Width),
        //        (icerik.Height / sayfa.Height));
        //    var transformGroup = new TransformGroup();
        //    transformGroup.Children.Add(sayfa.LayoutTransform);
        //    transformGroup.Children.Add(olcek);
        //    return transformGroup;
        //}
        //private static TransformGroup Dondur(Grid icerik)
        //{
        //    Transform cevir = new RotateTransform(-90);
        //    var transformGroup = new TransformGroup();
        //    transformGroup.Children.Add(icerik.LayoutTransform);
        //    transformGroup.Children.Add(cevir);
        //    icerik.LayoutTransform = transformGroup;
        //    return transformGroup;
        //}
        //private static void Dondur(ref Grid sayfa)
        //{
        //    sayfa.LayoutTransform = Dondur(sayfa);
        //}
        //private static void DondurGeriAl(ref Grid sayfa)
        //{
        //    sayfa.LayoutTransform = null;
        //}

        public static Thickness GetFromRegistry()
        {
            var key = Registry.CurrentUser.OpenSubKey("BilisselBeceri");
            var marj = new Thickness();
            try
            {
                if (key != null)
                {
                    double sol = Convert.ToDouble(key.GetValue("SolMarj"));
                    double sag = Convert.ToDouble(key.GetValue("SagMarj"));
                    double ust = Convert.ToDouble(key.GetValue("UstMarj"));
                    double alt = Convert.ToDouble(key.GetValue("AltMarj"));
                    marj = new Thickness(sol, ust, sag, alt);
                }
                return marj;
            }
            catch (Exception e)
            {
                if (Registry.CurrentUser.OpenSubKey("BilisselBeceri") != null)
                {
                    Registry.CurrentUser.DeleteSubKey("BilisselBeceri");
                }
                throw new Exception("GetFromRegistry Hata: " + e.Message + "\n" + e.InnerException.Message);
            }

        }
        public static void SetToRegistry(Thickness marj)
        {
            try
            {
                if (Registry.CurrentUser.OpenSubKey("BilisselBeceri") != null)
                {
                    Registry.CurrentUser.DeleteSubKey("BilisselBeceri");
                }

                var key = Registry.CurrentUser.CreateSubKey("BilisselBeceri");

                if (key != null)
                {
                    key.SetValue("SolMarj", marj.Left);
                    key.SetValue("SagMarj", marj.Right);
                    key.SetValue("UstMarj", marj.Top);
                    key.SetValue("AltMarj", marj.Bottom);

                    key.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Yazıcı Açma Problemi: " + ex.Message);
                if (Registry.CurrentUser.OpenSubKey("BilisselBeceri") != null)
                {
                    Registry.CurrentUser.DeleteSubKey("BilisselBeceri");
                }
            }
        }
    }
}
