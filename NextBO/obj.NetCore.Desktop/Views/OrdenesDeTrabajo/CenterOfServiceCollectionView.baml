   M S B A M L   `   `   `  ����E  ANextBO.Wpf, Version=1.0.1.0, Culture=neutral, PublicKeyToken=null'clr-namespace:NextBO.Wpf
NextBO.Wpf  5      9!clr-namespace:NextBO.Wpf.ServicesNextBO.Wpf.Services  5      4    .NextBO.Wpf.Views.CenterOfServiceCollectionView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35h dDevExpress.Xpf.TypedStyles.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aR NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/netfx/2009/xaml/presentation     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089<x,http://schemas.microsoft.com/winfx/2006/xaml      5      a ]DevExpress.Xpf.Core.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49al hDevExpress.Xpf.Core.v20.2.Extensions, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a?dx2http://schemas.devexpress.com/winfx/2008/xaml/core    5      Hmc;http://schemas.openxmlformats.org/markup-compatibility/2006    5      >dxb2http://schemas.devexpress.com/winfx/2008/xaml/bars   5      Adxe5http://schemas.devexpress.com/winfx/2008/xaml/editors   5      l hDevExpress.Xpf.Grid.v20.2.Extensions, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aa	 ]DevExpress.Xpf.Grid.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49af
 bDevExpress.Xpf.Grid.v20.2.Core, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aBdxg2http://schemas.devexpress.com/winfx/2008/xaml/grid  	 
  5	      c _DevExpress.Xpf.Ribbon.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aBdxr4http://schemas.devexpress.com/winfx/2008/xaml/ribbon    5
      d `DevExpress.Xpf.Docking.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aBdxdo5http://schemas.devexpress.com/winfx/2008/xaml/docking   5      g cDevExpress.Mvvm.v20.2.ViewModel, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a] YDevExpress.Mvvm.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aEdxmvvm2http://schemas.devexpress.com/winfx/2008/xaml/mvvm     5      *localclr-namespace:NextBO.Wpf     5      6services!clr-namespace:NextBO.Wpf.Services     5        � UseLayoutRounding$
  True��5       � 	Resources 5       �� MergedDictionaries �� Source!   NextBO.Wpf.PictureConverter   PictureConverter&    NextBO.Wpf.IntToBooleanConverter  IntToBooleanConverter�� 5   
    5      �� 5      $D >pack://application:,,,/NextBO.Wpf;component/Themes/Common.xaml?�6%   %:   &	        &	        5      6%     5      6*   5      2  ,DevExpress.Mvvm.UI.Interactivity.Interaction   	Behaviors 5      +   %NextBO.Wpf.Services.ExportGridService  5   
      View 6&   %  System.Windows.Markup.Reference  *ServiceCenterTableView+-  'DevExpress.Xpf.Core.DXMessageBoxService  5   
   .  (DevExpress.Mvvm.UI.SaveFileDialogService  5   
   .��5"      ]� .+�5#   
   )  #DevExpress.Xpf.Ribbon.RibbonControl  -   5          Name$ ribbonControl��5#         RibbonStyle$ 
Office2019=�63   $	��Top=�6L      ShowApplicationButton$ False��6a   	   Items.	 5%      5	  /DevExpress.Xpf.Ribbon.RibbonDefaultPageCategory	  2
  ,DevExpress.Xpf.Ribbon.RibbonPageCategoryBase
 
  Caption$
 defaultCategory��6,    
  Pages. 5&      &   DevExpress.Xpf.Ribbon.RibbonPage     Caption)  #DevExpress.Xpf.Core.ObjectConverter$
 Home 6!      Groups. 5'      +  %DevExpress.Xpf.Ribbon.RibbonPageGroup     Caption$ Acciones��6*      Items. 5(      '  !DevExpress.Xpf.Bars.BarButtonItem  !  DevExpress.Xpf.Bars.BarItem   Content$ Agregar 6,      Command 5)   ,   �� *
