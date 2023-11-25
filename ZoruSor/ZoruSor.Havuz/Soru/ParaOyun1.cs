using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using org.mariuszgromada.math.mxparser;

namespace ZoruSor.Lib.Soru
{
    public class ParaOyun : SoruBuilder
    {
        public string Satir1Formul { get; set; }
        public string Satir2Formul { get; set; }
        public string Satir3Formul { get; set; }
        public string Satir4Formul { get; set; }
        public bool IslemGorunsun { get; set; }

        private int x, y, z, p, r, m, n, dogruCevap;

        public override void ReferansResimUret()
        {
            //Degiskenlere zorluk derecesine gore deger ata.

            var degiskenList = new List<int>();
            for (int i = 0; i < 5; i++)
            {
                degiskenList.Add(RandomHelper.RandomDifferentNumber(1, 10 * ZorlukDerece, degiskenList.ToArray()));
            }
            degiskenList = degiskenList.OrderByDescending(s => s).ToList();
            x = degiskenList[0];
            y = degiskenList[1];
            z = degiskenList[2];
            p = degiskenList[3];
            r = degiskenList[4]; m = RandomHelper.RandomNumber(1, ZorlukDerece + 2);
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
            if (IslemGorunsun)
            {
                var satir1Islem = Satir1Formul
                    .Replace("x", x.ToString())
                    .Replace("y", y.ToString())
                    .Replace("m", m.ToString())
                    .Replace("n", n.ToString())
                    .Replace("*", "x");
                var satir2Islem = Satir2Formul
                    .Replace("y", y.ToString())
                    .Replace("z", z.ToString())
                    .Replace("m", m.ToString())
                    .Replace("n", n.ToString())
                    .Replace("*", "x");
                var satir3Islem = Satir3Formul
                    .Replace("z", z.ToString())
                    .Replace("p", p.ToString())
                    .Replace("m", m.ToString())
                    .Replace("n", n.ToString())
                    .Replace("*", "x");
                var paraX = ResimHelper.ParaResimUret(x, ResimBoyut);
                var paraY = ResimHelper.ParaResimUret(y, ResimBoyut);
                var paraZ = ResimHelper.ParaResimUret(z, ResimBoyut);
                var paraP = ResimHelper.ParaResimUret(p, ResimBoyut);
                var paraR = ResimHelper.ParaResimUret(r, ResimBoyut);
                var sonuc1 = ResimHelper.ParaResimUret((int)formulList[0].calculate(), ResimBoyut);
                var sonuc2 = ResimHelper.ParaResimUret((int)formulList[1].calculate(), ResimBoyut);
                var sonuc3 = ResimHelper.ParaResimUret((int)formulList[2].calculate(), ResimBoyut);

                var satir1 = ResimHelper.IslemResimUret(paraX, paraY, sonuc1, ResimBoyut);
                var satir2 = ResimHelper.IslemResimUret(paraY, paraZ, sonuc2, ResimBoyut);
                var satir3 = ResimHelper.IslemResimUret(paraZ, paraP, sonuc3, ResimBoyut);
                var satir4 = ResimHelper.IslemSoruResimUret(paraP, paraR, ResimBoyut);
                Soru.ReferansResimList.Add(satir1);
                Soru.ReferansResimList.Add(satir2);
                Soru.ReferansResimList.Add(satir3);
                Soru.ReferansResimList.Add(satir4);


            }
            else
            {
                var paraX = ResimHelper.ParaResimUret(x, ResimBoyut);
                var paraY = ResimHelper.ParaResimUret(y, ResimBoyut);
                var paraZ = ResimHelper.ParaResimUret(z, ResimBoyut);
                var paraP = ResimHelper.ParaResimUret(p, ResimBoyut);
                var paraR = ResimHelper.ParaResimUret(r, ResimBoyut);
                var sonuc1 = ResimHelper.ParaResimUret((int)formulList[0].calculate(), ResimBoyut);
                var sonuc2 = ResimHelper.ParaResimUret((int)formulList[1].calculate(), ResimBoyut);
                var sonuc3 = ResimHelper.ParaResimUret((int)formulList[2].calculate(), ResimBoyut);

                var satir1 = ResimHelper.IslemResimUret(paraX, paraY, sonuc1, ResimBoyut);
                var satir2 = ResimHelper.IslemResimUret(paraY, paraZ, sonuc2, ResimBoyut);
                var satir3 = ResimHelper.IslemResimUret(paraZ, paraP, sonuc3, ResimBoyut);
                var satir4 = ResimHelper.IslemSoruResimUret(paraP, paraR, ResimBoyut);
                Soru.ReferansResimList.Add(satir1);
                Soru.ReferansResimList.Add(satir2);
                Soru.ReferansResimList.Add(satir3);
                Soru.ReferansResimList.Add(satir4);
            }


            dogruCevap = (int)formulList[3].calculate();
        }

        public override void DogruCevapUret()
        {
            var dogruCevapResim = ResimHelper.ParaResimUret(dogruCevap, ResimBoyut);
            Soru.DogruCevapList.Add(dogruCevapResim);
        }

        public override void CeldiriciUret()
        {
            var celdiriciList = new List<int>();
            for (int i = 0; i < CeldiriciAdet; i++)
            {
                var min = dogruCevap - ZorlukDerece * 5;
                min = min < 0 ? 1 : min;
                var max = dogruCevap + ZorlukDerece * 5;
                max = max <= CeldiriciAdet + 5 ? CeldiriciAdet + 10 : max;


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
                Soru.CeldiriciList.Add(ResimHelper.ParaResimUret(celdirici, ResimBoyut));
            }
        }
    }
}
