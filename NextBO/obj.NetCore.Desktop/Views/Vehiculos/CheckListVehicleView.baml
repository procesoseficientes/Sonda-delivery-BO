   M S B A M L   `   `   `  ����E  ANextBO.Wpf, Version=1.0.1.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:NextBO.Wpf.ServicesNextBO.Wpf.Services  5      'clr-namespace:NextBO.Wpf
NextBO.Wpf  5      +    %NextBO.Wpf.Views.CheckListVehicleView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35h dDevExpress.Xpf.TypedStyles.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aR NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/netfx/2009/xaml/presentation     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089<x,http://schemas.microsoft.com/winfx/2006/xaml      5      a ]DevExpress.Xpf.Core.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49al hDevExpress.Xpf.Core.v20.2.Extensions, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a?dx2http://schemas.devexpress.com/winfx/2008/xaml/core    5      Hmc;http://schemas.openxmlformats.org/markup-compatibility/2006    5      >dxb2http://schemas.devexpress.com/winfx/2008/xaml/bars   5      Adxe5http://schemas.devexpress.com/winfx/2008/xaml/editors   5      l hDevExpress.Xpf.Grid.v20.2.Extensions, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aa	 ]DevExpress.Xpf.Grid.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49af
 bDevExpress.Xpf.Grid.v20.2.Core, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aBdxg2http://schemas.devexpress.com/winfx/2008/xaml/grid  	 
  5	      c _DevExpress.Xpf.Ribbon.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aBdxr4http://schemas.devexpress.com/winfx/2008/xaml/ribbon    5
      g cDevExpress.Mvvm.v20.2.ViewModel, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a] YDevExpress.Mvvm.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aEdxmvvm2http://schemas.devexpress.com/winfx/2008/xaml/mvvm     5      6services!clr-namespace:NextBO.Wpf.Services     5      *localclr-namespace:NextBO.Wpf     5      j fDevExpress.Xpf.LayoutControl.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aHdxlc;http://schemas.devexpress.com/winfx/2008/xaml/layoutcontrol   5      e aDevExpress.Xpf.Controls.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aEdxwui7http://schemas.devexpress.com/winfx/2008/xaml/windowsui   5        � 	Resources  5       �� MergedDictionaries �� Source!   NextBO.Wpf.PictureConverter   PictureConverter&    NextBO.Wpf.IntToBooleanConverter  IntToBooleanConverter0  *DevExpress.Mvvm.UI.ObjectToObjectConverter  IntToHighMediumLowConverter
   Map   DevExpress.Mvvm.UI.MapItem   Source   Target  ImagesOfCheck&   DevExpress.Xpf.Editors.ImageEdit   Stretch   ShowMenuMode   Source	 �� 	Converter
   MenuTemplate �� Orientation4  .DevExpress.Xpf.Editors.ImageEditSaveToolButton�� 5   
    5      �� 5      $D >pack://application:,,,/NextBO.Wpf;component/Themes/Common.xaml?�6%   %  &	        &	      &	 &     &	 �     7     5      6%     5      6*     5      . 5        $ 0��6!   $
 Bajo��5   !     5      $ 1��6!   $ Medio��5   !     5      $ 2��6!   $
 Alto��5    !   5!      �� 5"      .R�5#        $��ImagesCheckList��6    $��1q�67   $ Uniform=�6�   $ Hover=�6�    6B   �� *Image+8	   ��6�   Z� 
 5$      �� 5%      .R�5&      �� $ 
Horizontal=�6)   .+�5'   "     5(      5)      5+      5,      5-      2  ,DevExpress.Mvvm.UI.Interactivity.Interaction   	Behaviors 5/      +   %NextBO.Wpf.Services.ExportGridService  50   
      View 6%   %	  System.Windows.Markup.Reference	  *CheckListVehicleTableView+-
  'DevExpress.Xpf.Core.DXMessageBoxService
  51   
   .  (DevExpress.Mvvm.UI.SaveFileDialogService  52   
   .��55      ]� .+�56   
   )  #DevExpress.Xpf.Ribbon.RibbonControl  -   5          Name$ ribbonControl��56         RibbonStyle$ 
Office2019=�63   $	��Top=�6L      ShowApplicationButton$ False��6a      Items. 57      5  /DevExpress.Xpf.Ribbon.RibbonDefaultPageCategory  2  ,DevExpress.Xpf.Ribbon.RibbonPageCategoryBase   Caption$ defaultCategory��6,      Pages. 58      &   DevExpress.Xpf.Ribbon.RibbonPage     Caption)  #DevExpress.Xpf.Core.ObjectConverter$
 Home 6!      Groups. 59      +  %DevExpress.Xpf.Ribbon.RibbonPageGroup     Caption$ Exportar��6*      Items. 5:      '  !DevExpress.Xpf.Bars.BarButtonItem  !  DevExpress.Xpf.Bars.BarItem   Content$ Previsualizar 6,      Command 5;   ,   �� *ShowPreviewCommand+   
LargeGlyph 5<   ,   1  +DevExpress.Xpf.Core.SvgImageSourceExtension  
   Uri$L Fpack://application:,,,/NextBO.Wpf;component/Resources/PrintPreview.svg?�   Glyph 5=   ,     $L Fpack://application:,,,/NextBO.Wpf;component/Resources/PrintPreview.svg?�  5>      $ Exportar 6,      CommandParameter$
 XLSX��5@   ,    5?   ,   �� *ExportGridCommand+ 5A   ,     $T Npack://application:,,,/NextBO.Wpf;component/Resources/Controls/ExportToXLS.svg?� 5B   ,     $T Npack://application:,,,/NextBO.Wpf;component/Resources/Controls/ExportToXLS.svg?�  5C      $ Exportar 6,   $	 PDF��5E   ,    5D   ,   �� *ExportGridCommand+ 5F   ,     $T Npack://application:,,,/NextBO.Wpf;component/Resources/Controls/ExportToPDF.svg?� 5G   ,     $T Npack://application:,,,/NextBO.Wpf;component/Resources/Controls/ExportToXLS.svg?�5H      5I      5J      5K      0  *DevExpress.Xpf.LayoutControl.LayoutControl  5M   
   -   5          Name$ layoutControl��5M   �   .  (DevExpress.Xpf.LayoutControl.LayoutGroup   Orientation$ Vertical=�6   $��11(�64   $��Stretch=�6M       StretchContentVertically$
  True��6i   .+�5N        $��50��6   $
��left=�6+   .+�5O      -  'DevExpress.Xpf.LayoutControl.LayoutItem  !   Label$! Fecha inicio��6"   $��	10,10,0,0q�67   "   AddColonToLabel$
" True��6J   $
��Left=�6a   #   Content.# 5P      %  DevExpress.Xpf.Editors.DateEdit  $��25��6#   $   ShowClearButton$$ False��6a   %  DevExpress.Xpf.Editors.BaseEdit%   	EditValue% 6/   �� & �� Path$& 	StartDate�' �� Mode$' TwoWay=�6a   5Q        5R      $! 	Fecha Fin��6"   $��	10,10,0,0q�64   $
" True��6G   $
��Left=�6^   .# 5S        $��25��6#   $$ False��6_   % 6/   �� $& EndDate�$' TwoWay=�6_   5T        5U      $! Piloto��6"   $��25��61   $��	10,10,0,0q�6=   $
��Left=�6P   $	��200��6k   .# 5V      + 	 %DevExpress.Xpf.Grid.LookUp.LookUpEdit  +  %DevExpress.Xpf.Editors.LookUpEditBase(   DisplayMember$
( Name��6%   )   ValueMember$) Id��5W   %   *   AutoPopulateColumns$* False��5X   %   +   AutoComplete$
+ True��5Y   %   ,   ValidateOnTextInput$
, True��5\   %   -   IncrementalFiltering- True5]   %   .   ImmediatePopup. True5^   %   /   IsPopupAutoWidth$/ False��5_   %   $	��Top=�5`   %   0   ItemsSource0 5Z   %   �� *LookUpPilot+% 5[   %   �� $& PilotId�$' TwoWay=�*  $DevExpress.Xpf.Editors.PopupBaseEdit1   PopupContentTemplate1 5a      �� 5b      .R�5c   "   % 	 DevExpress.Xpf.Grid.GridControl  2  Name$2 PART_GridControl��62   3   Columns3 5d   &   $ 	 DevExpress.Xpf.Grid.GridColumn  5e   *   $ 
 DevExpress.Xpf.Grid.ColumnBase4   	FieldName$4 Pilot.Id��69     5f   *   $
4 Name��69     5g   *   $4 Pilot.LicenseNumber��69   5   View5 5i   &   #  	 DevExpress.Xpf.Grid.TableView   5j   *   6    	AutoWidth$
6 True��68   5l   #   5m      5o      5p        5q      $! Vehiculo��6"   $��25��63   $��	10,10,0,0q�6?   $
��Left=�6R   $	��200��6m   .# 5r        $( Brand��6%   $) Id��5s   %   $* False��5t   %   $
+ True��5u   %   $
, True��5x   %   - True5y   %   . True5z   %   $/ False��5{   %   $	��Top=�5|   %   0 5v   %   �� *LookUpVehicle+% 5w   %   �� $& 	VehicleId�$' TwoWay=�1 5}      �� 5~      .R�5   "     $2 PART_GridControl��62   3 5�   &     5�   *   $4 Id��69     5�   *   $4 PlateNumber��69     5�   *   $4 Brand��69     5�   *   $4 Model��69     5�   *   $4 Color��69   5 5�   &      5�   *   $
6 True��68   5�   #   5�      5�      5�      &!   DevExpress.Xpf.Core.SimpleButton!  5�      $��25��6"   $��	10,-5,0,5q�6.   $��Filtrar��6A   $
��Left=�6   7 !  Glyph7 6S   *"  $DevExpress.Xpf.Core.DXImageExtension"  8 "  Image1#  +DevExpress.Xpf.Core.Native.DXImageConverter$8 Filter_16x16.png#  5�      '$  !DevExpress.Mvvm.UI.EventToCommand$  5�      9 $  PassEventArgsToCommand9 True60   �%  �DevExpress.Mvvm.UI.Interactivity.EventTriggerBase`1[[System.Windows.DependencyObject, WindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35]]: %  	EventName$: Click��5�   <   +&  %DevExpress.Mvvm.UI.EventToCommandBase; &  Command; 5�   <   �� *RefreshCommand+< $  EventArgsConverter< 5�      5'  /DevExpress.Xpf.Core.EventArgsToDataRowConverter'  5�   "   5�      5�      5�        5�      -   5        =  Name$= entityGroup��5�   8   $ 
Horizontal=�6   .+�5�        $	��800��6T    6#   �� *ViewSettings.Orientation+.+�5�      � .+�5�        -   5        $2 tableViewGridControl��5�   *   )( 
 #DevExpress.Xpf.Grid.DataControlBase> (  
ShowBorder$
> True��5�   &   ?   AutoExpandAllGroups$
? True��5�   &   @ (  ClipboardCopyMode$@ ExcludeHeader=�5�   &   #A (  EnableSmartColumnsGeneration$
A True��5�   &   B (  ItemsSourceB 5�   &   �� *
Entities+C (  SelectedItemC 5�   &   �� *TableViewSelectedEntity+ 5�      ')   !NextBO.Wpf.GridSaveLayoutBehavior)  5�   "   -   5        SerializeHelper��D )  FileName$#D CheckListVehicleTableView.xml��5�   ;   5 5�         5�   "   -   5        $��CheckListVehicleTableView��5�   0   E    AllowPerPixelScrolling$
E True��5�       &* 
  DevExpress.Xpf.Grid.DataViewBaseF *  AllowEditing$F False��5�       G *  ShowSearchPanelMode$G Always=�5�       $
6 True��5�       %H *  SearchPanelHorizontalAlignment	H Right5�       I *  SearchPanelNullText$I Buscar chequeo (Ctrl + F)��5�       J    ShowAutoFilterRow$
J True��5�       "K    ShowCriteriaInAutoFilterRow$
K True��5�       L *  ColumnFilterPopupMode$L Excel=�5�       M    FormatConditionsM 5�   &   )+ 
 #DevExpress.Xpf.Grid.FormatCondition+  5�   *   -, 
 'DevExpress.Xpf.Grid.FormatConditionBaseN ,  	FieldName$N 
WaterLevel��6>   O +  	ValueRule$O Equal=�5�   >   P +  Value1$P 0��5�   >   Q ,  PredefinedFormatName$!Q LightRedFillWithDarkRedText��5�   >   +  5�   *   $N 
WaterLevel��6>   $O Equal=�5�   >   $P 1��5�   >   $"Q YellowFillWithDarkYellowText��5�   >   +  5�   *   $N 
WaterLevel��6>   $O Equal=�5�   >   $P 2��5�   >   $ Q GreenFillWithDarkGreenText��5�   >   +  5�   *   $N OilLevel��6>   $O Equal=�5�   >   $P 0��5�   >   $!Q LightRedFillWithDarkRedText��5�   >   +  5�   *   $N OilLevel��6>   $O Equal=�5�   >   $P 1��5�   >   $"Q YellowFillWithDarkYellowText��5�   >   +  5�   *   $N OilLevel��6>   $O Equal=�5�   >   $P 2��5�   >   $ Q GreenFillWithDarkGreenText��5�   >   +  5�   *   $N TirePressure��6>   $O Equal=�5�   >   $P 0��5�   >   $"Q YellowFillWithDarkYellowText��5�   >   +  5�   *   $N TirePressure��6>   $O Equal=�5�   >   $P 1��5�   >   $ Q GreenFillWithDarkGreenText��5�   >   R   BehaviorsTemplateR 5�   &   �� 5�   *   .R�5�   .   �� .��5�   2   $  $: 
RowUpdated��6H   ; 5�   <   �� *ItemUpdatedCommand+< 5�   6   &-    NextBO.Wpf.RowEventArgsConverter-  5�   :   5�   3   5�   /   5�   +    S *  RowCellMenuCustomizationsS 5�   &     5�   *   $
 Edit 6<    5�   ,   �� *ItemUpdatedCommand+ 5�   ,     $D >pack://application:,,,/NextBO.Wpf;component/Resources/Edit.svg?�5�   #   3 5�        5�   "   T   IsSmart$
T True��61   $4 
CreateDate��5�   !   $. 
 DevExpress.Xpf.Grid.BaseColumnU .  Header$U Fecha de Medicion 5�   !   V   ReadOnly$
V True��5�   !   W   EditSettingsW 5�   &   6/  0DevExpress.Xpf.Editors.Settings.DateEditSettings/  5�   *   60  0DevExpress.Xpf.Editors.Settings.TextEditSettingsX 0  Mask$X dd/MM/yyyy hh:mm:ss tt��6?   Y 0  MaskUseAsDisplayFormat$
Y True��5�   /   5�   #     5�   "   $
T True��61   $!4 ConfigCheckListVehicle.Type��5�   !   $
U Tipo 5�   !   Z .  Visible$
Z True��5�   !   $
V True��5�   !     5�   "   $
T True��61   $4 Vehicle.PilotId��5�   !   $U Piloto 5�   !   $
V True��5�   !     5�   "   $
T True��61   $4 Vehicle.PlateNumber��5�   !   $U Vehiculo 5�   !   $
V True��5   !     5  "   $
T True��61   $4 Mileage��5  !   $U Kilometraje 5  !   $
V True��5  !     5  "   $
T True��61   $4 	FuelLevel��5  !   $U Nivel de Gasolina 5  !   $
V True��5  !     5	  "   $
T True��61   $4 OilLevel��5
  !   $U Nivel de Aceite 5  !   $
V True��5  1   [   Binding[ 5  1   �� $& OilLevel�#	 [ W 5  &   0  5  *   5  #     5  "   $
T True��61   $4 
WaterLevel��5  !   $U Nivel de Agua 5  !   $
V True��5  !   [ 5  1   �� $& 
WaterLevel�#	 [ W 5  &   0  5  *   5  #     5  "   $
T True��61   $4 TirePressure��5  !   $U Presion de Llantas 5  !   $
V True��5  !   [ 5  !   �� $& TirePressure�#	 [ W 5   &   71  1DevExpress.Xpf.Editors.Settings.CheckEditSettings1  5!  *   5#  #   5%     5&     5'       5)     $ 
Horizontal=�6#   $��0,0,0,0q�6<   \ J� RenderTransformOrigin$\ 0.518,0.477&�6M   .+�5*       .+�5+     &2   DevExpress.Xpf.Core.DXTabControl2  .@�5,     #3  DevExpress.Xpf.Core.DXTabItem3  �4  �DevExpress.Xpf.Core.Native.HeaderedSelectorItemBase`2[[DevExpress.Xpf.Core.DXTabControl, DevExpress.Xpf.Core.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a],[DevExpress.Xpf.Core.DXTabItem, DevExpress.Xpf.Core.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a]]] 4  Header$] Imagenes��6+   .��5-  "     -   5        ^  Name$^ ContentImageDelivery��5-  2   $��Stretch=�6P   $��Center=�6l   $
��5000��6�   ���	#00000000.# 5.  &   '5  !DevExpress.Xpf.WindowsUI.FlipView5  #��[ 6]   ��65   �� *CollectionImage+��5/  *   �� 50  .   _ j� Stretch$_ Uniform=�6�   ` �� ImageSource` 69     $P Jpack://application:,,,/NextBO.Wpf;component/Resources/NoImageAvaliable.svg?�51  /   53  '   54  #   55     56     57     58     59     5:     5;     5<     