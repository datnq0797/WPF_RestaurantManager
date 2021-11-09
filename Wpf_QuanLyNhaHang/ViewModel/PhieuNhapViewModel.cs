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
	public class PhieuNhapViewModel:BaseViewModel
	{
		public ICommand SaveCommand { get; set; }
		public ICommand UpdateCommand { get; set; }
		public ICommand DeleteCommand { get; set; }

		private ObservableCollection<PHIEUNHAP> _ListPN;
		public ObservableCollection<PHIEUNHAP> ListPN
		{
			get
			{
				return _ListPN;
			}
			set
			{
				_ListPN = value;
				OnPropertyChanged();

			}

		}

		private ObservableCollection<NHANVIEN> _ListNV;
		public ObservableCollection<NHANVIEN> ListNV
		{
			get
			{
				return _ListNV;
			}
			set
			{
				_ListNV = value;
				OnPropertyChanged();

			}

		}
		
		public PhieuNhapViewModel()
		{
			ListNV = new ObservableCollection<NHANVIEN>(DataProvider.Ins.DB.NHANVIENs);
			ListPN = new ObservableCollection<PHIEUNHAP>(DataProvider.Ins.DB.PHIEUNHAPs);

			#region them
			SaveCommand = new RelayCommand<PHIEUNHAP>((p) =>
			{
				//---- kiểm tra các tool có bị null hay không
				if ( MaNV == null && NgayNhapPhieu == null)
				{
					return false;
				}

				//---- kiểm tra trùng lập đối tượng
				var list = DataProvider.Ins.DB.PHIEUNHAPs.Where(x => x.MAPN == MaPN);
				if (list == null || list.Count() != 0)
				{
					return false;
				}
				return true;
			},
			(p) => {
				try
				{

					PHIEUNHAP mh = new PHIEUNHAP() { MANV=SelectedNhanVien.MANV,NGAYNHAPPHIEU = NgayNhapPhieu};
					DataProvider.Ins.DB.PHIEUNHAPs.Add(mh);
					DataProvider.Ins.DB.SaveChanges();
					ListPN.Add(mh);
					MessageBox.Show("thêm thành công");
				}
				catch (Exception e)
				{
					MessageBox.Show(e.ToString());
				}
			});
			#endregion


			#region Edit
			UpdateCommand = new RelayCommand<PHIEUNHAP>((p) =>
			{
				if (MaPN == null && MaNV == null && NgayNhapPhieu == null)
				{
					return false;
				}

				//---- kiểm tra trùng lập đối tượng
				var listTenMH = DataProvider.Ins.DB.PHIEUNHAPs.Where(x => x.MAPN == MaPN);
				if (listTenMH == null || listTenMH.Count() != 0)
				{
					return false;
				}
				return true;
			},
			(p) => {
				try
				{
					var mh = DataProvider.Ins.DB.PHIEUNHAPs.Where(x => x.MAPN == SelectedItem.MAPN).SingleOrDefault();
					mh.MANV = MaNV;
					
					mh.NGAYNHAPPHIEU = NgayNhapPhieu;
					DataProvider.Ins.DB.SaveChanges();
					ListPN = new ObservableCollection<PHIEUNHAP>(DataProvider.Ins.DB.PHIEUNHAPs);//--load lai listview
					MessageBox.Show("sửa thành công");

				}
				catch (Exception e)
				{
					MessageBox.Show(e.ToString());
				}
			});
			#endregion


			#region delete
			DeleteCommand = new RelayCommand<PHIEUNHAP>((p) =>
			{
				if (MaPN == null && MaNV == null && NgayNhapPhieu == null)
				{
					return false;
				}

				//---- kiểm tra trùng lập đối tượng
				var list = DataProvider.Ins.DB.PHIEUNHAPs.Where(x => x.MAPN == MaPN);
				if (list == null || list.Count() == 0)
				{
					return false;
				}
				return true;
			},
			(p) => {
				try
				{

					var mh2 = DataProvider.Ins.DB.CTPHIEUNHAPs.Where(x => x.MAPN == SelectedItem.MAPN).ToList();
					var mh = DataProvider.Ins.DB.PHIEUNHAPs.Where(x => x.MAPN == SelectedItem.MAPN).SingleOrDefault();
					if (mh2 == null)
					{

						DataProvider.Ins.DB.PHIEUNHAPs.Remove(mh);
					}
					else
					{
						foreach (var item in mh2)
						{
							DataProvider.Ins.DB.CTPHIEUNHAPs.Remove(item);
						}

						DataProvider.Ins.DB.PHIEUNHAPs.Remove(mh);
					}

					DataProvider.Ins.DB.SaveChanges();
					ListPN = new ObservableCollection<PHIEUNHAP>(DataProvider.Ins.DB.PHIEUNHAPs);//--load lai listview
					MessageBox.Show("xóa thành công");

				}
				catch (Exception e)
				{
					MessageBox.Show(e.ToString());
				}
			});
			#endregion

		}

		private int _MaPN;
		public int MaPN
		{
			get
			{
				return _MaPN;
			}
			set
			{
				_MaPN = value;
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

		private DateTime _NgayNhapPhieu;
		public DateTime NgayNhapPhieu
		{
			get
			{
				return _NgayNhapPhieu;
			}
			set
			{
				_NgayNhapPhieu = value;
				OnPropertyChanged();
			}
		}

		private PHIEUNHAP _SelectedItem;
		public PHIEUNHAP SelectedItem
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
					MaPN = SelectedItem.MAPN;
					MaNV = SelectedItem.MANV;
					NgayNhapPhieu = SelectedItem.NGAYNHAPPHIEU;
				}
			}

		}

		private NHANVIEN _SelectedNhanVien;
		public NHANVIEN SelectedNhanVien
		{
			get
			{
				return _SelectedNhanVien;
			}
			set
			{
				_SelectedNhanVien = value;
				OnPropertyChanged();

			}

		}

	}
	
}
