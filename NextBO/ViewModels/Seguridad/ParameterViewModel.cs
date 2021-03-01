using System;
using DevExpress.Mvvm;
using NextBO.Wpf.Common;
using NextBO.DataModel;
using NextApi.Models.Models;
using DevExpress.Mvvm.DataModel;
using DevExpress.Mvvm.ViewModel;
using DevExpress.Mvvm.POCO;
using System.Linq;
using NextBO.Wpf.Services;
using System.Diagnostics;
using static Next.Utils.Enums.Enums;
using DevExpress.Xpf.Grid;

namespace NextBO.Wpf.ViewModels
{
    public class ParameterViewModel : CollectionViewModel<Parameter, int, INextBOUnitOfWork>
    {

        public static ParameterViewModel Create(IUnitOfWorkFactory<INextBOUnitOfWork> unitOfWorkFactory = null, UnitOfWorkPolicy unitOfWorkPolicy = UnitOfWorkPolicy.Individual)
        {
            return ViewModelSource.Create(() => new ParameterViewModel(unitOfWorkFactory,unitOfWorkPolicy));
        }

        protected ParameterViewModel(IUnitOfWorkFactory<INextBOUnitOfWork> unitOfWorkFactory = null, UnitOfWorkPolicy unitOfWorkPolicy = UnitOfWorkPolicy.Individual) 
            : base(unitOfWorkFactory ?? UnitOfWorkSource.GetUnitOfWorkFactory(), x => x.Parameters, unitOfWorkPolicy: unitOfWorkPolicy )
        {
        }

        public virtual Parameter TableViewSelectedEntity { get; set; }
        protected IUserSessionService UserSessionService { get { return this.GetRequiredService<IUserSessionService>(); } }
        protected virtual ISaveFileDialogService SaveFileDialogService { get { return null; } }
        protected virtual IExportGridService ExportGridService { get { return null; } }

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

        public void ShowPreview()
        {
            ExportGridService.ShowPreview();
        }

        public void ItemSelectedUpdated(GridRowValidationEventArgs e)
        {
            try
            {
                var entity = (Parameter)e.Row;
                if (entity.Name != null)
                {
                    entity.ModifiedBy = UserSessionService.LoggedUser.UserLogin;
                    entity.ModifiedDate = DateTime.Now;
                    if (entity.Id == new int())
                    {
                        entity.CreatedBy = UserSessionService.LoggedUser.UserLogin;
                        entity.CreationDate = DateTime.Now;
                    }
                    base.ItemUpdated(entity);
                    e.IsValid = true;
                    return;
                }
                e.ErrorContent = GetStringValue(Next.Enums.Enums.MessageError.RequiredError);
                e.IsValid = false;
            }
            catch (Exception ex)
            {
                MessageBoxService.ShowMessage(GetStringValue(Next.Enums.Enums.MessageError.SaveError) + ex.Message, ex.Message,
                    MessageButton.OK, MessageIcon.Error);
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

        protected override void OnSelectedEntityChanged()
        {
            base.OnSelectedEntityChanged();
            TableViewSelectedEntity = SelectedEntity;
        }

        protected override void OnEntitiesAssigned(Func<Parameter> getSelectedEntityCallback)
        {
            base.OnEntitiesAssigned(getSelectedEntityCallback);
            if (Entities.Any() && SelectedEntity == null)
                SelectedEntity = Entities.OrderBy(x => x.Name).FirstOrDefault();
        }

        public virtual void OnTableViewSelectedEntityChanged()
        {
            if (viewSettings.ViewKind == CollectionViewKind.ListView)
                SelectedEntity = TableViewSelectedEntity;
        }
    }
}
