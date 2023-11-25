using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BilisselBeceriler.BelgeEditor.Library.Enums;
using BilisselBeceriler.BelgeEditor.Library.Extensions;
using BilisselBeceriler.BelgeEditor.Library.Model;
using BilisselBeceriler.BelgeEditor.Library.Views;
using SilverFlow.Controls;

namespace BilisselBeceriler.BelgeEditor.Library.Types
{
    class TransparentBireyselHavuzProcessor : ProcessorTemplate
    {
        public override void Process(Grid sayfaSablonGrid)
        {
            foreach (var canvas in ExtensionService.FindVisualChildren<Canvas>(sayfaSablonGrid))
            {
                canvas.AllowDrop = true;
                canvas.DragEnter += OnDragEnter;
                canvas.DragOver += OnDragOver;
                canvas.Drop += OnDrop;
                canvas.DragLeave += OnDragLeave;

                ContextMenuHazirla(canvas);
            }

            foreach (var shape in ExtensionService.FindVisualChildren<Shape>(sayfaSablonGrid))
            {
                if (shape.Tag == null)
                {
                    shape.AllowDrop = true;
                    shape.DragEnter += ShapeOnDragEnter;
                    shape.DragOver += ShapeOnDragOver;
                    shape.Drop += ShapeOnDrop;
                    shape.DragLeave += ShapeOnDragLeave;
                    ContextMenuHazirla(shape);
                }
            }
        }

        #region shape events
        public void ShapeOnDragEnter(object sender, DragEventArgs e)
        {
            HandleOnDragEnter<ImageEntity, BireyselEntity>(e);
        }
        public void ShapeOnDragOver(object sender, DragEventArgs e)
        {
            HandleOnDragOver<ImageEntity, BireyselEntity, Border>(sender, e);
        }
        public void ShapeOnDragLeave(object sender, DragEventArgs e)
        {
            HandleOnDragLeave<ImageEntity, BireyselEntity, Border>(sender, e);
        }
        public void ShapeOnDrop(object sender, DragEventArgs e)
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

            #region Context Menu
            shape.ContextMenu = CreateMenu(shape);
            #endregion

            ChangeTargetState(shape, DragState.Drop);
            e.Handled = true;
        }

        #endregion

        #region canvas events
        public override void OnDragEnter(object sender, DragEventArgs e)
        {
            HandleOnDragEnter<ImageEntity>(e);
        }
        public override void OnDragOver(object sender, DragEventArgs e)
        {
            HandleOnDragOver<ImageEntity, Canvas>(sender, e);
        }
        public override void OnDragLeave(object sender, DragEventArgs e)
        {
            HandleOnDragLeave<ImageEntity, Canvas>(sender, e);
        }
        public override void OnDrop(object sender, DragEventArgs e)
        {
            var image = e.Data.GetData(typeof(ImageEntity)) as ImageEntity;
            if (image == null) return;

            if (IsValidExtension(image.Path, ValidExtension) == false) return;
            var canvas = (sender as Canvas);
            if (canvas == null) return;
            var ib = new ImageBrush { ImageSource = new BitmapImage(new Uri(image.Path, UriKind.RelativeOrAbsolute)), Stretch = Stretch.Uniform };
            Shape shape = new Rectangle();
            shape.Width = canvas.ActualWidth;
            shape.Height = canvas.ActualHeight;
            shape.SetValue(Canvas.LeftProperty, Convert.ToDouble(0));
            shape.SetValue(Canvas.TopProperty, Convert.ToDouble(0));
            shape.Fill = ib;

          

            canvas.Children.Add(shape);

            #region Context Menu
            ContextMenuHazirla(canvas);
            #endregion

            ChangeTargetState(canvas, DragState.Drop);
            e.Handled = true;
        }

        public override string ValidExtension
        {
            get { return ".png"; }
        }
        #endregion

        private void ContextMenuHazirla(Shape shape)
        {
            shape.ContextMenu = CreateMenu(shape);
        }
        private void ContextMenuHazirla(Canvas canvas)
        {
            foreach (var item in canvas.Children)
            {
                if (item is Shape)
                {
                    var shape = item as Shape;
                    shape.ContextMenu = CreateMenu(shape);
                }
            }
        }


