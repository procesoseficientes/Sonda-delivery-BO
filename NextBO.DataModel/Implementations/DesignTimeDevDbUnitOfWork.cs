using System;
using System.Collections.Generic;
using NextApi.Models.Models;
using DevExpress.Mvvm.DataModel.DesignTime;
using DevExpress.Mvvm.DataModel;
using NextApi.Models.Resources.Responses;
using System.Xml.Linq;

namespace NextBO.DataModel
{

    /// <summary>
    /// A DevAVDbDesignTimeUnitOfWork instance that represents the design-time implementation of the INextBOUnitOfWork interface.
    /// </summary>
    public class DesignTimeDevDbUnitOfWork : DesignTimeUnitOfWork, INextBOUnitOfWork
    {

        /// <summary>
        /// Initializes a new instance of the DevAVDbDesignTimeUnitOfWork class.
        /// </summary>
        public DesignTimeDevDbUnitOfWork()
        {
        }

        IRepository<RefundAction, int> INextBOUnitOfWork.RefundActions
        {
            get { return GetRepository((RefundAction x) => x.Id); }
        }

        IRepository<User, int> INextBOUnitOfWork.Users
        {
            get { return GetRepository((User x) => x.Id); }
        }

        IRepository<Role, int> INextBOUnitOfWork.Roles
        {
            get { return GetRepository((Role x) => x.Id); }
        }

        IRepository<Pilot, int> INextBOUnitOfWork.Pilots
        {
            get { return GetRepository((Pilot x) => x.Id); }
        }

        IRepository<Parameter, int> INextBOUnitOfWork.Parameters
        {
            get { return GetRepository((Parameter x) => x.Id); }
        }

        IRepository<DeliveryTask, long> INextBOUnitOfWork.DailyDeliveryTask
        {
            get { return GetRepository((DeliveryTask x) => x.Id); }
        }

        IRepository<DeliveryImage, long> INextBOUnitOfWork.DeliveryImages
        {
            get { return GetRepository((DeliveryImage x) => x.IdTask); }
        }

        IRepository<ReasonNoDelivery, int> INextBOUnitOfWork.ReasonNoDeliveries
        {
            get { return GetRepository((ReasonNoDelivery x) => x.Id); }
        }

        IRepository<Checkpoint, int> INextBOUnitOfWork.Checkpoint
        {
            get { return GetRepository((Checkpoint x) => x.Id); }
        }

        IRepository<Vehicle, int> INextBOUnitOfWork.Vehicles
        {
            get { return GetRepository((Vehicle x) => x.Id); }
        }

        IRepository<ConfigCheckListVehicle, int> INextBOUnitOfWork.ConfigCheckListVehicles
        {
            get { return GetRepository((ConfigCheckListVehicle x) => x.Id); }
        }

        IRepository<CheckListByVehicle, long> INextBOUnitOfWork.CheckListByVehicles
        {
            get { return GetRepository((CheckListByVehicle x) => x.Id); }
        }

        IRepository<WorkOrder, long> INextBOUnitOfWork.WorkOrders
        {
            get { return GetRepository((WorkOrder x) => x.Id); }
        }

        IRepository<Category, int> INextBOUnitOfWork.Categories
        {
            get { return GetRepository((Category x) => x.Id); }
        }

        IRepository<WorkItem, long> INextBOUnitOfWork.WorkItems
        {
            get { return GetRepository((WorkItem x) => x.Id); }
        }

        IRepository<Service, long> INextBOUnitOfWork.Services
        {
            get { return GetRepository((Service x) => x.Id); }
        }

        IRepository<CenterOfService, int> INextBOUnitOfWork.ServiceCenters
        {
            get { return GetRepository((CenterOfService x) => x.Id); }
        }

        IRepository<Document, long> INextBOUnitOfWork.Documents
        {
            get { return GetRepository((Document x) => x.Id); }
        }

        IRepository<DocumentDetail, long> INextBOUnitOfWork.DocumentDetails
        {
            get { return GetRepository((DocumentDetail x) => x.Id); }
        }

