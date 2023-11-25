using System.Collections.Generic;

namespace ZoruSor.Lib.ResimBuilder
{
   public  class DondurBulSatirArg
    {
        public Havuz.Havuz Havuz { get; set; }
        public List<ParcaExtent> ParcaExtentList { get; set; }

       
        public List<ParcaAci> Resim1 { get; set; }
        public bool Yon1 { get; set; }
        public List<ParcaAci> Resim2 { get; set; }
        public bool Yon2 { get; set; }
        public List<ParcaAci> Resim3 { get; set; }
        public bool Yon3 { get; set; }
        public List<ParcaAci> SonucResim { get; set; }
        public int ResimBoyut { get; set; }
    }
}
