using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Printing;

namespace BilisselBeceriler.BelgeEditor.Library.Converters
{
    public class PrinterToPageSizesConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
          object parameter, System.Globalization.CultureInfo culture)
        {
            return value == null ? null :
              ((PrintQueue)value).GetPrintCapabilities().PageMediaSizeCapability;
        }

        public object ConvertBack(object value, Type targetType,
          object parameter, System.Globalization.CultureInfo culture)
        { throw new NotImplementedException(); }
    }
}
