using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;

namespace BilisselBeceriler.BelgeEditor.Library.Helpers
{
    public static class SayfaNoHelper
    {
        public static Label Olusutur(int sayfaNo)
        {
            Label yeniSayfaNo = new Label();
            yeniSayfaNo.Tag = "SayfaNo";
            yeniSayfaNo.Content = "Sayfa " + sayfaNo;
            yeniSayfaNo.FontFamily = new FontFamily("Arial");
            yeniSayfaNo.FontWeight = FontWeights.Bold;
            yeniSayfaNo.Padding = new Thickness(0, 5, 0, 0);
            return yeniSayfaNo;
        }
        public static void NumaraDuzenle(Label seciliSayfaNo, int yeniNo)
        {
            if (seciliSayfaNo.Tag.ToString()== "SayfaNo")
            {
                seciliSayfaNo.Content = "Sayfa " + yeniNo;
            }
        }
    }
}
