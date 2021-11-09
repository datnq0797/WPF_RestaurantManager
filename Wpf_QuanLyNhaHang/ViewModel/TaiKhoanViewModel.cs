using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using Wpf_QuanLyNhaHang.Model;
using Button = System.Windows.Forms.Button;
using MessageBox = System.Windows.Forms.MessageBox;
using Wpf_QuanLyNhaHang.ViewModel.Encryption;
namespace Wpf_QuanLyNhaHang.ViewModel
{
	public class TaiKhoanViewModel:BaseViewModel
	{
		Encryp_MD5 MD5 = new Encryp_MD5();
		public ICommand SaveCommand { get; set; }
		public ICommand UpdateCommand { get; set; }
		public ICommand DeleteCommand { get; set; }
		public ICommand ImageCommand { get; set; }
		public ICommand TextChangedCommand { get; set; }

		private ObservableCollection<TAIKHOAN> _listTaiKhoan;
		public ObservableCollection<TAIKHOAN> listTaiKhoan
		{
			get
			{
				return _listTaiKhoan;
			}
			set
			{
				_listTaiKhoan = value;
				OnPropertyChanged();

			}
		}

		private ObservableCollection<LOAITK> _listLoaiTaiKhoan;
		public ObservableCollection<LOAITK> listLoaiTaiKhoan
		{
			get
			{
				return _listLoaiTaiKhoan;
			}
			set
			{
				_listLoaiTaiKhoan = value;
				OnPropertyChanged();

			}
		}

