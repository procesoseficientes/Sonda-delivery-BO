   M S B A M L   `   `   `  ����E  ANextBO.Wpf, Version=1.0.1.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:NextBO.Wpf.ViewModelsNextBO.Wpf.ViewModels  5
      +    %NextBO.Wpf.Views.CheckpointByRoleView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35h dDevExpress.Xpf.TypedStyles.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aR NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/netfx/2009/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089<x,http://schemas.microsoft.com/winfx/2006/xaml      5      Bd2http://schemas.microsoft.com/expression/blend/2008      5      a ]DevExpress.Xpf.Core.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49al hDevExpress.Xpf.Core.v20.2.Extensions, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a?dx2http://schemas.devexpress.com/winfx/2008/xaml/core    5      l hDevExpress.Xpf.Grid.v20.2.Extensions, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aa	 ]DevExpress.Xpf.Grid.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49af
 bDevExpress.Xpf.Grid.v20.2.Core, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aBdxg2http://schemas.devexpress.com/winfx/2008/xaml/grid  	 
  5      g cDevExpress.Mvvm.v20.2.ViewModel, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a] YDevExpress.Mvvm.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aEdxmvvm2http://schemas.devexpress.com/winfx/2008/xaml/mvvm     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5	      9	viewmodel#clr-namespace:NextBO.Wpf.ViewModels     5
        � DataContext  5      1  +DevExpress.Mvvm.UI.ViewModelSourceExtension  *viewmodel:CheckpointViewModel+2  ,DevExpress.Mvvm.UI.Interactivity.Interaction   	Behaviors 5      -  'DevExpress.Xpf.Core.DXMessageBoxService  5   
   -   5          Name$ messageBoxService��5   !   .��5      ]� .+�5   
   ) 	 #DevExpress.Xpf.Grid.TreeListControl  ) 
 #DevExpress.Xpf.Grid.DataControlBase   ItemsSource 6   �� *CheckPointAssignedToRole+   Columns 5      ( 	 "DevExpress.Xpf.Grid.TreeListColumn  5      $ 
 DevExpress.Xpf.Grid.ColumnBase   	FieldName$ Group��5      $ 
 DevExpress.Xpf.Grid.BaseColumn   Header)	  #DevExpress.Xpf.Core.ObjectConverter$ Grupo	 5         ReadOnly$
 True��5        5      $ DisplayName��5      $ Nombre	 5      $
 True��5        5      $
 Type��5       $ Tipo De Aplicación	 5!      $
 True��5"         View 5$      &
 	  DevExpress.Xpf.Grid.TreeListView
  5%      -   5        $��treeList��5,      !	 
  AllowRecursiveNodeChecking$
	 True��5&      
 
  AutoExpandAllNodes$

 True��5'       
  	AutoWidth$
 True��5(       
  CheckBoxFieldName$ Selected��5)       
  ChildNodesPath$ Children��5*       
  KeyFieldName$ Id��5+       
  ParentFieldName$ ParentId��5-       
  ShowCheckboxes$
 true��5.      & 
  DevExpress.Xpf.Grid.DataViewBase   ShowTotalSummary$
 True��5/       50      '  !DevExpress.Mvvm.UI.EventToCommand  51      �  �DevExpress.Mvvm.UI.Interactivity.EventTriggerBase`1[[System.Windows.DependencyObject, WindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35]]   	EventName$ NodeCheckStateChanged��53   !   +  %DevExpress.Mvvm.UI.EventToCommandBase   UseDispatcher True54   !      PassEventArgsToCommand True55   !      Command 52   !   �� *IsSelectedCommand+55   !   57      59      5:      5<      