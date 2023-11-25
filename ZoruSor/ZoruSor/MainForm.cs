using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using ZoruSor.Lib.Havuz;
using ZoruSor.Lib.Soru;
using ZoruSor.Lib.Test;
using ZoruSor.Lib.Test.SayiOyun;
using ZoruSor.Lib.TestSoru;
using ZoruSor.Reports;
using ZoruSor.Reports.Analoji;
using ZoruSor.Reports.EsEleman;
using ZoruSor.Reports.KuraliBul;
using ZoruSor.Reports.Matris;
using ZoruSor.Reports.Melez;
using ZoruSor.Reports.SayiOyunu;
using ZoruSor.Reports.Siniflandirma;
using ZoruSor.UserControls;

namespace ZoruSor
{
    public partial class MainForm : XtraForm
    {
        private readonly string _havuzDizin = ConfigurationManager.AppSettings["HavuzDizin"];
        private string _copyright = ConfigurationManager.AppSettings["Copyright"];
        public List<string> HavuzTemaList { get; set; }
        public List<string> HavuzList { get; set; }
        public Havuz SeciliHavuz { get; set; }
        private string _seciliHavuzTema;
        private string _seciliTest;
        private int _zorlukDerece;
        private int _sabitParcaAdet;
        private SayfaTip _seciliSayfaTip;
       
        public MainForm()
        {
            InitializeComponent();
            HavuzTemaList = new List<string>();
            DirectoryInfo fi = new DirectoryInfo(_havuzDizin);
            foreach (var info in fi.GetDirectories())
            {
                HavuzTemaList.Add(info.Name);
            }
            havuzTemaCombo.Properties.Items.AddRange(HavuzTemaList);
            copyrightEdit.EditValue = _copyright;
            sayiOyunCopyright.EditValue = _copyright;
            soruTipCombo.Properties.Items.AddRange(TestTip.List);
        }

        private bool TestValidate()
        {
            if (SeciliHavuz == null || _zorlukDerece <= 0 || _sabitParcaAdet < 0 ||
                sayfaAdetEdit.EditValue == null || _seciliSayfaTip == null)
            {
                XtraMessageBox.Show(this, "Lütfen değerleri kontrol ederek tekrar deneyiniz.", "Test hazırlama kontrolü");
                return false;
            }
            return true;
        }

        private void HavuzOnizlemeHazirla()
        {
            if (SeciliHavuz != null)
            {
                havuzPreview.Image = ResimHelper.RasgeleResimUret(SeciliHavuz, 350).Image;
                tabControl.SelectTab(0);
            }
        }
        
      
       

