   M S B A M L   `   `   `  ����E  ANextBO.Wpf, Version=1.0.1.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:NextBO.Wpf.ViewModelsNextBO.Wpf.ViewModels  5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49ae aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35h dDevExpress.Xpf.TypedStyles.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aR NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089g	 cDevExpress.Mvvm.v20.2.ViewModel, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a]
 YDevExpress.Mvvm.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49al hDevExpress.Xpf.Core.v20.2.Extensions, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aj fDevExpress.Xpf.LayoutControl.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a  �� DataType$  
 DevExpress.Mvvm.EnumMemberInfo )  %OutlookInspiredEnumMemberInfoTemplate �� Orientation!  DevExpress.Xpf.Core.DXImage   Source2   ,NextBO.Wpf.ViewModels.SortDirectionViewModel(  "DevExpress.Xpf.Editors.ListBoxEdit   ItemTemplate   ItemsSource,  &DevExpress.Xpf.Editors.EnumItemsSource   AllowImages   EnumType%  DevExpress.Xpf.Editors.BaseEdit   	EditValue5   /NextBO.Wpf.ViewModels.DefaultPrintModeViewModel0  *DevExpress.Mvvm.UI.ObjectToObjectConverter   personPrefixToImageConverter
   Map   DevExpress.Mvvm.UI.MapItem	   Source
   Target1	  +DevExpress.Xpf.Core.SvgImageSourceExtension5
  /DevExpress.Xpf.Core.BaseSvgImageSourceExtension 
  Size
 	  Uri  fileViewTemplate � ToolTip � RowDefinitions�� 5      L 9http://schemas.microsoft.com/winfx/2006/xaml/presentation        <x,http://schemas.microsoft.com/winfx/2006/xaml      5      Edxmvvm2http://schemas.devexpress.com/winfx/2008/xaml/mvvm  	  
 5      ?dx2http://schemas.devexpress.com/winfx/2008/xaml/core    5      Adxe5http://schemas.devexpress.com/winfx/2008/xaml/editors   5      Hdxlc;http://schemas.devexpress.com/winfx/2008/xaml/layoutcontrol   5      1	viewModel#clr-namespace:NextBO.Wpf.ViewModels  5      %2  &	        (�� �     5      *, +)7   (�� z    5      *, +)7   &	 �    &	 �    �� 5
      "    6   .R�5   
   �� $ 
Horizontal=�6   .+�5        $��2q�62    6   �� *Image+62   �� 5      $
��12,0q�6.   $
��Bold"�6<   $��Center=�6N   ��6   �� *Name+6N   5      5      �� 5      "   6   .R�5   
     8    6`     $ False��  viewModel:SortOrderPrintMode 6�   �� *SortDirection+5      �� 5      "   6   .R�5   
     8    6`     $ False��' #viewModel:DefaultPrintModeViewModel5        5C      . 5D   
     $	 Dr��6�   
 6   	  	 16,16$F @pack://application:,,,/NextBO.Wpf;component/Resources/Doctor.svg?�6�     5E   
   $	 Mr��6�   
 6   	  	 16,16$B <pack://application:,,,/NextBO.Wpf;component/Resources/Mr.svg?�6�     5F   
   $	 Ms��6�   
 6   	  	 16,16$B <pack://application:,,,/NextBO.Wpf;component/Resources/Ms.svg?�6�     5G   
   $
	 Miss��6�   
 6   	  	 16,16$D >pack://application:,,,/NextBO.Wpf;component/Resources/Miss.svg?�6�     5H   
   $		 Mrs��6�   
 6   	  	 16,16$C =pack://application:,,,/NextBO.Wpf;component/Resources/Mrs.svg?�6�   5I      �� 5J      .R�5K   
   � $��80��6    6   �� *Name+ 5L      �� 5M      $
��Auto �6    �� 5N      $
��Auto �6    .+�5P      �� $
��None=�6   ��6#   �� *Icon+�� 5Q      $��1��6   $��0,5,0,0q�6B   $��Center=�6S   $��CharacterEllipsis=�6p   ��6%   �� *DisplayName+6p   5R      5S      5V      