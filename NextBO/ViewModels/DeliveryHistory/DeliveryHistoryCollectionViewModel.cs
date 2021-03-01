using System;
using DevExpress.Mvvm;
using NextBO.Wpf.Common;
using NextBO.DataModel;
using NextApi.Models.Models;
using DevExpress.Mvvm.DataModel;
using DevExpress.Mvvm.ViewModel;
using DevExpress.Mvvm.POCO;
using NextBO.Wpf.Common.ViewModel;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using NextBO.Wpf.Services;
using System.Diagnostics;
using static Next.Utils.Enums.Enums;

namespace NextBO.Wpf.ViewModels
{
    public class DeliveryHistoryCollectionViewModel : CollectionViewModel<DeliveryTask, long, INextBOUnitOfWork>, ISupportFiltering<DeliveryTask>
    {
        /// <summary>
        /// Creates a new instance of DeliveryHistoryCollectionViewModel as a POCO view model.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        public static DeliveryHistoryCollectionViewModel Create(IUnitOfWorkFactory<INextBOUnitOfWork> unitOfWorkFactory = null, UnitOfWorkPolicy unitOfWorkPolicy = UnitOfWorkPolicy.Individual)
        {
            return ViewModelSource.Create(() => new DeliveryHistoryCollectionViewModel(unitOfWorkFactory, unitOfWorkPolicy));
        }

        /// <summary>
        /// Initializes a new instance of the DeliveryHistoryCollectionViewModel class.
        /// This constructor is declared protected to avoid undesired instantiation of the DeliveryHistoryCollectionViewModel type without the POCO proxy factory.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        protected DeliveryHistoryCollectionViewModel(IUnitOfWorkFactory<INextBOUnitOfWork> unitOfWorkFactory = null, UnitOfWorkPolicy unitOfWorkPolicy = UnitOfWorkPolicy.Individual)
            : base(unitOfWorkFactory ?? UnitOfWorkSource.GetUnitOfWorkFactory(), x => x.Tasks, query => query.Where(task => task.CreatedDate.Value.Date >= startDate.Date && task.CreatedDate.Value.Date <= endDate.Date && task.DriverId == (pilotId == 0 ? task.DriverId : pilotId) && task.VehicleId == (vehicleId == 0 ? task.VehicleId : vehicleId)), unitOfWorkPolicy: unitOfWorkPolicy)
        {
            try
            {
                User pilotDefault = new User();
                pilotDefault.Name = "Todos";
                pilotDefault.Id = 0;
                LookUpPilot = this.CreateUnitOfWork().Users.Where(x => x.Pilot != null).ToList();
                LookUpPilot.Insert(0, pilotDefault);
                Vehicle vehicleDefault = new Vehicle();
                vehicleDefault.Brand = "Todos";
                vehicleDefault.Id = 0;
                LookUpVehicle = this.CreateUnitOfWork().Vehicles.ToList();
                LookUpVehicle.Insert(0, vehicleDefault);
            }
            catch (Exception ex)
            {
                MessageBoxService.ShowMessage(GetStringValue(Next.Enums.Enums.MessageError.WindowError) + ex.Message, ex.Message,
                    MessageButton.OK, MessageIcon.Error);
            }
        }

        ViewSettingsViewModel viewSettings;
        IReportService PrintService { get { return this.GetRequiredService<IReportService>("PrintService"); } }
        IReportService ExportService { get { return this.GetRequiredService<IReportService>("ExportService"); } }
        protected virtual ISaveFileDialogService SaveFileDialogService { get { return null; } }
        protected virtual IExportGridService ExportGridService { get { return null; } }
        public virtual DeliveryTask TableViewSelectedEntity { get; set; }
        public UICommand SaveLayoutCommand { get; set; }
        public UICommand RestoreLayoutCommand { get; set; }
        public static DateTime startDate = DateTime.Now.AddDays(-7);
        public static DateTime endDate = DateTime.Now;
        public static int pilotId = 0;
        public static int vehicleId = 0;

        /// <summary>
        /// The view model that contains a look-up collection of pilot for the corresponding navigation property in the view.
        /// </summary>
        public List<User> LookUpPilot
        {
            get;
            set;
        }
        /// <summary>
        /// The view model that contains a look-up collection of vehicle for the corresponding navigation property in the view.
        /// </summary>
        public List<Vehicle> LookUpVehicle
        {
            get;
            set;
        }
        public static DateTime StartDate
        {
            get
            {
                return startDate;
            }
            set
            {
                startDate = value;
            }
        }
        public static DateTime EndDate
        {
            get
            {
                return endDate;
            }
            set
            {
                endDate = value;
            }
        }
        public static int PilotId
        {
            get
            {
                return pilotId;
            }
            set
            {
                pilotId = value;
            }
        }
        public static int VehicleId
        {
            get
            {
                return vehicleId;
            }
            set
            {
                vehicleId = value;
            }
        }

