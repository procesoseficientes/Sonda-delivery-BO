using System;
using DevExpress.Mvvm;
using NextBO.Wpf.Common;
using NextBO.DataModel;
using NextApi.Models.Models;
using DevExpress.Mvvm.DataModel;
using DevExpress.Mvvm.POCO;
using System.Linq;
using NextBO.Wpf.Services;
using System.Diagnostics;
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;
using System.IO;
using DevExpress.Xpf.Map;
using NextBO.Wpf.Common.ViewModel;
using static Next.Utils.Enums.Enums;
using System.Globalization;

namespace NextBO.Wpf.ViewModels
{
    public class TaskViewModel : SingleObjectViewModel<DeliveryTask, long, INextBOUnitOfWork>
    {

        /// <summary>
        /// Creates a new instance of UserViewModel as a POCO view model.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        public static TaskViewModel Create(IUnitOfWorkFactory<INextBOUnitOfWork> unitOfWorkFactory = null)
        {
            return ViewModelSource.Create(() => new TaskViewModel(unitOfWorkFactory));
        }

        /// <summary>
        /// Initializes a new instance of the UserViewModel class.
        /// This constructor is declared protected to avoid undesired instantiation of the UserViewModel type without the POCO proxy factory.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        protected TaskViewModel(IUnitOfWorkFactory<INextBOUnitOfWork> unitOfWorkFactory = null)
            : base(unitOfWorkFactory ?? UnitOfWorkSource.GetUnitOfWorkFactory(), x => x.Tasks, x => x.Id)
        {
        }

        public virtual ObservableCollection<DocumentDetail> ListDetailCurrentTask { get; set; }
        ObservableCollection<DocumentDetail> CollectionDetail = new ObservableCollection<DocumentDetail>();
        public virtual ObservableCollection<BitmapImage> CollectionBitmapImages { get; set; }
        ObservableCollection<BitmapImage> ListDeliveryImage = new ObservableCollection<BitmapImage>();
        public virtual ObservableCollection<GeoPoint> PointsMapDelivery { get; set; }
        ObservableCollection<GeoPoint> ListPointMap = new ObservableCollection<GeoPoint>();
        public virtual GeoPoint CenterPoint { get; set; }
        public virtual ObservableCollection<BitmapImage> CollectionFirmImage { get; set; }
        ObservableCollection<BitmapImage> firm = new ObservableCollection<BitmapImage>();

        private void getDocumentDetail()
        {
            try
            {
                if (Entity == null)
                    return;
                CollectionDetail = new ObservableCollection<DocumentDetail>();
                ListDetailCurrentTask = null;
                foreach (var document in Entity.Documents)
                {

                    foreach (var detail in document.DocumentDetail)
                    {
                        DocumentDetail currentDetail = new DocumentDetail();

                        currentDetail.Caliber = detail.Caliber;
                        currentDetail.CreatedDate = detail.CreatedDate;
                        currentDetail.Discount = detail.Discount;
                        currentDetail.DiscountType = detail.DiscountType;
                        currentDetail.Document = detail.Document;
                        currentDetail.DocumentId = detail.DocumentId;
                        currentDetail.ExternalDetailId = detail.ExternalDetailId;
                        currentDetail.Id = detail.Id;
                        currentDetail.IdLocal = detail.IdLocal;
                        currentDetail.IdLocalDocument = detail.IdLocalDocument;
                        currentDetail.LastUpdate = detail.LastUpdate;
                        currentDetail.LineNum = detail.LineNum;
                        currentDetail.MaterialId = detail.MaterialId;
                        currentDetail.MaterialName = detail.MaterialName;
                        currentDetail.Price = detail.Price;
                        currentDetail.Qty = detail.Qty;
                        currentDetail.QtyDelivered = detail.QtyDelivered;
                        currentDetail.ReasonNoDeliveryId = detail.ReasonNoDeliveryId;
                        currentDetail.Tone = detail.Tone;
                        currentDetail.UserIdCreated = detail.UserIdCreated;
                        currentDetail.UserIdUpdated = detail.UserIdUpdated;

                        if (detail.Qty == detail.QtyDelivered)
                        {
                            currentDetail.Status = "Completo";
                        }
                        else
                        {
                            currentDetail.Status = "Incompleto";
                        }
                        CollectionDetail.Add(currentDetail);
                    }
                }

                if (CollectionDetail.Count > 0)
                {
                    ListDetailCurrentTask = CollectionDetail;
                }
            }
            catch (Exception ex)
            {
                MessageBoxService.ShowMessage(GetStringValue(Next.Enums.Enums.MessageError.DataError), ex.Message,
                        MessageButton.OK, MessageIcon.Error);
            }
        }

        //convert base64 to BitmapImage
        public static BitmapImage GetBitmapImage(string img)
        {
            byte[] byteImage = Convert.FromBase64String(img);
            MemoryStream memoryStream = new MemoryStream(byteImage);
            BitmapImage bitImage = new BitmapImage();

            bitImage.BeginInit();
            bitImage.StreamSource = memoryStream;
            bitImage.EndInit();

            return bitImage;
        }

