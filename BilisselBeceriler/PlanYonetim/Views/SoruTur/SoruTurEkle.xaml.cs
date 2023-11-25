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
using System.Threading;
using System.Windows.Threading;
using BilisselBeceriler.Entities;
using BilisselBeceriler.Data;
using PlanYonetim.Codes;
using BilisselBeceriler.Entities.Windows;

namespace PlanYonetim.Views
{
    public partial class SoruTurEkle : UserControl
    {
        #region Public Events
        public event AddEntityHandler<SoruTur> SoruTurEklendi;
        public event EditEntityHandler<SoruTur> SoruTurGuncellendi;
        #endregion

        #region private variables
        private bool _hideRequest = false;
        private UIElement _parent;
        private SoruTur OldEntity;
        #endregion

        public SoruTurEkle()
        {
            InitializeComponent();
            Visibility = Visibility.Hidden;
        }

        #region Public Methods

        public void SetParent(UIElement parent)
        {
            _parent = parent;
        }
        public void ShowDialog()
        {
            Visibility = Visibility.Visible;
            _parent.IsEnabled = false;
            DoEvents();
        }
        public void ShowDialog(SoruTur soruTur)
        {
            Visibility = Visibility.Visible;
            _parent.IsEnabled = false;
            OldEntity = soruTur;
            tbSoruTurAciklama.Text = soruTur.Aciklama;
            tbSoruTurAd.Text = soruTur.Ad;
            btnGuncelle.Visibility = System.Windows.Visibility.Visible;
            btnKaydet.Visibility = System.Windows.Visibility.Hidden;
            DoEvents();
        }
        #endregion

        #region private methods
        void DoEvents()
        {
            _hideRequest = false;
            while (!_hideRequest)
            {
                if (this.Dispatcher.HasShutdownStarted || this.Dispatcher.HasShutdownFinished)
                {
                    break;
                }
                this.Dispatcher.Invoke(DispatcherPriority.Background, new ThreadStart(delegate { })); Thread.Sleep(20);
            }
        }
        private void HideHandlerDialog()
        {
            Visibility = Visibility.Hidden;
            _parent.IsEnabled = true;
            btnGuncelle.Visibility = System.Windows.Visibility.Hidden;
            btnKaydet.Visibility = System.Windows.Visibility.Visible;
        }
        #endregion

        private void VazgecTiklandi(object sender, RoutedEventArgs e)
        {
            tbSoruTurAd.Text = string.Empty;
            tbSoruTurAciklama.Text = string.Empty;            
            HideHandlerDialog();
        }

        private void TamamTiklandi(object sender, RoutedEventArgs e)
        {
            try
            {
                Repository<SoruTur> Repository = new Repository<SoruTur>();
                btnKaydet.IsEnabled = false;
                SoruTur Entity = new SoruTur();
                Entity.Ad = tbSoruTurAd.Text;
                Entity.Aciklama = tbSoruTurAciklama.Text;
                Repository.Kaydet(Entity);
                SoruTurEklendi(Entity, "Soru türü eklendi");
            }
            catch (Exception ex)
            {
                SoruTurEklendi(null, ex.Message);
            }

            btnKaydet.IsEnabled = true;
        }

        private void GuncelleTiklandi(object sender, RoutedEventArgs e)
        {
            try
            {
                Repository<SoruTur> Repository = new Repository<SoruTur>();

                btnGuncelle.IsEnabled = false;
                SoruTur Entity = new SoruTur();
                Entity.Ad = tbSoruTurAd.Text;
                Entity.Aciklama = tbSoruTurAciklama.Text;
                Repository.Kaydet(Entity);
                SoruTurGuncellendi(OldEntity, Entity, null);
            }
            catch (Exception ex)
            {
                SoruTurGuncellendi(OldEntity, null, ex.Message);
            }
            btnGuncelle.IsEnabled = true;
        }
    }
}