NewCommand+   
LargeGlyph 5*   ,   1  +DevExpress.Xpf.Core.SvgImageSourceExtension  
   Uri$C =pack://application:,,,/NextBO.Wpf;component/Resources/Add.svg?�   Glyph 5+   ,     $C =pack://application:,,,/NextBO.Wpf;component/Resources/Add.svg?�  5,      $ Editar 6,    5-   ,   �� *EditCommand+   CommandParameter 5.   ,   �� *SelectedEntity+ 5/   ,     $D >pack://application:,,,/NextBO.Wpf;component/Resources/Edit.svg?� 50   ,     $D >pack://application:,,,/NextBO.Wpf;component/Resources/Edit.svg?�  51      $ 	Inactivar 6,    52   ,   �� *DeactiveCommand+ 53   ,   �� *SelectedEntity+ 54   ,     $F @pack://application:,,,/NextBO.Wpf;component/Resources/Delete.svg?� 55   ,     $F @pack://application:,,,/NextBO.Wpf;component/Resources/Delete.svg?�  56      $ Activar 6,    57   ,   �� *ActivateCommand+ 58   ,   �� *SelectedEntity+ 59   ,     $F @pack://application:,,,/NextBO.Wpf;component/Resources/Active.svg?� 5:   ,     $F @pack://application:,,,/NextBO.Wpf;component/Resources/Active.svg?�5;        5<      $ Exportar��6*   . 5=        $ Previsualizar 6,    5>   ,   �� *ShowPreviewCommand+ 5?   ,     $L Fpack://application:,,,/NextBO.Wpf;component/Resources/PrintPreview.svg?� 5@   ,     $L Fpack://application:,,,/NextBO.Wpf;component/Resources/PrintPreview.svg?�  5A      $ Exportar 6,   $
 XLSX��5C   ,    5B   ,   �� *ExportGridCommand+ 5D   ,     $T Npack://application:,,,/NextBO.Wpf;component/Resources/Controls/ExportToXLS.svg?� 5E   ,     $T Npack://application:,,,/NextBO.Wpf;component/Resources/Controls/ExportToXLS.svg?�  5F      $ Exportar 6,   $	 PDF��5H   ,    5G   ,   �� *ExportGridCommand+ 5I   ,     $T Npack://application:,,,/NextBO.Wpf;component/Resources/Controls/ExportToPDF.svg?� 5J   ,     $T Npack://application:,,,/NextBO.Wpf;component/Resources/Controls/ExportToXLS.svg?�5K      5L      5M      5N      (  "DevExpress.Xpf.Docking.LayoutGroup  5P   
   $��Stretch=�5Q      $��Stretch=�5R      +  %DevExpress.Xpf.Docking.BaseLayoutItem   Margin$ 
