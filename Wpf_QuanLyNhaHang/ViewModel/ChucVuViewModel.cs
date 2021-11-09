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
	public class ChucVuViewModel:BaseViewModel
	{
		public ICommand SaveCommand { get; set; }
		public ICommand UpdateCommand { get; set; }
		public ICommand DeleteCommand { get; set; }
		public ICommand TextChangedCommand { get; set; }

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


		public ChucVuViewModel()
		{
			listChucVu = new ObservableCollection<CHUCVU>(DataProvider.Ins.DB.CHUCVUs.Where(x=>x.TRANGTHAI != "AN"));

			#region TEXT CHANGE TÌM KIẾM
			TextChangedCommand = new RelayCommand<object>((p) => { return true; },
				(p) =>
				{

					Searching(Search);


				});
			#endregion

			#region them
			SaveCommand = new RelayCommand<CHUCVU>((p) =>
			{
				//---- kiểm tra các tool có bị null hay không
				if (TenCV == null || PhuCap == null)
				{
					return false;
				}

				//---- kiểm tra trùng lập đối tượng
				var listTenMH = DataProvider.Ins.DB.CHUCVUs.Where(x => x.TENCV == TenCV);
				if (listTenMH == null || listTenMH.Count() != 0)
				{
					return false;
				}
				return true;
			},
			(p) => {
				try
				{
					CHUCVU mh = new CHUCVU() { TENCV = TenCV,PHUCAP = PhuCap};
					DataProvider.Ins.DB.CHUCVUs.Add(mh);
					DataProvider.Ins.DB.SaveChanges();
					listChucVu.Add(mh);
					MessageBox.Show("thêm thành công");
				}
				catch (Exception e)
				{
					MessageBox.Show(e.ToString());
				}
			});
			#endregion


			#region Edit
			UpdateCommand = new RelayCommand<CHUCVU>((p) =>
			{
				if (TenCV == null || PhuCap == null)
				{
					return false;
				}

				//---- kiểm tra trùng lập đối tượng
				var listTenMH = DataProvider.Ins.DB.CHUCVUs.Where(x => x.TENCV == TenCV);
				if (listTenMH == null || listTenMH.Count() == 0)
				{
					return false;
				}
				return true;
			},
			(p) => {
				try
				{
					var mh = DataProvider.Ins.DB.CHUCVUs.Where(x => x.TENCV == SelectedItem.TENCV).SingleOrDefault();
					mh.PHUCAP = PhuCap;
					mh.TENCV = TenCV;

					DataProvider.Ins.DB.SaveChanges();
					listChucVu = new ObservableCollection<CHUCVU>(DataProvider.Ins.DB.CHUCVUs.Where(x => x.TRANGTHAI != "AN"));//--load lai listview
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
				if (TenCV == null || PhuCap == null)
				{
					return false;
				}

				//---- kiểm tra trùng lập đối tượng
				var listTenMH = DataProvider.Ins.DB.CHUCVUs.Where(x => x.TENCV == TenCV);
				if (listTenMH == null || listTenMH.Count() == 0)
				{
					return false;
				}
				return true;
			},
			(p) => {
				try
				{
					var mh2 = DataProvider.Ins.DB.CHUCVUs.Where(x => x.TENCV == SelectedItem.TENCV).SingleOrDefault();
					mh2.TRANGTHAI = "AN";
					DataProvider.Ins.DB.SaveChanges();
					listChucVu = new ObservableCollection<CHUCVU>(DataProvider.Ins.DB.CHUCVUs.Where(x => x.TRANGTHAI != "AN"));//--load lai listview
					MessageBox.Show("xóa thành công");

				}
				catch (Exception e)
				{
					MessageBox.Show(e.ToString());
				}
			});
			#endregion

		}


		#region XỬ LÝ TÌM KIẾM
		public void Searching(string s)
		{
			int i = 0;
			
			if (s != "")
			{
				if (s.All(char.IsDigit)) //--- nếu s là số không phải chuỗi
				{
					i = int.Parse(s);

				}

				listChucVu = new ObservableCollection<CHUCVU>(
				from cv in DataProvider.Ins.DB.CHUCVUs
				where cv.TENCV.Contains(s) || cv.PHUCAP == i
				select cv

				);
			}
			else
			{
				listChucVu = new ObservableCollection<CHUCVU>(DataProvider.Ins.DB.CHUCVUs);
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

		private string _TenCV;
		public string TenCV
		{
			get
			{
				return _TenCV;
			}
			set
			{
				_TenCV = value;
				OnPropertyChanged();
			}
		}

		private double _PhuCap;
		public double PhuCap
		{
			get
			{
				return _PhuCap;
			}
			set
			{
				_PhuCap = value;
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

		private CHUCVU _SelectedItem;
		public CHUCVU SelectedItem
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
					MaCV = SelectedItem.MACV;
					TenCV = SelectedItem.TENCV;
					PhuCap = double.Parse(SelectedItem.PHUCAP.ToString());
				}
			}
		}
	}
}
