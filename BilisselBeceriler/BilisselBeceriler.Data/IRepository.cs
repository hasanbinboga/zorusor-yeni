using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace BilisselBeceriler.Data
{
    public interface IRepository<T> where T : new()
    {
        T Kaydet(T Entity);        
        void Guncelle(T Entity);
        void Sil(T Entity);
        int Adet();
        T Adet<T>(string SQL);
        T Bilgi(int ID);
        T Bilgi(string Url);
        T Yukle(int id);
        IList<T> Yukle(string SQL);
        IList<T> Liste();
        IList<T> SelectWhere(Func<T, bool> query);
        T Single(Func<T, bool> query);
        IList<T> Liste(int SayfaNo, int SatirAdet, out long ToplamSayfaSayisi);
        IList<T> Liste(ICriteria SorguKriter, int SayfaNo, int SatirAdet, out long ToplamSayfaSayisi);
    }
}
