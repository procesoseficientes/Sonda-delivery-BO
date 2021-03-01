using System.Windows.Controls;
using DevExpress.Mvvm.POCO;

namespace NextBO.Wpf.ViewModels {
    public class ViewSettingsViewModel {
        public static ViewSettingsViewModel Create(CollectionViewKind viewKind, object parentViewModel) {
            return ViewModelSource.Create(() => new ViewSettingsViewModel(viewKind)).SetParentViewModel(parentViewModel);
        }

        CollectionViewKind defaultCollectionViewKind;

        protected ViewSettingsViewModel(CollectionViewKind defaultCollectionViewKind) {
            this.defaultCollectionViewKind = defaultCollectionViewKind;
            ResetView();
        }
        public virtual CollectionViewKind ViewKind { get; set; }
        public virtual Orientation Orientation { get; set; }
        public virtual bool IsDataPaneVisible { get; set; }
        public virtual bool IsFilterPaneVisible { get; set; }
        public void ResetView() {
            ViewKind = defaultCollectionViewKind;
            Orientation = Orientation.Horizontal;
            IsDataPaneVisible = true;
            IsFilterPaneVisible = true;
        }
        public bool CanShowList() {
            return !object.Equals(ViewKind, CollectionViewKind.ListView);
        }
        public bool CanShowCard() {
            return !object.Equals(ViewKind, CollectionViewKind.CardView);
        }
        public bool CanShowMasterDetail() {
            return !object.Equals(ViewKind, CollectionViewKind.MasterDetailView);
        }
        public bool CanShowFilterId()
        {
            return !object.Equals(ViewKind, CollectionViewKind.FilterId);
        }
        public bool CanShowFilterDate()
        {
            return !object.Equals(ViewKind, CollectionViewKind.FilterDate);
        }
        public void ShowList() {
            ViewKind = CollectionViewKind.ListView;
        }
        public void ShowCard() {
            ViewKind = CollectionViewKind.CardView;
        }
        public void ShowMasterDetail() {
            ViewKind = CollectionViewKind.MasterDetailView;
        }
        public void ShowFilterId()
        {
            ViewKind = CollectionViewKind.FilterId;
        }
        public void ShowFilterDate()
        {
            ViewKind = CollectionViewKind.FilterDate;
        }
        public void DataPaneRight() {
            Orientation = Orientation.Horizontal;
            IsDataPaneVisible = true;
        }
        public bool CanDataPaneRight() {
            return Orientation != Orientation.Horizontal || !IsDataPaneVisible;
        }
        public void DataPaneLeft() {
            Orientation = Orientation.Vertical;
            IsDataPaneVisible = true;
        }
        public bool CanDataPaneLeft() {
            return Orientation != Orientation.Vertical || !IsDataPaneVisible;
        }
        public void DataPaneOff() {
            IsDataPaneVisible = false;
        }
        public bool CanDataPaneOff() {
            return IsDataPaneVisible;
        }
    }
}