   M S B A M L   `   `   `  ����E  ANextBO.Wpf, Version=1.0.1.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:NextBO.Wpf.ViewModelsNextBO.Wpf.ViewModels  5      'clr-namespace:NextBO.Wpf
NextBO.Wpf  5      *    $NextBO.Wpf.Views.CenterOfServiceView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35h dDevExpress.Xpf.TypedStyles.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aR NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/netfx/2009/xaml/presentation     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089<x,http://schemas.microsoft.com/winfx/2006/xaml      5      a ]DevExpress.Xpf.Core.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49al hDevExpress.Xpf.Core.v20.2.Extensions, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a?dx2http://schemas.devexpress.com/winfx/2008/xaml/core    5      Hmc;http://schemas.openxmlformats.org/markup-compatibility/2006    5      >dxb2http://schemas.devexpress.com/winfx/2008/xaml/bars   5      Adxe5http://schemas.devexpress.com/winfx/2008/xaml/editors   5      c _DevExpress.Xpf.Ribbon.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aBdxr4http://schemas.devexpress.com/winfx/2008/xaml/ribbon    5	      j	 fDevExpress.Xpf.LayoutControl.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aHdxlc;http://schemas.devexpress.com/winfx/2008/xaml/layoutcontrol  	 5
      g
 cDevExpress.Mvvm.v20.2.ViewModel, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a] YDevExpress.Mvvm.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aEdxmvvm2http://schemas.devexpress.com/winfx/2008/xaml/mvvm  
   5      9	viewmodel#clr-namespace:NextBO.Wpf.ViewModels  
   5      *localclr-namespace:NextBO.Wpf  
   5        � UseLayoutRounding$
  True��5       � DataContext 5      1  +DevExpress.Mvvm.UI.ViewModelSourceExtension  *$"viewmodel:CenterOfServiceViewModel+ � 	Resources 5       �� MergedDictionaries �� Source!   NextBO.Wpf.PictureConverter   PictureConverter�� 5   
    5      �� 5      $D >pack://application:,,,/NextBO.Wpf;component/Themes/Common.xaml?�6%   %   &	          5      6%   5      2  ,DevExpress.Mvvm.UI.Interactivity.Interaction   	Behaviors 5      -  'DevExpress.Xpf.Core.DXMessageBoxService  5   
   .��5       ]� .+�5!   
   )  #DevExpress.Xpf.Ribbon.RibbonControl  -   5          Name$ ribbonControl��5!         RibbonStyle$ 
Office2019=�63   $	��Top=�6L      ShowApplicationButton$ False��6a   	   Items.	 5"      &   DevExpress.Xpf.Ribbon.RibbonPage  
   Caption)  #DevExpress.Xpf.Core.ObjectConverter$

 Home 6      Groups. 5#      +  %DevExpress.Xpf.Ribbon.RibbonPageGroup     Caption$ Acciones��6&      Items. 5$      '	  !DevExpress.Xpf.Bars.BarButtonItem	  !
  DevExpress.Xpf.Bars.BarItem 
  Content$ Guardar 6(    
  Command 6:   �� *SaveCommand+ 
  Glyph 5%   !   1  +DevExpress.Xpf.Core.SvgImageSourceExtension  
   Uri$D >pack://application:,,,/NextBO.Wpf;component/Resources/Save.svg?� 
  
LargeGlyph 5&   !     $D >pack://application:,,,/NextBO.Wpf;component/Resources/Save.svg?�	  5'      $ 	Inactivar 6(    5(   ,   �� *DeactiveCommand+ 
  CommandParameter 5)   ,   �� *Entity+ 5*   ,     $F @pack://application:,,,/NextBO.Wpf;component/Resources/Delete.svg?� 5+   ,     $F @pack://application:,,,/NextBO.Wpf;component/Resources/Delete.svg?�	  5,      $ Activar 6(    5-   ,   �� *ActivateCommand+ 5.   ,   �� *Entity+ 5/   ,     $F @pack://application:,,,/NextBO.Wpf;component/Resources/Active.svg?� 50   ,     $F @pack://application:,,,/NextBO.Wpf;component/Resources/Active.svg?�51        52      $ Cerrar��6&   . 53      	  $ Guardar y cerrar 6(    6C   �� *SaveAndCloseCommand+ 54   !     $L Fpack://application:,,,/NextBO.Wpf;component/Resources/SaveAndClose.svg?� 55   !     $L Fpack://application:,,,/NextBO.Wpf;component/Resources/SaveAndClose.svg?�	  56      $ Cerrar 6(    69   �� *CloseCommand+ 57   !     $E ?pack://application:,,,/NextBO.Wpf;component/Resources/Close.svg?� 58   !     $E ?pack://application:,,,/NextBO.Wpf;component/Resources/Close.svg?�59        5:      . 5;      	  $ Restablecer cambios 6(    6F   �� *ResetCommand+ 5<   !     $L Fpack://application:,,,/NextBO.Wpf;component/Resources/ResetChanges.svg?� 5=   !     $L Fpack://application:,,,/NextBO.Wpf;component/Resources/ResetChanges.svg?�5>      5?      5@      2  ,DevExpress.Xpf.Ribbon.RibbonStatusBarControl  5A   
   $��Bottom=�6%   0 	 *DevExpress.Xpf.LayoutControl.LayoutControl  5B   
   -   5          Name$ layoutControl��5B   �   . 	 (DevExpress.Xpf.LayoutControl.LayoutGroup   Orientation$ Vertical=�6   $��11(�64   $��Stretch=�6L      StretchContentVertically$
 True��6h    5C      '  !DevExpress.Mvvm.UI.EventToCommand  5D       �� SourceUpdatedEvent�  �DevExpress.Mvvm.UI.Interactivity.EventTriggerBase`1[[System.Windows.DependencyObject, WindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35]]   Event# Z 6(   +  %DevExpress.Mvvm.UI.EventToCommandBase   Command 6V   �� *UpdateCommand+.+�5F        -   5          Name$ entityGroup��5F   8   $ 
