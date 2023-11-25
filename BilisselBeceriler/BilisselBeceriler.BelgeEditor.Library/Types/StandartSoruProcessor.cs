using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using BilisselBeceriler.BelgeEditor.Library.Constants;
using BilisselBeceriler.BelgeEditor.Library.Enums;
using BilisselBeceriler.BelgeEditor.Library.Extensions;
using BilisselBeceriler.BelgeEditor.Library.Model;
using System.Windows.Shapes;

namespace BilisselBeceriler.BelgeEditor.Library.Types
{
    public class StandartSoruProcessor : ProcessorTemplate
    {
        public override void Process(Grid sayfaSablonGrid)
        {
            base.Process(sayfaSablonGrid);
            foreach (var gridP in ExtensionService.FindVisualChildren<Grid>(sayfaSablonGrid))
            {
                var border = gridP.Children != null ? gridP.Children[0] as Border: null;
                if (border != null)
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

                    var mainMenu = new ContextMenu();
                    border.ContextMenu = mainMenu;
                    #region Yapistir
                    var itemYapistir = new MenuItem { Header = "Havuz Yapıştır" };
                    itemYapistir.Click += (sender, e) =>
                    {
                        try
                        {
                            var x = GetMenuItemSourceControl<Border>(sender);
                            if (Common.KopyaHavuz != null)
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
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }

                    };
                    mainMenu.Items.Add(itemYapistir);
                    #endregion

                    foreach (var grid in ExtensionService.FindVisualChildren<Grid>(border))
                    {
                        if (grid.Tag != null && string.IsNullOrEmpty(grid.Tag.ToString()) == false)
                        {

                           

                            HavuzProcessEkle(grid);
                        }

                    }
                }
            }
        }
        public override void OnDragEnter(object sender, DragEventArgs e)
        {
            HandleOnDragEnter<HavuzSablonEntity>(e);
        }
        public override void OnDragOver(object sender, DragEventArgs e)
        {
            HandleOnDragOver<HavuzSablonEntity, Border>(sender, e);
        }
       
        public override void OnDrop(object sender, DragEventArgs e)
        {
            var havuzSablon = e.Data.GetData(typeof(HavuzSablonEntity)) as HavuzSablonEntity;
            if (havuzSablon == null) return;
            if (IsValidExtension(havuzSablon.Path, ValidExtension) == false) return;
            var border = (sender as Border);
            if (border == null) return;
            var sayfaSablonGrid = (Grid)XamlReader.Load(File.OpenRead(havuzSablon.Path));
            sayfaSablonGrid.Width = border.ActualWidth;
            sayfaSablonGrid.Height = border.ActualWidth;

            HavuzProcessEkle(sayfaSablonGrid);

            border.Child = sayfaSablonGrid;
            border.Background = null;
            ChangeTargetState(border, DragState.Drop);
            e.Handled = true;
        }
        public override void OnDragLeave(object sender, DragEventArgs e)
        {
            HandleOnDragLeave<HavuzSablonEntity, Border>(sender, e);
        }
        public override string ValidExtension
        {
            get { return ".xaml"; }
        }
    }
}
