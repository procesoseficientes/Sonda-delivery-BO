   M S B A M L   `   `   `  ����E  ANextBO.Wpf, Version=1.0.1.0, Culture=neutral, PublicKeyToken=null'clr-namespace:NextBO.Wpf
NextBO.Wpf  5      9!clr-namespace:NextBO.Wpf.ServicesNextBO.Wpf.Services  5      !    NextBO.Wpf.Views.DetailView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35h dDevExpress.Xpf.TypedStyles.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aR NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/netfx/2009/xaml/presentation     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089<x,http://schemas.microsoft.com/winfx/2006/xaml      5      a ]DevExpress.Xpf.Core.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49al hDevExpress.Xpf.Core.v20.2.Extensions, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a?dx2http://schemas.devexpress.com/winfx/2008/xaml/core    5      Hmc;http://schemas.openxmlformats.org/markup-compatibility/2006    5      >dxb2http://schemas.devexpress.com/winfx/2008/xaml/bars   5      Adxe5http://schemas.devexpress.com/winfx/2008/xaml/editors   5      l hDevExpress.Xpf.Grid.v20.2.Extensions, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aa	 ]DevExpress.Xpf.Grid.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49af
 bDevExpress.Xpf.Grid.v20.2.Core, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aBdxg2http://schemas.devexpress.com/winfx/2008/xaml/grid  	 
  5	      c _DevExpress.Xpf.Ribbon.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aBdxr4http://schemas.devexpress.com/winfx/2008/xaml/ribbon    5
      d `DevExpress.Xpf.Docking.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aBdxdo5http://schemas.devexpress.com/winfx/2008/xaml/docking   5      g cDevExpress.Mvvm.v20.2.ViewModel, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a] YDevExpress.Mvvm.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aEdxmvvm2http://schemas.devexpress.com/winfx/2008/xaml/mvvm     5      *localclr-namespace:NextBO.Wpf     5      6services!clr-namespace:NextBO.Wpf.Services     5        � UseLayoutRounding$
  True��5       � 	Resources 5       �� MergedDictionaries �� Source!   NextBO.Wpf.PictureConverter   PictureConverter�� 5   
    5      �� 5      $D >pack://application:,,,/NextBO.Wpf;component/Themes/Common.xaml?�6%   %   &	          5      6%   5      2  ,DevExpress.Mvvm.UI.Interactivity.Interaction   	Behaviors 5      +   %NextBO.Wpf.Services.ExportGridService  5   
      View 6&   %  System.Windows.Markup.Reference  *DetailTableView+-  'DevExpress.Xpf.Core.DXMessageBoxService  5   
   .  (DevExpress.Mvvm.UI.SaveFileDialogService  5   
   -  'DevExpress.Mvvm.UI.CurrentWindowService  5   
      ClosingCommand 6&   �� *WindowClosingCommand+.��5"      ]� .+�5#   
   )  #DevExpress.Xpf.Ribbon.RibbonControl  -   5          Name$ ribbonControl��5#         RibbonStyle$ 
Office2019=�63   $	��Top=�6L   	   ShowApplicationButton$	 False��6a   
   Items.
 5$      5	  /DevExpress.Xpf.Ribbon.RibbonDefaultPageCategory	  2
  ,DevExpress.Xpf.Ribbon.RibbonPageCategoryBase 
  Caption$ defaultCategory��6,    
  Pages. 5%      &   DevExpress.Xpf.Ribbon.RibbonPage     Caption)  #DevExpress.Xpf.Core.ObjectConverter$
 Home 6!      Groups. 5&      +  %DevExpress.Xpf.Ribbon.RibbonPageGroup     Caption$ Acciones��6*      Items. 5'      '  !DevExpress.Xpf.Bars.BarButtonItem  !  DevExpress.Xpf.Bars.BarItem   Content$ Agregar 6,      Command 5(   ,   ��  �� ElementName$ DetailTableView�� �� Path$ Commands.AddNewRow�   
LargeGlyph 5)   ,   1  +DevExpress.Xpf.Core.SvgImageSourceExtension  
   Uri$C =pack://application:,,,/NextBO.Wpf;component/Resources/Add.svg?�   Glyph 5*   ,     $C =pack://application:,,,/NextBO.Wpf;component/Resources/Add.svg?�  5+      $ Eliminar 6,    5,   ,   �� *DeleteCommand+   CommandParameter 5-   ,   �� *SelectedEntity+ 5.   ,     $E ?pack://application:,,,/NextBO.Wpf;component/Resources/Trash.svg?� 5/   ,     $E ?pack://application:,,,/NextBO.Wpf;component/Resources/Trash.svg?�50        51      $ Exportar��6*   . 52        $ Previsualizar 6,    53   ,   �� *ShowPreviewCommand+ 54   ,     $L Fpack://application:,,,/NextBO.Wpf;component/Resources/PrintPreview.svg?� 55   ,     $L Fpack://application:,,,/NextBO.Wpf;component/Resources/PrintPreview.svg?�  56      $ Exportar 6,   $
 XLSX��58   ,    57   ,   �� *ExportGridCommand+ 59   ,     $T Npack://application:,,,/NextBO.Wpf;component/Resources/Controls/ExportToXLS.svg?� 5:   ,     $T Npack://application:,,,/NextBO.Wpf;component/Resources/Controls/ExportToXLS.svg?�  5;      $ Exportar 6,   $	 PDF��5=   ,    5<   ,   �� *ExportGridCommand+ 5>   ,     $T Npack://application:,,,/NextBO.Wpf;component/Resources/Controls/ExportToPDF.svg?� 5?   ,     $T Npack://application:,,,/NextBO.Wpf;component/Resources/Controls/ExportToXLS.svg?�5@      5A      5B      5C      (  "DevExpress.Xpf.Docking.LayoutGroup  5E   
   $��Stretch=�5F      $��Stretch=�5G      +  %DevExpress.Xpf.Docking.BaseLayoutItem   Margin$ 
