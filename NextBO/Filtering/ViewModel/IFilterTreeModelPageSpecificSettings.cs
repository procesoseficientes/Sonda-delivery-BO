using System.Collections.Generic;

namespace NextBO.Wpf.ViewModels {
    public interface IFilterTreeModelPageSpecificSettings {
        string StaticFiltersTitle { get; }
        string CustomFiltersTitle { get; }
        FilterInfoList StaticFilters { get; set; }
        FilterInfoList CustomFilters { get; set; }
        IEnumerable<string> HiddenFilterProperties { get; }
        IEnumerable<string> AdditionalFilterProperties { get; }
        string Module { get;  }
        void SaveSettings();
    }
}