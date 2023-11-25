using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.DataAccess.ObjectBinding;
using ZoruSor.Lib.Havuz;
using ZoruSor.Lib.Soru;
using ZoruSor.Lib.TestSoru;

namespace ZoruSor.Lib.Test
{
    [DisplayName("Analoji Parca 3 Test1")]
    [HighlightedClass]
    public class AnalojiParca3Test1 : BaseTest
    {

        private const int CeldiriciAdet = 7;
        private const int ResimBoyut = 350;
        private const int SayfadakiSoruAdet = 1;

        [HighlightedMember]
        public AnalojiParca3Test1(Havuz.Havuz havuz, int zorlukDerece, int sabitParcaAdet, int sayfaAdet)//:base(havuz, zorlukDerece, sabitParcaAdet, sayfaAdet)
        {
            
            for (int i = 0; i < SayfadakiSoruAdet* sayfaAdet; i++)
            {
                var soruCreater = new SoruCreater();
                SoruBuilder builder = new AnalojiParca3()
                {
                    Havuz = havuz,
                    ZorlukDerece = zorlukDerece,
                    SabitParcaAdet = sabitParcaAdet,
                    CeldiriciAdet = CeldiriciAdet,
                    ResimBoyut = ResimBoyut
                };
                soruCreater.Construct(builder);
                Add(new AnalojiParcaSoru1(builder.Soru));
            }
        }

        public AnalojiParca3Test1(List<AnalojiParcaSoru1> soruList )
        {
            soruList.ForEach(Add);
        }

        public AnalojiParca3Test1(IEnumerable<TestDetail> testDetails)
        {
            foreach (var testDetail in testDetails)
            {
                for (int i = 0; i < SayfadakiSoruAdet*testDetail.SayfaAdet; i++)
                {
                    var soruCreater = new SoruCreater();
                    SoruBuilder builder = new AnalojiParca3()
                    {
                        Havuz = testDetail.Havuz,
                        ZorlukDerece = testDetail.Zorluk,
                        SabitParcaAdet = testDetail.SabitParcaAdet,
                        CeldiriciAdet = CeldiriciAdet,
                        ResimBoyut = ResimBoyut
                    };
                    soruCreater.Construct(builder);
                    Add(new AnalojiParcaSoru1(builder.Soru));
                }
                testDetail.Dispose();
            }
        }
    }
}
