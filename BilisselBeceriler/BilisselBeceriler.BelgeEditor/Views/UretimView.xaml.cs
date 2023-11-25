using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using BilisselBeceriler.BelgeEditor.Library.Constants;
using BilisselBeceriler.BelgeEditor.Library.Helpers;
using BilisselBeceriler.BelgeEditor.Library.Model;
using BilisselBeceriler.BelgeEditor.Library.Service;
using BilisselBeceriler.Data;
using BilisselBeceriler.Entities.Web;
using System.Windows.Threading;
using System.Collections.Generic;
using System.IO;
using NHibernate.Criterion;
using NHibernate.Transform;

namespace BilisselBeceriler.BelgeEditor.Views
{
    public partial class UretimView
    {
        public UretimView()
        {
            InitializeComponent();
            BelgeUretHelper.CiktiPath = ConfigurationManager.AppSettings.Get(PathNameConstants.MainPath) + ConfigurationManager.AppSettings.Get(PathNameConstants.CiktiPath);
            BelgeUretHelper.CizgiCocukPath = ConfigurationManager.AppSettings.Get(PathNameConstants.MainPath) + ConfigurationManager.AppSettings.Get(PathNameConstants.CizgiCocukPath);
            BelgeUretHelper.CocukFotoPath = ConfigurationManager.AppSettings.Get(PathNameConstants.MainPath) + ConfigurationManager.AppSettings.Get(PathNameConstants.CocukFotoPath);
            BelgeUretHelper.OkulLogoPath = ConfigurationManager.AppSettings.Get(PathNameConstants.MainPath) + ConfigurationManager.AppSettings.Get(PathNameConstants.OkulLogoPath);
        }
        private bool _iptalEdildi = false;
        private Repository<Okul> _repository;
        private ObservableCollection<FolderEntity> _folderList;

        //public List<Okul> OkulListe(string OkulLogoPath)
        //{
        //    List<Okul> okullar = new List<Okul>();
        //    using (_repository = new Repository<Okul>())
        //    {
        //        var liste = _repository.Session.CreateCriteria("Okul")
        //            .SetProjection(Projections.ProjectionList()
        //           .Add(Projections.Property("Id"), "Id")
        //           .Add(Projections.Property("Adi"), "Adi"))
        //           .SetResultTransformer(Transformers.AliasToBean(typeof(Okul)))
        //           .List<Okul>();

        //        foreach (var seciliOkul in liste)
        //        {
        //            var kapakLogoPath = OkulLogoPath + @"\KapakLogo\" + seciliOkul.Id + ".png";
        //            var sayfaLogoPath = OkulLogoPath + @"\SayfaLogo\" + seciliOkul.Id + ".png";
        //            if (File.Exists(kapakLogoPath))
        //            {
        //                seciliOkul.KapakLogo = File.ReadAllBytes(kapakLogoPath);
        //            }
        //            else
        //            {
        //                seciliOkul.KapakLogo = _repository.Session.CreateSQLQuery("SELECT KapakLogo FROM okul WHERE Id=" + seciliOkul.Id).UniqueResult<Byte[]>();
        //            }
        //            if (File.Exists(sayfaLogoPath))
        //            {
        //                seciliOkul.Logo = File.ReadAllBytes(sayfaLogoPath);
        //            }
        //            else
        //            {
        //                seciliOkul.Logo = _repository.Session.CreateSQLQuery("SELECT Logo FROM okul WHERE Id=" + seciliOkul.Id).UniqueResult<Byte[]>();
        //            }
        //            okullar.Add(seciliOkul);
        //        }
        //    }
        //    return okullar;
        //}

