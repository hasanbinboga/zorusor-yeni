using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.IO;
using Microsoft.Practices.Unity;
using BilisselBeceriler.Entities.Imaging;
using BilisselBeceriler.Data;
using BilisselBeceriler.Entities;
using System.Drawing;
using System.Drawing.Imaging;
using BilisselBeceriler.Entities.Web;

namespace BilisselBeceriler.Portal.Core.Controllers
{
    public class ImageController : BaseController
    {
        [Dependency]
        public IImageResizer ImageServis { get; set; }

        public ActionResult OkulLogo(string Url, int Width, int Height)
        {
            using (Repository<Okul> Respository = new Repository<Okul>())
            {
                Okul Okul = Respository.Bilgi(Url);
                string contentType = "image/jpeg";
                Image Resim = ImageServis.ByteArrayToImage(Okul.Logo);
                Resim = ImageServis.Boyutlandir(Resim, Width, Height);
                return this.Image(ImageServis.ImageToByteArray(Resim, ImageFormat.Jpeg), contentType);
            }
        }

        public ActionResult OkulKapakLogo(string Url, int Width, int Height)
        {
            using (Repository<Okul> Respository = new Repository<Okul>())
            {
                Okul Sube = Respository.Bilgi(Url);
                string contentType = "image/jpeg";
                Image Resim = ImageServis.ByteArrayToImage(Sube.Logo);
                Resim = ImageServis.Boyutlandir(Resim, Width, Height);
                return this.Image(ImageServis.ImageToByteArray(Resim, ImageFormat.Jpeg), contentType);
            }
        }

        public ActionResult OgrenciResim(int OgrenciId, int Width, int Height)
        {
            using (Repository<OgrenciFotograf> Respository = new Repository<OgrenciFotograf>())
            {
                string contentType = "image/jpeg";
                IList<OgrenciFotograf> Temp = Respository.Yukle("SELECT * FROM ogrencifotograf WHERE KategoriRef = 31 AND OgrenciRef = " + OgrenciId);
                Image Resim = null;
                if (Temp != null && Temp.Count > 0)
                {
                    Resim = ImageServis.ByteArrayToImage(Temp[0].Resim);
                    Resim = ImageServis.Boyutlandir(Resim, Width, Height);
                    
                }
                else
                {
                    Resim = ImageServis.ByteArrayToImage(System.IO.File.ReadAllBytes(Server.MapPath("/content/resources/images/nophoto.png")));
                    Resim = ImageServis.Boyutlandir(Resim, Width, Height);

                }
                return this.Image(ImageServis.ImageToByteArray(Resim, ImageFormat.Jpeg), contentType);
            }

        }

    }
}
