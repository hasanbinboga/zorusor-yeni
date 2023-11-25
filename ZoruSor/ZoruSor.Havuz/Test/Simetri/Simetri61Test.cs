using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.DataAccess.ObjectBinding;
using ZoruSor.Lib.Havuz;
using ZoruSor.Lib.Soru;
using ZoruSor.Lib.TestSoru;

namespace ZoruSor.Lib.Test.Simetri
{
    [DisplayName("Simetrik Iliskiler 6")]
    [HighlightedClass]
    public class Simetri61Test : BaseTest
    {
        private const int SayfadakiSoruAdet = 1;
        private const int CeldiriciAdet = 11;
        private const int ResimBoyut = 282;

        [HighlightedMember]
        public Simetri61Test(Havuz.Havuz havuz, int zorlukDerece, int sabitParcaAdet, int sayfaAdet)
        {
            for (int i = 0; i < SayfadakiSoruAdet * sayfaAdet; i++)
            {
                var soruCreater = new SoruCreater();
                SoruBuilder builder = new SimetrikIliski6()
                {
                    Havuz = havuz,
                    ZorlukDerece = zorlukDerece,
                    SabitParcaAdet = sabitParcaAdet,
                    CeldiriciAdet = CeldiriciAdet,
                    ResimBoyut = ResimBoyut
                };
                soruCreater.Construct(builder);
                Add(new KurBulUySoru3(builder.Soru));
            }
        }

        public Simetri61Test(IEnumerable<TestDetail> testDetails)
        {
            foreach (var testDetail in testDetails)
            {
                for (int i = 0; i < SayfadakiSoruAdet * testDetail.SayfaAdet; i++)
                {
                    var soruCreater = new SoruCreater();
                    SoruBuilder builder = new SimetrikIliski6
                    {
                        Havuz = testDetail.Havuz,
                        ZorlukDerece = testDetail.Zorluk,
                        SabitParcaAdet = testDetail.SabitParcaAdet,
                        CeldiriciAdet = CeldiriciAdet,
                        ResimBoyut = ResimBoyut
                    };
                    soruCreater.Construct(builder);
                    Add(new KurBulUySoru3(builder.Soru));
                }
                testDetail.Dispose();
            }
        }
    }
}
