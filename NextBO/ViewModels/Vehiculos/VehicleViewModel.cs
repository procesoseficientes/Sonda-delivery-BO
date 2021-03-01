using System;
using DevExpress.Mvvm;
using NextBO.Wpf.Common;
using NextBO.DataModel;
using NextApi.Models.Models;
using DevExpress.Mvvm.DataModel;
using DevExpress.Mvvm.ViewModel;
using DevExpress.Mvvm.POCO;
using System.Linq;
using DevExpress.Mvvm.DataAnnotations;
using static Next.Utils.Enums.Enums;
using System.Collections.Generic;

namespace NextBO.Wpf.ViewModels
{
    [POCOViewModel(ImplementIDataErrorInfo = true)]

    public class VehicleViewModel : SingleObjectViewModel<Vehicle, int, INextBOUnitOfWork>
    {

        /// <summary>
        /// Creates a new instance of VehicleViewModel as a POCO view model.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        public static VehicleViewModel Create(IUnitOfWorkFactory<INextBOUnitOfWork> unitOfWorkFactory = null)
        {
            return ViewModelSource.Create(() => new VehicleViewModel(unitOfWorkFactory));
        }

        /// <summary>
        /// Initializes a new instance of the VehicleViewModel class.
        /// This constructor is declared protected to avoid undesired instantiation of the VehicleViewModel type without the POCO proxy factory.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        protected VehicleViewModel(IUnitOfWorkFactory<INextBOUnitOfWork> unitOfWorkFactory = null)
            : base(unitOfWorkFactory ?? UnitOfWorkSource.GetUnitOfWorkFactory(), x => x.Vehicles, x => x.PlateNumber)
        {
        }

        #region Base Methods

        protected override string GetTitle()
        {
            return $"Vehículo Placa: { Entity.PlateNumber }";
        }

        protected override string GetTitleForNewEntity()
        {
            return "Nuevo Vehículo";
        }

        public virtual Boolean IsCustomization { get; set; }
        protected IDocumentManagerService DocumentManagerService { get { return this.GetRequiredService<IDocumentManagerService>(); } }
        protected IUserSessionService UserSessionService { get { return this.GetRequiredService<IUserSessionService>(); } }
        public UICommand SaveLayoutCommand { get; set; }
        public UICommand RestoreLayoutCommand { get; set; }
        public List<Parameter> LookUpVehicleClassification { get; set; }
        /// <summary>
        /// The view model that contains a look-up collection of role for the corresponding navigation property in the view.
        /// </summary>
        public IEntitiesViewModel<Pilot> LookUpPilot
        {
            get
            {
                return GetLookUpEntitiesViewModel<VehicleViewModel, Pilot, int>(
                    propertyExpression: (VehicleViewModel x) => x.LookUpPilot,
                    getRepositoryFunc: x => x.Pilots);
            }
        }

        protected override void OnEntityChanged()
        {
            base.OnEntityChanged();
            if (Entity != null)
                Logger.Log(string.Format("Next: Edit Vehicle: {0}",
                    string.IsNullOrEmpty(Entity.PlateNumber) ? "<New>" : Entity.PlateNumber));
        }

        protected override bool TryClose()
        {
            var closed = base.TryClose();
            if (closed)
                DocumentManagerService.Documents.First(x => x.Content == this).DestroyOnClose = true;
            return closed;
        }



        protected override bool SaveCore()
        {
            if (!IsNew())
            {
                Entity.UserIdUpdated = UserSessionService.LoggedUser.UserLogin;
                Entity.LastUpdate = DateTime.Now;
            }
            else
            {
                Entity.PlateNumber = Entity.PlateNumber != null ? Entity.PlateNumber
                    : string.Format("{0}", Entity.PlateNumber);
                Entity.IsActive = 1;
                Entity.UserIdCreated = UserSessionService.LoggedUser.Id;
                Entity.CreatedDate = DateTime.Now;
            }
            return base.SaveCore();
        }

        public override void Delete()
        {
            Entity.IsActive = 0;
            ((IPOCOViewModel)this).RaisePropertyChanged("IsActive");
            Entity.UserIdUpdated = UserSessionService.LoggedUser.Id.ToString();
            Entity.LastUpdate = DateTime.Now;
            base.SaveCore();
        }

        public override bool CanDelete()
        {
            return Entity.IsActive == 1;
        }

        #endregion

        public void changeValueIsCustomization()
        {
            IsCustomization = !IsCustomization;

        }

        public void Activate()
        {
            Entity.IsActive = 1;
            ((IPOCOViewModel)this).RaisePropertyChanged("IsActive");
            Entity.UserIdUpdated = UserSessionService.LoggedUser.Id.ToString();
            Entity.LastUpdate = DateTime.Now;
            base.SaveCore();
        }

        public bool CanActivate()
        {
            return Entity.IsActive == 0;
        }

        public void GetDataLookUp()
        {
            try
            {
                var resultVehicleClassification = UnitOfWork.GetParameterByGroup(new Parameter { 
                    ParameterGroup = GetStringValue(Next.Enums.Enums.ParametersGroup.VehicleClassification)
                });

                LookUpVehicleClassification = resultVehicleClassification;
                
                var y = UnitOfWork.GetParameterByGroup(new Parameter
                {
                    ParameterGroup = GetStringValue(Next.Enums.Enums.ParametersGroup.VehicleLoadType)
                });
            }
            catch (Exception ex)
            {
                MessageBoxService.ShowMessage(GetStringValue(Next.Enums.Enums.MessageError.OperationError) + ex.Message,
                    ex.Message, MessageButton.OK, MessageIcon.Error);
            }
        }

    }
}
