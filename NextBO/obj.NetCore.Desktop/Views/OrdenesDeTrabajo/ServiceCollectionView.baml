   M S B A M L   `   `   `  ����E  ANextBO.Wpf, Version=1.0.1.0, Culture=neutral, PublicKeyToken=null'clr-namespace:NextBO.Wpf
NextBO.Wpf  5      9!clr-namespace:NextBO.Wpf.ServicesNextBO.Wpf.Services  5      ,    &NextBO.Wpf.Views.ServiceCollectionView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35h dDevExpress.Xpf.TypedStyles.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aR NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/netfx/2009/xaml/presentation     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089<x,http://schemas.microsoft.com/winfx/2006/xaml      5      a ]DevExpress.Xpf.Core.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49al hDevExpress.Xpf.Core.v20.2.Extensions, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a?dx2http://schemas.devexpress.com/winfx/2008/xaml/core    5      Hmc;http://schemas.openxmlformats.org/markup-compatibility/2006    5      >dxb2http://schemas.devexpress.com/winfx/2008/xaml/bars   5      l hDevExpress.Xpf.Grid.v20.2.Extensions, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aa	 ]DevExpress.Xpf.Grid.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49af
 bDevExpress.Xpf.Grid.v20.2.Core, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aBdxg2http://schemas.devexpress.com/winfx/2008/xaml/grid  	 
  5      c _DevExpress.Xpf.Ribbon.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aBdxr4http://schemas.devexpress.com/winfx/2008/xaml/ribbon    5	      d `DevExpress.Xpf.Docking.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aBdxdo5http://schemas.devexpress.com/winfx/2008/xaml/docking   5
      g cDevExpress.Mvvm.v20.2.ViewModel, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a] YDevExpress.Mvvm.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aEdxmvvm2http://schemas.devexpress.com/winfx/2008/xaml/mvvm     5      *localclr-namespace:NextBO.Wpf     5      6services!clr-namespace:NextBO.Wpf.Services     5        � UseLayoutRounding$
  True��5       � 	Resources 5       �� MergedDictionaries �� Source!   NextBO.Wpf.PictureConverter   PictureConverter�� 5   
    5      �� 5      $D >pack://application:,,,/NextBO.Wpf;component/Themes/Common.xaml?�6%   %   &	          5      6%   5      2  ,DevExpress.Mvvm.UI.Interactivity.Interaction   	Behaviors 5      +   %NextBO.Wpf.Services.ExportGridService  5   
      View 6&   %  System.Windows.Markup.Reference  *ServiceTableView+-  'DevExpress.Xpf.Core.DXMessageBoxService  5   
   .  (DevExpress.Mvvm.UI.SaveFileDialogService  5   
   .��5       ]� .+�5!   
   )  #DevExpress.Xpf.Ribbon.RibbonControl  -   5          Name$ ribbonControl��5!         RibbonStyle$ 
Office2019=�63   $	��Top=�6L      ShowApplicationButton$ False��6a   	   Items.	 5#      5  /DevExpress.Xpf.Ribbon.RibbonDefaultPageCategory  2	  ,DevExpress.Xpf.Ribbon.RibbonPageCategoryBase
 	  Caption$
 defaultCategory��6,    	  Pages. 5$      &
   DevExpress.Xpf.Ribbon.RibbonPage
   
  Caption)  #DevExpress.Xpf.Core.ObjectConverter$
 Home 6!    
  Groups. 5%      +  %DevExpress.Xpf.Ribbon.RibbonPageGroup     Caption$ Acciones��6*      Items. 5&      '  !DevExpress.Xpf.Bars.BarButtonItem  !  DevExpress.Xpf.Bars.BarItem   Content$ Agregar 6,      Command 5'   ,   �� *