Horizontal=�6   .+�5G        $ Vertical=�6#   $	��Top=�6:   $��Right=�6R   $��5q�6n     5H      $ Vertical=�6#   $	��Top=�6:   $��5q�6R   .+�5I        $ 
Horizontal=�6'   $��	0,25,0,25q�6@    J� RenderTransformOrigin$ 0.518,0.477&�6S   .+�5K        $ Vertical=�6-   $
��auto��6D   .+�5L      �� $��25��6$   $
��Bold"�60   $
��Auto��6B   .��6P   '%Datos Generales Del Cetro De Servicio6w   - 	 'DevExpress.Xpf.LayoutControl.LayoutItem  5M         Label$ Nombre��6.   $��10,0,0,0q�6=      AddColonToLabel$
 True��6O      Content. 5N   "   %  DevExpress.Xpf.Editors.TextEdit  %  DevExpress.Xpf.Editors.BaseEdit   	EditValue 6/   �� *Entity.Name+  �� UpdateSourceTrigger$  PropertyChanged=�! �� ValidatesOnDataErrors$
! True��" �� NotifyOnSourceUpdated$
" True��5O        5P      $ Contacto��6.   $��10,0,0,0q�6@   $
 True��6R   . 5Q   "      6/   �� *Entity.Contact+$  PropertyChanged=�$
! True��$
" True��5R        5S      $ Correo Electronico��6.   $��10,0,0,0q�6I   $
 True��6[   . 5T   "     #   MaskType$# RegEx=�6/   $   Mask$/$ )(\w|[\.\-])+@[a-zA-Z0-9.-]+.[a-zA-Z]{2,4}��5U   /   %   ValidateOnTextInput$
% True��5V   /    5W   /   �� *Entity.Email+$  PropertyChanged=�$
! True��$
" True��5X        5Z      $ 	Direccion��6.   $��10,0,0,0q�6A   $
 True��6S   . 5[   "      6/   �� *Entity.Address+$  PropertyChanged=�$
! True��$
" True��5\        5]      $% Correo Electronico Del Contacto��6.   $��10,0,0,0q�6W   $
 True��6i   . 5^   "     $# RegEx=�6/   $/$ )(\w|[\.\-])+@[a-zA-Z0-9.-]+.[a-zA-Z]{2,4}��5_   /   $
% True��5`   /    5a   /   �� *Entity.ContactEmail+$  PropertyChanged=�$
! True��$
" True��5b        5c      $��10,0,0,0q�6/   $ Numero de Telefono��6B   $
 True��6]   &   
IsRequired$
& True��6t   . 5d   "   '  !DevExpress.Xpf.Editors.ButtonEdit  '   IsTextEditable' True61   (   AllowDefaultButton	( False5e   -   $# Simple=�5f   -   $$ 	0000-0000��5g   -   )   MaskUseAsDisplayFormat$
) True��5h   -   $
��auto��5i   �    6-   �� *Entity.PhoneNumber+$  PropertyChanged=�$
! True��$
" True��*   Buttons.* 5j   &   '  !DevExpress.Xpf.Editors.ButtonInfo  +   	GlyphKind$+ Custom=�65   .  (DevExpress.Xpf.Editors.CommandButtonInfo,   Command, 6H   �� *Contacts.HomeCallCommand+-   Content.- 5k   *   !  DevExpress.Xpf.Core.DXImage  $	��3,0q�6�   .   Source. 65     5  /DevExpress.Xpf.Core.BaseSvgImageSourceExtension/   Size	/ 16,16$S Mpack://application:,,,/NextBO.Wpf;component/Resources/Buttons/Glyph_Phone.svg?�6�   5l   '   5m   #   5n        5o      $ 	Sitio Web��6.   $��10,0,0,0q�6A   $
 True��6S   . 5p   "      6/   �� *Entity.Website+$  PropertyChanged=�$
! True��$
" True��5q      5s      5t      5u      5v      5w      5x      5y      