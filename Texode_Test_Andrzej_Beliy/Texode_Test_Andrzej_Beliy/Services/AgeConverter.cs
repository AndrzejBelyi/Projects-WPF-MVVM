using System;
using System.Globalization;
using System.Windows.Data;

namespace Texode_Test_Andrzej_Beliy.Services
{
    public class AgeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int lastnumb =(int)((double.Parse(value.ToString()))%10);
            switch(lastnumb)
            {
                case 1:
                    return(value + " год").ToString();
                case 2:
                    return (value + " года").ToString();
                case 3:
                    return (value + " года").ToString();
                case 4:
                    return (value + " года").ToString();
                default:
                    return (value + " лет").ToString();
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return 0;
        }
    }
}
