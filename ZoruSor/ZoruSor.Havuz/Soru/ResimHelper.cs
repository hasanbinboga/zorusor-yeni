using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using DevExpress.Data.Browsing.Design;
using ZoruSor.Lib.Havuz;
using ZoruSor.Lib.ResimBuilder;

namespace ZoruSor.Lib.Soru
{
    public static class ResimHelper
    {
        private static Graphics KanavaGetir(Image resim)
        {
            var graphics = Graphics.FromImage(resim);

            graphics.CompositingMode = CompositingMode.SourceOver;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
            return graphics;
        }

        private static Image RotateRightResmiUret()
        {
            System.Reflection.Assembly myAssembly = System.Reflection.Assembly.GetExecutingAssembly();
            Stream myStream = myAssembly.GetManifestResourceStream("ZoruSor.Lib.Images.rotate-right.png");
            return new Bitmap(myStream);
        }
        private static Image RotateLeftResmiUret()
        {
            System.Reflection.Assembly myAssembly = System.Reflection.Assembly.GetExecutingAssembly();
            Stream myStream = myAssembly.GetManifestResourceStream("ZoruSor.Lib.Images.rotate-left.png");
            return new Bitmap(myStream);
        }

        private static Image GoldenCupResmiUret()
        {
            System.Reflection.Assembly myAssembly = System.Reflection.Assembly.GetExecutingAssembly();
            Stream myStream = myAssembly.GetManifestResourceStream("ZoruSor.Lib.Images.golden-cup.png");
            return new Bitmap(myStream);
        }

        private static Image SilverCupResmiUret()
        {
            System.Reflection.Assembly myAssembly = System.Reflection.Assembly.GetExecutingAssembly();
            Stream myStream = myAssembly.GetManifestResourceStream("ZoruSor.Lib.Images.silver-cup.png");
            return new Bitmap(myStream);
        }

        private static Image BronzeCupResmiUret()
        {
            System.Reflection.Assembly myAssembly = System.Reflection.Assembly.GetExecutingAssembly();
            Stream myStream = myAssembly.GetManifestResourceStream("ZoruSor.Lib.Images.bronze-cup.png");
            return new Bitmap(myStream);
        }

        private static Image ZayifKolResmiUret()
        {
            System.Reflection.Assembly myAssembly = System.Reflection.Assembly.GetExecutingAssembly();
            Stream myStream = myAssembly.GetManifestResourceStream("ZoruSor.Lib.Images.icon-weak-arm.jpg");
            return new Bitmap(myStream);
        }
        private static Image GucluKolResmiUret()
        {
            System.Reflection.Assembly myAssembly = System.Reflection.Assembly.GetExecutingAssembly();
            Stream myStream = myAssembly.GetManifestResourceStream("ZoruSor.Lib.Images.icon-strong-arm.jpg");
            return new Bitmap(myStream);
        }
        private static Image ParantezAcResmiUret()
        {
            System.Reflection.Assembly myAssembly = System.Reflection.Assembly.GetExecutingAssembly();
            Stream myStream = myAssembly.GetManifestResourceStream("ZoruSor.Lib.Images.parantez-ac.png");
            return new Bitmap(myStream);
        }
        private static Image ParantezKapaResmiUret()
        {
            System.Reflection.Assembly myAssembly = System.Reflection.Assembly.GetExecutingAssembly();
            Stream myStream = myAssembly.GetManifestResourceStream("ZoruSor.Lib.Images.parantez-kapa.png");
            return new Bitmap(myStream);
        }
        private static Image OkResmiUret()
        {
            System.Reflection.Assembly myAssembly = System.Reflection.Assembly.GetExecutingAssembly();
            Stream myStream = myAssembly.GetManifestResourceStream("ZoruSor.Lib.Images.ok.png");
            return new Bitmap(myStream);
        }

        private static Image CiftOkResmiUret()
        {
            System.Reflection.Assembly myAssembly = System.Reflection.Assembly.GetExecutingAssembly();
            Stream myStream = myAssembly.GetManifestResourceStream("ZoruSor.Lib.Images.ciftok.png");
            return new Bitmap(myStream);
        }

        private static Image SoruIsaretResmiUret()
        {
            System.Reflection.Assembly myAssembly = System.Reflection.Assembly.GetExecutingAssembly();
            Stream myStream = myAssembly.GetManifestResourceStream("ZoruSor.Lib.Images.sor.png");
            return new Bitmap(myStream);
        }

        public static Image LogoResmiUret()
        {
            System.Reflection.Assembly myAssembly = System.Reflection.Assembly.GetExecutingAssembly();
            Stream myStream = myAssembly.GetManifestResourceStream("ZoruSor.Lib.Images.logo.png");
            return new Bitmap(myStream);
        }
        public static Image CustomImageResmiUret()
        {
            System.Reflection.Assembly myAssembly = System.Reflection.Assembly.GetExecutingAssembly();
            Stream myStream = myAssembly.GetManifestResourceStream("ZoruSor.Lib.Images.custom.png");
            return new Bitmap(myStream);
        }
        private static Image YildizResmiUret()
        {
            System.Reflection.Assembly myAssembly = System.Reflection.Assembly.GetExecutingAssembly();
            Stream myStream = myAssembly.GetManifestResourceStream("ZoruSor.Lib.Images.yil.png");
            return new Bitmap(myStream);
        }

        private static Image UpResmiUret()
        {
            System.Reflection.Assembly myAssembly = System.Reflection.Assembly.GetExecutingAssembly();
            Stream myStream = myAssembly.GetManifestResourceStream("ZoruSor.Lib.Images.up-emoji.png");
            return new Bitmap(myStream);
        }

        private static Image DownResmiUret()
        {
            System.Reflection.Assembly myAssembly = System.Reflection.Assembly.GetExecutingAssembly();
            Stream myStream = myAssembly.GetManifestResourceStream("ZoruSor.Lib.Images.down-emoji.png");
            return new Bitmap(myStream);
        }
        private static Image SolResmiUret()
        {
            System.Reflection.Assembly myAssembly = System.Reflection.Assembly.GetExecutingAssembly();
            Stream myStream = myAssembly.GetManifestResourceStream("ZoruSor.Lib.Images.sol-emoji.png");
            return new Bitmap(myStream);
        }

        private static Image SagResmiUret()
        {
            System.Reflection.Assembly myAssembly = System.Reflection.Assembly.GetExecutingAssembly();
            Stream myStream = myAssembly.GetManifestResourceStream("ZoruSor.Lib.Images.sag-emoji.png");
            return new Bitmap(myStream);
        }

        private static Image ParaResimUret(string banknot)
        {
            System.Reflection.Assembly myAssembly = System.Reflection.Assembly.GetExecutingAssembly();
            Stream myStream = myAssembly.GetManifestResourceStream("ZoruSor.Lib.Images." + banknot + ".png");
            return new Bitmap(myStream);
        }



        private static List<string> DegisecekParcaUret(int degisecekParcaAdet, List<string> degisebilecekParcalar)
        {
            var degisecekParcalar = new List<string>();
            var secilmisIdler = new List<int>();
            for (int i = 0; i < degisecekParcaAdet; i++)
            {
                var newId = RandomHelper.RandomDifferentNumber(0, degisebilecekParcalar.Count - 1,
                    secilmisIdler.ToArray());
                degisecekParcalar.Add(degisebilecekParcalar[newId]);
                secilmisIdler.Add(newId);
            }
            return degisecekParcalar;
        }
        public struct Lst_Data
        {
            public Point point;
            public Color color;
        }

        public static CiktiResim IslemResimUret(List<string> satirList, int genislik, int yukseklik)
        {
            var fontBoyut = (28f * genislik) / 350f;
            var sonuc = new CiktiResim
            {
                Image = new Bitmap(genislik, yukseklik, PixelFormat.Format32bppArgb),
            };

            using (var graphics = KanavaGetir(sonuc.Image))
            {
                graphics.DrawLine(new Pen(Color.LimeGreen, 2), new Point(1, 1), new Point(genislik - 1, 1));
                graphics.DrawLine(new Pen(Color.LimeGreen, 2), new Point(1, 1), new Point(1, yukseklik - 1));
                graphics.DrawLine(new Pen(Color.LimeGreen, 2), new Point(1, yukseklik - 1), new Point(genislik - 1, yukseklik - 1));
                graphics.DrawLine(new Pen(Color.LimeGreen, 2), new Point(genislik - 1, 1), new Point(genislik - 1, yukseklik - 1));


                // Create font and brush.
                Font drawFont = new Font("Arial", fontBoyut, FontStyle.Regular);
                SolidBrush drawBrush = new SolidBrush(Color.Black);
                var format = new StringFormat();
                format.Alignment = StringAlignment.Near;

                var shift = (int)(yukseklik * 0.10);

                var satirYukseklik = yukseklik / satirList.Count - 3 * satirList.Count;
                foreach (var satir in satirList)
                {
                    // Create point for upper-left corner of drawing.
                    var drawRect = new RectangleF(2, shift, genislik - 5, satirYukseklik);
                    // Draw string to screen.
                    graphics.DrawString(satir, drawFont, drawBrush, drawRect, format);

                    shift += satirYukseklik + 3;
                }

                graphics.Flush();

            }
            return sonuc;
        }

        public static CiktiResim CarpmaResimUret(int sayi1, int sayi2, bool sayilarGorunsun, bool sonucGorunsun, int genislik, int yukseklik)
        {
            var satirAdet = 3;
            if (sayi1.ToString().Length + sayi2.ToString().Length > 3 && sayi1.ToString().Length + sayi2.ToString().Length < 6)
            {
                satirAdet = 5;
            }
            else if (sayi1.ToString().Length + sayi2.ToString().Length > 5 && sayi1.ToString().Length + sayi2.ToString().Length < 8)
            {
                satirAdet = 6;
            }
            var satirYukseklik = yukseklik / (satirAdet + 1);
            var fontBoyut = ((45f * yukseklik) / 100f) / satirAdet;
            //var yaziBoyu = resimBoyut /3-5;

            var sonuc = new CiktiResim
            {
                Image = new Bitmap(genislik, yukseklik, PixelFormat.Format32bppArgb),
            };
            using (var graphics = KanavaGetir(sonuc.Image))
            {
                graphics.DrawLine(new Pen(Color.LimeGreen, 2), new Point(1, 1), new Point(genislik - 1, 1));
                graphics.DrawLine(new Pen(Color.LimeGreen, 2), new Point(1, 1), new Point(1, yukseklik - 1));
                graphics.DrawLine(new Pen(Color.LimeGreen, 2), new Point(1, yukseklik - 1), new Point(genislik - 1, yukseklik - 1));
                graphics.DrawLine(new Pen(Color.LimeGreen, 2), new Point(genislik - 1, 1), new Point(genislik - 1, yukseklik - 1));


                // Create font and brush.
                Font drawFont = new Font("Arial", fontBoyut, FontStyle.Regular);
                SolidBrush drawBrush = new SolidBrush(Color.Black);
                var format = new StringFormat();
                format.Alignment = StringAlignment.Far;


                var shift = (int)(yukseklik * 0.10);
                // Create point for upper-left corner of drawing.
                var drawRect = new RectangleF(2, shift, (int)(genislik * .95), yukseklik / satirAdet);
                // Draw string to screen.
                graphics.DrawString(sayilarGorunsun ? sayi1.ToString() : ".....", drawFont, drawBrush, drawRect, format);

                shift += satirYukseklik;

                drawRect = new RectangleF(2, shift, (int)(genislik * .95), satirYukseklik - 5);
                graphics.DrawString(sayilarGorunsun ? sayi2.ToString() : ".....", drawFont, drawBrush, drawRect, format);

                graphics.DrawString("x", drawFont, drawBrush, 2, shift + (int)(satirYukseklik * 0.15));

                shift += satirYukseklik - 5;


                graphics.DrawLine(new Pen(Color.Black, 2), new Point(5, shift), new Point(genislik - 4, shift));
                shift += 5;

                if (satirAdet >= 5)
                {
                    var s = 0;
                    for (int i = sayi2.ToString().Length - 1; i >= 0; i--)
                    {
                        var rakam = Convert.ToInt32(sayi2.ToString().Substring(i, 1));
                        drawRect = new RectangleF(2, shift, (int)(genislik * .95) - (int)(s * genislik / 7.7), satirYukseklik - 5);
                        graphics.DrawString(sayilarGorunsun ? (sayi1 * rakam).ToString() : ".....", drawFont, drawBrush, drawRect, format);
                        s++;
                        shift += satirYukseklik;
                    }

                    graphics.DrawString("+", drawFont, drawBrush, 2, shift - (int)(satirYukseklik * 0.75));
                    graphics.DrawLine(new Pen(Color.Black, 2), new Point(5, shift), new Point(genislik - 4, shift));
                    shift += 5;
                }

                drawRect = new RectangleF(2, shift, (int)(genislik * .95), satirYukseklik - 5);
                graphics.DrawString(sonucGorunsun ? (sayi1 * sayi2).ToString() : ".....", drawFont, drawBrush, drawRect, format);
                graphics.Flush();

            }
            return sonuc;
        }
        public static CiktiResim MatematikResimUret(string satir1, string islem, string satir2, string sonucSatir, int genislik, int yukseklik)
        {
            var fontBoyut = (45f * yukseklik) / 350f;
            //var yaziBoyu = resimBoyut /3-5;

            var sonuc = new CiktiResim
            {
                Image = new Bitmap(genislik, yukseklik, PixelFormat.Format32bppArgb),
            };
            using (var graphics = KanavaGetir(sonuc.Image))
            {
                graphics.DrawLine(new Pen(Color.LimeGreen, 2), new Point(1, 1), new Point(genislik - 1, 1));
                graphics.DrawLine(new Pen(Color.LimeGreen, 2), new Point(1, 1), new Point(1, yukseklik - 1));
                graphics.DrawLine(new Pen(Color.LimeGreen, 2), new Point(1, yukseklik - 1), new Point(genislik - 1, yukseklik - 1));
                graphics.DrawLine(new Pen(Color.LimeGreen, 2), new Point(genislik - 1, 1), new Point(genislik - 1, yukseklik - 1));


                // Create font and brush.
                Font drawFont = new Font("Arial", fontBoyut, FontStyle.Regular);
                SolidBrush drawBrush = new SolidBrush(Color.Black);
                var format = new StringFormat();
                format.Alignment = StringAlignment.Far;


                var shift = (int)(yukseklik * 0.10);
                // Create point for upper-left corner of drawing.
                var drawRect = new RectangleF(2, shift, (int)(genislik * .95), yukseklik / 3);
                // Draw string to screen.
                graphics.DrawString(satir1, drawFont, drawBrush, drawRect, format);

                shift += yukseklik / 3;

                drawRect = new RectangleF(2, shift, (int)(genislik * .95), yukseklik / 3 - 5);
                graphics.DrawString(satir2, drawFont, drawBrush, drawRect, format);

                graphics.DrawString(islem, drawFont, drawBrush, 2, shift + 10);


                shift += yukseklik / 3 - 20;
                graphics.DrawLine(new Pen(Color.Black, 2), new Point(5, shift), new Point(genislik - 4, shift));

                shift += (int)(yukseklik * .10);

                drawRect = new RectangleF(2, shift, (int)(genislik * .95), yukseklik / 3 - 5);
                graphics.DrawString(sonucSatir, drawFont, drawBrush, drawRect, format);
                graphics.Flush();

            }
            return sonuc;
        }

        public static CiktiResim ParaResimUret(int tutar, int resimBoyut)
        {
            #region Gereken para sayisini hesapla

            var banknotList = new List<int> {1000000,
                                              500000,
                                              250000,
                                              100000,
                                               50000,
                                               20000,
                                               10000,
                                                5000,
                                                1000,
                                                 500,
                                                 200,
                                                 100,
                                                  50,
                                                  20,
                                                  10,
                                                   5,
                                                   1 };
            var kalan = tutar;
            var paraList = new Dictionary<string, int>();

            foreach (var banknot in banknotList)
            {
                if (kalan >= banknot)
                {
                    var para = kalan / banknot;
                    paraList.Add(banknot.ToString(), para);
                    kalan -= para * banknot;
                }
                else if (kalan == 0)
                {
                    break;
                }
            }


            #endregion

            var sonuc = new CiktiResim
            {
                Image = new Bitmap(resimBoyut, resimBoyut, PixelFormat.Format32bppArgb),
                ParcaList = paraList
            };
            using (var graphics = KanavaGetir(sonuc.Image))
            {

                var shift = 3;
                foreach (var parca in paraList)
                {
                    if (Convert.ToInt32(parca.Key) > 5000)
                    {
                        for (int i = 0; i < parca.Value; i++)
                        {
                            graphics.DrawImage(ParaResimUret(parca.Key), new Rectangle(3, shift, resimBoyut - 7, (int)(resimBoyut * 0.4775)));
                            shift += (int)(resimBoyut * 0.1);
                        }
                        shift += (int)(resimBoyut * 0.05);
                    }
                    if (Convert.ToInt32(parca.Key) <= 5000 && Convert.ToInt32(parca.Key) > 50)
                    {
                        for (int i = 0; i < parca.Value; i++)
                        {
                            graphics.DrawImage(ParaResimUret(parca.Key), new Rectangle(3, shift, (int)(resimBoyut * .94), (int)(resimBoyut * 0.465)));
                            shift += (int)(resimBoyut * 0.1);
                        }
                        shift += (int)(resimBoyut * 0.05);
                    }
                    else if (parca.Key == "50" || parca.Key == "20")
                    {
                        for (int i = 0; i < parca.Value; i++)
                        {
                            graphics.DrawImage(ParaResimUret(parca.Key), new Rectangle(3, shift, (int)(resimBoyut * 0.92), (int)(resimBoyut * 0.456)));
                            shift += (int)(resimBoyut * 0.1);
                        }
                        shift += (int)(resimBoyut * 0.05);
                    }
                    else if (parca.Key == "10" || parca.Key == "5")
                    {
                        for (int i = 0; i < parca.Value; i++)
                        {
                            graphics.DrawImage(ParaResimUret(parca.Key), new Rectangle(3, shift, (int)(resimBoyut * 0.851), (int)(resimBoyut * 0.412)));
                            shift += (int)(resimBoyut * 0.1);
                        }
                        shift += (int)(resimBoyut * 0.05);
                    }
                    else//Eger bir lira ise
                    {
                        var paraBoyut = (int)(resimBoyut * 0.25);
                        var shiftX = (int)(resimBoyut * 0.1);
                        shift = resimBoyut - paraBoyut - 8;
                        for (int i = 0; i < parca.Value; i++)
                        {
                            graphics.DrawImage(ParaResimUret(parca.Key), new Rectangle(shiftX, shift, paraBoyut, paraBoyut));
                            shiftX += (int)(resimBoyut * 0.1);
                        }
                    }
                }

                graphics.DrawLine(new Pen(Color.OrangeRed, 2), new Point(1, 1), new Point(resimBoyut - 1, 1));
                graphics.DrawLine(new Pen(Color.OrangeRed, 2), new Point(1, 1), new Point(1, resimBoyut - 1));
                graphics.DrawLine(new Pen(Color.OrangeRed, 2), new Point(1, resimBoyut - 1), new Point(resimBoyut - 1, resimBoyut - 1));
                graphics.DrawLine(new Pen(Color.OrangeRed, 2), new Point(resimBoyut - 1, 1), new Point(resimBoyut - 1, resimBoyut - 1));

                graphics.Flush();
            }
            return sonuc;
        }

