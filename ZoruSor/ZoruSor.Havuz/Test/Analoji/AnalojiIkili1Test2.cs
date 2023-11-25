using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.DataAccess.ObjectBinding;
using ZoruSor.Lib.Havuz;
using ZoruSor.Lib.Soru;
using ZoruSor.Lib.TestSoru;

namespace ZoruSor.Lib.Test.Analoji
{
    [DisplayName("Aynısını Bul")]
    [HighlightedClass]
    public class AnalojiIkili1Test2 : BaseTest
    {
        private const int CeldiriciAdet = 3;
        private const int ResimBoyut = 160;
        private const int SayfadakiSoruAdet = 2;

        [HighlightedMember]
        public AnalojiIkili1Test2(Havuz.Havuz havuz, int zorlukDerece, int sabitParcaAdet, int sayfaAdet)//:base(havuz, zorlukDerece, sabitParcaAdet, sayfaAdet)
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
                Add(new AnalojiIkili1Soru2(builder.Soru));
            }
        }

        public AnalojiIkili1Test2(List<AnalojiIkili1Soru2> soruList )
        {
            soruList.ForEach(Add);
        }

        public AnalojiIkili1Test2(IEnumerable<TestDetail> testDetails)
        {
            foreach (var testDetail in testDetails)
            {
                for (int i = 0; i < SayfadakiSoruAdet* testDetail.SayfaAdet; i++)
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
                    Add(new AnalojiIkili1Soru2(builder.Soru));
                }
                testDetail.Dispose();
            }
        }
    }
}
