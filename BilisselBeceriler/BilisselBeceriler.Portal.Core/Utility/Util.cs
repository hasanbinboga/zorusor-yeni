using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace BilisselBeceriler.Portal.Core.Utility
{
    public static class Util
    {
        public static int OkulIdGetir()
        {
            if (HttpContext.Current.Session["AktifOkulId"] != null)
                return Convert.ToInt32(HttpContext.Current.Session["AktifOkulId"]);
            else
                return 5;
        }
    }
}
