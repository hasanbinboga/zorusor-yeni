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
    /// Bu soru şablonu 11 ila 13. soru sablonlarina benzemektedir. Huseyin tarafindan gelistirilmistir.
    /// Parcalarin uc farkli degeri vardir. Bu degerler 1 ile 10 arasinda olabilir. 
    /// Her bir referans resimde rastgele guclu, normal ve zayif parcalardan olusur. Isleme giren parcalarin uc degeri vardir. 
    /// Bu parcalarin degerleri ise satirlarin ilk basinda gosterilir. 
    /// Daha sonra onceki kurali bul uygula soru turlerinde oldugu gibi bu parcalarin bulundugu  islem resmi yer alir. 
    /// Islem resminde onceki soru turlerinden farkli olarak uc tane resim  vardir. Bu resimlerden ikisi parantez icerisindedir. 
    /// Ilk satirda cozum verilir.  Ikinci satirda ise yine benzer sekilde parcalarin degerleri ve islem resmi vardir. 
    /// Bu islemin cevabi sorulur.
    /// </summary>
    public class KuraliBulUygulaHus : SoruBuilder
    {
        internal class Satir
        {
            public Satir()
            {
                Resim1 = new Dictionary<string, int>(10);
                Resim2 = new Dictionary<string, int>(10);
                Resim3 = new Dictionary<string, int>();
                Sonuc = new Dictionary<string, int>(10);
                Resim1ParcaFiyats = new List<ParcaFiyat>(10);
                Resim2ParcaFiyats = new List<ParcaFiyat>(10);
                Resim3ParcaFiyats = new List<ParcaFiyat>(10);

            }

            public Dictionary<string, int> Resim1 { get; set; }

            public Dictionary<string, int> Resim2 { get; set; }
            public Dictionary<string, int> Resim3 { get; set; }

            public Dictionary<string, int> Sonuc { get; set; }

            public List<ParcaFiyat> Resim1ParcaFiyats { get; set; }
            public List<ParcaFiyat> Resim2ParcaFiyats { get; set; }
            public List<ParcaFiyat> Resim3ParcaFiyats { get; set; }
            public bool Islem1 { get; set; }
            public bool Islem2 { get; set; }
            public int ParantezId { get; set; }

            public List<ParcaFiyat> PahaliFiyatList { get; set; }
            public List<ParcaFiyat> NormalFiyatList { get; set; }
            public List<ParcaFiyat> UcuzFiyatList { get; set; }

            public int Resim1Toplam { get; set; }
            public int Resim2Toplam { get; set; }
            public int Resim3Toplam { get; set; }
            public int SonucToplam { get; set; }
        }

        private List<Satir> _satirList;

        private List<ParcaFiyat> _parcaFiyatList;

        private Satir SatirIslemOlustur(CiktiResim referansResim, List<ParcaFiyat> resim1Deger, bool islem1,
            List<ParcaFiyat> resim2Deger, bool islem2, List<ParcaFiyat> resim3Deger, int parantezId)
        {
            var satir = new Satir();
            foreach (var parcaId in referansResim.ParcaList)
            {
                //Secili parcayi deger listesinde bul.
                var parcaAd = parcaId.Key;

                //resmlerin parca fiyatlarini al
                var resim1ParcaFiyat = resim1Deger.FirstOrDefault(s => s.Ad == parcaAd);
                var resim2ParcaFiyat = resim2Deger.FirstOrDefault(s => s.Ad == parcaAd);
                var resim3ParcaFiyat = resim3Deger.FirstOrDefault(s => s.Ad == parcaAd);

                //Eger secili parca fiyat listesinde varsa.
                if (resim1ParcaFiyat != null && resim1ParcaFiyat.Ad == parcaAd)
                {
                    ParcaFiyat satirSonuc = new ParcaFiyat();

                    #region Islemleri gerceklestir

                    //Parantez Id' si sifir ise
                    if (parantezId == 0)
                    {


                        ParcaFiyat sonuc1;
                        //Ilk Islem True ise
                        if (islem1)
                        {
                            //Ilk Islem True ise guclu kazanir.
                            //Sonuc degerini ata.
                            sonuc1 = resim1ParcaFiyat.Fiyat > resim2ParcaFiyat.Fiyat ? resim1ParcaFiyat : resim2ParcaFiyat;
                        }
                        else
                        {
                            //Ilk islem False ise zayif kazanir.
                            //Sonuc degerini ata.
                            sonuc1 = resim1ParcaFiyat.Fiyat < resim2ParcaFiyat.Fiyat ? resim1ParcaFiyat : resim2ParcaFiyat;
                        }

                        //Ikinci Islem True ise
                        if (islem2)
                        {
                            //Ikinci islem True ise guclu kazanir.
                            //Sonuc degerini ata.
                            satirSonuc = sonuc1.Fiyat > resim3ParcaFiyat.Fiyat ? sonuc1 : resim3ParcaFiyat;
                        }
                        else
                        {
                            //Ikinci islem False ise zayif olan kazanir.
                            //Sonuc degerini ata.
                            satirSonuc = sonuc1.Fiyat < resim3ParcaFiyat.Fiyat ? sonuc1 : resim3ParcaFiyat;
                        }
                    }
                    //Parantez Id' si 1 ise
                    else if (parantezId == 1)
                    {

                        ParcaFiyat sonuc1;
                        //Ikinci islem True ise
                        if (islem2)
                        {
                            //Ikinci islem True ise guclu kazanir.
                            //sonuc degerini ata.
                            sonuc1 = resim2ParcaFiyat.Fiyat > resim3ParcaFiyat.Fiyat ? resim2ParcaFiyat : resim3ParcaFiyat;
                        }
                        else
                        {
                            //Ikinci islem False ise zayif olan kazanir.
                            //Sonuc Degerini ata.
                            sonuc1 = resim2ParcaFiyat.Fiyat < resim3ParcaFiyat.Fiyat ? resim2ParcaFiyat : resim3ParcaFiyat;
                        }

                        //Eger birinci islem True ise
                        if (islem1)
                        {
                            //Birinci islem True ise guclu kazanir.
                            //Satirin sonucunu belirle
                            satirSonuc = sonuc1.Fiyat > resim1ParcaFiyat.Fiyat ? sonuc1 : resim1ParcaFiyat;
                        }
                        else
                        {
                            //Birinci islem False ise zayif olan kazanir.
                            //Satirin sonucunu belirle
                            satirSonuc = sonuc1.Fiyat < resim1ParcaFiyat.Fiyat ? sonuc1 : resim1ParcaFiyat;
                        }
                    }

                    #endregion



                    //Artik islem sonuclarini hesapladik.

                    //Simdi satiri olusturan resimleri olusturabiliriz.



                    satir.Resim1ParcaFiyats.Add(resim1ParcaFiyat);
                    satir.Resim2ParcaFiyats.Add(resim2ParcaFiyat);
                    satir.Resim3ParcaFiyats.Add(resim3ParcaFiyat);

                    satir.Resim1.Add(parcaAd, resim1ParcaFiyat.Id);
                    satir.Resim2.Add(parcaAd, resim2ParcaFiyat.Id);
                    satir.Resim3.Add(parcaAd, resim3ParcaFiyat.Id);

                    satir.Sonuc.Add(parcaAd, satirSonuc.Id);

                    satir.Resim1Toplam += resim1ParcaFiyat.Fiyat;
                    satir.Resim2Toplam += resim2ParcaFiyat.Fiyat;
                    satir.Resim3Toplam += resim3ParcaFiyat.Fiyat;

                    satir.SonucToplam += satirSonuc.Fiyat;
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

        private List<ParcaFiyat> SatirOlustur()
        {
            //rastgele bir resim uret.
            var referansResim = ResimHelper.RasgeleResimUret(Havuz, ResimBoyut);

            //Zorluk seviyesi kadar parca sec.
            var parcaFiyatList = new List<ParcaFiyat>(ZorlukDerece);

            ParcaSecimHelper.KadariniSec(Havuz, ZorlukDerece).ForEach(parcaAd =>
            {
                parcaFiyatList.Add(new ParcaFiyat { Ad = parcaAd });
                parcaFiyatList.Add(new ParcaFiyat { Ad = parcaAd });
                parcaFiyatList.Add(new ParcaFiyat { Ad = parcaAd });
            });

            var maxDeger = 3;
            var maxFiyat = 9;
            //Her parca icin ucer tane id sec.
            foreach (var parcaFiyat in parcaFiyatList)
            {
                for (int i = 0; i < maxDeger; i++)
                {
                    var parca = Havuz.ParcaList.FirstOrDefault(s => s.Ad == parcaFiyat.Ad);
                    //Her parcanin secilen parca id' sine 1' den 10' a kadar rastgele deger ata.
                    var yenifiyat = RandomHelper.RandomDifferentNumber(1, maxFiyat, parcaFiyatList.
                        Where(s => s.Ad == parcaFiyat.Ad).Select(s => s.Fiyat).ToArray());

                    //Rastgele bir parca id sec.
                    var id = RandomHelper.RandomDifferentNumber(0, parca.Adet - 1, parcaFiyatList.
                        Where(s => s.Ad == parcaFiyat.Ad).Select(s => s.Id).ToArray());
                    parcaFiyat.Id = id;
                    parcaFiyat.Fiyat = yenifiyat;
                }
            }

            var resim1ParcaFiyat = new List<ParcaFiyat>();
            var resim2ParcaFiyat = new List<ParcaFiyat>();
            var resim3ParcaFiyat = new List<ParcaFiyat>();

            //Satirdaki uc ayri referans resim icin parca degerlerini belirle
            foreach (var parcaAd in parcaFiyatList.Select(s => s.Ad).Distinct())
            {

                var rnd1 = RandomHelper.RandomNumber(0, maxDeger - 1);
                var rnd2 = RandomHelper.RandomNumber(0, maxDeger - 1);
                var rnd3 = rnd1 == rnd2
                    ? RandomHelper.RandomDifferentNumber(0, maxDeger - 1, new[] { rnd1 })
                    : RandomHelper.RandomNumber(0, maxDeger - 1);
                var fiyatList = parcaFiyatList.Where(s => s.Ad == parcaAd).ToList();
                resim1ParcaFiyat.Add(fiyatList[rnd1]);
                resim2ParcaFiyat.Add(fiyatList[rnd2]);
                resim3ParcaFiyat.Add(fiyatList[rnd3]);
            }

            //Satirdaki birinci ve ikinci islemleri belirle
            var islem1 = RandomHelper.RandomBool();
            var islem2 = RandomHelper.RandomBool();


            //Parantez Id sini belirle.
            var parantez = RandomHelper.RandomNumber(0, 1);

            var satir = SatirIslemOlustur(referansResim, resim1ParcaFiyat, islem1, resim2ParcaFiyat, islem2, resim3ParcaFiyat, parantez);


            //satirlarin siralarini rastgele belirle

            var gucluList = new List<ParcaFiyat>();
            var normalList = new List<ParcaFiyat>();
            var zayifList = new List<ParcaFiyat>();
            foreach (var parcaAd in parcaFiyatList.Select(s => s.Ad).Distinct())
            {
                var fiyatlar = parcaFiyatList.Where(s => s.Ad == parcaAd).OrderBy(s => s.Fiyat).ToList();
                zayifList.Add(new ParcaFiyat { Ad = parcaAd, Fiyat = fiyatlar[0].Fiyat, Id = fiyatlar[0].Id });
                normalList.Add(new ParcaFiyat { Ad = parcaAd, Fiyat = fiyatlar[1].Fiyat, Id = fiyatlar[1].Id });
                gucluList.Add(new ParcaFiyat { Ad = parcaAd, Fiyat = fiyatlar[2].Fiyat, Id = fiyatlar[2].Id });

            }

            satir.PahaliFiyatList = gucluList.Shuffle();
            satir.NormalFiyatList = normalList.Shuffle();
            satir.UcuzFiyatList = zayifList.Shuffle();

            _satirList.Add(satir);

            return parcaFiyatList.Shuffle();
        }
        public override void ReferansResimUret()
        {
            _satirList = new List<Satir>(2);

            SatirOlustur();
            _parcaFiyatList = SatirOlustur();

            var satir1args = new KuraliBulSatirArg
            {
                Havuz = Havuz,
                ResimBoyut = ResimBoyut,
                PahaliFiyatList = _satirList[0].PahaliFiyatList,
                NormalFiyatList = _satirList[0].NormalFiyatList,
                UcuzFiyatList = _satirList[0].UcuzFiyatList,
                Resim1 = _satirList[0].Resim1,
                Islem1 = _satirList[0].Islem1,
                Resim2 = _satirList[0].Resim2,
                Islem2 = _satirList[0].Islem2,
                Resim3 = _satirList[0].Resim3,
                ParantezId = _satirList[0].ParantezId,
                SonucResim = _satirList[0].Sonuc,
                Resim1FiyatToplam = _satirList[0].Resim1Toplam.ToString(),
                Resim2FiyatToplam = _satirList[0].Resim2Toplam.ToString(),
                Resim3FiyatToplam = _satirList[0].Resim3Toplam.ToString(),
                SonucResimFiyatToplam = _satirList[0].SonucToplam.ToString(),

            };
            var satir2args = new KuraliBulSatirArg
            {
                Havuz = Havuz,
                ResimBoyut = ResimBoyut,
                PahaliFiyatList = _satirList[1].PahaliFiyatList,
                NormalFiyatList = _satirList[1].NormalFiyatList,
                UcuzFiyatList = _satirList[1].UcuzFiyatList,
                Resim1 = _satirList[1].Resim1,
                Islem1 = _satirList[1].Islem1,
                Resim2 = _satirList[1].Resim2,
                Islem2 = _satirList[1].Islem2,
                Resim3 = _satirList[1].Resim3,
                ParantezId = _satirList[1].ParantezId,
                Resim1FiyatToplam = _satirList[1].Resim1Toplam.ToString(),
                Resim2FiyatToplam = _satirList[1].Resim2Toplam.ToString(),
                Resim3FiyatToplam = _satirList[1].Resim3Toplam.ToString(),
                SonucResimFiyatToplam = _satirList[1].SonucToplam.ToString()
            };
            Soru.ReferansResimList.Add(ResimHelper.IslemResimUret2(satir1args));
            Soru.ReferansResimList.Add(ResimHelper.IslemSoruResimUret2(satir2args));
        }

        public override void DogruCevapUret()
        {
            Soru.DogruCevapList.Add(ResimHelper.MelezResimUret(
                                        ResimHelper.ResimUret(Havuz, _satirList[1].Sonuc, ResimBoyut),
                                        _satirList[1].SonucToplam.ToString(), ResimBoyut, 4));
        }

        public override void CeldiriciUret()
        {
            var minFiyat = _satirList.Min(s => s.SonucToplam);
            var maxFiyat = _satirList.Max(s => s.SonucToplam);

            var sonSatir1 = ResimHelper.MelezResimUret(ResimHelper.ResimUret(Havuz, _satirList[1].Resim1, ResimBoyut), _satirList[1].Resim1Toplam.ToString(), ResimBoyut, 4);
            var sonSatir2 = ResimHelper.MelezResimUret(ResimHelper.ResimUret(Havuz, _satirList[1].Resim2, ResimBoyut), _satirList[1].Resim2Toplam.ToString(), ResimBoyut, 4);
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
            var kuralliParcalar = Havuz.ParcaList.Where(s => _parcaFiyatList.Any(x => x.Ad == s.Ad)).ToList();


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
                    var rnd = RandomHelper.RandomNumber(1, _parcaFiyatList.Select(s => s.Ad).Distinct().Count() - parcaList.Count);
                    var eklenecekParcalar = _parcaFiyatList.Where(s => parcaList.ContainsKey(s.Ad) == false).Select(s => s.Ad).Distinct().Take(rnd).ToList();
                    foreach (var parcaAd in eklenecekParcalar)
                    {
                        if (RandomHelper.RandomBool())
                        {
                            parcaList.Add(parcaAd, _satirList[1].Resim1ParcaFiyats.FirstOrDefault(s => s.Ad == parcaAd).Id);
                        }
                        else
                        {
                            parcaList.Add(parcaAd, _satirList[1].Resim2ParcaFiyats.FirstOrDefault(s => s.Ad == parcaAd).Id);
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
                    var randFiyat = RandomHelper.RandomNumber(minFiyat < 10 ? minFiyat : minFiyat - 9, maxFiyat + 10).ToString();
                    
                    Soru.CeldiriciList.Add(ResimHelper.MelezResimUret(sonuc, randFiyat, ResimBoyut, 4));
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
