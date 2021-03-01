using System;
using System.Windows.Data;
using System.Windows.Markup;
using NextBO.Wpf.ViewModels;

namespace NextBO.Wpf {
    public class SelectedFilterItemConverter : MarkupExtension, IValueConverter {
        public override object ProvideValue(IServiceProvider serviceProvider) {
            return this;
        }
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            return value;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            if(value is FilterCategory)
                return Binding.DoNothing;
            return value;
        }
    }
}
