using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZoruSor.Lib.Havuz;

namespace ZoruSor.Lib.Soru
{
    public static class ParcaSecimHelper
    {
        public static Dictionary<string, int> ParcaDegerUret(Havuz.Havuz havuz, List<string> parcaList)
        {
            var sonuc = new Dictionary<string, int>();

            foreach (var parca in havuz.ParcaList.OrderBy(s => s.Sira))
            {
                if (parcaList.Contains(parca.Ad))
                {
                    var newId = RandomHelper.RandomNumber(0, parca.Adet - 1);
                    sonuc.Add(parca.Ad, newId);
                }

            }
            return sonuc;
        }

        /// <summary>
        /// Sabit parcalar ciktiktan sonra [parca sayisi- Zorluk derecesi] kadar parcanin degistirilmesi icin adini belirler.
        /// </summary>
        /// <param name="havuz">Parcalarin bulundugu havuz</param>
        /// <param name="sabitParcaAdet">Degisim disi kalacak parca adedi</param>
        /// <param name="cikacakAdet">Cikacak parca adedi ne kadar yuksekse o kadar az parca secilir.</param>
        /// <param name="degisecekParcaAdet">degisecek parca adedi out arguman</param>
        /// <returns>Geriye Degisecek parcalarin isim listesini dondurur.</returns>
        public static List<string> KalaniSec(Havuz.Havuz havuz, int sabitParcaAdet, int cikacakAdet)
        {
            if (havuz.ParcaList.Count <= sabitParcaAdet)
            {
                throw new ApplicationException("sabit parca sayisi havuzdaki parca sayisindan esit ve buyuk olamaz.");
            }
           

            if (cikacakAdet<sabitParcaAdet)
            {
                sabitParcaAdet = cikacakAdet - 1;
                sabitParcaAdet = sabitParcaAdet < 0 ? 0 : sabitParcaAdet;
            }
            
            //parca derecesine parcalari gore kucukten buyuge sirala
            //sabit parca sayisi kadar parcayi atla ve degisebilecek parcalari sec
            var degisebilecekParcalar =
                havuz.ParcaList.OrderByDescending(s => s.Derece).Skip(sabitParcaAdet).ToList();

            var parcaCnt = havuz.ParcaList.Count - (cikacakAdet-1);
            if (parcaCnt == 0)
            {
                return  new List<string>();
            }
            switch (degisebilecekParcalar.Count)
            {
                case 0:
                    throw new ApplicationException("Mantik hatasi degisebilecek hic kayit yok");
                case 1:
                    return new List<string> {degisebilecekParcalar[0].Ad};
            }
            if (degisebilecekParcalar.Count == parcaCnt)
            {
                return degisebilecekParcalar.Select(s => s.Ad).ToList();
            }
            
            //Degisebilecek parcalardan zorluk derecesi kadar rasgele parca sec parca 
            var degisecekParcalar = new List<string>();
            do
            {
                int id;
                do
                {
                    id = RandomHelper.RandomNumber(0, degisebilecekParcalar.Count - 1);
                } while (degisecekParcalar.Exists(s => s.Equals(degisebilecekParcalar[id].Ad)));

                degisecekParcalar.Add(degisebilecekParcalar[id].Ad);
            } while (degisecekParcalar.Count < parcaCnt);
            return degisecekParcalar;
        }

