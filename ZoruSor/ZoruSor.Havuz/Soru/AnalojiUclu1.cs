using System.Collections.Generic;
using System.Linq;

namespace ZoruSor.Lib.Soru
{
    /// <summary>
    /// Diger Analoji Ikili 2' ye benzer bir test turudur. 
    /// Birinci satirda birbirinden tamamen farkli uc tane referans resim uretilir.
    /// Uc resimden birisi rasgele donor olarak secilir.
    /// Donor resimden zorluk derecesi kadar parca secilir. 
    /// Bu parcalar donor parca ile diger parcalarla degisir. Sonucta olusan resimler  isleme giren resimlerin 
    /// yaninda gosterilir.
    /// Ikinci satirda  yine uc tane birbirinden tamamen farkli resim uretilir.
    /// Bu resimlerden bir tanesini donor olarak secip diger resimle zorluk seviyesi kadar parca
    /// ile degistirilir olusan sonuc resimler dogru cevap olarak eklenir.
    /// </summary>
    class AnalojiUclu1: SoruBuilder
    {
        private CiktiResim _referansResim1, _referansResim2, _referansResim3, _dogruCevap;
        
        public override void ReferansResimUret()
        {
            //Uc tane birbirinden tamamen farkli iki referans resim uret
            _referansResim1 = ResimHelper.RasgeleResimUret(Havuz, ResimBoyut);
            _referansResim2 = ResimHelper.RasgeleFarkliResimUret(Havuz, new List<Dictionary<string, int>> { _referansResim1.ParcaList}, ResimBoyut);
            _referansResim3 = ResimHelper.RasgeleFarkliResimUret(Havuz, new List<Dictionary<string, int>> { _referansResim1.ParcaList, _referansResim2.ParcaList }, ResimBoyut);
           
            //Bu iki referans resmi birlestir. 
            var birlesik1 = ResimHelper.UcResimBirlestir(_referansResim1, _referansResim2, _referansResim3, ResimBoyut);

            

            //Zorluk derecesi kadar parca sec.
            var degisecekParcalar = ParcaSecimHelper.KadariniSec(Havuz, ZorlukDerece);

            var resim1Parcalar= new List<string>();
            var resim2Parcalar= new List<string>();


            //Eger zorluk seviyesi 3 ten azsa her bir resme birer tane parca degistir.
            if (ZorlukDerece == 1)
            {
                if (RandomHelper.RandomBool())
                {
                    resim1Parcalar = degisecekParcalar;
                }
                else
                {
                    resim2Parcalar = degisecekParcalar;
                }
            }
            else if (ZorlukDerece == 2)
            {
                resim1Parcalar.Add(degisecekParcalar[0]);
                resim2Parcalar.Add(degisecekParcalar[1]);
            }
            else
            {
                //Eger zorluk seviyesi 3 ten fazlaysa bir ile 1 ile zorluk derecesi arasinda bir sayi sec
                var parca1 = RandomHelper.RandomNumber(1, ZorlukDerece-1);
                //secilen sayi kadar parcayi birinci  resim ile kalani da ikinci resimle degistir.
                var parca2 = ZorlukDerece - parca1;
                for (int i = 0; i < parca1; i++)
                {
                    resim1Parcalar.Add(degisecekParcalar[i]);
                }
                for (int i = parca1-1; i < parca2; i++)
                {
                    resim2Parcalar.Add(degisecekParcalar[i]);
                }
            }

            var donor = RandomHelper.RandomNumber(1, 3);
            switch (donor)
            {
                case 1: //Donor referansResim1 dir.
                    _referansResim1 = ResimHelper.ParcaDegistir(Havuz, _referansResim1.ParcaList, _referansResim2.ParcaList,
                                                out _referansResim2, resim1Parcalar, ResimBoyut);
                    _referansResim1 = ResimHelper.ParcaDegistir(Havuz, _referansResim1.ParcaList, _referansResim3.ParcaList,
                                               out _referansResim3, resim2Parcalar, ResimBoyut);
                    break;
                case 2://Donor referansResim2 dir.
                    _referansResim2 = ResimHelper.ParcaDegistir(Havuz, _referansResim2.ParcaList, _referansResim1.ParcaList,
                                                out _referansResim1, resim1Parcalar, ResimBoyut);
                    _referansResim2 = ResimHelper.ParcaDegistir(Havuz, _referansResim2.ParcaList, _referansResim3.ParcaList,
                                               out _referansResim3, resim2Parcalar, ResimBoyut);
                    break;
                case 3://Donor referansResim3 dir.
                    _referansResim3 = ResimHelper.ParcaDegistir(Havuz, _referansResim3.ParcaList, _referansResim1.ParcaList,
                                                out _referansResim1, resim1Parcalar, ResimBoyut);
                    _referansResim3 = ResimHelper.ParcaDegistir(Havuz, _referansResim3.ParcaList, _referansResim2.ParcaList,
                                               out _referansResim2, resim2Parcalar, ResimBoyut);
                    break;
            }
           
            
            //Yeni Referans resimleri birlestir.
            var birlesik2 = ResimHelper.UcResimBirlestir(_referansResim1, _referansResim2, _referansResim3, ResimBoyut);

            //Islem satiri olustur. Referans resimlere ekle.
            Soru.ReferansResimList.Add(ResimHelper.IslemResimUret(birlesik1, birlesik2, ResimBoyut));


            //Uc tane birbirinden tamamen farkli iki referans resim uret
            _referansResim1 = ResimHelper.RasgeleResimUret(Havuz, ResimBoyut);
            _referansResim2 = ResimHelper.RasgeleFarkliResimUret(Havuz, new List<Dictionary<string, int>> { _referansResim1.ParcaList }, ResimBoyut);
            _referansResim3 = ResimHelper.RasgeleFarkliResimUret(Havuz, new List<Dictionary<string, int>> { _referansResim1.ParcaList, _referansResim2.ParcaList }, ResimBoyut);

            //Bu iki referans resmi birlestir. 
            birlesik1 = ResimHelper.UcResimBirlestir(_referansResim1, _referansResim2, _referansResim3, ResimBoyut);
        
            switch (donor)
            {
                case 1: //Donor referansResim1 dir.
                    _referansResim1 = ResimHelper.ParcaDegistir(Havuz, _referansResim1.ParcaList, _referansResim2.ParcaList,
                                                out _referansResim2, resim1Parcalar, ResimBoyut);
                    _referansResim1 = ResimHelper.ParcaDegistir(Havuz, _referansResim1.ParcaList, _referansResim3.ParcaList,
                                               out _referansResim3, resim2Parcalar, ResimBoyut);
                    break;
                case 2://Donor referansResim2 dir.
                    _referansResim2 = ResimHelper.ParcaDegistir(Havuz, _referansResim2.ParcaList, _referansResim1.ParcaList,
                                                out _referansResim1, resim1Parcalar, ResimBoyut);
                    _referansResim2 = ResimHelper.ParcaDegistir(Havuz, _referansResim2.ParcaList, _referansResim3.ParcaList,
                                               out _referansResim3, resim2Parcalar, ResimBoyut);
                    break;
                case 3://Donor referansResim3 dir.
                    _referansResim3 = ResimHelper.ParcaDegistir(Havuz, _referansResim3.ParcaList, _referansResim1.ParcaList,
                                                out _referansResim1, resim1Parcalar, ResimBoyut);
                    _referansResim3 = ResimHelper.ParcaDegistir(Havuz, _referansResim3.ParcaList, _referansResim2.ParcaList,
                                               out _referansResim2, resim2Parcalar, ResimBoyut);
                    break;
            }

            //Yeni Referans resimleri birlestir. Bu resim dogru cevaptir.
            _dogruCevap = ResimHelper.UcResimBirlestir(_referansResim1, _referansResim2, _referansResim3, ResimBoyut);

            
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
                bool solDegisti, sagDegisti, ortaDegisti;
                solDegisti = RandomHelper.RandomBool();
                ortaDegisti = RandomHelper.RandomBool();
                sagDegisti = !(solDegisti&ortaDegisti) || RandomHelper.RandomBool();
                CiktiResim solResim, ortaResim, sagResim;

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
                    ortaResim = ResimHelper.ResimDegistirUret(Havuz, _referansResim2, degisecekParcalar, ResimBoyut);
                }
                else
                {
                    ortaResim = _referansResim2;
                }

