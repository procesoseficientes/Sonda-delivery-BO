using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;

namespace NextBO.Wpf.ViewModels
{

    public class DashboardViewModel : ViewModelBase
    {

        /// <summary>
        /// Creates a new instance of BaseViewModel as a POCO view model.
        /// </summary>
        public static DashboardViewModel Create()
        {

            return ViewModelSource.Create(() => new DashboardViewModel());
        }


        public DashboardViewModel()
        {
            Messenger.Default.Register<string>(this, OnMessage);
        }

        private void OnMessage(string message)
        {
            if (message == "Logged!")
            {
                LoggedUser = this.GetService<IUserSessionService>(searchMode: ServiceSearchMode.PreferParents).LoggedUser;
                this.RaisePropertiesChanged();
            }
        }

        public LoginViewModel LoggedUser { get; set; }


    }


}



