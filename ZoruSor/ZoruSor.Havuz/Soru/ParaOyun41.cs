using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using org.mariuszgromada.math.mxparser;

namespace ZoruSor.Lib.Soru
{
    public class ParaOyun41 : SoruBuilder
    {

        private int dogruCevap;

        private string IslemGetir(string fonksiyon)
        {
            if (fonksiyon.Contains("+"))
            {
                return "+";
            }
            if (fonksiyon.Contains("-"))
            {
                return "-";
            }
            if (fonksiyon.Contains("*"))
            {
                return "x";
            }
            return "";
        }
        public override void ReferansResimUret()
        {
            //Degiskenlere zorluk derecesine gore deger ata.

            var degiskenList = new List<int>();
            for (int i = 0; i < 10; i++)
            {
                degiskenList.Add(RandomHelper.RandomDifferentNumber(1, 10 * ZorlukDerece, degiskenList.ToArray()));
            }

            //degiskenList = degiskenList.OrderByDescending(s => s).ToList();
            for (int i = 0; i < 3; i++)
            {
                var x = 0; var y = 0;
                if (degiskenList[i] < degiskenList[i + 1])
                {
                    x = degiskenList[i + 1];
                    y = degiskenList[i];
                }
                else
                {
                    x = degiskenList[i];
                    y = degiskenList[i + 1];
                }
                var paraX = ResimHelper.ParaResimUret(x, ResimBoyut);
                var paraY = ResimHelper.ParaResimUret(y, ResimBoyut);
                var sonuc1 = ResimHelper.ParaResimUret(x * y, ResimBoyut);
                bool gorunsun = i == 0;
                var mat1 = ResimHelper.CarpmaResimUret(x, y, gorunsun, gorunsun, (int)(ResimBoyut * 0.66), ResimBoyut);

                Soru.ReferansResimList.Add(ResimHelper.IslemResimUret(paraX, paraY, sonuc1, mat1, ResimBoyut));
            }
            int p, r;
            if (degiskenList[8] < degiskenList[9])
            {
                p = degiskenList[9];
                r = degiskenList[8];
            }
            else
            {
                p = degiskenList[8];
                r = degiskenList[9];
            }
            var paraP = ResimHelper.ParaResimUret(degiskenList[8], ResimBoyut);
            var paraR = ResimHelper.ParaResimUret(degiskenList[9], ResimBoyut);
            var mat4 = ResimHelper.CarpmaResimUret(p, r, false, false, (int)(ResimBoyut * 0.66), ResimBoyut);

            var satir4 = ResimHelper.IslemSoruResimUret(paraP, paraR, mat4, ResimBoyut);

            Soru.ReferansResimList.Add(satir4);

            dogruCevap = p * r;
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
