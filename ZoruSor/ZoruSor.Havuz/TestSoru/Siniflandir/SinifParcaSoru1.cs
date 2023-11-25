using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace ZoruSor.Lib.TestSoru
{
    public class SinifParcaSoru1 : BaseSoru
    {
        public SinifParcaSoru1(Soru.Soru soru)
        {
            Soru = soru;
            ReferansResim1 = soru.ReferansResimList[0].Image;
            ReferansResim2 = soru.ReferansResimList[1].Image;
            ReferansResim3 = soru.ReferansResimList[2].Image;
            ReferansResim4 = soru.ReferansResimList[3].Image;
            ReferansResim5 = soru.ReferansResimList[4].Image;
            ReferansResim6 = soru.ReferansResimList[5].Image;

            Cevap = RandomHelper.RandomChar('A', 'H').ToString();
            switch (Cevap)
            {
                case "A":
                    SecenekA = soru.DogruCevapStrList[0];
                    SecenekB = soru.CeldiriciStrList[0];
                    SecenekC = soru.CeldiriciStrList[1];
                    SecenekD = soru.CeldiriciStrList[2];
                    SecenekE = soru.CeldiriciStrList[3];
                    SecenekF = soru.CeldiriciStrList[4];
                    SecenekG = soru.CeldiriciStrList[5];
                    SecenekH = soru.CeldiriciStrList[6];
                    break;
                case "B":
                    SecenekA = soru.CeldiriciStrList[0];
                    SecenekB = soru.DogruCevapStrList[0];
                    SecenekC = soru.CeldiriciStrList[1];
                    SecenekD = soru.CeldiriciStrList[2];
                    SecenekE = soru.CeldiriciStrList[3];
                    SecenekF = soru.CeldiriciStrList[4];
                    SecenekG = soru.CeldiriciStrList[5];
                    SecenekH = soru.CeldiriciStrList[6];
                    break;
                case "C":
                    SecenekA = soru.CeldiriciStrList[0];
                    SecenekB = soru.CeldiriciStrList[1];
                    SecenekC = soru.DogruCevapStrList[0];
                    SecenekD = soru.CeldiriciStrList[2];
                    SecenekE = soru.CeldiriciStrList[3];
                    SecenekF = soru.CeldiriciStrList[4];
                    SecenekG = soru.CeldiriciStrList[5];
                    SecenekH = soru.CeldiriciStrList[6];
                    break;
                case "D":
                    SecenekA = soru.CeldiriciStrList[0];
                    SecenekB = soru.CeldiriciStrList[1];
                    SecenekC = soru.CeldiriciStrList[2];
                    SecenekD = soru.DogruCevapStrList[0];
                    SecenekE = soru.CeldiriciStrList[3];
                    SecenekF = soru.CeldiriciStrList[4];
                    SecenekG = soru.CeldiriciStrList[5];
                    SecenekH = soru.CeldiriciStrList[6];
                    break;
                case "E":
                    SecenekA = soru.CeldiriciStrList[0];
                    SecenekB = soru.CeldiriciStrList[1];
                    SecenekC = soru.CeldiriciStrList[2];
                    SecenekD = soru.CeldiriciStrList[3];
                    SecenekE = soru.DogruCevapStrList[0];
                    SecenekF = soru.CeldiriciStrList[4];
                    SecenekG = soru.CeldiriciStrList[5];
                    SecenekH = soru.CeldiriciStrList[6];
                    break;
                case "F":
                    SecenekA = soru.CeldiriciStrList[0];
                    SecenekB = soru.CeldiriciStrList[1];
                    SecenekC = soru.CeldiriciStrList[2];
                    SecenekD = soru.CeldiriciStrList[3];
                    SecenekE = soru.CeldiriciStrList[4];
                    SecenekF = soru.DogruCevapStrList[0];
                    SecenekG = soru.CeldiriciStrList[5];
                    SecenekH = soru.CeldiriciStrList[6];
                    break;
                case "G":
                    SecenekA = soru.CeldiriciStrList[0];
                    SecenekB = soru.CeldiriciStrList[1];
                    SecenekC = soru.CeldiriciStrList[2];
                    SecenekD = soru.CeldiriciStrList[3];
                    SecenekE = soru.CeldiriciStrList[4];
                    SecenekF = soru.CeldiriciStrList[5];
                    SecenekG = soru.DogruCevapStrList[0];
                    SecenekH = soru.CeldiriciStrList[6];
                    break;
                case "H":
                    SecenekA = soru.CeldiriciStrList[0];
                    SecenekB = soru.CeldiriciStrList[1];
                    SecenekC = soru.CeldiriciStrList[2];
                    SecenekD = soru.CeldiriciStrList[3];
                    SecenekE = soru.CeldiriciStrList[4];
                    SecenekF = soru.CeldiriciStrList[5];
                    SecenekG = soru.CeldiriciStrList[6];
                    SecenekH = soru.DogruCevapStrList[0];
                    break;
            }

        }
        [DisplayName("Referans Resim 1")]
        public Image ReferansResim1 { get; set; }
        [DisplayName("Referans Resim 2")]
        public Image ReferansResim2 { get; set; }
        [DisplayName("Referans Resim 3")]
        public Image ReferansResim3 { get; set; }
        [DisplayName("Referans Resim 4")]
        public Image ReferansResim4 { get; set; }
        [DisplayName("Referans Resim 5")]
        public Image ReferansResim5 { get; set; }
        [DisplayName("Referans Resim 6")]
        public Image ReferansResim6 { get; set; }
        [DisplayName("A)")]
        public string SecenekA { get; set; }
        [DisplayName("B)")]
        public  string SecenekB { get; set; }
        [DisplayName("C)")]
        public  string SecenekC { get; set; }
        [DisplayName("D)")]
        public  string SecenekD { get; set; }
        [DisplayName("E)")]
        public  string SecenekE { get; set; }
        [DisplayName("F)")]
        public  string SecenekF { get; set; }
        [DisplayName("G)")]
        public  string SecenekG { get; set; }
        [DisplayName("H)")]
        public string SecenekH { get; set; }
    }
}
