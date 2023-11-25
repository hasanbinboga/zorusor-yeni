using System.Drawing;
using System.ComponentModel;

namespace ZoruSor.Lib.TestSoru
{
    public class MelezUclu1Soru : BaseSoru
    {
        public MelezUclu1Soru(Soru.Soru soru)
        {
            Soru = soru;
            ReferansResim1 = soru.ReferansResimList[0].Image;
            ReferansResim2 = soru.ReferansResimList[1].Image;
            ReferansResim3 = soru.ReferansResimList[2].Image;
            Cevap = RandomHelper.RandomChar('A', 'D').ToString();
            switch (Cevap)
            {
                case "A":
                    SecenekA = soru.DogruCevapList[0].Image;
                    SecenekB = soru.CeldiriciList[0].Image;
                    SecenekC = soru.CeldiriciList[1].Image;
                    SecenekD = soru.CeldiriciList[2].Image;
                    break;
                case "B":
                    SecenekA = soru.CeldiriciList[0].Image;
                    SecenekB = soru.DogruCevapList[0].Image;
                    SecenekC = soru.CeldiriciList[1].Image;
                    SecenekD = soru.CeldiriciList[2].Image;
                    break;
                case "C":
                    SecenekA = soru.CeldiriciList[0].Image;
                    SecenekB = soru.CeldiriciList[1].Image;
                    SecenekC = soru.DogruCevapList[0].Image;
                    SecenekD = soru.CeldiriciList[2].Image;
                    break;
                case "D":
                    SecenekA = soru.CeldiriciList[0].Image;
                    SecenekB = soru.CeldiriciList[1].Image;
                    SecenekC = soru.CeldiriciList[2].Image;
                    SecenekD = soru.DogruCevapList[0].Image;
                    break;
            }

        }


        [DisplayName("Referans Resim 1")]
        public Image ReferansResim1 { get; set; }

        [DisplayName("Referans Resim 2")]
        public Image ReferansResim2 { get; set; }

        [DisplayName("Referans Resim 3")]
        public Image ReferansResim3 { get; set; }

        [DisplayName("A)")]
        public Image SecenekA { get; set; }

        [DisplayName("B)")]
        public Image SecenekB { get; set; }

        [DisplayName("C)")]
        public Image SecenekC { get; set; }

        [DisplayName("D)")]
        public Image SecenekD { get; set; }

    }
}