NewCommand+   
LargeGlyph 5(   ,   1  +DevExpress.Xpf.Core.SvgImageSourceExtension  
   Uri$C =pack://application:,,,/NextBO.Wpf;component/Resources/Add.svg?�   Glyph 5)   ,     $C =pack://application:,,,/NextBO.Wpf;component/Resources/Add.svg?�  5*      $ Editar 6,    5+   ,   �� *EditCommand+   CommandParameter 5,   ,   �� *SelectedEntity+ 5-   ,     $D >pack://application:,,,/NextBO.Wpf;component/Resources/Edit.svg?� 5.   ,     $D >pack://application:,,,/NextBO.Wpf;component/Resources/Edit.svg?�5/        50      $ Exportar��6*   . 51        $ Previsualizar 6,    52   ,   �� *ShowPreviewCommand+ 53   ,     $L Fpack://application:,,,/NextBO.Wpf;component/Resources/PrintPreview.svg?� 54   ,     $L Fpack://application:,,,/NextBO.Wpf;component/Resources/PrintPreview.svg?�  55      $ Exportar 6,   $
 XLSX��57   ,    56   ,   �� *ExportGridCommand+ 58   ,     $T Npack://application:,,,/NextBO.Wpf;component/Resources/Controls/ExportToXLS.svg?� 59   ,     $T Npack://application:,,,/NextBO.Wpf;component/Resources/Controls/ExportToXLS.svg?�  5:      $ Exportar 6,   $	 PDF��5<   ,    5;   ,   �� *ExportGridCommand+ 5=   ,     $T Npack://application:,,,/NextBO.Wpf;component/Resources/Controls/ExportToPDF.svg?� 5>   ,     $T Npack://application:,,,/NextBO.Wpf;component/Resources/Controls/ExportToXLS.svg?�5?        5@      $ Layout��6*   . 5A        $ Guardar Layout 6,    5B   ,   �� *SaveLayoutCommand+ �� ElementName$ SerializeHelper�� 5C   ,     $D >pack://application:,,,/NextBO.Wpf;component/Resources/Save.svg?� 5D   ,     $D >pack://application:,,,/NextBO.Wpf;component/Resources/Save.svg?�  5E      $ 	Restaurar 6,    5F   ,   �� *RestoreLayoutCommand+$ SerializeHelper�� 5G   ,     $D >pack://application:,,,/NextBO.Wpf;component/Resources/Undo.svg?� 5H   ,     $D >pack://application:,,,/NextBO.Wpf;component/Resources/Undo.svg?�5I      5J      5K      5L      .  (DevExpress.Xpf.Docking.DockLayoutManager  5N   
      
LayoutRoot 5O      (  "DevExpress.Xpf.Docking.LayoutGroup  5P      $��Stretch=�5Q      $��Stretch=�5R      +  %DevExpress.Xpf.Docking.BaseLayoutItem   Margin$ 
10,10,10,0q�5S         Orientation 5P   #   �� *ViewSettings.Orientation+   Items. 5T      (  "DevExpress.Xpf.Docking.LayoutPanel     AllowSizing$
 True��6'   "   VerticalScrollBarVisibility$ Disabled=�5U      $   HorizontalScrollBarVisibility$ Disabled=�5V         
AllowClose$ False��5W         	AllowDrag$ False��5X          
AllowFloat$  False��5Y      !   	AllowHide$! False��5Z      "   ShowCaption$" False��5[      #   	ItemWidth$# * �5\      $   
ItemHeight$$ * �5]      (  "DevExpress.Xpf.Docking.ContentItem%   Content.% 5^      � .+�5_      % 	 DevExpress.Xpf.Grid.GridControl  -   5        &  Name$& tableViewGridControl��5_   .   ) 
 #DevExpress.Xpf.Grid.DataControlBase'   
ShowBorder$' False��5b   &   (   AutoExpandAllGroups$
( True��5c   &   )   ItemsSource) 5`   &   �� *
Entities+*   SelectedItem* 5a   &   �� *SelectedEntity+ 5d   "   '  !DevExpress.Mvvm.UI.EventToCommand  5e   &   +   PassEventArgsToCommand+ True6<   �  �DevExpress.Mvvm.UI.Interactivity.EventTriggerBase`1[[System.Windows.DependencyObject, WindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35]],   	EventName$, MouseDoubleClick��5g   <   +  %DevExpress.Mvvm.UI.EventToCommandBase-   Command- 5f   <   �� *EditCommand+.   EventArgsConverter. 5h   *   5  /DevExpress.Xpf.Core.EventArgsToDataRowConverter  5i   .   5k   '   '   !NextBO.Wpf.GridSaveLayoutBehavior  5l   &   -   5        SerializeHelper��/   FileName$/ ServiceTableView.xml��5m   ;   0   View0 5o   "   # 	 DevExpress.Xpf.Grid.TableView  5p   &   -   5        $��ServiceTableView��5p   4   1   AllowPerPixelScrolling$
1 True��5q       & 
  DevExpress.Xpf.Grid.DataViewBase2   AllowEditing$2 False��5r       3   ShowSearchPanelMode$3 Always=�5s       4   	AutoWidth$
4 True��5t       %5   SearchPanelHorizontalAlignment	5 Right5u       6   SearchPanelNullText$ 6 Buscar Servicio (Ctrl + F)��5v       7   ShowAutoFilterRow$
7 True��5w       "8   ShowCriteriaInAutoFilterRow$
8 True��5x       9   ColumnFilterPopupMode$9 Excel=�5y       :   NavigationStyle$	: Row=�5z       ;   ShowTotalSummary$
; True��5{        <   IsTotalSummaryMenuEnabled$< False��5|       =   BehaviorsTemplate= 5}   *   �� 5~   .   .R�5   2   �� .��5�   6     + True6L   $, 
RowUpdated��5�   1   - 5�   <   �� *ItemUpdatedCommand+. 5�   :   &    NextBO.Wpf.RowEventArgsConverter  5�   >   5�   7   5�   3   5�   /    >   RowCellMenuCustomizations> 5�   *     5�   .   $ Editar 6@    5�   ,   �� *ItemUpdatedCommand+ 5�   ,     $D >pack://application:,,,/NextBO.Wpf;component/Resources/Edit.svg?�5�   '   ?   Columns? 5�   "   $ 	 DevExpress.Xpf.Grid.GridColumn  5�   &   $  
 DevExpress.Xpf.Grid.ColumnBase@    IsSmart$
@ True��65   A    	FieldName$A Id��5�   !   $! 
 DevExpress.Xpf.Grid.BaseColumnB !  Header$B Id 5�   !   C    ReadOnly$
C True��5�   !     5�   &   $
@ True��65   $
A Type��5�   !   $
B Tipo 5�   !   $
C True��5�   !     5�   &   $
@ True��65   $
A Name��5�   !   $B Nombre 5�   !   $
C True��5�   !     5�   &   -   5        D ! Name$D 	TotalCost��5�   !   $
@ True��5�   5   $A 	TotalCost��5�   !   $
C True��5�   !   5�   !   E   TotalSummaryE 5�   "   )" 	 #DevExpress.Xpf.Grid.GridSummaryItem"  5�   &   )# 
 #DevExpress.Xpf.Grid.SummaryItemBaseF #  	FieldName$F 	TotalCost��6:   G #  SummaryType] YDevExpress.Data.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a5$  /DevExpress.Data.Design.SummaryItemTypeConverter$	G Sum$ 6P   H #  DisplayFormat$	H {0}��6b   I #  ShowInColumn$I 	TotalCost��6x   5�      5�      5�      5�      5�      5�      5�      