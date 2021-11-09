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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using Wpf_QuanLyNhaHang.ViewModel;
using Wpf_QuanLyNhaHang.User_Control;
using Wpf_QuanLyNhaHang.View;
using Wpf_QuanLyNhaHang.Reporting;
using Wpf_QuanLyNhaHang.Model;
namespace Wpf_QuanLyNhaHang
{
    /// <summary>
    /// Interaction logic for MainWinfow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
		private Control _currentUser;
		
        public MainWindow()
        {
            InitializeComponent();
			
		}

		public MainWindow(int us)
		{
			InitializeComponent();
			
			var query = (
				from tk in DataProvider.Ins.DB.TAIKHOANs 
				join ltk in DataProvider.Ins.DB.LOAITKs on tk.MALOAITK equals ltk.MALOAITK
				where tk.MATK == us
				select new {tk.HINHANH,ltk.TENLOAITK,tk.USER}	
					).FirstOrDefault();
				
			if(query.TENLOAITK.Equals("USER"))
			{
				BtnLoaiMH.Height = 0;
				BtnChucVu.Height = 0;
				BtnKhuyenMai.Height = 0;
				BtnLoaiMA.Height = 0;
				BtnMatHang.Height = 0;
				BtnMenu.Height = 0;
				BtnNhanVien.Height = 0;
				BtnPhieuNhap.Height = 0;

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
			Tbl_TenForm.Text = "Trang chủ";


		

		}

		#region handle button
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
			this.Close();
			DangNhap dn = new DangNhap();
			dn.Show();
		}

		private void move(object sender, MouseButtonEventArgs e)
		{
			this.DragMove();
		}

		private void MaximizeForm_Click(object sender, RoutedEventArgs e)
		{
			this.WindowState = WindowState.Maximized;
			GridTab.Width = (MainWD.ActualWidth - menu.Width);
			
			Grid_Form.Width= (MainWD.ActualWidth - menu.Width);
			Grid_Form.Height = (MainWD.ActualHeight - GridTab.Height);
		}

		private void SetValue(string s)
		{
			MessageBox.Show(s);
		}
		#endregion
		#region thêm form con vào form chính
		//------thêm form con vào form chính

		private void BtnChucVu_Click(object sender, RoutedEventArgs e)
		{
			ChucVuWindow cv = new ChucVuWindow();
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
			Tbl_TenForm.Text = "Chi tiết order";
		}

		private void BtnCTPhieuNhap_Click(object sender, RoutedEventArgs e)
		{
			CTPhieuNhapWindow cv = new CTPhieuNhapWindow();
			Grid_Form.Children.Clear();
			if (_currentUser != cv)
			{
				_currentUser = cv;
			}
			_currentUser.Width = Grid_Form.Width;
			_currentUser.Height = Grid_Form.Height;
			Grid_Form.Children.Add(_currentUser);
			Tbl_TenForm.Text = "Chi tiết phiếu nhập";
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
			Tbl_TenForm.Text = "Khách hàng";
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
			Tbl_TenForm.Text = "Khuyến mãi";
		}

		

		private void BtnLoaiMA_Click(object sender, RoutedEventArgs e)
		{
			LoaiMAWindow cv = new LoaiMAWindow();
			Grid_Form.Children.Clear();
			if (_currentUser != cv)
			{
				_currentUser = cv;
			}
			_currentUser.Width = Grid_Form.Width;
			_currentUser.Height = Grid_Form.Height;
			Grid_Form.Children.Add(_currentUser);
			Tbl_TenForm.Text = "Loại món ăn";
		}

		private void BtnLoaiMH_Click(object sender, RoutedEventArgs e)
		{

			LoaiMHWindow cv = new LoaiMHWindow();
			Grid_Form.Children.Clear();
			if (_currentUser != cv)
			{
				_currentUser = cv;
			}
			_currentUser.Width = Grid_Form.Width;
			_currentUser.Height = Grid_Form.Height;
			Grid_Form.Children.Add(_currentUser);
			Tbl_TenForm.Text = "Loại mặt hàng";
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
			Tbl_TenForm.Text = "Mặt hàng";
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
			Tbl_TenForm.Text = "Menu";
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
			Tbl_TenForm.Text = "Nhân viên";
		}

		private void BtnOrder_Click(object sender, RoutedEventArgs e)
		{
			OrderWindow cv = new OrderWindow();
			Grid_Form.Children.Clear();
			if (_currentUser != cv)
			{
				_currentUser = cv;
			}
			_currentUser.Width = Grid_Form.Width;
			_currentUser.Height = Grid_Form.Height;
			Grid_Form.Children.Add(_currentUser);
			Tbl_TenForm.Text = "Order";
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
			Tbl_TenForm.Text = "Tài khoản";
		}

		private void BtnPhieuNhap_Click(object sender, RoutedEventArgs e)
		{
			PhieuNhapWindow cv = new PhieuNhapWindow();
			Grid_Form.Children.Clear();
			if (_currentUser != cv)
			{
				_currentUser = cv;
			}
			_currentUser.Width = Grid_Form.Width;
			_currentUser.Height = Grid_Form.Height;
			Grid_Form.Children.Add(_currentUser);
			Tbl_TenForm.Text = "Phiếu nhập";
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
			Tbl_TenForm.Text = "Báo cáo hàng tồn -  nhập";
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
			Tbl_TenForm.Text = "Thanh toán";
		}

		private void BtnTrangChu_Click(object sender, RoutedEventArgs e)
		{
			ChartMain cv = new ChartMain();
			Grid_Form.Children.Clear();
			if (_currentUser != cv)
			{
				_currentUser = cv;
			}
			_currentUser.Width = Grid_Form.Width;
			_currentUser.Height = Grid_Form.Height;
			Grid_Form.Children.Add(_currentUser);
			Tbl_TenForm.Text = "Trang chủ";
		}

		private void Btnsoluongbanduoc_Click(object sender, RoutedEventArgs e)
		{
			Chart_Soluongmonan_Banduoc cv = new Chart_Soluongmonan_Banduoc();
			Grid_Form.Children.Clear();
			if (_currentUser != cv)
			{
				_currentUser = cv;
			}
			_currentUser.Width = Grid_Form.Width;
			_currentUser.Height = Grid_Form.Height;
			Grid_Form.Children.Add(_currentUser);
			Tbl_TenForm.Text = "Report số lượng món ăn bán được";
		}
	}
}
