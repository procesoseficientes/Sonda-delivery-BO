   M S B A M L   `   `   `  ����E  ANextBO.Wpf, Version=1.0.1.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:NextBO.Wpf.ViewModelsNextBO.Wpf.ViewModels  5      'clr-namespace:NextBO.Wpf
NextBO.Wpf  5      9!clr-namespace:NextBO.Wpf.ServicesNextBO.Wpf.Services  5      >    8NextBO.Wpf.Views.Entregas.NoDeliveryReasonCollectionView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35h dDevExpress.Xpf.TypedStyles.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aR NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/netfx/2009/xaml/presentation     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089<x,http://schemas.microsoft.com/winfx/2006/xaml      5      a ]DevExpress.Xpf.Core.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49al hDevExpress.Xpf.Core.v20.2.Extensions, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a?dx2http://schemas.devexpress.com/winfx/2008/xaml/core    5      Hmc;http://schemas.openxmlformats.org/markup-compatibility/2006    5      >dxb2http://schemas.devexpress.com/winfx/2008/xaml/bars   5      Adxe5http://schemas.devexpress.com/winfx/2008/xaml/editors   5      l hDevExpress.Xpf.Grid.v20.2.Extensions, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aa	 ]DevExpress.Xpf.Grid.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49af
 bDevExpress.Xpf.Grid.v20.2.Core, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aBdxg2http://schemas.devexpress.com/winfx/2008/xaml/grid  	 
  5	      c _DevExpress.Xpf.Ribbon.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aBdxr4http://schemas.devexpress.com/winfx/2008/xaml/ribbon    5
      d `DevExpress.Xpf.Docking.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aBdxdo5http://schemas.devexpress.com/winfx/2008/xaml/docking   5      g cDevExpress.Mvvm.v20.2.ViewModel, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a] YDevExpress.Mvvm.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aEdxmvvm2http://schemas.devexpress.com/winfx/2008/xaml/mvvm     5      9	viewmodel#clr-namespace:NextBO.Wpf.ViewModels     5      *localclr-namespace:NextBO.Wpf     5      6services!clr-namespace:NextBO.Wpf.Services     5        � DataContext  5      1  +DevExpress.Mvvm.UI.ViewModelSourceExtension  */-viewmodel:NoDeliveryReasonCollectionViewModel+ � 	Resources 5       �� MergedDictionaries �� Source0  *DevExpress.Mvvm.UI.ObjectToObjectConverter &  "OrientationToIsHorizontalConverter
   Map   DevExpress.Mvvm.UI.MapItem   Source   Target $  OrientationToIsVerticalConverter  CardViewToTrueConverter 3 /CollectionViewKindToCardViewVisibilityConverter 4 0CollectionViewKindToTableViewVisibilityConverter  ListViewToTrueConverter&    NextBO.Wpf.IntToBooleanConverter  IntToBooleanConverter ( $CollectionViewKindToBooleanConverter�� 5   
    5      �� 5      $D >pack://application:,,,/NextBO.Wpf;component/Themes/Common.xaml?�6%   %�  &	        &	 �     &	     &	 �    &	     &	 �    &	     &	 '      5      . 5        $ 
Horizontal��6!   $
 True��65     5      $ Vertical��6!   $ False��63   5        5      . 5        $ 
Horizontal��6!   $ False��65     5      $ Vertical��6!   $
 True��63   5         5!      . 5"        $ CardView��6!   $
 True��63     5#      $ ListView��6!   $ False��63   5$        5%      . 5&        $ ListView��6!   $ 	Collapsed��63     5'      $ CardView��6!   $ Visible��63   5(        5)      . 5*        $ ListView��6!   $ Visible��5+   !     5,      $ CardView��6!   $ 	Collapsed��5-   !   5.        5/      . 50        $ ListView��6!   $
 True��63     51      $ CardView��6!   $ False��63   52        53      6*     54      . 55        $ ListView��6!   $
 True��63     56      $ CardView��6!   $ False��63   57      58      2  ,DevExpress.Mvvm.UI.Interactivity.Interaction   	Behaviors 5;      +   %NextBO.Wpf.Services.ExportGridService  5<   
      View 6%   %  System.Windows.Markup.Reference  *NoDeliveryTableView+-  'DevExpress.Xpf.Core.DXMessageBoxService  5=   
   .	  (DevExpress.Mvvm.UI.SaveFileDialogService	  5>   
   3
  -DevExpress.Xpf.Core.WindowedDocumentUIService
  5?   
   	 
  DocumentShowMode$	 Dialog=�6'   
 
  
WindowType&   DevExpress.Xpf.Core.ThemedWindow"
  6A    
  WindowStyle 5@      �� 5A       �� 
TargetType"  6   .�5B      �� -  'DevExpress.Xpf.Core.ScrollBarExtensions �� Property �@ ScrollBarMode �� Value$ TouchOverlap=�6M   �� 5C       �@ ShowIcon$ False��61   �� 5D       � ��$
 1154��6.   �� 5E       � ��$	 740��6/   5F      5H      .��5K      ]� .+�5L   
   )  #DevExpress.Xpf.Ribbon.RibbonControl  $	��Top=�6      RibbonStyle$ 
