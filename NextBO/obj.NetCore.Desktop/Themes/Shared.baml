   M S B A M L   `   `   `  ����E  ANextBO.Wpf, Version=1.0.1.0, Culture=neutral, PublicKeyToken=null3clr-namespace:NextBO.Wpf.ViewsNextBO.Wpf.Views  5      9!clr-namespace:NextBO.Wpf.ControlsNextBO.Wpf.Controls  5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49ae aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35h dDevExpress.Xpf.TypedStyles.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aR NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35l hDevExpress.Xpf.Core.v20.2.Extensions, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49ac	 _DevExpress.Xpf.Ribbon.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49ag
 cDevExpress.Mvvm.v20.2.ViewModel, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a] YDevExpress.Mvvm.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49ap lDevExpress.Xpf.DocumentViewer.v20.2.Core, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49ae aDevExpress.Xpf.Printing.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aR NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089)  	 #DevExpress.Xpf.Ribbon.RibbonControl  �� 
TargetType �� Property �� Value/   )NextBO.Wpf.Views.ObjectsEqualityConverter   objectsEqualityConverter # objectsEqualityInverseConverter   Inverse0  *DevExpress.Mvvm.UI.ObjectToObjectConverter  RibbonStyleToGlyphConverter
   Map   DevExpress.Mvvm.UI.MapItem   Source   Target1  +DevExpress.Xpf.Core.SvgImageSourceExtension5  /DevExpress.Xpf.Core.BaseSvgImageSourceExtension   Size
   Uri ! SettingsToVisibilityConverter	   DefaultTarget ! RibbonStyleToCaptionConverter.   (NextBO.Wpf.Views.RibbonStyleSelectorItem!  DevExpress.Xpf.Bars.BarItem
 �� RelativeSource �� 	Converter,  &DevExpress.Xpf.Bars.BarSplitButtonItem(	  "DevExpress.Xpf.Bars.GalleryControl 	  Gallery!
  DevExpress.Xpf.Bars.Gallery 
  AllowFilter) 
  "ItemDescriptionHorizontalAlignment 
  AutoHideGallery 
  ItemCheckMode 
  ColCount 
  Groups*  $DevExpress.Xpf.Bars.GalleryItemGroup   Caption)  #DevExpress.Xpf.Core.ObjectConverter   Items%  DevExpress.Xpf.Bars.GalleryItem   Caption   Description   	IsChecked �� Mode �� ConverterParameter   Glyph  waitIndicator'  !DevExpress.Xpf.Core.WaitIndicator   DeferedVisibility  silentWaitIndicator � Triggers :� RoutedEvent ��Name �� 
TargetName  �� TargetProperty! W� From	" W� To# g� Duration  BitmapButton$ �� 
TargetType% � 	Resources  Key& �� Orientation' �� Path 	 ObjectToVisibilityConverter8   2NextBO.Wpf.Controls.CustomBackstageDocumentPreview( � RowDefinitions) � ColumnDefinitions* �� 	Converter>  8DevExpress.Mvvm.UI.BooleanToVisibilityConverterExtension6  0DevExpress.Xpf.Printing.BackstageDocumentPreview+   IsPrintersAvailable, �� ElementName)  #DevExpress.Xpf.Editors.ComboBoxEdit-   Printers+  %DevExpress.Xpf.Editors.LookUpEditBase.   ItemsSource'  !DevExpress.Xpf.Editors.ButtonEdit/   IsTextEditable&0   ApplyItemTemplateToSelectedItem%  DevExpress.Xpf.Editors.BaseEdit1   	EditValue2 �� UpdateSourceTrigger3   ItemTemplate!  DevExpress.Xpf.Core.DXImage4   SourceF  @DevExpress.Xpf.DocumentViewer.UriToBitmapImageConverterExtension5   PrintersErrorMessage6   Inverse7   
ShowBorder8   ShowText9   ExportFormats*  $DevExpress.Xpf.Editors.PopupBaseEdit:   PopupFooterButtons;   ShowSizeGrip<   StyleSettings7  1DevExpress.Xpf.Editors.RadioComboBoxStyleSettings=   Buttons'  !DevExpress.Xpf.Editors.ButtonInfo+  %DevExpress.Xpf.Editors.ButtonInfoBase>   IsLeft-  'DevExpress.Xpf.Editors.CommonButtonInfo?   
ButtonKind@   SelectedFormat.  (DevExpress.Xpf.Editors.CommandButtonInfoA   CommandParameterB   CommandC   ContentB  <DevExpress.Xpf.Printing.CustomSettingsHeaderedContentControlD   CustomSettingsHeaderE   CustomSettings4  .DevExpress.Xpf.Printing.DocumentPreviewControlF  NameG   
CursorMode9   3DevExpress.Xpf.DocumentViewer.DocumentViewerControlH    CommandBarStyleI    ZoomModeJ   DocumentSourceK    DocumentSourceL   ShowPageMarginsM � 	ResourcesN �� 
IsReadOnly,!  &DevExpress.Xpf.Editors.ProgressBarEdit)"  #DevExpress.Xpf.Editors.TrackBarEdit*#  $DevExpress.Xpf.Editors.RangeBaseEditO #  MinimumP #  MaximumQ #  	LargeStepR #  	SmallStepS "  StyleSettings6$  0DevExpress.Xpf.Editors.TrackBarZoomStyleSettings�� 5      L 9http://schemas.microsoft.com/winfx/2006/xaml/presentation        ?dx2http://schemas.devexpress.com/winfx/2008/xaml/core    5      Bdxr4http://schemas.devexpress.com/winfx/2008/xaml/ribbon 	   5      >dxb2http://schemas.devexpress.com/winfx/2008/xaml/bars   5      Edxmvvm2http://schemas.devexpress.com/winfx/2008/xaml/mvvm  
   5      'viewclr-namespace:NextBO.Wpf.Views  5      .controls!clr-namespace:NextBO.Wpf.Controls  5      Idxdv<http://schemas.devexpress.com/winfx/2008/xaml/documentviewer   5      Adxe5http://schemas.devexpress.com/winfx/2008/xaml/editors   5	      Ddxp6http://schemas.devexpress.com/winfx/2008/xaml/printing    5
      <x,http://schemas.microsoft.com/winfx/2006/xaml      5      %�$  '         &	  _     &	 r     '�� �     &	     &	 �    &	 @    '  `    7  7  7   7   7   &	 N
    &	 �
    &	 �    7 	 '  E    7  �� 5      "    6   .�5   
   ��  �@  ToolbarShowMode$ 	ShowAbove=�6,   5        5      6$     5      $
 True��6L   �� 5      "  ��6   .�5   
   ��  � ��$ Stretch=�67   �� 5   
    � ��$ Stretch=�65   5        5      . 5   
     $ 
