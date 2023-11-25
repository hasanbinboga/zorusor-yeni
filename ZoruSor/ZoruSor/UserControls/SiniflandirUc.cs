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
    public partial class SiniflandirUc : BaseSoruUi
    {
        public SiniflandirUc(Havuz havuz, string soruTip, int zorlukDerece, int sabitParca, BaseSoru testSoru, int soruId)
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
                ResimBoyut = Soru.ReferansResimList[0].Image.Width;
                CeldiriciAdet = Soru.CeldiriciList.Count;
            }
            InitializeComponent();

            SetImages();
        }
        private void SetImages()
        {
            referansResim1.Image = Soru.ReferansResimList[0].Image;
            referansResim2.Image = Soru.ReferansResimList[1].Image;
            referansResim3.Image = Soru.ReferansResimList[2].Image;
            referansResim4.Image = Soru.ReferansResimList[3].Image;
            referansResim5.Image = Soru.ReferansResimList[4].Image;
            if (Soru.ReferansResimList.Count == 6)
            {
                referansResim6.Image = Soru.ReferansResimList[5].Image;
            }
            if (Soru.ReferansResimList.Count == 7)
            {
                referansResim6.Image = Soru.ReferansResimList[5].Image;
                referansResim7.Image = Soru.ReferansResimList[6].Image;
            }

            DogruCevap.Image = Soru.DogruCevapList[0].Image;

            soruNoLabel.Text = (SoruId + 1).ToString();

            Celdirici1.Image = Soru.CeldiriciList[0].Image;
            Celdirici2.Image = Soru.CeldiriciList[1].Image;
            Celdirici3.Image = Soru.CeldiriciList[2].Image;
            Celdirici4.Image = Soru.CeldiriciList[3].Image;
            Celdirici5.Image = Soru.CeldiriciList[4].Image;
            Celdirici6.Image = Soru.CeldiriciList[5].Image;
        }

        private BaseSoru SiniflandirBesli1Uret()
        {
            var soruCreater = new SoruCreater();
            SoruBuilder builder = new Lib.Soru.SinifBesli1
            {
                Havuz = SeciliHavuz,
                ZorlukDerece = ZorlukDerece,
                SabitParcaAdet = SabitParca,
                CeldiriciAdet = CeldiriciAdet,
                ResimBoyut = ResimBoyut
            };
            soruCreater.Construct(builder);
            if (TestSoru.GetType() == typeof(SinifBesliSoru1))
            {
                return new SinifBesliSoru1(builder.Soru);
            }
            return null;
        }
        private BaseSoru SiniflandirBesli2Uret()
        {
            var soruCreater = new SoruCreater();
            SoruBuilder builder = new Lib.Soru.SinifBesli2
            {
                Havuz = SeciliHavuz,
                ZorlukDerece = ZorlukDerece,
                SabitParcaAdet = SabitParca,
                CeldiriciAdet = CeldiriciAdet,
                ResimBoyut = ResimBoyut
            };
            soruCreater.Construct(builder);
            if (TestSoru.GetType() == typeof(SinifBesliSoru1))
            {
                return new SinifBesliSoru1(builder.Soru);
            }
            return null;
        }

        private BaseSoru SiniflandirBesli3Uret()
        {
            var soruCreater = new SoruCreater();
            SoruBuilder builder = new Lib.Soru.SinifBesli3
            {
                Havuz = SeciliHavuz,
                ZorlukDerece = ZorlukDerece,
                SabitParcaAdet = SabitParca,
                CeldiriciAdet = CeldiriciAdet,
                ResimBoyut = ResimBoyut
            };
            soruCreater.Construct(builder);
            if (TestSoru.GetType() == typeof(SinifBesliSoru1))
            {
                return new SinifBesliSoru1(builder.Soru);
            }
            return null;
        }

        private BaseSoru SiniflandirAlti1Uret()
        {
            var soruCreater = new SoruCreater();
            SoruBuilder builder = new Lib.Soru.SinifAlti1
            {
                Havuz = SeciliHavuz,
                ZorlukDerece = ZorlukDerece,
                SabitParcaAdet = SabitParca,
                CeldiriciAdet = CeldiriciAdet,
                ResimBoyut = ResimBoyut
            };
            soruCreater.Construct(builder);
            if (TestSoru.GetType() == typeof(SinifAltiliSoru1))
            {
                return new SinifAltiliSoru1(builder.Soru);
            }
            return null;
        }
        private BaseSoru SiniflandirAlti2Uret()
        {
            var soruCreater = new SoruCreater();
            SoruBuilder builder = new Lib.Soru.SinifAlti2
            {
                Havuz = SeciliHavuz,
                ZorlukDerece = ZorlukDerece,
                SabitParcaAdet = SabitParca,
                CeldiriciAdet = CeldiriciAdet,
                ResimBoyut = ResimBoyut
            };
            soruCreater.Construct(builder);
            if (TestSoru.GetType() == typeof(SinifAltiliSoru1))
            {
                return new SinifAltiliSoru1(builder.Soru);
            }
            return null;
        }

        private BaseSoru SiniflandirAlti3Uret()
        {
            var soruCreater = new SoruCreater();
            SoruBuilder builder = new Lib.Soru.SinifAlti3
            {
                Havuz = SeciliHavuz,
                ZorlukDerece = ZorlukDerece,
                SabitParcaAdet = SabitParca,
                CeldiriciAdet = CeldiriciAdet,
                ResimBoyut = ResimBoyut
            };
            soruCreater.Construct(builder);
            if (TestSoru.GetType() == typeof(SinifAltiliSoru1))
            {
                return new SinifAltiliSoru1(builder.Soru);
            }
            return null;
        }

        private BaseSoru SiniflandirYedi1Uret()
        {
            var soruCreater = new SoruCreater();
            SoruBuilder builder = new Lib.Soru.SinifYedi1
            {
                Havuz = SeciliHavuz,
                ZorlukDerece = ZorlukDerece,
                SabitParcaAdet = SabitParca,
                CeldiriciAdet = CeldiriciAdet,
                ResimBoyut = ResimBoyut
            };
            soruCreater.Construct(builder);
            if (TestSoru.GetType() == typeof(SinifYediliSoru1))
            {
                return new SinifYediliSoru1(builder.Soru);
            }
            return null;
        }
        private BaseSoru SiniflandirYedi2Uret()
        {
            var soruCreater = new SoruCreater();
            SoruBuilder builder = new Lib.Soru.SinifYedi2
            {
                Havuz = SeciliHavuz,
                ZorlukDerece = ZorlukDerece,
                SabitParcaAdet = SabitParca,
                CeldiriciAdet = CeldiriciAdet,
                ResimBoyut = ResimBoyut
            };
            soruCreater.Construct(builder);
            if (TestSoru.GetType() == typeof(SinifYediliSoru1))
            {
                return new SinifYediliSoru1(builder.Soru);
            }
            return null;
        }
        private BaseSoru SiniflandirYedi3Uret()
        {
            var soruCreater = new SoruCreater();
            SoruBuilder builder = new Lib.Soru.SinifYedi3
            {
                Havuz = SeciliHavuz,
                ZorlukDerece = ZorlukDerece,
                SabitParcaAdet = SabitParca,
                CeldiriciAdet = CeldiriciAdet,
                ResimBoyut = ResimBoyut
            };
            soruCreater.Construct(builder);
            if (TestSoru.GetType() == typeof(SinifYediliSoru1))
            {
                return new SinifYediliSoru1(builder.Soru);
            }
            return null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (SoruTip == "Sınıflandırma 1")
            {
                TestSoru = SiniflandirBesli1Uret();
            }
            if (SoruTip == "Sınıflandırma 2")
            {
                TestSoru = SiniflandirBesli2Uret();
            }
            if (SoruTip == "Sınıflandırma 3")
            {
                TestSoru = SiniflandirBesli3Uret();
            }
            if (SoruTip == "Sınıflandırma 6 lı 1")
            {
                TestSoru = SiniflandirAlti1Uret();
            }
            if (SoruTip == "Sınıflandırma 6 lı 2")
            {
                TestSoru = SiniflandirAlti2Uret();
            }
            if (SoruTip == "Sınıflandırma 6 lı 3")
            {
                TestSoru = SiniflandirAlti3Uret();
            }
            if (SoruTip == "Sınıflandırma 7 li 1")
            {
                TestSoru = SiniflandirYedi1Uret();
            }
            if (SoruTip == "Sınıflandırma 7 li 2")
            {
                TestSoru = SiniflandirYedi2Uret();
            }
            if (SoruTip == "Sınıflandırma 7 li 3")
            {
                TestSoru = SiniflandirYedi3Uret();
            }

            Soru = TestSoru.Soru;
            SetImages();
        }
    }
}
