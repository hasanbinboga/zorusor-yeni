using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BilisselBeceriler.Entities.Web
{
    public class Bildirim
    {
        public virtual int Id { get; set; }
        public virtual string Baslik { get; set; }
        public virtual string Aciklama { get; set; }
        public virtual DateTime Tarih { get; set; }
        public virtual bool OkunduMu { get; set; }
        public virtual bool AktifMi { get; set; }
    }
}
