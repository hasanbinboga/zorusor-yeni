using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace BilisselBeceriler.Entities.Imaging
{
    public interface IImageResizer
    {
        Image MetniResimeCevir(string metin, int width, int height);
        Image SaveJPEG(Image img, long Quality);
        Image Boyutlandir(Image i, int width, int height);
        Image ResimBoyutlandir(Image image, int? Width, int? Height);
        Image MetinLogoEkle(Image Foto, string Metin, string logoYol);
        Image GoruntuKirp(Image OrjinalResim, int x, int y, int width, int height);
        Image GoruntuKirp(Image OrjinalResim, Rectangle Koordinatlar);
        byte[] ImageToByteArray(Image img, ImageFormat format);
        Image ByteArrayToImage(byte[] buffer);
        ImageFormat UzantidanFormatBul(string uzanti);
        bool ResimDosyasiMi(Stream akim);        
    }
}