		public TaiKhoanViewModel()
		{
			
			listTaiKhoan = new ObservableCollection<TAIKHOAN>(DataProvider.Ins.DB.TAIKHOANs.Where(x=>x.TRANGTHAITK != "AN"));
			listLoaiTaiKhoan = new ObservableCollection<LOAITK>(DataProvider.Ins.DB.LOAITKs);
			#region TEXT CHANGE TÌM KIẾM
			TextChangedCommand = new RelayCommand<object>((p) => { return true; },
				(p) =>
				{

					Searching(Search);


				});
			#endregion

			#region them
			SaveCommand = new RelayCommand<MATHANG>((p) =>
			{
				//---- kiểm tra các tool có bị null hay không
				if (Userr == null || Pass == null )
				{
					return false;
				}

				//---- kiểm tra trùng lập đối tượng
				var list = DataProvider.Ins.DB.TAIKHOANs.Where(x => x.USER == Userr);
				if (list == null || list.Count() != 0)
				{
					return false;
				}
				return true;
			},
			(p) => {
				try
				{
					//thêm ảnh
					File.Copy(Image, Path.Combine(@"C:\Users\DAT\source\repos\Wpf_QuanLyNhaHang\Wpf_QuanLyNhaHang\Assets\",Path.GetFileName(Image)),true);
					
					//thêm dữ liệu
					TAIKHOAN mh = new TAIKHOAN() { USER = Userr ,PASS = MD5.Encryption(Pass),MALOAITK = SelectedTaiKhoan.MALOAITK,HINHANH = Image,TRANGTHAITK = TrangThai};
					DataProvider.Ins.DB.TAIKHOANs.Add(mh);
					DataProvider.Ins.DB.SaveChanges();
					listTaiKhoan.Add(mh);
					MessageBox.Show("thêm thành công");


				}
				catch (Exception e)
				{
					MessageBox.Show(e.ToString());
				}
			});
			#endregion


			#region Edit
			UpdateCommand = new RelayCommand<TAIKHOAN>((p) =>
			{
				if (Userr == null || Pass == null )
				{
					return false;
				}

				//---- kiểm tra trùng lập đối tượng
				var listTenMH = DataProvider.Ins.DB.TAIKHOANs.Where(x => x.USER == SelectedItem.USER);
				if (listTenMH == null || listTenMH.Count() == 0)
				{
					return false;
				}

				//-----kiểm tra mật khẩu có đúng hay không

				if (MD5.Encryption(KT_Pass) != SelectedItem.PASS)
				{
					return false;
				}
				return true;
			},
			(p) => {
				try
				{
					
					//sửa ảnh
					File.Copy(Image, Path.Combine(@"C:\Users\DAT\source\repos\Wpf_QuanLyNhaHang\Wpf_QuanLyNhaHang\Assets\", Path.GetFileName(Image)), true);

					//sửa data
					var mh = DataProvider.Ins.DB.TAIKHOANs.Where(x => x.USER == SelectedItem.USER).SingleOrDefault();

					mh.USER = Userr;
					if(Pass != "")
					{
						mh.PASS = MD5.Encryption(Pass);
					}
					
					mh.MALOAITK = SelectedTaiKhoan.MALOAITK;
					mh.HINHANH = Image;
					
					DataProvider.Ins.DB.SaveChanges();
					listTaiKhoan = new ObservableCollection<TAIKHOAN>(DataProvider.Ins.DB.TAIKHOANs.Where(x => x.TRANGTHAITK != "AN"));//--load lai listview
					MessageBox.Show("sửa thành công");

				}
				catch (Exception e)
				{
					System.Windows.MessageBox.Show(e.ToString());
				}
			});
			#endregion


			#region delete
			DeleteCommand = new RelayCommand<TAIKHOAN>((p) =>
			{

				if ( SelectedItem == null)
				{
					return false;
				}

				//---- kiểm tra trùng lập đối tượng
				var listTenMH = DataProvider.Ins.DB.TAIKHOANs.Where(x => x.USER == Userr);
				if (listTenMH == null || listTenMH.Count() == 0)
				{
					return false;
				}

				//-----kiểm tra mật khẩu có đúng hay không
				
				if (MD5.Encryption(KT_Pass) != SelectedItem.PASS)
				{
					return false;
				}
				return true;

			},
			(p) => {
				try
				{	

					var mh = DataProvider.Ins.DB.TAIKHOANs.Where(x => x.USER == SelectedItem.USER).SingleOrDefault();
					mh.TRANGTHAITK = "AN";
					

					DataProvider.Ins.DB.SaveChanges();
					listTaiKhoan = new ObservableCollection<TAIKHOAN>(DataProvider.Ins.DB.TAIKHOANs.Where(x => x.TRANGTHAITK != "AN"));//--load lai listview
					MessageBox.Show("xóa thành công");

				}
				catch (Exception e)
				{
					MessageBox.Show(e.ToString());
				}
			});
			#endregion

			#region Lưu ảnh
			ImageCommand = new RelayCommand<Button>((p) =>
			{
				
				return true;
			},
			(p) => {
				
				
				try
				{
					OpenFileDialog dialog = new OpenFileDialog();
					dialog.Filter = "Image Files(*.jpg;*.jpeg;*.gif;*.bmp;)|*.jpg;*.jpeg;*.gif;*.bmp;";
					if(dialog.ShowDialog() == DialogResult.OK)
					{ 
						Image = dialog.FileName;
					}
				}catch(Exception e)
				{
					MessageBox.Show(e.ToString());
				}
			});
			#endregion
		}

		#region TÌM KIẾM
		public void Searching(string s)
		{
			int i = 0;
			if (s != "")
			{
				if (s.All(char.IsDigit)) //---nếu là số
				{
					i = int.Parse(s);
				}
				listTaiKhoan = new ObservableCollection<TAIKHOAN>(
					from tk in DataProvider.Ins.DB.TAIKHOANs
					where tk.USER.Contains(s) 
					select tk
				);
			}
			else
			{
				listTaiKhoan = new ObservableCollection<TAIKHOAN>(DataProvider.Ins.DB.TAIKHOANs);
			}
		}

		private string _Search;
		public string Search
		{
			get
			{
				return _Search;
			}
			set
			{
				_Search = value;
				OnPropertyChanged();

			}

		}
		#endregion


		private string _Image;
		public string Image
		{
			get
			{
				return _Image;
			}
			set
			{
				_Image = value;
				OnPropertyChanged();
			}
		}

		private string _Userr;
		public string Userr
		{
			get
			{
				return _Userr;
			}
			set
			{
				_Userr = value;
				OnPropertyChanged();
			}
		}




		private string _Pass;
		public string Pass
		{
			get
			{
				return _Pass;
			}
			set
			{
				_Pass = value;
				OnPropertyChanged();
			}
		}

		private int _MaTK;
		public int MaTK
		{
			get
			{
				return _MaTK;
			}
			set
			{
				_MaTK = value;
				OnPropertyChanged();
			}
		}

		private LOAITK _SelectedTaiKhoan;
		public LOAITK SelectedTaiKhoan
		{
			get
			{
				return _SelectedTaiKhoan;
			}
			set
			{
				_SelectedTaiKhoan = value;
				OnPropertyChanged();
			}
		}

		private TAIKHOAN _SelectedItem;
		public TAIKHOAN SelectedItem
		{
			get
			{
				return _SelectedItem;
			}
			set
			{
				_SelectedItem = value;
				OnPropertyChanged();
				if(SelectedItem != null)
				{			
					Userr = SelectedItem.USER;
					MaTK = SelectedItem.MATK;
					Pass = SelectedItem.PASS;
					SelectedTaiKhoan = SelectedItem.LOAITK;
					Image = SelectedItem.HINHANH;
				}
			}
		}


		private string _KT_Pass;
		public string KT_Pass
		{
			get
			{
				return _KT_Pass;
			}
			set
			{
				_KT_Pass = value;
				OnPropertyChanged();
			}
		}


		private string _TrangThai;
		public string TrangThai
		{
			get
			{
				return _TrangThai;
			}
			set
			{
				_TrangThai = value;
				OnPropertyChanged();
			}
		}
	}
}
