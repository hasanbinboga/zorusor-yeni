using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZoruSor.Lib.Soru
{

    public class KuraliBulUygula2 : SoruBuilder
    {
        internal class ParcaDeger
        {
            public ParcaDeger()
            {
                IdDegerList = new Dictionary<int, int>();
            }
            public string Ad { get; set; }
            public Dictionary<int, int> IdDegerList { get; set; }
        }

        internal class Satir
        {
            public Satir()
            {
                Resim1 = new Dictionary<string, int>(10);
                Resim2 = new Dictionary<string, int>(10);
                Sonuc = new Dictionary<string, int>(10);
            }
            public Dictionary<string, int> Resim1 { get; set; }

            public Dictionary<string, int> Resim2 { get; set; }

            public Dictionary<string, int> Sonuc { get; set; }
        }

        private CiktiResim _referansResim;

        private List<ParcaDeger> _parcaDegerList;

        private List<Satir> _satirList;

        private  Satir SatirOlustur(int kucukDeger, int buyukDeger)
        {
            var satir = new Satir();
            foreach (var parcaId in _referansResim.ParcaList)
            {
                //parcalarin en kucuk degerli ve ondan bir yuksek olan degerini al.
                var seciliParcaDeger = _parcaDegerList.Find(s => s.Ad == parcaId.Key);
                if (seciliParcaDeger != null)
                {
                    var kucukId = seciliParcaDeger.IdDegerList[kucukDeger];
                    var buyukId = seciliParcaDeger.IdDegerList[buyukDeger];

                    if (RandomHelper.RandomBool())
                    {
                        satir.Resim1.Add(parcaId.Key, kucukId);
                        satir.Resim2.Add(parcaId.Key, buyukId);
                    }
                    else
                    {
                        satir.Resim1.Add(parcaId.Key, buyukId);
                        satir.Resim2.Add(parcaId.Key, kucukId);
                    }

                    satir.Sonuc.Add(parcaId.Key, buyukId);

                }
                else
                {
                    satir.Resim1.Add(parcaId.Key, parcaId.Value);
                    satir.Resim2.Add(parcaId.Key, parcaId.Value);
                    satir.Sonuc.Add(parcaId.Key, parcaId.Value);
                }


            }

            return satir;
        }


        public override void ReferansResimUret()
        {
            //rastgele bir resim uret.
            _referansResim = ResimHelper.RasgeleResimUret(Havuz, ResimBoyut);

            //Zorluk seviyesi kadar parca sec.
            _parcaDegerList = new List<ParcaDeger>(ZorlukDerece);

            ParcaSecimHelper.KadariniSec(Havuz, ZorlukDerece).
                ForEach(parcaAd => _parcaDegerList.Add(new ParcaDeger { Ad = parcaAd }));

            //Her parca icin dorder tane id sec.
            foreach (var parcaDeger in _parcaDegerList)
            {
                for (int i = 0; i < 4; i++)
                {
                    var parca = Havuz.ParcaList.FirstOrDefault(s => s.Ad == parcaDeger.Ad);
                    //Her parcanin secilen parca id' sine 1' den 4' e kadar rastgele deger ata.
                    var deger = RandomHelper.RandomDifferentNumber(1, 4, parcaDeger.IdDegerList.Keys.ToArray());

                    //Rastgele bir parca id sec.
                    var id = RandomHelper.RandomDifferentNumber(0, parca.Adet - 1,
                        parcaDeger.IdDegerList.Values.ToArray());
                    parcaDeger.IdDegerList.Add(deger, id);
                }
            }

            _satirList = new List<Satir>(4);

            //(A * B) Birinci satiri olustur.
            _satirList.Add(SatirOlustur(1, 2));

            //(B * C) Ikinci satiri olustur.
            _satirList.Add(SatirOlustur(2, 3));

            //(C * D) Ucuncu satiri olustur.
            _satirList.Add(SatirOlustur(3, 4));

            //(A * D)Soru satirini olustur.
            _satirList.Add(SatirOlustur(1, 4));

            //satirlarin siralarini rastgele belirle
            var siraList = new int[3];
            for (int i = 0; i < 3; i++)
            {
                siraList[i] = -1;
            }

            siraList[0] = RandomHelper.RandomDifferentNumber(0, 2, siraList);
            siraList[1] = RandomHelper.RandomDifferentNumber(0, 2, siraList);
            siraList[2] = RandomHelper.RandomDifferentNumber(0, 2, siraList);

            foreach (var sira in siraList)
            {
                Soru.ReferansResimList.Add(ResimHelper.IslemResimUret(Havuz,
                    _satirList[sira].Resim1, _satirList[sira].Resim2, _satirList[sira].Sonuc, ResimBoyut));
            }

            Soru.ReferansResimList.Add(ResimHelper.IslemSoruResimUret(Havuz, _satirList[3].Resim1, _satirList[3].Resim2, ResimBoyut));
        }



        public override void DogruCevapUret()
        {
            Soru.DogruCevapList.Add(ResimHelper.ResimUret(Havuz, _satirList[3].Sonuc, ResimBoyut));
        }

        public override void CeldiriciUret()
        {

            var sonSatir1 = ResimHelper.ResimUret(Havuz, _satirList[3].Resim1, ResimBoyut);
            var sonSatir2 = ResimHelper.ResimUret(Havuz, _satirList[3].Resim2, ResimBoyut);
            var kalanCeldirici = CeldiriciAdet;
            if (Soru.DogruCevapList[0].Equals(sonSatir1) == false)
            {
                Soru.CeldiriciList.Add(sonSatir1);
                kalanCeldirici--;
            }
            if (Soru.DogruCevapList[0].Equals(sonSatir2) == false)
            {
                Soru.CeldiriciList.Add(sonSatir2);
                kalanCeldirici--;
            }

            //Aynisini bul ile ayni
            //celdirici adedi kadar
            for (var i = 0; i < kalanCeldirici; i++)
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

            //Celdiricileri karistirmak icin mevcut sira no larina yeni rastgele sira nolari uret
            var idMap = new Dictionary<int, int>();
            for (int id = 0; id < CeldiriciAdet; id++)
            {
                var rnd = new List<int>();
                rnd.AddRange(idMap.Values.OrderBy(s => s).ToArray());
                var newId = RandomHelper.RandomDifferentNumber(0, CeldiriciAdet - 1, rnd.ToArray());
                idMap.Add(id, newId);
            }

            //Celdiricileri yeni sira nolarina tasi

            for (int i = 0; i < CeldiriciAdet; i++)
            {
                var t = Soru.CeldiriciList[i];
                Soru.CeldiriciList.RemoveAt(i);
                Soru.CeldiriciList.Insert(idMap[i], t);
            }
        }
    }
}