        private BaseSoruUi CreateSoruPreview(BaseSoru testSoru, int soruId)
        {
            switch (_seciliTest)
            {
                case "Analoji 1":
                    return new AnalojiUc(SeciliHavuz, _seciliTest, _zorlukDerece, _sabitParcaAdet, testSoru, soruId);
                case "Aynısını Bul":
                case "Tümü Farklı Eleman":
                case "Farklı Eleman":
                case "Farklısını Bul":
                case "Ortak Eleman":
                    return new AynisiniBulUc(SeciliHavuz, _seciliTest, _zorlukDerece, _sabitParcaAdet, testSoru, soruId);
                case "Bütünden Parçaya":
                    return new ButunParcaUc(SeciliHavuz, _seciliTest, _zorlukDerece, _sabitParcaAdet, testSoru, soruId);
                case "Çakıştırma Doğruyu Bul":
                    return new CakistirUc(SeciliHavuz, _seciliTest, _zorlukDerece, _sabitParcaAdet, testSoru, soruId);
                case "Çakıştırma Yanlışı Bul":
                    return new CakistirUc(SeciliHavuz, _seciliTest, _zorlukDerece, _sabitParcaAdet, testSoru, soruId);
                case "Dönüşüm 1":
                    return new Donusum1Uc(SeciliHavuz, _seciliTest, _zorlukDerece, _sabitParcaAdet, testSoru, soruId);
                case "Dönüşüm 2":
                    return new Donusum2Uc(SeciliHavuz, _seciliTest, _zorlukDerece, _sabitParcaAdet, testSoru, soruId);
                case "Dönüşüm 3":
                    return new Donusum3Uc(SeciliHavuz, _seciliTest, _zorlukDerece, _sabitParcaAdet, testSoru, soruId);
                case "Kavram Oluşturma":
                    return new KavramOlusturUc(SeciliHavuz, _seciliTest, _zorlukDerece, _sabitParcaAdet, testSoru, soruId);
                case "Kuralı Bul Uygula 1":
                case "Kuralı Bul Uygula 2":
                case "Kuralı Bul Uygula 3":
                case "Simetrik İlişkiler 1":
                case "Simetrik İlişkiler 2":
                case "Simetrik İlişkiler 3":
                    return new KurBulUygula1Uc(SeciliHavuz, _seciliTest, _zorlukDerece, _sabitParcaAdet, testSoru, soruId);
                case "Melez İkili":
                    return new MelezUc(SeciliHavuz, _seciliTest, _zorlukDerece, _sabitParcaAdet, testSoru, soruId,
                        resim1Formul.EditValue.ToString(), resim2Formul.EditValue.ToString(), resim3Formul.EditValue.ToString(),
                        resim4Formul.EditValue.ToString());
                case "Melez Üçlü":
                    return new MelezUc(SeciliHavuz, _seciliTest, _zorlukDerece, _sabitParcaAdet, testSoru, soruId,
                        resim1Formul.EditValue.ToString(), resim2Formul.EditValue.ToString(), resim3Formul.EditValue.ToString(),
                        resim4Formul.EditValue.ToString());
                case "Melez Dörtlü":
                    return new MelezUc(SeciliHavuz, _seciliTest, _zorlukDerece, _sabitParcaAdet, testSoru, soruId,
                        resim1Formul.EditValue.ToString(), resim2Formul.EditValue.ToString(), resim3Formul.EditValue.ToString(),
                        resim4Formul.EditValue.ToString());
                case "Parçadan Bütüne":
                    return new ParcaButunUc(SeciliHavuz, _seciliTest, _zorlukDerece, _sabitParcaAdet, testSoru, soruId);
                case "Sınıflandırma 1":
                case "Sınıflandırma 2":
                case "Sınıflandırma 3":
                case "Sınıflandırma 6 lı 1":
                case "Sınıflandırma 6 lı 2":
                case "Sınıflandırma 6 lı 3":
                case "Sınıflandırma 7 li 1":
                case "Sınıflandırma 7 li 2":
                case "Sınıflandırma 7 li 3":
                    return new SiniflandirUc(SeciliHavuz, _seciliTest, _zorlukDerece, _sabitParcaAdet, testSoru, soruId);


            }
            return null;
        }

