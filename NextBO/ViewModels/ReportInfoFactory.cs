using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using NextBO.Wpf.Common.ViewModel;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using DevExpress.XtraReports;
using NextApi.Models.Models;
using System.IO;
using DevExpress.XtraReports.UI;
using System.Drawing;
using NextBO.DataModel;
using static Next.Utils.Enums.Enums;

namespace NextBO.Wpf.ViewModels
{

    public static class ReportInfoFactory
    {

        #region User
        private class DataSource
        {
            public IEnumerable<object> List { get; set; }
        }

        public static IReportInfo GetReportInfoFromRepository(string name, IEnumerable<object> dataSource, INextBOUnitOfWork unitOfWork)
        {
            return GetReportInfo(DefaultPrintModeViewModel.Create(), p => GetReportbyName(name, dataSource, unitOfWork));

        }

        public static IReportInfo GetReportInfoFromRepository(string name, object dataSource, INextBOUnitOfWork unitOfWork)
        {
            return GetReportInfo(DefaultPrintModeViewModel.Create(), p => GetReportbyName(name, dataSource, unitOfWork));

        }


        public static IReportInfo GetReportInfoFromXtraReport(XtraReport report)
        {
            return GetReportInfo(DefaultPrintModeViewModel.Create(), p => report);

        }

        public static XtraReport GetDeliveryReport(DeliveryTask task, INextBOUnitOfWork unitOfWork)
        {
            List<DeliveryTask> list = new List<DeliveryTask>();
            foreach (var item in task.DeliveryImages)
            {
                item.ImageObj = string.IsNullOrEmpty(item.Image) ? null : Convert.FromBase64String(item.Image.Replace("data:image/jpeg;base64,", string.Empty).Replace("data:image/png;base64,", string.Empty));
            }
            task.DeliverySignatureObj = string.IsNullOrEmpty(task.DeliverySignature) ? null : Convert.FromBase64String(task.DeliverySignature.Replace("data:image/jpeg;base64,", string.Empty).Replace("data:image/png;base64,", string.Empty));
            list.Add(task);

            var report = ReportInfoFactory.GetReportbyName(GetStringValue(Next.Enums.Enums.Report.Entrega), list, unitOfWork);

            foreach (var item in report.Bands)
            {
                SetTaskReportDataMember((Band)item);

                if (item is DetailReportBand)
                {
                    foreach (var detail in ((DetailReportBand)item))
                    {
                        SetTaskReportDataMember((Band)detail);
                    }
                }
            }
            return report;
        }

        public static void SetTaskReportDataMember(Band reportBand)
        {

            switch (reportBand.Name)
            {
                case "DetailReport":
                    if (reportBand is DetailReportBand)
                    {
                        ((DetailReportBand)reportBand).DataMember = "List.Documents";
                    }
                    break;
                case "DetailReport1":
                    if (reportBand is DetailReportBand)
                    {
                        ((DetailReportBand)reportBand).DataMember = "List.Documents.DocumentDetail";
                    }
                    break;

                case "DetailReport2":
                    if (reportBand is DetailReportBand)
                    {
                        ((DetailReportBand)reportBand).DataMember = "List.DeliveryImages";
                    }
                    break;
                default:
                    break;
            }

        }


        public static XtraReport GetReportbyName(string name, object dataSource, INextBOUnitOfWork unitOfWork)
        {
            var dbReport = GetReportFromDb(name, unitOfWork);
            XtraReport report = XtraReport.FromXmlStream(GetStreamFromXmlString(dbReport.REPORT));
            report.Report.DataSource = dataSource;
            report.ScriptsSource = null;
            return report;
        }

        public static XtraReport GetReportbyName(string name, IEnumerable<object> dataSource, INextBOUnitOfWork unitOfWork)
        {

            var dbReport = GetReportFromDb(name, unitOfWork);
            XtraReport report = XtraReport.FromXmlStream(GetStreamFromXmlString(dbReport.REPORT));
            var ds = new DataSource { List = dataSource };
            report.Report.DataSource = ds;
            report.Report.DataMember = "List";
            report.ScriptsSource = null;
            
            return report;
        }

