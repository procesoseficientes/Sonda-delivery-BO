   M S B A M L   `   `   `  ����E  ANextBO.Wpf, Version=1.0.1.0, Culture=neutral, PublicKeyToken=null'clr-namespace:NextBO.Wpf
NextBO.Wpf  5      9!clr-namespace:NextBO.Wpf.ServicesNextBO.Wpf.Services  5      %    NextBO.Wpf.Views.ReDeliveryView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35h dDevExpress.Xpf.TypedStyles.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aR NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/netfx/2009/xaml/presentation     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089<x,http://schemas.microsoft.com/winfx/2006/xaml      5      a ]DevExpress.Xpf.Core.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49al hDevExpress.Xpf.Core.v20.2.Extensions, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a?dx2http://schemas.devexpress.com/winfx/2008/xaml/core    5      Hmc;http://schemas.openxmlformats.org/markup-compatibility/2006    5      >dxb2http://schemas.devexpress.com/winfx/2008/xaml/bars   5      Adxe5http://schemas.devexpress.com/winfx/2008/xaml/editors   5      l hDevExpress.Xpf.Grid.v20.2.Extensions, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aa	 ]DevExpress.Xpf.Grid.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49af
 bDevExpress.Xpf.Grid.v20.2.Core, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aBdxg2http://schemas.devexpress.com/winfx/2008/xaml/grid  	 
  5	      c _DevExpress.Xpf.Ribbon.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aBdxr4http://schemas.devexpress.com/winfx/2008/xaml/ribbon    5
      d `DevExpress.Xpf.Docking.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aBdxdo5http://schemas.devexpress.com/winfx/2008/xaml/docking   5      g cDevExpress.Mvvm.v20.2.ViewModel, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a] YDevExpress.Mvvm.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aEdxmvvm2http://schemas.devexpress.com/winfx/2008/xaml/mvvm     5      *localclr-namespace:NextBO.Wpf     5      6services!clr-namespace:NextBO.Wpf.Services     5      j fDevExpress.Xpf.LayoutControl.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aHdxlc;http://schemas.devexpress.com/winfx/2008/xaml/layoutcontrol   5        � UseLayoutRounding$
  True��5       � 	Resources 5       �� MergedDictionaries �� Source!   NextBO.Wpf.PictureConverter   PictureConverter0  *DevExpress.Mvvm.UI.ObjectToObjectConverter  PaymentConverter
   Map   DevExpress.Mvvm.UI.MapItem   Source   Target1  +DevExpress.Xpf.Core.SvgImageSourceExtension5  /DevExpress.Xpf.Core.BaseSvgImageSourceExtension   Size
   Uri  ShipmentConverter  TextConvert  PaidTooltipConverter	   DefaultTarget  PaymentStatusConverter  RefundTooltipConverter  ListViewToFalseConverter  DetailViewTemplate% 	 DevExpress.Xpf.Grid.GridControl) 
 #DevExpress.Xpf.Grid.DataControlBase
   
ShowBorder   ItemsSource   View# 	 DevExpress.Xpf.Grid.TableView&	 
  DevExpress.Xpf.Grid.DataViewBase 	  AllowEditing&
 	  DevExpress.Xpf.Grid.GridViewBase 
  ShowGroupPanel   FormatConditions   Columns$ 	 DevExpress.Xpf.Grid.GridColumn$ 
 DevExpress.Xpf.Grid.ColumnBase   IsSmart   	FieldName$ 
 DevExpress.Xpf.Grid.BaseColumn   HeaderToolTip   Width2 
 ,DevExpress.Xpf.Grid.GridColumnWidthConverter   
