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
using BilisselBeceriler.Entities;
using BilisselBeceriler.Data;
using System.Threading;
using System.Collections.ObjectModel;
using BilisselBeceriler.Altyapi;
using Microsoft.Practices.Unity;
using BilisselBeceriler.Entities.Windows;

namespace PlanYonetim.Views
{
    public partial class SoruTurYonetim : UserControl
    {
        #region Public Properties
        
        public IMainWindow Main { get; set; }
        public Repository<SoruTur> Repository { get; set; }
        public ObservableCollection<SoruTur> Liste { get; set; }
        #endregion

        #region private routins
        MessageBoxResult Onay(string Soru)
        {
            return MessageBox.Show(Soru);
        }
        internal bool GridSatirSeciliMi(DataGrid dataGrid)
        {
            return dataGrid.SelectedItem != null;
        }
        void AsenkronListeHazirla()
        {
            Thread t = new Thread(() =>
            {
                Liste = new ObservableCollection<SoruTur>();
                IList<SoruTur> TempListe = Repository.Liste();
                TempListe.ToList().ForEach(x => Liste.Add(x));
                TempListe.Clear();
                TempListe = null;
                this.Dispatcher.BeginInvoke(new Action(delegate()
                {
                    this.dgListe.ItemsSource = Liste;
                    //Main.MesajYaz(MesajTip.Bilgi, "Veri Hazırlandı...");
                }), null);
            });
            t.Start();
            //Main.MesajYaz(MesajTip.Bilgi, "Veri Hazırlanıyor...");
        }
        #endregion

        #region Startup Routins
        public SoruTurYonetim()
        {
            InitializeComponent();
            Repository = new Repository<SoruTur>();

            ModalDialog.SetParent(VisualRoot);
            ModalDialog.SoruTurEklendi += new Codes.AddEntityHandler<SoruTur>(SoruTurEklendi);
            ModalDialog.SoruTurGuncellendi += new Codes.EditEntityHandler<SoruTur>(SoruTurGuncellendi);
        }

        void SoruTurGuncellendi(SoruTur oldEntity, SoruTur NewEntity, string Mesaj)
        {
            if (NewEntity != null)
            {
                Liste[Liste.IndexOf(oldEntity)] = NewEntity;
                Main.MesajYaz(MesajTip.Bilgi, "Soru Türü Güncellendi");
            }
            else
            {
                Main.MesajYaz(MesajTip.Bilgi, "Soru Tür Güncellenemedi !!!", Mesaj);
            }
        }

        void SoruTurEklendi(SoruTur Entity, string Mesaj)
        {
            if (Entity != null)
            {
                Liste.Add(Entity);
                Main.MesajYaz(MesajTip.Bilgi, "Soru Türü Eklendi");
            }
            else
            {
                Main.MesajYaz(MesajTip.Bilgi, "Soru Tür Eklenemedi !!!", Mesaj);
            }
        }
        private void FormYuklendi(object sender, RoutedEventArgs e)
        {
            AsenkronListeHazirla();
        }
        #endregion

        #region Ekle Duzelt Sil
        private void EkleTiklandi(object sender, RoutedEventArgs e)
        {
            ModalDialog.ShowDialog();

        }
        private void DuzeltTiklandi(object sender, RoutedEventArgs e)
        {
            if (GridSatirSeciliMi(this.dgListe) == false)
            {
                Main.MesajGoster("Lütfen güncellemek istediğiniz kaydı seçiniz");
                return;
            }
            SoruTur Secim = (SoruTur)dgListe.SelectedItem;
            ModalDialog.ShowDialog(Secim);
        }
        private void SilTiklandi(object sender, RoutedEventArgs e)
        {
            if (GridSatirSeciliMi(this.dgListe) == false)
            {
                Main.MesajGoster("Lütfen silmek istediğiniz kaydı seçiniz");
                return;
            }
            MessageBoxResult Sonuc = Onay("Seçili kaydı silmek istediğinize eminmisiniz?");
            if (Sonuc == MessageBoxResult.OK)
            {
                SoruTur Secim = (SoruTur)dgListe.SelectedItem;
                Repository.Sil(Secim);
            }
        }
        #endregion
    }
}
