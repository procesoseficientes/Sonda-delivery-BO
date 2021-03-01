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
using Microsoft.EntityFrameworkCore;
using NextApi.DataAccessLayer;
using System.Collections.Generic;
using NextBO.Wpf.Services;
using System.Diagnostics;
using NextApi.Models.Resources.Responses;
using System.Collections.ObjectModel;

namespace NextBO.Wpf.ViewModels
{
    public class TaskViewModel : SingleObjectViewModel<Task, long, INextBOUnitOfWork>
    {
        /// <summary>
        /// Creates a new instance of UserViewModel as a POCO view model.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        public static TaskViewModel Create(IUnitOfWorkFactory<INextBOUnitOfWork> unitOfWorkFactory = null)
        {
            return ViewModelSource.Create(() => new TaskViewModel(unitOfWorkFactory));

        }

        /// <summary>
        /// Initializes a new instance of the UserViewModel class.
        /// This constructor is declared protected to avoid undesired instantiation of the UserViewModel type without the POCO proxy factory.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        protected TaskViewModel(IUnitOfWorkFactory<INextBOUnitOfWork> unitOfWorkFactory = null)
            : base(unitOfWorkFactory ?? UnitOfWorkSource.GetUnitOfWorkFactory(), x => x.DailyDeliveryTask, x => x.Id)
        {

        }


        protected override void OnEntityChanged()
        {
            base.OnEntityChanged();
            if (Entity != null)
                Logger.Log(string.Format("Next: Edit User: {0}",
                    string.IsNullOrEmpty(Entity.Id.ToString()) ? "<New>" : Entity.Id.ToString()));
        }
        protected override bool TryClose()
        {
            var closed = base.TryClose();
            if (closed)
                DocumentManagerService.Documents.First(x => x.Content == this).DestroyOnClose = true;
            return closed;
        }
        protected override string GetTitle()
        {
            return Entity.Id.ToString() + " - " + Entity.ClientName;
        }

        protected IDocumentManagerService DocumentManagerService { get { return this.GetRequiredService<IDocumentManagerService>(); } }

        //public virtual Task TableViewSelectedEntity { get; set; }
        //public virtual Task CurrentDeliveryTask { get; set; }


        //ViewSettingsViewModel viewSettingsView;

        protected virtual ISaveFileDialogService SaveFileDialogService { get { return null; } }
        protected virtual IExportGridService ExportGridService { get { return null; } }
        protected IUserSessionService UserSessionService { get { return this.GetRequiredService<IUserSessionService>(); } }

        //public ViewSettingsViewModel ViewSettings
        //{
        //    get
        //    {
        //        if (viewSettingsView == null)
        //            viewSettingsView = ViewSettingsViewModel.Create(CollectionViewKind.ListView, this);
        //        return viewSettingsView;
        //    }
        //}

        public void ShowPreview()
        {
            ExportGridService.ShowPreview();
        }
        protected IMessageBoxService MessageBoxService { get { return this.GetRequiredService<IMessageBoxService>(); } }
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
                MessageBoxService.ShowMessage("Ocurrió un error inesperado al exportar el archivo", ex.Message);
            }
        }

    }
}
