using System.Linq;

namespace ZoruSor.Lib.Soru
{
    /// <summary>
    /// Bu test turunde iki satirdan olusan bir referans resim vardir.
    /// Birinci satirda ilk olarak iki tane parca resmi isleme girerek butunlesmis 
    /// halin sagdaki resimlerde gosterilir.
    /// 
    /// Ikinci satirda ilk referans resimde iki tane parcalanmis resim vardir. Bu iki referans resmin 
    /// birlesmis halininin ne oldugu sorulmaktadir.
    /// 
    /// Dogru cevap bu iki resmin birlesmis halidir.
    /// </summary>
    class AnalojiParca1 : SoruBuilder
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
            var birlesik1 = ResimHelper.IkiResimBirlestir(parca1, parca2, ResimBoyut);

            //Referans resimleri birlestir.
            //Referans resimleri birlestir.
            var birlesik2 = ResimHelper.IkiResimBirlestir(_referansResim1, _referansResim2, ResimBoyut);

            //Islem satiri olustur. Referans resimlere ekle.
            Soru.ReferansResimList.Add(ResimHelper.IslemResimUret(birlesik1, birlesik2, ResimBoyut));

            //Iki tane birbirinden farkli referans resim uret 
            _referansResim1 = ResimHelper.RasgeleResimUret(Havuz, ResimBoyut);

            do
            {
                _referansResim2 = ResimHelper.RasgeleResimUret(Havuz, ResimBoyut);
            } while (_referansResim1.Equals(_referansResim2));

            //Bu referans resimlerin parca resimlerini uret.
            parca1 = ResimHelper.ParcaResimUret(Havuz, _referansResim1.ParcaList, ResimBoyut / 4);
            parca2 = ResimHelper.ParcaResimUret(Havuz, _referansResim2.ParcaList, ResimBoyut / 4);

            //Parca resimlerini birlestir.
            birlesik1 = ResimHelper.IkiResimBirlestir(parca1, parca2, ResimBoyut);

            //Soru satiri olustur.
            Soru.ReferansResimList.Add(ResimHelper.IslemSoruResimUret(birlesik1, ResimBoyut, birlesik1.Image.Height));
        }

        public override void DogruCevapUret()
        {
            //Referans resimleri birlestirerek dogru cevaba ekle.
            var birlesik1 = ResimHelper.IkiResimBirlestir(_referansResim1, _referansResim2, ResimBoyut);

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
                    //Resimleri birlestir.
                    //Celdiricilerde daha once yoksa ekle.
                    Soru.CeldiriciList.Add(ResimHelper.IkiResimBirlestir(solResim, sagResim, ResimBoyut));
                }
            }
        }
    }
}
