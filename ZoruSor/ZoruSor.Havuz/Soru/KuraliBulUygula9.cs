using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZoruSor.Lib.Havuz;
using ZoruSor.Lib.ResimBuilder;

namespace ZoruSor.Lib.Soru
{
    /// <summary>
    /// Bu soru şablonu 8. soru sablonuna benzemektedir. Sekizinci soru sablonundan daha kolaydir.
    /// Parca deger tablosunda, bir parcanin guclu ve zayif degerleri ayni satirda gorunur.
    /// Ancak parantezin konumu ve islemler rastlantisaldir.
    /// Her bir referans resimde rastgele guclu ve zayif parcalardan olusur. Isleme giren parcalarin sadece iki degeri vardir. Bu parcalarin degerleri ise 
    /// satirlarin ilk basinda gosterilir. Daha sonra onceki kurali bul uygula soru turlerinde oldugu gibi 
    /// bu parcalarin bulundugu  islem resmi yer alir. Islem resminde onceki soru turlerinden farkli olarak uc tane resim 
    /// vardir. Bu resimlerden ikisi parantez icerisindedir. Ilk satirda cozum verilir.
    /// Ikinci satirda ise yine benzer sekilde parcalarin degerleri ve islem resmi vardir. Bu islemin cevabi sorulur.
    /// </summary>
    public class KuraliBulUygula9 : SoruBuilder
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
                Resim3 = new Dictionary<string, int>();
                Sonuc = new Dictionary<string, int>(10);
                Resim1ParcaDegers = new List<ParcaDeger>(10);
                Resim2ParcaDegers = new List<ParcaDeger>(10);
                Resim3ParcaDegers = new List<ParcaDeger>(10);

            }

            public Dictionary<string, int> Resim1 { get; set; }

            public Dictionary<string, int> Resim2 { get; set; }
            public Dictionary<string, int> Resim3 { get; set; }

            public Dictionary<string, int> Sonuc { get; set; }

            public List<ParcaDeger> Resim1ParcaDegers { get; set; }
            public List<ParcaDeger> Resim2ParcaDegers { get; set; }
            public List<ParcaDeger> Resim3ParcaDegers { get; set; }
            public bool Islem1 { get; set; }
            public bool Islem2 { get; set; }
            public int ParantezId { get; set; }

            public Dictionary<string, int> GucluList { get; set; }
            public Dictionary<string, int> ZayifList { get; set; }
        }

        private List<Satir> _satirList;

        private List<ParcaDeger> _parcaDegerList;

        private Satir SatirIslemOlustur(CiktiResim referansResim, List<ParcaDeger> parcaDegerList, Dictionary<string, int> resim1Deger, bool islem1,
            Dictionary<string, int> resim2Deger, bool islem2, Dictionary<string, int> resim3Deger, int parantezId)
        {
            var satir = new Satir();
            foreach (var parcaId in referansResim.ParcaList)
            {
                //Secili parcayi deger listesinde bul.
                var parcaAd = parcaId.Key;
                var seciliParcaDeger = parcaDegerList.Find(s => s.Ad == parcaAd);

                //Eger secili parca deger listesinde varsa.
                if (seciliParcaDeger != null)
                {
                    var satirSonuc = -1;

                    #region Islemleri gerceklestir

                    //Parantez Id' si sifir ise
                    if (parantezId == 0)
                    {
                        //Ilk iki resmin parca degerlerini al
                        var resim1parcaDeger = resim1Deger[parcaAd];
                        var resim2parcaDeger = resim2Deger[parcaAd];
                        var sonuc1 = -1;
                        //Ilk Islem True ise
                        if (islem1)
                        {
                            //Ilk Islem True ise guclu kazanir.
                            //Sonuc degerini ata.
                            sonuc1 = resim1parcaDeger > resim2parcaDeger ? resim1parcaDeger : resim2parcaDeger;
                        }
                        else
                        {
                            //Ilk islem False ise zayif kazanir.
                            //Sonuc degerini ata.
                            sonuc1 = resim1parcaDeger < resim2parcaDeger ? resim1parcaDeger : resim2parcaDeger;
                        }
                        //Ucuncu resmin parca degerini al.
                        var resim3parcaDeger = resim3Deger[parcaAd];
                        //Ikinci Islem True ise
                        if (islem2)
                        {
                            //Ikinci islem True ise guclu kazanir.
                            //Sonuc degerini ata.
                            satirSonuc = sonuc1 > resim3parcaDeger ? sonuc1 : resim3parcaDeger;
                        }
                        else
                        {
                            //Ikinci islem False ise zayif olan kazanir.
                            //Sonuc degerini ata.
                            satirSonuc = sonuc1 < resim3parcaDeger ? sonuc1 : resim3parcaDeger;
                        }
                    }
                    //Parantez Id' si 1 ise
                    else if (parantezId == 1)
                    {
                        //Ikinci ve ucuncu resmin parca degerlerini al.
                        var resim2parcaDeger = resim2Deger[parcaAd];
                        var resim3parcaDeger = resim3Deger[parcaAd];
                        var sonuc1 = -1;
                        //Ikinci islem True ise
                        if (islem2)
                        {
                            //Ikinci islem True ise guclu kazanir.
                            //sonuc degerini ata.
                            sonuc1 = resim2parcaDeger > resim3parcaDeger ? resim2parcaDeger : resim3parcaDeger;
                        }
                        else
                        {
                            //Ikinci islem False ise zayif olan kazanir.
                            //Sonuc Degerini ata.
                            sonuc1 = resim2parcaDeger < resim3parcaDeger ? resim2parcaDeger : resim3parcaDeger;
                        }

                        //Birinci resmin degerini al
                        var resim1parcaDeger = resim1Deger[parcaAd];
                        //Eger birinci islem True ise
                        if (islem1)
                        {
                            //Birinci islem True ise guclu kazanir.
                            //Satirin sonucunu belirle
                            satirSonuc = sonuc1 > resim1parcaDeger ? sonuc1 : resim1parcaDeger;
                        }
                        else
                        {
                            //Birinci islem False ise zayif olan kazanir.
                            //Satirin sonucunu belirle
                            satirSonuc = sonuc1 < resim1parcaDeger ? sonuc1 : resim1parcaDeger;
                        }
                    }

                    #endregion



                    //Artik islem sonuclarini hesapladik.

                    //Simdi satiri olusturan resimleri olusturabiliriz.
                    var resim1Id = seciliParcaDeger.IdDegerList[resim1Deger[parcaAd]];
                    var resim2Id = seciliParcaDeger.IdDegerList[resim2Deger[parcaAd]];
                    var resim3Id = seciliParcaDeger.IdDegerList[resim3Deger[parcaAd]];

                    var sonuc = seciliParcaDeger.IdDegerList[satirSonuc];

                    satir.Resim1ParcaDegers.Add(new ParcaDeger { Ad = parcaId.Key, IdDegerList = new Dictionary<int, int> { { resim1Deger[parcaAd], resim1Id } } });
                    satir.Resim2ParcaDegers.Add(new ParcaDeger { Ad = parcaId.Key, IdDegerList = new Dictionary<int, int> { { resim2Deger[parcaAd], resim2Id } } });
                    satir.Resim3ParcaDegers.Add(new ParcaDeger { Ad = parcaId.Key, IdDegerList = new Dictionary<int, int> { { resim3Deger[parcaAd], resim3Id } } });

                    satir.Resim1.Add(parcaAd, resim1Id);
                    satir.Resim2.Add(parcaAd, resim2Id);
                    satir.Resim3.Add(parcaAd, resim3Id); satir.Sonuc.Add(parcaAd, sonuc);
                }
                //Eger Secili parca deger listesinde yoksa.
                else
                {
                    satir.Resim1.Add(parcaId.Key, parcaId.Value);
                    satir.Resim2.Add(parcaId.Key, parcaId.Value);
                    satir.Resim3.Add(parcaId.Key, parcaId.Value);
                    satir.Sonuc.Add(parcaId.Key, parcaId.Value);
                }


            }
            satir.Islem1 = islem1;
            satir.Islem2 = islem2;
            satir.ParantezId = parantezId;
            return satir;
        }

        private List<ParcaDeger> SatirOlustur()
        {
            //rastgele bir resim uret.
            var referansResim = ResimHelper.RasgeleResimUret(Havuz, ResimBoyut);

            //Zorluk seviyesi kadar parca sec.
            var parcaDegerList = new List<ParcaDeger>(ZorlukDerece);

            ParcaSecimHelper.KadariniSec(Havuz, ZorlukDerece).ForEach(parcaAd => parcaDegerList.Add(new ParcaDeger { Ad = parcaAd }));

            var maxDeger = 2;

            //Her parca icin dorder tane id sec.
            foreach (var parcaDeger in parcaDegerList)
            {
                for (int i = 0; i < maxDeger; i++)
                {
                    var parca = Havuz.ParcaList.FirstOrDefault(s => s.Ad == parcaDeger.Ad);
                    //Her parcanin secilen parca id' sine 1' den 4' e kadar rastgele deger ata.
                    var deger = RandomHelper.RandomDifferentNumber(1, maxDeger, parcaDeger.IdDegerList.Keys.ToArray());

                    //Rastgele bir parca id sec.
                    var id = RandomHelper.RandomDifferentNumber(0, parca.Adet - 1, parcaDeger.IdDegerList.Values.ToArray());
                    parcaDeger.IdDegerList.Add(deger, id);
                }
            }

            var resim1parcaDeger = new Dictionary<string, int>();
            var resim2parcaDeger = new Dictionary<string, int>();
            var resim3parcaDeger = new Dictionary<string, int>();

            //Satirdaki uc ayri referans resim icin parca degerlerini belirle
            foreach (var parcaDeger in parcaDegerList)
            {
                var rnd1 = RandomHelper.RandomNumber(1, maxDeger);
                var rnd2 = RandomHelper.RandomNumber(1, maxDeger);
                var rnd3 = rnd1 == rnd2
                    ? RandomHelper.RandomDifferentNumber(1, maxDeger, new[] { rnd1 })
                    : RandomHelper.RandomNumber(1, maxDeger);

                resim1parcaDeger.Add(parcaDeger.Ad, rnd1);
                resim2parcaDeger.Add(parcaDeger.Ad, rnd2);
                resim3parcaDeger.Add(parcaDeger.Ad, rnd3);
            }

            //Satirdaki birinci ve ikinci islemleri belirle
            var islem1 = RandomHelper.RandomBool();
            var islem2 = RandomHelper.RandomBool();


            //Parantez Id sini belirle.
            var parantez = RandomHelper.RandomNumber(0, 1);

            var satir = SatirIslemOlustur(referansResim, parcaDegerList, resim1parcaDeger, islem1, resim2parcaDeger, islem2, resim3parcaDeger, parantez);


            //satirlarin siralarini rastgele belirle

            var gucluList = new Dictionary<string, int>();
            var zayifList = new Dictionary<string, int>();
            foreach (var parca in parcaDegerList)
            {
                gucluList.Add(parca.Ad, parca.IdDegerList[2]);
                zayifList.Add(parca.Ad, parca.IdDegerList[1]);
            }

            satir.GucluList = gucluList;
            satir.ZayifList = zayifList;

            _satirList.Add(satir);

            return parcaDegerList;
        }
        public override void ReferansResimUret()
        {
            _satirList = new List<Satir>(2);

            SatirOlustur();
            _parcaDegerList = SatirOlustur();

            var satir1args = new KuraliBulSatirArg
            {
                Havuz = Havuz,
                ResimBoyut = ResimBoyut,
                GucluList = _satirList[0].GucluList,
                ZayifList = _satirList[0].ZayifList,
                Resim1 = _satirList[0].Resim1,
                Islem1 = _satirList[0].Islem1,
                Resim2 = _satirList[0].Resim2,
                Islem2 = _satirList[0].Islem2,
                Resim3 = _satirList[0].Resim3,
                ParantezId = _satirList[0].ParantezId,
                SonucResim = _satirList[0].Sonuc

            };
            var satir2args = new KuraliBulSatirArg
            {
                Havuz = Havuz,
                ResimBoyut = ResimBoyut,
                GucluList = _satirList[1].GucluList,
                ZayifList = _satirList[1].ZayifList,
                Resim1 = _satirList[1].Resim1,
                Islem1 = _satirList[1].Islem1,
                Resim2 = _satirList[1].Resim2,
                Islem2 = _satirList[1].Islem2,
                Resim3 = _satirList[1].Resim3,
                ParantezId = _satirList[1].ParantezId

            };
            Soru.ReferansResimList.Add(ResimHelper.IslemResimUret(satir1args));
            Soru.ReferansResimList.Add(ResimHelper.IslemSoruResimUret(satir2args));
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
