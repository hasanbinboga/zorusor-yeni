using System;
using System.Collections.Generic;
using System.Linq;

namespace ZoruSor.Lib.Soru
{
    public class CakistirmaYanlisBul: SoruBuilder
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
            var refResim = ResimHelper.ResimUret(Havuz, _parcaIdList, ResimBoyut);
            var degisecekParcalar = ParcaSecimHelper.KalaniSec(Havuz, SabitParcaAdet, ZorlukDerece);

            var sonuc = ResimHelper.ResimDegistirUret(Havuz, refResim, degisecekParcalar, ResimBoyut);

            Soru.DogruCevapList.Add(sonuc);
        }

        public override void CeldiriciUret()
        {
            //celdirici adedi kadar
            for (var i = 0; i < CeldiriciAdet; i++)
            {
                //Dogru cevabi uret
                Soru.CeldiriciList.Add(ResimHelper.ResimUret(Havuz, _parcaIdList, ResimBoyut));


            }
        }
    }
}
