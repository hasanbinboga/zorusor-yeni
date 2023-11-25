using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BilisselBeceriler.Data;
using BilisselBeceriler.Entities.Web;
using System.Data.OleDb;
using Microsoft.Practices.Unity;
//using Microsoft.Practices.Unity.Configuration;
using System.Configuration;
using BilisselBeceriler.Entities.Security;

namespace BilisselBeceriler.Test
{
    class Program
    {
        [Dependency]
        public static IKullaniciServis Servis { get; set; }
        static void Main(string[] args)
        {
            //IUnityContainer Container = new UnityContainer();
            //UnityConfigurationSection unityConfig = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
            //unityConfig.Configure(Container);
            //IKullaniciServis Servis = Container.Resolve<IKullaniciServis>();
            ////Console.WriteLine(Servis.Sil(new Kullanici() { Id = 1 }));            
            //IKullanici k = Servis.Login("5", "6");
            
            Repository<Ogrenci> OgrenciRepository = new Repository<Ogrenci>();
            Repository<OgrenciFotograf> OgrenciFotoRepository = new Repository<OgrenciFotograf>();

            IList<Ogrenci> Liste = OgrenciRepository.SelectWhere(o => o.Sinif.Id == 6);

            int YeniSinifId = 11;
            foreach (var item in Liste)
            {
                Ogrenci o = new Ogrenci();
                o.Adi = item.Adi;
                o.AktifMi = item.AktifMi;
                o.Baslangici = item.Baslangici;
                o.Cinsiyet = item.Cinsiyet;
                o.DogumTarih = item.DogumTarih;                
                o.Soyadi = item.Soyadi;
                item.Sinif.Id = 11;
                o.Sinif = item.Sinif;
                o.Vesikalik = item.Vesikalik;
                o.PaketTur = item.PaketTur;
                Ogrenci yeniOgrenci = OgrenciRepository.Kaydet(o);

                foreach (var oge in item.FotografListe)
                {
                    OgrenciFotograf fto = new OgrenciFotograf();
                    fto.AktifMi = oge.AktifMi;
                    fto.FotoKategori = oge.FotoKategori;
                    fto.Ogrenci.Id = yeniOgrenci.Id;
                    fto.Resim = oge.Resim;
                    OgrenciFotoRepository.Kaydet(fto);
                }
            }
        }
    }
}
