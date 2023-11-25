using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZoruSor.Lib.Havuz;

namespace ZoruSor.Lib.Soru
{
    /// <summary>
    /// Bu soru şablonu Simetrik ilişki 1 in aynısı. Toplamda her bir değişkenin 4 değeri 
    /// vardır. Bu değerlerin ilişkilerini iki farklı işlem ile gösterir. Bunların yanı sıra 
    /// değerler arasındaki ilişkiyi göstermek için işleme giren parçaları turuncu ve mavi olarak 
    /// renklendirir. İşleme göre kazanan parçalar sonuç resminde gösterirlir.
    /// </summary>
    public class SimetrikIliski4 : SoruBuilder
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
                Resim1Renk = new Dictionary<string, bool>(10);
                Resim2Renk = new Dictionary<string, bool>(10);
                SonucRenk = new Dictionary<string, bool>(10);
                Resim1ParcaDegers = new List<ParcaDeger>(10);
                Resim2ParcaDegers = new List<ParcaDeger>(10);

            }
            public Dictionary<string, int> Resim1 { get; set; }
            public Dictionary<string, bool> Resim1Renk { get; set; }

            public Dictionary<string, int> Resim2 { get; set; }
            public Dictionary<string, bool> Resim2Renk { get; set; }

            public Dictionary<string, int> Sonuc { get; set; }
            public Dictionary<string, bool> SonucRenk { get; set; }

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
                        satir.Resim1Renk.Add(parcaId.Key, false);
                        satir.Resim2.Add(parcaId.Key, buyukId);
                        satir.Resim2Renk.Add(parcaId.Key, true);
                        satir.Resim1ParcaDegers.Add(new ParcaDeger { Ad = parcaId.Key, IdDegerList = new Dictionary<int, int> { { kucukDeger, kucukId } } });
                        satir.Resim2ParcaDegers.Add(new ParcaDeger { Ad = parcaId.Key, IdDegerList = new Dictionary<int, int> { { buyukDeger, buyukId } } });
                    }
                    else
                    {
                        satir.Resim1.Add(parcaId.Key, buyukId);
                        satir.Resim1Renk.Add(parcaId.Key, true);
                        satir.Resim2.Add(parcaId.Key, kucukId);
                        satir.Resim2Renk.Add(parcaId.Key, false);
                        satir.Resim1ParcaDegers.Add(new ParcaDeger { Ad = parcaId.Key, IdDegerList = new Dictionary<int, int> { { buyukDeger, buyukId } } });
                        satir.Resim2ParcaDegers.Add(new ParcaDeger { Ad = parcaId.Key, IdDegerList = new Dictionary<int, int> { { kucukDeger, kucukId } } });
                    }
                    satir.Sonuc.Add(parcaId.Key, sonucBuyuk ? buyukId : kucukId);
                    satir.SonucBuyuk = sonucBuyuk;
                    satir.SonucRenk.Add(parcaId.Key, sonucBuyuk);
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
                for (int i = 0; i < 5; i++)
                {
                    var parca = Havuz.ParcaList.FirstOrDefault(s => s.Ad == parcaDeger.Ad);
                    //Her parcanin secilen parca id' sine 1' den 4' e kadar rastgele deger ata.
                    var deger = RandomHelper.RandomDifferentNumber(1, 5, parcaDeger.IdDegerList.Keys.ToArray());

                    //Rastgele bir parca id sec.
                    var id = RandomHelper.RandomDifferentNumber(0, parca.Adet - 1,
                        parcaDeger.IdDegerList.Values.ToArray());
                    parcaDeger.IdDegerList.Add(deger, id);
                }
            }

            var rnd1 = RandomHelper.RandomNumber(1, 5);
            var rnd2 = RandomHelper.RandomDifferentNumber(1, 5, new[] { rnd1 });
            if (rnd1 > rnd2)
            {
                var sw = rnd1;
                rnd1 = rnd2;
                rnd2 = sw;
            }

            var rnd3 = RandomHelper.RandomNumber(1, 5);
            var rnd4 = RandomHelper.RandomDifferentNumber(1, 5, new[] { rnd1 });
            if (rnd3 > rnd4)
            {
                var sw = rnd3;
                rnd3 = rnd4;
                rnd4 = sw;
            }
            _satirList = new List<Satir>
            {
                //(A * B) Birinci satiri olustur.
                SatirOlustur(1, 2, true),
                //(B * C) Ikinci satiri olustur.
                SatirOlustur(2,3, false),
                //(C * D) Ucuncu satiri olustur.
                SatirOlustur(3,4, true),
                //(D * E) Dorduncu satiri olustur.
                SatirOlustur(4,5, true),
                //Birinci soru satiri olustur.
                SatirOlustur(rnd1,rnd2, true),
                //Ikinci Soru satirini olustur.
                SatirOlustur(rnd3,rnd4, false)
            };




            //satirlarin siralarini rastgele belirle
            var siraList = new int[4];
            for (int i = 0; i < 4; i++)
            {
                siraList[i] = -1;
            }

            siraList[0] = RandomHelper.RandomDifferentNumber(0, 3, siraList);
            siraList[1] = RandomHelper.RandomDifferentNumber(0, 3, siraList);
            siraList[2] = RandomHelper.RandomDifferentNumber(0, 3, siraList);
            siraList[3] = RandomHelper.RandomDifferentNumber(0, 3, siraList);

            Soru.ReferansResimList.Add(ResimHelper.IslemResimUret(Havuz, _satirList[siraList[0]].Resim1, _satirList[siraList[0]].Resim2, _satirList[siraList[0]].Sonuc, _satirList[siraList[0]].SonucBuyuk, _satirList[siraList[0]].Resim1Renk, _satirList[siraList[0]].Resim2Renk, _satirList[siraList[0]].SonucRenk, ResimBoyut));
            Soru.ReferansResimList.Add(ResimHelper.IslemResimUret(Havuz, _satirList[siraList[1]].Resim1, _satirList[siraList[1]].Resim2, _satirList[siraList[1]].Sonuc, _satirList[siraList[1]].SonucBuyuk, _satirList[siraList[1]].Resim1Renk, _satirList[siraList[1]].Resim2Renk, _satirList[siraList[1]].SonucRenk, ResimBoyut));
            Soru.ReferansResimList.Add(ResimHelper.IslemResimUret(Havuz, _satirList[siraList[2]].Resim1, _satirList[siraList[2]].Resim2, _satirList[siraList[2]].Sonuc, _satirList[siraList[2]].SonucBuyuk, _satirList[siraList[2]].Resim1Renk, _satirList[siraList[2]].Resim2Renk, _satirList[siraList[2]].SonucRenk, ResimBoyut));
            Soru.ReferansResimList.Add(ResimHelper.IslemResimUret(Havuz, _satirList[siraList[3]].Resim1, _satirList[siraList[3]].Resim2, _satirList[siraList[3]].Sonuc, _satirList[siraList[3]].SonucBuyuk, _satirList[siraList[3]].Resim1Renk, _satirList[siraList[3]].Resim2Renk, _satirList[siraList[3]].SonucRenk, ResimBoyut));


            Soru.ReferansResimList.Add(ResimHelper.IslemSoruResimUret(Havuz, _satirList[4].Resim1, _satirList[4].Resim2, _satirList[4].SonucBuyuk, _satirList[4].Resim1Renk, _satirList[4].Resim2Renk, _satirList[4].SonucRenk, ResimBoyut));
            Soru.ReferansResimList.Add(ResimHelper.IslemSoruResimUret(Havuz, _satirList[5].Resim1, _satirList[5].Resim2, _satirList[5].SonucBuyuk, _satirList[5].Resim1Renk, _satirList[5].Resim2Renk, _satirList[5].SonucRenk, ResimBoyut));

        }


        public override void DogruCevapUret()
        {
            Soru.DogruCevapList.Add(ResimHelper.ResimUret(Havuz, _satirList[4].Sonuc, _satirList[5].Sonuc, ResimBoyut));
        }

        public override void CeldiriciUret()
        {

            var birinciSoruSatir1 = ResimHelper.ResimUret(Havuz, _satirList[4].Resim1, ResimBoyut);
            var birinciSoruSatir2 = ResimHelper.ResimUret(Havuz, _satirList[4].Resim2, ResimBoyut);
            var ikinciSoruSatir1 = ResimHelper.ResimUret(Havuz, _satirList[5].Resim1, ResimBoyut);
            var ikinciSoruSatir2 = ResimHelper.ResimUret(Havuz, _satirList[5].Resim2, ResimBoyut);

            var kalanCeldirici = CeldiriciAdet;


            if (_satirList[4].Sonuc.Equals(birinciSoruSatir1.ParcaList) == false &&
                _satirList[5].Sonuc.Equals(ikinciSoruSatir1.ParcaList) == false)
            {
                Soru.CeldiriciList.Add(ResimHelper.ResimUret(Havuz, birinciSoruSatir1.ParcaList, 
                    ikinciSoruSatir1.ParcaList, ResimBoyut));
                kalanCeldirici--;
            }
            if (_satirList[4].Sonuc.Equals(birinciSoruSatir2.ParcaList) == false &&
                _satirList[5].Sonuc.Equals(ikinciSoruSatir2.ParcaList) == false)
            {
                Soru.CeldiriciList.Add(ResimHelper.ResimUret(Havuz, birinciSoruSatir2.ParcaList,
                    ikinciSoruSatir2.ParcaList, ResimBoyut));
                kalanCeldirici--;
            }

            if (_satirList[4].Sonuc.Equals(birinciSoruSatir1.ParcaList) == false &&
                _satirList[5].Sonuc.Equals(ikinciSoruSatir2.ParcaList) == false)
            {
                Soru.CeldiriciList.Add(ResimHelper.ResimUret(Havuz, birinciSoruSatir1.ParcaList,
                    ikinciSoruSatir2.ParcaList, ResimBoyut));
                kalanCeldirici--;
            }

            if (_satirList[4].Sonuc.Equals(birinciSoruSatir2.ParcaList) == false &&
                 _satirList[5].Sonuc.Equals(ikinciSoruSatir1.ParcaList) == false)
            {
                Soru.CeldiriciList.Add(ResimHelper.ResimUret(Havuz, birinciSoruSatir2.ParcaList,
                    ikinciSoruSatir1.ParcaList, ResimBoyut));
                kalanCeldirici--;
            }


            //Son satırdaki kuralli parcalari al.
            var kuralliParcalar = Havuz.ParcaList.Where(s => _parcaDegerList.Any(x => x.Ad == s.Ad)).ToList();



            //Aynisini bul ile ayni
            //celdirici adedi kadar
            for (var i = 0; i < kalanCeldirici; i++)
            {
                //Sabit parca kadarini dogru cevap ile ayni birak
                var resim1parcaList = kuralliParcalar.OrderByDescending(s =>
                            s.Derece).Take(SabitParcaAdet).
                    ToDictionary(parca => parca.Ad, parca =>
                            _satirList[4].Sonuc[parca.Ad]);

                var resim2parcaList = kuralliParcalar.OrderByDescending(s =>
                            s.Derece).Take(SabitParcaAdet).
                    ToDictionary(parca => parca.Ad, parca =>
                            _satirList[5].Sonuc[parca.Ad]);

                //Sabit parca disindaki parcalardan birden parca adet-1 tanesini random celdiriciye ekle
                if (ZorlukDerece > 3)
                {
                    var rnd1 = RandomHelper.RandomNumber(1, _parcaDegerList.Count - resim1parcaList.Count);
                    var rnd2 = RandomHelper.RandomNumber(1, _parcaDegerList.Count - resim2parcaList.Count);
                    var eklenecekParcalar1 = _parcaDegerList.Where(s => resim1parcaList.ContainsKey(s.Ad) == false). Take(rnd1).ToList();
                    var eklenecekParcalar2 = _parcaDegerList.Where(s => resim2parcaList.ContainsKey(s.Ad) == false).Take(rnd2).ToList();

                    foreach (var parcaDeger in eklenecekParcalar1)
                    {
                        if (RandomHelper.RandomBool())
                        {
                            resim1parcaList.Add(parcaDeger.Ad, _satirList[4].Resim1ParcaDegers.FirstOrDefault(s => s.Ad == parcaDeger.Ad).IdDegerList.Values.First());
                        }
                        else
                        {
                            resim1parcaList.Add(parcaDeger.Ad, _satirList[4].Resim2ParcaDegers.FirstOrDefault(s => s.Ad == parcaDeger.Ad).IdDegerList.Values.First());
                        }
                    }

                    foreach (var parcaDeger in eklenecekParcalar2)
                    {
                        if (RandomHelper.RandomBool())
                        {
                            resim2parcaList.Add(parcaDeger.Ad, _satirList[5].Resim1ParcaDegers.FirstOrDefault(s => s.Ad == parcaDeger.Ad).IdDegerList.Values.First());
                        }
                        else
                        {
                            resim2parcaList.Add(parcaDeger.Ad, _satirList[5].Resim2ParcaDegers.FirstOrDefault(s => s.Ad == parcaDeger.Ad).IdDegerList.Values.First());
                        }
                    }
                }

                //Kalan parcalari rastgele degistir. 
                var kalanParcalar1 = Havuz.ParcaList.Where(s => resim1parcaList.ContainsKey(s.Ad) == false).Select(s => s.Ad).ToList();
                var kalanParcalar2 = Havuz.ParcaList.Where(s => resim2parcaList.ContainsKey(s.Ad) == false).Select(s => s.Ad).ToList();

                foreach (var prc in ParcaSecimHelper.ParcaDegerUret(Havuz, kalanParcalar1))
                {
                    resim1parcaList.Add(prc.Key, prc.Value);
                }

                foreach (var prc in ParcaSecimHelper.ParcaDegerUret(Havuz, kalanParcalar2))
                {
                    resim2parcaList.Add(prc.Key, prc.Value);
                }


                var sonuc = ResimHelper.ResimUret(Havuz, resim1parcaList, resim2parcaList, ResimBoyut);
                //celdiriciyi sorunun listesine ekle
                if (Soru.CeldiriciList.Any(s => s.ParcaList.Equals(resim1parcaList) && s
                .DigerResimParcaList.Equals(s.ParcaList)) || 
                (Soru.DogruCevapList[0].ParcaList.Equals(resim1parcaList)&&
                Soru.DogruCevapList[1].ParcaList.Equals(resim2parcaList)))
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
