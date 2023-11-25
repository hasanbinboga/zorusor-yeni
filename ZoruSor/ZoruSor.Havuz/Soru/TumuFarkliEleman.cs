using System;
using System.Collections.Generic;
using System.Linq;

namespace ZoruSor.Lib.Soru
{
    public class TumuFarkliEleman : SoruBuilder
    {
        private Dictionary<string, int> _ortakParcaList;

        private CiktiResim KotuParcaDegistir1(CiktiResim resim, Dictionary<string, int> ortakParca)
        {
            var kotuParcaList = new Dictionary<string, int>();
            foreach (var parca in resim.ParcaList)
            {
                if (ortakParca.ContainsKey(parca.Key) && ortakParca[parca.Key] == parca.Value)
                {
                    kotuParcaList.Add(parca.Key, parca.Value);
                }
            }
            //ortak parca 1 ve kotu parca yoksa resmi geri gonder/
            if (ortakParca.Count == 1 && kotuParcaList.Count == 0)
            {
                return resim;
            }
            //Ortak Parca listesinde 1 resim varsa ve kotuparcaList sayisi da 1 ise
            if (ortakParca.Count == 1 && kotuParcaList.Count == 1)
            {
                var parcaAd = kotuParcaList.Keys.First();
                kotuParcaList[parcaAd] = RandomHelper.RandomDifferentNumber(0,
                    Havuz.ParcaList.First(s => s.Ad == parcaAd).Adet - 1,
                            new[] { kotuParcaList[parcaAd] });
                resim = ResimHelper.ParcaDegistir(Havuz, resim,
                    kotuParcaList, ResimBoyut);
                return resim;
            }

            //yeni uretilen resimlerdeki otak parcalardan %50 si ayni ise 
            if (kotuParcaList.Count > 0)
            {
                //Ortak parcalarin yarisini sec 
                var kotuParcalar = kotuParcaList.ToDictionary(k => k.Key, v => v.Value);

                //bu parcalar icin rasgele id uret.
                foreach (var parca in Havuz.ParcaList)
                {
                    if (kotuParcalar.ContainsKey(parca.Ad))
                    {
                        kotuParcalar[parca.Ad] = RandomHelper.RandomDifferentNumber(0, parca.Adet - 1,
                            new[] { kotuParcaList[parca.Ad] });
                    }
                }

                //resimi degistir.  
                resim = ResimHelper.ParcaDegistir(Havuz, resim,
                    kotuParcalar, ResimBoyut);
            }
            return resim;
        }
        public override void ReferansResimUret()
        {
            
            Soru.ReferansResimList.Add(ResimHelper.RasgeleResimUret(Havuz, ResimBoyut));
        }

        public override void DogruCevapUret()
        {

            
            var sonuc = ResimHelper.RasgeleResimUret(Havuz, ResimBoyut);

            _ortakParcaList = new Dictionary<string, int>();
            foreach (var parca in sonuc.ParcaList)
            {
                if (Soru.ReferansResimList[0].ParcaList.Any(s=>s.Equals(parca)))
                {
                    _ortakParcaList.Add(parca.Key, parca.Value);
                }
            }

            sonuc = KotuParcaDegistir1(sonuc, _ortakParcaList);

            Soru.DogruCevapList.Add(sonuc);
        }

        public override void CeldiriciUret()
        {
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

            //celdirici adedi kadar
            for (var i = 0; i < CeldiriciAdet; i++)
            {
                var parcaAdet = Havuz.ParcaList.Count - (ZorlukDerece - 1) + 1; //Kalani sec parca adedini bir azaltiyor. O nedenle 1 eklendi.

                var sabitAdet = SabitParcaAdet > parcaAdet ? parcaAdet - 1 : SabitParcaAdet;
                sabitAdet = sabitAdet < 0 ? 0 : sabitAdet;

                //Parca sayisi - (Zorluk derecesi-1) tane parca sec.
                var degisecekParcaList = ParcaSecimHelper.KalaniSec(Havuz, sabitAdet, parcaAdet);

                //Secilen parcalari referans resim ile ayni yap.
                var sonuc = ResimHelper.ResimDegistirUret(Havuz, Soru.ReferansResimList[0], degisecekParcaList, ResimBoyut);

                //celdiriciyi sorunun listesine ekle
                if ((degisecekParcaList.Count > 0 && Soru.CeldiriciList.Any(s => s.Equals(sonuc))) || Soru.DogruCevapList[0].Equals(sonuc))
                {
                    i--;
                }
                else
                {
                    Soru.CeldiriciList.Add(sonuc);
                }

            }
        }
    }
}
