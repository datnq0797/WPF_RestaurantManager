using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Wpf_QuanLyNhaHang.User_Control;
using static Wpf_QuanLyNhaHang.MainWindow;
using Wpf_QuanLyNhaHang.Model;
using Wpf_QuanLyNhaHang.ViewModel.Encryption;
namespace Wpf_QuanLyNhaHang
{
	/// <summary>
	/// Interaction logic for DangNhap.xaml
	/// </summary>
	public partial class DangNhap : Window
	{

		
		public DangNhap()
		{
			InitializeComponent();
			
		}

		
		private void MinimizeForm_Click(object sender, RoutedEventArgs e)
		{
			this.WindowState = WindowState.Minimized;
		}

		private void CloseForm_Click(object sender, RoutedEventArgs e)
		{
			System.Windows.Application.Current.Shutdown();
		}

		private void btn_login_Click(object sender, RoutedEventArgs e)
		{
			this.Hide();

		}

		
	}
}
