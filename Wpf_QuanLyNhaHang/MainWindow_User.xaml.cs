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
using Wpf_QuanLyNhaHang.View;
using Wpf_QuanLyNhaHang.Reporting;
using Wpf_QuanLyNhaHang.Model;
namespace Wpf_QuanLyNhaHang
{
    /// <summary>
    /// Interaction logic for MainWindow_User.xaml
    /// </summary>
    public partial class MainWindow_User : Window
    {

		private Control _currentUser;

		public MainWindow_User()
        {
            InitializeComponent();
        }
		public MainWindow_User(int us)
		{
			InitializeComponent();

			var query = (
				from tk in DataProvider.Ins.DB.TAIKHOANs
				join ltk in DataProvider.Ins.DB.LOAITKs on tk.MALOAITK equals ltk.MALOAITK
				where tk.MATK == us
				select new { tk.HINHANH, ltk.TENLOAITK, tk.USER }
					).FirstOrDefault();

			if (query.TENLOAITK.Equals("USER"))
			{
				table_form.Height = 0;
			}

			//---gán thông tin vào phần admin
			PicLogin.Source = new BitmapImage(new Uri(query.HINHANH));

			LabelLogin.Content = query.USER.ToString();
			LabelLogin2.Content = query.TENLOAITK.ToString();


			//----thêm chart main 
			ChartMain cv = new ChartMain();
			Grid_Form.Children.Clear();
			if (_currentUser != cv)
			{
				_currentUser = cv;
			}
			_currentUser.Width = Grid_Form.Width;
			_currentUser.Height = Grid_Form.Height;

			//------thêm from vào grid
			Grid_Form.Children.Add(_currentUser);
			Tbl_TenForm.Text = "Chức vụ";

		}
		private void ButtonMenuOpen_Click(object sender, RoutedEventArgs e)
		{
			ButtonMenuOpen.Visibility = Visibility.Collapsed;
			ButtonMenuClose.Visibility = Visibility.Visible;
			menu.Width = 200;
			GridTab.Width = (MainWD.ActualWidth - menu.Width);
			Grid_Form.Width = (MainWD.ActualWidth - menu.Width);
			

		}

		private void ButtonMenuClose_Click(object sender, RoutedEventArgs e)
		{
			ButtonMenuOpen.Visibility = Visibility.Visible;
			ButtonMenuClose.Visibility = Visibility.Collapsed;
			menu.Width = 0;
			GridTab.Width = (MainWD.ActualWidth - menu.Width);
			Grid_Form.Width = (MainWD.ActualWidth);

		}

		private void MinimizeForm(object sender, RoutedEventArgs e)
		{

		}

		private void MinimizeForm_Click(object sender, RoutedEventArgs e)
		{
			this.WindowState = WindowState.Minimized;
		}

		private void CloseForm_Click(object sender, RoutedEventArgs e)
		{
			System.Windows.Application.Current.Shutdown();
		}

		private void move(object sender, MouseButtonEventArgs e)
		{
			this.DragMove();
		}

		private void MaximizeForm_Click(object sender, RoutedEventArgs e)
		{
			this.WindowState = WindowState.Maximized;
			GridTab.Width = (MainWD.ActualWidth - menu.Width);

			Grid_Form.Width = (MainWD.ActualWidth - menu.Width);
			Grid_Form.Height = (MainWD.ActualHeight - GridTab.Height);
		}

		private void SetValue(string s)
		{
			MessageBox.Show(s);
		}

		#region thêm form con vào form chính
		//------thêm form con vào form chính

		

		private void BtnCTOrder_Click(object sender, RoutedEventArgs e)
		{
			CTOrder_Window cv = new CTOrder_Window();
			Grid_Form.Children.Clear();
			if (_currentUser != cv)
			{
				_currentUser = cv;
			}
			_currentUser.Width = Grid_Form.Width;
			_currentUser.Height = Grid_Form.Height;
			Grid_Form.Children.Add(_currentUser);
			Tbl_TenForm.Text = "Chi tiết Order";
		}

	

		private void BtnKhachHang_Click(object sender, RoutedEventArgs e)
		{
			KhachHangWindow cv = new KhachHangWindow();
			Grid_Form.Children.Clear();
			if (_currentUser != cv)
			{
				_currentUser = cv;
			}
			_currentUser.Width = Grid_Form.Width;
			_currentUser.Height = Grid_Form.Height;
			Grid_Form.Children.Add(_currentUser);
		}

		private void BtnKhuyenMai_Click(object sender, RoutedEventArgs e)
		{
			KhuyenMaiWindow cv = new KhuyenMaiWindow();
			Grid_Form.Children.Clear();
			if (_currentUser != cv)
			{
				_currentUser = cv;
			}
			_currentUser.Width = Grid_Form.Width;
			_currentUser.Height = Grid_Form.Height;
			Grid_Form.Children.Add(_currentUser);
		}



		

		private void BtnMatHang_Click(object sender, RoutedEventArgs e)
		{
			MatHangWindow cv = new MatHangWindow();
			Grid_Form.Children.Clear();
			if (_currentUser != cv)
			{
				_currentUser = cv;
			}
			_currentUser.Width = Grid_Form.Width;
			_currentUser.Height = Grid_Form.Height;
			Grid_Form.Children.Add(_currentUser);
		}

		private void BtnMenu_Click(object sender, RoutedEventArgs e)
		{
			MenuWindow cv = new MenuWindow();
			Grid_Form.Children.Clear();
			if (_currentUser != cv)
			{
				_currentUser = cv;
			}
			_currentUser.Width = Grid_Form.Width;
			_currentUser.Height = Grid_Form.Height;
			Grid_Form.Children.Add(_currentUser);
		}

		private void BtnNhanVien_Click(object sender, RoutedEventArgs e)
		{
			NhanVienWindow cv = new NhanVienWindow();
			Grid_Form.Children.Clear();
			if (_currentUser != cv)
			{
				_currentUser = cv;
			}
			_currentUser.Width = Grid_Form.Width;
			_currentUser.Height = Grid_Form.Height;
			Grid_Form.Children.Add(_currentUser);
		}

		
		private void BtnTaiKhoan_Click(object sender, RoutedEventArgs e)
		{
			TaiKhoanWindow cv = new TaiKhoanWindow();
			Grid_Form.Children.Clear();
			if (_currentUser != cv)
			{
				_currentUser = cv;
			}
			_currentUser.Width = Grid_Form.Width;
			_currentUser.Height = Grid_Form.Height;
			Grid_Form.Children.Add(_currentUser);
		}

		#endregion

		private void BtnThanhToan_Click(object sender, RoutedEventArgs e)
		{
			ThanhToanWindow cv = new ThanhToanWindow();
			Grid_Form.Children.Clear();
			if (_currentUser != cv)
			{
				_currentUser = cv;
			}
			_currentUser.Width = Grid_Form.Width;
			_currentUser.Height = Grid_Form.Height;
			Grid_Form.Children.Add(_currentUser);
		}

		private void BtnHangton_nhap_Click(object sender, RoutedEventArgs e)
		{
			ChartHangton_nhap cv = new ChartHangton_nhap();
			Grid_Form.Children.Clear();
			if (_currentUser != cv)
			{
				_currentUser = cv;
			}
			_currentUser.Width = Grid_Form.Width;
			_currentUser.Height = Grid_Form.Height;
			Grid_Form.Children.Add(_currentUser);
		}
	}
}
