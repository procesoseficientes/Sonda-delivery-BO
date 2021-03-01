using System;
using System.Linq;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataModel;
using DevExpress.Mvvm.POCO;
using DevExpress.Mvvm.ViewModel;
using static Next.Utils.Enums.Enums;
using NextApi.Models.Models;
using NextBO.DataModel;
using NextBO.Wpf.Common;
using NextBO.Wpf.Common.ViewModel;


namespace NextBO.Wpf.ViewModels
{
    public class UserViewModel : SingleObjectViewModel<User, int, INextBOUnitOfWork>
    {


        /// <summary>
        /// Creates a new instance of UserViewModel as a POCO view model.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        public static UserViewModel Create(IUnitOfWorkFactory<INextBOUnitOfWork> unitOfWorkFactory = null)
        {
            return ViewModelSource.Create(() => new UserViewModel(unitOfWorkFactory));
        }

        /// <summary>
        /// Initializes a new instance of the UserViewModel class.
        /// This constructor is declared protected to avoid undesired instantiation of the UserViewModel type without the POCO proxy factory.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        protected UserViewModel(IUnitOfWorkFactory<INextBOUnitOfWork> unitOfWorkFactory = null)
            : base(unitOfWorkFactory ?? UnitOfWorkSource.GetUnitOfWorkFactory(), x => x.Users, x => x.Name)
        {
        }

        public virtual bool HasPilot { get; set; }
        public virtual Pilot Pilot { get; set; }
        IReportService PrintService { get { return this.GetRequiredService<IReportService>("PrintService"); } }
        IReportService ExportService { get { return this.GetRequiredService<IReportService>("ExportService"); } }
        protected IDocumentManagerService DocumentManagerService { get { return this.GetRequiredService<IDocumentManagerService>(); } }
        protected IUserSessionService UserSessionService { get { return this.GetRequiredService<IUserSessionService>(); } }

        /// <summary>
        /// The view model that contains a look-up collection of Role for the corresponding navigation property in the view.
        /// </summary>
        public IEntitiesViewModel<Role> LookUpRole
        {
            get
            {
                return GetLookUpEntitiesViewModel<UserViewModel, Role, int>(
                    propertyExpression: (UserViewModel x) => x.LookUpRole,
                    getRepositoryFunc: x => x.Roles);
            }
        }

        protected override void OnEntityChanged()
        {
            base.OnEntityChanged();
            if (Entity != null)
            {
                Logger.Log(string.Format("Next: Edit User: {0}",
                    string.IsNullOrEmpty(Entity.Name) ? "<New>" : Entity.Name));
                HasPilot = Entity.Pilot != null;
                Entity.Pilot = Entity.Pilot == null ? null : Pilot = Entity.Pilot;
            }

        }

        protected override bool TryClose()
        {
            var closed = base.TryClose();
            try
            {
                if (closed)
                {
                    DocumentManagerService.Documents.First(x => x.Content == this).DestroyOnClose = true;
                }
            }
            catch (Exception ex)
            {
                MessageBoxService.ShowMessage(GetStringValue(Next.Enums.Enums.MessageError.DataError) + ex.Message, ex.Message,
                    MessageButton.OK, MessageIcon.Error);
            }
            return closed;
        }

        protected override string GetTitle()
        {
            return Entity.Name;
        }

        public void PrintProfileUser()
        {
            try
            {
                Entity.ImageOb = Entity.Image == null ? null : Convert.FromBase64String(Entity.Image);
                DocumentManagerService.CreateDocument(GetStringValue(Next.Enums.Enums.Views.Reporter), 
                    ReporterViewModel.Create(Entity, GetStringValue(Next.Enums.Enums.Report.Usuarios),
                    "Datos completos del usuario " + Entity.Id + " " + Entity.Name, UnitOfWork), null, this).Show();
            }
            catch (Exception ex)
            {
                MessageBoxService.ShowMessage(GetStringValue(Next.Enums.Enums.MessageError.ReportError) + ex.Message, ex.Message,
                    MessageButton.OK, MessageIcon.Error);
            }
        }

        protected override bool SaveCore()
        {
            try
            {
                if (IsNew() && string.IsNullOrEmpty(Entity.Name))
                    Entity.Name = string.Format("{0}", Entity.Name);

                if (!IsNew())
                {
                    Entity.ModifiedBy = UserSessionService.LoggedUser.UserLogin;
                    Entity.ModifiedDate = DateTime.Now;
                }
                else
                {
                    Entity.IsActive = 1;
                    Entity.CreatedBy = UserSessionService.LoggedUser.UserLogin;
                    Entity.CreationDate = DateTime.Now;
                }
                return base.SaveCore();
            }
            catch (Exception ex)
            {
                MessageBoxService.ShowMessage(GetStringValue(Next.Enums.Enums.MessageError.DataError) + ex.Message, ex.Message,
                    MessageButton.OK, MessageIcon.Error);
                return false;
            }
        }

        public override void Delete()
        {
            Entity.IsActive = 0;
            ((IPOCOViewModel)this).RaisePropertyChanged("IsActive");
            Entity.ModifiedBy = UserSessionService.LoggedUser.UserLogin;
            Entity.ModifiedDate = DateTime.Now;
            base.SaveCore();
        }

        public void Activate()
        {
            Entity.IsActive = 1;
            ((IPOCOViewModel)this).RaisePropertyChanged("IsActive");
            Entity.ModifiedBy = UserSessionService.LoggedUser.UserLogin;
            Entity.ModifiedDate = DateTime.Now;
            base.SaveCore();
        }

        public override bool CanDelete()
        {
            return Entity.IsActive == 1;
        }

        public bool CanActivate()
        {
            return Entity.IsActive == 0;
        }
        public bool CanAddPilot()
        {
            return Entity.Pilot == null;
        }

        public void AddPilot()
        {
            try
            {
                Pilot = new Pilot
                {
                    User = Entity,
                    LicenseExpirationDate = DateTime.Now.Date
                };
                Entity.Pilot = Pilot;
                HasPilot = true;
            }
            catch (Exception ex)
            {
                MessageBoxService.ShowMessage(GetStringValue(Next.Enums.Enums.MessageError.SaveError) + ex.Message, ex.Message,
                    MessageButton.OK, MessageIcon.Error);
            }
        }

        void ShowReport(IReportInfo reportInfo, string reportId)
        {
            ExportService.ShowReport(reportInfo);
            PrintService.ShowReport(reportInfo);
            Logger.Log(string.Format("OutlookInspiredApp: Create Report : Employee: {0}", reportId));
        }

        void SetDefaultReport(IReportInfo reportInfo)
        {
            if (this.IsInDesignMode()) return;
            ExportService.SetDefaultReport(reportInfo);
            PrintService.SetDefaultReport(reportInfo);
        }

    }
}