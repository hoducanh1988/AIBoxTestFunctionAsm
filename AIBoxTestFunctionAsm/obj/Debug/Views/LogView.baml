   M S B A M L   `   `   `  ����O  KAIBoxTestFunctionAsm, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:AIBoxTestFunctionAsm.ViewsAIBoxTestFunctionAsm.Views  5      (    "AIBoxTestFunctionAsm.Views.LogView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:AIBoxTestFunctionAsm.Views     5      
�������.��5
      ��   �� TabStripPlacement$  Bottom=�6   $��0,0,0,0q�6,    � 	Resources 5   
    �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius ��Name �� Triggers	 P� Property
 P� Value �� 
TargetName��%J  '��       '�� �    �� 5      " ��6   .�5      ��  � �� 5      �� 5      " ��6*   .R�5      � .+�5   "   �� $��Border��6)   $��0,0,-4,0q�67   $��1,1,1,1q�6I   $ 0��6c   ._�5   &   �� $ ContentSite��67   $��Center=�6L   $��Center=�6g   $��Header��6�   $��2,2,2,2q�6�   ��. 6�   5   #   5       5      P� 5   "   	 �@��
IsSelected
 . . �5   &   ��  �@K�ZIndex$	 100��6E   �� 5   &   $ Border��6-    � ��$ 0,0,0,5q�6\   �� 5   &   $ Border��6-    � ��
 � � �6X   5   #   P� 5   "   	 �@��
IsSelected
 .  . �5   &   �� $ Border��6-    � �� �#FFFFFF6W   5   #   P� 5    "   	 �@J�IsMouseOver
 . 5!   #   5#      5%      5&      �� 5(      " ��6   .�5)      ��  � ��$ Center=�68   5*      5,      .@�5.   
   �� ��5/      �� 50      $	��100��6   $��15(�6$   $��Center=�62   $��
LOG SYSTEM��6V   .��52      �� -   5         ��Name$ 
scr_system��52      .��53      ��  �� 
IsReadOnly .  �� 
LineHeight$ 1��60      fontSizeNormal#��[  6I   $��Normal"�6t   $��Stretch=�6�   $��Stretch=�6�   . �54      /� .T�55      J�  �� Padding$ 10,10,10,10q�6$   .*�6:   .*�56      �� $��13(�6"   $��Normal"�60   �6D   ��  �� Path$ RN.logSystem� �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=�57      58      59      5:      5;      �� 5=   
   ��5>      �� 5?      $	��100��6   $��15(�6$   $��Center=�62   $��LOG DUT��6V   .��5A      �� -   5        $ scr_dut��5A      .��5B      ��  . $ 1��60   #��[  6I   $��Normal"�6t   $��Stretch=�6�   $��Stretch=�6�   . �5C      /� .T�5D      J� $ 10,10,10,10q�6$   .*�6:   .*�5E      �� $��13(�6"   $��Normal"�60   �6D   �� $ 	RN.logDut�$ PropertyChanged=�$ TwoWay=�5F      5G      5H      5I      5J      �� 5L   
   ��5M      �� 5N      $	��100��6   $��15(�6$   $��Center=�62   $��LOG DHCP��6V   .��5P      �� -   5        $ scr_dhcp��5P      .��5Q      ��  . $ 1��60   #��[  6I   $��Normal"�6t   $��Stretch=�6�   $��Stretch=�6�   . �5R      /� .T�5S      J� $ 10,10,10,10q�6$   .*�6:   .*�5T      �� $��13(�6"   $��Normal"�60   �6D   �� $ 
RN.logDhcp�$ PropertyChanged=�$ TwoWay=�5U      5V      5W      5X      5Y      5]      5_      