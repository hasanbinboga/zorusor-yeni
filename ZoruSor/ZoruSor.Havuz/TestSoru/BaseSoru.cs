using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZoruSor.Lib.TestSoru
{
    public class BaseSoru
    {
        [DisplayName("Referans Resim")]
        public Image ReferansResim { get; set; }

        [DisplayName("Cevap")]
        public string Cevap { get; set; }

        public Soru.Soru Soru { get; set; }
        
    }
}
