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
using static Next.Utils.Enums.Enums;
using NextBO.Wpf.Services;
using System.Diagnostics;
using DevExpress.XtraReports.UI;

namespace NextBO.Wpf.ViewModels
{
    public class DeliveryCollectionViewModel : CollectionViewModel<DeliveryTask, long, INextBOUnitOfWork>, ISupportFiltering<DeliveryTask>
    {

        /// <summary>
        /// Creates a new instance of DeliveryCollectionViewModel as a POCO view model.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        public static DeliveryCollectionViewModel Create(IUnitOfWorkFactory<INextBOUnitOfWork> unitOfWorkFactory = null, UnitOfWorkPolicy unitOfWorkPolicy = UnitOfWorkPolicy.Individual)
        {
            return ViewModelSource.Create(() => new DeliveryCollectionViewModel(unitOfWorkFactory, unitOfWorkPolicy));
        }

        /// <summary>
        /// Initializes a new instance of the DeliveryCollectionViewModel class.
        /// This constructor is declared protected to avoid undesired instantiation of the DeliveryCollectionViewModel type without the POCO proxy factory.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        protected DeliveryCollectionViewModel(IUnitOfWorkFactory<INextBOUnitOfWork> unitOfWorkFactory = null, UnitOfWorkPolicy unitOfWorkPolicy = UnitOfWorkPolicy.Individual)
            : base(unitOfWorkFactory ?? UnitOfWorkSource.GetUnitOfWorkFactory(), x => x.Tasks, query => query.Where(x => x.Status == "PENDING" || (x.Status == "DELIVERED" && x.CreatedDate.Value.Date == DateTime.Now.Date) || (x.Status == "CANCELLED" && x.CreatedDate.Value.Date == DateTime.Now.Date)), unitOfWorkPolicy: unitOfWorkPolicy)
        {
        }

        ViewSettingsViewModel viewSettings;
        protected virtual ISaveFileDialogService SaveFileDialogService { get { return null; } }
        protected virtual IExportGridService ExportGridService { get { return null; } }
        protected IUserSessionService UserSessionService { get { return this.GetRequiredService<IUserSessionService>(); } }
        public virtual DeliveryTask TableViewSelectedEntity { get; set; }
        public virtual DeliveryTask CardViewSelectedEntity { get; set; }
        public UICommand SaveLayoutCommand { get; set; }
        public UICommand RestoreLayoutCommand { get; set; }
        IReportService PrintService { get { return this.GetRequiredService<IReportService>("PrintService"); } }
        IReportService ExportService { get { return this.GetRequiredService<IReportService>("ExportService"); } }


        public ViewSettingsViewModel ViewSettings
        {
            get
            {
                if (viewSettings == null)
                    viewSettings = ViewSettingsViewModel.Create(CollectionViewKind.ListView, this);
                return viewSettings;
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
                MessageBoxService.ShowMessage(ex.Message, "Error", MessageButton.OK, MessageIcon.Error);
            }
        }

        public void LoadReport(bool showReport)
        {
            try
            {
                var UnitOfWork = UnitOfWorkFactory.CreateUnitOfWork();
                var report = ReportInfoFactory.GetReportbyName(GetStringValue(Next.Enums.Enums.Report.Entrega), Entities, UnitOfWork);

                foreach (var item in report.Bands)
                {
                    SetReportDataMember((Band)item);

                    if (item is DetailReportBand)
                    {
                        foreach (var detail in ((DetailReportBand)item))
                        {
                            SetReportDataMember((Band)detail);
                        }
                    }
                }

                if (showReport)
                    ShowReport(ReportInfoFactory.GetReportInfoFromXtraReport(report), "Entregas");
                else
                    SetDefaultReport(ReportInfoFactory.GetReportInfoFromXtraReport(report));
            }
            catch (Exception ex)
            {
                MessageBoxService.ShowMessage(GetStringValue(Next.Enums.Enums.MessageError.ReportError),
                    ex.Message, MessageButton.OK, MessageIcon.Error);
            }
        }

