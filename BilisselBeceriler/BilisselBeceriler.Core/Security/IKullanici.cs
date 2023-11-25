using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BilisselBeceriler.Entities.Security
{
    public interface IKullanici
    {
        int Id { get; set; }        
        string Ad { get; set; }
        string SoyAd { get; set; }
        string Mail { get; set; }
        string Sifre { get; set; }
        string Tel { get; set; }        
        DateTime Tarih { get; set; }
        bool AktifMi { get; set; }
    }
}
