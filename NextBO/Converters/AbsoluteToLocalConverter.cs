using System;
using System.Windows.Data;

namespace NextBO.Wpf {
    public class AbsoluteToLocalConverter : IValueConverter {
        public double MaxValue { get; set; }
        public double MinValue { get; set; }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            if(!(value is double))
                return value;
            return (double)value * (MaxValue - MinValue) + MinValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
}
