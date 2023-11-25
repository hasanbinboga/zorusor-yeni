using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.DataAccess.ObjectBinding;
using ZoruSor.Lib.Havuz;
using ZoruSor.Lib.Soru;
using ZoruSor.Lib.TestSoru;

namespace ZoruSor.Lib.Test.TumuFarkli
{
    [DisplayName("Tüm Elemanları Farklı Olanı Bul")]
    [HighlightedClass]
    public class TumuFarkliElemanTest2 : BaseTest
    {
        private const int SayfadakiSoruAdet = 4;
        private const int CeldiriciAdet = 2;
        private const int ResimBoyut = 160;

        [HighlightedMember]
        public TumuFarkliElemanTest2(Havuz.Havuz havuz, int zorlukDerece, int sabitParcaAdet, int sayfaAdet)
        {
            
            for (int i = 0; i < SayfadakiSoruAdet * sayfaAdet; i++)
            {
                var soruCreater = new SoruCreater();
                SoruBuilder builder = new TumuFarkliEleman
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

        public TumuFarkliElemanTest2(List<AynisiniBulSoru2> soruList )
        {
            soruList.ForEach(Add);
        }

        public TumuFarkliElemanTest2(IEnumerable<TestDetail> testDetails)
        {
            foreach (var testDetail in testDetails)
            {
                for (int i = 0; i < SayfadakiSoruAdet * testDetail.SayfaAdet; i++)
                {
                    var soruCreater = new SoruCreater();
                    SoruBuilder builder = new TumuFarkliEleman
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