        /// <summary>
        /// Sabit parcalar ciktiktan sonra [parca sayisi- Zorluk derecesi] kadar parcanin degistirilmesi icin adini belirler.
        /// Ancak belirtilen parcalari secim disi birakir.
        /// </summary>
        /// <param name="havuz">Parcalarin bulundugu havuz</param>
        /// <param name="sabitParcaAdet">Degisim disi kalacak parca adedi</param>
        /// <param name="cikacakAdet">Cikacak parca adedi ne kadar yuksekse o kadar az parca secilir.</param>
        /// <param name="sabitParcaList">Sabit Parca Listesi</param>
        /// <returns>Geriye Degisecek parcalarin isim listesini dondurur.</returns>
        public static List<string> KalaniSec(Havuz.Havuz havuz, int sabitParcaAdet, int cikacakAdet, List<string> sabitParcaList )
        {
            if (havuz.ParcaList.Count <= sabitParcaAdet)
            {
                throw new ApplicationException("sabit parca sayisi havuzdaki parca sayisindan esit ve buyuk olamaz.");
            }


            if (cikacakAdet < sabitParcaAdet)
            {
                sabitParcaAdet = cikacakAdet - 1;
                sabitParcaAdet = sabitParcaAdet < 0 ? 0 : sabitParcaAdet;
            }

            //parca derecesine parcalari gore kucukten buyuge sirala
            //sabit parca sayisi kadar parcayi atla ve degisebilecek parcalari sec
            var degisebilecekParcalar =
                havuz.ParcaList.Where(s=>sabitParcaList.Contains(s.Ad)==false).
                OrderByDescending(s => s.Derece).Skip(sabitParcaAdet).ToList();

            var parcaCnt = havuz.ParcaList.Count - (cikacakAdet - 1) - sabitParcaList.Count;
            if (parcaCnt == 0)
            {
                return new List<string>();
            }
            switch (degisebilecekParcalar.Count)
            {
                case 0:
                    throw new ApplicationException("Mantik hatasi degisebilecek hic kayit yok");
                case 1:
                    return new List<string> { degisebilecekParcalar[0].Ad };
            }
            if (degisebilecekParcalar.Count == parcaCnt)
            {
                return degisebilecekParcalar.Select(s => s.Ad).ToList();
            }

            //Degisebilecek parcalardan zorluk derecesi kadar rasgele parca sec parca 
            var degisecekParcalar = new List<string>();
            do
            {
                int id;
                do
                {
                    id = RandomHelper.RandomNumber(0, degisebilecekParcalar.Count - 1);
                } while (degisecekParcalar.Exists(s => s.Equals(degisebilecekParcalar[id].Ad)));

                degisecekParcalar.Add(degisebilecekParcalar[id].Ad);
            } while (degisecekParcalar.Count < parcaCnt);
            return degisecekParcalar;
        }

        /// <summary>
        /// Havuzdan belirtilen adette parcayi rasgele secer. Ancak sabit parca adedi kadar parcayi secim disi birakir.
        /// </summary>
        /// <param name="havuz">Parcalarin bulundugu havuz</param>
        /// <param name="sabitParcaAdet">Parca secimi disinda birakilacak sabit parca adedi</param>
        /// <param name="parcaAdet">secilecek parca adedi</param>
        /// <returns></returns>
        public static List<string> KadariniSec(Havuz.Havuz havuz, int sabitParcaAdet, int parcaAdet)
        {
            var sonuc = new List<string>();
            if (havuz.ParcaList.Count<=sabitParcaAdet)
            {
                throw new ApplicationException("sabit parca sayisi havuzdaki parca sayisindan esit ve buyuk olamaz.");
            }
            if (havuz.ParcaList.Count-sabitParcaAdet<parcaAdet)
            {
                throw new ApplicationException("Havuzdaki parca sayisindan sabit parca sayisi ciktiktan sonra kalan parca sayisi, secilecek parcadan az.");
            }
            //parca derecesine parcalari kucukten buyuge sirala
            //sabit parca sayisi kadar parcayi atla ve degisebilecek parcalari sec
            var degisebilecekParcalar =
               havuz.ParcaList.OrderByDescending(s => s.Derece).Skip(sabitParcaAdet).ToList();

            //Degisebilecek parcalardan zorluk derecesi kadar rasgele parca sec parca 

            if (parcaAdet == havuz.ParcaList.Count)
            {
                havuz.ParcaList.ForEach(s => sonuc.Add(s.Ad));
            }
            else if (parcaAdet > 0)
            {
                do
                {
                    int id;
                    do
                    {
                        id = RandomHelper.RandomNumber(0, degisebilecekParcalar.Count - 1);
                    } while (sonuc.Exists(s => s.Equals(degisebilecekParcalar[id].Ad)));

                    sonuc.Add(degisebilecekParcalar[id].Ad);
                } while (sonuc.Count < parcaAdet &&
                sonuc.Count < havuz.ParcaList.Count - sonuc.Count);
            }

            return sonuc;
        }