        private ContextMenu CreateMenu(Shape shape)
        {
            var mainMenu = new ContextMenu();

            #region Sil
            var itemSil = new MenuItem { Header = "Sil" };
            itemSil.Click += (o, args) =>
                {
                    try
                    {
                        var t = GetMenuItemSourceControlType(o);
                        if (InheritsFrom(t, typeof(Shape)))
                        {
                            var shp = GetMenuItemSourceControl<Shape>(o);
                            if (shp != null)
                            {
                                ((Canvas)shp.Parent).Children.Remove(shp);
                            }
                        }
                        else if (InheritsFrom(t, typeof(Panel)))
                        {
                            var cnv = GetMenuItemSourceControl<Panel>(o);
                            if (cnv != null)
                            {
                                if (cnv.Children.Count > 0)
                                {
                                    cnv.Children.RemoveAt(cnv.Children.Count - 1);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Silerken hata oluştu:" + ex, "Bilişsel Beceriler", MessageBoxButton.OK);
                    }
                    

                };
            mainMenu.Items.Add(itemSil);
            #endregion

            #region Alta Gönder
            var arkayaGonder = new MenuItem { Header = "Arkaya Gönder" };
            arkayaGonder.Click += (o, args) =>
                {
                    try
                    {
                        var t = GetMenuItemSourceControlType(o);
                        if (InheritsFrom(t, typeof(Shape)))
                        {
                            var shp = GetMenuItemSourceControl<Shape>(o);
                            var parentCanvas = (Canvas)shp.Parent;
                            if (parentCanvas.Children.Count <= 1) return;
                            var hedefIndex = parentCanvas.Children.IndexOf(shp) - 1;
                            //var temp = (Shape)parentCanvas.Children[hedefIndex];
                            parentCanvas.Children.Remove(shp);
                            parentCanvas.Children.Insert(hedefIndex, shp);
                            //parentCanvas.Children[hedefIndex] = shp;
                            //parentCanvas.Children[hedefIndex + 1] = temp;
                        }
                        else if (InheritsFrom(t, typeof(Panel)))
                        {
                            var cnv = GetMenuItemSourceControl<Panel>(o);
                            if (cnv.Children.Count <= 1) return;
                            var shp = cnv.Children[cnv.Children.Count - 1];
                            var hedefIndex = cnv.Children.Count - 2;
                            cnv.Children.Remove(shp);
                            cnv.Children.Insert(hedefIndex, shp);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Resim arkaya gönderilirken hata oluştu Hata:" + ex, "Bilişsel Beceriler",
                                        MessageBoxButton.OK);
                    }



                };
            mainMenu.Items.Add(arkayaGonder);
            #endregion

            #region En Alta Gönder
            var enAltaGonder = new MenuItem { Header = "En Alta Gönder" };
            enAltaGonder.Click += (o, args) =>
            {
                try
                {
                    var t = GetMenuItemSourceControlType(o);
                    if (InheritsFrom(t, typeof(Shape)))
                    {
                        var shp = GetMenuItemSourceControl<Shape>(o);
                        var parentCanvas = (Canvas)shp.Parent;
                        if (parentCanvas.Children.Count <= 1) return;
                        const int hedefIndex = 0;
                        parentCanvas.Children.Remove(shp);
                        parentCanvas.Children.Insert(hedefIndex, shp);
                    }
                    else if (InheritsFrom(t, typeof(Panel)))
                    {
                        var cnv = GetMenuItemSourceControl<Panel>(o);
                        if (cnv.Children.Count <= 1) return;
                        var shp = cnv.Children[cnv.Children.Count - 1];
                        const int hedefIndex = 0;
                        cnv.Children.Remove(shp);
                        cnv.Children.Insert(hedefIndex, shp);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("En alta gönderilirken hata oluştu:" + ex, "Bilişsel Beceriler", MessageBoxButton.OK);
                }
                
            };
            mainMenu.Items.Add(enAltaGonder);
            #endregion

            #region Düzenle
            var itemDuzenle = new MenuItem { Header = "Düzenle" };
            itemDuzenle.Click += (o, args) =>
                {
                    try
                    {
                        var t = GetMenuItemSourceControlType(o);
                        if (InheritsFrom(t, typeof(Shape)))
                        {
                            var cnv = (Panel)GetMenuItemSourceControl<Shape>(o).Parent;
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
                            var cnv = GetMenuItemSourceControl<Panel>(o);
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
                        MessageBox.Show("Düzenlenirken hata oluştu:" + ex, "Bilişsel Beceriler", MessageBoxButton.OK);
                    }
                    
                
            };
            mainMenu.Items.Add(itemDuzenle);
            #endregion

            #region Kopyala/Yapistir
            //canvas.ContextMenu = mainMenu;

            var itemKopyala = new MenuItem { Header = "Havuz Kopyala" };
            itemKopyala.Click += (o, args) =>
                {
                    try
                    {
                        var havuzType = GetHavuzType(o);
                        if (havuzType == null) return;
                        if (havuzType == typeof(Grid))
                        {
                            Common.KopyaHavuz = GetHavuz<Grid>(o);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Havuz kopyalanırken hata oluştu:" + ex, "Bilişsel Beceriler",
                                        MessageBoxButton.OK);
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
