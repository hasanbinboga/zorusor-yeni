using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Printing;
using System.Windows.Xps;
using System.Windows.Xps.Packaging;
using System.Windows.Documents;
using System.Windows.Controls;
using System.Windows;

namespace BilisselBeceriler.BelgeEditor.Library.Converters
{
    class XPStoPDF
    {
        public void PDFOlustur(string XPSdosya, string PDFDosyaAdi)
        {
            if (XPSdosya == null)
            {
                return;
            }


            var prnttck = new PrintTicket();
            prnttck.PageMediaSize = new PageMediaSize(PageMediaSizeName.ISOA3);
            prnttck.PageOrientation = PageOrientation.Landscape;

            PrintQueue seciliyazici = new PrintServer().GetPrintQueues(new[] {
                                EnumeratedPrintQueueTypes.Local, 
                                EnumeratedPrintQueueTypes.Connections}).Where(s => s.Name.Contains("XPS")).FirstOrDefault();
            seciliyazici.UserPrintTicket = prnttck;

            seciliyazici.CurrentJobSettings.Description = PDFDosyaAdi;
            XpsDocumentWriter xpsdw = PrintQueue.CreateXpsDocumentWriter(seciliyazici);


            VisualsToXpsDocument XpsVisWriter = (VisualsToXpsDocument)xpsdw.CreateVisualsCollator();

            XpsVisWriter.BeginBatchWrite();
            #region Yazdirma Islemleri
            using (XpsDocument XPSBelgesi = new XpsDocument(XPSdosya, System.IO.FileAccess.Read))
            {
                FixedDocumentSequence Dokuman = XPSBelgesi.GetFixedDocumentSequence();
                for (int i = 0; i < Dokuman.DocumentPaginator.PageCount; i++)
                {
                    DocumentPage seciliSayfa1 = null;
                    seciliSayfa1 = Dokuman.DocumentPaginator.GetPage(i);
                    StackPanel yeniA3Sayfa = new StackPanel();
                    yeniA3Sayfa.Width = seciliSayfa1.Size.Width * 2;
                    yeniA3Sayfa.Height = seciliSayfa1.Size.Height;
                    yeniA3Sayfa.Orientation = Orientation.Horizontal;

                    yeniA3Sayfa.Children.Add(new DocumentPagePageToBorder(seciliSayfa1).border);

                    yeniA3Sayfa.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
                    yeniA3Sayfa.Arrange(new Rect(new Point(0, 0), yeniA3Sayfa.DesiredSize));

                    XpsVisWriter.Write(yeniA3Sayfa, prnttck);
                    seciliSayfa1.Dispose();
                    yeniA3Sayfa = null;
                    GC.Collect();
                    GC.WaitForFullGCComplete(5000);
                }
            }
            #endregion
            XpsVisWriter.EndBatchWrite();
            GC.Collect();
            GC.WaitForFullGCComplete(50000);
        }
    }
}
