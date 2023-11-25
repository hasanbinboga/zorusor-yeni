using System;
using System.Collections.Generic;
using System.Linq;

namespace ZoruSor.Lib.Soru
{
    public class FarkliEleman : SoruBuilder
    {
        private int _dogruCevapDegisimAdet;

        public override void ReferansResimUret()
        {
            Soru.ReferansResimList.Add(ResimHelper.RasgeleResimUret(Havuz, ResimBoyut));
        }

        public override void DogruCevapUret()
        {
            //Zorluk derecesinden Havuzdaki toplam parca adedine kadar rastgele bir sayi sec.
            _dogruCevapDegisimAdet = RandomHelper.RandomNumber(ZorlukDerece, Havuz.ParcaList.Count);

            //Secilen sayi kadar parca sec.
            var parcaList = ParcaSecimHelper.KadariniSec(Havuz, _dogruCevapDegisimAdet);
            
            //Bu parcalari referans resimde degistir.
            var sonuc = ResimHelper.ResimDegistirUret(Havuz, Soru.ReferansResimList[0], parcaList, ResimBoyut);

            //Dogru cevabi kaydet.
            Soru.DogruCevapList.Add(sonuc);
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
                var degisecekParcaList = new List<string>();
                //Eger dogru cevaptaki degisim adedinin bir fazlasi parca listesi ile esit ise 
                //celdiricinin bir parcasi haric hepsini degistir.
                if (_dogruCevapDegisimAdet + 1 == Havuz.ParcaList.Count)
                {
                    degisecekParcaList = Havuz.ParcaList.OrderBy(s => s.Derece).Skip(1).Select(s => s.Ad).ToList();
                }
                else
                {
                    //Sifirdan Dogru cevaptaki degisim adedinin bir eksigine kadar rastgele bir parcaAdedi sec
                    var parcaAdet = RandomHelper.RandomNumber(0, _dogruCevapDegisimAdet - 1);

                    var sabitParcaAdet = 0;
                    if (Havuz.ParcaList.Count - SabitParcaAdet < parcaAdet)
                    {
                        sabitParcaAdet = Havuz.ParcaList.Count - parcaAdet;
                    }

                    //Belirlenen parca adedi kadar parcayi sec.
                    degisecekParcaList = ParcaSecimHelper.KadariniSec(Havuz, sabitParcaAdet, parcaAdet);
                }


                //Referans resimde parcalari degistir.
                var sonuc = ResimHelper.ResimDegistirUret(Havuz, Soru.ReferansResimList[0], degisecekParcaList, ResimBoyut);


                //celdiriciyi sorunun listesine ekle
                if ((degisecekParcaList.Count>0 && Soru.CeldiriciList.Any(s => s.Equals(sonuc))) || Soru.DogruCevapList[0].Equals(sonuc))
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
