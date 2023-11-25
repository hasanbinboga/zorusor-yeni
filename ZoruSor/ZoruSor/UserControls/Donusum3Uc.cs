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
    public partial class Donusum3Uc : BaseSoruUi
    {

        private void SetImages()
        {
            DonusumResim.Image = Soru.ReferansResimList[0].Image;
            DogruCevap.Image = Soru.DogruCevapList[0].Image;
            soruNoLabel.Text = (SoruId + 1).ToString();
            celdiriciLayoutPanel.ColumnStyles.Clear();
            celdiriciLayoutPanel.Controls.Clear();
            celdiriciLayoutPanel.ColumnCount = CeldiriciAdet % 2 == 1 ? CeldiriciAdet / 2 + 1 : CeldiriciAdet / 2;

            for (int i = 0; i < CeldiriciAdet; i++)
            {
                celdiriciLayoutPanel.ColumnStyles.Add(new ColumnStyle { SizeType = SizeType.Absolute, Width = 323 });
                var celdiriciImg = new PictureBox
                {
                    Image = Soru.CeldiriciList[i].Image,
                    Name = "celdiriciImg" + i,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Width = 323,
                    Height = 150
                };
                var satir = i < CeldiriciAdet / 2 ? 1 : 2;
                var sutun = i - ((satir - 1) * CeldiriciAdet / 2);
                celdiriciLayoutPanel.Controls.Add(celdiriciImg, sutun, satir);
            }
            celdiriciLayoutPanel.AutoScroll = false;
            celdiriciLayoutPanel.Refresh();
            celdiriciLayoutPanel.AutoScroll = true;
        }


        public Donusum3Uc(Havuz havuz, string soruTip, int zorlukDerece, int sabitParca, BaseSoru testSoru, int soruId)
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

        //Soru tipi belirtilmemis
        private BaseSoru Donusum2Uret()
        {
            var soruCreater = new SoruCreater();
            SoruBuilder builder = new Lib.Soru.Donusum2
            {
                Havuz = SeciliHavuz,
                ZorlukDerece = ZorlukDerece,
                SabitParcaAdet = SabitParca,
                CeldiriciAdet = CeldiriciAdet,
                ResimBoyut = ResimBoyut
            };
            soruCreater.Construct(builder);

            if (TestSoru.GetType() == typeof(Donusum3Soru))
            {
                return new Donusum3Soru(builder.Soru);
            }
            return null;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            switch (SoruTip)
            {
                case "Dönüşüm 2":
                    TestSoru = Donusum2Uret();
                    break;
            }


            Soru = TestSoru.Soru;
            SetImages();
        }
    }
}
