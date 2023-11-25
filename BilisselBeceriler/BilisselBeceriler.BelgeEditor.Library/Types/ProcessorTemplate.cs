using System;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;
using BilisselBeceriler.BelgeEditor.Library.Enums;
using BilisselBeceriler.BelgeEditor.Library.Extensions;
using BilisselBeceriler.BelgeEditor.Library.Model;
using System.Collections.Generic;

namespace BilisselBeceriler.BelgeEditor.Library.Types
{
    public abstract class ProcessorTemplate
    {

        public virtual void Process(Grid sayfaSablonGrid)
        {
            int i = 0;
            foreach (var textBlock in ExtensionService.FindVisualChildren<TextBlock>(sayfaSablonGrid))
            {
                if (textBlock.Parent != null)
                {
                    if (textBlock.Tag == null)
                    {
                        textBlock.Tag = "TextBox_" + i.ToString(CultureInfo.InvariantCulture);
                    }
                    i++;
                    textBlock.MouseDown += OnMouseDown;
                }

            }
        }

        private IEnumerable<MenuItem> GetStandardCommands()
        {
            var standardCommands = new List<MenuItem>();

            var item = new MenuItem { Command = ApplicationCommands.Cut };
            standardCommands.Add(item);

            item = new MenuItem { Command = ApplicationCommands.Copy };
            standardCommands.Add(item);

            item = new MenuItem { Command = ApplicationCommands.Paste };
            standardCommands.Add(item);

            return standardCommands;
        }

        void OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            var textBlock = (TextBlock)sender;
            if (textBlock != null)
            {


                var textBox = new TextBox
                {
                    Tag = textBlock.Tag,
                    Padding = textBlock.Padding,
                    FontSize = textBlock.FontSize,
                    FontWeight = textBlock.FontWeight,
                    FontFamily = textBlock.FontFamily,
                    FontStretch = textBlock.FontStretch,
                    Height = textBlock.Height,
                    Width = textBlock.Width,
                    Margin = textBlock.Margin,
                    HorizontalAlignment = textBlock.HorizontalAlignment,
                    VerticalAlignment = textBlock.VerticalAlignment,
                    Text = textBlock.Text,
                };

                #region ContextMenu Olustur
                if (textBox.Text.Contains("Telif"))
                {
                    textBox.ContextMenu = new ContextMenu();
                    foreach (var item in GetStandardCommands())
                    {
                        textBox.ContextMenu.Items.Add(item);
                    }
                    var telifKaldir = new MenuItem { Header = "Copyright Kaldır" };
                    telifKaldir.Click += (o, r) =>
                    {
                        var tb = (TextBox)((ContextMenu)((MenuItem)o).Parent).PlacementTarget;
                        var pr = (Panel)tb.Parent;
                        var tbl = ExtensionService.FindChildByTag<TextBlock>(pr, tb.Tag.ToString());
                        tbl.Background = new SolidColorBrush(Color.FromArgb(255, 137, 183, 212));
                        tbl.Foreground = new SolidColorBrush(Color.FromArgb(255, 137, 183, 212));

                    };
                    textBox.ContextMenu.Items.Add(telifKaldir);
                    var telifEkle = new MenuItem { Header = "Copyright Ekle" };
                    telifEkle.Click += (o, r) =>
                    {
                        var tb = (TextBox)((ContextMenu)((MenuItem)o).Parent).PlacementTarget;
                        var pr = (Panel)tb.Parent;
                        var tbl = ExtensionService.FindChildByTag<TextBlock>(pr, tb.Tag.ToString());
                        tbl.Background = null;
                        tbl.Foreground = new SolidColorBrush(Colors.Black);
                    };
                    textBox.ContextMenu.Items.Add(telifEkle);
                }
                #endregion
                Grid.SetColumn(textBox, Grid.GetColumn(textBlock));
                Grid.SetColumnSpan(textBox, Grid.GetColumnSpan(textBlock));
                Grid.SetRow(textBox, Grid.GetRow(textBlock));
                Grid.SetRowSpan(textBox, Grid.GetRowSpan(textBlock));
                textBox.TextAlignment = textBlock.TextAlignment;
                textBox.TextWrapping = textBox.TextWrapping;
                textBlock.SetValue(Canvas.LeftProperty, textBlock.GetValue(Canvas.LeftProperty));
                textBlock.Text = string.Empty;
                textBox.KeyDown += OnKeyDown;
                textBox.LostFocus += textBox_LostFocus;
                var parent = textBlock.Parent;
                if (parent is Panel)
                {
                    ((Panel)parent).Children.Add(textBox);
                }
                else if (parent is Border)
                {
                    ((Border)parent).Child = textBox;
                }


                Dispatcher.CurrentDispatcher.BeginInvoke((ThreadStart)(() => textBox.Focus()));
            }
        }

