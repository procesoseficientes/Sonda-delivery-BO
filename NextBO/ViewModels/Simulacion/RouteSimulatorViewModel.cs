using DevExpress.Mvvm;
using DevExpress.Mvvm.DataModel;
using DevExpress.Mvvm.POCO;
using DevExpress.Xpf.Editors;
using NextApi.Models.Models;
using NextApi.Models.Resources.Responses;
using NextBO.DataModel;
using NextBO.Wpf.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Xml.Linq;
using DevExpress.Xpf.Grid.LookUp;
using static Next.Utils.Enums.Enums;
using System.Xml;
using System.Threading.Tasks;
using System.Globalization;

namespace NextBO.Wpf.ViewModels
{
    public class RouteSimulatorViewModel : SingleObjectViewModel<RouteSimulatorHeader, long, INextBOUnitOfWork>
    {

        private readonly IRouteOptimizerService RouteOptimizerService;

        /// <summary>
        /// Creates a new instance of RouteSimulatorViewModel as a POCO view model.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        public static RouteSimulatorViewModel Create(IUnitOfWorkFactory<INextBOUnitOfWork> unitOfWorkFactory = null)
        {
            return ViewModelSource.Create(() => new RouteSimulatorViewModel(unitOfWorkFactory));
        }

        /// <summary>
        /// Initializes a new instance of the RouteSimulatorViewModel class.
        /// This constructor is declared protected to avoid undesired instantiation of the RouteSimulatorViewModel type without the POCO proxy factory.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        protected RouteSimulatorViewModel(IUnitOfWorkFactory<INextBOUnitOfWork> unitOfWorkFactory = null)
            : base(unitOfWorkFactory ?? UnitOfWorkSource.GetUnitOfWorkFactory(), x => x.RouteSimulatorHeaders, x => x.Id)
        {
            RouteOptimizerService = new RouteOptimizerService();
            RouteSimulators = new ObservableCollection<RouteSimulatorDetail>();
        }

        public virtual List<ManifestsByDateRangeResponseResource> ManifestsByDateRanges { get; set; }

        private readonly ObservableCollection<ManifestsByDateRangeResponseResource> selectedManifests = new ObservableCollection<ManifestsByDateRangeResponseResource>();
        public ObservableCollection<ManifestsByDateRangeResponseResource> SelectedManifests { get { return this.selectedManifests; } }
        public virtual ObservableCollection<RouteSimulatorDetail> RouteSimulators { get; set; }

        //public virtual List<Vehicle> LookUpVehicle { get; set; }
        public virtual DateTime StartDate { get; set; }
        public virtual DateTime EndDate { get; set; }
        public virtual string ListManifest { get; set; }
        public virtual int VehicleId { get; set; }
        public virtual bool IsLoading { get; set; }

        ViewSettingsViewModel viewSettings;

        public ViewSettingsViewModel ViewSettings
        {
            get
            {
                if (viewSettings == null)
                    viewSettings = ViewSettingsViewModel.Create(CollectionViewKind.FilterDate, this);
                return viewSettings;
            }
        }

        protected override string GetTitleForNewEntity()
        {
            return "Nueva Simulacion de Ruta";
        }


        //protected override void OnEntityChanged()
        //{
        //    base.OnEntityChanged();
        //    if (Entity != null)
        //        Logger.Log(string.Format("Next: Edit Simulator: {0}",
        //            string.IsNullOrEmpty(Entity.Id.ToString()) ? "<New>" : Entity.Id.ToString()));
        //}

        //public int VehicleId { get; private set; }

        //public void CleanVehicleSelected()
        //{
        //    VehicleId = 0;
        //}

        //public bool CanConvertToXml()
        //{
        //    return VehicleId != 0 && SelectedManifests.Count() > 0;
        //}

        //      public bool CanConvertToXml()
        //      {
        //          return SelectedManifests.Count() > 0 || !string.IsNullOrEmpty(ListManifest);
        //}
        
        public void CleanManifestsSelected()
        {
            //return VehicleId != 0 && SelectedManifests.Count() > 0;
            SelectedManifests.Clear();
        }

        public bool CanSimulateRoute()
        {
            return SelectedManifests.Count() > 0 || ListManifest != null;
        }
        //public Vehicle GetVehicle()
        public Vehicle GetVehicle(int VehicleId)
        {
            return UnitOfWork.Vehicles.Where(vh => vh.Id == VehicleId).FirstOrDefault();
        }

        public bool CanResetChanges()
        {
            return SelectedManifests.Count > 0 || RouteSimulators.Count > 0;
        }

