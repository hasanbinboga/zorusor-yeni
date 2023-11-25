using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.DataAccess.ObjectBinding;
using ZoruSor.Lib.Havuz;
using ZoruSor.Lib.Soru;
using ZoruSor.Lib.TestSoru;

namespace ZoruSor.Lib.Test.Analoji
{
    [DisplayName("Analoji Ikili 2")]
    [HighlightedClass]
    public class AnalojiIkili2Test1 : BaseTest
    {
        private const int CeldiriciAdet = 5;
        private const int ResimBoyut = 375;
        private const int SayfadakiSoruAdet = 3;

        [HighlightedMember]
        public AnalojiIkili2Test1(Havuz.Havuz havuz, int zorlukDerece, int sabitParcaAdet, int sayfaAdet)//:base(havuz, zorlukDerece, sabitParcaAdet, sayfaAdet)
        {
            
            for (int i = 0; i < SayfadakiSoruAdet * sayfaAdet; i++)
            {
                var soruCreater = new SoruCreater();
                SoruBuilder builder = new AnalojiIkili2
                {
                    Havuz = havuz,
                    ZorlukDerece = zorlukDerece,
                    SabitParcaAdet = sabitParcaAdet,
                    CeldiriciAdet = CeldiriciAdet,
                    ResimBoyut = ResimBoyut
                };
                soruCreater.Construct(builder);
                Add(new AnalojiIkili2Soru1(builder.Soru));
            }
        }

        public AnalojiIkili2Test1(List<AnalojiIkili1Soru2> soruList )
        {
            soruList.ForEach(Add);
        }

        public AnalojiIkili2Test1(IEnumerable<TestDetail> testDetails)
        {
            foreach (var testDetail in testDetails)
            {

                for (int i = 0; i < SayfadakiSoruAdet* testDetail.SayfaAdet; i++)
                {
                    var soruCreater = new SoruCreater();
                    SoruBuilder builder = new AnalojiIkili2
                    {
                        Havuz = testDetail.Havuz,
                        ZorlukDerece = testDetail.Zorluk ,
                        SabitParcaAdet = testDetail.SabitParcaAdet,
                        CeldiriciAdet = CeldiriciAdet,
                        ResimBoyut = ResimBoyut
                    };
                    soruCreater.Construct(builder);
                    Add(new AnalojiIkili2Soru1(builder.Soru));
                }
                testDetail.Dispose();
            }
        }

    }
}
