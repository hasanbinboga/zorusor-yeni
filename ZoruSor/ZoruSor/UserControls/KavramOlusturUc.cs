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
    public partial class KavramOlusturUc : BaseSoruUi
    {
        public KavramOlusturUc(Havuz havuz, string soruTip, int zorlukDerece, int sabitParca, BaseSoru testSoru, int soruId)
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
            Grup1Resim1.Image = Soru.ReferansResimList[0].Image;
            Grup1Resim2.Image = Soru.ReferansResimList[1].Image;
            Grup1Resim3.Image = Soru.ReferansResimList[2].Image;
            Grup1Resim4.Image = Soru.ReferansResimList[3].Image;

            Grup2Resim1.Image = Soru.ReferansResimList[4].Image;
            Grup2Resim2.Image = Soru.ReferansResimList[5].Image;
            Grup2Resim3.Image = Soru.ReferansResimList[6].Image;
            Grup2Resim4.Image = Soru.ReferansResimList[7].Image;

            DogruCevap.Image = Soru.DogruCevapList[0].Image;

            soruNoLabel.Text = (SoruId + 1).ToString();
            if (CeldiriciAdet == 4)
            {
                Celdirici1.Image = Soru.CeldiriciList[0].Image;
                Celdirici2.Image = Soru.CeldiriciList[1].Image;
                Celdirici3.Image = Soru.CeldiriciList[2].Image;
                Celdirici4.Image = Soru.CeldiriciList[3].Image;
            }
            else if (CeldiriciAdet == 5)
            {
                Celdirici1.Image = Soru.CeldiriciList[0].Image;
                Celdirici2.Image = Soru.CeldiriciList[1].Image;
                Celdirici3.Image = Soru.CeldiriciList[2].Image;
                Celdirici4.Image = Soru.CeldiriciList[3].Image;
                Celdirici5.Image = Soru.CeldiriciList[4].Image;
            }
        }

        private BaseSoru KavramOlusturmaUret()
        {
            var soruCreater = new SoruCreater();
            SoruBuilder builder = new Lib.Soru.KavramOlusturma
            {
                Havuz = SeciliHavuz,
                ZorlukDerece = ZorlukDerece,
                SabitParcaAdet = SabitParca,
                CeldiriciAdet = CeldiriciAdet,
                ResimBoyut = ResimBoyut
            };
            soruCreater.Construct(builder);
            if (TestSoru.GetType() == typeof(KavramSoru1))
            {
                return new KavramSoru1(builder.Soru);
            }
            if (TestSoru.GetType() == typeof(KavramSoru2))
            {
                return new KavramSoru2(builder.Soru);
            }
            return null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (SoruTip == "Kavram Oluşturma")
            {
                TestSoru = KavramOlusturmaUret();
            }

            Soru = TestSoru.Soru;
            SetImages();
        }
    }
}
