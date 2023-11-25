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
    public class TumuFarkliElemanTest3 : BaseTest
    {
        private const int SayfadakiSoruAdet = 2;
        private const int CeldiriciAdet = 2;
        private const int ResimBoyut = 250;

        [HighlightedMember]
        public TumuFarkliElemanTest3(Havuz.Havuz havuz, int zorlukDerece, int sabitParcaAdet, int sayfaAdet)
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

        public TumuFarkliElemanTest3(List<AynisiniBulSoru2> soruList )
        {
            soruList.ForEach(Add);
        }

        public TumuFarkliElemanTest3(IEnumerable<TestDetail> testDetails)
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
