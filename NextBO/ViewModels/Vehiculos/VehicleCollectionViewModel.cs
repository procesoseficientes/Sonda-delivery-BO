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
using NextBO.Wpf.Services;
using System.Diagnostics;
using static Next.Utils.Enums.Enums;

namespace NextBO.Wpf.ViewModels
{
   public  class VehicleCollectionViewModel : CollectionViewModel<Vehicle, int, INextBOUnitOfWork>, ISupportFiltering<Vehicle>
    {

        /// <summary>
        /// Creates a new instance of VehicleCollectionViewModel as a POCO view model.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        public static VehicleCollectionViewModel Create(IUnitOfWorkFactory<INextBOUnitOfWork> unitOfWorkFactory = null, UnitOfWorkPolicy unitOfWorkPolicy = UnitOfWorkPolicy.Individual)
        {
            return ViewModelSource.Create(() => new VehicleCollectionViewModel(unitOfWorkFactory, unitOfWorkPolicy));
        }

        /// <summary>
        /// Initializes a new instance of the VehicleCollectionViewModel class.
        /// This constructor is declared protected to avoid undesired instantiation of the VehicleCollectionViewModel type without the POCO proxy factory.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        protected VehicleCollectionViewModel(IUnitOfWorkFactory<INextBOUnitOfWork> unitOfWorkFactory = null, UnitOfWorkPolicy unitOfWorkPolicy = UnitOfWorkPolicy.Individual)
            : base(unitOfWorkFactory ?? UnitOfWorkSource.GetUnitOfWorkFactory(), x => x.Vehicles, unitOfWorkPolicy: unitOfWorkPolicy)
        {
        }

        ViewSettingsViewModel viewSettings;
        protected virtual ISaveFileDialogService SaveFileDialogService { get { return null; } }
        protected virtual IExportGridService ExportGridService { get { return null; } }
        protected IUserSessionService UserSessionService { get { return this.GetRequiredService<IUserSessionService>(); } }
        public virtual Vehicle TableViewSelectedEntity { get; set; }
        IReportService PrintService { get { return this.GetRequiredService<IReportService>("PrintService"); } }
        IReportService ExportService { get { return this.GetRequiredService<IReportService>("ExportService"); } }
        public UICommand SaveLayoutCommand { get; set; }
        public UICommand RestoreLayoutCommand { get; set; }

        public ViewSettingsViewModel ViewSettings
        {
            get
            {
                if (viewSettings == null)
                    viewSettings = ViewSettingsViewModel.Create(CollectionViewKind.ListView, this);
                return viewSettings;
            }
        }

        public void ShowCheckListVehicles()
        {
            try
            {
                DocumentManagerService.CreateDocument(GetStringValue(Next.Enums.Enums.Views.CheckListV),
                    CheckListVehicleViewModel.Create(), null, this).Show();
            }
            catch (Exception ex)
            {
                MessageBoxService.ShowMessage(GetStringValue(Next.Enums.Enums.MessageError.WindowError), ex.Message,
                        MessageButton.OK, MessageIcon.Error);
            }
        }

        public void CheckListVehicle()
        {
            try
            {
                DocumentManagerService.CreateDocument(GetStringValue(Next.Enums.Enums.Views.CheckListVCollection), 
                    CheckListVehicleCollectionViewModel.Create(), null, this).Show();
            }
            catch (Exception ex)
            {
                MessageBoxService.ShowMessage(GetStringValue(Next.Enums.Enums.MessageError.WindowError),ex.Message,
                        MessageButton.OK, MessageIcon.Error);
            }
        }

        /// <summary>
        /// Inactivate vehicle
        /// </summary>
        /// <param name="projectionEntity"></param>
        public override void Delete(Vehicle projectionEntity)
        {
            var entity = this.Entities.Where(x => x.Id == projectionEntity.Id).FirstOrDefault();
            entity.IsActive = 0;
            entity.UserIdUpdated = UserSessionService.LoggedUser.Id.ToString();
            entity.LastUpdate = DateTime.Now;
            this.CreateUnitOfWork().UpdateVehicle(projectionEntity);
            this.Refresh();
        }

        /// <summary>
        /// Activate vehicle
        /// </summary>
        /// <param name="projectionEntity"></param>
        public void Activate(Vehicle projectionEntity)
        {
            var entity = this.Entities.Where(x => x.Id == projectionEntity.Id).FirstOrDefault();
            entity.IsActive = 1;
            entity.UserIdUpdated = UserSessionService.LoggedUser.Id.ToString();
            entity.LastUpdate = DateTime.Now;
            this.CreateUnitOfWork().UpdateVehicle(entity);
            this.Refresh();
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
                MessageBoxService.ShowMessage(GetStringValue(Next.Enums.Enums.MessageError.ExportError), ex.Message,
                        MessageButton.OK, MessageIcon.Error);
            }
        }

        public override bool CanDelete(Vehicle projectionEntity)
        {
            return (projectionEntity != null && projectionEntity.IsActive == 1);
        }

        public bool CanActivate(Vehicle projectionEntity)
        {
            return (projectionEntity != null && projectionEntity.IsActive == 0);
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

        protected override void OnEntitiesAssigned(Func<Vehicle> getSelectedEntityCallback)
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
            Messenger.Default.Send(new CreateCustomFilterMessage<Vehicle>());
        }

        #region ISupportFiltering
        Expression<Func<Vehicle, bool>> ISupportFiltering<Vehicle>.FilterExpression
        {
            get { return FilterExpression; }
            set { FilterExpression = value; }
        }
        #endregion

    }
}
