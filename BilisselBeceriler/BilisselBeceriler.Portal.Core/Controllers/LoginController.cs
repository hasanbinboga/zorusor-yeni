using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Security;
using System.Web;
using BilisselBeceriler.Entities.Security;
using Microsoft.Practices.Unity;
using BilisselBeceriler.Utility;

namespace BilisselBeceriler.Portal.Core.Controllers
{
    public class LoginController : BaseController
    {
        [Dependency]
        public IKullaniciServis KullaniciServis { get; set; }

        public ActionResult Index(string ReturnURL)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            string Mail = collection["tbMail"];
            string Sifre = collection["tbSifre"];
            try
            {
                IKullanici Kullanici = KullaniciServis.Login(Mail, Sifre);
                if (Kullanici != null)
                {
                    IKullaniciYetki[] YetkiListe = KullaniciServis.YetkiListe(Kullanici.Id);
                    string YetkiString = null;
                    foreach (var item in YetkiListe)
                    {
                        if (YetkiString == null)
                        {
                            YetkiString = item.Ad;
                        }
                        else
                        {
                            YetkiString = YetkiString + "," + item.Ad;
                        }
                    }
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket
                    (
                        2, Kullanici.Id.ToString(), DateTime.Now, DateTime.Now.AddDays(1), true,
                        YetkiString, FormsAuthentication.FormsCookiePath
                    );

                    string encTicket = FormsAuthentication.Encrypt(ticket);
                    HttpCookie cok = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
                    cok.Expires = ticket.Expiration;
                    Response.Cookies.Add(cok);
                    return RedirectToAction("Index","Yonetim");
                }
                else
                {
                    ViewBag.Mesaj = "Kullanıcı adı veya şifre hatalı !!!";
                    return View();
                }
            }
            catch
            {
                ViewBag.Mesaj = "Hata oluştu, lütfen bir süre sonra tekrar deneyiniz !!!";
                return View();
            }
        }

        public ActionResult Cikis()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("index", "Anasayfa");
        }
    }
}