FixedWidth'    HorizontalHeaderContentAlignment   CellToolTipBinding �� Path �� 	Converter   HeaderTemplate!  DevExpress.Xpf.Core.DXImage   Source   CellTemplate   Header)  #DevExpress.Xpf.Core.ObjectConverter   Binding   EditSettings6  0DevExpress.Xpf.Editors.Settings.TextEditSettings�� 5   
    5      �� 5      $D >pack://application:,,,/NextBO.Wpf;component/Themes/Common.xaml?�6%   %(  &	        &	      &	     &	 �    &	 �    &	 �    &	 �    &	 7    &	 �    7  7  7    5      6%     5      . 5        $ 	CANCELLED��6!    64     	 16,16$T Npack://application:,,,/NextBO.Wpf;component/Resources/Orders/PaymentUnpaid.svg?�  5      $ 	DELIVERED��6!    64     	 16,16$R Lpack://application:,,,/NextBO.Wpf;component/Resources/Orders/PaymentPaid.svg?�  5      $ PENDING��6!    62     	 16,16$T Npack://application:,,,/NextBO.Wpf;component/Resources/Orders/PaymentRefund.svg?�  5      $ Other��6!    60   Z� 5        5       . 5!        $ PENDING��6!    62     	 16,16$W Qpack://application:,,,/NextBO.Wpf;component/Resources/Orders/ShipmentAwaiting.svg?�  5"      $ 	CANCELLED��6!    64     	 16,16$V Ppack://application:,,,/NextBO.Wpf;component/Resources/Orders/ShipmentTransit.svg?�  5#      $ 	DELIVERED��6!    64     	 16,16$W Qpack://application:,,,/NextBO.Wpf;component/Resources/Orders/ShipmentReceived.svg?�5$        5%      . 5&        $ 	DELIVERED��6!   $ 	ENTREGADO��64     5'      $ 	CANCELLED��6!   $ 	CANCELADO��64     5(      $ PENDING��6!   $ 	PENDIENTE��62   5)        5*      $
	 Paid��6J   . 5+        $ 0��6!   $ Mark as Paid��6,   5,        5-      $	 Other��6L   . 5.        $ Unpaid��6!   $ Unpaid��61     5/      $ 
PaidInFull��6!   $ Paid In Full��65     50      $ RefundInFull��6!   $ Refund In Full��67   51        52      $	 Refund Issued��6L   . 53        $ 0��6!   $ Issue Full Refund��6,   54        55      $
	 True��6N   . 56        $ ListView��6!   $ False��63   57      �� 58      .R�59        $

 True��6@   $
��5000��6R    6"   �� *Tasks+ 5:        5;      $ False��5<       $ False��5=        5>      5@       5B        5C      $
 True��6)   $ Status��68   $ Estado de Entrega��6K   $ 40 6�   $
 True��6�   $ Center=�6�    6m   �� $ Status�8    5D      �� 5E   "   .R�5F   &     $
��None=�6�    61     	 16,16$N Hpack://application:,,,/NextBO.Wpf;component/Resources/Orders/Payment.svg?�6�   5G   #    5I      �� 5J   "   .R�5K   &     $
��None=�6|    61   �� $ Value�8  6|   5L   #   5N        5O      $
 True��6)   $ Id��68    5P      �� 5Q   "   .R�5R   &   �� $��Tarea��60   $
��Bold"�6=   5S   #   5U        5V      $
 True��6)   $ CreatedDate��68   $ Fecha de Creacion 6P     5W      $
 True��6)   $ 
DriverName��68   $ Piloto 6O     5X      $
 True��6)   $ VehicleDescription��68   $ Modelo del Vehiculo 6W     5Y      $
 True��6)   $ NoReasonDelivery��68   $ Razon de no Entrega 6U     5Z      $
 True��6)   $ Status��68    5[   *   �� $ Status�8   5\        5]   "   5_        5`      $
 True��6)   $ QtyTotal��68   $ Items entregados 6M   5b      5c      5d      2  ,DevExpress.Mvvm.UI.Interactivity.Interaction    	Behaviors  5f      +   %NextBO.Wpf.Services.ExportGridService  5g   
   !   View! 6&   %  System.Windows.Markup.Reference  *ReDeliveryTableView+-  'DevExpress.Xpf.Core.DXMessageBoxService  5h   
   .  (DevExpress.Mvvm.UI.SaveFileDialogService  5i   
   .��5l      ]� .+�5m   
   )  #DevExpress.Xpf.Ribbon.RibbonControl  -   5        "  Name$" ribbonControl��5m      #   RibbonStyle$# 
