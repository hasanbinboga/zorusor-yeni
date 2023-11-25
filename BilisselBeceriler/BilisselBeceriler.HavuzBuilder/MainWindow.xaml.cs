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
using System.Windows.Media.Effects;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;
using System.IO;
using CH.Combinations;

namespace BilisselBeceriler.HavuzBuilder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string TemelParcalarKlasorAd = ConfigurationManager.AppSettings.Get("TemelParcalarKlasorAd");
        string DigerParcalarKlasorAd = ConfigurationManager.AppSettings.Get("DigerParcalarKlasorAd");
        string TemelParcalarKlasorMesaj = ConfigurationManager.AppSettings.Get("TemelParcalarKlasorMesaj");
        string ResimYol = ConfigurationManager.AppSettings.Get("ResimYol");
        string HavuzYol = ConfigurationManager.AppSettings.Get("HavuzYol");
        string KlasorBulunamadiMesaj = ConfigurationManager.AppSettings.Get("KlasorBulunamadiMesaj");
        string KlasorFigurIceremezMesaj = ConfigurationManager.AppSettings.Get("KlasorFigurIceremezMesaj");
        string KlasorKlasorIceremezMesaj = ConfigurationManager.AppSettings.Get("KlasorKlasorIceremezMesaj");
        string KlasordeFigurBulunamadi = ConfigurationManager.AppSettings.Get("KlasordeFigurBulunamadi");
        string FigurUzantiListe = ConfigurationManager.AppSettings.Get("FigurUzantiListe");
        string Uzanti = "*.png";
        public MainWindow()
        {
            InitializeComponent();
        }

        private string KlasorAdGetir(string KlasorYol)
        {
            return KlasorYol.Substring(
                   KlasorYol.LastIndexOf('\\') + 1,
                   KlasorYol.Length - KlasorYol.LastIndexOf('\\') - 1);
        }

        private string DosyaAdGetir(string DosyaYol, bool EklentiDahilMi = false)
        {
            FileInfo fi = new FileInfo(DosyaYol);
            if (EklentiDahilMi)
                return fi.Name;
            else
            {
                string[] Temp = fi.Name.Split('.');
                return Temp[0];
            }
        }
        string ParcaKontrol(string HavuzKlasor, string TemelParcaAd)
        {
            StringBuilder sb = new StringBuilder();


            string[] ParcaListe;

            //Figur var mi?
            string[] TempListe = Directory.GetFiles(HavuzKlasor + "\\" + TemelParcaAd, Uzanti).
                Where(s => File.GetAttributes(s) !=
                    (FileAttributes.Hidden | FileAttributes.Archive)).ToArray();
            //Directory.GetFiles(HavuzKlasor + "\\" + TemelParcaAd, Uzanti);
            if (TempListe.Count() > 0)
            {
                foreach (var item in TempListe)
                {
                    sb.AppendLine(string.Format(KlasorFigurIceremezMesaj, TemelParcaAd, DosyaAdGetir(item)));
                }
            }

            //Parca Varmi Kontrol
            ParcaListe = Directory.GetDirectories(HavuzKlasor + "\\" + TemelParcaAd);
            if (ParcaListe.Count() <= 0)
            {
                sb.AppendLine(string.Format(KlasorBulunamadiMesaj, TemelParcaAd, "Parça"));
            }
            else
            {
                //Parcalar klasorunde dosya varmı kontrol
                foreach (var item in ParcaListe)
                {

                    TempListe = Directory.GetFiles(item, Uzanti).
                Where(s => File.GetAttributes(s) !=
                    (FileAttributes.Hidden | FileAttributes.Archive)).ToArray();
                    if (TempListe.Count() > 0)
                    {
                        foreach (var oge in TempListe)
                        {
                            sb.AppendLine(String.Format(KlasorFigurIceremezMesaj, KlasorAdGetir(item), DosyaAdGetir(oge)));
                        }
                    }
                }
                //Her bir parca icin varyans var mi kontrolü
                foreach (var item in ParcaListe)
                {
                    var VaryansListe = Directory.GetDirectories(item);
                    if (VaryansListe.Count() <= 0)
                    {
                        sb.AppendLine(string.Format(KlasorBulunamadiMesaj, KlasorAdGetir(item), "Varyans"));
                    }
                    else
                    {
                        //figurler klasor olamaz kontrolü
                        foreach (var oge in VaryansListe)
                        {
                            if (Directory.GetFiles(oge, Uzanti).
                Where(s => File.GetAttributes(s) !=
                    (FileAttributes.Hidden | FileAttributes.Archive)).Count() <= 0)
                            {
                                sb.AppendLine(string.Format(KlasordeFigurBulunamadi, KlasorAdGetir(oge)));
                            }
                            TempListe = Directory.GetDirectories(oge);
                            if (TempListe.Count() > 0)
                            {
                                foreach (var satir in TempListe)
                                {
                                    sb.AppendLine(string.Format(KlasorKlasorIceremezMesaj, KlasorAdGetir(oge), DosyaAdGetir(satir)));
                                }
                            }
                        }
                    }
                }
            }
            return sb.ToString();
        }
        void HavuzYapiKontrol(string HavuzKlasor)
        {
            StringBuilder sb = new StringBuilder();
            lbKontrolSonucListe.Items.Clear();
            try
            {
                string Temp;
                string[] TempListe;
                TempListe = Directory.GetDirectories(tbHavuzKonum.Text);
                Temp = TempListe.FirstOrDefault(x => new DirectoryInfo(x).Name.ToLower() == TemelParcalarKlasorAd.ToLower());
                if (Temp == null)
                {
                    sb.AppendLine(string.Format(KlasorBulunamadiMesaj, KlasorAdGetir(HavuzKlasor), TemelParcalarKlasorAd));
                }
                else
                {
                    sb.AppendLine(ParcaKontrol(tbHavuzKonum.Text, TemelParcalarKlasorAd));
                }

                Temp = TempListe.FirstOrDefault(x => new DirectoryInfo(x).Name.ToLower() == DigerParcalarKlasorAd.ToLower());
                if (Temp != null)
                {
                    sb.AppendLine(ParcaKontrol(tbHavuzKonum.Text, DigerParcalarKlasorAd));
                }

                string[] MesajListe = sb.ToString().Split(new string[1] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                if (MesajListe.Length > 0)
                {
                    for (int i = 0; i < MesajListe.Length; i++)
                    {
                        lbKontrolSonucListe.Items.Add(MesajListe[i]);
                    }
                }
                else
                {
                    HavuzOlustur();
                }

            }
            catch (Exception ex)
            {
                sb.AppendLine(ex.Message);
                if (ex.InnerException != null)
                    sb.AppendLine(ex.InnerException.Message);
            }
        }

        private void HavuzKonumTiklandi(object sender, RoutedEventArgs e)
        {
            using (System.Windows.Forms.FolderBrowserDialog Dialog = new System.Windows.Forms.FolderBrowserDialog())
            {
                if (tbHavuzKonum.Text.Length > 0)
                    Dialog.SelectedPath = tbHavuzKonum.Text;

                if (Dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    tbHavuzKonum.Text = Dialog.SelectedPath;
                    HavuzYapiKontrol(tbHavuzKonum.Text);
                }
                else
                {
                    tbHavuzKonum.Text = string.Empty;
                    MessageBox.Show(ConfigurationManager.AppSettings.Get("HavuzKonumSecimMesaj"));
                }
            }
        }

        Grid XamlOlustur(string HavuzAd, string Prefix, string KlasorYol, string KapsulAd)
        {
            Grid Kapsul = new Grid();
            Kapsul.Name = KapsulAd;
            Kapsul.Width = 200;
            Kapsul.Height = 200;
            ListeyeMesajEkle(KapsulAd + " Grid Oluşturuldu");
            foreach (string ParcaYol in Directory.GetDirectories(KlasorYol))
            {
                Grid ParcaGrid = new Grid();
                ParcaGrid.Name = Prefix + "_" + KlasorAdGetir(ParcaYol);
                ParcaGrid.Width = 200;
                ParcaGrid.Height = 200;
                ListeyeMesajEkle(ParcaGrid.Name + " Grid Oluşturuldu");
                foreach (var VaryansYol in Directory.GetDirectories(ParcaYol))
                {
                    Grid VaryansGrid = new Grid();
                    VaryansGrid.Name = Prefix + "_" + KlasorAdGetir(VaryansYol);
                    VaryansGrid.Width = 200;
                    VaryansGrid.Height = 200;
                    ListeyeMesajEkle(VaryansGrid.Name + " Grid Oluşturuldu");
                    foreach (string f in Directory.GetFiles(VaryansYol, Uzanti).
                Where(s => File.GetAttributes(s) !=
                    (FileAttributes.Hidden | FileAttributes.Archive)))
                    {

                        string HedefYol = ResimYol + "\\" + HavuzAd + "\\" + KapsulAd + "\\" + DosyaAdGetir(f, true);
                        FileInfo Info = new FileInfo(HedefYol);
                        //if (Info.Attributes == FileAttributes.Hidden)
                        //    continue;
                        if (Info.Exists == false)
                        {
                            File.Copy(f, HedefYol);
                        }
                        Image Figur = new Image();
                        Figur.Width = 200;
                        Figur.Height = 200;
                        Figur.Stretch = Stretch.Fill;
                        Figur.Source = new BitmapImage(new Uri(HedefYol));
                        VaryansGrid.Children.Add(Figur);
                        ListeyeMesajEkle(DosyaAdGetir(f, false) + " Figür Oluşturuldu");
                    }
                    ParcaGrid.Children.Add(VaryansGrid);
                }
                Kapsul.Children.Add(ParcaGrid);
            }
            return Kapsul;
        }
        Grid XamlOlustur(string HavuzAd, string Prefix, string KlasorYol, string KapsulAd, int ParcaAdet, bool Bireysel, int[] FigurIndeksleri, bool siralamaMi)
        {
            try
            {
                Grid Kapsul = new Grid();
                Kapsul.Name = KapsulAd;
                Kapsul.Width = 200;
                Kapsul.Height = 200;
                ListeyeMesajEkle(KapsulAd + " Grid Oluşturuldu");
                bool CocukParcaOlustu = false;
                string ParcaYol = Directory.GetDirectories(KlasorYol)[0];
                //(Bireysel == true ? ParcaAdet-1 : ParcaAdet)
                for (int i = 0; i < ParcaAdet; i++)
                {
                    if (siralamaMi == true && Bireysel == true && CocukParcaOlustu == false)
                    {
                        Kapsul.Children.Add(SiralamaBireyselParcaOlustur(ParcaAdet));
                        CocukParcaOlustu = true;
                    }
                    Grid ParcaGrid = new Grid();
                    ParcaGrid.Name = Prefix + "_" + KlasorAdGetir(ParcaYol) + i;
                    ParcaGrid.Width = 200;
                    ParcaGrid.Height = 200;
                    ListeyeMesajEkle(ParcaGrid.Name + " Grid Oluşturuldu");
                    foreach (var VaryansYol in Directory.GetDirectories(ParcaYol))
                    {
                        Grid VaryansGrid = new Grid();
                        VaryansGrid.Name = Prefix + "_" + KlasorAdGetir(VaryansYol) + i;
                        VaryansGrid.Width = 200;
                        VaryansGrid.Height = 200;
                        ListeyeMesajEkle(VaryansGrid.Name + " Grid Oluşturuldu");
                        string[] dosyalar = 
                            Directory.GetFiles(VaryansYol, Uzanti).
                            Where(s => File.GetAttributes(s) != 
                                (FileAttributes.Hidden | FileAttributes.Archive)).ToArray();
                        foreach (int f in FigurIndeksleri)
                        {
                            string seciliDosya = dosyalar[f];
                            string HedefYol = ResimYol + "\\" + HavuzAd + "\\" + KapsulAd + "\\" + DosyaAdGetir(seciliDosya, true);
                            FileInfo Info = new FileInfo(HedefYol);
                            if (Info.Exists == false)
                            {
                                File.Copy(seciliDosya, HedefYol);
                            }
                            Canvas yeniFigur = null;
                            if (siralamaMi == false)
                            {
                                yeniFigur = FigurUret(HedefYol, ParcaAdet, i, Bireysel);
                            }
                            else
                            {
                                yeniFigur = SiralamaIcinFigurUret(HedefYol, ParcaAdet, i, Bireysel);
                            }

                            if (yeniFigur.Children.Count > 0)
                            {
                                VaryansGrid.Children.Add(yeniFigur);
                            }

                            ListeyeMesajEkle(DosyaAdGetir(seciliDosya, false) + " Figür Oluşturuldu");
                        }
                        if (VaryansGrid.Children.Count > 0)
                        {
                            ParcaGrid.Children.Add(VaryansGrid);
                        }
                    }
                    if (ParcaGrid.Children.Count > 0)
                    {
                        Kapsul.Children.Add(ParcaGrid);
                    }
                }
                return Kapsul;
            }
            catch (Exception ec)
            {
                MessageBox.Show("Dosyalardaki Resim sayıları eşleşmediği için havuz oluşturulamadı.\n\rEğer Varyanslardaki dosya sayıları eşit ise dosya uzantılarının (PNG) olduğundan emin olun.", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
                throw ec;
            }

        }
        Grid BireyselParcaOlustur(int ParcaAdet)
        {

            Grid ParcaGrid = new Grid();
            ParcaGrid.Name = "Cocuk";
            ParcaGrid.Width = 200;
            ParcaGrid.Height = 200;
            ListeyeMesajEkle(ParcaGrid.Name + " Grid Oluşturuldu");
            Grid VaryansGrid = new Grid();
            VaryansGrid.Name = "CocukVar1";
            VaryansGrid.Width = 200;
            VaryansGrid.Height = 200;
            ListeyeMesajEkle(VaryansGrid.Name + " Grid Oluşturuldu");

            Canvas Figur = new Canvas();
            Image cocukFoto = new Image();
            cocukFoto.Tag = "Foto";
            Canvas.SetLeft(cocukFoto, 17.487);
            Canvas.SetTop(cocukFoto, 12.666);
            cocukFoto.Height = 68;
            cocukFoto.Width = 61.026;
            cocukFoto.Source = new BitmapImage(new Uri(@"C:\HavuzProjesi\Resimler\CocukFotograf\28.png"));
            Figur.Children.Add(DaireOlustur(95, 95, null));
            Figur.Children.Add(cocukFoto);

            switch (ParcaAdet)
            {
                case 2:
                    Figur.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                    Figur.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                    Figur.Margin = new Thickness(0, 5, 0, 0);
                    Figur.Width = 95;
                    Figur.Height = 95;
                    break;
                case 3:
                    Figur.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                    Figur.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                    Figur.Margin = new Thickness(0, 17, 0, 0);
                    Figur.Width = 95;
                    Figur.Height = 95;
                    break;
                case 4:
                    Figur.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                    Figur.VerticalAlignment = System.Windows.VerticalAlignment.Center;
                    Figur.Margin = new Thickness(0, 5, 0, 0);
                    Figur.Width = 85;
                    Figur.Height = 85;
                    break;
                case 5:
                    Figur.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                    Figur.VerticalAlignment = System.Windows.VerticalAlignment.Center;
                    Figur.Width = 95;
                    Figur.Height = 95;
                    break;
                default:
                    break;
            }
            VaryansGrid.Children.Add(Figur);

            ParcaGrid.Children.Add(VaryansGrid);

            return ParcaGrid;
        }
        Grid SiralamaBireyselParcaOlustur(int ParcaAdet)
        {
            Grid ParcaGrid = new Grid();
            ParcaGrid.Name = "Cocuk";
            ParcaGrid.Width = 200;
            ParcaGrid.Height = 200;
            ListeyeMesajEkle(ParcaGrid.Name + " Grid Oluşturuldu");
            Grid VaryansGrid = new Grid();
            VaryansGrid.Name = "CocukVar1";
            VaryansGrid.Width = 200;
            VaryansGrid.Height = 200;
            ListeyeMesajEkle(VaryansGrid.Name + " Grid Oluşturuldu");

            Canvas Figur = new Canvas();
            Image cocukFoto = new Image();
            cocukFoto.Tag = "Foto";
            cocukFoto.Source = new BitmapImage(new Uri(@"C:\HavuzProjesi\Resimler\CocukFotograf\28.png"));
            Figur.Children.Add(cocukFoto);

            switch (ParcaAdet)
            {
                case 2:
                    Figur.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                    Figur.VerticalAlignment = System.Windows.VerticalAlignment.Center;
                    Figur.Width = 100;
                    Figur.Height = 100;
                    break;
                case 3:
                    Figur.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                    Figur.VerticalAlignment = System.Windows.VerticalAlignment.Center;
                    Figur.Width = 66.666;
                    Figur.Height = 66.666;
                    break;
                case 4:
                    Figur.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                    Figur.VerticalAlignment = System.Windows.VerticalAlignment.Center;
                    Figur.Width = 50;
                    Figur.Height = 50;
                    break;
                case 5:
                    Figur.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                    Figur.VerticalAlignment = System.Windows.VerticalAlignment.Center;
                    Figur.Width = 40;
                    Figur.Height = 40;
                    break;
                default:
                    break;
            }
            cocukFoto.Width = Figur.Width;
            cocukFoto.Height = Figur.Height;

            VaryansGrid.Children.Add(Figur);

            ParcaGrid.Children.Add(VaryansGrid);

            return ParcaGrid;
        }
        Canvas SiralamaIcinFigurUret(string HedefYol, int ParcaAdet, int SeciliParcaIndeks, bool Bireysel)
        {
            Canvas Figur = new Canvas();
            switch (ParcaAdet)
            {
                case 2:
                    if (SeciliParcaIndeks == 0 && Bireysel == false)
                    {
                        Figur.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                        Figur.VerticalAlignment = System.Windows.VerticalAlignment.Center;
                        Figur.Width = 100;
                        Figur.Height = 100;
                        //Figur.Children.Add(DaireOlustur(95, 95, null));
                        Figur.Children.Add(DortgenOlustur(100, 100, HedefYol));
                    }
                    else if (SeciliParcaIndeks == 1)
                    {

                        Figur.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                        Figur.VerticalAlignment = System.Windows.VerticalAlignment.Center;
                        Figur.Margin = new Thickness(100, 0, 0, 0);
                        Figur.Width = 100;
                        Figur.Height = 100;
                        //Figur.Children.Add(DaireOlustur(95, 95, null));
                        Figur.Children.Add(DortgenOlustur(100, 100, HedefYol));
                    }
                    break;
                case 3:
                    if (SeciliParcaIndeks == 0 && Bireysel == false)
                    {
                        Figur.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                        Figur.VerticalAlignment = System.Windows.VerticalAlignment.Center;
                        Figur.Width = 66.666;
                        Figur.Height = 66.666;
                        //Figur.Children.Add(DaireOlustur(95, 95, null));
                        Figur.Children.Add(DortgenOlustur(66.666, 66.666, HedefYol));
                    }
                    else if (SeciliParcaIndeks == 1)
                    {
                        Figur.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                        Figur.VerticalAlignment = System.Windows.VerticalAlignment.Center;
                        Figur.Margin = new Thickness(66.666, 0, 0, 0);
                        Figur.Width = 66.666;
                        Figur.Height = 66.666;
                        //Figur.Children.Add(DaireOlustur(95, 95, null));
                        Figur.Children.Add(DortgenOlustur(66.666, 66.666, HedefYol));
                    }
                    else if (SeciliParcaIndeks == 2)
                    {
                        Figur.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                        Figur.VerticalAlignment = System.Windows.VerticalAlignment.Center;
                        Figur.Margin = new Thickness(133.332, 0, 0, 0);
                        Figur.Width = 66.666;
                        Figur.Height = 66.666;
                        //Figur.Children.Add(DaireOlustur(95, 95, null));
                        Figur.Children.Add(DortgenOlustur(66.666, 66.666, HedefYol));
                    }
                    break;
                case 4:
                    if (SeciliParcaIndeks == 0 && Bireysel == false)
                    {
                        Figur.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                        Figur.VerticalAlignment = System.Windows.VerticalAlignment.Center;
                        Figur.Width = 50;
                        Figur.Height = 50;
                        //Figur.Children.Add(DaireOlustur(85, 85, null));
                        Figur.Children.Add(DortgenOlustur(50, 50, HedefYol));
                    }
                    else if (SeciliParcaIndeks == 1)
                    {
                        Figur.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                        Figur.VerticalAlignment = System.Windows.VerticalAlignment.Center;
                        Figur.Margin = new Thickness(50, 0, 0, 0);
                        Figur.Width = 50;
                        Figur.Height = 50;
                        //Figur.Children.Add(DaireOlustur(85, 85, null));
                        Figur.Children.Add(DortgenOlustur(50, 50, HedefYol));
                    }
                    else if (SeciliParcaIndeks == 2)
                    {
                        Figur.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                        Figur.VerticalAlignment = System.Windows.VerticalAlignment.Center;
                        Figur.Margin = new Thickness(100, 0, 0, 0);
                        Figur.Width = 50;
                        Figur.Height = 50;
                        //Figur.Children.Add(DaireOlustur(85, 85, null));
                        Figur.Children.Add(DortgenOlustur(50, 50, HedefYol));
                    }
                    else if (SeciliParcaIndeks == 3)
                    {
                        Figur.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                        Figur.VerticalAlignment = System.Windows.VerticalAlignment.Center;
                        Figur.Margin = new Thickness(150, 0, 0, 0);
                        Figur.Width = 50;
                        Figur.Height = 50;
                        //Figur.Children.Add(DaireOlustur(95, 95, null));
                        Figur.Children.Add(DortgenOlustur(50, 50, HedefYol));
                    }
                    break;
                case 5:
                    if (SeciliParcaIndeks == 0 && Bireysel == false)
                    {
                        Figur.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                        Figur.VerticalAlignment = System.Windows.VerticalAlignment.Center;
                        Figur.Width = 40;
                        Figur.Height = 40;
                        //Figur.Children.Add(DaireOlustur(40, 40, null));
                        Figur.Children.Add(DortgenOlustur(40, 40, HedefYol));
                    }
                    else if (SeciliParcaIndeks == 1)
                    {
                        Figur.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                        Figur.VerticalAlignment = System.Windows.VerticalAlignment.Center;
                        Figur.Margin = new Thickness(40, 0, 0, 0);
                        Figur.Width = 40;
                        Figur.Height = 40;
                        //Figur.Children.Add(DaireOlustur(40, 40, null));
                        Figur.Children.Add(DortgenOlustur(40, 40, HedefYol));
                    }
                    else if (SeciliParcaIndeks == 2)
                    {
                        Figur.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                        Figur.VerticalAlignment = System.Windows.VerticalAlignment.Center;
                        Figur.Margin = new Thickness(80, 0, 0, 0);
                        Figur.Width = 40;
                        Figur.Height = 40;
                        //Figur.Children.Add(DaireOlustur(40, 40, null));
                        Figur.Children.Add(DortgenOlustur(40, 40, HedefYol));
                    }
                    else if (SeciliParcaIndeks == 3)
                    {
                        Figur.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                        Figur.VerticalAlignment = System.Windows.VerticalAlignment.Center;
                        Figur.Margin = new Thickness(120, 0, 0, 0);
                        Figur.Width = 40;
                        Figur.Height = 40;
                        //Figur.Children.Add(DaireOlustur(40, 40, null));
                        Figur.Children.Add(DortgenOlustur(40, 40, HedefYol));
                    }
                    else if (SeciliParcaIndeks == 4)
                    {
                        Figur.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                        Figur.VerticalAlignment = System.Windows.VerticalAlignment.Center;
                        Figur.Margin = new Thickness(160, 0, 0, 0);
                        Figur.Width = 40;
                        Figur.Height = 40;
                        //Figur.Children.Add(DaireOlustur(40, 40, null));
                        Figur.Children.Add(DortgenOlustur(40, 40, HedefYol));
                    }
                    break;
                default:
                    break;
            }
            return Figur;
        }
        Canvas FigurUret(string HedefYol, int ParcaAdet, int SeciliParcaIndeks, bool Bireysel)
        {
            Canvas Figur = new Canvas();
            switch (ParcaAdet)
            {
                case 2:
                    if (SeciliParcaIndeks == 0 && Bireysel == false)
                    {
                        Figur.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                        Figur.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                        Figur.Margin = new Thickness(0, 5, 0, 0);
                        Figur.Width = 95;
                        Figur.Height = 95;
                        Figur.Children.Add(DaireOlustur(95, 95, null));
                        Figur.Children.Add(DaireOlustur(95, 95, HedefYol));
                    }
                    else if (SeciliParcaIndeks == 1)
                    {

                        Figur.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                        Figur.VerticalAlignment = System.Windows.VerticalAlignment.Bottom;
                        Figur.Margin = new Thickness(0, 0, 0, 5);
                        Figur.Width = 95;
                        Figur.Height = 95;
                        Figur.Children.Add(DaireOlustur(95, 95, null));
                        Figur.Children.Add(DaireOlustur(95, 95, HedefYol));
                    }
                    break;
                case 3:
                    if (SeciliParcaIndeks == 0 && Bireysel == false)
                    {
                        Figur.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                        Figur.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                        Figur.Margin = new Thickness(0, 17, 0, 0);
                        Figur.Width = 95;
                        Figur.Height = 95;
                        Figur.Children.Add(DaireOlustur(95, 95, null));
                        Figur.Children.Add(DaireOlustur(95, 95, HedefYol));
                    }
                    else if (SeciliParcaIndeks == 1)
                    {
                        Figur.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                        Figur.VerticalAlignment = System.Windows.VerticalAlignment.Bottom;
                        Figur.Margin = new Thickness(5, 0, 0, 5);
                        Figur.Width = 95;
                        Figur.Height = 95;
                        Figur.Children.Add(DaireOlustur(95, 95, null));
                        Figur.Children.Add(DaireOlustur(95, 95, HedefYol));
                    }
                    else if (SeciliParcaIndeks == 2)
                    {
                        Figur.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
                        Figur.VerticalAlignment = System.Windows.VerticalAlignment.Bottom;
                        Figur.Margin = new Thickness(0, 0, 5, 5);
                        Figur.Width = 95;
                        Figur.Height = 95;
                        Figur.Children.Add(DaireOlustur(95, 95, null));
                        Figur.Children.Add(DaireOlustur(95, 95, HedefYol));
                    }
                    break;
                case 4:
                    if (SeciliParcaIndeks == 0)
                    {
                        Figur.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                        Figur.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                        Figur.Margin = new Thickness(0, 5, 0, 0);
                        Figur.Width = 85;
                        Figur.Height = 85;
                        Figur.Children.Add(DaireOlustur(85, 85, null));
                        Figur.Children.Add(DaireOlustur(85, 85, HedefYol));
                    }
                    else if (SeciliParcaIndeks == 1)
                    {
                        Figur.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                        Figur.VerticalAlignment = System.Windows.VerticalAlignment.Bottom;
                        Figur.Margin = new Thickness(5, 0, 0, 5);
                        Figur.Width = 85;
                        Figur.Height = 85;
                        Figur.Children.Add(DaireOlustur(85, 85, null));
                        Figur.Children.Add(DaireOlustur(85, 85, HedefYol));
                    }
                    else if (SeciliParcaIndeks == 2)
                    {
                        Figur.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
                        Figur.VerticalAlignment = System.Windows.VerticalAlignment.Bottom;
                        Figur.Margin = new Thickness(0, 0, 5, 5);
                        Figur.Width = 85;
                        Figur.Height = 85;
                        Figur.Children.Add(DaireOlustur(85, 85, null));
                        Figur.Children.Add(DaireOlustur(85, 85, HedefYol));
                    }
                    else if (SeciliParcaIndeks == 3 && Bireysel == false)
                    {
                        Figur.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                        Figur.VerticalAlignment = System.Windows.VerticalAlignment.Center;
                        Figur.Margin = new Thickness(0, 13, 0, 0);
                        Figur.Width = 95;
                        Figur.Height = 95;
                        Figur.Children.Add(DaireOlustur(95, 95, null));
                        Figur.Children.Add(DaireOlustur(95, 95, HedefYol));
                    }
                    break;
                case 5:
                    if (SeciliParcaIndeks == 0)
                    {
                        Figur.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                        Figur.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                        Figur.Margin = new Thickness(5, 5, 0, 0);
                        Figur.Width = 90;
                        Figur.Height = 90;
                        Figur.Children.Add(DaireOlustur(90, 90, null));
                        Figur.Children.Add(DaireOlustur(90, 90, HedefYol));
                    }
                    else if (SeciliParcaIndeks == 1)
                    {
                        Figur.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
                        Figur.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                        Figur.Margin = new Thickness(0, 5, 5, 0);
                        Figur.Width = 90;
                        Figur.Height = 90;
                        Figur.Children.Add(DaireOlustur(90, 90, null));
                        Figur.Children.Add(DaireOlustur(90, 90, HedefYol));
                    }
                    else if (SeciliParcaIndeks == 2)
                    {
                        Figur.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                        Figur.VerticalAlignment = System.Windows.VerticalAlignment.Bottom;
                        Figur.Margin = new Thickness(5, 0, 0, 5);
                        Figur.Width = 90;
                        Figur.Height = 90;
                        Figur.Children.Add(DaireOlustur(90, 90, null));
                        Figur.Children.Add(DaireOlustur(90, 90, HedefYol));
                    }
                    else if (SeciliParcaIndeks == 3)
                    {
                        Figur.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
                        Figur.VerticalAlignment = System.Windows.VerticalAlignment.Bottom;
                        Figur.Margin = new Thickness(0, 0, 5, 5);
                        Figur.Width = 90;
                        Figur.Height = 90;
                        Figur.Children.Add(DaireOlustur(90, 90, null));
                        Figur.Children.Add(DaireOlustur(90, 90, HedefYol));
                    }
                    else if (SeciliParcaIndeks == 4 && Bireysel == false)
                    {
                        Figur.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                        Figur.VerticalAlignment = System.Windows.VerticalAlignment.Center;
                        Figur.Width = 95;
                        Figur.Height = 95;
                        Figur.Children.Add(DaireOlustur(95, 95, null));
                        Figur.Children.Add(DaireOlustur(95, 95, HedefYol));
                    }
                    break;
                default:
                    break;
            }
            return Figur;
        }
        Ellipse DaireOlustur(double Genislik, double Yukseklik, string HedefYol)
        {
            Ellipse resimTutucu = new Ellipse();
            resimTutucu.Width = Genislik;
            resimTutucu.Height = Yukseklik;
            //Panel.SetZIndex(resimTutucu, 0);
            if (string.IsNullOrEmpty(HedefYol))
            {
                resimTutucu.Fill = Brushes.White;
                DropShadowEffect golge = new DropShadowEffect();
                golge.BlurRadius = 10;
                golge.ShadowDepth = 3;
                resimTutucu.Effect = golge;
            }
            else
            {
                resimTutucu.Fill = new ImageBrush(new BitmapImage(new Uri(HedefYol))) { Stretch = Stretch.Uniform };
            }

            return resimTutucu;
        }
        Rectangle DortgenOlustur(double Genislik, double Yukseklik, string HedefYol)
        {
            Rectangle resimTutucu = new Rectangle();
            resimTutucu.Width = Genislik;
            resimTutucu.Height = Yukseklik;
            //Panel.SetZIndex(resimTutucu, 0);
            if (string.IsNullOrEmpty(HedefYol))
            {
                resimTutucu.Fill = Brushes.White;
                DropShadowEffect golge = new DropShadowEffect();
                golge.BlurRadius = 10;
                golge.ShadowDepth = 3;
                resimTutucu.Effect = golge;
            }
            else
            {
                resimTutucu.Fill = new ImageBrush(new BitmapImage(new Uri(HedefYol))) { Stretch = Stretch.Uniform };
            }

            return resimTutucu;
        }
        Grid FeykDigerParcaXamlOlustur()
        {
            string Prefix = "dp";
            Grid Kapsul = new Grid();
            Kapsul.Name = DigerParcalarKlasorAd;
            Kapsul.Width = 200;
            Kapsul.Height = 200;
            ListeyeMesajEkle(DigerParcalarKlasorAd + " Grid Oluşturuldu");

            Grid ParcaGrid = new Grid();
            ParcaGrid.Name = Prefix + "_" + "FeykParca1";
            ParcaGrid.Width = 200;
            ParcaGrid.Height = 200;
            ListeyeMesajEkle(ParcaGrid.Name + " Grid Oluşturuldu");

            Grid VaryansGrid = new Grid();
            VaryansGrid.Name = Prefix + "_" + "FeykVaryans1";
            VaryansGrid.Width = 200;
            VaryansGrid.Height = 200;
            ListeyeMesajEkle(VaryansGrid.Name + " Grid Oluşturuldu");

            for (int i = 0; i < 3; i++)
            {
                Rectangle feykParca = new Rectangle();
                feykParca.Visibility = System.Windows.Visibility.Hidden;
                VaryansGrid.Children.Add(feykParca);
                ListeyeMesajEkle("FeykParca" + i + " Figür Oluşturuldu");
            }

            ParcaGrid.Children.Add(VaryansGrid);

            Kapsul.Children.Add(ParcaGrid);
            return Kapsul;
        }
        Grid FeykTemelParcaXamlOlustur()
        {
            string Prefix = "tp";
            Grid Kapsul = new Grid();
            Kapsul.Name = TemelParcalarKlasorAd;
            Kapsul.Width = 200;
            Kapsul.Height = 200;
            ListeyeMesajEkle(TemelParcalarKlasorAd + " Grid Oluşturuldu");

            Grid ParcaGrid = new Grid();
            ParcaGrid.Name = Prefix + "_" + "FeykParca1";
            ParcaGrid.Width = 200;
            ParcaGrid.Height = 200;
            ListeyeMesajEkle(ParcaGrid.Name + " Grid Oluşturuldu");

            Grid VaryansGrid = new Grid();
            VaryansGrid.Name = Prefix + "_" + "FeykVaryans1";
            VaryansGrid.Width = 200;
            VaryansGrid.Height = 200;
            ListeyeMesajEkle(VaryansGrid.Name + " Grid Oluşturuldu");

            for (int i = 0; i < 3; i++)
            {
                Rectangle feykParca = new Rectangle();
                feykParca.Visibility = System.Windows.Visibility.Hidden;
                VaryansGrid.Children.Add(feykParca);
                ListeyeMesajEkle("FeykParca" + i + " Figür Oluşturuldu");
            }

            ParcaGrid.Children.Add(VaryansGrid);

            Kapsul.Children.Add(ParcaGrid);
            return Kapsul;
        }
        Grid BireyselDigerParcaXamlOlustur(int ParcaAdet)
        {
            string Prefix = "dp";
            Grid Kapsul = new Grid();
            Kapsul.Name = DigerParcalarKlasorAd;
            Kapsul.Width = 200;
            Kapsul.Height = 200;
            ListeyeMesajEkle(DigerParcalarKlasorAd + " Grid Oluşturuldu");
            Kapsul.Children.Add(BireyselParcaOlustur(ParcaAdet));
            return Kapsul;
        }

        void ResimKlasorOlustur(string Yol)
        {
            DirectoryInfo di;
            di = new DirectoryInfo(Yol);
            if (di.Exists == false)
            {
                di.Create();
                ListeyeMesajEkle(KlasorAdGetir(Yol) + " klasörü oluşturuldu");
            }
        }
        void ListeyeMesajEkle(string Mesaj)
        {
            lbKontrolSonucListe.Items.Add(Mesaj);
            lbKontrolSonucListe.ScrollIntoView(Mesaj);
        }
        private void HavuzOlustur()
        {
            string[] TempListe;
            string HavuzAd = KlasorAdGetir(tbHavuzKonum.Text);
            lbKontrolSonucListe.Items.Clear();
            ResimKlasorOlustur(ResimYol + "\\" + HavuzAd);
            ResimKlasorOlustur(ResimYol + "\\" + HavuzAd + "\\" + TemelParcalarKlasorAd);
            ResimKlasorOlustur(ResimYol + "\\" + HavuzAd + "\\" + DigerParcalarKlasorAd);

            Grid havuz = new Grid();
            havuz.Name = "havuz";
            havuz.Width = 200;
            havuz.Height = 200;
            ListeyeMesajEkle("Havuz Grid Oluşturuldu");

            TempListe = Directory.GetDirectories(tbHavuzKonum.Text);
            if (TempListe.Count() == 1)// diger parca yok ise
            {
                if (MessageBox.Show("Seçeceğiniz Resimlerden havuz oluşturmak ister misiniz?", "Resim Seiçimi",
                    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    ResimSecim resSec = new ResimSecim(TempListe[0]);
                    resSec.ShowDialog();
                    if (resSec.seciliResimIndeksleri != null)
                    {
                        //Normal Havuzlar
                        for (int i = 2; i < 6; i++)
                        {
                            HavuzXamlOlustur(TempListe, resSec.seciliResimIndeksleri, HavuzAd, i, true, false);
                            HavuzXamlOlustur(TempListe, resSec.seciliResimIndeksleri, HavuzAd, i, false, false);
                        }
                        //Sıralama Havuzları
                        for (int i = 2; i < 6; i++)
                        {
                            HavuzXamlOlustur(TempListe, resSec.seciliResimIndeksleri, HavuzAd, i, true, true);
                            HavuzXamlOlustur(TempListe, resSec.seciliResimIndeksleri, HavuzAd, i, false, true);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Havuz Oluşturma işlemi iptal edilmiştir.", "İptal", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                else
                {
                    //Normal Havuzlar
                    for (int i = 2; i < 6; i++)
                    {
                        string ParcaYol = Directory.GetDirectories(TempListe[0])[0];
                        string varYol = Directory.GetDirectories(ParcaYol)[0];
                        //var a = File.GetAttributes(Directory.GetFiles(varYol)[3]);
                        int figurAdet = Directory.GetFiles(varYol, Uzanti).Where(s => File.GetAttributes(s) != (FileAttributes.Hidden | FileAttributes.Archive)).Count();
                        List<int> indeksler = new List<int>();
                        for (int j = 0; j < figurAdet; j++)
                        {
                            indeksler.Add(j);
                        }
                        HavuzXamlOlustur(TempListe, indeksler, HavuzAd, i, true, false);
                        HavuzXamlOlustur(TempListe, indeksler, HavuzAd, i, false, false);
                    }
                    //Sıralama Havuzları
                    for (int i = 2; i < 6; i++)
                    {
                        string ParcaYol = Directory.GetDirectories(TempListe[0])[0];
                        string varYol = Directory.GetDirectories(ParcaYol)[0];
                        //var a = File.GetAttributes(Directory.GetFiles(varYol)[3]);
                        int figurAdet = Directory.GetFiles(varYol, Uzanti).Where(s => File.GetAttributes(s) != (FileAttributes.Hidden | FileAttributes.Archive)).Count();
                        List<int> indeksler = new List<int>();
                        for (int j = 0; j < figurAdet; j++)
                        {
                            indeksler.Add(j);
                        }
                        HavuzXamlOlustur(TempListe, indeksler, HavuzAd, i, true, true);
                        HavuzXamlOlustur(TempListe, indeksler, HavuzAd, i, false, true);
                    }
                }


            }
            else
            {
                HavuzXamlOlustur(TempListe, HavuzAd);
            }
        }
        private void HavuzXamlOlustur(string[] TempListe, List<int> indeksler, string HavuzAd, int ParcaAdet, bool Bireysel, bool siralamaMi)
        {

            string tmpHavuzAd = HavuzAd;
            if (chbKombinasyon.IsChecked == true)
            {
                for (int i = 2; i < indeksler.Count; i++)
                {
                    Combinations<int> combinations = new Combinations<int>(indeksler.ToArray(), i);
                    int dosyaAd = 1;
                    foreach (int[] combination in combinations)
                    {
                        dosyaKaydet(tmpHavuzAd, TempListe, ParcaAdet, Bireysel, combination, dosyaAd++, siralamaMi);
                        //if (dosyaAd > 5)
                        //{
                        //    break;
                        //}
                    }

                }
                dosyaKaydet(tmpHavuzAd, TempListe, ParcaAdet, Bireysel, indeksler.ToArray(), -1, siralamaMi);
            }
            else
            {
                dosyaKaydet(tmpHavuzAd, TempListe, ParcaAdet, Bireysel, indeksler.ToArray(), -1, siralamaMi);
            }


        }
        private void dosyaKaydet(string tmpHavuzAd, string[] TempListe, int ParcaAdet, bool Bireysel, int[] combination, int dosyaAd, bool siralamaHavuzMu)
        {
            string HavuzAd = tmpHavuzAd;
            Grid havuz = new Grid();
            havuz.Name = "havuz";
            havuz.Width = 200;
            havuz.Height = 200;
            ListeyeMesajEkle("Havuz Grid Oluşturuldu");
            if (siralamaHavuzMu == false)
            {
                havuz.Children.Add(XamlOlustur(HavuzAd, "tp", TempListe[0], TemelParcalarKlasorAd, ParcaAdet, Bireysel, combination, siralamaHavuzMu));
                if (Bireysel == false)
                {
                    havuz.Children.Add(FeykDigerParcaXamlOlustur());
                }
                else
                {
                    havuz.Children.Add(BireyselDigerParcaXamlOlustur(ParcaAdet));
                }
            }
            else
            {
                havuz.Children.Add(FeykTemelParcaXamlOlustur());
                havuz.Children.Add(XamlOlustur(HavuzAd, "dp", TempListe[0], DigerParcalarKlasorAd, ParcaAdet, Bireysel, combination, siralamaHavuzMu));
            }

            HavuzAd = Bireysel == false ? HavuzAd + "-" + ParcaAdet + "Parcali" + dosyaAd++ : HavuzAd + "-" + ParcaAdet + "Parcali-Bireysel" + dosyaAd++;
            XamlOkuyucu Okuyucu = new XamlOkuyucu();
            Okuyucu.Content = havuz;
            if (siralamaHavuzMu == false)
            {
                Okuyucu.IcerigiKaydet(HavuzYol + "\\" + tmpHavuzAd + "\\NormalHavuzlar\\" + ParcaAdet + "ParcaliHavuzlar\\" + combination.Count() + "ResimliHavuzlar\\", HavuzAd);
            }
            else
            {
                Okuyucu.IcerigiKaydet(HavuzYol + "\\" + tmpHavuzAd + "\\SiralamHavuzlari\\" + ParcaAdet + "ParcaliHavuzlar\\" + combination.Count() + "ResimliHavuzlar\\", HavuzAd);
            }

        }
        private void HavuzXamlOlustur(string[] TempListe, string HavuzAd)
        {
            Grid havuz = new Grid();
            havuz.Name = "havuz";
            havuz.Width = 200;
            havuz.Height = 200;
            ListeyeMesajEkle("Havuz Grid Oluşturuldu");

            havuz.Children.Add(XamlOlustur(HavuzAd, "tp", TempListe[0], TemelParcalarKlasorAd));
            havuz.Children.Add(XamlOlustur(HavuzAd, "dp", TempListe[1], DigerParcalarKlasorAd));

            XamlOkuyucu Okuyucu = new XamlOkuyucu();
            Okuyucu.Content = havuz;
            Okuyucu.IcerigiKaydet(HavuzYol, HavuzAd);
        }
    }
}
