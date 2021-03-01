using System;
using System.Windows.Media;
using NextBO.Wpf.Common.ViewModel;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using DevExpress.Mvvm.ViewModel;
using DevExpress.Xpf.Core;
using NextBO.DataModel;
using Next.Enums;
using static Next.Utils.Enums.Enums;

namespace NextBO.Wpf.ViewModels
{
    /// <summary>
    /// Represents the root POCO view model for the DevAVDb data model.
    /// </summary>
    public partial class BaseViewModel : DocumentsViewModel<ProjectModuleDescription, INextBOUnitOfWork>
    {

        const string TablesGroup = "Tables";
        const string DashboardGroup = "Dashboard";

        /// <summary>
        /// Creates a new instance of BaseViewModel as a POCO view model.
        /// </summary>
        public static BaseViewModel Create()
        {
            return ViewModelSource.Create(() => new BaseViewModel());
        }

        /// <summary>
        /// Initializes a new instance of the BaseViewModel class.
        /// This constructor is declared protected to avoid undesired instantiation of the BaseViewModel type without the POCO proxy factory.
        /// </summary>
        protected BaseViewModel()
            : base(UnitOfWorkSource.GetUnitOfWorkFactory())
        {
            NavigationPaneVisibility = NavigationPaneVisibility.Normal;
        }



        /// <summary>
        /// Module creation, add as many modules as necesary.
        /// </summary>
        /// <returns></returns>
        protected override ProjectModuleDescription[] CreateModules()
        {


            return new ProjectModuleDescription[] {
                new ProjectModuleDescription(GetStringValue(Enums.Modules.Main), "DashboardView", DashboardGroup, FiltersSettings.NoFilterModule(this)),
                new ProjectModuleDescription(GetStringValue(Enums.Modules.Seguridad), "UserCollectionView", TablesGroup, FiltersSettings.GetUserFilterTree(this)),
                new ProjectModuleDescription(GetStringValue(Enums.Modules.Entregas), "DeliveryCollectionView", TablesGroup, FiltersSettings.GetDeliveryFilterTree(this)),
                new ProjectModuleDescription(GetStringValue(Enums.Modules.Vehiculos), "VehicleCollectionView", TablesGroup, FiltersSettings.GetVehicleFilterTree(this)),
                new ProjectModuleDescription(GetStringValue(Enums.Modules.Ordenes), "WorkOrderCollectionView", TablesGroup, FiltersSettings.GetWorkOrderFilterTree(this)),
                new ProjectModuleDescription(GetStringValue(Enums.Modules.Historico), "DeliveryHistoryCollectionView", TablesGroup, FiltersSettings.GetDeliveryHistoryFilterTree(this)),
                new ProjectModuleDescription(GetStringValue(Enums.Modules.Simulador), "RouteSimulatorCollectionView", TablesGroup, FiltersSettings.GetRouteSimulatorFilterTree(this))
                //Continue adding new modules
            };
        }

        readonly Workspace defaultWorkspace = new Workspace();


        /// <summary>
        /// Vista base ha sido cargada
        /// </summary>
        /// <param name="module"></param>
        public override void OnLoaded(ProjectModuleDescription module)
        {
            base.OnLoaded(module);
            var unitOfWork = CreateUnitOfWork();
            UserSessionService.Login(LoggedUser, LoginDialogService, unitOfWork);
            LoggedUser = UserSessionService.LoggedUser;
            Messenger.Default.Send("Logged!");
        }

        LoginViewModel loggedUser;

        /// <summary>
        /// Usuario logueado
        /// </summary>
        public virtual LoginViewModel LoggedUser
        {
            get
            {
                if (loggedUser == null)
                    loggedUser = ViewModelSource.Create(() => new LoginViewModel()); ;
                return loggedUser;
            }
            set { loggedUser = value; }
        }



        protected IUserSessionService UserSessionService { get { return this.GetRequiredService<IUserSessionService>(); } }
        protected IDialogService LoginDialogService { get { return this.GetRequiredService<IDialogService>("LoginDialogService"); } }

        public override void SaveLogicalLayout() { }
        public override bool RestoreLogicalLayout()
        {
            return false;
        }

        protected override void OnActiveModuleChanged(ProjectModuleDescription oldModule)
        {
            base.OnActiveModuleChanged(oldModule);
            if (ActiveModule != null && ActiveModule.FilterTreeViewModel != null)
                ActiveModule.FilterTreeViewModel.SetViewModel(DocumentManagerService.ActiveDocument.Content);
            var title = Convert.ToString(DocumentManagerService.ActiveDocument.Title);
            MainWindowService.Title = title + " - Next";
            Logger.Log(string.Format("OutlookInspiredApp: Select module: {0}", title.ToUpper()));
            FinishModuleChangingDispatcherService.BeginInvoke(() =>
            {
                UpdateWorkspace(oldModule, ActiveModule);
            });
        }


        IDispatcherService FinishModuleChangingDispatcherService { get { return this.GetRequiredService<IDispatcherService>("FinishModuleChangingDispatcherService"); } }

        IWorkspaceService WorkspaceService { get { return this.GetRequiredService<IWorkspaceService>(); } }

        IMainWindowService MainWindowService { get { return this.GetRequiredService<IMainWindowService>(); } }

        INotificationService NotificationService { get { return this.GetRequiredService<INotificationService>(); } }

        void UpdateWorkspace(ProjectModuleDescription oldModule, ProjectModuleDescription newModule)
        {
            Workspace oldWorkspace = WorkspaceService.SaveWorkspace();
            Workspace newWorkspace = new Workspace();
            try
            {
                if (oldModule != null)
                    oldModule.Workspace = oldWorkspace;
                if (newModule != null)
                    newWorkspace = newModule.Workspace ?? defaultWorkspace;
            }
            finally
            {
                WorkspaceService.RestoreWorkspace(newWorkspace);
            }
        }

    }

    public partial class ProjectModuleDescription : ModuleDescription<ProjectModuleDescription>
    {
        public ProjectModuleDescription(string title, string documentType, string group, IFilterTreeViewModel filterTreeViewModel)
            : base(title, documentType, group)
        {
            if(title == "Vehículos")
            {
                string newTitle = "Vehiculos";
                ImageSource = (ImageSource)new SvgImageSourceExtension() { Uri = new Uri(string.Format(@"pack://application:,,,/NextBO.Wpf;component/Resources/Modules/{0}.svg", newTitle)), Size = new System.Windows.Size(24, 24) }
                .ProvideValue(null);
            }
            else if (title == "Histórico")
            {
                string newTitle = "Historico";
                ImageSource = (ImageSource)new SvgImageSourceExtension() { Uri = new Uri(string.Format(@"pack://application:,,,/NextBO.Wpf;component/Resources/Modules/{0}.svg", newTitle)), Size = new System.Windows.Size(24, 24) }
                .ProvideValue(null);
            }
            else
            {
                ImageSource = (ImageSource)new SvgImageSourceExtension() { Uri = new Uri(string.Format(@"pack://application:,,,/NextBO.Wpf;component/Resources/Modules/{0}.svg", title)), Size = new System.Windows.Size(24, 24) }
            .ProvideValue(null);
            }            
            FilterTreeViewModel = filterTreeViewModel;
        }

        public Workspace Workspace { get; set; }

        public ImageSource ImageSource { get; private set; }

        public IFilterTreeViewModel FilterTreeViewModel { get; private set; }


    }
}