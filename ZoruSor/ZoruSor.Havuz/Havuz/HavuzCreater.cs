using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ZoruSor.Lib.Havuz
{
    public class HavuzCreater
    {
        public static Havuz GetYeniTipHavuz(string dosyaYol)
        {
            var result = new Havuz();
            result.DosyaYol = dosyaYol;
            DirectoryInfo fi = new DirectoryInfo(dosyaYol);
            result.ParcaList = new List<Parca>();
            //Yeni tip havuzlar
            var parcaList = fi.GetFiles().Where(f => !f.Attributes.HasFlag(FileAttributes.Hidden)).Select(file => file.Name.Split('_')[0]).Distinct().ToList();
            foreach (var parca in parcaList)
            {
                result.ParcaList.Add(ParcaCreater.GetYeniTipParca(fi.GetFiles("*.png").Where(f=> !f.Attributes.HasFlag(FileAttributes.Hidden) && f.Name.StartsWith(parca+'_')).ToArray()));
            }
            return result;
        }

        public static int GetHavuzParcaCount(string dosyaYol)
        {
            DirectoryInfo fi = new DirectoryInfo(dosyaYol);
            var parcaList = fi.GetFiles().Where(f => !f.Attributes.HasFlag(FileAttributes.Hidden)).Select(file => file.Name.Split('_')[0]).Distinct().ToList();
            return parcaList.Count;
        }
    }
}
