using System;
using System.Collections.Generic;
using System.Linq;
using org.mariuszgromada.math.mxparser;

namespace ZoruSor.Lib.Soru
{
    public class MelezIkili : SoruBuilder
    {
        public string Resim1Formul { get; set; }
        public string Resim2Formul { get; set; }

        private Dictionary<string, int> _resim1ParcaList;
        private Dictionary<string, int> _resim2ParcaList;

        private CiktiResim KotuParcaDegistir1(CiktiResim resim, Dictionary<string, int> ortakParca)
        {
            var kotuParcaList = new Dictionary<string, int>();
            foreach (var parca in resim.ParcaList)
            {
                if (ortakParca.ContainsKey(parca.Key) && ortakParca[parca.Key] == parca.Value)
                {
                    kotuParcaList.Add(parca.Key, parca.Value);
                }
            }
            //ortak parca 1 ve kotu parca yoksa resmi geri gonder/
            if (ortakParca.Count == 1 && kotuParcaList.Count == 0)
            {
                return resim;
            }
            //Ortak Parca listesinde 1 resim varsa ve kotuparcaList sayisi da 1 ise
            if (ortakParca.Count == 1 && kotuParcaList.Count == 1)
            {
                var parcaAd = kotuParcaList.Keys.First();
                kotuParcaList[parcaAd] = RandomHelper.RandomDifferentNumber(0,
                    Havuz.ParcaList.First(s => s.Ad == parcaAd).Adet - 1,
                    new[] { kotuParcaList[parcaAd] });
                resim = ResimHelper.ParcaDegistir(Havuz, resim,
                    kotuParcaList, ResimBoyut);
                return resim;
            }

            //yeni uretilen resimlerdeki otak parcalardan %50 si ayni ise 
            if (kotuParcaList.Count > 0)
            {
                //Ortak parcalarin yarisini sec 
                var kotuParcalar = kotuParcaList.ToDictionary(k => k.Key, v => v.Value);

                //bu parcalar icin rasgele id uret.
                foreach (var parca in Havuz.ParcaList)
                {
                    if (kotuParcalar.ContainsKey(parca.Ad))
                    {
                        kotuParcalar[parca.Ad] = RandomHelper.RandomDifferentNumber(0, parca.Adet - 1,
                            new[] { kotuParcaList[parca.Ad] });
                    }
                }

                //resimi degistir.  
                resim = ResimHelper.ParcaDegistir(Havuz, resim,
                    kotuParcalar, ResimBoyut);
            }
            return resim;
        }

