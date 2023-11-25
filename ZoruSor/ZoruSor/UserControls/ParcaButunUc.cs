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
    public partial class ParcaButunUc : BaseSoruUi
    {
        public ParcaButunUc(Havuz havuz, string soruTip, int zorlukDerece, int sabitParca, BaseSoru testSoru, int soruId)
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
            ReferansResim.Image = Soru.ReferansResimList[0].Image;

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
        }

        private BaseSoru ParcadanButuneUret()
        {
            var soruCreater = new SoruCreater();
            SoruBuilder builder = new Lib.Soru.ParcadanButune1
            {
                Havuz = SeciliHavuz,
                ZorlukDerece = ZorlukDerece,
                SabitParcaAdet = SabitParca,
                CeldiriciAdet = CeldiriciAdet,
                ResimBoyut = ResimBoyut
            };
            soruCreater.Construct(builder);
            if (TestSoru.GetType() == typeof(ParcaButunSoru1))
            {
                return new ParcaButunSoru1(builder.Soru);
            }
            if (TestSoru.GetType() == typeof(ParcaButunSoru2))
            {
                return new ParcaButunSoru2(builder.Soru);
            }
            return null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (SoruTip == "Parçadan Bütüne")
            {
                TestSoru = ParcadanButuneUret();
            }

            Soru = TestSoru.Soru;
            SetImages();
        }
    }
}
