using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZoruSor.Lib.Havuz;

namespace ZoruSor.Lib.Soru
{
    public class Donusum2: SoruBuilder
    {
        private CiktiResim _referansResim;
        private List<Parca> _donusumParcaList;
        private List<string> _donusecekParcaAdList;
        public override void ReferansResimUret()
        {
            //Rastgele bır resim uret
            _referansResim = ResimHelper.RasgeleResimUret(Havuz, ResimBoyut);

            //Donusum listesini doldur.
            _donusumParcaList = ParcaSecimHelper.DonusumParcaList(Havuz, ZorlukDerece, out _donusecekParcaAdList);

            //Donusum resmi uret
            Soru.ReferansResimList.Add(
                ResimHelper.DonusumResmiUret(_referansResim, ZorlukDerece, _donusecekParcaAdList, _donusumParcaList, ResimBoyut));
        }

        public override void DogruCevapUret()
        {
            //Referans Resmi al ve birinci resim yap
            var resim1 = _referansResim;
            //Birinci resme donusum uygula ve resim2 olustur
            var resim2 = ResimHelper.DonusumListesiUygula(Havuz, _referansResim, Soru.ReferansResimList[0], ResimBoyut);
           
            //Dogru cevap uret
            Soru.DogruCevapList.Add(ResimHelper.IkiliResimUret(resim1, resim2, ResimBoyut));
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
                var resim = ResimHelper.RasgeleResimUret(Havuz, ResimBoyut);
                var resim1 = ResimHelper.DonusumListesiUygula(Havuz, resim, Soru.ReferansResimList[0], ZorlukDerece - 1,
                    ResimBoyut);
                var sonuc = ResimHelper.IkiliResimUret(resim, resim1, ResimBoyut);

                //celdiriciyi sorunun listesine ekle
                if ((Soru.CeldiriciList.Count>0 && Soru.CeldiriciList.Any(s => s.Equals(sonuc))) || Soru.DogruCevapList[0].Equals(sonuc))
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
