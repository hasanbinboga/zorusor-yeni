using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NHibernate;
using NHibernate.Linq;
using BilisselBeceriler.Entities;
using NHibernate.Criterion;
using System.Collections;

namespace BilisselBeceriler.Data
{
    public class Repository<T> : IDisposable, IRepository<T> where T : new()
    {
        public ISession Session { get; set; }

        public Repository()
        {
            try
            {
                Session = NHibernateProvider.GetSession().OpenSession();
            }
            catch (Exception ex)
            {
                throw new Exception("Oturum Açılamadı" + ex.Message);
            }
        }

        #region IRepository<T> Members

        public T Kaydet(T Entity)
        {
            //using (ITransaction transaction = Session.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted))
            //{
            //    //object o = Session.Save(Entity);
            //    //transaction.Commit();
            //    //return (T)o;
            //}
            return default(T);
        }

        public void Guncelle(T Entity)
        {
            using (ITransaction transaction = Session.BeginTransaction())
            {
                Session.Update(Entity);
                transaction.Commit();
            }
        }

        public virtual IList<T> SelectWhere(Func<T, bool> query)
        {
            return Session.Query<T>().Where(query).ToList();
        }

        public virtual T Single(Func<T, bool> query)
        {
            return Session.Query<T>().SingleOrDefault(query);
        }
        public void Sil(T Entity)
        {
            using (ITransaction transaction = Session.BeginTransaction())
            {
                Session.Delete(Entity);
                transaction.Commit();
            }
        }

        public T Bilgi(int ID)
        {
            T Sonuc = Session.Get<T>(ID);
            return Sonuc;
        }

        public T Yukle(int id)
        {
            T Sonuc = Session.Load<T>(id);
            return Sonuc;
        }

        public IList<T> Yukle(string SQL)
        {
            IList<T> Liste = Session.CreateSQLQuery(SQL).AddEntity(typeof(T)).List<T>();
            return Liste;
        }

        public T Adet<T>(string SQL)
        {
            T Sonuc = Session.CreateSQLQuery(SQL).UniqueResult<T>();
            return Sonuc;
        }

        public int Adet()
        {
            ICriteria criteria = Session.CreateCriteria(typeof(T));
            criteria.SetProjection(Projections.RowCount());
            int Adet = (int)criteria.UniqueResult();
            return Adet;
        }

        public IList<T> Liste()
        {
            try
            {
                IList<T> Liste = Session.CreateCriteria(typeof(T)).List<T>();
                return Liste;
            }
            catch (Exception ex)
            {
                throw new Exception("Hata:" + ex.Message);
            }
            return null;
        }

        public T Bilgi(string Url)
        {
            T Sonuc = Session.CreateCriteria(typeof(T)).Add(Restrictions.Eq("Url", Url)).UniqueResult<T>();
            return Sonuc;
        }


        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            //Session.Flush();
            //Session.Disconnect();
            //Session.Close();
            //Session.Dispose();
        }

        #endregion

        public IList<T> Liste(int SayfaNo, int SatirAdet, out long ToplamSayfaSayisi)
        {

            var all = new List<T>();


            IList results = Session.CreateMultiCriteria()
                                .Add(Session.CreateCriteria(typeof(T)).SetFirstResult(SayfaNo * SatirAdet).SetMaxResults(SatirAdet))
                                .Add(Session.CreateCriteria(typeof(T)).SetProjection(Projections.RowCountInt64()))
                                .List();

            foreach (var o in (IList)results[0])
                all.Add((T)o);

            ToplamSayfaSayisi = (long)((IList)results[1])[0];
            return all;
        }
        public IList<T> Liste(ICriteria SorguKriter, int SayfaNo, int SatirAdet, out long ToplamSayfaSayisi)
        {
            IList<T> Liste = new List<T>();
            ICriteria countCriteria = CriteriaTransformer.Clone(SorguKriter).SetProjection(NHibernate.Criterion.Projections.RowCountInt64());
            countCriteria.ClearOrders();

            SorguKriter.SetFirstResult(SayfaNo).SetMaxResults(SatirAdet);

            var multiCriteria = Session.CreateMultiCriteria()
                .Add(SorguKriter)
                .Add(countCriteria);

            IList results = multiCriteria.List();
            ToplamSayfaSayisi = (long)((IList)results[1])[0];     // get paged items

            IList temp = ((IList)results[0]);
            foreach (var item in temp)
            {
                Liste.Add((T)item);
            }
            return Liste;
        }
    }
}

