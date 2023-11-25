using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ZoruSor.Reports;

namespace ZoruSor
{
    [Serializable]
    public class FasikulTest : IDisposable
    {
        public FasikulTest()
        {
            FasikulTestDetails = new BindingList<FasikulTestDetail>();

        }
        public int Sira { get; set; }
        public string SeciliSoruTip { get; set; }
        
        public SayfaTip SeciliSayfaTip { get; set; }
        public string Baslik { get; set; }

        public BindingList<FasikulTestDetail> FasikulTestDetails { get; set; }
        public void Dispose()
        {
            SeciliSayfaTip.Test = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }


}
