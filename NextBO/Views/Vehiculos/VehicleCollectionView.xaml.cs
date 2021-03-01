﻿using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace NextBO.Wpf.Views
{

    /// <summary>
    /// Interaction logic for VehicleCollectionView.xaml
    /// </summary>
    public partial class VehicleCollectionView : UserControl
    {
        public VehicleCollectionView()
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
    }
}
