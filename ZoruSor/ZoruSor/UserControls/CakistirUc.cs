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
    public partial class CakistirUc : BaseSoruUi
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
                celdiriciLayoutPanel.ColumnStyles.Add(new ColumnStyle() {SizeType = SizeType.Absolute, Width = 150});
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

        public CakistirUc(Havuz havuz, string soruTip, int zorlukDerece, int sabitParca, BaseSoru testSoru, int soruId)
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

        private BaseSoru CakistirDogruBul()
        {
            var soruCreater = new SoruCreater();
            SoruBuilder builder = new CakistirmaDogruBul
            {
                Havuz = SeciliHavuz,
                ZorlukDerece = ZorlukDerece,
                SabitParcaAdet = SabitParca,
                CeldiriciAdet = CeldiriciAdet,
                ResimBoyut = ResimBoyut
            };
            soruCreater.Construct(builder);
            if (TestSoru.GetType() == typeof(Cakistirma1Soru))
            {
                return new Cakistirma1Soru(builder.Soru);
            }
            if (TestSoru.GetType() == typeof(Cakistirma2Soru))
            {
                return new Cakistirma2Soru(builder.Soru);
            }
            return null;
        }

        private BaseSoru CakistirYanlisBul()
        {
            var soruCreater = new SoruCreater();
            SoruBuilder builder = new CakistirmaYanlisBul
            {
                Havuz = SeciliHavuz,
                ZorlukDerece = ZorlukDerece,
                SabitParcaAdet = SabitParca,
                CeldiriciAdet = CeldiriciAdet,
                ResimBoyut = ResimBoyut
            };
            soruCreater.Construct(builder);
            if (TestSoru.GetType() == typeof(Cakistirma1Soru))
            {
                return new Cakistirma1Soru(builder.Soru);
            }
            if (TestSoru.GetType() == typeof(Cakistirma2Soru))
            {
                return new Cakistirma2Soru(builder.Soru);
            }
            return null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (SoruTip)
            {
                case "Çakıştırma Doğruyu Bul":
                    TestSoru = CakistirDogruBul();
                    break;
                case "Çakıştırma Yanlışı Bul":
                    TestSoru = CakistirYanlisBul();
                    break;
            }


            Soru = TestSoru.Soru;
            SetImages();
        }
    }

}
