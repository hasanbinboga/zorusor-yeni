using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Printing;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Xps;
using System.Windows.Xps.Packaging;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.Win32;

namespace BilisselBeceriler.BelgeEditor.Library.Helpers
{
    public static class PrintHelper
    {
        public static void PrintFixedDocument(FixedDocument toPrint, string outDosyaAdi, PrintQueue yazici)
        {
            try
            {
                if (toPrint == null)
                {
                    return;
                }
                yazici.CurrentJobSettings.Description = outDosyaAdi;
                XpsDocumentWriter xpsdw = PrintQueue.CreateXpsDocumentWriter(yazici);
                var tempPrnTckt = toPrint.PrintTicket as PrintTicket;
                toPrint.PrintTicket = null;
                // create the "batch" writer
                var xpsVisWriter = (VisualsToXpsDocument)xpsdw.CreateVisualsCollator();
                if (xpsVisWriter != null) xpsVisWriter.BeginBatchWrite();
                var paginator = new PageRangeDocumentPaginator(toPrint.DocumentPaginator, new PageRange(), yazici.UserPrintTicket,new Thickness());

                for (int i = 0; i < paginator.PageCount; i++)
                {
                    var page = paginator.GetPage(i);
                    if (xpsVisWriter != null)
                        xpsVisWriter.Write(((FixedPage)page.Visual).Children[0], yazici.UserPrintTicket);
                }
                paginator.Arrange();
                if (xpsVisWriter != null) xpsVisWriter.EndBatchWrite();
                toPrint.PrintTicket = tempPrnTckt;
            }
            catch
            {
            }
        }
        public static void PrintFixedDocument(FixedDocument toPrint, string outKlasor, string outDosya, PrintTicket yaziciAyar)
        {
            try
            {
                if (toPrint == null)
                {
                    return;
                }
                if (Directory.Exists(outKlasor) == false)
                {
                    Directory.CreateDirectory(outKlasor);
                }
                using (var outXpsDoc =
                        new XpsDocument(outKlasor + "\\" + outDosya, FileAccess.Write, System.IO.Packaging.CompressionOption.SuperFast))
                {
                    var tempPrnTckt = toPrint.PrintTicket as PrintTicket;
                    toPrint.PrintTicket = null;
                    // create the document writer for the new document
                    var xpsDocWrtr =
                        XpsDocument.CreateXpsDocumentWriter(outXpsDoc);

                    // create the "batch" writer
                    var xpsVisWriter = (VisualsToXpsDocument)xpsDocWrtr.CreateVisualsCollator();

                    if (xpsVisWriter != null) xpsVisWriter.BeginBatchWrite();
                    var paginator = new PageRangeDocumentPaginator(toPrint.DocumentPaginator, new PageRange());

                    for (int i = 0; i < paginator.PageCount; i++)
                    {
                        var page = paginator.GetPage(i);
                        if (xpsVisWriter != null)
                            xpsVisWriter.Write(((FixedPage)page.Visual).Children[0], yaziciAyar);
                    }
                    paginator.Arrange();

                    if (xpsVisWriter != null) xpsVisWriter.EndBatchWrite();
                    GC.Collect();
                    GC.WaitForFullGCComplete(5000);
                    toPrint.PrintTicket = tempPrnTckt;
                }
            }
            catch
            {

            }
        }
        public static void OnlyPrintFixedDocument(FixedDocument toPrint, string outKlasor, string outDosya, PrintTicket yaziciAyar)
        {
            try
            {
                if (toPrint == null)
                {
                    return;
                }
                if (Directory.Exists(outKlasor) == false)
                {
                    Directory.CreateDirectory(outKlasor);
                }
                using (var outXpsDoc =
                        new XpsDocument(outKlasor + "\\" + outDosya, FileAccess.Write, System.IO.Packaging.CompressionOption.SuperFast))
                {
                    var tempPrnTckt = toPrint.PrintTicket as PrintTicket;
                    toPrint.PrintTicket = null;
                    // create the document writer for the new document
                    var xpsDocWrtr =
                        XpsDocument.CreateXpsDocumentWriter(outXpsDoc);

                    // create the "batch" writer
                    var xpsVisWriter = (VisualsToXpsDocument)xpsDocWrtr.CreateVisualsCollator();

                    if (xpsVisWriter != null) xpsVisWriter.BeginBatchWrite();
                    var paginator = new PageRangeDocumentPaginator(toPrint.DocumentPaginator, new PageRange());

                    for (int i = 0; i < paginator.PageCount; i++)
                    {
                        var page = paginator.GetPage(i);
                        if (xpsVisWriter != null)
                            xpsVisWriter.Write(((FixedPage)page.Visual).Children[0], yaziciAyar);
                    }
                    paginator.Arrange();

                    if (xpsVisWriter != null) xpsVisWriter.EndBatchWrite();
                    GC.Collect();
                    GC.WaitForFullGCComplete(5000);
                    toPrint.PrintTicket = tempPrnTckt;
                }
            }
            catch
            {


            }
        }
        public static void OnlyPrintFixedDocument(FixedDocument toPrint, string outDosyaAdi, PrintQueue yazici, Thickness marj)
        {
            try
            {
                if (toPrint == null)
                {
                    return;
                }
                var tempPrnTckt = toPrint.PrintTicket as PrintTicket;
                toPrint.PrintTicket = null;
                yazici.CurrentJobSettings.Description = outDosyaAdi;
                yazici.DefaultPrintTicket = yazici.CurrentJobSettings.CurrentPrintTicket;
                var printDialog = new PrintDialog();
                printDialog.PrintQueue = yazici;
                printDialog.PrintTicket.PageMediaSize = yazici.UserPrintTicket.PageMediaSize;
                printDialog.PrintTicket.PageOrientation = yazici.UserPrintTicket.PageOrientation;
                printDialog.PrintTicket.PageResolution = yazici.UserPrintTicket.PageResolution;
                var paginator = new PageRangeDocumentPaginator(toPrint.DocumentPaginator, new PageRange());
                printDialog.PrintDocument(paginator, outDosyaAdi);

                //paginator.Arrange();

                toPrint.PrintTicket = tempPrnTckt;
            }
            catch
            {


            }
        }
        public static void ShowPrintPreview(FixedDocument fixedDoc)
        {
            var wnd = new Window();
            var viewer = new DocumentViewer { Document = fixedDoc };
            wnd.Content = viewer;
            wnd.Title = "Bişilsel Beceriler - Baskı Önizleme";
            wnd.ShowDialog();
        }

