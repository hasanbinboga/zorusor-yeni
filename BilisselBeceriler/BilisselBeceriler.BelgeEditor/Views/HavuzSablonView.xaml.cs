using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using BilisselBeceriler.BelgeEditor.Library.Constants;
using BilisselBeceriler.BelgeEditor.Library.Model;
using BilisselBeceriler.BelgeEditor.Library.Service;
using System.Configuration;
using System.Collections.ObjectModel;
using System.Windows.Markup;
using System.IO;
using System.Windows.Media;


namespace BilisselBeceriler.BelgeEditor.Views
{
    public partial class HavuzSablonView
    {
        private IFolderService FolderService { get; set; }
        private readonly object _dummyNode = null;

        public HavuzSablonView()
        {
            InitializeComponent();
            FolderService = new FolderService();
            var folderList = FolderService.GetFolders(ConfigurationManager.AppSettings.Get(PathNameConstants.MainPath) + ConfigurationManager.AppSettings.Get(PathNameConstants.HavuzSablonPath));
            foreach (var item in folderList.Select(folderInfo => new TreeViewItem { Header = folderInfo.Name, Tag = folderInfo.Tag }))
            {
                item.Items.Add(_dummyNode);
                item.Expanded += FolderExpanded;
                foldersItem.Items.Add(item);
            }
        }
        void FolderExpanded(object sender, RoutedEventArgs e)
        {
            var item = (TreeViewItem)sender;
            if (item.Items.Count != 1 || item.Items[0] != _dummyNode) return;
            item.Items.Clear();
            try
            {
                foreach (FolderEntity s in FolderService.GetFolders(item.Tag.ToString()))
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
        private void FoldersItemSelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            try
            {
                Cursor = Cursors.Wait;
                tbMesaj.Text = "Havuzlar aranıyor...";
                var tree = (TreeView)sender;
                var temp = ((TreeViewItem)tree.SelectedItem);
                var liste = FolderService.GetFiles(temp.Tag.ToString(), "*.xaml");
                var sablonlar = new ObservableCollection<HavuzSablonEntity>();
                foreach (var item in liste)
                {
                    var g = XamlReader.Load(File.OpenRead(item.Path)) as Grid;
                    if (g == null) continue;
                    g.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
                    g.Arrange(new Rect(new Point(0, 0), new Point(g.DesiredSize.Width, g.DesiredSize.Height)));
                    sablonlar.Add(new HavuzSablonEntity { ContainerObject = g, Path = item.Path, Name = Path.GetFileName(item.Path) });
                    
                }
                lstImageGallery.DataContext = sablonlar;
                if (liste.Count > 0)
                {
                    tbMesaj.Text = temp.Header + " konumunda " + liste.Count + " adet havuz şablonu bulundu";
                }
                else
                {
                    tbMesaj.Text = temp.Header + " konumunda " + " havuz şablonu bulunamadı !!!";
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

        private void ImagePreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var border = e.Source as Border;
            if (border == null) return;
            var xamlKapsul = (((HavuzSablonEntity)((ContentControl)((VisualBrush)border.Background).Visual).DataContext));
            var data = new DataObject(typeof(HavuzSablonEntity), xamlKapsul);
            DragDrop.DoDragDrop(border, data, DragDropEffects.Copy);
        }
    }
}
