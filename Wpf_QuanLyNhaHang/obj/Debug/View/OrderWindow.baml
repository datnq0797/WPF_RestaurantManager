   M S B A M L   `   `   `  ����L  HWpf_QuanLyNhaHang, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Wpf_QuanLyNhaHang.ViewWpf_QuanLyNhaHang.View  5   	   (    "Wpf_QuanLyNhaHang.View.OrderWindow   5      a ]DevExpress.Xpf.Core.v19.1, Version=19.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aR NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:Wpf_QuanLyNhaHang.View     5   	   b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   
   -   5          >�Name$  window��5   	      MaterialDesignBody#���   5
      $��Regular"�5      $��13(�5      &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5         TextRenderingMode$
 Auto=�5        MaterialDesignPaper#���  5        MaterialDesignFont#���  5        OrderVM � DataContext# [ 5   	   $	��550��5   
   $	��900��6   .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   .+�5!   
   � $��0��6   5#      #  MaterialDesignThemes.Wpf.Card  5$   
   $��5q�6   $��1��6)   .��5%      � .+�5&      �� -   5         ��Name$
 cbNV��5(      $��5 5 15 5q�5'      $��2��5)      $��12(�5*       �� 
IsEditable . )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Nhân viên ��5-       �� DisplayMemberPath$ TENNV��5.      ��5,      �� *ListNhanVien+	 �� Mode$	 TwoWay=�
 �� UpdateSourceTrigger$
 PropertyChanged=� �� SelectedItem 5/      �� *
SelectedNV+$	 TwoWay=�$
 PropertyChanged=�50      �� 52      -   5        $
 cbKH��54      $��5 5 15 5q�53      $��2��55      $��12(�56       . $ Khách hàng ��5:      $ TENKH��5;      $	��137��5<   i   ��58      �� *ListKhachHang+$	 TwoWay=�$
 PropertyChanged=� 5<      �� *
SelectedKH+$	 TwoWay=�$
 PropertyChanged=�5=      �� 5?      $��5 5 15 5q�5A      $! Số tiền đặt trước��5B       % !MaterialDesignFloatingHintTextBox#��[ 66   $��Center=�5C      ��5@      �� *	SoTienDat+$
 PropertyChanged=�5C      �� 5E      $��5 5 15 5q�5G      $ Số khách��5H      #��[ 6-   $��Center=�5I      ��5F      �� *	SoKhach+$
 PropertyChanged=�5I      (  "System.Windows.Controls.DatePicker  5K         DisplayDateStart$ 4/5/2021X�5M      $��5 5 15 5q�5N      $	��140��5O      $ Ngày đặt��5P       $  MaterialDesignOutlinedDatePicker#��[ 5Q         Text 5L      �� *	NgayDat+$
 PropertyChanged=�$	 TwoWay=�5Q      5R      5S        5U   
   $��2��6   $��5q�6+   .��5V      � .+�5W      �� $��Thêm��6   $��5q�6H   ��6(   �� *SaveCommand+5X      �� 5Y      $
��Xóa��6   $��5q�6I   ��6'   �� *DeleteCommand+5Z      �� 5[      $��Sửa��6   $��5q�6I   ��6'   �� *UpdateCommand+5\      5]      5^        5`   
   $��3��6   $��5q�6+   .��5a      �� ��6   �� *	ListOrder+$	 TwoWay=�$
 PropertyChanged=� 5b      �� *SelectedItem+$	 TwoWay=�$
 PropertyChanged=� �� View 5c      �� 5d      .P�5e      �� $��Nhân viên��6)    �� DisplayMemberBinding 6<   �� *NHANVIEN.TENNV+6n   �� 5f      $��Khách hàng��6)    6=   �� *KHACHHANG.TENKH+6p   �� 5g      $��Số tiền đặt��6)    6>   �� *	SOTIENDAT+6l   �� 5h      $��Ngày đặt��6)    6;   �� *	NGAYDAT+ �� StringFormat$ 
dd/MM/yyyy��6�   �� 5i      $��Số khách��6)    6;   �� *	SOKHACH+6g   5j      5l      5m      5n      5o      