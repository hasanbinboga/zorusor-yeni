using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using BilisselBeceriler.Entities;
using BilisselBeceriler.Data;
using BilisselBeceriler.Portal.Core.Attributes;
using BilisselBeceriler.Portal.Core.Utility;
using BilisselBeceriler.Entities.Web;

namespace BilisselBeceriler.Portal.Core.Controllers
{
    public class SinifController : BaseController
    {
        [YetkiControl(Roller = "Okul,Admin")]
        public ActionResult Index()
        {
            int Id = Util.OkulIdGetir();
            using (Repository<Okul> Respository = new Repository<Okul>())
            {
                IList<Sinif> SinifListe = Respository.Bilgi(Id).SinifListe;
                return View(SinifListe);
            }
        }
    }
}
