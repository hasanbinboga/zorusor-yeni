using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZoruSor.Lib.Soru
{
    public class ButundenParcaya:SoruBuilder
    {
        private CiktiResim _referansResim;
        public override void ReferansResimUret()
        {
            //Rastgele bir resim uret.
            _referansResim = ResimHelper.RasgeleResimUret(Havuz, ResimBoyut);
            Soru.ReferansResimList.Add(_referansResim);
        }

        public override void DogruCevapUret()
        {
            //Resmin parcalarinin donusum resimlerini kullanarak resim uret.
            Soru.DogruCevapList.Add(ResimHelper.ParcaResimUret(Havuz, _referansResim.ParcaList, ResimBoyut/10*4));
        }

        public override void CeldiriciUret()
        {
            //Aynisini bul ile ayni
            //Aynisini bul ile ayni
            #region Sifir Validation

            if (ZorlukDerece < 0)
            {
                throw new ApplicationException("Zorluk derecesi 0 dan büyük olmalıdır.");
            }
            if (SabitParcaAdet < 0)
            {
                throw new ApplicationException("Değişim Adedi 0 dan büyük olmalıdır.");
            }
            if (CeldiriciAdet < 0)
            {
                throw new ApplicationException("Çeldirici Adedi 0 dan büyük olmalıdır.");
            }

            #endregion

            if (ZorlukDerece > Havuz.ParcaList.Count)
            {
                throw new ApplicationException("Zorluk derecesi sadece 1 ile " + Havuz.ParcaList.Count + " arasında olabilir.");
            }

            if (ZorlukDerece - SabitParcaAdet <= 0)
            {
                throw new ApplicationException(ZorlukDerece + " Zorluk derecesi için sabit parca adedi en fazla " +
                                               (ZorlukDerece - 1) + " olabilir.");
            }

            var celdiriciler = new List<CiktiResim>();
            //celdirici adedi kadar
            for (var i = 0; i < CeldiriciAdet; i++)
            {
                var degisecekParcalar = ParcaSecimHelper.KalaniSec(Havuz, SabitParcaAdet, ZorlukDerece);

                var sonuc = ResimHelper.ResimDegistirUret(Havuz, Soru.ReferansResimList[0], degisecekParcalar, ResimBoyut);
                //celdiriciyi celdiricilere ekle
                if (Soru.CeldiriciList.Count>0 && Soru.CeldiriciList.Any(s => s.Equals(sonuc)))
                {
                    i--;
                }
                else
                {
                    celdiriciler.Add(sonuc);
                }

            }
            //Olusan resmin donusum resimlerini kullanarak celdirici uret.
            foreach (var resim in celdiriciler)
            {
                
                Soru.CeldiriciList.Add(ResimHelper.ParcaResimUret(Havuz, resim.ParcaList, ResimBoyut/10*4));
            }
        }
    }
}