        /// <summary>
        /// Zorluk Derecesi kadar parcanin degistirilmesi icin adini belirler
        /// </summary>
        /// <param name="havuz"></param>
        /// <param name="zorlukDerece"></param>
        /// <param name="degisecekParcaAdet"></param>
        /// <returns>Geriye Degisecek parcalarin isim listesini dondurur.</returns>
        public static List<string> KadariniSec(Havuz.Havuz havuz, int zorlukDerece)
        {
            //parca derecesine parcalari kucukten buyuge sirala
            //sabit parca sayisi kadar parcayi atla ve degisebilecek parcalari sec
            var degisebilecekParcalar =
                havuz.ParcaList.OrderByDescending(s => s.Derece).ToList();

            //Degisebilecek parcalardan zorluk derecesi kadar rasgele parca sec parca 
            
            var degisecekParcalar = new List<string>();
            if (zorlukDerece == havuz.ParcaList.Count)
            {
                havuz.ParcaList.ForEach(s => degisecekParcalar.Add(s.Ad));
            }
            else if (zorlukDerece >0)
            {
                do
                {
                    int id;
                    do
                    {
                        id = RandomHelper.RandomNumber(0, degisebilecekParcalar.Count - 1);
                    } while (degisecekParcalar.Exists(s => s.Equals(degisebilecekParcalar[id].Ad)));

                    degisecekParcalar.Add(degisebilecekParcalar[id].Ad);
                } while (degisecekParcalar.Count < zorlukDerece);
            }
            return degisecekParcalar;
        }

        /// <summary>
        /// Zorluk Derecesi kadar parcanin degistirilmesi icin adini belirler
        /// </summary>
        /// <param name="havuz"></param>
        /// <param name="zorlukDerece"></param>
        /// <param name="degisecekParcaAdet"></param>
        /// <param name="haricParcaAdList"></param>
        /// <returns>Geriye Degisecek parcalarin isim listesini dondurur.</returns>
        public static List<string> KadariniSec(Havuz.Havuz havuz, int zorlukDerece, List<string> haricParcaAdList)
        {
            //parca derecesine parcalari kucukten buyuge sirala
            //sabit parca sayisi kadar parcayi atla ve degisebilecek parcalari sec
            var degisebilecekParcalar =
                havuz.ParcaList.Where(s=>haricParcaAdList.Contains(s.Ad)==false).OrderByDescending(s => s.Derece).ToList();

            //Degisebilecek parcalardan zorluk derecesi kadar rasgele parca sec parca 

            var degisecekParcalar = new List<string>();
            if (zorlukDerece == havuz.ParcaList.Count)
            {
                havuz.ParcaList.ForEach(s => degisecekParcalar.Add(s.Ad));
            }
            else if (zorlukDerece > 0)
            {
                do
                {
                    int id;
                    do
                    {
                        id = RandomHelper.RandomNumber(0, degisebilecekParcalar.Count - 1);
                    } while (degisecekParcalar.Exists(s => s.Equals(degisebilecekParcalar[id].Ad)));

                    degisecekParcalar.Add(degisebilecekParcalar[id].Ad);
                } while (degisecekParcalar.Count < zorlukDerece && 
                degisecekParcalar.Count < havuz.ParcaList.Count- haricParcaAdList.Count);
            }
            return degisecekParcalar;
        }


        public static List<Parca> DonusumParcaList(Havuz.Havuz havuz, int zorlukDerece, out List<string> donusecekParcalar)
        {
            var donusumParcalari = havuz.ParcaList.Where(s => s.DonusumResimList.Count > 0).ToList();

            

            donusecekParcalar = new List<string>();

            if (zorlukDerece == donusumParcalari.Count)
            {
                foreach (var parca in donusumParcalari)
                {
                    donusecekParcalar.Add(parca.Ad);
                }
            }
            else
            {
                do
                {
                    int id;
                    do
                    {
                        id = RandomHelper.RandomNumber(0, donusumParcalari.Count - 1);

                    } while (donusecekParcalar.Contains(donusumParcalari[id].Ad));
                    donusecekParcalar.Add(donusumParcalari[id].Ad);

                } while (zorlukDerece > donusecekParcalar.Count);
            }
            return donusumParcalari;
        }
    }
}
