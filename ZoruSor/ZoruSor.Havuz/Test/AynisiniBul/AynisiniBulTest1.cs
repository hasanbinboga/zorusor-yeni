using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.DataAccess.ObjectBinding;
using ZoruSor.Lib.Havuz;
using ZoruSor.Lib.Soru;
using ZoruSor.Lib.TestSoru;

namespace ZoruSor.Lib.Test.AynisiniBul
{
    [DisplayName("Aynısını Bul")]
    [HighlightedClass]
    public class AynisiniBulTest1 : BaseTest
    {
        private const int CeldiriciAdet = 5;
        private const int ResimBoyut = 135;
        private const int SayfadakiSoruAdet = 7;

        [HighlightedMember]
        public AynisiniBulTest1(Havuz.Havuz havuz, int zorlukDerece, int sabitParcaAdet, int sayfaAdet)
        {
            
            for (int i = 0; i < SayfadakiSoruAdet * sayfaAdet; i++)
            {
                var soruCreater = new SoruCreater();
                SoruBuilder builder = new Soru.AynisiniBul
                {
                    Havuz = havuz,
                    ZorlukDerece = zorlukDerece,
                    SabitParcaAdet = sabitParcaAdet,
                    CeldiriciAdet = CeldiriciAdet,
                    ResimBoyut = ResimBoyut
                };soruCreater.Construct(builder);
                Add(new AynisiniBulSoru1(builder.Soru));
            }
        }

       

        public AynisiniBulTest1(List<AynisiniBulSoru1> soruList )
        {
            soruList.ForEach(Add);
        }

        public AynisiniBulTest1(IEnumerable<TestDetail> testDetails)
        {
            foreach (var testDetail in testDetails)
            {

                for (int i = 0; i < SayfadakiSoruAdet * testDetail.SayfaAdet; i++)
                {
                    var soruCreater = new SoruCreater();
                    SoruBuilder builder = new Soru.AynisiniBul
                    {
                        Havuz = testDetail.Havuz,
                        ZorlukDerece = testDetail.Zorluk,
                        SabitParcaAdet = testDetail.SabitParcaAdet,
                        CeldiriciAdet = CeldiriciAdet,
                        ResimBoyut = ResimBoyut
                    };
                    soruCreater.Construct(builder);
                    Add(new AynisiniBulSoru1(builder.Soru));
                }
                testDetail.Dispose();
            }
        }

    }
}
