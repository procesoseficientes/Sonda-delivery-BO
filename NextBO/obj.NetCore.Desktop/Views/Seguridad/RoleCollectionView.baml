   M S B A M L   `   `   `  ����E  ANextBO.Wpf, Version=1.0.1.0, Culture=neutral, PublicKeyToken=null'clr-namespace:NextBO.Wpf
NextBO.Wpf  5      9!clr-namespace:NextBO.Wpf.ServicesNextBO.Wpf.Services  5      3clr-namespace:NextBO.Wpf.ViewsNextBO.Wpf.Views  5      =#clr-namespace:NextBO.Wpf.ViewModelsNextBO.Wpf.ViewModels  5      )    #NextBO.Wpf.Views.RoleCollectionView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35h dDevExpress.Xpf.TypedStyles.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aR NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/netfx/2009/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089<x,http://schemas.microsoft.com/winfx/2006/xaml      5      Bd2http://schemas.microsoft.com/expression/blend/2008      5      a ]DevExpress.Xpf.Core.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49al hDevExpress.Xpf.Core.v20.2.Extensions, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a?dx2http://schemas.devexpress.com/winfx/2008/xaml/core    5      >dxb2http://schemas.devexpress.com/winfx/2008/xaml/bars   5      d `DevExpress.Xpf.Docking.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aBdxdo5http://schemas.devexpress.com/winfx/2008/xaml/docking   5      l	 hDevExpress.Xpf.Grid.v20.2.Extensions, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aa
 ]DevExpress.Xpf.Grid.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49af bDevExpress.Xpf.Grid.v20.2.Core, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aBdxg2http://schemas.devexpress.com/winfx/2008/xaml/grid 	 
   5      g cDevExpress.Mvvm.v20.2.ViewModel, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a] YDevExpress.Mvvm.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aEdxmvvm2http://schemas.devexpress.com/winfx/2008/xaml/mvvm     5	      c _DevExpress.Xpf.Ribbon.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aBdxr4http://schemas.devexpress.com/winfx/2008/xaml/ribbon    5
      (localclr-namespace:NextBO.Wpf    5      Hmc;http://schemas.openxmlformats.org/markup-compatibility/2006    5      4services!clr-namespace:NextBO.Wpf.Services    5      -viewclr-namespace:NextBO.Wpf.Views    5      7	viewmodel#clr-namespace:NextBO.Wpf.ViewModels    5        � DataContext  5      1  +DevExpress.Mvvm.UI.ViewModelSourceExtension  *#!viewmodel:RoleCollectionViewModel+ � 	Resources 5       �� MergedDictionaries �� Source0  *DevExpress.Mvvm.UI.ObjectToObjectConverter &  "OrientationToIsHorizontalConverter
   Map   DevExpress.Mvvm.UI.MapItem   Source   Target $  OrientationToIsVerticalConverter  CardViewToTrueConverter  ListViewToTrueConverter&    NextBO.Wpf.IntToBooleanConverter  IntToBooleanConverter ( $CollectionViewKindToBooleanConverter�� 5   
    5      �� 5      $D >pack://application:,,,/NextBO.Wpf;component/Themes/Common.xaml?�6%   %�  &	        &	 �     &	     &	 �    &	      &	       5      . 5        $ 
Horizontal��6!   $
 True��65     5      $ Vertical��6!   $ False��63   5        5      . 5        $ 
Horizontal��6!   $ False��65     5       $ Vertical��6!   $
 True��63   5!        5"      . 5#        $ CardView��6!   $
 True��63     5$      $ ListView��6!   $ False��63   5%        5&      . 5'        $ ListView��6!   $
 True��63     5(      $ CardView��6!   $ False��63   5)        5*      6*     5+      . 5,        $ ListView��6!   $
 True��63     5-      $ CardView��6!   $ False��63   5.      5/      2  ,DevExpress.Mvvm.UI.Interactivity.Interaction   	Behaviors 52      +   %NextBO.Wpf.Services.ExportGridService  53   
      View 6%   %  System.Windows.Markup.Reference  *RoleTableView+-  'DevExpress.Xpf.Core.DXMessageBoxService  54   
   .	  (DevExpress.Mvvm.UI.SaveFileDialogService	  55   
   3
  -DevExpress.Xpf.Core.WindowedDocumentUIService
  56   
   	 
  DocumentShowMode$	 Dialog=�6'   
 
  
WindowType&   DevExpress.Xpf.Core.ThemedWindow"
  6A    
  WindowStyle 57      �� 58       �� 
TargetType"  6   .�59      �� -  'DevExpress.Xpf.Core.ScrollBarExtensions �� Property �@ ScrollBarMode �� Value$ TouchOverlap=�6M   �� 5:       �@ ShowIcon$ False��61   �� 5;       � ��$
 1154��6.   �� 5<       � ��$	 740��6/   5=      5?      .��5B      ]� .+�5C   
   )  #DevExpress.Xpf.Ribbon.RibbonControl  $	��Top=�5D         RibbonStyle$ 
Office2019=�5E      $y�Visible=�5F         ShowApplicationButton$ False��5G         Items. 5H      5  /DevExpress.Xpf.Ribbon.RibbonDefaultPageCategory  2  ,DevExpress.Xpf.Ribbon.RibbonPageCategoryBase   Caption$ defaultCategory��6,      Pages. 5I      &   DevExpress.Xpf.Ribbon.RibbonPage     Caption)  #DevExpress.Xpf.Core.ObjectConverter$
 Home 6!      Groups. 5J      +  %DevExpress.Xpf.Ribbon.RibbonPageGroup     Caption$ Acciones��6*      Items. 5K      '  !DevExpress.Xpf.Bars.BarButtonItem  !  DevExpress.Xpf.Bars.BarItem   Content$ Nuevo 5M         Command 5L      ��  �� ElementName$ RoleTableView�� �� Path$ Commands.AddNewRow�   Glyph 5N      1  +DevExpress.Xpf.Core.SvgImageSourceExtension  
   Uri$J Dpack://application:,,,/NextBO.Wpf;component/Resources/NewEmploye.svg?�   
