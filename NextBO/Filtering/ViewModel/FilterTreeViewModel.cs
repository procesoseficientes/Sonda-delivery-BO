using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using DevExpress.Data.Filtering;
using DevExpress.Data.Utils;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using DevExpress.Mvvm.ViewModel;

namespace NextBO.Wpf.ViewModels
{
    public class FilterTreeViewModel<TEntity, TPrimaryKey> : IFilterTreeViewModel where TEntity : class
    {
        static FilterTreeViewModel()
        {
        }

        public static FilterTreeViewModel<TEntity, TPrimaryKey> Create(IFilterTreeModelPageSpecificSettings settings, IQueryable<TEntity> entities, Action<object, Action> registerEntityChangedMessageHandler)
        {
            return ViewModelSource.Create(() => new FilterTreeViewModel<TEntity, TPrimaryKey>(settings, entities, registerEntityChangedMessageHandler));
        }

        public static FilterTreeViewModel<TEntity, TPrimaryKey> CreateNoShowFilter()
        {
            return ViewModelSource.Create(() => new FilterTreeViewModel<TEntity, TPrimaryKey>());
        }
        readonly IQueryable<TEntity> entities;
        readonly IFilterTreeModelPageSpecificSettings settings;
        object viewModel;

        protected FilterTreeViewModel()
        {
            ShowFilterGroup = false;
        }
        protected FilterTreeViewModel(IFilterTreeModelPageSpecificSettings settings, IQueryable<TEntity> entities, Action<object, Action> registerEntityChangedMessageHandler)
        {
            this.settings = settings;
            this.entities = entities;
            StaticFilters = CreateFilterItems(settings.StaticFilters);
            CustomFilters = CreateFilterItems(settings.CustomFilters);
            SelectedItem = StaticFilters.FirstOrDefault();
            AllowFiltersContextMenu = true;
            WarningParameterName = "Overdue Tasks";
            ShowFilterGroup = true;
            Messenger.Default.Register<EntityMessage<TEntity, TPrimaryKey>>(this, message => UpdateFilters()); // temporary fix

            Messenger.Default.Register<CreateCustomFilterMessage<TEntity>>(this, message =>
            {

                CreateCustomFilter((message as CreateCustomFilterMessage<TEntity>).Module);

            });
            UpdateFilters();
            StaticCategoryName = settings.StaticFiltersTitle;
            CustomCategoryName = settings.CustomFiltersTitle;

            Categories = new ObservableCollection<FilterCategory>() {
                new FilterCategory(StaticCategoryName, this, StaticFilters),
                new FilterCategory(CustomCategoryName, this, CustomFilters, isCustom:true)
            };
        }

        public virtual ObservableCollection<FilterCategory> Categories { get; protected set; }

        public virtual ObservableCollection<FilterItem> StaticFilters { get; protected set; }
        public virtual ObservableCollection<FilterItem> CustomFilters { get; protected set; }
        public virtual FilterItem SelectedItem { get; set; }
        public virtual FilterItem ActiveFilterItem { get; set; }
        public string WarningParameterName { get; private set; }
        public virtual string WarningInfo { get; set; }
        public Action NavigateAction { get; set; }

        public virtual bool ShowFilterGroup { get; set; }
        public string StaticCategoryName { get; private set; }
        public string CustomCategoryName { get; private set; }
        public bool AllowCustomFilters { get { return settings.CustomFilters != null; } }
        public bool AllowFiltersContextMenu
        {
            get
            {
                return AllowCustomFilters && allowFiltersContextMenu;
            }
            set
            {
                allowFiltersContextMenu = value;
            }
        }
        bool allowFiltersContextMenu;

