   M S B A M L   `   `   `  ����E  ANextBO.Wpf, Version=1.0.1.0, Culture=neutral, PublicKeyToken=null'clr-namespace:NextBO.Wpf
NextBO.Wpf  5	           NextBO.Wpf.Views.LoginView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49ae aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35h dDevExpress.Xpf.TypedStyles.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aR NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35L 9http://schemas.microsoft.com/winfx/2006/xaml/presentation        5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089<x,http://schemas.microsoft.com/winfx/2006/xaml      5      Bd2http://schemas.microsoft.com/expression/blend/2008      5      l	 hDevExpress.Xpf.Core.v20.2.Extensions, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a?dx2http://schemas.devexpress.com/winfx/2008/xaml/core   	 5      Adxe5http://schemas.devexpress.com/winfx/2008/xaml/editors   5      j
 fDevExpress.Xpf.LayoutControl.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aHdxlc;http://schemas.devexpress.com/winfx/2008/xaml/layoutcontrol  
 5      &localclr-namespace:NextBO.Wpf  
 5	      Fmc;http://schemas.openxmlformats.org/markup-compatibility/2006  
 5
      $	��375��5        � 	Resources  5      !   NextBO.Wpf.PictureConverter   PictureConverter�� 5   
   %   &	          5      6%   5      .��5      )  #DevExpress.Xpf.Core.BackgroundPanel  .��5   
   ]� .+�5      � -   5         �Name$ 
LayoutRoot��5      $��0,0,0,0q�6'   .+�5      � -   5        $ Splash��5      $	��498��5      $	��400��5      $��Center=�5      $	��Top=�5      .+�5      � -   5        $ Content_Area��5      $��12q�61    � RowDefinitions 5      �� 5      $
��Auto �6,   �� 5       $
��Auto �6,   �� 5!      $��* �6,   �� 5"      $
��Auto �6,   .+�5$      �� $	��475��5%      $	��230��5&      ���#002e6e._�5(      � $��0,25,0,0q�6#    5)   "   �� 5*   &   $
��Auto �64   �� 5+   &   $
��Auto �64   �� 5,   &   $��* �64   .+�5/   "   !  DevExpress.Xpf.Core.DXImage  $	��200��50   %   $��50��51   %   $��	0,-80,0,0q�52   %   $��Uniform=�54   %      Source 53   %   �� *CompanyImage+ �� 	Converter# [  54   %   �� 56   "   $��
0,60,0,-20q�57   %   $��Center=�58   %   $��Segoe UI Light)�59   %   $��50(�5:   %   
�������$��Sonda Delivery��5<   %   �� 5>   "   $��1��5?   %   $��2��5@   %   $��0,26.497,0,35q�5A   %   $��Center=�5B   %   $��Segoe UI Light)�5C   %   $��20(�5D   %   
������� J� Opacity$	 0.5Q�5F   %   $��Ingrese sus credenciales��5G   %   5H      5I      0 
 *DevExpress.Xpf.LayoutControl.LayoutControl  5J      $��2��5K      $��2��5L      $��
0,10,0,-30q�5M      .+�5N      . 
 (DevExpress.Xpf.LayoutControl.LayoutGroup     Orientation$ Vertical=�6/   .+�5O   "   - 
 'DevExpress.Xpf.LayoutControl.LayoutItem     Label$ Usuario��62      Content. 5P   &   %  DevExpress.Xpf.Editors.TextEdit  $��94,0,0,0q�63   %  DevExpress.Xpf.Editors.BaseEdit	   	EditValue	 6E   �� *	UserLogin+
 �� UpdateSourceTrigger$
 PropertyChanged=�5Q   #     5R   "   $ Contraseña��62   . 5S   &   ,	  &DevExpress.Xpf.Editors.PasswordBoxEdit	  $��94,0,0,0q�6:   	 6L   �� *
Password+$
 PropertyChanged=�5T   #   � 5U   "   .+�5V   &   �� $��2��5W   )   $��2��5X   )   $��Right=�5Y   )   $��Segoe UI)�5Z   )   $��15(�5[   )   $
��Bold"�5\   )   
���  ��$	 0.5Q�5^   )   $	��Top=�5`   )   ��5_   )   �� *AutenticationMessage+$
 PropertyChanged=�5`   )   5a   #   5b      5c      5d      5e      � 5f      $
��Left=�6   $��Bottom=�62   $��22 0 0 0q�6M   .+�5g      �� $��16(�6    ��6.   �� *
AppVersion+$
 PropertyChanged=�5h      5i      5j      5k      5o      