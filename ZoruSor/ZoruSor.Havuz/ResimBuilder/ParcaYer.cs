using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZoruSor.Lib.ResimBuilder
{
    public class ParcaYer
    {
        public int IlkKonum { get; set; }
        public int SonKonum { get; set; }
        public string Ad { get; set; }

        public float GetAci(int toplamParcaAdet)
        {
            return (toplamParcaAdet - (IlkKonum - SonKonum))*(360f/toplamParcaAdet);
        }
    }
}
