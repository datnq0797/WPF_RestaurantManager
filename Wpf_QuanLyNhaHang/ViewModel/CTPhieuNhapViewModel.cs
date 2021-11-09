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
	public class CTPhieuNhapViewModel :BaseViewModel
	{
		public ICommand SaveCommand { get; set; }
		public ICommand UpdateCommand { get; set; }
		public ICommand DeleteCommand { get; set; }

		private ObservableCollection<CTPHIEUNHAP> _ListCTPN;
		public ObservableCollection<CTPHIEUNHAP> ListCTPN
		{
			get
			{
				return _ListCTPN;
			}
			set
			{
				_ListCTPN = value;
				OnPropertyChanged();

			}

		}

		private ObservableCollection<MATHANG> _ListMH;
		public ObservableCollection<MATHANG> ListMH
		{
			get
			{
				return _ListMH;
			}
			set
			{
				_ListMH= value;
				OnPropertyChanged();

			}

		}

		public CTPhieuNhapViewModel()
		{
			ListCTPN = new ObservableCollection<CTPHIEUNHAP>(DataProvider.Ins.DB.CTPHIEUNHAPs);
			ListMH = new ObservableCollection<MATHANG>(DataProvider.Ins.DB.MATHANGs);

			#region them
			SaveCommand = new RelayCommand<CTPHIEUNHAP>((p) =>
			{
				//---- kiểm tra các tool có bị null hay không
				if (MaPN == null || MaMH == null || SLNhap == null)
				{
					return false;
				}

				//---- kiểm tra trùng lập đối tượng
				var list = DataProvider.Ins.DB.CTPHIEUNHAPs.Where(x => x.MAPN == MaPN &&  x.MAMH == MaMH);
				if (list == null || list.Count() != 0)
				{
					return false;
				}
				return true;
			},
			(p) => {
				try
				{
					CTPHIEUNHAP pn = new CTPHIEUNHAP() { MAMH = SelectedMatHang.MAMH, MAPN = MaPN, SLNHAP = SLNhap};
					DataProvider.Ins.DB.CTPHIEUNHAPs.Add(pn);
					DataProvider.Ins.DB.SaveChanges();
					ListCTPN.Add(pn);
					MessageBox.Show("thêm thành công");
				}
				catch (Exception e)
				{
					MessageBox.Show(e.ToString());
				}
			});
			#endregion


			#region Edit
			UpdateCommand = new RelayCommand<MATHANG>((p) =>
			{
				if (MaPN == null || MaMH == null || SLNhap == null)
				{
					return false;
				}

				//---- kiểm tra trùng lập đối tượng
				var listTenMH = DataProvider.Ins.DB.CTPHIEUNHAPs.Where(x => x.MAPN == MaPN && x.MAMH == MaMH);
				if (listTenMH == null || listTenMH.Count() != 0)
				{
					return false;
				}
				return true;
			},
			(p) => {
				try
				{
					var mh = DataProvider.Ins.DB.CTPHIEUNHAPs.Where(x => x.MAMH == SelectedItem.MAMH && 
					x.MAPN == SelectedItem.MAPN).SingleOrDefault();
					mh.MAPN = MaPN;
					mh.MAMH = MaMH;
					mh.SLNHAP = SLNhap;
					DataProvider.Ins.DB.SaveChanges();
					ListCTPN = new ObservableCollection<CTPHIEUNHAP>(DataProvider.Ins.DB.CTPHIEUNHAPs);//--load lai listview
					MessageBox.Show("sửa thành công");

				}
				catch (Exception e)
				{
					MessageBox.Show(e.ToString());
				}
			});
			#endregion


			#region delete
			DeleteCommand = new RelayCommand<MATHANG>((p) =>
			{
				if (MaPN == null || MaMH == null || SLNhap == null)
				{
					return false;
				}

				//---- kiểm tra trùng lập đối tượng
				var listTenMH = DataProvider.Ins.DB.CTPHIEUNHAPs.Where(x => x.MAPN == MaPN && x.MAMH == MaMH);
				if (listTenMH == null || listTenMH.Count() == 0)
				{
					return false;
				}
				return true;
			},
			(p) => {
				try
				{

					var mh2 = DataProvider.Ins.DB.CTPHIEUNHAPs.Where(x => x.MAMH == SelectedItem.MAMH && x.MAPN == SelectedItem.MAPN).SingleOrDefault();
					
					if (mh2 != null)
					{

						DataProvider.Ins.DB.CTPHIEUNHAPs.Remove(mh2);
					}
					

					DataProvider.Ins.DB.SaveChanges();
					ListCTPN = new ObservableCollection<CTPHIEUNHAP>(DataProvider.Ins.DB.CTPHIEUNHAPs);//--load lai listview
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

		private int _MaMH;
		public int MaMH
		{
			get
			{
				return _MaMH;
			}
			set
			{
				_MaMH = value;
				OnPropertyChanged();

			}

		}


		private int _SLNhap;
		public int SLNhap
		{
			get
			{
				return _SLNhap;
			}
			set
			{
				_SLNhap = value;
				OnPropertyChanged();

			}

		}

		private CTPHIEUNHAP _SelectedItem;
		public CTPHIEUNHAP SelectedItem
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
					MaMH = SelectedItem.MAMH;
					SLNhap = SelectedItem.SLNHAP;
					SelectedMatHang = SelectedItem.MATHANG;
				}

			}

		}

		private MATHANG _SelectedMatHang;
		public MATHANG SelectedMatHang
		{
			get
			{
				return _SelectedMatHang;
			}
			set
			{
				_SelectedMatHang = value;
				OnPropertyChanged();

			}

		}
	}
}
