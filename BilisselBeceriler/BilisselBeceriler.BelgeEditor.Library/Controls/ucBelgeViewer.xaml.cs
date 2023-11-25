using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Printing;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Markup;
using System.Xml;
using BilisselBeceriler.BelgeEditor.Library.Helpers;
using BilisselBeceriler.BelgeEditor.Library.Model;
using BilisselBeceriler.BelgeEditor.Library.Types;
using BilisselBeceriler.BelgeEditor.Library.Extensions;
using BilisselBeceriler.BelgeEditor.Library.Constants;
using Microsoft.Win32;
using System.Windows.Media;

namespace BilisselBeceriler.BelgeEditor.Library.Controls
{
    /// <summary>
    /// Interaction logic for ucBelgeTemplate.xaml
    /// </summary>
    public partial class UcBelgeViewer
    {

        #region Private Variables
        private PrintDialog _prnDialog;
        private Thickness _marj;
        private PrintQueue _yazici;
        private bool _kapakMi;
        private bool _buyukKapakMi;

        private const string ValidFixedDocumenDropExtension = ".xaml";

        #endregion
        public int SayfaAdet { get { return fdBelge.Pages.Count; } }
        public UcBelgeViewer()
        {
            InitializeComponent();
            drReader.ContextMenu.IsTextSearchEnabled = false;
            _kapakMi = false;
            _buyukKapakMi = false;
            try
            {
                _prnDialog = PrintHelper.GetDialogFromRegistry();
                _prnDialog.UserPageRangeEnabled = true;
                _yazici = _prnDialog.PrintQueue;
                _marj = SayfaHelper.GetFromRegistry();
                fdBelge.PrintTicket = _yazici.UserPrintTicket;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void YaziciAyarla(PrintDialog pd)
        {
            try
            {
                _prnDialog = pd;
                PrintHelper.SetDialogToRegistry(_prnDialog);
                fdBelge.PrintTicket = _prnDialog.PrintTicket;
                _prnDialog.PrintQueue.UserPrintTicket = _prnDialog.PrintTicket;
                fdBelge.PrintTicket = _prnDialog.PrintTicket;
                _yazici = _prnDialog.PrintQueue;
                new PageRangeDocumentPaginator(drReader.Document.DocumentPaginator, new PageRange(), _prnDialog.PrintTicket, _marj);
                drReader.UpdateLayout();

                UpdateLayout();


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        public void MarjUygula(Thickness marj)
        {
            try
            {
                _marj = marj;
                foreach (var seciliSayfa in fdBelge.Pages)
                {
                    SayfaHelper.MarjUygula(seciliSayfa, _marj);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private PageContent SayfaOlustur(PageContent eskiSayfa)
        {
            var asilsayfa = eskiSayfa.Child.Children[0] as Grid;

            var yenisayfa = new FixedPage { Width = eskiSayfa.Child.Width, Height = eskiSayfa.Child.Height };
            eskiSayfa.Child.Children.Remove(asilsayfa);
            CreatePageContextMenu(yenisayfa);
            if (asilsayfa != null) yenisayfa.Children.Add(asilsayfa);
            var yeniContent = new PageContent { Child = yenisayfa, Width = eskiSayfa.Width, Height = eskiSayfa.Height };


            yeniContent.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
            yeniContent.Arrange(new Rect(new Point(0, 0), yeniContent.DesiredSize));


            return yeniContent;
        }

        private void DrReaderLoaded(object sender, RoutedEventArgs e)
        {
            var contentHost = drReader.Template.FindName("PART_FindToolBarHost", drReader) as ContentControl;
            if (contentHost != null)
            {
                var grid = contentHost.Parent as Grid;
                if (grid != null) grid.Children.Remove(contentHost);
            }
        }

        bool IsValidExtension(string path, string extension)
        {
            if (path == null || extension == null) return false;
            var fi = new FileInfo(path);
            if (fi.Exists == false) return false;
            return fi.Extension.ToLower() == extension.ToLower();
        }

        #region Sayfa Siralama
        public void SayfaYukari(int sayfaIndeks)
        {
            if (sayfaIndeks == 0 ||
                fdBelge.Pages.Count < 2 ||
                sayfaIndeks > fdBelge.Pages.Count) return;
            var temp = new FixedDocument { PrintTicket = fdBelge.PrintTicket };
            for (var i = 0; i < fdBelge.Pages.Count; i++)
            {
                if (i == sayfaIndeks - 1)
                {
                    temp.Pages.Add(SayfaOlustur(fdBelge.Pages.ElementAt(sayfaIndeks)));
                    temp.Pages.Add(SayfaOlustur(fdBelge.Pages.ElementAt(i)));
                    i++;
                    continue;
                }
                temp.Pages.Add(SayfaOlustur(fdBelge.Pages.ElementAt(i)));
            }
            fdBelge = temp;
            drReader.Document = null;
            drReader.Document = fdBelge;
            SayfaNoAyarla();
        }
        public void SayfaAsagi(int sayfaIndeks)
        {
            if (sayfaIndeks == fdBelge.Pages.Count - 1 ||
                fdBelge.Pages.Count < 2 ||
                sayfaIndeks > fdBelge.Pages.Count) return;

            var temp = new FixedDocument { PrintTicket = fdBelge.PrintTicket };
            for (var i = 0; i < fdBelge.Pages.Count; i++)
            {
                if (i == sayfaIndeks)
                {
                    temp.Pages.Add(SayfaOlustur(fdBelge.Pages.ElementAt(sayfaIndeks + 1)));
                    temp.Pages.Add(SayfaOlustur(fdBelge.Pages.ElementAt(i)));
                    i++;
                    continue;
                }
                temp.Pages.Add(SayfaOlustur(fdBelge.Pages.ElementAt(i)));
            }
            fdBelge = temp;
            drReader.Document = null;
            drReader.Document = fdBelge;
            SayfaNoAyarla();
        }
        public void SayfaKonumAyarla(int sayfaIndeks, int hedefIndeks)
        {
            if (
                hedefIndeks != sayfaIndeks &&         //Hedef indeks ile sayfa indeksi aynı değilse
                fdBelge.Pages.Count > 2 &&            //Belgede 2 den fazla sayfa varsa
                hedefIndeks < fdBelge.Pages.Count &&  //Hedef indeks toplam sayfa sayısından küçükse
                hedefIndeks >= 0                      //Hedef indeks 0 dan büyük veya eşitse
                )
            {
                var temp = new FixedDocument { PrintTicket = fdBelge.PrintTicket };
                hedefIndeks = sayfaIndeks > hedefIndeks ? hedefIndeks - 1 : hedefIndeks;
                for (int i = 0; i < fdBelge.Pages.Count; i++)
                {
                    if (i == hedefIndeks)
                    {
                        temp.Pages.Add(SayfaOlustur(fdBelge.Pages.ElementAt(sayfaIndeks)));
                        temp.Pages.Add(SayfaOlustur(fdBelge.Pages.ElementAt(hedefIndeks)));
                    }
                    else if (i == sayfaIndeks)
                    {
                        continue;
                    }
                    else
                    {
                        temp.Pages.Add(SayfaOlustur(fdBelge.Pages.ElementAt(i)));
                        continue;
                    }
                }
                fdBelge = temp;
                drReader.Document = null;
                drReader.Document = fdBelge;
                SayfaNoAyarla();
            }
        }
        #endregion

        #region Sayfa Ekle-Sil
        public void SayfaEkle(PageContent yeniSayfa)
        {
            fdBelge.Pages.Add(yeniSayfa);
            SayfaNoAyarla();
        }
        public void SayfalariEkle(IEnumerable<PageContent> yeniSayfalar)
        {
            foreach (var yeniSayfa in yeniSayfalar)
            {
                fdBelge.Pages.Add(yeniSayfa);
            }
            SayfaNoAyarla();
        }
        public void SayfaSil(int sayfaIndeks)
        {
            if (sayfaIndeks < 0 ||
                sayfaIndeks >= fdBelge.Pages.Count) return;
            var temp = new FixedDocument { PrintTicket = fdBelge.PrintTicket };
            for (int i = 0; i < fdBelge.Pages.Count; i++)
            {
                if (i == sayfaIndeks)
                {
                    continue;
                }
                temp.Pages.Add(SayfaOlustur(fdBelge.Pages.ElementAt(i)));
            }
            fdBelge = temp;
            drReader.Document = null;
            drReader.Document = fdBelge;
            SayfaNoAyarla();
        }
        #endregion

        #region Belge Islemleri
        public void YeniBelge()
        {
            fdBelge = new FixedDocument { PrintTicket = _yazici.UserPrintTicket };
            drReader.Document = null;
            drReader.Document = fdBelge;
            _kapakMi = false;
            _buyukKapakMi = false;
        }
        public void BelgeAc(string dosyaAd)
        {
            MessageBoxResult belgeKaydetSonuc = MessageBoxResult.No;
            if (fdBelge.Pages.Count > 0)
            {
                belgeKaydetSonuc = MessageBox.Show("Mevcut Belgeyi Kaydetmek isiyior musunuz?", "Belge Aç", MessageBoxButton.YesNo, MessageBoxImage.Question);

            }
            if (belgeKaydetSonuc == MessageBoxResult.No)
            {
                var cevap = MessageBox.Show("Seçili Belgeyi, açık beleye eklemek isiyior musunuz?", "Belge Ekle",
                                            MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (cevap == MessageBoxResult.No)
                {
                    #region Yeni Icerik
                    YeniBelge();
                    var oku = new XamlHelper();
                    oku.IcerigiYukle(dosyaAd);
                    if (oku.Content != null)
                    {
                        if (oku.Content is FixedDocument)
                        {
                            if (dosyaAd.Contains("KAPAK"))
                            {
                                _kapakMi = true;
                            }
                            var yeniBelge = oku.Content as FixedDocument;
                            yeniBelge.PrintTicket = fdBelge.PrintTicket;
                            fdBelge = yeniBelge;
                            if (fdBelge.Pages != null)
                            {
                                foreach (var page in fdBelge.Pages)
                                {
                                    var belgeGrid = page.Child.Children[0] as Grid;
                                    if (belgeGrid != null)
                                    {
                                        if (belgeGrid.Width > belgeGrid.Height &&
                                            _yazici.UserPrintTicket.PageMediaSize.Width != null)
                                        {
                                            _buyukKapakMi = true;
                                            if (_yazici.UserPrintTicket.PageMediaSize.Width != null)
                                                page.Child.Width = _yazici.UserPrintTicket.PageMediaSize.Width.Value * 2;
                                            if (_yazici.UserPrintTicket.PageMediaSize.Height != null)
                                                page.Child.Height = _yazici.UserPrintTicket.PageMediaSize.Height.Value;
                                        }
                                        else
                                        {
                                            if (_yazici.UserPrintTicket.PageMediaSize.Width != null)
                                                page.Child.Width = _yazici.UserPrintTicket.PageMediaSize.Width.Value;
                                            if (_yazici.UserPrintTicket.PageMediaSize.Height != null)
                                                page.Child.Height = _yazici.UserPrintTicket.PageMediaSize.Height.Value;
                                        }
                                    }
                                    page.Child.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
                                    page.Child.Arrange(new Rect(new Point(0, 0), page.Child.DesiredSize));
                                    page.Child.UpdateLayout();
                                    CreatePageContextMenu(page.Child);
                                    if (belgeGrid != null)
                                    {
                                        var sayfaGrid = belgeGrid.Children[0] as Grid;
                                        ProcessorEkle(sayfaGrid);
                                        textBoxTemizle(sayfaGrid);

                                        #region Scale Page Content
                                        double sc = ScaleHesapla(belgeGrid.DesiredSize, page.Child.DesiredSize);
                                        const double epsilon = 0;
                                        if (Math.Abs(sc - 1) > epsilon)
                                        {
                                            var tg = new TransformGroup();
                                            var sct = new ScaleTransform(sc, sc) { CenterX = 0, CenterY = 0 };
                                            tg.Children.Add(sct);
                                            if (page.Child.Width < page.Child.Height && (_yazici.UserPrintTicket.PageOrientation == PageOrientation.Landscape ||
                                                _yazici.UserPrintTicket.PageOrientation == PageOrientation.ReverseLandscape))
                                            {
                                                var rt = new RotateTransform(-90);
                                                tg.Children.Add(rt);
                                            }
                                            belgeGrid.Margin = _marj;
                                            belgeGrid.LayoutTransform = null;
                                            belgeGrid.LayoutTransform = tg;
                                            belgeGrid.UpdateLayout();
                                        }

                                        #endregion
                                    }

                                }



                                drReader.Document = fdBelge;


                            }
                        }
                    }
                    #endregion
                }
                else if (cevap == MessageBoxResult.Yes)
                {
                    #region Icerigi Ekle
                    var oku = new XamlHelper();
                    oku.IcerigiYukle(dosyaAd);
                    if (oku.Content != null)
                    {
                        if (oku.Content is FixedDocument)
                        {
                            if (dosyaAd.Contains("KAPAK"))
                            {
                                _kapakMi = true;
                            }
                            var yeniBelge = oku.Content as FixedDocument;
                            yeniBelge.PrintTicket = fdBelge.PrintTicket;
                            if (yeniBelge.Pages != null)
                            {
                                foreach (var page in yeniBelge.Pages)
                                {
                                    var belgeGrid = Common.CloneUsingXaml(page.Child.Children[0]) as Grid;
                                    var fxPage = new FixedPage();
                                    fxPage.Children.Add(belgeGrid);

                                    #region apply media size
                                    if (belgeGrid != null)
                                    {
                                        if (belgeGrid.Width > belgeGrid.Height &&
                                            _yazici.UserPrintTicket.PageMediaSize.Width != null)
                                        {
                                            _buyukKapakMi = true;
                                            if (_yazici.UserPrintTicket.PageMediaSize.Width != null)
                                                fxPage.Width = _yazici.UserPrintTicket.PageMediaSize.Width.Value * 2;
                                            if (_yazici.UserPrintTicket.PageMediaSize.Height != null)
                                                fxPage.Height = _yazici.UserPrintTicket.PageMediaSize.Height.Value;
                                        }
                                        else
                                        {
                                            if (_yazici.UserPrintTicket.PageMediaSize.Width != null)
                                                fxPage.Width = _yazici.UserPrintTicket.PageMediaSize.Width.Value;
                                            if (_yazici.UserPrintTicket.PageMediaSize.Height != null)
                                                fxPage.Height = _yazici.UserPrintTicket.PageMediaSize.Height.Value;
                                        }
                                    }
                                    fxPage.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
                                    fxPage.Arrange(new Rect(new Point(0, 0), fxPage.DesiredSize));
                                    fxPage.UpdateLayout();
                                    #endregion
                                    CreatePageContextMenu(fxPage);
                                    if (belgeGrid != null)
                                    {
                                        var sayfaGrid = belgeGrid.Children[0] as Grid;
                                        ProcessorEkle(sayfaGrid);
                                        textBoxTemizle(sayfaGrid);
                                        #region Scale Page Content
                                        double sc = ScaleHesapla(belgeGrid.DesiredSize, fxPage.DesiredSize);
                                        const double epsilon = 0;
                                        if (Math.Abs(sc - 1) > epsilon)
                                        {
                                            var tg = new TransformGroup();
                                            var sct = new ScaleTransform(sc, sc) { CenterX = 0, CenterY = 0 };
                                            tg.Children.Add(sct);
                                            if (fxPage.Width < fxPage.Height &&
                                                (_yazici.UserPrintTicket.PageOrientation == PageOrientation.Landscape ||
                                                 _yazici.UserPrintTicket.PageOrientation ==
                                                 PageOrientation.ReverseLandscape))
                                            {
                                                var rt = new RotateTransform(-90);
                                                tg.Children.Add(rt);
                                            }
                                            belgeGrid.Margin = _marj;
                                            belgeGrid.LayoutTransform = null;
                                            belgeGrid.LayoutTransform = tg;
                                            belgeGrid.UpdateLayout();
                                        }

                                        #endregion
                                    }
                                    fdBelge.Pages.Add(new PageContent { Child = fxPage });
                                }
                            }
                        }
                    }
                    #endregion
                }
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

        public void BelgeKaydet(string dosyaAd, bool kapatilacakMi)
        {
            string[] klasorler = dosyaAd.Split('\\');

            if (klasorler.Count() > 0)
            {
                var sonKlasor = klasorler[klasorler.Count() - 2];
                if (sonKlasor.Contains("AY VE SONRASI") || sonKlasor.Contains("Sayı"))
                {
                    MessageBox.Show("Yayın veya Yaş Grubu Altına Doğrudan Belge Kaydedemezsiniz.", "Belge Kaydet", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                fdBelge.PrintTicket = null;
                var yaz = new XamlHelper { Content = fdBelge };
                yaz.IcerigiKaydet(dosyaAd);
                fdBelge.PrintTicket = _yazici.UserPrintTicket;
                if (kapatilacakMi)
                {
                    YeniBelge();
                }
            }
        }
        #endregion
        private void textBoxTemizle(Grid sayfaIcerik)
        {
            int textBoxAdet = 0;
            foreach (var item in sayfaIcerik.Children.OfType<TextBox>())
            {
                var textblck = ExtensionService.FindChildByTag<TextBlock>(sayfaIcerik, item.Tag.ToString());
                textblck.Text = item.Text;
                textBoxAdet++;
            }
            for (int i = 0; i < textBoxAdet; i++)
            {
                var silinecek = sayfaIcerik.Children.OfType<TextBox>().First();
                sayfaIcerik.Children.Remove(silinecek);
            }
        }
        #region FlowDocument Drag Drop Events
        private void DocumentViewerDragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(SayfaSablonEntity)))
            {
                var grid = (SayfaSablonEntity)e.Data.GetData(typeof(SayfaSablonEntity));
                if (IsValidExtension(grid.Path, ValidFixedDocumenDropExtension) == false)
                {
                    e.Effects = e.Data.GetDataPresent(typeof(string)) ? DragDropEffects.Copy : DragDropEffects.None;
                }
            }
            else if (e.Data.GetDataPresent(typeof(BelgeSablonEntity)))
            {
                var belge = (BelgeSablonEntity)e.Data.GetData(typeof(BelgeSablonEntity));
                if (IsValidExtension(belge.Path, ValidFixedDocumenDropExtension))
                {
                    e.Effects = e.Data.GetDataPresent(typeof(string)) ? DragDropEffects.Copy : DragDropEffects.None;
                }
            }
        }
        private void DocumentViewerDragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(SayfaSablonEntity)))
            {
                var grid = (SayfaSablonEntity)e.Data.GetData(typeof(SayfaSablonEntity));
                if (IsValidExtension(grid.Path, ValidFixedDocumenDropExtension))
                {
                    //var fd = (sender as FlowDocument);
                    //if (fd != null) fd.Background = new SolidColorBrush(Colors.Silver);
                    e.Effects = DragDropEffects.All;
                    e.Handled = true;
                }
            }
            else if (e.Data.GetDataPresent(typeof(BelgeSablonEntity)))
            {
                var belge = (BelgeSablonEntity)e.Data.GetData(typeof(BelgeSablonEntity));
                if (IsValidExtension(belge.Path, ValidFixedDocumenDropExtension))
                {
                    e.Effects = DragDropEffects.All;
                    e.Handled = true;
                }
            }
        }
        int FindPageIndex(MenuItem mi)
        {
            var page = (FixedPage)((ContextMenu)mi.Parent).PlacementTarget;
            var oc = (PageContent)page.Parent;
            int index = -1;
            for (int i = 0; i < fdBelge.Pages.Count; i++)
            {
                if (fdBelge.Pages[i] == oc)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }
        void SayfaNoAyarla()
        {
            int index = 1;
            foreach (var item in fdBelge.Pages)
            {
                var asilSayfa = item.Child.Children[0] as Grid;
                var sayfaNo = ExtensionService.FindAllControlsByTag<Label>(asilSayfa, TagNameConstants.lblSayfaNo).FirstOrDefault();
                if (sayfaNo != null)
                {
                    sayfaNo.Content = "Sayfa " + index;
                    index++;
                }
            }
        }
        void CreatePageContextMenu(FixedPage fpSayfa)
        {
            #region Context Menu
            var mainMenu = new ContextMenu();
            fpSayfa.ContextMenu = mainMenu;

            #region Sayfa Sil
            var itemSil = new MenuItem { Header = "Sayfayı sil" };
            itemSil.Click += (o, args) =>
            {
                var menuItem = (MenuItem)o;
                var index = FindPageIndex(menuItem);
                SayfaSil(index);
            };
            mainMenu.Items.Add(itemSil);
            #endregion
            #region Aşağı taşı
            var asagiTasi = new MenuItem { Header = "Sayfayı aşağı taşı" };
            asagiTasi.Click += (o, args) =>
            {
                var menuItem = (MenuItem)o;
                var index = FindPageIndex(menuItem);
                SayfaAsagi(index);
            };
            mainMenu.Items.Add(asagiTasi);
            #endregion
            #region Yukarı taşı
            var yukariTasi = new MenuItem { Header = "Sayfayı yukarı taşı" };
            yukariTasi.Click += (o, args) =>
            {
                var menuItem = (MenuItem)o;
                var index = FindPageIndex(menuItem);
                SayfaYukari(index);
            };
            mainMenu.Items.Add(yukariTasi);
            #endregion

            #region Konumlandır
            var item = new StackPanel();
            item.Children.Add(new Label { Content = "Konumlandır- Hedef SayfaNo:" });
            item.Children.Add(new TextBox { Width = 120 });
            item.Orientation = Orientation.Horizontal;
            var kanumlandir = new MenuItem { Header = item };
            kanumlandir.Click += (o, args) =>
            {
                var menuItem = (MenuItem)o;
                var index = FindPageIndex(menuItem);
                int hedef;
                if (int.TryParse(((StackPanel)menuItem.Header).Children.OfType<TextBox>().First().Text, out hedef))
                    SayfaKonumAyarla(index, hedef);
            };
            mainMenu.Items.Add(kanumlandir);
            #endregion

            #region Tek Sayfalara Logo Ekle
            var tekSayfaOkulLogo = new MenuItem { Header = "Tek Sayfalara Logo Ekle" };
            tekSayfaOkulLogo.Click += (o, args) =>
            {
                var dlg = new OpenFileDialog { Title = "Logo Resmi Aç", Filter = "PNG Dosyaları|*.png" };
                bool? retval = dlg.ShowDialog();

                if (retval.Value)
                {
                    for (int i = 0; i < fdBelge.Pages.Count; i += 2)
                    {
                        var sayfa = (Grid)((Grid)fdBelge.Pages.ElementAt(i).Child.Children[0]).Children[0];

                        var antetLogo = ExtensionService.FindChildByTag<Border>(sayfa, TagNameConstants.AntetLogo);
                        if (antetLogo != null)
                        {
                            antetLogo.Background = BelgeUretHelper.StreamToImageBrush(dlg.FileName);
                        }
                    }
                }
            };
            mainMenu.Items.Add(tekSayfaOkulLogo);

            #endregion

            #region Çift Sayfalara Logo Ekle
            var ciftSayfaOkulLogo = new MenuItem { Header = "Çift Sayfalara Logo Ekle" };
            ciftSayfaOkulLogo.Click += (o, args) =>
            {
                var dlg = new OpenFileDialog { Title = "Logo Resmi Aç", Filter = "PNG Dosyaları|*.png" };
                bool? retval = dlg.ShowDialog();

                if (retval.Value)
                {
                    for (int i = 1; i < fdBelge.Pages.Count; i += 2)
                    {
                        var sayfa = (Grid)((Grid)fdBelge.Pages.ElementAt(i).Child.Children[0]).Children[0];

                        var antetLogo = ExtensionService.FindChildByTag<Border>(sayfa, TagNameConstants.AntetLogo);
                        if (antetLogo != null)
                        {
                            antetLogo.Background = BelgeUretHelper.StreamToImageBrush(dlg.FileName);
                        }
                    }
                }
            };
            mainMenu.Items.Add(ciftSayfaOkulLogo);

            #endregion

            #region Tek Sayfalardan Logo Kaldır
            var tekSayfaOkulLogoKaldir = new MenuItem { Header = "Tek Sayfalardan Logo Kaldır" };
            tekSayfaOkulLogoKaldir.Click += (o, args) =>
            {
                for (int i = 0; i < fdBelge.Pages.Count; i += 2)
                {
                    var sayfa = (Grid)((Grid)fdBelge.Pages.ElementAt(i).Child.Children[0]).Children[0];

                    var antetLogo = ExtensionService.FindChildByTag<Border>(sayfa, TagNameConstants.AntetLogo);
                    if (antetLogo != null)
                    {
                        antetLogo.Background = new SolidColorBrush(Color.FromArgb(255, 137, 183, 212));
                    }
                }

            };
            mainMenu.Items.Add(tekSayfaOkulLogoKaldir);

            #endregion

            #region Çift Sayfalardan Logo Kaldır
            var ciftSayfaOkulLogoKaldir = new MenuItem { Header = "Çift Sayfalardan Logo Kaldır" };
            tekSayfaOkulLogoKaldir.Click += (o, args) =>
            {
                for (int i = 1; i < fdBelge.Pages.Count; i += 2)
                {
                    var sayfa = (Grid)((Grid)fdBelge.Pages.ElementAt(i).Child.Children[0]).Children[0];

                    var antetLogo = ExtensionService.FindChildByTag<Border>(sayfa, TagNameConstants.AntetLogo);
                    if (antetLogo != null)
                    {
                        antetLogo.Background = new SolidColorBrush(Color.FromArgb(255, 137, 183, 212));
                    }
                }

            };
            mainMenu.Items.Add(ciftSayfaOkulLogoKaldir);

            #endregion

            #region Tek Sayfalara Resim Ekle
            var tekSayfaResimEkle = new MenuItem { Header = "Tek Sayfalara Resim Ekle" };
            tekSayfaResimEkle.Click += (o, args) =>
            {
                var dlg = new OpenFileDialog { Title = "Logo Resmi Aç", Filter = "PNG Dosyaları|*.png" };
                var retval = dlg.ShowDialog();

                if (retval.Value)
                {
                    for (int i = 0; i < fdBelge.Pages.Count; i += 2)
                    {
                        var sayfa = (Grid)((Grid)fdBelge.Pages.ElementAt(i).Child.Children[0]).Children[0];

                        var cocukFoto = ExtensionService.FindChildByTag<Border>(sayfa, TagNameConstants.AntetFoto);
                        if (cocukFoto != null)
                        {
                            cocukFoto.Background = BelgeUretHelper.StreamToImageBrush(dlg.FileName);
                        }
                    }
                }
            };
            mainMenu.Items.Add(tekSayfaResimEkle);

            #endregion

            #region Çift Sayfalara Resim Ekle
            var ciftSayfaResimEkle = new MenuItem { Header = "Çift Sayfalara Resim Ekle" };
            ciftSayfaResimEkle.Click += (o, args) =>
            {
                var dlg = new OpenFileDialog { Title = "Logo Resmi Aç", Filter = "PNG Dosyaları|*.png" };
                var retval = dlg.ShowDialog();

                if (retval.Value)
                {
                    for (var i = 1; i < fdBelge.Pages.Count; i += 2)
                    {
                        var sayfa = (Grid)((Grid)fdBelge.Pages.ElementAt(i).Child.Children[0]).Children[0];

                        var cocukFoto = ExtensionService.FindChildByTag<Border>(sayfa, TagNameConstants.AntetFoto);
                        if (cocukFoto != null)
                        {
                            cocukFoto.Background = BelgeUretHelper.StreamToImageBrush(dlg.FileName);
                        }
                    }
                }
            };
            mainMenu.Items.Add(ciftSayfaResimEkle);

            #endregion

            #region Tek Sayfalardan Resim Kaldır
            var tekSayfaResimKaldir = new MenuItem { Header = "Tek Sayfalardan Resim Kaldır" };
            tekSayfaResimKaldir.Click += (o, args) =>
            {
                for (int i = 0; i < fdBelge.Pages.Count; i += 2)
                {
                    var sayfa = (Grid)((Grid)fdBelge.Pages.ElementAt(i).Child.Children[0]).Children[0];

                    var cocukFoto = ExtensionService.FindChildByTag<Border>(sayfa, TagNameConstants.AntetFoto);
                    if (cocukFoto != null)
                    {
                        cocukFoto.Background = new SolidColorBrush(Color.FromArgb(255, 137, 183, 212));
                    }
                }

            };
            mainMenu.Items.Add(tekSayfaResimKaldir);

            #endregion

            #region Çift Sayfalardan Resim Kaldır
            var ciftSayfaResimKaldir = new MenuItem { Header = "Çift Sayfalardan Resim Kaldır" };
            ciftSayfaResimKaldir.Click += (o, args) =>
            {
                for (int i = 1; i < fdBelge.Pages.Count; i += 2)
                {
                    var sayfa = (Grid)((Grid)fdBelge.Pages.ElementAt(i).Child.Children[0]).Children[0];

                    var cocukFoto = ExtensionService.FindChildByTag<Border>(sayfa, TagNameConstants.AntetFoto);
                    if (cocukFoto != null)
                    {
                        cocukFoto.Background = new SolidColorBrush(Color.FromArgb(255, 137, 183, 212));
                    }
                }

            };
            mainMenu.Items.Add(ciftSayfaResimKaldir);

            #endregion
            #endregion
        }
        public void Yenile()
        {
            foreach (var page in fdBelge.Pages)
            {
                page.Child.UpdateLayout();
                page.UpdateLayout();
            }
            drReader.UpdateLayout();
            UpdateLayout();
        }
        private void DocumentViewerDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(SayfaSablonEntity)))
            {
                var yeniSayfa = (SayfaSablonEntity)e.Data.GetData(typeof(SayfaSablonEntity));
                if (yeniSayfa == null) return;
                if (_buyukKapakMi)
                {
                    MessageBox.Show("Büyük Kapak eklenen Dökümana başka bir sayfa eklenemez.");
                    return;
                }
                if (IsValidExtension(yeniSayfa.Path, ValidFixedDocumenDropExtension) == false) return;

                var sayfaSablonGrid = (Grid)XamlReader.Load(File.OpenRead(yeniSayfa.Path));
                ProcessorEkle(sayfaSablonGrid);
                Grid eklenecekSayfa;
                var fpSayfa = new FixedPage();
                if (yeniSayfa.Path.Contains("Kapak"))
                {
                    _kapakMi = true;

                    eklenecekSayfa = SayfaHelper.KapakOlustur(sayfaSablonGrid, _yazici.UserPrintTicket.PageMediaSize);
                    if (eklenecekSayfa.Width > eklenecekSayfa.Height && _yazici.UserPrintTicket.PageMediaSize.Width != null)
                    {
                        _buyukKapakMi = true;
                        if (_yazici.UserPrintTicket.PageMediaSize.Width != null)
                            fpSayfa.Width = _yazici.UserPrintTicket.PageMediaSize.Width.Value * 2;
                        if (_yazici.UserPrintTicket.PageMediaSize.Height != null)
                            fpSayfa.Height = _yazici.UserPrintTicket.PageMediaSize.Height.Value;
                    }
                    else
                    {
                        if (_yazici.UserPrintTicket.PageMediaSize.Width != null)
                            fpSayfa.Width = _yazici.UserPrintTicket.PageMediaSize.Width.Value;
                        if (_yazici.UserPrintTicket.PageMediaSize.Height != null)
                            fpSayfa.Height = _yazici.UserPrintTicket.PageMediaSize.Height.Value;
                    }
                }
                else
                {
                    eklenecekSayfa = SayfaHelper.Olustur(sayfaSablonGrid, _yazici.UserPrintTicket.PageMediaSize, _marj);
                    if (_yazici.UserPrintTicket.PageMediaSize.Width != null)
                        fpSayfa.Width = _yazici.UserPrintTicket.PageMediaSize.Width.Value;
                    if (_yazici.UserPrintTicket.PageMediaSize.Height != null)
                        fpSayfa.Height = _yazici.UserPrintTicket.PageMediaSize.Height.Value;
                }


                CreatePageContextMenu(fpSayfa);
                fpSayfa.Children.Add(eklenecekSayfa);
                var container = new PageContent { Child = fpSayfa };

                fdBelge.Pages.Add(container);
                do
                {
                    drReader.MoveDown();
                } while (drReader.PageCount > 1 && drReader.CanMoveDown);
                drReader.ScrollPageDown();
            }
            else if (e.Data.GetDataPresent(typeof(BelgeSablonEntity)))
            {
                var belge = (BelgeSablonEntity)e.Data.GetData(typeof(BelgeSablonEntity));
                if (belge == null) return;
                if (IsValidExtension(belge.Path, ValidFixedDocumenDropExtension) == false) return;
                BelgeAc(belge.Path);
            }
            SayfaNoAyarla();
        }

        private void DocumentViewerDragLeave(object sender, DragEventArgs e)
        {
            //var fd = (sender as FlowDocument);
            //if (fd != null) fd.Background = new SolidColorBrush(Colors.White);
        }
        #endregion
        private void ProcessorEkle(Grid sayfaSablonGrid)
        {
            var tag = sayfaSablonGrid.Tag.ToString();
            var t = Type.GetType(tag);
            if (t == null)
            {
                MessageBox.Show(
                    "İşleyici belirtilmedi!!!\nBelge şablonun Tag özelliğine belgeyi işleyecek sınıfın tam adı yazılmalıdır");
                return;
            }
            var processor = (ProcessorTemplate)Activator.CreateInstance(t);
            processor.Process(sayfaSablonGrid);
        }
        private void BosAlanTemizle()
        {
            var document = drReader.Document as FixedDocument;
            if (document != null)
                foreach (var item in document.Pages)
                {
                    var sayfa = (Grid)((Grid)item.Child.Children[0]).Children[0];
                    var cocukFoto = ExtensionService.FindChildByTag<Border>(sayfa, TagNameConstants.AntetFoto);
                    var antetLogo = ExtensionService.FindChildByTag<Border>(sayfa, TagNameConstants.AntetLogo);
                    if (cocukFoto != null && cocukFoto.Background != null && cocukFoto.Background.GetType() != typeof(ImageBrush))
                    {
                        cocukFoto.Visibility = Visibility.Hidden;
                    }
                    if (antetLogo != null && antetLogo.Background != null && antetLogo.Background.GetType() != typeof(ImageBrush))
                    {
                        antetLogo.Visibility = Visibility.Hidden;
                    }
                    //item.UpdateLayout();
                    sayfa.UpdateLayout();
                }
        }

        private void BosAlanBackgroundAyarla()
        {
            var document = drReader.Document as FixedDocument;
            if (document != null)
                foreach (var item in document.Pages)
                {
                    var sayfa = (Grid)((Grid)item.Child.Children[0]).Children[0];
                    var cocukFoto = ExtensionService.FindChildByTag<Border>(sayfa, TagNameConstants.AntetFoto);
                    var antetLogo = ExtensionService.FindChildByTag<Border>(sayfa, TagNameConstants.AntetLogo);
                    if (cocukFoto != null) cocukFoto.Visibility = Visibility.Visible;
                    if (antetLogo != null) antetLogo.Visibility = Visibility.Visible;
                    sayfa.UpdateLayout();
                    //item.UpdateLayout();
                }
        }
        private void BuyukKapakYaziciAyarla()
        {
            if (_buyukKapakMi)
            {
                _prnDialog.PrintTicket.PageMediaSize = new PageMediaSize(_prnDialog.PrintTicket.PageMediaSize.Height.Value,
                                                                                     _prnDialog.PrintTicket.PageMediaSize.Width.Value * 2);
                _prnDialog.PrintTicket.PageOrientation = PageOrientation.Landscape;
                _prnDialog.PrintQueue.UserPrintTicket = _prnDialog.PrintTicket;
                _yazici.UserPrintTicket = _prnDialog.PrintTicket;
            }
        }
        private void BuyukKapakYaziciGeriAl()
        {
            if (_buyukKapakMi)
            {
                _prnDialog.PrintTicket.PageMediaSize = new PageMediaSize(_prnDialog.PrintTicket.PageMediaSize.Height.Value / 2,
                                                                        _prnDialog.PrintTicket.PageMediaSize.Width.Value);
                _prnDialog.PrintTicket.PageOrientation = PageOrientation.Portrait;
                _prnDialog.PrintQueue.UserPrintTicket = _prnDialog.PrintTicket;
                _yazici.UserPrintTicket = _prnDialog.PrintTicket;
            }
        }
        #region DocumentViewer Commands
        public bool Yazdir()
        {

            
            try
            {
                drReader.Print();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Belge Yazdırma Hatası:" + ex.Message + "\n" + ex.InnerException.Message);
                return false;
            }

        }

        public bool DogrudanYazdir()
        {

            try
            {
                BosAlanTemizle();
                BuyukKapakYaziciAyarla();
                var paginator = new PageRangeDocumentPaginator(drReader.Document.DocumentPaginator, _prnDialog.PageRange, _yazici.UserPrintTicket, _marj);
                _prnDialog.PrintDocument(paginator, "Belge");
                BuyukKapakYaziciGeriAl();
                paginator.Arrange();
                BosAlanBackgroundAyarla();
                UpdateLayout();
                drReader.UpdateLayout();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Doğrudan Belge Yazdırma Hatası:" + ex);
                return false;
            }
        }
        public void Yaklas()
        {
            drReader.IncreaseZoom();
        }
        public void Uzaklas()
        {
            drReader.DecreaseZoom();
        }
        public void GercekBoyut()
        {
            drReader.Zoom = 100;
        }
        public void EkranaSigdir()
        {
            drReader.FitToWidth();
        }
        public void TumSayfa()
        {
            drReader.FitToMaxPagesAcross(1);
        }
        public void IkiSayfa()
        {
            drReader.FitToMaxPagesAcross(4);
        }

        #endregion
    }
}
