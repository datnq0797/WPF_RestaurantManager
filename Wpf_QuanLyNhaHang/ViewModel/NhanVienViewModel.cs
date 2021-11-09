using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using Wpf_QuanLyNhaHang.Model;
using MessageBox = System.Windows.MessageBox;

namespace Wpf_QuanLyNhaHang.ViewModel
{
	public class NhanVienViewModel : BaseViewModel
	{
		public ICommand SaveCommand { get; set; }
		public ICommand UpdateCommand { get; set; }
		public ICommand DeleteCommand { get; set; }
		public ICommand ImageCommand { get; set; }
		public ICommand TextChangedCommand { get; set; }
		
		//--trả về list nhân viên
		private ObservableCollection<NHANVIEN> _listNHANVIEN;
		public ObservableCollection<NHANVIEN> listNHANVIEN
		{
			get
			{
				return _listNHANVIEN;
			}
			set
			{
				_listNHANVIEN = value;
				OnPropertyChanged();

			}


		}

		//--trả về list chức vụ
		private ObservableCollection<CHUCVU> _listChucVu;
		public ObservableCollection<CHUCVU> listChucVu
		{
			get
			{
				return _listChucVu;
			}
			set
			{
				_listChucVu = value;
				OnPropertyChanged();
			}
		}

		//--trả về list tài khoản
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



