   M S B A M L   `   `   `  ����E  ANextBO.Wpf, Version=1.0.1.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:NextBO.Wpf.ViewModelsNextBO.Wpf.ViewModels  5      'clr-namespace:NextBO.Wpf
NextBO.Wpf  5          NextBO.Wpf.Views.UserView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35h dDevExpress.Xpf.TypedStyles.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aR NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/netfx/2009/xaml/presentation     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089<x,http://schemas.microsoft.com/winfx/2006/xaml      5      a ]DevExpress.Xpf.Core.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49al hDevExpress.Xpf.Core.v20.2.Extensions, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a?dx2http://schemas.devexpress.com/winfx/2008/xaml/core    5      Hmc;http://schemas.openxmlformats.org/markup-compatibility/2006    5      >dxb2http://schemas.devexpress.com/winfx/2008/xaml/bars   5      Adxe5http://schemas.devexpress.com/winfx/2008/xaml/editors   5      c _DevExpress.Xpf.Ribbon.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aBdxr4http://schemas.devexpress.com/winfx/2008/xaml/ribbon    5	      j	 fDevExpress.Xpf.LayoutControl.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aHdxlc;http://schemas.devexpress.com/winfx/2008/xaml/layoutcontrol  	 5
      g
 cDevExpress.Mvvm.v20.2.ViewModel, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a] YDevExpress.Mvvm.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aEdxmvvm2http://schemas.devexpress.com/winfx/2008/xaml/mvvm  
   5      9	viewmodel#clr-namespace:NextBO.Wpf.ViewModels  
   5      *localclr-namespace:NextBO.Wpf  
   5        � UseLayoutRounding$
  True��5       � DataContext 5      1  +DevExpress.Mvvm.UI.ViewModelSourceExtension  *viewmodel:UserViewModel+ � 	Resources 5       �� MergedDictionaries �� Source!   NextBO.Wpf.PictureConverter   PictureConverter0  *DevExpress.Mvvm.UI.ObjectToObjectConverter ! ShowPilotInformationConverter
   Map   DevExpress.Mvvm.UI.MapItem   Source   Target�� 5   
    5      �� 5      $D >pack://application:,,,/NextBO.Wpf;component/Themes/Common.xaml?�6%   %�   &	        &	        5      6%     5      . 5        $ false��6!   $ 	Collapsed��60     5      $
 true��6!   $ Visible��6/   5      5      2  ,DevExpress.Mvvm.UI.Interactivity.Interaction   	Behaviors 5      -  'DevExpress.Xpf.Core.DXMessageBoxService  5    
   .��5"      ]� .+�5#   
   )  #DevExpress.Xpf.Ribbon.RibbonControl  -   5        	  Name$	 ribbonControl��5#      
   RibbonStyle$
 
Office2019=�63   $	��Top=�6L      ShowApplicationButton$ False��6a      Items. 5$      &   DevExpress.Xpf.Ribbon.RibbonPage     Caption)	  #DevExpress.Xpf.Core.ObjectConverter$
 Home	 6      Groups. 5%      +
  %DevExpress.Xpf.Ribbon.RibbonPageGroup
   
  Caption$ Opciones��6&    
  Items. 5&      '  !DevExpress.Xpf.Bars.BarButtonItem  !  DevExpress.Xpf.Bars.BarItem   Content$ Agregar piloto	 6(      Command 6A   �� *AddPilotCommand+   Glyph 5'   !   1  +DevExpress.Xpf.Core.SvgImageSourceExtension  
   Uri$J Dpack://application:,,,/NextBO.Wpf;component/Resources/NewEmploye.svg?�   
LargeGlyph 5(   !     $J Dpack://application:,,,/NextBO.Wpf;component/Resources/NewEmploye.svg?�  5)      $ Guardar	 6(    6:   �� *SaveCommand+ 5*   !     $D >pack://application:,,,/NextBO.Wpf;component/Resources/Save.svg?� 5+   !     $D >pack://application:,,,/NextBO.Wpf;component/Resources/Save.svg?�  5,      $ Guardar y Cerrar	 6(    6C   �� *SaveAndCloseCommand+ 5-   !     $L Fpack://application:,,,/NextBO.Wpf;component/Resources/SaveAndClose.svg?� 5.   !     $L Fpack://application:,,,/NextBO.Wpf;component/Resources/SaveAndClose.svg?�5/      
  50      $ Cerrar��6&   . 51        $ Cerrar	 6(    69   �� *CloseCommand+ 52   !     $E ?pack://application:,,,/NextBO.Wpf;component/Resources/Close.svg?� 53   !     $E ?pack://application:,,,/NextBO.Wpf;component/Resources/Close.svg?�54      
  55      . 56        $ Restablecer Cambios	 6(    6F   �� *ResetCommand+ 57   !     $L Fpack://application:,,,/NextBO.Wpf;component/Resources/ResetChanges.svg?� 58   !     $L Fpack://application:,,,/NextBO.Wpf;component/Resources/ResetChanges.svg?�59      
  5:      . 5;        $ Activar	 6(    6:   �� *ActivateCommand+ 5<   !     $F @pack://application:,,,/NextBO.Wpf;component/Resources/Active.svg?� 5=   !     $F @pack://application:,,,/NextBO.Wpf;component/Resources/Active.svg?�  5>      $ 
Desactivar	 6(    6=   �� *DeleteCommand+ 5?   !     $F @pack://application:,,,/NextBO.Wpf;component/Resources/Delete.svg?� 5@   !     $F @pack://application:,,,/NextBO.Wpf;component/Resources/Delete.svg?�5A      
  5B      $ Exportar��6&   . 5C        $ Generar Reporte	 6(    6B   �� *PrintProfileUserCommand+ 5D   !     $F @pack://application:,,,/NextBO.Wpf;component/Resources/Report.svg?� 6�     $F @pack://application:,,,/NextBO.Wpf;component/Resources/Report.svg?�5E      5F      5G      2  ,DevExpress.Xpf.Ribbon.RibbonStatusBarControl  5H   
   $��Bottom=�6%   0 	 *DevExpress.Xpf.LayoutControl.LayoutControl  5I   
   -   5          Name$ layoutControl��5I   �   . 	 (DevExpress.Xpf.LayoutControl.LayoutGroup   Orientation$ Vertical=�6   $��11(�64   $��Stretch=�6L      StretchContentVertically$
 True��6h    5J      '  !DevExpress.Mvvm.UI.EventToCommand  5K       �� SourceUpdatedEvent�  �DevExpress.Mvvm.UI.Interactivity.EventTriggerBase`1[[System.Windows.DependencyObject, WindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35]]   Event# Z 6(   +  %DevExpress.Mvvm.UI.EventToCommandBase   Command 6V   �� *UpdateCommand+.+�5M           View$ GroupBox=�6      Header$ Datos Generales��6/   $ Vertical=�6H   .+�5N        $ Vertical=�6#   $	��Top=�6:   $��Right=�6R   $��5q�6n     5O      $ Vertical=�6#   $	��Top=�6:   $��5q�6R   .+�5P        $ 
