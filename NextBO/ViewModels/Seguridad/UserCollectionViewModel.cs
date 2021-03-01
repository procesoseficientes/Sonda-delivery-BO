using DevExpress.Mvvm;
using DevExpress.Mvvm.DataModel;
using DevExpress.Mvvm.POCO;
using DevExpress.Mvvm.ViewModel;
using NextApi.Models.Models;
using NextBO.DataModel;
using NextBO.Wpf.Common;
using NextBO.Wpf.Common.ViewModel;
using static Next.Utils.Enums.Enums;
using NextBO.Wpf.Services;
using System;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;

namespace NextBO.Wpf.ViewModels
{
    public class UserCollectionViewModel : CollectionViewModel<User, int, INextBOUnitOfWork>, ISupportFiltering<User>
    {

        /// <summary>
        /// Creates a new instance of UserCollectionViewModel as a POCO view model.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        public static UserCollectionViewModel Create(IUnitOfWorkFactory<INextBOUnitOfWork> unitOfWorkFactory = null, UnitOfWorkPolicy unitOfWorkPolicy = UnitOfWorkPolicy.Individual)
        {
            return ViewModelSource.Create(() => new UserCollectionViewModel(unitOfWorkFactory, unitOfWorkPolicy));
        }

        /// <summary>
        /// Initializes a new instance of the UserCollectionViewModel class.
        /// This constructor is declared protected to avoid undesired instantiation of the UserCollectionViewModel type without the POCO proxy factory.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        protected UserCollectionViewModel(IUnitOfWorkFactory<INextBOUnitOfWork> unitOfWorkFactory = null, UnitOfWorkPolicy unitOfWorkPolicy = UnitOfWorkPolicy.Individual)
            : base(unitOfWorkFactory ?? UnitOfWorkSource.GetUnitOfWorkFactory(), x => x.Users, unitOfWorkPolicy: unitOfWorkPolicy)
        {
        }

        protected virtual ISaveFileDialogService SaveFileDialogService { get { return null; } }
        protected virtual IExportGridService ExportGridService { get { return null; } }
        protected IUserSessionService UserSessionService { get { return this.GetRequiredService<IUserSessionService>(); } }
        public virtual User TableViewSelectedEntity { get; set; }
        public virtual User CardViewSelectedEntity { get; set; }
        IReportService PrintService { get { return this.GetRequiredService<IReportService>("PrintService"); } }
        IReportService ExportService { get { return this.GetRequiredService<IReportService>("ExportService"); } }
        public UICommand SaveLayoutCommand { get; set; }
        public UICommand RestoreLayoutCommand { get; set; }

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

        public void ShowRoles()
        {
            try
            {
                var RoleModel = RoleCollectionViewModel.Create();
                DocumentManagerService.CreateDocument(GetStringValue(Next.Enums.Enums.Views.Role), RoleModel, null, this).Show();
            }
            catch (Exception ex)
            {
                MessageBoxService.ShowMessage(GetStringValue(Next.Enums.Enums.MessageError.WindowError) + ex.Message, ex.Message,
                    MessageButton.OK, MessageIcon.Error);
            }
        }

        public void Parameter()
        {
            try
            {
                var Parameter = ParameterViewModel.Create();
                DocumentManagerService.CreateDocument(GetStringValue(Next.Enums.Enums.Views.Parameter), Parameter, null, this).Show();
            }
            catch (Exception ex)
            {
                MessageBoxService.ShowMessage(GetStringValue(Next.Enums.Enums.MessageError.WindowError) + ex.Message, ex.Message,
                    MessageButton.OK, MessageIcon.Error);
            }
        }

        public void ShowPreview()
        {
            ExportGridService.ShowPreview();
        }