Office2019=�63   $	��Top=�6L   $   ShowApplicationButton$$ False��6a   %   Items.% 5n      5  /DevExpress.Xpf.Ribbon.RibbonDefaultPageCategory  2  ,DevExpress.Xpf.Ribbon.RibbonPageCategoryBase&   Caption$& defaultCategory��6,   '   Pages.' 5o      &   DevExpress.Xpf.Ribbon.RibbonPage  (   Caption$
( Home 6!   )   Groups.) 5p      +  %DevExpress.Xpf.Ribbon.RibbonPageGroup  *   Caption$* Exportar��6*   +   Items.+ 5q      '  !DevExpress.Xpf.Bars.BarButtonItem  !  DevExpress.Xpf.Bars.BarItem,   Content$, Generar Reporte 6,   -   Command- 5r   ,   �� *PrintReprocessCommand+.   CommandParameter. 5s   ,   �� *SelectedEntity+/   
LargeGlyph/ 5t   ,     $F @pack://application:,,,/NextBO.Wpf;component/Resources/Report.svg?�0   Glyph0 5u   ,     $F @pack://application:,,,/NextBO.Wpf;component/Resources/Report.svg?�  5v      $, Previsualizar 6,   - 5w   ,   �� *ShowPreviewCommand+/ 5x   ,     $L Fpack://application:,,,/NextBO.Wpf;component/Resources/PrintPreview.svg?�0 5y   ,     $L Fpack://application:,,,/NextBO.Wpf;component/Resources/PrintPreview.svg?�  5z      $, Exportar 6,   $
. XLSX��5|   ,   - 5{   ,   �� *ExportGridCommand+/ 5}   ,     $T Npack://application:,,,/NextBO.Wpf;component/Resources/Controls/ExportToXLS.svg?�0 5~   ,     $T Npack://application:,,,/NextBO.Wpf;component/Resources/Controls/ExportToXLS.svg?�  5      $, Exportar 6,   $	. PDF��5�   ,   - 5�   ,   �� *ExportGridCommand+/ 5�   ,     $T Npack://application:,,,/NextBO.Wpf;component/Resources/Controls/ExportToPDF.svg?�0 5�   ,     $T Npack://application:,,,/NextBO.Wpf;component/Resources/Controls/ExportToXLS.svg?�5�      5�      5�      5�      .  (DevExpress.Xpf.Docking.DockLayoutManager  5�   
   1   
LayoutRoot.1 5�      (  "DevExpress.Xpf.Docking.LayoutGroup  2   Orientation2 6   �� *ViewSettings.Orientation+3   Items.3 5�      (   "DevExpress.Xpf.Docking.LayoutPanel   $4    HorizontalScrollBarVisibility$4 Disabled=�6#   "5    VerticalScrollBarVisibility$5 Disabled=�6L   +!  %DevExpress.Xpf.Docking.BaseLayoutItem6 !  AllowSizing$
6 True��6s   7 !  	ItemWidth$7 * �6�   8 !  
ItemHeight$8 * �6�   9 !  
AllowClose$9 False��6�   : !  	AllowDrag$: False��6�   ; !  
AllowFloat$; False��6�   < !  	AllowHide$< False��6�   = !  ShowCaption$= False��6�   ("  "DevExpress.Xpf.Docking.ContentItem> "  Content.> 5�      0#  *DevExpress.Xpf.LayoutControl.LayoutControl#  .$  (DevExpress.Xpf.LayoutControl.LayoutGroup? $  Orientation$? Vertical=�6)   .+�5�      $  .+�5�      -%  'DevExpress.Xpf.LayoutControl.LayoutItem%  @ %  Label$@ Fecha inicio��6.   $��	10,10,0,0q�6C   A %  AddColonToLabel$
A True��6V   $
��Left=�6m   B %  Content.B 5�   "   %&  DevExpress.Xpf.Editors.DateEdit&  $��25��6/   C &  ShowClearButton$C False��6m   %'  DevExpress.Xpf.Editors.BaseEditD '  	EditValueD 6;   �� $ 	StartDate�E �� Mode$E TwoWay=�6m   5�      %  5�      $@ 	Fecha fin��6.   $��	10,10,0,0q�6@   $
A True��6S   $
��Left=�6j   .B 5�   "   &  $��25��6/   $C False��6k   D 6;   �� $ EndDate�$E TwoWay=�6k   5�      &(   DevExpress.Xpf.Core.SimpleButton(  5�      $��25��6.   $��	10,10,0,5q�6:   $��Filtrar��6M   $
��Left=�6�   F (  GlyphF 6_   *)  $DevExpress.Xpf.Core.DXImageExtension)  G )  Image1*  +DevExpress.Xpf.Core.Native.DXImageConverter$G Filter_16x16.png*   5�   "   '+  !DevExpress.Mvvm.UI.EventToCommand+  5�   &   H +  PassEventArgsToCommandH True6<   �,  �DevExpress.Mvvm.UI.Interactivity.EventTriggerBase`1[[System.Windows.DependencyObject, WindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35]]I ,  	EventName$I Click��5�   <   +-  %DevExpress.Mvvm.UI.EventToCommandBaseJ -  CommandJ 5�   <   �� *RefreshPageCommand+K +  EventArgsConverterK 5�   *   5.  /DevExpress.Xpf.Core.EventArgsToDataRowConverter.  5�   .   5�   '   5�      (  5�      $��25��6.   $��	10,10,0,5q�6:   $��Cancelar Filtro��6M   $
��Left=�6g     5�   "   +  5�   &   H True6<   $I Click��5�   <   J 5�   <   �� *CancelFilterCommand+K 5�   *   .  5�   .   5�   '   5�      5�      $  5�      .+�5�        -   5        L  Name$L gridControl��5�   .   $

 True��5�   2   M   IsFilterEnabled$M False��6D   N   AutoExpandAllGroups$
