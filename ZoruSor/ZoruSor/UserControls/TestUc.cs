using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using ZoruSor.Lib.Havuz;
using ZoruSor.Reports;

namespace ZoruSor.UserControls
{
    public partial class TestUc : UserControl
    {
        #region Properties
        private readonly string _havuzDizin = ConfigurationManager.AppSettings["HavuzDizin"];
        private string _seciliHavuzTema;
        public int Sira { get; set; }
        private FasikulTest _fasikulTest;
        public FasikulTest FasikulTest { get { return _fasikulTest; } set { _fasikulTest = value; } }
        public List<string> HavuzTemaList { get; set; }
        public List<string> HavuzList { get; set; }

        public bool Resim1FormulVisible { get; set; }
        public bool Resim2FormulVisible { get; set; }
        public bool Resim3FormulVisible { get; set; }
        public bool Resim4FormulVisible { get; set; }
        public bool IslemGorunsunVisible { get; set; }

        private bool _loading;
        #endregion

        void InitializeHavuzTemaList()
        {
            HavuzTemaList = new List<string>();
            DirectoryInfo fi = new DirectoryInfo(_havuzDizin);
            foreach (var info in fi.GetDirectories())
            {
                HavuzTemaList.Add(info.Name);
            }
        }

        void InitializeDataGrid()
        {
            InitializeHavuzTemaList();

            gridView1.Columns["SeciliHavuzYol"].Visible = false;

            #region HavuzTema


            var havuzTemaCb = new RepositoryItemComboBox();
            havuzTemaCb.Items.AddRange(HavuzTemaList);
            // ReSharper disable once LocalizableElement
            havuzTemaCb.NullText = "Seçiniz";
            gridControl1.RepositoryItems.Add(havuzTemaCb);
            gridView1.Columns["HavuzTema"].ColumnEdit = havuzTemaCb;
            gridView1.Columns["HavuzTema"].Width = 200;

            #endregion

            #region HavuzAd
            // ReSharper disable once LocalizableElement
            var havuzCb = new RepositoryItemComboBox { NullText = "Seçiniz" };
            gridControl1.RepositoryItems.Add(havuzCb);

            gridView1.Columns["HavuzAd"].ColumnEdit = havuzCb;
            gridView1.Columns["HavuzAd"].Width = 250;

            #endregion

            #region ZorlukDerece

            // ReSharper disable once LocalizableElement
            var zorlukCb = new RepositoryItemComboBox { NullText = "Seçiniz" };
            gridControl1.RepositoryItems.Add(zorlukCb);

            gridView1.Columns["ZorlukDerece"].ColumnEdit = zorlukCb;
            gridView1.Columns["ZorlukDerece"].Width = 80;
            #endregion

            #region ZorlukDerece

            // ReSharper disable once LocalizableElement
            var sabitCb = new RepositoryItemComboBox { NullText = "Seçiniz" };
            gridControl1.RepositoryItems.Add(sabitCb);

            gridView1.Columns["SabitParcaAdet"].ColumnEdit = sabitCb;
            gridView1.Columns["SabitParcaAdet"].Width = 80;
            #endregion



            gridView1.Columns["SayfaAdet"].Width = 50;

            gridView1.Columns["Resim1Formul"].Width = 150;
            gridView1.Columns["Resim2Formul"].Width = 150;
            gridView1.Columns["Resim3Formul"].Width = 150;
            gridView1.Columns["Resim4Formul"].Width = 150;



            gridView1.CellValueChanged += GridView1_CellValueChanged;


            // Specify a different null value text presentation for the Image column
            //gridView1.Columns["Image"].RealColumnEdit.NullText = "[load image]";

            //Highlight the RequiredDate cells that match a certain condition.
            //GridFormatRule gridFormatRule = new GridFormatRule();
            //FormatConditionRuleValue formatConditionRuleValue = new FormatConditionRuleValue();
            //gridFormatRule.Column = gridView1.Columns["RequiredDate"];
            //formatConditionRuleValue.PredefinedName = "Red Bold Text";
            //formatConditionRuleValue.Condition = FormatCondition.Greater;
            //formatConditionRuleValue.Value1 = DateTime.Today;
            //gridFormatRule.Rule = formatConditionRuleValue;
            //gridFormatRule.ApplyToRow = false;
            //gridView1.FormatRules.Add(gridFormatRule);
            FormulVisibility();
            gridView1.BestFitColumns();

            gridView1.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
        }

