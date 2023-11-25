using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BilisselBeceriler.Entities.Web
{
    public class _Belge
    {
        public virtual int Id { get; set; }
        public virtual PaketTur PaketTur { get; set; }
        public virtual _BelgeTur BelgeTur { get; set; }
        public virtual string Sablon { get; set; }
        public virtual GenelAyarlar Cinsiyet { get; set; }
        public virtual bool AktifMi { get; set; }
        public virtual _Yayin Yayin { get; set; }
    }
}
