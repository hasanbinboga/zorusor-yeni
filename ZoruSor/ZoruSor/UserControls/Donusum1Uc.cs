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
    public partial class Donusum1Uc : BaseSoruUi
    {
        private void SetImages()
        {
            ReferansResim.Image = Soru.ReferansResimList[0].Image;
            DonusumResim.Image = Soru.ReferansResimList[1].Image;
            DogruCevap.Image = Soru.DogruCevapList[0].Image;
            soruNoLabel.Text = (SoruId + 1).ToString();
            celdiriciLayoutPanel.ColumnStyles.Clear();
            celdiriciLayoutPanel.Controls.Clear();
            celdiriciLayoutPanel.ColumnCount = CeldiriciAdet;
            for (int i = 0; i < CeldiriciAdet; i++)
            {
                celdiriciLayoutPanel.ColumnStyles.Add(new ColumnStyle { SizeType = SizeType.Absolute, Width = 150 });
                var celdiriciImg = new PictureBox
                {
                    Image = Soru.CeldiriciList[i].Image,
                    Name = "celdiriciImg" + i,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Width = 150,
                    Height = 150
                };
                celdiriciLayoutPanel.Controls.Add(celdiriciImg, i, 1);
            }
            celdiriciLayoutPanel.AutoScroll = false;
            celdiriciLayoutPanel.Refresh();
            celdiriciLayoutPanel.AutoScroll = true;
        }

        public Donusum1Uc(Havuz havuz, string soruTip, int zorlukDerece, int sabitParca, BaseSoru testSoru, int soruId)
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
        private BaseSoru Donusum1Uret()
        {
            var soruCreater = new SoruCreater();
            SoruBuilder builder = new Donusum
            {
                Havuz = SeciliHavuz,
                ZorlukDerece = ZorlukDerece,
                SabitParcaAdet = SabitParca,
                CeldiriciAdet = CeldiriciAdet,
                ResimBoyut = ResimBoyut
            };
            soruCreater.Construct(builder);
            if (TestSoru.GetType() == typeof(Donusum1Soru1))
            {
                return new Donusum1Soru1(builder.Soru);
            }
            if (TestSoru.GetType() == typeof(Donusum1Soru2))
            {
                return new Donusum1Soru2(builder.Soru);
            }
            return null;
        }

        //Soru tipi belirtilmemis
        private BaseSoru Donusum2Uret()
        {
            var soruCreater = new SoruCreater();
            SoruBuilder builder = new DonusumYeni
            {
                Havuz = SeciliHavuz,
                ZorlukDerece = ZorlukDerece,
                SabitParcaAdet = SabitParca,
                CeldiriciAdet = CeldiriciAdet,
                ResimBoyut = ResimBoyut
            };
            soruCreater.Construct(builder);
            if (TestSoru.GetType() == typeof(Donusum1Soru1))
            {
                return new Donusum1Soru1(builder.Soru);
            }
            if (TestSoru.GetType() == typeof(Donusum1Soru2))
            {
                return new Donusum1Soru2(builder.Soru);
            }
            return null;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            switch (SoruTip)
            {
                case "Dönüşüm 1":
                    TestSoru = Donusum1Uret();
                    break;
            }


            Soru = TestSoru.Soru;
            SetImages();
        }
    }
}
