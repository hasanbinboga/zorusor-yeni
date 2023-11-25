using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.DataAccess.ObjectBinding;
using ZoruSor.Lib.Havuz;
using ZoruSor.Lib.Soru;
using ZoruSor.Lib.TestSoru;

namespace ZoruSor.Lib.Test.ParaOyun
{
    [DisplayName("Para Oyun 1 Test 1")]
    [HighlightedClass]
    public class ParaOyun1Test1 : BaseTest
    {
        private const int SayfadakiSoruAdet = 2;
        private const int CeldiriciAdet = 8;
        private const int ResimBoyut = 185;

        [HighlightedMember]
        public ParaOyun1Test1(string satir1Formul, string satir2Formul, string satir3Formul
            , string satir4Formul, int zorlukDerece, int sayfaAdet, bool islemGorunsun)
        {

            for (int i = 0; i < SayfadakiSoruAdet * sayfaAdet; i++)
            {
                var soruCreater = new SoruCreater();
                SoruBuilder builder = new Soru.ParaOyun
                {
                    ZorlukDerece = zorlukDerece,
                    CeldiriciAdet = CeldiriciAdet,
                    ResimBoyut = ResimBoyut,
                    Satir1Formul = satir1Formul,
                    Satir2Formul = satir2Formul,
                    Satir3Formul = satir3Formul,
                    Satir4Formul = satir4Formul,
                    IslemGorunsun = islemGorunsun
                };
                soruCreater.Construct(builder);
                Add(new KurBulUySoru1(builder.Soru));
            }
        }

        public ParaOyun1Test1(IEnumerable<TestDetail> testDetails)
        {
            foreach (var testDetail in testDetails)
            {
                for (int i = 0; i < SayfadakiSoruAdet * testDetail.SayfaAdet; i++)
                {
                    var soruCreater = new SoruCreater();
                    SoruBuilder builder = new Soru.ParaOyun
                    {
                        ZorlukDerece = testDetail.Zorluk,
                        CeldiriciAdet = CeldiriciAdet,
                        ResimBoyut = ResimBoyut,
                        Satir1Formul = testDetail.Resim1Formul,
                        Satir2Formul = testDetail.Resim2Formul,
                        Satir3Formul = testDetail.Resim3Formul,
                        Satir4Formul = testDetail.Resim4Formul,
                        IslemGorunsun = testDetail.IslemGorunsun
                    };
                    soruCreater.Construct(builder);
                    Add(new KurBulUySoru1(builder.Soru));
                }
                testDetail.Dispose();
            }
        }
    }
}
