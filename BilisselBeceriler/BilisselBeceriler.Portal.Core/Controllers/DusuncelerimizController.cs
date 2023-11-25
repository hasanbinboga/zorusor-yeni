using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using BilisselBeceriler.Data;
using BilisselBeceriler.Entities;
using BilisselBeceriler.Utility;
using BilisselBeceriler.Portal.Core.Attributes;
using BilisselBeceriler.Entities.Web;

namespace BilisselBeceriler.Portal.Core.Controllers
{
    public class DusuncelerimizController : BaseController
    {

        public ActionResult Index(string id)
        {
            using (Repository<Dusunce> repository = new Repository<Dusunce>())
            {
                var Liste = repository.Liste();
                return View(Liste);
            }
        }
        public ActionResult Detay(string Url)
        {
            using (Repository<Dusunce> repository = new Repository<Dusunce>())
            {
                Dusunce Dusunce = repository.Bilgi(Url);
                return View(Dusunce);
            }
        }

        [YetkiControl(Roller = "Admin")]
        public ActionResult Kayit(FormCollection fc)
        {
            return View();
        }
        public ActionResult BilisselBecerilerveZeka(string Id)
        {
            return View();
        }
    }
}
