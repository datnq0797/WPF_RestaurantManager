using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using Wpf_QuanLyNhaHang.Model;
using Wpf_QuanLyNhaHang.ViewModel.Encryption;
namespace Wpf_QuanLyNhaHang.ViewModel
{
    public class DangNhapViewModel:BaseViewModel
    {
		private string p;
		Encryp_MD5 MD5 = new Encryp_MD5();
		public ICommand LoginCommand { get; set; }

		public DangNhapViewModel()
		{
			LoginCommand = new RelayCommand<object>((p) =>
			{
				return true;
			},
			(p) =>
			{
				p = MD5.Encryption(pass);
				var list = DataProvider.Ins.DB.TAIKHOANs.Where(x => x.USER == user && x.PASS == p).SingleOrDefault();
				if (list != null)
				{


					MainWindow m = new MainWindow(list.MATK);
					m.Show();
					

				}
				else
				{
					
					MessageBox.Show("Tài khoản hoặc mật khẩu chưa đúng!!!");
					DangNhap dn = new DangNhap();
					dn.ShowDialog();

				}

			});
		}


		private string _user;
		public string user
		{
			get { return _user; }
			set
			{
				_user = value;
				OnPropertyChanged();
			}
		}

		private string _pass;
		public string pass
		{
			get { return _pass; }
			set
			{
				_pass = value;
				OnPropertyChanged();
			}
		}
	}
}
