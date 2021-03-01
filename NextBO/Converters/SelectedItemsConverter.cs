using NextApi.Models.Models;
using System;
using System.Collections.Generic;
using System.Windows.Data;
using System.Windows.Markup;

namespace NextBO.Wpf {
    public class SelectedItemsConverter : MarkupExtension, IValueConverter {
        public override object ProvideValue(IServiceProvider serviceProvider) {
            return this;
        }
        object IValueConverter.Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            if(value == null) return null;
            var result = new List<object>();
            foreach(var item in (List<User>)value)
                result.Add(item);
            return result;
        }
        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            List<User> result = new List<User>();
            if(value != null)
                foreach(object item in ((List<object>)value)) {
                    if(item as User != null)
                        result.Add((User)item);
                }
            return result;
        }
    }
}
