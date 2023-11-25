using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BilisselBeceriler.Entities;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using BilisselBeceriler.Entities.Web;

namespace BilisselBeceriler.Data
{
    public class Yonetim
    {
        //public static Kurum KurumBilgi(int Id)
        //{
        //    Kurum kurum = null;
        //    try
        //    {
        //        Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("BilisselBecerilerDB");
        //        using (IDataReader dr = db.ExecuteReader(System.Data.CommandType.Text, "SELECT * FROM Kurum WHERE Id=" + Id))
        //        {
        //            while (dr.Read())
        //            {
        //                kurum = new Kurum();
        //                kurum.Id = Convert.ToInt32(dr["Id"]);
        //                kurum.Adi = dr["Adi"].ToString();
        //                kurum.Adresi = dr["Adresi"].ToString();
        //                kurum.WebAdresi = dr["WebAdresi"].ToString();
        //                kurum.EPostaAdresi = dr["EPostaAdresi"].ToString();
        //                kurum.Logo = dr["Logo"].ToString();
        //                kurum.KapakLogo = dr["KapakLogo"].ToString();
        //                kurum.AktifMi = Convert.ToBoolean(dr["AktifMi"]);
        //            }
        //        }
        //        return kurum;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Bilgi", ex);
        //    }
        //}
        public static Okul SubeBilgi(int Id)
        {
            Okul sube = null;
            try
            {
                string SQL = @" SELECT 
                                       k.Id KurumId,k.Adi KurumAd, k.Adresi KurumAdres, k.WebAdresi KurumWebAdres,k.EPostaAdresi KurumEPostaAdres,k.Logo KurumLogo, k.KapakLogo KurumKapakLogo,k.AktifMi KurumAktifMi,
                                       i.Id IlId, i.Adi IlAdi,
                                       s.Id SubeId, s.Adi SubeAd, s.Adresi SubeAdres, s.WebAdresi SubeWebAdres, s.EPostaAdresi SubeEPosta, s.Logo SubeLogo,
                                       s.KapakLogo SubeKapakLogo, s.AktifMi SubeAktiMi      
                                FROM Sube s
                                INNER JOIN Il i ON s.IlRef = i.Id
                                INNER JOIN Kurum k ON s.OkulRef = k.Id
                                WHERE s.Id =" + Id;

                Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("BilisselBecerilerDB");
                using (IDataReader dr = db.ExecuteReader(System.Data.CommandType.Text, SQL))
                {
                    while (dr.Read())
                    {
                        sube = new Okul();
                        sube.Id = Convert.ToInt32(dr["SubeId"]);
                        sube.Adi = dr["SubeAd"].ToString();
                        sube.Adresi = dr["SubeAdres"].ToString();
                        sube.WebAdresi = dr["SubeWebAdres"].ToString();
                        sube.EPostaAdresi = dr["SubeEPosta"].ToString();
                        //sube.Logo = dr["SubeLogo"].ToString();
                        //sube.KapakLogo = dr["SubeKapakLogo"].ToString();
                        sube.AktifMi = Convert.ToBoolean(dr["SubeAktiMi"]);

                        Il il = new Il();
                        il.Id = Convert.ToInt32(dr["IlId"]);
                        il.Adi = dr["IlAdi"].ToString();
                        sube.Il = il;

                        //Kurum kurum = new Kurum();
                        //kurum.Id = Convert.ToInt32(dr["KurumId"]);
                        //kurum.Adi = dr["KurumAd"].ToString();
                        //kurum.Adresi = dr["KurumAdres"].ToString();
                        //kurum.WebAdresi = dr["KurumWebAdres"].ToString();
                        //kurum.EPostaAdresi = dr["KurumEPostaAdres"].ToString();
                        //kurum.Logo = dr["KurumLogo"].ToString();
                        //kurum.KapakLogo = dr["KurumKapakLogo"].ToString();
                        //kurum.AktifMi = Convert.ToBoolean(dr["KurumAktifMi"]);
                        
                    }
                }
                return sube;
            }
            catch (Exception ex)
            {
                throw new Exception("Bilgi", ex);
            }
        }
        public static List<Sinif> SinifListe(int SubeRef)
        {
            List<Sinif> sinifListe = new List<Sinif>();

            try
            {
                string SQL = @" SELECT 
                                        sn.Id SinifId, sn.Adi SinifAd, sn.Logo SinifLogo, sn.KapakLogo SinifKapakLogo, sn.AktifMi SinifAktifMi,
                                        sb.Id SubeId, sb.Adi SubeAd, sb.Adresi SubeAdres, sb.WebAdresi SubeWebAdres, sb.EPostaAdresi SubeEPosta, sb.Logo SubeLogo,
                                        sb.KapakLogo SubeKapakLogo, sb.AktifMi SubeAktiMi      
                                FROM Sinif sn
                                INNER JOIN Sube sb ON sn.SubeRef = sb.Id
                                WHERE sb.Id=" + SubeRef;
                Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("BilisselBecerilerDB");
                using (IDataReader dr = db.ExecuteReader(System.Data.CommandType.Text, SQL))
                {
                    while (dr.Read())
                    {
                        Sinif sinif = new Sinif();
                        sinif.Id = Convert.ToInt32(dr["SubeId"]);
                        sinif.Adi = dr["SinifAd"].ToString();
                        //sinif.Logo = dr["SinifLogo"].ToString();
                        //sinif.KapakLogo = dr["SinifKapakLogo"].ToString();
                        sinif.AktifMi = Convert.ToBoolean(dr["SinifAktifMi"]);

                        Okul sube = new Okul();
                        sube.Id = Convert.ToInt32(dr["SubeId"]);
                        sube.Adi = dr["SubeAd"].ToString();
                        sube.Adresi = dr["SubeAdres"].ToString();
                        sube.WebAdresi = dr["SubeWebAdres"].ToString();
                        sube.EPostaAdresi = dr["SubeEPosta"].ToString();
                        //sube.Logo = dr["SubeLogo"].ToString();
                        //sube.KapakLogo = dr["SubeKapakLogo"].ToString();
                        sube.AktifMi = Convert.ToBoolean(dr["SubeAktiMi"]);

                        sinif.Okul = sube;
                        sinifListe.Add(sinif);
                    }
                }
                return sinifListe;
            }
            catch (Exception ex)
            {
                throw new Exception("Bilgi", ex);
            }
        }

