using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using BilisselBeceriler.BelgeEditor.Library.Constants;
using BilisselBeceriler.BelgeEditor.Library.Extensions;
using BilisselBeceriler.BelgeEditor.Library.Model;


namespace BilisselBeceriler.BelgeEditor.Library.Types
{
    public class OnKapakProcessor : ProcessorTemplate
    {
        public override void Process(Grid sayfaSablonGrid)
        {
            base.Process(sayfaSablonGrid);
            var gridReferans = (Grid)sayfaSablonGrid.Children[0];
            gridReferans.AllowDrop = true;
            gridReferans.DragEnter += OnDragEnter;
            gridReferans.DragOver += OnDragOver;
            gridReferans.Drop += OnDrop;
            gridReferans.DragLeave += OnDragLeave;
            var grAtaturk = ExtensionService.FindChildByTag<Grid>(gridReferans, TagNameConstants.grAtaturk);
            if (grAtaturk != null)
            {
                grAtaturk.AllowDrop = true;
                grAtaturk.DragEnter += OnDragEnter;
                grAtaturk.DragOver += OnDragOver;
                grAtaturk.Drop += OnDrop;
                grAtaturk.DragLeave += OnDragLeave;
            }
            var grArkaKapak = ExtensionService.FindChildByTag<Grid>(gridReferans.Parent, TagNameConstants.grArkaKapak);
            if (grArkaKapak != null)
            {
                grArkaKapak.AllowDrop = true;
                grArkaKapak.DragEnter += OnDragEnter;
                grArkaKapak.DragOver += OnDragOver;
                grArkaKapak.Drop += OnDrop;
                grArkaKapak.DragLeave += OnDragLeave;
            }
        }
        public override void OnDragEnter(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(typeof(ImageEntity))) return;
            var image = (ImageEntity)e.Data.GetData(typeof(ImageEntity));
            if (IsValidExtension(image.Path, ValidExtension) == false) return;
            e.Effects = e.Data.GetDataPresent(typeof(string))
                            ? DragDropEffects.All
                            : DragDropEffects.None;
            e.Handled = true;
        }
        public override void OnDragOver(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(typeof(ImageEntity))) return;
            var image = (ImageEntity)e.Data.GetData(typeof(ImageEntity));
            if (IsValidExtension(image.Path, ValidExtension) == false) return;
            //var grid = (sender as Grid);
            //if (grid != null) grid.Background = new SolidColorBrush(Colors.Silver);
            e.Effects = DragDropEffects.All;
            e.Handled = true;
        }

        public override void OnDrop(object sender, DragEventArgs e)
        {
            var image = e.Data.GetData(typeof(ImageEntity)) as ImageEntity;
            if(image== null) return;

            if (IsValidExtension(image.Path, ValidExtension) == false) return;
            var grid = (sender as Grid);
            if (grid == null) return;
            var ib = new ImageBrush { ImageSource = new BitmapImage(new Uri(image.Path, UriKind.RelativeOrAbsolute)) };

            if (grid.Tag != null &&  grid.Tag.ToString() == TagNameConstants.grAtaturk)
            {
                var Ataturk = ExtensionService.FindChildByTag<Border>(grid, TagNameConstants.brAtaturk);
                if (Ataturk != null)
                {
                    Ataturk.Background = ib;
                }
            }
            else
            {
                grid.Background = ib;
            }
            e.Handled = true;
        }

        public override void OnDragLeave(object sender, DragEventArgs e)
        {
            //var grid = (sender as Grid);
            //if (grid == null) return;
            //grid.Background = new SolidColorBrush(Colors.White);
            //e.Handled = true;
        }

        public override string ValidExtension
        {
            get { return ".png"; }
        }
    }
}
