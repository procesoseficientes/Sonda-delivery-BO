using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace NextBO.Wpf.Views
{

    /// <summary>
    /// Interaction logic for UserCollectionView.xaml
    /// </summary>
    public partial class DeliveryCollectionView : UserControl
    {
        public DeliveryCollectionView()
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
