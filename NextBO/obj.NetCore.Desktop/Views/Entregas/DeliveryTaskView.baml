   M S B A M L   `   `   `  ����E  ANextBO.Wpf, Version=1.0.1.0, Culture=neutral, PublicKeyToken=null'clr-namespace:NextBO.Wpf
NextBO.Wpf  5   	   9!clr-namespace:NextBO.Wpf.ServicesNextBO.Wpf.Services  5   	   =#clr-namespace:NextBO.Wpf.ViewModelsNextBO.Wpf.ViewModels  5   	   =#clr-namespace:NextBO.Wpf.ViewModelsNextBO.Wpf.ViewModels  5   	   '    !NextBO.Wpf.Views.DeliveryTaskView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35h dDevExpress.Xpf.TypedStyles.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aR NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/netfx/2009/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089<x,http://schemas.microsoft.com/winfx/2006/xaml      5   	   Bd2http://schemas.microsoft.com/expression/blend/2008      5   	   a ]DevExpress.Xpf.Core.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49al hDevExpress.Xpf.Core.v20.2.Extensions, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a?dx2http://schemas.devexpress.com/winfx/2008/xaml/core    5   	   >dxb2http://schemas.devexpress.com/winfx/2008/xaml/bars   5   	   Adxe5http://schemas.devexpress.com/winfx/2008/xaml/editors   5   	   l hDevExpress.Xpf.Grid.v20.2.Extensions, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aa	 ]DevExpress.Xpf.Grid.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49af
 bDevExpress.Xpf.Grid.v20.2.Core, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aBdxg2http://schemas.devexpress.com/winfx/2008/xaml/grid  	 
  5   	   g cDevExpress.Mvvm.v20.2.ViewModel, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a] YDevExpress.Mvvm.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aEdxmvvm2http://schemas.devexpress.com/winfx/2008/xaml/mvvm     5	   	   c _DevExpress.Xpf.Ribbon.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aBdxr4http://schemas.devexpress.com/winfx/2008/xaml/ribbon    5
   	   (localclr-namespace:NextBO.Wpf    5   	   Hmc;http://schemas.openxmlformats.org/markup-compatibility/2006    5   	   4services!clr-namespace:NextBO.Wpf.Services    5   	   3devAv#clr-namespace:NextBO.Wpf.ViewModels    5   	   7	viewmodel#clr-namespace:NextBO.Wpf.ViewModels    5   	   j fDevExpress.Xpf.LayoutControl.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aHdxlc;http://schemas.devexpress.com/winfx/2008/xaml/layoutcontrol   5   	   e aDevExpress.Xpf.Controls.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aEdxwui7http://schemas.devexpress.com/winfx/2008/xaml/windowsui   5   	   ` \DevExpress.Xpf.Map.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a=dxm1http://schemas.devexpress.com/winfx/2008/xaml/map   5   	     � DataContext  5   	   1  +DevExpress.Mvvm.UI.ViewModelSourceExtension  *viewmodel:TaskViewModel+ � 	Resources 5       �� MergedDictionaries �� Source!   NextBO.Wpf.PictureConverter   PictureConverter&    NextBO.Wpf.IntToBooleanConverter  IntToBooleanConverter  TemplateImageDelivery �Name&   DevExpress.Xpf.Editors.ImageEdit   Stretch   Source   MenuTemplate �� Orientation4  .DevExpress.Xpf.Editors.ImageEditSaveToolButton�� 5   
    5      �� 5      $D >pack://application:,,,/NextBO.Wpf;component/Themes/Common.xaml?�6%   %�  &	        &	      &	 &       5      6%     5      6*   �� 5      .R�5      � $ Grid_Content��6   $
