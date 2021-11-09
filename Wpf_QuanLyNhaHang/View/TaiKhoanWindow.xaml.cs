using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Wpf_QuanLyNhaHang.View
{
	/// <summary>
	/// Interaction logic for TaiKhoanWindow.xaml
	/// </summary>
	public partial class TaiKhoanWindow : UserControl
	{
		public TaiKhoanWindow()
		{
			InitializeComponent();
			btnXoa.IsEnabled = false;
			btnHuy.IsEnabled = false;
			btnSua.IsEnabled = false;
			
		}

		private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			//---đây là nút xóa - nhấn vào hiện box kiểm tra mật khẩu.
			btnHuy.IsEnabled = true; //---hiện nút hủy
			btnXoa.IsEnabled = false;
			kt_sua.Visibility = Visibility.Hidden;
			kt_xoa.Visibility = Visibility.Visible;
			var converter = new GridLengthConverter();
			Row_Kiemtra.Height = (GridLength)converter.ConvertFromString("200");
			Row_ListView.Height = (GridLength)converter.ConvertFromString("0");
		}

		private void BtnHuy_Click(object sender, RoutedEventArgs e)
		{
			//----hủy thao tác xóa
			btnHuy.IsEnabled = false;//nút xóa,sửa ẩn.
			btnXoa.IsEnabled = false;
			btnSua.IsEnabled = false;
			//box kiểm tra ẩn
			var converter = new GridLengthConverter();
			Row_Kiemtra.Height = (GridLength)converter.ConvertFromString("0");
			Row_ListView.Height = (GridLength)converter.ConvertFromString("330");
		}

		private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			//---list phải được chọn thì mới bật nút xóa sửa
			if (ListView.IsSelectedProperty.Equals(false))
			{
				btnXoa.IsEnabled = false;
				btnSua.IsEnabled = false;
			}
			else
			{
				btnXoa.IsEnabled = true;
				btnSua.IsEnabled = true;
			}
		}

		private void BtnSua_Click(object sender, RoutedEventArgs e)
		{
			//---đây là nút sửa - nhấn vào hiện box kiểm tra mật khẩu.
			btnHuy.IsEnabled = true; //---hiện nút hủy
			btnSua.IsEnabled = false;
			kt_sua.Visibility = Visibility.Visible;
			kt_xoa.Visibility = Visibility.Hidden;
			txbPass.Text = "";
			var converter = new GridLengthConverter();
			Row_Kiemtra.Height = (GridLength)converter.ConvertFromString("200");
			Row_ListView.Height = (GridLength)converter.ConvertFromString("0");
		}
	}
}