Office2019=�5M      $y�Visible=�5N         ShowApplicationButton$ False��5O         Items. 5P      5  /DevExpress.Xpf.Ribbon.RibbonDefaultPageCategory  2  ,DevExpress.Xpf.Ribbon.RibbonPageCategoryBase   Caption$ defaultCategory��6,      Pages. 5Q      &   DevExpress.Xpf.Ribbon.RibbonPage     Caption)  #DevExpress.Xpf.Core.ObjectConverter$
 Home 6!      Groups. 5R      +  %DevExpress.Xpf.Ribbon.RibbonPageGroup     Caption$ Acciones��6*      Items. 5S      '  !DevExpress.Xpf.Bars.BarButtonItem  !  DevExpress.Xpf.Bars.BarItem   Content$ Nuevo 5T   ,      Command 5S   ,   ��  �� ElementName$ NoDeliveryTableView�� �� Path$ Commands.AddNewRow�   Glyph 5U   ,   1  +DevExpress.Xpf.Core.SvgImageSourceExtension  
   Uri$C =pack://application:,,,/NextBO.Wpf;component/Resources/Add.svg?�   
LargeGlyph 5V   ,     $C =pack://application:,,,/NextBO.Wpf;component/Resources/Add.svg?�  5W      $ 
Desactivar 5Y   ,    5W   ,   �� *DeleteCommand+   CommandParameter 5X   ,   �� *SelectedEntity+ 5Z   ,     $F @pack://application:,,,/NextBO.Wpf;component/Resources/Delete.svg?� 5[   ,     $F @pack://application:,,,/NextBO.Wpf;component/Resources/Delete.svg?�  5\      $ Activar 6,    5]   ,   �� *ActivateCommand+ 5^   ,   �� *SelectedEntity+ 5_   ,     $F @pack://application:,,,/NextBO.Wpf;component/Resources/Active.svg?� 5`   ,     $F @pack://application:,,,/NextBO.Wpf;component/Resources/Active.svg?�5a        5b      $ Exportar��6*   . 5c        $ Previsualizar 5e       5d      �� *ShowPreviewCommand+ 5f        $L Fpack://application:,,,/NextBO.Wpf;component/Resources/PrintPreview.svg?� 5g        $L Fpack://application:,,,/NextBO.Wpf;component/Resources/PrintPreview.svg?�  5h      $
 XLSX��5j      $ Exportar 5k       5i      �� *ExportGridCommand+ 5l        $T Npack://application:,,,/NextBO.Wpf;component/Resources/Controls/ExportToXLS.svg?� 5m        $T Npack://application:,,,/NextBO.Wpf;component/Resources/Controls/ExportToXLS.svg?�  5n      $	 PDF��5p      $ Exportar 5q       5o      �� *ExportGridCommand+ 5r        $T Npack://application:,,,/NextBO.Wpf;component/Resources/Controls/ExportToXLS.svg?� 5s        $T Npack://application:,,,/NextBO.Wpf;component/Resources/Controls/ExportToPDF.svg?�5t        5u      $ Layout��6*   . 5v        $ Guardar Layout 6,    5w   ,   �� *SaveLayoutCommand+$ SerializeHelper�� 5x   ,     $D >pack://application:,,,/NextBO.wpf;component/Resources/Save.svg?� 5y   ,     $D >pack://application:,,,/NextBO.wpf;component/Resources/Save.svg?�  5z      $ 	Restaurar 6,    5{   ,   �� *RestoreLayoutCommand+$ SerializeHelper�� 5|   ,     $D >pack://application:,,,/NextBO.wpf;component/Resources/Undo.svg?� 5}   ,     $D >pack://application:,,,/NextBO.wpf;component/Resources/Undo.svg?�5~      5      5�      5�      .  (DevExpress.Xpf.Docking.DockLayoutManager  5�   
       
LayoutRoot  5�      (  "DevExpress.Xpf.Docking.LayoutGroup  5�      +  %DevExpress.Xpf.Docking.BaseLayoutItem!   Margin$! 
10,10,10,0q�5�      $��Stretch=�5�      $��Stretch=�5�      "   Orientation" 5�      �� *ViewSettings.Orientation+#   Items.# 5�      (  "DevExpress.Xpf.Docking.LayoutPanel  $   
AllowClose$$ False��5�      %   	AllowDrag$% False��5�      &   
AllowFloat$& False��5�      '   	AllowHide$' False��5�      (   AllowSizing$
( True��5�      $)   HorizontalScrollBarVisibility$) Disabled=�5�      *   
ItemHeight$* * �5�      +   	ItemWidth$+ * �5�      ,   ShowCaption$, False��5�      "-   VerticalScrollBarVisibility$- Disabled=�5�      (  "DevExpress.Xpf.Docking.ContentItem.   Content.. 5�      � .+�5�      % 	 DevExpress.Xpf.Grid.GridControl  -   5        /  Name$/ tableViewGridControl��5�   !   0   AutoExpandAllGroups$
0 True��5�   !   ) 
 #DevExpress.Xpf.Grid.DataControlBase1   ClipboardCopyMode$1 ExcludeHeader=�5�   !   2   SelectionMode$	2 Row=�5�   !   #3   EnableSmartColumnsGeneration$