��5000��6-   .+�5      �� $��Center=�6   $��Center=�6:   
�������
���   �._�5!        $ Uniform=�6<    6(   ��  5"      �� 5#   "   .R�5$   &   �� $ 
Horizontal=�61   .+�5%   *     5&   '   5'   #   5)      5*      5+      5,      5.      2  ,DevExpress.Mvvm.UI.Interactivity.Interaction	   	Behaviors	 50      '  !DevExpress.Mvvm.UI.EventToCommand  51   
   �  �DevExpress.Mvvm.UI.Interactivity.EventTriggerBase`1[[System.Windows.DependencyObject, WindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35]]
   	EventName$
 Loaded��6    +	  %DevExpress.Mvvm.UI.EventToCommandBase 	  Command 63   �� *OnLoadedCommand+6Y   +
   %NextBO.Wpf.Services.ExportGridService
  52   
    
  View 6&   %  System.Windows.Markup.Reference  *DeliveryTableView+-  'DevExpress.Xpf.Core.DXMessageBoxService  53   
   .  (DevExpress.Mvvm.UI.SaveFileDialogService  54   
   3  -DevExpress.Xpf.Core.WindowedDocumentUIService  55   
      DocumentShowMode$ Dialog=�6'      
WindowType&   DevExpress.Xpf.Core.ThemedWindow"  56   '      WindowStyle 57      �� 58       �� 
TargetType"  6   .�59      �� -  'DevExpress.Xpf.Core.ScrollBarExtensions �� Property �@ ScrollBarMode �� Value$ TouchOverlap=�5:      �� 5;       �@ ShowIcon$ False��5<      �� 5=       � ��$
 1154��5>      �� 5?       � ��$	 740��5@      5A      5C      .��5F      ]� .+�5G   
   )  #DevExpress.Xpf.Ribbon.RibbonControl  $	��Top=�5H         RibbonStyle$ 
Office2019=�5I      $y�Visible=�5J         ShowApplicationButton$ False��5K         Items. 5L      5  /DevExpress.Xpf.Ribbon.RibbonDefaultPageCategory  2  ,DevExpress.Xpf.Ribbon.RibbonPageCategoryBase   Caption$ defaultCategory��6,      Pages. 5M      &   DevExpress.Xpf.Ribbon.RibbonPage     Caption)  #DevExpress.Xpf.Core.ObjectConverter$
 Home 6!      Groups. 5N      +  %DevExpress.Xpf.Ribbon.RibbonPageGroup     Caption$ Acciones��6*      Items. 5O      '  !DevExpress.Xpf.Bars.BarButtonItem  !  DevExpress.Xpf.Bars.BarItem   Content$ Guardar 6,      Command 6>   �� *SaveCommand+   Glyph 5P   !   1  +DevExpress.Xpf.Core.SvgImageSourceExtension  
   Uri$D >pack://application:,,,/NextBO.Wpf;component/Resources/Save.svg?�    
LargeGlyph  5Q   !     $D >pack://application:,,,/NextBO.Wpf;component/Resources/Save.svg?�  5R      $ Guardar y Cerrar 6,    6G   �� *SaveAndCloseCommand+ 5S   !     $L Fpack://application:,,,/NextBO.Wpf;component/Resources/SaveAndClose.svg?�  5T   !     $L Fpack://application:,,,/NextBO.Wpf;component/Resources/SaveAndClose.svg?�  5U      $ Cerrar 5W       5V      �� *CloseCommand+ 5X        $E ?pack://application:,,,/NextBO.Wpf;component/Resources/Close.svg?�  5Y        $E ?pack://application:,,,/NextBO.Wpf;component/Resources/Close.svg?�5Z        5[      $ Exportar��6*   . 5\        $ Previsualizar 5^       5]      �� *ShowPreviewCommand+ 5_        $L Fpack://application:,,,/NextBO.Wpf;component/Resources/PrintPreview.svg?�  5`        $L Fpack://application:,,,/NextBO.Wpf;component/Resources/PrintPreview.svg?�  5a      !   CommandParameter$
! XLSX��5c      $ Exportar 5d       5b      �� *ExportGridCommand+ 5e        $T Npack://application:,,,/NextBO.Wpf;component/Resources/Controls/ExportToXLS.svg?�  5f        $T Npack://application:,,,/NextBO.Wpf;component/Resources/Controls/ExportToXLS.svg?�  5g      $	! PDF��5i      $ Exportar 5j       5h      �� *ExportGridCommand+ 5k        $T Npack://application:,,,/NextBO.Wpf;component/Resources/Controls/ExportToXLS.svg?�  5l        $T Npack://application:,,,/NextBO.Wpf;component/Resources/Controls/ExportToPDF.svg?�5m        5n      $ Comprobante��6*   . 5o        $ Enviar comprobante 5r       5p      �� *SendEmailCommand+! 5q      �� *Entity.CopyEmail+ 5s        $I Cpack://application:,,,/NextBO.Wpf;component/Resources/MailMerge.svg?�  5t        $I Cpack://application:,,,/NextBO.Wpf;component/Resources/MailMerge.svg?�5u        5v      . 5w        $ Generar Reporte 6,    5x   ,   �� *PrintTaskCommand+  5y   ,     $F @pack://application:,,,/NextBO.Wpf;component/Resources/Report.svg?� 5z   ,     $F @pack://application:,,,/NextBO.Wpf;component/Resources/Report.svg?�5{      5|      5}      5~      0  *DevExpress.Xpf.LayoutControl.LayoutControl  5�   
   -   5        "  Name$" layoutControl��5�   �   .  (DevExpress.Xpf.LayoutControl.LayoutGroup#   Orientation$# Vertical=�6   $��11(�64   $��Stretch=�6M   $   StretchContentVertically$
$ True��6i   	 5�        5�      % �� SourceUpdatedEvent&   Event#& Z% 6(    6V   �� *UpdateCommand+.+�5�        -   5        '  Name$' entityGroup��5�   8   $# 
Horizontal=�6   .+�5�        $# 
Horizontal=�6#   $��	0,25,0,25q�6<   ( J� RenderTransformOrigin$( 0.518,0.477&�6O   .+�5�        $# Vertical=�6)   .+�5�      -  'DevExpress.Xpf.LayoutControl.LayoutItem  )   Label$) Cliente��6.   $��10,0,0,0q�6>   *   AddColonToLabel$
* True��6P   +   Content.+ 5�      %  DevExpress.Xpf.Editors.TextEdit  ${�False��6+   %  DevExpress.Xpf.Editors.BaseEdit,   	EditValue, 6=   �� *Entity.ClientName+- �� UpdateSourceTrigger$- PropertyChanged=�. �� ValidatesOnDataErrors$
. True��/ �� NotifyOnSourceUpdated$
/ True��5�        5�      $) Fecha/Hora estimada��6.   $��10,0,0,0q�6K   $
* True��6]   .+ 5�   "     ${�False��6/   0   Mask$0 dd/MM/yyyy hh:mm:ss tt��5�   +   1   MaskUseAsDisplayFormat$
1 True��5�   +   , 5�   A   �� *!Entity.EstimatedDateTimeArrival+$- PropertyChanged=�$
. True��$
/ True��5�   +   5�        5�      $) Piloto��6.   $��10,0,0,0q�6>   $
* True��6P   .+ 5�   "     ${�False��6/   , 6A   �� *Entity.DriverName+$- PropertyChanged=�$
. True��$
/ True��5�        5�      $) Vehiculo��6.   $��10,0,0,0q�6@   $
* True��6R   .+ 5�   "     ${�False��6/   , 6A   �� *Entity.VehicleDescription+$- PropertyChanged=�$
. True��$
/ True��5�        5�      $) Correo Electronico��6.   $��10,0,0,0q�6J   $
* True��6\   .+ 5�   "     ${�False��6/   , 6A   �� *Entity.Email+$- PropertyChanged=�$
. True��$
/ True��5�        5�      $) Telefono��6.   $��10,0,0,0q�6@   $
* True��6R   .+ 5�   "     ${�False��6/   , 6A   �� *Entity.Telephone+$- PropertyChanged=�$
. True��$
/ True��5�        5�      $) Copia Correo Electronico��6.   $��10,0,0,0q�6P   $
* True��6b   .+ 5�        2   MaskType$2 RegEx=�6+   $/0 )(\w|[\.\-])+@[a-zA-Z0-9.-]+.[a-zA-Z]{2,4}��5�   +   3   ValidateOnTextInput$
3 True��5�   +   , 5�   -   �� *Entity.CopyEmail+$- PropertyChanged=�$
. True��$
/ True��5�        5�      $
��5000��6.   $��Stretch=�6?   $��5,13,0,0q�6[   .+ 5�      � .+�5�   "   % 	 DevExpress.Xpf.Grid.GridControl  -   5        4  Name$4 tableViewGridControl��5�   3   5   AutoExpandAllGroups$
5 True��5�   )   )  
 #DevExpress.Xpf.Grid.DataControlBase6    ClipboardCopyMode$6 ExcludeHeader=�5�   )   #7    EnableSmartColumnsGeneration$
