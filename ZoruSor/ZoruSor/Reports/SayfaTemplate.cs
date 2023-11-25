using System.Collections.Generic;
using System.Drawing;
using System.Xml.Serialization;
using ZoruSor.Lib.Test;

namespace ZoruSor.Reports
{
    [XmlInclude(typeof(AynisiniBulSayfa1))]
    [XmlInclude(typeof(AynisiniBulSayfa2))]
    [XmlInclude(typeof(AynisiniBulSayfa3))]
    [XmlInclude(typeof(SiniflandirSayfa1))]
    public partial class SayfaTemplate : DevExpress.XtraReports.UI.XtraReport
    {
        public Image CustomResim { get; set; }
        public Image LogoResim { get; set; }
        public List<string> SoruTipList { get; set; }
        public SayfaTemplate()
        {
            InitializeComponent();
            
            
        }

        public void LogoAyarla()
        {
            if (LogoResim != null)
            {
                LogoImage.Image = LogoResim;
            }
        }

        public void CustomResimAyarla()
        {
            if (CustomResim != null)
            {
                CustomImage.Image = CustomResim;
            }
        }

    }
}
