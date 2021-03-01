using System;
using DevExpress.Mvvm;
using NextBO.Wpf.Common;
using NextBO.DataModel;
using NextApi.Models.Models;
using DevExpress.Mvvm.DataModel;
using DevExpress.Mvvm.ViewModel;
using DevExpress.Mvvm.POCO;
using System.Linq;
using System.Collections.Generic;
using NextBO.Wpf.Services;
using System.Diagnostics;
using NextApi.Models.Resources.Responses;
using System.Collections.ObjectModel;
using static Next.Utils.Enums.Enums;
using DevExpress.Xpf.Grid;

namespace NextBO.Wpf.ViewModels
{
    public class RoleCollectionViewModel : CollectionViewModel<Role, int, INextBOUnitOfWork>
    {

        /// <summary>
        /// Creates a new instance of RoleCollectionViewModel as a POCO view model.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        public static RoleCollectionViewModel Create(IUnitOfWorkFactory<INextBOUnitOfWork> unitOfWorkFactory = null, UnitOfWorkPolicy unitOfWorkPolicy = UnitOfWorkPolicy.Individual)
        {
            return ViewModelSource.Create(() => new RoleCollectionViewModel(unitOfWorkFactory, unitOfWorkPolicy));
        }

        /// <summary>
        /// Initializes a new instance of the EmployeeCollectionViewModel class.
        /// This constructor is declared protected to avoid undesired instantiation of the RoleCollectionViewModel type without the POCO proxy factory.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        protected RoleCollectionViewModel(IUnitOfWorkFactory<INextBOUnitOfWork> unitOfWorkFactory = null, UnitOfWorkPolicy unitOfWorkPolicy = UnitOfWorkPolicy.Individual)
            : base(unitOfWorkFactory ?? UnitOfWorkSource.GetUnitOfWorkFactory(), x => x.Roles, unitOfWorkPolicy: unitOfWorkPolicy)
        {
            Checks = CreateUnitOfWork().Checkpoint.ToList();
        }

        protected virtual ISaveFileDialogService SaveFileDialogService { get { return null; } }
        protected virtual IExportGridService ExportGridService { get { return null; } }
        protected IUserSessionService UserSessionService { get { return this.GetRequiredService<IUserSessionService>(); } }
        public virtual Role TableViewSelectedEntity { get; set; }

        CheckpointViewModel checkpointsPanelViewModel;
        List<Checkpoint> Checks;
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

