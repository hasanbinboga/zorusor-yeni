using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZoruSor.Lib.Soru
{
    public class DonusumYeni: SoruBuilder
    {
        public override void ReferansResimUret()
        {
            //Rastgele bır resim uret
            Soru.ReferansResimList.Add(ResimHelper.RasgeleResimUret(Havuz, ResimBoyut));

            //Donusum listesini doldur.
            List<string> donusecekParcalar;
            var donusumParcalari = ParcaSecimHelper.DonusumParcaList(Havuz, ZorlukDerece, out donusecekParcalar);

            //Donusum resmi uret
            Soru.ReferansResimList.Add(
                ResimHelper.DonusumResmiUret(Soru.ReferansResimList[0], ZorlukDerece, donusecekParcalar, donusumParcalari, ResimBoyut));
        }

        public override void DogruCevapUret()
        {
            Soru.DogruCevapList.Add(ResimHelper.DonusumListesiUygula(Havuz, Soru.ReferansResimList[0], Soru.ReferansResimList[1], ResimBoyut));
        }

        public override void CeldiriciUret()
        {
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
                var sonuc =ResimHelper.DonusumListesiUygula(Havuz, Soru.ReferansResimList[0], Soru.ReferansResimList[1], ZorlukDerece-1, ResimBoyut);
                //celdiriciyi sorunun listesine ekle
                if (Soru.DogruCevapList[0].Equals(sonuc))
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
