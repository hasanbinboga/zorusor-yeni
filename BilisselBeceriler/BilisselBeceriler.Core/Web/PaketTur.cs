using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BilisselBeceriler.Entities.Web
{
    public class PaketTur
    {
        public virtual int Id { get; set; }
        public virtual string Ad { get; set; }
        public virtual decimal BirimFiyat { get; set; }
        public virtual bool AktifMi { get; set; }
        public virtual GenelAyarlar YasGrubu { get; set; }
    }
}
