using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using NextApi.Models.Models;
using NextBO.Wpf.Common;
using NextBO.DataModel;
using DevExpress.Mvvm.DataModel;
using DevExpress.Mvvm.ViewModel;
using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Windows.Data;
using System.Globalization;
using System.Windows.Markup;
using System.Linq;
using static Next.Utils.Enums.Enums;

namespace NextBO.Wpf.ViewModels
{
    public class SelectedItemsConverter : MarkupExtension, IValueConverter
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }

        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
                return new List<object>((IEnumerable<string>)value);
            return null;
        }
        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ObservableCollection<string> result = new ObservableCollection<string>();
            var enumerable = (List<object>)value;
            if (enumerable != null)
                foreach (object item in enumerable)
                    result.Add((string)item);
            return result;
        }
    }


    public class CheckListVehicleCollectionViewModel : CollectionViewModel<ConfigCheckListVehicle, int, INextBOUnitOfWork>
    {
        public static CheckListVehicleCollectionViewModel Create(IUnitOfWorkFactory<INextBOUnitOfWork> unitOfWorkFactory = null, UnitOfWorkPolicy unitOfWorkPolicy = UnitOfWorkPolicy.Individual)
        {
            return ViewModelSource.Create(() => new CheckListVehicleCollectionViewModel(unitOfWorkFactory, unitOfWorkPolicy));
        }
        protected CheckListVehicleCollectionViewModel(IUnitOfWorkFactory<INextBOUnitOfWork> unitOfWorkFactory = null, UnitOfWorkPolicy unitOfWorkPolicy = UnitOfWorkPolicy.Individual)
           : base(unitOfWorkFactory ?? UnitOfWorkSource.GetUnitOfWorkFactory(), x => x.ConfigCheckListVehicles, unitOfWorkPolicy: unitOfWorkPolicy)
        {
        }
        protected IUserSessionService UserSessionService { get { return this.GetRequiredService<IUserSessionService>(); } }

        ViewSettingsViewModel viewSettings;
        public virtual ConfigCheckListVehicle TableViewSelectedEntity { get; set; }
        public virtual ConfigCheckListVehicle ConfigRouteEntity { get; set; }
        public virtual ConfigCheckListVehicle CurrentConfig { get; set; }
        private ObservableCollection<string> _selectedDaysStart;
        private ObservableCollection<string> _selectedDaysEnd;

        public ObservableCollection<string> SelectedDaysStart
        {
            get { return _selectedDaysStart; }
            set
            {
                _selectedDaysStart = value;
                this.RaisePropertiesChanged();
            }
        }

        public ObservableCollection<string> SelectedDaysEnd
        {
            get { return _selectedDaysEnd; }
            set
            {
                _selectedDaysEnd = value;
                this.RaisePropertiesChanged();
            }
        }

        public ViewSettingsViewModel ViewSettings
        {
            get
            {
                if (viewSettings == null)
                    viewSettings = ViewSettingsViewModel.Create(CollectionViewKind.ListView, this);
                return viewSettings;
            }
        }

        public virtual void OnTableViewSelectedEntityChanged()
        {
            if (viewSettings.ViewKind == CollectionViewKind.ListView)
                SelectedEntity = TableViewSelectedEntity;
        }

        public void UpdateConfigCheckList()
        {
            try
            {
                var daysStart = string.Empty;
                foreach (var item in SelectedDaysStart)
                {
                    daysStart += daysStart == string.Empty ? item : "," + item;
                }
                var daysEnd = string.Empty;
                foreach (var item in SelectedDaysEnd)
                {
                    daysEnd += daysEnd == string.Empty ? item : "," + item;
                }
                Entities[0].UpdateBy = UserSessionService.LoggedUser.UserLogin;
                Entities[0].UpdateDate = DateTime.Now;
                Entities[0].Days = daysStart;
                Entities[1].UpdateBy = UserSessionService.LoggedUser.UserLogin;
                Entities[1].UpdateDate = DateTime.Now;
                Entities[1].Days = daysEnd;
                base.Save(Entities[0]);
                base.Save(Entities[1]);

                this.Refresh();
            }
            catch (Exception ex)
            {
                MessageBoxService.ShowMessage(GetStringValue(Next.Enums.Enums.MessageError.DataError) + ex.Message, ex.Message,
                    MessageButton.OK, MessageIcon.Error);
            }
        }

        protected override void OnEntitiesAssigned(Func<ConfigCheckListVehicle> getSelectedEntityCallback)
        {
            try
            {
                base.OnEntitiesAssigned(getSelectedEntityCallback);
                if (Entities.Any())
                {
                    var x = new ObservableCollection<string>();
                    foreach (var item in Entities[0].Days.Split(','))
                    {
                        x.Add(item);
                    }
                    SelectedDaysStart = x;

                    x = new ObservableCollection<string>();
                    foreach (var item in Entities[1].Days.Split(','))
                    {
                        x.Add(item);
                    }
                    SelectedDaysEnd = x;
                }
                else
                {
                    Entities.Add(new ConfigCheckListVehicle
                    {
                        Periodicity = "NINGUNO",
                        Days = string.Empty,
                        CreatedUser = UserSessionService.LoggedUser.UserLogin,
                        Type = "INICIO_RUTA",
                        CreateDate = DateTime.Now
                    });
                    Entities.Add(new ConfigCheckListVehicle
                    {
                        Periodicity = "NINGUNO",
                        Days = string.Empty,
                        CreatedUser = UserSessionService.LoggedUser.UserLogin,
                        Type = "FIN_RUTA",
                        CreateDate = DateTime.Now
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBoxService.ShowMessage(GetStringValue(Next.Enums.Enums.MessageError.DataError) + ex.Message, ex.Message,
                    MessageButton.OK, MessageIcon.Error);
            }
        }

        public void ValidateEntity()
        {
            try
            {
                if (!CurrentConfig.Equals(ConfigRouteEntity))
                {
                    if (MessageBoxService.ShowMessage("Hay cambios pendientes, ¿Desea guardarlos?", "Cambios sin guardar", MessageButton.YesNo) == MessageResult.Yes)
                    {
                        UpdateConfigCheckList();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBoxService.ShowMessage(GetStringValue(Next.Enums.Enums.MessageError.DataError) + ex.Message, ex.Message,
                    MessageButton.OK, MessageIcon.Error);
            }
        }

        public void changeValue()
        {
            if (Entities[0] == null)
                return;
        }

    }
}
