using System;
using System.Windows.Forms;
using ZoruSor.Lib.Havuz;
using ZoruSor.Lib.Soru;

namespace ZoruSor
{
    public partial class KavramOlusturma : Form
    {
        public KavramOlusturma()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            var havuz = HavuzCreater.GetYeniTipHavuz(@"C:\Users\admin\Desktop\Zorusor\Yüz1");
            var soruCreater = new SoruCreater();
            SoruBuilder builder = new Lib.Soru.KavramOlusturma
            {
                Havuz = havuz,
                SabitParcaAdet = 3,
                CeldiriciAdet = 5,
                ZorlukDerece = 5

            };

            soruCreater.Construct(builder);
            Grup1Resim1.Image = builder.Soru.ReferansResimList[0].Image;
            Grup1Resim2.Image = builder.Soru.ReferansResimList[1].Image;
            Grup1Resim3.Image = builder.Soru.ReferansResimList[2].Image;
            Grup1Resim4.Image = builder.Soru.ReferansResimList[3].Image;

            Grup2Resim1.Image = builder.Soru.ReferansResimList[4].Image;
            Grup2Resim2.Image = builder.Soru.ReferansResimList[5].Image;
            Grup2Resim3.Image = builder.Soru.ReferansResimList[6].Image;
            Grup2Resim4.Image = builder.Soru.ReferansResimList[7].Image;

            DogruCevap.Image = builder.Soru.DogruCevapList[0].Image;
            Celdirici1.Image = builder.Soru.CeldiriciList[0].Image;
            Celdirici2.Image = builder.Soru.CeldiriciList[1].Image;
            Celdirici3.Image = builder.Soru.CeldiriciList[2].Image;
            Celdirici4.Image = builder.Soru.CeldiriciList[3].Image;
            Celdirici5.Image = builder.Soru.CeldiriciList[4].Image;

        }
    }
}
