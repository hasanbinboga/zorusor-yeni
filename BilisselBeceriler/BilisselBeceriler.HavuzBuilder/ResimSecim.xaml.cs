using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;

namespace BilisselBeceriler.HavuzBuilder
{
    /// <summary>
    /// Interaction logic for ResimSecim.xaml
    /// </summary>
    public partial class ResimSecim : Window
    {
        public List<int> seciliResimIndeksleri { get; set; }
        public ResimSecim(string TemelParcaKlasorYolu)
        {
            InitializeComponent();

            string parca1 = Directory.GetDirectories(TemelParcaKlasorYolu)[0];
            string[] varyanslar = Directory.GetDirectories(parca1);
            int figurAdet = Directory.GetFiles(varyanslar[0], "*.png").
                Where(s => File.GetAttributes(s) !=
                    (FileAttributes.Hidden | FileAttributes.Archive)).Count();
            for (int i = 0; i < figurAdet; i++)
            {
                StackPanel listItem = new StackPanel();
                listItem.Height = 106;
                listItem.Orientation = Orientation.Horizontal;
                listItem.Margin = new Thickness(3);
                foreach (var varyans in varyanslar)
                {
                    try
                    {
                        Image figur = new Image();
                        figur.Width = 100;
                        figur.Height = 100;
                        BitmapImage src = new BitmapImage();
                        src.BeginInit();
                        src.UriSource = new Uri(Directory.GetFiles(varyans, "*.png").
                Where(s => File.GetAttributes(s) !=
                    (FileAttributes.Hidden | FileAttributes.Archive)).ElementAt(i), UriKind.Absolute);
                        src.EndInit();
                        figur.Source = src;
                        listItem.Children.Add(figur);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }

                }
                lbResimler.Items.Add(listItem);
            }
        }

        private void btnTamam_Click(object sender, RoutedEventArgs e)
        {
            seciliResimIndeksleri = new List<int>(lbResimler.SelectedItems.Count);
            foreach (var seciliResim in lbResimler.SelectedItems)
            {
                seciliResimIndeksleri.Add(lbResimler.Items.IndexOf(seciliResim));
            }
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            seciliResimIndeksleri = null;
            this.Close();
        }


    }
}