3 True��5�   !   4   
ShowBorder$4 False��5�   !   5   ItemsSource5 5�   !   �� *
Entities+6   SelectedItem6 5�   !   �� *TableViewSelectedEntity+ 5�   "   '   !NextBO.Wpf.GridSaveLayoutBehavior  5�   &   -   5        SerializeHelper��7   FileName$7 NoDeliveryTableView.xml��5�   \   8   View8 5�   "   # 	 DevExpress.Xpf.Grid.TableView  5�   &   -   5        $��NoDeliveryTableView��5�   )   & 
  DevExpress.Xpf.Grid.DataViewBase9   AllowEditing$
9 True��5�   )   :   AllowPerPixelScrolling$
: True��5�   )   ;   	AutoWidth$
; True��5�   )   <   ColumnFilterPopupMode$< Excel=�5�   )   %=   SearchPanelHorizontalAlignment	= Right5�   )   >   SearchPanelNullText$-> 'Buscar razones de no entrega (Ctrl + F)��5�   )   ?   ShowAutoFilterRow$
? True��5�   )   "@   ShowCriteriaInAutoFilterRow$
@ True��5�   )   A   ShowSearchPanelMode$A Always=�5�   )   B   BehaviorsTemplateB 5�   *   �� 5�   .   .R�5�   2   �� .��5�   6   '   !DevExpress.Mvvm.UI.EventToCommand   �!  �DevExpress.Mvvm.UI.Interactivity.EventTriggerBase`1[[System.Windows.DependencyObject, WindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35]]C !  	EventName$C ValidateRow��5�   L   D    PassEventArgsToCommandD True5�   L   +"  %DevExpress.Mvvm.UI.EventToCommandBaseE "  CommandE 5�   L   �� *ItemSelectedUpdatedCommand+5�   7   5�   3   5�   /   5�   '   F   ColumnsF 5�   "   $# 	 DevExpress.Xpf.Grid.GridColumn#  5�   &   $$ 
 DevExpress.Xpf.Grid.ColumnBaseG $  	FieldName$G Id��5�   )   $% 
 DevExpress.Xpf.Grid.BaseColumnH %  Header$H Id 5�   )   I $  IsSmart$
I True��5�   )   J $  ReadOnly$
J True��5�   )   #  5�   &   $G Reason��5�   )   $H Razon 5�   )   $
I True��5�   )   #  5�   &   $G IsActive��5�   )   $H Activo 5�   )   K %  Visible$K False��5�   )   #  5�   &   $H ¿Está Activo? 5�   )   L %  Width2& 
 ,DevExpress.Xpf.Grid.GridColumnWidthConverter$L 60& 5�   )   $
I True��5�   )   M $  BindingM 5�   )   �� $ IsActive�N �� 	Converter#N [ O $  EditSettingsO 5�   *   7'  1DevExpress.Xpf.Editors.Settings.CheckEditSettings'  5�   .   5�   '   #  5�   &   $G CreatedDate��5�   )   $H 	Creado el 5�   )   $
I True��5�   )   $
J True��5�   )   O 5�   *   6(  0DevExpress.Xpf.Editors.Settings.DateEditSettings(  5�   .   6)  0DevExpress.Xpf.Editors.Settings.TextEditSettingsP )  Mask$P yyyy/MM/dd hh:mm:ss tt��6C   Q )  MaskUseAsDisplayFormat$
Q True��5�   /   5�   '   #  5�   &   $G UserIdCreated��5�   )   $H 
Creado por 5�   )   $
I True��5�   )   $
J True��5�   )   #  5�   &   $G 
LastUpdate��5�   )   $H 
Editado el 5�   )   $
J True��5�   )   O 5�   *   (  5�   .   $P dd/MM/yyyy hh:mm:ss tt��6C   $
Q True��5�   /   5�   '   #  5�   &   $G UserIdUpdated��5�   )   $H Editado por 5�   )   $
I True��5�   )   $
J True��5�   )   R   GroupSummaryR 5�   "   )* 	 #DevExpress.Xpf.Grid.GridSummaryItem*  5�   &   )+ 
 #DevExpress.Xpf.Grid.SummaryItemBaseS +  SummaryType] YDevExpress.Data.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a5,  /DevExpress.Data.Design.SummaryItemTypeConverter$S Count, 6:   5�      5�      5�      5�      5�      5�      5�      