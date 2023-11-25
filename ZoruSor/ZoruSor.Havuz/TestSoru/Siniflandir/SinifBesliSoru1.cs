using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace ZoruSor.Lib.TestSoru
{
    public class SinifBesliSoru1 : BaseSoru
    {
        public SinifBesliSoru1(Soru.Soru soru)
        {
            Soru = soru;
            var idList = new List<int>();
            var id = RandomHelper.RandomNumber(0, 4);
            ReferansResim1 = soru.ReferansResimList[id].Image;
            idList.Add(id);
            id = RandomHelper.RandomDifferentNumber(0, 4, idList.ToArray());
            ReferansResim2 = soru.ReferansResimList[id].Image;
            idList.Add(id);
            id = RandomHelper.RandomDifferentNumber(0, 4, idList.ToArray());
            ReferansResim3 = soru.ReferansResimList[id].Image;
            idList.Add(id);
            id = RandomHelper.RandomDifferentNumber(0, 4, idList.ToArray());
            ReferansResim4 = soru.ReferansResimList[id].Image;
            idList.Add(id);
            id = RandomHelper.RandomDifferentNumber(0, 4, idList.ToArray());
            ReferansResim5 = soru.ReferansResimList[id].Image;
            
            Cevap = RandomHelper.RandomChar('A', 'G').ToString();
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
                    break;
                case "B":
                    SecenekA = soru.CeldiriciList[0].Image;
                    SecenekB = soru.DogruCevapList[0].Image;
                    SecenekC = soru.CeldiriciList[1].Image;
                    SecenekD = soru.CeldiriciList[2].Image;
                    SecenekE = soru.CeldiriciList[3].Image;
                    SecenekF = soru.CeldiriciList[4].Image;
                    SecenekG = soru.CeldiriciList[5].Image;
                    break;
                case "C":
                    SecenekA = soru.CeldiriciList[0].Image;
                    SecenekB = soru.CeldiriciList[1].Image;
                    SecenekC = soru.DogruCevapList[0].Image;
                    SecenekD = soru.CeldiriciList[2].Image;
                    SecenekE = soru.CeldiriciList[3].Image;
                    SecenekF = soru.CeldiriciList[4].Image;
                    SecenekG = soru.CeldiriciList[5].Image;
                    break;
                case "D":
                    SecenekA = soru.CeldiriciList[0].Image;
                    SecenekB = soru.CeldiriciList[1].Image;
                    SecenekC = soru.CeldiriciList[2].Image;
                    SecenekD = soru.DogruCevapList[0].Image;
                    SecenekE = soru.CeldiriciList[3].Image;
                    SecenekF = soru.CeldiriciList[4].Image;
                    SecenekG = soru.CeldiriciList[5].Image;
                    break;
                case "E":
                    SecenekA = soru.CeldiriciList[0].Image;
                    SecenekB = soru.CeldiriciList[1].Image;
                    SecenekC = soru.CeldiriciList[2].Image;
                    SecenekD = soru.CeldiriciList[3].Image;
                    SecenekE = soru.DogruCevapList[0].Image;
                    SecenekF = soru.CeldiriciList[4].Image;
                    SecenekG = soru.CeldiriciList[5].Image;
                    break;
                case "F":
                    SecenekA = soru.CeldiriciList[0].Image;
                    SecenekB = soru.CeldiriciList[1].Image;
                    SecenekC = soru.CeldiriciList[2].Image;
                    SecenekD = soru.CeldiriciList[3].Image;
                    SecenekE = soru.CeldiriciList[4].Image;
                    SecenekF = soru.DogruCevapList[0].Image;
                    SecenekG = soru.CeldiriciList[5].Image;
                    break;
                case "G":
                    SecenekA = soru.CeldiriciList[0].Image;
                    SecenekB = soru.CeldiriciList[1].Image;
                    SecenekC = soru.CeldiriciList[2].Image;
                    SecenekD = soru.CeldiriciList[3].Image;
                    SecenekE = soru.CeldiriciList[4].Image;
                    SecenekF = soru.CeldiriciList[5].Image;
                    SecenekG = soru.DogruCevapList[0].Image;
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
    }
}
