using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using org.mariuszgromada.math.mxparser;

namespace ZoruSor.Lib.Soru
{
    public class ParaOyun5 : SoruBuilder
    {
        internal class Parametre
        {
            public int X { get; set; }
            public int Y { get; set; }
            public int Z { get; set; }
            public int P { get; set; }
            public int R { get; set; }
            public int M { get; set; }
            public int N { get; set; }
        }

        public string Satir1Formul { get; set; }
        public string Satir2Formul { get; set; }
        public string Satir3Formul { get; set; }
        public string Satir4Formul { get; set; }

        private int _x, _y, _z, _p, _r, _m, _n, _dogruCevap;

        private CiktiResim IslemResimUret(int x, int y, int z, int p, int r, int m, int n)
        {
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


            var satirList = new List<string>
            {
                string.Format("{0,3} ★ {1,3} ➡ {2}", x, y, (int) formulList[0].calculate()),
                string.Format("{0,3} ★ {1,3} ➡ {2}", y, z, (int) formulList[1].calculate()),
                string.Format("{0,3} ★ {1,3} ➡ {2}", z, p, (int) formulList[2].calculate()),
                string.Format("{0,3} ★ {1,3} ➡ {2}", p, r, (int) formulList[3].calculate())
            };


            return ResimHelper.IslemResimUret(satirList, ResimBoyut, ResimBoyut);
        }

        private int Rastgele(int x)
        {
            if (x < 15)
            {
                return RandomHelper.RandomDifferentNumber(1, x + 5, x);
            }
            else
            {
                return RandomHelper.RandomDifferentNumber(x - 10, x + 10, x);
            }
        }
        public override void ReferansResimUret()
        {
            //Degiskenlere zorluk derecesine gore deger ata.

            var degiskenList = new List<int>();
            for (int i = 0; i < 5; i++)
            {
                degiskenList.Add(RandomHelper.RandomDifferentNumber(1, 10 * ZorlukDerece, degiskenList.ToArray()));
            }
            degiskenList = degiskenList.OrderByDescending(s => s).ToList();
            _x = degiskenList[0];
            _y = degiskenList[1];
            _z = degiskenList[2];
            _p = degiskenList[3];
            _r = degiskenList[4]; _m = RandomHelper.RandomNumber(1, ZorlukDerece + 2);
            _n = RandomHelper.RandomNumber(1, ZorlukDerece + 1);

            var argA = new Argument("x", _x);
            var argB = new Argument("y", _y);
            var argC = new Argument("z", _z);
            var argD = new Argument("p", _p);
            var argE = new Argument("r", _r);
            var argM = new Argument("m", _m);
            var argN = new Argument("n", _n);

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

            var paraX = ResimHelper.ParaResimUret(_x, ResimBoyut);
            var paraY = ResimHelper.ParaResimUret(_y, ResimBoyut);
            var paraZ = ResimHelper.ParaResimUret(_z, ResimBoyut);
            var paraP = ResimHelper.ParaResimUret(_p, ResimBoyut);
            var paraR = ResimHelper.ParaResimUret(_r, ResimBoyut);
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

            _dogruCevap = (int)formulList[3].calculate();
        }

        public override void DogruCevapUret()
        {

            var dogruCevapResim = IslemResimUret(_x, _y, _z, _p, _r, _m, _n);
            Soru.DogruCevapList.Add(dogruCevapResim);
        }

        public override void CeldiriciUret()
        {
            var parametreList = new List<Parametre>();
            for (int i = 0; i < CeldiriciAdet; i++)
            {


                if (parametreList.Count == 0)
                {
                    var celdirici = new Parametre
                    {
                        X = Rastgele(_x),
                        Y = Rastgele(_y),
                        Z = Rastgele(_z),
                        P = Rastgele(_p),
                        R = Rastgele(_r),
                        M = Rastgele(_m),
                        N = Rastgele(_n)
                    };

                    parametreList.Add(celdirici);
                }
                else
                {
                    var celdirici = new Parametre
                    {
                        X = Rastgele(_x),
                        Y = Rastgele(_y),
                        Z = Rastgele(_z),
                        P = Rastgele(_p),
                        R = Rastgele(_r),
                        M = Rastgele(_m),
                        N = Rastgele(_n)
                    };


                    if (!parametreList.Any(s => s.Equals(celdirici)))
                    {
                        parametreList.Add(celdirici);
                    }
                    else
                    {
                        i--;
                    }
                }
            }
            foreach (var p in parametreList)
            {
                Soru.CeldiriciList.Add(IslemResimUret(p.X, p.Y, p.Z, p.P, p.R, p.M, p.N));
            }
        }
    }
}
