   M S B A M L   `   `   `  ����E  ANextBO.Wpf, Version=1.0.1.0, Culture=neutral, PublicKeyToken=null'clr-namespace:NextBO.Wpf
NextBO.Wpf  5      9!clr-namespace:NextBO.Wpf.ServicesNextBO.Wpf.Services  5      $    NextBO.Wpf.Views.ParameterView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35h dDevExpress.Xpf.TypedStyles.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aR NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/netfx/2009/xaml/presentation     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089<x,http://schemas.microsoft.com/winfx/2006/xaml      5      a ]DevExpress.Xpf.Core.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49al hDevExpress.Xpf.Core.v20.2.Extensions, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a?dx2http://schemas.devexpress.com/winfx/2008/xaml/core    5      Hmc;http://schemas.openxmlformats.org/markup-compatibility/2006    5      >dxb2http://schemas.devexpress.com/winfx/2008/xaml/bars   5      Adxe5http://schemas.devexpress.com/winfx/2008/xaml/editors   5      l hDevExpress.Xpf.Grid.v20.2.Extensions, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aa	 ]DevExpress.Xpf.Grid.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49af
 bDevExpress.Xpf.Grid.v20.2.Core, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aBdxg2http://schemas.devexpress.com/winfx/2008/xaml/grid  	 
  5	      c _DevExpress.Xpf.Ribbon.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aBdxr4http://schemas.devexpress.com/winfx/2008/xaml/ribbon    5
      d `DevExpress.Xpf.Docking.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aBdxdo5http://schemas.devexpress.com/winfx/2008/xaml/docking   5      g cDevExpress.Mvvm.v20.2.ViewModel, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a] YDevExpress.Mvvm.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aEdxmvvm2http://schemas.devexpress.com/winfx/2008/xaml/mvvm     5      *localclr-namespace:NextBO.Wpf     5      6services!clr-namespace:NextBO.Wpf.Services     5        � UseLayoutRounding$
  True��5       � 	Resources 5       �� MergedDictionaries �� Source!   NextBO.Wpf.PictureConverter   PictureConverter�� 5   
    5      �� 5      $D >pack://application:,,,/NextBO.Wpf;component/Themes/Common.xaml?�6%   %   &	          5      6%   5      2  ,DevExpress.Mvvm.UI.Interactivity.Interaction   	Behaviors 5      +   %NextBO.Wpf.Services.ExportGridService  5   
      View 6&   %  System.Windows.Markup.Reference  *ParameterTableView+-  'DevExpress.Xpf.Core.DXMessageBoxService  5   
   .  (DevExpress.Mvvm.UI.SaveFileDialogService  5   
   .��5!      ]� .+�5"   
   )  #DevExpress.Xpf.Ribbon.RibbonControl  -   5          Name$ ribbonControl��5"         RibbonStyle$ 
Office2019=�63   $	��Top=�6L      ShowApplicationButton$ False��6a   	   Items.	 5#      5  /DevExpress.Xpf.Ribbon.RibbonDefaultPageCategory  2	  ,DevExpress.Xpf.Ribbon.RibbonPageCategoryBase
 	  Caption$
 defaultCategory��6,    	  Pages. 5$      &
   DevExpress.Xpf.Ribbon.RibbonPage
   
  Caption)  #DevExpress.Xpf.Core.ObjectConverter$
 Home 6!    
  Groups. 5%      +  %DevExpress.Xpf.Ribbon.RibbonPageGroup     Caption$ Acciones��6*      Items. 5&      '  !DevExpress.Xpf.Bars.BarButtonItem  !  DevExpress.Xpf.Bars.BarItem   Content$ Agregar 6,      Command 5'   ,   ��  �� ElementName$ ParameterTableView�� �� Path$ Commands.AddNewRow�   
