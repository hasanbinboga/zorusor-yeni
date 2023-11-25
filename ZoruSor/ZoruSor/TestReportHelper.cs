using System.Collections.Generic;
using ZoruSor.Lib.Havuz;
using ZoruSor.Lib.Test;
using ZoruSor.Lib.Test.Analoji;
using ZoruSor.Lib.Test.AynisiniBul;
using ZoruSor.Lib.Test.ButunParca;
using ZoruSor.Lib.Test.Cakistirma;
using ZoruSor.Lib.Test.DondurBul;
using ZoruSor.Lib.Test.DondurCakistir;
using ZoruSor.Lib.Test.Donusum;
using ZoruSor.Lib.Test.EsEleman;
using ZoruSor.Lib.Test.FarkliEleman;
using ZoruSor.Lib.Test.FarklisiniBul;
using ZoruSor.Lib.Test.Kavram;
using ZoruSor.Lib.Test.KuraliBul;
using ZoruSor.Lib.Test.Matris;
using ZoruSor.Lib.Test.Melez;
using ZoruSor.Lib.Test.OrtakEleman;
using ZoruSor.Lib.Test.ParaOyun;
using ZoruSor.Lib.Test.ParcaButun;
using ZoruSor.Lib.Test.Simetri;
using ZoruSor.Lib.Test.Siniflandirma;
using ZoruSor.Lib.Test.TumuFarkli;
using ZoruSor.Lib.Test.YerDegistir;
using ZoruSor.Reports;
using ZoruSor.Reports.Analoji;
using ZoruSor.Reports.AnalojiParcali;
using ZoruSor.Reports.CakistirDogru;
using ZoruSor.Reports.CakistirYanlis;
using ZoruSor.Reports.DondurBul;
using ZoruSor.Reports.DondurCakistirDogru;
using ZoruSor.Reports.DondurCakistirYanlis;
using ZoruSor.Reports.EsEleman;
using ZoruSor.Reports.FarkliEleman;
using ZoruSor.Reports.FarklisiniBul;
using ZoruSor.Reports.KuraliBul;
using ZoruSor.Reports.Matris;
using ZoruSor.Reports.Melez;
using ZoruSor.Reports.OrtakEleman;
using ZoruSor.Reports.ParaOyunu;
using ZoruSor.Reports.SimetrikIliski;
using ZoruSor.Reports.Siniflandirma;
using ZoruSor.Reports.TumuFarkliEleman;

