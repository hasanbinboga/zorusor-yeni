using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZoruSor.Lib.Havuz;

namespace ZoruSor.Lib.Soru
{
    /// <summary>
    /// Bu soru şablonu onceki kurali bulup uygulama soru turlerinden cok daha basittir.
    /// Iki satirdan olusur. Isleme giren parcalarin sadece iki degeri vardir. Bu parcalarin degerleri ise 
    /// satirlarin ilk basinda gosterilir. Daha sonra onceki kurali bul uygula soru turlerinde oldugu gibi 
    /// bu parcalarin bulundugu  islem resmi yer alir.  Ilk satirda cozum verilir.
    /// Ikinci satirda ise yine benzer sekilde parcalarin degerleri ve islem resmi vardir. Bu islemin cevabi sorulur.
    /// </summary>
    public class KuraliBulUygula4 : SoruBuilder
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
                    //Her parcanin secilen parca id' sine 1' den 4' e kadar rastgele deger ata.
                    var deger = RandomHelper.RandomDifferentNumber(1, 4, parcaDeger.IdDegerList.Keys.ToArray());

                    //Rastgele bir parca id sec.
                    var id = RandomHelper.RandomDifferentNumber(0, parca.Adet - 1,
                        parcaDeger.IdDegerList.Values.ToArray());
                    parcaDeger.IdDegerList.Add(deger, id);
                }
            }

            var islem = RandomHelper.RandomBool();
            _satirList = new List<Satir>
            {
                //(A * B) Birinci satiri olustur.
                SatirOlustur(1, 2, islem),
                //(B * C) Ikinci satiri olustur.
                SatirOlustur(3, 4, islem),
            };
            
            //satirlarin siralarini rastgele belirle
           
            var gucluList = new Dictionary<string, int>();
            var zayifList = new Dictionary<string, int>();
            var guclu1List = new Dictionary<string, int>();
            var zayif1List = new Dictionary<string, int>();
            foreach (var parca in _parcaDegerList)
            {
                gucluList.Add(parca.Ad, parca.IdDegerList[2]);
                zayifList.Add(parca.Ad, parca.IdDegerList[1]);
                guclu1List.Add(parca.Ad, parca.IdDegerList[4]);
                zayif1List.Add(parca.Ad, parca.IdDegerList[3]);
            }

            Soru.ReferansResimList.Add(ResimHelper.IslemResimUret(Havuz, _satirList[0].Resim1, _satirList[0].Resim2, _satirList[0].Sonuc, _satirList[0].SonucBuyuk, gucluList, zayifList, ResimBoyut));
            Soru.ReferansResimList.Add(ResimHelper.IslemSoruResimUret(Havuz, _satirList[1].Resim1, _satirList[1].Resim2, _satirList[1].SonucBuyuk, guclu1List, zayif1List, ResimBoyut));
        }

        public override void DogruCevapUret()
        {
            Soru.DogruCevapList.Add(ResimHelper.ResimUret(Havuz, _satirList[1].Sonuc, ResimBoyut));
        }

        public override void CeldiriciUret()
        {

            var sonSatir1 = ResimHelper.ResimUret(Havuz, _satirList[1].Resim1, ResimBoyut);
            var sonSatir2 = ResimHelper.ResimUret(Havuz, _satirList[1].Resim2, ResimBoyut);
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

            //Son satırdaki kuralli parcalari al.
            var kuralliParcalar = Havuz.ParcaList.Where(s => _parcaDegerList.Any(x => x.Ad == s.Ad)).ToList();


            //Aynisini bul ile ayni
            //celdirici adedi kadar
            for (var i = 0; i < kalanCeldirici; i++)
            {
                //Sabit parca kadarini dogru cevap ile ayni birak
                var parcaList = kuralliParcalar.OrderByDescending(s =>
                            s.Derece).Take(SabitParcaAdet).
                    ToDictionary(parca => parca.Ad, parca =>
                            Soru.DogruCevapList[0].ParcaList[parca.Ad]);

                //Sabit parca disindaki parcalardan birden parca adet-1 tanesini random celdiriciye ekle
                if (ZorlukDerece > 3)
                {
                    var rnd = RandomHelper.RandomNumber(1, _parcaDegerList.Count - parcaList.Count);
                    var eklenecekParcalar = _parcaDegerList.Where(s => parcaList.ContainsKey(s.Ad) == false).
                        Take(rnd).ToList();
                    foreach (var parcaDeger in eklenecekParcalar)
                    {
                        if (RandomHelper.RandomBool())
                        {
                            parcaList.Add(parcaDeger.Ad, _satirList[1].Resim1ParcaDegers.FirstOrDefault(s => s.Ad == parcaDeger.Ad).IdDegerList.Values.First());
                        }
                        else
                        {
                            parcaList.Add(parcaDeger.Ad, _satirList[1].Resim2ParcaDegers.FirstOrDefault(s => s.Ad == parcaDeger.Ad).IdDegerList.Values.First());
                        }
                    }
                }

                //Kalan parcalari rastgele degistir. 
                var kalanParcalar =
                    Havuz.ParcaList.Where(s => parcaList.ContainsKey(s.Ad) == false).Select(s => s.Ad).ToList();

                foreach (var prc in ParcaSecimHelper.ParcaDegerUret(Havuz, kalanParcalar))
                {
                    parcaList.Add(prc.Key, prc.Value);
                }


                var sonuc = ResimHelper.ResimUret(Havuz, parcaList, ResimBoyut);
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
                rnd.AddRange(idMap.Values.OrderBy(s=>s).ToArray());
                var newId = RandomHelper.RandomDifferentNumber(0, CeldiriciAdet - 1, rnd.ToArray());
                idMap.Add(id, newId);}

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