        public static Color RenkGuncelle(Color pixel, float redYuzde, float greenYuzde, float blueYuzde)
        {
            var yeniRed = (byte)((int)(pixel.R + byte.MaxValue * redYuzde) > byte.MaxValue ? byte.MaxValue : pixel.R + byte.MaxValue * redYuzde);
            var yeniGreen = (byte)((int)(pixel.G + byte.MaxValue * greenYuzde) > byte.MaxValue ? byte.MaxValue : pixel.G + byte.MaxValue * greenYuzde);
            var yeniBlue = (byte)((int)(pixel.B + byte.MaxValue * blueYuzde) > byte.MaxValue ? byte.MaxValue : pixel.B + byte.MaxValue * blueYuzde);
            return Color.FromArgb(pixel.A, yeniRed, yeniGreen, yeniBlue);
        }
        public static Image KonturAt(Image image, int resimBoyut, float redYuzde, float greenYuzde, float blueYuzde)
        {
            var bmp = new Bitmap(image, resimBoyut, resimBoyut);

            int w = bmp.Width;
            int h = bmp.Height;

            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    var eskiRenk = bmp.GetPixel(x, y);
                    bmp.SetPixel(x, y, RenkGuncelle(eskiRenk, redYuzde, greenYuzde, blueYuzde));
                }
            }

            //Lst_Data lastpointcolor = new Lst_Data();

            //for (int y = 0; y < h; y++)
            //{
            //    for (int x = 0; x < w; x++)
            //    {
            //        Color c = bmp.GetPixel(x, y);
            //        if (c.A != Color.Transparent.A)
            //        {
            //            if (lastpointcolor.color.A == Color.Transparent.A)
            //            {
            //                bmp.SetPixel(lastpointcolor.point.X, lastpointcolor.point.Y, renk);
            //            }
            //        }
            //        var currColor = bmp.GetPixel(x, y);
            //        lastpointcolor = new Lst_Data() { point = new Point(x, y), color =  RenkGuncelle(currColor, redYuzde, greenYuzde, blueYuzde)};
            //    }
            //}

