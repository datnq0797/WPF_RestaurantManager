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
	public class KhuyenMaiViewModel : BaseViewModel
	{
		public ICommand SaveCommand { get; set; }
		public ICommand UpdateCommand { get; set; }
		public ICommand DeleteCommand { get; set; }

		private ObservableCollection<KHUYENMAI> _listKhuyenMai;
		public ObservableCollection<KHUYENMAI> listKhuyenMai
		{
			get
			{
				return _listKhuyenMai;
			}
			set
			{
				_listKhuyenMai = value;
				OnPropertyChanged();

			}
		}

		public KhuyenMaiViewModel(){
			listKhuyenMai = new ObservableCollection<KHUYENMAI>(DataProvider.Ins.DB.KHUYENMAIs.Where(x => x.TRANGTHAI != "AN"));

			#region save
			SaveCommand = new RelayCommand<KHUYENMAI>((p) =>
			{
				if(TenCT == null || ChietKhau == null || TGBatDau == null || TGKetThuc == null)
				{
					return false;
				}

				var list = DataProvider.Ins.DB.KHUYENMAIs.Where(x => x.TENCT == TenCT);
				if(list == null || list.Count() != 0)
				{
					return false;
				}
				return true;

			}, 
			(p) =>
			{
				KHUYENMAI km = new KHUYENMAI { TENCT = TenCT,CHIETKHAU = ChietKhau , TGBATDAU =TGBatDau,TGKETTHUC =TGKetThuc};
				DataProvider.Ins.DB.KHUYENMAIs.Add(km);
				DataProvider.Ins.DB.SaveChanges();
				listKhuyenMai.Add(km);
				MessageBox.Show("Thêm thành công");

			});
			#endregion

			#region Edit
			UpdateCommand = new RelayCommand<KHUYENMAI>((p) =>
			{
				if (TenCT == null || ChietKhau == null || TGBatDau == null || TGKetThuc == null)
				{
					return false;
				}

				//---- kiểm tra trùng lập đối tượng
				var listTenMH = DataProvider.Ins.DB.KHUYENMAIs.Where(x => x.TENCT == TenCT);
				if (listTenMH == null || listTenMH.Count() == 0)
				{
					return false;
				}
				return true;
			},
			(p) => {
				try
				{
					var mh = DataProvider.Ins.DB.KHUYENMAIs.Where(x => x.MAKM == SelectedItem.MAKM).SingleOrDefault();
					mh.TENCT = TenCT;
					mh.CHIETKHAU = ChietKhau;
					mh.TGBATDAU = TGBatDau;
					mh.TGKETTHUC = TGKetThuc;

					DataProvider.Ins.DB.SaveChanges();
					listKhuyenMai = new ObservableCollection<KHUYENMAI>(DataProvider.Ins.DB.KHUYENMAIs.Where(x => x.TRANGTHAI != "AN"));//--load lai listview
					MessageBox.Show("sửa thành công");

				}
				catch (Exception e)
				{
					MessageBox.Show(e.ToString());
				}
			});
			#endregion


			#region delete
			DeleteCommand = new RelayCommand<KHUYENMAI>((p) =>
			{
				if (TenCT == null || ChietKhau == null || TGBatDau == null || TGKetThuc == null)
				{
					return false;
				}

				//---- kiểm tra trùng lập đối tượng
				var listTenMH = DataProvider.Ins.DB.KHUYENMAIs.Where(x => x.TENCT == TenCT);
				if (listTenMH == null || listTenMH.Count() == 0)
				{
					return false;
				}
				return true;
			},
			(p) => {
				try
				{
					var mh2 = DataProvider.Ins.DB.KHUYENMAIs.Where(x => x.MAKM == MaKM).SingleOrDefault();
					mh2.TRANGTHAI = "AN";
					DataProvider.Ins.DB.SaveChanges();
					listKhuyenMai = new ObservableCollection<KHUYENMAI>(DataProvider.Ins.DB.KHUYENMAIs.Where(x => x.TRANGTHAI != "AN"));//--load lai listview
					MessageBox.Show("xóa thành công");

				}
				catch (Exception e)
				{
					MessageBox.Show(e.ToString());
				}
			});
			#endregion
		}

		private string _TenCT;
		public string TenCT
		{
			get
			{
				return _TenCT;
			}
			set
			{
				_TenCT = value;
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

		private int _ChietKhau;
		public int ChietKhau
		{
			get
			{
				return _ChietKhau;
			}
			set
			{
				_ChietKhau = value;
				OnPropertyChanged();
			}
		}

		private DateTime _TGBatDau;
		public DateTime TGBatDau
		{
			get
			{
				return _TGBatDau;
			}
			set
			{
				_TGBatDau = value;
				OnPropertyChanged();
			}
		}
		private DateTime _TGKetThuc;
		public DateTime TGKetThuc
		{
			get
			{
				return _TGKetThuc;
			}
			set
			{
				_TGKetThuc = value;
				OnPropertyChanged();
			}
		}

		private int _MaKM;
		public int MaKM
		{
			get
			{
				return _MaKM;
			}
			set
			{
				_MaKM = value;
				OnPropertyChanged();
			}
		}

		

		private KHUYENMAI _SelectedItem;
		public KHUYENMAI SelectedItem
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
					MaKM = SelectedItem.MAKM;
					TenCT = SelectedItem.TENCT;
					ChietKhau = SelectedItem.CHIETKHAU;
					TGBatDau = SelectedItem.TGBATDAU;
					TGKetThuc = SelectedItem.TGKETTHUC;
				}

			}

		}
	}
}