Office2010��6    6-     	 16,16$V Ppack://application:,,,/NextBO.Wpf;component/Resources/RibbonStyle/Office2010.svg?�  5   
   $ 
OfficeSlim��6    6-     	 16,16$V Ppack://application:,,,/NextBO.Wpf;component/Resources/RibbonStyle/OfficeSlim.svg?�  5   
   $ TabletOffice��6    6/     	 16,16$X Rpack://application:,,,/NextBO.Wpf;component/Resources/RibbonStyle/TabletOffice.svg?�5        5      $	 Visible��6K   . 5   
     $ 	Collapsed��6+    6   Z� 6+   5        5      $	 Visible��6K   . 5   
     $ 
Office2007��6   $ Office 2007��6-     5    
   $ 
Office2010��6   $ Office Classic��6-     5!   
   $ 
OfficeSlim��6   $ Office Slim��6-     5"   
   $ TabletOffice��6   $ Tablet Office��6/   5#      �� 5$      "   6   .�5%   
   ��  �@ RibbonStyle$ SmallWithText=�6(   �� 5&   
    �@ Content 6$   �� *SelectedRibbonStyle+
 �� *Self+8   �� 5'   
    �@ ActAsDropDown$
 True��6*   �� 5(   
    �@ Glyph 6"   �� *SelectedRibbonStyle+
 �� *Self+8  �� 5)   
    �@ 	MergeType$ Replace=�6&   �� 5*   
    �@ PopupTemplate 5+      �� 5,      .R�5-      	  $��galleryControl��6)   . 5.      
  $ False��6&   $
 Left=�6:   $
 True��6d   $ Single=�6{   $ 1��6�   . 5/        $ Classic 63   . 50   "     $ Office Classic 62   $$ MS Office Classic style Ribbon 6K    6x   �� *Selector.SelectedRibbonStyle+$ TwoWay=�8  $ 
Office2010�� 6    $V Ppack://application:,,,/NextBO.Wpf;component/Resources/RibbonStyle/Office2010.svg?�51        52      $ Tablet 63   . 53   "     $ Tablet Office 62   $1 +Emulates the UI found in MS Office for iPad 6J    6�   �� *Selector.SelectedRibbonStyle+$ TwoWay=�8  $ TabletOffice�� 6    $X Rpack://application:,,,/NextBO.Wpf;component/Resources/RibbonStyle/TabletOffice.svg?�  54   "   $ Office Slim 62   $% MS Office Store inspired Ribbon 6H    6v   �� *Selector.SelectedRibbonStyle+$ TwoWay=�8  $ 
OfficeSlim�� 6
    $V Ppack://application:,,,/NextBO.Wpf;component/Resources/RibbonStyle/OfficeSlim.svg?�55      56      57      58      5:      5;      �� 5<      .R�5=   
     $
 True��6   5>      �� 5?      .R�5@   
     $��waitIndicator��64   $
 True��6    5A      :� 5B      $ FrameworkElement.Unloaded��6   .[�5C      �� .��5D      �� $ board��6%   .��5E      W� $ waitIndicator��6.   $  Opacity�6T   ! 1.06x   " 06�   $# 0:0:1.5D�6�   5F      5G      5H      5J      5K      �� 5L      "  ��6   .�5M   
   ��  � �� 5N      �� 5O      "$ ��6"   % 5P      ��  5Q      ObjectToVisibilityConverter $	 Visible��6]   . 5R        $ 	Collapsed��6?    6-   Z� 6?   5S      5T      .R�5U      �� $& Vertical=�6!   .+�5V      �� $
��None=�6    $��Center=�6{   ��6/   �� *	Content+
 �� *TemplatedParent+6{   �� 5W      $��Center=�6�   ��6$   �� $!' (AutomationProperties.Name)�
 �� *TemplatedParent+y�5X   $   �� $!' (AutomationProperties.Name)�
 �� *TemplatedParent+8   5Y      5Z      5\      5]      �� 5^      "   6   .�5_   
   ��  � �� 5`      �� 5a      "$  6"   .R�5b      � $��	printGrid��6&   $��5q�6   ( 5c      �� 5d      $��* �6,   �� 5e      $
��Auto �6,   ) 5g      �� 5h      $��40 �6/   �� 5i      $
��Auto �6/   �� 5j      $��40 �6/   �� 5k      $��* �6/   .+�5m      �� $& Vertical=�6%   $��1��6<   .+�5n      � .+�5o   "   �� $& Vertical=�6�   y�6-   �� *IsPrintOptionsVisible+*   .+�5p   &   �� $��Print��60   $��40(�6=   $��	0,30,0,20q�6K   �� 5q   &   $& 
Horizontal=�61   #{�z+ 6J   .+�5r   *   �� $��90��61   $��90��6=   $��0,0,5,0q�6H   ��5s   )   �� $, documentViewer��$' PrintDirectCommand���5t   )   �� *SelectedPrinter.Name+
 �� *TemplatedParent+.��5u   .   �� .+�5v   2   �� $��Center=�6�   $
��None=�6�   ��69     $E ?pack://application:,,,/NextBO.Wpf;component/Resources/Print.svg?�6�   �� 5w   2   $��Print��6<   $��Center=�6I   $��Center=�6f   5x   /   5y   +   �� 5z   *   $3��-Specify how you want the report to be printed��64   $��WrapWithOverflow=�6i   $	��142��6�   $��Center=�6�   5{   '   �� 5|   &   $��Printer��60   $��22(�6?   $��0,17,0,5q�6M     5}   &   #. z- 67   	/ False5~   )   $
0 True��6@   #{�z+ 6g   1 5}   `   �� *SelectedPrinter+$ TwoWay=�
 �� *TemplatedParent+$2 PropertyChanged=�3 5   *   �� 5�   .   .R�5�   2   ]� .+�5�   6     $
��Left=�6�   $��3q�6�   $��16��6�   $��16��6�   4 6A   �� *
ImageUri+   6�   �� 5�   6   $	��Top=�6]   $��3q�6r   ��6@   �� *DisplayName+6r   �� 5�   6   $��Bottom=�6X   $��Light"�6p   $��3q�6�   ��6@   �� *Status+6�   5�   3   5�   /   5�   '   �� 5�   &   #��z5 60   $
��Wrap=�6^   $
��Left=�6r   $	��220��6�   y�5�   0   �� *IsPrintersAvailable+*   $
6 True���� 5�   &   $��Print Options��6-   $
��Left=�6E   $	��0,7q�6`   ��5�   %   �� $, documentViewer��$' PageSetupCommand�5�   #   �� 5�   "   $& Vertical=�6�   y�6-   �� *IsPrintOptionsVisible+*   $
6 True��.+�5�   &   �� $��Export��60   $��40(�6>   $��	0,30,0,20q�6L   �� 5�   &   $& 
Horizontal=�61   .+�5�   *     $7 False��6;   $8 False��6N   $��90��6_   $��90��6k   $��0,0,5,0q�6v   #. z9 5�   1   : OkCancel5�   1   $; FalseY�6O   1 5�   _   �� *SelectedFormat+$ TwoWay=�
 �� *TemplatedParent+$2 PropertyChanged=�< 5�   .     5�   2   = 5�   2     $
> True��6A   $? Simple=�6O   #A z@ 5�   -   B 5�   -   �� $, documentViewer��$' ExportCommand�.C 5�   6   �� .+�5�   :     $��Center=�6�   $
��None=�6�   4 6E     	 40,40$O Ipack://application:,,,/NextBO.Wpf;component/Resources/Controls/Export.svg?�6�   �� 5�   :   $��Export��6D   $��Center=�6R   $��Center=�6o   5�   7   5�   3   5�   +   �� 5�   *   $z��tThe DevExpress Reporting platform allows you to export any report to PDF, XLS, RTF and countless image file formats.��64   $��WrapWithOverflow=�5�      $	��142��6=   $��Center=�6I   5�   '   5�   #   5�        5�      #��zD 6G   #��zE 5�   G   y�5�   w   �� *CustomSettings+8*   5�   G   5�        5�      $F documentViewer��6E   $��3��65   $G HandTool=�6]   $
H None=�6s   $I 
FitToWidth=�6�   #K zJ 5�   6   $L False��6h   � 5�      $��1��6   $��3��6,   $��0,2,0,0q�6<   M 5�      ���� 5�   "   '��       "  ��6(   .�5�   &   ��  � ��$ 0q�6H   �� 5�   &    � ��$ 0q�6@   5�   #   5�      .+�5�      �� $& 
Horizontal=�6)   $
��Left=�6B   $
��15,0q�6]   .+�5�   "   �� $��Center=�6)   ��6F   �� $, documentViewer��$' PreviousPageCommand���5�   &   �� 5�   *   .R�5�   .     4 69     	 16,16$U Opack://application:,,,/NextBO.Wpf;component/Resources/Controls/PagePrevious.svg?�5�   +   5�   #   �� 5�   "   $
N True��6*   $��Center=�6<   ��6Y   �� $, documentViewer��$' CurrentPageNumber��� 5�   "   $��of��6,   $��Center=�66   $��3q�6S   �� 5�   "   $��Center=�6,   $��3q�6I   ��6T   �� $, documentViewer��$' 	PageCount��� 5�   "   $��Center=�6)   ��6F   �� $, documentViewer��$' NextPageCommand���5�   &   �� 5�   *   .R�5�   .     4 69     	 16,16$Q Kpack://application:,,,/NextBO.Wpf;component/Resources/Controls/PageNext.svg?�5�   +   5�   #   !  5�   "   $��Center=�66   $	��250��6Q   $
��Left=�6]   1 5�   6   �� $, documentViewer��$' Document.ProgressPosition�$ OneWay=�y�5�   6   �� $, documentViewer��$' Document.InProgress�$ OneWay=�   5�      �� 5�      $& 
Horizontal=�6)   $��Right=�6B   .+�5�   "   "  $	O 0.1Q�63   $	P 2.5Q�6A   $
Q 0.05Q�6O   $
R 0.02Q�6`   $	��150��6�   $��0,4,2,0q�5�   #   
������ 1 5�   q   �� $, documentViewer��$' 
ZoomFactor�S 5�   &   $  5�   *   5�   #   �� 5�   "   $��Center=�6)   $��2q�6F   ��6Q   �� $, documentViewer��$' PageSetupCommand���5�   &   �� 5�   *   .R�5�   .     4 69     	 16,16$N Hpack://application:,,,/NextBO.Wpf;component/Resources/Controls/Pages.svg?�5�   +   5�   #   �� 5�   "   $��Center=�6)   $��2q�6F   ��6Q   �� $, documentViewer��$' ScaleCommand���5�   &   �� 5�   *   .R�5�   .     4 69     	 16,16$N Hpack://application:,,,/NextBO.Wpf;component/Resources/Controls/Scale.svg?�5�   +   5�   #   5�      5�      5�      5�      5�      5�      5�      