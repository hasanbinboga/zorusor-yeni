using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace BilisselBeceriler.Portal.Core.Controllers
{
   public class FiyatlarController:BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult OtuzAltiAySonrasi()
        {
            return View();
        }
        public ActionResult KirkSekizAySonrasi()
        {
            return View();
        }
        public ActionResult AltmisAySonrasi()
        {
            return View();
        }
        public ActionResult YetmisIkiAySonrasi()
        {
            return View();
        }
    }
}