7 True��5�   )   8    
ShowBorder$
8 True��5�   )   9    ItemsSource9 5�   )   �� *ListDetailCurrentTask+	 5�   &   '!   !NextBO.Wpf.GridSaveLayoutBehavior!  5�   *   -   5        SerializeHelper��: !  FileName$: DeliveryTableView.xml��5�   `   ;   View; 5�   &   #" 	 DevExpress.Xpf.Grid.TableView"  5�   *   -   5        $��DeliveryTableView��5�   4   &# 
  DevExpress.Xpf.Grid.DataViewBase< #  AllowEditing$< False��5�   8   = "  AllowPerPixelScrolling$
= True��5�   4   > "  	AutoWidth$
> True��5�   4   ? #  ColumnFilterPopupMode$? Excel=�5�   4   %@ #  SearchPanelHorizontalAlignment	@ Right5�   4   A #  SearchPanelNullText$"A Buscar documentos (Ctrl + F)��5�   4   B "  ShowAutoFilterRow$
B True��5�   4   "C "  ShowCriteriaInAutoFilterRow$
C True��5�   4   D #  ShowSearchPanelMode$D Always=�5�   4   5�   +   E   ColumnsE 5�   &   $$ 	 DevExpress.Xpf.Grid.GridColumn$  5�   *   $% 
 DevExpress.Xpf.Grid.ColumnBaseF %  IsSmart$
