using System.Windows;
using System.Windows.Controls;
using System.IO;

namespace NextBO.Wpf.Views.DeliveryHistory
{
    /// <summary>
    /// Interaction logic for DeliveryHistoryCollectionView.xaml
    /// </summary>
    public partial class DeliveryHistoryCollectionView : UserControl
    {
        public DeliveryHistoryCollectionView()
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

        private void GridControl_CustomGroupDisplayText(object sender, DevExpress.Xpf.Grid.CustomGroupDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "RouteIdentifier.FinishDate")
            {
                if (e.Value == null)
                {
                    e.DisplayText = "Pendiente";
                }
            }
        }
    }
}
