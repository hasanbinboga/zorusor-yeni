using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using BilisselBeceriler.Data;
using BilisselBeceriler.Entities;
using BilisselBeceriler.Portal.Core.Attributes;
using BilisselBeceriler.Entities.Web;

namespace BilisselBeceriler.Portal.Core.Controllers
{
    public class YonetimController : BaseController
    {
        [ChildActionOnly]
        public ActionResult SubeListe()
        {
            IList<Okul> OkulListe = new List<Okul>();
            if (User.Identity.IsAuthenticated)
            {
                string SQL = @"
                    SELECT 
                            s.* 
                    FROM Okul as s ";

                if (User.IsInRole("Admin") == false)
                    SQL += " INNER JOIN kullanicisube ks ON s.Id = ks.SubeRef WHERE ks.KullaniciRef = " + User.Identity.Name;

                using (Repository<Okul> OkulRepository = new Repository<Okul>())
                {
                    using (Repository<Bildirim> BildirimRepository = new Repository<Bildirim>())
                    {
                        OkulListe = OkulRepository.Yukle(SQL);

                        Okul AktifOkul = OkulListe.FirstOrDefault();
                        if (AktifOkul != null)
                            Session["AktifOkulId"] = AktifOkul.Id;
                        ViewBag.BildirimAdet = BildirimRepository.Adet();
                        ViewBag.AktifOkul = AktifOkul;
                        ViewBag.OkulListe = OkulListe;
                    }
                }
            }
            return PartialView(OkulListe);
        }


        public ActionResult Index()
        {
            Repository<Okul> OkulRepository = new Repository<Okul>();
            Repository<Ogrenci> OgrenciRepository = new Repository<Ogrenci>();

            ViewBag.OkulAdet = OkulRepository.Adet();
            ViewBag.OgrenciAdet = OgrenciRepository.Adet();

            return View();
        }

        [YetkiControl(Roller = "Admin")]
        public ActionResult PortalZiyaretIstatistik()
        {
            using (Repository<ZiyaretIstatistik> ziyaretci = new Repository<ZiyaretIstatistik>())
            {
                ViewBag.ToplamZiyaretciSayisi = ziyaretci.Adet();
                ViewBag.AktifZiyaretciSayisi = 0;//ziyaretci.Yukle("SELECT * FROM ZiyaretIstatistik WHERE TIMESTAMPDIFF(MINUTE, Tarih, now())<=20;").Count;
                return View();
            }
        }
    }
}
