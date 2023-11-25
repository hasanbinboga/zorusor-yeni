using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.DataAccess.ObjectBinding;
using ZoruSor.Lib.Havuz;
using ZoruSor.Lib.Soru;
using ZoruSor.Lib.TestSoru;

namespace ZoruSor.Lib.Test.ParaOyun
{
    [DisplayName("Para Oyun 5 Test 1")]
    [HighlightedClass]
    public class ParaOyun5Test1 : BaseTest
    {
        private const int SayfadakiSoruAdet = 2;
        private const int CeldiriciAdet = 8;
        private const int ResimBoyut = 185;

        [HighlightedMember]
        public ParaOyun5Test1(string satir1Formul, string satir2Formul, string satir3Formul
            , string satir4Formul, int zorlukDerece,int sayfaAdet)
        {
            
            for (int i = 0; i < SayfadakiSoruAdet * sayfaAdet; i++)
            {
                var soruCreater = new SoruCreater();
                SoruBuilder builder = new ParaOyun5()
                {
                    ZorlukDerece = zorlukDerece,
                    CeldiriciAdet = CeldiriciAdet,
                    ResimBoyut = ResimBoyut,
                    Satir1Formul = satir1Formul,
                    Satir2Formul = satir2Formul,
                    Satir3Formul = satir3Formul,
                    Satir4Formul = satir4Formul
                };
                soruCreater.Construct(builder);
                Add(new KurBulUySoru1(builder.Soru));
            }
        }

        public ParaOyun5Test1(IEnumerable<TestDetail> testDetails)
        {
            foreach (var testDetail in testDetails)
            {
                for (int i = 0; i < SayfadakiSoruAdet * testDetail.SayfaAdet; i++)
                {
                    var soruCreater = new SoruCreater();
                    SoruBuilder builder = new ParaOyun5
                    {
                        ZorlukDerece = testDetail.Zorluk,
                        CeldiriciAdet = CeldiriciAdet,
                        ResimBoyut = ResimBoyut,
                        Satir1Formul = testDetail.Resim1Formul,
                        Satir2Formul = testDetail.Resim2Formul,
                        Satir3Formul = testDetail.Resim3Formul,
                        Satir4Formul = testDetail.Resim4Formul
                    };
                    soruCreater.Construct(builder);
                    Add(new KurBulUySoru1(builder.Soru));
                }
                testDetail.Dispose();
            }
        }
    }
}
