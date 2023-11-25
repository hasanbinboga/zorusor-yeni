using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using BilisselBeceriler.BelgeEditor.Library.Constants;
using BilisselBeceriler.BelgeEditor.Library.Controls;
using BilisselBeceriler.BelgeEditor.Library.Model;
using BilisselBeceriler.BelgeEditor.Library.Service;

namespace BilisselBeceriler.BelgeEditor.Views
{
    /// <summary>
    /// Interaction logic for BelgeSablonView.xaml
    /// </summary>
    public partial class BelgeSablonView
    {
        private FolderService FolderService { get; set; }
        private readonly object _dummyNode;
        private UcBelgeViewer _belge;
        private string _seciliKlasor;
        public bool KapatilacakMi;
        public BelgeSablonView(ref UcBelgeViewer kaydedilecekBelge)
        {
            _belge = kaydedilecekBelge;
            InitializeComponent();
            FolderService = new FolderService();
            var folderList = FolderService.GetFolders(ConfigurationManager.AppSettings.Get(PathNameConstants.MainPath) + ConfigurationManager.AppSettings.Get(PathNameConstants.BelgeSablonPath));
            foreach (var item in folderList.Select(folderInfo => new TreeViewItem { Header = folderInfo.Name, Tag = folderInfo.Tag }))
            {
                item.Items.Add(_dummyNode);
                item.Expanded += FolderExpanded;
                foldersItem.Items.Add(item);
            }
        }
        private void Yenile()
        {
            FolderService = new FolderService();
            var folderList = FolderService.GetFolders(ConfigurationManager.AppSettings.Get(PathNameConstants.MainPath) + ConfigurationManager.AppSettings.Get(PathNameConstants.BelgeSablonPath));
            foreach (var item in folderList.Select(folderInfo => new TreeViewItem { Header = folderInfo.Name, Tag = folderInfo.Tag }))
            {

                if (foldersItem.Items.OfType<TreeViewItem>().
                    Any(s => s.Header.ToString() == item.Header.ToString()) == false)
                {
                    item.Items.Add(_dummyNode);
                    item.Expanded += FolderExpanded;
                    foldersItem.Items.Add(item);
                }
            }
            if (foldersItem.SelectedItem != null)
            {
                BelgeGoster(foldersItem.SelectedItem as TreeViewItem);
            }
        }
        void FolderExpanded(object sender, RoutedEventArgs e)
        {
            var item = (TreeViewItem)sender;
            if (item.Items.Count != 1 || item.Items[0] != _dummyNode) return;
            item.Items.Clear();
            try
            {
                _seciliKlasor = item.Tag.ToString();
                foreach (FolderEntity s in FolderService.GetFolders(_seciliKlasor))
                {
                    var subitem = new TreeViewItem { Header = s.Name, Tag = s.Tag, FontWeight = FontWeights.Normal };
                    subitem.Items.Add(_dummyNode);
                    subitem.Expanded += FolderExpanded;
                    item.Items.Add(subitem);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void BelgeGoster(TreeViewItem temp)
        {
            if (temp == null) throw new ArgumentNullException("temp");
            try
            {
                Cursor = Cursors.Wait;
                tbMesaj.Text = "Belge aranıyor...";
                _seciliKlasor = temp.Tag.ToString();
                var liste = FolderService.GetBelge(temp.Tag.ToString());
                var sablonlar = new ObservableCollection<BelgeSablonEntity>();
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
                            if (gridParent != null) gridParent.Children.Remove(grid);
                            sablonlar.Add(new BelgeSablonEntity { ContainerObject = grid, Path = item.Path, Name = Path.GetFileName(item.Path) });
                        }
                    }

                }
                lstBelgeGallery.DataContext = sablonlar;
                if (liste.Count > 0)
                {
                    tbMesaj.Text = temp.Header + " konumunda " + liste.Count + " adet belge şablonu bulundu";
                }
                else
                {
                    tbMesaj.Text = temp.Header + " konumunda " + " belge şablonu bulunamadı !!!";
                }
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

        private void FoldersItemSelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            BelgeGoster(((TreeView)sender).SelectedItem as TreeViewItem);
        }

        private void SayiOlusturClick(object sender, RoutedEventArgs e)
        {
            int sayi;
            if (int.TryParse(txtSayi.Text, out sayi))
            {
                if (!string.IsNullOrEmpty(txtAciklama.Text))
                {
                    string yol = ConfigurationManager.AppSettings.Get(PathNameConstants.MainPath) + ConfigurationManager.AppSettings.Get(PathNameConstants.BelgeSablonPath);
                    for (int yas = 36; yas < 73; yas += 12)
                    {
                        Directory.CreateDirectory(yol + @"\Sayı " + sayi + "-" + txtAciklama.Text + @"\" + yas + @" AY VE SONRASI\Alıştırma Oluşturma Gereci");
                        Directory.CreateDirectory(yol + @"\Sayı " + sayi + "-" + txtAciklama.Text + @"\" + yas + @" AY VE SONRASI\Alıştırma Oluşturma Şablonu");
                        Directory.CreateDirectory(yol + @"\Sayı " + sayi + "-" + txtAciklama.Text + @"\" + yas + @" AY VE SONRASI\Bireye Özel Kitap");
                        Directory.CreateDirectory(yol + @"\Sayı " + sayi + "-" + txtAciklama.Text + @"\" + yas + @" AY VE SONRASI\Kapak");
                        Directory.CreateDirectory(yol + @"\Sayı " + sayi + "-" + txtAciklama.Text + @"\" + yas + @" AY VE SONRASI\Ek Test");
                        Directory.CreateDirectory(yol + @"\Sayı " + sayi + "-" + txtAciklama.Text + @"\" + yas + @" AY VE SONRASI\Günlük Bireysel Alıştırma");
                        Directory.CreateDirectory(yol + @"\Sayı " + sayi + "-" + txtAciklama.Text + @"\" + yas + @" AY VE SONRASI\Günlük Porjeksiyon Etkinliği");
                        Directory.CreateDirectory(yol + @"\Sayı " + sayi + "-" + txtAciklama.Text + @"\" + yas + @" AY VE SONRASI\Seviye Belirleme Testi");
                    }
                    Yenile();
                }
                else
                {
                    MessageBox.Show("Lütfen dergi için açıklama giriniz.", "Sayı Oluşturma",
                                   MessageBoxButton.OK, MessageBoxImage.Error);

                }
            }
            else
            {
                MessageBox.Show("Lütfen Yayınlanacak derginin sayısını numerik olarak giriniz.", "Sayı Oluşturma",
                                MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BelgeKaydetClick(object sender, RoutedEventArgs e)
        {
            var dosyalar = Directory.GetFiles(_seciliKlasor);
            if (dosyalar.Any(s => s.Contains("Erkek") || s.Contains("Kadin")))
            {
                MessageBox.Show("Daha Önce Cinsiyet Belirterek Şablon Kaydedildiğinden Kaydedilemedi.",
                    "Belge Kaydet", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            _belge.BelgeKaydet(_seciliKlasor + @"\Genel-Belge.xaml", KapatilacakMi);
            Yenile();
        }
        private void ErkekBelgeKaydetClick(object sender, RoutedEventArgs e)
        {
            var dosyalar = Directory.GetFiles(_seciliKlasor);
            if (dosyalar.Any(s => s.Contains("Genel")))
            {
                MessageBox.Show("Daha Önce Genel Şablon Kaydedildiğinden Kaydedilemedi.",
                    "Belge Kaydet", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            _belge.BelgeKaydet(_seciliKlasor + @"\Erkek-Belge.xaml", KapatilacakMi);
            Yenile();
        }
        private void KadinBelgeKaydetClick(object sender, RoutedEventArgs e)
        {
            var dosyalar = Directory.GetFiles(_seciliKlasor);
            if (dosyalar.Any(s => s.Contains("Genel")))
            {
                MessageBox.Show("Daha Önce Genel Şablon Kaydedildiğinden Kaydedilemedi.",
                    "Belge Kaydet", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            _belge.BelgeKaydet(_seciliKlasor + @"\Kadin-Belge.xaml", KapatilacakMi);
            Yenile();
        }

        private void Border_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var border = e.Source as Border;
            if (border == null) return;
            var belgeSablonEntity = (((BelgeSablonEntity)((ContentControl)((VisualBrush)border.Background).Visual).DataContext));
            var data = new DataObject(typeof(BelgeSablonEntity), belgeSablonEntity);
            DragDrop.DoDragDrop(border, data, DragDropEffects.Copy);
        }
    }
}
