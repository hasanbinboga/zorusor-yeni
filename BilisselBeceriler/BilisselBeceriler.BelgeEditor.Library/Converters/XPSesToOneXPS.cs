using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BilisselBeceriler.BelgeEditor.Library.Enums;
using BilisselBeceriler.BelgeEditor.Library.Types;
using System.Windows.Documents;
using System.Windows.Xps.Packaging;
using System.Printing;
using System.Windows.Xps;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;
using System.IO;

namespace BilisselBeceriler.BelgeEditor.Library.Converters
{
    class XPSesToOneXPS
    {
        
        private static void A3SayfaYazdir(List<DocumentPage> sayfalar,
                                         ref VisualsToXpsDocument XpsVisWriter,
                                         ref PrintTicket seciliTicket)
        {
            for (int i = 0; i < sayfalar.Count - 1; i += 2)
            {
                DocumentPage seciliSayfa1 = null;
                DocumentPage seciliSayfa2 = null;

                seciliSayfa1 = sayfalar[i];

                StackPanel yeniA3Sayfa = new StackPanel();
                yeniA3Sayfa.Width = seciliSayfa1.Size.Width * 2;
                yeniA3Sayfa.Height = seciliSayfa1.Size.Height;
                yeniA3Sayfa.Orientation = Orientation.Horizontal;

                yeniA3Sayfa.Children.Add(new DocumentPagePageToBorder(seciliSayfa1).border);

                if (i + 1 < sayfalar.Count)
                {
                    seciliSayfa2 = sayfalar[i + 1];
                    yeniA3Sayfa.Children.Add(new DocumentPagePageToBorder(seciliSayfa2).border);
                }

                yeniA3Sayfa.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
                yeniA3Sayfa.Arrange(new Rect(new Point(0, 0), yeniA3Sayfa.DesiredSize));

                XpsVisWriter.Write(yeniA3Sayfa, seciliTicket);
                seciliSayfa1.Dispose();
                seciliSayfa2.Dispose();
                yeniA3Sayfa = null;
                GC.Collect();
                GC.WaitForFullGCComplete(5000);
            }
        }
        public void TopluXPSOlustur(object xpsArgs)
        {
            XPSOlusturArgs args = new XPSOlusturArgs();
            if (xpsArgs == null)
            {
                return;
            }
            else if (xpsArgs is XPSOlusturArgs)
            {
                args = xpsArgs as XPSOlusturArgs;
            }
            else
            {
                return;
            }
            List<DocumentPage> yazdirilacakSayfalar = new List<DocumentPage>();
            List<DocumentPage> yazdirilacakKapaklar = new List<DocumentPage>();
            if (args.belgeTur == BelgeTur.Kitap)
            {
                foreach (var seciliDosya in args.dosyalar)
                {
                    using (XpsDocument XPSBelgesi = new XpsDocument(seciliDosya, System.IO.FileAccess.Read))
                    {
                        FixedDocumentSequence Dokuman = XPSBelgesi.GetFixedDocumentSequence();

                        yazdirilacakKapaklar.Add(Dokuman.DocumentPaginator.GetPage(0));
                        yazdirilacakKapaklar.Add(Dokuman.DocumentPaginator.GetPage(Dokuman.DocumentPaginator.PageCount - 1));
                        for (int i = 1; i < Dokuman.DocumentPaginator.PageCount - 1; i++)
                        {
                            yazdirilacakSayfalar.Add(Dokuman.DocumentPaginator.GetPage(i));
                        }
                    }
                }
            }
            else
            {
                foreach (var seciliDosya in args.dosyalar)
                {
                    using (XpsDocument XPSBelgesi = new XpsDocument(seciliDosya, System.IO.FileAccess.Read))
                    {
                        FixedDocumentSequence Dokuman = XPSBelgesi.GetFixedDocumentSequence();
                        for (int i = 0; i < Dokuman.DocumentPaginator.PageCount; i++)
                        {
                            yazdirilacakSayfalar.Add(Dokuman.DocumentPaginator.GetPage(i));
                        }
                    }
                }
            }
            if (args.belgeTur == BelgeTur.Kitap)
            {
                using (XpsDocument outXpsDoc =
                   new XpsDocument(args.Klasor + @"\Kapaklar.XPS", FileAccess.Write, System.IO.Packaging.CompressionOption.SuperFast))
                {
                    PrintTicket prnttck = new PrintTicket();
                    prnttck.PageMediaSize = new PageMediaSize(PageMediaSizeName.ISOA3);
                    prnttck.PageOrientation = PageOrientation.Landscape;

                    // create the document writer for the new document
                    XpsDocumentWriter XpsDocWrtr =
                        XpsDocument.CreateXpsDocumentWriter(outXpsDoc);

                    // create the "batch" writer
                    VisualsToXpsDocument XpsVisWriter = (VisualsToXpsDocument)XpsDocWrtr.CreateVisualsCollator();

                    XpsVisWriter.BeginBatchWrite();

                    A3SayfaYazdir(yazdirilacakKapaklar, ref XpsVisWriter, ref prnttck);

                    XpsVisWriter.EndBatchWrite();

                    yazdirilacakKapaklar.Clear();
                    yazdirilacakKapaklar = null;

                    GC.Collect();
                    GC.WaitForFullGCComplete(5000);
                }
            }
            using (XpsDocument outXpsDoc =
                   new XpsDocument(args.Klasor + "\\" + args.XPSDosyaAdi, FileAccess.Write, System.IO.Packaging.CompressionOption.SuperFast))
            {
                PrintTicket prnttck = new PrintTicket();
                prnttck.PageMediaSize = new PageMediaSize(PageMediaSizeName.ISOA3);
                prnttck.PageOrientation = PageOrientation.Landscape;

                // create the document writer for the new document
                XpsDocumentWriter XpsDocWrtr =
                    XpsDocument.CreateXpsDocumentWriter(outXpsDoc);



                // create the "batch" writer
                VisualsToXpsDocument XpsVisWriter = (VisualsToXpsDocument)XpsDocWrtr.CreateVisualsCollator();

                XpsVisWriter.BeginBatchWrite();

                A3SayfaYazdir(yazdirilacakSayfalar, ref XpsVisWriter, ref prnttck);

                XpsVisWriter.EndBatchWrite();

                yazdirilacakSayfalar.Clear();
                yazdirilacakSayfalar = null;

                GC.Collect();
                GC.WaitForFullGCComplete(5000);
            }
            GC.Collect();
            GC.WaitForFullGCComplete(5000);
            //if (args.belgeTur == BelgeTur.Alistirma)
            //{
            //    NiXPS.Converter.XpsToPdfWithFile(@"C:\Alistirmalar.XPS", @"C:\Alistirmalar.PDF");
            //    //PDFOlustur(@"C:\Alistirmalar.XPS", "Alistirmalar");
            //    GC.Collect();
            //    GC.WaitForFullGCComplete(50000);
            //}
            //else if (args.belgeTur == BelgeTur.Cikartma)
            //{
            //    NiXPS.Converter.XpsToPdfWithFile(@"C:\Cikartmalar.XPS", @"C:\Cikartmalar.PDF");
            //    //PDFOlustur(@"C:\Cikartmalar.XPS", "Cikartmalar");
            //    GC.Collect();
            //    GC.WaitForFullGCComplete(50000);
            //}
            //else if (args.belgeTur == BelgeTur.CikartmaSablonu)
            //{
            //    NiXPS.Converter.XpsToPdfWithFile(@"C:\CikartmaSablonlari.XPS", @"C:\CikartmaSablonlari.PDF");
            //    //PDFOlustur(@"C:\CikartmaSablonlari.XPS", "CikartmaSablonlari");
            //    GC.Collect();
            //    GC.WaitForFullGCComplete(50000);
            //}
            //else if (args.belgeTur == BelgeTur.Kitap)
            //{
            //    NiXPS.Converter.XpsToPdfWithFile(@"C:\Kapaklar.XPS", @"C:\Kapaklar.PDF");
            //    //PDFOlustur(@"C:\Kapaklar.XPS", "Kapaklar");
            //    GC.Collect();
            //    GC.WaitForFullGCComplete(50000);
            //    NiXPS.Converter.XpsToPdfWithFile(@"C:\Kitaplar.XPS", @"C:\Kitaplar.PDF");
            //    //PDFOlustur(@"C:\Kitaplar.XPS", "Kitaplar");
            //    GC.Collect();
            //    GC.WaitForFullGCComplete(50000);
            //}
        }
    }
}
