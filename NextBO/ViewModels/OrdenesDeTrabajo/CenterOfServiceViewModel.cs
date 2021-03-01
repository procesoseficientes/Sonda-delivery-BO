using DevExpress.Mvvm.DataModel;
using DevExpress.Mvvm.POCO;
using NextApi.Models.Models;
using NextBO.DataModel;
using NextBO.Wpf.Common;

namespace NextBO.Wpf.ViewModels
{
    public class CenterOfServiceViewModel: SingleObjectViewModel<CenterOfService, int, INextBOUnitOfWork>
    {

        public static CenterOfServiceViewModel Create(IUnitOfWorkFactory<INextBOUnitOfWork> unitOfWorkFactory = null)
        {
            return ViewModelSource.Create(() => new CenterOfServiceViewModel(unitOfWorkFactory));
        }

        protected CenterOfServiceViewModel(IUnitOfWorkFactory<INextBOUnitOfWork> unitOfWorkFactory = null)
            : base(unitOfWorkFactory ?? UnitOfWorkSource.GetUnitOfWorkFactory(), x => x.ServiceCenters, x => x.Id)
        {
        }

        public void Activate()
        {
                Entity.IsActive = 1;
        }

        public void Deactive()
        {
                Entity.IsActive = 0;
        }

        public bool CanDeactive()
        {
            return (Entity != null && Entity.IsActive == 1);
        }

        public bool CanActivate()
        {
            return (Entity != null && Entity.IsActive == 0);
        }


    }
}
