using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZoruSor.Lib.ResimBuilder;

namespace ZoruSor.Lib.Soru
{/// <summary>
 /// Dondur Bul problemlerine benzer. Ancak bu soru turunde resimdeki objeleri resim alaninin merkezini baz alarak
 /// resimdeki parcalari 0, 90, 180 ve 270 dereceden rastgele bir aci ile dondurur. Sonraki parcalari onceki parca ile 
 /// ic ice gecmeyecek sekilde dondurur. Ornegin ilk parca 90 derece donmusse ikinci parca  180 derece dondugunde 
 /// birinci parcanin icinde kaliyorsa 180 disinda farkli bir aciyla dondurulur. Ilk resim rastgele secilir.
 /// Parcalarin tum enveloplarinin kesisim noktasini bulup bu nokta baz alinarak dondurme yapilir.
 /// </summary>
    public class YerDegistir1 : SoruBuilder
    {
        private YerDegistirArgs _soruArg;
        private List<YerDegistirArgs> _celdiriciAciList;
        private YerDegistirArgs SatirOlustur(YerDegistirArgs arg = null)
        {


            var sonuc = arg ?? new YerDegistirArgs();
            sonuc.Havuz = Havuz;

            // Ilk olarak rastgele bir resim olustur.
            var resim = ResimHelper.RasgeleResimUret(Havuz);
            sonuc.ReferansResim = resim;
            sonuc.ResimBoyut = ResimBoyut;
            sonuc.Havuz = Havuz;
            if (arg == null)
            {

                for (int i = 0; i < resim.Count; i++)
                {
                    sonuc.ReferansYerList.Add(new ParcaYer { Ad = resim.ElementAt(i).Key, IlkKonum = i, SonKonum = i });
                }
                for (int i = 0; i < 2; i++)
                {
                    var id1 = RandomHelper.RandomNumber(0, resim.Count - 1);
                    var id2 = RandomHelper.RandomDifferentNumber(0, resim.Count - 1, id1);
                    sonuc.YerDegistir(id1, id2);
                }
            }
            else
            {
                sonuc.ReferansYerList = arg.ReferansYerList;
                sonuc.DegisimMetin = arg.DegisimMetin;
            }

            return sonuc;
        }




        public override void ReferansResimUret()
        {

            //Birinci satiri uret.
            var satir1 = SatirOlustur();
            Soru.ReferansResimList.Add(ResimHelper.IslemResimUret(satir1));
            //Ikinci satiri uret.
            _soruArg = SatirOlustur(satir1);
            Soru.ReferansResimList.Add(ResimHelper.IslemSoruResimUret(_soruArg));
            //Islem resmini uret.
        }

        public override void DogruCevapUret()
        {
            Soru.DogruCevapList.Add(ResimHelper.DondurResimUret(Havuz, _soruArg.ReferansResim, _soruArg.ReferansYerList, ResimBoyut));
        }

        public override void CeldiriciUret()
        {
            _celdiriciAciList = new List<YerDegistirArgs>(CeldiriciAdet); for (int i = 0; i < CeldiriciAdet; i++)
            {
                var yeniCeldirici = new YerDegistirArgs
                {
                    Havuz = Havuz,
                    ResimBoyut = ResimBoyut,
                    YerDegisimList = _soruArg.YerDegisimList,
                    ReferansResim = _soruArg.ReferansResim,
                    ReferansYerList = _soruArg.ReferansYerList
                };

                //Havuzdaki parca sayisi - Zorluk derecesinin bir eksigi kadar degisim uygula
                var kalanYerDegisim = Havuz.ParcaList.Count - (SabitParcaAdet + 1);
                for (int j = 0; j < Havuz.ParcaList.Count - (ZorlukDerece - 1); j++)
                {
                    //Hangi degisimin yapilacagini rastgele sec.
                    var degisimTip = RandomHelper.RandomNumber(1, 3);
                    //Kalan yer degisim adedi sifirdan buyukse ve rastgele true gelmisse
                    //yer degistirecek parcalardan birisinde degistir Ornek: 1-2 yerine 1-3 yap
                    if (kalanYerDegisim > 0 && degisimTip == 1)
                    {
                        var id = RandomHelper.RandomNumber(0, yeniCeldirici.YerDegisimList.Count - 1);
                        var degisim = yeniCeldirici.YerDegisimList.ElementAt(id);
                        int id1;
                        int id2;

                        if (RandomHelper.RandomBool())
                        {
                            id1 = RandomHelper.RandomDifferentNumber(0, Havuz.ParcaList.Count - 1, degisim);
                            id2 = degisim[1];
                        }
                        else
                        {
                            id1 = degisim[0];
                            id2 = RandomHelper.RandomDifferentNumber(0, Havuz.ParcaList.Count - 1, degisim);
                        }

                        yeniCeldirici.YerDegisimList.RemoveAt(id);
                        yeniCeldirici.YerDegisimList.Insert(id, new[] { id1, id2 });
                        yeniCeldirici.YenidenSirala();
                        kalanYerDegisim--;
                        continue;
                    }
                    //Kalan yer degisim adedi sifirdan buyukse ve rastgele true gelmisse
                    // Yer Degistirecek parcalarin sirasi degistirlebilir. Ornek: 1-2 yerine 2-1 yap
                    if (kalanYerDegisim > 0 && degisimTip == 2)
                    {
                        var id = RandomHelper.RandomNumber(0, yeniCeldirici.YerDegisimList.Count - 1);
                        var degisim = yeniCeldirici.YerDegisimList.ElementAt(id);

                        var id1 = degisim[1];
                        var id2 = degisim[0];

                        yeniCeldirici.YerDegisimList.RemoveAt(id);
                        yeniCeldirici.YerDegisimList.Insert(id, new[] { id1, id2 });
                        yeniCeldirici.YenidenSirala();
                        kalanYerDegisim--;
                        continue;
                    }
                    if (kalanYerDegisim == 0 || degisimTip == 3)
                    {
                        //Yer degisimi dogru cevap ile ayni birakilip parca resmi degistirilebilir.
                        var parcaId = RandomHelper.RandomNumber(0, yeniCeldirici.ReferansResim.Count - 1);
                        var seciliParca = yeniCeldirici.ReferansResim.ElementAt(parcaId);
                        var havuzParca = Havuz.ParcaList.FirstOrDefault(s => s.Ad == seciliParca.Key);
                        if (havuzParca != null)
                        {
                            var seciliParcaResimCnt = havuzParca.Adet - 1;

                            var yeniResimId = RandomHelper.RandomDifferentNumber(0, seciliParcaResimCnt, seciliParca.Value);
                            yeniCeldirici.ReferansResim[seciliParca.Key] = yeniResimId;
                        }
                        continue;
                    }
                    j--;
                }

                if (yeniCeldirici.Equals(_soruArg) || _celdiriciAciList.Any(s => yeniCeldirici.Equals(s)))
                {
                    i--;
                    continue;
                }
                _celdiriciAciList.Add(yeniCeldirici);
                Soru.CeldiriciList.Add(ResimHelper.DondurResimUret(Havuz, yeniCeldirici.ReferansResim, yeniCeldirici.ReferansYerList, ResimBoyut));

            }
        }
    }
}
