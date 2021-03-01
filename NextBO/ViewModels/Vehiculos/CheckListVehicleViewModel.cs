using DevExpress.Mvvm;
using DevExpress.Mvvm.DataModel;
using DevExpress.Mvvm.POCO;
using DevExpress.Mvvm.ViewModel;
using NextApi.Models.Models;
using NextBO.DataModel;
using NextBO.Wpf.Common;
using NextBO.Wpf.Common.ViewModel;
using static Next.Utils.Enums.Enums;
using NextBO.Wpf.Services;
using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;
using System.Collections.Generic;

namespace NextBO.Wpf.ViewModels
{
    public class CheckListVehicleViewModel : CollectionViewModel<CheckListByVehicle, long, INextBOUnitOfWork>
    {

        /// <summary>
        /// Creates a new instance of CheckListVehicleViewModel as a POCO view model.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        public static CheckListVehicleViewModel Create(IUnitOfWorkFactory<INextBOUnitOfWork> unitOfWorkFactory = null, UnitOfWorkPolicy unitOfWorkPolicy = UnitOfWorkPolicy.Individual)
        {
            return ViewModelSource.Create(() => new CheckListVehicleViewModel(unitOfWorkFactory, unitOfWorkPolicy));
        }

        /// <summary>
        /// Initializes a new instance of the CheckListVehicleViewModel class.
        /// This constructor is declared protected to avoid undesired instantiation of the CheckListVehicleViewModel type without the POCO proxy factory.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        protected CheckListVehicleViewModel(IUnitOfWorkFactory<INextBOUnitOfWork> unitOfWorkFactory = null, UnitOfWorkPolicy unitOfWorkPolicy = UnitOfWorkPolicy.Individual)
            : base(unitOfWorkFactory ?? UnitOfWorkSource.GetUnitOfWorkFactory(), x => x.CheckListByVehicles, 
                  query => query.Where(CheckListByVehicle => CheckListByVehicle.CreateDate.Value.Date >= startDate.Date &&
                  CheckListByVehicle.CreateDate.Value.Date >= startDate.Date &&
                  CheckListByVehicle.Vehicle.PilotId == (pilotId == 0 ? CheckListByVehicle.Vehicle.PilotId: pilotId) && 
                  CheckListByVehicle.VehicleId == (vehicleId == 0 ? CheckListByVehicle.VehicleId : vehicleId)),
                  unitOfWorkPolicy: unitOfWorkPolicy)
        {
            LookUpPilot = this.CreateUnitOfWork().Users.Where(x => x.Pilot != null).ToList();
            User pilot = new User{ Id = 0, Name = "todos" };
            LookUpPilot.Insert(0,pilot);
            LookUpVehicle = this.CreateUnitOfWork().Vehicles.ToList();
            Vehicle vehicle = new Vehicle { Brand = "Todos", Id = 0 };
            LookUpVehicle.Insert(0,vehicle);
        }

        public virtual string NoAvaliable { get; set; }
        public virtual ObservableCollection<BitmapImage> CollectionBitmapImages { get; set; }
        public virtual ObservableCollection<ImageCheckListByVehicle> CollectionImage { get; set; }
        public virtual CheckListByVehicle TableViewSelectedEntity { get; set; }
        IReportService PrintService { get { return this.GetRequiredService<IReportService>("PrintService"); } }
        IReportService ExportService { get { return this.GetRequiredService<IReportService>("ExportService"); } }
        protected virtual ISaveFileDialogService SaveFileDialogService { get { return null; } }
        protected virtual IExportGridService ExportGridService { get { return null; } }

        ViewSettingsViewModel viewSettings;

        public static DateTime startDate = DateTime.Now.AddDays(-7);
        public static DateTime endDate = DateTime.Now.AddDays(7);
        public static int pilotId = 0;
        public static int vehicleId = 0;

        public List<User> LookUpPilot
        {
            get;
            set;
        }

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

        public ViewSettingsViewModel ViewSettings
        {
            get
            {
                if (viewSettings == null)
                    viewSettings = ViewSettingsViewModel.Create(CollectionViewKind.ListView, this);
                return viewSettings;
            }
        }

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

        public void GetImageDelivery()
        {
            try
            {
                if (SelectedEntity == null)
                {
                    return;
                }
                ObservableCollection<ImageCheckListByVehicle> obsImageCheckList = new ObservableCollection<ImageCheckListByVehicle>();
                if (SelectedEntity.ImageCheckListByVehicles.Count() <= 0 && CollectionImage != null)
                {
                    CollectionImage.Clear();
                }
                foreach (var item in SelectedEntity.ImageCheckListByVehicles)
                {
                    obsImageCheckList.Add(item);
                }
                if (obsImageCheckList.Count > 0) CollectionImage = obsImageCheckList;
            }
            catch (Exception ex)
            {
                MessageBoxService.ShowMessage(GetStringValue(Next.Enums.Enums.MessageError.DataError) + ex.Message, ex.Message,
                    MessageButton.OK, MessageIcon.Error);
            }
        }

        public void ShowPreview()
        {
            ExportGridService.ShowPreview();
        }

        void ShowReport(IReportInfo reportInfo, string reportId)
        {
            ExportService.ShowReport(reportInfo);
            PrintService.ShowReport(reportInfo);
            Logger.Log(string.Format("OutlookInspiredApp: Create Report : User: {0}", reportId));
        }

        void SetDefaultReport(IReportInfo reportInfo)
        {
            if (this.IsInDesignMode()) return;
            ExportService.SetDefaultReport(reportInfo);
            PrintService.SetDefaultReport(reportInfo);
        }

        protected override void OnSelectedEntityChanged()
        {
            base.OnSelectedEntityChanged();
            TableViewSelectedEntity = SelectedEntity;
            GetImageDelivery();
        }

        protected override void OnEntitiesAssigned(Func<CheckListByVehicle> getSelectedEntityCallback)
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

    } 
}