N True��5�   2    5�   2   �� *	Documents+O   SelectedItemO 5�   2   �� *SelectedEntity+P   ShowLoadingPanelP 5�   2   �� *	IsLoading+Q   FilterStringQ 5�   M   �� *DefaultFilter+$E OneWay=� 5�   "     5�   &   -   5        $��ReDeliveryTableView��5�   4   $ False��6�   %R 	  SearchPanelHorizontalAlignment	R Right5�   0   S 	  NavigationStyle$	S Row=�6W   %T   AllowConditionalFormattingMenu$
T True��6m   U   AllowPerPixelScrolling$
U True��5�   0    V 	  ShowSearchPanelFindButton$
V True��6N   W 	  ShowSearchPanelMode$W Always=�6o   X   	AutoWidth$
X True��6�   Y   GroupSummaryDisplayMode$Y AlignByColumns=�5�   0   $Z   HorizontalScrollbarVisibility$Z Hidden=�6Y   $ False��6�   [ 	  SearchPanelNullText$![ Buscar Reentrega (Ctrl + F)��5�   0   \ 	  ColumnFilterPopupMode$\ Excel=�6b   ]   AllowMasterDetail] 5�   O   �� *ViewSettings.ViewKind+ ^ 	  RowCellMenuCustomizations^ 5�   *     5�   .   $, Refresh 6@   - 6R   �� *!View.DataContext.RefreshCommand+0 6�     $J Dpack://application:,,,/NextBO.Wpf;component/Resources/ChangeView.svg?�5�   '    5�   "     5�   &   $
 True��65   $ Task.Status��6D   $ Estado de Entrega��6\   $ 40 6�   $
 True��6�   $ Center=�6�    6~   �� $ Task.Status�# [  5�   *   �� 5�   .   .R�5�   2     $
��None=�6�    6=     	 16,16$O Ipack://application:,,,/NextBO.Wpf;component/Resources/Orders/Shipment.svg?�6�   5�   /    5�   *   �� 5�   .   .R�5�   2     $
��None=�6�    6=   �� $ Value�# [ 6�   5�   /   5�   '     5�   &   $
 True��65   $ CreatedDate��6D   $ Fecha del documento 6\   _   	SortOrder] YDevExpress.Data.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a9/  3DevExpress.Data.Design.ColumnSortOrderTypeConverter$_ 	Ascending/ 6y     5�   &   $
 True��65   $ DocNum��6D   $ Numero de documento 6W     5�   &   $ DocumentDetail.Count��65   $ Cantidad entregada 6V     5�   &   $ 
ClientName��65   $ Nombre del cliente 6L     5�   &   $
 True��65   $ AddressCustomer��6D   $ 	Direccion 6`     5�   &   $
 True��65   $ Task.DeliveredDate��6D   $ Fecha de entrega 6c     5�   &   $
 True��65   $ 
DriverName��6D   $ Nombre Del Piloto 6[   `   Visible$` False��6v     5�   &   $
 True��65   $ Id��6D   $ ID Document 6S   $` False��6h     5�   &   $
 True��65   $ 
MaterialId��6D   $ Id Material 6[   $` False��6p     5�   &   $
 True��65   $ MaterialName��6D   $ Nombre del Material 6]   $` False��6z     5�   &   $
 True��65   $	 Qty��6D   $ Cantidad 6T   $` False��6f     5�   &   $
 True��65   $ TaskId��6D   $ Id Task 6W   $` False��6h     5�   &   $
 True��65   $ LineNum��6D   $ NUmero de Linea 6X   $` False��6q     5�   &   $
 True��65   $ Status��6D   $ Estado 6W   $` False��6g     5�   &   $
 True��65   $ VehicleDescription��6D   $ Descripcion del Vehiculo 6c   $` False��6�     5�   &   $
 True��65   $ Reason��6D   $ Razon De No Entrega 6W   $` False��6t   a   DetailDescriptora 5�   "   10 
 +DevExpress.Xpf.Grid.ContentDetailDescriptor0  5�   &   .1 
 (DevExpress.Xpf.Grid.DetailDescriptorBaseb 1  ContentTemplate#b [ 6B   5�      5�      5�      5�      5�      5�      5�      5�      