        void MesayYaz(string mesaj)
        {
            Dispatcher.BeginInvoke((Action)(() => tbKullaniciMesaj.Text = mesaj));
        }
        private delegate void Uret(Okul okul, Ogrenci ogrenci, string sayiPath);
        private void TopluBelgeUret(object sender, RoutedEventArgs e)
        {
            if (lstOkul.SelectedItem == null)
            {
                MessageBox.Show("Lüfen okul seçiniz");
                return;
            }
            if (lstSinif.SelectedItem == null)
            {
                MessageBox.Show("Lüfen sınıf seçiniz");
                return;
            }
            if (lstSayi.SelectedItem == null)
            {
                MessageBox.Show("Lüfen sayi seçiniz");
                return;
            }
            btnBelgeUret.IsEnabled = false;
            var okul = (Okul)lstOkul.SelectedItem;
            var sinif = (Sinif)lstSinif.SelectedItem;
            var sayi = (FolderEntity)lstSayi.SelectedItem;
            var ogrenciListe = sinif.OgrenciListe;
            int adet = ogrenciListe.Count;
            int index = 0;
            pbTopluBelgeDurum.Visibility = Visibility.Visible;
            pbTopluBelgeDurum.Minimum = 0;
            pbTopluBelgeDurum.Maximum = adet;
            btnIptal.Visibility = System.Windows.Visibility.Visible;
            var yazici = PrintHelper.GetDialogFromRegistry();
            if (lstOgrenci.SelectedItem == null)
            {
                foreach (var ogrenci in ogrenciListe)
                {
                    if (_iptalEdildi)
                    {
                        break;
                    }
                    pbTopluBelgeDurum.Value = index;
                    MesayYaz(ogrenci.Adi + " " + ogrenci.Soyadi + " hazırlanıyor...");
                    BelgeUretHelper.Yazici = yazici.PrintQueue;
                    BelgeUretHelper.OgrenciBelgeUret(okul, ogrenci, sayi.Path);
                    //Dispatcher.BeginInvoke(new Uret(BelgeUretHelper.OgrenciBelgeUret), okul, ogrenci, sayi.Path);
                    //Thread.Sleep(3000);
                    MesayYaz(ogrenci.Adi + " " + ogrenci.Soyadi + " hazırlandı");
                    index++;
                }
                pbTopluBelgeDurum.Visibility = Visibility.Collapsed;
                MesayYaz(sinif.Adi + " sınıfı öğrencileri için toplam " + adet + " adet belge hazırlandı");
            }
            else
            {
                var ogrenci = (Ogrenci)lstOgrenci.SelectedItem;
                pbTopluBelgeDurum.Value = index;
                MesayYaz(ogrenci.Adi + " " + ogrenci.Soyadi + " hazırlanıyor...");
                BelgeUretHelper.Yazici = yazici.PrintQueue;
                BelgeUretHelper.OgrenciBelgeUret(okul, ogrenci, sayi.Path);
                //Dispatcher.BeginInvoke(new Uret(BelgeUretHelper.OgrenciBelgeUret), okul, ogrenci, sayi.Path);
                //Thread.Sleep(3000);
                pbTopluBelgeDurum.Visibility = Visibility.Collapsed;
                MesayYaz(ogrenci.Adi + " " + ogrenci.Soyadi + " hazırlandı");
                index++;
            }
            btnBelgeUret.IsEnabled = true;
            btnIptal.Visibility = Visibility.Hidden;
        }

        private void FloatingWindowLoaded(object sender, RoutedEventArgs e)
        {
            var t = new Thread(() =>
            {
                MesayYaz("Okul listesi hazırlanıyor...");
                using (_repository = new Repository<Okul>())
                {
                    Dispatcher.BeginInvoke((Action)(() => lstOkul.ItemsSource = _repository.Liste()));
                }
                MesayYaz("Okul listesi hazırlandı");
            });
            t.Start();
        }

        private void OkulSecimDegisti(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems != null && e.AddedItems.Count > 0)
            {
                var okul = e.AddedItems[0] as Okul;
                if (okul != null)
                {
                    lstSinif.ItemsSource = okul.SinifListe;
                }
            }
        }
        private void TopluBelgeUretimFormKapandi(object sender, EventArgs e)
        {
            if (_repository == null || _repository.Session == null) return;
            _repository.Session.Flush();
            _repository.Session.Close();
            _repository.Session.Dispose();
        }

        private void SinifSecimDegisti(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems != null && e.AddedItems.Count > 0)
            {
                var sinif = e.AddedItems[0] as Sinif;
                if (sinif != null)
                {
                    lstOgrenci.ItemsSource = sinif.OgrenciListe.OrderBy(s => s.Adi);
                }
            }
            if (_folderList != null && _folderList.Count > 0) return;
            var folderService = new FolderService();
            _folderList = folderService.GetFolders(ConfigurationManager.AppSettings.Get(PathNameConstants.MainPath) + ConfigurationManager.AppSettings.Get(PathNameConstants.BelgeSablonPath));
            lstSayi.ItemsSource = _folderList;
        }

        private void btnIptal_Click(object sender, RoutedEventArgs e)
        {
            _iptalEdildi = true;
            btnIptal.Visibility = System.Windows.Visibility.Hidden;
        }

        private void OgrenciSecimDegisti(object sender, SelectionChangedEventArgs e)
        {
            if (_folderList != null && _folderList.Count > 0) return;
            var folderService = new FolderService();
            _folderList = folderService.GetFolders(ConfigurationManager.AppSettings.Get(PathNameConstants.MainPath) + ConfigurationManager.AppSettings.Get(PathNameConstants.BelgeSablonPath));
            lstSayi.ItemsSource = _folderList;
        }
    }
}
