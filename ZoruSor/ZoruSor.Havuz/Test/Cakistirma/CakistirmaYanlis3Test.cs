using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.DataAccess.ObjectBinding;
using ZoruSor.Lib.Havuz;
using ZoruSor.Lib.Soru;
using ZoruSor.Lib.TestSoru.Cakistirma;

namespace ZoruSor.Lib.Test.Cakistirma
{
    [DisplayName("Cakistirma Dogru")]
    [HighlightedClass]
    public class CakistirmaYanlis3Test : BaseTest
    {
        private const int SayfadakiSoruAdet = 1;
        private const int CeldiriciAdet = 8;
        private const int ResimBoyut = 570;

        [HighlightedMember]
        public CakistirmaYanlis3Test(Havuz.Havuz havuz, int zorlukDerece, int sabitParcaAdet, int sayfaAdet)
        {
            for (int i = 0; i < 1 * sayfaAdet; i++)
            {
                var soruCreater = new SoruCreater();
                SoruBuilder builder = new CakistirmaYanlisBul
                {
                    Havuz = havuz,
                    ZorlukDerece = zorlukDerece,
                    SabitParcaAdet = sabitParcaAdet,
                    CeldiriciAdet = 8,
                    ResimBoyut = 570
                };
                soruCreater.Construct(builder);
                Add(new Cakistirma3Soru(builder.Soru));
            }
        }
        public CakistirmaYanlis3Test(IEnumerable<TestDetail> testDetails)
        {
            foreach (var testDetail in testDetails)
            {

                for (int i = 0; i < SayfadakiSoruAdet * testDetail.SayfaAdet; i++)
                {
                    var soruCreater = new SoruCreater();
                    SoruBuilder builder = new CakistirmaYanlisBul{
                        Havuz = testDetail.Havuz,
                        ZorlukDerece = testDetail.Zorluk,
                        SabitParcaAdet = testDetail.SabitParcaAdet,
                        CeldiriciAdet = CeldiriciAdet,
                        ResimBoyut = ResimBoyut
                    };
                    soruCreater.Construct(builder);
                    Add(new Cakistirma3Soru(builder.Soru));
                }
                testDetail.Dispose();
            }
        }
    }
}
