using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.DataAccess.ObjectBinding;
using ZoruSor.Lib.Havuz;
using ZoruSor.Lib.Soru;
using ZoruSor.Lib.TestSoru;

namespace ZoruSor.Lib.Test.Melez
{
    [DisplayName("Melez Ikili 1")]
    [HighlightedClass]
    public class MelezIkiliTest1 : BaseTest
    {
        private const int SayfadakiSoruAdet = 7;
        private const int CeldiriciAdet = 4;
        private const int ResimBoyut = 185;

        [HighlightedMember]
        public MelezIkiliTest1(Havuz.Havuz havuz, string resim1Formul, string resim2Formul
            , int zorlukDerece, int sabitParcaAdet, int sayfaAdet)
        {

            for (int i = 0; i < SayfadakiSoruAdet * sayfaAdet; i++)
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
                Add(new MelezIkili1Soru(builder.Soru));
            }
        }

        public MelezIkiliTest1(List<MelezIkili1Soru> soruList)
        {
            soruList.ForEach(Add);
        }
        public MelezIkiliTest1(IEnumerable<TestDetail> testDetails)
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
                    Add(new MelezIkili1Soru(builder.Soru));
                }
                testDetail.Dispose();
            }
        }
    }
}
