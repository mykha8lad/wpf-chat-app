   M S B A M L   `   `   `  ����  
ChatClient    ChatClient.MainWindow   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Chat Client��5   	   $	��500��6   $	��860��6*   ���#f2f2f2$	��600��5      $	��400��6-   .��5      �  � ColumnDefinitions 5      �� 5	   
   $��* �6   �� 5
   
   $	��200 �6    � RowDefinitions 5      �� 5   
   $��* �6   �� 5   
   $
��Auto �6   .+�5      �� -   5         ��Name$ ChatBox��5      $��0��6   $��0��6,   $��10q�6<   $��10q�6H    �� 
IsReadOnly$
 True��5       �� TextWrapping$
 Wrap=�6    " �� VerticalScrollBarVisibility$
 Auto=�5      $ �� HorizontalScrollBarVisibility$ Disabled=�61   
����������#333$��Segoe UI)�5      $��14(�6$   ���#ccc$��1q�5   !   �� 5      $��1��6   $��2��6    �� Orientation$ 
Horizontal=�62   $��10q�6K   .+�5   
   �� -   5        $ 
MessageBox��5      $	��600��6&   $��40��62   $��0,0,10,0q�6>   $��10q�5      $��Center=�6   
����������#333$��Segoe UI)�5      $��14(�6(   ���#ccc$��1q�5   %   �� 5    
   -   5        	 ��Name$	 
SendButton��5       $
��Send��6%   $	��100��64   $��40��6@   ���#0078D7
�������$��Segoe UI)�5"      $��14(�6'   $��0q�5#      
 � Cursor$

 Hand��6%   ��5%      �� 5&       �� 
TargetType" ��6   .�5'      ��  �� Property � �� �� Value 5(      �� 5)       �� 
TargetType" ��6.   .R�5*   "   �� #��z��6)    �� CornerRadius$ 5��5+   )    �� Padding$ 5q�5,   )   ���#005A9E$��1q�5-   ?   ._�5.   &   �� $��Center=�67   $��Center=�6T   5/   #   50      52      �� 53       � �� �#0078D763   �� 54       � ��
 �����63    �� Triggers 55      P� 56       P� Property �@J�IsMouseOver P� Value$
 True��69   . �57      ��  � �� �#005A9E6;   58      P� 59       � ��$
 True��67   . �5:      ��  � �� �#0045786;   5;      5=      5?      �� 5@   
   -   5        $	 LoadDataButton��5@      $��	Load Data��6)   $	��100��6=   $��40��6I   $��10,0,0,0q�6U   ���#0078D7
�������$
��Left=�5A   1   $��Segoe UI)�5B   	   $��14(�6   $��0q�6-   $

 Hand��6A   5C   	   5D      5H      5J      