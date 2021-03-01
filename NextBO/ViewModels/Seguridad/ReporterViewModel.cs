using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using DevExpress.XtraReports.UI;
using NextBO.DataModel;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using static Next.Utils.Enums.Enums;

namespace NextBO.Wpf.ViewModels
{
    public class ReporterViewModel : IDocumentContent
    {

        #region IDocumentContent
        void IDocumentContent.OnClose(CancelEventArgs e)
        {
            Report.Dispose();
        }
        void IDocumentContent.OnDestroy() { }
        IDocumentOwner IDocumentContent.DocumentOwner
        {
            get { return DocumentOwner; }
            set { DocumentOwner = value; }
        }
        object IDocumentContent.Title { get { return Title; } }
        #endregion

        public static ReporterViewModel Create(object entity, string reportName, string reportTitle, INextBOUnitOfWork unitOfWork)
        {
            return ViewModelSource.Create(() => new ReporterViewModel(entity, reportName, reportTitle, unitOfWork));
        }

        public static ReporterViewModel Create(IEnumerable<object> entities, string reportName, string reportTitle, INextBOUnitOfWork unitOfWork)
        {
            return ViewModelSource.Create(() => new ReporterViewModel(entities, reportName, reportTitle, unitOfWork));
        }

        public static ReporterViewModel Create(XtraReport report, string reportTitle)
        {
            return ViewModelSource.Create(() => new ReporterViewModel(report, reportTitle));
        }



        protected ReporterViewModel(object entity, string reportName, string reportTitle, INextBOUnitOfWork unitOfWork)
        {
            Entity = entity;
            Name = reportName;
            Title = reportTitle;
            UnitOfWork = unitOfWork;
            Report = null;
        }

        protected ReporterViewModel(XtraReport report, string reportTitle)
        {
            Report = report;
            Title = reportTitle;
        }

        protected ReporterViewModel(IEnumerable<object> entities, string reportName, string reportTitle, INextBOUnitOfWork unitOfWork)
        {
            Entities = entities;
            Entity = null;
            Name = reportName;
            Title = reportTitle;
            UnitOfWork = unitOfWork;
            Report = null;
        }

        public object Entity { get; set; }
        public INextBOUnitOfWork UnitOfWork { get; set; }
        public IEnumerable<object> Entities { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        protected IDocumentManagerService DocumentManagerService { get { return this.GetService<IDocumentManagerService>(); } }
        protected IDocumentOwner DocumentOwner { get; private set; }
        public RevenueReportFormat Format { get; set; }
        public virtual XtraReport Report { get; set; }
        public enum RevenueReportFormat
        {
            Summary,
            Analysis
        }

        public virtual void OnLoaded()
        {
            if (Report == null)
            {
                Report = Entity != null ? ReportInfoFactory.GetReportbyName(Name, Entity, UnitOfWork) : ReportInfoFactory.GetReportbyName(Name, Entities, UnitOfWork);
            }
            Report.CreateDocument();
        }

        public void ShowDesigner()
        {
            var viewModel = ReportDesignerViewModel.Create(CloneReport(Report));
            var doc = DocumentManagerService.CreateDocument(GetStringValue(Next.Enums.Enums.Views.ReporterDesigner), viewModel, null, this);
            doc.Title = Title;
            doc.Show();

            if (viewModel.IsReportSaved)
            {
                Report = CloneReport(viewModel.Report);
                Report.CreateDocument();
                viewModel.Report.Dispose();
            }
        }

        void InitReport(XtraReport report)
        {
            report.DataSource = Entity;
            report.Parameters["paramOrderDate"].Value = true;
        }

        XtraReport CloneReport(XtraReport report)
        {
            var clonedReport = CloneReportLayout(report);
            InitReport(clonedReport);
            return clonedReport;
        }

        static XtraReport CloneReportLayout(XtraReport report)
        {
            using (var stream = new MemoryStream())
            {
                report.SaveLayoutToXml(stream);
                stream.Position = 0;
                return XtraReport.FromStream(stream, true);
            }
        }

        public void Close()
        {
            if (DocumentOwner != null)
                DocumentOwner.Close(this);
        }

    }
}
