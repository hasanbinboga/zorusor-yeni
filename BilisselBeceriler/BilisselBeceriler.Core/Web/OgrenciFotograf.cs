using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BilisselBeceriler.Entities.Web
{
    public class OgrenciFotograf
    {
        public virtual int Id { get; set; }
        public virtual Ogrenci Ogrenci { get; set; }
        public virtual GenelAyarlar FotoKategori { get; set; }        
        public virtual bool AktifMi { get; set; }
        public virtual byte[] Resim { get; set; }
    }
}
