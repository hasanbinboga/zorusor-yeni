using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Printing;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BilisselBeceriler.BelgeEditor.Library.Constants;
using BilisselBeceriler.BelgeEditor.Library.Enums;
using BilisselBeceriler.BelgeEditor.Library.Extensions;
using BilisselBeceriler.BelgeEditor.Library.Model;
using BilisselBeceriler.BelgeEditor.Library.Service;
using BilisselBeceriler.Entities.Web;
using Path = System.IO.Path;
using System.Windows.Controls.Primitives;
using System.Windows.Media.Effects;

namespace BilisselBeceriler.BelgeEditor.Library.Helpers
{
    public class BelgeUretHelper
    {
        public static string CocukFotoPath;
        public static string OkulLogoPath;
        public static string CizgiCocukPath;
        public static string CiktiPath;
        private static bool _tamamlandi;
        public static PrintQueue Yazici;
        private static Thickness _marj;
        public static bool Tamamlandi
        {
            get
            {
                return _tamamlandi;
            }
        }
        public static void OgrenciBelgeUret(Okul seciliOkul, Ogrenci seciliOgrenci, string sayiPath)
        {
            _tamamlandi = false;
            _marj = SayfaHelper.GetFromRegistry();
            var folderService = new FolderService();
            var yasGrupList = folderService.GetFolders(sayiPath);
            var sayi = Convert.ToInt32(sayiPath.Split('\\').Last().Split('-').First().Split(' ').Last());
            var tarih = DateTime.Now;//Convert.ToDateTime(sayiPath.Split('\\').Last().Split('-').Last());
            var yasGrup = yasGrupList.FirstOrDefault(s => s.Name == seciliOgrenci.Sinif.Yas.Adi);
            var cikti = seciliOkul.Url;

            if (yasGrup != null)
            {
                var belgeTurList = folderService.GetFolders(yasGrup.Path);
                foreach (var item in belgeTurList)
                {
                    var belgeAd = item.Name + "-" + cikti + "-" + seciliOgrenci.Adi + "-" + seciliOgrenci.Soyadi;
                    switch (item.Name)
                    {
                        case "Günlük Porjeksiyon Etkinliği":
                            var belgeList = folderService.GetFixedDoc(item.Path, Yazici.UserPrintTicket, _marj);
                            if (belgeList.Count == 1)
                            {
                                DergiOlustur(belgeList[0].BelgeContainer, seciliOgrenci, tarih, sayi);
                                PrintHelper.OnlyPrintFixedDocument(belgeList[0].BelgeContainer, belgeAd, Yazici, _marj);
                            }
                            else
                            {
                                var ogrBelge = belgeList.FirstOrDefault(s => s.Cinsiyet == seciliOgrenci.Cinsiyet.Id);
                                if (ogrBelge != null)
                                {
                                    DergiOlustur(ogrBelge.BelgeContainer, seciliOgrenci, tarih, sayi);
                                    PrintHelper.OnlyPrintFixedDocument(belgeList[0].BelgeContainer, belgeAd, Yazici, _marj);
                                }
                            }
                            break;
                        case "Kapak":

                            belgeList = folderService.GetFixedDoc(item.Path, Yazici.UserPrintTicket, new Thickness());
                            if (belgeList.Count == 1)
                            {
                                var folderEntity = belgeTurList.FirstOrDefault(s => s.Name.Contains("Kitap"));
                                if (folderEntity != null)
                                {
                                    DergiOlustur(belgeList[0].BelgeContainer, seciliOgrenci, tarih, sayi,
                                                 folderEntity.Path);
                                    KapakYazdir(belgeList[0].BelgeContainer, Yazici, belgeAd);
                                }
                            }
                            else
                            {
                                var ogrBelge = belgeList.FirstOrDefault(s => s.Cinsiyet == seciliOgrenci.Cinsiyet.Id);
                                if (ogrBelge != null)
                                {
                                    DergiOlustur(ogrBelge.BelgeContainer, seciliOgrenci, tarih, sayi);
                                    KapakYazdir(belgeList[0].BelgeContainer, Yazici, belgeAd);
                                }
                            }
                            break;
                        default:
                            belgeList = folderService.GetFixedDoc(item.Path, Yazici.UserPrintTicket, _marj);
                            if (belgeList.Count == 1)
                            {
                                DergiOlustur(belgeList[0].BelgeContainer, seciliOgrenci, tarih, sayi);
                                PrintHelper.OnlyPrintFixedDocument(belgeList[0].BelgeContainer, belgeAd, Yazici, _marj);
                            }
                            else
                            {
                                var ogrBelge = belgeList.FirstOrDefault(s => s.Cinsiyet == seciliOgrenci.Cinsiyet.Id);
                                if (ogrBelge != null)
                                {
                                    DergiOlustur(ogrBelge.BelgeContainer, seciliOgrenci, tarih, sayi);
                                    PrintHelper.OnlyPrintFixedDocument(belgeList[0].BelgeContainer, belgeAd, Yazici, _marj);
                                }
                            }
                            break;
                    }
                }
            }
            _tamamlandi = true;
        }
        private static void KapakYazdir(FixedDocument kapak, PrintQueue yazici, string belgeAd)
        {
            var buyukKapakMi = false;
            foreach (var page in kapak.Pages)
            {
                var fixedPage = page.Child;
                var belgeGrid = fixedPage.Children[0] as Grid;
                if (belgeGrid != null)
                {
                    if (belgeGrid.Width > belgeGrid.Height &&
                        yazici.UserPrintTicket.PageMediaSize.Width != null)
                    {
                        yazici = BuyukKapakYaziciAyarla(yazici);
                        buyukKapakMi = true;
                        if (yazici.UserPrintTicket.PageMediaSize.Height != null)
                            page.Child.Width = yazici.UserPrintTicket.PageMediaSize.Height.Value;
                        if (yazici.UserPrintTicket.PageMediaSize.Width != null)
                            page.Child.Height = yazici.UserPrintTicket.PageMediaSize.Width.Value;
                    }
                    else
                    {
                        if (yazici.UserPrintTicket.PageMediaSize.Width != null)
                            page.Child.Width = yazici.UserPrintTicket.PageMediaSize.Width.Value;
                        if (yazici.UserPrintTicket.PageMediaSize.Height != null)
                            page.Child.Height = yazici.UserPrintTicket.PageMediaSize.Height.Value;
                    }
                    page.Child.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
                    page.Child.Arrange(new Rect(new Point(0, 0), page.Child.DesiredSize));
                    page.Child.UpdateLayout();

                    #region Scale Page Content
                    double sc = ScaleHesapla(new Size(belgeGrid.Width, belgeGrid.Height), page.Child.DesiredSize);
                    var tg = new TransformGroup();
                    var sct = new ScaleTransform(sc, sc) { CenterX = 0, CenterY = 0 };
                    tg.Children.Add(sct);
                    if (page.Child.Width < page.Child.Height && (yazici.UserPrintTicket.PageOrientation == PageOrientation.Landscape ||
                        yazici.UserPrintTicket.PageOrientation == PageOrientation.ReverseLandscape))
                    {
                        var rt = new RotateTransform(-90);
                        tg.Children.Add(rt);
                    }
                    belgeGrid.Margin = _marj;
                    belgeGrid.LayoutTransform = null;
                    belgeGrid.LayoutTransform = tg;
                    belgeGrid.UpdateLayout();
                    #endregion
                }


            }
            if (buyukKapakMi)
            {


                PrintHelper.PrintFixedDocument(kapak, belgeAd, yazici);
                BuyukKapakYaziciGeriAl(yazici);
            }
            else
            {
                PrintHelper.OnlyPrintFixedDocument(kapak, belgeAd, yazici, new Thickness());
            }
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
        private static PrintQueue BuyukKapakYaziciAyarla(PrintQueue yazici)
        {
            yazici.UserPrintTicket.PageMediaSize = new PageMediaSize(yazici.UserPrintTicket.PageMediaSize.Height.Value,
                                                                                 yazici.UserPrintTicket.PageMediaSize.Width.Value * 2);
            yazici.UserPrintTicket.PageOrientation = PageOrientation.Landscape;
            return yazici;
        }
        private static PrintQueue BuyukKapakYaziciGeriAl(PrintQueue yazici)
        {
            yazici.UserPrintTicket.PageMediaSize = new PageMediaSize(   yazici.UserPrintTicket.PageMediaSize.Height.Value / 2,
                                                                    yazici.UserPrintTicket.PageMediaSize.Width.Value);
            yazici.UserPrintTicket.PageOrientation = PageOrientation.Portrait;
            return yazici;
        }
        private static string HataTopluMesaj(Exception ex)
        {
            var sb = new StringBuilder();
            sb.AppendLine("Son Mesaj=" + ex.Message + Environment.NewLine);
            Exception ie = ex.InnerException;
            int k = 0;
            while (ie != null)
            {
                k++;
                sb.AppendLine(k + ".Mesaj :" + ie.Message + Environment.NewLine);
                ie = ie.InnerException;
            }
            return sb.ToString();
        }
        #region Belgeler Olusturuluyor
        private static void DergiOlustur(FixedDocument belge, Ogrenci seciliOgrenci, DateTime yayinTarih, int sayi)
        {
            try
            {
                foreach (var item in belge.Pages)
                {
                    var seciliSayfa = (Grid)((Grid)item.Child.Children[0]).Children[0];
                    if (seciliSayfa.Tag.ToString() == TagNameConstants.OnKapakProcessor)
                    {
                        YayinBilgisiniUygula(seciliSayfa, sayi, yayinTarih, seciliOgrenci.Sinif.Okul.Id, seciliOgrenci.Sinif.Okul.Il.Id, seciliOgrenci.DogumTarih);
                        OkulBilgisiUygula(seciliSayfa, seciliOgrenci.Sinif.Okul, true);
                        CocukBilgisiUygula(seciliSayfa, seciliOgrenci, true);
                        seciliSayfa.UpdateLayout();
                    }
                    else
                    {
                        OkulBilgisiUygula(seciliSayfa, seciliOgrenci.Sinif.Okul, false);
                        CocukBilgisiUygula(seciliSayfa, seciliOgrenci, false);
                        BireyselResimUygula(seciliSayfa, seciliOgrenci);
                        seciliSayfa.UpdateLayout();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("DergiOlustur HATA: " + Environment.NewLine + HataTopluMesaj(ex));
            }
        }
        private static void DergiOlustur(FixedDocument belge, Ogrenci seciliOgrenci, DateTime yayinTarih, int sayi, string kitapPath)
        {
            try
            {
                foreach (var item in belge.Pages)
                {
                    var seciliSayfa = (Grid)((Grid)item.Child.Children[0]).Children[0];
                    if (seciliSayfa.Tag.ToString() == TagNameConstants.OnKapakProcessor)
                    {
                        YayinBilgisiniUygula(seciliSayfa, sayi, yayinTarih, seciliOgrenci.Sinif.Okul.Id, seciliOgrenci.Sinif.Okul.Il.Id, seciliOgrenci.DogumTarih);
                        OkulBilgisiUygula(seciliSayfa, seciliOgrenci.Sinif.Okul, true);
                        CocukBilgisiUygula(seciliSayfa, seciliOgrenci, true);
                        OrnekTestSayfasiUygula(seciliSayfa, kitapPath, seciliOgrenci);
                        seciliSayfa.UpdateLayout();
                    }
                    else
                    {
                        OkulBilgisiUygula(seciliSayfa, seciliOgrenci.Sinif.Okul, false);
                        CocukBilgisiUygula(seciliSayfa, seciliOgrenci, false);
                        BireyselResimUygula(seciliSayfa, seciliOgrenci);
                        seciliSayfa.UpdateLayout();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("DergiOlustur HATA: " + Environment.NewLine + HataTopluMesaj(ex));
            }
        }
        #endregion

        #region Bireysel Resimler Uygulaniyor
        public static ImageBrush StreamToImageBrush(OgrenciFotograf ogrFoto)
        {
            string fotoPath = CocukFotoPath + "\\" + ogrFoto.Id + ".png";
            if (File.Exists(fotoPath))
            {
                return new ImageBrush { ImageSource = new BitmapImage(new Uri(fotoPath, UriKind.RelativeOrAbsolute)), Stretch = Stretch.Uniform };
            }
            File.WriteAllBytes(fotoPath, ogrFoto.Resim);
            return new ImageBrush { ImageSource = new BitmapImage(new Uri(fotoPath, UriKind.RelativeOrAbsolute)), Stretch = Stretch.Uniform };
        }
        public static ImageBrush StreamToImageBrush(string fotoPath)
        {
            if (File.Exists(fotoPath))
            {
                return new ImageBrush { ImageSource = new BitmapImage(new Uri(fotoPath, UriKind.RelativeOrAbsolute)), Stretch = Stretch.Uniform };
            }
            return null;
        }
        public static ImageBrush StreamToImageBrush(Okul okul, bool kapakLogoMu)
        {
            string logoPath;
            if (kapakLogoMu)
            {
                logoPath = OkulLogoPath + @"\KapakLogo\" + okul.Id + ".png";
            }
            else
            {
                logoPath = OkulLogoPath + @"\SayfaLogo\" + okul.Id + ".png";
            }
            if (File.Exists(logoPath))
            {
                return new ImageBrush { ImageSource = new BitmapImage(new Uri(logoPath, UriKind.RelativeOrAbsolute)), Stretch = Stretch.Uniform };
            }
            File.WriteAllBytes(logoPath, kapakLogoMu ? okul.KapakLogo : okul.Logo);

            return new ImageBrush { ImageSource = new BitmapImage(new Uri(logoPath, UriKind.RelativeOrAbsolute)), Stretch = Stretch.Uniform };
        }
        private static int ResimIdAl(IList<OgrenciFotograf> fotolar)
        {
            var resim = fotolar.FirstOrDefault(s => s.FotoKategori.Id == 30); //Kapak Resmi
            if (resim != null)
            {
                return resim.Id;
            }
            resim = fotolar.FirstOrDefault(s => s.FotoKategori.Id == 27); //Cepheden Çekilmiş
            if (resim != null)
            {
                return resim.Id;
            }
            resim = fotolar.FirstOrDefault(s => s.FotoKategori.Id != 31); //Vesikalık Hariç
            if (resim != null)
            {
                return resim.Id;
            }
            return -1;
        }
        private static List<Ogrenci> ArkadaslariSec(Ogrenci seciliOgrenci)
        {
            var arkadaslar = seciliOgrenci.Sinif.OgrenciListe.Where(s => s.Id != seciliOgrenci.Id);
            var sonucInd = new List<int>(5);
            var arkCount = arkadaslar.Count();
            if (arkCount > 0)
            {
                if (arkCount > 5)
                {
                    short count = 0;
                    do
                    {
                        int arkInd;
                        do
                        {
                            arkInd = RandomHelper.HassasRastgeleSayi(9999, 0, arkCount - 1);
                        } while (sonucInd.Count(s => s == arkInd) > 0);
                        sonucInd.Add(arkInd);
                        count++;
                    } while (count < 5);

                    var sonuc = new List<Ogrenci>(5);
                    sonuc.AddRange(sonucInd.Select(item => arkadaslar.ElementAt(item)));
                    return sonuc;
                }
                return arkadaslar.ToList();
            }
            return null;
        }
        private static int CizgiCocukSec(int cizgiCocukCount)
        {
            if (cizgiCocukCount > 0)
            {
                return RandomHelper.HassasRastgeleSayi(9999, 0, cizgiCocukCount - 1);
            }
            return -1;
        }

        private static int BireyselKendiUygula(IEnumerable<Shape> bireyseller, Ogrenci seciliOgrenci)
        {
            var kendiId = ResimIdAl(seciliOgrenci.FotografListe);
            if (kendiId == -1)
            {
                return -1;
                //   MessageBox.Show(seciliOgrenci.Adi + " " + seciliOgrenci.Soyadi + " adlı öğrencinin hiç Fotoğrafı yok.");
            }

            foreach (var item in bireyseller)
            {
                item.Fill = StreamToImageBrush(seciliOgrenci.FotografListe.FirstOrDefault(s => s.Id == kendiId));
            }
            return kendiId;
        }
        private static void BireyselKendiDigerUygula(List<Shape> bireyseller, Ogrenci seciliOgrenci, int kendiId)
        {
            if (kendiId < 0) return;
            var digerResimler = seciliOgrenci.FotografListe.Where(s => s.FotoKategori.Id != 31 && s.Id != kendiId); //Vesikalık ve Kendi Resmi Hariç
            if (digerResimler.Count() == 0)
            {
                foreach (var item in bireyseller)
                {
                    item.Fill = StreamToImageBrush(seciliOgrenci.FotografListe.FirstOrDefault(s => s.Id == kendiId));
                }
            }
            else if (digerResimler.Count() == 1)
            {
                foreach (var item in bireyseller)
                {
                    item.Fill = StreamToImageBrush(seciliOgrenci.FotografListe.FirstOrDefault(s => s.Id == digerResimler.ElementAt(0).Id));
                }
            }
            else if (digerResimler.Count() == 2)
            {
                foreach (var item in bireyseller.Where(
                    s => s.Tag.ToString().Split('-').Last().EndsWith("1") ||
                         s.Tag.ToString().Split('-').Last().EndsWith("3")))
                {
                    item.Fill = StreamToImageBrush(seciliOgrenci.FotografListe.FirstOrDefault(s => s.Id == digerResimler.ElementAt(0).Id));
                }
                foreach (var item in bireyseller.Where(
                    s => s.Tag.ToString().Split('-').Last().EndsWith("2") ||
                         s.Tag.ToString().Split('-').Last().EndsWith("4")))
                {
                    item.Fill = StreamToImageBrush(seciliOgrenci.FotografListe.FirstOrDefault(s => s.Id == digerResimler.ElementAt(1).Id));
                }

            }
            else if (digerResimler.Count() == 3)
            {
                foreach (var item in bireyseller.Where(
                    s => s.Tag.ToString().Split('-').Last().EndsWith("1") ||
                         s.Tag.ToString().Split('-').Last().EndsWith("4")))
                {
                    item.Fill = StreamToImageBrush(seciliOgrenci.FotografListe.FirstOrDefault(s => s.Id == digerResimler.ElementAt(0).Id));
                }
                foreach (var item in bireyseller.Where(
                    s => s.Tag.ToString().Split('-').Last().EndsWith("2")))
                {
                    item.Fill = StreamToImageBrush(seciliOgrenci.FotografListe.FirstOrDefault(s => s.Id == digerResimler.ElementAt(1).Id));
                }
                foreach (var item in bireyseller.Where(
                    s => s.Tag.ToString().Split('-').Last().EndsWith("3")))
                {
                    item.Fill = StreamToImageBrush(seciliOgrenci.FotografListe.FirstOrDefault(s => s.Id == digerResimler.ElementAt(2).Id));
                }
            }
            else if (digerResimler.Count() >= 4)
            {
                for (var i = 0; i < 5; i++)
                {
                    foreach (var item in bireyseller.Where(
                        s => s.Tag.ToString().Split('-').Last().EndsWith((i + 1).ToString())))
                    {
                        item.Fill = StreamToImageBrush(seciliOgrenci.FotografListe.FirstOrDefault(s => s.Id == digerResimler.ElementAt(i).Id));
                    }
                }
            }
        }
        private static void BireyselArkadasUygula(List<Shape> bireyseller, Ogrenci seciliOgrenci)
        {
            if (ResimIdAl(seciliOgrenci.FotografListe) == -1) return;
            var arkadaslar = ArkadaslariSec(seciliOgrenci);
            if (arkadaslar == null)
            {
                BireyselKendiUygula(bireyseller, seciliOgrenci);
            }
            else if (arkadaslar.Count < 5)
            {
                if (arkadaslar.Count == 1)
                {
                    int kendiId = 0;
                    for (int i = 1; i < 6; i++)
                    {
                        kendiId = BireyselKendiUygula(bireyseller.
                            Where(s => s.Tag.ToString().ToLower() ==
                                ("Bireysel-Arkadasi" + i).ToLower()).ToList(),
                                arkadaslar[0]);

                    }
                    for (int i = 1; i < 6; i++)
                    {
                        BireyselKendiDigerUygula(bireyseller.
                            Where(s => s.Tag.ToString().Contains(
                                "Bireysel-Arkadasi" + i + "-Diger")).ToList(),
                                arkadaslar[0], kendiId);
                    }
                }
                else if (arkadaslar.Count == 2)
                {
                    int kendiId = 0;
                    for (int i = 1; i < 6; i += 2)
                    {
                        kendiId = BireyselKendiUygula(bireyseller.
                            Where(s => s.Tag.ToString().ToLower() ==
                                ("Bireysel-Arkadasi" + i).ToLower()).ToList(),
                                arkadaslar[0]);

                    }
                    for (int i = 1; i < 6; i += 2)
                    {
                        BireyselKendiDigerUygula(bireyseller.
                            Where(s => s.Tag.ToString().Contains(
                                "Bireysel-Arkadasi" + i + "-Diger")).ToList(),
                                arkadaslar[0], kendiId);
                    }

                    for (int i = 2; i < 6; i += 2)
                    {
                        kendiId = BireyselKendiUygula(bireyseller.
                            Where(s => s.Tag.ToString().ToLower() ==
                                ("Bireysel-Arkadasi" + i).ToLower()).ToList(),
                                arkadaslar[1]);

                    }
                    for (int i = 2; i < 6; i += 2)
                    {
                        BireyselKendiDigerUygula(bireyseller.
                            Where(s => s.Tag.ToString().Contains(
                                "Bireysel-Arkadasi" + i + "-Diger")).ToList(),
                                arkadaslar[1], kendiId);
                    }
                }
                else if (arkadaslar.Count == 3)
                {
                    int kendiId = BireyselKendiUygula(bireyseller.
                                                          Where(s => s.Tag.ToString().ToLower() ==
                                                                     ("Bireysel-Arkadasi1").ToLower()).ToList(),
                                                      arkadaslar[0]);
                    BireyselKendiDigerUygula(bireyseller.
                            Where(s => s.Tag.ToString().Contains(
                                "Bireysel-Arkadasi1-Diger")).ToList(),
                                arkadaslar[0], kendiId);
                    kendiId = BireyselKendiUygula(bireyseller.
                            Where(s => s.Tag.ToString().ToLower() ==
                                ("Bireysel-Arkadasi2").ToLower()).ToList(),
                                arkadaslar[1]);
                    BireyselKendiDigerUygula(bireyseller.
                            Where(s => s.Tag.ToString().Contains(
                                "Bireysel-Arkadasi2-Diger")).ToList(),
                                arkadaslar[1], kendiId);
                    kendiId = BireyselKendiUygula(bireyseller.
                            Where(s => s.Tag.ToString().ToLower() ==
                                ("Bireysel-Arkadasi3").ToLower()).ToList(),
                                arkadaslar[2]);
                    BireyselKendiDigerUygula(bireyseller.
                            Where(s => s.Tag.ToString().Contains(
                                "Bireysel-Arkadasi3-Diger")).ToList(),
                                arkadaslar[2], kendiId);
                    kendiId = BireyselKendiUygula(bireyseller.
                            Where(s => s.Tag.ToString().ToLower() ==
                                ("Bireysel-Arkadasi4").ToLower()).ToList(),
                                arkadaslar[0]);
                    BireyselKendiDigerUygula(bireyseller.
                            Where(s => s.Tag.ToString().Contains(
                                "Bireysel-Arkadasi4-Diger")).ToList(),
                                arkadaslar[0], kendiId);
                    kendiId = BireyselKendiUygula(bireyseller.
                            Where(s => s.Tag.ToString().ToLower() ==
                                ("Bireysel-Arkadasi5").ToLower()).ToList(),
                                arkadaslar[1]);
                    BireyselKendiDigerUygula(bireyseller.
                            Where(s => s.Tag.ToString().Contains(
                                "Bireysel-Arkadasi5-Diger")).ToList(),
                                arkadaslar[1], kendiId);
                }
                else if (arkadaslar.Count == 4)
                {
                    int kendiId = BireyselKendiUygula(bireyseller.
                                                          Where(s => s.Tag.ToString().ToLower() ==
                                                                     ("Bireysel-Arkadasi1").ToLower()).ToList(),
                                                      arkadaslar[0]);
                    BireyselKendiDigerUygula(bireyseller.
                            Where(s => s.Tag.ToString().Contains(
                                "Bireysel-Arkadasi1-Diger")).ToList(),
                                arkadaslar[0], kendiId);
                    kendiId = BireyselKendiUygula(bireyseller.
                            Where(s => s.Tag.ToString().ToLower() ==
                                ("Bireysel-Arkadasi2").ToLower()).ToList(),
                                arkadaslar[1]);
                    BireyselKendiDigerUygula(bireyseller.
                            Where(s => s.Tag.ToString().Contains(
                                "Bireysel-Arkadasi2-Diger")).ToList(),
                                arkadaslar[1], kendiId);
                    kendiId = BireyselKendiUygula(bireyseller.
                            Where(s => s.Tag.ToString().ToLower() ==
                                ("Bireysel-Arkadasi3").ToLower()).ToList(),
                                arkadaslar[2]);
                    BireyselKendiDigerUygula(bireyseller.
                            Where(s => s.Tag.ToString().Contains(
                                "Bireysel-Arkadasi3-Diger")).ToList(),
                                arkadaslar[2], kendiId);
                    kendiId = BireyselKendiUygula(bireyseller.
                            Where(s => s.Tag.ToString().ToLower() ==
                                ("Bireysel-Arkadasi4").ToLower()).ToList(),
                                arkadaslar[3]);
                    BireyselKendiDigerUygula(bireyseller.
                            Where(s => s.Tag.ToString().Contains(
                                "Bireysel-Arkadasi4-Diger")).ToList(),
                                arkadaslar[3], kendiId);
                    kendiId = BireyselKendiUygula(bireyseller.
                            Where(s => s.Tag.ToString().ToLower() ==
                                ("Bireysel-Arkadasi5").ToLower()).ToList(),
                                arkadaslar[0]);
                    BireyselKendiDigerUygula(bireyseller.
                            Where(s => s.Tag.ToString().Contains(
                                "Bireysel-Arkadasi5-Diger")).ToList(),
                                arkadaslar[0], kendiId);
                }
            }
            else
            {
                int kendiId = 0;
                for (int i = 1; i < 6; i++)
                {
                    kendiId = BireyselKendiUygula(bireyseller.
                        Where(s => s.Tag.ToString().ToLower() ==
                            ("Bireysel-Arkadasi" + i).ToLower()).ToList(),
                            arkadaslar[i - 1]);

                }
                for (int i = 1; i < 6; i++)
                {
                    BireyselKendiDigerUygula(bireyseller.
                        Where(s => s.Tag.ToString().Contains(
                            "Bireysel-Arkadasi" + i + "-Diger")).ToList(),
                            arkadaslar[i - 1], kendiId);
                }
            }
        }
        private static void BireyselCizgiUygula(IEnumerable<Shape> bireyseller)
        {
            var cizgiCocuklar = new FolderService().GetFiles(CizgiCocukPath, "*.png");
            var count = cizgiCocuklar.Count();
            foreach (var item in bireyseller)
            {
                item.Fill = new ImageBrush
                                {
                                    ImageSource = new BitmapImage(
                                        new Uri(
                                            cizgiCocuklar.ElementAt(CizgiCocukSec(count)).Path,
                                            UriKind.RelativeOrAbsolute)),
                                    Stretch = Stretch.Uniform
                                };
            }
        }
        private static void BireyselResimUygula(DependencyObject seciliSayfa, Ogrenci seciliOgrenci)
        {
            var kendiId = BireyselKendiUygula(ExtensionService
                                    .FindAllChildByTag<Shape>
                                    (seciliSayfa, "Bireysel-Kendi"),
                                seciliOgrenci);
            BireyselKendiDigerUygula(ExtensionService
                                        .FindAllChildByTagContains<Shape>
                                        (seciliSayfa, "Bireysel-Kendi-Diger"),
                                      seciliOgrenci, kendiId);
            BireyselArkadasUygula(ExtensionService
                                        .FindAllChildByTagContains<Shape>
                                        (seciliSayfa, "Bireysel-Arkadasi"),
                                    seciliOgrenci);
            BireyselCizgiUygula(ExtensionService
                                        .FindAllChildByTagContains<Shape>
                                        (seciliSayfa, "Bireysel-Cizgi"));
        }
        #endregion
        #region Cocuk, Okul ve Yayin Bilgileri Uygulaniyor
        private static void CocukBilgisiUygula(DependencyObject sayfa, Ogrenci seciliOgrenci, bool onKapakMi)
        {
            try
            {
                if (sayfa != null)
                {
                    if (onKapakMi)
                    {
                        var cocukAd = ExtensionService.FindChildByTag<TextBlock>(sayfa, TagNameConstants.txtCocukAd);
                        if (cocukAd != null) cocukAd.Text = seciliOgrenci.Adi + " " + seciliOgrenci.Soyadi;
                        var dogumTarih = ExtensionService.FindChildByTag<TextBlock>(sayfa, TagNameConstants.txtDogumTarih);
                        if (dogumTarih != null) dogumTarih.Text = seciliOgrenci.DogumTarih.ToShortDateString();
                        var cocukFoto = ExtensionService.FindChildByTag<Border>(sayfa, TagNameConstants.brFoto);
                        var arkaSayfaCocukFoto = ExtensionService.FindChildByTag<Border>(sayfa, TagNameConstants.brSinifResimKendi);
                        var resimListe = seciliOgrenci.FotografListe;
                        int resimIndeks = RandomHelper.HassasRastgeleSayi(9000, 0, resimListe.Count() - 1);
                        var fotoKayit = resimListe.ElementAt(resimIndeks);//Kapak Fotoğrafı
                        if (fotoKayit != null && cocukFoto != null)
                        {
                            cocukFoto.Background = StreamToImageBrush(fotoKayit);
                        }
                        #region Arka Sayfa Islemleri
                        if (fotoKayit != null && arkaSayfaCocukFoto != null)
                        {
                            arkaSayfaCocukFoto.Background = StreamToImageBrush(fotoKayit);
                        }
                        //var arkaKapakcocukAd = ExtensionService.FindChildByTag<TextBlock>(sayfa, TagNameConstants.txbSinifResimKendiAd);
                        //if (arkaKapakcocukAd != null) arkaKapakcocukAd.Text = seciliOgrenci.Adi + " " + seciliOgrenci.Soyadi +
                        //                                                      " \n" + seciliOgrenci.DogumTarih.ToShortDateString();
                        var sinifGrid = ExtensionService.FindChildByTag<UniformGrid>(sayfa, TagNameConstants.ugrSinifArkadaslar);
                        if (sinifGrid != null)
                        {
                            sinifGrid.Children.Clear();
                            foreach (var seciliArkadas in seciliOgrenci.Sinif.OgrenciListe.Where(s => s.Id != seciliOgrenci.Id))
                            {
                                sinifGrid.Children.Add(SinifArkadasOlustur(seciliArkadas));
                            }
                        }
                        #endregion
                    }
                    else
                    {
                        var adSoyad = ExtensionService.FindChildByTag<Label>(sayfa, TagNameConstants.AntetAdSoyad);
                        if (adSoyad != null) adSoyad.Content = seciliOgrenci.Adi + " " + seciliOgrenci.Soyadi;
                        var ogrDogumTarih = ExtensionService.FindChildByTag<Label>(sayfa, TagNameConstants.AntetDogumTarih);
                        if (ogrDogumTarih != null) ogrDogumTarih.Content = seciliOgrenci.DogumTarih.ToShortDateString();
                        var cocukFoto = ExtensionService.FindChildByTag<Border>(sayfa, TagNameConstants.AntetFoto);
                        var fotoKayit = seciliOgrenci.FotografListe.FirstOrDefault(s => s.FotoKategori.Id == 31);//Vesikalık Fotoğrafı
                        if (fotoKayit != null && cocukFoto != null)
                        {
                            cocukFoto.Background = StreamToImageBrush(fotoKayit);
                        }
                        else if (cocukFoto != null && cocukFoto.Background.GetType() != typeof(ImageBrush))
                        {
                            cocukFoto.Visibility = Visibility.Hidden;
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("CocukBilgisiUygula");
                throw new Exception(MethodBase.GetCurrentMethod().Name, ex);
            }
        }
        private static void OkulBilgisiUygula(Grid sayfa, Okul seciliOkul, bool onKapakMi)
        {
            try
            {
                if (sayfa != null)
                {
                    if (onKapakMi)
                    {
                        var bilgi = ExtensionService.FindChildByTag<TextBlock>(sayfa, TagNameConstants.OkulBilgi);
                        if (bilgi != null) bilgi.Text = seciliOkul.Adi + " Web Adresi: " + seciliOkul.WebAdresi + " E-Posta Adresi: " + seciliOkul.EPostaAdresi;

                        var okulOzel = ExtensionService.FindChildByTag<TextBlock>(sayfa, TagNameConstants.OkulOzel);
                        if (okulOzel != null) okulOzel.Text = okulOzel.Text.Replace(TagNameConstants.OkulOzel, seciliOkul.Adi);

                        var okulLogo = ExtensionService.FindChildByTag<Border>(sayfa, TagNameConstants.OkulLogo);
                        if (okulLogo != null) okulLogo.Background = StreamToImageBrush(seciliOkul, true);
                    }
                    else
                    {
                        var antetLogo = ExtensionService.FindChildByTag<Border>(sayfa, TagNameConstants.AntetLogo);
                        if (antetLogo != null && antetLogo.Background.GetType() != typeof(ImageBrush))
                        {
                            antetLogo.Background = StreamToImageBrush(seciliOkul, false);
                        }
                        else if (antetLogo != null)
                        {
                            antetLogo.Visibility = Visibility.Hidden;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("OkulBilgisiUygula");
                throw new Exception(MethodBase.GetCurrentMethod().Name, ex);
            }
        }
        private static void YayinBilgisiniUygula(Grid kapak, int sayi, DateTime tarih, int okulId, int ilId, DateTime ogrDogumTarih)
        {
            try
            {
                if (kapak != null)
                {
                    var yayinTarih = ExtensionService.FindChildByTag<TextBlock>(kapak, TagNameConstants.txbYayinTarih);
                    if (yayinTarih != null) yayinTarih.Text = tarih.ToShortDateString();
                    var yayinSayi = ExtensionService.FindChildByTag<TextBlock>(kapak, TagNameConstants.txbDergiSayi);
                    if (yayinSayi != null) yayinSayi.Text = sayi.ToString();
                    var yayinSeriNo = ExtensionService.FindChildByTag<TextBlock>(kapak, TagNameConstants.txbSeriNo);
                    if ((yayinSeriNo != null) && (yayinSayi != null))
                        yayinSeriNo.Text = okulId.ToString() + ilId.ToString() + ogrDogumTarih.Day.ToString() +
                                           ogrDogumTarih.Month.ToString() + ogrDogumTarih.Year.ToString() + yayinSayi.Text;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("YayinBilgisiniUygula HATA");
                throw new Exception(MethodBase.GetCurrentMethod().Name, ex);
            }
        }
        private static void OrnekTestSayfasiUygula(Grid kapak, string kitapPath, Ogrenci seciliOgrenci)
        {
            var liste = new FolderService().GetBelge(kitapPath);
            foreach (var item in liste)
            {
                var g = (FixedDocument)XamlReader.Load(File.OpenRead(item.Path));
                var ilkSayfa = g.Pages.FirstOrDefault();
                if (ilkSayfa != null)
                {
                    var grid = ilkSayfa.Child.Children[0] as Grid;
                    if (grid != null)
                    {
                        grid.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
                        grid.Arrange(new Rect(new Point(0, 0), new Point(grid.DesiredSize.Width, grid.DesiredSize.Height)));
                        var gridParent = grid.Parent as FixedPage;
                        CocukBilgisiUygula(grid, seciliOgrenci, false);
                        OkulBilgisiUygula(grid, seciliOgrenci.Sinif.Okul, false);
                        if (gridParent != null) gridParent.Children.Remove(grid);
                    }

                    var ornekSayfa = ExtensionService.FindChildByTag<Border>(kapak, TagNameConstants.brOrnekSayfa);
                    if (ornekSayfa != null)
                    {
                        var visBrush = new VisualBrush(grid) { Stretch = Stretch.Uniform, TileMode = TileMode.None };
                        ornekSayfa.Background = visBrush;
                    }

                }

            }
        }
        private static Grid SinifArkadasOlustur(Ogrenci arkadas)
        {
            var result = new Grid{Margin = new Thickness(5)};
            var border = new Border{Effect = new DropShadowEffect{BlurRadius = 17, ShadowDepth = 4}};
            //var text = new TextBlock
            //               {
            //                   Height = 23,
            //                   VerticalAlignment = VerticalAlignment.Bottom,
            //                   Background = new SolidColorBrush(Color.FromArgb(153, 255, 255, 255)),
            //                   HorizontalAlignment = HorizontalAlignment.Center,
            //                   TextWrapping = TextWrapping.Wrap,
            //                   TextAlignment = TextAlignment.Center,
            //                   FontSize = 9.333,
            //                   FontFamily = new FontFamily("Arial"),
            //                   Text = arkadas.Adi+" "+ arkadas.Soyadi+"\n"+arkadas.DogumTarih.ToShortDateString(),
            //               };
            
            if (arkadas.FotografListe.Count > 0)
            {
                if (arkadas.FotografListe.Any(s => s.FotoKategori.Id == (int)FotografTip.Vesikalik))
                {
                    var foto =
                        arkadas.FotografListe.
                                        First(s => s.FotoKategori.Id ==
                                                   (int)FotografTip.Vesikalik);
                    border.Background = StreamToImageBrush(foto);
                }
                else if (arkadas.FotografListe.Any(s => s.FotoKategori.Id == (int)FotografTip.KapakFotograf))
                {
                    var foto =
                        arkadas.FotografListe.
                                        First(s => s.FotoKategori.Id ==
                                                   (int)FotografTip.KapakFotograf);
                    border.Background = StreamToImageBrush(foto);
                }
                else if (arkadas.FotografListe.Any(s => s.FotoKategori.Id == (int)FotografTip.CephedenCekilmis))
                {
                    var foto =
                        arkadas.FotografListe.
                                        First(s => s.FotoKategori.Id ==
                                                   (int)FotografTip.CephedenCekilmis);
                    border.Background = StreamToImageBrush(foto);
                }
                else
                {
                    var foto = arkadas.FotografListe.FirstOrDefault();
                    border.Background = StreamToImageBrush(foto);
                }
            }
            else
            {
                border.Background = new SolidColorBrush(Color.FromArgb(153, 255, 255, 255));
            }
            result.Children.Add(border);
            //result.Children.Add(text);
            return result;
        }
        #endregion
    }
}
