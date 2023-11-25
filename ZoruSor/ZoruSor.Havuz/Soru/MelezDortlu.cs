using System;
using System.Collections.Generic;
using System.Linq;
using org.mariuszgromada.math.mxparser;

namespace ZoruSor.Lib.Soru
{
    public class MelezDortlu : SoruBuilder
    {
        private Dictionary<string, int> _resim1ParcaList;
        private Dictionary<string, int> _resim2ParcaList;
        private Dictionary<string, int> _resim3ParcaList;
        private Dictionary<string, int> _resim4ParcaList;

        public string Resim1Formul { get; set; }
        public string Resim2Formul { get; set; }
        public string Resim3Formul { get; set; }
        public string Resim4Formul { get; set; }
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
            //Rastgele uc resim uret.
            var resim1 = ResimHelper.RasgeleResimUret(Havuz, ResimBoyut);
            var resim2 = ResimHelper.RasgeleResimUret(Havuz, ResimBoyut);
            var resim3 = ResimHelper.RasgeleResimUret(Havuz, ResimBoyut);
            var resim4 = ResimHelper.RasgeleResimUret(Havuz, ResimBoyut);

            #region Resimlerdeki ortak parcalari degistir
            var ortakParcaList = new Dictionary<string, int>();

            foreach (var parca in resim1.ParcaList)
            {
                if (resim2.ParcaList[parca.Key] == parca.Value)
                {
                    ortakParcaList.Add(parca.Key, parca.Value);
                }
            }
            resim2 = KotuParcaDegistir1(resim2, ortakParcaList);

            ortakParcaList = new Dictionary<string, int>();

            foreach (var parca in resim1.ParcaList)
            {
                if (resim3.ParcaList[parca.Key] == parca.Value)
                {
                    ortakParcaList.Add(parca.Key, parca.Value);
                }
            }
            resim3 = KotuParcaDegistir1(resim3, ortakParcaList);

            ortakParcaList = new Dictionary<string, int>();

            foreach (var parca in resim1.ParcaList)
            {
                if (resim4.ParcaList[parca.Key] == parca.Value)
                {
                    ortakParcaList.Add(parca.Key, parca.Value);
                }
            }
            resim4 = KotuParcaDegistir1(resim4, ortakParcaList);

            ortakParcaList = new Dictionary<string, int>();

            foreach (var parca in resim2.ParcaList)
            {
                if (resim3.ParcaList[parca.Key] == parca.Value)
                {
                    ortakParcaList.Add(parca.Key, parca.Value);
                }
            }
            resim3 = KotuParcaDegistir1(resim3, ortakParcaList);

            ortakParcaList = new Dictionary<string, int>();

            foreach (var parca in resim2.ParcaList)
            {
                if (resim4.ParcaList[parca.Key] == parca.Value)
                {
                    ortakParcaList.Add(parca.Key, parca.Value);
                }
            }
            resim4 = KotuParcaDegistir1(resim4, ortakParcaList);

            ortakParcaList = new Dictionary<string, int>();

            foreach (var parca in resim3.ParcaList)
            {
                if (resim4.ParcaList[parca.Key] == parca.Value)
                {
                    ortakParcaList.Add(parca.Key, parca.Value);
                }
            }
            resim4 = KotuParcaDegistir1(resim4, ortakParcaList);
            #endregion

            //Zorluk seviyesine gore toplam parca sayisini sec.
            int toplamParca;

            //Havuzdaki parca sayisinin 4 te 1 i zorluk derecesinden dusukse
            if (ZorlukDerece < Havuz.ParcaList.Count / 4)
            {
                switch (ZorlukDerece)
                {
                    case 1:
                        toplamParca = 4;
                        break;
                    case 2:
                        toplamParca = 5;
                        break;
                    default:
                        toplamParca = (ZorlukDerece - 1) * 4;
                        break;
                }
            }
            else
            {
                toplamParca = Havuz.ParcaList.Count;
            }
            //toplam parca havuzdaki parca sayisindan buyukse toplam parcayi parca sayisina esitle
            toplamParca = toplamParca > Havuz.ParcaList.Count ? Havuz.ParcaList.Count : toplamParca;

