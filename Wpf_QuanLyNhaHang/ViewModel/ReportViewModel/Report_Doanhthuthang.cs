using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DevExpress.Xpf.Charts;
using LiveCharts;
using LiveCharts.Wpf;
using Wpf_QuanLyNhaHang.Model;

namespace Wpf_QuanLyNhaHang.ViewModel.ReportViewModel
{
    public class Report_Doanhthuthang:BaseViewModel
    {
		public ObservableCollection<DataPoint> Data { get; private set; }

		public ICommand TextChanged { get; set; }

		public Report_Doanhthuthang()
		{
			var query = DataProvider.Ins.DB.SLBANDUOC_THANG2(3);
			
			foreach(var item in query)
			{
				this.Data.Add(new DataPoint { Argument = item.TENMONAN, Value = int.Parse(item.SOLUONG.ToString()) });
			}



		}

		

		private string _thang;
		public string thang
		{
			set
			{
				_thang = value;
				OnPropertyChanged();
			}
			get
			{
				return _thang;

			}
		}


    }
}
