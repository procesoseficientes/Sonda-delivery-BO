   M S B A M L   `   `   `  ����E  ANextBO.Wpf, Version=1.0.1.0, Culture=neutral, PublicKeyToken=null'clr-namespace:NextBO.Wpf
NextBO.Wpf  5      9!clr-namespace:NextBO.Wpf.ServicesNextBO.Wpf.Services  5
      =#clr-namespace:NextBO.Wpf.ViewModelsNextBO.Wpf.ViewModels  5      ;    5NextBO.Wpf.Views.Entregas.RouteTrackingCollectionView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35h dDevExpress.Xpf.TypedStyles.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aR NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/netfx/2009/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089<x,http://schemas.microsoft.com/winfx/2006/xaml      5      Bd2http://schemas.microsoft.com/expression/blend/2008      5      a ]DevExpress.Xpf.Core.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49al hDevExpress.Xpf.Core.v20.2.Extensions, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a?dx2http://schemas.devexpress.com/winfx/2008/xaml/core    5      Adxe5http://schemas.devexpress.com/winfx/2008/xaml/editors   5      g cDevExpress.Mvvm.v20.2.ViewModel, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a]	 YDevExpress.Mvvm.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aEdxmvvm2http://schemas.devexpress.com/winfx/2008/xaml/mvvm    	 5      *localclr-namespace:NextBO.Wpf    	 5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006    	 5	      6services!clr-namespace:NextBO.Wpf.Services    	 5
      5devAv#clr-namespace:NextBO.Wpf.ViewModels    	 5      j
 fDevExpress.Xpf.LayoutControl.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aHdxlc;http://schemas.devexpress.com/winfx/2008/xaml/layoutcontrol  
 5      ` \DevExpress.Xpf.Map.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a=dxm1http://schemas.devexpress.com/winfx/2008/xaml/map   5        � UseLayoutRounding$
  True��5       � 	Resources 5       �� MergedDictionaries �� Source!   NextBO.Wpf.PictureConverter   PictureConverter&    NextBO.Wpf.IntToBooleanConverter  IntToBooleanConverter  TemplateImageDelivery �Name&   DevExpress.Xpf.Editors.ImageEdit   Stretch   Source   MenuTemplate �� Orientation4  .DevExpress.Xpf.Editors.ImageEditSaveToolButton�� 5   
    5      �� 5      $D >pack://application:,,,/NextBO.Wpf;component/Themes/Common.xaml?�6%   %�  &	        &	      &	 &       5      6%     5      6*   �� 5      .R�5      � $ Grid_Content��6   $
��5000��6-   .+�5      �� $��Center=�6   $��Center=�6:   
�������
���   �._�5        $ Uniform=�6<    6(   ��  5      �� 5   "   .R�5    &   �� $ 
Horizontal=�61   .+�5!   *     5"   '   5#   #   5%      5&      5'      5(      5*      .��5,      ]� .+�5-   
   0 
 *DevExpress.Xpf.LayoutControl.LayoutControl  -   5        	  Name$	 layoutControl��5-   �   . 
 (DevExpress.Xpf.LayoutControl.LayoutGroup
   Orientation$
 Vertical=�6   $��11(�64   $��Stretch=�6M      StretchContentVertically$
 True��6i   .+�5.        -   5          Name$ entityGroup��5.   8   $
 
Horizontal=�6   .+�5/        $
 
Horizontal=�6#   $��	0,25,0,25q�6<    J� RenderTransformOrigin$ 0.518,0.477&�6O   .+�50        .+�51      &   DevExpress.Xpf.Core.DXTabControl  .@�52      #  DevExpress.Xpf.Core.DXTabItem  �	  �DevExpress.Xpf.Core.Native.HeaderedSelectorItemBase`2[[DevExpress.Xpf.Core.DXTabControl, DevExpress.Xpf.Core.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a],[DevExpress.Xpf.Core.DXTabItem, DevExpress.Xpf.Core.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a]] 	  Header$ Seguimiento Ruta��6+   .��53   "   #
  DevExpress.Xpf.Map.MapControl
  -   5        $��mapControl1��54   M    
  EnableScrolling$
 True��53   1    
  EnableZooming$
 True��6H    
  	ZoomLevel$ 12Q�6]   $	��400��54   5   $��0q�6B    
  CenterPoint 55   5   �� *CenterPoint+ 
  CoordinatesPanelOptions 56   &   0  *DevExpress.Xpf.Map.CoordinatesPanelOptions  57   *   *  $DevExpress.Xpf.Map.MapElementOptions   Visible$ False��6F    
  ScrollButtonsOptions 59   &   -  'DevExpress.Xpf.Map.ScrollButtonsOptions  5:   *   $ False��6C    
  ScalePanelOptions 5<   &   *  $DevExpress.Xpf.Map.ScalePanelOptions  5=   *      HorizontalAlignment$ Center=�6@      Margin$	 -10q�6]      ShowMilesScale$ False��6j      VerticalAlignment$ Bottom=�6�    
  ZoomTrackbarOptions 5?   &   ,  &DevExpress.Xpf.Map.ZoomTrackbarOptions  5@   *   $ Center=�6B   $ 0q�6_      Orientation$ 
Horizontal=�6j   $ Bottom=�6�    
  Layers. 5B   &   (  "DevExpress.Xpf.Map.ImageTilesLayer  #  DevExpress.Xpf.Map.ImageLayer   DataProvider. 5C   *   2  ,DevExpress.Xpf.Map.OpenStreetMapDataProvider  5D   '     5E   &   . 5F   *   ,  &DevExpress.Xpf.Map.BingMapDataProvider     Kind$
 Road=�6B   ,   &NextBO.Wpf.ViewModels.MapViewModelBase    
WpfBingKey!   BingKey#! Z  6N   5G   '   )  #DevExpress.Xpf.Map.InformationLayer  5H   &   (  "DevExpress.Xpf.Map.VectorLayerBase"   EnableHighlighting$" False��6;   #   DataProvider# 5I   *   .  (DevExpress.Xpf.Map.BingRouteDataProvider  5J   .   -   5        routeProvider��0  *DevExpress.Xpf.Map.BingMapDataProviderBase$   BingKey#$ Z  5J   _   5K   -   5M   '   5N   #   5O        5P      $ Seguimiento Vehiculo��6+   .��5Q   "   - 
 'DevExpress.Xpf.LayoutControl.LayoutItem  -   5        %  Name$% ContentImageFirm��5Q   2   $��Stretch=�6L   $��Center=�6h   $
��5000��6�   5S   #   5T        5U      $ GeoCerca��6+   5W      5X      5Y      5Z      5[      5\      &   System.Windows.Controls.DataGrid  5]   
   -   5        &  Name$& 
listPoints��5]      $y�Hidden=�6L   ��6'   �� *LogLocations+6`   5^      5_      