        private static Report GetReportFromDb(string reportName, INextBOUnitOfWork unitOfWork)
        {
            var dbReport = unitOfWork.GetReportByName(reportName);
            if (dbReport == null)
            {
                throw new Exception("No se encontro informacion del reporte");
            }
            return dbReport;
        }
        private static MemoryStream GetStreamFromXmlString(string report)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(report);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        #endregion

        static IReportInfo GetReportInfo<TParametersViewModel>(TParametersViewModel parametersViewModel, Func<TParametersViewModel, IReport> reportFactory)
        {
            return new ReportInfo<TParametersViewModel>(parametersViewModel, reportFactory);
        }
    }

    public class SortDirectionViewModel
    {
        public static SortDirectionViewModel Create()
        {
            return ViewModelSource.Create(() => new SortDirectionViewModel());
        }
        protected SortDirectionViewModel() { }
        public virtual SortOrderPrintMode SortDirection { get; set; }
    }

    public class SortDirectionAndDateRangeViewModel : SortDirectionViewModel
    {
        public new static SortDirectionAndDateRangeViewModel Create()
        {
            return ViewModelSource.Create(() => new SortDirectionAndDateRangeViewModel());
        }
        protected SortDirectionAndDateRangeViewModel()
        {
        }
    }

    public class SortByDateViewModel
    {
        public static SortByDateViewModel Create()
        {
            return ViewModelSource.Create(() => new SortByDateViewModel());
        }
        protected SortByDateViewModel() { }
        public virtual SortByDatePrintMode SortDirection { get; set; }
    }

    public class SortByViewModel
    {
        public static SortByViewModel Create()
        {
            return ViewModelSource.Create(() => new SortByViewModel());
        }
        protected SortByViewModel() { }
        public virtual SortByPrintMode SortDirection { get; set; }
    }


    public class DefaultPrintModeViewModel
    {
        public static DefaultPrintModeViewModel Create()
        {
            return ViewModelSource.Create(() => new DefaultPrintModeViewModel());
        }
        protected DefaultPrintModeViewModel() { }

    }



    public enum EmployeeEvaluationsPrintMode
    {
        [Image("pack://application:,,,/NextBO.Wpf;component/Resources/PrintExcludeEvaluations.svg")]
        ExcludeEvaluations,
        [Image("pack://application:,,,/NextBO.Wpf;component/Resources/PrintIncludeEvaluations.svg")]
        IncludeEvaluations,
    }
    public enum CustomerContactsPrintMode
    {
        [Image("pack://application:,,,/NextBO.Wpf;component/Resources/PrintIncludeEvaluations.svg")]
        IncludeContacts,
        [Image("pack://application:,,,/NextBO.Wpf;component/Resources/PrintExcludeEvaluations.svg")]
        ExcludeContacts,
    }
    public enum ProductImagesPrintMode
    {
        [Image("pack://application:,,,/NextBO.Wpf;component/Resources/ShowProduct.svg")]
        DisplayProductImages,
        [Image("pack://application:,,,/NextBO.Wpf;component/Resources/HideProduct.svg")]
        HideProductImages,
    }
    public enum SortOrderPrintMode
    {
        [Image("pack://application:,,,/NextBO.Wpf;component/Resources/SortAsc.svg")]
        AscendingOrder,
        [Image("pack://application:,,,/NextBO.Wpf;component/Resources/SortDesc.svg")]
        DescencingOrder
    }
    public enum SortByDatePrintMode
    {
        [Display(Name = "Sort by Due Date"), Image("pack://application:,,,/NextBO.Wpf;component/Resources/ShowDueDate.svg")]
        SortByDueDate,
        [Display(Name = "Sort by Start Date"), Image("pack://application:,,,/NextBO.Wpf;component/Resources/ShowStartDate.svg")]
        SortByStartDate
    }
    public enum SortByPrintMode
    {
        [Display(Name = "Sort by Order Date"), Image("pack://application:,,,/NextBO.Wpf;component/Resources/SortByOrderDate.svg")]
        SortByOrderDate,
        [Display(Name = "Sort by Invoice #"), Image("pack://application:,,,/NextBO.Wpf;component/Resources/SortByInvoice.svg")]
        SortByInvoice
    }
}