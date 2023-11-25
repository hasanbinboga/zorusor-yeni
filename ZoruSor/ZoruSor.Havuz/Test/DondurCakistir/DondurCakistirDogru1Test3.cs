using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.DataAccess.ObjectBinding;
using ZoruSor.Lib.Havuz;
using ZoruSor.Lib.Soru;
using ZoruSor.Lib.TestSoru.DondurCakistir;

namespace ZoruSor.Lib.Test.DondurCakistir
{
    [DisplayName("Döndür Bul Uygula 1")]
    [HighlightedClass]
    public class DondurCakistirDogru1Test3 : BaseTest
    {

        private const int SayfadakiSoruAdet = 3;
        private const int CeldiriciAdet = 7;
        private const int ResimBoyut = 270;

        [HighlightedMember]
        public DondurCakistirDogru1Test3(Havuz.Havuz havuz, int zorlukDerece, int sabitParcaAdet, int sayfaAdet)
        {
            for (int i = 0; i < SayfadakiSoruAdet * sayfaAdet; i++)
            {
                var soruCreater = new SoruCreater();
                SoruBuilder builder = new DondurCakistirDogruBul1
                {
                    Havuz = havuz,
                    ZorlukDerece = zorlukDerece,
                    SabitParcaAdet = sabitParcaAdet,
                    CeldiriciAdet = CeldiriciAdet,
                    ResimBoyut = ResimBoyut};
                soruCreater.Construct(builder);
                Add(new DondurCakistirSoru3(builder.Soru));
            }
        }

        public DondurCakistirDogru1Test3(IEnumerable<TestDetail> testDetails)
        {
            foreach (var testDetail in testDetails)
            {

                for (int i = 0; i < SayfadakiSoruAdet * testDetail.SayfaAdet; i++)
                {
                    var soruCreater = new SoruCreater();
                    SoruBuilder builder = new DondurCakistirDogruBul1
                    {
                        Havuz = testDetail.Havuz,
                        ZorlukDerece = testDetail.Zorluk,
                        SabitParcaAdet = testDetail.SabitParcaAdet,
                        CeldiriciAdet = CeldiriciAdet,
                        ResimBoyut = ResimBoyut
                    };
                    soruCreater.Construct(builder);
                    Add(new DondurCakistirSoru3(builder.Soru));
                }
                testDetail.Dispose();
            }
        }


    }
}
