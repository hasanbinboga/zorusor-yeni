using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZoruSor.Lib.Havuz;
using ZoruSor.Lib.Soru;

namespace ZoruSor
{
    public partial class OrtakElemanFrm : Form
    {
        public OrtakElemanFrm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            var havuz = HavuzCreater.GetYeniTipHavuz(@"C:\Users\admin\Desktop\Zorusor\Yüz1");
            var soruCreater = new SoruCreater();
            SoruBuilder builder = new Lib.Soru.OrtakEleman
            {
                Havuz = havuz,
                SabitParcaAdet = 3,
                CeldiriciAdet = 5,
                ZorlukDerece = 5
            };

            soruCreater.Construct(builder);
            ReferansResim.Image = builder.Soru.ReferansResimList[0].Image;

            DogruCevap.Image = builder.Soru.DogruCevapList[0].Image;
            Celdirici1.Image = builder.Soru.CeldiriciList[0].Image;
            Celdirici2.Image = builder.Soru.CeldiriciList[1].Image;
            Celdirici3.Image = builder.Soru.CeldiriciList[2].Image;
            Celdirici4.Image = builder.Soru.CeldiriciList[3].Image;
            Celdirici5.Image = builder.Soru.CeldiriciList[4].Image;
        }
    }
}
