using System;
using System.Collections.Generic;
using System.Linq;

namespace ZoruSor.Lib.Soru
{
    public class KuraliBulUygula1 : SoruBuilder
    {
        private CiktiResim _buyukDereceliResim;
        private CiktiResim _kucukDereceliResim;

        public override void ReferansResimUret()
        {

            var referansResimler = new List<CiktiResim>();

            _buyukDereceliResim = new CiktiResim();
            _kucukDereceliResim = new CiktiResim();
            //Referans resim uret
            var a = ResimHelper.RasgeleResimUret(Havuz, ResimBoyut);

            // Degisecek parcalari uret
            var degisecekParcalar = ParcaSecimHelper.KadariniSec(Havuz, ZorlukDerece);

            #region Diger referans resimleri Uret

            var b = ResimHelper.ResimDegistirUret(Havuz, a, degisecekParcalar, ResimBoyut);
            CiktiResim c;

            do
            {
                c = ResimHelper.ResimDegistirUret(Havuz, a, degisecekParcalar, ResimBoyut);

            } while (c.Equals(a) || c.Equals(b));


            CiktiResim d;

            do
            {
                d = ResimHelper.ResimDegistirUret(Havuz, a, degisecekParcalar, ResimBoyut);

            } while (d.Equals(a) || d.Equals(b) || d.Equals(c));

            #endregion


            #region Referans resimlere derece ver.

            var dereceler = new List<int>();

            do
            {
                dereceler.Add(RandomHelper.RandomDifferentNumber(1, 4, dereceler.ToArray()));
            } while (dereceler.Count < 4);

            a.Derece = dereceler[0];
            b.Derece = dereceler[1];
            c.Derece = dereceler[2];
            d.Derece = dereceler[3];

            referansResimler.Add(a);
            referansResimler.Add(b);
            referansResimler.Add(c);
            referansResimler.Add(d);
            #endregion

            #region Rastgele birbirinden farkli 4 tane ikili uret

            var soruList = new int[3][];
            soruList[0] = new[] { 1, 3 };
            soruList[1] = new[] { 2, 4 };
            soruList[2] = new[] { 1, 4 };


            var ikililer = new int[4][];
            int[] yeniSatir;


            //Soruyu sec
            var soru = soruList[RandomHelper.RandomNumber(0, 2)];

            var kucukResimId = referansResimler.FindIndex(s => s.Derece == soru[0]);
            var buyukResimId = referansResimler.FindIndex(s => s.Derece == soru[1]);

            //buyuk deger ile kucuk deger arasindaki resmi sec
            var aradakiResimId = referansResimler.FindIndex(s => s.Derece > soru[0] && s.Derece < soru[1]);

            //Son satiri rasgele karistir
            if (RandomHelper.RandomBool())
            {
                ikililer[3] = new[] { kucukResimId, buyukResimId };
            }
            else
            {
                ikililer[3] = new[] { buyukResimId, kucukResimId };
            }


            //rastgele 2 sira sec

            var sira1 = RandomHelper.RandomNumber(0, 2);
            var sira2 = RandomHelper.RandomDifferentNumber(0, 2, new[] { sira1 });

            //Rastgele bir sira sec
            if (RandomHelper.RandomBool())
            {

                //satir 1 i rasgele karistir
                if (RandomHelper.RandomBool())
                {
                    ikililer[sira1] = new[] { kucukResimId, aradakiResimId };
                }
                else
                {
                    ikililer[sira1] = new[] { aradakiResimId, kucukResimId };
                }


                //satir 1 i rasgele karistir
                if (RandomHelper.RandomBool())
                {
                    ikililer[sira2] = new[] { aradakiResimId, buyukResimId };
                }
                else
                {
                    ikililer[sira2] = new[] { buyukResimId, aradakiResimId };
                }
            }
            else
            {
                //satir 1 i rasgele karistir
                if (RandomHelper.RandomBool())
                {
                    ikililer[sira2] = new[] { kucukResimId, aradakiResimId };
                }
                else
                {
                    ikililer[sira2] = new[] { aradakiResimId, kucukResimId };
                }

                //satir 1 i rasgele karistir
                if (RandomHelper.RandomBool())
                {
                    ikililer[sira1] = new[] { aradakiResimId, buyukResimId };
                }
                else
                {
                    ikililer[sira1] = new[] { buyukResimId, aradakiResimId };
                }
            }

            var kalanSatir = 6 - (3 + sira1 + sira2);

            do
            {
                //kalan sira icin  rastgele sayi uret
                var num1 = RandomHelper.RandomNumber(0, 3);

                //secilen sayinin sirasini belirle
                var sira = RandomHelper.RandomNumber(0, 1);

                //kalan sira icin yeni bir sayi daha sec
                var num2 = RandomHelper.RandomDifferentNumber(0, 3, new[] { num1 });

                //yeni satiri olustur
                yeniSatir = new[] { sira == 0 ? num1 : num2, sira == 1 ? num1 : num2 };

                //yeni satir diger satirlardan farkli olana kadar devam et.
            } while (Kontrol(ikililer.Where(s => s != null && s.Length > 0), yeniSatir));

            ikililer[kalanSatir] = yeniSatir;

            foreach (var ikiliSira1 in ikililer)
            {
                var adet = 0;
                foreach (var ikiliSira2 in ikililer)
                {
                    if (ikiliSira1.OrderBy(s => s).First() == ikiliSira2.OrderBy(s => s).First() &&
                        ikiliSira1.OrderBy(s => s).Last() == ikiliSira2.OrderBy(s => s).Last())
                    {
                        adet++;
                    }
                }
                if (adet > 1)
                {
                    throw new ApplicationException("Birden fazla satir var!!!");
                }

            }
            //for (int i = 0; i < 4; i++)
            //{
            //    ikililer[i] = RandomHelper.RandomDifferentNumbers(1, 4, 2, ikililer);
            //}

            #endregion


            #region Resimleri Uret

            for (int i = 0; i < 3; i++)
            {
                Soru.ReferansResimList.Add(ResimHelper.KuraliBulUygulaReferansUret(referansResimler, ikililer[i], ResimBoyut));
            }
            Soru.ReferansResimList.Add(ResimHelper.KuraliBulUygulaSoruUret(referansResimler, ikililer[3], out _buyukDereceliResim, out _kucukDereceliResim, ResimBoyut));
            #endregion


        }
        private bool Kontrol(IEnumerable<int[]> ikililer, int[] yeniSatir)
        {
            var mevcutSatirlar = ikililer as int[][] ?? ikililer.ToArray();
            var adet = 0;
            foreach (var seciliSira in mevcutSatirlar)
            {
                if (seciliSira.OrderBy(s => s).First() == yeniSatir.OrderBy(s => s).First() &&
                        seciliSira.OrderBy(s => s).Last() == yeniSatir.OrderBy(s => s).Last())
                {
                    adet++;
                }
            }
            if (adet > 0)
            {
                return true;
            }
            return false;
        }
        public override void DogruCevapUret()
        {
            //Dogru cevap referans resim uretilirken belirlendi.
            Soru.DogruCevapList.Add(_buyukDereceliResim);
        }

