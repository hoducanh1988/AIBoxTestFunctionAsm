   M S B A M L   `   `   `  ����O  KAIBoxTestFunctionAsm, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:AIBoxTestFunctionAsm.ViewsAIBoxTestFunctionAsm.Views  5      )    #AIBoxTestFunctionAsm.Views.HDMIView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:AIBoxTestFunctionAsm.Views     5      
�������  � 	Resources  5
       �� 
TargetType �� Property   fontSizeNormal �� Value  color_ready �� Triggers �� Binding �� RelativeSource �� Mode �� Path	 �� Value  color_checked��%%  '	�       7   7  7  �� 5   
   " 	�6   .�5      ��  � ��8   6)   �� 5       � ��$ 10,5,0,0q�6'   �� 5       � ��$ 20��6'   �� 5       � ��$ Center=�62   �� 5       � ��$ Center=�69   �� 5       � ��$
 Left=�64   �� 5       � ��$ Normal"�6+   �� 5       � ��8  6+   -   5         5      �� 5       6   ��  �� $
 Self=�$ 	IsChecked�	 True6l   .a�5      ��  � ��$ SemiBold"�63   �� 5       � ��8  63   5      5      5      .��5       ��   color_border#��[ 6   $��1q�69   ._�5!   
   �� $��5q�6   .+�5"      � .+�5#      �� #��[ 6   $��0,0,0,1q�6D   $
��Bold"�6^     fontSizeController#��[ 6p   $(��"Kiểm tra cổng kết nối HDMI��6�   �� 5$      
���  ��$
��Bold"�6)   #��[ 6;   $��(��6j   �� 5%      
���  ��$
��Bold"�6)   #��[ 6;   ��6j   �� $ RN.hdmiTimeout�
 �� UpdateSourceTrigger$
 PropertyChanged=��� 5&      
���  ��$
��Bold"�6)   #��[ 6;   $��sec )��6j   5'      �� 5(      #��[  6   $F��@Vui lòng chọn 1 trong những kết quả bên dưới đây:��6?   �� 5)      .+�5*      	� 
 � Tag$ 0��6   $3��-Hình ảnh tốt nhìn sắc nét, rõ ràng��6&   	� 5+      $ 1��6   $4��.Hình ảnh lỗi bị nhòe, nhìn không rõ��6&   	� 5,      $ 2��6   $?��9Hình ảnh lỗi bị mất 1 phần không hiển thị��6&   	� 5-      $ 3��6   $;��5Hình ảnh lỗi bị sọc ngang hoặc sọc dọc��6&   	� 5.      $ 4��6   $"��Hình ảnh bị lỗi khác��6&   5/      �� 50        fontSizeButton#��[ 6<   $��SemiBold"�6g   $��50��6}   $��0,20,0,0q�6�   $��Xác nhận��6�   ��6   �� *HDMIConfirmCommand+��51      �� 52      " ��6   .�53      ��  � {� . 66    54      �� 55       6*   �� $ RN.hdmiIdResult�	 -16S   .a�56   "   ��  � {� .  6>   57      59      5;      �� 5<      $��0,20,0,0q�6   #��[  6&   $��Kết quả:��6Q   �� 5=      ��6   �� $ RN.checkHdmiResult�$
 PropertyChanged=���5>      �� 5?      " ��6   .�5@      ��  � ��$ 40(�65   �� 5A       � ��$ 	0,-10,0,0q�63   �� 5B       � ��$ SemiBold"�67   �� 5C       � ��# [ 67    5D      �� 5E       6*   ��  �� $
 Self=�$ Content�	 
Waiting...6v   .a�5F   "   ��  � ��  
color_wait# [ 6?   5G      �� 5H       6*   ��  �� $
 Self=�$ Content�
	 Passed6v   .a�5I   "   ��  � ��  
color_pass# [ 6?   5J      �� 5K       6*   ��  �� $
 Self=�$ Content�
	 Failed6v   .a�5L   "   ��  � ��  
color_fail# [ 6?   5M      5O      5Q      5R      5S      5V      