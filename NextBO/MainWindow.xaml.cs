using System.Windows;
using DevExpress.Xpf.Bars;
using DevExpress.Xpf.Core;
using NextBO.Wpf.Properties;

namespace NextBO.Wpf
{
    public partial class MainWindow : ThemedWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            if (Height > SystemParameters.VirtualScreenHeight || Width > SystemParameters.VirtualScreenWidth)
                WindowState = WindowState.Maximized;

            EventManager.RegisterClassHandler(typeof(BarItem), BarItem.ItemClickEvent, new ItemClickEventHandler(OnBarItemClick), true);
            DevExpress.Xpf.Core.ThemeManager.AddThemeChangingHandler(this, (s, e) =>
            {
                Settings.Default.UserTheme = DevExpress.Xpf.Core.ApplicationThemeHelper.ApplicationThemeName;
                Properties.Settings.Default.Save();
                Logger.Log(string.Format("Next: Change Theme: {0}", DevExpress.Xpf.Core.ApplicationThemeHelper.ApplicationThemeName));
            });

        }



        void MainWindowLoaded(object sender, RoutedEventArgs e)
        {
            if (Left < 0 || Top < 0)
                WindowState = WindowState.Maximized;
        }
        void OnBarItemClick(object sender, ItemClickEventArgs e)
        {
            var barItem = (BarItem)sender;
            var content = barItem.Content ?? barItem.ActualCustomizationContent;
            if (content != null)
                Logger.Log(string.Format("NextBO: BarItemClick: {0}", content.ToString()));
        }


    }
}
