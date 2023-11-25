using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.DataAccess.ObjectBinding;
using ZoruSor.Lib.Havuz;
using ZoruSor.Lib.Soru;
using ZoruSor.Lib.TestSoru;

namespace ZoruSor.Lib.Test.SayiOyun
{
    [DisplayName("Sayi Oyun Test 1")]
    [HighlightedClass]
    public class SayiOyunTest1 : BaseTest
    {
        private const int SayfadakiSoruAdet = 7;
        private const int CeldiriciAdet = 7;
        private const int ResimBoyut = 185;

        [HighlightedMember]
        public SayiOyunTest1(string satir1Formul, string satir2Formul, string satir3Formul
            , string satir4Formul, int zorlukDerece,int sayfaAdet, IslemGorunum islemGorunsun)
        {
            
            for (int i = 0; i < SayfadakiSoruAdet * sayfaAdet; i++)
            {
                var soruCreater = new SoruCreater();
                SoruBuilder builder = new Soru.SayiOyun()
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
                Add(new SayiOyunSoru1(builder.Soru));
            }
        }

        public SayiOyunTest1(List<SayiOyunSoru1> soruList )
        {
            soruList.ForEach(Add);
        }

        public SayiOyunTest1(IEnumerable<TestDetail> testDetails)
        {
            foreach (var testDetail in testDetails)
            {
                for (int i = 0; i < SayfadakiSoruAdet * testDetail.SayfaAdet; i++)
                {
                    var soruCreater = new SoruCreater();
                    SoruBuilder builder = new Soru.SayiOyun
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
                    Add(new SayiOyunSoru1(builder.Soru));
                }
                testDetail.Dispose();
            }
        }
    }
}
