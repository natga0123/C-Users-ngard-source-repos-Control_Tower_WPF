   M S B A M L   `   `   `  ����L  HControl_Tower_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Control_Tower_WPFControl_Tower_WPF  5   	   %    Control_Tower_WPF.Flight_window   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:Control_Tower_WPF     5   	   -   5          � Title$  Flight_window��5   	   $��411.978��6   $��595.209��60    � 
ResizeMode$ NoResize=�6@   .��5
      � -   5         �Name$ Flight_form��5
      $��0,0,3.6,-19.6q�6     � ColumnDefinitions 5   
   .+�5   
   �� -   5         ��Name$ 	Image_fpl��5      $
��Left=�6#   $	��300��6>   $��6,0,0,0q�6K   $	��Top=�6\   $	��574��6t   $��2��6�   �� 5   
   -   5         ��Name$ 	Btn_Start��5      $��Start��6$   $
��Left=�64   $��
42,325,0,0q�6O   $	��Top=�6c   $	��119��6{   $��28��6�   $��20(�6�   $
��Bold"�6�    J� RenderTransformOrigin$ 0.52,-1.864&�6�   6�   �� 5   
   -   5        $ Btn_Land��5      $
��Land��6#   $
��Left=�62   $��425,324,0,0q�6M   $	��117��6b   $��20(�6n   $
��Bold"�6|   $ 0.075,-1.954&�6�   $��29��6�   $	��Top=�6�   6�   �� 5   
   -   5         ��Name$ Combo_Headings��5      $
��Left=�6+   $��216,325,0,0q�6F   $	��Top=�6[   $	��171��6s   $��28��6   $ 0.521,1.066&�6�   6�   5      5      