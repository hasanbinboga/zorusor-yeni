using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using BilisselBeceriler.BelgeEditor.Library.Enums;
using BilisselBeceriler.BelgeEditor.Library.Extensions;
using BilisselBeceriler.BelgeEditor.Library.Model;
using System.Windows.Shapes;
using BilisselBeceriler.BelgeEditor.Library.Views;
using SilverFlow.Controls;

namespace BilisselBeceriler.BelgeEditor.Library.Types
{
    public class HavuzProccesor : ProcessorTemplate
    {

        public override void Process(Grid sayfaSablonGrid)
        {
            foreach (var shape in ExtensionService.FindVisualChildren<Shape>(sayfaSablonGrid))
            {
                if (shape.Effect != null)
                    continue;
                shape.AllowDrop = true;
                shape.DragEnter += OnDragEnter;
                shape.DragOver += OnDragOver;
                shape.Drop += OnDrop;
                shape.DragLeave += OnDragLeave;
                shape.ContextMenu = CreateMenu(shape);
            }
        }
        public override void OnDragEnter(object sender, DragEventArgs e)
        {
            HandleOnDragEnter<ImageEntity, BireyselEntity>(e);
        }
        public override void OnDragOver(object sender, DragEventArgs e)
        {
            HandleOnDragOver<ImageEntity, BireyselEntity, Border>(sender, e);
        }
        public override void OnDrop(object sender, DragEventArgs e)
        {
            var image = e.Data.GetData(typeof(ImageEntity)) as ImageEntity ??
                        e.Data.GetData(typeof(BireyselEntity)) as BireyselEntity;
            if (image == null) return;

            if (IsValidExtension(image.Path, ValidExtension) == false) return;
            var shape = (sender as Shape);
            if (shape == null) return;
            var ib = new ImageBrush { ImageSource = new BitmapImage(new Uri(image.Path, UriKind.RelativeOrAbsolute)), Stretch = Stretch.Uniform };

            shape.Fill = ib;
            if (image is BireyselEntity)
                shape.Tag = (image as BireyselEntity).Tag;

            ChangeTargetState(shape, DragState.Drop);
            e.Handled = true;
        }
        public override void OnDragLeave(object sender, DragEventArgs e)
        {
            HandleOnDragLeave<ImageEntity, BireyselEntity, Border>(sender, e);
        }
        public override string ValidExtension
        {
            get { return ".png"; }
        }

        private ContextMenu CreateMenu(Shape shape)
        {
            var mainMenu = new ContextMenu();
            

            #region Düzenle
            var duzenle = new MenuItem { Header = "Düzenle" };
            var shape1 = shape;
            duzenle.Click += (sender, e) =>
            {
                try
                {
                    var t = GetMenuItemSourceControlType(sender);
                    if (InheritsFrom(t, typeof(Shape)))
                    {
                        var cnv = (Panel)GetMenuItemSourceControl<Shape>(sender).Parent;
                        var shp = (Shape)cnv.Children[cnv.Children.Count - 1];
                        var window = Window.GetWindow(shp);
                        if (window == null) return;
                        var host = window.FindName("host") as FloatingWindowHost;
                        var view = new ShapeEditView(shp);
                        if (host != null) host.Add(view);
                        view.Show();
                    }
                    if (InheritsFrom(t, typeof(Panel)))
                    {
                        var cnv = GetMenuItemSourceControl<Panel>(sender);
                        var shp = (Shape)cnv.Children[cnv.Children.Count - 1];
                        var window = Window.GetWindow(shp);
                        if (window == null) return;
                        var host = window.FindName("host") as FloatingWindowHost;
                        var view = new ShapeEditView(shp);
                        if (host != null) host.Add(view);
                        view.Show();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Düzenlerken Hata oluştu:" + ex, "Bilişsel Beceriler", MessageBoxButton.OK);
                }
                
                
            };
            mainMenu.Items.Add(duzenle);
            #endregion

            #region Kopyala/Yapistir
            var itemKopyala = new MenuItem { Header = "Havuz Kopyala" };
            itemKopyala.Click += (sender, e) =>
            {
                try
                {
                    var havuzType = GetHavuzType(sender);
                    if (havuzType == null) return;
                    if (havuzType == typeof(Grid))
                    {
                        Common.KopyaHavuz = GetHavuz<Grid>(sender);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Havuz Kopyalarken hata oluştu:" + ex, "Bilişsel Beceriler", MessageBoxButton.OK);
                }
                
            };
            mainMenu.Items.Add(itemKopyala);

            #endregion

            #region Yapistir
            var itemYapistir = new MenuItem { Header = "Havuz Yapıştır" };
            itemYapistir.Click += (sender, e) =>
            {
                try
                {
                    //var x = GetMenuItemSourceControl<Border>(sender);
                    var xType = GetHavuzType(sender);
                    if (xType == null && xType != typeof(Grid)) return;

                    if (Common.KopyaHavuz != null)
                    {
                        var x = GetHavuz<Grid>(sender).Parent as Border;
                        if (x != null)
                        {
                            Grid temp = (Grid)Common.CloneUsingXaml(Common.KopyaHavuz);

                            temp.Width = x.ActualWidth;
                            temp.Height = x.ActualWidth;
                            //temp.MaxWidth = border.ActualWidth;
                            //temp.MaxHeight = border.ActualWidth;
                            temp.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
                            temp.Arrange(new Rect(x.RenderSize));
                            HavuzProcessEkle(temp);
                            x.Child = temp;
                            x.Background = null;
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Havuz yapıştırılırken hata oluştu: " + ex.Message);
                }

            };
            mainMenu.Items.Add(itemYapistir);
            #endregion
            return mainMenu;
        }
    }
}