        /// <summary>
        /// Extension method to check the entire inheritance hierarchy of a
        /// type to see whether the given base type is inherited.
        /// </summary>
        /// <param name="t">The Type object this method was called on</param>
        /// <param name="baseType">The base type to look for in the 
        /// inheritance hierarchy</param>
        /// <returns>True if baseType is found somewhere in the inheritance 
        /// hierarchy, false if not</returns>
        public bool InheritsFrom(Type t, Type baseType)
        {
            Type cur = t.BaseType;

            while (cur != null)
            {
                if (cur == baseType)
                {
                    return true;
                }

                cur = cur.BaseType;
            }

            return false;
        }

        void textBox_LostFocus(object sender, RoutedEventArgs e)
        {
            var textBox = (TextBox)sender;
            var parent = textBox.Parent;
            if (parent is Panel)
            {
                var textBlock = ExtensionService.FindChildByTag<TextBlock>(parent, textBox.Tag.ToString());
                if (textBlock != null) textBlock.Text = textBox.Text;
                if (parent != null) ((Panel)parent).Children.Remove((TextBox)sender);
            }

        }

        void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                var textBox = (TextBox)sender;
                var parent = textBox.Parent;
                if (parent is Panel)
                {
                    var textBlock = ExtensionService.FindChildByTag<TextBlock>(parent, textBox.Tag.ToString());
                    textBlock.Text = textBox.Text;
                    ((Panel)parent).Children.Remove((TextBox)sender);
                }
                else if (parent is Border)
                {

                }
            }
        }
        public abstract void OnDragEnter(object sender, DragEventArgs e);
        public abstract void OnDragOver(object sender, DragEventArgs e);
        public abstract void OnDrop(object sender, DragEventArgs e);
        public abstract void OnDragLeave(object sender, DragEventArgs e);
        public abstract string ValidExtension { get; }
        public T GetMenuItemSourceControl<T>(object sender) where T : FrameworkElement
        {
            try
            {
                var menuItem = (MenuItem)sender;
                if (((ContextMenu)menuItem.Parent).PlacementTarget.GetType() == typeof(T) ||
                    InheritsFrom(((ContextMenu)menuItem.Parent).PlacementTarget.GetType(), typeof(T)))
                {
                    return (T)((ContextMenu)menuItem.Parent).PlacementTarget;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Seçili obje alınırken hata oluştu. Hata:" + ex, "Bilişsel Beceriler", MessageBoxButton.OK);
            }
            return null;
        }

        public Type GetMenuItemSourceControlType(object sender)
        {
            var menuItem = (MenuItem)sender;
            return ((ContextMenu)menuItem.Parent).PlacementTarget.GetType();
        }

        public T GetHavuz<T>(object sender) where T : FrameworkElement
        {
            try
            {
                if (sender.GetType() == typeof(MenuItem))
                {
                    var menuItem = (MenuItem)sender;
                    return GetHavuz<T>(((ContextMenu)menuItem.Parent).PlacementTarget);
                }
                var tagProp = sender.GetType().GetProperty("Tag");
                if (tagProp != null)
                {
                    var tagValue = tagProp.GetValue(sender, null);
                    if (tagValue == null)
                    {
                        return GetHavuz<T>(sender.GetType().GetProperty("Parent").GetValue(sender, null));
                    }
                    return (T)sender;
                }
                return null;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Seçili obje alınırken hata oluştu. Hata:" + ex, "Bilişsel Beceriler", MessageBoxButton.OK);
            }
            return null;
        }
        public Type GetHavuzType(object sender)
        {

            if (sender.GetType() == typeof(MenuItem))
            {
                var menuItem = (MenuItem)sender;
                return GetHavuzType(((ContextMenu)menuItem.Parent).PlacementTarget);
            }

            var tagProp = sender.GetType().GetProperty("Tag");

            if (tagProp != null)
            {

                var tagValue = tagProp.GetValue(sender, null);
                if (tagValue == null)
                {
                    return GetHavuzType(sender.GetType().GetProperty("Parent").GetValue(sender, null));
                }
                return sender.GetType();
            }
            return null;

        }

        /// <summary>
        /// Suruklenen nesneyi iceren klasor adi uzerinden kisitlama koymak icin directoryRestriction parametresi kullanilir.
        /// Bu parametre dolu ise suruklenen nesnenin yolunda bu parametreye atanan deger olmasi sarti aranir.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="extension"></param>
        /// <param name="directoryRestriction"></param>
        /// <returns></returns>
        protected bool IsValidExtension(string path, string extension, string directoryRestriction = null)
        {
            if (path == null || extension == null) return false;
            var fi = new FileInfo(path);
            if (fi.Exists == false) return false;
            if (fi.Extension.ToLower() != extension.ToLower()) return false;
            if (directoryRestriction != null)
            {
                if (fi.DirectoryName != null)
                {
                    return fi.DirectoryName.ToLower().Contains(directoryRestriction.ToLower());
                }
                return false;
            }
            return true;
        }

        protected void HavuzProcessEkle(Grid sayfaSablonGrid)
        {
            var tag = sayfaSablonGrid.Tag.ToString();
            var t = Type.GetType(tag);
            if (t == null)
            {
                MessageBox.Show(
                    "İşleyici belirtilmedi!!!\nHavuzun Tag özelliğine havuzu işleyecek sınıfın tam adı yazılmalıdır");
                return;
            }
            var processor = (ProcessorTemplate)Activator.CreateInstance(t);
            processor.Process(sayfaSablonGrid);
        }

        protected void CreateContexMenu(FrameworkElement hedef, string solaKaydirHeader = "Sola Kaydır", string sagaKaydirHeader = "Sağa Kaydır")
        {
            var mainMenu = new ContextMenu();
            hedef.ContextMenu = mainMenu;

           
            #region Resmi Sil
            var itemSil = new MenuItem { Header = "Sil" };
            itemSil.Click += (sender, e) =>
            {
                try
                {
                    var t = GetMenuItemSourceControlType(sender);
                    if (InheritsFrom(t, typeof(Shape)))
                    {
                        var shp = GetMenuItemSourceControl<Shape>(sender);
                        if (shp != null)
                        {
                            ((Canvas)shp.Parent).Children.Remove(shp);
                        }
                    }
                    else if (InheritsFrom(t, typeof(Panel)))
                    {
                        var cnv = GetMenuItemSourceControl<Panel>(sender);
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

            #region Sağa Kaydır
            var itemSonraki = new MenuItem { Header = sagaKaydirHeader };
            itemSonraki.Click += (sender, e) =>
            {
                try
                {
                    var image = GetMenuItemSourceControl<Image>(sender);
                    var parent = ((StackPanel)image.Parent);
                    var index = parent.Children.IndexOf(image);
                    var count = parent.Children.Count;
                    var newIndex = index + 1;
                    if (newIndex == count) return;
                    parent.Children.Remove(image);
                    parent.Children.Insert(newIndex, image);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Kaydırırken Hata oluştu:" + ex, "Bilişsel Beceriler", MessageBoxButton.OK);
                }

            };

            mainMenu.Items.Add(itemSonraki);
            #endregion

            #region Sola Kaydır
            var itemSolaKaydir = new MenuItem { Header = solaKaydirHeader };
            itemSolaKaydir.Click += (sender, e) =>
            {
                try
                {
                    var image = GetMenuItemSourceControl<Image>(sender);
                    var parent = ((StackPanel)image.Parent);
                    var index = parent.Children.IndexOf(image);
                    var newIndex = index - 1;
                    if (newIndex < 0) return;
                    parent.Children.Remove(image);
                    parent.Children.Insert(newIndex, image);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Kaydırırken hata oluştu:" + ex, "Bilişsel Beceriler", MessageBoxButton.OK);
                }

            };

            mainMenu.Items.Add(itemSolaKaydir);
            #endregion
        }
        protected void ChangeTargetState(object target, DragState state)
        {
            if (target is Border)
            {
                var border = target as Border;
                switch (state)
                {
                    case DragState.Over:
                    case DragState.Enter:
                        border.BorderBrush = new SolidColorBrush(Colors.Black);
                        border.BorderThickness = new Thickness(2);
                        break;
                    case DragState.Leave:
                    case DragState.Drop:
                        border.BorderBrush = new SolidColorBrush(Colors.Transparent);
                        border.BorderThickness = new Thickness(0);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("state");

                }
            }
            else if (target is StackPanel)
            {
                var stackPanel = target as StackPanel;
                switch (state)
                {
                    case DragState.Over:
                    case DragState.Enter:
                        stackPanel.Background = new SolidColorBrush(Colors.Silver);
                        break;
                    case DragState.Leave:
                    case DragState.Drop:
                        //stackPanel.Background = new SolidColorBrush(Color.FromArgb(255, 137, 183, 212));
                        stackPanel.Background = new SolidColorBrush(Colors.White);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("state");
                }
            }
            else if (target is Shape && target.GetType() != typeof(System.Windows.Shapes.Path))
            {
                var shape = target as Shape;
                switch (state)
                {
                    case DragState.Over:
                    case DragState.Enter:
                        shape.Stroke = new SolidColorBrush(Colors.Black);
                        shape.StrokeThickness = 2;
                        break;
                    case DragState.Leave:
                    case DragState.Drop:
                        shape.Stroke = new SolidColorBrush(Colors.Transparent);
                        shape.StrokeThickness = 0;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("state");
                }
            }
            else if (target is Canvas)
            {
                var canvas = target as Canvas;
                switch (state)
                {
                    case DragState.Over:
                    case DragState.Enter:
                        canvas.Background = new SolidColorBrush(Colors.Silver);
                        break;
                    case DragState.Leave:
                    case DragState.Drop:
                        canvas.Background = new SolidColorBrush(Colors.Transparent);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("state");
                }
            }
        }
        /// <summary>
        /// T süreklenen objenin tipini belirtmelidir.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="e"></param>
        /// <param name="directoryRestriction"> </param>
        /// <returns></returns>
        protected bool EnableDragDrop<T>(DragEventArgs e, string directoryRestriction = null) where T : BaseEntity
        {
            e.Handled = true;
            if (!e.Data.GetDataPresent(typeof(T))) return false;
            var data = (T)e.Data.GetData(typeof(T));
            return IsValidExtension(data.Path, ValidExtension, directoryRestriction);
        }
        /// <summary>
        /// Birden fazla tipi kontrol etmek icin yazildi
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="e"></param>
        /// <param name="directoryRestriction"></param>
        /// <returns></returns>
        protected bool EnableDragDrop<T1, T2>(DragEventArgs e, string directoryRestriction = null)
            where T1 : BaseEntity
            where T2 : BaseEntity
        {
            e.Handled = true;
            if (e.Data.GetDataPresent(typeof(T1)))
            {
                var data = (T1)e.Data.GetData(typeof(T1));
                return IsValidExtension(data.Path, ValidExtension, directoryRestriction);
            }
            if (e.Data.GetDataPresent(typeof(T2)))
            {
                var data = (T2)e.Data.GetData(typeof(T2));
                return IsValidExtension(data.Path, ValidExtension, directoryRestriction);
            }

            return false;
        }

        protected void HandleOnDragEnter<T>(DragEventArgs e, string directoryRestriction = null) where T : BaseEntity
        {
            e.Effects = EnableDragDrop<T>(e, directoryRestriction) ? DragDropEffects.All : DragDropEffects.None;
            e.Handled = true;
        }
        protected void HandleOnDragEnter<T1, T2>(DragEventArgs e, string directoryRestriction = null)
            where T1 : BaseEntity
            where T2 : BaseEntity
        {
            var result = EnableDragDrop<T1>(e, directoryRestriction);
            if (result)
            {
                e.Effects = DragDropEffects.All;
            }
            else
            {
                result = EnableDragDrop<T2>(e, directoryRestriction);
                e.Effects = result ? DragDropEffects.All : DragDropEffects.None;
            }
            e.Handled = true;
        }
        /// <summary>
        /// T argümanı sürüklenen objenin tipini belirtmelidir. Bu tip BaseEntity sınıfından türemelidir.
        /// U argümanı ise üzerine bişey bırakılacak objenin tipini tutar.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TU"></typeparam>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="directoryRestriction"> </param>
        protected void HandleOnDragOver<T, TU>(object sender, DragEventArgs e, string directoryRestriction = null) where T : BaseEntity
        {
            if (EnableDragDrop<T>(e, directoryRestriction))
            {
                if (sender is TU)
                {
                    ChangeTargetState(sender, DragState.Over);
                    e.Effects = DragDropEffects.All;
                }
            }
            e.Handled = true;
        }

        protected void HandleOnDragOver<T1, T2, TU>(object sender, DragEventArgs e, string directoryRestriction = null)
            where T1 : BaseEntity
            where T2 : BaseEntity
        {
            var result = EnableDragDrop<T1>(e, directoryRestriction);
            if (result)
            {
                if (!(sender is TU))
                {
                    ChangeTargetState(sender, DragState.Over);
                    e.Effects = DragDropEffects.All;
                }
            }
            else
            {
                result = EnableDragDrop<T2>(e, directoryRestriction);
                if (result)
                {
                    if (!(sender is TU))
                    {
                        ChangeTargetState(sender, DragState.Over);
                        e.Effects = DragDropEffects.All;
                    }
                }
            }
            e.Handled = true;
        }
        protected void HandleOnDragLeave<T, TU>(object sender, DragEventArgs e, string directoryRestriction = null) where T : BaseEntity
        {
            if (EnableDragDrop<T>(e, directoryRestriction))
            {
                if (sender is TU)
                {
                    ChangeTargetState(sender, DragState.Leave);
                    e.Effects = DragDropEffects.None;
                }
            }
            e.Handled = true;
        }

        protected void HandleOnDragLeave<T1, T2, TU>(object sender, DragEventArgs e, string directoryRestriction = null)
            where T1 : BaseEntity
            where T2 : BaseEntity
        {
            var result = EnableDragDrop<T1>(e, directoryRestriction);
            if (result)
            {
                if (!(sender is TU))
                {
                    ChangeTargetState(sender, DragState.Leave);
                    e.Effects = DragDropEffects.None;
                }
            }
            else
            {
                result = EnableDragDrop<T2>(e, directoryRestriction);
                if (result)
                {
                    if (!(sender is TU))
                    {
                        ChangeTargetState(sender, DragState.Leave);
                        e.Effects = DragDropEffects.None;
                    }
                }
            }
            e.Handled = true;
        }
    }
}