10,10,10,0q�5S         Orientation 5P      �� *ViewSettings.Orientation+   Items. 5T      (  "DevExpress.Xpf.Docking.LayoutPanel     AllowSizing$
 True��6   "   VerticalScrollBarVisibility$ Disabled=�5U      $   HorizontalScrollBarVisibility$ Disabled=�5V         
AllowClose$ False��5W         	AllowDrag$ False��5X         
AllowFloat$ False��5Y         	AllowHide$ False��5Z          ShowCaption$  False��5[      !   	ItemWidth$! * �5\      "   
ItemHeight$" * �5]      (  "DevExpress.Xpf.Docking.ContentItem#   Content.# 5^      � .+�5_      % 	 DevExpress.Xpf.Grid.GridControl  -   5        $  Name$$ tableViewGridControl��5_   &   ) 
 #DevExpress.Xpf.Grid.DataControlBase%   
ShowBorder$% False��5b   &   &   AutoExpandAllGroups$
& True��5c   &   '   ClipboardCopyMode$' ExcludeHeader=�5d   &   #(   EnableSmartColumnsGeneration$
( True��5e   &   )   ItemsSource) 5`   &   �� *
Entities+*   SelectedItem* 5a   &   �� *SelectedEntity+ 5f      '  !DevExpress.Mvvm.UI.EventToCommand  5g      +   PassEventArgsToCommand+ True64   �  �DevExpress.Mvvm.UI.Interactivity.EventTriggerBase`1[[System.Windows.DependencyObject, WindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35]],   	EventName$, MouseDoubleClick��5i   <   +  %DevExpress.Mvvm.UI.EventToCommandBase-   Command- 5h   <   �� *EditCommand+.   EventArgsConverter. 5j   "   5  /DevExpress.Xpf.Core.EventArgsToDataRowConverter  5k   &   5m      '   !NextBO.Wpf.GridSaveLayoutBehavior  5n      -   5        SerializeHelper��/   FileName$ / ServiceCenterTableView.xml��5o   ;   0   View0 5q      # 	 DevExpress.Xpf.Grid.TableView  5r      -   5        $��ServiceCenterTableView��5r   ,   1   AllowPerPixelScrolling$
1 True��5s       & 
  DevExpress.Xpf.Grid.DataViewBase2   AllowEditing$
2 True��5t       3   ShowSearchPanelMode$3 Always=�5u       4   	AutoWidth$
4 True��5v       %5   SearchPanelHorizontalAlignment	5 Right5w       6   SearchPanelNullText$*6 $Buscar Centro De Servicio (Ctrl + F)��5x       7   ShowAutoFilterRow$
7 True��5y       "8   ShowCriteriaInAutoFilterRow$
8 True��5z       9   ColumnFilterPopupMode$9 Excel=�5{        :   RowCellMenuCustomizations: 5|   "     5}   &   $ Editar 68    5~   ,   �� *View.DataContext.EditCommand+ 5   ,   �� *	Row.Row+ 5�   ,     $D >pack://application:,,,/NextBO.Wpf;component/Resources/Edit.svg?�5�      ;   Columns; 5�      $ 	 DevExpress.Xpf.Grid.GridColumn  5�      $ 
 DevExpress.Xpf.Grid.ColumnBase<   IsSmart$
< True��6-   $  
 DevExpress.Xpf.Grid.BaseColumn=    Width2! 
 ,DevExpress.Xpf.Grid.GridColumnWidthConverter$= 15! 5�   !   >   	FieldName$> Id��5�   !   ?    Header$? # 5�   !   @   ReadOnly$
@ True��5�   !     5�      $
< True��6-   $
> Name��5�   !   $? Nombre 5�   !   $
@ True��5�   !     5�      $
< True��6-   $> Contact��5�   !   $? Contacto 5�   !   A    Visible$
A True��5�   !   $
@ True��5�   !     5�      $
< True��6-   $> PhoneNumber��5�   !   $? Numero Teléfonico 5�   !   $
A True��5�   !   $
@ True��5�   !     5�      $> Website��6-   $? 
Pagina web 5�   !   B   CellTemplateB 5�   "   �� 5�   &   .R�5�   *   �� �� 5�      -   5        C �� 
TargetName$C _blank��5�   I   ��6$   �� *Data.Website+.�6�   .�5�      �� ��6(   �� *Data.Website+5�      5�      5�   '   5�        5�      $? ¿Es Activo? 6-   $= 60! 5�   -   3"  -DevExpress.Xpf.Core.DXFrameworkContentElementD "  	IsEnabled$D False��5�   -   E   BindingE 5�   -   �� F �� Path$F IsActive�G �� 	Converter#G [ H   EditSettingsH 5�   "   7#  1DevExpress.Xpf.Editors.Settings.CheckEditSettings#  5�   &   5�      I   GroupSummaryI 5�      )$ 	 #DevExpress.Xpf.Grid.GridSummaryItem$  5�      )% 
 #DevExpress.Xpf.Grid.SummaryItemBaseJ %  SummaryType] YDevExpress.Data.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a5&  /DevExpress.Data.Design.SummaryItemTypeConverter$J Count& 62   5�      5�      5�      5�      5�      5�      