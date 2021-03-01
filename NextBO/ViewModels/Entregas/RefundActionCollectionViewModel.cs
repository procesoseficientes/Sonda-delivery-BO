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
using System.Linq.Expressions;
using static Next.Utils.Enums.Enums;
using DevExpress.Xpf.Grid;

namespace NextBO.Wpf.ViewModels
{
    public class RefundActionCollectionViewModel : CollectionViewModel<RefundAction, int, INextBOUnitOfWork>, ISupportFiltering<RefundAction>
    {
        /// <summary>
        /// Creates a new instance of EmployeeCollectionViewModel as a POCO view model.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param> 
        public static RefundActionCollectionViewModel Create(IUnitOfWorkFactory<INextBOUnitOfWork> unitOfWorkFactory = null, UnitOfWorkPolicy unitOfWorkPolicy = UnitOfWorkPolicy.Individual)
        {
            return ViewModelSource.Create(() => new RefundActionCollectionViewModel(unitOfWorkFactory, unitOfWorkPolicy));
        }

        protected RefundActionCollectionViewModel(IUnitOfWorkFactory<INextBOUnitOfWork> unitOfWorkFactory = null, UnitOfWorkPolicy unitOfWorkPolicy = UnitOfWorkPolicy.Individual)
            : base(unitOfWorkFactory ?? UnitOfWorkSource.GetUnitOfWorkFactory(), x => x.RefundActions, unitOfWorkPolicy: unitOfWorkPolicy)
        { 
        }

        ViewSettingsViewModel viewSettings;
        protected IUserSessionService UserSessionService { get { return this.GetRequiredService<IUserSessionService>(); } }
        protected virtual ISaveFileDialogService SaveFileDialogService { get { return null; } }
        protected virtual IExportGridService ExportGridService { get { return null; } }
        public UICommand SaveLayoutCommand { get; set; }
        public UICommand RestoreLayoutCommand { get; set; }
        public virtual RefundAction TableViewSelectedEntity { get; set; }

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
                var entity = (RefundAction)e.Row;
                if (entity.Action != null)
                {
                    entity.UserIdUpdated = UserSessionService.LoggedUser.UserLogin;
                    entity.LastUpdate = DateTime.Now;
                    if (entity.Id == new int())
                    {
                        entity.UserIdCreated = UserSessionService.LoggedUser.UserLogin;
                        entity.CreatedDate = DateTime.Now;
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
                MessageBoxService.ShowMessage(GetStringValue(Next.Enums.Enums.MessageError.SaveError), ex.Message,
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
                MessageBoxService.ShowMessage(GetStringValue(Next.Enums.Enums.MessageError.ExportError), ex.Message,
                        MessageButton.OK,MessageIcon.Error);
            }
        }

        public void Activate(RefundAction projectionEntity)
        {
            var entity = this.Entities.Where(x => x.Id == projectionEntity.Id).FirstOrDefault();
            entity.IsActive = 1;
            entity.UserIdUpdated = UserSessionService.LoggedUser.UserLogin;
            entity.LastUpdate = DateTime.Now;
            this.CreateUnitOfWork().UpdateRefund(entity);
            this.Refresh();
        }

        public override void Delete(RefundAction projectionEntity)
        {
            var entity = this.Entities.Where(x => x.Id == projectionEntity.Id).FirstOrDefault();
            entity.IsActive = 0;
            entity.UserIdUpdated = UserSessionService.LoggedUser.UserLogin;
            entity.LastUpdate = DateTime.Now;
            this.CreateUnitOfWork().UpdateRefund(projectionEntity);
            this.Refresh();
        }

        public bool CanActivate(RefundAction projectionEntity)
        {
            return (projectionEntity != null && projectionEntity.IsActive == 0);
        }

        public override bool CanDelete(RefundAction projectionEntity)
        {
            return (projectionEntity != null && projectionEntity.IsActive == 1);
        }

        protected override void OnSelectedEntityChanged()
        {
            base.OnSelectedEntityChanged();
            TableViewSelectedEntity = SelectedEntity;   
        }

        protected override void OnEntitiesAssigned(Func<RefundAction> getSelectedEntityCallback)
        {
            base.OnEntitiesAssigned(getSelectedEntityCallback);
            if (Entities.Any() && SelectedEntity == null)
                SelectedEntity = Entities.OrderBy(x => x.Action).FirstOrDefault();
        }

        public virtual void OnTableViewSelectedEntityChanged()
        {
            if (ViewSettings.ViewKind == CollectionViewKind.ListView)
                SelectedEntity = TableViewSelectedEntity;
        }

        Expression<Func<RefundAction, bool>> ISupportFiltering<RefundAction>.FilterExpression
        {
            get { return FilterExpression; }
            set { FilterExpression = value; }
        }
        
    }
}   