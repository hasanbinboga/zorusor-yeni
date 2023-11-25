using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZoruSor.Lib.Soru
{
    public class AnalojiIkili1 : SoruBuilder
    {
        protected CiktiResim ReferansResim1;
        protected CiktiResim ReferansResim2;
        protected CiktiResim DogruCevap1;
        protected CiktiResim DogruCevap2;
        protected Dictionary<string, int> EskiParcaDegerleri;
        protected Dictionary<string, int> YeniParcaDegerleri;


        public override void ReferansResimUret()
        {
            //Referans Resim uret
            ReferansResim1 = ResimHelper.RasgeleResimUret(Havuz, ResimBoyut);

            //Zorluk derecesine gore zorluk derecesi kadar degisecek parca sec
            var degisecekParcalar = ParcaSecimHelper.KadariniSec(Havuz, ZorlukDerece);

            //Degisecek parcalarin mevcut resimdeki id lerini sec ve yeni resimde olacak idleri sec.
            EskiParcaDegerleri = new Dictionary<string, int>();
            YeniParcaDegerleri = new Dictionary<string, int>();
            foreach (var seciliParca in ReferansResim1.ParcaList)
            {
                if (degisecekParcalar.Contains(seciliParca.Key))
                {
                    EskiParcaDegerleri.Add(seciliParca.Key, seciliParca.Value);
                    var degisecekParca = Havuz.ParcaList.FirstOrDefault(s => s.Ad == seciliParca.Key);
                    if (degisecekParca != null)
                        YeniParcaDegerleri.Add(seciliParca.Key,
                            RandomHelper.RandomDifferentNumber(0, degisecekParca.Adet - 1, new[] { seciliParca.Value }));
                }
            }

            //Referans resme yeni parcalari uygulayarak yeni parca uret
            ReferansResim2 = ResimHelper.ParcaDegistir(Havuz, ReferansResim1, YeniParcaDegerleri, ResimBoyut);

            //iki resmi birlestirip referans resim listesine ekle.
            Soru.ReferansResimList.Add(ResimHelper.IkiliResimUret(ReferansResim1, ReferansResim2, ResimBoyut));
        }

        public override void DogruCevapUret()
        {
            //parcalarin eski id lerini kullanarak yeni bir resim uret.
            DogruCevap1 = ResimHelper.RasgeleResimUret(Havuz, ResimBoyut);
            DogruCevap1 = ResimHelper.ParcaDegistir(Havuz, DogruCevap1, EskiParcaDegerleri, ResimBoyut);
            //bu resme yeni parca id lerini uygulayarak yeni bir resim uret.
            DogruCevap2 = ResimHelper.ParcaDegistir(Havuz, DogruCevap1, YeniParcaDegerleri, ResimBoyut);
            //Iki resmi birlestirip dogruCevap listesine ekle.
            Soru.DogruCevapList.Add(ResimHelper.IkiliResimUret(DogruCevap1, DogruCevap2, ResimBoyut));

        }

        public override void CeldiriciUret()
        {
            //Dogru Cevap Resimlerini al.
            //Zorluk derecesi kadar parcayi, sabitler ciktiktan sonra, degistir.
            for (int i = 0; i < CeldiriciAdet; i++)
            {
                var degisecekParcalar = ParcaSecimHelper.KalaniSec(Havuz, SabitParcaAdet, ZorlukDerece);

                var sonuc1 = ResimHelper.ResimDegistirUret(Havuz, DogruCevap1, degisecekParcalar, ResimBoyut);
                var sonuc2 = ResimHelper.ResimDegistirUret(Havuz, DogruCevap1, degisecekParcalar, ResimBoyut);


                Soru.CeldiriciList.Add(RandomHelper.RandomBool()
                    ? ResimHelper.IkiliResimUret(sonuc1, sonuc2, ResimBoyut)
                    : ResimHelper.IkiliResimUret(sonuc2, sonuc1, ResimBoyut));
            }
        }
    }
}
