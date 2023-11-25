using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BilisselBeceriler.Altyapi;
using Microsoft.Practices.Composite.Modularity;

namespace BilisselBeceriler.Host
{

    public partial class Shell : Window
    {
        private IModuleManager _moduleManager;

        public Shell(IModuleManager ModuleManager)
        {
            _moduleManager = ModuleManager;            
            
            InitializeComponent();
        }

        #region common routins
        void Yerlestir(UIElement Element, int SatirIndex, int SutunIndex, int? ColumnSpan = null, int? RowSpan = null)
        {
            VisualRoot.Children.Remove(Element);
            Grid.SetColumn(Element, SutunIndex);
            Grid.SetRow(Element, SatirIndex);
            if (ColumnSpan.HasValue)
                Grid.SetColumnSpan(Element, ColumnSpan.Value);

            if (RowSpan.HasValue)
                Grid.SetColumnSpan(Element, RowSpan.Value);
            VisualRoot.Children.Add(Element);
        }
        void Yerlestir(UIElement Element)
        {
            spKapsul.Children.Clear();
            spKapsul.Children.Add(Element);
        }
        #endregion
        private void SoruTurTanimlamaTiklandi(object sender, RoutedEventArgs e)
        {
            //SoruTurYonetim sty = new SoruTurYonetim();
            //sty.Main = this;
            //Yerlestir(sty);
            _moduleManager.LoadModule("PlanYonetim");
        }
    }
}
