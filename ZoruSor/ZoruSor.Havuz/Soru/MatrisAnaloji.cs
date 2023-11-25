using System.Linq;

namespace ZoruSor.Lib.Soru
{
    /// <summary>
    /// Bu soru turunde iki tane referans resimden olusan bir matris vardir.
    /// Ilk satirdaki birinci matristeki referans resim ile matristeki resim parcalari 
    /// Ikinci matriste yer degistirir. 
    /// Ikinci satirda da benzer sekilde iki ayri resimden olusan bir bir matris vardir.
    /// Bu matriste yer alan referans resimlerin yer degisimi ile olusan yeni matris dogru cevap 
    /// olarak yer alir.
    /// </summary>
    class MatrisAnaloji1 : SoruBuilder
    {
        private CiktiResim _referansResim1, _referansResim2;
        public override void ReferansResimUret()
        {
            //Birinci satiri olusturmak icin iki tane birbirinden farkli referans resim uret.
            _referansResim1 = ResimHelper.RasgeleResimUret(Havuz, ResimBoyut);
            do
            {
                _referansResim2 = ResimHelper.RasgeleResimUret(Havuz, ResimBoyut);
            } while (_referansResim1.Equals(_referansResim2));
            //Bu resimlerle ilk matrisi olustur.
            var matris1 = ResimHelper.MatrisOlustur(Havuz, _referansResim1, _referansResim2.ParcaList, ResimBoyut);
            //Bu resimleri yer degistirdikten sonra ilk satirin ikinci Matrisini uret.
            var matris2 = ResimHelper.MatrisOlustur(Havuz, _referansResim2, _referansResim1.ParcaList, ResimBoyut);
            
            
            //Matris Islem resmi uretip Referans resme ekle.
            Soru.ReferansResimList.Add(ResimHelper.IslemResimUret(matris1, matris2, ResimBoyut));

            //Ikinci satirda kullanilacak iki tane birbirinden farkli resim uret.
            _referansResim1 = ResimHelper.RasgeleResimUret(Havuz, ResimBoyut);
            do
            {
                _referansResim2 = ResimHelper.RasgeleResimUret(Havuz, ResimBoyut);
            } while (_referansResim1.Equals(_referansResim2));

            //Ikinci satir icin matris olustur.
            matris1 = ResimHelper.MatrisOlustur(Havuz, _referansResim1, _referansResim2.ParcaList, ResimBoyut);
            //Iki resmi kullanarak Matris Soru satiri uret.
            Soru.ReferansResimList.Add(ResimHelper.IslemSoruResimUret(matris1, ResimBoyut, matris1.Image.Height));
        }

        public override void DogruCevapUret()
        {
            //Soru satirindaki referans resimleri  yer degistirerek dogru cevap matrisi uret.
            var matris2 = ResimHelper.MatrisOlustur(Havuz, _referansResim2, _referansResim1.ParcaList, ResimBoyut);

            //Dogru cevaba ekle.
            Soru.DogruCevapList.Add(matris2);
        }

        public override void CeldiriciUret()
        {
            for (int i = 0; i < CeldiriciAdet; i++)
            {
                bool icDegisti, disDegisti;
                icDegisti = RandomHelper.RandomBool();
                disDegisti = !icDegisti || RandomHelper.RandomBool();
                CiktiResim icResim, disResim;
                if (icDegisti)
                {
                    //Zorluk derecesine gore degisecek parcalari sec. (Farklisini bul gibi)
                    var degisecekParcalar = ParcaSecimHelper.KalaniSec(Havuz, SabitParcaAdet, ZorlukDerece);
                    icResim = ResimHelper.ResimDegistirUret(Havuz, _referansResim2, degisecekParcalar, ResimBoyut);
                }
                else
                {
                    icResim = _referansResim2;
                }

                if (disDegisti)
                {
                    //Zorluk derecesine gore degisecek parcalari sec. (Farklisini bul gibi)
                    var degisecekParcalar = ParcaSecimHelper.KalaniSec(Havuz, SabitParcaAdet, ZorlukDerece);
                    disResim = ResimHelper.ResimDegistirUret(Havuz, _referansResim1, degisecekParcalar, ResimBoyut);
                }
                else
                {
                    disResim = _referansResim1;
                }

                if ((Soru.DogruCevapList[0].ParcaList.Equals(icResim.ParcaList) && Soru.DogruCevapList[0].DigerResimParcaList.Equals(disResim.ParcaList)) ||
                    Soru.CeldiriciList.Any(s=>s.ParcaList.Equals(icResim.ParcaList) && s.DigerResimParcaList.Equals(disResim.ParcaList)))
                {
                    i--;
                }
                else
                {
                    //Matris resim olustur.
                    //Celdiricilerde daha once yoksa ekle.
                    Soru.CeldiriciList.Add(ResimHelper.MatrisOlustur(Havuz, icResim, disResim.ParcaList, ResimBoyut));
                }
                
            }

        }
    }
}
