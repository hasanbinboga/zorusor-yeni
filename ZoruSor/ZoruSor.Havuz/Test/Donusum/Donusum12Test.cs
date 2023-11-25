using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.DataAccess.ObjectBinding;
using ZoruSor.Lib.Havuz;
using ZoruSor.Lib.Soru;
using ZoruSor.Lib.TestSoru;

namespace ZoruSor.Lib.Test.Donusum
{
    [DisplayName("Dönüşüm 1")]
    [HighlightedClass]
    public class Donusum12Test : BaseTest
    {
        private const int SayfadakiSoruAdet = 2;
        private const int CeldiriciAdet = 8;
        private const int ResimBoyut = 205;

        [HighlightedMember]
        public Donusum12Test(Havuz.Havuz havuz, int zorlukDerece, int sabitParcaAdet, int sayfaAdet)
        {
            for (int i = 0; i < SayfadakiSoruAdet * sayfaAdet; i++)
            {
                var soruCreater = new SoruCreater();
                SoruBuilder builder = new Soru.Donusum
                {
                    Havuz = havuz,
                    ZorlukDerece = zorlukDerece,
                    SabitParcaAdet = sabitParcaAdet,
                    CeldiriciAdet = CeldiriciAdet,
                    ResimBoyut = ResimBoyut

                };
                soruCreater.Construct(builder);
                Add(new Donusum1Soru2(builder.Soru));
            }
        }

        public Donusum12Test(IEnumerable<TestDetail> testDetails)
        {
            foreach (var testDetail in testDetails)
            {

                for (int i = 0; i < SayfadakiSoruAdet * testDetail.SayfaAdet; i++)
                {
                    var soruCreater = new SoruCreater();
                    SoruBuilder builder = new Soru.Donusum
                    {
                        Havuz = testDetail.Havuz,
                        ZorlukDerece = testDetail.Zorluk,
                        SabitParcaAdet = testDetail.SabitParcaAdet,
                        CeldiriciAdet = CeldiriciAdet,
                        ResimBoyut = ResimBoyut
                    };
                    soruCreater.Construct(builder);
                    Add(new Donusum1Soru2(builder.Soru));
                }
                testDetail.Dispose();
            }
        }
    }
}
