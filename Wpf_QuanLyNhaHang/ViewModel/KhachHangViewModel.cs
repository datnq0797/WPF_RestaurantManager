using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Wpf_QuanLyNhaHang.Model;
namespace Wpf_QuanLyNhaHang.ViewModel
{
    public class KhachHangViewModel:BaseViewModel
    {
		public ICommand SaveCommand { get; set; }
		public ICommand UpdateCommand { get; set; }
		public ICommand DeleteCommand { get; set; }
		public ICommand TextChangedCommand { get; set; }

		private ObservableCollection<KHACHHANG> _ListKhachHang;
		public ObservableCollection<KHACHHANG> ListKhachHang
		{
			get
			{
				return _ListKhachHang;
			}
			set
			{
				_ListKhachHang = value;
				OnPropertyChanged();
			}
		}

		private ObservableCollection<LOAIKH> _ListLoaiKH;
		public ObservableCollection<LOAIKH> ListLoaiKH
		{
			get
			{
				return _ListLoaiKH;
			}
			set
			{
				_ListLoaiKH = value;
				OnPropertyChanged();
			}
		}


		public KhachHangViewModel()
		{
			ListKhachHang = new ObservableCollection<KHACHHANG>(DataProvider.Ins.DB.KHACHHANGs.Where(x => x.TRANGTHAI != "AN"));
			ListLoaiKH = new ObservableCollection<LOAIKH>(DataProvider.Ins.DB.LOAIKHs.Where(x => x.TRANGTHAI != "AN"));
			#region TEXT CHANGE TÌM KIẾM
			TextChangedCommand = new RelayCommand<object>((p) => { return true; },
				(p) =>
				{

					Searching(Search);


				});
			#endregion


			#region  save
			SaveCommand = new RelayCommand<KHACHHANG>(
				(p) => {
					if (SelectedLoaiKH == null || TenKH == null || QueQuan == null || CMND == null || SDT == null || GioiTinh != 1 && GioiTinh != 0)
						return false;
					var list = DataProvider.Ins.DB.KHACHHANGs.Where(x => x.TENKH == TenKH && x.CMND == CMND);
					if (list == null || list.Count() != 0)
						return false;
					return true;
				},
				(p) => {
					KHACHHANG kh = new KHACHHANG() { MALOAIKH = SelectedLoaiKH.MALOAIKH, TENKH = TenKH, QUEQUAN = QueQuan, CMND = CMND, SDT = SDT, GIOITINH = GioiTinh };
					DataProvider.Ins.DB.KHACHHANGs.Add(kh);
					DataProvider.Ins.DB.SaveChanges();
					ListKhachHang.Add(kh);
					MessageBox.Show("Đã thêm");
				});
			#endregion


			#region Edit
			UpdateCommand = new RelayCommand<KHACHHANG>((p) =>
			{
				if (SelectedLoaiKH == null || TenKH == null || QueQuan == null || CMND == null || SDT == null || GioiTinh !=1 && GioiTinh !=0)
					return false;
				var list = DataProvider.Ins.DB.KHACHHANGs.Where(x => x.MAKH == SelectedItem.MAKH);
				if (list == null || list.Count() == 0)
					return false;
				return true;
			},
			(p) => {
				try

				{
					var list = DataProvider.Ins.DB.KHACHHANGs.Where(x => x.TENKH == TenKH && x.CMND == CMND).SingleOrDefault();
					list.MALOAIKH = SelectedLoaiKH.MALOAIKH;
					list.TENKH = TenKH;
					list.QUEQUAN = QueQuan;
					list.CMND = CMND;
					list.SDT = SDT;
					list.GIOITINH = GioiTinh;


					DataProvider.Ins.DB.SaveChanges();
					ListKhachHang = new ObservableCollection<KHACHHANG>(DataProvider.Ins.DB.KHACHHANGs.Where(x => x.TRANGTHAI != "AN"));
					MessageBox.Show("sửa thành công");

				}
				catch (Exception e)
				{
					MessageBox.Show(e.ToString());
				}
			});
			#endregion


			#region delete
			DeleteCommand = new RelayCommand<KHACHHANG>((p) => {
				if (SelectedLoaiKH == null || TenKH == null || QueQuan == null || CMND == null || SDT == null || GioiTinh != 1 && GioiTinh != 0)
					return false;
				var list = DataProvider.Ins.DB.KHACHHANGs.Where(x => x.TENKH == TenKH && x.CMND == CMND);
				if (list == null || list.Count() == 0)
					return false;
				return true;

			},
			(p) => {

				var list = DataProvider.Ins.DB.KHACHHANGs.Where(x => x.TENKH == TenKH && x.CMND == CMND).SingleOrDefault();
				list.TRANGTHAI = "AN";
				DataProvider.Ins.DB.SaveChanges();
				ListKhachHang = new ObservableCollection<KHACHHANG>(DataProvider.Ins.DB.KHACHHANGs.Where(x=>x.TRANGTHAI != "AN"));
				MessageBox.Show("Đã xóa");
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
				ListKhachHang = new ObservableCollection<KHACHHANG>(
					from kh in DataProvider.Ins.DB.KHACHHANGs
					join lkh in DataProvider.Ins.DB.LOAIKHs on kh.MALOAIKH equals lkh.MALOAIKH
					where kh.TENKH.Contains(s)  || kh.SDT.Contains(s) || lkh.TENLOAIKH.Contains(s) ||kh.CMND.Contains(s)
					select kh
				);
			}
			else
			{
				ListKhachHang = new ObservableCollection<KHACHHANG>(DataProvider.Ins.DB.KHACHHANGs);
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

		private LOAIKH  _SelectedLoaiKH ;
		public LOAIKH SelectedLoaiKH
		{
			get
			{
				return _SelectedLoaiKH;
			}
			set
			{
				_SelectedLoaiKH = value;
				OnPropertyChanged();
			}
		}

		private string _TenKH;
		public string TenKH
		{
			get
			{
				return _TenKH;
			}
			set
			{
				_TenKH = value;
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
	
	



		private KHACHHANG _SelectedItem;
		public KHACHHANG SelectedItem
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
					SelectedLoaiKH = SelectedItem.LOAIKH;
					TenKH = SelectedItem.TENKH;
					QueQuan = SelectedItem.QUEQUAN;
					CMND = SelectedItem.CMND;
					SDT = SelectedItem.SDT;
					GioiTinh = SelectedItem.GIOITINH;
					
				}
			}
		}
	}
}
