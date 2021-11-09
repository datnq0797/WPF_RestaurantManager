using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf_QuanLyNhaHang.Model;
namespace Wpf_QuanLyNhaHang.ViewModel
{
	public class ChartMainViewModel : BaseViewModel
	{

		private ObservableCollection<ORDER> _ListBanDat;
		public ObservableCollection<ORDER> ListBanDat
		{
			get
			{
				return _ListBanDat;
			}
			set
			{
				_ListBanDat = value;
				OnPropertyChanged();
			}
		}


		public ChartMainViewModel()
		{
			ListBanDat = new ObservableCollection<ORDER>(DataProvider.Ins.DB.ORDERs.Where(x=>x.TRANGTHAI != "AN"));

			//----lấy dữ liệu cho beststaff
			var ob = DataProvider.Ins.DB.BESTSTAFF(3).First();
			picStaff = ob.HINH_ANH;
			infoStaff = ob.TENNV;
			countStaff = ob.SOLUONGMON.ToString();

			//----lấy dữ liệu cho doanh thu
			var ob2 = DataProvider.Ins.DB.DOANHTHU().SingleOrDefault();
			sumTotal = ob2.ToString();

		}

		private string _picStaff;
		public string picStaff
		{
			get
			{
				return _picStaff;
			}
			set
			{
				_picStaff = value;
				OnPropertyChanged();
			}
		}



		private string _infoStaff;
		public string infoStaff
		{
			get
			{
				return _infoStaff;
			}
			set
			{
				_infoStaff = value;
				OnPropertyChanged();
			}
		}

		private string _countStaff;
		public string countStaff
		{
			get
			{
				return _countStaff;
			}
			set
			{
				_countStaff = value;
				OnPropertyChanged();
			}
		}

		private string _sumTotal;
		public string sumTotal
		{
			get
			{
				return _sumTotal;
			}
			set
			{
				_sumTotal = value;
				OnPropertyChanged();
			}
		}



	}
}

