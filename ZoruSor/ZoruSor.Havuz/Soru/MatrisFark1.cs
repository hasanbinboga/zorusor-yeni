using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZoruSor.Lib.Soru
{
    /// <summary>
    /// Bu soru turunde Referans resim yoktur. Sadece seceneklerden olusur.
    /// Her bir secenekte bir referans resim ve bu resmin sekiz ayri parcasindan olusan 
    /// bir matris vardir. Dogru secenekte referans resimdeki parcalardan bir veya birden fazlasi
    /// (zorluk seviyesine gore) matrisin diger hucrelerdeki parca resimlerinden farklidir. 
    /// Celdiricilerde ise referans resim ile matrisin hucrelerindeki parca resimleri ile birebir aynidir.
    /// </summary>
    class MatrisFark1 : SoruBuilder
    {
        public override void ReferansResimUret()
        {
            //Bu soru turunde referans resim yok
        }

        public override void DogruCevapUret()
        {
            //Referans resim uret.
            var resim = ResimHelper.RasgeleResimUret(Havuz, ResimBoyut);

            //Zorluk derecesine gore degisecek parcalari sec. (Farklisini bul gibi)
            var degisecekParcalar = ParcaSecimHelper.KalaniSec(Havuz, SabitParcaAdet, ZorlukDerece);
            var farkliResim = ResimHelper.ResimDegistirUret(Havuz, resim, degisecekParcalar,
                ResimBoyut);

            //Matris Resim olustur
            Soru.DogruCevapList.Add(ResimHelper.MatrisOlustur(Havuz, resim, farkliResim.ParcaList, ResimBoyut));
        }

        public override void CeldiriciUret()
        {
            for (int i = 0; i < CeldiriciAdet; i++)
            {
                //Referans resim uret
                var resim = ResimHelper.RasgeleResimUret(Havuz, ResimBoyut);
                //Matris resim olustur.
                //Celdiricilerde daha once yoksa ekle.
                Soru.CeldiriciList.Add(ResimHelper.MatrisOlustur(Havuz, resim, resim.ParcaList, ResimBoyut));
            }

        }
    }
}
