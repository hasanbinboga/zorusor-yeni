using System;
using System.Drawing;
using System.ComponentModel;

namespace ZoruSor.Lib.TestSoru
{
    public class AynisiniBulSoru2:BaseSoru
    {
        public AynisiniBulSoru2(Soru.Soru soru)
        {
            Soru = soru;
            ReferansResim = soru.ReferansResimList[0].Image;
            Cevap = RandomHelper.RandomChar('A', 'C').ToString();
            switch (Cevap)
            {
                case "A":
                    SecenekA = soru.DogruCevapList[0].Image;
                    SecenekB = soru.CeldiriciList[0].Image;
                    SecenekC = soru.CeldiriciList[1].Image;
                    break;
                case "B":
                    SecenekA = soru.CeldiriciList[0].Image; 
                    SecenekB = soru.DogruCevapList[0].Image;
                    SecenekC = soru.CeldiriciList[1].Image;
                    break;
                case "C":
                    SecenekA = soru.CeldiriciList[0].Image;
                    SecenekB = soru.CeldiriciList[1].Image;
                    SecenekC = soru.DogruCevapList[0].Image; 
                    break;
            }
            
        }

        [DisplayName("A)")]
        public Image SecenekA { get; set; }

        [DisplayName("B)")]
        public Image SecenekB { get; set; }

        [DisplayName("C)")]
        public Image SecenekC { get; set; }
       }
}
