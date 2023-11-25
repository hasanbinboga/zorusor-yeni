using System;
using System.Windows.Forms;
using ZoruSor.Lib.Havuz;
using ZoruSor.Lib.Soru;
using ZoruSor.Lib.TestSoru;

namespace ZoruSor.UserControls
{
    public partial class AynisiniBulUc : BaseSoruUi
    {

        private void SetImages()
        {
            ReferansResim.Image = Soru.ReferansResimList[0].Image;
            DogruCevap.Image = Soru.DogruCevapList[0].Image;
            soruNoLabel.Text = (SoruId + 1).ToString();
            celdiriciLayoutPanel.ColumnStyles.Clear();
            celdiriciLayoutPanel.Controls.Clear();
            celdiriciLayoutPanel.ColumnCount = CeldiriciAdet;
            for (int i = 0; i < CeldiriciAdet; i++)
            {
                celdiriciLayoutPanel.ColumnStyles.Add(new ColumnStyle() { SizeType = SizeType.Absolute, Width = 150 });
                var celdiriciImg = new PictureBox
                {
                    Image = Soru.CeldiriciList[i].Image,
                    Name = "celdiriciImg" + i,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Width = 150,
                    Height = 150
                };
                celdiriciLayoutPanel.Controls.Add(celdiriciImg, i, 0);
            }
            celdiriciLayoutPanel.AutoScroll = false;
            celdiriciLayoutPanel.Refresh();
            celdiriciLayoutPanel.AutoScroll = true;
        }


        public AynisiniBulUc(Havuz havuz, string soruTip, int zorlukDerece, int sabitParca, BaseSoru testSoru, int soruId)
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

        private BaseSoru AynisiniBulUret()
        {
            var soruCreater = new SoruCreater();
            SoruBuilder builder = new Lib.Soru.AynisiniBul
            {
                Havuz = SeciliHavuz,
                ZorlukDerece = ZorlukDerece,
                SabitParcaAdet = SabitParca,
                CeldiriciAdet = CeldiriciAdet,
                ResimBoyut = ResimBoyut
            };
            soruCreater.Construct(builder);
            if (TestSoru.GetType() == typeof(AynisiniBulSoru1))
            {
                return new AynisiniBulSoru1(builder.Soru);
            }
            if (TestSoru.GetType() == typeof(AynisiniBulSoru2))
            {
                return new AynisiniBulSoru2(builder.Soru);
            }
            return null;
        }

        private BaseSoru FarklisiniBulUret()
        {
            var soruCreater = new SoruCreater();
            SoruBuilder builder = new Lib.Soru.FarklisiniBul
            {
                Havuz = SeciliHavuz,
                ZorlukDerece = ZorlukDerece,
                SabitParcaAdet = SabitParca,
                CeldiriciAdet = CeldiriciAdet,
                ResimBoyut = ResimBoyut
            };
            soruCreater.Construct(builder);
            if (TestSoru.GetType() == typeof(AynisiniBulSoru1))
            {
                return new AynisiniBulSoru1(builder.Soru);
            }
            if (TestSoru.GetType() == typeof(AynisiniBulSoru2))
            {
                return new AynisiniBulSoru2(builder.Soru);
            }
            return null;
        }

        private BaseSoru FarkliElemanUret()
        {
            var soruCreater = new SoruCreater();
            SoruBuilder builder = new FarkliEleman
            {
                Havuz = SeciliHavuz,
                ZorlukDerece = ZorlukDerece,
                SabitParcaAdet = SabitParca,
                CeldiriciAdet = CeldiriciAdet,
                ResimBoyut = ResimBoyut
            };
            soruCreater.Construct(builder);
            if (TestSoru.GetType() == typeof(AynisiniBulSoru1))
            {
                return new AynisiniBulSoru1(builder.Soru);
            }
            if (TestSoru.GetType() == typeof(AynisiniBulSoru2))
            {
                return new AynisiniBulSoru2(builder.Soru);
            }
            return null;
        }

        private BaseSoru TumuFarkliElemanUret()
        {
            var soruCreater = new SoruCreater();
            SoruBuilder builder = new TumuFarkliEleman
            {
                Havuz = SeciliHavuz,
                ZorlukDerece = ZorlukDerece,
                SabitParcaAdet = SabitParca,
                CeldiriciAdet = CeldiriciAdet,
                ResimBoyut = ResimBoyut
            };
            soruCreater.Construct(builder);
            if (TestSoru.GetType() == typeof(AynisiniBulSoru1))
            {
                return new AynisiniBulSoru1(builder.Soru);
            }
            if (TestSoru.GetType() == typeof(AynisiniBulSoru2))
            {
                return new AynisiniBulSoru2(builder.Soru);
            }
            return null;
        }

        private BaseSoru OrtakElemanUret()
        {
            var soruCreater = new SoruCreater();
            SoruBuilder builder = new OrtakEleman
            {
                Havuz = SeciliHavuz,
                ZorlukDerece = ZorlukDerece,
                SabitParcaAdet = SabitParca,
                CeldiriciAdet = CeldiriciAdet,
                ResimBoyut = ResimBoyut
            };
            soruCreater.Construct(builder);
            if (TestSoru.GetType() == typeof(AynisiniBulSoru1))
            {
                return new AynisiniBulSoru1(builder.Soru);
            }
            if (TestSoru.GetType() == typeof(AynisiniBulSoru2))
            {
                return new AynisiniBulSoru2(builder.Soru);
            }
            return null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (SoruTip)
            {
                case "Aynısını Bul":
                    TestSoru = AynisiniBulUret();
                    break;
                case "Farklısını Bul":
                    TestSoru = FarklisiniBulUret();
                    break;
                case "Farklı Eleman":
                    TestSoru = FarkliElemanUret();
                    break;
                case "Ortak Eleman":
                    TestSoru = OrtakElemanUret();
                    break;
                case "Tümü Farklı Eleman":
                    TestSoru = TumuFarkliElemanUret();
                    break;
            }


            Soru = TestSoru.Soru;
            SetImages();
        }
    }
}