10,10,10,0q�5H         Orientation 5E      �� *ViewSettings.Orientation+   Items. 5I      (  "DevExpress.Xpf.Docking.LayoutPanel     AllowSizing$
 True��6   "   VerticalScrollBarVisibility$ Disabled=�5J      $   HorizontalScrollBarVisibility$ Disabled=�5K         
AllowClose$ False��5L          	AllowDrag$  False��5M      !   
AllowFloat$! False��5N      "   	AllowHide$" False��5O      #   ShowCaption$# False��5P      $   	ItemWidth$$ * �5Q      %   
ItemHeight$% * �5R      (  "DevExpress.Xpf.Docking.ContentItem&   Content.& 5S      � .+�5T      % 	 DevExpress.Xpf.Grid.GridControl  -   5        '  Name$' tableViewGridControl��5T   &   ) 
 #DevExpress.Xpf.Grid.DataControlBase(   
ShowBorder$( False��5W   &   )   AutoExpandAllGroups$
) True��5X   &   *   ClipboardCopyMode$* ExcludeHeader=�5Y   &   #+   EnableSmartColumnsGeneration$
+ True��5Z   &   ,   ItemsSource, 5U   &   �� *
Entities+-   SelectedItem- 5V   &   �� *SelectedEntity+ 5[      '   !NextBO.Wpf.GridSaveLayoutBehavior  5\      -   5        SerializeHelper��.   FileName$. DetailTableView.xml��5]   ;   /   View/ 5_      # 	 DevExpress.Xpf.Grid.TableView  5`      -   5        $��DetailTableView��5`   ,   0   AllowPerPixelScrolling$
0 True��5a       & 
  DevExpress.Xpf.Grid.DataViewBase1   AllowEditing$
1 True��5b       2   ShowSearchPanelMode$2 Always=�5c       3   	AutoWidth$
3 True��5d       %4   SearchPanelHorizontalAlignment	4 Right5e       5   SearchPanelNullText$5 Buscar Detalle (Ctrl + F)��5f       6   ShowAutoFilterRow$
6 True��5g       "7   ShowCriteriaInAutoFilterRow$
7 True��5h       8   ColumnFilterPopupMode$8 Excel=�5i        5j   "   '  !DevExpress.Mvvm.UI.EventToCommand  5k   &   �  �DevExpress.Mvvm.UI.Interactivity.EventTriggerBase`1[[System.Windows.DependencyObject, WindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35]]9   	EventName$9 ValidateRow��6<   :   PassEventArgsToCommand: True5m   <   +  %DevExpress.Mvvm.UI.EventToCommandBase;   Command; 5l   <   �� *ItemSelectedUpdatedCommand+5n   '   5p      <   Columns< 5r      $ 	 DevExpress.Xpf.Grid.GridColumn  5s      $ 
 DevExpress.Xpf.Grid.ColumnBase=   IsSmart$
= True��6-   >   	FieldName$
> Name��5t   !   $ 
 DevExpress.Xpf.Grid.BaseColumn?   Header$? Nombre 5u   !     5v      $
= True��6-   $> Description��5w   !   $? Descripcion 5x   !     5y      $
= True��6-   $> 
CategoryId��5z   -   $? 	Categoria 5{   -   @   EditSettings@ 5|   "   :   4DevExpress.Xpf.Editors.Settings.ComboBoxEditSettings   5}   &   <!  6DevExpress.Xpf.Editors.Settings.LookUpEditSettingsBaseA !  DisplayMember$
A Name��5~   3   B !  ValueMember$B Id��6H   C !  ItemsSourceC 5}   ?   �� *LookUpCategories+5~   H   5�        5�      $
= True��6-   $> EstimatedCost��5�   !   $? Costo Estimado 5�   !   D   Visible$
D True��5�   !   E   GroupSummaryE 5�      )" 	 #DevExpress.Xpf.Grid.GridSummaryItem"  5�      )# 
 #DevExpress.Xpf.Grid.SummaryItemBaseF #  SummaryType] YDevExpress.Data.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a5$  /DevExpress.Data.Design.SummaryItemTypeConverter$F Count$ 62   5�      5�      5�      5�      5�      5�      