using static Next.Utils.Enums.Enums;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using NextApi.Models.Models;
using NextApi.Models.Resources.Responses;
using NextBO.DataModel;
using NextBO.Wpf.Common.ViewModel;
using NextBO.Wpf.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace NextBO.Wpf.ViewModels
{
    public class ReDeliveryViewModel
    {

        public static ReDeliveryViewModel Create(INextBOUnitOfWork unitOfWork, IDocumentManagerService documentManager)
        {
            return ViewModelSource.Create(() => new ReDeliveryViewModel(unitOfWork, documentManager));
        }

        protected ReDeliveryViewModel(INextBOUnitOfWork UnitOfWork, IDocumentManagerService documentManager)
        {
            Documents = UnitOfWork.GetLastDocument();
            FindDocumentssByDocNum(UnitOfWork);
            unitOfWork = UnitOfWork;
            DocumentManagerService = documentManager;
        }

        protected IUserSessionService UserSessionService { get { return this.GetRequiredService<IUserSessionService>(); } }
        protected IMessageBoxService MessageBoxService { get { return this.GetRequiredService<IMessageBoxService>(); } }
        protected virtual ISaveFileDialogService SaveFileDialogService { get { return null; } }
        protected virtual IExportGridService ExportGridService { get { return null; } }
        public virtual Document SelectedEntity { get; set; }
        public virtual List<Document> Documents { get; set; }

        public static DateTime endDate = DateTime.Now.Date;
        public static DateTime startDate = DateTime.Now.Date;
        protected IDocumentManagerService DocumentManagerService;
        public INextBOUnitOfWork unitOfWork;
        ViewSettingsViewModel viewSettings;

        public ViewSettingsViewModel ViewSettings
        {
            get
            {
                if (viewSettings == null)
                    viewSettings = ViewSettingsViewModel.Create(CollectionViewKind.ListView, this);
                return viewSettings;
            }
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

        public void ShowPreview()
        {
            ExportGridService.ShowPreview();
        }

        public void RefreshPage()
        {
            try
            {
                Documents = unitOfWork.GetLastDocument().Where(x => x.CreatedDate.Value.Date >= StartDate.Date && x.CreatedDate.Value.Date <= EndDate.Date ).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void CancelFilter()
        {
            try
            {
                Documents = unitOfWork.GetLastDocument();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
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
                MessageBoxService.ShowMessage(GetStringValue(Next.Enums.Enums.MessageError.ExportError), ex.Message,
                    MessageButton.OK, MessageIcon.Error);
            }
        }

        public void PrintReprocess()
        {
            try
            {
                DocumentManagerService.CreateDocument(GetStringValue(Next.Enums.Enums.Views.Reporter), 
                    ReporterViewModel.Create(unitOfWork.GetDocumentsByDocNumber(SelectedEntity.DocNum),
                    GetStringValue(Next.Enums.Enums.Report.Reproceso), "Reporte de Reentregas", unitOfWork), null, this).Show();
            }
            catch (Exception ex)
            {
                MessageBoxService.ShowMessage(GetStringValue(Next.Enums.Enums.MessageError.ReportError), ex.Message,
                    MessageButton.OK, MessageIcon.Error);
            }
        }

        public bool CanPrintReprocess()
        {
            return SelectedEntity != null;
        }

        public void FindDocumentssByDocNum(INextBOUnitOfWork unitOfWork)
        {
            try
            {
                foreach (var item in Documents)
                {
                    item.Tasks = new List<DeliveryTask>();
                    foreach (var document in unitOfWork.Documents.Where(x => x.DocNum == item.DocNum).OrderByDescending(x => x.TaskId).ToList())
                    {
                        item.Tasks.Add(document.Task);
                        if (document.Task.ReasonNoDeliveryId != null)
                        {
                            var reason = unitOfWork.ReasonNoDeliveries.Where(r => r.Id == document.Task.ReasonNoDeliveryId).Select(r => r.Reason).FirstOrDefault();
                            document.Task.NoReasonDelivery = reason.ToString();
                        }
                    }

                    int x = 0;
                    item.Tasks.ForEach(task =>
                    {
                        var listDetail = unitOfWork.Documents.Where(x => x.DocNum == item.DocNum).OrderByDescending(x => x.Id).ToList();
                        foreach (var detail in listDetail[x].DocumentDetail)
                        {
                            task.QtyTotal += detail.QtyDelivered;
                        }
                        x++;
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
