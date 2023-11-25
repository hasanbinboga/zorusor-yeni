using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BilisselBeceriler.Entities.Security;

namespace BilisselBeceriler.FormLoginService
{
    public class KullaniciYetki:IKullaniciYetki
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
    }
}
