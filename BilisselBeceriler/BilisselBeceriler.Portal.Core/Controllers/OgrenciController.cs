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
using NHibernate;
using NHibernate.Criterion;
using BilisselBeceriler.Portal.Helpers;
using BilisselBeceriler.Utility;

namespace BilisselBeceriler.Portal.Core.Controllers
{
    public class OgrenciController : BaseController
    {
        public JsonResult SinifOgrenciListe(int SinifId, int SayfaNo, int SayfaBasiKayitAdet)
        {
            long Toplam;
            using (Repository<Ogrenci> OgrenciRepository = new Repository<Ogrenci>())
            {

                ICriteria criteria = OgrenciRepository.Session.CreateCriteria(typeof(Ogrenci))
                .CreateAlias("Sinif", "sinif")
                .Add(Restrictions.Eq("sinif.Id", SinifId));

                IList<Ogrenci> OgrenciListe = OgrenciRepository.Liste(criteria, SayfaNo, SayfaBasiKayitAdet, out Toplam);
                Toplam = (Toplam % SayfaBasiKayitAdet);

                if (Toplam % SayfaBasiKayitAdet != 0)
                    Toplam++;

                dynamic Temp = null;
                if (OgrenciListe != null && OgrenciListe.Count > 0)
                {
                    Temp = new
                    {
                        ToplamAdet = Toplam,
                        OgrenciListe = from ogrenci in OgrenciListe
                                       select new
                                       {
                                           Id = ogrenci.Id,
                                           Ad = ogrenci.Adi,
                                           Soyad = ogrenci.Soyadi,
                                           DogumTarih = ogrenci.DogumTarih.ToShortDateString(),
                                           Toplam = Toplam
                                       }
                    };
                }
                return Json(Temp);
            }
        }

        public ActionResult Liste()
        {
            int Id = Util.OkulIdGetir();
            using (Repository<Okul> OkulRepository = new Repository<Okul>())
            {
                List<Sinif> SinifListe = OkulRepository.Bilgi(Id).SinifListe.ToList();
                List<SelectListItem> items = new List<SelectListItem>();
                items.Add(new SelectListItem() { Text = "Sınıf seçiniz", Value = "-1", Selected = true });
                SinifListe.ForEach(sl => items.Add(new SelectListItem() { Text = sl.Adi.ToTitleCase(true), Value = sl.Id.ToString() }));
                ViewData["ddlSinif"] = items;
            }
            return View();
        }
    }
}
