using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.DataAccess.ObjectBinding;
using ZoruSor.Lib.Havuz;
using ZoruSor.Lib.Soru;
using ZoruSor.Lib.TestSoru;

namespace ZoruSor.Lib.Test.OrtakEleman
{
    [DisplayName("Benzer Elemanları Olanı Bul")]
    [HighlightedClass]
    public class OrtakElemanTest1 : BaseTest
    {
        private const int SayfadakiSoruAdet = 7;
        private const int CeldiriciAdet = 5;
        private const int ResimBoyut = 135;

        [HighlightedMember]
        public OrtakElemanTest1(Havuz.Havuz havuz, int zorlukDerece, int sabitParcaAdet, int sayfaAdet)
        {
            
            for (int i = 0; i < SayfadakiSoruAdet * sayfaAdet; i++)
            {
                var soruCreater = new SoruCreater();
                SoruBuilder builder = new Soru.OrtakEleman
                {
                    Havuz = havuz,
                    ZorlukDerece = zorlukDerece,
                    SabitParcaAdet = sabitParcaAdet,
                    CeldiriciAdet = CeldiriciAdet,
                    ResimBoyut = ResimBoyut
                };
                soruCreater.Construct(builder);
                Add(new AynisiniBulSoru1(builder.Soru));
            }
        }

        public OrtakElemanTest1(List<AynisiniBulSoru1> soruList )
        {
            soruList.ForEach(Add);
        }

        public OrtakElemanTest1(IEnumerable<TestDetail> testDetails)
        {
            foreach (var testDetail in testDetails)
            {
                for (int i = 0; i < SayfadakiSoruAdet * testDetail.SayfaAdet; i++)
                {
                    var soruCreater = new SoruCreater();
                    SoruBuilder builder = new Soru.OrtakEleman
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
