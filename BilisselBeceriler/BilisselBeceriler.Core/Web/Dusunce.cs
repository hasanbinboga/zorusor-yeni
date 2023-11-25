using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BilisselBeceriler.Entities.Security;

namespace BilisselBeceriler.Entities.Web
{
    public class Dusunce
    {
        public virtual int Id { get; set; }
        public virtual int KullaniciRef { get; set; }
        public virtual string Baslik { get; set; }
        public virtual string Url { get; set; }
        public virtual string Icerik { get; set; }
        public virtual string AnahtarKelime { get; set; }
        public virtual DateTime Tarih { get; set; }
    }
}
