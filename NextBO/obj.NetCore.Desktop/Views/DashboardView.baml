   M S B A M L   `   `   `  ����E  ANextBO.Wpf, Version=1.0.1.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:NextBO.Wpf.ViewModelsNextBO.Wpf.ViewModels  5	      'clr-namespace:NextBO.Wpf
NextBO.Wpf  5
      $    NextBO.Wpf.Views.DashboardView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49ae aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35h dDevExpress.Xpf.TypedStyles.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aR NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35L 9http://schemas.microsoft.com/winfx/2006/xaml/presentation        5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089<x,http://schemas.microsoft.com/winfx/2006/xaml      5      Lmc;http://schemas.openxmlformats.org/markup-compatibility/2006      5      Bd2http://schemas.microsoft.com/expression/blend/2008      5      l	 hDevExpress.Xpf.Core.v20.2.Extensions, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a?dx2http://schemas.devexpress.com/winfx/2008/xaml/core   	 5      j
 fDevExpress.Xpf.LayoutControl.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aHdxlc;http://schemas.devexpress.com/winfx/2008/xaml/layoutcontrol  
 5      g cDevExpress.Mvvm.v20.2.ViewModel, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a] YDevExpress.Mvvm.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aEdxmvvm2http://schemas.devexpress.com/winfx/2008/xaml/mvvm     5      9	viewmodel#clr-namespace:NextBO.Wpf.ViewModels     5	      *localclr-namespace:NextBO.Wpf     5
        � DataContext  5      1  +DevExpress.Mvvm.UI.ViewModelSourceExtension  *viewmodel:DashboardViewModel+ � 	Resources 5         LayoutItemStyle �� 
TargetType- 
 'DevExpress.Xpf.LayoutControl.LayoutItem �� Property �� Value  MainGroupHeaderTemplate0 
 *DevExpress.Xpf.LayoutControl.LayoutControl4 
 .DevExpress.Xpf.LayoutControl.LayoutControlBase   Padding'  !DevExpress.Xpf.Core.ScrollControl   
ScrollBars �� ElementName��%�  &	        &	 b     �� 5   
   "  5      .�5      ��  �@ AddColonToLabel$
 True��5      5      �� 5   
   .R�5        $ 2q�6!   $
 None=�5   !   
������  5      ��61   .+�5      �� $��Next BackOffice��6   $
��Left=�5      $��Center=�5      �� 5      $��Right=�5      $��Center=�5      $
��Bold"�5       ��5      �� *!DataContext.LoggedUser.RoleName+$ 
LayoutRoot��5       5!      5"      5#      2  ,DevExpress.Mvvm.UI.Interactivity.Interaction   	Behaviors 5$      -  'DevExpress.Xpf.Core.DXMessageBoxService  5%   
   #   NextBO.Wpf.UserSessionService  5&   
   .��5(        -   5        	  Name$	 
LayoutRoot��5(      .	 
 (DevExpress.Xpf.LayoutControl.LayoutGroup
 	  Orientation$
 Vertical=�5)         StretchContentVertically$ False��5*      
������  	  	ItemStyle# [  5,      .+�5-   
   	   	  HeaderTemplate# [ 6    	  View$ GroupBox=�5.         	ItemSpace$ 10Q�5/         AllowVerticalSizing$
 True��50      $
 Vertical=�52        51      �� *
LoggedUser+.+�54      � .+�55      �� $��¡Bienvenido!��6   $��80(�56      $
��Wrap=�57      $	��Top=�58      59      � 5:      .+�5;      �� $��50(�5<      $��
50,-15,0,0q�5=      $
��Wrap=�5>      $	��Top=�5?      ��5;      �� *Name+5?      5@      5B      5C      5D      