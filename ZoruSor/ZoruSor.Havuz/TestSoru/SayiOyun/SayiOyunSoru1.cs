using System.ComponentModel;

namespace ZoruSor.Lib.TestSoru
{
    public class SayiOyunSoru1 : BaseSoru
    {
        public SayiOyunSoru1(Soru.Soru soru)
        {
            Soru = soru;
            Referans1 = soru.ReferansStrList[0];
            Referans2 = soru.ReferansStrList[1];
            Referans3 = soru.ReferansStrList[2];
            Referans4 = soru.ReferansStrList[3];
            Cevap = RandomHelper.RandomChar('A', 'H').ToString();
            switch (Cevap)
            {
                case "A":
                    SecenekA = soru.DogruCevapObjList[0].Metin;
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
                    SecenekB = soru.DogruCevapObjList[0].Metin;
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
                    SecenekC = soru.DogruCevapObjList[0].Metin;
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
                    SecenekD = soru.DogruCevapObjList[0].Metin;
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
                    SecenekE = soru.DogruCevapObjList[0].Metin; 
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
                    SecenekF = soru.DogruCevapObjList[0].Metin; 
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
                    SecenekG = soru.DogruCevapObjList[0].Metin; 
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
                    SecenekH = soru.DogruCevapObjList[0].Metin; 
                    break;
            }

            Cevap = string.Format("{0} - {2} = {1}", Cevap, soru.DogruCevapObjList[0].Metin, soru.DogruCevapObjList[0].Aciklama);

        }


        [DisplayName("Referans 1")]
        public string Referans1 { get; set; }

        [DisplayName("Referans 2")]
        public string Referans2 { get; set; }

        [DisplayName("Referans 3")]
        public string Referans3 { get; set; }

        [DisplayName("Referans 4")]
        public string Referans4 { get; set; }

        [DisplayName("A)")]
        public string SecenekA { get; set; }

        [DisplayName("B)")]
        public string SecenekB { get; set; }

        [DisplayName("C)")]
        public string SecenekC { get; set; }

        [DisplayName("D)")]
        public string SecenekD { get; set; }

        [DisplayName("E)")]
        public string SecenekE { get; set; }

        [DisplayName("F)")]
        public string SecenekF { get; set; }

        [DisplayName("G)")]
        public string SecenekG { get; set; }

        [DisplayName("H)")]
        public string SecenekH { get; set; }

    }
}
