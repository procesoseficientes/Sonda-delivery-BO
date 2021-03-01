using DevExpress.Mvvm;
using DevExpress.Mvvm.DataModel;
using DevExpress.Mvvm.POCO;
using DevExpress.Mvvm.ViewModel;
using NextApi.Models.Models;
using NextBO.DataModel;
using NextBO.Wpf.Common;
using NextBO.Wpf.Common.ViewModel;
using NextBO.Wpf.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using static Next.Utils.Enums.Enums;

namespace NextBO.Wpf.ViewModels
{

    public class RouteSimulatorCollectionViewModel : CollectionViewModel<RouteSimulatorHeader, long, INextBOUnitOfWork>, ISupportFiltering<RouteSimulatorHeader>
    {

        /// <summary>
        /// Creates a new instance of RouteSimulatorCollectionViewModel as a POCO view model.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        public static RouteSimulatorCollectionViewModel Create(IUnitOfWorkFactory<INextBOUnitOfWork> unitOfWorkFactory = null, UnitOfWorkPolicy unitOfWorkPolicy = UnitOfWorkPolicy.Individual)
        {
            return ViewModelSource.Create(() => new RouteSimulatorCollectionViewModel(unitOfWorkFactory, unitOfWorkPolicy));
        }

        /// <summary> 
        /// Initializes a new instance of the RouteSimulatorCollectionViewModel class.
        /// This constructor is declared protected to avoid undesired instantiation of the RouteSimulatorCollectionViewModel type without the POCO proxy factory.
        /// </summary> && rh.VehicleId == (vehicleId == 0? rh.VehicleId : vehicleId)
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        protected RouteSimulatorCollectionViewModel(IUnitOfWorkFactory<INextBOUnitOfWork> unitOfWorkFactory = null, UnitOfWorkPolicy unitOfWorkPolicy = UnitOfWorkPolicy.Individual)
            : base(unitOfWorkFactory ?? UnitOfWorkSource.GetUnitOfWorkFactory(), x => x.RouteSimulatorHeaders, 
                  query => query.Where( rh => rh.CreatedDate.Date >= startDate && 
                  rh.CreatedDate.Date <= endDate ),
                  unitOfWorkPolicy: unitOfWorkPolicy)
        {
            //try
            //{
            //    LookUpVehicle = CreateUnitOfWork().Vehicles.Where(vc => vc.IsActive > 0).ToList();
            //}
            //catch (Exception ex)
            //{
            //    MessageBoxService.ShowMessage(GetStringValue(Next.Enums.Enums.MessageError.DataError) + ex.Message, ex.Message,
            //        MessageButton.OK, MessageIcon.Error);
            //}
        }

        protected virtual ISaveFileDialogService SaveFileDialogService { get { return null; } }
        protected virtual IExportGridService ExportGridService { get { return null; } }
        public virtual List<Vehicle> LookUpVehicle { get; set; }
        public virtual RouteSimulatorHeader TableViewSelectedEntity { get; set; }

        public static DateTime startDate = DateTime.Now.AddDays(-7).Date;
        public DateTime StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }

        public static DateTime endDate = DateTime.Now.AddDays(7).Date;
        public DateTime EndDate
        {
            get { return endDate; }
            set { endDate = value; }
        }

        public static int vehicleId = 0;
        public int VehicleId
        {
            get { return vehicleId; }
            set { vehicleId = value; }
        }

        ViewSettingsViewModel viewSettings;

        public ViewSettingsViewModel ViewSettings
        {
            get
            {
                if (viewSettings == null)
                    viewSettings = ViewSettingsViewModel.Create(CollectionViewKind.ListView, this);
                return viewSettings;
            }
        }

        /// <summary>
        /// Export Grid
        /// </summary>
        /// <param name="fileType"></param>
        public void ExportGrid(ExportType fileType)
        {
            try
            {
                switch (fileType)
                {
                    case ExportType.XLSX:
                        SaveFileDialogService.DefaultExt = "xlsx";
                        SaveFileDialogService.Filter = "Excel 2007+|*.xlsx";
                        break;
                    case ExportType.PDF:
                        SaveFileDialogService.DefaultExt = "pdf";
                        SaveFileDialogService.Filter = "PDF|*.pdf";
                        break;
                }

                if (SaveFileDialogService.ShowDialog())
                {
                    var fileName = SaveFileDialogService.GetFullFileName();
                    ExportGridService.ExportTo(fileType, fileName);
                    if (MessageBoxService.ShowMessage("¿Desea abrir el archivo?", "Operación Exitosa", MessageButton.YesNo) == MessageResult.Yes)
                    {
                        var process = new Process();
                        process.StartInfo.UseShellExecute = true;
                        process.StartInfo.FileName = fileName;
                        process.Start();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBoxService.ShowMessage(GetStringValue(Next.Enums.Enums.MessageError.ExportError), ex.Message,
                        MessageButton.OK, MessageIcon.Error);
            }
        }

        public void ShowPreview()
        {
            ExportGridService.ShowPreview();
        }

        public void CreateCustomFilter()
        {
            Messenger.Default.Send(new CreateCustomFilterMessage<RouteSimulatorHeader>());
        }

        #region ISupportFiltering
        Expression<Func<RouteSimulatorHeader, bool>> ISupportFiltering<RouteSimulatorHeader>.FilterExpression
        {
            get { return FilterExpression; }
            set { FilterExpression = value; }
        }
        #endregion

    }
}