Horizontal=�6'   $��	0,15,0,25q�6@    J� RenderTransformOrigin$ 0.518,0.477&�6S   .+�5R        $ Vertical=�6-   $
��auto��6D   .+�5S      - 	 'DevExpress.Xpf.LayoutControl.LayoutItem     Label$ Nombre Completo��6.   $��10,0,0,0q�6F       AddColonToLabel$
  True��6X   !   Content.! 5T   "   %  DevExpress.Xpf.Editors.TextEdit  %  DevExpress.Xpf.Editors.BaseEdit"   	EditValue" 6/   �� *Entity.Name+# �� UpdateSourceTrigger$# PropertyChanged=�$ �� ValidatesOnDataErrors$
$ True��% �� NotifyOnSourceUpdated$
% True��5U        5V      $ Usuario��6.   $��10,0,0,0q�6?   $
  True��6Q   .! 5W   "     " 6/   �� *Entity.UserLogin+$# PropertyChanged=�$
$ True��$
% True��5X        5Y      $��10,0,0,0q�6.   $	 Rol��6@   $
  True��6L   .! 5[   "   )  #DevExpress.Xpf.Editors.ComboBoxEdit  '  !DevExpress.Xpf.Editors.ButtonEdit&   IsTextEditable	& False63   +  %DevExpress.Xpf.Editors.LookUpEditBase'   ValueMember$' Id��5\   +   8(   1AllowUpdateTwoWayBoundPropertiesOnSynchronization$( False��5]   +   &)   ApplyItemTemplateToSelectedItem$
) True��6e   $ 0.5,0.5&�6�   $��
0,0,-0.2,0q�6�   " 5[   J   �� *Entity.RoleId+$# PropertyChanged=�$
% True��$
$ True��*   ItemsSource* 5\   <   �� *LookUpRole.Entities+z�5^   &   V� 5_   *   .~�5`   .   �� �� 5a   .   �� 5b   .   + �� Angle$+ -0.017Q�6>   T� 5c   .   5d   +   ,   ItemTemplate, 5f   &   �� 5g   *   .R�5h   .   �� - �� Orientation$- 
Horizontal=�69   .+�5i   2   !  DevExpress.Xpf.Core.DXImage  $
��None=�6�   .   Source. 6=   �� *Prefix+   personPrefixToImageConverter/ �� 	Converter#/ [ 6�   �� 5j   2   $��Center=�6R   $��3,0,0,0q�6n   ��6<   �� *Name+6n   5k   /   5l   +   5n   #   5o        5q      $��10,0,0,0q�6/   $ 	Teléfono��6B   $
  True��6S   0   
IsRequired$
0 True��6j   .! 5r   "     & True61   1   AllowDefaultButton	1 False5s   -   2   MaskType$2 Simple=�5t   -   3   Mask$3 	0000-0000��5u   -   4   MaskUseAsDisplayFormat$
4 True��5v   -   $
��auto��5w   �   " 6-   �� *Entity.Phone+$# PropertyChanged=�$
$ True��$
% True��5   Buttons.5 5x   &   '  !DevExpress.Xpf.Editors.ButtonInfo  6   	GlyphKind$6 Custom=�65   .  (DevExpress.Xpf.Editors.CommandButtonInfo7   Command7 6H   �� *Contacts.HomeCallCommand+8   Content.8 5y   *     $	��3,0q�6�   . 65     5  /DevExpress.Xpf.Core.BaseSvgImageSourceExtension9   Size	9 16,16$S Mpack://application:,,,/NextBO.Wpf;component/Resources/Buttons/Glyph_Phone.svg?�6�   5z   '   5{   #   5|        5~      $��10,0,0,0q�6/   $ Correo Electronico��6A   $
  True��6\   .! 5   "     & True61   	1 False5�   -   $2 RegEx=�5�   -   $>3 8(\w|[\.\-])+@(\w|[\-]+\.)*(\w|[\-]){2,63}\.[a-zA-Z]{2,4}��5�   -   :   ValidateOnTextInput$
: True��5�   -   $
��auto��6H   " 5�   -   �� *Entity.Email+$# PropertyChanged=�$
$ True��$
% True��z�5�   &   V� 5�   *   .~�5�   .   �� �� 5�   .   �� 5�   .   $+ -0.07Q�6>   T� 5�   .   5�   +   .5 5�   &     $6 Custom=�65   7 6H   �� *Contacts.MailToCommand+.8 5�   *     $	��3,0q�6�   . 65     	9 16,16$R Lpack://application:,,,/NextBO.Wpf;component/Resources/Buttons/Glyph_Mail.svg?�6�   5�   '   5�   #   5�      5�        5�      $��Right=�6*   $��Stretch=�6F   $��5,0,0,0q�6b   .! 5�      &   DevExpress.Xpf.Editors.ImageEdit  $	��150��6,   $	��120��68   " 6E   �� *Entity.Image+#/ [  $# PropertyChanged=�$
$ True��$
% True��5�      5�      5�      5�        5�      $ GroupBox=�6   $( "Información de Piloto Relacionado��6/   $ Vertical=�6Z   ;   IsCollapsible$
; True��6q   y�5�   !   �� *
HasPilot+< �� Mode$< TwoWay=�#/ [ .+�5�        .+�5�        $" Documento de Identificación��6&   .! 5�        " 6'   �� *$"Pilot.IdentificationDocumentNumber+$< TwoWay=�$# PropertyChanged=�$
$ True��$
% True��5�        5�      $ Número de Licencia��6&   .! 5�        " 6'   �� *Pilot.LicenseNumber+$< TwoWay=�$# PropertyChanged=�$
$ True��$
% True��5�      5�        5�      .+�5�        $ Tipo de Licencia��6&   .! 5�        " 6'   �� *Pilot.LiceseType+$< TwoWay=�$# PropertyChanged=�$
$ True��$
% True��5�        5�      $&  Fecha de Vencimiento de Licencia��6&   .! 5�      %  DevExpress.Xpf.Editors.DateEdit  " 6'   �� *Pilot.LicenseExpirationDate+$< TwoWay=�$# PropertyChanged=�$
$ True��$
% True��5�      5�        5�      .+�5�        $ 
Dirección��6&   .! 5�        " 6'   �� *Pilot.Address+$< TwoWay=�$# PropertyChanged=�$
$ True��$
% True��5�        5�      $ 
Comentario��6&   .! 5�        " 6'   �� *Pilot.Comment+$< TwoWay=�$# PropertyChanged=�$
$ True��$
% True��5�      5�        5�      .+�5�        $ Rastrear Piloto��6&   .! 5�      &    DevExpress.Xpf.Editors.CheckEdit   " 6(   �� *Pilot.TrackRoute+$< TwoWay=�$# PropertyChanged=�$
$ True��$
% True��5�      5�      5�      5�      5�      5�      