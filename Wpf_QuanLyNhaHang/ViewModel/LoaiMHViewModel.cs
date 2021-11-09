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
	public class LoaiMHViewModel : BaseViewModel
	{
		public ICommand SaveCommand { get; set; }
		public ICommand UpdateCommand { get; set; }
		public ICommand DeleteCommand { get; set; }

		private ObservableCollection<LOAIMH> _ListLoaiMH;
		public ObservableCollection<LOAIMH> ListLoaiMH
		{
			get
			{
				return _ListLoaiMH;
			}
			set
			{
				_ListLoaiMH = value;
				OnPropertyChanged();

			}

		}

		public LoaiMHViewModel()
		{
			ListLoaiMH = new ObservableCollection<LOAIMH>(DataProvider.Ins.DB.LOAIMHs);
			#region them
			SaveCommand = new RelayCommand<LOAIMH>((p) =>
			{
				//---- kiểm tra các tool có bị null hay không
				if (MaLoai == null && TenLoai == null)
				{
					return false;
				}


				//---- kiểm tra trùng lập đối tượng
				var list = DataProvider.Ins.DB.LOAIMHs.Where(x => x.MALOAIMH == MaLoai);

				if (list == null || list.Count() == 0)
				{
					return false;
				}

				return true;


			},
			(p) =>
			{
				try
				{
					LOAIMH lmh = new LOAIMH()
					{
						MALOAIMH = MaLoai,
						TENLOAIMH = TenLoai

					};
					DataProvider.Ins.DB.LOAIMHs.Add(lmh);
					DataProvider.Ins.DB.SaveChanges();
					ListLoaiMH.Add(lmh);
					MessageBox.Show("thêm thành công");
				}
				catch (Exception e)
				{
					MessageBox.Show(e.ToString());
				}
			});
			#endregion


			#region Edit
			UpdateCommand = new RelayCommand<LOAIMH>((p) =>
			{
				if (MaLoai == null && TenLoai == null)
				{
					return false;
				}

				//---- kiểm tra trùng lập đối tượng
				var list = DataProvider.Ins.DB.LOAIMHs.Where(x => x.MALOAIMH == MaLoai);
				if (list == null || list.Count() == 0)
				{
					return false;
				}
				return true;
			},
			(p) =>
			{
				try
				{
					var nv = DataProvider.Ins.DB.LOAIMHs.Where(x => x.MALOAIMH == MaLoai).SingleOrDefault();
					nv.TENLOAIMH = TenLoai;



					DataProvider.Ins.DB.SaveChanges();
					ListLoaiMH = new ObservableCollection<LOAIMH>(DataProvider.Ins.DB.LOAIMHs);//--load lai listview
					MessageBox.Show("sửa thành công");

				}
				catch (Exception e)
				{
					MessageBox.Show(e.ToString());
				}
			});
			#endregion


			#region delete
			DeleteCommand = new RelayCommand<LOAIMH>((p) =>
			{
				if (MaLoai == null && TenLoai == null)
				{
					return false;
				}

				//---- kiểm tra trùng lập đối tượng
				var listNV = DataProvider.Ins.DB.LOAIMHs.Where(x => x.MALOAIMH == MaLoai);
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
					var mh = DataProvider.Ins.DB.LOAIMHs.Where(x => x.MALOAIMH == SelectedItem.MALOAIMH).SingleOrDefault();
					var lmh2 = DataProvider.Ins.DB.LOAIMHs.Where(x => x.MALOAIMH == SelectedItem.MALOAIMH).SingleOrDefault();
					if (mh != null)
					{
						MessageBox.Show("Không thể xóa vì có ở bảng con");
					}
					else
					{
						DataProvider.Ins.DB.LOAIMHs.Remove(lmh2);
						DataProvider.Ins.DB.SaveChanges();
						ListLoaiMH = new ObservableCollection<LOAIMH>(DataProvider.Ins.DB.LOAIMHs);//--load lai listview
						MessageBox.Show("xóa thành công");
					}


				}
				catch (Exception e)
				{
					MessageBox.Show(e.ToString());
				}
			});
			#endregion

		}

		private int _MaLoai;
		public int MaLoai
		{
			get
			{
				return _MaLoai;
			}
			set
			{
				_MaLoai = value;
				OnPropertyChanged();

			}

		}

		private string _TenLoai;
		public string TenLoai
		{
			get
			{
				return _TenLoai;
			}
			set
			{
				_TenLoai = value;
				OnPropertyChanged();

			}

		}



		private LOAIMH _SelectedItem;
		public LOAIMH SelectedItem
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
					MaLoai = SelectedItem.MALOAIMH;
					TenLoai = SelectedItem.TENLOAIMH;

				}

			}

		}
	}
}

