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
    public class Order_ViewModel:BaseViewModel
    {
		public ICommand SaveCommand { get; set; }
		public ICommand UpdateCommand { get; set; }
		public ICommand DeleteCommand { get; set; }

		private ObservableCollection<ORDER> _ListOrder;
		public ObservableCollection<ORDER> ListOrder
		{
			get
			{
				return _ListOrder;
			}
			set
			{
				_ListOrder = value;
				OnPropertyChanged();
			}
		}

		private ObservableCollection<NHANVIEN> _ListNhanVien;
		public ObservableCollection<NHANVIEN> ListNhanVien
		{
			get
			{
				return _ListNhanVien;
			}
			set
			{
				_ListNhanVien = value;
				OnPropertyChanged();
			}
		}

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

		public Order_ViewModel()
		{
			ListOrder = new ObservableCollection<ORDER>(DataProvider.Ins.DB.ORDERs);
			ListKhachHang = new ObservableCollection<KHACHHANG>(DataProvider.Ins.DB.KHACHHANGs);
			ListNhanVien = new ObservableCollection<NHANVIEN>(DataProvider.Ins.DB.NHANVIENs);
			#region Save
			SaveCommand = new RelayCommand<ORDER>((p) =>
			{
				//---- kiểm tra các tool có bị null hay không
				if (SoTienDat == null || NgayDat == null || SoKhach == 0 || SelectedKH == null|| SelectedNV == null)
				{
					return false;
				}

				//---- kiểm tra trùng lập đối tượng
				var listTenMH = DataProvider.Ins.DB.ORDERs.Where(x => x.MAKH == SelectedKH.MAKH && x.NGAYDAT.Equals(NgayDat));
				if (listTenMH == null || listTenMH.Count() != 0)
				{
					return false;
				}
				return true;
			},
			(p) => {
				try
				{
					ORDER mh = new ORDER() { SOTIENDAT = SoTienDat , NGAYDAT = NgayDat,SOKHACH = SoKhach,MANV = SelectedNV.MANV ,MAKH = SelectedKH.MAKH ,TRANGTHAI=""};
					DataProvider.Ins.DB.ORDERs.Add(mh);
					DataProvider.Ins.DB.SaveChanges();
					ListOrder.Add(mh);
					MessageBox.Show("thêm thành công");
				}
				catch (Exception e)
				{
					MessageBox.Show(e.ToString());
				}
			});
			#endregion


			#region Update
			UpdateCommand = new RelayCommand<ORDER>((p) =>
			{
				//---- kiểm tra các tool có bị null hay không
				if (SoTienDat == null || NgayDat == null || SoKhach == null || SelectedKH == null || SelectedNV == null)
				{
					return false;
				}

				//---- kiểm tra trùng lập đối tượng
				var listTenMH = DataProvider.Ins.DB.ORDERs.Where(x => x.MAKH == SelectedKH.MAKH && x.NGAYDAT == NgayDat);
				if (listTenMH == null || listTenMH.Count() == 0)
				{
					return false;
				}
				return true;
			},
			(p) => {
				try
				{
					var list = DataProvider.Ins.DB.ORDERs.Where(x => x.MAKH == SelectedKH.MAKH && x.NGAYDAT == NgayDat && x.MANV == SelectedNV.MANV).SingleOrDefault();
					list.MANV = SelectedNV.MANV;
					list.MAKH = SelectedKH.MAKH;
					list.SOTIENDAT = SoTienDat;
					list.NGAYDAT = NgayDat;
					list.SOKHACH = SoKhach;
					DataProvider.Ins.DB.SaveChanges();
					ListOrder = new ObservableCollection<ORDER>(DataProvider.Ins.DB.ORDERs);
					MessageBox.Show("Sửa thành công");
				}
				catch (Exception e)
				{
					MessageBox.Show(e.ToString());
				}
			});
			#endregion

			#region Delete
			DeleteCommand = new RelayCommand<ORDER>((p) =>
			{
				//---- kiểm tra các tool có bị null hay không
				if (SoTienDat == null || NgayDat == null || SoKhach == null || SelectedKH == null || SelectedNV == null)
				{
					return false;
				}

				//---- kiểm tra trùng lập đối tượng
				var listTenMH = DataProvider.Ins.DB.ORDERs.Where(x => x.MAKH == SelectedKH.MAKH && x.NGAYDAT == NgayDat && x.MANV == SelectedNV.MANV);
				if (listTenMH == null || listTenMH.Count() == 0)
				{
					return false;
				}
				return true;
			},
			(p) => {
				try
				{
					//tìm order bảng order
					var list = DataProvider.Ins.DB.ORDERs.Where(x=>x.MAOD == MaOD).SingleOrDefault();
					//tìm order bảng chitietorder
					var listCT = DataProvider.Ins.DB.CHITIETORDERs.Where(x=>x.MAOD == MaOD);
					//tìm order bảng bill
					var listBill = DataProvider.Ins.DB.BILLs.Where(x => x.MAOD == MaOD);

					if (listBill.Count() !=0 || listCT.Count() != 0)
					{
						foreach(var item in listCT)
						{
							DataProvider.Ins.DB.CHITIETORDERs.Remove(item);
						}

						foreach (var item in listBill)
						{
							DataProvider.Ins.DB.BILLs.Remove(item);
						}
						
					}
					DataProvider.Ins.DB.ORDERs.Remove(list);
					DataProvider.Ins.DB.SaveChanges();
					ListOrder = new ObservableCollection<ORDER>(DataProvider.Ins.DB.ORDERs);
					MessageBox.Show("Xóa thành công");
				}
				catch (Exception e)
				{
					MessageBox.Show(e.ToString());
				}
			});
			#endregion
		}

		private NHANVIEN _SelectedNV;
		public NHANVIEN SelectedNV
		{
			get
			{
				return _SelectedNV;
			}

			set
			{
				_SelectedNV = value;
				OnPropertyChanged();
			}
		}

		private KHACHHANG _SelectedKH;
		public KHACHHANG SelectedKH
		{
			get
			{
				return _SelectedKH;
			}

			set
			{
				_SelectedKH = value;
				OnPropertyChanged();
			}
		}

		private double _SoTienDat;
		public double SoTienDat
		{
			get
			{
				return _SoTienDat;
			}

			set
			{
				_SoTienDat = value;
				OnPropertyChanged();
			}
		}

		private DateTime _NgayDat;
		public DateTime NgayDat
		{
			get
			{
				return _NgayDat;
			}

			set
			{
				_NgayDat = value;
				OnPropertyChanged();
			}
		}

		private int _SoKhach;
		public int SoKhach
		{
			get
			{
				return _SoKhach;
			}

			set
			{
				_SoKhach = value;
				OnPropertyChanged();
			}
		}

		private int _MaOD;
		public int MaOD
		{
			get
			{
				return _MaOD;
			}

			set
			{
				_MaOD = value;
				OnPropertyChanged();
			}
		}

		private ORDER _SelectedItem;
		public ORDER SelectedItem
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
					try
					{
						SoTienDat = double.Parse(SelectedItem.SOTIENDAT.ToString());
					}
					catch(Exception e)
					{
						MessageBox.Show(e.ToString());
					}

					NgayDat = DateTime.Parse(SelectedItem.NGAYDAT.ToString());
					SoKhach = int.Parse(SelectedItem.SOKHACH.ToString());
					SelectedKH = SelectedItem.KHACHHANG;
					SelectedNV = SelectedItem.NHANVIEN;
				}

			}

		}
	}
}
