   M S B A M L   `   `   `  ����O  KAIBoxTestFunctionAsm, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:AIBoxTestFunctionAsm.ViewsAIBoxTestFunctionAsm.Views  5      0    *AIBoxTestFunctionAsm.Views.PowerButtonView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:AIBoxTestFunctionAsm.Views     5      
�������  � 	Resources  5       �� 
TargetType �� Property   fontSizeNormal �� Value  color_ready �� Triggers �� Binding �� RelativeSource �� Mode �� Path	 �� Value  color_checked��%%  '	�       7   7  7  �� 5   
   " 	�6   .�5      ��  � ��8   6)   �� 5       � ��$ 10,5,0,0q�6'   �� 5       � ��$ 20��6'   �� 5       � ��$ Center=�62   �� 5       � ��$ Center=�69   �� 5       � ��$
 Left=�64   �� 5       � ��$ Normal"�6+   �� 5       � ��8  6+   -   5         5      �� 5       6   ��  �� $
 Self=�$ 	IsChecked�	 True6l   .a�5      ��  � ��$ SemiBold"�63   �� 5       � ��8  63   5      5      5      .��5!      ��   color_border#��[ 6   $��1q�69   ._�5"   
   �� $��5q�6   .+�5#      � .+�5$      �� #��[ 6   $��0,0,0,1q�6D   $
��Bold"�6^     fontSizeController#��[ 6p   $%��Kiểm tra nút nguồn và LED��6�   �� 5%      
���  ��$
��Bold"�6)   #��[ 6;   $��(��6j   �� 5&      
���  ��$
��Bold"�6)   #��[ 6;   ��6j   �� $ RN.buttonTimeout�
 �� UpdateSourceTrigger$
 PropertyChanged=��� 5'      
���  ��$
��Bold"�6)   #��[ 6;   $��sec )��6j   5(      �� 5)      $��0,5,0,0q�6   $
��Wrap=�6)   #��[  6=   $w��qNhấn giữ nút nguồn trong khoảng 10 giây. Sau đó nhả tay ra và quan sát trạng thái LED nguồn.��6h   �� 5*      $��0,5,0,10q�6   $
��Wrap=�6*   #��[  6>   $L��FClick chọn 1 trong 2 trạng thái của LED ở bên dưới đây:��6i   �� 5+      .+�5,      	� 
 � Tag$ 0��6   $��	LED tắt��6&   	� 5-      $ 1��6   $��LED sáng xanh��6&   5.      �� 5/        fontSizeButton#��[ 6>   $��SemiBold"�6i   $��50��6   $��0,20,0,0q�6�   $��Xác nhận��6�   ��6   �� *ButtonConfirmCommand+��50      �� 51      " ��6   .�52      ��  � {� . 66    53      �� 54       6*   �� $ RN.buttonIdResult�	 -16U   .a�55   "   ��  � {� .  6>   56      58      5:      �� 5;      $��0,20,0,0q�6   #��[  6&   $��Kết quả:��6Q   �� 5<      ��6   �� $ RN.checkPowerButtonResult�$
 PropertyChanged=���5=      �� 5>      " ��6   .�5?      ��  � ��$ 40(�65   �� 5@       � ��$ 	0,-10,0,0q�63   �� 5A       � ��$ SemiBold"�67   �� 5B       � ��# [ 67    5C      �� 5D       6*   ��  �� $
 Self=�$ Content�	 
Waiting...6v   .a�5E   "   ��  � ��  
color_wait# [ 6?   5F      �� 5G       6*   ��  �� $
 Self=�$ Content�
	 Passed6v   .a�5H   "   ��  � ��  
color_pass# [ 6?   5I      �� 5J       6*   ��  �� $
 Self=�$ Content�
	 Failed6v   .a�5K   "   ��  � ��  
color_fail# [ 6?   5L      5N      5P      5Q      5R      5U      