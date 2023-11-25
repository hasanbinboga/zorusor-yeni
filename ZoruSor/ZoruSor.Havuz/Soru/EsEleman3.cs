using System;

namespace ZoruSor.Lib.Soru
{
    public class EsEleman3 : SoruBuilder
    {
        private CiktiResim _referansResim;
        public override void ReferansResimUret()
        {
            //Bu soruda referans resim yoktur.
        }

        public override void DogruCevapUret()
        {
            _referansResim = ResimHelper.RasgeleResimUret(Havuz, ResimBoyut);
            var parcalanmisResim = ResimHelper.ParcaResimUret(Havuz, _referansResim.ParcaList, Convert.ToInt32(ResimBoyut * 0.4f));
            if (RandomHelper.RandomBool())
            {
                Soru.DogruCevapList.Add(ResimHelper.IkiResimBirlestir(parcalanmisResim, _referansResim, ResimBoyut));

            }
            else
            {
                Soru.DogruCevapList.Add(ResimHelper.IkiResimBirlestir(_referansResim, parcalanmisResim, ResimBoyut));

            }
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


                CiktiResim butunSonuc;
                CiktiResim parcaSonuc;

                do
                {
                    var butunDegisecekParcalar = ParcaSecimHelper.KalaniSec(Havuz, SabitParcaAdet, ZorlukDerece);
                    var parcaDegisecekParcalar = ParcaSecimHelper.KalaniSec(Havuz, SabitParcaAdet, ZorlukDerece);
                    butunSonuc = ResimHelper.ResimDegistirUret(Havuz, _referansResim, butunDegisecekParcalar, ResimBoyut);
                    parcaSonuc = ResimHelper.ResimDegistirUret(Havuz, _referansResim, parcaDegisecekParcalar, ResimBoyut);
                } while (butunSonuc.Equals(parcaSonuc));
                var parcalanmis = ResimHelper.ParcaResimUret(Havuz, parcaSonuc.ParcaList, Convert.ToInt32(ResimBoyut * 0.4f));

                if (RandomHelper.RandomBool())
                {
                Soru.CeldiriciList.Add(ResimHelper.IkiResimBirlestir(parcalanmis, butunSonuc, ResimBoyut));

                }
                else
                {
                Soru.CeldiriciList.Add(ResimHelper.IkiResimBirlestir(butunSonuc, parcalanmis, ResimBoyut));

                }

            }
        }
    }
}
