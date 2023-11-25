using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using ZoruSor.Lib.Soru;
using ZoruSor.Lib.TestSoru;
using ZoruSor.Reports;

namespace ZoruSor.UserControls
{
    public partial class Fasikul : UserControl
    {
        private string _copyright = ConfigurationManager.AppSettings["Copyright"];
        private readonly string _havuzDizin = ConfigurationManager.AppSettings["HavuzDizin"];

       
        public Fasikul()
        {
            InitializeComponent();
            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                copyrightEdit.EditValue = _copyright;

                //testLayoutPanel.RowStyles.Clear();
                testLayoutPanel.RowCount = 0;
                testLayoutPanel.Controls.Clear();
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

        private void testEkle_Click(object sender, EventArgs e)
        {
            
            //var havuzTema = "";
            //var havuz = "";
            //var soruTip = "";
            //var sayfaTip = "";
            //var zorlukDerece = 0;
            //var sabitParca = 0;
            //if (testLayoutPanel.Controls.Count > 0)
            //{
            //    TestUc sonTest = (TestUc)testLayoutPanel.Controls[testLayoutPanel.Controls.Count - 1];
            //    //havuzTema = sonTest.SeciliHavuzTema;
            //    //havuz = sonTest.SeciliHavuzAd;
            //    //soruTip = sonTest.SeciliSoruTip;
            //    //sayfaTip = sonTest.SeciliSayfaTipAd;
            //    //zorlukDerece = sonTest.ZorlukDerece;
            //    //sabitParca = sonTest.SabitParcaAdet;
            //}
            var control = new TestUc(testLayoutPanel.RowCount + 1)
            {
                Dock = DockStyle.Fill
            };

            testLayoutPanel.RowCount++;
            testLayoutPanel.RowStyles.Add(new RowStyle { SizeType = SizeType.Absolute, Height = control.Height });

            testLayoutPanel.Controls.Add(control, 0, testLayoutPanel.RowCount - 1);
        }

        private void testLayoutPanel_ControlRemoved(object sender, ControlEventArgs e)
        {
            var sira = 0;
            foreach (TestUc test in testLayoutPanel.Controls)
            {
                test.SiraGuncelle(sira + 1);
                testLayoutPanel.SetRow(test, sira++);
            }
            testLayoutPanel.RowCount--;
        }

        private void fasikulHazırla_Click(object sender, EventArgs e)
        {
            foreach (TestUc test in testLayoutPanel.Controls)
            {
                if (test.TestValidate() == false)
                {
                    return;
                }

            }

            try
            {

                var cevapAnahtarList = new List<FasikulTestCevap>();
                var fasikul = new XtraReport();
                fasikul.CreateDocument();


                int i = 1;
                foreach (TestUc test in testLayoutPanel.Controls)
                {

                    test.FasikulTest.SeciliSayfaTip.Test = new TestReportHelper().CreateTest(test.FasikulTest.SeciliSoruTip,
                        test.FasikulTest.SeciliSayfaTip, test.FasikulTest.FasikulTestDetails);

                  
                        #region Testteki Soru Cevaplarini al

                        var testCevap = new FasikulTestCevap
                        {
                            TestBaslik = test.FasikulTest.Baslik,
                            TestSira = i
                        };

                        var cevapStr = "";
                        var soruNo = 1;
                        foreach (var soru in test.FasikulTest.SeciliSayfaTip.Test)
                        {
                            cevapStr += $"{soruNo}){soru.Cevap}\t";
                            soruNo++;
                        }

                        testCevap.Cevaplar = cevapStr;
                        cevapAnahtarList.Add(testCevap);
                        i++;

                        #endregion
                    

                    test.FasikulTest.SeciliSayfaTip.SayfaTemplate.Parameters["copyright"].Value = _copyright;
                    test.FasikulTest.SeciliSayfaTip.SayfaTemplate.Parameters["baslik"].Value = test.FasikulTest.Baslik;
                    test.FasikulTest.SeciliSayfaTip.SayfaTemplate.Parameters["adSoyad"].Value = adSoyadEdit.EditValue?.ToString() ?? "";
                    test.FasikulTest.SeciliSayfaTip.SayfaTemplate.Parameters["dogumTarih"].Value = dogumTarihEdit.EditValue?.ToString() ?? "";
                    test.FasikulTest.SeciliSayfaTip.SayfaTemplate.Parameters["zorlukDerece"].Value = "";
                    test.FasikulTest.SeciliSayfaTip.SayfaTemplate.CustomResim = ResimHelper.CustomImageResmiUret();
                    test.FasikulTest.SeciliSayfaTip.SayfaTemplate.LogoResim = ResimHelper.LogoResmiUret();
                    test.FasikulTest.SeciliSayfaTip.SayfaTemplate.LogoAyarla();
                    test.FasikulTest.SeciliSayfaTip.SayfaTemplate.CustomResimAyarla();
                    test.FasikulTest.SeciliSayfaTip.SayfaTemplate.DataSource = test.FasikulTest.SeciliSayfaTip.Test;
                    test.FasikulTest.SeciliSayfaTip.SayfaTemplate.FillDataSource();
                    test.FasikulTest.SeciliSayfaTip.SayfaTemplate.CreateDocument();

                    fasikul.Pages.AddRange(test.FasikulTest.SeciliSayfaTip.SayfaTemplate.Pages);
                    test.FasikulTest.Dispose();
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }

                #region Cevap anahtari

                var cevap = new FasikulCevap
                {
                    CustomResim = ResimHelper.CustomImageResmiUret(),
                    LogoResim = ResimHelper.LogoResmiUret()
                };
                cevap.LogoAyarla();
                cevap.CustomResimAyarla();
                cevap.Parameters["baslik"].Value = "CEVAPLAR";
                cevap.Parameters["adSoyad"].Value = adSoyadEdit.EditValue?.ToString() ?? "";
                cevap.Parameters["dogumTarih"].Value = dogumTarihEdit.EditValue?.ToString() ?? "";
                cevap.Parameters["zorlukDerece"].Value = "";

                cevap.DataSource = cevapAnahtarList;
                cevap.FillDataSource();
                cevap.CreateDocument();

                foreach (Page cevapPage in cevap.Pages)
                {
                    fasikul.Pages.Add(cevapPage);
                }
                #endregion

                #region Preview

                fasikul.ShowPreviewDialog();

                #endregion

            }
            catch (Exception ex)
            {
            // ReSharper disable once LocalizableElement
                MessageBox.Show(this, "Hata oluştu: \n" + ex);
            }
        }

        private void fasikulKaydet_Click(object sender, EventArgs e)
        {
            var testList = new List<FasikulTest>();
            foreach (TestUc test in testLayoutPanel.Controls)
            {
                testList.Add(test.FasikulTest);
            }
            Save(testList);
        }

        private void Save(List<FasikulTest> listofa)
        {
            var testDizin = _havuzDizin + "testler\\";
            var di = new DirectoryInfo(testDizin);
            if (!di.Exists)
            {
                di.Create();
            }

            var dialog = new SaveFileDialog
            {
                Filter = @"Zorusor Testleri|*.zst",
                InitialDirectory = testDizin
            };
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {

                var formatter = new BinaryFormatter();
                try
                {
                    // Create a FileStream that will write data to file.
                    FileStream writerFileStream =
                        new FileStream(dialog.FileName, FileMode.Create, FileAccess.Write);
                    // Save our dictionary of friends to file
                    formatter.Serialize(writerFileStream, listofa);

                    // Close the writerFileStream when we are done.
                    writerFileStream.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Zorusor testleri berlitilen dosyaya kaydedilemedi. \n {ex})");
                }
            }
        }

