   M S B A M L   `   `   `  ����L  HWpf_QuanLyNhaHang, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Wpf_QuanLyNhaHangWpf_QuanLyNhaHang  5   	   '    !Wpf_QuanLyNhaHang.MainWindow_User   5   	   a ]DevExpress.Xpf.Core.v19.1, Version=19.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aR NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:Wpf_QuanLyNhaHang     5   	   b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   
      MaterialDesignBody#���   5
   
   $��Regular"�5   	   &   System.Windows.Media.TextOptions    TextRenderingMode$
  Auto=�5        MaterialDesignFont#���  5       � 
ResizeMode$ 	CanResize=�5   	    � Title$ 
MainWindow��5   	   $	��600��6   $
��1024��6)    � Topmost .  � WindowStartupLocation$ CenterScreen=�5       � AllowsTransparency .  � WindowStyle$
 None=�6W   .��5      � -   5         �Name$ MainWD��5   #   
�������.+�5   
   � -   5        $ GridTab��5      $��50��5      $	��Top=�6   $��Right=�5      $	��824��5      $��0��6   #��� ��5   1   .+�5      �� -   5        $��Tbl_TenForm��5      $��Center=�5       $��Center=�5!      $��22(�5"      5%      �� 5&       J� 	AllowDrop .  $	��170��6+   	 �� Orientation$	 
Horizontal=�67   $��Right=�6P   .+�5(      �� -   5        $��50��5)      $��0 0 5 0q�5*      $
��Left=�5+      
����  �
������ 
���������5(      0  *MaterialDesignThemes.Wpf.PackIconExtension  
   Kind$
 WindowMinimize=�50      �� 51      -   5        $��50��52      $��0 0 5 0q�53      $
��Left=�54      
��� � �
������ ��51        $
 WindowMaximize=�58      �� 59      -   5        $��50��5:      
�������$��Right=�5<      
���  ��
������ ��59        $
 Close=�5@      5A      �� 5B      -   5         ��Name$ ButtonMenuOpen��5C      $��1��5B      $��50��5E      $
��Left=�5F      
������ 
������ $��50��5I      
���   �$y�	Collapsed=�5K      ��5D        $

 Menu=�5O      �� 5P      -   5        $ ButtonMenuClose��5Q      $��1��5P      $��50��5S      $
��Left=�5T      
������ 
������ $��50��5W      
���   ���5R        $
 	ArrowLeft=�5]      5^      � 5_   
   -	   5        $ 	Grid_Form��5_      $��1��5`      $	��824��5a      $��Right=�5b      $��Bottom=�5c      $	��550��5e      5i      � 5n   
   -
   5        $
 menu��5n      $	��200��6   $
��Left=�5o      ���	#FF10376A$
��Auto=�5p      $
��Auto=�5q       � RowDefinitions 5r      �� 5s      $��70 �6    6.   �� 5t      $��* �6    6-   �� 5u      $��50 �6    6.   .+�5w      � $��0��6   
�������.+�5x      �� $'��!Assets\Logo-My-Mother-news-03.png��6   6E   5y      �� 5z      $��Stretch=�6   $��Disabled=�69   $
��Auto=�5{      $��1��65   ���	#FF1390F4.��5}      �� $	 Vertical=�6   #���   5~      .+�5�      9� -   5        $��
table_form��5�      $��Stretch=�5�      $��Table��6=   ���	#FF1390F4.��5�      �� $	 Vertical=�5�      #���   5�      .+�5�      �� -   5        $��BtnKhachHang��5�   -     MaterialDesignFlatButton#��[ 5�   !   .��5�   "   Khách hàng5�      �� 5�      -   5        $��BtnKhuyenMai��5�   -   #��[ 5�   !   .��5�   "   Khuyến mãi5�      �� 5�      -   5        $��
BtnMatHang��5�   -   #��[ 5�   !   .��5�   "   Mặt hàng5�      �� 5�      -   5        $��BtnMenu��5�   -   #��[ 5�   !   .��5�   "   Menu5�      �� 5�      -   5        $��BtnNhanVien��5�   -   #��[ 5�   !   .��5�   "   Nhân viên5�      �� 5�      -   5        $��BtnOrder��5�   -   #��[ 5�   !   .��5�   "   Order5�      �� 5�      -   5        $��BtnTaiKhoan��5�   -   #��[ 5�   !   .��5�   "   Tài khoản5�      5�      5�      9� 5�      $��Stretch=�6   $��Report��6=   ���	#FF1390F4.��5�      �� $	 Vertical=�5�      #���   5�      .+�5�      �� -   5        $��ReportHangton_nhap��5�   -   #��[ 5�   !   .��5�   "   Hàng tồn - nhập5�      5�      5�      �� 5�      -   5        ��5�      Z� ��5�      �� 5�       �� Color$ Transparent��6.   .��5�   .   Thanh toán5�      5�      5�      � 5�      $��2��6   
������� � ColumnDefinitions 5�      �� 5�      $��70 �6'   �� 5�      .+�5�      �� -   5        $��PicLogin��5�   @   $��70��6   $��50��6#   $��0��6/    J� OpacityMask
 �   �$
��Fill=�6d   5�      � 5�      $��1��6   $	��130��6,    � Orientation$ Vertical=�69   .+�5�      �� -   5        $��
LabelLogin��5�      $��18(�61   $��Bernard MT Condensed)�6?   $��Italic$�6a   $
��Bold"�6t   �� 5�      -   5        $��LabelLogin2��5�      $��12(�61   $��Book Antiqua)�6?   $��Italic$�6Y   $
��Bold"�6l   5�      5�      5�      5�      5�      