using System;
using DevExpress.Mvvm;
using NextBO.Wpf.Common;
using NextBO.DataModel;
using NextApi.Models.Models;
using DevExpress.Mvvm.DataModel;
using DevExpress.Mvvm.POCO;
using System.Linq;
using NextBO.Wpf.Services;
using System.Diagnostics;
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;
using System.IO;
using DevExpress.Xpf.Map;
using NextBO.Wpf.Common.ViewModel;
using NextApi.Models.Resources.Responses;
using static Next.Utils.Enums.Enums;
using DevExpress.Mvvm.ViewModel;
using System.Collections.Generic;

namespace NextBO.Wpf.ViewModels
{
    public class RouteTrackingCollectionViewModel
    {
        public static RouteTrackingCollectionViewModel Create(INextBOUnitOfWork unitOfWork, IDocumentManagerService documentManager)
        {
            return ViewModelSource.Create(() => new RouteTrackingCollectionViewModel(unitOfWork, documentManager));
        }

        protected RouteTrackingCollectionViewModel(INextBOUnitOfWork UnitOfWork, IDocumentManagerService documentManager)
        {
            Locations = UnitOfWork.GetTaskLogLocations(61542);
            GetPointAndShowInMap();
            unitOfWork = UnitOfWork;
            DocumentManagerService = documentManager;
        }

        public virtual ObservableCollection<GeoPoint> PointsMapDelivery { get; set; }
        ObservableCollection<GeoPoint> ListPointMap = new ObservableCollection<GeoPoint>();
        public virtual GeoPoint CenterPoint { get; set; }
        public virtual List<LogLocation> Locations { get; set; }
        public virtual ObservableCollection<LogLocation> LogLocations { get; set; }
        ObservableCollection<LogLocation> LogLocations2 = new ObservableCollection<LogLocation>();
        public INextBOUnitOfWork unitOfWork;
        protected IDocumentManagerService DocumentManagerService;

        private void GetPointAndShowInMap()
        {
            try
            {
                
                PointsMapDelivery = new ObservableCollection<GeoPoint>();
                if (Locations.Count > 0)
                {
                    foreach (var location in Locations)
                    {
                        GeoPointResource geoPoint = new GeoPointResource();
                        geoPoint.Longitude = (double)location.Longitude;
                        geoPoint.Latitude = (double)location.Latitude;

                        GeoPoint centerPoin = new GeoPoint();
                        centerPoin.Latitude = (double)location.Latitude;
                        centerPoin.Longitude = (double)location.Longitude;
                        LogLocations2.Add(location);
                        ListPointMap.Add(centerPoin);
                    }
                }

                if (ListPointMap.Count > 0) {
                    PointsMapDelivery = ListPointMap;
                    LogLocations = LogLocations2;
                }   
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
