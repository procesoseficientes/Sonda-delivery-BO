using System;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Media.Animation;
using System.Runtime.InteropServices;
using DevExpress.Images;
using DevExpress.Internal;
using DevExpress.Mvvm.UI;
using DevExpress.Xpf.Core;
using Microsoft.Extensions.Configuration;
using NextBO.Wpf.Properties;

namespace NextBO.Wpf
{
    public partial class App : Application
    {
        public IConfiguration Configuration { get; set; }
        static IDisposable singleInstanceApplicationGuard;

        protected override void OnStartup(StartupEventArgs e)
        {
            ExceptionHelper.Initialize();

            DevAVDataDirectoryHelper.LocalPrefix = "NextBO";

            Theme.RegisterPredefinedPaletteThemes();
            ImagesAssemblyLoader.Load();
            Timeline.DesiredFrameRateProperty.OverrideMetadata(typeof(Timeline), new FrameworkPropertyMetadata(200));

            base.OnStartup(e);
            ViewLocator.Default = new ViewLocator(typeof(App).Assembly);
            bool exit;
            singleInstanceApplicationGuard = DevAVDataDirectoryHelper.SingleInstanceApplicationGuard("NextBOApp", out exit);
            if (exit)
            {
                Shutdown();
                return;
            }
            Theme.TouchlineDark.ShowInThemeSelector = false;
            ApplicationThemeHelper.ApplicationThemeName = string.IsNullOrEmpty(Settings.Default.UserTheme) ? Theme.Office2019Colorful.Name : Settings.Default.UserTheme;

            SetCultureInfo();


            var builder = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            Configuration = builder.Build();

        }



        static void SetCultureInfo()
        {
            CultureInfo demoCI = CultureInfo.InvariantCulture;
            //demoCI.NumberFormat.CurrencySymbol = "$";
            //demoCI.DateTimeFormat = new DateTimeFormatInfo();
            //demoCI.NumberFormat = new NumberFormatInfo();
            Thread.CurrentThread.CurrentCulture = demoCI;

            //CultureInfo demoUI = (CultureInfo)Thread.CurrentThread.CurrentUICulture.Clone();
            //demoUI.NumberFormat.CurrencySymbol = "$";
            //demoUI.DateTimeFormat = new DateTimeFormatInfo();
            //demoUI.NumberFormat = new NumberFormatInfo();
            Thread.CurrentThread.CurrentUICulture = demoCI;

            //CultureInfo demoCI = CultureInfo.CreateSpecificCulture("es-GT");
            //Thread.CurrentThread.CurrentCulture = demoCI;

            //Thread.CurrentThread.CurrentUICulture = demoCI;
        }


        public static string ApplicationID
        {
            get { return string.Format("NextBO_APP_{0}", AssemblyInfo.VersionShort.Replace(".", "_")); }
        }
    }
    [Guid("86882B9F-1EAE-41D9-B9CF-BD7ACCA51523"), ComVisible(true)]
    public class OutlookInspiredAppNotificationActivator : ToastNotificationActivator
    {
        public override void OnActivate(string arguments, System.Collections.Generic.Dictionary<string, string> data)
        {
        }
    }
}

