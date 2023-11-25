using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZoruSor.Lib.Soru
{
    public class CakistirmaDogruBul: SoruBuilder
    {
        private Dictionary<string, int> _parcaIdList;
        public override void ReferansResimUret()
        {
            _parcaIdList = new Dictionary<string, int>(10);
            //Havuzdaki parca sayisinin yarisi kadar rastgele parca sec.
            var grupAdet = Math.Round(Havuz.ParcaList.Count / 2d, MidpointRounding.AwayFromZero) ;
            var grup1IdList = new List<int>();
            for (int i = 0; i < grupAdet; i++)
            {
                grup1IdList.Add(RandomHelper.RandomDifferentNumber(0, Havuz.ParcaList.Count-1, grup1IdList.ToArray()));
            }
            var grup1 = new List<string>();
            foreach (var id in grup1IdList)
            {
                grup1.Add(Havuz.ParcaList[id].Ad);
            }

            //Kalan parcalari sec.
            var grup2 = Havuz.ParcaList.Where(s => grup1.Contains(s.Ad) == false).Select(s => s.Ad).ToList();

            //Birinci gruptan resim uret
            var resim1 = ResimHelper.RasgeleResimUret(Havuz, grup1, ResimBoyut);

            //Ikinci gruptan resim uret
            var resim2 = ResimHelper.RasgeleResimUret(Havuz, grup2, ResimBoyut);

            //Referans Resim Uret
            Soru.ReferansResimList.Add(ResimHelper.IslemSoruResmiUret(resim1, resim2, ResimBoyut));

            //Dogru cevap icin parca id lerini al.
            foreach (var parca in resim1.ParcaList)
            {
                _parcaIdList.Add(parca.Key, parca.Value);
            }
            foreach (var parca in resim2.ParcaList)
            {
                _parcaIdList.Add(parca.Key, parca.Value);
            }
        }

        public override void DogruCevapUret()
        {
            Soru.DogruCevapList.Add(ResimHelper.ResimUret(Havuz, _parcaIdList, ResimBoyut));
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
                var degisecekParcalar = ParcaSecimHelper.KalaniSec(Havuz, SabitParcaAdet, ZorlukDerece);

                var sonuc = ResimHelper.ResimDegistirUret(Havuz, Soru.DogruCevapList[0], degisecekParcalar, ResimBoyut);
                //celdiriciyi sorunun listesine ekle
                if (Soru.CeldiriciList.Any(s => s.Equals(sonuc)) || Soru.DogruCevapList[0].Equals(sonuc))
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
