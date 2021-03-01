using DevExpress.Mvvm.UI;
using DevExpress.Xpf.Grid;
using System;
using System.Windows.Markup;

namespace NextBO.Wpf
{
    public class RowEventArgsConverter : MarkupExtension, IEventArgsConverter
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
        public object Convert(object sender, object args)
        {
            return ((RowEventArgs)args).Row;
        }
    }
}
