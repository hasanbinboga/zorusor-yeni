using System.Collections.Generic;
using System.Linq;

namespace ZoruSor.Lib.Soru
{
    /// <summary>
    /// Diger Analoji test turunden farklidir. 
    /// Birinci satirda birbirinden tamamen farkli iki tane referans resim uretilir.
    /// Iki resimden birisi rasgele donor olarak secilir.
    /// Donor resimden zorluk derecesi kadar parca secilir. 
    /// Bu parcalar donor parca ile diger parcalarla degisir. Sonucta olusan resimler  isleme giren resimlerin 
    /// yaninda gosterilir.
    /// Ikinci satirda  yine iki tane birbirinden tamamen farkli resim uretilir.
    /// Bu resimlerden bir tanesini donor olarak secip diger resimle zorluk seviyesi kadar parca
    /// ile degistirilir olusan sonuc resimler dogru cevap olarak eklenir.
    /// </summary>
    class AnalojiIkili2: SoruBuilder
    {
        private CiktiResim _referansResim1, _referansResim2, _dogruCevap;
        
        public override void ReferansResimUret()
        {
            //Iki tane birbirinden tamamen farkli iki referans resim uret
            _referansResim1 = ResimHelper.RasgeleResimUret(Havuz, ResimBoyut);
            _referansResim2 = ResimHelper.RasgeleFarkliResimUret(Havuz, new List<Dictionary<string, int>> { _referansResim1.ParcaList}, ResimBoyut);
           
            //Bu iki referans resmi birlestir. 
            var birlesik1 = ResimHelper.IkiResimBirlestir(_referansResim1, _referansResim2, ResimBoyut);

            

            //Zorluk derecesi kadar parca sec.
            var degisecekParcalar = ParcaSecimHelper.KadariniSec(Havuz, ZorlukDerece);

            //rasgele bir donor sec.
            if (RandomHelper.RandomBool())
            {
               //Birinci resim donor oldugundan birinci resimdeki parcalari ikinci resimdeki parcalarla degistir.
                _referansResim1 = ResimHelper.ParcaDegistir(Havuz, _referansResim1.ParcaList, _referansResim2.ParcaList, 
                                                out _referansResim2, degisecekParcalar, ResimBoyut);
            }
            else
            {
                //Ikinci resim donor oldugundan birinci resimdeki parcalari ikinci resimdeki parcalarla degistir.
                _referansResim2 = ResimHelper.ParcaDegistir(Havuz, _referansResim2.ParcaList, _referansResim1.ParcaList,
                                                out _referansResim1, degisecekParcalar, ResimBoyut);
            }
            
            //Yeni Referans resimleri birlestir.
            var birlesik2 = ResimHelper.IkiResimBirlestir(_referansResim1, _referansResim2, ResimBoyut);

            //Islem satiri olustur. Referans resimlere ekle.
            Soru.ReferansResimList.Add(ResimHelper.IslemResimUret(birlesik1, birlesik2, ResimBoyut));


            //Iki tane birbirinden tamamen farkli iki referans resim uret
            _referansResim1 = ResimHelper.RasgeleResimUret(Havuz, ResimBoyut);
            _referansResim2 = ResimHelper.RasgeleFarkliResimUret(Havuz, new List<Dictionary<string, int>> { _referansResim1.ParcaList }, ResimBoyut);

            //Bu iki referans resmi birlestir. 
            birlesik1 = ResimHelper.IkiResimBirlestir(_referansResim1, _referansResim2, ResimBoyut);



           //rasgele bir donor sec.
            if (RandomHelper.RandomBool())
            {
                //Birinci resim donor oldugundan birinci resimdeki parcalari ikinci resimdeki parcalarla degistir.
                _referansResim1 = ResimHelper.ParcaDegistir(Havuz, _referansResim1.ParcaList, _referansResim2.ParcaList,
                                                out _referansResim2, degisecekParcalar, ResimBoyut);
            }
            else
            {
                //Ikinci resim donor oldugundan birinci resimdeki parcalari ikinci resimdeki parcalarla degistir.
                _referansResim2 = ResimHelper.ParcaDegistir(Havuz, _referansResim2.ParcaList, _referansResim1.ParcaList,
                                                out _referansResim1, degisecekParcalar, ResimBoyut);
            }

            //Yeni Referans resimleri birlestir. Bu resim dogru cevaptir.
            _dogruCevap = ResimHelper.IkiResimBirlestir(_referansResim1, _referansResim2, ResimBoyut);

            
            //Soru satiri olustur.
            Soru.ReferansResimList.Add(ResimHelper.IslemSoruResimUret(birlesik1, ResimBoyut, birlesik1.Image.Height));
        }

        public override void DogruCevapUret()
        {
            Soru.DogruCevapList.Add(_dogruCevap);
        }

        public override void CeldiriciUret()
        {
            for (int i = 0; i < CeldiriciAdet; i++)
            {
                bool solDegisti, sagDegisti;
                solDegisti = RandomHelper.RandomBool();
                sagDegisti = !solDegisti || RandomHelper.RandomBool();
                CiktiResim solResim, sagResim;

                if (solDegisti)
                {
                    //Zorluk derecesine gore degisecek parcalari sec. (Farklisini bul gibi)
                    var degisecekParcalar = ParcaSecimHelper.KalaniSec(Havuz, SabitParcaAdet, ZorlukDerece);
                    solResim = ResimHelper.ResimDegistirUret(Havuz, _referansResim1, degisecekParcalar, ResimBoyut);
                }
                else
                {
                    solResim = _referansResim1;
                }

                if (sagDegisti)
                {
                    //Zorluk derecesine gore degisecek parcalari sec. (Farklisini bul gibi)
                    var degisecekParcalar = ParcaSecimHelper.KalaniSec(Havuz, SabitParcaAdet, ZorlukDerece);
                    sagResim = ResimHelper.ResimDegistirUret(Havuz, _referansResim2, degisecekParcalar, ResimBoyut);
                }
                else
                {
                    sagResim = _referansResim2;
                }

                if ((Soru.DogruCevapList[0].ParcaList.Equals(solResim.ParcaList) && Soru.DogruCevapList[0].DigerResimParcaList.Equals(sagResim.ParcaList)) ||
                    Soru.CeldiriciList.Any(s => s.ParcaList.Equals(solResim.ParcaList) && s.DigerResimParcaList.Equals(sagResim.ParcaList)))
                {
                    i--;
                }
                else
                {
                   
                    //Bu iki  parca resmi birlestir.
                    var birlesik1 = ResimHelper.IkiResimBirlestir(solResim, sagResim, ResimBoyut);

                    //Resimleri birlestir.
                    //Celdiricilerde daha once yoksa ekle.
                    Soru.CeldiriciList.Add(birlesik1);
                }
            }
        }
    }
}
