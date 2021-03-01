using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NextApi.Models.Models;
using DevExpress.Mvvm.DataModel;
using DevExpress.Mvvm.DataModel.EFCore;
using NextApi.DataAccessLayer;
using Microsoft.Data.SqlClient;
using NextApi.Models.Resources.Responses;
using System.Xml.Linq;

namespace NextBO.DataModel
{

    /// <summary>
    /// A Unit of work instance that represents the run-time implementation of the INextBOUnitOfWork interface.
    /// </summary>
    public partial class DbUnitOfWork : DbUnitOfWork<NextDatabaseContext>, INextBOUnitOfWork
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="contextFactory"></param>
        public DbUnitOfWork(Func<NextDatabaseContext> contextFactory)
            : base(contextFactory)
        {
        }

        IRepository<RefundAction, int> INextBOUnitOfWork.RefundActions
        {
            get { return GetRepository(x => x.RefundActions, (RefundAction x) => x.Id); }
        }

        /// <summary>
        /// Get Users
        /// </summary>
        IRepository<User, int> INextBOUnitOfWork.Users
        {
            get { return GetRepository(x => x.Users, (User x) => x.Id); }
        }

        /// <summary>
        /// Get Roles
        /// </summary>
        IRepository<Role, int> INextBOUnitOfWork.Roles
        {
            get { return GetRepository(x => x.Roles, (Role x) => x.Id); }
        }

        /// <summary>
        /// Get Roles
        /// </summary>
        IRepository<Pilot, int> INextBOUnitOfWork.Pilots
        {
            get { return GetRepository(x => x.Pilots, (Pilot x) => x.Id); }
        }

        /// <summary>
        /// Get Delivery DailyTask
        /// 
        /// </summary>
        IRepository<NextApi.Models.Models.DeliveryTask, long> INextBOUnitOfWork.DailyDeliveryTask
        {

            get
            {
                return GetRepository(x => x.TaskManifests.Where(x => x.Status == "PENDING" || (x.Status == "DELIVERED" && x.CreatedDate.Value.Date == DateTime.Now.Date) || (x.Status == "CANCELLED" && x.CreatedDate.Value.Date == DateTime.Now.Date))
              , (DeliveryTask x) => x.Id);
            }
        }


        /// <summary>
        /// Get Delivery DailyTask
        /// 
        /// </summary>
        IRepository<NextApi.Models.Models.DeliveryTask, long> INextBOUnitOfWork.Tasks
        {
            get { return GetRepository(x => x.TaskManifests, (NextApi.Models.Models.DeliveryTask x) => x.Id); }
        }

        /// <summary>
        /// Get Image delivery
        /// 
        /// </summary>
        IRepository<DeliveryImage, long> INextBOUnitOfWork.DeliveryImages
        {
            get { return GetRepository(x => x.DeliveryImages, (DeliveryImage x) => x.IdTask); }
        }

        /// <summary>
        /// Get Parameters
        /// </summary>
        IRepository<Parameter, int> INextBOUnitOfWork.Parameters
        {
            get { return GetRepository(x => x.Parameters, (Parameter x) => x.Id); }
        }

        IRepository<ReasonNoDelivery, int> INextBOUnitOfWork.ReasonNoDeliveries
        {
            get { return GetRepository(x => x.ReasonNoDeliveries, (ReasonNoDelivery x) => x.Id); }
        }
        /// <summary>
        /// Get Checkpoint
        /// </summary>
        IRepository<Checkpoint, int> INextBOUnitOfWork.Checkpoint
        {
            get { return GetRepository(x => x.Checkpoints, (Checkpoint x) => x.Id); }
        }

        /// <summary>
        /// Get Vehicles
        /// </summary>
        IRepository<Vehicle, int> INextBOUnitOfWork.Vehicles
        {
            get { return GetRepository(x => x.Vehicles, (Vehicle x) => x.Id); }
        }

        /// <summary>
        /// Get report
        /// </summary>
        public Report GetReportByName(string name)
        {
            var report = Context.Reports.Where(x => x.NAME_REPORT == name).FirstOrDefault();
            return report;
        }