namespace ZoruSor
{
    public class TestReportHelper
    {
        public BaseTest CreateTest(string seciliTest, SayfaTip seciliSayfaTip, Havuz seciliHavuz, 
            int zorlukDerece, int sabitParcaAdet, int sayfaAdet, 
            string resim1Formul, string resim2Formul, string resim3Formul, string resim4Formul)
        {
            switch (seciliTest)
            {
                case "Analoji Parçalı 1":

                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(AnalojiParcali1Sayfa1))
                    {
                        return new AnalojiParca1Test1(seciliHavuz, zorlukDerece, sabitParcaAdet, sayfaAdet);
                    }
                    break;
                case "Analoji Parçalı 2":

                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(AnalojiParcali2Sayfa1))
                    {
                        return new AnalojiParca2Test1(seciliHavuz, zorlukDerece, sabitParcaAdet, sayfaAdet);
                    }
                    break;
                case "Analoji Parçalı 3":

                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(AnalojiParcali3Sayfa1))
                    {
                        return new AnalojiParca3Test1(seciliHavuz, zorlukDerece, sabitParcaAdet,sayfaAdet);
                    }
                    break;
                case "Analoji 1":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(AnalojiSayfa1))
                    {
                        return new AnalojiIkili1Test1(seciliHavuz, zorlukDerece, sabitParcaAdet,
                            sayfaAdet);
                    }
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(AnalojiSayfa2))
                    {
                        return new AnalojiIkili1Test2(seciliHavuz, zorlukDerece, sabitParcaAdet,
                            sayfaAdet);
                    }
                    break;
                case "Analoji 2":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(AnalojiSayfa3))
                    {
                        return new AnalojiIkili2Test1(seciliHavuz, zorlukDerece, sabitParcaAdet,
                            sayfaAdet);
                    }
                    break;
                case "Analoji 3":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(AnalojiSayfa4))
                    {
                        return new AnalojiUclu1Test1(seciliHavuz, zorlukDerece, sabitParcaAdet,
                            sayfaAdet);
                    }
                    break;
                case "Aynısını Bul":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(AynisiniBulSayfa1))
                    {
                        return new AynisiniBulTest1(seciliHavuz, zorlukDerece, sabitParcaAdet,
                            sayfaAdet);
                    }
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(AynisiniBulSayfa2))
                    {
                        return new AynisiniBulTest2(seciliHavuz, zorlukDerece, sabitParcaAdet,
                            sayfaAdet);
                    }
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(AynisiniBulSayfa3))
                    {
                        return new AynisiniBulTest3(seciliHavuz, zorlukDerece, sabitParcaAdet,
                            sayfaAdet);
                    }
                    break;
                case "Bütünden Parçaya":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(ButunParcaSayfa1))
                    {
                        return new ButunParca1Test(seciliHavuz, zorlukDerece, sabitParcaAdet,
                            sayfaAdet);

                    }
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(ButunParcaSayfa2))
                    {
                        return new ButunParca2Test(seciliHavuz, zorlukDerece, sabitParcaAdet,
                            sayfaAdet);

                    }
                    break;
                case "Çakıştırma Doğruyu Bul":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(CakistirDogruSayfa1))
                    {
                        return new CakistirmaDogru1Test(seciliHavuz, zorlukDerece, sabitParcaAdet,
                            sayfaAdet);
                    }
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(CakistirDogruSayfa2))
                    {
                        return new CakistirmaDogru2Test(seciliHavuz, zorlukDerece, sabitParcaAdet,
                            sayfaAdet);
                    }
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(CakistirDogruSayfa3))
                    {
                        return new CakistirmaDogru3Test(seciliHavuz, zorlukDerece, sabitParcaAdet,
                            sayfaAdet);
                    }
                    break;
                case "Çakıştırma Yanlışı Bul":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(CakistirYanlisSayfa1))
                    {
                        return new CakistirmaYanlis1Test(seciliHavuz, zorlukDerece, sabitParcaAdet,
                            sayfaAdet);
                    }
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(CakistirYanlisSayfa2))
                    {
                        return new CakistirmaYanlis2Test(seciliHavuz, zorlukDerece, sabitParcaAdet,
                            sayfaAdet);
                    }
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(CakistirYanlisSayfa3))
                    {
                        return new CakistirmaYanlis3Test(seciliHavuz, zorlukDerece, sabitParcaAdet,
                            sayfaAdet);
                    }
                    break;
                case "Döndür Bul Uygula 1":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(DondurBul1Sayfa1))
                    {
                        return new DondurBul1Test1(seciliHavuz, zorlukDerece, sabitParcaAdet,
                            sayfaAdet);
                    }
                   
                    break;
                case "Döndür Bul Uygula 2":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(DondurBul2Sayfa1))
                    {
                        return new DondurBul2Test1(seciliHavuz, zorlukDerece, sabitParcaAdet,
                            sayfaAdet);
                    }

                    break;
                case "Döndür Çakıştır Doğruyu Bul 1":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(DondurCakistirDogru1Sayfa1))
                    {
                        return new DondurCakistirDogru1Test1(seciliHavuz, zorlukDerece, sabitParcaAdet,
                            sayfaAdet);
                    }
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(DondurCakistirDogru1Sayfa2))
                    {
                        return new DondurCakistirDogru1Test2(seciliHavuz, zorlukDerece, sabitParcaAdet,
                            sayfaAdet);
                    }
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(DondurCakistirDogru1Sayfa3))
                    {
                        return new DondurCakistirDogru1Test3(seciliHavuz, zorlukDerece, sabitParcaAdet,
                            sayfaAdet);
                    }
                    break;

                case "Döndür Çakıştır Doğruyu Bul 2":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(DondurCakistirDogru2Sayfa1))
                    {
                        return new DondurCakistirDogru2Test1(seciliHavuz, zorlukDerece, sabitParcaAdet,
                            sayfaAdet);
                    }
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(DondurCakistirDogru2Sayfa2))
                    {
                        return new DondurCakistirDogru2Test2(seciliHavuz, zorlukDerece, sabitParcaAdet,
                            sayfaAdet);
                    }
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(DondurCakistirDogru2Sayfa3))
                    {
                        return new DondurCakistirDogru2Test3(seciliHavuz, zorlukDerece, sabitParcaAdet,
                            sayfaAdet);
                    }
                    break;
                case "Döndür Çakıştır Yanlışı Bul 1":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(DondurCakistirYanlis1Sayfa1))
                    {
                        return new DondurCakistirYanlis1Test1(seciliHavuz, zorlukDerece, sabitParcaAdet,
                            sayfaAdet);
                    }
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(DondurCakistirYanlis1Sayfa2))
                    {
                        return new DondurCakistirYanlis1Test2(seciliHavuz, zorlukDerece, sabitParcaAdet,
                            sayfaAdet);
                    }
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(DondurCakistirYanlis1Sayfa3))
                    {
                        return new DondurCakistirYanlis1Test3(seciliHavuz, zorlukDerece, sabitParcaAdet,
                            sayfaAdet);
                    }
                    break;
                case "Döndür Çakıştır Yanlışı Bul 2":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(DondurCakistirYanlis2Sayfa1))
                    {
                        return new DondurCakistirYanlis2Test1(seciliHavuz, zorlukDerece, sabitParcaAdet,
                            sayfaAdet);
                    }
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(DondurCakistirYanlis2Sayfa2))
                    {
                        return new DondurCakistirYanlis2Test2(seciliHavuz, zorlukDerece, sabitParcaAdet,
                            sayfaAdet);
                    }
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(DondurCakistirYanlis2Sayfa3))
                    {
                        return new DondurCakistirYanlis2Test3(seciliHavuz, zorlukDerece, sabitParcaAdet,
                            sayfaAdet);
                    }
                    break;
                case "Dönüşüm 1":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(DonusumSayfa1))
                    {
                        return new Donusum11Test(seciliHavuz, zorlukDerece, sabitParcaAdet,
                            sayfaAdet);
                    }
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(DonusumSayfa11))
                    {
                        return new Donusum12Test(seciliHavuz, zorlukDerece, sabitParcaAdet,
                            sayfaAdet);
                    }
                    break;
                case "Dönüşüm 2":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(DonusumSayfa2))
                    {
                        return new Donusum21Test(seciliHavuz, zorlukDerece, sabitParcaAdet,
                            sayfaAdet);
                    }
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(DonusumSayfa21))
                    {
                        return new Donusum22Test(seciliHavuz, zorlukDerece, sabitParcaAdet,
                            sayfaAdet);
                    }
                    break;
                case "Dönüşüm 3":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(DonusumSayfa3))
                    {
                        return new Donusum31Test(seciliHavuz, zorlukDerece, sabitParcaAdet,
                            sayfaAdet);
                    }
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(DonusumSayfa31))
                    {
                        return new Donusum32Test(seciliHavuz, zorlukDerece, sabitParcaAdet,
                            sayfaAdet);
                    }
                    break;
                case "Eş Eleman 1":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(EsEleman1Sayfa1))
                    {
                        return new EsElemanest11(seciliHavuz, zorlukDerece, sabitParcaAdet,
                            sayfaAdet);
                    }
                    break;
                case "Eş Eleman 2":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(EsEleman2Sayfa1))
                    {
                        return new EsElemanTest21(seciliHavuz, zorlukDerece, sabitParcaAdet,
                            sayfaAdet);
                    }
                    break;
                case "Eş Eleman 3":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(EsEleman3Sayfa1))
                    {
                        return new EsElemanest31(seciliHavuz, zorlukDerece, sabitParcaAdet,
                            sayfaAdet);
                    }
                    break;
                case "Eş Eleman 4":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(EsEleman4Sayfa1))
                    {
                        return new EsElemanTest41(seciliHavuz, zorlukDerece, sabitParcaAdet,
                            sayfaAdet);
                    }
                    break;
                case "Farklı Eleman":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(FarkliElemanSayfa1))
                    {
                        return new FarkliElemanTest1(seciliHavuz, zorlukDerece, sabitParcaAdet,
                            sayfaAdet);
                    }
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(FarkliElemanSayfa1))
                    {
                        return new FarkliElemanTest2(seciliHavuz, zorlukDerece, sabitParcaAdet,
                            sayfaAdet);
                    }
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(FarkliElemanSayfa1))
                    {
                        return new FarkliElemanTest3(seciliHavuz, zorlukDerece, sabitParcaAdet,
                            sayfaAdet);
                    }
                    break;
                case "Farklısını Bul":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(FarklisiniBulSayfa1))
                    {
                        return new FarklisiniBulTest1(seciliHavuz, zorlukDerece, sabitParcaAdet,
                            sayfaAdet);
                    }
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(FarklisiniBulSayfa2))
                    {
                        return new FarklisiniBulTest2(seciliHavuz, zorlukDerece, sabitParcaAdet,
                            sayfaAdet);
                    }
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(FarklisiniBulSayfa3))
                    {
                        return new FarklisiniBulTest3(seciliHavuz, zorlukDerece, sabitParcaAdet,
                            sayfaAdet);
                    }
                    break;
                case "Kavram Oluşturma":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(KavramSayfa1))
                    {
                        return new Kavram1Test(seciliHavuz, zorlukDerece, sabitParcaAdet,
                            sayfaAdet);
                    }
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(KavramSayfa2))
                    {
                        return new Kavram2Test(seciliHavuz, zorlukDerece, sabitParcaAdet,
                            sayfaAdet);
                    }
                    break;
                case "Kuralı Bul Uygula 1":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(KuraliBulSayfa1))
                    {
                        return new KurBulUy11Test(seciliHavuz, zorlukDerece, sabitParcaAdet,
                            sayfaAdet);
                    }
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(KuraliBulSayfa2))
                    {
                        return new KurBulUy12Test(seciliHavuz, zorlukDerece, sabitParcaAdet,
                            sayfaAdet);
                    }
                    break;
                case "Kuralı Bul Uygula 2":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(KuraliBul2Sayfa1))
                    {
                        return new KurBulUy21Test(seciliHavuz, zorlukDerece, sabitParcaAdet,
                            sayfaAdet);
                    }
                    else if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(KuraliBul2Sayfa2))
                    {
                        return new KurBulUy22Test(seciliHavuz, zorlukDerece, sabitParcaAdet,
                            sayfaAdet);
                    }
                    break;
                case "Kuralı Bul Uygula 3":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(KuraliBul3Sayfa1))
                    {
                        return new KurBulUy31Test(seciliHavuz, zorlukDerece, sabitParcaAdet,
                            sayfaAdet);
                    }
                    else if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(KuraliBul3Sayfa2))
                    {
                        return new KurBulUy32Test(seciliHavuz, zorlukDerece, sabitParcaAdet,
                            sayfaAdet);
                    }
                    break;
                case "Kuralı Bul Uygula 4":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(KuraliBul4Sayfa1))
                    {
                        return new KurBulUy41Test(seciliHavuz, zorlukDerece, sabitParcaAdet,
                            sayfaAdet);
                    }
                    break;
                case "Kuralı Bul Uygula 5":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(KuraliBul5Sayfa1))
                    {
                        return new KurBulUy51Test(seciliHavuz, zorlukDerece, sabitParcaAdet,
                            sayfaAdet);
                    }
                    break;
                case "Kuralı Bul Uygula 6":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(KuraliBul6Sayfa1))
                    {
                        return new KurBulUy61Test(seciliHavuz, zorlukDerece, sabitParcaAdet,
                            sayfaAdet);
                    }
                    break;
                case "Kuralı Bul Uygula 7":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(KuraliBul7Sayfa1))
                    {
                        return new KurBulUy71Test(seciliHavuz, zorlukDerece, sabitParcaAdet,
                            sayfaAdet);
                    }
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(KuraliBul7Sayfa2))
                    {
                        return new KurBulUy72Test(seciliHavuz, zorlukDerece, sabitParcaAdet,
                            sayfaAdet);
                    }
                    break;
                case "Kuralı Bul Uygula 8":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(KuraliBul8Sayfa1))
                    {
                        return new KurBulUy81Test(seciliHavuz, zorlukDerece, sabitParcaAdet,
                            sayfaAdet);
                    }
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(KuraliBul8Sayfa2))
                    {
                        return new KurBulUy82Test(seciliHavuz, zorlukDerece, sabitParcaAdet,
                            sayfaAdet);
                    }
                    break;
                case "Kuralı Bul Uygula 9":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(KuraliBul9Sayfa1))
                    {
                        return new KurBulUy91Test(seciliHavuz, zorlukDerece, sabitParcaAdet,
                            sayfaAdet);
                    }
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(KuraliBul9Sayfa2))
                    {
                        return new KurBulUy92Test(seciliHavuz, zorlukDerece, sabitParcaAdet,
                            sayfaAdet);
                    }
                    break;
                case "Kuralı Bul Uygula 10":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(KuraliBul10Sayfa1))
                    {
                        return new KurBulUy101Test(seciliHavuz, zorlukDerece, sabitParcaAdet,
                            sayfaAdet);
                    }
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(KuraliBul10Sayfa2))
                    {
                        return new KurBulUy102Test(seciliHavuz, zorlukDerece, sabitParcaAdet,
                            sayfaAdet);
                    }

                    break;
                case "Kuralı Bul Uygula 11":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(KuraliBul11Sayfa1))
                    {
                        return new KurBulUy111Test(seciliHavuz, zorlukDerece, sabitParcaAdet,
                            sayfaAdet);
                    }
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(KuraliBul11Sayfa2))
                    {
                        return new KurBulUy112Test(seciliHavuz, zorlukDerece, sabitParcaAdet,
                            sayfaAdet);
                    }

                    break;
                case "Kuralı Bul Uygula 12":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(KuraliBul12Sayfa1))
                    {
                        return new KurBulUy121Test(seciliHavuz, zorlukDerece, sabitParcaAdet,
                            sayfaAdet);
                    }
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(KuraliBul12Sayfa2))
                    {
                        return new KurBulUy122Test(seciliHavuz, zorlukDerece, sabitParcaAdet,
                            sayfaAdet);
                    }

                    break;
                case "Kuralı Bul Uygula 13":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(KuraliBul13Sayfa1))
                    {
                        return new KurBulUy131Test(seciliHavuz, zorlukDerece, sabitParcaAdet,
                            sayfaAdet);
                    }
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(KuraliBul13Sayfa2))
                    {
                        return new KurBulUy132Test(seciliHavuz, zorlukDerece, sabitParcaAdet,
                            sayfaAdet);
                    }

                    break;
                case "Kuralı Bul Uygula Hüseyin 1":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(KuraliBulHus1Sayfa1))
                    {
                        return new KurBulUyHusTest1(seciliHavuz, zorlukDerece, sabitParcaAdet,
                            sayfaAdet);
                    }
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(KuraliBulHus1Sayfa2))
                    {
                        return new KurBulUyHusTest2(seciliHavuz, zorlukDerece, sabitParcaAdet,
                            sayfaAdet);
                    }

                    break;
                case "Kuralı Bul Uygula Hüseyin 2":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(KuraliBulHus2Sayfa1))
                    {
                        return new KurBulUyHus2Test1(seciliHavuz, zorlukDerece, sabitParcaAdet,
                            sayfaAdet);
                    }
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(KuraliBulHus2Sayfa2))
                    {
                        return new KurBulUyHus2Test2(seciliHavuz, zorlukDerece, sabitParcaAdet,
                            sayfaAdet);
                    }

                    break;
                
                case "Simetrik İlişkiler 1":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(SimetrikIliski1Sayfa1))
                    {
                        return new Simetri11Test(seciliHavuz, zorlukDerece, sabitParcaAdet,
                            sayfaAdet);
                    }
                    else if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(SimetrikIliski1Sayfa2))
                    {
                        return new Simetri12Test(seciliHavuz, zorlukDerece, sabitParcaAdet,
                            sayfaAdet);
                    }
                    break;
                case "Simetrik İlişkiler 2":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(SimetrikIliski2Sayfa1))
                    {
                        return new Simetri21Test(seciliHavuz, zorlukDerece, sabitParcaAdet,
                            sayfaAdet);
                    }
                    else if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(SimetrikIliski2Sayfa2))
                    {
                        return new Simetri22Test(seciliHavuz, zorlukDerece, sabitParcaAdet,
                            sayfaAdet);
                    }
                    break;
                case "Simetrik İlişkiler 3":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(SimetrikIliski3Sayfa1))
                    {
                        return new Simetri31Test(seciliHavuz, zorlukDerece, sabitParcaAdet,
                            sayfaAdet);
                    }
                    else if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(SimetrikIliski3Sayfa2))
                    {
                        return new Simetri32Test(seciliHavuz, zorlukDerece, sabitParcaAdet,
                            sayfaAdet);
                    }
                    break;

                case "Simetrik İlişkiler 4":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(SimetrikIliski4Sayfa1))
                    {
                        return new Simetri41Test(seciliHavuz, zorlukDerece, sabitParcaAdet,
                            sayfaAdet);
                    }

                    break;

                case "Simetrik İlişkiler 5":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(SimetrikIliski5Sayfa1))
                    {
                        return new Simetri51Test(seciliHavuz, zorlukDerece, sabitParcaAdet,
                            sayfaAdet);
                    }

                    break;

                case "Simetrik İlişkiler 6":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(SimetrikIliski6Sayfa1))
                    {
                        return new Simetri61Test(seciliHavuz, zorlukDerece, sabitParcaAdet,
                            sayfaAdet);
                    }

                    break;
                case "Matris Faklıyı Bul 1":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(MatrisSayfa1))
                    {
                        return new MatrisFark1Test(seciliHavuz, zorlukDerece, sabitParcaAdet,
                            sayfaAdet);
                    }

                    break;

                case "Matris Aynısını Bul 1":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(MatrisSayfa1))
                    {
                        return new MatrisAyni1Test(seciliHavuz, zorlukDerece, sabitParcaAdet,
                            sayfaAdet);
                    }

                    break;

                case "Matris Analoji 1":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(MatrisAnalojiSayfa1))
                    {
                        return new MatrisAnaloji1Test(seciliHavuz, zorlukDerece, sabitParcaAdet,
                            sayfaAdet);
                    }

                    break;




                case "Melez İkili":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(MelezIkiliSayfa1))
                    {
                        return new MelezIkiliTest1(seciliHavuz, resim1Formul,
                            resim2Formul, zorlukDerece, sabitParcaAdet,
                            sayfaAdet);
                    }
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(MelezIkiliSayfa2))
                    {
                        return new MelezIkiliTest2(seciliHavuz, resim1Formul,
                            resim2Formul, zorlukDerece, sabitParcaAdet,
                            sayfaAdet);
                    }
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(MelezIkiliSayfa3))
                    {
                        return new MelezIkiliTest3
                            (seciliHavuz, resim1Formul,
                            resim2Formul, zorlukDerece, sabitParcaAdet,
                            sayfaAdet);
                    }
                    break;

                case "Melez Üçlü":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(MelezUcluSayfa1))
                    {
                        return new MelezUcluTest1(seciliHavuz, resim1Formul,
                            resim2Formul, resim3Formul,
                            zorlukDerece, sabitParcaAdet, sayfaAdet);
                    }
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(MelezUcluSayfa2))
                    {
                        return new MelezUcluTest2(seciliHavuz, resim1Formul,
                            resim2Formul, resim3Formul,
                            zorlukDerece, sabitParcaAdet, sayfaAdet);
                    }
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(MelezUcluSayfa3))
                    {
                        return new MelezUcluTest3
                            (seciliHavuz, resim1Formul,
                            resim2Formul, resim3Formul,
                            zorlukDerece, sabitParcaAdet, sayfaAdet);
                    }
                    break;
                case "Melez Dörtlü":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(MelezDortluSayfa1))
                    {
                        return new MelezDortluTest1(seciliHavuz, resim1Formul,
                            resim2Formul, resim3Formul,
                            resim4Formul, zorlukDerece, sabitParcaAdet,
                            sayfaAdet);
                    }
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(MelezDortluSayfa2))
                    {
                        return new MelezDortluTest2(seciliHavuz, resim1Formul,
                            resim2Formul, resim3Formul,
                            resim4Formul, zorlukDerece, sabitParcaAdet,
                            sayfaAdet);
                    }

                    break;

                case "Ortak Eleman":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(OrtakElemanSayfa1))
                    {
                        return new OrtakElemanTest1(seciliHavuz, zorlukDerece, sabitParcaAdet,
                            sayfaAdet);
                    }
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(OrtakElemanSayfa2))
                    {
                        return new OrtakElemanTest2(seciliHavuz, zorlukDerece, sabitParcaAdet,
                            sayfaAdet);
                    }
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(OrtakElemanSayfa3))
                    {
                        return new OrtakElemanTest3(seciliHavuz, zorlukDerece, sabitParcaAdet,
                            sayfaAdet);
                    }
                    break;
                case "Para Oyunu 1":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(ParaOyunu1Sayfa1))
                    {
                        return new ParaOyun1Test1(resim1Formul,
                            resim2Formul, resim3Formul,
                            resim4Formul, zorlukDerece,
                            sayfaAdet, false);
                    }
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(ParaOyunu1Sayfa2))
                    {
                        return new ParaOyun1Test2(resim1Formul,
                            resim2Formul, resim3Formul,
                            resim4Formul, zorlukDerece,
                            sayfaAdet, false);
                    }
                    break;
                case "Para Oyunu 2":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(ParaOyunu2Sayfa1))
                    {
                        return new ParaOyun2Test1(zorlukDerece, sayfaAdet);
                    }
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(ParaOyunu2Sayfa2))
                    {
                        return new ParaOyun2Test2(zorlukDerece, sayfaAdet);
                    }
                    break;
                case "Para Oyunu 3":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(ParaOyunu3Sayfa1))
                    {
                        return new ParaOyun3Test1(zorlukDerece, sayfaAdet);
                    }
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(ParaOyunu3Sayfa2))
                    {
                        return new ParaOyun3Test2(zorlukDerece, sayfaAdet);
                    }
                    break;
                case "Para Oyunu 4":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(ParaOyunu4Sayfa1))
                    {
                        return new ParaOyun4Test1(zorlukDerece, sayfaAdet);
                    }
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(ParaOyunu4Sayfa2))
                    {
                        return new ParaOyun4Test2(zorlukDerece, sayfaAdet);
                    }
                    break;
                case "Para Oyunu 4 - 1":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(ParaOyunu41Sayfa1))
                    {
                        return new ParaOyun41Test1(zorlukDerece, sayfaAdet);
                    }
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(ParaOyunu41Sayfa2))
                    {
                        return new ParaOyun41Test2(zorlukDerece, sayfaAdet);
                    }
                    break;
                case "Para Oyunu 5":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(ParaOyunu5Sayfa1))
                    {
                        return new ParaOyun5Test1(resim1Formul,
                            resim2Formul, resim3Formul,
                            resim4Formul, zorlukDerece,
                            sayfaAdet);
                    }
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(ParaOyunu5Sayfa2))
                    {
                        return new ParaOyun5Test2(resim1Formul,
                            resim2Formul, resim3Formul,
                            resim4Formul, zorlukDerece,
                            sayfaAdet);
                    }
                    break;
                case "Parçadan Bütüne":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(ParcaButunSayfa1))
                    {
                        return new ParcaButun1Test(seciliHavuz, zorlukDerece, sabitParcaAdet,
                            sayfaAdet);
                    }
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(ParcaButunSayfa2))
                    {
                        return new ParcaButun2Test(seciliHavuz, zorlukDerece, sabitParcaAdet,
                            sayfaAdet);
                    }
                    break;
                case "Sınıflandırma 1":
                    return new SinifBesli1Test(seciliHavuz, zorlukDerece, sabitParcaAdet,
                        sayfaAdet);
                case "Sınıflandırma 2":
                    return new SinifBesli2Test(seciliHavuz, zorlukDerece, sabitParcaAdet,
                        sayfaAdet);
                case "Sınıflandırma 3":
                    return new SinifBesli3Test(seciliHavuz, zorlukDerece, sabitParcaAdet,
                        sayfaAdet);
                case "Sınıflandırma 6 lı 1":
                    return new SinifAltili1Test(seciliHavuz, zorlukDerece, sabitParcaAdet,
                        sayfaAdet);
                case "Sınıflandırma 6 lı 2":
                    return new SinifAltili2Test(seciliHavuz, zorlukDerece, sabitParcaAdet,
                        sayfaAdet);
                case "Sınıflandırma 6 lı 3":
                    return new SinifAltili3Test(seciliHavuz, zorlukDerece, sabitParcaAdet,
                        sayfaAdet);
                case "Sınıflandırma 7 li 1":
                    return new SinifYedili1Test(seciliHavuz, zorlukDerece, sabitParcaAdet,
                        sayfaAdet);
                case "Sınıflandırma 7 li 2":
                    return new SinifYedili2Test(seciliHavuz, zorlukDerece, sabitParcaAdet,
                        sayfaAdet);
                case "Sınıflandırma 7 li 3":
                    return new SinifYedili3Test(seciliHavuz, zorlukDerece, sabitParcaAdet,
                        sayfaAdet);
                case "Sınıflandırma Parça Bütün":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(SinifParcaSayfa1))
                    {
                        return new SinifParca1Test(seciliHavuz, zorlukDerece, sabitParcaAdet,
                      sayfaAdet);
                    }
                    break;
                case "Tümü Farklı Eleman":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(TumuFarkliElemanSayfa1))
                    {
                        return new TumuFarkliElemanTest1(seciliHavuz, zorlukDerece, sabitParcaAdet,
                            sayfaAdet);
                    }
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(TumuFarkliElemanSayfa2))
                    {
                        return new TumuFarkliElemanTest2(seciliHavuz, zorlukDerece, sabitParcaAdet,
                            sayfaAdet);
                    }
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(TumuFarkliElemanSayfa3))
                    {
                        return new TumuFarkliElemanTest3(seciliHavuz, zorlukDerece, sabitParcaAdet,
                            sayfaAdet);
                    }
                    break;
                case "Yer Değiştireni Bul Uygula":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(YerDegistir1Sayfa1))
                    {
                        return new YerDegistir1Test1(seciliHavuz, zorlukDerece, sabitParcaAdet,
                      sayfaAdet);
                    }
                    break;
            }
            return null;
        }

        public BaseTest CreateTest(string seciliSoruTip, SayfaTip seciliSayfaTip, IEnumerable<FasikulTestDetail> testDetails )
        {
            switch (seciliSoruTip)
            {
                case "Analoji Parçalı 1":

                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(AnalojiParcali1Sayfa1))
                    {
                       return new AnalojiParca1Test1(GetTestDetails(testDetails));
                    }
                    break;
                case "Analoji Parçalı 2":

                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(AnalojiParcali2Sayfa1))
                    {
                        return new AnalojiParca2Test1(GetTestDetails(testDetails));
                    }
                    break;
                case "Analoji Parçalı 3":

                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(AnalojiParcali3Sayfa1))
                    {
                        return new AnalojiParca3Test1(GetTestDetails(testDetails));
                    }
                    break;
                case "Analoji 1":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(AnalojiSayfa1))
                    {
                        return new AnalojiIkili1Test1(GetTestDetails(testDetails));
                    }
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(AnalojiSayfa2))
                    {
                        return new AnalojiIkili1Test2(GetTestDetails(testDetails));
                    }
                    break;
                case "Analoji 2":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(AnalojiSayfa3))
                    {
                        return new AnalojiIkili2Test1(GetTestDetails(testDetails));
                    }
                    break;
                case "Analoji 3":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(AnalojiSayfa4))
                    {
                        return new AnalojiUclu1Test1(GetTestDetails(testDetails));
                    }
                    break;
                case "Aynısını Bul":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(AynisiniBulSayfa1))
                    {
                        return new AynisiniBulTest1(GetTestDetails(testDetails));
                    }
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(AynisiniBulSayfa2))
                    {
                        return new AynisiniBulTest2(GetTestDetails(testDetails));
                    }
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(AynisiniBulSayfa3))
                    {
                        return new AynisiniBulTest3(GetTestDetails(testDetails));
                    }
                    break;
                case "Bütünden Parçaya":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(ButunParcaSayfa1))
                    {
                        return new ButunParca1Test(GetTestDetails(testDetails));

                    }
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(ButunParcaSayfa2))
                    {
                        return new ButunParca2Test(GetTestDetails(testDetails));

                    }
                    break;
                case "Çakıştırma Doğruyu Bul":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(CakistirDogruSayfa1))
                    {
                        return new CakistirmaDogru1Test(GetTestDetails(testDetails));
                    }
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(CakistirDogruSayfa2))
                    {
                        return new CakistirmaDogru2Test(GetTestDetails(testDetails));
                    }
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(CakistirDogruSayfa3))
                    {
                        return new CakistirmaDogru3Test(GetTestDetails(testDetails));
                    }
                    break;
                case "Çakıştırma Yanlışı Bul":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(CakistirYanlisSayfa1))
                    {
                        return new CakistirmaYanlis1Test(GetTestDetails(testDetails));
                    }
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(CakistirYanlisSayfa2))
                    {
                        return new CakistirmaYanlis2Test(GetTestDetails(testDetails));
                    }
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(CakistirYanlisSayfa3))
                    {
                        return new CakistirmaYanlis3Test(GetTestDetails(testDetails));
                    }
                    break;
                case "Döndür Bul Uygula 1":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(DondurBul1Sayfa1))
                    {
                        return new DondurBul1Test1(GetTestDetails(testDetails));
                    }

                    break;
                case "Döndür Bul Uygula 2":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(DondurBul2Sayfa1))
                    {
                        return new DondurBul2Test1(GetTestDetails(testDetails));
                    }

                    break;
                case "Döndür Çakıştır Doğruyu Bul 1":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(DondurCakistirDogru1Sayfa1))
                    {
                        return new DondurCakistirDogru1Test1(GetTestDetails(testDetails));
                    }
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(DondurCakistirDogru1Sayfa2))
                    {
                        return new DondurCakistirDogru1Test2(GetTestDetails(testDetails));
                    }
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(DondurCakistirDogru1Sayfa3))
                    {
                        return new DondurCakistirDogru1Test3(GetTestDetails(testDetails));
                    }
                    break;
                case "Döndür Çakıştır Doğruyu Bul 2":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(DondurCakistirDogru2Sayfa1))
                    {
                        return new DondurCakistirDogru2Test1(GetTestDetails(testDetails));
                    }
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(DondurCakistirDogru2Sayfa2))
                    {
                        return new DondurCakistirDogru2Test2(GetTestDetails(testDetails));
                    }
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(DondurCakistirDogru2Sayfa3))
                    {
                        return new DondurCakistirDogru2Test3(GetTestDetails(testDetails));
                    }
                    break;
                case "Döndür Çakıştır Yanlışı Bul 1":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(DondurCakistirYanlis1Sayfa1))
                    {
                        return new DondurCakistirYanlis1Test1(GetTestDetails(testDetails));
                    }
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(DondurCakistirYanlis1Sayfa2))
                    {
                        return new DondurCakistirYanlis1Test2(GetTestDetails(testDetails));
                    }
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(DondurCakistirYanlis1Sayfa3))
                    {
                        return new DondurCakistirYanlis1Test3(GetTestDetails(testDetails));
                    }
                    break;
                case "Döndür Çakıştır Yanlışı Bul 2":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(DondurCakistirYanlis2Sayfa1))
                    {
                        return new DondurCakistirYanlis2Test1(GetTestDetails(testDetails));
                    }
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(DondurCakistirYanlis2Sayfa2))
                    {
                        return new DondurCakistirYanlis2Test2(GetTestDetails(testDetails));
                    }
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(DondurCakistirYanlis2Sayfa3))
                    {
                        return new DondurCakistirYanlis2Test3(GetTestDetails(testDetails));
                    }
                    break;
                case "Dönüşüm 1":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(DonusumSayfa1))
                    {
                        return new Donusum11Test(GetTestDetails(testDetails));
                    }
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(DonusumSayfa11))
                    {
                        return new Donusum12Test(GetTestDetails(testDetails));
                    }
                    break;
                case "Dönüşüm 2":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(DonusumSayfa2))
                    {
                        return new Donusum21Test(GetTestDetails(testDetails));
                    }
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(DonusumSayfa21))
                    {
                        return new Donusum22Test(GetTestDetails(testDetails));
                    }
                    break;
                case "Dönüşüm 3":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(DonusumSayfa3))
                    {
                        return new Donusum31Test(GetTestDetails(testDetails));
                    }
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(DonusumSayfa31))
                    {
                        return new Donusum32Test(GetTestDetails(testDetails));
                    }
                    break;
                case "Eş Eleman 1":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(EsEleman1Sayfa1))
                    {
                        return new EsElemanest11(GetTestDetails(testDetails));
                    }
                    break;
                case "Eş Eleman 2":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(EsEleman2Sayfa1))
                    {
                        return new EsElemanTest21(GetTestDetails(testDetails));
                    }
                    break;
                case "Eş Eleman 3":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(EsEleman3Sayfa1))
                    {
                        return new EsElemanest31(GetTestDetails(testDetails));
                    }
                    break;
                case "Eş Eleman 4":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(EsEleman4Sayfa1))
                    {
                        return new EsElemanTest41(GetTestDetails(testDetails));
                    }
                    break;
                case "Farklı Eleman":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(FarkliElemanSayfa1))
                    {
                        return new FarkliElemanTest1(GetTestDetails(testDetails));
                    }
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(FarkliElemanSayfa1))
                    {
                        return new FarkliElemanTest2(GetTestDetails(testDetails));
                    }
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(FarkliElemanSayfa1))
                    {
                        return new FarkliElemanTest3(GetTestDetails(testDetails));
                    }
                    break;
                case "Farklısını Bul":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(FarklisiniBulSayfa1))
                    {
                        return new FarklisiniBulTest1(GetTestDetails(testDetails));
                    }
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(FarklisiniBulSayfa2))
                    {
                        return new FarklisiniBulTest2(GetTestDetails(testDetails));
                    }
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(FarklisiniBulSayfa3))
                    {
                        return new FarklisiniBulTest3(GetTestDetails(testDetails));
                    }
                    break;
                case "Kavram Oluşturma":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(KavramSayfa1))
                    {
                        return new Kavram1Test(GetTestDetails(testDetails));
                    }
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(KavramSayfa2))
                    {
                        return new Kavram2Test(GetTestDetails(testDetails));
                    }
                    break;
                case "Kuralı Bul Uygula 1":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(KuraliBulSayfa1))
                    {
                        return new KurBulUy11Test(GetTestDetails(testDetails));
                    }
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(KuraliBulSayfa2))
                    {
                        return new KurBulUy12Test(GetTestDetails(testDetails));
                    }
                    break;
                case "Kuralı Bul Uygula 2":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(KuraliBul2Sayfa1))
                    {
                        return new KurBulUy21Test(GetTestDetails(testDetails));
                    }
                    else if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(KuraliBul2Sayfa2))
                    {
                        return new KurBulUy22Test(GetTestDetails(testDetails));
                    }
                    break;
                case "Kuralı Bul Uygula 3":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(KuraliBul3Sayfa1))
                    {
                        return new KurBulUy31Test(GetTestDetails(testDetails));
                    }
                    else if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(KuraliBul3Sayfa2))
                    {
                        return new KurBulUy32Test(GetTestDetails(testDetails));
                    }
                    break;

                case "Kuralı Bul Uygula 4":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(KuraliBul4Sayfa1))
                    {
                        return new KurBulUy41Test(GetTestDetails(testDetails));
                    }
                    break;
                case "Kuralı Bul Uygula 5":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(KuraliBul5Sayfa1))
                    {
                        return new KurBulUy51Test(GetTestDetails(testDetails));
                    }
                    break;
                case "Kuralı Bul Uygula 6":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(KuraliBul6Sayfa1))
                    {
                        return new KurBulUy61Test(GetTestDetails(testDetails));
                    }
                    break;
                case "Kuralı Bul Uygula 7":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(KuraliBul7Sayfa1))
                    {
                        return new KurBulUy71Test(GetTestDetails(testDetails));
                    }
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(KuraliBul7Sayfa2))
                    {
                        return new KurBulUy72Test(GetTestDetails(testDetails));
                    }
                    break;
                case "Kuralı Bul Uygula 8":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(KuraliBul8Sayfa1))
                    {
                        return new KurBulUy81Test(GetTestDetails(testDetails));
                    }
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(KuraliBul8Sayfa2))
                    {
                        return new KurBulUy82Test(GetTestDetails(testDetails));
                    }
                    break;
                case "Kuralı Bul Uygula 9":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(KuraliBul9Sayfa1))
                    {
                        return new KurBulUy91Test(GetTestDetails(testDetails));
                    }
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(KuraliBul9Sayfa2))
                    {
                        return new KurBulUy92Test(GetTestDetails(testDetails));
                    }
                    break;
                case "Kuralı Bul Uygula 10":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(KuraliBul10Sayfa1))
                    {
                        return new KurBulUy101Test(GetTestDetails(testDetails));
                    }
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(KuraliBul10Sayfa2))
                    {
                        return new KurBulUy102Test(GetTestDetails(testDetails));
                    }

                    break;
                case "Kuralı Bul Uygula 11":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(KuraliBul11Sayfa1))
                    {
                        return new KurBulUy111Test(GetTestDetails(testDetails));
                    }
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(KuraliBul11Sayfa2))
                    {
                        return new KurBulUy112Test(GetTestDetails(testDetails));
                    }

                    break;
                case "Kuralı Bul Uygula 12":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(KuraliBul12Sayfa1))
                    {
                        return new KurBulUy121Test(GetTestDetails(testDetails));
                    }
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(KuraliBul12Sayfa2))
                    {
                        return new KurBulUy122Test(GetTestDetails(testDetails));
                    }

                    break;
                case "Kuralı Bul Uygula 13":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(KuraliBul13Sayfa1))
                    {
                        return new KurBulUy131Test(GetTestDetails(testDetails));
                    }
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(KuraliBul13Sayfa2))
                    {
                        return new KurBulUy132Test(GetTestDetails(testDetails));
                    }

                    break;
                case "Kuralı Bul Uygula Hüseyin 1":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(KuraliBulHus1Sayfa1))
                    {
                        return new KurBulUyHusTest1(GetTestDetails(testDetails));
                    }
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(KuraliBulHus1Sayfa2))
                    {
                        return new KurBulUyHusTest2(GetTestDetails(testDetails));
                    }

                    break;
                case "Kuralı Bul Uygula Hüseyin 2":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(KuraliBulHus2Sayfa1))
                    {
                        return new KurBulUyHus2Test1(GetTestDetails(testDetails));
                    }
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(KuraliBulHus2Sayfa2))
                    {
                        return new KurBulUyHus2Test2(GetTestDetails(testDetails));
                    }

                    break;
                case "Simetrik İlişkiler 1":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(SimetrikIliski1Sayfa1))
                    {
                        return new Simetri11Test(GetTestDetails(testDetails));
                    }
                    else if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(SimetrikIliski1Sayfa2))
                    {
                        return new Simetri12Test(GetTestDetails(testDetails));
                    }
                    break;
                case "Simetrik İlişkiler 2":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(SimetrikIliski2Sayfa1))
                    {
                        return new Simetri21Test(GetTestDetails(testDetails));
                    }
                    else if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(SimetrikIliski2Sayfa2))
                    {
                        return new Simetri22Test(GetTestDetails(testDetails));
                    }
                    break;
                case "Simetrik İlişkiler 3":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(SimetrikIliski3Sayfa1))
                    {
                        return new Simetri31Test(GetTestDetails(testDetails));
                    }
                    else if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(SimetrikIliski3Sayfa2))
                    {
                        return new Simetri32Test(GetTestDetails(testDetails));
                    }
                    break;
                case "Simetrik İlişkiler 4":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(SimetrikIliski4Sayfa1))
                    {
                        return new Simetri41Test(GetTestDetails(testDetails));
                    }

                    break;
                case "Simetrik İlişkiler 5":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(SimetrikIliski5Sayfa1))
                    {
                        return new Simetri51Test(GetTestDetails(testDetails));
                    }

                    break;
                case "Simetrik İlişkiler 6":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(SimetrikIliski6Sayfa1))
                    {
                        return new Simetri61Test(GetTestDetails(testDetails));
                    }

                    break;
                case "Matris Faklıyı Bul 1":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(MatrisSayfa1))
                    {
                        return new MatrisFark1Test(GetTestDetails(testDetails));
                    }

                    break;
                case "Matris Aynısını Bul 1":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(MatrisSayfa1))
                    {
                        return new MatrisAyni1Test(GetTestDetails(testDetails));
                    }

                    break;
                case "Matris Analoji 1":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(MatrisAnalojiSayfa1))
                    {
                        return new MatrisAnaloji1Test(GetTestDetails(testDetails));
                    }

                    break;
                case "Melez İkili":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(MelezIkiliSayfa1))
                    {
                        return new MelezIkiliTest1(GetTestDetails(testDetails));
                    }
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(MelezIkiliSayfa2))
                    {
                        return new MelezIkiliTest2(GetTestDetails(testDetails));
                    }
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(MelezIkiliSayfa3))
                    {
                        return new MelezIkiliTest3(GetTestDetails(testDetails));
                    }
                    break;
                case "Melez Üçlü":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(MelezUcluSayfa1))
                    {
                        return new MelezUcluTest1(GetTestDetails(testDetails));
                    }
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(MelezUcluSayfa2))
                    {
                        return new MelezUcluTest2(GetTestDetails(testDetails));
                    }
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(MelezUcluSayfa3))
                    {
                        return new MelezUcluTest3(GetTestDetails(testDetails));
                    }
                    break;
                case "Melez Dörtlü":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(MelezDortluSayfa1))
                    {
                        return new MelezDortluTest1(GetTestDetails(testDetails));
                    }
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(MelezDortluSayfa2))
                    {
                        return new MelezDortluTest2(GetTestDetails(testDetails));
                    }

                    break;
                case "Ortak Eleman":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(OrtakElemanSayfa1))
                    {
                        return new OrtakElemanTest1(GetTestDetails(testDetails));
                    }
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(OrtakElemanSayfa2))
                    {
                        return new OrtakElemanTest2(GetTestDetails(testDetails));
                    }
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(OrtakElemanSayfa3))
                    {
                        return new OrtakElemanTest3(GetTestDetails(testDetails));
                    }
                    break;
                case "Para Oyunu 1":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(ParaOyunu1Sayfa1))
                    {
                        return new ParaOyun1Test1(GetTestDetails(testDetails));
                    }
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(ParaOyunu1Sayfa2))
                    {
                        return new ParaOyun1Test2(GetTestDetails(testDetails));
                    }
                    break;
                case "Para Oyunu 2":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(ParaOyunu2Sayfa1))
                    {
                        return new ParaOyun2Test1(GetTestDetails(testDetails));
                    }
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(ParaOyunu2Sayfa2))
                    {
                        return new ParaOyun2Test2(GetTestDetails(testDetails));
                    }
                    break;
                case "Para Oyunu 3":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(ParaOyunu3Sayfa1))
                    {
                        return new ParaOyun3Test1(GetTestDetails(testDetails));
                    }
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(ParaOyunu3Sayfa2))
                    {
                        return new ParaOyun3Test2(GetTestDetails(testDetails));
                    }
                    break;
                case "Para Oyunu 4":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(ParaOyunu4Sayfa1))
                    {
                        return new ParaOyun4Test1(GetTestDetails(testDetails));
                    }
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(ParaOyunu4Sayfa2))
                    {
                        return new ParaOyun4Test2(GetTestDetails(testDetails));
                    }
                    break;
                case "Parçadan Bütüne":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(ParcaButunSayfa1))
                    {
                        return new ParcaButun1Test(GetTestDetails(testDetails));
                    }
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(ParcaButunSayfa2))
                    {
                        return new ParcaButun2Test(GetTestDetails(testDetails));
                    }
                    break;
                case "Sınıflandırma 1":
                    return new SinifBesli1Test(GetTestDetails(testDetails));
                case "Sınıflandırma 2":
                    return new SinifBesli2Test(GetTestDetails(testDetails));
                case "Sınıflandırma 3":
                    return new SinifBesli3Test(GetTestDetails(testDetails));
                case "Sınıflandırma 6 lı 1":
                    return new SinifAltili1Test(GetTestDetails(testDetails));
                case "Sınıflandırma 6 lı 2":
                    return new SinifAltili2Test(GetTestDetails(testDetails));
                case "Sınıflandırma 6 lı 3":
                    return new SinifAltili3Test(GetTestDetails(testDetails));
                case "Sınıflandırma 7 li 1":
                    return new SinifYedili1Test(GetTestDetails(testDetails));
                case "Sınıflandırma 7 li 2":
                    return new SinifYedili2Test(GetTestDetails(testDetails));
                case "Sınıflandırma 7 li 3":
                    return new SinifYedili3Test(GetTestDetails(testDetails));
                case "Sınıflandırma Parça Bütün":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(SinifParcaSayfa1))
                    {
                        return new SinifParca1Test(GetTestDetails(testDetails));
                    }
                    break;
                case "Tümü Farklı Eleman":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(TumuFarkliElemanSayfa1))
                    {
                        return new TumuFarkliElemanTest1(GetTestDetails(testDetails));
                    }
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(TumuFarkliElemanSayfa2))
                    {
                        return new TumuFarkliElemanTest2(GetTestDetails(testDetails));
                    }
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(TumuFarkliElemanSayfa3))
                    {
                        return new TumuFarkliElemanTest3(GetTestDetails(testDetails));
                    }
                    break;
                case "Yer Değiştireni Bul Uygula":
                    if (seciliSayfaTip.SayfaTemplate.GetType() == typeof(YerDegistir1Sayfa1))
                    {
                        return new YerDegistir1Test1(GetTestDetails(testDetails));
                    }
                    break;
            }
            return null;
        }




        private List<TestDetail> GetTestDetails(IEnumerable<FasikulTestDetail> testDetails)
        {
            var newTests = new List<TestDetail>();
            foreach (var fasikulTestDetail in testDetails)
            {
                newTests.Add(new TestDetail
                {
                    Havuz = HavuzCreater.GetYeniTipHavuz(fasikulTestDetail.SeciliHavuzYol),
                    SabitParcaAdet = fasikulTestDetail.SabitParcaAdet,
                    SayfaAdet = fasikulTestDetail.SayfaAdet,
                    Zorluk = fasikulTestDetail.ZorlukDerece
                });
            }
            return newTests;
        }
       
    }
}
