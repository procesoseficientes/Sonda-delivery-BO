using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Forms;
using static Next.Utils.Enums.Enums;

namespace NextBO.Wpf.Views
{
    /// <summary>
    /// Interaction logic for ParameterView.xaml
    /// </summary>
    public partial class CenterOfServiceCollectionView : System.Windows.Controls.UserControl
    {
        public CenterOfServiceCollectionView()
        {
            InitializeComponent();
            this.Loaded += View_Loaded;
        }

        private void View_Loaded(object sender, RoutedEventArgs e)
        {
            if (File.Exists(tableViewGridControl.View.Name + ".xml"))
            {
                tableViewGridControl.RestoreLayoutFromXml(tableViewGridControl.View.Name + ".xml");
            }
            else
            {
                tableViewGridControl.SaveLayoutToXml(tableViewGridControl.View.Name + "_Default.xml");
            }
        }

        private void Hyperlink_RequestNavigate_1(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            try
            {
                if (File.Exists(GetStringValue(Next.Enums.Enums.UrlNavegator.Chrome)))
                {
                    Process.Start(new ProcessStartInfo(GetStringValue(Next.Enums.Enums.UrlNavegator.Chrome), e.Uri.AbsoluteUri));
                    e.Handled = true;
                }
                else if(File.Exists(GetStringValue(Next.Enums.Enums.UrlNavegator.Edge)))
                {
                    Process.Start(new ProcessStartInfo(GetStringValue(Next.Enums.Enums.UrlNavegator.Edge), e.Uri.AbsoluteUri));
                    e.Handled = true;
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show(GetStringValue(Next.Enums.Enums.UrlNavegator.Edge), "Error Navegator",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(GetStringValue(Next.Enums.Enums.MessageError.OperationError) + ex.Message, ex.Message,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Handled = false;
            }
        }
    }
}
