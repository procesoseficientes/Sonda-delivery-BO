using NextBO.Wpf.Properties;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using DevExpress.Mvvm.ViewModel;
using System;
using NextBO.DataModel;
using NextApi.Models.Models;
using Action = System.Action;

namespace NextBO.Wpf.ViewModels
{
    internal static class FiltersSettings
    {

        public static FilterTreeViewModel<Vehicle, int> GetVehicleFilterTree(object parentViewModel)
        {
            return FilterTreeViewModel<Vehicle, int>.Create(
                new FilterTreeModelPageSpecificSettings<Settings>(Settings.Default, "Estado", x => x.VehicleStaticFilters, x => x.VehicleCustomFilters, Next.Enums.Enums.Modules.Vehiculos.ToString()),
                CreateUnitOfWork().Vehicles, new Action<object, Action>(RegisterEntityChangedMessageHandler<Vehicle, int>)
            ).SetParentViewModel(parentViewModel);
        }




        public static FilterTreeViewModel<User, int> GetUserFilterTree(object parentViewModel)
        {
            return FilterTreeViewModel<User, int>.Create(
                new FilterTreeModelPageSpecificSettings<Settings>(Settings.Default, "Estado", x => x.UserStaticFilters, x => x.UserCustomFilters, Next.Enums.Enums.Modules.Seguridad.ToString(),
                    null,
                    new[] {
                        BindableBase.GetPropertyName(() => new User().Role.Name)
                    }),
                CreateUnitOfWork().Users, new Action<object, Action>(RegisterEntityChangedMessageHandler<User, long>)
            ).SetParentViewModel(parentViewModel);
        }

        public static FilterTreeViewModel<DeliveryTask, long> GetDeliveryFilterTree(object parentViewModel)
        {
            return FilterTreeViewModel<DeliveryTask, long>.Create(
                new FilterTreeModelPageSpecificSettings<Settings>(Settings.Default, "Entregas", x => x.DeliveryStaticFilters, x => x.DeliveryCustomFilters, Next.Enums.Enums.Modules.Entregas.ToString()),
                CreateUnitOfWork().Tasks, new Action<object, Action>(RegisterEntityChangedMessageHandler<DeliveryTask, long>)
            ).SetParentViewModel(parentViewModel);
        }

        public static FilterTreeViewModel<WorkOrder, long> GetWorkOrderFilterTree(object parentViewModel)
        {
            return FilterTreeViewModel<WorkOrder, long>.Create(
                new FilterTreeModelPageSpecificSettings<Settings>(Settings.Default, "Ordenes de Trabajo", x => x.WorkOrderStaticFilters, x => x.WorkOrderCustomFilters, Next.Enums.Enums.Modules.Ordenes.ToString()),
                CreateUnitOfWork().WorkOrders, new Action<object, Action>(RegisterEntityChangedMessageHandler<WorkOrder, long>)
            ).SetParentViewModel(parentViewModel);
        }

        public static FilterTreeViewModel<DeliveryTask, long> GetDeliveryHistoryFilterTree(object parentViewModel)
        {
            return FilterTreeViewModel<DeliveryTask, long>.Create(
                new FilterTreeModelPageSpecificSettings<Settings>(Settings.Default, "Historico de Entregas", x => x.DeliveryHistoryStaticFilters, x => x.DeliveryHistoryCustomFilters, Next.Enums.Enums.Modules.Historico.ToString()),
                CreateUnitOfWork().Tasks, new Action<object, Action>(RegisterEntityChangedMessageHandler<DeliveryTask, long>)
            ).SetParentViewModel(parentViewModel);
        }

        public static FilterTreeViewModel<RouteSimulatorHeader, long> GetRouteSimulatorFilterTree(object parentViewModel)
        {
            return FilterTreeViewModel<RouteSimulatorHeader, long>.Create(
                new FilterTreeModelPageSpecificSettings<Settings>(Settings.Default, "Simulador de rutas", x => x.RouteSimulatorStaticFilters, x => x.RouteSimulatorCustomFilters, Next.Enums.Enums.Modules.Simulador.ToString()),
                CreateUnitOfWork().RouteSimulatorHeaders, new Action<object, Action>(RegisterEntityChangedMessageHandler<RouteSimulatorHeader, long>)
            ).SetParentViewModel(parentViewModel);
        }

