using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZoruSor.Lib.ResimBuilder
{
   public  class KuraliBulSatirArg
    {
        public Havuz.Havuz Havuz { get; set; }
        public List<ParcaFiyat> PahaliFiyatList { get; set; }
        public List<ParcaFiyat> NormalFiyatList { get; set; }
        public List<ParcaFiyat> UcuzFiyatList { get; set; }
        public Dictionary<string, int> GucluList { get; set; }
        public Dictionary<string, int> NormalList { get; set; }
        public Dictionary<string, int> ZayifList { get; set; }
        public Dictionary<string, int> Resim1 { get; set; }
        public bool Islem1 { get; set; }
        public Dictionary<string, int> Resim2 { get; set; }
        public bool Islem2 { get; set; }
        public Dictionary<string, int> Resim3 { get; set; }
        public int ParantezId { get; set; }
        public Dictionary<string, int> SonucResim { get; set; }
        public int ResimBoyut { get; set; }
        public string Resim1FiyatToplam { get; set; }
        public string Resim2FiyatToplam { get; set; }
        public string Resim3FiyatToplam { get; set; }
        public string SonucResimFiyatToplam { get; set; }

    }
}
