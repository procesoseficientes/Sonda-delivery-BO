namespace NextBO.Wpf.Properties
{


    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.1.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase
    {

        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));

        public static Settings Default
        {
            get
            {
                return defaultInstance;
            }
        }


        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string LastLoggedUser
        {
            get
            {
                return ((string)(this["LastLoggedUser"]));
            }
            set
            {
                this["LastLoggedUser"] = value;
            }
        }

        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string CompanyImage
        {
            get
            {
                return ((string)(this["CompanyImage"]));
            }
            set
            {
                this["CompanyImage"] = value;
            }
        }

        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string UserTheme
        {
            get
            {
                return ((string)(this["UserTheme"]));
            }
            set
            {
                this["UserTheme"] = value;
            }
        }


        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"<?xml version=""1.0"" encoding=""utf-16""?>
<ArrayOfFilterInfo xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <FilterInfo>
    <Name>Todos</Name>
  </FilterInfo>

  <FilterInfo>
    <Name>Activos</Name>
    <FilterCriteria>[IsActive] == 1</FilterCriteria>
  </FilterInfo>
  <FilterInfo>
    <Name>Inactivos</Name>
    <FilterCriteria>[IsActive] == 0</FilterCriteria>
  </FilterInfo>

  
</ArrayOfFilterInfo>")]
        public global::NextBO.Wpf.ViewModels.FilterInfoList UserStaticFilters
        {
            get
            {
                return ((global::NextBO.Wpf.ViewModels.FilterInfoList)(this["UserStaticFilters"]));
            }
            set
            {
                this["UserStaticFilters"] = value;
            }
        }

        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"<?xml version=""1.0"" encoding=""utf-16""?>
<ArrayOfFilterInfo xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
 
  
</ArrayOfFilterInfo>")]
        public global::NextBO.Wpf.ViewModels.FilterInfoList UserCustomFilters
        {
            get
            {
                return ((global::NextBO.Wpf.ViewModels.FilterInfoList)(this["UserCustomFilters"]));
            }
            set
            {
                this["UserCustomFilters"] = value;
            }
        }

        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"<?xml version=""1.0"" encoding=""utf-16""?>
<ArrayOfFilterInfo xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <FilterInfo>
    <Name>All</Name>
  </FilterInfo>
  <FilterInfo>
    <Name>Stores &gt; 10 Locations</Name>
    <FilterCriteria>[TotalStores] &gt; 10</FilterCriteria>
  </FilterInfo>
  <FilterInfo>
    <Name>Revenues &gt; 100 Billion</Name>
    <FilterCriteria>[AnnualRevenue] &gt; 100000000000.0m</FilterCriteria>
  </FilterInfo>
  <FilterInfo>
    <Name>Employees &gt; 10000</Name>
    <FilterCriteria>[TotalEmployees] &gt; 10000</FilterCriteria>
  </FilterInfo>
