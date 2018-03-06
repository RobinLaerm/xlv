using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Xitaso.Logging.Viewer.App.Converter
{
    public static class SafeColorConverter
    {
        public static Color ConvertToColor(string colorName)
        {
            try
            {
                return (Color)System.Windows.Media.ColorConverter.ConvertFromString(colorName);
            }
            catch (Exception ex)
            {
                return Colors.Transparent;
            }
        }

        public static SolidColorBrush ConvertToSolidBrush(string colorName)
        {
            return new SolidColorBrush(ConvertToColor(colorName));
        }
    }
}
