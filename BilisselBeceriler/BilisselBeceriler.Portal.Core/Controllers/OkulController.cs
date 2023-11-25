using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using BilisselBeceriler.Data;
using BilisselBeceriler.Entities;
using BilisselBeceriler.Portal.Core.Attributes;
using BilisselBeceriler.Portal.Core.Utility;
using BilisselBeceriler.Entities.Web;

namespace BilisselBeceriler.Portal.Core.Controllers
{
    public class OkulController : BaseController
    {


        [YetkiControl(Roller = "Okul,Admin")]
        public ActionResult Index()
        {
            int Id = Util.OkulIdGetir();
            using (Repository<Okul> Respository = new Repository<Okul>())
            {
                Okul Okul = Respository.Bilgi(Id);
                return View(Okul);
            }
        }
        [YetkiControl(Roller = "Okul,Admin")]
        public ActionResult Kayit(Okul Okul)
        {
            using (Repository<Okul> Respository = new Repository<Okul>())
            {
                Respository.Kaydet(Okul);
                return View();
            }
        }
        [YetkiControl(Roller = "Okul,Admin")]
        public ActionResult Detay(string Url)
        {
            using (Repository<Okul> Respository = new Repository<Okul>())
            {
                Okul sube = Respository.Bilgi(Url);
                return View(sube);
            }
        }

        //public ActionResult SubeYonetim(int? KurumId)
        //{
        //    Sube sube = Yonetim.SubeBilgi(5);
        //    return View(sube);
        //}
    }
}
