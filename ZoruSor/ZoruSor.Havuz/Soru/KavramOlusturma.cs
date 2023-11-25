using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ZoruSor.Lib.Soru
{
    public class KavramOlusturma : SoruBuilder
    {
        private Dictionary<string, int> _ortakParcalar;
        public override void ReferansResimUret()
        {
            _ortakParcalar = new Dictionary<string, int>(10);

            //Bir tane referans resim uret.
            Soru.ReferansResimList.Add(ResimHelper.RasgeleResimUret(Havuz, ResimBoyut));

            //Bu resmi baz alarak Zorluk Derecesi -1 tane parcasi farkli olan 3 tane daha resim olustur.
            var degisecekParcalar = ParcaSecimHelper.KadariniSec(Havuz, ZorlukDerece - 1);

            for (int i = 0; i < 3; i++)
            {
                Soru.ReferansResimList.Add(ResimHelper.ResimDegistirUret(Havuz, Soru.ReferansResimList[0], degisecekParcalar, ResimBoyut));
            }


            //Referans resimlerin Ilk 4 tanesinde ortak olan ve sonraki 4'unde olmayan parcalari al.
            foreach (var seciliParca in Havuz.ParcaList)
            {
                var hepsiAnyi = true;
                for (int i = 0; i < 3; i++)
                {
                    if (Soru.ReferansResimList[i].ParcaList[seciliParca.Ad] != Soru.ReferansResimList[i + 1].ParcaList[seciliParca.Ad])
                    {
                        hepsiAnyi = false;
                    }
                }
                if (hepsiAnyi)
                {
                    _ortakParcalar.Add(seciliParca.Ad, Soru.ReferansResimList[0].ParcaList[seciliParca.Ad]);
                }
            }

            for (int i = 0; i < 4; i++)
            {
                Soru.ReferansResimList.Add(ResimHelper.RasgeleResimUret(Havuz, ResimBoyut));
            }

            //Diger Dort resimde bu parcalarin aynisi varsa bu parcalari cikar.
            var cikarilacaklar = new Dictionary<string, int>();
            foreach (var seciliParca in _ortakParcalar)
            {
                var resimdeVar = false;
                for (int i = 4; i < 8; i++)
                {
                    if (seciliParca.Value == Soru.ReferansResimList[i].ParcaList[seciliParca.Key])
                    {
                        resimdeVar = true;
                    }
                }
                if (resimdeVar)
                {
                    cikarilacaklar.Add(seciliParca.Key, seciliParca.Value);
                }
            }
            //Eger ortak parca sayisi Ortakparca sayisi -1 Kotu parca sayisindan kucukse 
            if (_ortakParcalar.Count - 1 < cikarilacaklar.Count)
            {
                //kotu parcalardan degistirilecek sayisini hesapla
                var cnt = cikarilacaklar.Count - (_ortakParcalar.Count - 1);

                var iptalEdilenler = cikarilacaklar.Take(cnt).ToList();

                foreach (var parca in iptalEdilenler)
                {
                    for (int i = 4; i < 8; i++)
                    {
                        if (Soru.ReferansResimList[i].ParcaList[parca.Key] == parca.Value)
                        {
                            var havuzParca = Havuz.ParcaList.FirstOrDefault(s => s.Ad == parca.Key);
                            if (havuzParca != null)
                            {
                                var yeniDeger = RandomHelper.RandomDifferentNumber(0, havuzParca.Adet-1, new[] { parca.Value });
                                var yeniParca = new Dictionary<string, int>();
                                yeniParca.Add(parca.Key, yeniDeger);
                                Soru.ReferansResimList[i] = ResimHelper.ParcaDegistir(Havuz, Soru.ReferansResimList[i], yeniParca, ResimBoyut);
                            }
                        }
                    }
                    cikarilacaklar.Remove(parca.Key);
                }
            }

            foreach (var kotuParca in cikarilacaklar)
            {
                _ortakParcalar.Remove(kotuParca.Key);
            }


        }

        public override void DogruCevapUret()
        {
            //Rastgele bir resim uret.
            var dogruCevap = ResimHelper.RasgeleResimUret(Havuz, ResimBoyut);
            //Yeni resmin parcalarini kalan parcalarla guncelle. 
            dogruCevap = ResimHelper.ParcaDegistir(Havuz, dogruCevap, _ortakParcalar, ResimBoyut);

            //dogru cevaptaki kotu Parcalari sec
            var kotuParcalar = new Dictionary<string, List<int>>();
            foreach (var seciliParca in dogruCevap.ParcaList)
            {
                var kotu = false;
                for (int i = 4; i < 8; i++)
                {
                    if (Soru.ReferansResimList[i].ParcaList[seciliParca.Key] == seciliParca.Value)
                    {
                        kotu = true;
                    }
                }
                if (kotu)
                {
                    var idList = new List<int>();
                    for (int i = 4; i < 8; i++)
                    {
                        idList.Add(Soru.ReferansResimList[i].ParcaList[seciliParca.Key]);
                    }
                    kotuParcalar.Add(seciliParca.Key, idList);
                }
            }

            var yeniParcalar = new Dictionary<string, int>();
            //kotu parcalari yenileri ile degistir.
            foreach (var seciliParca in kotuParcalar)
            {
                var havuzParcasi = Havuz.ParcaList.FirstOrDefault(s => s.Ad == seciliParca.Key);

                if (havuzParcasi != null)
                {
                    var yeniId = RandomHelper.RandomDifferentNumber(0, havuzParcasi.Adet-1, seciliParca.Value.ToArray());
                    yeniParcalar.Add(seciliParca.Key, yeniId);
                }
            }
            dogruCevap = ResimHelper.ParcaDegistir(Havuz, dogruCevap, yeniParcalar, ResimBoyut);
            Soru.DogruCevapList.Add(dogruCevap);
        }

        public override void CeldiriciUret()
        {
            //Referans resmi baz alarak Zorluk seviyesi ve sabit parca adedine gore celdiricileri uret.
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
                var degisecekOrtakParAdet = 0;
                //degisecek ortak parca sayisini hesapla
                foreach (var parca in _ortakParcalar)
                {
                    if (degisecekParcalar.Contains(parca.Key))
                    {
                        degisecekOrtakParAdet++;
                    }
                }
                //Eger degisecek ortak parca sayisi, ortak parca sayisinin %50 sinden azsa
                var ortalama = (double)degisecekOrtakParAdet / _ortakParcalar.Count;
                if (ortalama < 0.5d)
                {
                    //Degisecek parcalardan ortak parcalar haricindekileri sec.
                    var ortakParcaHarici = degisecekParcalar.Where(s => _ortakParcalar.ContainsKey(s) == false);

                    //iptal edilecek parca sayisini belirle
                    var ortakYarisi = (int)Math.Round(_ortakParcalar.Count * 0.6d, MidpointRounding.AwayFromZero);

                    var iptalEdilecekParcaAdet = ortakYarisi - degisecekOrtakParAdet;

                    //degisecek parcalardan hesaplanan kadar parca cikar
                    foreach (var iptalParca in ortakParcaHarici.Take(iptalEdilecekParcaAdet).ToList())
                    {
                        degisecekParcalar.Remove(iptalParca);
                    }

                    var olmayanOrtaklar = _ortakParcalar.Where(s => degisecekParcalar.Contains(s.Key) == false);
                    //Degisim listesinde olmayan ortaklardan hesaplanan kadarini degisime ekle
                    foreach (var yeniOrtak in olmayanOrtaklar.Take(iptalEdilecekParcaAdet).ToList())
                    {
                        degisecekParcalar.Add(yeniOrtak.Key);
                    }
                }
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
