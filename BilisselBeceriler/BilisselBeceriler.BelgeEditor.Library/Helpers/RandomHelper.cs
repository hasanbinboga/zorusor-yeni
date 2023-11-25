using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace BilisselBeceriler.BelgeEditor.Library.Helpers
{
    public static class RandomHelper
    {
        public static int RastgeleSayi(int Hasasiyet)
        {
            byte[] RastgeleByte = new byte[Hasasiyet];
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetBytes(RastgeleByte);
            return BitConverter.ToInt32(RastgeleByte, 0);
        }
        public static int HassasRastgeleSayi(int Hasasiyet, int ilk, int son)
        {
            if (son - ilk == 0)
            {
                return ilk;
            }
            else if (son - ilk <= 255)
            {
                Random r = new Random(RastgeleSayi(Hasasiyet));
                int rIndeks = r.Next(ilk * 100000, son * 100000);
                return Convert.ToInt32(decimal.Round((decimal)rIndeks / 100000, 0));
            }
            else
            {
                Random r = new Random(RastgeleSayi(Hasasiyet));
                return r.Next(ilk, son);
            }
        }
        public static double HassasRastgeleSayi(int Hasasiyet, double ilk, double son)
        {
            Random r = new Random(RastgeleSayi(Hasasiyet));
            return (r.NextDouble() * (son - ilk)) + ilk;
        }
    }
}
