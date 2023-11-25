using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using BilisselBeceriler.BelgeEditor.Library.Enums;
using BilisselBeceriler.BelgeEditor.Library.Extensions;
using BilisselBeceriler.BelgeEditor.Library.Model;

namespace BilisselBeceriler.BelgeEditor.Library.Types
{
    class SiralamaSoruProcessor : ProcessorTemplate
    {
        public override void Process(Grid sayfaSablonGrid)
        {
            base.Process(sayfaSablonGrid);
            foreach (var border in ExtensionService.FindVisualChildren<StackPanel>(sayfaSablonGrid))
            {
                border.AllowDrop = true;
                border.DragEnter += OnDragEnter;
                border.DragOver += OnDragOver;
                border.Drop += OnDrop;
                border.DragLeave += OnDragLeave;
            }
        }
        public override void OnDragEnter(object sender, DragEventArgs e)
        {
            HandleOnDragEnter<ImageEntity>(e);
        }
        public override void OnDragOver(object sender, DragEventArgs e)
        {
            HandleOnDragOver<ImageEntity, Border>(sender, e);
        }
        public override void OnDrop(object sender, DragEventArgs e)
        {
            var imageEntity = e.Data.GetData(typeof(ImageEntity)) as ImageEntity;
            if (imageEntity == null) return;
            if (IsValidExtension(imageEntity.Path, ValidExtension) == false) return;
            var stackPanel = (sender as StackPanel);
            if (stackPanel == null) return;
            var image = new Image
                            {
                                Source = new BitmapImage(new Uri(imageEntity.Path, UriKind.RelativeOrAbsolute)),
                                Cursor = Cursors.Hand
                            };

            //image.MouseEnter += imageMouseLeave;
            //image.MouseMove += imageMouseMove;
            CreateContexMenu(image);
            stackPanel.Children.Add(image);
            stackPanel.Background= new SolidColorBrush(Colors.White);
            ChangeTargetState(stackPanel, DragState.Drop);
            e.Handled = true;
        }

        //void imageMouseMove(object sender, MouseEventArgs e)
        //{
        //    var image = (Image)sender;
        //    var golge = new DropShadowEffect { ShadowDepth = 10, BlurRadius = 10, Color = Colors.Red, Direction = -50 };
        //    image.Effect = golge;
        //}
        //void imageMouseLeave(object sender, MouseEventArgs e)
        //{
        //    var image = (Image)sender;
        //    if (image.Effect == null) return;
        //    image.Effect = null;
        //}

        public override string ValidExtension
        {
            get { return ".png"; }
        }

        public override void OnDragLeave(object sender, DragEventArgs e)
        {
            HandleOnDragLeave<ImageEntity, Border>(sender, e);
        }

    }
}
