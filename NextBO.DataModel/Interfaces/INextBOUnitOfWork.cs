using DevExpress.Mvvm.DataModel;
using NextApi.Models.Models;
using System.Collections.Generic;
using NextApi.Models.Resources.Responses;
using System;
using System.Xml.Linq;

namespace NextBO.DataModel
{

    /// <summary>
    /// INextBOUnitOfWork extends the IUnitOfWork interface with repositories representing specific entities.
    /// </summary>
    public interface INextBOUnitOfWork :
    IUnitOfWork
    {

        /// <summary>
        /// The User entities repository.
        /// </summary>
        IRepository<User, int> Users { get; }

        /// <summary>
        /// The User entities repository.
        /// </summary>
        IRepository<Role, int> Roles { get; }

        /// <summary>
        /// The User entities repository.
        /// </summary>
        IRepository<Pilot, int> Pilots { get; }

        /// <summary>
        /// The User entities repository.
        /// </summary>
        IRepository<Parameter, int> Parameters { get; }
        /// <summary>
        /// The DailyDeliveryTask
        /// </summary>
        IRepository<DeliveryTask, long> DailyDeliveryTask { get; }

        /// <summary>
        /// The Vehicles
        /// </summary>
        IRepository<Vehicle, int> Vehicles { get; }

        Report GetReportByName(string name);

        IRepository<DeliveryTask, long> Tasks { get; }

        IRepository<ReasonNoDelivery, int> ReasonNoDeliveries { get; }

        IRepository<RefundAction, int> RefundActions { get; }

        IRepository<Checkpoint, int> Checkpoint { get; }

        IRepository<DeliveryImage, long> DeliveryImages { get; }

        IRepository<ConfigCheckListVehicle, int> ConfigCheckListVehicles { get; }

        IRepository<CheckListByVehicle, long> CheckListByVehicles { get; }

        IRepository<WorkOrder, long> WorkOrders { get; }

        IRepository<Category, int> Categories { get; }

        IRepository<WorkItem, long> WorkItems { get; }
        
        IRepository<Service, long> Services { get; }
        
        IRepository<CenterOfService, int> ServiceCenters { get; }

        IRepository<Document, long> Documents { get; }

        IRepository<DocumentDetail, long> DocumentDetails { get; }

        IRepository<RouteSimulatorHeader, long> RouteSimulatorHeaders { get; }

        IRepository<RouteSimulatorDetail, long> RouteSimulatorDetails { get; }

        List<Document> GetLastDocument();
        List<ReprocessReportResource> GetDocumentsByDocNumber(string docNum);
        User UpdateUser(User user);
        Vehicle UpdateVehicle(Vehicle vehicle);
        ReasonNoDelivery UpdateReasonNoDelivery(ReasonNoDelivery reasonNoDelivery);
        RefundAction UpdateRefund(RefundAction refundAction);
        User GetUserByLogin(User user);
        Parameter GetParameter(Parameter parameter);
        ConfigCheckListVehicle UpdateConfigurationCheckListVehicle(ConfigCheckListVehicle checkList);
        List<ManifestsByDateRangeResponseResource> GetStopsByManifest(DateTime StartDate, DateTime EndDate);
        List<ListManifestByVehicleXmlResource> GetManifestDetailByXML(XElement xml);
        List<ListManifestByVehicleXmlResource> GetManifestDetailByListId(string manifest);
        List<Parameter> GetParameterByGroup(Parameter parameter);
        List<LogLocation> GetTaskLogLocations(long taskId);
    }
}
