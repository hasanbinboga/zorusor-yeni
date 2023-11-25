using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BilisselBeceriler.Altyapi;
using System.Windows;
using System.Windows.Media.Imaging;

namespace BilisselBeceriler.Host
{
    public class MainWindow : IMainWindow
    {
        #region IMainWindow Members

        public void MesajGoster(string Mesaj)
        {
            MessageBox.Show(Mesaj);
        }
        public void MesajYaz(MesajTip Tip, string Mesaj, string ToolTip = null)
        {
            if (Tip == MesajTip.Bilgi)
            {
                //iMesajResim.Source = new BitmapImage(new Uri("/PlanYonetim;component/Images/bilgi.png", UriKind.Relative));
            }
            else if (Tip == MesajTip.Hata)
            {
                //iMesajResim.Source = new BitmapImage(new Uri("/PlanYonetim;component/Images/hata.png", UriKind.Relative));
            }
            else if (Tip == MesajTip.Uyari)
            {
                //iMesajResim.Source = new BitmapImage(new Uri("/PlanYonetim;component/Images/uyari.png", UriKind.Relative));
            }
            //tbMesaj.ToolTip = ToolTip;
            //tbMesaj.Text = Mesaj;
        }

        #endregion
    }
}