        private void GridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "HavuzTema")
            {
                var havuzCb = ((RepositoryItemComboBox)gridControl1.RepositoryItems[1]);
                if (havuzCb != null)
                {
                    havuzCb.Items.Clear();

                    _seciliHavuzTema = e.Value.ToString();
                    HavuzList = new List<string>();

                    DirectoryInfo fi = new DirectoryInfo(_havuzDizin + _seciliHavuzTema);
                    foreach (var info in fi.GetDirectories())
                    {
                        HavuzList.Add(info.Name);
                    }
                    havuzCb.Items.AddRange(HavuzList);

                }
            }
            else if (e.Column.FieldName == "HavuzAd")
            {
                var zorlukCb = ((RepositoryItemComboBox)gridControl1.RepositoryItems[2]);
                if (zorlukCb != null)
                {
                    zorlukCb.Items.Clear();

                    //_seciliHavuzAd =  e.Value.ToString();

                    var parcaCnt = HavuzCreater.GetHavuzParcaCount($"{_havuzDizin}{_seciliHavuzTema}\\{e.Value}");

                    //Secili Havuz' un parca sayisi kadar Zorluk derecesi olustur.
                    for (int i = 0; i < parcaCnt; i++)
                    {
                        //Zorluk seviyelerini comboya doldur.
                        zorlukCb.Items.Add(i + 1);
                    }

                }
            }
            else if (e.Column.FieldName == "ZorlukDerece")
            {
                var sabitCb = ((RepositoryItemComboBox)gridControl1.RepositoryItems[3]);
                if (sabitCb != null)
                {
                    sabitCb.Items.Clear();

                    var zorlukDerece = (int)e.Value;

                    //Secili Zorluk derecesinin bir eksigi kadar olustur olustur.
                    for (int i = 0; i < zorlukDerece; i++)
                    {
                        //Sabit parca degerlerini comboya doldur.
                        sabitCb.Items.Add(i);
                    }

                }
            }
        }

        void GenerateHavuzList()
        {
            HavuzTemaList = new List<string>();
            DirectoryInfo fi = new DirectoryInfo(_havuzDizin);
            foreach (var info in fi.GetDirectories())
            {
                HavuzTemaList.Add(info.Name);
            }

        }

        public TestUc(int sira)
        {
            Sira = sira;

            InitializeComponent();
            _fasikulTest = new FasikulTest();

            GenerateHavuzList();



            // This line of code is generated by Data Source Configuration Wizard
            gridControl1.DataSource = FasikulTest.FasikulTestDetails;

            InitializeDataGrid();


            soruTipCombo.Properties.Items.AddRange(TestTip.List);

            siraLbl.Text = sira.ToString();
            //havuzTemaCombo.Properties.Items.AddRange(HavuzTemaList);
            //ZorlukDerece = zorlukDerece;
            //zorlukCombo.EditValue = zorlukDerece.ToString();
            //SabitParcaAdet = sabitParca;
            //sabitCombo.EditValue = sabitParca.ToString();

            //havuzTemaCombo.EditValue = string.IsNullOrEmpty(havuzTema) ? null : havuzTema;
            //havuzCombo.EditValue = string.IsNullOrEmpty(havuz) ? null : havuz;
            //soruTipCombo.EditValue = string.IsNullOrEmpty(soruTip) ? null : soruTip;
            //if (string.IsNullOrEmpty(sayfaTip) == false)
            //{
            //    var sayfaTipList = SoruSayfaTip.Items.Where(s => s.SoruTipList.Contains(SeciliTest)).ToList();
            //    sayfaTipCombo.Properties.Items.Clear();
            //    sayfaTipCombo.Properties.Items.AddRange(sayfaTipList);

            //    sayfaTipCombo.EditValue = sayfaTip;

            //    SeciliSayfaTip = sayfaTipList.FirstOrDefault(s => s.Ad == sayfaTip);
            //    zorlukCombo.Enabled = true;
            //}

        }

        public TestUc(FasikulTest test)
        {
            Sira = test.Sira;

            InitializeComponent();
            _loading = true;
            _fasikulTest = test;
            if (_fasikulTest.FasikulTestDetails == null)
            {
                _fasikulTest.FasikulTestDetails = new BindingList<FasikulTestDetail>();
            }

            GenerateHavuzList();

            soruTipCombo.Properties.Items.AddRange(TestTip.List);

            // This line of code is generated by Data Source Configuration Wizard
            gridControl1.DataSource = FasikulTest.FasikulTestDetails;

            InitializeDataGrid();

            soruTipCombo.SelectedItem = FasikulTest.SeciliSoruTip;



            //SeciliSayfaTip = new SayfaTip();


            baslikEdit.EditValue = test.Baslik;
           
            siraLbl.Text = test.Sira.ToString();
            //havuzTemaCombo.Properties.Items.AddRange(HavuzTemaList);
            //ZorlukDerece = test.ZorlukDerece;
            //zorlukCombo.EditValue = test.ZorlukDerece.ToString();
            //SabitParcaAdet = test.SabitParcaAdet;
            //sabitCombo.EditValue = test.SabitParcaAdet.ToString();
            //sayfaAdetEdit.EditValue = test.SayfaAdet;
            //havuzTemaCombo.EditValue = string.IsNullOrEmpty(test.SeciliHavuzTema) ? null : test.SeciliHavuzTema;
            //havuzCombo.EditValue = string.IsNullOrEmpty(test.SeciliHavuzAd) ? null : test.SeciliHavuzAd;
            //soruTipCombo.EditValue = string.IsNullOrEmpty(test.SeciliSoruTip) ? null : test.SeciliSoruTip;
            //if (string.IsNullOrEmpty(test.SeciliSayfaTip) == false)
            //{
            //    var sayfaTipList = SoruSayfaTip.Items.Where(s => s.SoruTipList.Contains(SeciliTest)).ToList();
            //    sayfaTipCombo.Properties.Items.Clear();
            //    sayfaTipCombo.Properties.Items.AddRange(sayfaTipList);

            //    sayfaTipCombo.EditValue = test.SeciliSayfaTip;
            //    SeciliSayfaTip = sayfaTipList.FirstOrDefault(s => s.Ad == test.SeciliSayfaTip);

            //    zorlukCombo.Enabled = true;
            //    sabitCombo.Enabled = true;
            //}
            //resim1Formul.EditValue = string.IsNullOrEmpty(test.Resim1Formul) ? null : test.Resim1Formul;
            //resim1Formul.EditValue = string.IsNullOrEmpty(test.Resim2Formul) ? null : test.Resim2Formul;
            //resim3Formul.EditValue = string.IsNullOrEmpty(test.Resim3Formul) ? null : test.Resim3Formul;
            //resim4Formul.EditValue = string.IsNullOrEmpty(test.Resim4Formul) ? null : test.Resim4Formul;
            FormulVisibility();
            _loading = false;
        }


        public void SiraGuncelle(int sira)
        {
            Sira = sira;
            siraLbl.Text = sira.ToString();
        }

        public bool TestValidate()
        {
            if (_fasikulTest.SeciliSayfaTip == null || string.IsNullOrEmpty(_fasikulTest.SeciliSoruTip))
            {
                XtraMessageBox.Show(this, $"Lütfen {Sira}. siradaki testin soru tipi ve sayfa tipi değerlerini kontrol ederek tekrar deneyiniz.", "Test hazırlama kontrolü");
                return false;
            }
            var i = 1;
            foreach (var detail in _fasikulTest.FasikulTestDetails)
            {
                if (string.IsNullOrEmpty(detail.HavuzAd) || detail.ZorlukDerece <= 0 || detail.SabitParcaAdet < 0 ||
                    detail.SayfaAdet <= 0)
                {
                    XtraMessageBox.Show(this, $"Lütfen {Sira}. siradaki testin {i}. satirdaki havuz, zorluk derecesi, sabit parca ve sayfa adedi değerlerini kontrol ederek tekrar deneyiniz.", "Test hazırlama kontrolü");
                    return false;
                }
                i++;
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Parent.Controls.Remove(this);
            Dispose();
        }


        private void soruTipCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(ComboBoxEdit))
            {
                var combo = (ComboBoxEdit)sender;
                if (combo.SelectedItem != null)
                {
                    _fasikulTest.SeciliSoruTip = combo.SelectedItem.ToString();

                    FormulVisibility();



                    //#region Formullere deger ata
                    //resim1Formul.EditValue = "A";
                    //resim2Formul.EditValue = "A+B";
                    //resim3Formul.EditValue = "A+B+C";
                    //resim4Formul.EditValue = "A+B+C+D";

                    //#endregion

                    // ReSharper disable once LocalizableElement
                    aciklamaLbl.Text = $"Test {Sira} - { _fasikulTest.SeciliSoruTip}";

                    var sayfaTipList = SoruSayfaTip.Items.Where(s => s.SoruTipList.Contains(_fasikulTest.SeciliSoruTip)).ToList();

                    sayfaTipCombo.Properties.Items.Clear();
                    sayfaTipCombo.Properties.Items.AddRange(sayfaTipList);

                    sayfaTipCombo.Enabled = true;

                    if (_loading)
                    {
                        var selected = sayfaTipList.FirstOrDefault(s => s.Ad == _fasikulTest.SeciliSayfaTip.Ad);
                        sayfaTipCombo.SelectedItem = selected;
                    }
                    else
                    {
                        sayfaTipCombo.SelectedItem = null;
                    }

                }
                else
                {
                    soruTipCombo.SelectedItem = null;
                    _fasikulTest.SeciliSoruTip = null;
                    aciklamaLbl.Text = "";
                }
            }
        }

        private void SayfaTipCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(ComboBoxEdit))
            {
                var combo = (ComboBoxEdit)sender;
                if (combo.SelectedItem != null)
                {
                    _fasikulTest.SeciliSayfaTip = (SayfaTip)combo.SelectedItem;
                    baslikEdit.EditValue = _fasikulTest.SeciliSoruTip;
                }

            }
        }
        private void FormulVisibility()
        {
            switch (_fasikulTest.SeciliSoruTip)
            {
                case "Melez İkili":
                    Resim1FormulVisible = true;
                    Resim2FormulVisible = true;
                    Resim3FormulVisible = false;
                    Resim4FormulVisible = false;
                    IslemGorunsunVisible = false;
                    break;
                case "Melez Üçlü":
                    Resim1FormulVisible = true;
                    Resim2FormulVisible = true;
                    Resim3FormulVisible = true;
                    Resim4FormulVisible = false;
                    IslemGorunsunVisible = false;
                    break;
                case "Melez Dörtlü":
                    Resim1FormulVisible = true;
                    Resim2FormulVisible = true;
                    Resim3FormulVisible = true;
                    Resim4FormulVisible = true;
                    IslemGorunsunVisible = false;
                    break;
                case "Para Oyunu 1":
                    Resim1FormulVisible = true;
                    Resim2FormulVisible = true;
                    Resim3FormulVisible = true;
                    Resim4FormulVisible = true;
                    IslemGorunsunVisible = true;
                    break;
                case "Para Oyunu 5":
                    Resim1FormulVisible = true;
                    Resim2FormulVisible = true;
                    Resim3FormulVisible = true;
                    Resim4FormulVisible = true;
                    IslemGorunsunVisible = false;
                    break;
                default:
                    Resim1FormulVisible = false;
                    Resim2FormulVisible = false;
                    Resim3FormulVisible = false;
                    Resim4FormulVisible = false;
                    IslemGorunsunVisible = false;
                    break;
            }

            gridView1.Columns["Resim1Formul"].Visible = Resim1FormulVisible;
            gridView1.Columns["Resim2Formul"].Visible = Resim2FormulVisible;
            gridView1.Columns["Resim3Formul"].Visible = Resim3FormulVisible;
            gridView1.Columns["Resim4Formul"].Visible = Resim4FormulVisible;
            gridView1.Columns["IslemGorunsun"].Visible = IslemGorunsunVisible;


        }

        private void baslikEdit_EditValueChanged(object sender, EventArgs e)
        {
            _fasikulTest.Baslik = baslikEdit.EditValue.ToString();
        }
    }
}
