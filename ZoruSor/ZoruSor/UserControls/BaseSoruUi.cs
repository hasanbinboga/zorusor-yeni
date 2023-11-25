using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZoruSor.Lib.Havuz;
using ZoruSor.Lib.Soru;
using ZoruSor.Lib.TestSoru;

namespace ZoruSor.UserControls
{
    public class BaseSoruUi:UserControl
    {
        protected Havuz SeciliHavuz;
        protected int ZorlukDerece;
        protected int SabitParca;
        protected int CeldiriciAdet;
        protected Soru Soru;
        protected int ResimBoyut;
        protected int SoruId;
        protected string SoruTip;

        public BaseSoru TestSoru { get; set; }
    }
}
