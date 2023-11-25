using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BilisselBeceriler.Entities.Web
{
    public class ZiyaretIstatistik
    {
        public virtual int Id { get; set; }
        public virtual string Ip { get; set; }
        public virtual string SessionId { get; set; }
        public virtual int UyeRef { get; set; }
        public virtual DateTime Tarih { get; set; }
    }
}
