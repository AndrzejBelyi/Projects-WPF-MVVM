using System;
using System.Globalization;
using System.Windows.Data;

namespace Texode_Test_Andrzej_Beliy.Services
{
    public class GenderConverter : IValueConverter
    {
       public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((uint)value)
            {
                case 0:
                    return "М";
                case 1:
                    return "Ж";
                default:
                    return "Не определён";
            }

        }

       public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((string)value)
            {
                case "М":
                    return 0;
                case "Ж":
                    return 1;
                default:
                    return 2;
            }
        }
    }
}
