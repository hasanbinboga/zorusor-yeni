using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BilisselBeceriler.Entities.Web
{
    public class Sinif
    {
        public virtual int Id { get; set; }
        public virtual string Adi { get; set; }
        public virtual Okul Okul { get; set; }
        public virtual GenelAyarlar Yas { get; set; }
        public virtual IList<Ogrenci> OgrenciListe { get; set; }       
        public virtual bool AktifMi { get; set; }
    }
}
