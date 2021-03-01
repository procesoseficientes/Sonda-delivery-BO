using DevExpress.Mvvm;
using DevExpress.Mvvm.DataModel;
using DevExpress.Mvvm.POCO;
using DevExpress.Mvvm.ViewModel;
using NextApi.Models.Models;
using NextBO.DataModel;
using NextBO.Wpf.Common;
using NextBO.Wpf.Services;
using System;
using System.Diagnostics;
using static Next.Utils.Enums.Enums;

namespace NextBO.Wpf.ViewModels
{
    public class WorkOrderCollectionViewModel : CollectionViewModel<WorkOrder, long, INextBOUnitOfWork>
    {

        /// <summary>
        /// Creates a new instance of WorkOrderCollectionViewModel as a POCO view model.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        public static WorkOrderCollectionViewModel Create(IUnitOfWorkFactory<INextBOUnitOfWork> unitOfWorkFactory = null, UnitOfWorkPolicy unitOfWorkPolicy = UnitOfWorkPolicy.Individual)
        {
            return ViewModelSource.Create(() => new WorkOrderCollectionViewModel(unitOfWorkFactory, unitOfWorkPolicy));
        }

        /// <summary>
        /// Initializes a new instance of the WorkOrderCollectionViewModel class.
        /// This constructor is declared protected to avoid undesired instantiation of the WorkOrderCollectionViewModel type without the POCO proxy factory.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        protected WorkOrderCollectionViewModel(IUnitOfWorkFactory<INextBOUnitOfWork> unitOfWorkFactory = null, UnitOfWorkPolicy unitOfWorkPolicy = UnitOfWorkPolicy.Individual)
            : base(unitOfWorkFactory ?? UnitOfWorkSource.GetUnitOfWorkFactory(), x => x.WorkOrders, unitOfWorkPolicy: unitOfWorkPolicy)
        {
        }

        protected virtual ISaveFileDialogService SaveFileDialogService { get { return null; } }
        protected virtual IExportGridService ExportGridService { get { return null; } }

        public void ShowDetails()
        {
            try
            {
                ShowDocument(
                    DocumentManagerService.CreateDocument(GetStringValue(Next.Enums.Enums.Views.Detail),
                    DetailViewModel.Create(), null, this),
                    GetStringValue(Next.Enums.Enums.WindowTitle.Detail));
            }
            catch (Exception ex)
            {
                MessageBoxService.ShowMessage(GetStringValue(Next.Enums.Enums.MessageError.WindowError) + ex.Message, ex.Message,
                    MessageButton.OK, MessageIcon.Error);
            }
        }

        public void ShowServices()
        {
            try
            {
                ShowDocument(
                    DocumentManagerService.CreateDocument(GetStringValue(Next.Enums.Enums.Views.ServiceCollection),
                ServiceCollectionViewModel.Create(), null, this),
                    GetStringValue(Next.Enums.Enums.WindowTitle.ServiceCollection));
            }
            catch (Exception ex)
            {
                MessageBoxService.ShowMessage(GetStringValue(Next.Enums.Enums.MessageError.WindowError) + ex.Message, ex.Message,
                    MessageButton.OK, MessageIcon.Error);
            }
        }

        public void ShowCenterOfServices()
        {
            try
            {
                ShowDocument(
                    DocumentManagerService.CreateDocument(
                        GetStringValue(Next.Enums.Enums.Views.CenterOfService),
                        CenterOfServiceCollectionViewModel.Create(), null, this),
                    GetStringValue(Next.Enums.Enums.WindowTitle.CenterOfService));
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

        public void CreateCustomFilter()
        {
            Messenger.Default.Send(new CreateCustomFilterMessage<WorkOrder>(Next.Enums.Enums.Modules.Ordenes.ToString()));
        }
    }
}