        /// <summary>
        /// Get Conig check list vehicle
        /// 
        /// </summary>
        IRepository<ConfigCheckListVehicle, int> INextBOUnitOfWork.ConfigCheckListVehicles
        {
            get { return GetRepository(x => x.ConfigCheckListVehicles, (ConfigCheckListVehicle x) => x.Id); }
        }

        /// <summary>
        /// Get CheckList By Vehicle
        /// 
        /// </summary>
        IRepository<CheckListByVehicle, long> INextBOUnitOfWork.CheckListByVehicles
        {
            get { return GetRepository(x => x.CheckListByVehicles, (CheckListByVehicle x) => x.Id); }
        }

        /// <summary>
        /// Get Work Orders
        /// 
        /// </summary>
        IRepository<WorkOrder, long> INextBOUnitOfWork.WorkOrders
        {
            get { return GetRepository(x => x.WorkOrders, (WorkOrder x) => x.Id); }
        }

        /// <summary>
        /// Get Categories
        /// 
        /// </summary>
        IRepository<Category, int> INextBOUnitOfWork.Categories
        {
            get { return GetRepository(x => x.Categories, (Category x) => x.Id); }
        }

        /// <summary>
        /// Get Work Items
        /// 
        /// </summary>
        IRepository<WorkItem, long> INextBOUnitOfWork.WorkItems
        {
            get { return GetRepository(x => x.WorkItems, (WorkItem x) => x.Id); }
        }

        /// <summary>
        /// Get Services
        /// 
        /// </summary>
        IRepository<Service, long> INextBOUnitOfWork.Services
        {
            get { return GetRepository(x => x.Services, (Service x) => x.Id); }
        }

        /// <summary>
        /// Get Service Centers
        /// 
        /// </summary>
        IRepository<CenterOfService, int> INextBOUnitOfWork.ServiceCenters
        {
            get { return GetRepository(x => x.ServiceCenters, (CenterOfService x) => x.Id); }
        }

        /// <summary>
        /// Get Documents
        /// 
        /// </summary>
        IRepository<Document, long> INextBOUnitOfWork.Documents
        {
            get { return GetRepository(x => x.Documents, (Document x) => x.Id); }
        }

        /// <summary>
        /// Get Document Details
        /// 
        /// </summary>
        IRepository<DocumentDetail, long> INextBOUnitOfWork.DocumentDetails
        {
            get { return GetRepository(x => x.DocumentDetails, (DocumentDetail x) => x.Id); }
        }

        /// <summary>
        /// Get Document Details
        /// 
        /// </summary>
        IRepository<RouteSimulatorHeader, long> INextBOUnitOfWork.RouteSimulatorHeaders
        {
            get { return GetRepository(x => x.RouteSimulatorHeaders, (RouteSimulatorHeader x) => x.Id); }
        }

        /// <summary>
        /// Get Document Details
        /// 
        /// </summary>
        IRepository<RouteSimulatorDetail, long> INextBOUnitOfWork.RouteSimulatorDetails
        {
            get { return GetRepository(x => x.RouteSimulatorDetails, (RouteSimulatorDetail x) => x.Id); }
        }

        /// <summary>
        /// Get userLogin for login
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public User GetUserByLogin(User user)
        {
            var x = GetRepository(x => x.Users, (User x) => x.Id);
            return x.Where(x => x.UserLogin == user.UserLogin).FirstOrDefault();
        }

        public List<Document> GetLastDocument()
        {
            string query = "EXEC [dbo].[GetLastTaskRegistered] @DocNum";
            var sqlParam = new SqlParameter("@DocNum", string.Empty);
            return Context.Documents.FromSqlRaw(query,sqlParam).ToList();
        }

        public List<ReprocessReportResource> GetDocumentsByDocNumber(string docNum)
        {
            string query = "EXEC [dbo].[GetLastTaskRegistered] @DocNum";
            var sqlParam = new SqlParameter("@DocNum", docNum);
            var result = Context.ReprocessReports.FromSqlRaw(query, sqlParam).ToList();
            return result;
        }

