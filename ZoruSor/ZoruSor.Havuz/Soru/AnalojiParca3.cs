using System.Linq;

namespace ZoruSor.Lib.Soru
{
    /// <summary>
    /// AnalojiParca1 in benzeridir. Ilk resimler tum, ikinci resimler parcalidir.
    /// Bu test turunde iki satirdan olusan bir referans resim vardir.
    /// Birinci satirda ilk olarak iki tane referans resim isleme girerek sol tarafta bu resimlerin
    /// parcalanmis hali gosterilir.
    /// 
    /// Ikinci satirda ilk referans resimde iki tane butunlesik resim vardir. Bu iki referans resmin 
    /// parcalanmis hallerinin ne oldugu sorulmaktadir.
    /// 
    /// Dogru cevap bu iki resmin parcalanmis halidir.
    /// </summary>
    class AnalojiParca3 : SoruBuilder
    {
        private CiktiResim _referansResim1, _referansResim2;
        public override void ReferansResimUret()
        {
            //Iki tane birbirinden farkli referans resim uret
            _referansResim1 = ResimHelper.RasgeleResimUret(Havuz, ResimBoyut);

            do
            {
                _referansResim2 = ResimHelper.RasgeleResimUret(Havuz, ResimBoyut);
            } while (_referansResim1.Equals(_referansResim2));


            //Referans resimlerin parca resimlerini uret
            var parca1 = ResimHelper.ParcaResimUret(Havuz, _referansResim1.ParcaList, ResimBoyut / 4);
            var parca2 = ResimHelper.ParcaResimUret(Havuz, _referansResim2.ParcaList, ResimBoyut / 4);

            //Bu iki  parca resmi birlestir.
            var birlesik1 = ResimHelper.IkiResimBirlestir(_referansResim1, parca2, ResimBoyut);

            //Referans resimleri birlestir.
            //Referans resimleri birlestir.
            var birlesik2 = ResimHelper.IkiResimBirlestir(parca1, _referansResim2, ResimBoyut);

            //Islem satiri olustur. Referans resimlere ekle.
            Soru.ReferansResimList.Add(ResimHelper.IslemResimUret(birlesik2, birlesik1, ResimBoyut));

            //Iki tane birbirinden farkli referans resim uret 
            _referansResim1 = ResimHelper.RasgeleResimUret(Havuz, ResimBoyut);

            do
            {
                _referansResim2 = ResimHelper.RasgeleResimUret(Havuz, ResimBoyut);
            } while (_referansResim1.Equals(_referansResim2));

            parca1 = ResimHelper.ParcaResimUret(Havuz, _referansResim1.ParcaList, ResimBoyut / 4);
            //Parca resimlerini birlestir.
            birlesik2 = ResimHelper.IkiResimBirlestir(parca1, _referansResim2, ResimBoyut);
            
            //Soru satiri olustur.
            Soru.ReferansResimList.Add(ResimHelper.IslemSoruResimUret(birlesik2, ResimBoyut, parca1.Image.Height));
        }

        public override void DogruCevapUret()
        {
            //Referans resimlerin parca resimlerini uret
            var parca2 = ResimHelper.ParcaResimUret(Havuz, _referansResim2.ParcaList, ResimBoyut / 4);

            //Bu iki  parca resmi birlestir.
            var birlesik1 = ResimHelper.IkiResimBirlestir(_referansResim1, parca2, ResimBoyut);

            Soru.DogruCevapList.Add(birlesik1);
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
                    //Referans resimlerin parca resimlerini uret
                    var parca2 = ResimHelper.ParcaResimUret(Havuz, sagResim.ParcaList, ResimBoyut / 4);

                    //Bu iki  parca resmi birlestir.
                    var birlesik1 = ResimHelper.IkiResimBirlestir(solResim, parca2, ResimBoyut);

                    //Resimleri birlestir.
                    //Celdiricilerde daha once yoksa ekle.
                    Soru.CeldiriciList.Add(birlesik1);
                }
            }
        }
    }
}