LargeGlyph 5O        $J Dpack://application:,,,/NextBO.Wpf;component/Resources/NewEmploye.svg?�  5P      $ Guardar y Cerrar 5R       5Q      �� *SaveAndCloseCommand+ 5S        $L Fpack://application:,,,/NextBO.Wpf;component/Resources/SaveAndClose.svg?� 5T        $L Fpack://application:,,,/NextBO.Wpf;component/Resources/SaveAndClose.svg?�  5U      $ Eliminar 5X       5V      �� *DeleteCommand+   CommandParameter 5W      �� *SelectedEntity+ 5Y        $E ?pack://application:,,,/NextBO.Wpf;component/Resources/Trash.svg?� 5Z        $E ?pack://application:,,,/NextBO.Wpf;component/Resources/Trash.svg?�  5[      $ Close 5]       5\      �� *CloseCommand+ 5^        $E ?pack://application:,,,/NextBO.Wpf;component/Resources/Close.svg?� 5_        $E ?pack://application:,,,/NextBO.Wpf;component/Resources/Close.svg?�5`        5a      $ Accesos��6*   . 5b        $ Asociar Todo 5e       5c      �� *AssociateAllCommand+ 5d      �� *SelectedEntity+ 5f        $D >pack://application:,,,/NextBO.Wpf;component/Resources/Link.svg?� 5g        $D >pack://application:,,,/NextBO.Wpf;component/Resources/Link.svg?�  5h      $ Desasociar Todos 5k       5i      �� *DissociateAllCommand+ 5j      �� *SelectedEntity+ 5l        $F @pack://application:,,,/NextBO.Wpf;component/Resources/Unlink.svg?� 5m        $F @pack://application:,,,/NextBO.Wpf;component/Resources/Unlink.svg?�5n        5o      $ Exportar��6*   . 5p        $ Previsualizar 5r       5q      �� *ShowPreviewCommand+ 5s        $L Fpack://application:,,,/NextBO.Wpf;component/Resources/PrintPreview.svg?� 5t        $L Fpack://application:,,,/NextBO.Wpf;component/Resources/PrintPreview.svg?�  5u      $
 XLSX��5w      $ Exportar 5x       5v      �� *ExportGridCommand+ 5y        $T Npack://application:,,,/NextBO.Wpf;component/Resources/Controls/ExportToXLS.svg?� 5z        $T Npack://application:,,,/NextBO.Wpf;component/Resources/Controls/ExportToXLS.svg?�  5{      $	 PDF��5}      $ Exportar 5~       5|      �� *ExportGridCommand+ 5        $T Npack://application:,,,/NextBO.Wpf;component/Resources/Controls/ExportToXLS.svg?� 5�        $T Npack://application:,,,/NextBO.Wpf;component/Resources/Controls/ExportToPDF.svg?�5�      5�      5�      5�      2  ,DevExpress.Xpf.Ribbon.RibbonStatusBarControl  5�   
   $��Bottom=�6%       
RightItems  5�      '  !DevExpress.Xpf.Bars.BarStaticItem  5�       6$   �� *Entities.Count+! �� 	Converter! 7  1DevExpress.Mvvm.UI.FormatStringConverterExtension  "   FormatString$" Conteo: {0}��5�      .  (DevExpress.Xpf.Docking.DockLayoutManager  5�   
   #   