        private void CreateTestPages()
        {
            _seciliSayfaTip.SayfaTemplate.CustomResim = ResimHelper.CustomImageResmiUret();
            _seciliSayfaTip.SayfaTemplate.LogoResim = ResimHelper.LogoResmiUret();
            _seciliSayfaTip.SayfaTemplate.LogoAyarla();
            _seciliSayfaTip.SayfaTemplate.CustomResimAyarla();
            _seciliSayfaTip.SayfaTemplate.Parameters["copyright"].Value = _copyright;
            _seciliSayfaTip.SayfaTemplate.Parameters["baslik"].Value = baslikEdit.EditValue.ToString();
            _seciliSayfaTip.SayfaTemplate.Parameters["adSoyad"].Value = adSoyadEdit.EditValue?.ToString() ?? "";
            _seciliSayfaTip.SayfaTemplate.Parameters["dogumTarih"].Value = dogumTarihEdit.EditValue?.ToString() ?? "";
            _seciliSayfaTip.SayfaTemplate.Parameters["zorlukDerece"].Value = $"{_zorlukDerece} / {_sabitParcaAdet}";

            _seciliSayfaTip.SayfaTemplate.DataSource = _seciliSayfaTip.Test;
            _seciliSayfaTip.SayfaTemplate.FillDataSource();
            _seciliSayfaTip.SayfaTemplate.CreateDocument();

            var cevap = new CevapAnahtar();
            cevap.CustomResim = ResimHelper.CustomImageResmiUret();
            cevap.LogoResim = ResimHelper.LogoResmiUret();
            cevap.LogoAyarla();
            cevap.CustomResimAyarla();
            cevap.Parameters["baslik"].Value = baslikEdit.EditValue.ToString();
            cevap.Parameters["adSoyad"].Value = adSoyadEdit.EditValue?.ToString() ?? "";
            cevap.Parameters["dogumTarih"].Value = dogumTarihEdit.EditValue?.ToString() ?? "";
            cevap.Parameters["zorlukDerece"].Value = $"{_zorlukDerece} / {_sabitParcaAdet}";

            cevap.DataSource = _seciliSayfaTip.Test;
            cevap.FillDataSource();
            cevap.CreateDocument();

            foreach (Page cevapPage in cevap.Pages)
            {
                _seciliSayfaTip.SayfaTemplate.Pages.Add(cevapPage);
            }

            var printTool = new ReportPrintTool(_seciliSayfaTip.SayfaTemplate);
            printTool.ShowPreviewDialog();
        }

        private void ClearResults()
        {
            soruLayoutPanel.Controls.Clear();
            tabControl.SelectTab(0);
        }

        private void havuzTemaCombo_SelectedIndexChanged(object sender, EventArgs e)
        {

            havuzCombo.Properties.Items.Clear();
            SeciliHavuz = null;

            if (sender.GetType() == typeof(ComboBoxEdit))
            {
                var combo = (ComboBoxEdit)sender;
                if (combo.SelectedItem != null)
                {
                    _seciliHavuzTema = combo.SelectedItem.ToString();

                    havuzCombo.Enabled = true;
                    HavuzList = new List<string>();

                    DirectoryInfo fi = new DirectoryInfo(_havuzDizin + _seciliHavuzTema);
                    foreach (var info in fi.GetDirectories())
                    {
                        HavuzList.Add(info.Name);
                    }
                    havuzCombo.Properties.Items.AddRange(HavuzList);
                }
                else
                {
                    SeciliHavuz = null;
                    havuzCombo.Enabled = false;
                }

            }
            havuzCombo.SelectedItem = null;
            ClearResults();
        }

        private void havuzCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            GC.Collect();
            if (sender.GetType() == typeof(ComboBoxEdit))
            {
                var combo = (ComboBoxEdit)sender;
                //Secili havuz adiyla havuz objesi olustur.
                SeciliHavuz = HavuzCreater.GetYeniTipHavuz($"{_havuzDizin}{_seciliHavuzTema}\\{combo.SelectedItem}");
                HavuzOnizlemeHazirla();

                zorlukCombo.Properties.Items.Clear();
                //Secili Havuz' un parca sayisi kadar Zorluk derecesi olustur.
                for (int i = 0; i < SeciliHavuz.ParcaList.Count; i++)
                {
                    //Zorluk seviyelerini comboya doldur.
                    zorlukCombo.Properties.Items.Add(i + 1);
                }

                //Soru tipi combosunu aktif yap
                soruTipCombo.Enabled = true;
                soruTipCombo.SelectedItem = null;
                ClearResults();
                GC.Collect();

            }
        }

