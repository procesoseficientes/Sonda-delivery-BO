using DevExpress.Xpf.Map;
using NextApi.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NextBO.Wpf.Views.Entregas
{
    /// <summary>
    /// Interaction logic for RouteTrackingCollectionView.xaml
    /// </summary>
    public partial class RouteTrackingCollectionView : UserControl
    {
        public RouteTrackingCollectionView()
        {
            InitializeComponent();
        }

        private void routeProvider_LayerItemsGenerating(object sender, LayerItemsGeneratingEventArgs args)
        {
            char letter = 'A';

            foreach (MapItem item in args.Items)
            {
                MapPushpin pushpin = item as MapPushpin;
                if (pushpin != null)
                    pushpin.Text = letter++.ToString();
            }
        }

        private void listPoints_Loaded(object sender, RoutedEventArgs e)
        {
            List<RouteWaypoint> waypoints = new List<RouteWaypoint>();
            var points = listPoints.ItemsSource;
            int i = 0;
            waypoints.Add(new RouteWaypoint("New York", new GeoPoint(41.145556, -73.995)));
            waypoints.Add(new RouteWaypoint("Oklahoma", new GeoPoint(36.131389, -95.937222)));
            waypoints.Add(new RouteWaypoint("Las Vegas", new GeoPoint(36.175, -115.136389)));
            foreach (LogLocation point in points) {
                i++;
                try
                {
                    if (i > 10)
                    {
                        continue;
                    }
                    waypoints.Add(new RouteWaypoint("- " + i, new GeoPoint(Convert.ToDouble(point.Latitude), Convert.ToDouble(point.Longitude))));
                }
                catch (Exception ex)
                {
                }
            }
            
            routeProvider.CalculateRoute(waypoints);
        }
    }
}
