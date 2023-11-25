using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using BilisselBeceriler.BelgeEditor.Library.Model;
using System.Configuration;
using BilisselBeceriler.BelgeEditor.Library.Constants;

namespace BilisselBeceriler.BelgeEditor.Views
{
    /// <summary>
    /// Interaction logic for BireyselView.xaml
    /// </summary>
    public partial class BireyselView
    {
        public BireyselView()
        {
            InitializeComponent();

        }

        private void ImagePreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var cp = e.Source as ContentPresenter;
            if (cp == null) return;
            var ie = cp.Content as BireyselEntity;
            if (ie == null) return;
            var data = new DataObject(typeof(BireyselEntity), ie);
            DragDrop.DoDragDrop(cp, data, DragDropEffects.Copy);
        }

        private void FloatingWindowLoaded(object sender, RoutedEventArgs e)
        {
            try
            {
                var path = ConfigurationManager.AppSettings.Get(PathNameConstants.MainPath) + "\\" + 
                           ConfigurationManager.AppSettings.Get(PathNameConstants.BireyselResimSablonPath);
                Cursor = Cursors.Wait;
                var liste = new List<BireyselEntity>();
                var resim = new BireyselEntity
                            {
                                Path = path + "\\Kendi.png",
                                ToolTip = "KENDİ RESMİ",
                                Tag = "Bireysel-Kendi"
                            };
                liste.Add(resim);
                for (int i = 1; i < 5; i++)
                {
                    resim = new BireyselEntity
                    {
                        Path = path + "\\Kendi-Diger" + i + ".png",
                        ToolTip = "VARSA KENDİSİNİN " + i + ". DİĞER RESMİ",
                        Tag = "Bireysel-Kendi-Diger"+i
                    };
                    liste.Add(resim);
                }


                for (int i = 1; i < 6; i++)
                {
                    resim = new BireyselEntity
                    {
                        Path = path + "\\Arkadasi" + i + ".png",
                        ToolTip = i + ". ARKADAŞININ RESMİ",
                        Tag = "Bireysel-Arkadasi"+i
                    };
                    liste.Add(resim);

                    for (int j = 1; j < 5; j++)
                    {
                        resim = new BireyselEntity
                                {
                                    Path = path + "\\Arkadasi" + i + "-Diger" + j + ".png",
                                    ToolTip = i + ". ARKADAŞININ VARSA " + j + ". RESMİ",
                                    Tag = "Bireysel-Arkadasi"+i+"-Diger"+j
                                };
                        liste.Add(resim);
                    }

                }

                resim = new BireyselEntity
                            {
                                Path = path + "\\Cizgi.png",
                                ToolTip = "ÇİZGİ ÇOCUKLARDAN RASTGELE BİRİSİNİN RESMİ",
                                Tag = "Bireysel-Cizgi"
                            };
                liste.Add(resim);
                lstImageGallery.DataContext = liste;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor = Cursors.Arrow;
            }
        }
    }
}
