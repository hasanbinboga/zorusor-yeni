using System.Collections.Generic;

namespace ZoruSor.Lib.Soru
{
    public class ParaOyun3 : SoruBuilder
    {

        private int _dogruCevap;
        
        public override void ReferansResimUret()
        {
            //Degiskenlere zorluk derecesine gore deger ata.



            var x1 = RandomHelper.RandomNumber(10*ZorlukDerece -5, 2*10*ZorlukDerece);
            var y1 = RandomHelper.RandomDifferentNumber(1, 10*ZorlukDerece, x1, true);
            var x2 = RandomHelper.RandomNumber(10 * ZorlukDerece - 5, 10*ZorlukDerece);
            var y2 = RandomHelper.RandomDifferentNumber(1, 10 * ZorlukDerece, x2, true);
            var x3 = RandomHelper.RandomNumber(10 * ZorlukDerece - 5, 10 * ZorlukDerece);
            var y3 = RandomHelper.RandomDifferentNumber(1, 10 * ZorlukDerece, x3, true);
            var x4 = RandomHelper.RandomNumber(10 * ZorlukDerece - 5, 10 * ZorlukDerece);
            var y4 = RandomHelper.RandomDifferentNumber(1, 10 * ZorlukDerece, x4, true);


            var paraX1 = ResimHelper.ParaResimUret(x1, ResimBoyut);
            var paraY1 = ResimHelper.ParaResimUret(y1, ResimBoyut);
            var paraX2 = ResimHelper.ParaResimUret(x2, ResimBoyut);
            var paraY2 = ResimHelper.ParaResimUret(y2, ResimBoyut);
            var paraX3 = ResimHelper.ParaResimUret(x3, ResimBoyut);
            var paraY3 = ResimHelper.ParaResimUret(y3, ResimBoyut);
            var paraX4 = ResimHelper.ParaResimUret(x4, ResimBoyut);
            var paraY4 = ResimHelper.ParaResimUret(y4, ResimBoyut);
            var sonuc1 = ResimHelper.ParaResimUret(x1 - y1, ResimBoyut);
            var sonuc2 = ResimHelper.ParaResimUret(x2 - y2, ResimBoyut);
            var sonuc3 = ResimHelper.ParaResimUret(x3 - y3, ResimBoyut);

            var mat1 = ResimHelper.MatematikResimUret(x1.ToString(), "-", y1.ToString(), (x1 - y1).ToString(), (int)(ResimBoyut * 0.66), ResimBoyut);
            var mat2 = ResimHelper.MatematikResimUret("....", "-", "....", "....", (int)(ResimBoyut * 0.66), ResimBoyut);
            var mat3 = ResimHelper.MatematikResimUret("....", "-", "....", "....", (int)(ResimBoyut * 0.66), ResimBoyut);
            var mat4 = ResimHelper.MatematikResimUret("....", "-", "....", "....", (int)(ResimBoyut * 0.66), ResimBoyut);


            var satir1 = ResimHelper.IslemResimUret(paraX1, paraY1, sonuc1, mat1, ResimBoyut);
            var satir2 = ResimHelper.IslemResimUret(paraX2, paraY2, sonuc2, mat2, ResimBoyut);
            var satir3 = ResimHelper.IslemResimUret(paraX3, paraY3, sonuc3, mat3, ResimBoyut);
            var satir4 = ResimHelper.IslemSoruResimUret(paraX4, paraY4, mat4, ResimBoyut);

            Soru.ReferansResimList.Add(satir1);
            Soru.ReferansResimList.Add(satir2);
            Soru.ReferansResimList.Add(satir3);
            Soru.ReferansResimList.Add(satir4);

            _dogruCevap = x4 - y4;
        }

        public override void DogruCevapUret()
        {
            var dogruCevapResim = ResimHelper.ParaResimUret(_dogruCevap, ResimBoyut);
            Soru.DogruCevapList.Add(dogruCevapResim);
        }

        public override void CeldiriciUret()
        {
            var celdiriciList = new List<int>();
            for (int i = 0; i < CeldiriciAdet; i++)
            {
                var min = _dogruCevap - ZorlukDerece * 5;
                min = min < 0 ? 1 : min;
                var max = _dogruCevap + ZorlukDerece * 5;
                max = max <= CeldiriciAdet + 5 ? CeldiriciAdet + 10 : max;

                if (celdiriciList.Count == 0)
                {
                    var celdirici = RandomHelper.RandomNumber(min, max);
                    if (celdirici != _dogruCevap)
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
                    if (celdirici != _dogruCevap)
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
