   M S B A M L   `   `   `  ����  
NextBO.Wpf#    NextBO.Wpf.SplashScreenWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49ae aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35h dDevExpress.Xpf.TypedStyles.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aR NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35L 9http://schemas.microsoft.com/winfx/2006/xaml/presentation        5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089<x,http://schemas.microsoft.com/winfx/2006/xaml      5   	   Bd2http://schemas.microsoft.com/expression/blend/2008      5   	   Lmc;http://schemas.openxmlformats.org/markup-compatibility/2006      5   	   Adxe5http://schemas.devexpress.com/winfx/2008/xaml/editors   5   	   Jdxet?http://schemas.devexpress.com/winfx/2008/xaml/editors/themekeys  5   	   l	 hDevExpress.Xpf.Core.v20.2.Extensions, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a?dx2http://schemas.devexpress.com/winfx/2008/xaml/core   	 5   	   -   5          �Name$  splashWindow��5   	   &   DevExpress.Xpf.Core.ThemeManager   Theme,  &DevExpress.Xpf.Core.ThemeTypeConverter$ Office2019Colorful 5	   	    � WindowStyle$
 None=�5   	    � 
ResizeMode$ NoResize=�5   	    � ShowActivated$ False��5   	   $	��800��5   	   $	��600��5   	    � AllowsTransparency$
 True��5   	   
������  � ShowInTaskbar$ False��5   	    � Topmost$
 True��5   	    � 	Resources 5      I  CDevExpress.Xpf.Editors.Themes.ProgressBarEditStyleThemeKeyExtension�  �DevExpress.Xpf.Utils.Themes.ThemeKeyExtensionInternalBase`1[[System.String, System.Runtime, Version=4.2.1.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]]	   ResourceKey�  �DevExpress.Xpf.Utils.Themes.ThemeKeyExtensionBase`1[[System.String, System.Runtime, Version=4.2.1.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]]
   IsThemeIndependent �� 
TargetTypeD  >DevExpress.Xpf.Editors.Themes.ProgressBarEditThemeKeyExtension�  �DevExpress.Xpf.Utils.Themes.ThemeKeyExtensionInternalBase`1[[DevExpress.Xpf.Editors.Themes.ProgressBarEditThemeKeys, DevExpress.Xpf.Core.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a]]   ResourceKey�  �DevExpress.Xpf.Utils.Themes.ThemeKeyExtensionBase`1[[DevExpress.Xpf.Editors.Themes.ProgressBarEditThemeKeys, DevExpress.Xpf.Core.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a]]   IsThemeIndependent ��Name � UseLayoutRounding ��Name��%�  (        5      $:	 4ProgressBarMarqueeHorizontalAnimationElementTemplate��$

 True��)(  <     5      $' !PanelBackgroundHorizontalTemplate=�$
 True��)�� 5   
   .R�5      �� ���#002e6e6   5      �� 5   
   " ��5      .R�5      �� $ Border��6   
�������$
 True��5      ._�5      �� $ content��6#   $��1q�5   #   5       5!      5"      .��5#      � -   5         �Name$ 
LayoutRoot��5#      .+�5$   
   � -   5        $ Splash��5$      $	��498��5%      $	��368��5&      $��Center=�5'      $	��Top=�5(      $��	0,100,0,0q�5)      .+�5*      � -   5        $
 Back��5*       J� Effect 5+      3	  -System.Windows.Media.Effects.DropShadowEffect	  5,       	  ShadowDepth$ 1Q�6'    	  	Direction$	 -90Q�5-   '    	  
BlurRadius$ 10Q�5.   '    	  Opacity$
 0.25Q�5/   '   .+�51      �� 
���   � �� CornerRadius$ 3��52       J� Opacity$
 0.15Q�53      �� 54      $ 2��6   $��1q�55      
�������56      57      � 58      -   5        $ Content_Area��58      $��12q�59       � RowDefinitions 5:      �� 5;      $
��Auto �6$   �� 5<      $
��Auto �6$   �� 5=      $��* �6$   �� 5>      $
��Auto �6$   .+�5@      �� $	��475��6   $	��180��5A      ���#002e6e._�5C      � $��0,60,0,0q�6    5D      �� 5E      $
��Auto �6,   �� 5F      $
��Auto �6,   �� 5G      $��* �6,   .+�5I      �� 
�������$��Center=�5J   $   $
��Next��5K   $   $��36(�5L   $   $��Segoe UI Light)�5M   $   �� 5N      $��1��6$   $	 0.5Q�5O   $   
�������$��Center=�5Q   $   $��Route Planning��5R   $   $��20(�5S   $   $��Segoe UI Light)�5T   $   5U      5V      �� 5W      -   5         ��Name$
 Info��5W      $��	60,35,0,0q�5X      $
��Wrap=�5Y      $��Cargando...��5Z      $��1��5[      ,
  &DevExpress.Xpf.Editors.ProgressBarEdit
  5\      -   5         
 Name$ progressBar��5\   &   $��20��5]   &   $	��355��5^   &   $��2��5_   &   $��0,2,0,0q�5`   &   $	��Top=�5a   &   
������� 
  StyleSettings 5c      <  6DevExpress.Xpf.Editors.ProgressBarMarqueeStyleSettings  5d      5f      ]� 5g      -   5         ]�Name$ Footer��5g      $��3��5h      $��55��5i      $��-11,0,-11,-11q�5j      ���	#FFEEEEEE.+�5l      �� -	   5        $ Footer_Text��5l       $
��Wrap=�5m       $��20,0,0,0q�5n       $
��Left=�5o       $��Center=�5p       �� 5r      Mobility SCM5s   '   5t      5u      5v      5w      5x      