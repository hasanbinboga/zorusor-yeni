using System.ComponentModel;

namespace BilisselBeceriler.BelgeEditor.Library.Model
{
    public class FolderEntity :BaseEntity, INotifyPropertyChanged
    {
        private bool _isSelected;
        private bool _isExpanded;
        private string _folderIcon;
        private string _tag;
        public string FolderIcon
        {
            get
            {
                return _folderIcon;
            }
            set
            {
                _folderIcon = value;
                RaisePropertyChanged("FolderIcon");
            }
        }
        public string Tag
        {
            get
            {
                return _tag;
            }
            set
            {
                _tag = value;
                RaisePropertyChanged("Tag");
            }
        }
        public bool IsSelected
        {
            get
            {
                return _isSelected;
            }
            set
            {
                if (_isSelected != value)
                {
                    _isSelected = value;
                    RaisePropertyChanged("IsSelected");
                    IsExpanded = true; //Default windows behaviour of expanding the selected folder
                }
            }
        }
        public bool IsExpanded
        {
            get
            {
                return _isExpanded;
            }
            set
            {
                if (_isExpanded != value)
                {
                    _isExpanded = value;
                    FolderIcon = _isExpanded ? "/FolderBrowser/Images/FolderOpen.png" : "/FolderBrowser/Images/FolderClosed.png";
                    RaisePropertyChanged("IsExpanded");
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
