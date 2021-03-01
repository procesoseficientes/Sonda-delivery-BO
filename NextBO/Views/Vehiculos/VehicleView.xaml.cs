using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Xml;

namespace NextBO.Wpf.Views
{
    /// <summary>
    /// Interaction logic for VehicleView.xaml
    /// </summary>
    /// 

    public partial class VehicleView : UserControl
    {
        public VehicleView()
        {
            InitializeComponent();
            this.Loaded += View_Loaded;
        }

        private void View_Loaded(object sender, RoutedEventArgs e)
        {
            if (File.Exists(layoutItemss.Name + ".xml"))
            {
                XmlReader reader = XmlReader.Create(layoutItemss.Name + ".xml");
                layoutItemss.ReadFromXML(reader);
                reader.Close();
            }
            else
            {
                XmlWriter writer = XmlWriter.Create(layoutItemss.Name + "_Default.xml");
                layoutItemss.WriteToXML(writer);
                writer.Close();
            }
        }

    }
}
