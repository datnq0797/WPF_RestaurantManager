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
    public class CTOrder_ViewModel : BaseViewModel
    {
		public ICommand SaveCommand { get; set; }
		public ICommand UpdateCommand { get; set; }
		public ICommand DeleteCommand { get; set; }
		public ICommand TextChangedCommand { get; set; }
		public ICommand SelectionChanged { get; set; }
		private ObservableCollection<CHITIETORDER> _ListOrder;
		public ObservableCollection<CHITIETORDER> ListOrder
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

		private ObservableCollection<ORDER> _ListOrder_KH;
		public ObservableCollection<ORDER> ListOrder_KH
		{
			get
			{
				return _ListOrder_KH;
			}
			set
			{
				_ListOrder_KH = value;
				OnPropertyChanged();
			}
		}

		private ObservableCollection<MENU> _ListMenu;
		public ObservableCollection<MENU> ListMenu
		{
			get
			{
				return _ListMenu;
			}
			set
			{
				_ListMenu = value;
				OnPropertyChanged();
			}
		}

		public CTOrder_ViewModel()
		{
			
				
				ListOrder = new ObservableCollection<CHITIETORDER>(DataProvider.Ins.DB.CHITIETORDERs);
				ListMenu = new ObservableCollection<MENU>(DataProvider.Ins.DB.MENUs.Where(x => x.TRANGTHAI != "AN"));
				ListOrder_KH = new ObservableCollection<ORDER>(DataProvider.Ins.DB.ORDERs);


				#region TEXT CHANGE TÌM KIẾM
				TextChangedCommand = new RelayCommand<object>((p) => { return true; },
					(p) =>
					{

						Searching(Search);


					});
				#endregion

				SaveCommand = new RelayCommand<CHITIETORDER>((p) =>
				{
					if (SelectedOD == null || SelectedMN == null || Soluong == null)
						return false;

					var list = DataProvider.Ins.DB.CHITIETORDERs.Where(x => x.MAOD == SelectedOD.MAOD && x.MAMONAN == SelectedMN.MAMONAN);
					if (list == null || list.Count() != 0)
					{
						return false;
					}
					return true;
				}, (p) => {

					CHITIETORDER ct = new CHITIETORDER() { MAMONAN = SelectedMN.MAMONAN, MAOD = SelectedOD.MAOD, SOLUONG = Soluong };
					DataProvider.Ins.DB.CHITIETORDERs.Add(ct);
					ListOrder.Add(ct);
					DataProvider.Ins.DB.SaveChanges();
					MessageBox.Show("Đã thêm");
				});

				UpdateCommand = new RelayCommand<CHITIETORDER>((p) => {
					if (SelectedOD == null || SelectedMN == null || Soluong == null)
						return false;

					var list = DataProvider.Ins.DB.CHITIETORDERs.Where(x => x.MAOD == SelectedOD.MAOD && x.MAMONAN == SelectedItem.MAMONAN);
					if (list == null || list.Count() != 0)
						return false;
					return true;


				}, (p) => {

					var list = DataProvider.Ins.DB.CHITIETORDERs.Where(x => x.MAOD == SelectedOD.MAOD && x.MAMONAN == SelectedItem.MAMONAN).SingleOrDefault();
					list.MAMONAN = SelectedMN.MAMONAN;
					list.MAOD = SelectedOD.MAOD;
					list.SOLUONG = Soluong;
					DataProvider.Ins.DB.SaveChanges();
					ListOrder = new ObservableCollection<CHITIETORDER>(DataProvider.Ins.DB.CHITIETORDERs);
					MessageBox.Show("Đã cập nhật");
				});

				DeleteCommand = new RelayCommand<CHITIETORDER>((p) => {
					if (SelectedOD == null || SelectedMN == null || Soluong == null)
						return false;

					var list = DataProvider.Ins.DB.CHITIETORDERs.Where(x => x.MAOD == SelectedOD.MAOD && x.MAMONAN == SelectedItem.MAMONAN);
					if (list == null || list.Count() == 0)
						return false;
					return true;

				},
				(p) => {

					var list = DataProvider.Ins.DB.CHITIETORDERs.Where(x => x.MAOD == SelectedOD.MAOD && x.MAMONAN == SelectedItem.MAMONAN).SingleOrDefault();
					DataProvider.Ins.DB.CHITIETORDERs.Remove(list);
					DataProvider.Ins.DB.SaveChanges();
					ListOrder = new ObservableCollection<CHITIETORDER>(DataProvider.Ins.DB.CHITIETORDERs);
					MessageBox.Show("Đã xóa");
				});

			SelectionChanged = new RelayCommand<object>((p) => { return true; }, (p) =>
			{
				ListOrder = new ObservableCollection<CHITIETORDER>(
						from ct in DataProvider.Ins.DB.CHITIETORDERs	
						where ct.MAOD == SelectedOD.MAOD				
						select ct
						);

			});



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
				ListOrder = new ObservableCollection<CHITIETORDER>(
					from od in DataProvider.Ins.DB.CHITIETORDERs
					join mn in DataProvider.Ins.DB.MENUs on od.MAMONAN equals mn.MAMONAN
					where mn.TENMONAN.Contains(s) || od.SOLUONG == i || od.MAOD == i
					select od
				);
			}
			else
			{
				ListOrder = new ObservableCollection<CHITIETORDER>(DataProvider.Ins.DB.CHITIETORDERs);
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

		private MENU _SelectedMN;
		public MENU SelectedMN
		{
			get
			{
				return _SelectedMN;
			}
			set
			{
				_SelectedMN = value;
				OnPropertyChanged();
			}
		}

		private ORDER _SelectedOD;
		public ORDER SelectedOD
		{
			get
			{
				return _SelectedOD;
			}
			set
			{
				_SelectedOD = value;
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



		private CHITIETORDER _SelectedItem;
		public CHITIETORDER SelectedItem
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

					SelectedOD = SelectedItem.ORDER; 
					Soluong = int.Parse(SelectedItem.SOLUONG.ToString());
					SelectedMN = SelectedItem.MENU;
				}

			}

		}
	}
}
