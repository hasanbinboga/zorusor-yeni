using System.Windows;
using BilisselBeceriler.BelgeEditor.Views;
using System.Collections.Generic;
using System.Linq;
using BilisselBeceriler.Data;
using SilverFlow.Controls;
using System.Windows.Controls;
using BilisselBeceriler.BelgeEditor.Library.Controls;
using BilisselBeceriler.Entities.Web;
using System;

namespace BilisselBeceriler.BelgeEditor
{
    public partial class MainWindow : Window
    {
        private bool _belgeKaydedildi;
        public MainWindow()
        {
            InitializeComponent();
            _belgeKaydedildi = false;
        }


        private void btnBelgeSablon_Click(object sender, RoutedEventArgs e)
        {
            BelgeSablonView window = new BelgeSablonView(ref belgeViewer);
            window.KapatilacakMi = _belgeKaydedildi;
            window.Title = "Belge Şablon Yönetim";
            host.Add(window);
            window.Show(new Point(0, 0));
        }

        private void btnYaklas_Click(object sender, RoutedEventArgs e)
        {
            belgeViewer.Yaklas();
        }

        private void btnYazdir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //var pd = new PrintDialog();
                //if (pd.ShowDialog().Value)
                //{
                    belgeViewer.Yazdir();    
                //}
            }
            catch(Exception ex)   
            {
              MessageBox.Show("Hata:"+ ex);
            }
        }

        private void btnGercekBoyut_Click(object sender, RoutedEventArgs e)
        {
            belgeViewer.GercekBoyut();
        }

        private void btnEkranaSigdir_Click(object sender, RoutedEventArgs e)
        {
            belgeViewer.EkranaSigdir();
        }

        private void btnTumSayfaGoster_Click(object sender, RoutedEventArgs e)
        {
            belgeViewer.TumSayfa();
        }

        private void btnIkiSayfa_Click(object sender, RoutedEventArgs e)
        {
            belgeViewer.IkiSayfa();
        }

        private void btnSayfaSablon_Click(object sender, RoutedEventArgs e)
        {
            SayfaSablonView wnd = new SayfaSablonView();
            wnd.Title = "Sayfa Şablon Yönetim";
            host.Add(wnd);
            wnd.Show(new Point(0, (this.ActualHeight - wnd.Height - 100)));
        }

        private void btnHavuzSablon_Click(object sender, RoutedEventArgs e)
        {
            HavuzSablonView wnd = new HavuzSablonView();
            wnd.Title = "Havuz Şablon Yönetim";
            host.Add(wnd);
            wnd.Show(new Point((this.ActualWidth - wnd.Width - 20), 0));
        }

        private void btnHavuzResim_Click(object sender, RoutedEventArgs e)
        {
            ImageView window = new ImageView();
            window.Title = "Havuz Resim Yönetim";
            host.Add(window);
            window.Show(new Point((this.ActualWidth - window.Width - 20),
                (this.ActualHeight - window.Height - 100)));
        }

        private void btnSayfaAyar_Click(object sender, RoutedEventArgs e)
        {
            ucPageSetup wnd = new ucPageSetup();
            host.Add(wnd);
            wnd.ShowModal();
        }

        private void btnDogrudanYazdir_Click(object sender, RoutedEventArgs e)
        {
            belgeViewer.DogrudanYazdir();
            this.UpdateLayout();
            belgeViewer.UpdateLayout();
        }

        private void btnBireyselAyar_Click(object sender, RoutedEventArgs e)
        {
            BireyselView wnd = new BireyselView();
            host.Add(wnd);
            wnd.Show(0, 0);
        }

        private void btnBelgeUret_Click(object sender, RoutedEventArgs e)
        {
            UretimView wnd = new UretimView();
            host.Add(wnd);
            wnd.Show();
        }

        private void btnUzaklas_Click(object sender, RoutedEventArgs e)
        {
            belgeViewer.Uzaklas();
        }

        private void btnYeniBelge_Click(object sender, RoutedEventArgs e)
        {
            if (belgeViewer.SayfaAdet > 0)
            {
                var cevap = MessageBox.Show("Açık Belgeyi Kaydetmek ister misiniz?",
                            "Yeni Belge", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
                if (cevap == MessageBoxResult.Yes && _belgeKaydedildi == false)
                {
                    _belgeKaydedildi = true;
                    btnBelgeSablon_Click(sender, e);
                    _belgeKaydedildi = false;
                }
                else if (cevap == MessageBoxResult.No)
                {
                    belgeViewer.YeniBelge();
                    this.UpdateLayout();
                }
            }
        }

        private void host_ActiveWindowChanged(object sender, ActiveWindowChangedEventArgs e)
        {
            if (e.New != null)
            {
                if (e.New is ucPageSetup)
                {
                    var pgStp = e.New as ucPageSetup;
                    if (pgStp.Tamam)
                    {
                        belgeViewer.MarjUygula(pgStp.Marj);

                        belgeViewer.UpdateLayout();

                        pgStp.Close();
                    }
                }
            }

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (belgeViewer.SayfaAdet > 0)
            {
                var cevap = MessageBox.Show("Uygulama Kapanıyor...\n\nAçık Belgeyi Kaydetmek ister misiniz?",
                            "Yeni Belge", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (cevap == MessageBoxResult.Yes && _belgeKaydedildi == false)
                {
                    e.Cancel =true;
                }
            }
        }

        private void btnYaziciAyar_Click(object sender, RoutedEventArgs e)
        {
            var pd = new PrintDialog();
            if (pd.ShowDialog().Value)
            {
                belgeViewer.YaziciAyarla(pd);
            }
            
        }

        private void btnYenile_Click(object sender, RoutedEventArgs e)
        {
            belgeViewer.Yenile();
        }
    }
}