        public void SetReportDataMember(Band reportBand)
        {
            try
            {
                switch (reportBand.Name)
                {
                    case "DetailReport":
                        if (reportBand is DetailReportBand)
                        {
                            ((DetailReportBand)reportBand).DataMember = "List.Documents";
                        }
                        break;
                    case "DetailReport1":
                        if (reportBand is DetailReportBand)
                        {
                            ((DetailReportBand)reportBand).DataMember = "List.Documents.DocumentDetail";
                        }
                        break;

                    case "DetailReport2":
                        if (reportBand is DetailReportBand)
                        {
                            ((DetailReportBand)reportBand).DataMember = "List.DeliveryImages";
                        }
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
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

        public void PrintDeliveries()
        {
            LoadReport(true);
        }

        public bool CanPrintDeliveriesCommand()
        {
            return Entities != null;
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
                MessageBoxService.ShowMessage(GetStringValue(Next.Enums.Enums.MessageError.ExportError), ex.Message);
            }
        }
        // ------------------------------------------------------------------------------------------------------------------------------------
        public void NoDeliveryReason()
        {
            try
            {
                var noDeliveryReason = NoDeliveryReasonCollectionViewModel.Create();
                DocumentManagerService.CreateDocument(GetStringValue(Next.Enums.Enums.Views.NoDeliveryReason), noDeliveryReason, null, this).Show();
            }
            catch (Exception ex)
            {
                MessageBoxService.ShowMessage(ex.Message, "Error", MessageButton.OK, MessageIcon.Error);
            }
        }

        public void RouteTracking()
        {
            try
            {
                DocumentManagerService.CreateDocument(GetStringValue(Next.Enums.Enums.Views.RouteTracking),
                RouteTrackingCollectionViewModel.Create(CreateUnitOfWork(), DocumentManagerService), this, null).Show();
            }
            catch (Exception ex)
            {
                MessageBoxService.ShowMessage(ex.Message, "Error", MessageButton.OK, MessageIcon.Error);
            }
        }

        public void RefundAction()
        {
            try
            {
                var refundAction = RefundActionCollectionViewModel.Create();
                DocumentManagerService.CreateDocument(GetStringValue(Next.Enums.Enums.Views.RefundAction), refundAction, null, this).Show();
            }
            catch (Exception ex)
            {
                MessageBoxService.ShowMessage(ex.Message, "Error", MessageButton.OK, MessageIcon.Error);
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

        public override void UpdateSelectedEntity()
        {
            base.UpdateSelectedEntity();
        }

        protected override void OnEntitiesAssigned(Func<DeliveryTask> getSelectedEntityCallback)
        {
            base.OnEntitiesAssigned(getSelectedEntityCallback);

            if (Entities.Any())
            {
                LoadReport(false);
                if (SelectedEntity == null)
                {
                    SelectedEntity = Entities.OrderBy(x => x.Id).FirstOrDefault();
                }
            }
        }

        public virtual void OnTableViewSelectedEntityChanged()
        {
            if (viewSettings.ViewKind == CollectionViewKind.ListView)
                SelectedEntity = TableViewSelectedEntity;
        }

        public virtual void OnCardViewSelectedEntityChanged()
        {
            if (viewSettings.ViewKind == CollectionViewKind.CardView)
                SelectedEntity = CardViewSelectedEntity;
        }

        public void CreateCustomFilter()
        {
            Messenger.Default.Send(new CreateCustomFilterMessage<DeliveryTask>(Next.Enums.Enums.Modules.Entregas.ToString()));
        }

        protected override void OnSelectedEntityChanged()
        {
            base.OnSelectedEntityChanged();
            TableViewSelectedEntity = SelectedEntity;
            CardViewSelectedEntity = SelectedEntity;
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