using DevExpress.Mvvm;
using DevExpress.Mvvm.DataModel;
using DevExpress.Mvvm.POCO;
using DevExpress.Mvvm.ViewModel;
using NextApi.Models.Models;
using NextApi.Models.Resources.Responses;
using NextBO.DataModel;
using NextBO.Wpf.Common;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using static Next.Utils.Enums.Enums;

namespace NextBO.Wpf.ViewModels
{
    public class CheckpointViewModel : ReadOnlyCollectionViewModel<CheckpointByRole, INextBOUnitOfWork>
    {

        /// <summary>
        /// Creates a new instance of CheckpointViewModel as a POCO view model.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        public static CheckpointViewModel Create(object parentViewModel, IUnitOfWorkFactory<INextBOUnitOfWork> unitOfWorkFactory = null, UnitOfWorkPolicy unitOfWorkPolicy = UnitOfWorkPolicy.Individual)
        {
            return ViewModelSource.Create(() => new CheckpointViewModel(unitOfWorkFactory, unitOfWorkPolicy)).SetParentViewModel(parentViewModel);
        }

        /// <summary>
        /// Initializes a new instance of the CheckpointViewModel class.
        /// This constructor is declared protected to avoid undesired instantiation of the CheckpointViewModel type without the POCO proxy factory.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        protected CheckpointViewModel(IUnitOfWorkFactory<INextBOUnitOfWork> unitOfWorkFactory = null, UnitOfWorkPolicy unitOfWorkPolicy = UnitOfWorkPolicy.Individual)
            : base(unitOfWorkFactory ?? UnitOfWorkSource.GetUnitOfWorkFactory(), null, unitOfWorkPolicy: unitOfWorkPolicy)
        {
        }

        protected IMessageBoxService MessageBoxService { get { return this.GetRequiredService<IMessageBoxService>(); } }
        public virtual ObservableCollection<CheckPointByRoleResource> CheckPointAssignedToRole { get; set; }


        public void AssociateAll(CheckPointByRoleResource checkByRoleResource)
        {
            try
            {
                var parent = (RoleCollectionViewModel)this.GetParentViewModel<CheckpointViewModel>().ParentViewModel;
                var checkPoints = new CheckpointByRole
                {
                    RoleId = checkByRoleResource.IdRole,
                    CheckpointId = checkByRoleResource.Id,
                    Id = checkByRoleResource.CheckpointByRoleId
                };
                foreach (var item in parent.Entities.Where(y => y.Id == checkByRoleResource.IdRole))
                {
                    var listChecks = item.CheckpointByRole.ToList();
                    if (!listChecks.Where(y => y.RoleId == checkByRoleResource.IdRole && y.CheckpointId == checkByRoleResource.Id).Any())
                    {
                        listChecks.Add(checkPoints);
                        item.CheckpointByRole = listChecks;
                    }
                }
                parent.Save(parent.SelectedEntity);
                parent.SendRefreshCollectionsMessage();
            }
            catch (Exception ex)
            {
                MessageBoxService.ShowMessage(GetStringValue(Next.Enums.Enums.MessageError.SaveError) + ex.Message, ex.Message,
                    MessageButton.OK, MessageIcon.Error);
            }
        }

        public void DissociateAll(CheckPointByRoleResource checkByRoleResource)
        {
            try
            {
                var parent = (RoleCollectionViewModel)this.GetParentViewModel<CheckpointViewModel>().ParentViewModel;
                var checkPoints = new CheckpointByRole
                {
                    RoleId = checkByRoleResource.IdRole,
                    CheckpointId = checkByRoleResource.Id,
                    Id = checkByRoleResource.CheckpointByRoleId
                };
                foreach (var item in parent.Entities.Where(y => y.Id == checkByRoleResource.IdRole))
                {
                    var listChecks = item.CheckpointByRole.ToList();
                    listChecks.RemoveAll(y => y.RoleId == checkByRoleResource.IdRole && y.CheckpointId == checkByRoleResource.Id);
                    item.CheckpointByRole = listChecks;
                }
                parent.Save(parent.SelectedEntity);
                parent.SendRefreshCollectionsMessage();
            }
            catch (Exception ex)
            {
                MessageBoxService.ShowMessage(GetStringValue(Next.Enums.Enums.MessageError.SaveError) + ex.Message, ex.Message,
                    MessageButton.OK, MessageIcon.Error);
            }
        }

        public void IsSelected(DevExpress.Xpf.Grid.TreeList.TreeListNodeEventArgs e)
        {
            try
            {
                var CheckByRoleResource = (CheckPointByRoleResource)e.Row;

                var parent = (RoleCollectionViewModel)this.GetParentViewModel<CheckpointViewModel>().ParentViewModel;
                var checkPoints = new CheckpointByRole
                {
                    RoleId = CheckByRoleResource.IdRole,
                    CheckpointId = CheckByRoleResource.Id,
                    Id = CheckByRoleResource.CheckpointByRoleId
                };
                if (CheckByRoleResource.Selected == null || CheckByRoleResource.Selected == true)
                {
                    foreach (var item in parent.Entities.Where(y => y.Id == CheckByRoleResource.IdRole))
                    {
                        var listChecks = item.CheckpointByRole.ToList();
                        if (!listChecks.Where(y => y.RoleId == CheckByRoleResource.IdRole && y.CheckpointId == CheckByRoleResource.Id).Any())
                        {
                            listChecks.Add(checkPoints);
                            item.CheckpointByRole = listChecks;
                        }
                    }
                    parent.Save(parent.SelectedEntity);
                }
                else
                {
                    foreach (var item in parent.Entities.Where(y => y.Id == CheckByRoleResource.IdRole))
                    {
                        var listChecks = item.CheckpointByRole.ToList();
                        listChecks.RemoveAll(y => y.RoleId == CheckByRoleResource.IdRole && y.CheckpointId == CheckByRoleResource.Id);
                        item.CheckpointByRole = listChecks;
                    }
                    parent.Save(parent.SelectedEntity);
                }
                parent.SendRefreshCollectionsMessage();
            }
            catch (Exception ex)
            {
                MessageBoxService.ShowMessage(GetStringValue(Next.Enums.Enums.MessageError.SaveError) + ex.Message, ex.Message,
                    MessageButton.OK, MessageIcon.Error);
            }
        }

    }
}
