   M S B A M L   `   `   `  ����L  HControl_Tower_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Control_Tower_WPFControl_Tower_WPF  5   	   "    Control_Tower_WPF.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:Control_Tower_WPF     5   	   -   5          �Name$  Window_Tower��5   	    � 
ResizeMode$ NoResize=�5   	    � Title$ Control Tower��5	   	   $	��450��6   $	��800��6,   .��5
      � .+�5   
   �� -   5         ��Name$ List_View_Flights��5      $
��Left=�6.   $	��263��6I   $��	70,63,0,0q�6V   $	��Top=�6i   $	��635��6�    �� View 5      �� 5      .P�5      �� $��Flight Code��6%    �� Width$	 200��6:    �� DisplayMemberBinding 6F   �� *Flight_Code+ �� HeaderContainerStyle 5      �� 5       �� 
TargetType" ��6$   .�5   "   �� 	 �� Property	 � ��
 �� Value$

 Left=�6O   5      5      �� 5      $��Status��6%   $	 200��65    6A   �� *Status+ 5      �� 5      " ��6$   .�5   "   �� 	 � ��$

 Left=�6O   5      5      �� 5      $
��Time��6%   $	 200��63    6?   �� *Time+ 5      �� 5      " ��6$   .�5    "   �� 	 � ��$

 Left=�6O   5!      5#      5%      5'      �� 5(   
   $��Next Flight:��6   $
��Left=�6'   $��
70,366,0,0q�6B   $	��Top=�6V   $��74��6n   �� 5)   
   -   5         ��Name$ TextBox_Flight_Code��5)      $
��Left=�6/   $��23��6J   $��162,370,0,0q�6V    �� TextWrapping$
 Wrap=�6k   $��flight code��6   $	��Top=�6�   $	��120��6�   6�   �� 5*   
   -   5         ��Name$ Send_btn��5*      $"��Send next airplane to runway��6#   $
��Left=�6J   $��347,370,0,0q�6e   $	��Top=�6z   $	��206��6�   $��23��6�   6�   �� 5+   
   -   5         ��Name$ Label_Number_of_Flights��5+      $��Label��61   $
��Left=�6A   $��
476,19,0,0q�6\   $	��Top=�6p   5-      5.      