using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.DataAccess.ObjectBinding;
using ZoruSor.Lib.Havuz;
using ZoruSor.Lib.Soru;
using ZoruSor.Lib.TestSoru;

namespace ZoruSor.Lib.Test.FarklisiniBul
{
    [DisplayName("Farklısını Bul")]
    [HighlightedClass]
    public class FarklisiniBulTest2 : BaseTest
    {
        private const int SayfadakiSoruAdet = 4;
        private const int CeldiriciAdet = 3;
        private const int ResimBoyut = 160;

        [HighlightedMember]
        public FarklisiniBulTest2(Havuz.Havuz havuz, int zorlukDerece, int sabitParcaAdet, int sayfaAdet)
        {
            
            for (int i = 0; i < SayfadakiSoruAdet * sayfaAdet; i++)
            {
                var soruCreater = new SoruCreater();
                SoruBuilder builder = new Soru.FarklisiniBul
                {
                    Havuz = havuz,
                    ZorlukDerece = zorlukDerece,
                    SabitParcaAdet = sabitParcaAdet,
                    CeldiriciAdet = CeldiriciAdet,
                    ResimBoyut = ResimBoyut
                };
                soruCreater.Construct(builder);
                Add(new AynisiniBulSoru2(builder.Soru));
            }
        }

        public FarklisiniBulTest2(List<AynisiniBulSoru2> soruList )
        {
            soruList.ForEach(Add);
        }

        public FarklisiniBulTest2(IEnumerable<TestDetail> testDetails)
        {
            foreach (var testDetail in testDetails)
            {
                for (int i = 0; i < SayfadakiSoruAdet * testDetail.SayfaAdet; i++)
                {
                    var soruCreater = new SoruCreater();
                    SoruBuilder builder = new Soru.FarklisiniBul
                    {
                        Havuz = testDetail.Havuz,
                        ZorlukDerece = testDetail.Zorluk,
                        SabitParcaAdet = testDetail.SabitParcaAdet,
                        CeldiriciAdet = CeldiriciAdet,
                        ResimBoyut = ResimBoyut
                    };
                    soruCreater.Construct(builder);
                    Add(new AynisiniBulSoru2(builder.Soru));
                }
                testDetail.Dispose();
            }
        }

    }
}
