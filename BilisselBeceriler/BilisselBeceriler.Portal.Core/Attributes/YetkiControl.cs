using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace BilisselBeceriler.Portal.Core.Attributes
{
    public class YetkiControl : AuthorizeAttribute
    {
        public string Roller { get; set; }
        
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
            if (filterContext.HttpContext.User != null)
            {
                string[] RolBilgi = Roller.Split(new char[] { ',' });
                bool YetkiliMi = false;
                foreach (var item in RolBilgi)
                {
                    if (filterContext.HttpContext.User.IsInRole(item))
                    {
                        YetkiliMi = true;
                        break;
                    }
                }
                if (YetkiliMi == false)
                    filterContext.Result = new HttpUnauthorizedResult(); 
            }
            else
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }
    }
}