        public static PrintDialog GetDialogFromRegistry()
        {
            var key = Registry.CurrentUser.OpenSubKey("BilisselBeceri-Yazici");
            var result = new PrintDialog();
            try
            {
                if (key != null)
                {
                    result.MaxPage = DeSerialize<uint>(key.GetValue("MaxPage").ToString());
                    result.MinPage = DeSerialize<uint>(key.GetValue("MinPage").ToString());
                    result.PageRangeSelection = DeSerialize<PageRangeSelection>(key.GetValue("PageRangeSelection").ToString());
                    result.PrintQueue = FindQueue(DeSerialize<string>(key.GetValue("PrintQueue").ToString()));
                    var xml = key.GetValue("PrintTicket").ToString();
                    using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(xml)))
                    {
                        result.PrintTicket = new PrintTicket(stream);
                    }
                    result.PrintQueue.UserPrintTicket = result.PrintTicket;
                    result.UserPageRangeEnabled = DeSerialize<bool>(key.GetValue("UserPageRangeEnabled").ToString());
                }
                return result;
            }
            catch (Exception e)
            {
                if (Registry.CurrentUser.OpenSubKey("BilisselBeceri-Yazici") != null)
                {
                    Registry.CurrentUser.DeleteSubKey("BilisselBeceri-Yazici");
                }
                throw new Exception("GetDialogFromRegistry Hata: " + e.Message + "\n" + e.InnerException.Message);
            }

        }
        private static PrintQueue FindQueue(string name)
        {
            PrintQueueCollection yazicilar = new PrintServer().GetPrintQueues(new[] {
                                EnumeratedPrintQueueTypes.Local, 
                                EnumeratedPrintQueueTypes.Connections});
            return yazicilar.FirstOrDefault(s => s.Name.Contains(name));

        }
        private static T DeSerialize<T>(string xml)
        {
            // serialise to object
            var serializer = new XmlSerializer(typeof(T));
            var stream = new StringReader(xml);
            var reader = new XmlTextReader(stream);
            // covert reader to object
            return (T)serializer.Deserialize(reader);
        }



        private static string Serialize(object obj)
        {
            string objectToSaveInRegistry;

            using (var stream = new MemoryStream())
            {
                new XmlSerializer(obj.GetType()).Serialize(stream, obj);

                objectToSaveInRegistry = Encoding.UTF8.GetString(stream.ToArray());
            }
            return objectToSaveInRegistry;
        }

        private static string Serialize(MemoryStream stream)
        {
            string objectToSaveInRegistry;

            using (stream)
            {
                objectToSaveInRegistry = Encoding.UTF8.GetString(stream.ToArray());
            }
            return objectToSaveInRegistry;
        }

        public static void SetDialogToRegistry(PrintDialog dialog)
        {
            try
            {
                if (Registry.CurrentUser.OpenSubKey("BilisselBeceri-Yazici") != null)
                {
                    Registry.CurrentUser.DeleteSubKey("BilisselBeceri-Yazici");
                }

                var key = Registry.CurrentUser.CreateSubKey("BilisselBeceri-Yazici");

                if (key != null)
                {
                    key.SetValue("MaxPage", Serialize(dialog.MaxPage), RegistryValueKind.String);
                    key.SetValue("MinPage", Serialize(dialog.MinPage), RegistryValueKind.String);
                    key.SetValue("PageRangeSelection", Serialize(dialog.PageRangeSelection), RegistryValueKind.String);
                    key.SetValue("PrintQueue", Serialize(dialog.PrintQueue.Name), RegistryValueKind.String);
                    key.SetValue("PrintTicket", Serialize(dialog.PrintTicket.GetXmlStream()), RegistryValueKind.String);

                    key.SetValue("UserPageRangeEnabled", Serialize(dialog.UserPageRangeEnabled), RegistryValueKind.String);
                    key.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Yazıcı Açma Problemi: " + ex.Message);
                if (Registry.CurrentUser.OpenSubKey("BilisselBeceri") != null)
                {
                    Registry.CurrentUser.DeleteSubKey("BilisselBeceri");
                }
            }
        }

        private const string FEATURENODE = "psf:Feature";
        private const string PAPERSIZEATTRIBUTE = "psk:PageMediaSize";
        private const string PAPEROPTIONNODE = "psf:Option";
        private const string SCOREDPROPERTYNODE = "psf:ScoredProperty";
        private const string WIDTHATTRIBUTE = "psk:MediaSizeWidth";
        private const string HEIGHTATTRIBUTE = "psk:MediaSizeHeight";
        private const string VALUENODE = "psf:Value";
        private const string PROPERTNODE = "psf:Property";
        private const string DISPLAYNAMEATTRIBUTE = "psk:DisplayName";
        private const string NAMEATTRIBUTE = "name";


        public static List<PageMediaSize> GetMediaSizes(PrintQueue yazici)
        {
            var lstPaperSizes = new List<PageMediaSize>();
            try
            {
                using (var stream = yazici.GetPrintCapabilitiesAsXml())
                {
                    var xmlString = new XmlTextReader(stream);
                    while (xmlString.Read())
                    {
                        if (xmlString.NodeType == XmlNodeType.Element && xmlString.Name == FEATURENODE)
                        {

                            if (xmlString.AttributeCount == 1 &&
                                xmlString.GetAttribute(NAMEATTRIBUTE) == PAPERSIZEATTRIBUTE)
                            {
                                lstPaperSizes = processAllPaperSizes(xmlString.ReadSubtree());
                            }

                        }


                    }
                }
                return lstPaperSizes;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private static List<PageMediaSize> processAllPaperSizes(XmlReader PaperSizeXmlString)
        {
            var lstPaperSizes = new List<PageMediaSize>();
            string currentKey;
            try
            {
                while (PaperSizeXmlString.Read())
                {
                    if (PaperSizeXmlString.NodeType == XmlNodeType.Element && PaperSizeXmlString.Name == PAPEROPTIONNODE)
                    {
                        currentKey = PaperSizeXmlString.GetAttribute(NAMEATTRIBUTE);
                        var newSize = processPaperSize(currentKey, PaperSizeXmlString.ReadSubtree());
                        if (newSize != null)
                        {
                            lstPaperSizes.Add(newSize);
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return lstPaperSizes;
        }

        private static PageMediaSize processPaperSize(string currentPaperKey, XmlReader PaperSizeXmlString)
        {
            double? currentWidth = null, currentHeight = null;
            string currentName = null;
            string stringwidth, stringheight;
            try
            {
                while (PaperSizeXmlString.Read())
                {
                    if (PaperSizeXmlString.NodeType == XmlNodeType.Element)
                    {
                        switch (PaperSizeXmlString.Name)
                        {
                            case SCOREDPROPERTYNODE:
                                if (PaperSizeXmlString.AttributeCount == 1)
                                {
                                    switch (PaperSizeXmlString.GetAttribute(NAMEATTRIBUTE))
                                    {
                                        case WIDTHATTRIBUTE:
                                            stringwidth = processPaperValue(PaperSizeXmlString.ReadSubtree());
                                            if (string.IsNullOrEmpty(stringwidth))
                                            {
                                                currentWidth = null;
                                            }
                                            else
                                            {
                                                currentWidth = Convert.ToDouble(stringwidth);
                                                currentWidth /= 10000;
                                                currentWidth *= 37.8;
                                            }
                                            break;
                                        case HEIGHTATTRIBUTE:
                                            stringheight = processPaperValue(PaperSizeXmlString.ReadSubtree());
                                            if (string.IsNullOrEmpty(stringheight))
                                            {
                                                currentHeight = null;
                                            }
                                            else
                                            {
                                                currentHeight = Convert.ToDouble(stringheight);
                                                currentHeight /= 10000;
                                                currentHeight *= 37.8;
                                            }
                                            break;
                                    }
                                }
                                break;
                            case PROPERTNODE:
                                if (PaperSizeXmlString.AttributeCount == 1 && PaperSizeXmlString.GetAttribute(NAMEATTRIBUTE) == DISPLAYNAMEATTRIBUTE)
                                {
                                    currentName = processPaperValue(PaperSizeXmlString.ReadSubtree());
                                }
                                break;
                        }
                    }
                }
                if (currentWidth.HasValue && currentHeight.HasValue)
                {
                    var identifyList = new List<string>();
                    var enumValues = typeof(PageMediaSizeName).GetFields().Where(f => f.IsLiteral).OrderBy(x => x.MetadataToken).Select(f => f.GetValue(null)).ToArray();
                    foreach (var item in enumValues)
                    {
                        var fc = (Enum)Enum.Parse(typeof(PageMediaSizeName), item.ToString(), true);
                        identifyList.Add(fc.ToString());
                    }
                    PageMediaSizeName mediaName;
                    Enum.TryParse(identifyList.FirstOrDefault(s=> currentName != null && s.Contains(currentName)), true, out mediaName);
                    return new PageMediaSize(mediaName, currentWidth.Value, currentHeight.Value);
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private static string processPaperValue(XmlReader valueXmlString)
        {
            try
            {
                while (valueXmlString.Read())
                {
                    if (valueXmlString.NodeType == XmlNodeType.Element && valueXmlString.Name == VALUENODE)
                    {
                        return valueXmlString.ReadElementContentAsString().Trim();
                    }
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
