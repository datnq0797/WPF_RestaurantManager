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
	public class LoaiMAViewModel : BaseViewModel
	{
		public ICommand SaveCommand { get; set; }
		public ICommand UpdateCommand { get; set; }
		public ICommand DeleteCommand { get; set; }

		private ObservableCollection<LOAIMONAN> _listLoaiMA;
		public ObservableCollection<LOAIMONAN> listLoaiMA
		{
			get
			{
				return _listLoaiMA;
			}
			set
			{
				_listLoaiMA = value;
				OnPropertyChanged();
			}
		}

		public LoaiMAViewModel()
		{
			listLoaiMA = new ObservableCollection<LOAIMONAN>(DataProvider.Ins.DB.LOAIMONANs.Where(x => x.TRANGTHAI != "AN"));

			SaveCommand = new RelayCommand<LOAIMONAN>(
				(p) =>
				{
					if (TenLoaiMA == null || MaLoaiMA == null)
						return false;


					var list = DataProvider.Ins.DB.LOAIMONANs.Where(x => x.TENLOAIMONAN == TenLoaiMA || x.MALOAIMONAN == MaLoaiMA);
					if (list == null || list.Count() != 0)
						return false;
					return true;
				},

				(p) =>
				{
					LOAIMONAN lma = new LOAIMONAN() { MALOAIMONAN = MaLoaiMA,TENLOAIMONAN = TenLoaiMA};
					DataProvider.Ins.DB.LOAIMONANs.Add(lma);
					DataProvider.Ins.DB.SaveChanges();
					listLoaiMA.Add(lma);
					MessageBox.Show("Thêm thành công");
				}

				);

			UpdateCommand = new RelayCommand<LOAIMONAN>(
				(p) =>
				{
					if (TenLoaiMA == null)
						return false;


					var list = DataProvider.Ins.DB.LOAIMONANs.Where(x => x.TENLOAIMONAN == TenLoaiMA || x.MALOAIMONAN == MaLoaiMA);
					if (list == null || list.Count() == 0)
						return false;
					return true;
				},

				(p) =>
				{
					var list = DataProvider.Ins.DB.LOAIMONANs.Where(x => x.MALOAIMONAN == MaLoaiMA).SingleOrDefault();
					list.TENLOAIMONAN = TenLoaiMA;
					list.MALOAIMONAN = MaLoaiMA;
					DataProvider.Ins.DB.SaveChanges();
					listLoaiMA = new ObservableCollection<LOAIMONAN>(DataProvider.Ins.DB.LOAIMONANs.Where(x => x.TRANGTHAI != "AN"));
					MessageBox.Show("Cập nhật thành công");
				}

				);

			DeleteCommand = new RelayCommand<LOAIMONAN>(
				(p) =>
				{
					if (TenLoaiMA == null)
						return false;


					var list = DataProvider.Ins.DB.LOAIMONANs.Where(x => x.TENLOAIMONAN == TenLoaiMA);
					if (list == null || list.Count() == 0)
						return false;
					return true;
				},

				(p) =>
				{
					var list = DataProvider.Ins.DB.LOAIMONANs.Where(x => x.MALOAIMONAN == MaLoaiMA).SingleOrDefault();
					list.TRANGTHAI = "AN";

					DataProvider.Ins.DB.SaveChanges();
					listLoaiMA = new ObservableCollection<LOAIMONAN>(DataProvider.Ins.DB.LOAIMONANs.Where(x => x.TRANGTHAI != "AN"));
					MessageBox.Show("Cập nhật thành công");
				}

				);

		}

		private string _MaLoaiMA;
		public string MaLoaiMA
		{
			get
			{
				return _MaLoaiMA;
			}
			set
			{
				_MaLoaiMA = value;
				OnPropertyChanged();
			}
		}

		private string _TenLoaiMA;
		public string TenLoaiMA
		{
			get
			{
				return _TenLoaiMA;
			}
			set
			{
				_TenLoaiMA = value;
				OnPropertyChanged();
			}
		}

		private LOAIMONAN _SelectedItem;
		public LOAIMONAN SelectedItem
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
					MaLoaiMA = SelectedItem.MALOAIMONAN;
					TenLoaiMA = SelectedItem.TENLOAIMONAN;
				}
			}
		}
	}
}
