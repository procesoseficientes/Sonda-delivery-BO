namespace NextBO.Wpf.ViewModels {
    public abstract partial class MapViewModelBase {
        public const string WinBingKey = DevExpress.Map.Native.DXBingKeyVerifier.BingKeyWinOutlookInspiredApp;        
        public const string WpfBingKey = "Tv6zTvw3ykxbviueR9lU~RlLv0LeMlywC-hRyftKIpw~AouQVapTL-S4jo8cNFXGm0ic0ZIt-1JIJIm8ec1cxOQaGfeAUBU5AHe1ry4oqdxE";
        //public const string WpfBingKey = DevExpress.Map.Native.DXBingKeyVerifier.BingKeyWpfOutlookInspiredApp;
        public virtual Address Address { get; set; }
    }
}