        private void LoadTests(string path)
        {
            // Check if we had previously Save information of our friends
            // previously
            var formatter = new BinaryFormatter();
            if (File.Exists(path))
            {

                try
                {
                    // Create a FileStream will gain read access to the 
                    // data file.
                    FileStream readerFileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
                    // Reconstruct information of our friends from file.
                    var testList = (List<FasikulTest>)formatter.Deserialize(readerFileStream);
                    // Close the readerFileStream when we are done
                    readerFileStream.Close();

                    foreach (var test in testList)
                    {
                        testLayoutPanel.RowCount++;
                        test.Sira = testLayoutPanel.RowCount;
                        var control = new TestUc(test) {Dock = DockStyle.Fill};
                        testLayoutPanel.Controls.Add(control, 0, testLayoutPanel.RowCount - 1);
                    }

                }
                catch (Exception)
                {
                    MessageBox.Show(@"Belirtilen dosya Zorusor test ayarlarını içermiyor.");
                } // end try-catch

            }
        }

        private void fasikulYukle_Click(object sender, EventArgs e)
        {
            var testDizin = _havuzDizin + "testler\\";
            var di = new DirectoryInfo(testDizin);
            if (!di.Exists)
            {
                di.Create();
            }

            var dialog = new OpenFileDialog
            {
                Filter = @"Zorusor Testleri|*.zst",
                InitialDirectory = testDizin,
                Multiselect = false
            };
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                testLayoutPanel.Controls.Clear();
                testLayoutPanel.RowCount=0;
                LoadTests(dialog.FileName);
            }
        }

        private void fasikulEkle_Click(object sender, EventArgs e)
        {
            var testDizin = _havuzDizin + "testler\\";
            var di = new DirectoryInfo(testDizin);
            if (!di.Exists)
            {
                di.Create();
            }

            var dialog = new OpenFileDialog
            {
                Filter = @"Zorusor Testleri|*.zst",
                InitialDirectory = testDizin,
                Multiselect = false
            };
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                 
                LoadTests(dialog.FileName);
            }
        }
    }
}
