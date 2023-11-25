using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.Win32;
using System.Windows.Markup;

namespace BilisselBeceriler.HavuzBuilder
{
    public class XamlOkuyucu
    {

        public string FilePath { get; set; }
        public object Content { get; set; }

        public void IcerigiYukle()
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "XAML Doyası Aç";
            dlg.Filter = "XAML Dosyaları|*.xaml";
            bool? retval = dlg.ShowDialog();

            if (retval.HasValue && retval.Value)
            {
                this.FilePath = dlg.FileName;
                using (FileStream stream = new FileStream(dlg.FileName, FileMode.Open))
                {
                    object content = XamlReader.Load(stream);
                    this.Content = content;
                }
            }
        }
        public void IcerigiYukle(string dosya)
        {

            this.FilePath = dosya;
            using (FileStream stream = new FileStream(dosya, FileMode.Open))
            {
                object content = XamlReader.Load(stream);
                this.Content = content;
            }
        }

        public void IcerigiKaydet()
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "XAML Dosyaları|*.xaml";
            dlg.Title = "XAML Doyası Kaydet";
            bool? retval = dlg.ShowDialog();
            if (retval.HasValue && retval.Value)
            {
                using (FileStream stream = new FileStream(dlg.FileName, FileMode.Create))
                {
                    XamlWriter.Save(this.Content, stream);
                    this.Content = null;
                }
            }
        }
        public void IcerigiKaydet(string DosyaYolu, string DosyaAdi)
        {
            if (Directory.Exists(DosyaYolu) == false)
            {
                Directory.CreateDirectory(DosyaYolu);
            }
            using (FileStream stream = new FileStream(DosyaYolu+"\\"+DosyaAdi+".xaml", FileMode.Create))
            {
                XamlWriter.Save(this.Content, stream);
                this.Content = null;
            }
        }
    }
}
