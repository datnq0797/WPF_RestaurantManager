   M S B A M L   `   `   `  ����L  HWpf_QuanLyNhaHang, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Wpf_QuanLyNhaHang.ViewWpf_QuanLyNhaHang.View  5   	   +    %Wpf_QuanLyNhaHang.View.CTOrder_Window   5      a ]DevExpress.Xpf.Core.v19.1, Version=19.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aR NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:Wpf_QuanLyNhaHang.View     5   	   b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   
   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5	   	   -   5          >�Name$  window��5   	      MaterialDesignBody#���   5
      $��Regular"�5      $��13(�5      &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5         TextRenderingMode$
 Auto=�5        MaterialDesignPaper#���  5        MaterialDesignFont#���  5        	CTOrderVM � DataContext# [ 5   	   $	��550��5   	   $	��900��6   .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   .+�5!   
   � $��0��6   5#      #  MaterialDesignThemes.Wpf.Card  5$   
   $��5q�6   $��1��6)   .��5%      � .+�5&      �� -   5         ��Name$ cbMaMA��5(      $��5 5 15 5q�5'      $��2��5)      $��12(�5*       �� 
IsEditable . )  #MaterialDesignThemes.Wpf.HintAssist   Hint$
 Menu��5-       �� DisplayMemberPath$ TENMONAN��5.      ��5,      �� *
ListMenu+	 �� Mode$	 TwoWay=�
 �� UpdateSourceTrigger$
 PropertyChanged=� �� SelectedItem 5/      �� *
SelectedMN+$	 TwoWay=�$
 PropertyChanged=�50      �� 52      -   5        $ cbMaKH��54      $��5 5 15 5q�53      $��2��55      $��12(�56       . $ Order ��5:      $ KHACHHANG.TENKH��5;      $	��137��5<   i   ��58      �� *ListOrder_KH+$	 TwoWay=�$
 PropertyChanged=� 5<      �� *
SelectedOD+$	 TwoWay=�$
 PropertyChanged=�.  (System.Windows.Interactivity.Interaction   Triggers 5>      /  )System.Windows.Interactivity.EventTrigger  5?         	EventName$ SelectionChanged��6)   .  (System.Windows.Interactivity.TriggerBase   Actions. 5@      6  0System.Windows.Interactivity.InvokeCommandAction     Command 64   �� *SelectionChanged+5B      5E      �� 5G      -   5         ��Name$ 
txbSoluong��5H      $��5 5 15 5q�5K      $ Số lượng��5L       % !MaterialDesignFloatingHintTextBox#��[ 6-   $��Center=�5M      ��5J      �� *	Soluong+$
 PropertyChanged=�5M      5P      5Q        5S   
   $��2��6   $��5q�6+   .��5T      � .+�5U      �� $��Thêm��6   $��5q�6H   ��6(   �� *SaveCommand+5V      �� 5W      $
��Xóa��6   $��5q�6I   ��6'   �� *DeleteCommand+5X      �� 5Y      $��Sửa��6   $��5q�6I   ��6'   �� *UpdateCommand+5Z      �� 5[      $��15 0 0 0q�5]      $	��200��6&   $ Tìm kiếm��5^      #��[ 5_      $��Center=�5`      ��5\      �� *Search+$
 PropertyChanged=�$	 TwoWay=�.��5`   /    5a        5b      $ TextChanged��6)   . 5c         64   �� *TextChangedCommand+5d      .��5e   .   5f      5g      5h        5j   
   $��3��6   $��5q�6+   .��5k      �� ��6   �� *	ListOrder+$	 TwoWay=�$
 PropertyChanged=� 5l      �� *SelectedItem+$	 TwoWay=�$
 PropertyChanged=� �� View 5m      �� 5n      .P�5o      �� $��Tên món ăn��6)    �� DisplayMemberBinding 6=   �� *MENU.TENMONAN+6n   �� 5p      $��	Mã order��6)    6;   �� *MAOD+6c   �� 5q      $��Số lượng��6)    6;   �� *	SOLUONG+6g   5s      5u      5v      5w      5x      