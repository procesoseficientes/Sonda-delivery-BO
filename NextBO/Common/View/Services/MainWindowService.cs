using DevExpress.Mvvm.Native;
using DevExpress.Mvvm.UI;
using NextBO.Wpf.Common.ViewModel;
using System.Windows;

namespace NextBO.Wpf.Common.View
{
    public class MainWindowService : ServiceBase, IMainWindowService {
        public string Title {
            get { return Application.Current.With(a => a.MainWindow).With(w => w.Title); }
            set { Application.Current.With(a => a.MainWindow).Do(w => w.Title = value); }
        }
    }
}
