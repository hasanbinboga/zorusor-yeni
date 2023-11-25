using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.DataAccess.ObjectBinding;
using ZoruSor.Lib.Havuz;
using ZoruSor.Lib.Soru;
using ZoruSor.Lib.TestSoru;

namespace ZoruSor.Lib.Test.Melez
{
    [DisplayName("Melez Uclu 2")]
    [HighlightedClass]
    public class MelezUcluTest2 : BaseTest
    {
        private const int SayfadakiSoruAdet = 2;
        private const int CeldiriciAdet = 3;
        private const int ResimBoyut = 350;

        [HighlightedMember]
        public MelezUcluTest2(Havuz.Havuz havuz, string resim1Formul, string resim2Formul, string resim3Formul
            , int zorlukDerece, int sabitParcaAdet, int sayfaAdet)
        {

            for (int i = 0; i < SayfadakiSoruAdet * sayfaAdet; i++)
            {
                var soruCreater = new SoruCreater();
                SoruBuilder builder = new MelezUclu
                {
                    Havuz = havuz,
                    ZorlukDerece = zorlukDerece,
                    SabitParcaAdet = sabitParcaAdet,
                    CeldiriciAdet = CeldiriciAdet,
                    ResimBoyut = ResimBoyut,
                    Resim1Formul = resim1Formul,
                    Resim2Formul = resim2Formul,
                    Resim3Formul = resim3Formul};
                soruCreater.Construct(builder);
                Add(new MelezUclu1Soru(builder.Soru));
            }
        }

        public MelezUcluTest2(List<MelezUclu1Soru> soruList)
        {
            soruList.ForEach(Add);
        }

        public MelezUcluTest2(IEnumerable<TestDetail> testDetails)
        {
            foreach (var testDetail in testDetails)
            {
                for (int i = 0; i < SayfadakiSoruAdet * testDetail.SayfaAdet; i++)
                {
                    var soruCreater = new SoruCreater();
                    SoruBuilder builder = new MelezUclu
                    {
                        Havuz = testDetail.Havuz,
                        ZorlukDerece = testDetail.Zorluk,
                        SabitParcaAdet = testDetail.SabitParcaAdet,
                        CeldiriciAdet = CeldiriciAdet,
                        ResimBoyut = ResimBoyut,
                        Resim1Formul = testDetail.Resim1Formul,
                        Resim2Formul = testDetail.Resim2Formul,
                        Resim3Formul = testDetail.Resim3Formul
                    };
                    soruCreater.Construct(builder);
                    Add(new MelezUclu1Soru(builder.Soru));
                }
                testDetail.Dispose();
            }
        }
    }
}