        public override void CeldiriciUret()
        {
         

            //Kucuk dereceli resmi celdiricilere ekle
            Soru.CeldiriciList.Add(_kucukDereceliResim);
            var kalanCeldirici = CeldiriciAdet - 1;
            if (kalanCeldirici == 0)
            {
                return;
            }
            var degisecekParcalar = ParcaSecimHelper.KalaniSec(Havuz, SabitParcaAdet, ZorlukDerece);
            if (kalanCeldirici == 1)
            {
                Soru.CeldiriciList.Add(
                    ResimHelper.ResimDegistirUret(Havuz, Soru.DogruCevapList[0], degisecekParcalar, ResimBoyut));
                return;
            }
            if (kalanCeldirici == 2)
            {
                Soru.CeldiriciList.Add(
                    ResimHelper.ResimDegistirUret(Havuz, Soru.DogruCevapList[0], degisecekParcalar, ResimBoyut));
                Soru.CeldiriciList.Add(
                    ResimHelper.ResimDegistirUret(Havuz, Soru.CeldiriciList[0], degisecekParcalar, ResimBoyut));
            }
            if (kalanCeldirici > 2)
            {
                for (int i = 0; i < kalanCeldirici / 2; i++)
                {
                    Soru.CeldiriciList.Add(
                    ResimHelper.ResimDegistirUret(Havuz, Soru.DogruCevapList[0], degisecekParcalar, ResimBoyut));
                }

                for (int i = kalanCeldirici / 2; i < kalanCeldirici; i++)
                {
                    Soru.CeldiriciList.Add(
                    ResimHelper.ResimDegistirUret(Havuz, Soru.CeldiriciList[0], degisecekParcalar, ResimBoyut));
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
