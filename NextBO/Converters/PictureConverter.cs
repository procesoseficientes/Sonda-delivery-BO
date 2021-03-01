using System;
using System.Globalization;
using System.Windows.Data;

namespace NextBO.Wpf
{
    public class PictureConverter : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                var base64String = value != null ? ((string)value).Replace("data:image/jpeg;base64,", string.Empty).Replace("data:image/png;base64,", string.Empty) : string.Empty;

                return !string.IsNullOrWhiteSpace(base64String) ? Convert.FromBase64String(base64String) : null;
            }
            catch
            {

                return null;
            }
        }
        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                byte[] data = value as byte[];
                return Convert.ToBase64String(data); ;
            }
            catch 
            {
                return string.Empty;
            }
        }
    }
}