F True��69   $& 
 DevExpress.Xpf.Grid.BaseColumnG &  Header$G 	Documento 5�   5   H %  	FieldName$H Document.DocNum��5�   5   $  5�   *   $
F True��69   $G Codigo Material 5�   5   $H 
MaterialId��5�   5   $  5�   *   $
F True��69   $G Nombre Material 5�   5   $H MaterialName��5�   5   $  5�   *   $
F True��69   $G Cantidad 5�   5   $	H Qty��5�   5   $  5�   *   $
F True��69   $G Cantidad Entregada 5�   5   $H QtyDelivered��5�   5   $  5�   *   $
F True��69   $G Línea 5�   5   $H LineNum��5�   5   $  5�   *   $
F True��69   $G Estado 5�   5   $H Status��5�   9   5�   #   5�      5�      5�        5�      .+�5�      &'   DevExpress.Xpf.Core.DXTabControl'  .@�5�   "   #(  DevExpress.Xpf.Core.DXTabItem(  �)  �DevExpress.Xpf.Core.Native.HeaderedSelectorItemBase`2[[DevExpress.Xpf.Core.DXTabControl, DevExpress.Xpf.Core.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a],[DevExpress.Xpf.Core.DXTabItem, DevExpress.Xpf.Core.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a]]I )  Header$I Imagenes��6/   .��5�   &     -   5        J  Name$J ContentImageDelivery��5�   6   $��Stretch=�6T   $��Center=�6p   $
��5000��6�   .+ 5�   &   '*  !DevExpress.Xpf.WindowsUI.FlipView*  #��[ 6f   ��66   �� *CollectionBitmapImages+6f   5�   '   5�   #   (  5�      $I Firma��6+   .��5�   "     -   5        $J ContentImageFirm��5�   2   $��Stretch=�6L   $��Center=�6h   $
��5000��6�   .+ 5�   &   *  #��[ 6c   ��66   �� *CollectionFirmImage+6c   5�   #   5�      (  5�      $
I Mapa��6+   .��5�   &   #+  DevExpress.Xpf.Map.MapControl+  -   5        $��
mapControl��5�   M   K +  EnableScrolling$
K True��5�   5   L +  EnableZooming$
L True��6L   M +  	ZoomLevel$M 12Q�6a   $	��400��5�   5   $��0q�6B   N +  CenterPointN 5�   5   �� *CenterPoint+O +  CoordinatesPanelOptionsO 5�   *   0,  *DevExpress.Xpf.Map.CoordinatesPanelOptions,  5�   .   *-  $DevExpress.Xpf.Map.MapElementOptionsP -  Visible$P False��6J   Q +  ScrollButtonsOptionsQ 5�   *   -.  'DevExpress.Xpf.Map.ScrollButtonsOptions.  5�   .   $P False��6G   R +  ScalePanelOptionsR 5�   *   */  $DevExpress.Xpf.Map.ScalePanelOptions/  5�   .   S -  HorizontalAlignment$S Center=�6D   T -  Margin$	T -10q�6a   U /  ShowMilesScale$U False��6n   V -  VerticalAlignment$V Bottom=�6�   W +  ZoomTrackbarOptionsW 5�   *   ,0  &DevExpress.Xpf.Map.ZoomTrackbarOptions0  5�   .   $S Center=�6F   $T 0q�6c   X 0  Orientation$X 
Horizontal=�6n   $V Bottom=�6�   Y +  Layers.Y 5�   *   (1  "DevExpress.Xpf.Map.ImageTilesLayer1  #2  DevExpress.Xpf.Map.ImageLayerZ 2  DataProvider.Z 5�   .   23  ,DevExpress.Xpf.Map.OpenStreetMapDataProvider3  5�   +   2  5�   *   .Z 5�   .   ,4  &DevExpress.Xpf.Map.BingMapDataProvider4  [ 4  Kind$
[ Road=�6F   ,5   &NextBO.Wpf.ViewModels.MapViewModelBase\ 5  
WpfBingKey] 4  BingKey#] Z\ 6R   5�   +   $6  DevExpress.Xpf.Map.VectorLayer6  5�   &   ^ 6  Data.^ 5�   *   .7  (DevExpress.Xpf.Map.ListSourceDataAdapter7  .8  (DevExpress.Xpf.Map.DataSourceAdapterBase_ 8  
DataSource_ 6D   �� *PointsMapDelivery+` 7  Mappings` 5�   .   +9  %DevExpress.Xpf.Map.MapItemMappingInfo9  5�   2   0:  *DevExpress.Xpf.Map.MapPointMappingInfoBasea :  Latitude$a Latitude��6I   b :  	Longitude$b 	Longitude��6]   c 7  ItemSettingsc 5  .   +;  %DevExpress.Xpf.Map.MapPushpinSettings;  5  2   5  3   5  +   5  '   5
  '   5  #   5     5     5     5     5     5     5     