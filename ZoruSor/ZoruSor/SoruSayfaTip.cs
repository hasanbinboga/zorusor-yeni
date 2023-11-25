using System.Collections.Generic;
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
    public static class SoruSayfaTip
    {
        static SoruSayfaTip()
        {
            InitializeSayfaTip();
        }

        public static List<SayfaTip> Items { get; set; }

        private static void InitializeSayfaTip()
        {
            Items = new List<SayfaTip>(20);

            Items.Add(new SayfaTip
            {
                Ad = "Sekiz Seçenekli",
                SoruTipList = new List<string> { "Analoji Parçalı 1" },
                SayfaTemplate = new AnalojiParcali1Sayfa1()
            });
            Items.Add(new SayfaTip
            {
                Ad = "Sekiz Seçenekli",
                SoruTipList = new List<string> { "Analoji Parçalı 2" },
                SayfaTemplate = new AnalojiParcali2Sayfa1()
            });
            Items.Add(new SayfaTip
            {
                Ad = "Sekiz Seçenekli",
                SoruTipList = new List<string> { "Analoji Parçalı 3" },
                SayfaTemplate = new AnalojiParcali3Sayfa1()
            });

            Items.Add(new SayfaTip
            {
                Ad = "Beş Seçenekli",
                SoruTipList = new List<string> { "Analoji 1" },
                SayfaTemplate = new AnalojiSayfa1()
            });

            Items.Add(new SayfaTip
            {
                Ad = "Dört Seçenekli",
                SoruTipList = new List<string> { "Analoji 1" },
                SayfaTemplate = new AnalojiSayfa2()
            });
            Items.Add(new SayfaTip
            {
                Ad = "Altı Seçenekli",
                SoruTipList = new List<string> { "Analoji 2" },
                SayfaTemplate = new AnalojiSayfa3()
            });
            Items.Add(new SayfaTip
            {
                Ad = "Altı Seçenekli",
                SoruTipList = new List<string> { "Analoji 3" },
                SayfaTemplate = new AnalojiSayfa4()
            });
            Items.Add(new SayfaTip
            {
                Ad = "Altı Seçenekli",
                SoruTipList = new List<string> { "Aynısını Bul" },
                SayfaTemplate = new AynisiniBulSayfa1()
            });


            Items.Add(new SayfaTip
            {
                Ad = "Dokuz Seçenekli",
                SoruTipList = new List<string> { "Döndür Bul Uygula 1" },
                SayfaTemplate = new DondurBul1Sayfa1()
            });
            Items.Add(new SayfaTip
            {
                Ad = "Dokuz Seçenekli",
                SoruTipList = new List<string> { "Döndür Bul Uygula 2" },
                SayfaTemplate = new DondurBul2Sayfa1()
            });

            Items.Add(new SayfaTip
            {
                Ad = "Oniki Seçenekli",
                SoruTipList = new List<string> { "Döndür Çakıştır Doğruyu Bul 1" },
                SayfaTemplate = new DondurCakistirDogru1Sayfa1()
            });

            Items.Add(new SayfaTip
            {
                Ad = "Sekiz Seçenekli",
                SoruTipList = new List<string> { "Döndür Çakıştır Doğruyu Bul 1" },
                SayfaTemplate = new DondurCakistirDogru1Sayfa2()
            });

            Items.Add(new SayfaTip
            {
                Ad = "Dört Seçenekli",
                SoruTipList = new List<string> { "Döndür Çakıştır Doğruyu Bul 1" },
                SayfaTemplate = new DondurCakistirDogru1Sayfa3()
            });

            Items.Add(new SayfaTip
            {
                Ad = "Oniki Seçenekli",
                SoruTipList = new List<string> { "Döndür Çakıştır Doğruyu Bul 2" },
                SayfaTemplate = new DondurCakistirDogru2Sayfa1()
            });

            Items.Add(new SayfaTip
            {
                Ad = "Sekiz Seçenekli",
                SoruTipList = new List<string> { "Döndür Çakıştır Doğruyu Bul 2" },
                SayfaTemplate = new DondurCakistirDogru2Sayfa2()
            });

            Items.Add(new SayfaTip
            {
                Ad = "Dört Seçenekli",
                SoruTipList = new List<string> { "Döndür Çakıştır Doğruyu Bul 2" },
                SayfaTemplate = new DondurCakistirDogru2Sayfa3()
            });

            Items.Add(new SayfaTip
            {
                Ad = "Oniki Seçenekli",
                SoruTipList = new List<string> { "Döndür Çakıştır Yanlışı Bul 1" },
                SayfaTemplate = new DondurCakistirYanlis1Sayfa1()
            });
            Items.Add(new SayfaTip
            {
                Ad = "Sekiz Seçenekli",
                SoruTipList = new List<string> { "Döndür Çakıştır Yanlışı Bul 1" },
                SayfaTemplate = new DondurCakistirYanlis1Sayfa2()
            });
            Items.Add(new SayfaTip
            {
                Ad = "Dört Seçenekli",
                SoruTipList = new List<string> { "Döndür Çakıştır Yanlışı Bul 1" },
                SayfaTemplate = new DondurCakistirYanlis1Sayfa3()
            });

            Items.Add(new SayfaTip
            {
                Ad = "Oniki Seçenekli",
                SoruTipList = new List<string> { "Döndür Çakıştır Yanlışı Bul 2" },
                SayfaTemplate = new DondurCakistirYanlis2Sayfa1()
            });

            Items.Add(new SayfaTip
            {
                Ad = "Sekiz Seçenekli",
                SoruTipList = new List<string> { "Döndür Çakıştır Yanlışı Bul 2" },
                SayfaTemplate = new DondurCakistirYanlis2Sayfa2()
            });
            Items.Add(new SayfaTip
            {
                Ad = "Dört Seçenekli",
                SoruTipList = new List<string> { "Döndür Çakıştır Yanlışı Bul 2" },
                SayfaTemplate = new DondurCakistirYanlis2Sayfa3()
            });
            Items.Add(new SayfaTip
            {
                Ad = "Altı Seçenekli",
                SoruTipList = new List<string> { "Farklısını Bul" },
                SayfaTemplate = new FarklisiniBulSayfa1()
            });
            Items.Add(new SayfaTip
            {
                Ad = "Altı Seçenekli",
                SoruTipList = new List<string> { "Farklı Eleman" },
                SayfaTemplate = new FarkliElemanSayfa1()
            });
            Items.Add(new SayfaTip
            {
                Ad = "Altı Seçenekli",
                SoruTipList = new List<string> { "Ortak Eleman" },
                SayfaTemplate = new OrtakElemanSayfa1()
            });
            Items.Add(new SayfaTip
            {
                Ad = "Altı Seçenekli",
                SoruTipList = new List<string> { "Tümü Farklı Eleman" },
                SayfaTemplate = new TumuFarkliElemanSayfa1()
            });
            Items.Add(new SayfaTip
            {
                Ad = "Üç Seçenekli",
                SoruTipList = new List<string> { "Aynısını Bul" },
                SayfaTemplate = new AynisiniBulSayfa2()
            });
            Items.Add(new SayfaTip
            {
                Ad = "Üç Seçenekli",
                SoruTipList = new List<string> { "Farklısını Bul" },
                SayfaTemplate = new FarklisiniBulSayfa2()
            });
            Items.Add(new SayfaTip
            {
                Ad = "Üç Seçenekli",
                SoruTipList = new List<string> { "Farklı Eleman" },
                SayfaTemplate = new FarkliElemanSayfa2()
            });
            Items.Add(new SayfaTip
            {
                Ad = "Üç Seçenekli",
                SoruTipList = new List<string> { "Ortak Eleman" },
                SayfaTemplate = new OrtakElemanSayfa2()
            });
            Items.Add(new SayfaTip
            {
                Ad = "Üç Seçenekli",
                SoruTipList = new List<string> { "Tümü Farklı Eleman" },
                SayfaTemplate = new TumuFarkliElemanSayfa2()

            });
            Items.Add(new SayfaTip
            {
                Ad = "Üç Seçenekli Büyük",
                SoruTipList = new List<string> { "Aynısını Bul" },
                SayfaTemplate = new AynisiniBulSayfa3()
            });
            Items.Add(new SayfaTip
            {
                Ad = "Üç Seçenekli Büyük",
                SoruTipList = new List<string> { "Farklısını Bul" },
                SayfaTemplate = new FarklisiniBulSayfa3()
            });
            Items.Add(new SayfaTip
            {
                Ad = "Üç Seçenekli Büyük",
                SoruTipList = new List<string> { "Farklı Eleman" },
                SayfaTemplate = new AynisiniBulSayfa3()
            });
            Items.Add(new SayfaTip
            {
                Ad = "Üç Seçenekli Büyük",
                SoruTipList = new List<string> { "Ortak Eleman" },
                SayfaTemplate = new OrtakElemanSayfa3()
            });
            Items.Add(new SayfaTip
            {
                Ad = "Üç Seçenekli Büyük",
                SoruTipList = new List<string> { "Tümü Farklı Eleman" },
                SayfaTemplate = new TumuFarkliElemanSayfa3()
            });
            Items.Add(new SayfaTip
            {
                Ad = "Beş Seçenekli",
                SoruTipList = new List<string> { "Bütünden Parçaya" },
                SayfaTemplate = new ButunParcaSayfa1()
            });
            Items.Add(new SayfaTip
            {
                Ad = "Üç Seçenekli",
                SoruTipList = new List<string> { "Bütünden Parçaya" },
                SayfaTemplate = new ButunParcaSayfa2()
            });
            Items.Add(new SayfaTip
            {
                Ad = "Dört Seçenekli",
                SoruTipList = new List<string> { "Çakıştırma Doğruyu Bul" },
                SayfaTemplate = new CakistirDogruSayfa1()
            });
            Items.Add(new SayfaTip
            {
                Ad = "Dört Seçenekli",
                SoruTipList = new List<string> { "Çakıştırma Yanlışı Bul" },
                SayfaTemplate = new CakistirYanlisSayfa1()
            });
            Items.Add(new SayfaTip
            {
                Ad = "Altı Seçenekli",
                SoruTipList = new List<string> { "Çakıştırma Doğruyu Bul" },
                SayfaTemplate = new CakistirDogruSayfa2()
            });
            Items.Add(new SayfaTip
            {
                Ad = "Altı Seçenekli",
                SoruTipList = new List<string> {  "Çakıştırma Yanlışı Bul" },
                SayfaTemplate = new CakistirYanlisSayfa2()
            });
            Items.Add(new SayfaTip
            {
                Ad = "Dokuz Seçenekli",
                SoruTipList = new List<string> { "Çakıştırma Doğruyu Bul" },
                SayfaTemplate = new CakistirDogruSayfa3()
            });
            Items.Add(new SayfaTip
            {
                Ad = "Dokuz Seçenekli",
                SoruTipList = new List<string> { "Çakıştırma Yanlışı Bul" },
                SayfaTemplate = new CakistirYanlisSayfa3()
            });
            Items.Add(new SayfaTip
            {
                Ad = "Sekiz Seçenekli",
                SoruTipList = new List<string> { "Dönüşüm 1" },
                SayfaTemplate = new DonusumSayfa1()
            });
            Items.Add(new SayfaTip
            {
                Ad = "Dokuz Seçenekli",
                SoruTipList = new List<string> { "Dönüşüm 1" },
                SayfaTemplate = new DonusumSayfa11()
            });
            Items.Add(new SayfaTip
            {
                Ad = "On Seçenekli",
                SoruTipList = new List<string> { "Dönüşüm 2" },
                SayfaTemplate = new DonusumSayfa2()
            });
            Items.Add(new SayfaTip
            {
                Ad = "Dokuz Seçenekli",
                SoruTipList = new List<string> { "Dönüşüm 2" },
                SayfaTemplate = new DonusumSayfa21()
            });
            Items.Add(new SayfaTip
            {
                Ad = "Altı Seçenekli",
                SoruTipList = new List<string> { "Dönüşüm 3" },
                SayfaTemplate = new DonusumSayfa3()
            });
            Items.Add(new SayfaTip
            {
                Ad = "Altı Seçenekli Büyük",
                SoruTipList = new List<string> { "Dönüşüm 3" },
                SayfaTemplate = new DonusumSayfa31()
            });
            Items.Add(new SayfaTip
            {
                Ad = "Dört Seçenekli",
                SoruTipList = new List<string> { "Eş Eleman 1" },
                SayfaTemplate = new EsElemanSayfa1()
            });
            Items.Add(new SayfaTip
            {
                Ad = "Dört Seçenekli",
                SoruTipList = new List<string> { "Eş Eleman 2"},
                SayfaTemplate = new EsElemanSayfa1()
            });
            Items.Add(new SayfaTip
            {
                Ad = "Dört Seçenekli",
                SoruTipList = new List<string> { "Eş Eleman 3"},
                SayfaTemplate = new EsElemanSayfa1()
            });
            Items.Add(new SayfaTip
            {
                Ad = "Dört Seçenekli",
                SoruTipList = new List<string> {  "Eş Eleman 4" },
                SayfaTemplate = new EsElemanSayfa1()
            });
            Items.Add(new SayfaTip
            {
                Ad = "Altı Seçenekli",
                SoruTipList = new List<string> { "Kavram Oluşturma" },
                SayfaTemplate = new KavramSayfa1()
            });
            Items.Add(new SayfaTip
            {
                Ad = "Beş Seçenekli",
                SoruTipList = new List<string> { "Kavram Oluşturma" },
                SayfaTemplate = new KavramSayfa2()
            });

            #region KuraliBul 1

            Items.Add(new SayfaTip
            {
                Ad = "Dokuz Seçenekli",
                SoruTipList = new List<string> { "Kuralı Bul Uygula 1"},
                SayfaTemplate = new KuraliBulSayfa1()
            });

            Items.Add(new SayfaTip
            {
                Ad = "Dört Seçenekli",
                SoruTipList = new List<string> { "Kuralı Bul Uygula 1"},
                SayfaTemplate = new KuraliBulSayfa2()
            });

            #endregion

            #region KuraliBul 2

            Items.Add(new SayfaTip
            {
                Ad = "Dokuz Seçenekli",
                SoruTipList = new List<string> { "Kuralı Bul Uygula 2"},
                SayfaTemplate = new KuraliBul2Sayfa1()
            });

            Items.Add(new SayfaTip
            {
                Ad = "Dört Seçenekli",
                SoruTipList = new List<string> { "Kuralı Bul Uygula 2"},
                SayfaTemplate = new KuraliBul2Sayfa2()
            });

            #endregion

            #region KuraliBul 3

            Items.Add(new SayfaTip
            {
                Ad = "Dokuz Seçenekli",
                SoruTipList = new List<string> { "Kuralı Bul Uygula 3"},
                SayfaTemplate = new KuraliBul3Sayfa1()
            });

            Items.Add(new SayfaTip
            {
                Ad = "Dört Seçenekli",
                SoruTipList = new List<string> { "Kuralı Bul Uygula 3" },
                SayfaTemplate = new KuraliBul3Sayfa2()
            });

            #endregion

            Items.Add(new SayfaTip
            {
                Ad = "Dokuz Seçenekli",
                SoruTipList = new List<string> { "Kuralı Bul Uygula 4" },
                SayfaTemplate = new KuraliBul4Sayfa1()
            });

            Items.Add(new SayfaTip
            {
                Ad = "Dokuz Seçenekli",
                SoruTipList = new List<string> { "Kuralı Bul Uygula 5" },
                SayfaTemplate = new KuraliBul5Sayfa1()
            });

            Items.Add(new SayfaTip
            {
                Ad = "Dokuz Seçenekli",
                SoruTipList = new List<string> { "Kuralı Bul Uygula 6" },
                SayfaTemplate = new KuraliBul6Sayfa1()
            });

            Items.Add(new SayfaTip
            {
                Ad = "Dokuz Seçenekli",
                SoruTipList = new List<string> { "Kuralı Bul Uygula 7" },
                SayfaTemplate = new KuraliBul7Sayfa1()
            });

            Items.Add(new SayfaTip
            {
                Ad = "Dokuz Seçenekli",
                SoruTipList = new List<string> { "Kuralı Bul Uygula 8" },
                SayfaTemplate = new KuraliBul8Sayfa1()
            });

            Items.Add(new SayfaTip
            {
                Ad = "Dokuz Seçenekli",
                SoruTipList = new List<string> { "Kuralı Bul Uygula 9" },
                SayfaTemplate = new KuraliBul9Sayfa1()
            });

            Items.Add(new SayfaTip
            {
                Ad = "Dokuz Seçenekli",
                SoruTipList = new List<string> {  "Kuralı Bul Uygula 10" },
                SayfaTemplate = new KuraliBul10Sayfa1()
            });

            Items.Add(new SayfaTip
            {
                Ad = "Dokuz Seçenekli",
                SoruTipList = new List<string> { "Kuralı Bul Uygula 11" },
                SayfaTemplate = new KuraliBul11Sayfa1()
            });

            Items.Add(new SayfaTip
            {
                Ad = "Dokuz Seçenekli",
                SoruTipList = new List<string> {"Kuralı Bul Uygula 12" },
                SayfaTemplate = new KuraliBul12Sayfa1()
            });

            Items.Add(new SayfaTip
            {
                Ad = "Dokuz Seçenekli",
                SoruTipList = new List<string> { "Kuralı Bul Uygula 13" },
                SayfaTemplate = new KuraliBul13Sayfa1()
            });
            Items.Add(new SayfaTip
            {
                Ad = "Dokuz Seçenekli",
                SoruTipList = new List<string> { "Kuralı Bul Uygula Hüseyin 1" },
                SayfaTemplate = new KuraliBulHus1Sayfa1()
            });
            Items.Add(new SayfaTip
            {
                Ad = "Dokuz Seçenekli",
                SoruTipList = new List<string> {  "Kuralı Bul Uygula Hüseyin 2"
                                                },
                SayfaTemplate = new KuraliBulHus2Sayfa1()
            });

            Items.Add(new SayfaTip
            {
                Ad = "Altı Seçenekli",
                SoruTipList = new List<string> { "Kuralı Bul Uygula 7" },
                SayfaTemplate = new KuraliBul7Sayfa2()
            });

            Items.Add(new SayfaTip
            {
                Ad = "Altı Seçenekli",
                SoruTipList = new List<string> { "Kuralı Bul Uygula 8" },
                SayfaTemplate = new KuraliBul8Sayfa2()
            });

            Items.Add(new SayfaTip
            {
                Ad = "Altı Seçenekli",
                SoruTipList = new List<string> { "Kuralı Bul Uygula 9" },
                SayfaTemplate = new KuraliBul9Sayfa2()
            });

            Items.Add(new SayfaTip
            {
                Ad = "Altı Seçenekli",
                SoruTipList = new List<string> {"Kuralı Bul Uygula 10" },
                SayfaTemplate = new KuraliBul10Sayfa2()
            });

            Items.Add(new SayfaTip
            {
                Ad = "Altı Seçenekli",
                SoruTipList = new List<string> { "Kuralı Bul Uygula 11" },
                SayfaTemplate = new KuraliBul11Sayfa2()
            });

            Items.Add(new SayfaTip
            {
                Ad = "Altı Seçenekli",
                SoruTipList = new List<string> { "Kuralı Bul Uygula 12" },
                SayfaTemplate = new KuraliBul12Sayfa2()
            });

            Items.Add(new SayfaTip
            {
                Ad = "Altı Seçenekli",
                SoruTipList = new List<string> { "Kuralı Bul Uygula 13" },
                SayfaTemplate = new KuraliBul13Sayfa2()
            });

            Items.Add(new SayfaTip
            {
                Ad = "Altı Seçenekli",
                SoruTipList = new List<string> { "Kuralı Bul Uygula Hüseyin" },
                SayfaTemplate = new KuraliBulHus1Sayfa2()
            });

            Items.Add(new SayfaTip
            {
                Ad = "Altı Seçenekli",
                SoruTipList = new List<string> { "Kuralı Bul Uygula Hüseyin 2"  },
                SayfaTemplate = new KuraliBulHus2Sayfa2()
            });

            Items.Add(new SayfaTip
            {
                Ad = "Dokuz Seçenekli",
                SoruTipList = new List<string> { "Simetrik İlişkiler 1"},
                SayfaTemplate = new SimetrikIliski1Sayfa1()
            });
            Items.Add(new SayfaTip
            {
                Ad = "Dört Seçenekli",
                SoruTipList = new List<string> { "Simetrik İlişkiler 1" },
                SayfaTemplate = new SimetrikIliski1Sayfa2()
            });

            Items.Add(new SayfaTip
            {
                Ad = "Dokuz Seçenekli",
                SoruTipList = new List<string> { "Simetrik İlişkiler 2" },
                SayfaTemplate = new SimetrikIliski2Sayfa1()
            });
            Items.Add(new SayfaTip
            {
                Ad = "Dört Seçenekli",
                SoruTipList = new List<string> { "Simetrik İlişkiler 2" },
                SayfaTemplate = new SimetrikIliski2Sayfa2()
            });

            Items.Add(new SayfaTip
            {
                Ad = "Dokuz Seçenekli",
                SoruTipList = new List<string> { "Simetrik İlişkiler 3" },
                SayfaTemplate = new SimetrikIliski3Sayfa1()
            });
            Items.Add(new SayfaTip
            {
                Ad = "Dört Seçenekli",
                SoruTipList = new List<string> { "Simetrik İlişkiler 3" },
                SayfaTemplate = new SimetrikIliski3Sayfa2()
            });

            Items.Add(new SayfaTip
            {
                Ad = "Oniki Seçenekli",
                SoruTipList = new List<string> { "Simetrik İlişkiler 4" },
                SayfaTemplate = new SimetrikIliski4Sayfa1()
            });

            Items.Add(new SayfaTip
            {
                Ad = "Oniki Seçenekli",
                SoruTipList = new List<string> {  "Simetrik İlişkiler 5" },
                SayfaTemplate = new SimetrikIliski5Sayfa1()
            });

            Items.Add(new SayfaTip
            {
                Ad = "Oniki Seçenekli",
                SoruTipList = new List<string> { "Simetrik İlişkiler 6" },
                SayfaTemplate = new SimetrikIliski6Sayfa1()
            });

            Items.Add(new SayfaTip
            {
                Ad = "Altı Seçenekli",
                SoruTipList = new List<string> { "Matris Faklıyı Bul 1" },
                SayfaTemplate = new MatrisSayfa1()
            });

            Items.Add(new SayfaTip
            {
                Ad = "Altı Seçenekli",
                SoruTipList = new List<string> { "Matris Aynısını Bul 1" },
                SayfaTemplate = new MatrisSayfa1()
            });

            Items.Add(new SayfaTip
            {
                Ad = "Altı Seçenekli",
                SoruTipList = new List<string> { "Matris Analoji 1" },
                SayfaTemplate = new MatrisAnalojiSayfa1()
            });
            
            Items.Add(new SayfaTip
            {
                Ad = "Beş Seçenekli",
                SoruTipList = new List<string> { "Melez İkili" },
                SayfaTemplate = new MelezIkiliSayfa1()
            });
            Items.Add(new SayfaTip
            {
                Ad = "Dört Seçenekli",
                SoruTipList = new List<string> { "Melez İkili" },
                SayfaTemplate = new MelezIkiliSayfa2()
            });
            Items.Add(new SayfaTip
            {
                Ad = "Oniki Seçenekli",
                SoruTipList = new List<string> { "Melez İkili" },
                SayfaTemplate = new MelezIkiliSayfa3()
            });
            Items.Add(new SayfaTip
            {
                Ad = "Dört Seçenekli",
                SoruTipList = new List<string> { "Melez Üçlü" },
                SayfaTemplate = new MelezUcluSayfa1()
            });
            Items.Add(new SayfaTip
            {
                Ad = "Dört Seçenekli Büyük",
                SoruTipList = new List<string> { "Melez Üçlü" },
                SayfaTemplate = new MelezUcluSayfa2()
            });
            Items.Add(new SayfaTip
            {
                Ad = "Oniki Seçenekli Büyük",
                SoruTipList = new List<string> { "Melez Üçlü" },
                SayfaTemplate = new MelezUcluSayfa3()
            });
            Items.Add(new SayfaTip
            {
                Ad = "Dört Seçenekli Büyük",
                SoruTipList = new List<string> { "Melez Dörtlü" },
                SayfaTemplate = new MelezDortluSayfa1()
            });
            Items.Add(new SayfaTip
            {
                Ad = "Oniki Seçenekli Büyük",
                SoruTipList = new List<string> { "Melez Dörtlü" },
                SayfaTemplate = new MelezDortluSayfa2()
            });
            #region Para Oyunu 1

            Items.Add(new SayfaTip
            {
                Ad = "Dokuz Seçenekli",
                SoruTipList = new List<string> { "Para Oyunu 1" },
                SayfaTemplate = new ParaOyunu1Sayfa1()
            });

            Items.Add(new SayfaTip
            {
                Ad = "Dört Seçenekli",
                SoruTipList = new List<string> { "Para Oyunu 1" },
                SayfaTemplate = new ParaOyunu1Sayfa2()
            });

            #endregion

            #region Para Oyunu 2

            Items.Add(new SayfaTip
            {
                Ad = "Dokuz Seçenekli",
                SoruTipList = new List<string> { "Para Oyunu 2" },
                SayfaTemplate = new ParaOyunu2Sayfa1()
            });

            Items.Add(new SayfaTip
            {
                Ad = "Dört Seçenekli",
                SoruTipList = new List<string> { "Para Oyunu 2" },
                SayfaTemplate = new ParaOyunu2Sayfa2()
            });

            #endregion

            #region Para Oyunu 2

            Items.Add(new SayfaTip
            {
                Ad = "Dokuz Seçenekli",
                SoruTipList = new List<string> { "Para Oyunu 3" },
                SayfaTemplate = new ParaOyunu3Sayfa1()
            });

            Items.Add(new SayfaTip
            {
                Ad = "Dört Seçenekli",
                SoruTipList = new List<string> { "Para Oyunu 3" },
                SayfaTemplate = new ParaOyunu3Sayfa2()
            });

            #endregion

            #region Para Oyunu 4

            Items.Add(new SayfaTip
            {
                Ad = "Dokuz Seçenekli",
                SoruTipList = new List<string> { "Para Oyunu 4" },
                SayfaTemplate = new ParaOyunu4Sayfa1()
            });

            Items.Add(new SayfaTip
            {
                Ad = "Dört Seçenekli",
                SoruTipList = new List<string> { "Para Oyunu 4" },
                SayfaTemplate = new ParaOyunu4Sayfa2()
            });

            #endregion

            #region Para Oyunu 4 - 1

            Items.Add(new SayfaTip
            {
                Ad = "Dokuz Seçenekli",
                SoruTipList = new List<string> { "Para Oyunu 4 - 1" },
                SayfaTemplate = new ParaOyunu41Sayfa1()
            });

            Items.Add(new SayfaTip
            {
                Ad = "Dört Seçenekli",
                SoruTipList = new List<string> { "Para Oyunu 4 - 1" },
                SayfaTemplate = new ParaOyunu41Sayfa2()
            });

            #endregion

            #region Para Oyunu 5

            Items.Add(new SayfaTip
            {
                Ad = "Dokuz Seçenekli",
                SoruTipList = new List<string> { "Para Oyunu 5" },
                SayfaTemplate = new ParaOyunu5Sayfa1()
            });

            Items.Add(new SayfaTip
            {
                Ad = "Dört Seçenekli",
                SoruTipList = new List<string> { "Para Oyunu 5" },
                SayfaTemplate = new ParaOyunu5Sayfa2()
            });

            #endregion


            Items.Add(new SayfaTip
            {
                Ad = "Beş Seçenekli",
                SoruTipList = new List<string> { "Parçadan Bütüne" },
                SayfaTemplate = new ParcaButunSayfa1()
            });
            Items.Add(new SayfaTip
            {
                Ad = "Dört Seçenekli",
                SoruTipList = new List<string> { "Parçadan Bütüne" },
                SayfaTemplate = new ParcaButunSayfa2()
            });
            Items.Add(new SayfaTip
            {
                Ad = "Yedi Seçenekli",
                SoruTipList = new List<string> { "Sınıflandırma 1"},
                SayfaTemplate = new Siniflandir1Sayfa1()
            });

            Items.Add(new SayfaTip
            {
                Ad = "Yedi Seçenekli",
                SoruTipList = new List<string> { "Sınıflandırma 2"},
                SayfaTemplate = new Siniflandir2Sayfa1()
            });

            Items.Add(new SayfaTip
            {
                Ad = "Yedi Seçenekli",
                SoruTipList = new List<string> { "Sınıflandırma 3" },
                SayfaTemplate = new Siniflandir3Sayfa1()
            });
            Items.Add(new SayfaTip
            {
                Ad = "Yedi Seçenekli",
                SoruTipList = new List<string> { "Sınıflandırma 6 lı 1" },
                SayfaTemplate = new Siniflandir61Sayfa1()
            });
            Items.Add(new SayfaTip
            {
                Ad = "Yedi Seçenekli",
                SoruTipList = new List<string> {"Sınıflandırma 6 lı 2" },
                SayfaTemplate = new Siniflandir62Sayfa1()
            });
            Items.Add(new SayfaTip
            {
                Ad = "Yedi Seçenekli",
                SoruTipList = new List<string> {   "Sınıflandırma 6 lı 3" },
                SayfaTemplate = new Siniflandir63Sayfa1()
            });
            Items.Add(new SayfaTip
            {
                Ad = "Yedi Seçenekli",
                SoruTipList = new List<string> { "Sınıflandırma 7 li 1"  },
                SayfaTemplate = new Siniflandir71Sayfa1()
            });
            Items.Add(new SayfaTip
            {
                Ad = "Yedi Seçenekli",
                SoruTipList = new List<string> {  "Sınıflandırma 7 li 2"  },
                SayfaTemplate = new Siniflandir72Sayfa1()
            });
            Items.Add(new SayfaTip
            {
                Ad = "Yedi Seçenekli",
                SoruTipList = new List<string> {  "Sınıflandırma 7 li 3" },
                SayfaTemplate = new Siniflandir73Sayfa1()
            });
            Items.Add(new SayfaTip
            {
                Ad = "Sekiz Seçeneki",
                SoruTipList = new List<string> { "Sınıflandırma Parça Bütün" },
                SayfaTemplate = new SinifParcaSayfa1()
            });
             Items.Add(new SayfaTip
            {
                Ad = "Dokuz Seçeneki",
                SoruTipList = new List<string> { "Yer Değiştireni Bul Uygula" },
                SayfaTemplate = new YerDegistir1Sayfa1()
            });
        }
    }
}
