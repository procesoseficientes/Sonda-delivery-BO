using DevExpress.Mvvm;
using DevExpress.Mvvm.DataModel;
using DevExpress.Mvvm.POCO;
using DevExpress.Xpf.Grid;
using NextApi.Models.Models;
using NextBO.DataModel;
using NextBO.Wpf.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using static Next.Utils.Enums.Enums;

namespace NextBO.Wpf.ViewModels
{
    public class ServiceViewModel : SingleObjectViewModel<Service, long, INextBOUnitOfWork>
    {

        public static ServiceViewModel Create(IUnitOfWorkFactory<INextBOUnitOfWork> unitOfWorkFactory = null)
        {
            return ViewModelSource.Create(() => new ServiceViewModel(unitOfWorkFactory));
        }

        protected ServiceViewModel(IUnitOfWorkFactory<INextBOUnitOfWork> unitOfWorkFactory = null)
            : base(unitOfWorkFactory ?? UnitOfWorkSource.GetUnitOfWorkFactory(), x => x.Services, x => x.Id)
        {
            LookUpWorkItems = UnitOfWork.WorkItems.ToList();
        }

        public virtual List<WorkItem> LookUpWorkItems { get; set; }
        public virtual ObservableCollection<DetailService> DetailServices { get; set; }
        public virtual DetailService DetailService { get; set; }
        public virtual WorkItem WorkItem { get; set; }

        public void ItemUpdated(GridRowValidationEventArgs e)
        {
            try
            {
                DetailService = (DetailService)e.Row;
                if (DetailService != null)
                {
                    DetailService.ServiceId = Entity.Id;
                    DetailService.Service = Entity;
                    DetailServices.ToList().Add(DetailService);

                    Entity.TotalCost = 0;
                    DetailServices.ToList().ForEach(item =>
                    {
                        Entity.TotalCost += item.TotalCost;
                    });
                    Entity.DetailServices = DetailServices;
                    e.IsValid = true;
                    return;
                }
                e.ErrorContent = GetStringValue(Next.Enums.Enums.MessageError.RequiredError);
                e.IsValid = false;
                return;
            }
            catch (Exception ex)
            {
                MessageBoxService.ShowMessage(GetStringValue(Next.Enums.Enums.MessageError.SaveError) + ex.Message, ex.Message,
                    MessageButton.OK, MessageIcon.Error);
            }
        }

        public void SetWorkItem(GridCellValidationEventArgs e)
        {
            try
            {
                var detail = (DetailService)e.Row;
                detail.WorkItem = WorkItem;
                detail.UnitCost = WorkItem.EstimatedCost;
            }
            catch (Exception ex)
            {
                MessageBoxService.ShowMessage(GetStringValue(Next.Enums.Enums.MessageError.DataError) + ex.Message, ex.Message,
                    MessageButton.OK, MessageIcon.Error);
            }
        }

        public override void OnLoaded()
        {
            try
            {
                DetailServices = new ObservableCollection<DetailService>();
                if (Entity.DetailServices != null)
                {
                    Entity.DetailServices.ToList().ForEach(item => { DetailServices.Add(item); });
                }
                else
                {
                    Entity.DetailServices = new ObservableCollection<DetailService>();
                }
                base.OnLoaded();
            }
            catch (Exception ex)
            {
                MessageBoxService.ShowMessage(GetStringValue(Next.Enums.Enums.MessageError.DataError) + ex.Message, ex.Message,
                    MessageButton.OK, MessageIcon.Error);
            }
        }

    }
}
