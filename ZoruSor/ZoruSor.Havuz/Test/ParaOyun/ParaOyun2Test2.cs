using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.DataAccess.ObjectBinding;
using ZoruSor.Lib.Havuz;
using ZoruSor.Lib.Soru;
using ZoruSor.Lib.TestSoru;

namespace ZoruSor.Lib.Test.ParaOyun
{
    [DisplayName("Para Oyun Test 2")]
    [HighlightedClass]
    public class ParaOyun2Test2 : BaseTest
    {
        private const int SayfadakiSoruAdet = 1;
        private const int CeldiriciAdet = 3;
        private const int ResimBoyut = 350;

        [HighlightedMember]
        public ParaOyun2Test2(int zorlukDerece, int sayfaAdet)
        {
            for (int i = 0; i <  sayfaAdet; i++)
            {
                var soruCreater = new SoruCreater();
                SoruBuilder builder = new ParaOyun2
                {
                    ZorlukDerece = zorlukDerece,
                    CeldiriciAdet = 3,
                    ResimBoyut = 350
                };
                soruCreater.Construct(builder);
                Add(new KurBulUySoru2(builder.Soru));
            }
        }

        public ParaOyun2Test2(IEnumerable<TestDetail> testDetails)
        {
            foreach (var testDetail in testDetails)
            {
                for (int i = 0; i < SayfadakiSoruAdet * testDetail.SayfaAdet; i++)
                {
                    var soruCreater = new SoruCreater();
                    SoruBuilder builder = new ParaOyun2
                    {
                        ZorlukDerece = testDetail.Zorluk,
                        CeldiriciAdet = CeldiriciAdet,
                        ResimBoyut = ResimBoyut
                    };
                    soruCreater.Construct(builder);
                    Add(new KurBulUySoru2(builder.Soru));
                }
                testDetail.Dispose();
            }
        }
    }
}
