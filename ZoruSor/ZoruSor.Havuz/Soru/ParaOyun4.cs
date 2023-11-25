using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using org.mariuszgromada.math.mxparser;

namespace ZoruSor.Lib.Soru
{
    public class ParaOyun4 : SoruBuilder
    {
        private int dogruCevap;
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


            var paraX = x > y ? ResimHelper.ParaResimUret(x, ResimBoyut) : ResimHelper.ParaResimUret(y, ResimBoyut);
            var paraY = x > y ? ResimHelper.ParaResimUret(y, ResimBoyut) : ResimHelper.ParaResimUret(x, ResimBoyut);
            var paraY1 = y > z ? ResimHelper.ParaResimUret(y, ResimBoyut) : ResimHelper.ParaResimUret(z, ResimBoyut);
            var paraZ = y > z ? ResimHelper.ParaResimUret(z, ResimBoyut) : ResimHelper.ParaResimUret(y, ResimBoyut);
            var paraZ1 = z > p ? ResimHelper.ParaResimUret(z, ResimBoyut) : ResimHelper.ParaResimUret(p, ResimBoyut);
            var paraP = z > p ? ResimHelper.ParaResimUret(p, ResimBoyut) : ResimHelper.ParaResimUret(z, ResimBoyut);
            var paraP1 = p > r ? ResimHelper.ParaResimUret(p, ResimBoyut) : ResimHelper.ParaResimUret(r, ResimBoyut);
            var paraR = p > r ? ResimHelper.ParaResimUret(r, ResimBoyut) : ResimHelper.ParaResimUret(p, ResimBoyut);

            var sonuc1 = ResimHelper.ParaResimUret(x * y, ResimBoyut);
            var sonuc2 = ResimHelper.ParaResimUret(y * z, ResimBoyut);
            var sonuc3 = ResimHelper.ParaResimUret(z * p, ResimBoyut);

            var mat1 = x > y ? ResimHelper.CarpmaResimUret(x, y, true, true, (int)(ResimBoyut * 0.66), ResimBoyut) :
                                ResimHelper.CarpmaResimUret(y, x, true, true, (int)(ResimBoyut * 0.66), ResimBoyut);
            var mat2 = y > z ? ResimHelper.CarpmaResimUret(y, z, false, false, (int)(ResimBoyut * 0.66), ResimBoyut) :
                 ResimHelper.CarpmaResimUret(z, y, false, false, (int)(ResimBoyut * 0.66), ResimBoyut);
            var mat3 = z > p ? ResimHelper.CarpmaResimUret(z, p, false, false, (int)(ResimBoyut * 0.66), ResimBoyut) :
                ResimHelper.CarpmaResimUret(p, z, false, false, (int)(ResimBoyut * 0.66), ResimBoyut);
            var mat4 = p > r ? ResimHelper.CarpmaResimUret(p, r, false, false, (int)(ResimBoyut * 0.66), ResimBoyut) :
                ResimHelper.CarpmaResimUret(r, p, false, false, (int)(ResimBoyut * 0.66), ResimBoyut);


            var satir1 = ResimHelper.IslemResimUret(paraX, paraY, sonuc1, mat1, ResimBoyut);
            var satir2 = ResimHelper.IslemResimUret(paraY1, paraZ, sonuc2, mat2, ResimBoyut);
            var satir3 = ResimHelper.IslemResimUret(paraZ1, paraP, sonuc3, mat3, ResimBoyut);
            var satir4 = ResimHelper.IslemSoruResimUret(paraP1, paraR, mat4, ResimBoyut);

            Soru.ReferansResimList.Add(satir1);
            Soru.ReferansResimList.Add(satir2);
            Soru.ReferansResimList.Add(satir3);
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
