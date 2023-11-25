using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZoruSor.Lib.Soru
{
    /// <summary>
    /// Bu soru turunde bir referans resmin daginik ve butun halinden olusan toplam alti resim vardir.
    /// Bu resimlerden dordunde daginik ve butun resimleri birbirinin aynisidir. Diger iki resimde daginik ve butun
    /// resimler birbirinden farklidir. Secenekler ise bu resimlerin numaralarindan (I, II, III ve IV) gibi olusur. 
    /// </summary>
    public class SinifParcaButun : SoruBuilder
    {
        private List<int> _dogruResimList;
        private readonly int _totalCount = 6;
        string ToRomen(int id)
        {
            var sonuc="";
            switch (id)
            {
                case 1:
                    sonuc += "I";
                    break;
                case 2:
                    sonuc += "II";
                    break;
                case 3:
                    sonuc += "III";
                    break;
                case 4:
                    sonuc += "IV";
                    break;
                case 5:
                    sonuc += "V";
                    break;
                case 6:
                    sonuc += "VI";
                    break;
            }
            return sonuc;
        }
        string CevapUret(List<int> resimIdList)
        {
            var sonuc = "";
            var sirali = resimIdList.OrderBy(s => s).ToList();
            for (int i = 0; i < sirali.Count; i++)
            {
                if (i < sirali.Count-1)
                {
                    sonuc += ToRomen(sirali[i]) + ", ";
                }
                else
                {
                    sonuc = sonuc.Substring(0, sonuc.Length - 2);
                    sonuc += " ve " + ToRomen(sirali[i]);
                }
            }
            return sonuc;

        }
        public override void ReferansResimUret()
        {
            _dogruResimList = new List<int>(4);

            

            //Hatali resim id lerini belirle.
            var hataList = new List<int> { RandomHelper.RandomNumber(1, _totalCount) };
            hataList.Add(RandomHelper.RandomDifferentNumber(1, _totalCount, hataList.ToArray()));

            //Alti kere
            for (int i = 1; i <= _totalCount; i++)
            {

                //Rastgele referans resim uret.
                var referansResim = ResimHelper.RasgeleResimUret(Havuz, ResimBoyut);
                CiktiResim parca; 

                //Bu resim id si hatali resim idleri arasinda ise
                if (hataList.Contains(i))
                {
                    //Zorluk seviyesine gore daginik resmin parcalarini degistir.
                    var degisecekParcalar = ParcaSecimHelper.KalaniSec(Havuz, SabitParcaAdet, ZorlukDerece);

                    var hata = ResimHelper.ResimDegistirUret(Havuz, referansResim, degisecekParcalar, ResimBoyut);
                    parca = ResimHelper.ParcaResimUret(Havuz, hata.ParcaList, ResimBoyut / 4);
                }
                else
                {
                    parca = ResimHelper.ParcaResimUret(Havuz, referansResim.ParcaList, ResimBoyut / 4);

                    //Hatali resimler haricindeki resim idleri dogru cevap olarak belirle.
                    _dogruResimList.Add(i);
                }


                //Bu resimlerden daginik butun resim uret
                //Parca resimlerini birlestir.
                var birlesik1 = ResimHelper.IkiResimBirlestir(referansResim, parca, ResimBoyut);

                //Bu resmi referanslara ekle.
                Soru.ReferansResimList.Add(birlesik1);
            }
        }

        public override void DogruCevapUret()
        {
            //Dogru resim Id lerinden dogru cevap uret.
            Soru.DogruCevapStrList.Add(CevapUret(_dogruResimList));
        }

        public override void CeldiriciUret()
        {
            //Her celdirici icin
            for (int i = 0; i < CeldiriciAdet; i++)
            {
                //Dogru resimlerden 3 ila 2 tanesini al.
                var rnd = RandomHelper.RandomNumber(2, 3);
                var celdiriciList = new List<int>();
                var idList = new List<int>();

                for (int j = 0; j < rnd; j++)
                { 
                    idList.Add(RandomHelper.RandomDifferentNumber(0, _dogruResimList.Count-1, idList.ToArray()));
                }

                foreach (var id in idList)
                {
                   celdiriciList.Add(_dogruResimList[id]);
                }

                //dogru resim sayisina gore 4- dogru resim kadar hatali resim al.
                var kalan = 4 - rnd;
                for (int j = 0; j < kalan; j++)
                {
                    celdiriciList.Add(RandomHelper.RandomDifferentNumber(1, _totalCount, celdiriciList.ToArray()));
                }

                //Belirlenen resim id lerinden celdirici uret.
                var celdirici = CevapUret(celdiriciList);
                if (Soru.CeldiriciStrList.Any(s=>s == celdirici) || Soru.DogruCevapStrList.Any(s=> s == celdirici))
                {
                    i--;
                }
                else
                {
                    Soru.CeldiriciStrList.Add(celdirici);
                }
            }


        }
    }
}