        public void LoadReport(bool showReport)
        {
            try
            {
                var UnitOfWork = UnitOfWorkFactory.CreateUnitOfWork();
                foreach (var item in Entities)
                {
                    item.ImageOb = item.Image == null ? null : Convert.FromBase64String(item.Image.Replace("data:image/jpeg;base64,", ""));
                }
                if (showReport)
                    ShowReport(ReportInfoFactory.GetReportInfoFromRepository(GetStringValue(Next.Enums.Enums.Report.Usuarios), Entities, UnitOfWork), "Usuarios");
                else
                    SetDefaultReport(ReportInfoFactory.GetReportInfoFromRepository(GetStringValue(Next.Enums.Enums.Report.Usuarios), Entities, UnitOfWork));
            }
            catch (Exception ex)
            {
                MessageBoxService.ShowMessage(GetStringValue(Next.Enums.Enums.MessageError.ReportError) + ex.Message, ex.Message,
                    MessageButton.OK, MessageIcon.Error);
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
                MessageBoxService.ShowMessage(GetStringValue(Next.Enums.Enums.MessageError.ExportError) + ex.Message, ex.Message,
                    MessageButton.OK, MessageIcon.Error);
            }
        }

        /// <summary>
        /// Inactivate user
        /// </summary>
        /// <param name="projectionEntity"></param>
        public override void Delete(User projectionEntity)
        {
            var entity = this.Entities.Where(x => x.Id == projectionEntity.Id).FirstOrDefault();
            entity.IsActive = 0;
            entity.ModifiedBy = UserSessionService.LoggedUser.UserLogin;
            entity.ModifiedDate = DateTime.Now;
            this.CreateUnitOfWork().UpdateUser(projectionEntity);
            this.Refresh();
        }

        /// <summary>
        /// Activate user
        /// </summary>
        /// <param name="projectionEntity"></param>
        public void Activate(User projectionEntity)
        {
            var entity = this.Entities.Where(x => x.Id == projectionEntity.Id).FirstOrDefault();
            entity.IsActive = 1;
            entity.ModifiedBy = UserSessionService.LoggedUser.UserLogin;
            entity.ModifiedDate = DateTime.Now;
            this.CreateUnitOfWork().UpdateUser(entity);
            this.Refresh();
        }

        public override bool CanDelete(User projectionEntity)
        {
            return (projectionEntity != null && projectionEntity.IsActive == 1);
        }

        public bool CanActivate(User projectionEntity)
        {
            return (projectionEntity != null && projectionEntity.IsActive == 0);
        }

        void ShowReport(IReportInfo reportInfo, string reportId)
        {
            ExportService.ShowReport(reportInfo);
            PrintService.ShowReport(reportInfo);
            Logger.Log(string.Format("OutlookInspiredApp: Create Report : User: {0}", reportId));
        }

        void SetDefaultReport(IReportInfo reportInfo)
        {
            if (this.IsInDesignMode()) return;
            ExportService.SetDefaultReport(reportInfo);
            PrintService.SetDefaultReport(reportInfo);
        }

        public void PrintProfilesUsers()
        {
            LoadReport(true);
        }

        public bool CanPrintProfileUserCommand()
        {
            return Entities != null;
        }

        protected override void OnSelectedEntityChanged()
        {
            base.OnSelectedEntityChanged();
            TableViewSelectedEntity = SelectedEntity;
            CardViewSelectedEntity = SelectedEntity;
        }

        protected override void OnEntitiesAssigned(Func<User> getSelectedEntityCallback)
        {
            base.OnEntitiesAssigned(getSelectedEntityCallback);
            if (Entities.Any())
            {
                LoadReport(false);
                if (SelectedEntity == null)
                {
                    SelectedEntity = Entities.OrderBy(x => x.Name).FirstOrDefault();
                }
            }
        }

        public virtual void OnTableViewSelectedEntityChanged()
        {
            if (viewSettings.ViewKind == CollectionViewKind.ListView)
            {
                SelectedEntity = TableViewSelectedEntity;
            }
        }

        public virtual void OnCardViewSelectedEntityChanged()
        {
            if (viewSettings.ViewKind == CollectionViewKind.CardView)
            {
                SelectedEntity = CardViewSelectedEntity;
            }
        }

        public void CreateCustomFilter()
        {
            Messenger.Default.Send(new CreateCustomFilterMessage<User>());
        }

        #region ISupportFiltering
        Expression<Func<User, bool>> ISupportFiltering<User>.FilterExpression
        {
            get { return FilterExpression; }
            set { FilterExpression = value; }
        }
        #endregion

    }
}