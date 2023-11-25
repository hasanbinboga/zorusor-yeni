using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BilisselBeceriler.Entities.Web
{
    public class _Yayin
    {
        public virtual int Id { get; set; }
        public virtual DateTime Tarih { get; set; }
        public virtual string Sayi { get; set; }
        public virtual bool AktifMi { get; set; }
        
    }
}
