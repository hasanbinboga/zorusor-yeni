using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using org.mariuszgromada.math.mxparser;

namespace ZoruSor.Lib.Soru
{
    public class ParaOyun2 : SoruBuilder
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
            for (int i = 0; i < 5; i++)
            {
                degiskenList.Add(RandomHelper.RandomDifferentNumber(1, 10 * ZorlukDerece, degiskenList.ToArray()));
            }
            //degiskenList = degiskenList.OrderByDescending(s => s).ToList();

            var x = degiskenList[0];
            var y = degiskenList[1];
            var z = degiskenList[2];
            var p = degiskenList[3];
            var r = degiskenList[4];
            

            var paraX = ResimHelper.ParaResimUret(x, ResimBoyut);
            var paraY = ResimHelper.ParaResimUret(y, ResimBoyut);
            var paraZ = ResimHelper.ParaResimUret(z, ResimBoyut);
            var paraP = ResimHelper.ParaResimUret(p, ResimBoyut);
            var paraR = ResimHelper.ParaResimUret(r, ResimBoyut);
            var sonuc1 = ResimHelper.ParaResimUret(x+y, ResimBoyut);
            var sonuc2 = ResimHelper.ParaResimUret(y+z, ResimBoyut);
            var sonuc3 = ResimHelper.ParaResimUret(z+p, ResimBoyut);

            var mat1 = ResimHelper.MatematikResimUret(x.ToString(), "+", y.ToString(), (x+y).ToString(), (int)(ResimBoyut * 0.66), ResimBoyut);
            var mat2 = ResimHelper.MatematikResimUret("....", "+", "....", "....", (int)(ResimBoyut * 0.66), ResimBoyut);
            var mat3 = ResimHelper.MatematikResimUret("....", "+", "....", "....", (int)(ResimBoyut * 0.66), ResimBoyut);
            var mat4 = ResimHelper.MatematikResimUret("....", "+", "....", "....", (int)(ResimBoyut * 0.66), ResimBoyut);


            var satir1 = ResimHelper.IslemResimUret(paraX, paraY, sonuc1, mat1, ResimBoyut);
            var satir2 = ResimHelper.IslemResimUret(paraY, paraZ, sonuc2, mat2, ResimBoyut);
            var satir3 = ResimHelper.IslemResimUret(paraZ, paraP, sonuc3, mat3, ResimBoyut);
            var satir4 = ResimHelper.IslemSoruResimUret(paraP, paraR, mat4, ResimBoyut);

            Soru.ReferansResimList.Add(satir1);
            Soru.ReferansResimList.Add(satir2);
            Soru.ReferansResimList.Add(satir3);
            Soru.ReferansResimList.Add(satir4);
            
            dogruCevap = p + r;
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
