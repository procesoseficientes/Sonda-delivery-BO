using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataModel;
using DevExpress.Mvvm.POCO;
using DevExpress.Mvvm.ViewModel;
using static Next.Utils.Enums.Enums;
using Next.Utils.Enums;
using NextApi.Models.Models;
using NextBO.DataModel;
using NextBO.Wpf.Common;
using System.ComponentModel;
using NextBO.Wpf.Services;
using System.Diagnostics;
using DevExpress.Xpf.Grid;

namespace NextBO.Wpf.ViewModels
{
    public class DetailViewModel : CollectionViewModel<WorkItem, long, INextBOUnitOfWork>
    {
        /// <summary>
        /// Creates a new instance of DetailViewModel as a POCO view model.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        public static DetailViewModel Create(IUnitOfWorkFactory<INextBOUnitOfWork> unitOfWorkFactory = null, UnitOfWorkPolicy unitOfWorkPolicy = UnitOfWorkPolicy.Individual)
        {
            return ViewModelSource.Create(() => new DetailViewModel(unitOfWorkFactory, unitOfWorkPolicy));
        }

        /// <summary>
        /// Initializes a new instance of the DetailViewModel class.
        /// This constructor is declared protected to avoid undesired instantiation of the DetailViewModel type without the POCO proxy factory.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        protected DetailViewModel(IUnitOfWorkFactory<INextBOUnitOfWork> unitOfWorkFactory = null, UnitOfWorkPolicy unitOfWorkPolicy = UnitOfWorkPolicy.Individual)
            : base(unitOfWorkFactory ?? UnitOfWorkSource.GetUnitOfWorkFactory(), x => x.WorkItems, unitOfWorkPolicy: unitOfWorkPolicy)
        {
            LookUpCategories = this.CreateUnitOfWork().Categories.ToList();
        }


        protected virtual IExportGridService ExportGridService { get { return null; } }
        protected virtual ISaveFileDialogService SaveFileDialogService { get { return null; } }
        ViewSettingsViewModel viewSettings;
        public virtual WorkItem TableViewSelectedEntity { get; set; }

        public List<Category> LookUpCategories
        {
            get;
            set;
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

        public void ShowPreview()
        {
            ExportGridService.ShowPreview();
        }

        public void ItemSelectedUpdated(GridRowValidationEventArgs e)
        {
            try
            {
                var entity = (WorkItem)e.Row;
                if (entity.Name != null && entity.Description != null
                    && entity.CategoryId > 0)
                {
                    base.ItemUpdated(entity);
                    e.IsValid = true;
                    return;
                }
                e.ErrorContent = GetStringValue(Next.Enums.Enums.MessageError.RequiredError);
                e.IsValid = false;
            }
            catch(Exception ex)
            {
                MessageBoxService.ShowMessage(GetStringValue(Next.Enums.Enums.MessageError.SaveError) + ex.Message, ex.Message,
                    MessageButton.OK, MessageIcon.Error);
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

        public void WindowClosing(CancelEventArgs e)
        {
            if (SelectedEntity != null)
            {
                e.Cancel = false;
            }
        }

        protected override void OnSelectedEntityChanged()
        {
            base.OnSelectedEntityChanged();
            TableViewSelectedEntity = SelectedEntity;
        }

        protected override void OnEntitiesAssigned(Func<WorkItem> getSelectedEntityCallback)
        {
            base.OnEntitiesAssigned(getSelectedEntityCallback);
            if (Entities.Any() && SelectedEntity == null)
            {
                SelectedEntity = Entities.OrderBy(x => x.Id).FirstOrDefault();
            }
        }

        public virtual void OnTableViewSelectedEntityChanged()
        {
            if (viewSettings.ViewKind == CollectionViewKind.ListView)
                SelectedEntity = TableViewSelectedEntity;
        }

    }
}
