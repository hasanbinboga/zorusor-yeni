using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.DataAccess.ObjectBinding;
using ZoruSor.Lib.Havuz;
using ZoruSor.Lib.Soru;
using ZoruSor.Lib.TestSoru;
using ZoruSor.Lib.TestSoru.DondurCakistir;

namespace ZoruSor.Lib.Test.Donusum
{
    [DisplayName("Dönüşüm 11")]
    [HighlightedClass]
    public class Donusum11Test : BaseTest
    {
        private const int SayfadakiSoruAdet = 4;
        private const int CeldiriciAdet = 7;
        private const int ResimBoyut = 135;
        [HighlightedMember]
        public Donusum11Test(Havuz.Havuz havuz, int zorlukDerece, int sabitParcaAdet, int sayfaAdet)
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
                Add(new Donusum1Soru1(builder.Soru));
            }
        }

        public Donusum11Test(IEnumerable<TestDetail> testDetails)
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
                    Add(new Donusum1Soru1(builder.Soru));
                }
                testDetail.Dispose();
            }
        }
    }
}
