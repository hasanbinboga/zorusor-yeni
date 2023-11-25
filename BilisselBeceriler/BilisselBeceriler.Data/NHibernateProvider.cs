using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NHibernate;
using NHibernate.Cfg;
using System.Reflection;

namespace BilisselBeceriler.Data
{
    public class NHibernateProvider
    {
        private static ISessionFactory fabrika = null;
        protected NHibernateProvider()
        {

        }

        public static ISessionFactory GetSession()
        {
            if (fabrika == null)
            {
                lock (typeof(NHibernateProvider))
                {
                    try
                    {
                        if (fabrika == null)
                        {
                            var confg = new Configuration();
                            confg.Configure();
                            confg.AddAssembly(Assembly.GetExecutingAssembly());
                            fabrika = confg.BuildSessionFactory();
                        }
                    }
                    catch (Exception ex )
                    {
                        throw new Exception("Bağlantı Hatası:" + ex.Message);
                    }

                }
            }
            return fabrika;
        }
    }
}
