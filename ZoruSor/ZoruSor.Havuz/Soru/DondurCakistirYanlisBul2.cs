using System;
using System.Collections.Generic;
using System.Linq;
using ZoruSor.Lib.ResimBuilder;

namespace ZoruSor.Lib.Soru
{
    /// <summary>
    /// Cakistir Yanlisi bul testlerine benzer Parcalari uc esit referans resme dagitir. Her bir referans resimdeki
    /// parcayi rastgele bir aciyla dondurur. Dondurulmus parcalarin bir araya gelmesiyle olusan resmi celdiricilere atar.
    /// dogru cevap, celdiricilerdeki ayni aci ile dondurulmus farkli parca resimlerin bir araya
    /// gelmesiyle olusturulur. Zorluk derecesi arttikca degisen parca sayisi azalir.
    /// </summary>
    public class DondurCakistirYanlisBul2 : SoruBuilder
    {
        private DondurBulSatirArg _soruArg;

        private DondurBulSatirArg SatirOlustur(DondurBulSatirArg arg = null)
        {
            var sonuc = arg ?? new DondurBulSatirArg();
            sonuc.Havuz = Havuz;

            //Rastgele bir resim uret
            var resim = ResimHelper.RasgeleResimUret(Havuz);

            if (arg == null)
            {
                sonuc.ParcaExtentList = ResimHelper.ParcaExtentGetir(Havuz, ResimBoyut);
            }

            foreach (var parcaExtent in sonuc.ParcaExtentList)
            {
                parcaExtent.Id = resim[parcaExtent.Ad];
            }


            if (arg == null)
            {
                //Resimdeki parca sayisini ikiye bol
                //Ikiye gore modunu al 1 ise birinci referans icin parca sayisini 1 arttir.
                int resim1ParcaAdet, resim2ParcaAdet;
                switch (resim.Count % 3)
                {
                    case 2:
                        resim1ParcaAdet = resim.Count / 3 + 1;
                        resim2ParcaAdet = resim1ParcaAdet;
                        break;
                    case 1:
                        resim1ParcaAdet = resim.Count / 3 + 1;
                        resim2ParcaAdet = resim1ParcaAdet - 1;
                        break;
                    default:
                        resim1ParcaAdet = resim.Count / 3;
                        resim2ParcaAdet = resim1ParcaAdet;
                        break;
                }

                sonuc.Yon1 = RandomHelper.RandomBool();
                //Resimde yer alacak parcalari secerken parcalarin extent yuzolcumune gore siralanmasi gerekiyor.
                //Buna gore resim1 de extenti en buyuk parca/parcalar yer alacak. resim2 de daha extenti kucuk olan 
                //parca/parcalar yer alacak.
                //Ayrica ayni resimde yer alan parcalarin birbirleri icinde olup olmadigi degerlendirilecek.
                //Bu olmazsa farkli bir parcanin icinde kalan bir parca farkli resimde olursa birlikte donmeyeceklerinden 
                //resimde acikliklar olur.

                //Resim1 deki her parca icin
                sonuc.Resim1 = ParcaAciUret(sonuc.ParcaExtentList
                                                 .OrderByDescending(s => s.Yuzolcum)
                                                 .Take(resim1ParcaAdet)
                                                 .ToList(),
                                            sonuc.Yon1);


                //Ayni islemi satirdaki ikinci resim icin de yap.
                sonuc.Yon2 = RandomHelper.RandomBool();
                sonuc.Resim2 = ParcaAciUret(sonuc.ParcaExtentList
                                                 .OrderByDescending(s => s.Yuzolcum)
                                                 .Skip(resim1ParcaAdet)
                                                 .Take(resim2ParcaAdet)
                                                 .ToList(),
                                            sonuc.Yon2);
                //Ayni islemi satirdaki ucuncu resim icin de yap.
                sonuc.Yon3 = RandomHelper.RandomBool();
                sonuc.Resim3 = ParcaAciUret(sonuc.ParcaExtentList
                                                 .OrderByDescending(s => s.Yuzolcum)
                                                 .Skip(resim1ParcaAdet + resim2ParcaAdet)
                                                 .ToList(),
                                            sonuc.Yon2);
                //Sonuc resmini uret.
                sonuc.ResimBoyut = ResimBoyut;
                sonuc.SonucResim = new List<ParcaAci>(sonuc.Resim1);
                sonuc.SonucResim.AddRange(sonuc.Resim2);
                sonuc.SonucResim.AddRange(sonuc.Resim3);
            }
            else
            {
                //resim1 in id lerini guncelle
                foreach (var parcaAci in sonuc.Resim1)
                {
                    parcaAci.Id = resim[parcaAci.Ad];
                }
                //resim2 nin idlerini guncelle
                foreach (var parcaAci in sonuc.Resim2)
                {
                    parcaAci.Id = resim[parcaAci.Ad];
                }
                //resim3 un idlerini guncelle
                foreach (var parcaAci in sonuc.Resim3)
                {
                    parcaAci.Id = resim[parcaAci.Ad];
                }

                //sonuc resmin idlerini guncelle
                foreach (var parcaAci in sonuc.SonucResim)
                {
                    parcaAci.Id = resim[parcaAci.Ad];
                }
            }
            return sonuc;
        }
        private List<ParcaAci> ParcaAciUret(List<ParcaExtent> resim, bool yon)
        {

            //Her parca icin dondurulmus resimleri uret.
            var parcas = resim;
            var sonuc = new List<ParcaAci>(parcas.Count);
            foreach (var parca in parcas)
            {
                //Parca sayisi kadar +- 20 ila +-340 arasinda aci belirle.
                var yeniAci = RandomHelper.RandomNumber(20, 340, 10);
                //Belirlenen aciya ve resim yonune gore parca aci objesini olustur.
                sonuc.Add(new ParcaAci
                {
                    Id = parca.Id,
                    Ad = parca.Ad,
                    Aci = yon ? yeniAci : -1 * yeniAci
                });
            }
            return sonuc;
        }
        public override void ReferansResimUret()
        {
            //Birinci satiri uret.
            _soruArg = SatirOlustur();
            Soru.ReferansResimList.Add(ResimHelper.IslemSoruResimUret(_soruArg));
        }