        public CheckpointViewModel SelectedRoleCheckpointViewModel
        {
            get
            {
                if (checkpointsPanelViewModel == null)
                    checkpointsPanelViewModel = CheckpointViewModel.Create(this);
                return checkpointsPanelViewModel;
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
                var entity = (Role)e.Row;
                if (entity.Name != null)
                {
                    entity.LastUpdatedBy = UserSessionService.LoggedUser.UserLogin;
                    entity.LastUpdated = DateTime.Now;
                    if (entity.Id == new int())
                    {
                        entity.CreatedBy = UserSessionService.LoggedUser.UserLogin;
                        entity.CreatedOn = DateTime.Now;
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
                MessageBoxService.ShowMessage(GetStringValue(Next.Enums.Enums.MessageError.ExportError), ex.Message,
                    MessageButton.OK, MessageIcon.Error);
            }
        }

        /// <summary>
        /// Inactivate user
        /// </summary>
        /// <param name="projectionEntity"></param>
        public override void Delete(Role projectionEntity)
        {
            var entity = this.Entities.Where(x => x.Id == projectionEntity.Id).FirstOrDefault();
            base.Delete(entity);
        }

        public override bool CanDelete(Role projectionEntity)
        {
            return (projectionEntity != null);
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
            LoadCheckpointsByroles();
        }

        protected void LoadCheckpointsByroles()
        {
            try
            {
                if (SelectedEntity == null)
                {
                    return;
                }
                else
                {
                    if (SelectedEntity.CheckpointByRole != null)
                    {
                        var list = new ObservableCollection<CheckPointByRoleResource>();
                        foreach (var item in Checks)
                        {
                            var existingCheckByRole = SelectedEntity.CheckpointByRole.Where(x => x.CheckpointId == item.Id).FirstOrDefault();
                            var resource = new CheckPointByRoleResource
                            {
                                DisplayName = item.DisplayName,
                                Group = item.Group,
                                Type = item.Type,
                                Id = item.Id,
                                ParentId = item.ParentId,
                                IdRole = SelectedEntity.Id,
                                Selected = existingCheckByRole != null,
                                CheckpointByRoleId = existingCheckByRole != null ? existingCheckByRole.Id : new int()
                            };
                            list.Add(resource);
                        }
                        SelectedRoleCheckpointViewModel.CheckPointAssignedToRole = list;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBoxService.ShowMessage(GetStringValue(Next.Enums.Enums.MessageError.DataError) + ex.Message, ex.Message,
                    MessageButton.OK, MessageIcon.Error);
            }
        }

        public void AssociateAll()
        {
            try
            {
                if (SelectedEntity == null)
                    return;
                var list = new ObservableCollection<CheckPointByRoleResource>();

                if (SelectedEntity.CheckpointByRole == null)
                {
                    SelectedEntity.CheckpointByRole = new ObservableCollection<CheckpointByRole>();
                }

                foreach (var item in Checks)
                {
                    var existingCheckByRole = SelectedEntity.CheckpointByRole.Where(x => x.CheckpointId == item.Id).FirstOrDefault();
                    var resource = new CheckPointByRoleResource
                    {
                        DisplayName = item.DisplayName,
                        Group = item.Group,
                        Type = item.Type,
                        Id = item.Id,
                        ParentId = item.ParentId,
                        IdRole = SelectedEntity.Id,
                        Selected = true,
                        CheckpointByRoleId = existingCheckByRole != null ? existingCheckByRole.Id : new int()
                    };
                    list.Add(resource);
                    SelectedRoleCheckpointViewModel.AssociateAll(resource);
                }
                SelectedRoleCheckpointViewModel.CheckPointAssignedToRole = list;
            }
            catch (Exception ex)
            {
                MessageBoxService.ShowMessage(GetStringValue(Next.Enums.Enums.MessageError.DataError) + ex.Message, ex.Message,
                    MessageButton.OK, MessageIcon.Error);
            }
        }

        public void DissociateAll()
        {
            try
            {
                if (SelectedEntity == null)
                    return;
                var list = new ObservableCollection<CheckPointByRoleResource>();

                if (SelectedEntity.CheckpointByRole == null)
                {
                    SelectedEntity.CheckpointByRole = new ObservableCollection<CheckpointByRole>();
                }

                foreach (var item in Checks)
                {
                    if (SelectedEntity.CheckpointByRole == null)
                    {
                        break;
                    }
                    var existingCheckByRole = SelectedEntity.CheckpointByRole.Where(x => x.CheckpointId == item.Id).FirstOrDefault();
                    var resource = new CheckPointByRoleResource
                    {
                        DisplayName = item.DisplayName,
                        Group = item.Group,
                        Type = item.Type,
                        Id = item.Id,
                        ParentId = item.ParentId,
                        IdRole = SelectedEntity.Id,
                        Selected = false,
                        CheckpointByRoleId = existingCheckByRole != null ? existingCheckByRole.Id : new int()
                    };
                    list.Add(resource);
                    SelectedRoleCheckpointViewModel.DissociateAll(resource);
                }
            }
            catch (Exception ex)
            {
                MessageBoxService.ShowMessage(GetStringValue(Next.Enums.Enums.MessageError.DataError) + ex.Message, ex.Message,
                    MessageButton.OK, MessageIcon.Error);
            }
        }

        protected override void OnEntitiesAssigned(Func<Role> getSelectedEntityCallback)
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