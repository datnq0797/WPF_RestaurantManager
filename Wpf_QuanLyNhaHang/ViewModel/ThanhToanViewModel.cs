using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Wpf_QuanLyNhaHang.Model;

namespace Wpf_QuanLyNhaHang.ViewModel
{
	public class ThanhToanViewModel : BaseViewModel
	{

		public ICommand SelectionChanged { get; set; }
		public ICommand ThanhToanCommand { get; set; }


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

		private ObservableCollection<CHITIETORDER> _ListMonAn;
		public ObservableCollection<CHITIETORDER> ListMonAn
		{
			get
			{
				return _ListMonAn;
			}
			set
			{
				_ListMonAn = value;
				OnPropertyChanged();

			}

		}

		private ObservableCollection<CHITIETORDER> _listMatHang;
		public ObservableCollection<CHITIETORDER> listMatHang
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

		public ThanhToanViewModel()
		{
			ListKhachHang = new ObservableCollection<KHACHHANG>(DataProvider.Ins.DB.KHACHHANGs.Where(x => x.TRANGTHAI != "AN"));

			#region chon text box
			SelectionChanged = new RelayCommand<object>((p) => { return true; },

				(p) =>
				{
					ListMonAn = new ObservableCollection<CHITIETORDER>(
						from ct in DataProvider.Ins.DB.CHITIETORDERs
						join menu in DataProvider.Ins.DB.MENUs on ct.MAMONAN equals menu.MAMONAN
						join od in DataProvider.Ins.DB.ORDERs on ct.MAOD equals od.MAOD
						where od.MAKH == SelectedKhachHang.MAKH
						orderby od.MAOD descending
						select ct
						);
				});
			#endregion

			ThanhToanCommand = new RelayCommand<Button>((p) =>
			{


				//---- kiểm tra các tool có bị null hay không
				if (Soban == null || SelectedKhachHang == null )
				{
					return false;
				}





				return true;



			}, (p) =>
			{

				try
				{
					var query = new ObservableCollection<ORDER>(
						from ct in DataProvider.Ins.DB.CHITIETORDERs
						join menu in DataProvider.Ins.DB.MENUs on ct.MAMONAN equals menu.MAMONAN
						join od in DataProvider.Ins.DB.ORDERs on ct.MAOD equals od.MAOD
						where od.MAKH == SelectedKhachHang.MAKH
						orderby od.MAOD descending
						select od
						).FirstOrDefault();

					var query2 = DataProvider.Ins.DB.KHACHHANGs.Where(x => x.MAKH == SelectedKhachHang.MAKH).SingleOrDefault();
					var query3 = DataProvider.Ins.DB.BILLs.Where(x => x.MAKH == SelectedKhachHang.MAKH).SingleOrDefault();
					var tt = DataProvider.Ins.DB.total(query3.MAOD).SingleOrDefault();

					//----------thêm đối tượng vào bills
					try
					{
						BILL mh = new BILL()
						{
							MAKH = SelectedKhachHang.MAKH,
							SOBAN = Soban,
							MANV = query.MANV,
							MAOD = query.MAOD,
							SOLUONGKHACH = query.SOKHACH,
							CHECKIN = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy H:mm")),
							CHECKOUT = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy H:mm"))
						};
						DataProvider.Ins.DB.BILLs.Add(mh);
						DataProvider.Ins.DB.SaveChanges();

						MessageBox.Show("thêm thành công");
					}
					catch (Exception e)
					{
						MessageBox.Show(e.ToString());
					}


					//--------thêm vào hóa đơn
					listMatHang = new ObservableCollection<CHITIETORDER>(DataProvider.Ins.DB.CHITIETORDERs.Where(x => x.MAOD == query.MAOD));
					yourname = query2.TENKH;
					youremail = query2.CMND;
					yourphone = query2.SDT;
					ngayxuat = DateTime.Now.ToString("hh:mm tt");
					checkin = DateTime.Now.ToString("MM/dd/yyyy H:mm");
					checkout = DateTime.Now.ToString("MM/dd/yyyy H:mm");
					total = int.Parse(tt.ToString());

				}
				catch (Exception e)
				{
					MessageBox.Show("có thể khách chưa đặt món @@@");
				}
				
				


			});




		}



		private KHACHHANG _SelectedKhachHang;
		public KHACHHANG SelectedKhachHang
		{
			get
			{
				return _SelectedKhachHang;
			}
			set
			{
				_SelectedKhachHang = value;
				OnPropertyChanged();

			}

		}

		private int _Soban;
		public int Soban
		{
			get
			{
				return _Soban;
			}
			set
			{
				_Soban = value;
				OnPropertyChanged();
			}
		}


		private string _yourname;
		public string yourname
		{
			get
			{
				return _yourname;
			}
			set
			{
				_yourname = value;
				OnPropertyChanged();
			}
		}

		private string _youremail;
		public string youremail
		{
			get
			{
				return _youremail;
			}
			set
			{
				_youremail = value;
				OnPropertyChanged();
			}
		}

		private string _yourphone;
		public string yourphone
		{
			get
			{
				return _yourphone;
			}
			set
			{
				_yourphone = value;
				OnPropertyChanged();
			}
		}

		private string _checkin;
		public string checkin
		{
			get
			{
				return _checkin;
			}
			set
			{
				_checkin = value;
				OnPropertyChanged();
			}
		}

		private string _checkout;
		public string checkout
		{
			get
			{
				return _checkout;
			}
			set
			{
				_checkout = value;
				OnPropertyChanged();
			}
		}

		private string _ngayxuat;
		public string ngayxuat
		{
			get
			{
				return _ngayxuat;
			}
			set
			{
				_ngayxuat = value;
				OnPropertyChanged();
			}
		}

		private int _total;
		public int total
		{
			get
			{
				return _total;
			}
			set
			{
				_total = value;
				OnPropertyChanged();
			}
		}
	}
}
