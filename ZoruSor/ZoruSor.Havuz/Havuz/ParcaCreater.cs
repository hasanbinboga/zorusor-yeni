using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace ZoruSor.Lib.Havuz
{
    public class ParcaCreater
    {
        public static Parca GetYeniTipParca(FileInfo[] fileList)
        {
            if (fileList == null || fileList.Length == 0)
            {
                return null;
            }
            var result = new Parca();
            var ad = fileList[0].Name.Split('_')[0];
            result.Ad = ad;
            result.Adet = fileList.Count(s=>s.Name.StartsWith(ad+"_x_")==false);
            var i = 0;

            #region Derece al

            var derece = fileList[0].Name.Split('_')[1];
            int.TryParse(derece, out i);
            result.Derece = i;

            #endregion

            #region Sira al

            var sira = fileList[0].Name.Split('_')[2];
            int.TryParse(sira, out i);
            result.Sira = i;

            #endregion

            #region ResimList Al

            result.ResimList = new List<ParcaResim>(fileList.Count(s => s.Name.StartsWith(ad + "_x_") == false));
            i = 0;
            foreach (var fileInfo in fileList.Where(s => s.Name.StartsWith(ad + "_x_") == false))
            {
                var img = new Bitmap(Image.FromFile(fileInfo.FullName));
                img.SetResolution(96, 96);
                result.ResimList.Add(new ParcaResim
                {
                    Id = i,
                    DosyaYol = fileInfo.FullName,
                    Nesne = img
                });
                i++;
            }

            #endregion

            #region DonusumList Al

            result.DonusumResimList = new List<ParcaResim>(fileList.Count(s => s.Name.StartsWith(ad + "_x_")));
            i = 0;
            foreach (var fileInfo in fileList.Where(s => s.Name.StartsWith(ad + "_x_")))
            {
                var img = new Bitmap(Image.FromFile(fileInfo.FullName));
                img.SetResolution(96, 96);
                result.DonusumResimList.Add(new ParcaResim
                {
                    Id = i,
                    DosyaYol = fileInfo.FullName,
                    Nesne = img
                });
                i++;
            }

            #endregion
            
            return result;
        }
    }
}
