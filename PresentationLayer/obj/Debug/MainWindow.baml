   M S B A M L   `   `   `  ����L  HPresentationLayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:PresentationLayerPresentationLayer  5      U QMahApps.Metro, Version=1.5.0.23, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls 5      "    PresentationLayer.MainWindow   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      1localclr-namespace:PresentationLayer     5      PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5        � Title$  Cinema��5      $
��1024��5      $	��768��6'   $
��1024��5      $	��768��6$   .��5
      �  � RowDefinitions 5   
   �� 5      $	��100 �6   6+   �� 5      $��1* �6   6*    � ColumnDefinitions 5   
   �� 5      $	��300 �6   6-   �� 5      $��1* �6   6,   .+�5   
   � 
�������$��0��6%   $��0��65   $��2��6B    5      �� 5      $��1* �6#   60   �� 5      $��90 �6#   60   �� 5      $��90 �6#   60   .+�5      �� $
��5 20q�6   $��80��5      $��Register��5      $��1��5!      ��5      �� *ChangePageCommand+��5       �� *GetRegisterPage+5!      �� 5"      $
��5 20q�6   $��80��5#      $��Login��5$      $��2��5'      ��5%      �� *ChangePageCommand+��5&      �� *GetLoginPage+5'      5(      �� 5*      -   5        $��SeatingArea��5.      
�������$��1��5+      $��0��5,      ��5-      �� *Films+��50      �� 51      .R�52      �� 53      ��57      �� 58      .R�59      �� $��
20 10 20 0q�5=      ��5:      ��  �� Path$- 'MainWindowViewModel.ChangeToFilmCommand�   ViewModelLocator �� Source# [  ��5;      �� ��5<      �� *Name+5=      5>      5@      �� 5B   
   $��1��6   $��1��5C      $
��Auto=�5D      $
��Auto=�5E      .��5F       � 
�������  � NavigationUIVisibility$ Hidden=�5G      ��5H      �� *CurrentPage+ �� 	Converter 5   /PresentationLayer.ApplicationPageValueConverter  5I      5K      5L      