        public void DeleteCustomFilter(FilterItem filterItem)
        {
            try
            {
                CustomFilters.Remove(filterItem);
                SaveCustomFilters();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DuplicateFilter(FilterItem filterItem)
        {
            try
            {
                var newItem = filterItem.Clone("Copy of " + filterItem.Name, null);
                CustomFilters.Add(newItem);
                SaveCustomFilters();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void ResetCustomFilters()
        {
            try
            {
                if (CustomFilters.Contains(SelectedItem))
                    SelectedItem = null;
                settings.CustomFilters = new FilterInfoList();
                CustomFilters.Clear();
                settings.SaveSettings();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void ModifyCustomFilter(FilterItem existing)
        {
            try
            {
                FilterItem clone = existing.Clone();
                var filterViewModel = CreateCustomFilterViewModel(clone, true);
                ShowFilter(clone, filterViewModel, () =>
                {
                    existing.FilterCriteria = clone.FilterCriteria;
                    existing.Name = clone.Name;
                    SaveCustomFilters();
                    if (existing == SelectedItem)
                        OnSelectedItemChanged();
                });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void ModifyCustomFilterCriteria(FilterItem existing, CriteriaOperator criteria)
        {
            try
            {
                if (!ReferenceEquals(existing.FilterCriteria, null) && !ReferenceEquals(criteria, null) && existing.FilterCriteria.ToString() == criteria.ToString())
                    return;
                existing.FilterCriteria = criteria;
                SaveCustomFilters();
                if (existing == SelectedItem)
                    OnSelectedItemChanged();
                UpdateFilters();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ResetToAll()
        {
            SelectedItem = StaticFilters[0];
        }

        public void CreateCustomFilter(string module)
        {
            try
            {
                if (module != string.Empty && this.settings.Module != module)
                {
                    return;
                }
                FilterItem filterItem = CreateFilterItem(string.Empty, null, null);
                var filterViewModel = CreateCustomFilterViewModel(filterItem, true);
                ShowFilter(filterItem, filterViewModel, () => AddNewCustomFilter(filterItem));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void AddCustomFilter(string name, CriteriaOperator filterCriteria, string imageUri = null)
        {
            AddNewCustomFilter(CreateFilterItem(name, filterCriteria, imageUri));
        }
        protected virtual void OnSelectedItemChanged()
        {
            ActiveFilterItem = SelectedItem.Clone();
            UpdateFilterExpression();
            NavigateCore();
        }
        public virtual void Navigate()
        {
            NavigateCore();
        }
        void NavigateCore()
        {
            if (NavigateAction != null)
                NavigateAction();
        }
        void IFilterTreeViewModel.SetViewModel(object viewModel)
        {
            this.viewModel = viewModel;
            var viewModelContainer = viewModel as IFilterTreeViewModelContainer<TEntity, TPrimaryKey>;
            if (viewModelContainer != null)
                viewModelContainer.FilterTreeViewModel = this;
            UpdateFilterExpression();
        }

        void UpdateFilterExpression()
        {
            ISupportFiltering<TEntity> viewModel = this.viewModel as ISupportFiltering<TEntity>;
            if (viewModel != null)
                viewModel.FilterExpression = ActiveFilterItem == null ? null : GetWhereExpression(ActiveFilterItem.FilterCriteria);
        }

        ObservableCollection<FilterItem> CreateFilterItems(IEnumerable<FilterInfo> filters)
        {
            if (filters == null)
                return new ObservableCollection<FilterItem>();
            return new ObservableCollection<FilterItem>(filters.Select(x => CreateFilterItem(x.Name, CriteriaOperator.Parse(x.FilterCriteria), x.ImageUri)));
        }

        const string NewFilterName = @"New Filter";

        void AddNewCustomFilter(FilterItem filterItem)
        {
            try
            {
                if (string.IsNullOrEmpty(filterItem.Name))
                {
                    int prevIndex = CustomFilters.Select(fi => Regex.Match(fi.Name, NewFilterName + @" (?<index>\d+)")).Where(m => m.Success).Select(m => int.Parse(m.Groups["index"].Value)).DefaultIfEmpty(0).Max();
                    filterItem.Name = NewFilterName + " " + (prevIndex + 1);
                }
                else
                {
                    var existing = CustomFilters.FirstOrDefault(fi => fi.Name == filterItem.Name);
                    if (existing != null)
                        CustomFilters.Remove(existing);
                }
                CustomFilters.Add(filterItem);
                SaveCustomFilters();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        void SaveCustomFilters()
        {
            settings.CustomFilters = SaveToSettings(CustomFilters);
            settings.SaveSettings();
        }

        FilterInfoList SaveToSettings(ObservableCollection<FilterItem> filters)
        {
            return new FilterInfoList(filters.Select(fi => new FilterInfo { Name = fi.Name, FilterCriteria = CriteriaOperator.ToString(fi.FilterCriteria) }));
        }

        void UpdateFilters()
        {
            try
            {
                foreach (var item in StaticFilters.Concat(CustomFilters))
                {
                    var entityCount = GetEntityCount(item.FilterCriteria);
                    if (item.Name == WarningParameterName)
                        WarningInfo = entityCount.ToString();
                    item.Update(entityCount);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        void ShowFilter(FilterItem filterItem, CustomFilterViewModel filterViewModel, Action onSave)
        {
            try
            {
                if (FilterDialogService.ShowDialog(MessageButton.OKCancel, "Crear Filtro Persnalizado", "CustomFilterView", filterViewModel) != MessageResult.OK)
                    return;
                filterItem.FilterCriteria = filterViewModel.FilterCriteria;
                filterItem.Name = filterViewModel.FilterName;
                ActiveFilterItem = filterItem;
                if (filterViewModel.Save)
                {
                    onSave();
                    UpdateFilters();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        CustomFilterViewModel CreateCustomFilterViewModel(FilterItem existing, bool save)
        {
            var viewModel = CustomFilterViewModel.Create(typeof(TEntity), settings.HiddenFilterProperties, settings.AdditionalFilterProperties, settings.Module);
            viewModel.FilterCriteria = existing.FilterCriteria;
            viewModel.FilterName = existing.Name;
            viewModel.Save = save;
            viewModel.SetParentViewModel(this);
            return viewModel;
        }

        FilterItem CreateFilterItem(string name, CriteriaOperator filterCriteria, string imageUri)
        {
            return FilterItem.Create(GetEntityCount(filterCriteria), name, filterCriteria, imageUri, this);
        }

        int GetEntityCount(CriteriaOperator criteria)
        {
            try
            {
                return entities.Where(GetWhereExpression(criteria).Compile()).Count();
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        Expression<Func<TEntity, bool>> GetWhereExpression(CriteriaOperator criteria)
        {
            var caseInsensitiveCriteria = DevExpress.Data.Helpers.StringsTolowerCloningHelper.Process(criteria);
            return this.IsInDesignMode()
                ? CriteriaOperatorToExpressionConverter.GetLinqToObjectsWhere<TEntity>(caseInsensitiveCriteria)
                : CriteriaOperatorToExpressionConverter.GetGenericWhere<TEntity>(caseInsensitiveCriteria);
        }

        IDialogService FilterDialogService { get { return this.GetRequiredService<IDialogService>("FilterDialogService"); } }

        ObservableCollection<FilterCategory> IFilterTreeViewModel.Categories
        {
            get { return Categories; }
        }
    }

    public interface IFilterTreeViewModelContainer<TEntity, TPrimaryKey> where TEntity : class
    {
        FilterTreeViewModel<TEntity, TPrimaryKey> FilterTreeViewModel { get; set; }
    }

    public class CreateCustomFilterMessage<TEntity> where TEntity : class
    {
        public string Module { get; set; }
        public CreateCustomFilterMessage(string module)
        {
            Module = module;
        }

        public string getModule() { return Module; }

        public CreateCustomFilterMessage()
        {
            Module = string.Empty;
        }
    }
    public class FilterCategory
    {
        public string Name { get; private set; }
        public IFilterTreeViewModel FilterTreeViewModel { get; private set; }
        public ObservableCollection<FilterItem> FilterItems { get; private set; }
        public bool IsCustom { get; private set; }

        public FilterCategory(string name, IFilterTreeViewModel filterTreeViewModel, ObservableCollection<FilterItem> filterItems, bool isCustom = false)
        {
            Name = name;
            FilterItems = filterItems;
            FilterTreeViewModel = filterTreeViewModel;
            IsCustom = isCustom;
        }
    }
    public interface IFilterTreeViewModel
    {
        void SetViewModel(object content);
        Action NavigateAction { get; set; }
        ObservableCollection<FilterCategory> Categories { get; }
    }
}