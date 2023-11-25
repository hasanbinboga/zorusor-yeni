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
    public partial class KurBulUygula1Uc : BaseSoruUi
    {
        public KurBulUygula1Uc(Havuz havuz, string soruTip, int zorlukDerece, int sabitParca, BaseSoru testSoru, int soruId)
        {
            SeciliHavuz = havuz;
            ZorlukDerece = zorlukDerece;
            SabitParca = sabitParca;
            SoruId = soruId;
            SoruTip = soruTip;
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
            ReferansResim3.Image = Soru.ReferansResimList[2].Image;
            ReferansResim4.Image = Soru.ReferansResimList[3].Image;
            

            DogruCevap.Image = Soru.DogruCevapList[0].Image;

            soruNoLabel.Text = (SoruId + 1).ToString();
            if (CeldiriciAdet == 3)
            {
                Celdirici1.Image = Soru.CeldiriciList[0].Image;
                Celdirici2.Image = Soru.CeldiriciList[1].Image;
                Celdirici3.Image = Soru.CeldiriciList[2].Image;
            }
            else if (CeldiriciAdet == 8)
            {
                Celdirici1.Image = Soru.CeldiriciList[0].Image;
                Celdirici2.Image = Soru.CeldiriciList[1].Image;
                Celdirici3.Image = Soru.CeldiriciList[2].Image;
                Celdirici4.Image = Soru.CeldiriciList[3].Image;
                Celdirici5.Image = Soru.CeldiriciList[4].Image;
                Celdirici6.Image = Soru.CeldiriciList[5].Image;
                Celdirici7.Image = Soru.CeldiriciList[6].Image;
                Celdirici8.Image = Soru.CeldiriciList[7].Image;
            }
        }

        private BaseSoru KurBulUygula1Uret()
        {
            var soruCreater = new SoruCreater();
            SoruBuilder builder = new Lib.Soru.KuraliBulUygula1()
            {
                Havuz = SeciliHavuz,
                ZorlukDerece = ZorlukDerece,
                SabitParcaAdet = SabitParca,
                CeldiriciAdet = CeldiriciAdet,
                ResimBoyut = ResimBoyut
            };
            soruCreater.Construct(builder);
            if (TestSoru.GetType() == typeof(KurBulUySoru1))
            {
                return new KurBulUySoru1(builder.Soru);
            }
            if (TestSoru.GetType() == typeof(KurBulUySoru2))
            {
                return new KurBulUySoru2(builder.Soru);
            }
            return null;
        }
        private BaseSoru KurBulUygula2Uret()
        {
            var soruCreater = new SoruCreater();
            SoruBuilder builder = new Lib.Soru.KuraliBulUygula2()
            {
                Havuz = SeciliHavuz,
                ZorlukDerece = ZorlukDerece,
                SabitParcaAdet = SabitParca,
                CeldiriciAdet = CeldiriciAdet,
                ResimBoyut = ResimBoyut
            };
            soruCreater.Construct(builder);
            if (TestSoru.GetType() == typeof(KurBulUySoru1))
            {
                return new KurBulUySoru1(builder.Soru);
            }
            if (TestSoru.GetType() == typeof(KurBulUySoru2))
            {
                return new KurBulUySoru2(builder.Soru);
            }
            return null;
        }

        private BaseSoru KurBulUygula3Uret()
        {
            var soruCreater = new SoruCreater();
            SoruBuilder builder = new Lib.Soru.KuraliBulUygula3()
            {
                Havuz = SeciliHavuz,
                ZorlukDerece = ZorlukDerece,
                SabitParcaAdet = SabitParca,
                CeldiriciAdet = CeldiriciAdet,
                ResimBoyut = ResimBoyut
            };
            soruCreater.Construct(builder);
            if (TestSoru.GetType() == typeof(KurBulUySoru1))
            {
                return new KurBulUySoru1(builder.Soru);
            }
            if (TestSoru.GetType() == typeof(KurBulUySoru2))
            {
                return new KurBulUySoru2(builder.Soru);
            }
            return null;
        }

        private BaseSoru Simetrik1Uret()
        {
            var soruCreater = new SoruCreater();
            SoruBuilder builder = new Lib.Soru.SimetrikIliski1()
            {
                Havuz = SeciliHavuz,
                ZorlukDerece = ZorlukDerece,
                SabitParcaAdet = SabitParca,
                CeldiriciAdet = CeldiriciAdet,
                ResimBoyut = ResimBoyut
            };
            soruCreater.Construct(builder);
            if (TestSoru.GetType() == typeof(KurBulUySoru1))
            {
                return new KurBulUySoru1(builder.Soru);
            }
            if (TestSoru.GetType() == typeof(KurBulUySoru2))
            {
                return new KurBulUySoru2(builder.Soru);
            }
            return null;
        }

        private BaseSoru Simetrik2Uret()
        {
            var soruCreater = new SoruCreater();
            SoruBuilder builder = new Lib.Soru.SimetrikIliski2()
            {
                Havuz = SeciliHavuz,
                ZorlukDerece = ZorlukDerece,
                SabitParcaAdet = SabitParca,
                CeldiriciAdet = CeldiriciAdet,
                ResimBoyut = ResimBoyut
            };
            soruCreater.Construct(builder);
            if (TestSoru.GetType() == typeof(KurBulUySoru1))
            {
                return new KurBulUySoru1(builder.Soru);
            }
            if (TestSoru.GetType() == typeof(KurBulUySoru2))
            {
                return new KurBulUySoru2(builder.Soru);
            }
            return null;
        }

        private BaseSoru Simetrik3Uret()
        {
            var soruCreater = new SoruCreater();
            SoruBuilder builder = new Lib.Soru.SimetrikIliski3()
            {
                Havuz = SeciliHavuz,
                ZorlukDerece = ZorlukDerece,
                SabitParcaAdet = SabitParca,
                CeldiriciAdet = CeldiriciAdet,
                ResimBoyut = ResimBoyut
            };
            soruCreater.Construct(builder);
            if (TestSoru.GetType() == typeof(KurBulUySoru1))
            {
                return new KurBulUySoru1(builder.Soru);
            }
            if (TestSoru.GetType() == typeof(KurBulUySoru2))
            {
                return new KurBulUySoru2(builder.Soru);
            }
            return null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (SoruTip == "Kuralı Bul Uygula 1")
            {
                TestSoru = KurBulUygula1Uret();
            }
            else if (SoruTip == "Kuralı Bul Uygula 2")
            {
                TestSoru = KurBulUygula2Uret();
            }
            else if (SoruTip == "Kuralı Bul Uygula 3")
            {
                TestSoru = KurBulUygula3Uret();
            }
            else if (SoruTip == "Simetrik İlişkiler 1")
            {
                TestSoru = Simetrik1Uret();
            }
            else if (SoruTip == "Simetrik İlişkiler 2")
            {
                TestSoru = Simetrik2Uret();
            }
            else if (SoruTip == "Simetrik İlişkiler 3")
            {
                TestSoru = Simetrik3Uret();
            }

            Soru = TestSoru.Soru;
            SetImages();
        }
    }
}