        private void soruTipCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(ComboBoxEdit))
            {
                var combo = (ComboBoxEdit)sender;
                if (combo.SelectedItem != null)
                {
                    _seciliTest = combo.SelectedItem.ToString();
                    resim1Formul.EditValue = "A";
                    resim2Formul.EditValue = "A+B";
                    resim3Formul.EditValue = "A+B+C";
                    resim4Formul.EditValue = "A+B+C+D";
                    switch (_seciliTest)
                    {
                        case "Melez İkili":
                            resim1Formul.Visible = true;
                            resim1FormulLbl.Visible = true;
                            resim2Formul.Visible = true;
                            resim2FormulLbl.Visible = true;
                            resim3Formul.Visible = false;
                            resim3FormulLbl.Visible = false;
                            resim4Formul.Visible = false;
                            resim4FormulLbl.Visible = false;
                            break;
                        case "Melez Üçlü":
                            resim1Formul.Visible = true;
                            resim1FormulLbl.Visible = true;
                            resim2Formul.Visible = true;
                            resim2FormulLbl.Visible = true;
                            resim3Formul.Visible = true;
                            resim3FormulLbl.Visible = true;
                            resim4Formul.Visible = false;
                            resim4FormulLbl.Visible = false;
                            break;
                        case "Melez Dörtlü":
                            resim1Formul.Visible = true;
                            resim1FormulLbl.Visible = true;
                            resim2Formul.Visible = true;
                            resim2FormulLbl.Visible = true;
                            resim3Formul.Visible = true;
                            resim3FormulLbl.Visible = true;
                            resim4Formul.Visible = true;
                            resim4FormulLbl.Visible = true;
                            break;
                        case "Para Oyunu 1":
                        case "Para Oyunu 5":
                            resim1Formul.EditValue = "x+y";
                            resim2Formul.EditValue = "y+z";
                            resim3Formul.EditValue = "z+p";
                            resim4Formul.EditValue = "p+r";
                            resim1Formul.Visible = true;
                            resim1FormulLbl.Visible = true;
                            resim2Formul.Visible = true;
                            resim2FormulLbl.Visible = true;
                            resim3Formul.Visible = true;
                            resim3FormulLbl.Visible = true;
                            resim4Formul.Visible = true;
                            resim4FormulLbl.Visible = true;
                            break;
                        default:
                            resim1Formul.Visible = false;
                            resim1FormulLbl.Visible = false;
                            resim2Formul.Visible = false;
                            resim2FormulLbl.Visible = false;
                            resim3Formul.Visible = false;
                            resim3FormulLbl.Visible = false;
                            resim4Formul.Visible = false;
                            resim4FormulLbl.Visible = false;
                            break;
                    }

                    var sayfaTipList = SoruSayfaTip.Items.Where(s => s.SoruTipList.Contains(_seciliTest)).ToList();
                    SayfaTipCombo.Enabled = true;
                    SayfaTipCombo.Properties.Items.Clear();
                    SayfaTipCombo.Properties.Items.AddRange(sayfaTipList);
                    SayfaTipCombo.EditValue = null;
                }
                else
                {
                    soruTipCombo.SelectedItem = null;
                    _seciliTest = null;
                }
                ClearResults();
            }
        }

        private void SayfaTipCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(ComboBoxEdit))
            {
                var combo = (ComboBoxEdit)sender;
                if (combo.SelectedItem != null)
                {
                    _seciliSayfaTip = (SayfaTip)combo.SelectedItem;
                    baslikEdit.EditValue = _seciliTest;
                    zorlukCombo.Enabled = true;
                }

                ClearResults();
            }
        }

        private void zorlukCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(ComboBoxEdit))
            {
                var combo = (ComboBoxEdit)sender;
                if (combo.SelectedItem != null)
                {
                    _zorlukDerece = (int)combo.SelectedItem;
                    sabitCombo.Properties.Items.Clear();
                    for (int i = 0; i < _zorlukDerece; i++)
                    {
                        sabitCombo.Properties.Items.Add(i);
                    }
                    sabitCombo.Enabled = true;
                }

                ClearResults();
            }
        }

        private void sabitCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(ComboBoxEdit))
            {
                var combo = (ComboBoxEdit)sender;
                if (combo.SelectedItem != null)
                {
                    _sabitParcaAdet = (int)combo.SelectedItem;
                }
                ClearResults();
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (TestValidate() == false)
                {
                    return;
                }


                if (_seciliSayfaTip.SayfaTemplate == null) return;
                ClearResults();

                _seciliSayfaTip.Test = new TestReportHelper().CreateTest(_seciliTest, _seciliSayfaTip, SeciliHavuz, _zorlukDerece, _sabitParcaAdet, Convert.ToInt32(sayfaAdetEdit.EditValue.ToString()), resim1Formul.EditValue.ToString(), resim2Formul.EditValue.ToString(), resim3Formul.EditValue.ToString(), resim4Formul.EditValue.ToString());
                CreateTestPages();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(LookAndFeel, "Hata oluştu: \n" + ex);
            }


        }

        private void copyrightEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(TextEdit))
            {
                var textEdit = (TextEdit)sender;
                ConfigurationManager.AppSettings["Copyright"] = textEdit.EditValue.ToString();
                _copyright = textEdit.EditValue?.ToString();
            }
        }

        private void soruUretButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (TestValidate() == false)
                {
                    return;
                }


                if (_seciliSayfaTip.SayfaTemplate == null) return;

                _seciliSayfaTip.Test = new TestReportHelper().CreateTest(_seciliTest, _seciliSayfaTip, SeciliHavuz, _zorlukDerece, 
                    _sabitParcaAdet, Convert.ToInt32(sayfaAdetEdit.EditValue.ToString()), resim1Formul.EditValue.ToString(), 
                    resim2Formul.EditValue.ToString(), resim3Formul.EditValue.ToString(), resim4Formul.EditValue.ToString());
                soruLayoutPanel.RowStyles.Clear();
                soruLayoutPanel.Controls.Clear();
                var sira = 0;
                foreach (var soru in _seciliSayfaTip.Test)
                {
                    var control = CreateSoruPreview(soru, sira);
                    control.Dock = DockStyle.Fill;

                    soruLayoutPanel.RowStyles.Add(new RowStyle() { SizeType = SizeType.Absolute, Height = control.Height });

                    soruLayoutPanel.Controls.Add(control, 0, sira);
                    sira++;
                }
                tabControl.SelectTab(1);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(LookAndFeel, "Hata oluştu: \n" + ex);

            }

        }

        private void soruListTestUret_Click(object sender, EventArgs e)
        {
            if (TestValidate() == false)
            {
                return;
            }


            if (_seciliSayfaTip.SayfaTemplate == null) return;

            if (_seciliSayfaTip.Test == null)
            {
                return;
            }
            var sira = 0;
            foreach (BaseSoruUi soruUiControl in soruLayoutPanel.Controls)
            {
                _seciliSayfaTip.Test.RemoveAt(sira);
                _seciliSayfaTip.Test.Insert(sira, soruUiControl.TestSoru);
                sira++;
            }

            CreateTestPages();
        }

        private void sayiOyunHazirlaBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (sayiOyunZorluk.SelectedItem == null || sayiOyunSatir1Formul.EditValue == null || sayiOyunSatir2Formul.EditValue == null ||
                sayiOyunSatir3Formul.EditValue == null || sayiOyunSatir4Formul.EditValue == null || sayiOyunSayfaAdet.EditValue == null ||
                sayiOyunIslem.EditValue == null)
                {
                    XtraMessageBox.Show(this, "Lütfen değerleri kontrol ederek tekrar deneyiniz.", "sayi Oyunu Test hazırlama kontrolü");
                    return;
                }

                _zorlukDerece = Convert.ToInt32(sayiOyunZorluk.SelectedItem);



                _seciliSayfaTip = new SayfaTip
                {
                    Ad = "Dokuz Seçenekli",
                    SoruTipList = new List<string> { "Sayi Oyunu" },
                    SayfaTemplate = new SayiOyunSayfa1()
                };

                var islemGorunsun = IslemGorunum.Bilinmiyor;
                switch (sayiOyunIslem.EditValue.ToString())
                {
                    case "Referans resimde görünsün":
                        islemGorunsun = IslemGorunum.ReferanstaGorunsun;
                        break;
                    case "Cevapta görünsün":
                        islemGorunsun = IslemGorunum.CevaptaGorunsun;
                        break;
                    case "Hayır":
                        islemGorunsun = IslemGorunum.Gorunmesin;
                        break;
                }


                _seciliSayfaTip.Test = new SayiOyunTest1(sayiOyunSatir1Formul.EditValue.ToString(),
                    sayiOyunSatir2Formul.EditValue.ToString(), sayiOyunSatir3Formul.EditValue.ToString(),
                    sayiOyunSatir4Formul.EditValue.ToString(), _zorlukDerece, Convert.ToInt32(sayiOyunSayfaAdet.EditValue), islemGorunsun);

                _seciliSayfaTip.SayfaTemplate.CustomResim = ResimHelper.CustomImageResmiUret();
                _seciliSayfaTip.SayfaTemplate.LogoResim = ResimHelper.LogoResmiUret();
                _seciliSayfaTip.SayfaTemplate.LogoAyarla();
                _seciliSayfaTip.SayfaTemplate.CustomResimAyarla();
                _seciliSayfaTip.SayfaTemplate.Parameters["copyright"].Value = sayiOyunCopyright.EditValue;
                _seciliSayfaTip.SayfaTemplate.Parameters["baslik"].Value = sayiOyunBaslik.EditValue;
                _seciliSayfaTip.SayfaTemplate.Parameters["adSoyad"].Value = sayiOyunAdSoyad.EditValue?.ToString() ?? "";
                _seciliSayfaTip.SayfaTemplate.Parameters["dogumTarih"].Value = sayiOyunDogumTarih.EditValue?.ToString() ?? "";
                _seciliSayfaTip.SayfaTemplate.Parameters["zorlukDerece"].Value = $"{_zorlukDerece}";

                _seciliSayfaTip.SayfaTemplate.DataSource = _seciliSayfaTip.Test;
                _seciliSayfaTip.SayfaTemplate.FillDataSource();
                _seciliSayfaTip.SayfaTemplate.CreateDocument();

                var cevap = new CevapAnahtar();
                cevap.CustomResim = ResimHelper.CustomImageResmiUret();
                cevap.LogoResim = ResimHelper.LogoResmiUret();
                cevap.LogoAyarla();
                cevap.CustomResimAyarla();
                cevap.Parameters["copyright"].Value = sayiOyunCopyright.EditValue.ToString();
                cevap.Parameters["baslik"].Value = sayiOyunBaslik.EditValue.ToString();
                cevap.Parameters["adSoyad"].Value = sayiOyunAdSoyad.EditValue?.ToString() ?? "";
                cevap.Parameters["dogumTarih"].Value = sayiOyunDogumTarih.EditValue?.ToString() ?? "";
                cevap.Parameters["zorlukDerece"].Value = $"{_zorlukDerece}";

                cevap.DataSource = _seciliSayfaTip.Test;
                cevap.FillDataSource();
                cevap.CreateDocument();

                foreach (Page cevapPage in cevap.Pages)
                {
                    _seciliSayfaTip.SayfaTemplate.Pages.Add(cevapPage);
                }

                var printTool = new ReportPrintTool(_seciliSayfaTip.SayfaTemplate);
                printTool.ShowPreviewDialog();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(LookAndFeel, "Hata oluştu: \n" + ex);
            }


        }
    }
}
