using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZoruSor.Lib.Havuz
{
    public class TestDetail:IDisposable
    {
        public Havuz Havuz { get; set; }
        public int Zorluk { get; set; }
        public int SabitParcaAdet { get; set; }
        public int SayfaAdet { get; set; }

        public string Resim1Formul { get; set; }
        public string Resim2Formul { get; set; }
        public string Resim3Formul { get; set; }
        public string Resim4Formul { get; set; }

        public bool IslemGorunsun { get; set; }

        public void Dispose()
        {
            Havuz = null;
            GC.Collect();
        }
    }
}