        IRepository<RouteSimulatorHeader, long> INextBOUnitOfWork.RouteSimulatorHeaders
        {
            get { return GetRepository((RouteSimulatorHeader x) => x.Id); }
        }

        IRepository<RouteSimulatorDetail, long> INextBOUnitOfWork.RouteSimulatorDetails
        {
            get { return GetRepository((RouteSimulatorDetail x) => x.Id); }
        }

        public IRepository<DeliveryTask, long> Tasks => throw new NotImplementedException();

        IRepository<DeliveryTask, long> INextBOUnitOfWork.Tasks => throw new NotImplementedException();

        public IRepository<Report, int> Reports => throw new NotImplementedException();

        public User GetUserByLogin(User user)
        {
            throw new NotImplementedException();
        }

        public ReasonNoDelivery UpdateReasonNoDelivery(ReasonNoDelivery reasonNoDelivery)
        {
            throw new NotImplementedException();
        }

        public RefundAction UpdateRefund(RefundAction refundAction)
        {
            throw new NotImplementedException();
        }
        
        public User UpdateUser(User user)
        {
            throw new NotImplementedException();
        }

        public User UpdateTask(DeliveryTask task)
        {
            throw new NotImplementedException();
        }

        public CheckpointByRole CreateCheckpointByRole(CheckpointByRole checkpointByRole)
        {
            throw new NotImplementedException();
        }

        public void DeleteCheckpointByRole(CheckpointByRole checkpointByRole)
        {
            throw new NotImplementedException();
        }

        public Vehicle UpdateVehicle(Vehicle vehicle)
        {
            throw new NotImplementedException();
        }

        public Parameter GetParameter(Parameter parameter)
        {
            throw new NotImplementedException();
        }

        User INextBOUnitOfWork.UpdateUser(User user)
        {
            throw new NotImplementedException();
        }

        ReasonNoDelivery INextBOUnitOfWork.UpdateReasonNoDelivery(ReasonNoDelivery reasonNoDelivery)
        {
            throw new NotImplementedException();
        }

        RefundAction INextBOUnitOfWork.UpdateRefund(RefundAction refundAction)
        {
            throw new NotImplementedException();
        }

        User INextBOUnitOfWork.GetUserByLogin(User user)
        {
            throw new NotImplementedException();
        }

        Parameter INextBOUnitOfWork.GetParameter(Parameter parameter)
        {
            throw new NotImplementedException();
        }

        public Report GetReportByName(string name)
        {
            throw new NotImplementedException();
        }

        ConfigCheckListVehicle INextBOUnitOfWork.UpdateConfigurationCheckListVehicle(ConfigCheckListVehicle checkList)
        {
            throw new NotImplementedException();
        }

        public List<Document> GetLastDocument()
        {
            throw new NotImplementedException();
        }

        public List<ReprocessReportResource> GetDocumentsByDocNumber(string docNum)
        {
            throw new NotImplementedException();
        }

        public List<ManifestsByDateRangeResponseResource> GetStopsByManifest(DateTime StartDate, DateTime EndDate)
        {
            throw new NotImplementedException();
        }

        public List<ListManifestByVehicleXmlResource> GetManifestDetailByXML(XElement xml)
        {
            throw new NotImplementedException();
        }
        List<Parameter> INextBOUnitOfWork.GetParameterByGroup(Parameter parameter)
        {
            throw new NotImplementedException();
        }

        public List<DetailManifestsByXMLResource> GetManifestDetailByListId(string manifest)
        {
            throw new NotImplementedException();
        }
        List<ListManifestByVehicleXmlResource> INextBOUnitOfWork.GetManifestDetailByXML(XElement xml)
        {
            throw new NotImplementedException();
        }

        List<ListManifestByVehicleXmlResource> INextBOUnitOfWork.GetManifestDetailByListId(string manifest)
        {
            throw new NotImplementedException();
        }

        public List<LogLocation> GetTaskLogLocations(long taskId)
        {
            throw new NotImplementedException();
        }
    }
}
