using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BilisselBeceriler.Entities.Web
{
    public class Okul
    {
        public virtual int Id { get; set; }
        public virtual string Adi { get; set; }
        public virtual Il Il { get; set; }
        public virtual string Url { get; set; }
        public virtual string Adresi { get; set; }
        public virtual string Tel { get; set; }
        public virtual string WebAdresi { get; set; }
        public virtual string EPostaAdresi { get; set; }
        public virtual byte[] Logo { get; set; }
        public virtual byte[] KapakLogo { get; set; }
        public virtual bool AktifMi { get; set; }
        public virtual IList<Sinif> SinifListe { get; set; }       
    }
}

