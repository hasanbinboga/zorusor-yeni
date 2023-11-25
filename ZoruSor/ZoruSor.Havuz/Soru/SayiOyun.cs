using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using org.mariuszgromada.math.mxparser;

namespace ZoruSor.Lib.Soru
{
    public enum IslemGorunum
    {
        Bilinmiyor=0,
        ReferanstaGorunsun=1,
        CevaptaGorunsun=2,
        Gorunmesin=3
    }
    public class SayiOyun : SoruBuilder
    {
        public string Satir1Formul { get; set; }
        public string Satir2Formul { get; set; }
        public string Satir3Formul { get; set; }
        public string Satir4Formul { get; set; }
        public IslemGorunum IslemGorunsun { get; set; }

        private int x, y, z, p, r, m, n, dogruCevap;
        private string _cevapIslem;
        string IslemGetir(string formul)
        {
           return formul
                   .Replace("x", x.ToString())
                   .Replace("y", y.ToString())
                   .Replace("z", z.ToString())
                   .Replace("p", p.ToString())
                   .Replace("r", r.ToString())
                   .Replace("m", m.ToString())
                   .Replace("n", n.ToString())
                   .Replace("*", "x");
        }
        public override void ReferansResimUret()
        {
            //Degiskenlere zorluk derecesine gore deger ata.

            var degiskenList = new List<int>();
            for (int i = 0; i < 5; i++)
            {
                degiskenList.Add(RandomHelper.RandomDifferentNumber(1, 10 * ZorlukDerece, degiskenList.ToArray()));
            }
            degiskenList = degiskenList.OrderByDescending(s=>s).ToList();
            x = degiskenList[0];
            y = degiskenList[1];
            z = degiskenList[2];
            p = degiskenList[3];
            r = degiskenList[4];m = RandomHelper.RandomNumber(1, ZorlukDerece + 2);
            n = RandomHelper.RandomNumber(1, ZorlukDerece + 1);

            var argA = new Argument("x", x);
            var argB = new Argument("y", y);
            var argC = new Argument("z", z);
            var argD = new Argument("p", p);
            var argE = new Argument("r", r);
            var argM = new Argument("m", m);
            var argN = new Argument("n", n);

            var formulList = new List<Expression>
            {
                new Expression(Satir1Formul.ToLower()),
                new Expression(Satir2Formul.ToLower()),
                new Expression(Satir3Formul.ToLower()),
                new Expression(Satir4Formul.ToLower())
            };


            #region Arguman Ekle

            foreach (var formul in formulList)
            {
                if (formul.getExpressionString().Contains("x"))
                {
                    formul.addArguments(argA);
                }
                if (formul.getExpressionString().Contains("y"))
                {
                    formul.addArguments(argB);
                }
                if (formul.getExpressionString().Contains("z"))
                {
                    formul.addArguments(argC);
                }
                if (formul.getExpressionString().Contains("p"))
                {
                    formul.addArguments(argD);
                }
                if (formul.getExpressionString().Contains("r"))
                {
                    formul.addArguments(argE);
                }
                if (formul.getExpressionString().Contains("m"))
                {
                    formul.addArguments(argM);
                }
                if (formul.getExpressionString().Contains("n"))
                {
                    formul.addArguments(argN);
                }

            }

            #endregion

            var hata = "";
            var st = 1;
            foreach (var formul in formulList)
            {
                if (formul.checkSyntax() == false)
                {
                    hata += string.Format("{0}. Satir formulu hatali: {1}\n", st, formul.getErrorMessage());
                }
                st++;
            }
            if (string.IsNullOrEmpty(hata) == false)
            {
                throw new Exception(hata);
            }
            switch (IslemGorunsun)
            {
               
                case IslemGorunum.ReferanstaGorunsun:
                    var satir1Islem = IslemGetir(Satir1Formul);
                    var satir2Islem = IslemGetir(Satir2Formul);
                    var satir3Islem = IslemGetir(Satir3Formul);

                    Soru.ReferansStrList.Add(string.Format("{0,3} ★ {1,3} ➡ {2}\t(İşlem:  {3})", x, y, (int)formulList[0].calculate(), satir1Islem));
                    Soru.ReferansStrList.Add(string.Format("{0,3} ★ {1,3} ➡ {2}\t(İşlem:  {3})", y, z, (int)formulList[1].calculate(), satir2Islem));
                    Soru.ReferansStrList.Add(string.Format("{0,3} ★ {1,3} ➡ {2}\t(İşlem:  {3})", z, p, (int)formulList[2].calculate(), satir3Islem));
                    Soru.ReferansStrList.Add(string.Format("{0,3} ★ {1,3} ➡ {2}\t .........................................", p, r, "?"));
                    break;
                case IslemGorunum.CevaptaGorunsun:
                    _cevapIslem = IslemGetir(Satir4Formul);
                    Soru.ReferansStrList.Add(string.Format("{0,3} ★ {1,3} ➡ {2}", x, y, (int)formulList[0].calculate()));
                    Soru.ReferansStrList.Add(string.Format("{0,3} ★ {1,3} ➡ {2}", y, z, (int)formulList[1].calculate()));
                    Soru.ReferansStrList.Add(string.Format("{0,3} ★ {1,3} ➡ {2}", z, p, (int)formulList[2].calculate()));
                    Soru.ReferansStrList.Add(string.Format("{0,3} ★ {1,3} ➡ {2}", p, r, "?"));

                    break;
                case IslemGorunum.Gorunmesin:
                    Soru.ReferansStrList.Add(string.Format("{0,3} ★ {1,3} ➡ {2}", x, y, (int)formulList[0].calculate()));
                    Soru.ReferansStrList.Add(string.Format("{0,3} ★ {1,3} ➡ {2}", y, z, (int)formulList[1].calculate()));
                    Soru.ReferansStrList.Add(string.Format("{0,3} ★ {1,3} ➡ {2}", z, p, (int)formulList[2].calculate()));
                    Soru.ReferansStrList.Add(string.Format("{0,3} ★ {1,3} ➡ {2}", p, r, "?"));
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
           


            dogruCevap = (int)formulList[3].calculate();
        }

        public override void DogruCevapUret()
        {
            Soru.DogruCevapObjList.Add(new DogruCevap {Metin = dogruCevap.ToString(CultureInfo.InvariantCulture) , Aciklama = _cevapIslem});
        }

        public override void CeldiriciUret()
        {
            var celdiriciList = new List<int>();
            for (int i = 0; i < CeldiriciAdet; i++)
            {
                var min = dogruCevap - ZorlukDerece * 5;
                min = min < 0 ? 1 : min;
                var max = dogruCevap + ZorlukDerece * 5;

                if (celdiriciList.Count == 0)
                {
                    var celdirici = RandomHelper.RandomNumber(min, max);
                    if (celdirici != dogruCevap)
                    {
                        celdiriciList.Add(celdirici);
                    }
                    else
                    {
                        i--;
                    }
                }
                else
                {
                    var celdirici = RandomHelper.RandomDifferentNumber(min, max, celdiriciList.ToArray());
                    if (celdirici != dogruCevap)
                    {
                        celdiriciList.Add(celdirici);
                    }
                    else
                    {
                        i--;
                    }
                }
            }
            foreach (var celdirici in celdiriciList)
            {
                Soru.CeldiriciStrList.Add(celdirici.ToString());
            }
        }
    }
}
