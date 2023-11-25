using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BilisselBeceriler.Entities;
using BilisselBeceriler.Data;
using System.IO;
using BilisselBeceriler.Entities.Web;

namespace BilisselBeceriler.FotoAktarim
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Öğrenci fotoğraflarının aktarımı başladı");
            Console.Read();

            using (Repository<OgrenciFotograf> Repository = new Repository<OgrenciFotograf>())
            {
                var OgrenciFotografListe = Repository.Liste();
                foreach (var item in OgrenciFotografListe)
                {
                    try
                    {
                        byte[] Bufer = null;//File.ReadAllBytes(item.Fotograf);
                        item.Resim = Bufer;
                        Repository.Guncelle(item);
                        //Console.WriteLine(item.Ogrenci.Adi + " " + item.Ogrenci.Soyadi);
                    }
                    catch (Exception ex)
                    {
                        //Console.WriteLine(item.Ogrenci.Adi + " " + item.Ogrenci.Soyadi + " !!!! Hata" + ex.Message);
                    }
                }
            }
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Bitti");
            Console.Read();
        }
    }
}
