using DevExpress.Mvvm;
using DevExpress.Mvvm.DataModel;
using DevExpress.Mvvm.POCO;
using DevExpress.Mvvm.ViewModel;
using DevExpress.Xpf.Grid;
using NextApi.Models.Models;
using NextBO.DataModel;
using NextBO.Wpf.Common;
using NextBO.Wpf.Services;
using System;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using static Next.Utils.Enums.Enums;

namespace NextBO.Wpf.ViewModels
{
    public class NoDeliveryReasonCollectionViewModel : CollectionViewModel<ReasonNoDelivery, int, INextBOUnitOfWork>, ISupportFiltering<ReasonNoDelivery>
    {
        /// <summary>
        /// Creates a new instance of NoDeliveryReasonCollectionViewModel as a POCO view model.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param> 
        public static NoDeliveryReasonCollectionViewModel Create(IUnitOfWorkFactory<INextBOUnitOfWork> unitOfWorkFactory = null, UnitOfWorkPolicy unitOfWorkPolicy = UnitOfWorkPolicy.Individual) {
            return ViewModelSource.Create(() => new NoDeliveryReasonCollectionViewModel(unitOfWorkFactory, unitOfWorkPolicy));
        }

        protected NoDeliveryReasonCollectionViewModel(IUnitOfWorkFactory<INextBOUnitOfWork> unitOfWorkFactory = null, UnitOfWorkPolicy unitOfWorkPolicy = UnitOfWorkPolicy.Individual)
            : base(unitOfWorkFactory ?? UnitOfWorkSource.GetUnitOfWorkFactory(), x => x.ReasonNoDeliveries, unitOfWorkPolicy: unitOfWorkPolicy)
        {
        }

        ViewSettingsViewModel viewSettings;
        protected virtual ISaveFileDialogService SaveFileDialogService { get { return null; } }
        protected virtual IExportGridService ExportGridService { get { return null; } }
        public virtual ReasonNoDelivery TableViewSelectedEntity { get; set; }
        protected IUserSessionService UserSessionService { get { return this.GetRequiredService<IUserSessionService>(); } }
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

        public void ShowPreview()
        {
            ExportGridService.ShowPreview();
        }

        public void ItemSelectedUpdated(GridRowValidationEventArgs e)
        {
            try
            {
                var entity = (ReasonNoDelivery)e.Row;
                if (entity.Reason != null)
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

        public void Activate(ReasonNoDelivery projectionEntity)
        {
            if(SelectedEntity != null)
            {
                var entity = this.Entities.Where(x => x.Id == projectionEntity.Id).FirstOrDefault();
                entity.IsActive = 1;
                entity.UserIdUpdated = UserSessionService.LoggedUser.UserLogin;
                entity.LastUpdate = DateTime.Now;
                this.CreateUnitOfWork().UpdateReasonNoDelivery(entity);
                this.Refresh();
            }
        }

        public override void Delete(ReasonNoDelivery projectionEntity)
        {
            if (SelectedEntity != null)
            {
                var entity = this.Entities.Where(x => x.Id == projectionEntity.Id).FirstOrDefault();
                entity.IsActive = 0;
                entity.UserIdUpdated = UserSessionService.LoggedUser.UserLogin;
                entity.LastUpdate = DateTime.Now;
                this.CreateUnitOfWork().UpdateReasonNoDelivery(projectionEntity);
                this.Refresh();
            }
        }

        public bool CanActivate(ReasonNoDelivery projectionEntity)
        {
            return (projectionEntity == null || projectionEntity.IsActive == 0);
        }

        public override bool CanDelete(ReasonNoDelivery projectionEntity)
        {
            return (projectionEntity != null && projectionEntity.IsActive == 1);
        }

        public bool CanShowMap()
        {
            return SelectedEntity != null;
        }

        public override void UpdateSelectedEntity()
        {
            base.UpdateSelectedEntity();
        }

        protected override void OnSelectedEntityChanged()
        {
            base.OnSelectedEntityChanged();
            TableViewSelectedEntity = SelectedEntity;
        }

        protected override void OnEntitiesAssigned(Func<ReasonNoDelivery> getSelectedEntityCallback)
        {
            base.OnEntitiesAssigned(getSelectedEntityCallback);
            if (Entities.Any() && SelectedEntity == null)
                SelectedEntity = Entities.OrderBy(x => x.Reason).FirstOrDefault();
        }

        public virtual void OnTableViewSelectedEntityChanged()
        {
            if (viewSettings.ViewKind == CollectionViewKind.ListView)
                SelectedEntity = TableViewSelectedEntity;
        }

        Expression<Func<ReasonNoDelivery, bool>> ISupportFiltering<ReasonNoDelivery>.FilterExpression
        {
            get { return FilterExpression; }
            set { FilterExpression = value; }
        }

    }
}
