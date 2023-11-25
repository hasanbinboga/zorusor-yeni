using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.DataAccess.ObjectBinding;
using ZoruSor.Lib.Havuz;
using ZoruSor.Lib.Soru;
using ZoruSor.Lib.TestSoru;

namespace ZoruSor.Lib.Test.Melez
{
    [DisplayName("Melez Ikili 3")]
    [HighlightedClass]
    public class MelezIkiliTest3 : BaseTest
    {
        private const int SayfadakiSoruAdet = 1;
        private const int CeldiriciAdet = 11;
        private const int ResimBoyut = 350;

        [HighlightedMember]
        public MelezIkiliTest3(Havuz.Havuz havuz, string resim1Formul, string resim2Formul
           , int zorlukDerece, int sabitParcaAdet, int sayfaAdet)
        {

            for (int i = 0; i < SayfadakiSoruAdet* sayfaAdet; i++)
            {
                var soruCreater = new SoruCreater();
                SoruBuilder builder = new MelezIkili
                {
                    Havuz = havuz,
                    ZorlukDerece = zorlukDerece,
                    SabitParcaAdet = sabitParcaAdet,
                    CeldiriciAdet = CeldiriciAdet,
                    ResimBoyut = ResimBoyut,
                    Resim1Formul = resim1Formul,
                    Resim2Formul = resim2Formul
                };
                soruCreater.Construct(builder);
                Add(new MelezIkili3Soru(builder.Soru));
            }
        }

        public MelezIkiliTest3(List<MelezIkili3Soru> soruList)
        {
            soruList.ForEach(Add);
        }

        public MelezIkiliTest3(IEnumerable<TestDetail> testDetails)
        {
            foreach (var testDetail in testDetails)
            {
                for (int i = 0; i < SayfadakiSoruAdet * testDetail.SayfaAdet; i++)
                {
                    var soruCreater = new SoruCreater();
                    SoruBuilder builder = new MelezIkili
                    {
                        Havuz = testDetail.Havuz,
                        ZorlukDerece = testDetail.Zorluk,
                        SabitParcaAdet = testDetail.SabitParcaAdet,
                        CeldiriciAdet = CeldiriciAdet,
                        ResimBoyut = ResimBoyut,
                        Resim1Formul = testDetail.Resim1Formul,
                        Resim2Formul = testDetail.Resim2Formul
                    };
                    soruCreater.Construct(builder);
                    Add(new MelezIkili3Soru(builder.Soru));
                }
                testDetail.Dispose();
            }
        }
    }
}
