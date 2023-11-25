using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BilisselBeceriler.Utility;

namespace BilisselBeceriler.Portal.Helpers
{
    public static class HtmlHelpers
    {
        public static string ToTitleCase(this HtmlHelper Helper, string Metin)
        {
            return Metin.ToTitleCase(true);
        }

        public static string Clear(this HtmlHelper Helper, string Metin)
        {
            string Sonuc = HttpUtility.HtmlDecode(Metin);
            return Sonuc;
        }       
    }
}