using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Security.Principal;
using Microsoft.Practices.Unity.Configuration;
using System.Configuration;
using BilisselBeceriler.Data;
using BilisselBeceriler.Entities;
using BilisselBeceriler.Portal.Core;
using Microsoft.Practices.Unity;
using BilisselBeceriler.Entities.Security;
using BilisselBeceriler.Entities.Imaging;
using BilisselBeceriler.Entities.Web;

namespace BilisselBeceriler.Portal
{

    public class MvcApplication : System.Web.HttpApplication, IContainerAccessor
    {
        private static UnityContainer _container;
        public static IUnityContainer Container
        {
            get { return _container; }
        }

        IUnityContainer IContainerAccessor.Container
        {
            get { return Container; }
        }

        private static void Initialize()
        {
            if (_container == null)
                _container = new UnityContainer();

            UnityConfigurationSection unityConfig = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
            unityConfig.Configure(_container);

            IControllerFactory controllerFactory = new UnityControllerFactory(_container);

            ControllerBuilder.Current.SetControllerFactory(controllerFactory);

            // For Sample Only... Create a Singleton
            //_container.RegisterType<INewsService, NewsService>(new ContainerControlledLifetimeManager());
            //IKullaniciServis se = _container.Resolve<IKullaniciServis>();
            //IImageResizer ir = _container.Resolve<IImageResizer>();
        }

        #region Application events
        protected void Application_AuthenticateRequest(Object sender, EventArgs e)
        {
            string cookieAdi = FormsAuthentication.FormsCookieName;
            HttpCookie YetkiCookie = Context.Request.Cookies[cookieAdi];
            if (YetkiCookie == null)
            {
                return;
            }
            FormsAuthenticationTicket ticket = null;
            try
            {
                ticket = FormsAuthentication.Decrypt(YetkiCookie.Value);
            }
            catch (Exception)
            {
                return;
            }
            if (ticket == null)
            {
                return;
            }

            string[] roller = ticket.UserData.Split(',');
            FormsIdentity id = new FormsIdentity(ticket);
            System.Security.Principal.GenericPrincipal gp = new System.Security.Principal.GenericPrincipal(id, roller);
            Context.User = gp;
        }
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
        protected void Session_Start(Object sender, EventArgs e)
        {
            //if (_container == null)
            //    _container = new UnityContainer();

            //UnityConfigurationSection section = (UnityConfigurationSection)
            //               ConfigurationManager.GetSection("unity");
            //section.Containers.Default.GetConfigCommand().Configure(_container);
            using (Repository<ZiyaretIstatistik> r = new Repository<ZiyaretIstatistik>())
            {
                r.Kaydet(new ZiyaretIstatistik() { Ip = Request.UserHostAddress, Tarih = DateTime.Now, UyeRef = 0, SessionId = Session.SessionID });
            }
        }
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{*favicon}", new { favicon = @"(.*/)?favicon.ico(/.*)?" });

            routes.MapRoute(
                    "Dusuncelerimiz1", // Route name
                    "Dusuncelerimiz/Kayit", // URL with parameters
                    new { controller = "Dusuncelerimiz", action = "Kayit" } // Parameter defaults
            );

            routes.MapRoute(
                "Dusuncelerimiz2", // Route name
                "Dusuncelerimiz/{Url}", // URL with parameters
                new { controller = "Dusuncelerimiz", action = "Detay" } // Parameter defaults
            );

            routes.MapRoute(
                "Okul", // Route name
                "Okul/{Url}", // URL with parameters
                new { controller = "Okul", action = "Detay" } // Parameter defaults
            );

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Anasayfa", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
            Initialize();
            log4net.Config.XmlConfigurator.Configure();
        }
        void Application_Error(object sender, EventArgs e)
        {
            //var error = Server.GetLastError();
            //var code = (error is HttpException) ? (error as HttpException).GetHttpCode() : 500;


            //Response.Clear();
            //Server.ClearError();

            //string path = Request.Path;
            //Context.RewritePath(string.Format("~/Errors/Http{0}", code), false);
            //IHttpHandler httpHandler = new MvcHttpHandler();
            //httpHandler.ProcessRequest(Context);
            //Context.RewritePath(path, false);
        }
        protected void Application_End(object sender, EventArgs e)
        {

        }
        #endregion
    }
}