        public override void DogruCevapUret()
        {
            //Parca Sayisi - Zorluk derecesi kadar parcayi sec.
            var degisecekParcalar = ParcaSecimHelper.KalaniSec(Havuz, SabitParcaAdet, ZorlukDerece);

            //Degismeyecek parcalari celdirici aci listesine dogru cevaptan aynen ekle.
            var dogruCevap = new List<ParcaAci>();
            foreach (var seciliParca in _soruArg.SonucResim.Where(s => degisecekParcalar.Contains(s.Ad) == false))
            {
                dogruCevap.Add(seciliParca);
            }

            //Secilen parca sayisini al.
            //Secilen parcalari degistir ve ayni aciyla dondur.
            for (int j = 0; j < degisecekParcalar.Count; j++)
            {
                var aa = _soruArg.SonucResim.FirstOrDefault(s => s.Ad == degisecekParcalar[j]);
                if (aa == null)
                {
                    throw new Exception("Belirtilen parcaya ait aci bulunamadi");
                }

                var seciliParcaAci = new ParcaAci { Id = aa.Id, Ad = aa.Ad, Aci = aa.Aci };

                var parcaResimAdet = Havuz.ParcaList.First(s => s.Ad == seciliParcaAci.Ad).Adet - 1;

                var yeniId = RandomHelper.RandomDifferentNumber(0, parcaResimAdet, seciliParcaAci.Id);
                seciliParcaAci.Id = yeniId;
                dogruCevap.Add(seciliParcaAci);
            }

            //Yen uretilen resmi celdirici olarak ata.
            Soru.DogruCevapList.Add(ResimHelper.DondurResimUret(Havuz, dogruCevap, _soruArg.ParcaExtentList, ResimBoyut));

        }

        public override void CeldiriciUret()
        {
            new List<List<ParcaAci>>(CeldiriciAdet);
            //Cerldirici sayisi kadar
            for (int i = 0; i < CeldiriciAdet; i++)
            {
                //Soru Satirinin sonucunu dogru cevap olarak ekle.
                Soru.CeldiriciList.Add(ResimHelper.DondurResimUret(Havuz, _soruArg.SonucResim, _soruArg.ParcaExtentList, ResimBoyut));
            }
        }
    }
}
