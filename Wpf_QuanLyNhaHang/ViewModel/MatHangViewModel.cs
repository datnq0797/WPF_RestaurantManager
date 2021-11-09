using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Wpf_QuanLyNhaHang.Model;
namespace Wpf_QuanLyNhaHang.ViewModel
{
	public class MatHangViewModel : BaseViewModel
	{
		public ICommand SaveCommand { get; set; }
		public ICommand UpdateCommand { get; set; }
		public ICommand DeleteCommand { get; set; }
		public ICommand TextChangedCommand { get; set; }
		//--trả về list mặt hàng
		private ObservableCollection<MATHANG> _listMatHang;
		public ObservableCollection<MATHANG> listMatHang
		{
			get
			{
				return _listMatHang;
			}
			set
			{
				_listMatHang = value;
				OnPropertyChanged();

			}


		}

		//--trả về list loại mặt hàng
		private ObservableCollection<LOAIMH> _listLoaiMH;
		public ObservableCollection<LOAIMH> listLoaiMH
		{
			get
			{
				return _listLoaiMH;
			}
			set
			{
				_listLoaiMH = value;
				OnPropertyChanged();
			}
		}

		public MatHangViewModel()
		{
			listMatHang = new ObservableCollection<MATHANG>(DataProvider.Ins.DB.MATHANGs);
			listLoaiMH = new ObservableCollection<LOAIMH>(DataProvider.Ins.DB.LOAIMHs);

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
				if (TenMH == null || SelectedLoaiMH == null || Soluong == null || Gia == null || DVT == null
				)
				{
					return false;
				}

				//---- kiểm tra trùng lập đối tượng
				var listTenMH = DataProvider.Ins.DB.MATHANGs.Where(x => x.TENMH == TenMH);
				if (listTenMH == null || listTenMH.Count() != 0)
				{
					return false;
				}
				return true;
			},
			(p) =>
			{
				try
				{


					MATHANG mh = new MATHANG() { TENMH = TenMH, MALOAIMH = SelectedLoaiMH.MALOAIMH, SOLUONG = Soluong, HANSUDUNG = HSD, GIA = Gia, DVT = DVT };
					DataProvider.Ins.DB.MATHANGs.Add(mh);
					DataProvider.Ins.DB.SaveChanges();
					listMatHang.Add(mh);
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
				if (TenMH == null || SelectedLoaiMH == null || Soluong == null  || Gia == null || DVT == null
				|| SelectedItem == null)
				{
					return false;
				}

				//---- kiểm tra trùng lập đối tượng
				var listTenMH = DataProvider.Ins.DB.MATHANGs.Where(x => x.TENMH == TenMH);
				if (listTenMH == null || listTenMH.Count() == 0)
				{
					return false;
				}
				return true;
			},
			(p) => {
				try
				{
					var mh = DataProvider.Ins.DB.MATHANGs.Where(x => x.MAMH == SelectedItem.MAMH).SingleOrDefault();
					mh.TENMH = TenMH;
					mh.LOAIMH = SelectedLoaiMH;
					mh.SOLUONG = Soluong;
					mh.GIA = Gia;
					mh.HANSUDUNG = HSD;
					mh.DVT = DVT;

					DataProvider.Ins.DB.SaveChanges();
					listMatHang = new ObservableCollection<MATHANG>(DataProvider.Ins.DB.MATHANGs);//--load lai listview
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
				if (TenMH == null || SelectedLoaiMH == null || Soluong == null || HSD == null || Gia == null || DVT == null
				|| SelectedItem == null)
				{
					return false;
				}

				//---- kiểm tra trùng lập đối tượng
				var listTenMH = DataProvider.Ins.DB.MATHANGs.Where(x => x.TENMH == TenMH);
				if (listTenMH == null || listTenMH.Count() == 0)
				{
					return false;
				}
				return true;
			},
			(p) => {
				try
				{
					
					var mh2 = DataProvider.Ins.DB.CTPHIEUNHAPs.Where(x => x.MAMH == SelectedItem.MAMH).ToList();
					var mh = DataProvider.Ins.DB.MATHANGs.Where(x => x.MAMH == SelectedItem.MAMH).SingleOrDefault();
					if (mh2 == null)
					{
								
						DataProvider.Ins.DB.MATHANGs.Remove(mh);
					}
					else
					{
						foreach(var item in mh2)
						{
							DataProvider.Ins.DB.CTPHIEUNHAPs.Remove(item);
						}
						
						DataProvider.Ins.DB.MATHANGs.Remove(mh);
					}

					DataProvider.Ins.DB.SaveChanges();
					listMatHang = new ObservableCollection<MATHANG>(DataProvider.Ins.DB.MATHANGs);//--load lai listview
					MessageBox.Show("xóa thành công");

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
			int i=0;
			if (s != "")
			{
				if(s.All(char.IsDigit) ) //---nếu là số
				{
					i = int.Parse(s);
				}
				listMatHang = new ObservableCollection<MATHANG>(
					from mh in DataProvider.Ins.DB.MATHANGs
					where mh.TENMH.Contains(s) || (mh.SOLUONG == i) || (mh.GIA == i) 
					select mh
				);
			}
			else
			{
				listMatHang = new ObservableCollection<MATHANG>(DataProvider.Ins.DB.MATHANGs);
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

		private string _TenMH;
		public string TenMH
		{
			get
			{
				return _TenMH;
			}
			set
			{
				_TenMH = value;
				OnPropertyChanged();
				
			}

		}

		private LOAIMH _SelectedLoaiMH;
		public LOAIMH SelectedLoaiMH
		{
			get
			{
				return _SelectedLoaiMH;
			}
			set
			{
				_SelectedLoaiMH = value;
				OnPropertyChanged();

			}

		}


		private int _Soluong;
		public int Soluong
		{
			get
			{
				return _Soluong;
			}
			set
			{
				_Soluong = value;
				OnPropertyChanged();

			}

		}

		private DateTime _HSD;
		public DateTime HSD
		{
			get
			{
				return _HSD;
			}
			set
			{
				_HSD = value;
				OnPropertyChanged();

			}

		}

		private double _Gia;
		public double Gia
		{
			get
			{
				return _Gia;
			}
			set
			{
				_Gia = value;
				OnPropertyChanged();

			}

		}

		private string _DVT;
		public string DVT
		{
			get
			{
				return _DVT;
			}
			set
			{
				_DVT = value;
				OnPropertyChanged();

			}
		}

		private int _MAMH;
		public int MAMH
		{
			get
			{
				return _MAMH;
			}
			set
			{
				_MAMH = value;
				OnPropertyChanged();

			}
		}

		private MATHANG _SelectedItem;
		public MATHANG SelectedItem
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
					MAMH = SelectedItem.MAMH;
					TenMH = SelectedItem.TENMH;
					SelectedLoaiMH = SelectedItem.LOAIMH;
					Soluong = SelectedItem.SOLUONG;
					HSD = SelectedItem.HANSUDUNG;
					Gia = SelectedItem.GIA;
					DVT = SelectedItem.DVT;
				}

			}

		}

		
	}
}
