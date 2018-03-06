using NLog;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace Xitaso.Logging.Viewer.App.Converter
{
    public class StringToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(targetType == typeof(Brush)) || value == null)
                return new SolidColorBrush(Colors.Transparent);

            try
            {
                var color = (Color)ColorConverter.ConvertFromString(value.ToString());
                return new SolidColorBrush(color);
            }
            catch (Exception ex)
            {
                return new SolidColorBrush(Colors.Transparent);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return "";
        }
    }
}