            _resim1ParcaList = new Dictionary<string, int>(toplamParca);
            _resim2ParcaList = new Dictionary<string, int>(toplamParca);
            _resim3ParcaList = new Dictionary<string, int>(toplamParca);
            _resim4ParcaList = new Dictionary<string, int>(toplamParca);

            int a, b, c, d;

            //eger toplam parca 3 ise her resimden bir parca al
            if (toplamParca == 4)
            {
                var parcaList = new List<string>();
                var parca = ParcaSecimHelper.KadariniSec(Havuz, 1);
                parcaList.AddRange(parca);
                var deger = resim1.ParcaList[parca[0]];
                _resim1ParcaList.Add(parca[0], deger);

                parca = ParcaSecimHelper.KadariniSec(Havuz, 1, parcaList);
                parcaList.AddRange(parca);
                deger = resim2.ParcaList[parca[0]];
                _resim2ParcaList.Add(parca[0], deger);

                parca = ParcaSecimHelper.KadariniSec(Havuz, 1, parcaList);
                deger = resim3.ParcaList[parca[0]];
                _resim3ParcaList.Add(parca[0], deger);

                parca = ParcaSecimHelper.KadariniSec(Havuz, 1, parcaList);
                deger = resim4.ParcaList[parca[0]];
                _resim4ParcaList.Add(parca[0], deger);

                a = 1;
                b = 1;
                c = 1;
                d = 1;
            }
            else
            {
                //resim1 icin rasgele parca sayisi sec
                a = RandomHelper.RandomNumber(1, toplamParca - 3);

                //resim2 icin kalan parcalardan rasgele parca sayisi sec
                b = RandomHelper.RandomNumber(1, toplamParca - (a + 2));

                // resim3 icin kalan parcalardan rasgele parca sayisi sec
                c = RandomHelper.RandomNumber(1, toplamParca - (a + b + 1));

                //kalan parca sayisi resim3 icin ata
                d = toplamParca - (a + b + c);

                var totalParcaList = new List<string>();

                //resim1 icin degisecek parcalari sec
                var parcaList = ParcaSecimHelper.KadariniSec(Havuz, a);

                totalParcaList.AddRange(parcaList);
                foreach (var parca in parcaList)
                {
                    var deger = resim1.ParcaList[parca];
                    _resim1ParcaList.Add(parca, deger);
                }

                //resim2 icin degisecek parcalari sec
                parcaList = ParcaSecimHelper.KadariniSec(Havuz, b, totalParcaList);

                totalParcaList.AddRange(parcaList);
                foreach (var parca in parcaList)
                {
                    var deger = resim2.ParcaList[parca];
                    _resim2ParcaList.Add(parca, deger);
                }

                //resim3 icin degisecek parcalari sec
                parcaList = ParcaSecimHelper.KadariniSec(Havuz, c, totalParcaList);
                foreach (var parca in parcaList)
                {
                    var deger = resim3.ParcaList[parca];
                    _resim3ParcaList.Add(parca, deger);
                }

                //resim4 icin degisecek parcalari sec
                parcaList = ParcaSecimHelper.KadariniSec(Havuz, d, totalParcaList);
                foreach (var parca in parcaList)
                {
                    var deger = resim4.ParcaList[parca];
                    _resim4ParcaList.Add(parca, deger);
                }
            }
            var argA = new Argument("a", a);
            var argB = new Argument("b", b);
            var argC = new Argument("c", c);
            var argD = new Argument("d", d);

