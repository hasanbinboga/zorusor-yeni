using System.ComponentModel;
using System.Drawing;

namespace ZoruSor.Lib.TestSoru
{
    public class KurBulUySoru3 : BaseSoru
    {
        public KurBulUySoru3(Soru.Soru soru)
        {
            Soru = soru;
            ReferansResim1 = soru.ReferansResimList[0].Image;
            ReferansResim2 = soru.ReferansResimList[1].Image;
            ReferansResim3 = soru.ReferansResimList[2].Image;
            ReferansResim4 = soru.ReferansResimList[3].Image;
            ReferansResim5 = soru.ReferansResimList[4].Image;
            ReferansResim6 = soru.ReferansResimList[5].Image;
            ReferansResim7 = soru.ReferansResimList[6].Image;
            ReferansResim8 = soru.ReferansResimList[7].Image;

            Cevap = RandomHelper.RandomChar('A', 'L').ToString();
            switch (Cevap)
            {
                case "A":
                    SecenekA = soru.DogruCevapList[0].Image;
                    SecenekB = soru.CeldiriciList[0].Image;
                    SecenekC = soru.CeldiriciList[1].Image;
                    SecenekD = soru.CeldiriciList[2].Image;
                    SecenekE = soru.CeldiriciList[3].Image;
                    SecenekF = soru.CeldiriciList[4].Image;
                    SecenekG = soru.CeldiriciList[5].Image;
                    SecenekH = soru.CeldiriciList[6].Image;
                    SecenekI = soru.CeldiriciList[7].Image;
                    SecenekJ = soru.CeldiriciList[8].Image;
                    SecenekK = soru.CeldiriciList[9].Image;
                    SecenekL = soru.CeldiriciList[10].Image;
                    break;
                case "B":
                    SecenekA = soru.CeldiriciList[0].Image;
                    SecenekB = soru.DogruCevapList[0].Image;
                    SecenekC = soru.CeldiriciList[1].Image;
                    SecenekD = soru.CeldiriciList[2].Image;
                    SecenekE = soru.CeldiriciList[3].Image;
                    SecenekF = soru.CeldiriciList[4].Image;
                    SecenekG = soru.CeldiriciList[5].Image;
                    SecenekH = soru.CeldiriciList[6].Image;
                    SecenekI = soru.CeldiriciList[7].Image;
                    SecenekJ = soru.CeldiriciList[8].Image;
                    SecenekK = soru.CeldiriciList[9].Image;
                    SecenekL = soru.CeldiriciList[10].Image;
                    break;
                case "C":
                    SecenekA = soru.CeldiriciList[0].Image;
                    SecenekB = soru.CeldiriciList[1].Image;
                    SecenekC = soru.DogruCevapList[0].Image;
                    SecenekD = soru.CeldiriciList[2].Image;
                    SecenekE = soru.CeldiriciList[3].Image;
                    SecenekF = soru.CeldiriciList[4].Image;
                    SecenekG = soru.CeldiriciList[5].Image;
                    SecenekH = soru.CeldiriciList[6].Image;
                    SecenekI = soru.CeldiriciList[7].Image;
                    SecenekJ = soru.CeldiriciList[8].Image;
                    SecenekK = soru.CeldiriciList[9].Image;
                    SecenekL = soru.CeldiriciList[10].Image;
                    break;
                case "D":
                    SecenekA = soru.CeldiriciList[0].Image;
                    SecenekB = soru.CeldiriciList[1].Image;
                    SecenekC = soru.CeldiriciList[2].Image;
                    SecenekD = soru.DogruCevapList[0].Image;
                    SecenekE = soru.CeldiriciList[3].Image;
                    SecenekF = soru.CeldiriciList[4].Image;
                    SecenekG = soru.CeldiriciList[5].Image;
                    SecenekH = soru.CeldiriciList[6].Image;
                    SecenekI = soru.CeldiriciList[7].Image;
                    SecenekJ = soru.CeldiriciList[8].Image;
                    SecenekK = soru.CeldiriciList[9].Image;
                    SecenekL = soru.CeldiriciList[10].Image;
                    break;
                case "E":
                    SecenekA = soru.CeldiriciList[0].Image;
                    SecenekB = soru.CeldiriciList[1].Image;
                    SecenekC = soru.CeldiriciList[2].Image;
                    SecenekD = soru.CeldiriciList[3].Image;
                    SecenekE = soru.DogruCevapList[0].Image;
                    SecenekF = soru.CeldiriciList[4].Image;
                    SecenekG = soru.CeldiriciList[5].Image;
                    SecenekH = soru.CeldiriciList[6].Image;
                    SecenekI = soru.CeldiriciList[7].Image;
                    SecenekJ = soru.CeldiriciList[8].Image;
                    SecenekK = soru.CeldiriciList[9].Image;
                    SecenekL = soru.CeldiriciList[10].Image;
                    break;
                case "F":
                    SecenekA = soru.CeldiriciList[0].Image;
                    SecenekB = soru.CeldiriciList[1].Image;
                    SecenekC = soru.CeldiriciList[2].Image;
                    SecenekD = soru.CeldiriciList[3].Image;
                    SecenekE = soru.CeldiriciList[4].Image;
                    SecenekF = soru.DogruCevapList[0].Image;
                    SecenekG = soru.CeldiriciList[5].Image;
                    SecenekH = soru.CeldiriciList[6].Image;
                    SecenekI = soru.CeldiriciList[7].Image;
                    SecenekJ = soru.CeldiriciList[8].Image;
                    SecenekK = soru.CeldiriciList[9].Image;
                    SecenekL = soru.CeldiriciList[10].Image;
                    break;
                case "G":
                    SecenekA = soru.CeldiriciList[0].Image;
                    SecenekB = soru.CeldiriciList[1].Image;
                    SecenekC = soru.CeldiriciList[2].Image;
                    SecenekD = soru.CeldiriciList[3].Image;
                    SecenekE = soru.CeldiriciList[4].Image;
                    SecenekF = soru.CeldiriciList[5].Image;
                    SecenekG = soru.DogruCevapList[0].Image;
                    SecenekH = soru.CeldiriciList[6].Image;
                    SecenekI = soru.CeldiriciList[7].Image;
                    SecenekJ = soru.CeldiriciList[8].Image;
                    SecenekK = soru.CeldiriciList[9].Image;
                    SecenekL = soru.CeldiriciList[10].Image;
                    break;
                case "H":
                    SecenekA = soru.CeldiriciList[0].Image;
                    SecenekB = soru.CeldiriciList[1].Image;
                    SecenekC = soru.CeldiriciList[2].Image;
                    SecenekD = soru.CeldiriciList[3].Image;
                    SecenekE = soru.CeldiriciList[4].Image;
                    SecenekF = soru.CeldiriciList[5].Image;
                    SecenekG = soru.CeldiriciList[6].Image;
                    SecenekH = soru.DogruCevapList[0].Image;
                    SecenekI = soru.CeldiriciList[7].Image;
                    SecenekJ = soru.CeldiriciList[8].Image;
                    SecenekK = soru.CeldiriciList[9].Image;
                    SecenekL = soru.CeldiriciList[10].Image;
                    break;
                case "I":
                    SecenekA = soru.CeldiriciList[0].Image;
                    SecenekB = soru.CeldiriciList[1].Image;
                    SecenekC = soru.CeldiriciList[2].Image;
                    SecenekD = soru.CeldiriciList[3].Image;
                    SecenekE = soru.CeldiriciList[4].Image;
                    SecenekF = soru.CeldiriciList[5].Image;
                    SecenekG = soru.CeldiriciList[6].Image;
                    SecenekH = soru.CeldiriciList[7].Image;
                    SecenekI = soru.DogruCevapList[0].Image;
                    SecenekJ = soru.CeldiriciList[8].Image;
                    SecenekK = soru.CeldiriciList[9].Image;
                    SecenekL = soru.CeldiriciList[10].Image;
                    break;
                case "J":
                    SecenekA = soru.CeldiriciList[0].Image;
                    SecenekB = soru.CeldiriciList[1].Image;
                    SecenekC = soru.CeldiriciList[2].Image;
                    SecenekD = soru.CeldiriciList[3].Image;
                    SecenekE = soru.CeldiriciList[4].Image;
                    SecenekF = soru.CeldiriciList[5].Image;
                    SecenekG = soru.CeldiriciList[6].Image;
                    SecenekH = soru.CeldiriciList[7].Image;
                    SecenekI = soru.CeldiriciList[8].Image;
                    SecenekJ = soru.DogruCevapList[0].Image;
                    SecenekK = soru.CeldiriciList[9].Image;
                    SecenekL = soru.CeldiriciList[10].Image;
                    break;
                case "K":
                    SecenekA = soru.CeldiriciList[0].Image;
                    SecenekB = soru.CeldiriciList[1].Image;
                    SecenekC = soru.CeldiriciList[2].Image;
                    SecenekD = soru.CeldiriciList[3].Image;
                    SecenekE = soru.CeldiriciList[4].Image;
                    SecenekF = soru.CeldiriciList[5].Image;
                    SecenekG = soru.CeldiriciList[6].Image;
                    SecenekH = soru.CeldiriciList[7].Image;
                    SecenekI = soru.CeldiriciList[8].Image;
                    SecenekJ = soru.CeldiriciList[9].Image;
                    SecenekK = soru.DogruCevapList[0].Image;
                    SecenekL = soru.CeldiriciList[10].Image;
                    break;
                case "L":
                    SecenekA = soru.CeldiriciList[0].Image;
                    SecenekB = soru.CeldiriciList[1].Image;
                    SecenekC = soru.CeldiriciList[2].Image;
                    SecenekD = soru.CeldiriciList[3].Image;
                    SecenekE = soru.CeldiriciList[4].Image;
                    SecenekF = soru.CeldiriciList[5].Image;
                    SecenekG = soru.CeldiriciList[6].Image;
                    SecenekH = soru.CeldiriciList[7].Image;
                    SecenekI = soru.CeldiriciList[8].Image;
                    SecenekJ = soru.CeldiriciList[9].Image;
                    SecenekK = soru.CeldiriciList[10].Image;
                    SecenekL = soru.DogruCevapList[0].Image;
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
        [DisplayName("Referans Resim 7")]
        public Image ReferansResim7 { get; set; }
        [DisplayName("Referans Resim 8")]
        public Image ReferansResim8 { get; set; }

        [DisplayName("A)")]
        public Image SecenekA { get; set; }
        [DisplayName("B)")]
        public Image SecenekB { get; set; }
        [DisplayName("C)")]
        public Image SecenekC { get; set; }
        [DisplayName("D)")]
        public Image SecenekD { get; set; }
        [DisplayName("E)")]
        public Image SecenekE { get; set; }
        [DisplayName("F)")]
        public Image SecenekF { get; set; }
        [DisplayName("G)")]
        public Image SecenekG { get; set; }
        [DisplayName("H)")]
        public Image SecenekH { get; set; }
        [DisplayName("I)")]
        public Image SecenekI { get; set; }
        [DisplayName("J)")]
        public Image SecenekJ { get; set; }
        [DisplayName("K)")]
        public Image SecenekK { get; set; }
        [DisplayName("L)")]
        public Image SecenekL { get; set; }
    }
}