		public NhanVienViewModel()
		{
			
			

			listNHANVIEN = new ObservableCollection<NHANVIEN>(DataProvider.Ins.DB.NHANVIENs.Where(x=> x.TRANGTHAI != "AN"));
			listChucVu = new ObservableCollection<CHUCVU>(DataProvider.Ins.DB.CHUCVUs);
			listTaiKhoan = new ObservableCollection<TAIKHOAN>(DataProvider.Ins.DB.TAIKHOANs);


			#region TEXT CHANGE TÌM KIẾM
			TextChangedCommand = new RelayCommand<object>((p) => { return true; },
				(p) =>
				{

					Searching(Search);


				});
			#endregion

			#region them
			SaveCommand = new RelayCommand<NHANVIEN>((p) =>
			{
				//----kiểm tra các tool có bị null hay không
				if (TenNV == null || SelectedChucVu == null || NgaySinh == null || QueQuan == null || CMND == null || SDT == null
				|| GioiTinh !=1 && GioiTinh !=0
				|| TTGD == null || Luong == null ||  SelectedTaiKhoan == null)
				{
					return false;
				}


				//----kiểm tra trùng lập đối tượng
			   var listNV = DataProvider.Ins.DB.NHANVIENs.Where(x => x.TENNV == TenNV
			   && x.NGAYSINH == NgaySinh || x.CMND == CMND);

				if (listNV == null || listNV.Count() != 0)
				{
					return false;
				}

				return true;
				
				
			},
			(p) =>
			{
				try
				{
					NHANVIEN nv = new NHANVIEN() {TENNV =TenNV , MATK = SelectedTaiKhoan.MATK , MACV = SelectedChucVu.MACV
					,NGAYSINH = NgaySinh,QUEQUAN = QueQuan,CMND =CMND,GIOITINH = GioiTinh,TTGD =TTGD,SDT =SDT,
						LUONGCANBAN = Luong,HINH_ANH=Image};
					DataProvider.Ins.DB.NHANVIENs.Add(nv);
					DataProvider.Ins.DB.SaveChanges();
					listNHANVIEN.Add(nv);
					MessageBox.Show("thêm thành công");
				}
				catch (Exception e)
				{
					MessageBox.Show(e.ToString());
				}
			});
			#endregion


			#region Edit
			UpdateCommand = new RelayCommand<NHANVIEN>((p) =>
			{
				if (TenNV == null || SelectedChucVu == null || NgaySinh == null || QueQuan == null || CMND == null || SDT == null
				|| GioiTinh != 0 && GioiTinh != 1
				|| TTGD == null || Luong == null || Luong < 0 || SelectedTaiKhoan == null)
				{
					return false;
				}

				//---- kiểm tra trùng lập đối tượng
				var listNV = DataProvider.Ins.DB.NHANVIENs.Where(x => x.TENNV == TenNV
				&& x.NGAYSINH == NgaySinh || x.CMND == CMND);
				if (listNV == null || listNV.Count() == 0)
				{
					return false;
				}
				return true;
			},
			(p) =>
			{
				try
				{
					var nv = DataProvider.Ins.DB.NHANVIENs.Where(x => x.MANV == SelectedItem.MANV).SingleOrDefault();
					nv.TENNV= TenNV;
					nv.CHUCVU = SelectedChucVu;
					nv.TAIKHOAN = SelectedTaiKhoan;
					nv.NGAYSINH = NgaySinh;
					nv.QUEQUAN = QueQuan;
					nv.CMND = CMND;
					nv.GIOITINH = GioiTinh;
					nv.TTGD = TTGD;
					nv.SDT = SDT;
					nv.LUONGCANBAN = Luong;
					nv.HINH_ANH = Image;
					DataProvider.Ins.DB.SaveChanges();
					listNHANVIEN = new ObservableCollection<NHANVIEN>(DataProvider.Ins.DB.NHANVIENs.Where(x => x.TRANGTHAI != "AN"));//--load lai listview
					MessageBox.Show("sửa thành công");

				}
				catch (Exception e)
				{
					MessageBox.Show(e.ToString());
				}
			});
			#endregion


			#region delete
			DeleteCommand = new RelayCommand<NHANVIEN>((p) =>
			{
				if (TenNV == null || SelectedChucVu == null || NgaySinh == null||QueQuan == null || CMND == null || SDT == null
				|| GioiTinh != 0 && GioiTinh != 1
				|| TTGD == null || Luong == null || Luong <0 || SelectedTaiKhoan == null)
				{
					return false;
				}

				//---- kiểm tra trùng lập đối tượng
				var listNV = DataProvider.Ins.DB.NHANVIENs.Where(x => x.TENNV == TenNV
				&& x.NGAYSINH == NgaySinh || x.CMND == CMND);
				if (listNV == null || listNV.Count() == 0)
				{
					return false;
				}
				return true;
			},
			(p) =>
			{
				try
				{

					var nv = DataProvider.Ins.DB.NHANVIENs.Where(x => x.MANV == SelectedItem.MANV).SingleOrDefault();
					nv.TRANGTHAI = "NGHI";
					DataProvider.Ins.DB.SaveChanges();
					listNHANVIEN = new ObservableCollection<NHANVIEN>(DataProvider.Ins.DB.NHANVIENs.Where(x => x.TRANGTHAI != "AN"));//--load lai listview
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
					if (dialog.ShowDialog() == DialogResult.OK)
					{
						Image = dialog.FileName;
					}
				}
				catch (Exception e)
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
				listNHANVIEN = new ObservableCollection<NHANVIEN>(
					from nv in DataProvider.Ins.DB.NHANVIENs
					where nv.TENNV.Contains(s) || nv.MANV == i || nv.CMND.Equals(s)
					select nv
				);
			}
			else
			{
				listNHANVIEN = new ObservableCollection<NHANVIEN>(DataProvider.Ins.DB.NHANVIENs);
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

		private string _TenNV;
		public string TenNV
		{
			get
			{
				return _TenNV;
			}
			set
			{
				_TenNV = value;
				OnPropertyChanged();

			}

		}

		private CHUCVU _SelectedChucVu;
		public CHUCVU SelectedChucVu
		{
			get
			{
				return _SelectedChucVu;
			}
			set
			{
				_SelectedChucVu = value;
				OnPropertyChanged();

			}

		}


		private TAIKHOAN _SelectedTaiKhoan;
		public TAIKHOAN SelectedTaiKhoan
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

		private DateTime _NgaySinh;
		public DateTime NgaySinh
		{
			get
			{
				return _NgaySinh;
			}
			set
			{
				_NgaySinh = value;
				OnPropertyChanged();

			}

		}

		private double _Luong;
		public double Luong
		{
			get
			{
				return _Luong;
			}
			set
			{
				_Luong = value;
				OnPropertyChanged();

			}

		}

		private int _MaNV;
		public int MaNV
		{
			get
			{
				return _MaNV;
			}
			set
			{
				_MaNV = value;
				OnPropertyChanged();

			}

		}

		private int _MaCV;
		public int MaCV
		{
			get
			{
				return _MaCV;
			}
			set
			{
				_MaCV = value;
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

		private string _QueQuan;
		public string QueQuan
		{
			get
			{
				return _QueQuan;
			}
			set
			{
				_QueQuan = value;
				OnPropertyChanged();

			}

		}

		private string _CMND;
		public string CMND
		{
			get
			{
				return _CMND;
			}
			set
			{
				_CMND = value;
				OnPropertyChanged();

			}

		}

		private int _GioiTinh;
		public int GioiTinh
		{
			get
			{
				return _GioiTinh;
			}
			set
			{
				_GioiTinh = value;
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

		private string _TTGD;
		public string TTGD
		{
			get
			{
				return _TTGD;
			}
			set
			{
				_TTGD = value;
				OnPropertyChanged();

			}

		}

		private string _SDT;
		public string SDT
		{
			get
			{
				return _SDT;
			}
			set
			{
				_SDT = value;
				OnPropertyChanged();

			}

		}

		private NHANVIEN _SelectedItem;
		public NHANVIEN SelectedItem
		{
			get
			{
				return _SelectedItem;
			}
			set
			{
				_SelectedItem = value;
				OnPropertyChanged();
				if (SelectedItem != null)
				{
					MaNV = SelectedItem.MANV;
					TenNV = SelectedItem.TENNV;
					SelectedChucVu = SelectedItem.CHUCVU;
					SelectedTaiKhoan = SelectedItem.TAIKHOAN;
					NgaySinh = SelectedItem.NGAYSINH;
					QueQuan = SelectedItem.QUEQUAN;
					CMND = SelectedItem.CMND;
					GioiTinh = SelectedItem.GIOITINH;
					TTGD = SelectedItem.TTGD;
					SDT = SelectedItem.SDT;
					Luong = double.Parse(SelectedItem.LUONGCANBAN.ToString());
					TrangThai = SelectedItem.TRANGTHAI;
					Image = SelectedItem.HINH_ANH;
				}

			}

		}
	}
}
