using System.Collections.Generic;

namespace ZoruSor.Lib.Havuz
{
    public class Parca
    {
        public string Ad { get; set; }
        public int Adet { get; set; }
        public int Derece { get; set; }
        public int Sira { get; set; }
        public List<ParcaResim> ResimList { get; set; }
        public List<ParcaResim> DonusumResimList { get; set; }
    }
}