LargeGlyph 5(   ,   1  +DevExpress.Xpf.Core.SvgImageSourceExtension  
   Uri$C =pack://application:,,,/NextBO.Wpf;component/Resources/Add.svg?�   Glyph 5)   ,     $C =pack://application:,,,/NextBO.Wpf;component/Resources/Add.svg?�5*        5+      $ Exportar��6*   . 5,        $ Previsualizar 6,    5-   ,   �� *ShowPreviewCommand+ 5.   ,     $L Fpack://application:,,,/NextBO.Wpf;component/Resources/PrintPreview.svg?� 5/   ,     $L Fpack://application:,,,/NextBO.Wpf;component/Resources/PrintPreview.svg?�  50      $ Exportar 6,      CommandParameter$
 XLSX��52   ,    51   ,   �� *ExportGridCommand+ 53   ,     $T Npack://application:,,,/NextBO.Wpf;component/Resources/Controls/ExportToXLS.svg?� 54   ,     $T Npack://application:,,,/NextBO.Wpf;component/Resources/Controls/ExportToXLS.svg?�  55      $ Exportar 6,   $	 PDF��57   ,    56   ,   �� *ExportGridCommand+ 58   ,     $T Npack://application:,,,/NextBO.Wpf;component/Resources/Controls/ExportToPDF.svg?� 59   ,     $T Npack://application:,,,/NextBO.Wpf;component/Resources/Controls/ExportToXLS.svg?�5:      5;      5<      5=      (  "DevExpress.Xpf.Docking.LayoutGroup  5?   
   $��Stretch=�5@      $��Stretch=�5A      +  %DevExpress.Xpf.Docking.BaseLayoutItem   Margin$ 
10,10,10,0q�5B         Orientation 5?      �� *ViewSettings.Orientation+   Items. 5C      (  "DevExpress.Xpf.Docking.LayoutPanel     AllowSizing$
 True��6   "   VerticalScrollBarVisibility$ Disabled=�5D      $   HorizontalScrollBarVisibility$ Disabled=�5E         
AllowClose$ False��5F         	AllowDrag$ False��5G          
AllowFloat$  False��5H      !   	AllowHide$! False��5I      "   ShowCaption$" False��5J      #   	ItemWidth$# * �5K      $   
ItemHeight$$ * �5L      (  "DevExpress.Xpf.Docking.ContentItem%   Content.% 5M      � .+�5N      % 	 DevExpress.Xpf.Grid.GridControl  -   5        &  Name$& tableViewGridControl��5N   &   ) 
 #DevExpress.Xpf.Grid.DataControlBase'   
ShowBorder$' False��5P   &   (   AutoExpandAllGroups$
( True��5Q   &   )   ClipboardCopyMode$) ExcludeHeader=�5R   &   #*   EnableSmartColumnsGeneration$
* True��5S   &   +   ItemsSource+ 5O   &   �� *
Entities+ 5T      '   !NextBO.Wpf.GridSaveLayoutBehavior  5U      -   5        SerializeHelper��,   FileName$, ParameterTableView.xml��5V   ;   -   View- 5X      # 	 DevExpress.Xpf.Grid.TableView  5Y      -   5        $��ParameterTableView��5Y   ,   .   AllowPerPixelScrolling$
. True��5Z       & 
  DevExpress.Xpf.Grid.DataViewBase/   AllowEditing$
/ True��5[       0   ShowSearchPanelMode$0 Always=�5\       1   	AutoWidth$
1 True��5]       %2   SearchPanelHorizontalAlignment	2 Right5^       3   SearchPanelNullText$!3 Buscar Parametro (Ctrl + F)��5_       4   ShowAutoFilterRow$
4 True��5`       "5   ShowCriteriaInAutoFilterRow$
5 True��5a       6   ColumnFilterPopupMode$6 Excel=�5b       7   BehaviorsTemplate7 5c   "   �� 5d   &   .R�5e   *   �� .��5f   .   '  !DevExpress.Mvvm.UI.EventToCommand  �  �DevExpress.Mvvm.UI.Interactivity.EventTriggerBase`1[[System.Windows.DependencyObject, WindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35]]8   	EventName$8 ValidateRow��6D   9   PassEventArgsToCommand9 True5h   D   +  %DevExpress.Mvvm.UI.EventToCommandBase:   Command: 5g   D   �� *ItemSelectedUpdatedCommand+5i   /   5j   +   5k   '    ;   RowCellMenuCustomizations; 5m   "     5n   &   $ Editar 68    5o   ,   �� *ItemUpdatedCommand+ 5p   ,     $D >pack://application:,,,/NextBO.Wpf;component/Resources/Edit.svg?�5r      <   Columns< 5t      $ 	 DevExpress.Xpf.Grid.GridColumn  5u      $ 
 DevExpress.Xpf.Grid.ColumnBase=   IsSmart$
= True��6-   >   	FieldName$> Id��5v   !   $ 
 DevExpress.Xpf.Grid.BaseColumn?   Header$? Id 5w   !   @   ReadOnly$
@ True��5x   !     5y      $
= True��6-   $> ParameterGroup��5z   !   $? Grupo 5{   !     5|      $
= True��6-   $
> Name��5}   !   $? Nombre 5~   !     5      $
= True��6-   $> Value��5�   !   $? Valor 5�   !     5�      $
= True��6-   $> 	CreatedBy��5�   !   $? 
Creado Por 5�   !   A   Visible$
A True��5�   !   $
@ True��5�   !     5�      $
= True��6-   $> CreationDate��5�   !   $? 	Creado el 5�   !   $
A True��5�   !   $
@ True��5�   !   B   EditSettingsB 5�   "   6  0DevExpress.Xpf.Editors.Settings.DateEditSettings  5�   &   6   0DevExpress.Xpf.Editors.Settings.TextEditSettingsC    Mask$C dd/MM/yyyy hh:mm:ss tt��6;   D    MaskUseAsDisplayFormat$
D True��5�   /   5�        5�      $
= True��6-   $> 
ModifiedBy��5�   !   $? Modificado Por 5�   !   $
A True��5�   !   $
@ True��5�   !     5�      $
= True��6-   $> ModifiedDate��5�   !   $? Modificado el 5�   !   $
A True��5�   !   $
@ True��5�   !   B 5�   "     5�   &   $C dd/MM/yyyy hh:mm:ss tt��6;   $
D True��5�   /   5�      E   GroupSummaryE 5�      )! 	 #DevExpress.Xpf.Grid.GridSummaryItem!  5�      )" 
 #DevExpress.Xpf.Grid.SummaryItemBaseF "  SummaryType] YDevExpress.Data.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a5#  /DevExpress.Data.Design.SummaryItemTypeConverter$F Count# 62   5�      5�      5�      5�      5�      5�      