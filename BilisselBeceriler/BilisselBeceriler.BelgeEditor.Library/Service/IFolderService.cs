using System.Collections.Generic;
using System.Collections.ObjectModel;
using BilisselBeceriler.BelgeEditor.Library.Model;


namespace BilisselBeceriler.BelgeEditor.Library.Service
{
    public interface IFolderService
    {
        ObservableCollection<FolderEntity> GetFolders(string path);
        List<ImageEntity> GetFiles(string path, string format);
    }
}
