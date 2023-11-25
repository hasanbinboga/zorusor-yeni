using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace BilisselBeceriler.Portal.Core
{
    public class TestController:BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
