using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace ZoruSor.Lib.ResimBuilder
{
    public class ParcaExtent
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public Rectangle Extent { get; set; }
        public int Yuzolcum { get { return Extent.Width*Extent.Height; } }

        public List<ParcaExtent> IcindekiParcalariGetir(List<ParcaExtent> parcaList)
        {
            var sonuc = new List<ParcaExtent>();

            foreach (var parca in parcaList)
            {
                if (parca.Ad != Ad && Extent.Contains(parca.Extent))
                {
                    sonuc.Add(parca);
                }
            }
            return sonuc.OrderByDescending(s=>s.Yuzolcum).ToList();
        }

        public ParcaExtent GetParentExtent(List<ParcaExtent> parcaList)
        {
            foreach (var parca in parcaList.OrderBy(s=>s.Yuzolcum))
            {
                if (parca.Ad != Ad && parca.Extent.Contains(Extent))
                {
                    return parca;
                }
            }
            return null;
        }
    }
}
