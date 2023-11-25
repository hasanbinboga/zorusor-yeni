using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using System.IO;
using System.Windows.Markup;
using System.Windows;

namespace BilisselBeceriler.BelgeEditor.Library.Helpers
{
    public class XamlHelper
    {

        public string FilePath { get; set; }
        public object Content { get; set; }
        public string KlasorYolu { get; set; }
        public void IcerigiYukle()
        {
            try
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
            catch (Exception ex)
            {

                MessageBox.Show("Hata Oluştu : " + ex.Message);
            }

        }
        public void KlasorIcerigiYukle(string Klasor)
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                if (string.IsNullOrEmpty(Klasor) == false)
                {
                    dlg.InitialDirectory = Klasor;
                }
                dlg.Title = "XAML Doyası Aç";
                dlg.Filter = "XAML Dosyaları|*.xaml";
                bool? retval = dlg.ShowDialog();

                if (retval.HasValue && retval.Value)
                {
                    this.FilePath = dlg.FileName;
                    this.KlasorYolu = dlg.FileName.Substring(0, (dlg.FileName.Length - dlg.SafeFileName.Length));
                    using (FileStream stream = new FileStream(dlg.FileName, FileMode.Open))
                    {
                        object content = XamlReader.Load(stream);
                        this.Content = content;
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Hata Oluştu : " + ex.Message);
            }

        }
        public void IcerigiYukle(string dosya)
        {
            try
            {
                this.FilePath = dosya;
                using (FileStream stream = new FileStream(dosya, FileMode.Open))
                {
                    object content = XamlReader.Load(stream);
                    this.Content = content;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Hata Oluştu : " + ex.Message);
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
        public string IcerigiVeriTabaninaKaydet(decimal Id)
        {
            string dosya = @"C:\HavuzProjesi\Belgeler\" + Id + ".xaml";
            if (File.Exists(dosya) == true)
            {
                if (MessageBox.Show(Id + ".xaml Şablon Dosyası zaten var üzerine kadetmek istiyor musunuz?",
                    "Şablon Kaydet", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    using (FileStream stream = new FileStream(dosya, FileMode.Create))
                    {
                        XamlWriter.Save(this.Content, stream);
                        this.Content = null;
                    }
                }
            }
            else
            {
                using (FileStream stream = new FileStream(dosya, FileMode.Create))
                {
                    XamlWriter.Save(this.Content, stream);
                    this.Content = null;
                }
            }
            return dosya;
        }
        public string IcerigiKaydet(string dosya)
        {
            if (File.Exists(dosya) == true)
            {
                if (MessageBox.Show(dosya + ".xaml Şablon Dosyası zaten var üzerine kadetmek istiyor musunuz?",
                    "Şablon Kaydet", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    using (FileStream stream = new FileStream(dosya, FileMode.Create))
                    {
                        XamlWriter.Save(this.Content, stream);
                        this.Content = null;
                    }
                }
            }
            else
            {
                using (FileStream stream = new FileStream(dosya, FileMode.Create))
                {
                    XamlWriter.Save(this.Content, stream);
                    this.Content = null;
                }
            }
            return dosya;
        }
    }
}
