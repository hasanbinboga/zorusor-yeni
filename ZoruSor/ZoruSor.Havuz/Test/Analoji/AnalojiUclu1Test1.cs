using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.DataAccess.ObjectBinding;
using ZoruSor.Lib.Havuz;
using ZoruSor.Lib.Soru;
using ZoruSor.Lib.TestSoru;

namespace ZoruSor.Lib.Test
{
    [DisplayName("Analoji Uclu 1")]
    [HighlightedClass]
    public class AnalojiUclu1Test1 : BaseTest
    {
        private const int CeldiriciAdet = 5;
        private const int ResimBoyut = 270;
        private const int SayfadakiSoruAdet = 2;

        [HighlightedMember]
        public AnalojiUclu1Test1(Havuz.Havuz havuz, int zorlukDerece, int sabitParcaAdet, int sayfaAdet)//:base(havuz, zorlukDerece, sabitParcaAdet, sayfaAdet)
        {
            
            for (int i = 0; i < SayfadakiSoruAdet * sayfaAdet; i++)
            {
                var soruCreater = new SoruCreater();
                SoruBuilder builder = new AnalojiUclu1
                {
                    Havuz = havuz,
                    ZorlukDerece = zorlukDerece,
                    SabitParcaAdet = sabitParcaAdet,
                    CeldiriciAdet = CeldiriciAdet,
                    ResimBoyut = ResimBoyut
                };
                soruCreater.Construct(builder);
                Add(new AnalojiUclu1Soru1(builder.Soru));
            }
        }

        public AnalojiUclu1Test1(List<AnalojiUclu1Soru1> soruList )
        {
            soruList.ForEach(Add);
        }

        public AnalojiUclu1Test1(IEnumerable<TestDetail> testDetails)
        {
            foreach (var testDetail in testDetails)
            {

                for (int i = 0; i < SayfadakiSoruAdet * testDetail.SayfaAdet; i++)
                {
                    var soruCreater = new SoruCreater();
                    SoruBuilder builder = new AnalojiUclu1
                    {
                        Havuz = testDetail.Havuz,
                        ZorlukDerece = testDetail.Zorluk,
                        SabitParcaAdet = testDetail.SabitParcaAdet,
                        CeldiriciAdet = CeldiriciAdet,
                        ResimBoyut = ResimBoyut
                    };
                    soruCreater.Construct(builder);
                    Add(new AnalojiUclu1Soru1(builder.Soru));
                }
                testDetail.Dispose();
            }
        }

    }
}
