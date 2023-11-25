using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using ZoruSor.Lib.Havuz;
using ZoruSor.Lib.Soru;
using ZoruSor.Lib.Test;
using ZoruSor.Lib.Test.Analoji;
using ZoruSor.Lib.Test.AynisiniBul;
using ZoruSor.Lib.Test.ButunParca;
using ZoruSor.Lib.Test.Cakistirma;
using ZoruSor.Lib.Test.Donusum;
using ZoruSor.Lib.Test.FarklisiniBul;
using ZoruSor.Lib.Test.Kavram;
using ZoruSor.Lib.Test.KuraliBul;
using ZoruSor.Lib.Test.ParcaButun;
using ZoruSor.Lib.Test.Siniflandirma;
using ZoruSor.Lib.TestSoru;
using ZoruSor.Reports;
using ZoruSor.Reports.CakistirDogru;
using ZoruSor.Reports.KuraliBul;

namespace ZoruSor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        
        private void button2_Click(object sender, EventArgs e)
        {
            new KavramOlusturma().Show(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Cakistirma().Show(this);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new Siniflandirma().Show(this);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            new AynisiniBul().Show(this);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            new FarklisiniBul().Show(this);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new Donusum1().Show(this);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            new Donusum2().Show(this);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            new KurBulUygula().Show(this);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            new Analoji().Show(this);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            new CakistirYanlisiBul().Show(this);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            new Donusum3().Show(this);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            new KurBulUygula1().Show(this);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            new ParcadanButune().Show(this);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            new ButundenParcaya().Show(this);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            new Donusum4().Show(this);
        }

        private void button16_Click(object sender, EventArgs e)
        {

            var havuz = HavuzCreater.GetYeniTipHavuz(@"C:\Users\admin\Desktop\Zorusor\Yüz1");

            var zorulDerece = 8;
            var sabitParca = 2;
            var sayfaAdet = 10;
            var test = new AynisiniBulTest1(havuz, zorulDerece, sabitParca, sayfaAdet);
            var rapor = new AynisiniBulSayfa1();
            rapor.Parameters["copyright"].Value =
                "www.cingöz.com - BGDG - Telif Hakları Sebahattin Dilaver'e Aittir. - (0312) 425 16  ResimBoyut - © 30 Ağustos 2017 - BGDG";
            rapor.Parameters["baslik"].Value = "AYNISINI BUL";
            rapor.Parameters["adSoyad"].Value = "Barış GÜNDÜZ";
            rapor.Parameters["dogumTarih"].Value = "..../..../........";//new DateTime(1998, 10, 15);
            rapor.Parameters["zorlukDerece"].Value = string.Format("{0} / {1}", zorulDerece, sabitParca);

            rapor.DataSource = test;
            rapor.FillDataSource();
            rapor.CreateDocument();
            var cevap = new CevapAnahtar();
            cevap.Parameters["baslik"].Value = "AYNISINI BUL";
            cevap.Parameters["adSoyad"].Value = "Barış GÜNDÜZ";
            cevap.Parameters["dogumTarih"].Value = "..../..../........";//new DateTime(1998, 10, 15);
            cevap.Parameters["zorlukDerece"].Value = string.Format("{0} / {1}", zorulDerece, sabitParca);

            cevap.DataSource = test;
            cevap.FillDataSource();
            cevap.CreateDocument();

            foreach (Page cevapPage in cevap.Pages)
            {
                rapor.Pages.Add(cevapPage);
            }

            var printTool = new ReportPrintTool(rapor);
            printTool.ShowPreviewDialog();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            var havuz = HavuzCreater.GetYeniTipHavuz(@"C:\Users\admin\Desktop\Zorusor\Yüz1");

            var zorulDerece = 8;
            var sabitParca = 2;
            var sayfaAdet = 10;
            var test = new Donusum12Test(havuz, zorulDerece, sabitParca, sayfaAdet);
            var rapor = new DonusumSayfa1();
            rapor.Parameters["copyright"].Value =
                "www.cingöz.com - BGDG - Telif Hakları Sebahattin Dilaver'e Aittir. - (0312) 425 16  ResimBoyut - © 30 Ağustos 2017 - BGDG";
            rapor.Parameters["baslik"].Value = "DÖNÜŞÜMLERİ BUL";
            rapor.Parameters["adSoyad"].Value = "Barış GÜNDÜZ";
            rapor.Parameters["dogumTarih"].Value = "..../..../........";//new DateTime(1998, 10, 15);
            rapor.Parameters["zorlukDerece"].Value = string.Format("{0} / {1}", zorulDerece, sabitParca);

            rapor.DataSource = test;
            rapor.FillDataSource();
            rapor.CreateDocument();
            var cevap = new CevapAnahtar();
            cevap.Parameters["baslik"].Value = "DÖNÜŞÜMLERİ BUL";
            cevap.Parameters["adSoyad"].Value = "Barış GÜNDÜZ";
            cevap.Parameters["dogumTarih"].Value = "..../..../........";//new DateTime(1998, 10, 15);
            cevap.Parameters["zorlukDerece"].Value = string.Format("{0} / {1}", zorulDerece, sabitParca);

            cevap.DataSource = test;
            cevap.FillDataSource();
            cevap.CreateDocument();

            foreach (Page cevapPage in cevap.Pages)
            {
                rapor.Pages.Add(cevapPage);
            }

            var printTool = new ReportPrintTool(rapor);
            printTool.ShowPreviewDialog();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            var havuz = HavuzCreater.GetYeniTipHavuz(@"C:\Users\admin\Desktop\Zorusor\Yüz1");

            var zorulDerece = 8;
            var sabitParca = 2;
            var sayfaAdet = 10;
            var test = new Donusum21Test(havuz, zorulDerece, sabitParca, sayfaAdet);
            var rapor = new DonusumSayfa2();
            rapor.Parameters["copyright"].Value =
                "www.cingöz.com - BGDG - Telif Hakları Sebahattin Dilaver'e Aittir. - (0312) 425 16  ResimBoyut - © 30 Ağustos 2017 - BGDG";
            rapor.Parameters["baslik"].Value = "DÖNÜŞMÜŞ RESMİ BUL";
            rapor.Parameters["adSoyad"].Value = "Barış GÜNDÜZ";
            rapor.Parameters["dogumTarih"].Value = "..../..../........";//new DateTime(1998, 10, 15);
            rapor.Parameters["zorlukDerece"].Value = string.Format("{0} / {1}", zorulDerece, sabitParca);

            rapor.DataSource = test;
            rapor.FillDataSource();
            rapor.CreateDocument();
            var cevap = new CevapAnahtar();
            cevap.Parameters["baslik"].Value = "DÖNÜŞMÜŞ RESMİ BUL";
            cevap.Parameters["adSoyad"].Value = "Barış GÜNDÜZ";
            cevap.Parameters["dogumTarih"].Value = "..../..../........";//new DateTime(1998, 10, 15);
            cevap.Parameters["zorlukDerece"].Value = string.Format("{0} / {1}", zorulDerece, sabitParca);

            cevap.DataSource = test;
            cevap.FillDataSource();
            cevap.CreateDocument();

            foreach (Page cevapPage in cevap.Pages)
            {
                rapor.Pages.Add(cevapPage);
            }

            var printTool = new ReportPrintTool(rapor);
            printTool.ShowPreviewDialog();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            var havuz = HavuzCreater.GetYeniTipHavuz(@"C:\Users\admin\Desktop\Zorusor\Yüz1");

            var zorulDerece = 8;
            var sabitParca = 2;
            var sayfaAdet = 10;
            var test = new Donusum31Test(havuz, zorulDerece, sabitParca, sayfaAdet);
            var rapor = new DonusumSayfa3();
            rapor.Parameters["copyright"].Value =
                "www.cingöz.com - BGDG - Telif Hakları Sebahattin Dilaver'e Aittir. - (0312) 425 16  ResimBoyut - © 30 Ağustos 2017 - BGDG";
            rapor.Parameters["baslik"].Value = "DOĞRU DÖNÜŞÜMÜ BUL";
            rapor.Parameters["adSoyad"].Value = "Barış GÜNDÜZ";
            rapor.Parameters["dogumTarih"].Value = "..../..../........";//new DateTime(1998, 10, 15);
            rapor.Parameters["zorlukDerece"].Value = string.Format("{0} / {1}", zorulDerece, sabitParca);

            rapor.DataSource = test;
            rapor.FillDataSource();
            rapor.CreateDocument();
            var cevap = new CevapAnahtar();
            cevap.Parameters["baslik"].Value = "DOĞRU DÖNÜŞÜMÜ BUL";
            cevap.Parameters["adSoyad"].Value = "Barış GÜNDÜZ";
            cevap.Parameters["dogumTarih"].Value = "..../..../........";//new DateTime(1998, 10, 15);
            cevap.Parameters["zorlukDerece"].Value = string.Format("{0} / {1}", zorulDerece, sabitParca);

            cevap.DataSource = test;
            cevap.FillDataSource();
            cevap.CreateDocument();

            foreach (Page cevapPage in cevap.Pages)
            {
                rapor.Pages.Add(cevapPage);
            }

            var printTool = new ReportPrintTool(rapor);
            printTool.ShowPreviewDialog();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            var havuz = HavuzCreater.GetYeniTipHavuz(@"C:\Users\admin\Desktop\Zorusor\Yüz1");

            var zorulDerece = 8;
            var sabitParca = 2;
            var sayfaAdet = 10;
            var test = new AnalojiIkili1Test1(havuz, zorulDerece, sabitParca, sayfaAdet);
            var rapor = new AnalojiSayfa1();
            rapor.Parameters["copyright"].Value =
                "www.cingöz.com - BGDG - Telif Hakları Sebahattin Dilaver'e Aittir. - (0312) 425 16  ResimBoyut - © 30 Ağustos 2017 - BGDG";
            rapor.Parameters["baslik"].Value = "ANALOJİYİ BUL";
            rapor.Parameters["adSoyad"].Value = "Barış GÜNDÜZ";
            rapor.Parameters["dogumTarih"].Value = "..../..../........";//new DateTime(1998, 10, 15);
            rapor.Parameters["zorlukDerece"].Value = string.Format("{0} / {1}", zorulDerece, sabitParca);

            rapor.DataSource = test;
            rapor.FillDataSource();
            rapor.CreateDocument();
            var cevap = new CevapAnahtar();
            cevap.Parameters["baslik"].Value = "ANALOJİ BUL";
            cevap.Parameters["adSoyad"].Value = "Barış GÜNDÜZ";
            cevap.Parameters["dogumTarih"].Value = "..../..../........";//new DateTime(1998, 10, 15);
            cevap.Parameters["zorlukDerece"].Value = string.Format("{0} / {1}", zorulDerece, sabitParca);

            cevap.DataSource = test;
            cevap.FillDataSource();
            cevap.CreateDocument();

            foreach (Page cevapPage in cevap.Pages)
            {
                rapor.Pages.Add(cevapPage);
            }

            var printTool = new ReportPrintTool(rapor);
            printTool.ShowPreviewDialog();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            var havuz = HavuzCreater.GetYeniTipHavuz(@"C:\Users\admin\Desktop\Zorusor\Yüz1");

            var zorulDerece = 8;
            var sabitParca = 2;
            var sayfaAdet = 10;
            var test = new KurBulUy11Test(havuz, zorulDerece, sabitParca, sayfaAdet);
            var rapor = new KuraliBulSayfa1();
            rapor.Parameters["copyright"].Value =
                "www.cingöz.com - BGDG - Telif Hakları Sebahattin Dilaver'e Aittir. - (0312) 425 16  ResimBoyut - © 30 Ağustos 2017 - BGDG";
            rapor.Parameters["baslik"].Value = "KURALI BULUP UYGULA";
            rapor.Parameters["adSoyad"].Value = "Barış GÜNDÜZ";
            rapor.Parameters["dogumTarih"].Value = "..../..../........";//new DateTime(1998, 10, 15);
            rapor.Parameters["zorlukDerece"].Value = string.Format("{0} / {1}", zorulDerece, sabitParca);

            rapor.DataSource = test;
            rapor.FillDataSource();
            rapor.CreateDocument();
            var cevap = new CevapAnahtar();
            cevap.Parameters["baslik"].Value = "KURALI BULUP UYGULA";
            cevap.Parameters["adSoyad"].Value = "Barış GÜNDÜZ";
            cevap.Parameters["dogumTarih"].Value = "..../..../........";//new DateTime(1998, 10, 15);
            cevap.Parameters["zorlukDerece"].Value = string.Format("{0} / {1}", zorulDerece, sabitParca);

            cevap.DataSource = test;
            cevap.FillDataSource();
            cevap.CreateDocument();

            foreach (Page cevapPage in cevap.Pages)
            {
                rapor.Pages.Add(cevapPage);
            }

            var printTool = new ReportPrintTool(rapor);
            printTool.ShowPreviewDialog();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            var havuz = HavuzCreater.GetYeniTipHavuz(@"C:\Users\admin\Desktop\Zorusor\Yüz1");

            var zorulDerece = 8;
            var sabitParca = 2;
            var sayfaAdet = 10;
            var test = new Kavram1Test(havuz, zorulDerece, sabitParca, sayfaAdet);
            var rapor = new KavramSayfa1();
            rapor.Parameters["copyright"].Value =
                "www.cingöz.com - BGDG - Telif Hakları Sebahattin Dilaver'e Aittir. - (0312) 425 16  ResimBoyut - © 30 Ağustos 2017 - BGDG";
            rapor.Parameters["baslik"].Value = "KAVRAM OLUŞTURMA TESTİ";
            rapor.Parameters["adSoyad"].Value = "Barış GÜNDÜZ";
            rapor.Parameters["dogumTarih"].Value = "..../..../........";//new DateTime(1998, 10, 15);
            rapor.Parameters["zorlukDerece"].Value = string.Format("{0} / {1}", zorulDerece, sabitParca);

            rapor.DataSource = test;
            rapor.FillDataSource();
            rapor.CreateDocument();
            var cevap = new CevapAnahtar();
            cevap.Parameters["baslik"].Value = "KAVRAM OLUŞTURMA TESTİ";
            cevap.Parameters["adSoyad"].Value = "Barış GÜNDÜZ";
            cevap.Parameters["dogumTarih"].Value = "..../..../........";//new DateTime(1998, 10, 15);
            cevap.Parameters["zorlukDerece"].Value = string.Format("{0} / {1}", zorulDerece, sabitParca);

            cevap.DataSource = test;
            cevap.FillDataSource();
            cevap.CreateDocument();

            foreach (Page cevapPage in cevap.Pages)
            {
                rapor.Pages.Add(cevapPage);
            }

            var printTool = new ReportPrintTool(rapor);
            printTool.ShowPreviewDialog();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            var havuz = HavuzCreater.GetYeniTipHavuz(@"C:\Users\admin\Desktop\Zorusor\Yüz1");

            var zorulDerece = 8;
            var sabitParca = 2;
            var sayfaAdet = 10;
            var test = new SinifBesli1Test(havuz, zorulDerece, sabitParca, sayfaAdet);
            var rapor = new SiniflandirSayfa1();
            rapor.Parameters["copyright"].Value =
                "www.cingöz.com - BGDG - Telif Hakları Sebahattin Dilaver'e Aittir. - (0312) 425 16  ResimBoyut - © 30 Ağustos 2017 - BGDG";
            rapor.Parameters["baslik"].Value = "SINIFLANDIRMA TESTİ";
            rapor.Parameters["adSoyad"].Value = "Barış GÜNDÜZ";
            rapor.Parameters["dogumTarih"].Value = "..../..../........";//new DateTime(1998, 10, 15);
            rapor.Parameters["zorlukDerece"].Value = string.Format("{0} / {1}", zorulDerece, sabitParca);

            rapor.DataSource = test;
            rapor.FillDataSource();
            rapor.CreateDocument();
            var cevap = new CevapAnahtar();
            cevap.Parameters["baslik"].Value = "SINIFLANDIRMA TESTİ";
            cevap.Parameters["adSoyad"].Value = "Barış GÜNDÜZ";
            cevap.Parameters["dogumTarih"].Value = "..../..../........";//new DateTime(1998, 10, 15);
            cevap.Parameters["zorlukDerece"].Value = string.Format("{0} / {1}", zorulDerece, sabitParca);

            cevap.DataSource = test;
            cevap.FillDataSource();
            cevap.CreateDocument();

            foreach (Page cevapPage in cevap.Pages)
            {
                rapor.Pages.Add(cevapPage);
            }

            var printTool = new ReportPrintTool(rapor);
            printTool.ShowPreviewDialog();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            var havuz = HavuzCreater.GetYeniTipHavuz(@"C:\Users\admin\Desktop\Zorusor\Yüz1");

            var zorulDerece = 8;
            var sabitParca = 2;
            var sayfaAdet = 10;
            var test = new SinifAltili1Test(havuz, zorulDerece, sabitParca, sayfaAdet);
            var rapor = new SiniflandirSayfa2();
            rapor.Parameters["copyright"].Value =
                "www.cingöz.com - BGDG - Telif Hakları Sebahattin Dilaver'e Aittir. - (0312) 425 16  ResimBoyut - © 30 Ağustos 2017 - BGDG";
            rapor.Parameters["baslik"].Value = "SINIFLANDIRMA TESTİ";
            rapor.Parameters["adSoyad"].Value = "Barış GÜNDÜZ";
            rapor.Parameters["dogumTarih"].Value = "..../..../........";//new DateTime(1998, 10, 15);
            rapor.Parameters["zorlukDerece"].Value = string.Format("{0} / {1}", zorulDerece, sabitParca);

            rapor.DataSource = test;
            rapor.FillDataSource();
            rapor.CreateDocument();
            var cevap = new CevapAnahtar();
            cevap.Parameters["baslik"].Value = "SINIFLANDIRMA TESTİ";
            cevap.Parameters["adSoyad"].Value = "Barış GÜNDÜZ";
            cevap.Parameters["dogumTarih"].Value = "..../..../........";//new DateTime(1998, 10, 15);
            cevap.Parameters["zorlukDerece"].Value = string.Format("{0} / {1}", zorulDerece, sabitParca);

            cevap.DataSource = test;
            cevap.FillDataSource();
            cevap.CreateDocument();

            foreach (Page cevapPage in cevap.Pages)
            {
                rapor.Pages.Add(cevapPage);
            }

            var printTool = new ReportPrintTool(rapor);
            printTool.ShowPreviewDialog();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            var havuz = HavuzCreater.GetYeniTipHavuz(@"C:\Users\admin\Desktop\Zorusor\Yüz1");

            var zorulDerece = 8;
            var sabitParca = 2;
            var sayfaAdet = 10;
            var test = new SinifYedili1Test(havuz, zorulDerece, sabitParca, sayfaAdet);
            var rapor = new SiniflandirSayfa3();
            rapor.Parameters["copyright"].Value =
                "www.cingöz.com - BGDG - Telif Hakları Sebahattin Dilaver'e Aittir. - (0312) 425 16  ResimBoyut - © 30 Ağustos 2017 - BGDG";
            rapor.Parameters["baslik"].Value = "SINIFLANDIRMA TESTİ";
            rapor.Parameters["adSoyad"].Value = "Barış GÜNDÜZ";
            rapor.Parameters["dogumTarih"].Value = "..../..../........";//new DateTime(1998, 10, 15);
            rapor.Parameters["zorlukDerece"].Value = string.Format("{0} / {1}", zorulDerece, sabitParca);

            rapor.DataSource = test;
            rapor.FillDataSource();
            rapor.CreateDocument();
            var cevap = new CevapAnahtar();
            cevap.Parameters["baslik"].Value = "SINIFLANDIRMA TESTİ";
            cevap.Parameters["adSoyad"].Value = "Barış GÜNDÜZ";
            cevap.Parameters["dogumTarih"].Value = "..../..../........";//new DateTime(1998, 10, 15);
            cevap.Parameters["zorlukDerece"].Value = string.Format("{0} / {1}", zorulDerece, sabitParca);

            cevap.DataSource = test;
            cevap.FillDataSource();
            cevap.CreateDocument();

            foreach (Page cevapPage in cevap.Pages)
            {
                rapor.Pages.Add(cevapPage);
            }

            var printTool = new ReportPrintTool(rapor);
            printTool.ShowPreviewDialog();
        }

        private void button26_Click(object sender, EventArgs e)
        {
            var havuz = HavuzCreater.GetYeniTipHavuz(@"C:\Users\admin\Desktop\Zorusor\Yüz1");

            var zorulDerece = 8;
            var sabitParca = 2;
            var sayfaAdet = 10;
            var test = new SinifBesli2Test(havuz, zorulDerece, sabitParca, sayfaAdet);
            var rapor = new SiniflandirSayfa1();
            rapor.Parameters["copyright"].Value =
                "www.cingöz.com - BGDG - Telif Hakları Sebahattin Dilaver'e Aittir. - (0312) 425 16  ResimBoyut - © 30 Ağustos 2017 - BGDG";
            rapor.Parameters["baslik"].Value = "SINIFLANDIRMA TESTİ";
            rapor.Parameters["adSoyad"].Value = "Barış GÜNDÜZ";
            rapor.Parameters["dogumTarih"].Value = "..../..../........";//new DateTime(1998, 10, 15);
            rapor.Parameters["zorlukDerece"].Value = string.Format("{0} / {1}", zorulDerece, sabitParca);

            rapor.DataSource = test;
            rapor.FillDataSource();
            rapor.CreateDocument();
            var cevap = new CevapAnahtar();
            cevap.Parameters["baslik"].Value = "SINIFLANDIRMA TESTİ";
            cevap.Parameters["adSoyad"].Value = "Barış GÜNDÜZ";
            cevap.Parameters["dogumTarih"].Value = "..../..../........";//new DateTime(1998, 10, 15);
            cevap.Parameters["zorlukDerece"].Value = string.Format("{0} / {1}", zorulDerece, sabitParca);

            cevap.DataSource = test;
            cevap.FillDataSource();
            cevap.CreateDocument();

            foreach (Page cevapPage in cevap.Pages)
            {
                rapor.Pages.Add(cevapPage);
            }

            var printTool = new ReportPrintTool(rapor);
            printTool.ShowPreviewDialog();
        }

        private void button27_Click(object sender, EventArgs e)
        {
            var havuz = HavuzCreater.GetYeniTipHavuz(@"C:\Users\admin\Desktop\Zorusor\Yüz1");

            var zorulDerece = 8;
            var sabitParca = 2;
            var sayfaAdet = 10;
            var test = new SinifAltili2Test(havuz, zorulDerece, sabitParca, sayfaAdet);
            var rapor = new SiniflandirSayfa2();
            rapor.Parameters["copyright"].Value =
                "www.cingöz.com - BGDG - Telif Hakları Sebahattin Dilaver'e Aittir. - (0312) 425 16  ResimBoyut - © 30 Ağustos 2017 - BGDG";
            rapor.Parameters["baslik"].Value = "SINIFLANDIRMA TESTİ";
            rapor.Parameters["adSoyad"].Value = "Barış GÜNDÜZ";
            rapor.Parameters["dogumTarih"].Value = "..../..../........";//new DateTime(1998, 10, 15);
            rapor.Parameters["zorlukDerece"].Value = string.Format("{0} / {1}", zorulDerece, sabitParca);

            rapor.DataSource = test;
            rapor.FillDataSource();
            rapor.CreateDocument();
            var cevap = new CevapAnahtar();
            cevap.Parameters["baslik"].Value = "SINIFLANDIRMA TESTİ";
            cevap.Parameters["adSoyad"].Value = "Barış GÜNDÜZ";
            cevap.Parameters["dogumTarih"].Value = "..../..../........";//new DateTime(1998, 10, 15);
            cevap.Parameters["zorlukDerece"].Value = string.Format("{0} / {1}", zorulDerece, sabitParca);

            cevap.DataSource = test;
            cevap.FillDataSource();
            cevap.CreateDocument();

            foreach (Page cevapPage in cevap.Pages)
            {
                rapor.Pages.Add(cevapPage);
            }

            var printTool = new ReportPrintTool(rapor);
            printTool.ShowPreviewDialog();
        }

        private void button28_Click(object sender, EventArgs e)
        {
            var havuz = HavuzCreater.GetYeniTipHavuz(@"C:\Users\admin\Desktop\Zorusor\Yüz1");

            var zorulDerece = 8;
            var sabitParca = 2;
            var sayfaAdet = 10;
            var test = new SinifYedili2Test(havuz, zorulDerece, sabitParca, sayfaAdet);
            var rapor = new SiniflandirSayfa3();
            rapor.Parameters["copyright"].Value =
                "www.cingöz.com - BGDG - Telif Hakları Sebahattin Dilaver'e Aittir. - (0312) 425 16  ResimBoyut - © 30 Ağustos 2017 - BGDG";
            rapor.Parameters["baslik"].Value = "SINIFLANDIRMA TESTİ";
            rapor.Parameters["adSoyad"].Value = "Barış GÜNDÜZ";
            rapor.Parameters["dogumTarih"].Value = "..../..../........";//new DateTime(1998, 10, 15);
            rapor.Parameters["zorlukDerece"].Value = string.Format("{0} / {1}", zorulDerece, sabitParca);

            rapor.DataSource = test;
            rapor.FillDataSource();
            rapor.CreateDocument();
            var cevap = new CevapAnahtar();
            cevap.Parameters["baslik"].Value = "SINIFLANDIRMA TESTİ";
            cevap.Parameters["adSoyad"].Value = "Barış GÜNDÜZ";
            cevap.Parameters["dogumTarih"].Value = "..../..../........";//new DateTime(1998, 10, 15);
            cevap.Parameters["zorlukDerece"].Value = string.Format("{0} / {1}", zorulDerece, sabitParca);

            cevap.DataSource = test;
            cevap.FillDataSource();
            cevap.CreateDocument();

            foreach (Page cevapPage in cevap.Pages)
            {
                rapor.Pages.Add(cevapPage);
            }

            var printTool = new ReportPrintTool(rapor);
            printTool.ShowPreviewDialog();
        }

        private void button29_Click(object sender, EventArgs e)
        {
            var havuz = HavuzCreater.GetYeniTipHavuz(@"C:\Users\admin\Desktop\Zorusor\Yüz1");

            var zorulDerece = 8;
            var sabitParca = 2;
            var sayfaAdet = 10;
            var test = new CakistirmaDogru1Test(havuz, zorulDerece, sabitParca, sayfaAdet);
            var rapor = new CakistirDogruSayfa1();
            rapor.Parameters["copyright"].Value =
                "www.cingöz.com - BGDG - Telif Hakları Sebahattin Dilaver'e Aittir. - (0312) 425 16  ResimBoyut - © 30 Ağustos 2017 - BGDG";
            rapor.Parameters["baslik"].Value = "ÇAKIŞTIRIP DOĞRUYU BUL";
            rapor.Parameters["adSoyad"].Value = "Barış GÜNDÜZ";
            rapor.Parameters["dogumTarih"].Value = "..../..../........";//new DateTime(1998, 10, 15);
            rapor.Parameters["zorlukDerece"].Value = string.Format("{0} / {1}", zorulDerece, sabitParca);

            rapor.DataSource = test;
            rapor.FillDataSource();
            rapor.CreateDocument();
            var cevap = new CevapAnahtar();
            cevap.Parameters["baslik"].Value = "ÇAKIŞTIRIP DOĞRUYU BUL";
            cevap.Parameters["adSoyad"].Value = "Barış GÜNDÜZ";
            cevap.Parameters["dogumTarih"].Value = "..../..../........";//new DateTime(1998, 10, 15);
            cevap.Parameters["zorlukDerece"].Value = string.Format("{0} / {1}", zorulDerece, sabitParca);

            cevap.DataSource = test;
            cevap.FillDataSource();
            cevap.CreateDocument();

            foreach (Page cevapPage in cevap.Pages)
            {
                rapor.Pages.Add(cevapPage);
            }

            var printTool = new ReportPrintTool(rapor);
            printTool.ShowPreviewDialog();
        }

        private void button30_Click(object sender, EventArgs e)
        {
            var havuz = HavuzCreater.GetYeniTipHavuz(@"C:\Users\admin\Desktop\Zorusor\Yüz1");

            var zorulDerece = 8;
            var sabitParca = 2;
            var sayfaAdet = 10;
            var test = new CakistirmaYanlis1Test(havuz, zorulDerece, sabitParca, sayfaAdet);
            var rapor = new CakistirDogruSayfa1();
            rapor.Parameters["copyright"].Value =
                "www.cingöz.com - BGDG - Telif Hakları Sebahattin Dilaver'e Aittir. - (0312) 425 16  ResimBoyut - © 30 Ağustos 2017 - BGDG";
            rapor.Parameters["baslik"].Value = "ÇAKIŞTIRIP YANLIŞI BUL";
            rapor.Parameters["adSoyad"].Value = "Barış GÜNDÜZ";
            rapor.Parameters["dogumTarih"].Value = "..../..../........";//new DateTime(1998, 10, 15);
            rapor.Parameters["zorlukDerece"].Value = string.Format("{0} / {1}", zorulDerece, sabitParca);

            rapor.DataSource = test;
            rapor.FillDataSource();
            rapor.CreateDocument();
            var cevap = new CevapAnahtar();
            cevap.Parameters["baslik"].Value = "ÇAKIŞTIRIP YANLIŞI BUL";
            cevap.Parameters["adSoyad"].Value = "Barış GÜNDÜZ";
            cevap.Parameters["dogumTarih"].Value = "..../..../........";//new DateTime(1998, 10, 15);
            cevap.Parameters["zorlukDerece"].Value = string.Format("{0} / {1}", zorulDerece, sabitParca);

            cevap.DataSource = test;
            cevap.FillDataSource();
            cevap.CreateDocument();

            foreach (Page cevapPage in cevap.Pages)
            {
                rapor.Pages.Add(cevapPage);
            }

            var printTool = new ReportPrintTool(rapor);
            printTool.ShowPreviewDialog();
        }

        private void button31_Click(object sender, EventArgs e)
        {
            var havuz = HavuzCreater.GetYeniTipHavuz(@"C:\Users\admin\Desktop\Zorusor\Yüz1");

            var zorulDerece = 8;
            var sabitParca = 2;
            var sayfaAdet = 10;
            var test = new ParcaButun1Test(havuz, zorulDerece, sabitParca, sayfaAdet);
            var rapor = new ParcaButunSayfa1();
            rapor.Parameters["copyright"].Value =
                "www.cingöz.com - BGDG - Telif Hakları Sebahattin Dilaver'e Aittir. - (0312) 425 16  ResimBoyut - © 30 Ağustos 2017 - BGDG";
            rapor.Parameters["baslik"].Value = "PARÇALARI BİRLEŞTİR";
            rapor.Parameters["adSoyad"].Value = "Barış GÜNDÜZ";
            rapor.Parameters["dogumTarih"].Value = "..../..../........";//new DateTime(1998, 10, 15);
            rapor.Parameters["zorlukDerece"].Value = string.Format("{0} / {1}", zorulDerece, sabitParca);

            rapor.DataSource = test;
            rapor.FillDataSource();
            rapor.CreateDocument();
            var cevap = new CevapAnahtar();
            cevap.Parameters["baslik"].Value = "PARÇALARI BİRLEŞTİR";
            cevap.Parameters["adSoyad"].Value = "Barış GÜNDÜZ";
            cevap.Parameters["dogumTarih"].Value = "..../..../........";//new DateTime(1998, 10, 15);
            cevap.Parameters["zorlukDerece"].Value = string.Format("{0} / {1}", zorulDerece, sabitParca);

            cevap.DataSource = test;
            cevap.FillDataSource();
            cevap.CreateDocument();

            foreach (Page cevapPage in cevap.Pages)
            {
                rapor.Pages.Add(cevapPage);
            }

            var printTool = new ReportPrintTool(rapor);
            printTool.ShowPreviewDialog();
        }

        private void button32_Click(object sender, EventArgs e)
        {
            var havuz = HavuzCreater.GetYeniTipHavuz(@"C:\Users\admin\Desktop\Zorusor\Yüz1");

            var zorulDerece = 8;
            var sabitParca = 2;
            var sayfaAdet = 10;
            var test = new ButunParca1Test(havuz, zorulDerece, sabitParca, sayfaAdet);
            var rapor = new ButunParcaSayfa1();
            rapor.Parameters["copyright"].Value =
                "www.cingöz.com - BGDG - Telif Hakları Sebahattin Dilaver'e Aittir. - (0312) 425 16  ResimBoyut - © 30 Ağustos 2017 - BGDG";
            rapor.Parameters["baslik"].Value = "PARÇALARA AYIR";
            rapor.Parameters["adSoyad"].Value = "Barış GÜNDÜZ";
            rapor.Parameters["dogumTarih"].Value = "..../..../........";//new DateTime(1998, 10, 15);
            rapor.Parameters["zorlukDerece"].Value = string.Format("{0} / {1}", zorulDerece, sabitParca);

            rapor.DataSource = test;
            rapor.FillDataSource();
            rapor.CreateDocument();
            var cevap = new CevapAnahtar();
            cevap.Parameters["baslik"].Value = "PARÇALARA AYIR";
            cevap.Parameters["adSoyad"].Value = "Barış GÜNDÜZ";
            cevap.Parameters["dogumTarih"].Value = "..../..../........";//new DateTime(1998, 10, 15);
            cevap.Parameters["zorlukDerece"].Value = string.Format("{0} / {1}", zorulDerece, sabitParca);

            cevap.DataSource = test;
            cevap.FillDataSource();
            cevap.CreateDocument();

            foreach (Page cevapPage in cevap.Pages)
            {
                rapor.Pages.Add(cevapPage);
            }

            var printTool = new ReportPrintTool(rapor);
            printTool.ShowPreviewDialog();
        }

        private void button33_Click(object sender, EventArgs e)
        {

            var havuz = HavuzCreater.GetYeniTipHavuz(@"C:\Users\admin\Desktop\Zorusor\Yüz1");

            var zorulDerece = 8;
            var sabitParca = 2;
            var sayfaAdet = 10;
            var test = new FarklisiniBulTest1(havuz, zorulDerece, sabitParca, sayfaAdet);
            var rapor = new AynisiniBulSayfa1();
            rapor.Parameters["copyright"].Value =
                "www.cingöz.com - BGDG - Telif Hakları Sebahattin Dilaver'e Aittir. - (0312) 425 16  ResimBoyut - © 30 Ağustos 2017 - BGDG";
            rapor.Parameters["baslik"].Value = "FARKLISINI BUL";
            rapor.Parameters["adSoyad"].Value = "Barış GÜNDÜZ";
            rapor.Parameters["dogumTarih"].Value = "..../..../........";//new DateTime(1998, 10, 15);
            rapor.Parameters["zorlukDerece"].Value = string.Format("{0} / {1}", zorulDerece, sabitParca);

            rapor.DataSource = test;
            rapor.FillDataSource();
            rapor.CreateDocument();
            var cevap = new CevapAnahtar();
            cevap.Parameters["baslik"].Value = "FARKLISINI BUL";
            cevap.Parameters["adSoyad"].Value = "Barış GÜNDÜZ";
            cevap.Parameters["dogumTarih"].Value = "..../..../........";//new DateTime(1998, 10, 15);
            cevap.Parameters["zorlukDerece"].Value = string.Format("{0} / {1}", zorulDerece, sabitParca);

            cevap.DataSource = test;
            cevap.FillDataSource();
            cevap.CreateDocument();

            foreach (Page cevapPage in cevap.Pages)
            {
                rapor.Pages.Add(cevapPage);
            }

            var printTool = new ReportPrintTool(rapor);
            printTool.ShowPreviewDialog();
        }

        private void button34_Click(object sender, EventArgs e)
        {
            new OrtakElemanFrm().Show(this);

        }

        private void button35_Click(object sender, EventArgs e)
        {
            new FarkliElemanFrm().Show(this);
        }

        private void button36_Click(object sender, EventArgs e)
        {
            new Melez1().Show(this);
        }

        private void button37_Click(object sender, EventArgs e)
        {
            new Melez2Frm().Show(this);
        }
    }
}
