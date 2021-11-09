using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using Wpf_QuanLyNhaHang.Model;
using MessageBox = System.Windows.MessageBox;

namespace Wpf_QuanLyNhaHang.ViewModel
{
	public class MenuViewModel : BaseViewModel
	{
		public ICommand SaveCommand { get; set; }
		public ICommand UpdateCommand { get; set; }
		public ICommand DeleteCommand { get; set; }
		public ICommand TextChangedCommand { get; set;}
		public ICommand ImageCommand { get; set; }

		private ObservableCollection<MENU> _listMenu;
		public ObservableCollection<MENU> listMenu
		{
			get
			{
				return _listMenu;
			}
			set
			{
				_listMenu = value;
				OnPropertyChanged();

			}
		}

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

		public MenuViewModel()
		{
			listMenu = new ObservableCollection<MENU>(DataProvider.Ins.DB.MENUs.Where(x => x.TRANGTHAI != "AN"));
			listKhuyenMai = new ObservableCollection<KHUYENMAI>(DataProvider.Ins.DB.KHUYENMAIs);
			listLoaiMA = new ObservableCollection<LOAIMONAN>(DataProvider.Ins.DB.LOAIMONANs);

			#region TEXT CHANGE TÌM KIẾM
			TextChangedCommand = new RelayCommand<object>((p) => { return true; },
				(p) =>
				{

					Searching(Search);


				});
			#endregion

			#region save
			SaveCommand = new RelayCommand<MENU>((p) =>
			{
				if (TenMA == null || GiaBan == null || SelectedKM == null || DVT == null ||SelectedLoaiMA == null)
				{
					return false;
				}

				var list = DataProvider.Ins.DB.MENUs.Where(x => x.TENMONAN == TenMA);
				if (list == null || list.Count() != 0)
				{
					return false;
				}
				return true;

			},
			(p) =>
			{
				try
				{
					//sửa ảnh
					File.Copy(Image, Path.Combine(@"C:\Users\DAT\source\repos\Wpf_QuanLyNhaHang\Wpf_QuanLyNhaHang\Assets\", Path.GetFileName(Image)), true);

					MENU km = new MENU { MAKM = SelectedKM.MAKM, TENMONAN = TenMA, GIABAN = GiaBan, DVT = DVT, LOAIMONAN = SelectedLoaiMA, TRANGTHAI = null, HINH_MONAN = Image };
					DataProvider.Ins.DB.MENUs.Add(km);
					DataProvider.Ins.DB.SaveChanges();
					listMenu.Add(km);
					MessageBox.Show("Thêm thành công");
				}
				catch (DbEntityValidationException e)
				{
					foreach (var eve in e.EntityValidationErrors)
					{
						Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
							eve.Entry.Entity.GetType().Name, eve.Entry.State);
						foreach (var ve in eve.ValidationErrors)
						{
							Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
								ve.PropertyName, ve.ErrorMessage);
						}
					}
					throw;
				}
				

			});
			#endregion

			#region Edit
			UpdateCommand = new RelayCommand<MENU>((p) =>
			{
				if (TenMA == null || GiaBan == null ||  DVT == null || SelectedLoaiMA == null)
				{
					return false;
				}

				//---- kiểm tra trùng lập đối tượng
				var listTenMH = DataProvider.Ins.DB.MENUs.Where(x => x.TENMONAN == TenMA);
				if (listTenMH == null || listTenMH.Count() == 0)
				{
					return false;
				}
				return true;
			},
			(p) =>
			{
				try
				{
					//sửa ảnh
					File.Copy(Image, Path.Combine(@"C:\Users\DAT\source\repos\Wpf_QuanLyNhaHang\Wpf_QuanLyNhaHang\Assets\", Path.GetFileName(Image)), true);

					var mh = DataProvider.Ins.DB.MENUs.Where(x => x.MAMONAN == SelectedItem.MAMONAN).SingleOrDefault();
					mh.MALOAIMONAN = SelectedLoaiMA.MALOAIMONAN;
					if(SelectedKM == null)
					{
						mh.MAKM = null;
					}
					else
					{
						mh.MAKM = SelectedKM.MAKM;
					}
					
					mh.TENMONAN = TenMA;
					mh.GIABAN = GiaBan;
					mh.DVT = DVT;
					mh.TRANGTHAI = TrangThai;
					mh.HINH_MONAN = Image;
					DataProvider.Ins.DB.SaveChanges();
					listMenu = new ObservableCollection<MENU>(DataProvider.Ins.DB.MENUs.Where(x => x.TRANGTHAI != "AN"));//--load lai listview
					MessageBox.Show("sửa thành công");

				}
				catch (Exception e)
				{
					MessageBox.Show(e.ToString());
				}
			});
			#endregion

			#region delete
			DeleteCommand = new RelayCommand<MENU>((p) =>
			{
				if (TenMA == null || GiaBan == null || SelectedKM == null || DVT == null || SelectedLoaiMA == null)
				{
					return false;
				}

				//---- kiểm tra trùng lập đối tượng
				var listTenMH = DataProvider.Ins.DB.MENUs.Where(x => x.TENMONAN == TenMA);
				if (listTenMH == null || listTenMH.Count() == 0)
				{
					return false;
				}
				return true;
			},
			(p) =>
			{
				try
				{
					var mh2 = DataProvider.Ins.DB.MENUs.Where(x => x.MAMONAN == MaMA).SingleOrDefault();
					mh2.TRANGTHAI = "AN";
					DataProvider.Ins.DB.SaveChanges();
					listMenu = new ObservableCollection<MENU>(DataProvider.Ins.DB.MENUs.Where(x => x.TRANGTHAI != "AN"));//--load lai listview
					MessageBox.Show("xóa thành công");

				}
				catch (Exception e)
				{
					MessageBox.Show(e.ToString());
				}
			});
			#endregion

			#region Lưu ảnh
			ImageCommand = new RelayCommand<Button>((p) =>
			{

				return true;
			},
			(p) => {


				try
				{
					OpenFileDialog dialog = new OpenFileDialog();
					dialog.Filter = "Image Files(*.jpg;*.jpeg;*.gif;*.bmp;)|*.jpg;*.jpeg;*.gif;*.bmp;";
					if (dialog.ShowDialog() == DialogResult.OK)
					{

						Image = dialog.FileName;
					}
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
			int i = 0;
			if (s != "")
			{
				if (s.All(char.IsDigit)) //---nếu là số
				{
					i = int.Parse(s);
				}
				listMenu = new ObservableCollection<MENU>(
					from mn in DataProvider.Ins.DB.MENUs
					where mn.TENMONAN.Contains(s) || mn.MAMONAN == i
					select mn
				);
			}
			else
			{
				listMenu = new ObservableCollection<MENU>(DataProvider.Ins.DB.MENUs);
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

		private string _Image;
		public string Image
		{
			get
			{
				return _Image;
			}
			set
			{
				_Image = value;
				OnPropertyChanged();
			}
		}

		private string _LoaiMA;
		public string LoaiMA
		{
			get
			{
				return _LoaiMA;
			}
			set
			{
				_LoaiMA = value;
				OnPropertyChanged();
			}
		}



		private LOAIMONAN _SelectedLoaiMA;
		public LOAIMONAN SelectedLoaiMA
		{
			get
			{
				return _SelectedLoaiMA;

			}
			set
			{
				_SelectedLoaiMA = value;
				OnPropertyChanged();
			}
		}

		private KHUYENMAI _SelectedKM;
		public KHUYENMAI SelectedKM
		{
			get
			{
				return _SelectedKM;

			}
			set
			{
				_SelectedKM = value;
				OnPropertyChanged();
			}
		}

		private string _TenMA;
		public string TenMA
		{
			get
			{
				return _TenMA;

			}
			set
			{
				_TenMA = value;
				OnPropertyChanged();
			}
		}

		private double _GiaBan;
		public double GiaBan
		{
			get
			{
				return _GiaBan;

			}
			set
			{
				_GiaBan = value;
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

		private int _MaMA;
		public int MaMA
		{
			get
			{
				return _MaMA;

			}
			set
			{
				_MaMA = value;
				OnPropertyChanged();
			}
		}

		private MENU _SelectedItem;
		public MENU SelectedItem
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
					MaMA = SelectedItem.MAMONAN;
					SelectedLoaiMA = SelectedItem.LOAIMONAN;
					SelectedKM = SelectedItem.KHUYENMAI;
					TenMA = SelectedItem.TENMONAN;
					GiaBan = SelectedItem.GIABAN;
					Image = SelectedItem.HINH_MONAN;
					DVT = SelectedItem.DVT;

				}

			}

		}
	}
}

