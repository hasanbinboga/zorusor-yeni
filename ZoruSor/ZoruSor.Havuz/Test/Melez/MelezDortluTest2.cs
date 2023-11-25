using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.DataAccess.ObjectBinding;
using ZoruSor.Lib.Havuz;
using ZoruSor.Lib.Soru;
using ZoruSor.Lib.TestSoru;

namespace ZoruSor.Lib.Test.Melez
{
    [DisplayName("Melez Dortlu 2")]
    [HighlightedClass]
    public class MelezDortluTest2 : BaseTest
    {
        private const int SayfadakiSoruAdet = 1;
        private const int CeldiriciAdet = 11;
        private const int ResimBoyut = 350;

        [HighlightedMember]
        public MelezDortluTest2(Havuz.Havuz havuz, string resim1Formul, string resim2Formul, string resim3Formul, 
            string resim4Formul, int zorlukDerece, int sabitParcaAdet, int sayfaAdet)
        {

            for (int i = 0; i < SayfadakiSoruAdet * sayfaAdet; i++)
            {
                var soruCreater = new SoruCreater();
                SoruBuilder builder = new MelezDortlu
                {
                    Havuz = havuz,
                    ZorlukDerece = zorlukDerece,
                    SabitParcaAdet = sabitParcaAdet,
                    CeldiriciAdet = CeldiriciAdet,
                    ResimBoyut = ResimBoyut,
                    Resim1Formul = resim1Formul,
                    Resim2Formul = resim2Formul,
                    Resim3Formul = resim3Formul,
                    Resim4Formul = resim4Formul};
                soruCreater.Construct(builder);
                Add(new MelezDortlu2Soru(builder.Soru));
            }
        }

        public MelezDortluTest2(List<MelezDortlu2Soru> soruList)
        {
            soruList.ForEach(Add);
        }

        public MelezDortluTest2(IEnumerable<TestDetail> testDetails)
        {
            foreach (var testDetail in testDetails)
            {
                for (int i = 0; i < SayfadakiSoruAdet * testDetail.SayfaAdet; i++)
                {
                    var soruCreater = new SoruCreater();
                    SoruBuilder builder = new MelezDortlu
                    {
                        Havuz = testDetail.Havuz,
                        ZorlukDerece = testDetail.Zorluk,
                        SabitParcaAdet = testDetail.SabitParcaAdet,
                        CeldiriciAdet = CeldiriciAdet,
                        ResimBoyut = ResimBoyut,
                        Resim1Formul = testDetail.Resim1Formul,
                        Resim2Formul = testDetail.Resim2Formul,
                        Resim3Formul = testDetail.Resim3Formul,
                        Resim4Formul = testDetail.Resim4Formul
                    };
                    soruCreater.Construct(builder);
                    Add(new MelezDortlu2Soru(builder.Soru));
                }
                testDetail.Dispose();
            }
        }
    }
}