            //for (int y = h - 1; y > 0; y--)
            //{
            //    for (int x = w - 1; x > 0; x--)
            //    {
            //        Color c = bmp.GetPixel(x, y);
            //        if (c.A != Color.Transparent.A)
            //        {
            //            if (lastpointcolor.color.A == Color.Transparent.A)
            //            {
            //                bmp.SetPixel(lastpointcolor.point.X, lastpointcolor.point.Y, renk);
            //            }
            //        }
            //        var currColor = bmp.GetPixel(x, y);
            //        lastpointcolor = new Lst_Data() { point = new Point(x, y), color = RenkGuncelle(currColor, redYuzde, greenYuzde, blueYuzde) };
            //    }
            //}
            return bmp;
        }


        /// <summary>
        /// Dogru Cevaba ait resimden Celdirici uretir.
        /// </summary>
        /// <param name="havuz">Resmin uretilecegi havuz</param>
        /// <param name="resim">Degistirilecek Resim</param>
        /// <param name="resim">Degistirilecek Resim</param>
        /// <param name="degisecekParcalar">Degisecek parcalarin isimleri</param>
        /// <param name="degisecekParcaAdet">degisecek parca adedi</param>
        /// <returns>Yeni celdirici Resmi dondurur.</returns>
        public static CiktiResim ResimDegistirUret(Havuz.Havuz havuz, CiktiResim resim, List<string> degisecekParcalar, int resimBoyut)
        {
            var sonuc = new CiktiResim { Image = new Bitmap(resimBoyut, resimBoyut, PixelFormat.Format32bppArgb) };
            var degisenAdet = 0;



            using (var graphics = KanavaGetir(sonuc.Image))
            {

                foreach (var parca in havuz.ParcaList.OrderBy(s => s.Sira))
                {
                    int id = resim.ParcaList[parca.Ad];


                    if (degisecekParcalar.Any(s => s == parca.Ad))
                    {
                        id = RandomHelper.RandomDifferentNumber(0, parca.ResimList.Count - 1, id);
                        degisenAdet++;
                    }
                    sonuc.ParcaList.Add(parca.Ad, id);

                    graphics.DrawImage(parca.ResimList[id].Nesne, new Rectangle(0, 0, resimBoyut, resimBoyut));
                }
                graphics.Flush();
            }
            return sonuc;
        }

        /// <summary>
        /// Verilen Havuzun, parcaList argumani ile verilen listedeki tum parcalarini kullanarak resim uretir.
        /// </summary>
        /// <param name="havuz">Resim uretilecek Havuz</param>
        /// <param name="parcaList">Resim uretilecek parcalar ve degerleri</param>
        /// <returns>Uretilen resim geri doner.</returns>
        public static CiktiResim ResimUret(Havuz.Havuz havuz, Dictionary<string, int> resim1, Dictionary<string, int> resim2, int resimBoyut)
        {
            var resimGenislik = resimBoyut * 2;
            var sonuc = new CiktiResim { Image = new Bitmap(resimGenislik, resimBoyut, PixelFormat.Format32bppArgb) };

            using (var graphics = KanavaGetir(sonuc.Image))
            {
                var shift = 1;
                graphics.DrawImage(ResimUret(havuz, resim1, resimBoyut).Image, new Rectangle(1, 1, resimBoyut - 1, resimBoyut - 1));
                shift += resimBoyut;
                graphics.DrawImage(ResimUret(havuz, resim2, resimBoyut).Image, new Rectangle(shift, 1, resimBoyut - 1, resimBoyut - 1));

                graphics.Flush();
            }

            sonuc.ParcaList = resim1;
            sonuc.DigerResimParcaList = resim2;
            return sonuc;
        }


        /// <summary>
        /// Verilen Havuzun, parcaList argumani ile verilen listedeki tum parcalarini kullanarak resim uretir.
        /// </summary>
        /// <param name="havuz">Resim uretilecek Havuz</param>
        /// <param name="parcaList">Resim uretilecek parcalar ve degerleri</param>
        /// <returns>Uretilen resim geri doner.</returns>
        public static CiktiResim ResimUret(Havuz.Havuz havuz, Dictionary<string, int> parcaList, int resimBoyut)
        {
            var sonuc = new CiktiResim { Image = new Bitmap(resimBoyut, resimBoyut, PixelFormat.Format32bppArgb) };
            using (var graphics = KanavaGetir(sonuc.Image))
            {

                foreach (var parca in havuz.ParcaList.OrderBy(s => s.Sira))
                {
                    if (parcaList.ContainsKey(parca.Ad))
                    {
                        var id = parcaList[parca.Ad];
                        sonuc.ParcaList.Add(parca.Ad, id);

                        graphics.DrawImage(parca.ResimList[id].Nesne, new Rectangle(0, 0, resimBoyut, resimBoyut));
                    }

                }
                graphics.Flush();
            }
            return sonuc;
        }

        /// <summary>
        /// Verilen Havuzun, parcaList argumani ile verilen listedeki tum parcalarini kullanarak resim uretir.
        /// Ancak Parcalari verilen acilar kadar dondurur.
        /// </summary>
        /// <param name="havuz">Resim uretilecek Havuz</param>
        /// <param name="parcaList">Resim uretilecek parcalar ve degerleri</param>
        /// <param name="resimBoyut">Uretilecek resmin boyutu</param>
        /// <returns>Uretilen resim geri doner.</returns>
        public static CiktiResim ResimUret(Havuz.Havuz havuz, List<ParcaAci> parcaList, int resimBoyut)
        {

            var sonuc = new CiktiResim { Image = new Bitmap(resimBoyut, resimBoyut, PixelFormat.Format32bppArgb) };
            using (var graphics = KanavaGetir(sonuc.Image))
            {

                foreach (var parca in havuz.ParcaList.OrderBy(s => s.Sira))
                {

                    var seciliParca = parcaList.FirstOrDefault(p => p.Ad == parca.Ad);
                    if (seciliParca != null && string.IsNullOrEmpty(seciliParca.Ad) == false)
                    {
                        var id = seciliParca.Id;
                        sonuc.ParcaList.Add(parca.Ad, id);

                        graphics.DrawImage(parca.ResimList[id].Nesne, new Rectangle(0, 0, resimBoyut, resimBoyut));
                    }

                }
                graphics.Flush();
            }
            return sonuc;
        }

        public static List<ParcaExtent> ParcaExtentGetir(Havuz.Havuz havuz, int resimBoyut)
        {
            var sonuc = new List<ParcaExtent>();
            foreach (var parca in havuz.ParcaList)
            {
                sonuc.Add(new ParcaExtent { Ad = parca.Ad, Extent = GetExtent(parca.ResimList[0].Nesne, resimBoyut) });
            }
            return sonuc;
        }

        private static Rectangle GetExtent(Image resim, int resimBoyut)
        {
            var sonuc = new Rectangle();

            var src = new Bitmap(resim, resimBoyut, resimBoyut);
            Rectangle rect = new Rectangle(0, 0, resimBoyut, resimBoyut);
            var bmpData = src.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            unsafe
            {
                int stride = bmpData.Stride;
                byte* p;
                byte* pIn = (byte*)bmpData.Scan0.ToPointer();
                int A, minX = 100000, minY = 100000, maxX = -1, maxY = -1;

                for (int y = 0; y < bmpData.Height; y++)
                {
                    for (int x = 0; x < bmpData.Width; x++)
                    {
                        p = pIn;
                        A = p[0];
                        if (A != 0)
                        {


                            if (minX > x)
                            {
                                minX = x;
                            }
                            if (minY > y)
                            {
                                minY = y;
                            }

                            if (maxX < x)
                            {
                                maxX = x;
                            }
                            if (maxY < y)
                            {
                                maxY = y;
                            }

                        }
                        pIn += 4;
                    }
                    pIn += stride - src.Width * 4;
                }
                var size = new Size(maxX - minX, maxY - minY);
                sonuc = new Rectangle(new Point(minX, minY), size);
            }
            src.UnlockBits(bmpData);
            return sonuc;
        }

        // Using two valued image ， Black background in image ， White represents the target 
        // Define the center of mass calculation function 
        private static Point CenterPoint(Bitmap src)
        {
            // Defines an array variable that stores a centroid coordinate 
            var CentreP = new Point();
            int M00 = 0, M01 = 0, M10 = 0;
            Rectangle rect = new Rectangle(0, 0, src.Width, src.Height);
            var bmpData = src.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            unsafe
            {
                int stride = bmpData.Stride;
                byte* p;
                byte* pIn = (byte*)bmpData.Scan0.ToPointer();
                int R, G, B;
                for (int y = 0; y < src.Height; y++)
                {
                    for (int x = 0; x < src.Width; x++)
                    {
                        p = pIn;
                        R = p[2];
                        G = p[1];
                        B = p[0];
                        if (R + G + B != 0)
                        {
                            M00++;
                            M01 += y;
                            M10 += x;
                        }
                        pIn += 3;
                    }
                    pIn += stride - src.Width * 3;
                }
                CentreP.X = (int)(M10 / M00);
                CentreP.Y = (int)(M01 / M00);
            }
            src.UnlockBits(bmpData);
            return CentreP;
            // Returns an array ， The first element in the array is centroid X coordinate ，
            // The second element is the center of mass. Y coordinate 
        }

        /// <summary>
        /// Verilen Havuzun, parcaList argumani ile verilen listedeki tum parcalarini kullanarak resim uretir.
        /// </summary>
        /// <param name="havuz">Resim uretilecek Havuz</param>
        /// <param name="parcaList">Resim uretilecek parcalar ve degerleri</param>
        /// <param name="renkList">Renklendirilecek parcalar. Parca adi ve parcanin rengi, true ise turuncu, false ise mavi</param>
        /// <returns>Uretilen resim geri doner.</returns>
        public static CiktiResim ResimUret(Havuz.Havuz havuz, Dictionary<string, int> parcaList, Dictionary<string, bool> renkList, int resimBoyut)
        {
            var sonuc = new CiktiResim { Image = new Bitmap(resimBoyut, resimBoyut, PixelFormat.Format32bppArgb) };
            using (var graphics = KanavaGetir(sonuc.Image))
            {

                foreach (var parca in havuz.ParcaList.OrderBy(s => s.Sira))
                {
                    if (parcaList.ContainsKey(parca.Ad))
                    {
                        var id = parcaList[parca.Ad];
                        sonuc.ParcaList.Add(parca.Ad, id);
                        if (renkList.ContainsKey(parca.Ad))
                        {
                            if (renkList[parca.Ad]) //True ise Turuncu
                            {
                                graphics.DrawImage(KonturAt(parca.ResimList[id].Nesne, resimBoyut, 1f, 0.15f, 0.15f),
                                    new Rectangle(0, 0, resimBoyut, resimBoyut));

                            }
                            else
                            {
                                graphics.DrawImage(KonturAt(parca.ResimList[id].Nesne, resimBoyut, 0.15f, 1f, 0.15f),
                                    new Rectangle(0, 0, resimBoyut, resimBoyut));

                            }

                        }
                        else
                        {
                            graphics.DrawImage(parca.ResimList[id].Nesne, new Rectangle(0, 0, resimBoyut, resimBoyut));
                        }
                    }

                }
                graphics.Flush();
            }
            return sonuc;
        }

        /// <summary>
        /// Verilen Havuzun tum parcalarini kullanarak rastgele resim uretir.
        /// </summary>
        /// <param name="havuz">Resim uretilecek Havuz</param>
        /// <returns>Uretilen resim geri doner.</returns>
        public static CiktiResim RasgeleResimUret(Havuz.Havuz havuz, int resimBoyut)
        {
            var sonuc = new CiktiResim { Image = new Bitmap(resimBoyut, resimBoyut, PixelFormat.Format32bppArgb) };
            using (var graphics = KanavaGetir(sonuc.Image))
            {

                foreach (var parca in havuz.ParcaList.OrderBy(s => s.Sira))
                {
                    var id = RandomHelper.RandomNumber(0, parca.ResimList.Count - 1);
                    sonuc.ParcaList.Add(parca.Ad, id);

                    graphics.DrawImage(parca.ResimList[id].Nesne, new Rectangle(0, 0, resimBoyut, resimBoyut));
                }
                graphics.Flush();
            }
            return sonuc;
        }


        /// <summary>
        /// Verilen Havuzun tum parcalarini kullanarak rastgele resim uretir. Resmi olusturan parcalarin
        /// id lerini barindiran bir dictionary doner. 
        /// </summary>
        /// <param name="havuz">Resim uretilecek Havuz</param>
        /// <returns>Uretilen resmin parca ad ve idlerinden olan dictionary geri doner.</returns>
        public static Dictionary<string, int> RasgeleResimUret(Havuz.Havuz havuz)
        {
            var sonuc = new Dictionary<string, int>();

            foreach (var parca in havuz.ParcaList.OrderBy(s => s.Sira))
            {
                var id = RandomHelper.RandomNumber(0, parca.ResimList.Count - 1);
                sonuc.Add(parca.Ad, id);
            }
            return sonuc;
        }

        public static CiktiResim RasgeleFarkliResimUret(Havuz.Havuz havuz, List<Dictionary<string, int>> eskiResimList, int resimBoyut)
        {
            var sonuc = new CiktiResim { Image = new Bitmap(resimBoyut, resimBoyut, PixelFormat.Format32bppArgb) };
            using (var graphics = KanavaGetir(sonuc.Image))
            {

                foreach (var parca in havuz.ParcaList.OrderBy(s => s.Sira))
                {
                    var parcaIdList = new List<int>();
                    foreach (var resim in eskiResimList)
                    {
                        parcaIdList.Add(resim[parca.Ad]);
                    }
                    var id = RandomHelper.RandomDifferentNumber(0, parca.ResimList.Count - 1, parcaIdList.ToArray());
                    sonuc.ParcaList.Add(parca.Ad, id);

                    graphics.DrawImage(parca.ResimList[id].Nesne, new Rectangle(0, 0, resimBoyut, resimBoyut));
                }
                graphics.Flush();
            }
            return sonuc;
        }



        /// <summary>
        /// Verilen Havuzun, parcaList ile verilen parcalarini kullanarak rastgele resim uretir.
        /// </summary>
        /// <param name="havuz">Resim uretilecek Havuz</param>
        /// <param name="parcaList">Resim uretilecek parca adlari listesi</param>
        /// <returns>Uretilen resim geri doner.</returns>
        public static CiktiResim RasgeleResimUret(Havuz.Havuz havuz, List<string> parcaList, int resimBoyut)
        {
            var sonuc = new CiktiResim { Image = new Bitmap(resimBoyut, resimBoyut, PixelFormat.Format32bppArgb) };
            using (var graphics = KanavaGetir(sonuc.Image))
            {

                foreach (var parca in havuz.ParcaList.OrderBy(s => s.Sira))
                {
                    if (parcaList.Contains(parca.Ad))
                    {
                        var id = RandomHelper.RandomNumber(0, parca.ResimList.Count - 1);
                        sonuc.ParcaList.Add(parca.Ad, id);

                        graphics.DrawImage(parca.ResimList[id].Nesne, new Rectangle(0, 0, resimBoyut, resimBoyut));
                    }

                }
                graphics.Flush();
            }
            return sonuc;
        }

        /// <summary>
        /// Referans resmin belirtilen parcalarini, yine belirtilen parcalarla degistirir
        /// </summary>
        /// <param name="havuz">Resim uretiminde kullanilacak havuz</param>
        /// <param name="referansResim">Referans resim</param>
        /// <param name="zorlukSeviye">En fazla donusum adedi</param>
        /// <param name="donusecekParcalar">Donusecek parcalarin isim listesi</param>
        /// <param name="donusumParcalari">Donusum Parca Listesi</param>
        /// <returns>Donusumleri iceren resim doner.</returns>
        public static CiktiResim DonusumResmiUret(CiktiResim referansResim, int zorlukSeviye, List<string> donusecekParcalar, List<Parca> donusumParcalari, int resimBoyut)
        {
            var resimEn = resimBoyut / 3;
            var isaretEn = resimEn / 2;

            var sonuc = new CiktiResim { Image = new Bitmap(resimEn * 2 + isaretEn, resimEn * zorlukSeviye, PixelFormat.Format32bppArgb) };

            using (var graphics = KanavaGetir(sonuc.Image))
            {

                int i = 0;

                foreach (var parca in donusumParcalari.OrderBy(s => s.Sira))
                {
                    if (donusecekParcalar.Contains(parca.Ad))
                    {
                        int id;
                        referansResim.ParcaList.TryGetValue(parca.Ad, out id);

                        var newId = RandomHelper.RandomDifferentNumber(0, parca.ResimList.Count - 1, id);

                        sonuc.DonusumList.Add(parca.Ad, newId);

                        var shift = 1;

                        graphics.DrawImage(parca.DonusumResimList[id].Nesne, new Rectangle(shift, resimEn * i, resimEn - 1, resimEn - 1));

                        shift += resimEn;

                        graphics.DrawImage(OkResmiUret(), new Rectangle(shift, resimEn * i + resimEn / 4, isaretEn, isaretEn));

                        shift += isaretEn;
                        graphics.DrawImage(parca.DonusumResimList[newId].Nesne, new Rectangle(shift, resimEn * i, resimEn - 1, resimEn - 1));
                        i++;
                    }
                }
                graphics.Flush();
            }
            return sonuc;
        }

        /// <summary>
        /// Belirtilen resme, yine belirtilen donusum listesini uygular.
        /// </summary>
        /// <param name="havuz">Resmin uretilecegi Havuz</param>
        /// <param name="resim">Donusum uygulanacak resim</param>
        /// <param name="donusumResim">donusum parcalari</param>
        /// <param name="resimBoyut">pixel cinsinden resmin en ve boyu</param>
        /// <returns>Donusturulmus resmi doner.</returns>
        public static CiktiResim DonusumListesiUygula(Havuz.Havuz havuz, CiktiResim resim, CiktiResim donusumResim, int resimBoyut)
        {
            var sonuc = new CiktiResim { Image = new Bitmap(resimBoyut, resimBoyut, PixelFormat.Format32bppArgb) };
            using (var graphics = KanavaGetir(sonuc.Image))
            {

                foreach (var parca in havuz.ParcaList.OrderBy(s => s.Sira))
                {
                    var id = resim.ParcaList[parca.Ad];

                    if (donusumResim.DonusumList.ContainsKey(parca.Ad))
                    {
                        id = donusumResim.DonusumList[parca.Ad];
                    }
                    sonuc.ParcaList.Add(parca.Ad, id);

                    graphics.DrawImage(parca.ResimList[id].Nesne, new Rectangle(0, 0, resimBoyut, resimBoyut));
                }
                sonuc.DonusumList = donusumResim.DonusumList;
                graphics.Flush();
            }
            return sonuc;
        }

        /// <summary>
        /// Belirtilen resme, yine belirtilen donusum listesini uygular. 
        /// Ancak Zorluk seviyesi kadar parcayi referans resimle ayni birakir.
        /// </summary>
        /// <param name="havuz">Resmin uretilecegi Havuz</param>
        /// <param name="resim">Donusum uygulanacak resim</param>
        /// <param name="donusumResim">donusum parcalari</param>
        /// <param name="zorlukSeviye"></param>
        /// <param name="resimBoyut">pixel cinsinden resmin en ve boyu</param>
        /// <returns>Donusturulmus resmi doner.</returns>
        public static CiktiResim DonusumListesiUygula(Havuz.Havuz havuz, CiktiResim resim, CiktiResim donusumResim, int degisecekParcaAdet, int resimBoyut)
        {
            var sonuc = new CiktiResim { Image = new Bitmap(resimBoyut, resimBoyut, PixelFormat.Format32bppArgb) };
            var degisecekParcalar = DegisecekParcaUret(degisecekParcaAdet, donusumResim.DonusumList.Keys.ToList());
            using (var graphics = KanavaGetir(sonuc.Image))
            {

                foreach (var parca in havuz.ParcaList.OrderBy(s => s.Sira))
                {
                    var id = resim.ParcaList[parca.Ad];

                    if (degisecekParcalar.Contains(parca.Ad))
                    {
                        id = donusumResim.DonusumList[parca.Ad];
                    }
                    sonuc.ParcaList.Add(parca.Ad, id);

                    graphics.DrawImage(parca.ResimList[id].Nesne, new Rectangle(0, 0, resimBoyut, resimBoyut));
                }

                graphics.Flush();
            }
            return sonuc;
        }
        public static CiktiResim KuraliBulUygulaReferansUret(List<CiktiResim> referansResimList, int[] ikililer, int resimBoyut)
        {
            var sonuc = new CiktiResim();
            var isaretGenislik = resimBoyut / 3 - 1;
            var resimGenislik = resimBoyut + isaretGenislik + resimBoyut + isaretGenislik + resimBoyut;
            sonuc.Image = new Bitmap(resimGenislik, resimBoyut, PixelFormat.Format32bppArgb);

            var a = referansResimList[ikililer[0]];
            var b = referansResimList[ikililer[1]];

            using (var graphics = KanavaGetir(sonuc.Image))
            {
                var shift = 1;
                graphics.DrawImage(a.Image, new Rectangle(shift, 1, resimBoyut - 1, resimBoyut - 1));
                shift += resimBoyut;

                graphics.DrawImage(YildizResmiUret(), new Rectangle(shift, resimBoyut / 3, isaretGenislik, isaretGenislik));

                shift += isaretGenislik;

                graphics.DrawImage(b.Image, new Rectangle(shift, 1, resimBoyut - 1, resimBoyut - 1));

                shift += resimBoyut;

                graphics.DrawImage(OkResmiUret(), new Rectangle(shift, resimBoyut / 3, isaretGenislik, isaretGenislik));

                shift += isaretGenislik;
                if (a.Derece > b.Derece)
                {
                    graphics.DrawImage(a.Image, new Rectangle(shift, 1, resimBoyut - 1, resimBoyut - 1));

                }
                else
                {
                    graphics.DrawImage(b.Image, new Rectangle(shift, 1, resimBoyut - 1, resimBoyut - 1));

                }
            }
            return sonuc;
        }

        public static CiktiResim KuraliBulUygulaSoruUret(List<CiktiResim> referansResimList, int[] ikililer, out CiktiResim dogruCevap, out CiktiResim celdiriciResim, int resimBoyut)
        {
            var sonuc = new CiktiResim();
            var isaretGenislik = resimBoyut / 3 - 1;
            var resimGenislik = resimBoyut + isaretGenislik + resimBoyut + isaretGenislik + resimBoyut;
            sonuc.Image = new Bitmap(resimGenislik, resimBoyut, PixelFormat.Format32bppArgb);

            var a = referansResimList[ikililer[0]];
            var b = referansResimList[ikililer[1]];

            using (var graphics = KanavaGetir(sonuc.Image))
            {
                var shift = 1;
                graphics.DrawImage(a.Image, new Rectangle(shift, 1, resimBoyut - 1, resimBoyut - 1));
                shift += resimBoyut;


                graphics.DrawImage(YildizResmiUret(), new Rectangle(shift, resimBoyut / 3, isaretGenislik, isaretGenislik));

                shift += isaretGenislik;


                graphics.DrawImage(b.Image, new Rectangle(shift, 1, resimBoyut - 1, resimBoyut - 1));

                shift += resimBoyut;

                graphics.DrawImage(OkResmiUret(), new Rectangle(shift, resimBoyut / 3, isaretGenislik, isaretGenislik));

                shift += isaretGenislik;

                if (a.Derece > b.Derece)
                {
                    dogruCevap = a;
                    celdiriciResim = b;
                }
                else
                {
                    dogruCevap = b;
                    celdiriciResim = a;

                }

                graphics.DrawImage(SoruIsaretResmiUret(), new Rectangle(shift, 1, resimBoyut - 1, resimBoyut - 1));
            }
            return sonuc;
        }

        public static CiktiResim MelezResimUret(CiktiResim resim, string islemMetin, int resimBoyut, int maxMetinLen)
        {
            var yaziBoyu = 80f / maxMetinLen * resimBoyut / 90f;
            var sonuc = new CiktiResim { Image = new Bitmap(resimBoyut, resimBoyut + (int)(yaziBoyu * 1.33f), PixelFormat.Format32bppArgb) };
            foreach (var parca in resim.ParcaList)
            {
                sonuc.ParcaList.Add(parca.Key, parca.Value);
            }

            using (var graphics = KanavaGetir(sonuc.Image))
            {

                graphics.DrawImage(resim.Image, new Rectangle(1, 1, resimBoyut - 2, resimBoyut - 2));

                // Create font and brush.
                Font drawFont = new Font("Arial", yaziBoyu, FontStyle.Regular);
                SolidBrush drawBrush = new SolidBrush(Color.Black);
                var format = new StringFormat();
                format.Alignment = StringAlignment.Center;

                // Create point for upper-left corner of drawing.
                var drawRect = new RectangleF(10, resimBoyut + 1, resimBoyut, yaziBoyu * 3);

                // Draw string to screen.
                graphics.DrawString(islemMetin, drawFont, drawBrush, drawRect, format);
                graphics.Flush();
            }
            return sonuc;
        }
        public static CiktiResim IslemResimUret(Havuz.Havuz havuz, Dictionary<string, int> resim1,
           Dictionary<string, int> resim2, Dictionary<string, int> resim3, Dictionary<string, int> resimSonuc, int resimBoyut)
        {
            var isaretGenislik = resimBoyut / 3 - 1;
            var resimGenislik = resimBoyut + isaretGenislik + resimBoyut + isaretGenislik + resimBoyut + isaretGenislik + resimBoyut;

            var sonuc = new CiktiResim { Image = new Bitmap(resimGenislik, resimBoyut, PixelFormat.Format32bppArgb) };

            using (var graphics = KanavaGetir(sonuc.Image))
            {
                var shift = 1;
                graphics.DrawImage(ResimUret(havuz, resim1, resimBoyut).Image, new Rectangle(1, 1, resimBoyut - 2, resimBoyut - 2));

                shift += resimBoyut;

                graphics.DrawImage(YildizResmiUret(), new Rectangle(shift, resimBoyut / 3, isaretGenislik, isaretGenislik));

                shift += isaretGenislik;

                graphics.DrawImage(ResimUret(havuz, resim2, resimBoyut).Image, new Rectangle(shift, 1, resimBoyut - 1, resimBoyut - 1));

                shift += resimBoyut;

                graphics.DrawImage(YildizResmiUret(), new Rectangle(shift, resimBoyut / 3, isaretGenislik, isaretGenislik));

                shift += isaretGenislik;

                graphics.DrawImage(ResimUret(havuz, resim3, resimBoyut).Image, new Rectangle(shift, 1, resimBoyut - 1, resimBoyut - 1));

                shift += resimBoyut;

                graphics.DrawImage(OkResmiUret(), new Rectangle(shift, resimBoyut / 3, isaretGenislik, isaretGenislik));

                shift += isaretGenislik;

                graphics.DrawImage(ResimUret(havuz, resimSonuc, resimBoyut).Image, new Rectangle(shift, 1, resimBoyut - 1, resimBoyut - 1)); graphics.Flush();
            }
            return sonuc;
        }

        public static CiktiResim IslemResimUret(Havuz.Havuz havuz, Dictionary<string, int> resim1,
           Dictionary<string, int> resim2, Dictionary<string, int> resim3, Dictionary<string, int> resimSonuc, bool buyukMu, int resimBoyut)
        {
            var isaretGenislik = resimBoyut / 3 - 1;
            var resimGenislik = resimBoyut + isaretGenislik + resimBoyut + isaretGenislik + resimBoyut + isaretGenislik + resimBoyut;

            var sonuc = new CiktiResim { Image = new Bitmap(resimGenislik, resimBoyut, PixelFormat.Format32bppArgb) };

            using (var graphics = KanavaGetir(sonuc.Image))
            {
                var shift = 1;
                graphics.DrawImage(ResimUret(havuz, resim1, resimBoyut).Image, new Rectangle(1, 1, resimBoyut - 2, resimBoyut - 2));

                shift += resimBoyut;

                graphics.DrawImage(YildizResmiUret(), new Rectangle(shift, resimBoyut / 3, isaretGenislik, isaretGenislik));

                shift += isaretGenislik;

                graphics.DrawImage(ResimUret(havuz, resim2, resimBoyut).Image, new Rectangle(shift, 1, resimBoyut - 1, resimBoyut - 1));

                shift += resimBoyut;

                graphics.DrawImage(buyukMu ? UpResmiUret() : DownResmiUret(),
                   new Rectangle(shift, resimBoyut / 3, isaretGenislik, isaretGenislik));

                shift += isaretGenislik;

                graphics.DrawImage(ResimUret(havuz, resim3, resimBoyut).Image, new Rectangle(shift, 1, resimBoyut - 1, resimBoyut - 1));

                shift += resimBoyut;

                graphics.DrawImage(OkResmiUret(), new Rectangle(shift, resimBoyut / 3, isaretGenislik, isaretGenislik));

                shift += isaretGenislik;

                graphics.DrawImage(ResimUret(havuz, resimSonuc, resimBoyut).Image, new Rectangle(shift, 1, resimBoyut - 1, resimBoyut - 1)); graphics.Flush();
            }
            return sonuc;
        }
        public static CiktiResim IslemResimUret(Havuz.Havuz havuz, Dictionary<string, int> resim1,
            Dictionary<string, int> resim2, Dictionary<string, int> resimSonuc, int resimBoyut)
        {
            var isaretGenislik = resimBoyut / 3 - 1;
            var resimGenislik = resimBoyut + isaretGenislik + resimBoyut + isaretGenislik + resimBoyut;

            var sonuc = new CiktiResim { Image = new Bitmap(resimGenislik, resimBoyut, PixelFormat.Format32bppArgb) };

            using (var graphics = KanavaGetir(sonuc.Image))
            {
                var shift = 1;
                graphics.DrawImage(ResimUret(havuz, resim1, resimBoyut).Image, new Rectangle(1, 1, resimBoyut - 2, resimBoyut - 2));

                shift += resimBoyut;

                graphics.DrawImage(YildizResmiUret(), new Rectangle(shift, resimBoyut / 3, isaretGenislik, isaretGenislik));

                shift += isaretGenislik;

                graphics.DrawImage(ResimUret(havuz, resim2, resimBoyut).Image, new Rectangle(shift, 1, resimBoyut - 1, resimBoyut - 1));

                shift += resimBoyut;

                graphics.DrawImage(OkResmiUret(), new Rectangle(shift, resimBoyut / 3, isaretGenislik, isaretGenislik));

                shift += isaretGenislik;

                graphics.DrawImage(ResimUret(havuz, resimSonuc, resimBoyut).Image, new Rectangle(shift, 1, resimBoyut - 1, resimBoyut - 1)); graphics.Flush();
            }
            return sonuc;
        }

        public static CiktiResim IslemResimUret(CiktiResim resim1, CiktiResim resim2, int resimBoyut)
        {
            var isaretGenislik = resimBoyut / 3 - 1;
            var resimGenislik = resim1.Image.Width + isaretGenislik + resim2.Image.Width;
            var yukseklik = resim1.Image.Height >= resim2.Image.Height ? resim1.Image.Height : resim2.Image.Height;

            var sonuc = new CiktiResim
            {
                Image = new Bitmap(resimGenislik, yukseklik, PixelFormat.Format32bppArgb),
                ParcaList = resim1.ParcaList,
                DigerResimParcaList = resim2.ParcaList
            };

            using (var graphics = KanavaGetir(sonuc.Image))
            {
                var shift = 1;
                graphics.DrawImage(resim1.Image, new Rectangle(1, 1, resim1.Image.Width - 2, resim1.Image.Height - 2));

                shift += resim1.Image.Width - 2;

                graphics.DrawImage(OkResmiUret(), new Rectangle(shift, resimBoyut / 3, isaretGenislik, isaretGenislik));

                shift += isaretGenislik;

                graphics.DrawImage(resim2.Image, new Rectangle(shift, 1, resim2.Image.Width - 1, resim2.Image.Height - 1));

                graphics.Flush();
            }
            return sonuc;
        }

        public static CiktiResim IslemResimUret(CiktiResim resim1, CiktiResim resim2, CiktiResim sonucResim, CiktiResim matematikResim, int resimBoyut)
        {
            var isaretGenislik = resimBoyut / 3 - 1;
            var resimGenislik = resim1.Image.Width + isaretGenislik + resim2.Image.Width + isaretGenislik + sonucResim.Image.Width + 8 + matematikResim.Image.Width + 3;
            var yukseklik = resim1.Image.Height >= resim2.Image.Height ? resim1.Image.Height : resim2.Image.Height;

            var sonuc = new CiktiResim
            {
                Image = new Bitmap(resimGenislik, yukseklik, PixelFormat.Format32bppArgb),
                ParcaList = resim1.ParcaList,
                DigerResimParcaList = resim2.ParcaList
            };

            using (var graphics = KanavaGetir(sonuc.Image))
            {

                var shift = 10;
                graphics.DrawImage(resim1.Image, new Rectangle(1, 1, resim1.Image.Width - 2, resim1.Image.Height - 2));

                shift += resim1.Image.Width - 2;

                graphics.DrawImage(YildizResmiUret(), new Rectangle(shift, resimBoyut / 3, isaretGenislik, isaretGenislik));

                shift += isaretGenislik;

                graphics.DrawImage(resim2.Image, new Rectangle(shift, 1, resim2.Image.Width - 1, resim2.Image.Height - 1));

                shift += resim2.Image.Width - 2;

                graphics.DrawImage(OkResmiUret(), new Rectangle(shift, resimBoyut / 3, isaretGenislik, isaretGenislik));

                shift += isaretGenislik;

                graphics.DrawImage(sonucResim.Image, new Rectangle(shift, 1, sonucResim.Image.Width - 1, sonucResim.Image.Height - 1));

                shift += sonucResim.Image.Width + 7;

                graphics.DrawImage(matematikResim.Image, new Rectangle(shift, 1, matematikResim.Image.Width - 1, matematikResim.Image.Height - 1));

                graphics.Flush();
            }
            return sonuc;
        }

        public static CiktiResim IslemResimUret(CiktiResim resim1, CiktiResim resim2, CiktiResim sonucResim, int resimBoyut)
        {
            var isaretGenislik = resimBoyut / 3 - 1;
            var resimGenislik = resim1.Image.Width + isaretGenislik + resim2.Image.Width + isaretGenislik + sonucResim.Image.Width;
            var yukseklik = resim1.Image.Height >= resim2.Image.Height ? resim1.Image.Height : resim2.Image.Height;

            var sonuc = new CiktiResim
            {
                Image = new Bitmap(resimGenislik, yukseklik, PixelFormat.Format32bppArgb),
                ParcaList = resim1.ParcaList,
                DigerResimParcaList = resim2.ParcaList
            };

            using (var graphics = KanavaGetir(sonuc.Image))
            {
                var shift = 1;
                graphics.DrawImage(resim1.Image, new Rectangle(1, 1, resim1.Image.Width - 2, resim1.Image.Height - 2));

                shift += resim1.Image.Width - 2;

                graphics.DrawImage(YildizResmiUret(), new Rectangle(shift, resimBoyut / 3, isaretGenislik, isaretGenislik));

                shift += isaretGenislik;

                graphics.DrawImage(resim2.Image, new Rectangle(shift, 1, resim2.Image.Width - 1, resim2.Image.Height - 1));

                shift += resim2.Image.Width - 2;

                graphics.DrawImage(OkResmiUret(), new Rectangle(shift, resimBoyut / 3, isaretGenislik, isaretGenislik));

                shift += isaretGenislik;

                graphics.DrawImage(sonucResim.Image, new Rectangle(shift, 1, sonucResim.Image.Width - 1, sonucResim.Image.Height - 1));

                graphics.Flush();
            }
            return sonuc;
        }

        private static CiktiResim GucluZayifTabloOlustur(Havuz.Havuz havuz, Dictionary<string, int> gucluList,
            Dictionary<string, int> zayifList, int resimBoyut, out int genislik)
        {
            if (gucluList.Count != zayifList.Count)
            {
                throw new Exception("Guclu ve zayif liste sayisi birbirinden farkli olamaz.");
            }
            var yukseklik = resimBoyut * 5;
            int sutunAdet = gucluList.Count / 4 + (gucluList.Count % 4 == 0 ? 0 : 1);
            genislik = resimBoyut * 2 * sutunAdet + (3 + sutunAdet * 6);

            var sonuc = new CiktiResim
            {
                Image = new Bitmap(genislik, yukseklik, PixelFormat.Format32bppArgb)
            };

            var satir = 0;
            var sutun = 0;
            using (var graphics = KanavaGetir(sonuc.Image))
            {
                graphics.DrawLine(new Pen(Color.OrangeRed, 2), new Point(1, 1), new Point(genislik - 1, 1));
                graphics.DrawLine(new Pen(Color.OrangeRed, 2), new Point(1, 1), new Point(1, yukseklik - 1));
                graphics.DrawLine(new Pen(Color.OrangeRed, 2), new Point(1, yukseklik - 1), new Point(genislik - 1, yukseklik - 1));
                graphics.DrawLine(new Pen(Color.OrangeRed, 2), new Point(genislik - 1, 1), new Point(genislik - 1, yukseklik - 1));

                graphics.DrawLine(new Pen(Color.OrangeRed, 2), new Point(2, resimBoyut + 2), new Point(genislik, resimBoyut + 2));
                var gcLst = gucluList.ToList();
                var zfLst = zayifList.ToList();
                for (int i = 0; i < gcLst.Count; i++)
                {
                    var parca1 = havuz.ParcaList.FirstOrDefault(s => s.Ad == gcLst[i].Key);
                    var parca2 = havuz.ParcaList.FirstOrDefault(s => s.Ad == zfLst[i].Key);

                    if (satir == 0)
                    {
                        var gucluKolX = sutun * 2 * resimBoyut + (3 + sutun * 6);
                        var gucluKolY = 2;

                        graphics.DrawImage(GucluKolResmiUret(), new Rectangle(gucluKolX, gucluKolY, resimBoyut - 2, resimBoyut - 2));
                    }


                    var resim1X = sutun * 2 * resimBoyut + (3 + sutun * 6);
                    var resim1Y = (satir + 1) * resimBoyut + (satir > 0 ? 4 : 2);

                    graphics.DrawImage(parca1.DonusumResimList[gcLst[i].Value].Nesne, resim1X, resim1Y, resimBoyut - 2, resimBoyut - 2);

                    if (satir == 0)
                    {
                        var gucluKolX = sutun * 2 * resimBoyut + resimBoyut + (3 + sutun * 6);
                        var gucluKolY = 2;

                        graphics.DrawImage(ZayifKolResmiUret(), new Rectangle(gucluKolX, gucluKolY, resimBoyut - 2, resimBoyut - 2));
                    }

                    var resim2X = sutun * 2 * resimBoyut + resimBoyut + (3 + sutun * 6);
                    var resim2Y = (satir + 1) * resimBoyut + (satir > 0 ? 4 : 2);

                    graphics.DrawImage(parca2.DonusumResimList[zfLst[i].Value].Nesne, resim2X, resim2Y, resimBoyut - 2, resimBoyut - 2);
                    satir++;
                    if (satir == 4)
                    {
                        var cizgiX = resim2X + resimBoyut + 4;
                        graphics.DrawLine(new Pen(Color.OrangeRed, 2), new Point(cizgiX, 2), new Point(cizgiX, yukseklik - 2));
                        sutun++;
                        satir = 0;

                    }
                }

            }

            return sonuc;
        }

        private static CiktiResim GucluZayifTabloOlustur(Havuz.Havuz havuz, List<ParcaFiyat> pahaliList,
             List<ParcaFiyat> ucuzList, int resimBoyut, out int genislik)
        {
            if (ucuzList.Count != pahaliList.Count)
            {
                throw new Exception("Pahali ve ucuz liste sayisi birbirinden farkli olamaz.");
            }
            var yukseklik = resimBoyut * 5;
            int sutunAdet = pahaliList.Count / 4 + (pahaliList.Count % 4 == 0 ? 0 : 1);
            genislik = resimBoyut * 4 * sutunAdet + (3 + sutunAdet * 6);
            var fontBoyut = (28f * genislik) / 350f;

            var sonuc = new CiktiResim
            {
                Image = new Bitmap(genislik, yukseklik, PixelFormat.Format32bppArgb)
            };
            Font drawFont = new Font("Arial", fontBoyut, FontStyle.Regular);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            var format = new StringFormat();
            format.Alignment = StringAlignment.Near;

            var satir = 0;
            var sutun = 0;
            using (var graphics = KanavaGetir(sonuc.Image))
            {
                graphics.DrawLine(new Pen(Color.OrangeRed, 2), new Point(1, 1), new Point(genislik - 1, 1));
                graphics.DrawLine(new Pen(Color.OrangeRed, 2), new Point(1, 1), new Point(1, yukseklik - 1));
                graphics.DrawLine(new Pen(Color.OrangeRed, 2), new Point(1, yukseklik - 1), new Point(genislik - 1, yukseklik - 1));
                graphics.DrawLine(new Pen(Color.OrangeRed, 2), new Point(genislik - 1, 1), new Point(genislik - 1, yukseklik - 1));

                graphics.DrawLine(new Pen(Color.OrangeRed, 2), new Point(2, resimBoyut + 2), new Point(genislik, resimBoyut + 2));
                for (int i = 0; i < pahaliList.Count; i++)
                {
                    var parca1 = havuz.ParcaList.FirstOrDefault(s => s.Ad == pahaliList[i].Ad);
                    var parca2 = havuz.ParcaList.FirstOrDefault(s => s.Ad == ucuzList[i].Ad);

                    if (satir == 0)
                    {
                        var gucluKolX = sutun * 2 * resimBoyut + (3 + sutun * 6);
                        var gucluKolY = 2;

                        graphics.DrawImage(GucluKolResmiUret(), new Rectangle(gucluKolX, gucluKolY, resimBoyut - 2, resimBoyut - 2));
                    }


                    var resim1X = sutun * 2 * resimBoyut + (3 + sutun * 6);
                    var resim1Y = (satir + 1) * resimBoyut + (satir > 0 ? 4 : 2);

                    graphics.DrawImage(parca1.DonusumResimList[pahaliList[i].Id].Nesne, resim1X, resim1Y, resimBoyut - 2, resimBoyut - 2);
                    // Create point for upper-left corner of drawing.
                    var drawRect = new RectangleF(resim1X + resimBoyut + 2, resim1Y, resimBoyut - 2, resimBoyut - 2);
                    // Draw string to screen.
                    graphics.DrawString(pahaliList[i].Fiyat.ToString(), drawFont, drawBrush, drawRect, format);

                    if (satir == 0)
                    {
                        var gucluKolX = sutun * 2 * resimBoyut + resimBoyut + (3 + sutun * 6);
                        var gucluKolY = 2;

                        graphics.DrawImage(ZayifKolResmiUret(), new Rectangle(gucluKolX, gucluKolY, resimBoyut - 2, resimBoyut - 2));
                    }

                    var resim2X = sutun * 2 * resimBoyut + resimBoyut + (3 + sutun * 6);
                    var resim2Y = (satir + 1) * resimBoyut + (satir > 0 ? 4 : 2);

                    graphics.DrawImage(parca2.DonusumResimList[ucuzList[i].Id].Nesne, resim2X, resim2Y, resimBoyut - 2, resimBoyut - 2);

                    // Create point for upper-left corner of drawing.
                    drawRect = new RectangleF(resim2X + resimBoyut + 2, resim2Y, resimBoyut - 2, resimBoyut - 2);
                    // Draw string to screen.
                    graphics.DrawString(ucuzList[i].Fiyat.ToString(), drawFont, drawBrush, drawRect, format);

                    satir++;
                    if (satir == 4)
                    {
                        var cizgiX = resim2X + resimBoyut + 4;
                        graphics.DrawLine(new Pen(Color.OrangeRed, 2), new Point(cizgiX, 2), new Point(cizgiX, yukseklik - 2));
                        sutun++;
                        satir = 0;

                    }
                }

            }

            return sonuc;
        }
        private static CiktiResim GucluNromalZayifTabloOlustur(Havuz.Havuz havuz, Dictionary<string, int> gucluList,
            Dictionary<string, int> normalList, Dictionary<string, int> zayifList, int resimBoyut, out int genislik)
        {
            if (gucluList.Count != zayifList.Count || gucluList.Count != normalList.Count || normalList.Count != zayifList.Count)
            {
                throw new Exception("Guclu, normal ve zayif liste sayisi birbirinden farkli olamaz.");
            }

            var yukseklik = resimBoyut * 5;
            int sutunAdet = gucluList.Count / 4 + (gucluList.Count % 4 == 0 ? 0 : 1);
            genislik = resimBoyut * 3 * sutunAdet + (3 + sutunAdet * 6);

            var sonuc = new CiktiResim
            {
                Image = new Bitmap(genislik, yukseklik, PixelFormat.Format32bppArgb)
            };

            var satir = 0;
            var sutun = 0;
            using (var graphics = KanavaGetir(sonuc.Image))
            {
                //Cerceve ciz
                graphics.DrawLine(new Pen(Color.OrangeRed, 2), new Point(1, 1), new Point(genislik - 1, 1));
                graphics.DrawLine(new Pen(Color.OrangeRed, 2), new Point(1, 1), new Point(1, yukseklik - 1));
                graphics.DrawLine(new Pen(Color.OrangeRed, 2), new Point(1, yukseklik - 1), new Point(genislik - 1, yukseklik - 1));
                graphics.DrawLine(new Pen(Color.OrangeRed, 2), new Point(genislik - 1, 1), new Point(genislik - 1, yukseklik - 1));

                //Baslik altina cizgi ciz.
                graphics.DrawLine(new Pen(Color.OrangeRed, 2), new Point(2, resimBoyut + 2), new Point(genislik, resimBoyut + 2));
                var gcLst = gucluList.ToList();
                var nrLst = normalList.ToList();
                var zfLst = zayifList.ToList();
                for (int i = 0; i < gcLst.Count; i++)
                {
                    var parca1 = havuz.ParcaList.FirstOrDefault(s => s.Ad == gcLst[i].Key);
                    var parca2 = havuz.ParcaList.FirstOrDefault(s => s.Ad == nrLst[i].Key);
                    var parca3 = havuz.ParcaList.FirstOrDefault(s => s.Ad == zfLst[i].Key);

                    if (satir == 0)
                    {
                        var gucluX = sutun * 3 * resimBoyut + (3 + sutun * 6);
                        var gucluY = 2;

                        graphics.DrawImage(GoldenCupResmiUret(), new Rectangle(gucluX, gucluY, resimBoyut - 2, resimBoyut - 2));
                    }


                    var resim1X = sutun * 3 * resimBoyut + (3 + sutun * 6);
                    var resim1Y = (satir + 1) * resimBoyut + (satir > 0 ? 4 : 2);

                    graphics.DrawImage(parca1.DonusumResimList[gcLst[i].Value].Nesne, resim1X, resim1Y, resimBoyut - 2, resimBoyut - 2);

                    if (satir == 0)
                    {
                        var normalX = sutun * 3 * resimBoyut + resimBoyut + (3 + sutun * 6);
                        var normalY = 2;

                        graphics.DrawImage(SilverCupResmiUret(), new Rectangle(normalX, normalY, resimBoyut - 2, resimBoyut - 2));
                    }

                    var resim2X = sutun * 3 * resimBoyut + resimBoyut + (3 + sutun * 6);
                    var resim2Y = (satir + 1) * resimBoyut + (satir > 0 ? 4 : 2);

                    graphics.DrawImage(parca2.DonusumResimList[nrLst[i].Value].Nesne, resim2X, resim2Y, resimBoyut - 2, resimBoyut - 2);

                    if (satir == 0)
                    {
                        var zayifX = sutun * 3 * resimBoyut + resimBoyut + resimBoyut + (3 + sutun * 6);
                        var zayifY = 2;

                        graphics.DrawImage(BronzeCupResmiUret(), new Rectangle(zayifX, zayifY, resimBoyut - 2, resimBoyut - 2));
                    }

                    var resim3X = sutun * 3 * resimBoyut + resimBoyut + resimBoyut + (3 + sutun * 6);
                    var resim3Y = (satir + 1) * resimBoyut + (satir > 0 ? 4 : 2);

                    graphics.DrawImage(parca3.DonusumResimList[zfLst[i].Value].Nesne, resim3X, resim3Y, resimBoyut - 2, resimBoyut - 2);

                    satir++;
                    if (satir == 4)
                    {
                        var cizgiX = resim3X + resimBoyut + 4;
                        graphics.DrawLine(new Pen(Color.OrangeRed, 2), new Point(cizgiX, 2), new Point(cizgiX, yukseklik - 2));
                        sutun++;
                        satir = 0;

                    }
                }

            }

            return sonuc;
        }

        private static CiktiResim GucluNromalZayifTabloOlustur(Havuz.Havuz havuz, List<ParcaFiyat> pahaliList,
            List<ParcaFiyat> normalList, List<ParcaFiyat> ucuzList, int resimBoyut, out int genislik)
        {
            if (pahaliList.Count != ucuzList.Count || pahaliList.Count != normalList.Count || normalList.Count != ucuzList.Count)
            {
                throw new Exception("Pahali, normal ve ucuz liste sayisi birbirinden farkli olamaz.");
            }

            var yukseklik = resimBoyut * 5;
            int sutunAdet = pahaliList.Count / 4 + (pahaliList.Count % 4 == 0 ? 0 : 1);
            genislik = resimBoyut * 6 * sutunAdet + (3 + sutunAdet * 6);
            var fontBoyut = (25f * yukseklik) / 270f;

            var sonuc = new CiktiResim
            {
                Image = new Bitmap(genislik, yukseklik, PixelFormat.Format32bppArgb)
            };
            Font drawFont = new Font("Arial", fontBoyut, FontStyle.Regular);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            var format = new StringFormat();
            format.Alignment = StringAlignment.Near;


            var satir = 0;
            var sutun = 0;
            using (var graphics = KanavaGetir(sonuc.Image))
            {
                //Cerceve ciz
                graphics.DrawLine(new Pen(Color.OrangeRed, 2), new Point(1, 1), new Point(genislik - 1, 1));
                graphics.DrawLine(new Pen(Color.OrangeRed, 2), new Point(1, 1), new Point(1, yukseklik - 1));
                graphics.DrawLine(new Pen(Color.OrangeRed, 2), new Point(1, yukseklik - 1), new Point(genislik - 1, yukseklik - 1));
                graphics.DrawLine(new Pen(Color.OrangeRed, 2), new Point(genislik - 1, 1), new Point(genislik - 1, yukseklik - 1));

                //Baslik altina cizgi ciz.
                graphics.DrawLine(new Pen(Color.OrangeRed, 2), new Point(2, resimBoyut + 2), new Point(genislik, resimBoyut + 2));
                for (int i = 0; i < pahaliList.Count; i++)
                {
                    var parca1 = havuz.ParcaList.FirstOrDefault(s => s.Ad == pahaliList[i].Ad);
                    var parca2 = havuz.ParcaList.FirstOrDefault(s => s.Ad == normalList[i].Ad);
                    var parca3 = havuz.ParcaList.FirstOrDefault(s => s.Ad == ucuzList[i].Ad);

                    if (satir == 0)
                    {
                        var gucluX = sutun * 6 * resimBoyut + (3 + sutun * 6);
                        var gucluY = 2;

                        graphics.DrawImage(GoldenCupResmiUret(), new Rectangle(gucluX, gucluY, resimBoyut - 2, resimBoyut - 2));
                    }


                    var resim1X = sutun * 6 * resimBoyut + (3 + sutun * 6);
                    var resim1Y = (satir + 1) * resimBoyut + (satir > 0 ? 4 : 2);

                    graphics.DrawImage(parca1.DonusumResimList[pahaliList[i].Id].Nesne, resim1X, resim1Y, resimBoyut - 3, resimBoyut - 3);

                    // Create point for upper-left corner of drawing.
                    var drawRect = new RectangleF(resim1X + resimBoyut + 2, resim1Y + 5, resimBoyut - 2, resimBoyut - 2);
                    // Draw string to screen.
                    graphics.DrawString(pahaliList[i].Fiyat.ToString(), drawFont, drawBrush, drawRect, format);

                    if (satir == 0)
                    {
                        var normalX = sutun * 6 * resimBoyut + 2 * resimBoyut + (3 + sutun * 6);
                        var normalY = 2;

                        graphics.DrawImage(SilverCupResmiUret(), new Rectangle(normalX, normalY, resimBoyut - 2, resimBoyut - 2));
                    }

                    var resim2X = sutun * 6 * resimBoyut + 2 * resimBoyut + (3 + sutun * 6);
                    var resim2Y = (satir + 1) * resimBoyut + (satir > 0 ? 4 : 2);

                    graphics.DrawImage(parca2.DonusumResimList[normalList[i].Id].Nesne, resim2X, resim2Y, resimBoyut - 3, resimBoyut - 3);
                    // Create point for upper-left corner of drawing.
                    drawRect = new RectangleF(resim2X + resimBoyut + 2, resim2Y + 5, resimBoyut - 2, resimBoyut - 2);
                    // Draw string to screen.
                    graphics.DrawString(normalList[i].Fiyat.ToString(), drawFont, drawBrush, drawRect, format);

                    if (satir == 0)
                    {
                        var zayifX = sutun * 6 * resimBoyut + 4 * resimBoyut + (3 + sutun * 6);
                        var zayifY = 2;

                        graphics.DrawImage(BronzeCupResmiUret(), new Rectangle(zayifX, zayifY, resimBoyut - 2, resimBoyut - 2));
                    }

                    var resim3X = sutun * 6 * resimBoyut + 4 * resimBoyut + (3 + sutun * 6);
                    var resim3Y = (satir + 1) * resimBoyut + (satir > 0 ? 4 : 2);

                    graphics.DrawImage(parca3.DonusumResimList[ucuzList[i].Id].Nesne, resim3X, resim3Y, resimBoyut - 3, resimBoyut - 3);
                    // Create point for upper-left corner of drawing.
                    drawRect = new RectangleF(resim3X + resimBoyut + 2, resim3Y + 5, resimBoyut - 2, resimBoyut - 2);
                    // Draw string to screen.
                    graphics.DrawString(ucuzList[i].Fiyat.ToString(), drawFont, drawBrush, drawRect, format);

                    satir++;
                    if (satir == 4)
                    {
                        var cizgiX = resim3X + 2 * resimBoyut + 4;
                        graphics.DrawLine(new Pen(Color.OrangeRed, 2), new Point(cizgiX, 2), new Point(cizgiX, yukseklik - 2));
                        sutun++;
                        satir = 0;

                    }
                }

            }

            return sonuc;
        }

        public static CiktiResim IslemResimUret(KuraliBulSatirArg arg)
        {
            var isaretGenislik = arg.ResimBoyut / 3 - 1;
            int tabloEn;

            var tablo = arg.NormalList == null ? GucluZayifTabloOlustur(arg.Havuz, arg.GucluList, arg.ZayifList, arg.ResimBoyut / 5, out tabloEn) :
                GucluNromalZayifTabloOlustur(arg.Havuz, arg.GucluList, arg.NormalList, arg.ZayifList, arg.ResimBoyut / 5, out tabloEn);

            var parantezGenislik = arg.ResimBoyut / 3;
            var resimGenislik = 10 + tabloEn + 4 * arg.ResimBoyut + 3 * isaretGenislik + 2 * parantezGenislik;

            var sonuc = new CiktiResim { Image = new Bitmap(resimGenislik, arg.ResimBoyut, PixelFormat.Format32bppArgb) };

            using (var graphics = KanavaGetir(sonuc.Image))
            {
                var shift = 1;
                //GucluZayif Tablo Olustur
                graphics.DrawImage(tablo.Image, new Rectangle(1, 1, tabloEn, arg.ResimBoyut - 2));

                shift += tabloEn + 10;
                //Eger parantezId 0 ise parantezAc Sembolu ciz
                if (arg.ParantezId == 0)
                {
                    graphics.DrawImage(ParantezAcResmiUret(), new Rectangle(shift, 1, parantezGenislik, arg.ResimBoyut));
                    shift += parantezGenislik;
                }

                //Birinci resmi ciz
                graphics.DrawImage(ResimUret(arg.Havuz, arg.Resim1, arg.ResimBoyut).Image, new Rectangle(shift, 1, arg.ResimBoyut - 1, arg.ResimBoyut - 1));
                shift += arg.ResimBoyut;

                //Birinci Islemi ciz
                graphics.DrawImage(arg.Islem1 ? UpResmiUret() : DownResmiUret(),
                    new Rectangle(shift, arg.ResimBoyut / 3, isaretGenislik, isaretGenislik));

                shift += isaretGenislik;

                //Eger parantezId 1 ise parantezAc Sembolu ciz
                if (arg.ParantezId == 1)
                {
                    graphics.DrawImage(ParantezAcResmiUret(), new Rectangle(shift, 1, parantezGenislik, arg.ResimBoyut));
                    shift += parantezGenislik;
                }

                //Ikinci Resmi ciz.
                graphics.DrawImage(ResimUret(arg.Havuz, arg.Resim2, arg.ResimBoyut).Image, new Rectangle(shift, 1, arg.ResimBoyut - 1, arg.ResimBoyut - 1));
                shift += arg.ResimBoyut;

                //Eger parantezId 0 ise parantezKapa Sembolu ciz
                if (arg.ParantezId == 0)
                {
                    graphics.DrawImage(ParantezKapaResmiUret(), new Rectangle(shift, 1, parantezGenislik, arg.ResimBoyut));
                    shift += parantezGenislik;
                }

                //Ikinci Islemi ciz
                graphics.DrawImage(arg.Islem2 ? UpResmiUret() : DownResmiUret(),
                    new Rectangle(shift, arg.ResimBoyut / 3, isaretGenislik, isaretGenislik));

                shift += isaretGenislik;

                //Ucuncu Resmi ciz.
                graphics.DrawImage(ResimUret(arg.Havuz, arg.Resim3, arg.ResimBoyut).Image, new Rectangle(shift, 1, arg.ResimBoyut - 1, arg.ResimBoyut - 1));
                shift += arg.ResimBoyut;

                //Eger parantezId 1 ise parantezKapa Sembolu ciz
                if (arg.ParantezId == 1)
                {
                    graphics.DrawImage(ParantezKapaResmiUret(), new Rectangle(shift, 1, parantezGenislik, arg.ResimBoyut));
                    shift += parantezGenislik;
                }

                //Ok isareti Ciz
                graphics.DrawImage(OkResmiUret(), new Rectangle(shift, arg.ResimBoyut / 3, isaretGenislik, isaretGenislik));

                shift += isaretGenislik;

                //Sonuc Resmini ciz.
                graphics.DrawImage(ResimUret(arg.Havuz, arg.SonucResim, arg.ResimBoyut).Image, new Rectangle(shift, 1, arg.ResimBoyut - 1, arg.ResimBoyut - 1));

            }

            return sonuc;
        }
        public static CiktiResim IslemResimUret2(KuraliBulSatirArg arg)
        {
            var isaretGenislik = arg.ResimBoyut / 3 - 1;
            int tabloEn;

            var tablo = arg.NormalFiyatList == null ? GucluZayifTabloOlustur(arg.Havuz, arg.PahaliFiyatList, arg.UcuzFiyatList, arg.ResimBoyut / 5, out tabloEn) :
                GucluNromalZayifTabloOlustur(arg.Havuz, arg.PahaliFiyatList, arg.NormalFiyatList, arg.UcuzFiyatList, arg.ResimBoyut / 5, out tabloEn);

            var parantezGenislik = arg.ResimBoyut / 3;
            var resimGenislik = 10 + tabloEn + 4 * arg.ResimBoyut + 3 * isaretGenislik + 2 * parantezGenislik;

            var sonuc = new CiktiResim { Image = new Bitmap(resimGenislik, arg.ResimBoyut + (int)(arg.ResimBoyut * 0.2), PixelFormat.Format32bppArgb) };

            using (var graphics = KanavaGetir(sonuc.Image))
            {
                var shift = 1;
                //GucluZayif Tablo Olustur
                graphics.DrawImage(tablo.Image, new Rectangle(1, 1, tabloEn, arg.ResimBoyut - 2));

                shift += tabloEn + 10;
                //Eger parantezId 0 ise parantezAc Sembolu ciz
                if (arg.ParantezId == 0)
                {
                    graphics.DrawImage(ParantezAcResmiUret(), new Rectangle(shift, 1, parantezGenislik, arg.ResimBoyut + (int)(arg.ResimBoyut * 0.2)));
                    shift += parantezGenislik;
                }

                //Birinci resmi ciz
                graphics.DrawImage(MelezResimUret(ResimUret(arg.Havuz, arg.Resim1, arg.ResimBoyut),
                                arg.Resim1FiyatToplam.ToString(), arg.ResimBoyut, 4).Image,
                                new Rectangle(shift, 1, arg.ResimBoyut - 1, arg.ResimBoyut + (int)(arg.ResimBoyut * .2) - 1));

                shift += arg.ResimBoyut;

                //Birinci Islemi ciz
                graphics.DrawImage(arg.Islem1 ? UpResmiUret() : DownResmiUret(),
                    new Rectangle(shift, arg.ResimBoyut / 3, isaretGenislik, isaretGenislik));

                shift += isaretGenislik;

                //Eger parantezId 1 ise parantezAc Sembolu ciz
                if (arg.ParantezId == 1)
                {
                    graphics.DrawImage(ParantezAcResmiUret(), new Rectangle(shift, 1, parantezGenislik, arg.ResimBoyut + (int)(arg.ResimBoyut * 0.2)));
                    shift += parantezGenislik;
                }

                //Ikinci Resmi ciz.
                graphics.DrawImage(MelezResimUret(ResimUret(arg.Havuz, arg.Resim2, arg.ResimBoyut),
                                    arg.Resim2FiyatToplam.ToString(), arg.ResimBoyut, 4).Image,
                                    new Rectangle(shift, 1, arg.ResimBoyut - 1, arg.ResimBoyut + (int)(arg.ResimBoyut * 0.2) - 1));
                shift += arg.ResimBoyut;

                //Eger parantezId 0 ise parantezKapa Sembolu ciz
                if (arg.ParantezId == 0)
                {
                    graphics.DrawImage(ParantezKapaResmiUret(), new Rectangle(shift, 1, parantezGenislik, arg.ResimBoyut + (int)(arg.ResimBoyut * .2)));
                    shift += parantezGenislik;
                }

                //Ikinci Islemi ciz
                graphics.DrawImage(arg.Islem2 ? UpResmiUret() : DownResmiUret(),
                    new Rectangle(shift, arg.ResimBoyut / 3, isaretGenislik, isaretGenislik));

                shift += isaretGenislik;

                //Ucuncu Resmi ciz.
                graphics.DrawImage(MelezResimUret(ResimUret(arg.Havuz, arg.Resim3, arg.ResimBoyut),
                    arg.Resim3FiyatToplam.ToString(), arg.ResimBoyut, 4).Image,
                    new Rectangle(shift, 1, arg.ResimBoyut - 1, arg.ResimBoyut + (int)(arg.ResimBoyut * .2) - 1));
                shift += arg.ResimBoyut;

                //Eger parantezId 1 ise parantezKapa Sembolu ciz
                if (arg.ParantezId == 1)
                {
                    graphics.DrawImage(ParantezKapaResmiUret(), new Rectangle(shift, 1, parantezGenislik, arg.ResimBoyut + (int)(arg.ResimBoyut * .2)));
                    shift += parantezGenislik;
                }

                //Ok isareti Ciz
                graphics.DrawImage(OkResmiUret(), new Rectangle(shift, arg.ResimBoyut / 3, isaretGenislik, isaretGenislik));

                shift += isaretGenislik;

                //Sonuc Resmini ciz.
                graphics.DrawImage(MelezResimUret(ResimUret(arg.Havuz, arg.SonucResim, arg.ResimBoyut),
                    arg.SonucResimFiyatToplam.ToString(), arg.ResimBoyut, 4).Image,
                    new Rectangle(shift, 1, arg.ResimBoyut - 1, arg.ResimBoyut + (int)(arg.ResimBoyut * .2) - 1));

            }

            return sonuc;
        }
        public static CiktiResim IslemResimUret(Havuz.Havuz havuz, Dictionary<string, int> resim1,
          Dictionary<string, int> resim2, Dictionary<string, int> resimSonuc, bool buyukMu,
          Dictionary<string, int> gucluList, Dictionary<string, int> zayifList, int resimBoyut)
        {
            var isaretGenislik = resimBoyut / 3 - 1;

            var tabloEn = 0;
            var tablo = GucluZayifTabloOlustur(havuz, gucluList, zayifList, resimBoyut / 5, out tabloEn);
            var resimGenislik = tabloEn + resimBoyut + isaretGenislik + resimBoyut + isaretGenislik + resimBoyut;


            var sonuc = new CiktiResim { Image = new Bitmap(resimGenislik, resimBoyut, PixelFormat.Format32bppArgb) };

            using (var graphics = KanavaGetir(sonuc.Image))
            {
                var shift = 1;

                graphics.DrawImage(tablo.Image, new Rectangle(1, 1, tabloEn, resimBoyut - 2));

                shift += tabloEn;

                graphics.DrawImage(ResimUret(havuz, resim1, resimBoyut).Image, new Rectangle(shift, 1, resimBoyut - 2, resimBoyut - 2));

                shift += resimBoyut;

                graphics.DrawImage(buyukMu ? UpResmiUret() : DownResmiUret(),
                  new Rectangle(shift, resimBoyut / 3, isaretGenislik, isaretGenislik));

                shift += isaretGenislik;

                graphics.DrawImage(ResimUret(havuz, resim2, resimBoyut).Image, new Rectangle(shift, 1, resimBoyut - 1, resimBoyut - 1));

                shift += resimBoyut;

                graphics.DrawImage(OkResmiUret(), new Rectangle(shift, resimBoyut / 3, isaretGenislik, isaretGenislik));

                shift += isaretGenislik;

                graphics.DrawImage(ResimUret(havuz, resimSonuc, resimBoyut).Image, new Rectangle(shift, 1, resimBoyut - 1, resimBoyut - 1)); graphics.Flush();
            }
            return sonuc;
        }

        public static CiktiResim IslemResimUret(Havuz.Havuz havuz, Dictionary<string, int> resim1,
           Dictionary<string, int> resim2, Dictionary<string, int> resimSonuc, bool buyukMu, int resimBoyut)
        {
            var isaretGenislik = resimBoyut / 3 - 1;
            var resimGenislik = resimBoyut + isaretGenislik + resimBoyut + isaretGenislik + resimBoyut;

            var sonuc = new CiktiResim { Image = new Bitmap(resimGenislik, resimBoyut, PixelFormat.Format32bppArgb) };

            using (var graphics = KanavaGetir(sonuc.Image))
            {
                var shift = 1;
                graphics.DrawImage(ResimUret(havuz, resim1, resimBoyut).Image, new Rectangle(1, 1, resimBoyut - 2, resimBoyut - 2));

                shift += resimBoyut;

                graphics.DrawImage(buyukMu ? UpResmiUret() : DownResmiUret(),
                  new Rectangle(shift, resimBoyut / 3, isaretGenislik, isaretGenislik));

                shift += isaretGenislik;

                graphics.DrawImage(ResimUret(havuz, resim2, resimBoyut).Image, new Rectangle(shift, 1, resimBoyut - 1, resimBoyut - 1));

                shift += resimBoyut;

                graphics.DrawImage(OkResmiUret(), new Rectangle(shift, resimBoyut / 3, isaretGenislik, isaretGenislik));

                shift += isaretGenislik;

                graphics.DrawImage(ResimUret(havuz, resimSonuc, resimBoyut).Image, new Rectangle(shift, 1, resimBoyut - 1, resimBoyut - 1)); graphics.Flush();
            }
            return sonuc;
        }

        public static CiktiResim YonIsaretResimUret(Havuz.Havuz havuz, bool yon, List<ParcaAci> parcaAciList, int resimBoyut)
        {
            var isaretYukseklik = resimBoyut / 6;

            var sonuc = new CiktiResim { Image = new Bitmap(resimBoyut, resimBoyut, PixelFormat.Format32bppArgb) };

            using (var graphic = KanavaGetir(sonuc.Image))
            {
                graphic.DrawImage(ResimUret(havuz, parcaAciList, resimBoyut).Image,
                                   new Rectangle(new Point(1, 1),
                                   new Size(resimBoyut, resimBoyut)));
                if (yon)
                {
                    graphic.DrawImage(RotateRightResmiUret(),
                                  new Rectangle(new Point(1, 1),
                                  new Size(isaretYukseklik, isaretYukseklik)));
                }
                else
                {
                    graphic.DrawImage(RotateLeftResmiUret(),
                                  new Rectangle(new Point(resimBoyut - isaretYukseklik - 1, 1),
                                  new Size(isaretYukseklik, isaretYukseklik)));
                }


            }
            return sonuc;
        }
        private static Matrix GetTransform(int resimBoyut, float aci)
        {
            var sonuc = new Matrix();
            var targetExtent = new Rectangle(0, 0, resimBoyut, resimBoyut);

            //Resim Aci listesindeki her bir parcaya kendisinden buyuk olan tum parcalara 
            //uygulanmis dondurme acilarini uygula 

            //parcanin merkezine git.
            float moveX = targetExtent.X + 1 + (targetExtent.Width + 1) / 2f;
            float moveY = targetExtent.Y + 1 + (targetExtent.Height + 1) / 2f;
            sonuc.Translate(moveX, moveY);

            //parcanin acisi kadar dondur.
            sonuc.Rotate(aci);

            //parcayi eski yerine tasi
            sonuc.Translate(-moveX, -moveY);

            return sonuc;
        }
        private static Matrix GetTransform(List<ParcaExtent> parcaExtentList, List<ParcaAci> parcaAciList, ParcaAci target)
        {
            var sonuc = new Matrix();
            var targetExtent = parcaExtentList.FirstOrDefault(s => s.Ad == target.Ad);
            var parentExtent = targetExtent.GetParentExtent(parcaExtentList);

            //Resim Aci listesindeki her bir parcaya kendisinden buyuk olan tum parcalara 
            //uygulanmis dondurme acilarini uygula 
            if (parentExtent != null)
            {
                var parentAci = parcaAciList.FirstOrDefault(s => s.Ad == parentExtent.Ad);
                sonuc = GetTransform(parcaExtentList, parcaAciList, parentAci);
            }
            //parcanin merkezine git.
            float moveX = targetExtent.Extent.X + 1 + (targetExtent.Extent.Width + 1) / 2f;
            float moveY = targetExtent.Extent.Y + 1 + (targetExtent.Extent.Height + 1) / 2f;
            sonuc.Translate(moveX, moveY);

            //parcanin acisi kadar dondur.
            sonuc.Rotate(target.Aci);

            //parcayi eski yerine tasi
            sonuc.Translate(-moveX, -moveY);

            return sonuc;
        }
        public static CiktiResim DondurResimUret(Havuz.Havuz havuz, List<ParcaAci> parcaAciList,
            List<ParcaExtent> parcaExtentList, int resimBoyut)
        {
            var sonuc = new CiktiResim { Image = new Bitmap(resimBoyut, resimBoyut, PixelFormat.Format32bppArgb) };
            using (var graphic = KanavaGetir(sonuc.Image))
            {


                //Parca extentlerini en buyukten en kucuge sirala
                foreach (var extent in parcaExtentList.OrderByDescending(s => s.Yuzolcum))
                {

                    var parcaAci = parcaAciList.FirstOrDefault(s => s.Ad == extent.Ad);
                    if (parcaAci != null)
                    {

                        graphic.Transform = GetTransform(parcaExtentList, parcaAciList, parcaAci);

                        var parca = havuz.ParcaList.FirstOrDefault(s => s.Ad == parcaAci.Ad);
                        if (parca != null)
                        {
                            //Resmi kanavaya ciz.
                            graphic.DrawImage(parca.ResimList[parcaAci.Id].Nesne,
                                    new Rectangle(new Point(1, 1),
                                    new Size(resimBoyut, resimBoyut)));
                        }
                        graphic.ResetTransform();
                    }
                }
            }
            return sonuc;
        }
        public static CiktiResim DondurResimUret(Havuz.Havuz havuz,
            Dictionary<string, int> resimList, List<ParcaYer> parcaYerList, int resimBoyut)
        {
            var sonuc = new CiktiResim { Image = new Bitmap(resimBoyut, resimBoyut, PixelFormat.Format32bppArgb) };
            using (var graphic = KanavaGetir(sonuc.Image))
            {
                //Parca extentlerini en buyukten en kucuge sirala
                foreach (var seciliParca in resimList)
                {
                    var parcaYer = parcaYerList.FirstOrDefault(s => s.Ad == seciliParca.Key);
                    if (parcaYer != null)
                    {

                        graphic.Transform = GetTransform(resimBoyut, parcaYer.GetAci(resimList.Count));

                        var parca = havuz.ParcaList.FirstOrDefault(s => s.Ad == parcaYer.Ad);
                        if (parca != null)
                        {
                            //Resmi kanavaya ciz.
                            graphic.DrawImage(parca.ResimList[seciliParca.Value].Nesne,
                                    new Rectangle(new Point(1, 1),
                                    new Size(resimBoyut, resimBoyut)));
                        }
                        graphic.ResetTransform();
                    }
                    else
                    {
                        var parca = havuz.ParcaList.FirstOrDefault(s => s.Ad == seciliParca.Key);
                        if (parca != null)
                        {
                            //Resmi kanavaya ciz.
                            graphic.DrawImage(parca.ResimList[seciliParca.Value].Nesne,
                                    new Rectangle(new Point(1, 1),
                                    new Size(resimBoyut, resimBoyut)));
                        }
                    }
                }
            }
            return sonuc;
        }
        public static CiktiResim IslemResimUret(DondurBulSatirArg arg)
        {
            var isaretGenislik = arg.ResimBoyut / 3 - 1;
            var resimGenislik = arg.ResimBoyut + isaretGenislik + arg.ResimBoyut + isaretGenislik + arg.ResimBoyut;
            if (arg.Resim3 != null && arg.Resim3.Count > 0)
            {
                resimGenislik += isaretGenislik + arg.ResimBoyut;
            }
            var sonuc = new CiktiResim { Image = new Bitmap(resimGenislik, arg.ResimBoyut, PixelFormat.Format32bppArgb) };

            using (var graphics = KanavaGetir(sonuc.Image))
            {
                var shift = 1;
                graphics.DrawImage(YonIsaretResimUret(arg.Havuz, arg.Yon1, arg.Resim1, arg.ResimBoyut).Image,
                                new Rectangle(1, 1, arg.ResimBoyut - 2, arg.ResimBoyut - 2));

                shift += arg.ResimBoyut;

                graphics.DrawImage(YildizResmiUret(), new Rectangle(shift, arg.ResimBoyut / 3, isaretGenislik, isaretGenislik));

                shift += isaretGenislik;

                graphics.DrawImage(YonIsaretResimUret(arg.Havuz, arg.Yon2, arg.Resim2, arg.ResimBoyut).Image,
                                new Rectangle(shift, 1, arg.ResimBoyut - 1, arg.ResimBoyut - 1));

                shift += arg.ResimBoyut;

                if (arg.Resim3 != null)
                {
                    graphics.DrawImage(YildizResmiUret(), new Rectangle(shift, arg.ResimBoyut / 3, isaretGenislik, isaretGenislik));

                    shift += isaretGenislik;

                    graphics.DrawImage(YonIsaretResimUret(arg.Havuz, arg.Yon3, arg.Resim3, arg.ResimBoyut).Image,
                                    new Rectangle(shift, 1, arg.ResimBoyut - 1, arg.ResimBoyut - 1));

                    shift += arg.ResimBoyut;
                }

                graphics.DrawImage(OkResmiUret(), new Rectangle(shift, arg.ResimBoyut / 3, isaretGenislik, isaretGenislik));

                shift += isaretGenislik;

                graphics.DrawImage(DondurResimUret(arg.Havuz, arg.SonucResim, arg.ParcaExtentList, arg.ResimBoyut).Image,
                    new Rectangle(shift, 1, arg.ResimBoyut - 1, arg.ResimBoyut - 1)); graphics.Flush();
            }
            return sonuc;
        }

        public static CiktiResim IslemResimUret(YerDegistirArgs arg)
        {
            var isaretGenislik = arg.ResimBoyut / 3 - 1;
            var yaziGenislik = 9 * arg.DegisimMetin.Length;
            var resimGenislik = arg.ResimBoyut + isaretGenislik + yaziGenislik + isaretGenislik + arg.ResimBoyut;

            var sonuc = new CiktiResim { Image = new Bitmap(resimGenislik, arg.ResimBoyut, PixelFormat.Format32bppArgb) };

            using (var graphics = KanavaGetir(sonuc.Image))
            {
                var shift = 1;
                graphics.DrawImage(ResimUret(arg.Havuz, arg.ReferansResim, arg.ResimBoyut).Image,
                                new Rectangle(1, 1, arg.ResimBoyut - 2, arg.ResimBoyut - 2));

                shift += arg.ResimBoyut + isaretGenislik;
                // Create font and brush.
                Font drawFont = new Font("Arial", 12f, FontStyle.Regular);
                SolidBrush drawBrush = new SolidBrush(Color.Black);
                var format = new StringFormat();
                format.Alignment = StringAlignment.Near;

                // Create point for upper-left corner of drawing.
                var drawRect = new RectangleF(shift, arg.ResimBoyut / 2 - isaretGenislik / 2, yaziGenislik, 27);
                // Draw string to screen.
                graphics.DrawString(arg.DegisimMetin, drawFont, drawBrush, drawRect, format);

                shift += yaziGenislik;
                
                graphics.DrawImage(OkResmiUret(), new Rectangle(shift, arg.ResimBoyut / 3, isaretGenislik, isaretGenislik));

                shift += isaretGenislik;

                graphics.DrawImage(DondurResimUret(arg.Havuz, arg.ReferansResim, arg.ReferansYerList, arg.ResimBoyut).Image,
                    new Rectangle(shift, 1, arg.ResimBoyut - 1, arg.ResimBoyut - 1)); graphics.Flush();
            }
            return sonuc;
        }

        /// <summary>
        /// Renklendirme Yapar
        /// </summary>
        /// <param name="havuz"></param>
        /// <param name="resim1"></param>
        /// <param name="resim2"></param>
        /// <param name="resimSonuc"></param>
        /// <param name="buyukMu"></param>
        /// <param name="sonucRenkList"></param>
        /// <param name="resimBoyut"></param>
        /// <param name="resim1RenkList"></param>
        /// <param name="resim2RenkList"></param>
        /// <returns></returns>
        public static CiktiResim IslemResimUret(Havuz.Havuz havuz, Dictionary<string, int> resim1,
          Dictionary<string, int> resim2, Dictionary<string, int> resimSonuc, bool buyukMu,
          Dictionary<string, bool> resim1RenkList, Dictionary<string, bool> resim2RenkList,
          Dictionary<string, bool> sonucRenkList, int resimBoyut)
        {
            var isaretGenislik = resimBoyut / 3 - 1;
            var resimGenislik = resimBoyut + isaretGenislik + resimBoyut + isaretGenislik + resimBoyut;

            var sonuc = new CiktiResim { Image = new Bitmap(resimGenislik, resimBoyut, PixelFormat.Format32bppArgb) };

            using (var graphics = KanavaGetir(sonuc.Image))
            {
                var shift = 1;
                graphics.DrawImage(ResimUret(havuz, resim1, resim1RenkList, resimBoyut).Image, new Rectangle(1, 1, resimBoyut - 2, resimBoyut - 2));

                shift += resimBoyut;

                graphics.DrawImage(buyukMu ? UpResmiUret() : DownResmiUret(),
                  new Rectangle(shift, resimBoyut / 3, isaretGenislik, isaretGenislik));

                shift += isaretGenislik;

                graphics.DrawImage(ResimUret(havuz, resim2, resim2RenkList, resimBoyut).Image, new Rectangle(shift, 1, resimBoyut - 1, resimBoyut - 1));

                shift += resimBoyut;

                graphics.DrawImage(OkResmiUret(), new Rectangle(shift, resimBoyut / 3, isaretGenislik, isaretGenislik));

                shift += isaretGenislik;

                graphics.DrawImage(ResimUret(havuz, resimSonuc, sonucRenkList, resimBoyut).Image, new Rectangle(shift, 1, resimBoyut - 1, resimBoyut - 1)); graphics.Flush();
            }
            return sonuc;
        }

        public static CiktiResim IslemSoruResimUret(YerDegistirArgs arg)
        {
            var isaretGenislik = arg.ResimBoyut / 3 - 1;
            var yaziGenislik = 9 * arg.DegisimMetin.Length;
            var resimGenislik = arg.ResimBoyut + isaretGenislik + yaziGenislik + isaretGenislik + arg.ResimBoyut;

            var sonuc = new CiktiResim { Image = new Bitmap(resimGenislik, arg.ResimBoyut, PixelFormat.Format32bppArgb) };

            using (var graphics = KanavaGetir(sonuc.Image))
            {
                var shift = 1;
                graphics.DrawImage(ResimUret(arg.Havuz, arg.ReferansResim, arg.ResimBoyut).Image,
                                new Rectangle(1, 1, arg.ResimBoyut - 2, arg.ResimBoyut - 2));

                shift += arg.ResimBoyut + isaretGenislik;
                // Create font and brush.
                Font drawFont = new Font("Arial", 12f, FontStyle.Regular);
                SolidBrush drawBrush = new SolidBrush(Color.Black);
                var format = new StringFormat();
                format.Alignment = StringAlignment.Near;

                // Create point for upper-left corner of drawing.
                var drawRect = new RectangleF(shift, arg.ResimBoyut / 2 - isaretGenislik / 2, yaziGenislik, 27);
                // Draw string to screen.
                graphics.DrawString(arg.DegisimMetin, drawFont, drawBrush, drawRect, format);

                shift += yaziGenislik;

                graphics.DrawImage(OkResmiUret(), new Rectangle(shift, arg.ResimBoyut / 3, isaretGenislik, isaretGenislik));

                shift += isaretGenislik;

                graphics.DrawImage(SoruIsaretResmiUret(), new Rectangle(shift, 1, arg.ResimBoyut - 1, arg.ResimBoyut - 1));

                graphics.Flush();

            }
            return sonuc;
        }

        public static CiktiResim IslemSoruResimUret(DondurBulSatirArg arg)
        {
            var isaretGenislik = arg.ResimBoyut / 3 - 1;
            var resimGenislik = arg.ResimBoyut + isaretGenislik + arg.ResimBoyut + isaretGenislik + arg.ResimBoyut;

            if (arg.Resim3 != null && arg.Resim3.Count > 0)
            {
                resimGenislik += isaretGenislik + arg.ResimBoyut;
            }

            var sonuc = new CiktiResim { Image = new Bitmap(resimGenislik, arg.ResimBoyut, PixelFormat.Format32bppArgb) };

            using (var graphics = KanavaGetir(sonuc.Image))
            {
                var shift = 1;
                graphics.DrawImage(YonIsaretResimUret(arg.Havuz, arg.Yon1, arg.Resim1, arg.ResimBoyut).Image,
                                new Rectangle(1, 1, arg.ResimBoyut - 2, arg.ResimBoyut - 2));

                shift += arg.ResimBoyut;

                graphics.DrawImage(YildizResmiUret(), new Rectangle(shift, arg.ResimBoyut / 3, isaretGenislik, isaretGenislik));

                shift += isaretGenislik;

                graphics.DrawImage(YonIsaretResimUret(arg.Havuz, arg.Yon2, arg.Resim2, arg.ResimBoyut).Image,
                                new Rectangle(shift, 1, arg.ResimBoyut - 1, arg.ResimBoyut - 1));

                shift += arg.ResimBoyut;

                if (arg.Resim3 != null)
                {
                    graphics.DrawImage(YildizResmiUret(), new Rectangle(shift, arg.ResimBoyut / 3, isaretGenislik, isaretGenislik));

                    shift += isaretGenislik;

                    graphics.DrawImage(YonIsaretResimUret(arg.Havuz, arg.Yon3, arg.Resim3, arg.ResimBoyut).Image,
                                    new Rectangle(shift, 1, arg.ResimBoyut - 1, arg.ResimBoyut - 1));

                    shift += arg.ResimBoyut;
                }

                graphics.DrawImage(OkResmiUret(), new Rectangle(shift, arg.ResimBoyut / 3, isaretGenislik, isaretGenislik));

                shift += isaretGenislik;

                graphics.DrawImage(SoruIsaretResmiUret(), new Rectangle(shift, 1, arg.ResimBoyut - 1, arg.ResimBoyut - 1));

                graphics.Flush();

            }
            return sonuc;
        }
        public static CiktiResim IslemSoruResimUret(Havuz.Havuz havuz, Dictionary<string, int> resim1,
            Dictionary<string, int> resim2, Dictionary<string, int> resim3, int resimBoyut)
        {
            var isaretGenislik = resimBoyut / 3 - 1;
            var resimGenislik = resimBoyut + isaretGenislik + resimBoyut + isaretGenislik + resimBoyut + isaretGenislik + resimBoyut;

            var sonuc = new CiktiResim { Image = new Bitmap(resimGenislik, resimBoyut, PixelFormat.Format32bppArgb) };

            using (var graphics = KanavaGetir(sonuc.Image))
            {
                var shift = 1;

                graphics.DrawImage(ResimUret(havuz, resim1, resimBoyut).Image, new Rectangle(shift, 1, resimBoyut - 1, resimBoyut - 1));

                shift += resimBoyut;

                graphics.DrawImage(YildizResmiUret(), new Rectangle(shift, resimBoyut / 3, isaretGenislik, isaretGenislik));

                shift += isaretGenislik;

                graphics.DrawImage(ResimUret(havuz, resim2, resimBoyut).Image, new Rectangle(shift, 1, resimBoyut - 1, resimBoyut - 1));

                shift += resimBoyut;

                graphics.DrawImage(YildizResmiUret(), new Rectangle(shift, resimBoyut / 3, isaretGenislik, isaretGenislik));

                shift += isaretGenislik;

                graphics.DrawImage(ResimUret(havuz, resim3, resimBoyut).Image, new Rectangle(shift, 1, resimBoyut - 1, resimBoyut - 1));

                shift += resimBoyut;

                graphics.DrawImage(OkResmiUret(), new Rectangle(shift, resimBoyut / 3, isaretGenislik, isaretGenislik));

                shift += isaretGenislik;

                graphics.DrawImage(SoruIsaretResmiUret(), new Rectangle(shift, 1, resimBoyut - 1, resimBoyut - 1)); graphics.Flush();
            }
            return sonuc;
        }

        public static CiktiResim IslemSoruResimUret(CiktiResim resim1, int resimEn, int resimYukseklik)
        {
            var isaretGenislik = resimEn / 3 - 1;
            var resimGenislik = resim1.Image.Width + isaretGenislik + resim1.Image.Width;
            var yukseklik = resim1.Image.Height >= resimYukseklik ? resim1.Image.Height : resimYukseklik;

            var sonuc = new CiktiResim
            {
                Image = new Bitmap(resimGenislik, yukseklik, PixelFormat.Format32bppArgb),
                ParcaList = resim1.ParcaList,
                DigerResimParcaList = resim1.DigerResimParcaList
            };

            using (var graphics = KanavaGetir(sonuc.Image))
            {
                var shift = 1;

                graphics.DrawImage(resim1.Image, new Rectangle(shift, 1, resim1.Image.Width - 2, yukseklik - 2));

                shift += resim1.Image.Width - 2;

                graphics.DrawImage(OkResmiUret(), new Rectangle(shift, resimEn / 3, isaretGenislik, isaretGenislik));

                shift += isaretGenislik;

                graphics.DrawImage(SoruIsaretResmiUret(),
                    new Rectangle(shift + resimEn / 2, resimEn / 3,
                    resimEn / 2, resimEn / 2));

                graphics.Flush();
            }
            return sonuc;
        }

        public static CiktiResim IslemSoruResimUret(Havuz.Havuz havuz, Dictionary<string, int> resim1,
            Dictionary<string, int> resim2, int resimBoyut)
        {
            var isaretGenislik = resimBoyut / 3 - 1;
            var resimGenislik = resimBoyut + isaretGenislik + resimBoyut + isaretGenislik + resimBoyut;

            var sonuc = new CiktiResim { Image = new Bitmap(resimGenislik, resimBoyut, PixelFormat.Format32bppArgb) };

            using (var graphics = KanavaGetir(sonuc.Image))
            {
                var shift = 1;

                graphics.DrawImage(ResimUret(havuz, resim1, resimBoyut).Image, new Rectangle(shift, 1, resimBoyut - 1, resimBoyut - 1));

                shift += resimBoyut;

                graphics.DrawImage(YildizResmiUret(), new Rectangle(shift, resimBoyut / 3, isaretGenislik, isaretGenislik));

                shift += isaretGenislik;

                graphics.DrawImage(ResimUret(havuz, resim2, resimBoyut).Image, new Rectangle(shift, 1, resimBoyut - 1, resimBoyut - 1));

                shift += resimBoyut;

                graphics.DrawImage(OkResmiUret(), new Rectangle(shift, resimBoyut / 3, isaretGenislik, isaretGenislik));

                shift += isaretGenislik;

                graphics.DrawImage(SoruIsaretResmiUret(), new Rectangle(shift, 1, resimBoyut - 1, resimBoyut - 1)); graphics.Flush();
            }
            return sonuc;
        }

        public static CiktiResim IslemSoruResimUret(KuraliBulSatirArg arg)
        {
            var isaretGenislik = arg.ResimBoyut / 3 - 1;
            int tabloEn;
            var tablo = arg.NormalList == null ? GucluZayifTabloOlustur(arg.Havuz, arg.GucluList, arg.ZayifList, arg.ResimBoyut / 5, out tabloEn) :
                GucluNromalZayifTabloOlustur(arg.Havuz, arg.GucluList, arg.NormalList, arg.ZayifList, arg.ResimBoyut / 5, out tabloEn);
            var parantezGenislik = arg.ResimBoyut / 3;
            var resimGenislik = 10 + tabloEn + 4 * arg.ResimBoyut + 3 * isaretGenislik + 2 * parantezGenislik;

            var sonuc = new CiktiResim { Image = new Bitmap(resimGenislik, arg.ResimBoyut, PixelFormat.Format32bppArgb) };

            using (var graphics = KanavaGetir(sonuc.Image))
            {
                var shift = 1;
                //GucluZayif Tablo Olustur
                graphics.DrawImage(tablo.Image, new Rectangle(1, 1, tabloEn, arg.ResimBoyut - 2));

                shift += tabloEn + 10;
                //Eger parantezId 0 ise parantezAc Sembolu ciz
                if (arg.ParantezId == 0)
                {
                    graphics.DrawImage(ParantezAcResmiUret(), new Rectangle(shift, 1, parantezGenislik, arg.ResimBoyut));
                    shift += parantezGenislik;
                }

                //Birinci resmi ciz
                graphics.DrawImage(ResimUret(arg.Havuz, arg.Resim1, arg.ResimBoyut).Image, new Rectangle(shift, 1, arg.ResimBoyut - 1, arg.ResimBoyut - 1));
                shift += arg.ResimBoyut;

                //Birinci Islemi ciz
                graphics.DrawImage(arg.Islem1 ? UpResmiUret() : DownResmiUret(),
                    new Rectangle(shift, arg.ResimBoyut / 3, isaretGenislik, isaretGenislik));

                shift += isaretGenislik;

                //Eger parantezId 1 ise parantezAc Sembolu ciz
                if (arg.ParantezId == 1)
                {
                    graphics.DrawImage(ParantezAcResmiUret(), new Rectangle(shift, 1, parantezGenislik, arg.ResimBoyut));
                    shift += parantezGenislik;
                }

                //Ikinci Resmi ciz.
                graphics.DrawImage(ResimUret(arg.Havuz, arg.Resim2, arg.ResimBoyut).Image, new Rectangle(shift, 1, arg.ResimBoyut - 1, arg.ResimBoyut - 1));
                shift += arg.ResimBoyut;

                //Eger parantezId 0 ise parantezKapa Sembolu ciz
                if (arg.ParantezId == 0)
                {
                    graphics.DrawImage(ParantezKapaResmiUret(), new Rectangle(shift, 1, parantezGenislik, arg.ResimBoyut));
                    shift += parantezGenislik;
                }

                //Ikinci Islemi ciz
                graphics.DrawImage(arg.Islem2 ? UpResmiUret() : DownResmiUret(),
                    new Rectangle(shift, arg.ResimBoyut / 3, isaretGenislik, isaretGenislik));

                shift += isaretGenislik;

                //Ucuncu Resmi ciz.
                graphics.DrawImage(ResimUret(arg.Havuz, arg.Resim3, arg.ResimBoyut).Image, new Rectangle(shift, 1, arg.ResimBoyut - 1, arg.ResimBoyut - 1));
                shift += arg.ResimBoyut;

                //Eger parantezId 1 ise parantezKapa Sembolu ciz
                if (arg.ParantezId == 1)
                {
                    graphics.DrawImage(ParantezKapaResmiUret(), new Rectangle(shift, 1, parantezGenislik, arg.ResimBoyut));
                    shift += parantezGenislik;
                }

                //Ok isareti Ciz
                graphics.DrawImage(OkResmiUret(), new Rectangle(shift, arg.ResimBoyut / 3, isaretGenislik, isaretGenislik));

                shift += isaretGenislik;

                //Soru Isareti Ciz.
                graphics.DrawImage(SoruIsaretResmiUret(), new Rectangle(shift, 1, arg.ResimBoyut - 1, arg.ResimBoyut - 1)); graphics.Flush();

            }

            return sonuc;
        }

        public static CiktiResim IslemSoruResimUret2(KuraliBulSatirArg arg)
        {
            var isaretGenislik = arg.ResimBoyut / 3 - 1;
            int tabloEn;
            var tablo = arg.NormalFiyatList == null ? GucluZayifTabloOlustur(arg.Havuz, arg.PahaliFiyatList, arg.UcuzFiyatList, arg.ResimBoyut / 5, out tabloEn) :
                GucluNromalZayifTabloOlustur(arg.Havuz, arg.PahaliFiyatList, arg.NormalFiyatList, arg.UcuzFiyatList, arg.ResimBoyut / 5, out tabloEn);
            var parantezGenislik = arg.ResimBoyut / 3;
            var resimGenislik = 10 + tabloEn + 4 * arg.ResimBoyut + 3 * isaretGenislik + 2 * parantezGenislik;

            var sonuc = new CiktiResim { Image = new Bitmap(resimGenislik, arg.ResimBoyut + (int)(arg.ResimBoyut * .2), PixelFormat.Format32bppArgb) };

            using (var graphics = KanavaGetir(sonuc.Image))
            {
                var shift = 1;
                //GucluZayif Tablo Olustur
                graphics.DrawImage(tablo.Image, new Rectangle(1, 1, tabloEn, arg.ResimBoyut - 2));

                shift += tabloEn + 10;
                //Eger parantezId 0 ise parantezAc Sembolu ciz
                if (arg.ParantezId == 0)
                {
                    graphics.DrawImage(ParantezAcResmiUret(), new Rectangle(shift, 1, parantezGenislik, arg.ResimBoyut + (int)(arg.ResimBoyut * .2)));
                    shift += parantezGenislik;
                }

                //Birinci resmi ciz
                graphics.DrawImage(MelezResimUret(ResimUret(arg.Havuz, arg.Resim1, arg.ResimBoyut),
                    arg.Resim1FiyatToplam.ToString(), arg.ResimBoyut, 4).Image,
                    new Rectangle(shift, 1, arg.ResimBoyut - 1, arg.ResimBoyut + (int)(arg.ResimBoyut * .2) - 1));
                shift += arg.ResimBoyut;

                //Birinci Islemi ciz
                graphics.DrawImage(arg.Islem1 ? UpResmiUret() : DownResmiUret(),
                    new Rectangle(shift, arg.ResimBoyut / 3, isaretGenislik, isaretGenislik));

                shift += isaretGenislik;

                //Eger parantezId 1 ise parantezAc Sembolu ciz
                if (arg.ParantezId == 1)
                {
                    graphics.DrawImage(ParantezAcResmiUret(), new Rectangle(shift, 1, parantezGenislik, arg.ResimBoyut + (int)(arg.ResimBoyut * .2)));
                    shift += parantezGenislik;
                }

                //Ikinci Resmi ciz.
                graphics.DrawImage(MelezResimUret(ResimUret(arg.Havuz, arg.Resim2, arg.ResimBoyut),
                    arg.Resim2FiyatToplam.ToString(), arg.ResimBoyut, 4).Image,
                    new Rectangle(shift, 1, arg.ResimBoyut - 1, arg.ResimBoyut + (int)(arg.ResimBoyut * .2) - 1));
                shift += arg.ResimBoyut;

                //Eger parantezId 0 ise parantezKapa Sembolu ciz
                if (arg.ParantezId == 0)
                {
                    graphics.DrawImage(ParantezKapaResmiUret(), new Rectangle(shift, 1, parantezGenislik, arg.ResimBoyut + (int)(arg.ResimBoyut * .2)));
                    shift += parantezGenislik;
                }

                //Ikinci Islemi ciz
                graphics.DrawImage(arg.Islem2 ? UpResmiUret() : DownResmiUret(),
                    new Rectangle(shift, arg.ResimBoyut / 3, isaretGenislik, isaretGenislik));

                shift += isaretGenislik;

                //Ucuncu Resmi ciz.
                graphics.DrawImage(MelezResimUret(ResimUret(arg.Havuz, arg.Resim3, arg.ResimBoyut),
                    arg.Resim3FiyatToplam.ToString(), arg.ResimBoyut, 4).Image,
                    new Rectangle(shift, 1, arg.ResimBoyut - 1, arg.ResimBoyut + (int)(arg.ResimBoyut * .2) - 1));
                shift += arg.ResimBoyut;

                //Eger parantezId 1 ise parantezKapa Sembolu ciz
                if (arg.ParantezId == 1)
                {
                    graphics.DrawImage(ParantezKapaResmiUret(), new Rectangle(shift, 1, parantezGenislik, arg.ResimBoyut + (int)(arg.ResimBoyut * .2)));
                    shift += parantezGenislik;
                }

                //Ok isareti Ciz
                graphics.DrawImage(OkResmiUret(), new Rectangle(shift, arg.ResimBoyut / 3, isaretGenislik, isaretGenislik));

                shift += isaretGenislik;

                //Soru Isareti Ciz.
                graphics.DrawImage(SoruIsaretResmiUret(), new Rectangle(shift, 1, arg.ResimBoyut - 1, arg.ResimBoyut - 1)); graphics.Flush();

            }

            return sonuc;
        }

        public static CiktiResim IslemSoruResimUret(Havuz.Havuz havuz, Dictionary<string, int> resim1,
          Dictionary<string, int> resim2, bool buyukMu,
          Dictionary<string, int> gucluList, Dictionary<string, int> zayifList, int resimBoyut)
        {
            var isaretGenislik = resimBoyut / 3 - 1;
            var tabloEn = 0;
            var tablo = GucluZayifTabloOlustur(havuz, gucluList, zayifList, resimBoyut / 5, out tabloEn);
            var resimGenislik = tabloEn + resimBoyut + isaretGenislik + resimBoyut + isaretGenislik + resimBoyut;


            var sonuc = new CiktiResim { Image = new Bitmap(resimGenislik, resimBoyut, PixelFormat.Format32bppArgb) };

            using (var graphics = KanavaGetir(sonuc.Image))
            {
                var shift = 1;

                graphics.DrawImage(tablo.Image, new Rectangle(1, 1, tabloEn, resimBoyut - 2));

                shift += tabloEn;

                graphics.DrawImage(ResimUret(havuz, resim1, resimBoyut).Image, new Rectangle(shift, 1, resimBoyut - 1, resimBoyut - 1));

                shift += resimBoyut;

                graphics.DrawImage(buyukMu ? UpResmiUret() : DownResmiUret(),
                    new Rectangle(shift, resimBoyut / 3, isaretGenislik, isaretGenislik));

                shift += isaretGenislik;

                graphics.DrawImage(ResimUret(havuz, resim2, resimBoyut).Image, new Rectangle(shift, 1, resimBoyut - 1, resimBoyut - 1));

                shift += resimBoyut;

                graphics.DrawImage(OkResmiUret(), new Rectangle(shift, resimBoyut / 3, isaretGenislik, isaretGenislik));

                shift += isaretGenislik;

                graphics.DrawImage(SoruIsaretResmiUret(), new Rectangle(shift, 1, resimBoyut - 1, resimBoyut - 1)); graphics.Flush();
            }
            return sonuc;
        }

        public static CiktiResim IslemSoruResimUret(Havuz.Havuz havuz, Dictionary<string, int> resim1,
           Dictionary<string, int> resim2, bool buyukMu, int resimBoyut)
        {
            var isaretGenislik = resimBoyut / 3 - 1;
            var resimGenislik = resimBoyut + isaretGenislik + resimBoyut + isaretGenislik + resimBoyut;

            var sonuc = new CiktiResim { Image = new Bitmap(resimGenislik, resimBoyut, PixelFormat.Format32bppArgb) };

            using (var graphics = KanavaGetir(sonuc.Image))
            {
                var shift = 1;

                graphics.DrawImage(ResimUret(havuz, resim1, resimBoyut).Image, new Rectangle(shift, 1, resimBoyut - 1, resimBoyut - 1));

                shift += resimBoyut;

                graphics.DrawImage(buyukMu ? UpResmiUret() : DownResmiUret(),
                    new Rectangle(shift, resimBoyut / 3, isaretGenislik, isaretGenislik));

                shift += isaretGenislik;

                graphics.DrawImage(ResimUret(havuz, resim2, resimBoyut).Image, new Rectangle(shift, 1, resimBoyut - 1, resimBoyut - 1));

                shift += resimBoyut;

                graphics.DrawImage(OkResmiUret(), new Rectangle(shift, resimBoyut / 3, isaretGenislik, isaretGenislik));

                shift += isaretGenislik;

                graphics.DrawImage(SoruIsaretResmiUret(), new Rectangle(shift, 1, resimBoyut - 1, resimBoyut - 1)); graphics.Flush();
            }
            return sonuc;
        }

        public static CiktiResim IslemSoruResimUret(Havuz.Havuz havuz, Dictionary<string, int> resim1,
          Dictionary<string, int> resim2, bool buyukMu,
          Dictionary<string, bool> resim1RenkList, Dictionary<string, bool> resim2RenkList,
          Dictionary<string, bool> sonucRenkList, int resimBoyut)
        {
            var isaretGenislik = resimBoyut / 3 - 1;
            var resimGenislik = resimBoyut + isaretGenislik + resimBoyut + isaretGenislik + resimBoyut;

            var sonuc = new CiktiResim { Image = new Bitmap(resimGenislik, resimBoyut, PixelFormat.Format32bppArgb) };

            using (var graphics = KanavaGetir(sonuc.Image))
            {
                var shift = 1;

                graphics.DrawImage(ResimUret(havuz, resim1, resim1RenkList, resimBoyut).Image, new Rectangle(shift, 1, resimBoyut - 1, resimBoyut - 1));

                shift += resimBoyut;

                graphics.DrawImage(buyukMu ? UpResmiUret() : DownResmiUret(),
                    new Rectangle(shift, resimBoyut / 3, isaretGenislik, isaretGenislik));

                shift += isaretGenislik;

                graphics.DrawImage(ResimUret(havuz, resim2, resim2RenkList, resimBoyut).Image, new Rectangle(shift, 1, resimBoyut - 1, resimBoyut - 1));

                shift += resimBoyut;

                graphics.DrawImage(OkResmiUret(), new Rectangle(shift, resimBoyut / 3, isaretGenislik, isaretGenislik));

                shift += isaretGenislik;

                graphics.DrawImage(SoruIsaretResmiUret(), new Rectangle(shift, 1, resimBoyut - 1, resimBoyut - 1)); graphics.Flush();
            }
            return sonuc;
        }

        public static CiktiResim IslemSoruResimUret(CiktiResim resim1, CiktiResim resim2, int resimBoyut)
        {
            var isaretGenislik = resimBoyut / 3 - 1;
            var resimGenislik = resim1.Image.Width + isaretGenislik + resim2.Image.Width + isaretGenislik + resim2.Image.Width;
            var yukseklik = resim1.Image.Height >= resim2.Image.Height ? resim1.Image.Height : resim2.Image.Height;

            var sonuc = new CiktiResim
            {
                Image = new Bitmap(resimGenislik, yukseklik, PixelFormat.Format32bppArgb),
                ParcaList = resim1.ParcaList,
                DigerResimParcaList = resim2.ParcaList
            };

            using (var graphics = KanavaGetir(sonuc.Image))
            {
                var shift = 1;
                graphics.DrawImage(resim1.Image, new Rectangle(1, 1, resim1.Image.Width - 2, resim1.Image.Height - 2));

                shift += resim1.Image.Width - 2;

                graphics.DrawImage(YildizResmiUret(), new Rectangle(shift, resimBoyut / 3, isaretGenislik, isaretGenislik));

                shift += isaretGenislik;

                graphics.DrawImage(resim2.Image, new Rectangle(shift, 1, resim2.Image.Width - 1, resim2.Image.Height - 1));

                shift += resim2.Image.Width - 2;

                graphics.DrawImage(OkResmiUret(), new Rectangle(shift, resimBoyut / 3, isaretGenislik, isaretGenislik));

                shift += isaretGenislik;

                graphics.DrawImage(SoruIsaretResmiUret(), new Rectangle(shift, resimBoyut / 3, isaretGenislik, isaretGenislik));

                graphics.Flush();
            }
            return sonuc;
        }

        public static CiktiResim IslemSoruResimUret(CiktiResim resim1, CiktiResim resim2, CiktiResim matematikResim, int resimBoyut)
        {
            var isaretGenislik = resimBoyut / 3 - 1;
            var resimGenislik = resim1.Image.Width + isaretGenislik + resim2.Image.Width + isaretGenislik + resim2.Image.Width + 8 + matematikResim.Image.Width;
            var yukseklik = resim1.Image.Height >= resim2.Image.Height ? resim1.Image.Height : resim2.Image.Height;

            var sonuc = new CiktiResim
            {
                Image = new Bitmap(resimGenislik, yukseklik, PixelFormat.Format32bppArgb),
                ParcaList = resim1.ParcaList,
                DigerResimParcaList = resim2.ParcaList
            };

            using (var graphics = KanavaGetir(sonuc.Image))
            {
                var shift = 10;
                graphics.DrawImage(resim1.Image, new Rectangle(1, 1, resim1.Image.Width - 2, resim1.Image.Height - 2));

                shift += resim1.Image.Width - 2;

                graphics.DrawImage(YildizResmiUret(), new Rectangle(shift, resimBoyut / 3, isaretGenislik, isaretGenislik));

                shift += isaretGenislik;

                graphics.DrawImage(resim2.Image, new Rectangle(shift, 1, resim2.Image.Width - 1, resim2.Image.Height - 1));

                shift += resim2.Image.Width - 2;

                graphics.DrawImage(OkResmiUret(), new Rectangle(shift, resimBoyut / 3, isaretGenislik, isaretGenislik));

                shift += isaretGenislik;

                graphics.DrawImage(SoruIsaretResmiUret(), new Rectangle(shift, resimBoyut / 3, isaretGenislik, isaretGenislik));

                shift += resim2.Image.Width + 4;

                graphics.DrawImage(matematikResim.Image, new Rectangle(shift, 1, matematikResim.Image.Width - 1, matematikResim.Image.Height - 1));

                graphics.Flush();
            }
            return sonuc;
        }

        public static CiktiResim ParcaDegistir(Havuz.Havuz havuz, CiktiResim referansResim, Dictionary<string, int> yeniParcaDegerList, int resimBoyut)
        {
            var sonuc = new CiktiResim { Image = new Bitmap(resimBoyut, resimBoyut, PixelFormat.Format32bppArgb) };
            using (var graphics = KanavaGetir(sonuc.Image))
            {
                foreach (var parca in referansResim.ParcaList)
                {
                    var seciliHavuzParcasi = havuz.ParcaList.FirstOrDefault(s => s.Ad == parca.Key);
                    var id = parca.Value;
                    if (seciliHavuzParcasi != null)
                    {
                        if (yeniParcaDegerList.ContainsKey(parca.Key))
                        {
                            id = yeniParcaDegerList[parca.Key];
                        }
                        var yeniParcaResmi = seciliHavuzParcasi.ResimList[id].Nesne;
                        sonuc.ParcaList.Add(parca.Key, id);
                        graphics.DrawImage(yeniParcaResmi, new Rectangle(0, 0, resimBoyut, resimBoyut));
                    }
                }
            }
            return sonuc;
        }


        public static CiktiResim ParcaDegistir(Havuz.Havuz havuz, Dictionary<string, int> referansResim1,
            Dictionary<string, int> referansResim2, out CiktiResim yeniReferansResim2,
            List<string> degisecekParcaList, int resimBoyut)
        {


            foreach (var parcaAd in degisecekParcaList)
            {
                var tmp = referansResim1[parcaAd];
                referansResim1[parcaAd] = referansResim2[parcaAd];
                referansResim2[parcaAd] = tmp;
            }

            yeniReferansResim2 = ResimUret(havuz, referansResim2, resimBoyut);

            return ResimUret(havuz, referansResim1, resimBoyut);
        }

        public static CiktiResim IkiliResimUret(CiktiResim resim1, CiktiResim resim2, int resimBoyut)
        {
            var isaretBoyut = resimBoyut / 3;
            var sonuc = new CiktiResim { Image = new Bitmap((resimBoyut + isaretBoyut + resimBoyut), resimBoyut, PixelFormat.Format32bppArgb) };

            using (var graphics = KanavaGetir(sonuc.Image))
            {
                var shift = 1;
                graphics.DrawImage(resim1.Image, new Rectangle(shift, 1, resimBoyut - 1, resimBoyut - 1));
                shift += resimBoyut;
                graphics.DrawImage(CiftOkResmiUret(), new Rectangle(shift, (resimBoyut - isaretBoyut) / 2, isaretBoyut, isaretBoyut));
                shift += isaretBoyut;
                graphics.DrawImage(resim2.Image, new Rectangle(shift, 1, resimBoyut - 1, resimBoyut - 1));
                graphics.Flush();
            }
            return sonuc;
        }

        /// <summary>
        /// Iki resmi birlestirir ancak resimlerden buyuk olanin yuksekligi ve genisligine gore kanava olusturur.
        /// Ayrica Iki Resim arasina cizgi atar. EsResim ve EsOlmayanResim sorularinda kullanilir.
        /// </summary>
        /// <param name="resim1">Butun veya parca Resim</param>
        /// <param name="resim2">Butun veya parca resim</param>
        /// <param name="resimBoyut">Standart resim boyu</param>
        /// <returns></returns>
        public static CiktiResim IkiResimBirlestir(CiktiResim resim1, CiktiResim resim2, int resimBoyut)
        {
            var isaretBoyut = 3;
            var yukseklik = resim1.Image.Height >= resim2.Image.Height ? resim1.Image.Height : resim2.Image.Height;

            var sonuc = new CiktiResim
            {
                Image = new Bitmap((resim1.Image.Width + 20 + isaretBoyut + resim2.Image.Width), yukseklik, PixelFormat.Format32bppArgb),
                ParcaList = resim1.ParcaList,
                DigerResimParcaList = resim2.ParcaList
            };

            using (var graphics = KanavaGetir(sonuc.Image))
            {
                var shift = 1;
                graphics.DrawImage(resim1.Image, new Rectangle(shift, 1, resim1.Image.Width, resim1.Image.Height));
                shift += resim1.Image.Width + 15;
                graphics.DrawLine(new Pen(Color.DarkBlue, (float)isaretBoyut), new Point(shift, 2), new Point(shift, yukseklik - 2));
                shift += isaretBoyut;
                graphics.DrawImage(resim2.Image, new Rectangle(shift, 1, resim2.Image.Width, resim2.Image.Height));
                graphics.Flush();
            }
            return sonuc;
        }

        public static CiktiResim UcResimBirlestir(CiktiResim resim1, CiktiResim resim2, CiktiResim resim3, int resimBoyut)
        {
            var isaretBoyut = 3;
            var yukseklik = resim1.Image.Height >= resim2.Image.Height ?
                                    resim1.Image.Height >= resim3.Image.Height ?
                                        resim1.Image.Height :
                                    resim3.Image.Height :
                                resim2.Image.Height;

            var sonuc = new CiktiResim
            {
                Image = new Bitmap((resim1.Image.Width + 40 + isaretBoyut + resim2.Image.Width + isaretBoyut + resim3.Image.Width), yukseklik, PixelFormat.Format32bppArgb),
                ParcaList = resim1.ParcaList,
                DigerResimParcaList = resim2.ParcaList,
                DonusumList = resim3.ParcaList
            };

            using (var graphics = KanavaGetir(sonuc.Image))
            {
                var shift = 1;
                graphics.DrawImage(resim1.Image, new Rectangle(shift, 1, resim1.Image.Width, resim1.Image.Height));
                shift += resim1.Image.Width + 15;
                graphics.DrawLine(new Pen(Color.DarkBlue, (float)isaretBoyut), new Point(shift, 2), new Point(shift, yukseklik - 2));
                shift += isaretBoyut;
                graphics.DrawImage(resim2.Image, new Rectangle(shift, 1, resim2.Image.Width, resim2.Image.Height));
                shift += resim2.Image.Width + 15;
                graphics.DrawLine(new Pen(Color.DarkBlue, (float)isaretBoyut), new Point(shift, 2), new Point(shift, yukseklik - 2));
                shift += isaretBoyut;
                graphics.DrawImage(resim3.Image, new Rectangle(shift, 1, resim3.Image.Width, resim3.Image.Height));
                graphics.Flush();
            }
            return sonuc;
        }


        /// <summary>
        /// Verilen referans resmi ve parca listesini kullanarak 3x3 matris olusturur.
        /// </summary>
        /// <param name="resim1">Butun veya parca Resim</param>
        /// <param name="resim2">Butun veya parca resim</param>
        /// <param name="resimBoyut">Standart resim boyu</param>
        /// <returns></returns>
        public static CiktiResim MatrisOlustur(Havuz.Havuz havuz, CiktiResim resim1, Dictionary<string, int> parcaList, int resimBoyut)
        {
            var cizgiKalinlik = 3;
            var hucreBoyut = (int)resimBoyut / 3 - 9;

            var sonuc = new CiktiResim
            {
                Image = new Bitmap((hucreBoyut + 6) * 3, (hucreBoyut + 6) * 3, PixelFormat.Format32bppArgb),
                ParcaList = resim1.ParcaList,
                DigerResimParcaList = parcaList
            };

            //Her hucre icin baslangic koordinatini hesapla
            var startPointList = new Point[3, 3];
            startPointList[0, 0] = new Point(cizgiKalinlik + 1, cizgiKalinlik + 1);
            startPointList[0, 1] = new Point(cizgiKalinlik + 1 + hucreBoyut + 1 + cizgiKalinlik + 1, cizgiKalinlik + 1);
            startPointList[0, 2] = new Point(2 * (cizgiKalinlik) + 2 * (1 + hucreBoyut + 1) + cizgiKalinlik + 1, cizgiKalinlik + 1);

            startPointList[1, 0] = new Point(cizgiKalinlik + 1, cizgiKalinlik + 1 + hucreBoyut + 1 + cizgiKalinlik + 1);
            startPointList[1, 1] = new Point(cizgiKalinlik + 1 + hucreBoyut + 1 + cizgiKalinlik + 1, cizgiKalinlik + 1 + hucreBoyut + 1 + cizgiKalinlik + 1);
            startPointList[1, 2] = new Point(2 * (cizgiKalinlik) + 2 * (1 + hucreBoyut + 1) + cizgiKalinlik + 1, cizgiKalinlik + 1 + hucreBoyut + 1 + cizgiKalinlik + 1);


            startPointList[2, 0] = new Point(cizgiKalinlik + 1, 2 * (cizgiKalinlik) + 2 * (1 + hucreBoyut + 1) + cizgiKalinlik + 1);
            startPointList[2, 1] = new Point(cizgiKalinlik + 1 + hucreBoyut + 1 + cizgiKalinlik + 1, 2 * (cizgiKalinlik) + 2 * (1 + hucreBoyut + 1) + cizgiKalinlik + 1);
            startPointList[2, 2] = new Point(2 * (cizgiKalinlik) + 2 * (1 + hucreBoyut + 1) + cizgiKalinlik + 1, 2 * (cizgiKalinlik) + 2 * (1 + hucreBoyut + 1) + cizgiKalinlik + 1);

            using (var graphics = KanavaGetir(sonuc.Image))
            {
                #region Cizgileri olustur

                //Sutun0
                graphics.DrawLine(new Pen(Color.DarkBlue, (float)cizgiKalinlik), new Point(0, 0), new Point(0, resimBoyut));
                //Satir0
                graphics.DrawLine(new Pen(Color.DarkBlue, (float)cizgiKalinlik), new Point(0, 0), new Point(resimBoyut, 0));
                //Sutun1 
                var sutun1 = cizgiKalinlik + 3 + 1 + hucreBoyut + 1;
                graphics.DrawLine(new Pen(Color.DarkBlue, (float)cizgiKalinlik), new Point(sutun1, 0), new Point(sutun1, resimBoyut));
                //Satir2
                graphics.DrawLine(new Pen(Color.DarkBlue, (float)cizgiKalinlik), new Point(0, sutun1), new Point(resimBoyut, sutun1));
                //Sutun2
                var sutun2 = sutun1 + cizgiKalinlik + 1 + hucreBoyut + 1;
                graphics.DrawLine(new Pen(Color.DarkBlue, (float)cizgiKalinlik), new Point(sutun2, 0), new Point(sutun2 + 6, resimBoyut));
                //Satir2
                graphics.DrawLine(new Pen(Color.DarkBlue, (float)cizgiKalinlik), new Point(0, sutun2), new Point(resimBoyut, sutun2));
                //Sutun3
                var sutun3 = sutun2 + cizgiKalinlik + 1 + hucreBoyut + 1;
                graphics.DrawLine(new Pen(Color.DarkBlue, (float)cizgiKalinlik), new Point(sutun3, 0), new Point(sutun3, resimBoyut));
                //Satir2
                graphics.DrawLine(new Pen(Color.DarkBlue, (float)cizgiKalinlik), new Point(0, sutun3), new Point(resimBoyut, sutun3));


                #endregion

                //Referans resmi ciz
                graphics.DrawImage(resim1.Image, new Rectangle(startPointList[1, 1], new Size(hucreBoyut, hucreBoyut)));


                var currCell = 0;
                foreach (var parca in parcaList)
                {
                    var parcaResim = havuz.ParcaList.FirstOrDefault(s => s.Ad == parca.Key).ResimList[parca.Value].Nesne;
                    switch (currCell)
                    {
                        case 0:
                            graphics.DrawImage(parcaResim, new Rectangle(startPointList[0, 0], new Size(hucreBoyut, hucreBoyut)));
                            break;
                        case 1:
                            graphics.DrawImage(parcaResim, new Rectangle(startPointList[0, 1], new Size(hucreBoyut, hucreBoyut)));
                            break;
                        case 2:
                            graphics.DrawImage(parcaResim, new Rectangle(startPointList[0, 2], new Size(hucreBoyut, hucreBoyut)));
                            break;
                        case 3:
                            graphics.DrawImage(parcaResim, new Rectangle(startPointList[1, 0], new Size(hucreBoyut, hucreBoyut)));
                            break;
                        case 4:
                            graphics.DrawImage(parcaResim, new Rectangle(startPointList[1, 2], new Size(hucreBoyut, hucreBoyut)));
                            break;
                        case 5:
                            graphics.DrawImage(parcaResim, new Rectangle(startPointList[2, 0], new Size(hucreBoyut, hucreBoyut)));
                            break;
                        case 6:
                            graphics.DrawImage(parcaResim, new Rectangle(startPointList[2, 1], new Size(hucreBoyut, hucreBoyut)));
                            break;
                        case 7:
                            graphics.DrawImage(parcaResim, new Rectangle(startPointList[2, 2], new Size(hucreBoyut, hucreBoyut)));
                            break;
                    }
                    currCell++;
                    if (currCell > 7)
                    {
                        currCell = 0;
                    }
                }

                if (parcaList.Count < 8)
                {
                    var kalanHucre = 8 - parcaList.Count;
                    do
                    {
                        foreach (var parca in parcaList)
                        {
                            var havuzParca = havuz.ParcaList.FirstOrDefault(s => s.Ad == parca.Key);
                            var newId = RandomHelper.RandomDifferentNumber(0, havuzParca.ResimList.Count - 1, parca.Value);
                            var parcaResim = havuzParca.ResimList[newId].Nesne;
                            switch (currCell)
                            {
                                case 0:
                                    graphics.DrawImage(parcaResim, new Rectangle(startPointList[0, 0], new Size(hucreBoyut, hucreBoyut)));
                                    break;
                                case 1:
                                    graphics.DrawImage(parcaResim, new Rectangle(startPointList[0, 1], new Size(hucreBoyut, hucreBoyut)));
                                    break;
                                case 2:
                                    graphics.DrawImage(parcaResim, new Rectangle(startPointList[0, 2], new Size(hucreBoyut, hucreBoyut)));
                                    break;
                                case 3:
                                    graphics.DrawImage(parcaResim, new Rectangle(startPointList[1, 0], new Size(hucreBoyut, hucreBoyut)));
                                    break;
                                case 4:
                                    graphics.DrawImage(parcaResim, new Rectangle(startPointList[1, 2], new Size(hucreBoyut, hucreBoyut)));
                                    break;
                                case 5:
                                    graphics.DrawImage(parcaResim, new Rectangle(startPointList[2, 0], new Size(hucreBoyut, hucreBoyut)));
                                    break;
                                case 6:
                                    graphics.DrawImage(parcaResim, new Rectangle(startPointList[2, 1], new Size(hucreBoyut, hucreBoyut)));
                                    break;
                                case 7:
                                    graphics.DrawImage(parcaResim, new Rectangle(startPointList[2, 2], new Size(hucreBoyut, hucreBoyut)));
                                    break;
                            }
                            currCell++;
                            if (currCell > 7)
                            {
                                currCell = 0;
                            }
                            kalanHucre--;
                        }
                    } while (kalanHucre > 0);

                }

                graphics.Flush();
            }
            return sonuc;
        }

        public static CiktiResim IslemSoruResmiUret(CiktiResim resim1, CiktiResim resim2, int resimBoyut)
        {
            var sonuc = new CiktiResim { Image = new Bitmap((resimBoyut + resimBoyut / 3 + resimBoyut + resimBoyut / 10 * 6), resimBoyut, PixelFormat.Format32bppArgb) };

            using (var graphics = KanavaGetir(sonuc.Image))
            {

                graphics.DrawImage(resim1.Image, new Rectangle(1, 1, resimBoyut - 2, resimBoyut - 2));
                graphics.DrawImage(CiftOkResmiUret(), new Rectangle(resimBoyut, resimBoyut / 25 * 10, resimBoyut / 3, resimBoyut / 3));
                graphics.DrawImage(resim2.Image, new Rectangle(resimBoyut + resimBoyut / 3 + 1, 1, resimBoyut - 2, resimBoyut - 2));
                graphics.DrawImage(SoruIsaretResmiUret(), new Rectangle(resimBoyut + resimBoyut + resimBoyut / 3 + 1, (resimBoyut - resimBoyut / 10 * 6) / 2, resimBoyut / 10 * 6, resimBoyut / 10 * 6));
                graphics.Flush();
            }
            return sonuc;
        }

        public static CiktiResim ParcaResimUret(Havuz.Havuz havuz, Dictionary<string, int> parcaIdList, int parcaResimBoyut)
        {

            var satirAdet = (int)Math.Ceiling((decimal)havuz.ParcaList.Count / 3);
            var sonuc = new CiktiResim { Image = new Bitmap(parcaResimBoyut * 3, satirAdet * parcaResimBoyut, PixelFormat.Format32bppArgb) };

            using (var graphics = KanavaGetir(sonuc.Image))
            {
                for (int i = 0; i < satirAdet; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        var parcaId = i * 3 + j;
                        if (parcaId == havuz.ParcaList.Count)
                        {
                            break;
                        }
                        var parca = havuz.ParcaList[parcaId];

                        if (parcaIdList.Keys.Contains(parca.Ad))
                        {
                            int parcaResimId = parcaIdList[parca.Ad];

                            sonuc.DonusumList.Add(parca.Ad, parcaResimId);

                            graphics.DrawImage(parca.DonusumResimList[parcaResimId].Nesne,
                                new Rectangle(j * parcaResimBoyut + 1, i * parcaResimBoyut + 1, parcaResimBoyut - 1,
                                    parcaResimBoyut - 1));
                        }
                    }

                }
                graphics.Flush();
            }
            return sonuc;
        }
    }
}
