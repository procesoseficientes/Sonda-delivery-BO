   M S B A M L   `   `   `  ����E  ANextBO.Wpf, Version=1.0.1.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:NextBO.Wpf.ViewModelsNextBO.Wpf.ViewModels  5      'clr-namespace:NextBO.Wpf
NextBO.Wpf  5      "    NextBO.Wpf.Views.VehicleView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49ae aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35h dDevExpress.Xpf.TypedStyles.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aR NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35L 9http://schemas.microsoft.com/winfx/2006/xaml/presentation        5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089<x,http://schemas.microsoft.com/winfx/2006/xaml      5      Bd2http://schemas.microsoft.com/expression/blend/2008      5      Lmc;http://schemas.openxmlformats.org/markup-compatibility/2006      5      l	 hDevExpress.Xpf.Core.v20.2.Extensions, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a?dx2http://schemas.devexpress.com/winfx/2008/xaml/core   	 5      >dxb2http://schemas.devexpress.com/winfx/2008/xaml/bars   5      Adxe5http://schemas.devexpress.com/winfx/2008/xaml/editors   5      c
 _DevExpress.Xpf.Ribbon.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aBdxr4http://schemas.devexpress.com/winfx/2008/xaml/ribbon 
   5	      j fDevExpress.Xpf.LayoutControl.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aHdxlc;http://schemas.devexpress.com/winfx/2008/xaml/layoutcontrol   5
      g cDevExpress.Mvvm.v20.2.ViewModel, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a] YDevExpress.Mvvm.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aEdxmvvm2http://schemas.devexpress.com/winfx/2008/xaml/mvvm     5      9	viewmodel#clr-namespace:NextBO.Wpf.ViewModels     5      *localclr-namespace:NextBO.Wpf     5      l hDevExpress.Xpf.Grid.v20.2.Extensions, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aa ]DevExpress.Xpf.Grid.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49af bDevExpress.Xpf.Grid.v20.2.Core, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aBdxg2http://schemas.devexpress.com/winfx/2008/xaml/grid     5        � UseLayoutRounding$
  True��5       � DataContext 5      1  +DevExpress.Mvvm.UI.ViewModelSourceExtension  *viewmodel:VehicleViewModel+ � 	Resources 5       �� MergedDictionaries �� Source!   NextBO.Wpf.PictureConverter   PictureConverter�� 5   
    5      �� 5      $D >pack://application:,,,/NextBO.Wpf;component/Themes/Common.xaml?�6%   %   &	          5      6%   5      2  ,DevExpress.Mvvm.UI.Interactivity.Interaction   	Behaviors 5      -  'DevExpress.Xpf.Core.DXMessageBoxService  5   
   .��5      ]� $��
0,0,0,-108q�6   .+�5   
   ) 
 #DevExpress.Xpf.Ribbon.RibbonControl  -   5          Name$ ribbonControl��5         RibbonStyle$ 
Office2019=�63   $	��Top=�6L      ShowApplicationButton$ False��6b    5       	   Items.	 5"      5 
 /DevExpress.Xpf.Ribbon.RibbonDefaultPageCategory  2 
 ,DevExpress.Xpf.Ribbon.RibbonPageCategoryBase
   Caption$
 defaultCategory��6,      Pages. 5#      & 
  DevExpress.Xpf.Ribbon.RibbonPage     Caption)	  #DevExpress.Xpf.Core.ObjectConverter$
 Home	 6!      Groups. 5$      +
 
 %DevExpress.Xpf.Ribbon.RibbonPageGroup
   
  Caption$ Acciones��6*    
  Items. 5%      '  !DevExpress.Xpf.Bars.BarButtonItem  -   5          Name$ butonPrincipal��5%   ^   !  DevExpress.Xpf.Bars.BarItem   Content$ Guardar	 6,      Command 6>   �� *SaveCommand+   Glyph 5&   !   1  +DevExpress.Xpf.Core.SvgImageSourceExtension  
   Uri$D >pack://application:,,,/NextBO.Wpf;component/Resources/Save.svg?�   
LargeGlyph 5'   !     $D >pack://application:,,,/NextBO.Wpf;component/Resources/Save.svg?�  5(      $ Guardar y Cerrar	 6,    6G   �� *SaveAndCloseCommand+ 5)   !     $L Fpack://application:,,,/NextBO.Wpf;component/Resources/SaveAndClose.svg?� 5*   !     $L Fpack://application:,,,/NextBO.Wpf;component/Resources/SaveAndClose.svg?�  5+      $ Activar	 6,    6>   �� *ActivateCommand+ 5,   !     $F @pack://application:,,,/NextBO.Wpf;component/Resources/Active.svg?� 5-   !     $F @pack://application:,,,/NextBO.Wpf;component/Resources/Active.svg?�  5.      $ 
Desactivar	 6,    6A   �� *DeleteCommand+ 5/   !     $F @pack://application:,,,/NextBO.Wpf;component/Resources/Delete.svg?� 50   !     $F @pack://application:,,,/NextBO.Wpf;component/Resources/Delete.svg?�51      
  52      . 53        $ Restablecer Cambios	 6,    6J   �� *ResetCommand+ 54   !     $L Fpack://application:,,,/NextBO.Wpf;component/Resources/ResetChanges.svg?� 55   !     $L Fpack://application:,,,/NextBO.Wpf;component/Resources/ResetChanges.svg?�56      
  57      . 58        $ Reestructurar	 6,    6D   �� *#!changeValueIsCustomizationCommand+ 59   !     $J Dpack://application:,,,/NextBO.Wpf;component/Resources/AssignTask.svg?� 5:   !     $J Dpack://application:,,,/NextBO.Wpf;component/Resources/AssignTask.svg?�5<        5=      $ Guardar Layout	 6,    5>   ,   �� *SaveLayoutCommand+ �� ElementName$ SerializeHelper�� 5?   ,     $D >pack://application:,,,/NextBO.Wpf;component/Resources/Save.svg?� 5@   ,     $D >pack://application:,,,/NextBO.Wpf;component/Resources/Save.svg?�  5A      $ 	Restaurar	 6,    5B   ,   �� *RestoreLayoutCommand+$ SerializeHelper�� 5C   ,     $D >pack://application:,,,/NextBO.Wpf;component/Resources/Undo.svg?� 5D   ,     $D >pack://application:,,,/NextBO.Wpf;component/Resources/Undo.svg?�5E      5F      5G      5H      2 
 ,DevExpress.Xpf.Ribbon.RibbonStatusBarControl  5I   
   $��Bottom=�6%   4  .DevExpress.Xpf.LayoutControl.DataLayoutControl  5J   
   -   5          Name$ layoutItemss��5J   !   .  (DevExpress.Xpf.LayoutControl.LayoutGroup   Orientation$ Vertical=�5K      
������    AutoGenerateItems$ False��5O      0  *DevExpress.Xpf.LayoutControl.LayoutControl   IsCustomization 5M      �� *IsCustomization+   CurrentItem 5N      �� *Entity+ 5P      *   $NextBO.Wpf.LayoutControlSaveBehavior  5Q      -   5        SerializeHelper��   FileName$ layoutItemss��5Q   K   5R      .+�5T           View$ GroupBox=�6      Header$ Informacion Basica��6/      IsCollapsible$
 True��6K   .+�5U        $ Vertical=�6#   .+�5V        .+�5W      1  +DevExpress.Xpf.LayoutControl.DataLayoutItem  -  'DevExpress.Xpf.LayoutControl.LayoutItem    Label$  Marca��6.   !   Binding! 6<   �� *Brand+" �� UpdateSourceTrigger$" PropertyChanged=�# �� ValidatesOnDataErrors$
# True��  5X      $  Línea��6.   $��20,0,0,0q�6<   $��Center=�6N   ! 6i   �� *Line+$" PropertyChanged=�$
# True��5Y        5Z      .+�5[        $  Modelo��6.   ! 6=   �� *Model+$" PropertyChanged=�$
# True��$ �� NotifyOnSourceUpdated$
$ True��  5\      $  
Cilindraje��6.   $��20,0,0,0q�6�   $��Center=�6�   ! 6A   �� *CC+$" PropertyChanged=�$
# True��$
$ True��6�   5]        5^      .+�5_        $  Kilometraje��6.   ! 6B   �� *
Odometer+$" PropertyChanged=�$
# True��$
$ True��  5`      $  Color��6.   $��20,0,0,0q�6<   $��Center=�6N   ! 6i   �� *Color+$" PropertyChanged=�$
# True��$
$ True��5a        5b      .+�5c        $  Número de chasís��6.   ! 6G   �� *ChassisNumber+$" PropertyChanged=�$
# True��$
$ True��  5d      $  Número de motor��6.   $��20,0,0,0q�6F   $��Center=�6X   ! 6s   �� *EngineNumber+$" PropertyChanged=�$
# True��$
$ True��5e        5f      .+�5g        $	  VIN��6.   ! 6:   �� *	VinNumber+$" PropertyChanged=�$
# True��$
$ True��  5h      $  Número de placa��6.   $��20,0,0,0q�6F   $��Center=�6X   ! 6s   �� *PlateNumber+$" PropertyChanged=�$
# True��$
$ True��5i        5j      .+�5k        $#  Código empresa de transporte��6.   ! 6S   �� *TransportCompanyCode+$" PropertyChanged=�$
# True��$
$ True��  5l      $  Piloto��6*   $��20,0,0,0q�69   $��Center=�6K   %   Content.% 5m      )  #DevExpress.Xpf.Editors.ComboBoxEdit  '  !DevExpress.Xpf.Editors.ButtonEdit&   IsTextEditable	& False6/   +  %DevExpress.Xpf.Editors.LookUpEditBase'   ValueMember$' Id��5n   *   %  DevExpress.Xpf.Editors.BaseEdit8(   1AllowUpdateTwoWayBoundPropertiesOnSynchronization$( False��5o   *   &)   ApplyItemTemplateToSelectedItem$
) True��6d   * J� RenderTransformOrigin$* 0.5,0.5&�6�   +   	EditValue+ 5m   F   �� *Entity.PilotId+$" PropertyChanged=�$
$ True��$
# True��,   ItemsSource, 5n   ;   �� *LookUpPilot.Entities+z�5p   "   V� 5q   &   .~�5r   *   �� �� 5s   *   �� 5t   *   - �� Angle$- -0.017Q�6:   T� 5u   *   5v   '   .   ItemTemplate. 5x   "   �� 5y   &   .R�5z   *   �� / �� Orientation$/ 
Horizontal=�65   .+�5{   .   !  DevExpress.Xpf.Core.DXImage  $
��None=�6�   0   Source0 69   �� *Prefix+   personPrefixToImageConverter1 �� 	Converter#1 [ 6�   �� 5|   .   $��Center=�6S   $��3,0,0,0q�6n   ��68   �� *	User.Name+6n   5}   +   5~   '   5�      5�      5�        5�      .+�5�        $  Estado��6.   ! 6=   �� *Status+$" PropertyChanged=�$
# True��$
$ True��  5�      $  Costo Diario��6.   $��20,0,0,0q�6C   ! 6U   �� *	DailyCost+$" PropertyChanged=�$
# True��$
$ True��5�      5�        5�      $	��210��6#   .+�5�        $	��210��6*   .% 5�      &   DevExpress.Xpf.Editors.ImageEdit  2   Stretch$2 Uniform=�5�   (   + 5�   (   �� *Image+#1 [  $" PropertyChanged=�$
# True��$
$ True��5�   (   5�      5�      5�        5�      $ GroupBox=�6   $ 
Eficiencia��6/   $ Vertical=�6C   $
 True��6Z   .+�5�        .+�5�        $  Confiabilidad (0 - 5)��6*   .% 5�      %  DevExpress.Xpf.Editors.SpinEdit  3   MinValue3 06'   4   MaxValue4 564   5   ShowErrorToolTip$
5 True��6A   + 6Y   �� *'%View.DataContext.Entity.Confiabilidad+$" PropertyChanged=�$
# True��$
$ True��"6   ErrorToolTipContentTemplate6 5�      �� 5�   "   .R�5�   &   �� $.��(Ingrese un valor entre el rango de 0 a 5��60   5�   #   5�      5�        5�      $#  Tasa de llenado del vehículo��6*   .% 5�        3 06'   4 10064   $
5 True��6C   + 6[   �� *
FillRate+$" PropertyChanged=�$
# True��$
$ True��6 5�      �� 5�   "   .R�5�   &   �� $0��*Ingrese un valor entre el rango de 0 a 100��60   5�   #   5�      5�      5�        5�      $y�	Collapsed=�6#   .+�5�        $y�	Collapsed=�6*   $"  Costo esperado por kilometro��6A   ! 6f   �� *!AverageCostPerKilometerEsperado+$" PropertyChanged=�$
# True��$
$ True��  5�      $y�	Collapsed=�6*   $"  Costo promedio por kilometro��6A   ! 6f   �� *AverageCostPerKilometer+$" PropertyChanged=�$
# True��$
$ True��5�      5�        5�      $ GroupBox=�6   $$ Información de Carga (Furgon)��6/   $ Vertical=�6V   $
 True��6m   .+�5�        .+�5�        $  Tipo de carga��6&   $��0,0,0,0q�5�   *   7   AddColonToLabel$
7 True��5�   *   .% 5�        *  $DevExpress.Xpf.Editors.PopupBaseEdit8   PopupFooterButtons8 OkCancel6+   9   ShowSizeGrip$
9 TrueY�5�   /   	& False5�   /   + 5�   /   �� *Entity.LoadType+$" PropertyChanged=�$
# True��$
$ True��:   StyleSettings: 5�      7  1DevExpress.Xpf.Editors.RadioComboBoxStyleSettings  5�   "   ;   Items.; 5�      -  'DevExpress.Xpf.Editors.ComboBoxEditItem  $��Pesada��63     5�      $��Mediana��63     5�      $��Liviana��63   5�      5�        5�      $
  Peso��6*   ! 67   �� *Weight+$" PropertyChanged=�$
# True��$
$ True��5�        5�      .+�5�        $  Altura��6*   ! 69   �� *High+$" PropertyChanged=�$
# True��$
$ True��  5�      $  Anchura��6*   ! 6:   �� *Width+$" PropertyChanged=�$
# True��$
$ True��5�        5�      .+�5�        $  Profundidad��6*   ! 6>   �� *Depth+$" PropertyChanged=�$
# True��$
$ True��  5�      $  Factor de volumen��6*   ! 6D   �� *VolumeFactor+$" PropertyChanged=�$
# True��$
$ True��5�      5�        5�      $ GroupBox=�6   $ 	Adicional��61   $ Vertical=�6D   $
 True��6[   .+�5�        .+�5�        $  Número de seguro��6*   ! 6C   �� *InsuranceDocId+$" PropertyChanged=�$
# True��$
$ True��  5�      $  Ejes de vehículos��6*   ! 6D   �� *VehicleAxles+$" PropertyChanged=�$
# True��$
$ True��5�        5�      .+�5�        $  Clasificación��6&   $��0,0,0,0q�5�   *   $
7 True��5�   *   .% 5�        8 OkCancel6+   $
9 TrueY�5�   /   	& False5�   /   + 5�   /   �� *Entity.Rating+$" PropertyChanged=�$
# True��$
$ True��: 5�        5�   "   .; 5�        $��Cabezal��63     5�      $��Camion��63     5�      $��Panel��63     5�      $��Pickup��63     5�      $��Picanto��63   5�      5�      5       5     5     5     5     5     5     