                if (sagDegisti)
                {
                    //Zorluk derecesine gore degisecek parcalari sec. (Farklisini bul gibi)
                    var degisecekParcalar = ParcaSecimHelper.KalaniSec(Havuz, SabitParcaAdet, ZorlukDerece);
                    sagResim = ResimHelper.ResimDegistirUret(Havuz, _referansResim3, degisecekParcalar, ResimBoyut);
                }
                else
                {
                    sagResim = _referansResim3;
                }

                if ((Soru.DogruCevapList[0].ParcaList.Equals(solResim.ParcaList) && 
                     Soru.DogruCevapList[0].DigerResimParcaList.Equals(ortaResim.ParcaList) && 
                     Soru.DogruCevapList[0].DonusumList.Equals(sagResim.ParcaList)) ||
                    Soru.CeldiriciList.Any(s => s.ParcaList.Equals(solResim.ParcaList) && 
                                                s.DigerResimParcaList.Equals(ortaResim.ParcaList) &&
                                                s.DonusumList.Equals(sagResim.ParcaList)))
                {
                    i--;
                }
                else
                {
                   
                    //Bu iki  parca resmi birlestir.
                    var birlesik1 = ResimHelper.UcResimBirlestir(solResim, ortaResim, sagResim, ResimBoyut);

                    //Resimleri birlestir.
                    //Celdiricilerde daha once yoksa ekle.
                    Soru.CeldiriciList.Add(birlesik1);
                }
            }
        }
    }
}
