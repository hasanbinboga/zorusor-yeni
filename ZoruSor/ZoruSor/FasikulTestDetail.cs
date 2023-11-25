using System;
using System.ComponentModel;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace ZoruSor
{
    [Serializable]
    public class FasikulTestDetail : INotifyPropertyChanged
    {
        private readonly string _havuzDizin = ConfigurationManager.AppSettings["HavuzDizin"];


        public string SeciliHavuzYol => $"{_havuzDizin}{_havuzTema}\\{_havuzAd}";

        string _havuzTema;
        // ReSharper disable once LocalizableElement
        [DisplayName("Havuz Tema")]
        public string HavuzTema
        {
            get { return _havuzTema; }
            set
            {
                if (_havuzTema != value)
                {
                    if (string.IsNullOrEmpty(value))
                        throw new Exception();
                    _havuzTema = value;
                    OnPropertyChanged();
                }
            }
        }

        string _havuzAd;
        // ReSharper disable once LocalizableElement
        [DisplayName("Havuz")]
        public string HavuzAd
        {
            get { return _havuzAd ; }
            set
            {
                if (_havuzAd  != value)
                {
                    if (string.IsNullOrEmpty(value))
                        throw new Exception();
                    _havuzAd  = value;
                    OnPropertyChanged();
                }
            }
        }

        int _sayfaAdet;
        // ReSharper disable once LocalizableElement
        [DisplayName("Sayfa Adet")]
        public int SayfaAdet
        {
            get { return _sayfaAdet; }
            set
            {
                if (_sayfaAdet != value)
                {
                    _sayfaAdet = value;
                    OnPropertyChanged();
                }
            }
        }

        int _zorlukDerece;
        // ReSharper disable once LocalizableElement
        [DisplayName("Zorluk")]
        public int ZorlukDerece
        {
            get { return _zorlukDerece; }
            set
            {
                if (_zorlukDerece != value)
                {
                    _zorlukDerece = value;
                    OnPropertyChanged();
                }
            }
        }

        int _sabitParcaAdet;
        // ReSharper disable once LocalizableElement
        [DisplayName("Sabit Parça")]
        public int SabitParcaAdet
        {
            get { return _sabitParcaAdet; }
            set
            {
                if (_sabitParcaAdet != value)
                {
                    _sabitParcaAdet = value;
                    OnPropertyChanged();
                }
            }
        }

        string _resim1Formul;
        // ReSharper disable once LocalizableElement
        [DisplayName("Resim 1 Formul")]
        public string Resim1Formul
        {
            get { return _resim1Formul; }
            set
            {
                if (_resim1Formul != value)
                {
                    if (string.IsNullOrEmpty(value))
                        throw new Exception();
                    _resim1Formul = value;
                    OnPropertyChanged();
                }
            }
        }
        string _resim2Formul;
        // ReSharper disable once LocalizableElement
        [DisplayName("Resim 2 Formul")]
        public string Resim2Formul
        {
            get { return _resim2Formul; }
            set
            {
                if (_resim2Formul != value)
                {
                    if (string.IsNullOrEmpty(value))
                        throw new Exception();
                    _resim2Formul = value;
                    OnPropertyChanged();
                }
            }
        }

        string _resim3Formul;
        // ReSharper disable once LocalizableElement
        [DisplayName("Resim 3 Formul")]
        public string Resim3Formul
        {
            get { return _resim3Formul; }
            set
            {
                if (_resim3Formul != value)
                {
                    if (string.IsNullOrEmpty(value))
                        throw new Exception();
                    _resim3Formul = value;
                    OnPropertyChanged();
                }
            }
        }

        string _resim4Formul;
        // ReSharper disable once LocalizableElement
        [DisplayName("Resim 4 Formul")]
        public string Resim4Formul
        {
            get { return _resim4Formul; }
            set
            {
                if (_resim4Formul != value)
                {
                    if (string.IsNullOrEmpty(value))
                        throw new Exception();
                    _resim4Formul = value;
                    OnPropertyChanged();
                }
            }
        }

        bool _islemGorunsun;
        // ReSharper disable once LocalizableElement
        [DisplayName("İşlem Görünsün")]
        public bool IslemGorunsun
        {
            get { return _islemGorunsun; }
            set
            {
                if (_islemGorunsun != value)
                {
                    _islemGorunsun = value;
                    OnPropertyChanged();
                }
            }
        }

        public override string ToString()
        {
            return $"Havuz = {HavuzAd} SayfaAdet: {SayfaAdet}";
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
