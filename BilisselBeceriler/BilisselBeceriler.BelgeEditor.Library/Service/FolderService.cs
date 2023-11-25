using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using BilisselBeceriler.BelgeEditor.Library.Model;
using System.Windows.Documents;
using System.Windows.Markup;
using BilisselBeceriler.BelgeEditor.Library.Helpers;
using System.Windows.Controls;
using System.Windows;
using System.Printing;

namespace BilisselBeceriler.BelgeEditor.Library.Service
{
    public class FolderService : IFolderService
    {
        public ObservableCollection<FolderEntity> GetFolders(string path)
        {
            var list = new ObservableCollection<FolderEntity>();
            foreach (var s in Directory.GetDirectories(path))
            {
                var di = new DirectoryInfo(s);
                if ((di.Attributes == FileAttributes.Hidden) || (di.Name.ToLower() == ".svn")) continue;
                var fi = new FolderEntity
                {
                    Name = s.Substring(s.LastIndexOf("\\") + 1),
                    Tag = s,
                    Path = s,
                    FolderIcon = "/FolderBrowser/Images/FolderClosed.png",
                    IsExpanded = false,
                    IsSelected = false
                };
                list.Add(fi);
            }
            return list;
        }

        public List<ImageEntity> GetFiles(string path, string format)
        {
            var list = new List<ImageEntity>();
            var resimListe = Directory.GetFiles(path, format);
            foreach (string s in resimListe)
            {
                var fi = new FileInfo(s);
                if (fi.Attributes != FileAttributes.Hidden)
                {
                    list.Add(new ImageEntity() { Path = s, Name = Path.GetFileName(s) });
                }

            }
            return list;
        }
        public List<BelgeSablonEntity> GetBelge(string path)
        {
            var list = new List<BelgeSablonEntity>();
            var belgeListe = Directory.GetFiles(path, "*.xaml");
            foreach (string s in belgeListe)
            {
                var fi = new FileInfo(s);
                if (fi.Attributes != FileAttributes.Hidden)
                {
                    list.Add(new BelgeSablonEntity() { Path = s, Name = Path.GetFileName(s) });
                }

            }
            return list;
        }
        public List<BelgeEntity> GetFixedDoc(string path, PrintTicket prnTicket, Thickness marj)
        {
            var list = new List<BelgeEntity>();
            var belgeListe = Directory.GetFiles(path, "*.xaml");
            foreach (string s in belgeListe)
            {
                var fi = new FileInfo(s);
                if (fi.Attributes != FileAttributes.Hidden)
                {
                    var doc = (FixedDocument)XamlReader.Load(File.OpenRead(s));
                    PageRangeDocumentPaginator pag = new PageRangeDocumentPaginator(
                            doc.DocumentPaginator, new PageRange(), prnTicket, marj);
                    for (int i = 0; i < pag.PageCount; i++)
                    {
                        var curPage = pag.GetPage(i);
                    }
                    string ad = Path.GetFileName(s);
                    string cinsiyet = ad.Split('-')[0];
                    int cinsId = 0;
                    if (cinsiyet == "Erkek")
                    {
                        cinsId = 11;
                    }
                    else if (cinsiyet == "Kadin")
                    {
                        cinsId = 12;
                    }
                    else if (cinsiyet == "Genel")
                    {
                        cinsId = 13;
                    }
                    list.Add(new BelgeEntity() { Path = s, Name = ad, BelgeContainer = doc, Cinsiyet = cinsId });
                }

            }
            return list;
        }
       
       
    }
}
