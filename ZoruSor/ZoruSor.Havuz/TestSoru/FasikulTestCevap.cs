using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZoruSor.Lib.TestSoru
{
   

    public class FasikulTestCevap
    {
        [DisplayName("Test Baslik")]
        public string TestBaslik { get; set; }
        [DisplayName("Test Sira")]
        public int TestSira { get; set; }
        [DisplayName("Cevaplar")]
        public string Cevaplar { get; set; }
    }
}
