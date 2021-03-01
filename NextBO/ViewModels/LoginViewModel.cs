using System;
using DevExpress.Mvvm.POCO;

namespace NextBO.Wpf.ViewModels
{

    public class LoginViewModel
    {
        public static LoginViewModel Create(object parentViewModel)
        {
            return ViewModelSource.Create(() => new LoginViewModel()).SetParentViewModel(parentViewModel);
        }


        public virtual string UserLogin { get; set; }
        public virtual string Password { get; set; }

        public int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual string Phone { get; set; }

        public virtual string Email { get; set; }

        public virtual string Image { get; set; }

        public virtual int RoleId { get; set; }

        public virtual short IsActive { get; set; }

        public virtual DateTime LoginTime { get; set; }
        public virtual string RoleName { get; set; }
        public virtual int IdRol { get; set; }

        public virtual string AppVersion { get; set; }
        public virtual string AutenticationMessage { get; set; }

        public virtual string CompanyImage { get; set; }


    }
}