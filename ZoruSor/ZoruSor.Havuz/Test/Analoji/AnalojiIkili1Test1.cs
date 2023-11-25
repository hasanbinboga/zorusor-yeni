using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.DataAccess.ObjectBinding;
using ZoruSor.Lib.Havuz;
using ZoruSor.Lib.Soru;
using ZoruSor.Lib.TestSoru;

namespace ZoruSor.Lib.Test.Analoji
{
    [DisplayName("Analoji Ikili 1")]
    [HighlightedClass]
    public class AnalojiIkili1Test1 : BaseTest
    {
        private const int CeldiriciAdet = 4;
        private const int ResimBoyut = 140;
        private const int SayfadakiSoruAdet = 4;

        [HighlightedMember]
        public AnalojiIkili1Test1(Havuz.Havuz havuz, int zorlukDerece, int sabitParcaAdet, int sayfaAdet)
        {
            
            for (int i = 0; i < SayfadakiSoruAdet * sayfaAdet; i++)
            {
                var soruCreater = new SoruCreater();
                SoruBuilder builder = new AnalojiIkili1
                {
                    Havuz = havuz,
                    ZorlukDerece = zorlukDerece,
                    SabitParcaAdet = sabitParcaAdet,
                    CeldiriciAdet = CeldiriciAdet,
                    ResimBoyut = ResimBoyut
                };
                soruCreater.Construct(builder);
                Add(new AnalojiIkili1Soru1(builder.Soru));
            }
        }

        [HighlightedMember]
        public AnalojiIkili1Test1(IEnumerable<TestDetail> testDetails) 
        {
            foreach (var testDetail in testDetails)
            {
                for (int i = 0; i < SayfadakiSoruAdet * testDetail.SayfaAdet; i++)
                {
                    var soruCreater = new SoruCreater();
                    SoruBuilder builder = new AnalojiIkili1
                    {
                        Havuz = testDetail.Havuz,
                        ZorlukDerece = testDetail.Zorluk,
                        SabitParcaAdet = testDetail.SabitParcaAdet,
                        CeldiriciAdet = CeldiriciAdet,
                        ResimBoyut = ResimBoyut
                    };
                    soruCreater.Construct(builder);
                    Add(new AnalojiIkili1Soru1(builder.Soru));
                }
                testDetail.Dispose();
            }

        }

        public AnalojiIkili1Test1(List<AnalojiIkili1Soru1> soruList )
        {
            soruList.ForEach(Add);
        }

    }
}
