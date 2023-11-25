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
    public class ParaOyun3Test2 : BaseTest
    {
        private const int SayfadakiSoruAdet = 1;
        private const int CeldiriciAdet = 3;
        private const int ResimBoyut = 350;


        [HighlightedMember]
        public ParaOyun3Test2(int zorlukDerece, int sayfaAdet)
        {
            for (int i = 0; i < SayfadakiSoruAdet* sayfaAdet; i++)
            {
                var soruCreater = new SoruCreater();
                SoruBuilder builder = new ParaOyun3
                {
                    ZorlukDerece = zorlukDerece,
                    CeldiriciAdet = CeldiriciAdet,
                    ResimBoyut = ResimBoyut
                };
                soruCreater.Construct(builder);
                Add(new KurBulUySoru2(builder.Soru));
            }
        }

        public ParaOyun3Test2(IEnumerable<TestDetail> testDetails)
        {
            foreach (var testDetail in testDetails)
            {
                for (int i = 0; i < SayfadakiSoruAdet * testDetail.SayfaAdet; i++)
                {
                    var soruCreater = new SoruCreater();
                    SoruBuilder builder = new ParaOyun3
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
