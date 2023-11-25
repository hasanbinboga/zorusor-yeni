using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZoruSor.Lib.Havuz;
using ZoruSor.Lib.Soru;
using ZoruSor.Lib.TestSoru;

namespace ZoruSor.UserControls
{
    public partial class MelezUc : BaseSoruUi
    {
        protected string Resim1Formul;
        protected string Resim2Formul;
        protected string Resim3Formul;
        protected string Resim4Formul;
        public MelezUc(Havuz havuz, string soruTip, int zorlukDerece, int sabitParca, BaseSoru testSoru, int soruId,
                        string resim1Formul, string resim2Formul, string resim3Formul, string resim4Formul)
        {
            SeciliHavuz = havuz;
            ZorlukDerece = zorlukDerece;
            SabitParca = sabitParca;
            SoruId = soruId;
            SoruTip = soruTip;
            Resim1Formul = resim1Formul;
            Resim2Formul = resim2Formul;
            Resim3Formul = resim3Formul;
            Resim4Formul = resim4Formul;

            if (testSoru != null)
            {
                TestSoru = testSoru;
                Soru = testSoru.Soru;
                ResimBoyut = Soru.DogruCevapList[0].Image.Width;
                CeldiriciAdet = Soru.CeldiriciList.Count;
            }
            InitializeComponent();

            SetImages();
        }
        private void SetImages()
        {
            ReferansResim1.Image = Soru.ReferansResimList[0].Image;
            ReferansResim2.Image = Soru.ReferansResimList[1].Image;
            if (Soru.ReferansResimList.Count == 3)
            {
                ReferansResim3.Image = Soru.ReferansResimList[2].Image;

            }
            else if (Soru.ReferansResimList.Count == 4)
            {
                ReferansResim3.Image = Soru.ReferansResimList[2].Image;
                ReferansResim4.Image = Soru.ReferansResimList[3].Image;
            }

            DogruCevap.Image = Soru.DogruCevapList[0].Image;

            soruNoLabel.Text = (SoruId + 1).ToString();
            if (CeldiriciAdet == 3)
            {
                Celdirici1.Image = Soru.CeldiriciList[0].Image;
                Celdirici2.Image = Soru.CeldiriciList[1].Image;
                Celdirici3.Image = Soru.CeldiriciList[2].Image;
            }
            else if (CeldiriciAdet == 4)
            {
                Celdirici1.Image = Soru.CeldiriciList[0].Image;
                Celdirici2.Image = Soru.CeldiriciList[1].Image;
                Celdirici3.Image = Soru.CeldiriciList[2].Image;
                Celdirici4.Image = Soru.CeldiriciList[3].Image;
            }
            else if (CeldiriciAdet == 11)
            {
                Celdirici1.Image = Soru.CeldiriciList[0].Image;
                Celdirici2.Image = Soru.CeldiriciList[1].Image;
                Celdirici3.Image = Soru.CeldiriciList[2].Image;
                Celdirici4.Image = Soru.CeldiriciList[3].Image;
                Celdirici5.Image = Soru.CeldiriciList[4].Image;
                Celdirici6.Image = Soru.CeldiriciList[5].Image;
                Celdirici7.Image = Soru.CeldiriciList[6].Image;
                Celdirici8.Image = Soru.CeldiriciList[7].Image;
                Celdirici9.Image = Soru.CeldiriciList[8].Image;
                Celdirici10.Image = Soru.CeldiriciList[9].Image;
                Celdirici11.Image = Soru.CeldiriciList[10].Image;
            }
        }

        private BaseSoru MelezIkiliUret()
        {
            var soruCreater = new SoruCreater();
            SoruBuilder builder = new MelezIkili()
            {
                Havuz = SeciliHavuz,
                ZorlukDerece = ZorlukDerece,
                SabitParcaAdet = SabitParca,
                CeldiriciAdet = CeldiriciAdet,
                ResimBoyut = ResimBoyut,
                Resim1Formul = Resim1Formul,
                Resim2Formul = Resim2Formul
            };
            soruCreater.Construct(builder);
            if (TestSoru.GetType() == typeof(MelezIkili1Soru))
            {
                return new MelezIkili1Soru(builder.Soru);
            }
            if (TestSoru.GetType() == typeof(MelezIkili2Soru))
            {
                return new MelezIkili2Soru(builder.Soru);
            }
            if (TestSoru.GetType() == typeof(MelezIkili3Soru))
            {
                return new MelezIkili3Soru(builder.Soru);
            }
            return null;
        }

        private BaseSoru MelezUcluUret()
        {
            var soruCreater = new SoruCreater();
            SoruBuilder builder = new MelezUclu
            {
                Havuz = SeciliHavuz,
                ZorlukDerece = ZorlukDerece,
                SabitParcaAdet = SabitParca,
                CeldiriciAdet = CeldiriciAdet,
                ResimBoyut = ResimBoyut,
                Resim1Formul = Resim1Formul,
                Resim2Formul = Resim2Formul,
                Resim3Formul = Resim3Formul
            };
            soruCreater.Construct(builder);
            if (TestSoru.GetType() == typeof(MelezUclu1Soru))
            {
                return new MelezUclu1Soru(builder.Soru);
            }
            if (TestSoru.GetType() == typeof(MelezUclu2Soru))
            {
                return new MelezUclu2Soru(builder.Soru);
            }
            
            return null;
        }

        private BaseSoru MelezDortluUret()
        {
            var soruCreater = new SoruCreater();
            SoruBuilder builder = new MelezDortlu
            {
                Havuz = SeciliHavuz,
                ZorlukDerece = ZorlukDerece,
                SabitParcaAdet = SabitParca,
                CeldiriciAdet = CeldiriciAdet,
                ResimBoyut = ResimBoyut,
                Resim1Formul = Resim1Formul,
                Resim2Formul = Resim2Formul,
                Resim3Formul = Resim3Formul,
                Resim4Formul = Resim4Formul
            };
            soruCreater.Construct(builder);
            if (TestSoru.GetType() == typeof(MelezDortlu1Soru))
            {
                return new MelezDortlu1Soru(builder.Soru);
            }
            if (TestSoru.GetType() == typeof(MelezDortlu2Soru))
            {
                return new MelezDortlu2Soru(builder.Soru);
            }

            return null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (SoruTip == "Melez İkili")
            {
                TestSoru = MelezIkiliUret();
            }
            else if (SoruTip == "Melez Üçlü")
            {
                TestSoru = MelezUcluUret();
            }
            else if (SoruTip == "Melez Dörtlü")
            {
                TestSoru = MelezDortluUret();
            }
            Soru = TestSoru.Soru;
            SetImages();
        }
    }
}
