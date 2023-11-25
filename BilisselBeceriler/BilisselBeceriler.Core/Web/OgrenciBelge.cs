using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BilisselBeceriler.Entities.Web
{
    public class OgrenciBelge
    {
        public virtual int Id { get; set; }
        public virtual Ogrenci Ogrenci { get; set; }
        public virtual _Belge Belge { get; set; }
        public virtual string Sablon { get; set; }
        public virtual bool AktifMi { get; set; }
    }
}