        public List<ManifestsByDateRangeResponseResource> GetStopsByManifest(DateTime StartDate, DateTime EndDate)
        {
            string query = "EXEC [dbo].[GetManifestsByDateRange] @initDate, @endDate";
            var sqlParam = new SqlParameter("@initDate", StartDate);
            var sqlParam1 = new SqlParameter("@endDate", EndDate);
            var result = Context.ManifestsByDateRange.FromSqlRaw(query, parameters: new[] { sqlParam,sqlParam1 }).ToList();
            return result;
        }

        public ReasonNoDelivery UpdateReasonNoDelivery(ReasonNoDelivery reasonNoDelivery)
        {
            var x = GetRepository(x => x.ReasonNoDeliveries, (ReasonNoDelivery x) => x.Id);
            x.Update(reasonNoDelivery);
            x.UnitOfWork.SaveChanges();
            return reasonNoDelivery;
        }

        public RefundAction UpdateRefund(RefundAction refundAction)
        {
            var x = GetRepository(x => x.RefundActions, (RefundAction x) => x.Id);
            x.Update(refundAction);
            x.UnitOfWork.SaveChanges();
            return refundAction;
        }


        public Parameter GetParameter(Parameter parameter)
        {
            return GetRepository(x => x.Parameters.Where(y => y.ParameterGroup == parameter.ParameterGroup && y.Name == parameter.Name), (Parameter x) => x.Id).FirstOrDefault();
        }

        public List<Parameter> GetParameterByGroup(Parameter parameter)
        {
            return GetRepository(x => x.Parameters.Where(y => y.ParameterGroup == parameter.ParameterGroup), (Parameter x) => x.Id).ToList();
        }


        /// <summary>
        /// Update user from projection
        /// </summary>
        /// <param name="user">Projection</param>
        /// <returns>Updated user</returns>
        public User UpdateUser(User user)
        {
            var x = GetRepository(x => x.Users, (User x) => x.Id);
            x.Update(user);
            x.UnitOfWork.SaveChanges();
            return user;
        }
        public Vehicle UpdateVehicle(Vehicle vehicle)
        {
            var x = GetRepository(x => x.Vehicles, (Vehicle x) => x.Id);
            x.Update(vehicle);
            x.UnitOfWork.SaveChanges();
            return vehicle;
        }

        public ConfigCheckListVehicle UpdateConfigurationCheckListVehicle(ConfigCheckListVehicle checkList)
        {
            var x = GetRepository(x => x.ConfigCheckListVehicles, (ConfigCheckListVehicle x) => x.Id);
            x.Update(checkList);
            x.UnitOfWork.SaveChanges();
            return checkList;
        }

        public List<ListManifestByVehicleXmlResource> GetManifestDetailByXML(XElement xml)
        {            
            string query = "EXEC [dbo].[GetManifestDetailByXML] @manifestsXML";
            var sqlParam = new SqlParameter("@manifestsXML", xml.ToString());
            var result = Context.DetailManifestsByXML.FromSqlRaw(query, sqlParam).ToList();
            return result;
        }

        public List<ListManifestByVehicleXmlResource> GetManifestDetailByListId(string manifest)
        {
            string query = "EXEC [dbo].[GetManifestDetailByListId] @manifestsId";
            var sqlParam = new SqlParameter("@manifestsId", manifest);
            var result = Context.DetailManifestsByXML.FromSqlRaw(query, parameters: new[] { sqlParam }).ToList();
            return result;
        }

        public List<LogLocation> GetTaskLogLocations(long taskId)
        {
            var x = GetRepository(x => x.TaskManifests, (DeliveryTask x) => x.Id).Where(x => x.Id == taskId).FirstOrDefault();
            List<LogLocation> logs = new List<LogLocation>();
            if (x != null)
            {
                Guid a = Guid.Parse("63D4DD3D-835A-4048-B38F-9FB0006C04BA");
                logs = GetRepository(l => l.LogLocations, (LogLocation l) => l.Id)
                    //.Where(l => l.Latitude == Math.Round(latitudeNoDelivery, 5) && Math.Round(l.Longitude, 5) == longitudeNoDelivery && l.ProcessGrouper == x.ProcessGrouper)
                    .Where(l => l.ProcessGrouper == a)
                    .ToList();
            }
            return logs;
        }
    }
}
