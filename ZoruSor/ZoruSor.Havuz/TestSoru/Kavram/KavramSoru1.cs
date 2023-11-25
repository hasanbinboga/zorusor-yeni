using System.ComponentModel;
using System.Drawing;

namespace ZoruSor.Lib.TestSoru
{
    public class KavramSoru1 : BaseSoru
    {
        public KavramSoru1(Soru.Soru soru)
        {
            Soru = soru;
            ReferansIyiResim1 = soru.ReferansResimList[0].Image;
            ReferansIyiResim2 = soru.ReferansResimList[1].Image;
            ReferansIyiResim3 = soru.ReferansResimList[2].Image;
            ReferansIyiResim4 = soru.ReferansResimList[3].Image;
            ReferansKotuResim1 = soru.ReferansResimList[4].Image;
            ReferansKotuResim2 = soru.ReferansResimList[5].Image;
            ReferansKotuResim3 = soru.ReferansResimList[6].Image;
            ReferansKotuResim4 = soru.ReferansResimList[7].Image;
            Cevap = RandomHelper.RandomChar('A', 'F').ToString();
            switch (Cevap)
            {
                case "A":
                    SecenekA = soru.DogruCevapList[0].Image;
                    SecenekB = soru.CeldiriciList[0].Image;
                    SecenekC = soru.CeldiriciList[1].Image;
                    SecenekD = soru.CeldiriciList[2].Image;
                    SecenekE = soru.CeldiriciList[3].Image;
                    SecenekF = soru.CeldiriciList[4].Image;
                    break;
                case "B":
                    SecenekA = soru.CeldiriciList[0].Image;
                    SecenekB = soru.DogruCevapList[0].Image;
                    SecenekC = soru.CeldiriciList[1].Image;
                    SecenekD = soru.CeldiriciList[2].Image;
                    SecenekE = soru.CeldiriciList[3].Image;
                    SecenekF = soru.CeldiriciList[4].Image;
                    break;
                case "C":
                    SecenekA = soru.CeldiriciList[0].Image;
                    SecenekB = soru.CeldiriciList[1].Image;
                    SecenekC = soru.DogruCevapList[0].Image;
                    SecenekD = soru.CeldiriciList[2].Image;
                    SecenekE = soru.CeldiriciList[3].Image;
                    SecenekF = soru.CeldiriciList[4].Image;
                    break;
                case "D":
                    SecenekA = soru.CeldiriciList[0].Image;
                    SecenekB = soru.CeldiriciList[1].Image;
                    SecenekC = soru.CeldiriciList[2].Image;
                    SecenekD = soru.DogruCevapList[0].Image;
                    SecenekE = soru.CeldiriciList[3].Image;
                    SecenekF = soru.CeldiriciList[4].Image;
                    break;
                case "E":
                    SecenekA = soru.CeldiriciList[0].Image;
                    SecenekB = soru.CeldiriciList[1].Image;
                    SecenekC = soru.CeldiriciList[2].Image;
                    SecenekD = soru.CeldiriciList[3].Image;
                    SecenekE = soru.DogruCevapList[0].Image;
                    SecenekF = soru.CeldiriciList[4].Image;
                    break;
                case "F":
                    SecenekA = soru.CeldiriciList[0].Image;
                    SecenekB = soru.CeldiriciList[1].Image;
                    SecenekC = soru.CeldiriciList[2].Image;
                    SecenekD = soru.CeldiriciList[3].Image;
                    SecenekE = soru.CeldiriciList[4].Image;
                    SecenekF = soru.DogruCevapList[0].Image;
                    break;
            }

        }

        [DisplayName("Iyi Referans Resim 1")]
        public Image ReferansIyiResim1 { get; set; }
        [DisplayName("Iyi Referans Resim 2")]
        public Image ReferansIyiResim2 { get; set; }
        [DisplayName("Iyi Referans Resim 3")]
        public Image ReferansIyiResim3 { get; set; }
        [DisplayName("Iyi Referans Resim 4")]
        public Image ReferansIyiResim4 { get; set; }
        [DisplayName("Kotu Referans Resim 1")]
        public Image ReferansKotuResim1 { get; set; }
        [DisplayName("Kotu Referans Resim 2")]
        public Image ReferansKotuResim2 { get; set; }
        [DisplayName("Kotu Referans Resim 3")]
        public Image ReferansKotuResim3 { get; set; }
        [DisplayName("Kotu Referans Resim 4")]
        public Image ReferansKotuResim4 { get; set; }
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
    }
}
