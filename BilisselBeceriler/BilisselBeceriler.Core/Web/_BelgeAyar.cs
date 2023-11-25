using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BilisselBeceriler.Entities.Web
{
    public class _BelgeAyar
    {
        public virtual int Id { get; set; }
        public virtual _Belge Belge { get; set; }
        public virtual GenelAyarlar ResimTur { get; set; }
        public virtual GenelAyarlar ZorlukTur { get; set; }        
        public virtual int Baslangic { get; set; }
        public virtual int Bitis { get; set; }
        public virtual bool AktifMi { get; set; }
    }
}
