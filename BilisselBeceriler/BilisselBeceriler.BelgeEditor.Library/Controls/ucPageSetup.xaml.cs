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
using System.Printing;
using BilisselBeceriler.BelgeEditor.Library.Helpers;
using SilverFlow.Controls;

namespace BilisselBeceriler.BelgeEditor.Library.Controls
{
    /// <summary>
    /// Interaction logic for ucPrintSetup.xaml
    /// </summary>
    public partial class ucPageSetup : FloatingWindow

    {
        public ucPageSetup()
        {
            InitializeComponent();
            _marj = SayfaHelper.GetFromRegistry();
            txtSol.Text = _marj.Left.ToString();
            txtSag.Text = _marj.Right.ToString();
            txtUst.Text = _marj.Top.ToString();
            txtAlt.Text = _marj.Bottom.ToString();
            Tamam = false;
        }
        public Thickness Marj { get { return _marj; } }
        private Thickness _marj;
        public bool Tamam { get; set; }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double d;
            if (double.TryParse(txtAlt.Text, out d) &&
                double.TryParse(txtSag.Text, out d) &&
                double.TryParse(txtSol.Text, out d) &&
                double.TryParse(txtUst.Text, out d))
            {
                //PrintDocumentImageableArea capabilities
                _marj = new Thickness(Convert.ToDouble(txtSol.Text), Convert.ToDouble(txtUst.Text),
                                Convert.ToDouble(txtSag.Text), Convert.ToDouble(txtAlt.Text));
            }
            else
            {
                MessageBox.Show("Lütfen Marjin ayarlarını girin");
                Tamam = false;
                return;
            }
            SayfaHelper.SetToRegistry(_marj);
            Tamam = true;
        }
    }
}