</ArrayOfFilterInfo>")]
        public global::NextBO.Wpf.ViewModels.FilterInfoList CustomersStaticFilters
        {
            get
            {
                return ((global::NextBO.Wpf.ViewModels.FilterInfoList)(this["CustomersStaticFilters"]));
            }
            set
            {
                this["CustomersStaticFilters"] = value;
            }
        }

        #region FilterDelivery

        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"<?xml version=""1.0"" encoding=""utf-16""?>
        <ArrayOfFilterInfo xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
          <FilterInfo>
            <Name>Todos</Name>
          </FilterInfo>
          <FilterInfo>
            <Name>Pendientes</Name>
            <FilterCriteria>[Status] == 'PENDING'</FilterCriteria>
          </FilterInfo>
          <FilterInfo>
            <Name>Finalizadas</Name>
            <FilterCriteria>[Status] == 'DELIVERED'</FilterCriteria>
          </FilterInfo>
          <FilterInfo>
            <Name>Canceladas</Name>
            <FilterCriteria>[Status] == 'CANCELLED'</FilterCriteria>
          </FilterInfo>
        </ArrayOfFilterInfo>")]
        public global::NextBO.Wpf.ViewModels.FilterInfoList DeliveryStaticFilters
        {
            get
            {
                return ((global::NextBO.Wpf.ViewModels.FilterInfoList)(this["DeliveryStaticFilters"]));
            }
            set
            {
                this["DeliveryStaticFilters"] = value;
            }
        }


        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"<?xml version=""1.0"" encoding=""utf-16""?>
        <ArrayOfFilterInfo xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema""> 
        </ArrayOfFilterInfo>")]
        public global::NextBO.Wpf.ViewModels.FilterInfoList DeliveryCustomFilters
        {
            get
            {
                return ((global::NextBO.Wpf.ViewModels.FilterInfoList)(this["DeliveryCustomFilters"]));
            }
            set
            {
                this["DeliveryCustomFilters"] = value;
            }
        }
        #endregion
        
        #region FilterDeliveryHistory

        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"<?xml version=""1.0"" encoding=""utf-16""?>
        <ArrayOfFilterInfo xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
          <FilterInfo>
            <Name>Todos</Name>
          </FilterInfo>
          <FilterInfo>
            <Name>Pendientes</Name>
            <FilterCriteria>[Status] == 'PENDING'</FilterCriteria>
          </FilterInfo>
          <FilterInfo>
            <Name>Finalizadas</Name>
            <FilterCriteria>[Status] == 'DELIVERED'</FilterCriteria>
          </FilterInfo>
          <FilterInfo>
            <Name>Canceladas</Name>
            <FilterCriteria>[Status] == 'CANCELLED'</FilterCriteria>
          </FilterInfo>
        </ArrayOfFilterInfo>")]
        public global::NextBO.Wpf.ViewModels.FilterInfoList DeliveryHistoryStaticFilters
        {
            get
            {
                return ((global::NextBO.Wpf.ViewModels.FilterInfoList)(this["DeliveryHistoryStaticFilters"]));
            }
            set
            {
                this["DeliveryHistoryStaticFilters"] = value;
            }
        }


        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"<?xml version=""1.0"" encoding=""utf-16""?>
        <ArrayOfFilterInfo xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema""> 
        </ArrayOfFilterInfo>")]
        public global::NextBO.Wpf.ViewModels.FilterInfoList DeliveryHistoryCustomFilters
        {
            get
            {
                return ((global::NextBO.Wpf.ViewModels.FilterInfoList)(this["DeliveryHistoryCustomFilters"]));
            }
            set
            {
                this["DeliveryHistoryCustomFilters"] = value;
            }
        }
        #endregion

        #region FilterVehicle

        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"<?xml version=""1.0"" encoding=""utf-16""?>
        <ArrayOfFilterInfo xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
          <FilterInfo>
            <Name>Todos</Name>
          </FilterInfo>
            <FilterInfo>
            <Name>Activos</Name>
            <FilterCriteria>[IsActive] == 1</FilterCriteria>
          </FilterInfo>
          <FilterInfo>
            <Name>Inactivos</Name>
            <FilterCriteria>[IsActive] == 0</FilterCriteria>
          </FilterInfo>
        </ArrayOfFilterInfo>")]
        public global::NextBO.Wpf.ViewModels.FilterInfoList VehicleStaticFilters
        {
            get
            {
                return ((global::NextBO.Wpf.ViewModels.FilterInfoList)(this["VehicleStaticFilters"]));
            }
            set
            {
                this["VehicleStaticFilters"] = value;
            }
        }


        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"<?xml version=""1.0"" encoding=""utf-16""?>
        <ArrayOfFilterInfo xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema""> 
        </ArrayOfFilterInfo>")]
        public global::NextBO.Wpf.ViewModels.FilterInfoList VehicleCustomFilters
        {
            get
            {
                return ((global::NextBO.Wpf.ViewModels.FilterInfoList)(this["VehicleCustomFilters"]));
            }
            set
            {
                this["VehicleCustomFilters"] = value;
            }
        }
        #endregion

        #region FilterWorkOrder

        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"<?xml version=""1.0"" encoding=""utf-16""?>
        <ArrayOfFilterInfo xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
          <FilterInfo>
            <Name>Todos</Name>
          </FilterInfo>
          <FilterInfo>
            <Name>Pendientes</Name>
            <FilterCriteria>[Status] == 'PENDING'</FilterCriteria>
          </FilterInfo>
          <FilterInfo>
            <Name>Activas</Name>
            <FilterCriteria>[Status] == 'ACTIVE'</FilterCriteria>
          </FilterInfo>
          <FilterInfo>
            <Name>Cerradas</Name>
            <FilterCriteria>[Status] == 'CLOSED'</FilterCriteria>
          </FilterInfo>
        </ArrayOfFilterInfo>")]
        public global::NextBO.Wpf.ViewModels.FilterInfoList WorkOrderStaticFilters
        {
            get
            {
                return ((global::NextBO.Wpf.ViewModels.FilterInfoList)(this["WorkOrderStaticFilters"]));
            }
            set
            {
                this["WorkOrderStaticFilters"] = value;
            }
        }


        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"<?xml version=""1.0"" encoding=""utf-16""?>
        <ArrayOfFilterInfo xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema""> 
        </ArrayOfFilterInfo>")]
        public global::NextBO.Wpf.ViewModels.FilterInfoList WorkOrderCustomFilters
        {
            get
            {
                return ((global::NextBO.Wpf.ViewModels.FilterInfoList)(this["WorkOrderCustomFilters"]));
            }
            set
            {
                this["WorkOrderCustomFilters"] = value;
            }
        }
        #endregion

        #region RouteSimulator

        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"<?xml version=""1.0"" encoding=""utf-16""?>
        <ArrayOfFilterInfo xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
          <FilterInfo>
            <Name>Todos</Name>
          </FilterInfo>
     
        </ArrayOfFilterInfo>")]
        public global::NextBO.Wpf.ViewModels.FilterInfoList RouteSimulatorStaticFilters
        {
            get
            {
                return ((global::NextBO.Wpf.ViewModels.FilterInfoList)(this["RouteSimulatorStaticFilters"]));
            }
            set
            {
                this["RouteSimulatorStaticFilters"] = value;
            }
        }


        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"<?xml version=""1.0"" encoding=""utf-16""?>
        <ArrayOfFilterInfo xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema""> 
        </ArrayOfFilterInfo>")]
        public global::NextBO.Wpf.ViewModels.FilterInfoList RouteSimulatorCustomFilters
        {
            get
            {
                return ((global::NextBO.Wpf.ViewModels.FilterInfoList)(this["RouteSimulatorCustomFilters"]));
            }
            set
            {
                this["RouteSimulatorCustomFilters"] = value;
            }
        }

        #endregion

    }
}
