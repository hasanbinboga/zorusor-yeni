using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BilisselBeceriler.Entities.Security;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using System.Data.Common;

namespace BilisselBeceriler.FormLoginService
{
    #region Mappers
    class KullaniciLoginParameterMapper : IParameterMapper
    {
        public void AssignParameters(DbCommand command, object[] parameterValues)
        {
            DbParameter parameter = null;

            parameter = command.CreateParameter();
            parameter.ParameterName = "EMail";
            parameter.Value = parameterValues[0];
            command.Parameters.Add(parameter);

            parameter = command.CreateParameter();
            parameter.ParameterName = "Sifre";
            parameter.Value = parameterValues[1];
            command.Parameters.Add(parameter);
        }
    }
    class KullaniciYetkiParameterMapper : IParameterMapper
    {
        public void AssignParameters(DbCommand command, object[] parameterValues)
        {
            DbParameter parameter = null;

            parameter = command.CreateParameter();
            parameter.ParameterName = "KullaniciId";
            parameter.Value = parameterValues[0];
            command.Parameters.Add(parameter);
        }
    }
    #endregion

    public class KullaniciServis : IKullaniciServis, IDisposable
    {
        private Database Db;
        public KullaniciServis()
        {
            Db = EnterpriseLibraryContainer.Current.GetInstance<Database>();
        }
        public IKullanici Login(string Mail, string Sifre)
        {
            try
            {
                return Db.ExecuteSprocAccessor<Kullanici>("Login", new KullaniciLoginParameterMapper(), Mail, Sifre).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception("", ex);
            }
        }
        public IKullaniciYetki[] YetkiListe(int ID)
        {
            try
            {
                return Db.ExecuteSprocAccessor<KullaniciYetki>("KullaniciYetkiListe", new KullaniciYetkiParameterMapper(), ID).ToArray();
            }
            catch (Exception ex)
            {
                throw new Exception("", ex);
            }
        }
        public bool Ekle(IKullanici Kullanici)
        {
            throw new NotImplementedException();
        }

        public bool Sil(IKullanici Sil)
        {
            bool Sonuc;
            string SQL = "DELETE FROM Kullanici WHERE Id = @KullaniciId";
            try
            {
                using (DbConnection Con = Db.CreateConnection())
                {
                    Con.Open();
                    using (DbTransaction Trns = Con.BeginTransaction())
                    {
                        using (DbCommand Cmd = Db.GetSqlStringCommand(SQL))
                        {
                            Db.AddInParameter(Cmd, "KullaniciId", System.Data.DbType.Int16, Sil.Id);
                            int Adet = Db.ExecuteNonQuery(Cmd, Trns);
                            if (Adet == 1)
                            {
                                Trns.Commit();
                                Sonuc = true;
                            }
                            else
                            {
                                Trns.Rollback();
                                Sonuc = false;
                            }
                        }
                    }
                }
                return Sonuc;
            }
            catch (Exception ex)
            {
                throw new Exception("", ex);
            }
        }

        public bool Guncelle(IKullanici Guncelle)
        {
            throw new NotImplementedException();
        }

        public bool HesapDurumDegistir(KullaniciHesapDurum HesapDurum)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            if (Db != null)
                Db = null;
        }
    }
}