        public override void ReferansResimUret()
        {
            //Rastgele iki resim uret.
            var resim1 = ResimHelper.RasgeleResimUret(Havuz, ResimBoyut);
            var resim2 = ResimHelper.RasgeleResimUret(Havuz, ResimBoyut);
            var ortakParcaList = new Dictionary<string, int>();
            foreach (var parca in resim1.ParcaList)
            {
                if (resim2.ParcaList[parca.Key] == parca.Value)
                {
                    ortakParcaList.Add(parca.Key, parca.Value);
                }
            }
            resim2 = KotuParcaDegistir1(resim2, ortakParcaList);
            //Zorluk seviyesine gore toplam parca sayisini sec.
            int toplamParca;
            if (ZorlukDerece < Havuz.ParcaList.Count / 2)
            {
                switch (ZorlukDerece)
                {
                    case 1:
                        toplamParca = 2;
                        break;
                    case 2:
                        toplamParca = 3;
                        break;
                    default:
                        toplamParca = (ZorlukDerece - 1) * 2;
                        break;
                }
            }
            else
            {
                toplamParca = Havuz.ParcaList.Count;
            }
            toplamParca = toplamParca > Havuz.ParcaList.Count ? Havuz.ParcaList.Count : toplamParca;

            _resim1ParcaList = new Dictionary<string, int>(toplamParca);
            _resim2ParcaList = new Dictionary<string, int>(toplamParca);
            int a, b;
            //eger toplam parca 2 ise 
            if (toplamParca == 2)
            {
                var parca = ParcaSecimHelper.KadariniSec(Havuz, 1);
                var deger = resim1.ParcaList[parca[0]];
                _resim1ParcaList.Add(parca[0], deger);
                a = 1;

                parca = ParcaSecimHelper.KadariniSec(Havuz, 1, parca);
                deger = resim2.ParcaList[parca[0]];
                _resim2ParcaList.Add(parca[0], deger);
                b = 1;
            }
            else
            {
                a = RandomHelper.RandomNumber(1, toplamParca - 1);
                b = toplamParca - a;
                var parcaList = ParcaSecimHelper.KadariniSec(Havuz, a);
                foreach (var parca in parcaList)
                {
                    var deger = resim1.ParcaList[parca];
                    _resim1ParcaList.Add(parca, deger);
                }
                parcaList = ParcaSecimHelper.KadariniSec(Havuz, b, parcaList);
                foreach (var parca in parcaList)
                {
                    var deger = resim2.ParcaList[parca];
                    _resim2ParcaList.Add(parca, deger);
                }
            }

            var argA = new Argument("a", a);
            var argB = new Argument("b", b);
            var resim1Exp = new Expression(Resim1Formul.ToLower());
            var resim2Exp = new Expression(Resim2Formul.ToLower());

            #region Arguman Ekle
            //resim 1
            if (Resim1Formul.ToLower().Contains("a"))
            {
                resim1Exp.addArguments(argA);
            }
            if (Resim1Formul.ToLower().Contains("b"))
            {
                resim1Exp.addArguments(argB);
            }
            //resim2
            if (Resim2Formul.ToLower().Contains("a"))
            {
                resim2Exp.addArguments(argA);
            }
            if (Resim2Formul.ToLower().Contains("b"))
            {
                resim2Exp.addArguments(argB);
            }
            #endregion
            try
            {
                if (resim1Exp.checkSyntax() == false)
                {
                    throw new Exception("Resim 1 Formulu yanlis");
                }
                if (resim2Exp.checkSyntax() == false)
                {
                    throw new Exception("Resim 2 Formulu yanlis");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            var frm1 = Resim1Formul + "=" + resim1Exp.calculate();
            var frm2 = Resim2Formul + "=" + resim2Exp.calculate();
            var maxLen = frm1.Length > frm2.Length ? frm1.Length : frm2.Length;
            maxLen = maxLen < 7 ? 7 : maxLen;

            Soru.ReferansResimList.Add(ResimHelper.MelezResimUret(resim1, frm1 , ResimBoyut, maxLen));
            Soru.ReferansResimList.Add(ResimHelper.MelezResimUret(resim2, frm2 , ResimBoyut, maxLen));
        }

        public override void DogruCevapUret()
        {
            //Degisimleri uygula
            var sonuc = ResimHelper.RasgeleResimUret(Havuz, ResimBoyut);
            sonuc = KotuParcaDegistir1(sonuc, Soru.ReferansResimList[0].ParcaList);
            sonuc = KotuParcaDegistir1(sonuc, Soru.ReferansResimList[1].ParcaList);
            sonuc = ResimHelper.ParcaDegistir(Havuz, sonuc, _resim1ParcaList, ResimBoyut);
            sonuc = ResimHelper.ParcaDegistir(Havuz, sonuc, _resim2ParcaList, ResimBoyut);

            //Dogru cevabi ekle
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
                var degisecekParcalar = ParcaSecimHelper.KalaniSec(Havuz, SabitParcaAdet, ZorlukDerece);

                var sonuc = ResimHelper.ResimDegistirUret(Havuz, Soru.DogruCevapList[0], degisecekParcalar, ResimBoyut);

                //Degisecek parcalarin referans resimlerdeki degerlerini al ve kotu parcalari degistir.
                for (int j = 0; j < 2; j++)
                {
                    var parcaDeger = new Dictionary<string, int>();
                    foreach (var parca in Soru.ReferansResimList[j].ParcaList)
                    {
                        if (degisecekParcalar.Contains(parca.Key))
                        {
                            parcaDeger.Add(parca.Key, parca.Value);
                        }
                    }
                    sonuc = KotuParcaDegistir1(sonuc, parcaDeger);
                }
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