        public void ResetChanges()
        {
            OnLoaded();
        }

        public void PopupVehicleClosing(ClosePopupEventArgs args)
        {
            switch (args.CloseMode)
            {
                case PopupCloseMode.Normal:
                    break;
                case PopupCloseMode.Cancel:
                    VehicleId = 0;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public override void OnLoaded()
        {
            try
            {
                StartDate = DateTime.Now.AddDays(-7).Date;
                EndDate = DateTime.Now.AddDays(7).Date;
                VehicleId = 0;
                RouteSimulators = new ObservableCollection<RouteSimulatorDetail>();

                //LookUpVehicle = UnitOfWork.Vehicles.Where(vc => vc.IsActive > 0).ToList();
                ManifestsByDateRanges = UnitOfWork.GetStopsByManifest(StartDate, EndDate);
                base.OnLoaded();
            }
            catch (Exception ex)
            {
                MessageBoxService.ShowMessage(GetStringValue(Next.Enums.Enums.MessageError.DataError) + ex.Message, ex.Message,
                    MessageButton.OK, MessageIcon.Error);
            }
        }

        public void SaveAndNewEntity()
        {
            try
            {
                if (RouteSimulators.Count <= 0) return;

                Entity.CreatedDate = DateTime.Now;
                Entity.QuantityDelivery = SelectedManifests.Count();
                Entity.QuantityManifest = RouteSimulators.Select(x => x.ManifestId).Distinct().Count();
                Entity.DistanceToTravel = RouteSimulators.Sum(x => x.DistanceToTravel).Value;

                //Entity.MarginOfGainInMoney = RouteSimulators.Sum(x => x.MarginOfGain).Value;
                base.SaveAndNew();
                OnLoaded();
            }
            catch (Exception ex)
            {
                MessageBoxService.ShowMessage(GetStringValue(Next.Enums.Enums.MessageError.SaveError) + ex.Message,
                    ex.Message, MessageButton.OK, MessageIcon.Error);
            }
        }

        //{
        //	    if (!ViewSettings.CanShowFilterDate())
        //              {
        //                  RouteSimulators.Clear();
        //                  XElement xml = new XElement("DATA", SelectedManifests.Select(i => new XElement("MANIFEST",
        //                  new XElement("ID", i.manifestId),
        //                  new XElement("EXTERNAL_MANIFEST_ID", i.externalManifestId),
        //                  new XElement("IS_EXTERNAL", i.isExternal)
        //                  )));
        //                  SimulatorDetails = UnitOfWork.GetManifestDetailByXML(xml);
        //                  SimulateManifests();
        //              }
        //              else
        //              {
        //                  SimulatorDetails = UnitOfWork.GetManifestDetailByListId(ListManifest);
        //                  SimulateManifests();
        //              }
        //}

        public void SaveAndCloseEntity()
        {
            try
            {

                if (RouteSimulators.Count <= 0) return;

                Entity.CreatedDate = DateTime.Now;
                Entity.QuantityDelivery = SelectedManifests.Count();
                Entity.QuantityManifest = RouteSimulators.Select(x => x.ManifestId).Distinct().Count();
                Entity.DistanceToTravel = RouteSimulators.Sum(x => x.DistanceToTravel).Value;
                Entity.QuantityVehicles = RouteSimulators.Select(x => x.VehicleId).Distinct().Count();
                base.SaveAndClose();
            }
            catch (Exception ex)
            {
                MessageBoxService.ShowMessage(GetStringValue(Next.Enums.Enums.MessageError.SaveError) + ex.Message,
                    ex.Message, MessageButton.OK, MessageIcon.Error);
            }
        }

        public void SimulateRoute()
        {
            //Shows loading panel
            IsLoading = true;
            try
            {
                if (!ViewSettings.CanShowFilterDate())
                {
                    RouteSimulators.Clear();
                    var listByXml = UnitOfWork.GetManifestDetailByXML(GetXmlOfSelectedManifests());
                    if (0 >= listByXml.Count) return;
                    ReadXmlAsync(listByXml[0]);
                }
                else
                {
                    RouteSimulators.Clear();
                    var listInputByXml = UnitOfWork.GetManifestDetailByListId(ListManifest);
                    if (0 >= listInputByXml.Count) return;
                    ReadXmlAsync(listInputByXml[0]);

                }
            }
            catch (Exception ex)
            {
                MessageBoxService.ShowMessage(GetStringValue(Next.Enums.Enums.MessageError.OperationError) + ex.Message, ex.Message,
                    MessageButton.OK, MessageIcon.Error);
                IsLoading = false;
            }
        }

        public XElement GetXmlOfSelectedManifests()
        {
            IsLoading = true;
            RouteSimulators.Clear();

            XElement xml = new XElement("DATA", SelectedManifests.Select(i => new XElement("MANIFEST",
            new XElement("ID", i.manifestId),
            new XElement("EXTERNAL_MANIFEST_ID", i.externalManifestId),
            new XElement("IS_EXTERNAL", i.isExternal)
            )));

            return xml;
        }

        public void ConvertTextDisplay(CustomDisplayTextEventArgs e)
        {
            try
            {
                e.Handled = true;
                e.DisplayText = "";
                SelectedManifests.ToList().ForEach(manifest =>
                {
                    if (SelectedManifests.ToList().Last() == manifest)
                    {
                        e.DisplayText += manifest.manifestId;
                        return;
                    }
                    e.DisplayText += manifest.manifestId + ",";
                });
            }
            catch (Exception ex)
            {
                MessageBoxService.ShowMessage(GetStringValue(Next.Enums.Enums.MessageError.OperationError) + ex.Message,
                    ex.Message, MessageButton.OK, MessageIcon.Error);
            }
        }

        public void FilterManifestByDateRange()
        {
            try
            {
                if (StartDate <= EndDate)
                {
                    ManifestsByDateRanges = UnitOfWork.GetStopsByManifest(StartDate, EndDate);
                    return;
                }
                MessageBoxService.ShowMessage(GetStringValue(Next.Enums.Enums.MessageError.OperationError),
                    GetStringValue(Next.Enums.Enums.MessageError.OperationError), MessageButton.OK, MessageIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBoxService.ShowMessage(GetStringValue(Next.Enums.Enums.MessageError.OperationError) + ex.Message, ex.Message,
                    MessageButton.OK, MessageIcon.Error);
            }
        }

        public List<RouteSimulatorDetail> CalculatePricesByDocuments(List<RouteSimulatorDetail> routes)
        {

            List<RouteSimulatorDetail> totalsList = new List<RouteSimulatorDetail>();
            try
            {
                IsLoading = true;

                Vehicle vehicle = GetVehicle(routes[0].VehicleId);
                if (vehicle == null)
                {
                    IsLoading = false;
                    MessageBoxService.ShowMessage("No se encontró el vehículo, verifique la información.", "Vehículo no encontrado", MessageButton.OK, MessageIcon.Information);
                    return totalsList;
                };

                var distanceTotalRoute = (routes.Sum(x => x.distance).Value) / 1000;
                var costByKM = vehicle.DailyCost / distanceTotalRoute;

                foreach (var detail in routes)
                {
                    detail.Vehicle = vehicle;
                    detail.DistanceToTravel = detail.distance / 1000;
                    detail.DistanceCost = costByKM;

                    detail.DeliveryCost = detail.DistanceToTravel * detail.DistanceCost;
                    detail.TotalDistributionCost = detail.DeliveryCost + detail.OrderCost;
                    detail.MarginOfGain = detail.OrderPrice - detail.OrderCost - detail.DeliveryCost;
                    if ((detail.OrderPrice.HasValue && detail.OrderPrice > 0) && detail.TotalDistributionCost.HasValue)
                    {
                        var x = ((detail.OrderPrice.Value - detail.TotalDistributionCost.Value) * 100) / detail.OrderPrice.Value;
                        detail.PercentageMarginOnTheSalePrice = Math.Round(x);
                    }
                    else
                    {
                        detail.MarginOfGain = 0;
                    }
                    totalsList.Add(detail);
                }

                //CAMBIA EL NUMERO DE ENTREGA POR EL TEXTO - RETORNO
                var countItem = routes.Count;
                totalsList[countItem - 1].Order = "RETORNO";

            }
            catch (Exception ex)
            {
                MessageBoxService.ShowMessage(GetStringValue(Next.Enums.Enums.MessageError.OperationError) + ex.Message, ex.Message,
                    MessageButton.OK, MessageIcon.Error);
                IsLoading = false;
            }
            return totalsList;
        }

        public async Task<List<RouteSimulatorDetail>> SimulateManifests(IList<DetailManifestsByXMLResource> DetailManifests)
        {
            IsLoading = true;
            List<RouteSimulatorDetail> listRouteSimulatorDetail = new List<RouteSimulatorDetail>();
            List<RouteSimulatorDetail> totalListByCost = new List<RouteSimulatorDetail>();

            if (DetailManifests == null || !DetailManifests.Any())
            {
                IsLoading = false;
                throw new ArgumentException("Debe seleccionar los manifiestos a procesar.", "Manifiestos");
            }

            listRouteSimulatorDetail = DetailManifests.Select(item => new RouteSimulatorDetail
            {
                ManifestId = item.ManifestId,
                Order = item.Order,
                OrderPrice = item.OrderPrice,
                TotalWeight = item.TotalWeight,
                TotalVolume = item.TotalVolume,
                OrderCost = item.OrderCost,
                Address = item.Address,
                Longitude = item.Longitude,
                Latitude = item.Latitude,
                ClientCode = item.ClientCode,
                ClientName = item.ClientName,
                VehicleId = item.VehicleId
            }).ToList();

            //OBTIENE LOS PARAMETROS DE LATITUD Y LONGITUD CONFIGURADOS PARA LA EMPRESA O CENTRO DE DISTRIBUCION          
            Parameter parameterGeolocation = new Parameter { ParameterGroup = GetStringValue(Next.Enums.Enums.ParametersGroup.Geolocation), Name = GetStringValue(Next.Enums.Enums.ParametersName.DefaultLongitude) };
            List<Parameter> listParameter = UnitOfWork.GetParameterByGroup(parameterGeolocation);

            if (listParameter == null || !listParameter.Any())
            {
                IsLoading = false;
                throw new Exception("No se tiene configurado parametros de geolocalización.");
            };

            var longitude = listParameter.Find(x => x.Name == GetStringValue(Next.Enums.Enums.ParametersName.DefaultLongitude)).Value;
            var latitude = listParameter.Find(x => x.Name == GetStringValue(Next.Enums.Enums.ParametersName.DefaultLatitude)).Value;

            if (string.IsNullOrEmpty(longitude) || string.IsNullOrEmpty(latitude))
            {
                IsLoading = false;
                throw new Exception("No se tiene configurado parametros de GPS.");
            };

            var OptimizationList = await RouteOptimizerService.ObtenerDistancia(listRouteSimulatorDetail, longitude, latitude);

            if (OptimizationList.Count <= 0)
            {
                IsLoading = false;
                throw new Exception("No se puede calcular ruta, verifique y vuelva a intentar.");
            }

            totalListByCost = CalculatePricesByDocuments(OptimizationList);

            //Hides loading panel
            IsLoading = false;

            return totalListByCost;
        }

        public async Task ReadXmlAsync(ListManifestByVehicleXmlResource element)
        {
            XDocument xml = XDocument.Parse(element.resultXML.ToString());

            foreach (var item in xml.Descendants("Vehicle"))
            {

                var response = item;
                var attr = response.Attribute("Id");
                List<DetailManifestsByXMLResource> listByXmlDetail = new List<DetailManifestsByXMLResource>();
                List<RouteSimulatorDetail> contentDetail = new List<RouteSimulatorDetail>();

                foreach (var item2 in response.Elements("Manifest"))
                {
                    DetailManifestsByXMLResource detailXmlByVehicle = new DetailManifestsByXMLResource()
                    {
                        Address = item2.Element("Address").Value,
                        ClientCode = item2.Element("ClientCode").Value,
                        ClientName = item2.Element("ClientName").Value,
                        ExternalManifestId = Convert.ToInt32(item2.Element("ExternalManifestId").Value),
                        Id = Convert.ToInt32(item2.Element("id").Value),
                        Latitude = decimal.Parse(item2.Element("Latitude").Value),
                        Longitude = decimal.Parse(item2.Element("Longitude").Value),
                        ManifestId = Convert.ToInt32(item2.Element("ManifestId").Value),
                        Order = item2.Element("Order").Value,
                        OrderCost = Convert.ToDecimal(item2.Element("OrderCost").Value),
                        OrderPrice = Convert.ToDecimal(item2.Element("OrderPrice").Value),
                        TotalDistributionCost = Convert.ToDecimal(item2.Element("TotalDistributionCost").Value),
                        TotalVolume = Convert.ToDecimal(item2.Element("TotalVolume").Value),
                        TotalWeight = Convert.ToDecimal(item2.Element("TotalWeight").Value),
                        VehicleId = Convert.ToInt32(item2.Element("VehicleId").Value),
                    };

                    listByXmlDetail.Add(detailXmlByVehicle);
                }

                if (listByXmlDetail.Count > 0)
                {
                    contentDetail = await SimulateManifests(listByXmlDetail);

                    contentDetail.ForEach(x =>
                    {
                        RouteSimulators.Add(x);
                    });
                }
            }
        }

    }
}