        public static FilterTreeViewModel<string, int> NoFilterModule(object parentViewModel)
        {
            return FilterTreeViewModel<string, int>.CreateNoShowFilter().SetParentViewModel(parentViewModel);
        }
        //public static FilterTreeViewModel<EmployeeTask, long> GetTasksFilterTree(object parentViewModel)
        //{
        //    return FilterTreeViewModel<EmployeeTask, long>.Create(
        //        new FilterTreeModelPageSpecificSettings<Settings>(Settings.Default, "Tasks", x => x.TasksStaticFilters, x => x.TasksCustomFilters, null, null, "By Employee"),
        //        CreateUnitOfWork().Tasks, new Action<object, Action>(RegisterEntityChangedMessageHandler<EmployeeTask, long>)
        //    ).SetParentViewModel(parentViewModel);
        //}
        //public static FilterTreeViewModel<Customer, long> GetCustomersFilterTree(object parentViewModel)
        //{
        //    return FilterTreeViewModel<Customer, long>.Create(
        //        new FilterTreeModelPageSpecificSettings<Settings>(Settings.Default, "Favorites", x => x.CustomersStaticFilters, x => x.CustomersCustomFilters,
        //            new[] {
        //                BindableBase.GetPropertyName(() => new Customer().Id),
        //            },
        //            new[] {
        //                BindableBase.GetPropertyName(() => new Customer().BillingAddress) + "." + BindableBase.GetPropertyName(() => new Address().City),
        //                BindableBase.GetPropertyName(() => new Customer().BillingAddress) + "." + BindableBase.GetPropertyName(() => new Address().State),
        //                BindableBase.GetPropertyName(() => new Customer().BillingAddress) + "." + BindableBase.GetPropertyName(() => new Address().ZipCode),
        //            }),
        //        CreateUnitOfWork().Customers, new Action<object, Action>(RegisterEntityChangedMessageHandler<Customer, long>)
        //    ).SetParentViewModel(parentViewModel);
        //}
        //public static FilterTreeViewModel<Product, long> GetProductsFilterTree(object parentViewModel)
        //{
        //    return FilterTreeViewModel<Product, long>.Create(
        //        new FilterTreeModelPageSpecificSettings<Settings>(Settings.Default, "Category", x => x.ProductsStaticFilters, x => x.ProductsCustomFilters, null,
        //            new[] {
        //                BindableBase.GetPropertyName(() => new Product().Id),
        //                BindableBase.GetPropertyName(() => new Product().EngineerId),
        //                BindableBase.GetPropertyName(() => new Product().PrimaryImageId),
        //                BindableBase.GetPropertyName(() => new Product().SupportId),
        //                BindableBase.GetPropertyName(() => new Product().Support),
        //            }),
        //        CreateUnitOfWork().Products, new Action<object, Action>(RegisterEntityChangedMessageHandler<Product, long>)
        //    ).SetParentViewModel(parentViewModel);
        //}
        //public static FilterTreeViewModel<Order, long> GetSalesFilterTree(object parentViewModel)
        //{
        //    return FilterTreeViewModel<Order, long>.Create(
        //        new FilterTreeModelPageSpecificSettings<Settings>(Settings.Default, "Category", x => x.OrdersStaticFilters, x => x.OrdersCustomFilters,
        //            new[] {
        //                BindableBase.GetPropertyName(() => new Order().Id),
        //                BindableBase.GetPropertyName(() => new Order().CustomerId),
        //                BindableBase.GetPropertyName(() => new Order().EmployeeId),
        //                BindableBase.GetPropertyName(() => new Order().StoreId),
        //            },
        //            new[] {
        //                BindableBase.GetPropertyName(() => new Order().Customer) + "." + BindableBase.GetPropertyName(() => new Customer().Name),
        //            }),
        //        CreateUnitOfWork().Orders.ActualOrders(), new Action<object, Action>(RegisterEntityChangedMessageHandler<Order, long>)
        //    ).SetParentViewModel(parentViewModel);
        //}
        //public static FilterTreeViewModel<Quote, long> GetOpportunitiesFilterTree(object parentViewModel)
        //{
        //    return FilterTreeViewModel<Quote, long>.Create(
        //        new FilterTreeModelPageSpecificSettings<Settings>(Settings.Default, "Category", x => x.QuotesStaticFilters, null, null),
        //        CreateUnitOfWork().Quotes.ActualQuotes(), new Action<object, Action>(RegisterEntityChangedMessageHandler<Quote, long>)
        //    ).SetParentViewModel(parentViewModel);
        //}

        static INextBOUnitOfWork CreateUnitOfWork()
        {
            return UnitOfWorkSource.GetUnitOfWorkFactory().CreateUnitOfWork();
        }

        static void RegisterEntityChangedMessageHandler<TEntity, TPrimaryKey>(object recipient, Action handler)
        {
            Messenger.Default.Register<EntityMessage<TEntity, TPrimaryKey>>(recipient, message => handler());
        }
    }
}