LayoutRoot# 5�      (  "DevExpress.Xpf.Docking.LayoutGroup  5�      +  %DevExpress.Xpf.Docking.BaseLayoutItem$   Margin$$ 
10,10,10,0q�5�      $��Stretch=�5�      $��Stretch=�5�      %   Orientation% 5�      �� *ViewSettings.Orientation+&   Items.& 5�      (  "DevExpress.Xpf.Docking.LayoutPanel  '   
AllowClose$' False��5�      (   	AllowDrag$( False��5�      )   
AllowFloat$) False��5�      *   	AllowHide$* False��5�      +   AllowSizing$
+ True��5�      $,   HorizontalScrollBarVisibility$, Disabled=�5�      -   
ItemHeight$- * �5�      .   	ItemWidth$. * �5�      /   ShowCaption$/ False��5�      "0   VerticalScrollBarVisibility$0 Disabled=�5�      (  "DevExpress.Xpf.Docking.ContentItem1   Content.1 5�      � .+�5�      % 
 DevExpress.Xpf.Grid.GridControl  -   5        2  Name$2 tableViewGridControl��5�   !   3   AutoExpandAllGroups$
3 True��5�   !   )  #DevExpress.Xpf.Grid.DataControlBase4   ClipboardCopyMode$4 ExcludeHeader=�5�   !   #5   EnableSmartColumnsGeneration$
5 True��5�   !   6   
ShowBorder$6 False��5�   !   7   ItemsSource7 5�   !   �� *
Entities+8   SelectedItem8 5�   !   �� *TableViewSelectedEntity+ 5�   "   '    !NextBO.Wpf.GridSaveLayoutBehavior   5�   &   -   5        SerializeHelper��9    FileName$9 RoleTableView.xml��5�   \   :   View: 5�   "   #! 
 DevExpress.Xpf.Grid.TableView!  5�   &   -   5        $��RoleTableView��5�   )   &"   DevExpress.Xpf.Grid.DataViewBase; "  AllowEditing$
; True��5�   )   < !  AllowPerPixelScrolling$
< True��5�   )   = !  	AutoWidth$
= True��5�   )   > "  ColumnFilterPopupMode$> Excel=�5�   )   %? "  SearchPanelHorizontalAlignment	? Right5�   )   @ "  SearchPanelNullText$@ Buscar Roles (Ctrl + F)��5�   )   A !  ShowAutoFilterRow$
A True��5�   )   "B !  ShowCriteriaInAutoFilterRow$
B True��5�   )   C "  ShowSearchPanelMode$C Always=�5�   )   D   BehaviorsTemplateD 5�   *   �� 5�   .   .R�5�   2   �� .��5�   6   '#  !DevExpress.Mvvm.UI.EventToCommand#  �$  �DevExpress.Mvvm.UI.Interactivity.EventTriggerBase`1[[System.Windows.DependencyObject, WindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35]]E $  	EventName$E ValidateRow��5�   L   F #  PassEventArgsToCommandF True5�   L   +%  %DevExpress.Mvvm.UI.EventToCommandBaseG %  CommandG 5�   L   �� *ItemSelectedUpdatedCommand+5�   7   5�   3   5�   /   5�   '   H   ColumnsH 5�   "   $& 
 DevExpress.Xpf.Grid.GridColumn&  5�   &   $'  DevExpress.Xpf.Grid.ColumnBaseI '  	FieldName$I Id��5�   )   $(  DevExpress.Xpf.Grid.BaseColumnJ (  Header$J Id 5�   )   K '  IsSmart$
K True��5�   )   L '  ReadOnly$
L True��5�   )   &  5�   &   $
I Name��5�   )   $J Nombre 5�   )   $
K True��5�   )   &  5�   &   $I Description��5�   )   $J Descripción 5�   )   $
K True��5�   )   &  5�   &   $I LastUpdatedBy��5�   )   $J Modificado Por 5�   )   $
K True��5�   )   $
L True��5�   )   &  5�   &   $I LastUpdated��5�   )   $J Modificado el 5�   )   $
K True��5�   )   $
L True��5�   )   &  5�   &   $I 	CreatedBy��5�   )   $J 
Creado Por 5�   )   $
K True��5�   )   $
L True��5�   )   &  5�   &   $I 	CreatedOn��5�   )   $J Fecha de Creación 5�   )   $
K True��5�   )   $
L True��5�   )   M   GroupSummaryM 5�   "   )) 
 #DevExpress.Xpf.Grid.GridSummaryItem)  5�   &   )*  #DevExpress.Xpf.Grid.SummaryItemBaseN *  SummaryType] YDevExpress.Data.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a5+  /DevExpress.Data.Design.SummaryItemTypeConverter$N Count+ 6:   5�      5�      5�        5�      $' False��5�      $( False��5�      $) False��5�      $* False��5�      $
+ True��5�      $, Disabled=�5�      $	- 300 �5�      $	. 420 �5�      O   
ShowBorder$O False��5�      $/ False��5�      $0 Disabled=�5�      y�5�      �� * ViewSettings.IsDataPaneVisible+! >,  8DevExpress.Mvvm.UI.BooleanToVisibilityConverterExtension,  .1 5�      +-   %NextBO.Wpf.Views.CheckpointByRoleView-    64   �� *!SelectedRoleCheckpointViewModel+,.  &DevExpress.Mvvm.UI.ViewModelExtensionsP .  ParentViewModelP 6l   �� 5�      5�      5�      5�      5�      