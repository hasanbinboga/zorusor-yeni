using System;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using System.Globalization;

namespace BilisselBeceriler.BelgeEditor.Library.Converters
{
    [ValueConversion(typeof(string), typeof(bool))]
    public class HeaderToImageConverter : IValueConverter
    {
        public static HeaderToImageConverter Instance = new HeaderToImageConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var uri = new Uri("/Images/FolderClosed.png", UriKind.Relative);
            var source = new BitmapImage(uri);
            return source;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException("Cannot convert back");
        }
    }
}