        protected IUserSessionService UserSessionService { get { return this.GetRequiredService<IUserSessionService>(); } }

        public ViewSettingsViewModel ViewSettings
        {
            get
            {
                if (viewSettings == null)
                    viewSettings = ViewSettingsViewModel.Create(CollectionViewKind.ListView, this);
                return viewSettings;
            }
        }

        /// <summary>
        /// Export Grid
        /// </summary>
        /// <param name="fileType"></param>
        public void ExportGrid(ExportType fileType)
        {
            try
            {
                switch (fileType)
                {
                    case ExportType.XLSX:
                        SaveFileDialogService.DefaultExt = "xlsx";
                        SaveFileDialogService.Filter = "Excel 2007+|*.xlsx";
                        break;
                    case ExportType.PDF:
                        SaveFileDialogService.DefaultExt = "pdf";
                        SaveFileDialogService.Filter = "PDF|*.pdf";
                        break;
                }

                if (SaveFileDialogService.ShowDialog())
                {
                    var fileName = SaveFileDialogService.GetFullFileName();
                    ExportGridService.ExportTo(fileType, fileName);
                    if (MessageBoxService.ShowMessage("¿Desea abrir el archivo?", "Operación Exitosa", MessageButton.YesNo) == MessageResult.Yes)
                    {
                        var process = new Process();
                        process.StartInfo.UseShellExecute = true;
                        process.StartInfo.FileName = fileName;
                        process.Start();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBoxService.ShowMessage(GetStringValue(Next.Enums.Enums.MessageError.ExportError) + ex.Message, ex.Message,
                    MessageButton.OK, MessageIcon.Error);
            }
        }

        public void NoDeliveryReason()
        {
            try
            {
                DocumentManagerService.CreateDocument(GetStringValue(Next.Enums.Enums.Views.NoDeliveryReasonCollection), 
                    NoDeliveryReasonCollectionViewModel.Create(), null, this).Show();
            }
            catch (Exception ex)
            {
                MessageBoxService.ShowMessage(GetStringValue(Next.Enums.Enums.MessageError.WindowError) + ex.Message, ex.Message,
                    MessageButton.OK, MessageIcon.Error);
            }
        }

        public void RefundAction()
        {
            try
            {
                DocumentManagerService.CreateDocument(GetStringValue(Next.Enums.Enums.Views.RefundAction), 
                    RefundActionCollectionViewModel.Create(), null, this).Show();
            }
            catch (Exception ex)
            {
                MessageBoxService.ShowMessage(GetStringValue(Next.Enums.Enums.MessageError.WindowError) + ex.Message, ex.Message,
                    MessageButton.OK, MessageIcon.Error);
            }
        }

        public void ShowReDelivery()
        {
            try
            {
                DocumentManagerService.CreateDocument(GetStringValue(Next.Enums.Enums.Views.ReDelivery), 
                    ReDeliveryViewModel.Create(CreateUnitOfWork(), DocumentManagerService), this, null).Show();
            }
            catch (Exception ex)
            {
                MessageBoxService.ShowMessage(GetStringValue(Next.Enums.Enums.MessageError.WindowError) + ex.Message, ex.Message,
                    MessageButton.OK, MessageIcon.Error);
            }
        }

        public void ShowPreview()
        {
            ExportGridService.ShowPreview();
        }

        public bool CanShowMap()
        {
            return SelectedEntity != null;
        }

        protected override void OnEntitiesAssigned(Func<DeliveryTask> getSelectedEntityCallback)
        {
            base.OnEntitiesAssigned(getSelectedEntityCallback);
            if (Entities.Any() && SelectedEntity == null)
                SelectedEntity = Entities.OrderBy(x => x.Id).FirstOrDefault();
        }

        public virtual void OnTableViewSelectedEntityChanged()
        {
            if (viewSettings.ViewKind == CollectionViewKind.ListView)
                SelectedEntity = TableViewSelectedEntity;
        }

        public void CreateCustomFilter()
        {
            Messenger.Default.Send(new CreateCustomFilterMessage<DeliveryTask>(Next.Enums.Enums.Modules.Historico.ToString()));
        }

        protected override void OnSelectedEntityChanged()
        {
            base.OnSelectedEntityChanged();
            TableViewSelectedEntity = SelectedEntity;
        }

        #region ISupportFiltering
        Expression<Func<DeliveryTask, bool>> ISupportFiltering<DeliveryTask>.FilterExpression
        {
            get { return FilterExpression; }
            set { FilterExpression = value; }
        }
        #endregion
    }
}