        public void GetImageDelivery()
        {
            try
            {
                if (Entity == null)
                    return;

                var EntityDeliveryImage = this.UnitOfWork.DeliveryImages.Where(x => x.IdTask == Entity.Id).ToList();
                if (EntityDeliveryImage != null)
                {
                    foreach (var curImage in EntityDeliveryImage)
                    {
                        var base64String = curImage.Image != null ? ((string)curImage.Image).
                            Replace("data:image/jpeg;base64,", string.Empty).
                            Replace("data:image/png;base64,", string.Empty) :
                            string.Empty;
                        var imageConvertBitImage = GetBitmapImage(base64String);
                        ListDeliveryImage.Add(imageConvertBitImage);
                    }

                    if (Entity.DeliverySignature != null)
                    {
                        var SignatureBase64String = Entity.DeliverySignature != null ? ((string)Entity.DeliverySignature).
                            Replace("data:image/jpeg;base64,", string.Empty).
                            Replace("data:image/png;base64,", string.Empty) :
                            string.Empty;
                        var image = GetBitmapImage(SignatureBase64String);
                        firm.Add(image);
                        CollectionFirmImage = firm;
                    }
                    if (ListDeliveryImage.Count > 0)
                        CollectionBitmapImages = ListDeliveryImage;

                }
            }
            catch (Exception ex)
            {
                MessageBoxService.ShowMessage(GetStringValue(Next.Enums.Enums.MessageError.DataError), ex.Message,
                    MessageButton.OK, MessageIcon.Error);
            }
        }

        private void GetPointAndShowInMap()
        {
            PointsMapDelivery = new ObservableCollection<GeoPoint>();
            ListPointMap.Clear();
            //Obtiene los puntos principales para centrar el mapa
            try
            {
                if (Entity.LongitudeInVisit != null || Entity.LatitudeInVisit != null)
                {
                    CenterPoint = new GeoPoint();
                    CenterPoint.Latitude = Convert.ToDouble(Entity.LatitudeInVisit, CultureInfo.GetCultureInfo("en-US"));
                    CenterPoint.Longitude = Convert.ToDouble(Entity.LongitudeInVisit, CultureInfo.GetCultureInfo("en-US"));

                    ListPointMap.Add(CenterPoint);
                }

                if (!String.IsNullOrEmpty(Entity.Longitude) || !String.IsNullOrEmpty(Entity.Latitude))
                {
                    GeoPoint centerPoin = new GeoPoint();
                    centerPoin.Latitude = Convert.ToDouble(Entity.Latitude, CultureInfo.GetCultureInfo("en-US"));
                    centerPoin.Longitude = Convert.ToDouble(Entity.Longitude, CultureInfo.GetCultureInfo("en-US"));

                    ListPointMap.Add(centerPoin);
                    if (CenterPoint != null)
                    {
                        CenterPoint = new GeoPoint((CenterPoint.Latitude + centerPoin.Latitude) / 2,
                            (CenterPoint.Longitude + centerPoin.Longitude) / 2);
                    }
                    else
                    {
                        CenterPoint = centerPoin;
                    }
                }

                if (ListPointMap.Count > 0)
                    PointsMapDelivery = ListPointMap;
            }
            catch (Exception ex)
            {
                MessageBoxService.ShowMessage(GetStringValue(Next.Enums.Enums.MessageError.DataError), ex.Message,
                        MessageButton.OK, MessageIcon.Error);
            }
        }

        //protected override void OnEntityChanged()
        //{
        //    base.OnEntityChanged();
        //    if (Entity != null)
        //    {
        //        Logger.Log(string.Format("Next: Edit User: {0}",
        //            string.IsNullOrEmpty(Entity.Id.ToString()) ? "<New>" : Entity.Id.ToString()));

        //        getDocumentDetail();
        //        GetImageDelivery();
        //        GetPointAndShowInMap();
        //    }
        //}

        public override void OnLoaded()
        {
            if (Entity != null)
            {
                getDocumentDetail();
                GetImageDelivery();
                GetPointAndShowInMap();
            }
        }

        protected IDocumentManagerService DocumentManagerService { get { return this.GetRequiredService<IDocumentManagerService>(); } }
        protected virtual ISaveFileDialogService SaveFileDialogService { get { return null; } }
        protected virtual IExportGridService ExportGridService { get { return null; } }
        protected IUserSessionService UserSessionService { get { return this.GetRequiredService<IUserSessionService>(); } }
        IReportService PrintService { get { return this.GetRequiredService<IReportService>("PrintService"); } }
        IReportService ExportService { get { return this.GetRequiredService<IReportService>("ExportService"); } }

        protected override string GetTitle()
        {
            return Entity.Id.ToString() + " - " + Entity.ClientName;
        }

        public void ShowPreview()
        {
            ExportGridService.ShowPreview();
        }

        public void PrintTask()
        {
            try
            {
                var UnitOfWork = UnitOfWorkFactory.CreateUnitOfWork();
                DocumentManagerService.CreateDocument(GetStringValue(Next.Enums.Enums.Views.Reporter),
                    ReporterViewModel.Create(ReportInfoFactory.GetDeliveryReport(Entity, UnitOfWork),
                    "Entrega:  " + Entity.Id), null, this).Show();
            }
            catch (Exception ex)
            {
                MessageBoxService.ShowMessage(GetStringValue(Next.Enums.Enums.MessageError.ReportError), ex.Message,
                        MessageButton.OK, MessageIcon.Error);
            }
        }

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

        void ShowReport(IReportInfo reportInfo, string reportId)
        {
            ExportService.ShowReport(reportInfo);
            PrintService.ShowReport(reportInfo);
            Logger.Log(string.Format("OutlookInspiredApp: Create Report : User: {0}", reportId));
        }

        public void SendEmail()
        {
            try
            {
                Entity.EmailSent = 0;
                Entity.LastUpdate = DateTime.Now;
                Entity.UserIdUpdated = UserSessionService.LoggedUser.Id.ToString();
                base.Save();
            }
            catch (Exception ex)
            {
                MessageBoxService.ShowMessage(GetStringValue(Next.Enums.Enums.MessageError.OperationError), ex.Message,
                        MessageButton.OK, MessageIcon.Error);
            }
        }

        public bool CanSendEmail()
        {
            return Entity.Status.Equals(GetStringValue(Next.Enums.Enums.StatusTask.Delivered));
        }

    }
}
