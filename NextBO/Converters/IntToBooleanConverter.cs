using System;
using System.Windows.Data;

namespace NextBO.Wpf
{
    public class IntToBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var result = System.Convert.ToBoolean(value);
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var result = System.Convert.ToInt32(value);
            return result;
        }
    }
}
