using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;

namespace ZoruSor.Lib.Soru
{
    public class CiktiResim
    {
        public CiktiResim()
        {
            Image= new Bitmap(360, 360, PixelFormat.Format32bppArgb);
            ParcaList = new Dictionary<string, int>();
            DonusumList = new Dictionary<string, int>();
        }
        public Image Image { get; set; }
        public Dictionary<string, int> ParcaList { get; set; }
        /// <summary>
        /// Simetrik iliskiler ve kurali bul uygula icin kullanilan 
        /// bir ozelliktir. Bir secenek iki ayri resim barindirdigindan eklenmistir.
        /// </summary>
        public Dictionary<string, int> DigerResimParcaList { get; set; }
        public Dictionary<string, int> DonusumList { get; set; }

        /// <summary>
        /// Resmin diger resimler arasindaki derecesini gosterir. Derecesi buyuk olan daha degerlidir. 
        /// Kurali Bulup Uygulama testleri icin eklendi.
        /// </summary>
        public int Derece { get; set; }
        private bool ResimlerAyniMi(CiktiResim resim1, CiktiResim resim2)
        {
            if (resim1.ParcaList.Count == 0 || resim2.ParcaList.Count == 0)
            {
                return resim1.Image.Equals(resim2.Image);
            }
            var ayniParcaAdet = 0;
            var ayniDonusumParcaAdet = 0;
            foreach (var parca in resim1.ParcaList)
            {

                if (resim2.ParcaList.ContainsKey(parca.Key) && parca.Value == resim2.ParcaList[parca.Key])
                {
                    ayniParcaAdet++;
                }
            }
            foreach (var donusum in resim1.DonusumList)
            {
                if (resim2.DonusumList.ContainsKey(donusum.Key) && donusum.Value == resim2.DonusumList[donusum.Key])
                {
                    ayniDonusumParcaAdet++;
                }
            }
            if (ayniParcaAdet == resim1.ParcaList.Count && 
                ayniDonusumParcaAdet == resim1.DonusumList.Count)
            {
                return true;
            }
            return false;
        }
        public override bool Equals(object obj)
        {
            if (base.Equals(obj))
            {
                return true;
            }
            return obj != null && (obj.GetType() != typeof(CiktiResim) || ResimlerAyniMi(this, (CiktiResim) obj));
        }

        protected bool Equals(CiktiResim other)
        {
            return Equals(Image, other.Image) && Equals(ParcaList, other.ParcaList) && Equals(DonusumList, other.DonusumList) && Derece == other.Derece;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Image != null ? Image.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (ParcaList != null ? ParcaList.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (DonusumList != null ? DonusumList.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ Derece;
                return hashCode;
            }
        }
    }
}
