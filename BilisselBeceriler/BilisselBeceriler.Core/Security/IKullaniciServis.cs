using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BilisselBeceriler.Entities.Security
{
    public enum KullaniciHesapDurum
    {
        Bilinmiyor=0,
        Aktif=1,
        Pasif=2
    }
    public interface IKullaniciServis
    {
        IKullanici Login(string Mail, string Sifre);
        IKullaniciYetki[] YetkiListe(int ID);        
        bool Ekle(IKullanici Kullanici);
        bool Sil(IKullanici Sil);
        bool Guncelle(IKullanici Guncelle);
        bool HesapDurumDegistir(KullaniciHesapDurum HesapDurum);
    }
}