        public static List<Ogrenci> OgrenciListe(int SinifRef)
        {
            List<Ogrenci> ogrenciListe = new List<Ogrenci>();

            try
            {
                string SQL = @" SELECT 
                                       o.Id OgrenciId, o.Adi, o.Soyadi, o.Cinsiyeti, o.DogumTarihi, o.Vesikalik,
                                       o.AbonelikBaslangici, o.PaketTurRef 
                                FROM Ogrenci o
                                WHERE o.SinifRef = " + SinifRef;

                Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("BilisselBecerilerDB");
                using (IDataReader dr = db.ExecuteReader(System.Data.CommandType.Text, SQL))
                {
                    while (dr.Read())
                    {
                        Ogrenci ogrenci = new Ogrenci();
                        ogrenci.Id = Convert.ToInt32(dr["OgrenciId"]);
                        ogrenci.Adi = dr["Adi"].ToString();
                        ogrenci.Soyadi = dr["Soyadi"].ToString();
                        //ogrenci.Cinsiyeti = dr["Cinsiyeti"].ToString();
                        ogrenci.DogumTarih = Convert.ToDateTime(dr["DogumTarihi"]);
                        //ogrenci.Vesikalik = dr["Vesikalik"].ToString();
                        ogrenci.Baslangici = Convert.ToDateTime(dr["AbonelikBaslangici"]);
                        //ogrenci.PaketTurRef = Convert.ToInt32(dr["PaketTurRef"]);
                        ogrenciListe.Add(ogrenci);
                    }
                }
                return ogrenciListe;
            }
            catch (Exception ex)
            {
                throw new Exception("OgrenciListe", ex);
            }
        }
    }
}
