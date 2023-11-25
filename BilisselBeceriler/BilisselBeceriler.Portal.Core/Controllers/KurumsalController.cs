using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace BilisselBeceriler.Portal.Core.Controllers
{
    public class KurumsalController:BaseController
    {
        public ActionResult Index()//Biz Kimiz?
        {
            return View();
        }
        public ActionResult Eserlerimiz()
        {
            return View();
        }
        public ActionResult KilometreTaslarimiz()
        {
            return View();
        }
        public ActionResult Hedeflerimiz()
        {
            return View();
        }
    }
}
