   M S B A M L   `   `   `  ����L  HWpf_QuanLyNhaHang, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:Wpf_QuanLyNhaHang.User_ControlWpf_QuanLyNhaHang.User_Control  5   	        Wpf_QuanLyNhaHang.DangNhap   5   	   a ]DevExpress.Xpf.Core.v19.1, Version=19.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aR NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   ?user_control,clr-namespace:Wpf_QuanLyNhaHang.User_Control  5   	   -   5        $��dangnhap��5   	      MaterialDesignBody#���   5   	   $��Regular"�5	      $��13(�5
      &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5         TextRenderingMode$
 Auto=�5        MaterialDesignPaper#���  5        MaterialDesignFont#���  5       � WindowStartupLocation$ CenterScreen=�5   	    � 
ResizeMode$ 	CanResize=�5   	    � WindowStyle$
 None=�5   	    � Title$ DangNhap��5   	   $	��450��5   
   $	��800��6     
DangNhapVM � DataContext# [ 5   	   .��5      � ��5   
   �� 5       �� 
StartPoint$ 0.1,0&�6"    �� EndPoint$ 0.9,1&�65   .��5      � 	 � Color$
	 Blue��6   
 � Offset$
 1Q�6,   69   � 5      $
	 Aqua��6   $
 0Q�6,   69   5      .+�5    
   �� $	��390��6   $	��Top=�6    �� CornerRadius$ 	0 0 180 0��66   
�������._�5!      �� $��Right=�6   $	��Top=�65   $	��120��6M    �� Orientation$ 
Horizontal=�6Y   .+�5"      �� -   5        $��50��5#      $��0 0 5 0q�5$      $
��Left=�5%      
������ 
������ 
���   ���5"      0  *MaterialDesignThemes.Wpf.PackIconExtension     Kind$ WindowMinimize=�5*      �� 5+      -   5        $��50��5,      $��0 0 5 0q�5-      $
��Left=�5.      
������ 
������ 
���   ���5+        $ Close=�53      54      55      �� 56   
   $ 
Horizontal=�6   .+�57      �� $	��350��6   .+�58      �� $'��!Assets\Logo-My-Mother-news-03.png��6   $	��Top=�59      $��0 90 0 0q�5:      $	��300��5;      5=      �� 5>      $	��350��6   .+�5?      �� $��20 40q�6   .+�5@      �� $��
User login��6    $��20q�62   
���   � �� TextAlignment$ Center=�6Q   $��38(�5A       $��Italic$�6.   $��Times New Roman)�6A   6a   �� 5B      $ 
Horizontal=�6!   $��10q�6:   .+�5C      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$
 User=�62   $��25��6>   $��25��5D      
���   �6@   �� 5E      -   5         ��Name$ txtUsername��5I   "   $
��10 0q�5E   "   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Enter Username / Email��60   
���   �$	��250��5G   "   
������� �� SelectionBrush
 �������5J   #   �� *user+ �� UpdateSourceTrigger$ PropertyChanged=�5K   %   5L      �� 5N      $ 
Horizontal=�6!   $��10q�6:   .+�5O        $ Password=�62   $��25��6B   $��25��5P      
���   �6@   7   1Wpf_QuanLyNhaHang.User_Control.BinablePasswordBox  5Q      -   5          Name$ txtPassword��5W   &   $
��10 0q�5Q   :   $  *******��6H   
���   �$	��250��5S   "   
�������   Password 5V   !   �� *pass+$ PropertyChanged=� �� Mode$ TwoWay=�5X   %   5Y      �� 5Z      $ 
Horizontal=�6!   $��10q�6:   $��Center=�6F   .+�5[      �� -   5         ��Name$ btnLogin��5d      $	��100��5\   !   $��40��5]   !   +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 10��5^      $��2q�5_      
����  �
�������
����  � � ToolTip$ Login��5c      $��Login��5e      ��5h      �� *LoginCommand+5i   $   5j      5k      5m      5n      5o      5r      