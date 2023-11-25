using System.Collections.Generic;
using System.Linq;

namespace ZoruSor.Lib.Soru
{
    /// <summary>
    /// Bu soru şablonu simetrik ilişki 1 ve 2 ye göre daha basittir. Toplamda 8 referans resim vardır.
    /// Her parçanın 4 değeri vardır. ilk satırdaki iki referans resimde birinci ve ikinci değerleri karşılaştırır.
    /// İkinci satırda ikinci ve üçüncü değerleri karşılaştırılır. Üçüncü satırda da üçüncü ve dördüncü değerleri
    /// karşılaştırılır. Son satırda İki tane soru vardır.
    /// </summary>
    public class SimetrikIliski6 : SoruBuilder
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
                Resim1ParcaDegers = new List<ParcaDeger>(10);
                Resim2ParcaDegers = new List<ParcaDeger>(10);

            }
            public Dictionary<string, int> Resim1 { get; set; }

            public Dictionary<string, int> Resim2 { get; set; }

            public Dictionary<string, int> Sonuc { get; set; }

            public List<ParcaDeger> Resim1ParcaDegers { get; set; }
            public List<ParcaDeger> Resim2ParcaDegers { get; set; }
            public bool SonucBuyuk { get; set; }
        }

        private CiktiResim _referansResim;

        private List<ParcaDeger> _parcaDegerList;

        private List<Satir> _satirList;

        private Satir SatirOlustur(int kucukDeger, int buyukDeger, bool sonucBuyuk)
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
                        satir.Resim1ParcaDegers.Add(new ParcaDeger { Ad = parcaId.Key, IdDegerList = new Dictionary<int, int> { { kucukDeger, kucukId } } });
                        satir.Resim2ParcaDegers.Add(new ParcaDeger { Ad = parcaId.Key, IdDegerList = new Dictionary<int, int> { { buyukDeger, buyukId } } });
                    }
                    else
                    {
                        satir.Resim1.Add(parcaId.Key, buyukId);
                        satir.Resim2.Add(parcaId.Key, kucukId);
                        satir.Resim1ParcaDegers.Add(new ParcaDeger { Ad = parcaId.Key, IdDegerList = new Dictionary<int, int> { { buyukDeger, buyukId } } });
                        satir.Resim2ParcaDegers.Add(new ParcaDeger { Ad = parcaId.Key, IdDegerList = new Dictionary<int, int> { { kucukDeger, kucukId } } });
                    }
                    satir.Sonuc.Add(parcaId.Key, sonucBuyuk ? buyukId : kucukId);
                    satir.SonucBuyuk = sonucBuyuk;
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
                    if (parca != null)
                    {
                        //Her parcanin secilen parca id' sine 1' den 4' e kadar rastgele deger ata.
                        var deger = RandomHelper.RandomDifferentNumber(1, 4, parcaDeger.IdDegerList.Keys.ToArray());

                        //Rastgele bir parca id sec.
                        var id = RandomHelper.RandomDifferentNumber(0, parca.Adet - 1,
                            parcaDeger.IdDegerList.Values.ToArray());
                        parcaDeger.IdDegerList.Add(deger, id);
                    }

                }
            }

            var rnd1 = RandomHelper.RandomNumber(1, 4);
            var rnd2 = RandomHelper.RandomDifferentNumber(1, 4, new[] { rnd1 });
            if (rnd1 > rnd2)
            {
                var sw = rnd1;
                rnd1 = rnd2;
                rnd2 = sw;
            }

            _satirList = new List<Satir>
            {
                //Birinci satir birinci resmi olustur.
                SatirOlustur(1, 2, true),
                //Birinci satir ikinci resmi olustur.
                SatirOlustur(1, 2, false),
                //Ikinci satir birinci resmi olustur.
                SatirOlustur(2, 3, true),
                //Ikinci satir ikinci resmi olustur.
                SatirOlustur(2, 3, false),
                //Ucuncu satir birinci resmi olustur.
                SatirOlustur(3, 4, true),
                //Ucuncu satir ikinci resmi olustur.
                SatirOlustur(3, 4, false),
                //Birinci Soru resmini olustur.
                SatirOlustur(rnd1,rnd2, true),
                //Ikinci Soru resmini olustur.
                SatirOlustur(rnd1,rnd2, false)
            };


            //satirlari sirali olarak olustur.
            for (int i = 0; i < 8; i++)
            {
                if (i < 6)
                {
                    Soru.ReferansResimList.Add(ResimHelper.IslemResimUret(Havuz, _satirList[i].Resim1, _satirList[i].Resim2, _satirList[i].Sonuc, _satirList[i].SonucBuyuk, ResimBoyut));
                }
                else
                {
                    Soru.ReferansResimList.Add(ResimHelper.IslemSoruResimUret(Havuz, _satirList[i].Resim1, _satirList[i].Resim2, _satirList[i].SonucBuyuk, ResimBoyut));
                }
            }
        }

        public override void DogruCevapUret(){
            var resim1 = ResimHelper.ResimUret(Havuz, _satirList[6].Sonuc, ResimBoyut);
            var resim2 = ResimHelper.ResimUret(Havuz, _satirList[7].Sonuc, ResimBoyut);

            Soru.DogruCevapList.Add(ResimHelper.IkiResimBirlestir(resim1, resim2, ResimBoyut));


        }

        public override void CeldiriciUret()
        {
            var cevap1 = ResimHelper.ResimUret(Havuz, _satirList[6].Sonuc, ResimBoyut);
            var cevap2 = ResimHelper.ResimUret(Havuz, _satirList[7].Sonuc, ResimBoyut);

            var sonSatir11 = ResimHelper.ResimUret(Havuz, _satirList[6].Resim1, ResimBoyut);
            var sonSatir12 = ResimHelper.ResimUret(Havuz, _satirList[6].Resim2, ResimBoyut);

            var sonSatir21 = ResimHelper.ResimUret(Havuz, _satirList[7].Resim1, ResimBoyut);
            var sonSatir22 = ResimHelper.ResimUret(Havuz, _satirList[7].Resim2, ResimBoyut);

            var kalanCeldirici = CeldiriciAdet;
            if ((_satirList[6].Sonuc.Equals(sonSatir11.ParcaList) && _satirList[7].Sonuc.Equals(sonSatir21.ParcaList)) == false)
            {
                Soru.CeldiriciList.Add(ResimHelper.IkiResimBirlestir(sonSatir11, sonSatir21, ResimBoyut));
                kalanCeldirici--;
            }

            if (kalanCeldirici > 0 && (_satirList[6].Sonuc.Equals(sonSatir11.ParcaList) && _satirList[7].Sonuc.Equals(sonSatir22.ParcaList)) == false)
            {
                Soru.CeldiriciList.Add(ResimHelper.IkiResimBirlestir(sonSatir11, sonSatir22, ResimBoyut));
                kalanCeldirici--;
            }

            if (kalanCeldirici > 0 && (_satirList[6].Sonuc.Equals(sonSatir12.ParcaList) && _satirList[7].Sonuc.Equals(sonSatir21.ParcaList)) == false)
            {
                Soru.CeldiriciList.Add(ResimHelper.IkiResimBirlestir(sonSatir12, sonSatir21, ResimBoyut));
                kalanCeldirici--;
            }

            if (kalanCeldirici > 0 && (_satirList[6].Sonuc.Equals(sonSatir12.ParcaList) && _satirList[7].Sonuc.Equals(sonSatir22.ParcaList)) == false)
            {
                Soru.CeldiriciList.Add(ResimHelper.IkiResimBirlestir(sonSatir12, sonSatir22, ResimBoyut));
                kalanCeldirici--;
            }



            //Aynisini bul ile ayni
            //celdirici adedi kadar
            for (var i = 0; i < kalanCeldirici; i++)
            {

                var degisecekParcalar = ParcaSecimHelper.KalaniSec(Havuz, SabitParcaAdet, ZorlukDerece);

                var sonuc1 = ResimHelper.ResimDegistirUret(Havuz, cevap1, degisecekParcalar, ResimBoyut);
                var sonuc2 = ResimHelper.ResimDegistirUret(Havuz, cevap2, degisecekParcalar, ResimBoyut);

                //celdiriciyi sorunun listesine ekle
                if (Soru.CeldiriciList.Any(s => s.ParcaList.Equals(sonuc1.ParcaList) && s.DigerResimParcaList.Equals(sonuc2.ParcaList)) ||
                    (Soru.DogruCevapList[0].ParcaList.Equals(sonuc1.ParcaList) && Soru.DogruCevapList[0].DigerResimParcaList.Equals(sonuc2.ParcaList)))
                {
                    i--;
                }
                else
                {
                    Soru.CeldiriciList.Add(ResimHelper.IkiResimBirlestir(sonuc1, sonuc2, ResimBoyut));
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
