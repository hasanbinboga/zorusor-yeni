using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BilisselBeceriler.Entities.Security;

namespace BilisselBeceriler.FormLoginService
{
    public class Kullanici : IKullanici
    {

        public int Id
        {
            get;
            set;
        }

        public string Ad
        {
            get;
            set;
        }

        public string SoyAd
        {
            get;
            set;
        }

        public string Mail
        {
            get;
            set;
        }

        public string Sifre
        {
            get;
            set;
        }

        public string Tel
        {
            get;
            set;
        }

        public bool AktifMi
        {
            get;
            set;
        }

        public DateTime Tarih
        {
            get;
            set;
        }        
    }
}
