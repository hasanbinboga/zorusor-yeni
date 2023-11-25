using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BilisselBeceriler.Entities.Imaging;
using System.Drawing;
using System.IO;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace BilisselBeceriler.ImagingService
{
    public class ImageResizer : IImageResizer
    {
        /// <summary>
        /// Girilen metni bir resme yazarak resmi döndürür.
        /// </summary>
        /// <param name="metin"> Resme çevrilecek metin</param>
        /// <param name="width"> Döndürelecek image ın pixel genişliği </param>
        /// <param name="height"> Döndürelecek image ın pixel yüksekliği</param>
        /// <returns></returns>
        public Image MetniResimeCevir(string metin, int width, int height)
        {
            try
            {
                Font f = new Font("Tahoma", height, GraphicsUnit.Pixel);
                Bitmap bmp = new Bitmap(width, height);
                System.Drawing.Image img = (System.Drawing.Image)bmp;
                Graphics g = Graphics.FromImage(img);
                g.FillRectangle(new SolidBrush(Color.FromArgb(242, 249, 255)), 0, 0, width, height);
                g.DrawString(metin, f, new SolidBrush(Color.FromArgb(51, 51, 102)), 0, -(float)height / 5);
                return img;
            }
            catch (Exception ex)
            {
                throw new Exception("MetniResmeÇevir|metin=" + metin + "|width=" + width.ToString() + "|height=" + height.ToString(), ex);
            }

        }
        /// <summary>
        /// gif formatındaki resmi yüksek kalitede jpg formatına çevirir.
        /// </summary>
        /// <param name="img"></param>
        /// <param name="Quality"></param>
        /// <returns></returns>
        public Image SaveJPEG(Image img, long Quality)
        {
            System.Drawing.Image sonuc;
            using (MemoryStream ms = new MemoryStream())
            {
                ImageCodecInfo[] encoders = ImageCodecInfo.GetImageEncoders();
                EncoderParameters encoderParameters = new EncoderParameters(1);
                encoderParameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, Quality);
                foreach (ImageCodecInfo encoder in encoders)
                {
                    if (encoder.MimeType == "image/jpeg")
                    {
                        img.Save(ms, encoder, encoderParameters);
                    }
                }
                sonuc = System.Drawing.Image.FromStream(ms);
            }
            return sonuc;
        }
        /// <summary>
        /// Resmi belirtilen sınırlar içerisinde kalacak şekilde orantılı boyutlandırır.
        /// Eğer format jpeg ise yüksek kalitede orantılama yapar.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public Image Boyutlandir(Image i, int width, int height)
        {
            double x = (double)i.Width;
            double y = (double)i.Height;
            double sx = (double)width;
            double sy = (double)height;
            int ResimX, ResimY;
            double k = 1;

            System.Drawing.Image resim;

            if (((x / y) > (sx / sy)) || ((x / y) == (sx / sy)))
            {
                if (x > sx) k = sx / x;
            }
            else
            {
                if (y > sy) k = sy / y;
            }
            x = x * k;
            y = y * k;

            ResimX = (int)Math.Floor(x);
            ResimY = (int)Math.Floor(y);
            try
            {
                resim = ResimBoyutlandir(i, ResimX, ResimY);
                return resim;
            }
            catch (Exception ex)
            {
                throw new Exception("Boyutlandir|width=" + width.ToString() + "|height=" + height.ToString(), ex);
            }

        }
        /// <summary>
        /// Resmi belirtilen degerlerde yüksek kalitede yeniden boyutalndırır
        /// </summary>
        /// <param name="image"></param>
        /// <param name="Width"></param>
        /// <param name="Height"></param>
        /// <returns></returns>
        public Image ResimBoyutlandir(Image image, int? Width, int? Height)
        {
            double new_height = Height ?? 0;
            double new_width = Width ?? 0;
            Bitmap bitmap = new Bitmap((int)new_width, (int)new_height);
            bitmap.SetResolution(image.HorizontalResolution, image.VerticalResolution);
            ImageAttributes ia = new ImageAttributes();
            ia.SetWrapMode(WrapMode.TileFlipXY);
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.CompositingQuality = CompositingQuality.HighQuality;
            graphics.InterpolationMode = InterpolationMode.High;
            graphics.CompositingMode = CompositingMode.SourceCopy;
            graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            graphics.DrawImage(image, new Rectangle(0, 0, bitmap.Width, bitmap.Height), 0, 0, image.Width, image.Height, System.Drawing.GraphicsUnit.Pixel, ia);
            return (System.Drawing.Image)bitmap;
        }
        /// <summary>
        /// Resmin sağ üst köşesine logo ekler, ve belirtilen stringi(Maximum 10 karakter) resmin altına yazar
        /// </summary>
        /// <param name="i"></param>
        /// <param name="Tarih"></param>
        /// <returns></returns>
        public Image MetinLogoEkle(Image Foto, string Metin, string logoYol)
        {
            Bitmap bmFoto = new Bitmap(Foto.Width, Foto.Height, PixelFormat.Format24bppRgb);
            bmFoto.SetResolution(Foto.HorizontalResolution, Foto.VerticalResolution);
            Graphics grFoto = Graphics.FromImage(bmFoto);
            int FotoWidth = Foto.Width;
            int FotoHeight = Foto.Height;
            int MetinX, MetinY;
            grFoto.SmoothingMode = SmoothingMode.AntiAlias;

            grFoto.DrawImage(Foto, new Rectangle(0, 0, FotoWidth, FotoHeight), 0, 0, FotoWidth, FotoHeight, GraphicsUnit.Pixel);

            StringFormat StrFormat = new StringFormat();
            StrFormat.Alignment = StringAlignment.Center;

            SolidBrush MetinBrush = new SolidBrush(Color.FromArgb(153, 0, 0, 0));
            Font MetinFont = new Font("Arial", 20, FontStyle.Regular);
            MetinX = (int)(((double)FotoWidth) / 2);
            MetinY = FotoHeight - 30;

            grFoto.DrawString(Metin, MetinFont, MetinBrush, new PointF(MetinX + 1, MetinY + 1), StrFormat);
            MetinBrush = new SolidBrush(Color.FromArgb(153, 255, 255, 255));

            grFoto.DrawString(Metin, MetinFont, MetinBrush, new PointF(MetinX, MetinY), StrFormat);

            if (logoYol != null)
            {
                System.Drawing.Image Logo = System.Drawing.Image.FromFile(logoYol);
                int LogoWidth = Logo.Width;
                int LogoHeight = Logo.Height;
                grFoto.DrawImage(Logo, new Rectangle(FotoWidth - 60, 15, LogoWidth, LogoHeight),
                   0, 0, LogoWidth, LogoHeight, GraphicsUnit.Pixel);
                Logo.Dispose();
            }

            grFoto.Dispose();
            System.Drawing.Image ReturnImage = (System.Drawing.Image)bmFoto;
            return ReturnImage;
        }
        /// <summary>
        /// Bir resmin belirtilen koordinatlarını yüksek kalitede jpeg'e çevirir ve döndürür.
        /// Koordinatlar piksel cinsinden verilmelidir.
        /// </summary>
        /// <param name="orjinalResim"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public Image GoruntuKirp(Image OrjinalResim, int x, int y, int width, int height)
        {
            using (Bitmap bmpYeni = new Bitmap(width, height))
            {
                System.Drawing.Image imgYeni = (System.Drawing.Image)bmpYeni;
                Graphics g = Graphics.FromImage(imgYeni);
                g.DrawImage(OrjinalResim, 0, 0, new Rectangle(x, y, width, height), GraphicsUnit.Pixel);
                imgYeni = SaveJPEG(imgYeni, 100);
                return imgYeni;
            }
        }
        /// <summary>
        /// Bir resmin belirtilen koordinatlarını yüksek kalitede jpeg'e çevirir ve döndürür.
        /// </summary>
        /// <param name="OrjinalResim"></param>
        /// <param name="Koordinatlar"></param>
        /// <returns></returns>
        public Image GoruntuKirp(Image OrjinalResim, Rectangle Koordinatlar)
        {
            Bitmap bmpImage = new Bitmap(OrjinalResim);
            Bitmap bmpCrop = bmpImage.Clone(Koordinatlar, bmpImage.PixelFormat);
            return SaveJPEG(bmpCrop, 100);
        }
        /// <summary>
        /// Image'ı byte dizisine atar
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public byte[] ImageToByteArray(Image img, ImageFormat format)
        {
            try
            {
                byte[] buffer;
                using (MemoryStream ms = new MemoryStream())
                {
                    img.Save(ms, format);
                    buffer = ms.ToArray();
                }
                return buffer;
            }
            catch (Exception ex)
            {
                throw new Exception("ImageToByteArray", ex);
            }
        }
        /// <summary>
        /// Verilen byte dizisini image a dönüştürür
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public Image ByteArrayToImage(byte[] buffer)
        {
            try
            {
                System.Drawing.Image img;
                using (MemoryStream ms = new MemoryStream(buffer, 0, buffer.Length, true))
                {
                    img = System.Drawing.Image.FromStream(ms);
                }
                return img;
            }
            catch (Exception ex)
            {
                throw new Exception("ByteArrayToImage", ex);
            }
        }
        /// <summary>
        /// Verilen uzantıdan imageformat döndürür
        /// </summary>
        /// <param name="uzanti"></param>
        /// <returns></returns>
        public ImageFormat UzantidanFormatBul(string uzanti)
        {
            try
            {
                uzanti = uzanti.ToLower();
                if (uzanti.StartsWith(".")) uzanti = uzanti.Substring(1, uzanti.Length - 1);
                ImageFormat format = null;
                switch (uzanti)
                {
                    case "gif":
                        format = System.Drawing.Imaging.ImageFormat.Gif;
                        break;
                    case "jpg":
                        format = System.Drawing.Imaging.ImageFormat.Jpeg;
                        break;
                    case "jpeg":
                        format = System.Drawing.Imaging.ImageFormat.Jpeg;
                        break;
                    case "tiff":
                        format = System.Drawing.Imaging.ImageFormat.Tiff;
                        break;
                    case "png":
                        format = System.Drawing.Imaging.ImageFormat.Png;
                        break;
                }
                return format;
            }
            catch (Exception ex)
            {
                throw new Exception("UzantidanFormatBul|uzanti=" + uzanti, ex);
            }
        }
        /// <summary>
        /// Verilen Stream'ın image dosyası olup olmadığını verir
        /// </summary>
        /// <param name="akim"></param>
        /// <returns></returns>
        public bool ResimDosyasiMi(Stream akim)
        {
            try
            {
                using (Bitmap bmp = new Bitmap(akim))
                {
                    return true;
                }
            }
            catch (Exception)
            { }
            return false;
        }
    }    
}