            var resim1Exp = new Expression(Resim1Formul.ToLower());
            var resim2Exp = new Expression(Resim2Formul.ToLower());
            var resim3Exp = new Expression(Resim3Formul.ToLower());
            var resim4Exp = new Expression(Resim4Formul.ToLower());

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
            if (Resim1Formul.ToLower().Contains("c"))
            {
                resim1Exp.addArguments(argC);
            }
            if (Resim1Formul.ToLower().Contains("d"))
            {
                resim1Exp.addArguments(argD);
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
            if (Resim2Formul.ToLower().Contains("c"))
            {        
                resim2Exp.addArguments(argC);
            }
            if (Resim2Formul.ToLower().Contains("D"))
            {
                resim2Exp.addArguments(argD);
            }

            //resim3
            if (Resim3Formul.ToLower().Contains("a"))
            {        
                resim3Exp.addArguments(argA);
            }        
            if (Resim3Formul.ToLower().Contains("b"))
            {        
                resim3Exp.addArguments(argB);
            }
            if (Resim3Formul.ToLower().Contains("c"))
            {
                resim3Exp.addArguments(argC);
            }
            if (Resim3Formul.ToLower().Contains("d"))
            {
                resim3Exp.addArguments(argD);
            }

            //resim4
            if (Resim4Formul.ToLower().Contains("a"))
            {
                resim4Exp.addArguments(argA);
            }
            if (Resim4Formul.ToLower().Contains("b"))
            {
                resim4Exp.addArguments(argB);
            }
            if (Resim4Formul.ToLower().Contains("c"))
            {
                resim4Exp.addArguments(argC);
            }
            if (Resim4Formul.ToLower().Contains("d"))
            {
                resim4Exp.addArguments(argD);
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
                if (resim3Exp.checkSyntax() == false)
                {
                    throw new Exception("Resim 3 Formulu yanlis");
                }
                if (resim4Exp.checkSyntax() == false)
                {
                    throw new Exception("Resim 4 Formulu yanlis");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            var frm1 = Resim1Formul + "=" + resim1Exp.calculate();
            var frm2 = Resim2Formul + "=" + resim2Exp.calculate();
            var frm3 = Resim3Formul + "=" + resim3Exp.calculate();
            var frm4 = Resim4Formul + "=" + resim4Exp.calculate();
            var maxLen = new List<int> { frm1.Length , frm2.Length , frm3.Length, frm4.Length}.Max();
            maxLen = maxLen < 7 ? 7 : maxLen;
            Soru.ReferansResimList.Add(ResimHelper.MelezResimUret(resim1, frm1, ResimBoyut, maxLen));
            Soru.ReferansResimList.Add(ResimHelper.MelezResimUret(resim2, frm2, ResimBoyut, maxLen));
            Soru.ReferansResimList.Add(ResimHelper.MelezResimUret(resim3, frm3, ResimBoyut, maxLen));
            Soru.ReferansResimList.Add(ResimHelper.MelezResimUret(resim4, frm4, ResimBoyut, maxLen));
        }

        public override void DogruCevapUret()
        {
            //Degisimleri uygula
            var sonuc = ResimHelper.RasgeleResimUret(Havuz, ResimBoyut);
            sonuc = KotuParcaDegistir1(sonuc, Soru.ReferansResimList[0].ParcaList);
            sonuc = KotuParcaDegistir1(sonuc, Soru.ReferansResimList[1].ParcaList);
            sonuc = KotuParcaDegistir1(sonuc, Soru.ReferansResimList[2].ParcaList);
            sonuc = KotuParcaDegistir1(sonuc, Soru.ReferansResimList[3].ParcaList);

            sonuc = ResimHelper.ParcaDegistir(Havuz, sonuc, _resim1ParcaList, ResimBoyut);
            sonuc = ResimHelper.ParcaDegistir(Havuz, sonuc, _resim2ParcaList, ResimBoyut);
            sonuc = ResimHelper.ParcaDegistir(Havuz, sonuc, _resim3ParcaList, ResimBoyut);
            sonuc = ResimHelper.ParcaDegistir(Havuz, sonuc, _resim4ParcaList, ResimBoyut);

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
                for (int j = 0; j < 4; j++)
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
                //sonuc = KotuParcaDegistir1(sonuc, _resim1ParcaList);
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
