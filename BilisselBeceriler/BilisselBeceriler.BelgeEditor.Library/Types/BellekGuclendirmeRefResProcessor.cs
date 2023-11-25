using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using BilisselBeceriler.BelgeEditor.Library.Constants;
using BilisselBeceriler.BelgeEditor.Library.Enums;
using BilisselBeceriler.BelgeEditor.Library.Extensions;
using BilisselBeceriler.BelgeEditor.Library.Model;

namespace BilisselBeceriler.BelgeEditor.Library.Types
{
    /// <summary>
    /// Bellek guclendirme referans resim isleyicisi
    /// </summary>
    public class BellekGuclendirmeRefResProcessor : ProcessorTemplate
    {
        /// <summary>
        /// Suruklenebilecek resmin uzantisi
        /// </summary>
        public override string ValidExtension
        {
            get { return ".png"; }
        }

        public override void Process(Grid sayfaSablonGrid)
        {
            base.Process(sayfaSablonGrid);
            foreach (var border in ExtensionService.FindVisualChildren<Border>(sayfaSablonGrid))
            {
                if (border.Tag != null)
                {
                    var tag = border.Tag.ToString();
                    if ((String.Compare(tag, TagNameConstants.AntetFoto, StringComparison.OrdinalIgnoreCase) == 0 || String.Compare(tag, TagNameConstants.AntetLogo, StringComparison.OrdinalIgnoreCase) == 0))
                        continue;
                }

                border.AllowDrop = true;
                border.DragEnter += OnDragEnter;
                border.DragOver += OnDragOver;
                border.Drop += OnDrop;
                border.DragLeave += OnDragLeave;

                var grid = (Canvas)border.Parent;
                grid.AllowDrop = true;
                grid.DragEnter += GridOnDragEnter;
                grid.DragOver += GridOnDragOver;
                grid.Drop += GridOnDrop;
                grid.DragLeave += GridOnDragLeave;
            }
        }

        #region Referans Resim Border Events
        public override void OnDragEnter(object sender, DragEventArgs e)
        {
            HandleOnDragEnter<ImageEntity>(e, DirectoryNameConstants.BellekGuclendirmeZeminPathName);
            e.Handled = false;
        }
        public override void OnDragOver(object sender, DragEventArgs e)
        {
            HandleOnDragOver<ImageEntity, Border>(sender, e, DirectoryNameConstants.BellekGuclendirmeZeminPathName);
            e.Handled = false;
        }
        public override void OnDrop(object sender, DragEventArgs e)
        {
            if (EnableDragDrop<ImageEntity>(e, DirectoryNameConstants.BellekGuclendirmeZeminPathName))
            {
                var image = (ImageEntity)e.Data.GetData(typeof(ImageEntity));
                var border = (sender as Border);
                if (border == null) return;
                var ib = new ImageBrush { ImageSource = new BitmapImage(new Uri(image.Path, UriKind.RelativeOrAbsolute)) };
                border.Background = ib;
                ChangeTargetState(border, DragState.Drop);
            }
            e.Handled = false;
        }
        public override void OnDragLeave(object sender, DragEventArgs e)
        {
            HandleOnDragLeave<ImageEntity, Border>(sender, e, DirectoryNameConstants.BellekGuclendirmeZeminPathName);
            e.Handled = false;
        }
        #endregion

        #region Zemin Referans Resim Canvas Events
        public void GridOnDragEnter(object sender, DragEventArgs e)
        {
            HandleOnDragEnter<ImageEntity>(e, DirectoryNameConstants.BellekGuclendirmeKarakterPathName);
        }
        public void GridOnDragOver(object sender, DragEventArgs e)
        {
            HandleOnDragOver<ImageEntity, Canvas>(sender, e, DirectoryNameConstants.BellekGuclendirmeKarakterPathName);
        }


        public void GridOnDrop(object sender, DragEventArgs e)
        {
            if (EnableDragDrop<ImageEntity>(e, DirectoryNameConstants.BellekGuclendirmeKarakterPathName))
            {
                var canvas = (sender as Canvas);
                if (canvas == null) return;
                var imageEntitiy = (ImageEntity)e.Data.GetData(typeof(ImageEntity));
                var image = new Image { Source = new BitmapImage(new Uri(imageEntitiy.Path, UriKind.RelativeOrAbsolute)), Cursor = Cursors.Hand };

                Point p = e.GetPosition(canvas);
                image.SetValue(Canvas.LeftProperty, p.X);
                image.SetValue(Canvas.TopProperty, p.Y);
                image.AddHandler(UIElement.MouseLeftButtonDownEvent, new MouseButtonEventHandler(Handle_MouseDown));
                image.AddHandler(UIElement.MouseMoveEvent, new MouseEventHandler(Handle_MouseMove));
                image.AddHandler(UIElement.MouseLeftButtonUpEvent, new MouseButtonEventHandler(Handle_MouseUp));                
                canvas.Children.Add(image);
                ChangeTargetState(canvas, DragState.Drop);
            }
            e.Handled = false;
        }

        #region Karakter Drag Drop
        bool isMouseCaptured;
        double mouseVerticalPosition;
        double mouseHorizontalPosition;

        public void Handle_MouseDown(object sender, MouseEventArgs args)
        {
            Image item = sender as Image;
            mouseVerticalPosition = args.GetPosition(null).Y;
            mouseHorizontalPosition = args.GetPosition(null).X;
            isMouseCaptured = true;
            item.CaptureMouse();
            args.Handled = true;
        }

        public void Handle_MouseMove(object sender, MouseEventArgs args)
        {
            Image item = sender as Image;
            if (isMouseCaptured)
            {

                // Calculate the current position of the object.
                double deltaV = args.GetPosition(null).Y - mouseVerticalPosition;
                double deltaH = args.GetPosition(null).X - mouseHorizontalPosition;
                double newTop = deltaV + (double)item.GetValue(Canvas.TopProperty);
                double newLeft = deltaH + (double)item.GetValue(Canvas.LeftProperty);

                // Set new position of object.
                item.SetValue(Canvas.TopProperty, newTop);
                item.SetValue(Canvas.LeftProperty, newLeft);

                // Update position global variables.
                mouseVerticalPosition = args.GetPosition(null).Y;
                mouseHorizontalPosition = args.GetPosition(null).X;
            }
            
        }

        public void Handle_MouseUp(object sender, MouseEventArgs args)
        {
            Image item = sender as Image;
            isMouseCaptured = false;
            item.ReleaseMouseCapture();
            mouseVerticalPosition = -1;
            mouseHorizontalPosition = -1;
        }
        #endregion
        public void GridOnDragLeave(object sender, DragEventArgs e)
        {
            HandleOnDragLeave<ImageEntity, Canvas>(sender, e);
        }
        #endregion

    }
}
