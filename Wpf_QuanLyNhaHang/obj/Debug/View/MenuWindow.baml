   M S B A M L   `   `   `  ����L  HWpf_QuanLyNhaHang, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Wpf_QuanLyNhaHangWpf_QuanLyNhaHang  5   	   '    !Wpf_QuanLyNhaHang.View.MenuWindow   5      a ]DevExpress.Xpf.Core.v19.1, Version=19.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aR NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:Wpf_QuanLyNhaHang     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	   -   5          >�Name$  window��5   	      MaterialDesignBody#���   5      $��Regular"�5      $��13(�5      &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5         TextRenderingMode$
 Auto=�5        MaterialDesignPaper#���  5        MaterialDesignFont#���  5       
 MenuVM � DataContext# [ 5   	   $	��750��5   
   $	��800��6   .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   .+�5!   
   � $��0��6   $
��Left=�6    � ColumnDefinitions 5"      �� 5#      $	��550 �6#   61   �� 5$      6%   .+�5&      � $��0��6    5'      �� 5(      $
��auto �6$   64   �� 5)      $
��auto �6$   64   .+�5+      #  MaterialDesignThemes.Wpf.Card  $��5q�6&   $��0��61   .��5,      � .+�5-      �� -   5         ��Name$ cbLoaiMA��5/      $��5 5 15 5q�50      $��2��51      $��12(�52       �� 
IsEditable . )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Loại món ăn��55      	 �� DisplayMemberPath$	 TENLOAIMONAN��56      ��54      �� *
listLoaiMA+
 �� Mode$
 TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=� �� SelectedItem 57      �� *SelectedLoaiMA+$
 TwoWay=�$ PropertyChanged=�5:      �� 5<      -   5        $ cbKhuyenMai��5>      $��5 5 15 5q�5?      $��2��5@      $��12(�5A       . $ Khuyến mãi��5D      $	 TENCT��5E      ��5C      �� *listKhuyenMai+$
 TwoWay=�$ PropertyChanged=� 5G      �� *
SelectedKM+$
 TwoWay=�$ PropertyChanged=�5J      �� 5L      -   5         ��Name$ txbTenMA��5M      $��5 5 15 5q�5O      $ Tên món ăn��5P       % !MaterialDesignFloatingHintTextBox#��[ 5Q      $��Center=�5R      ��5N      �� *TenMA+$ PropertyChanged=�$
 TwoWay=�5R      �� 5T      -   5        $ 	txbGiaBan��5U      $��5 5 15 5q�5W      $ 	Giá bán��5X      #��[ 6,   $��Center=�5Y      ��5V      �� *GiaBan+$ PropertyChanged=�$
 TwoWay=�5Y      �� 5[      -   5        $ txbDVT��5\      $��5 5 15 5q�5^      $ Đơn vị tính��5_      #��[ 60   $��Center=�5`      ��5]      �� *DVT+$ PropertyChanged=�$
 TwoWay=�5`      5b      5c        5e      $��5q�6'   $��1��62   .��5f      � .+�5g      �� $��Thêm��6!   $��5q�6P   ��60   �� *SaveCommand+5h      �� 5i      $
��Xóa��6!   $��5q�6Q   ��6/   �� *DeleteCommand+5j      �� 5k      $��Sửa��6!   $��5q�6Q   ��6/   �� *UpdateCommand+5l      �� 5m      $��Chọn hình��6!   $��5q�6V   ��65   �� *ImageCommand+5n      �� 5o      $��15 0 0 0q�5q      $	��200��6&   $ Tìm kiếm��5r      #��[ 5s      $��Center=�5t      ��5p      �� *Search+$ PropertyChanged=�$
 TwoWay=�.��5t   /   .  (System.Windows.Interactivity.Interaction   Triggers 5u      /  )System.Windows.Interactivity.EventTrigger  5v   "      	EventName$ TextChanged��61   .  (System.Windows.Interactivity.TriggerBase   Actions. 5w   &   6  0System.Windows.Interactivity.InvokeCommandAction     Command 6<   �� *TextChangedCommand+5x   #   .��5y   6   5z      5{      5|      5}      �� 5~      $��1��6    �� Orientation$ 
Horizontal=�6*   .+�5      �� $	��250��6   $	��100��6$   ��62   �� *Image+5�      5�        5�   
   $��1��6   $��5q�6+   .��5�      �� ��6   �� *
listMenu+$
 TwoWay=�$ PropertyChanged=� 5�      �� *SelectedItem+$
 TwoWay=�$ PropertyChanged=� �� View 5�      �� 5�      .P�5�      �� $��Mã món ăn��6)    �� DisplayMemberBinding 6<   �� *	MAMONAN+6g   �� 5�      $��Loại món ăn��6)    6>   �� *LOAIMONAN.TENLOAIMONAN+6x   �� 5�      $��Khuyến mãi��6)    6=   �� *KHUYENMAI.TENCT+6p   �� 5�      $��Tên món ăn��6)    6=   �� *
TENMONAN+6i   �� 5�      $��	Giá bán��6)    6:   �� *GIABAN+6d   �� 5�      $��Hình ảnh��6)    6;   �� *Image+6d   �� 5�      $��
Đơn vị��6)    69   �� *DVT+6`   5�      5�      5�      5�      5�      