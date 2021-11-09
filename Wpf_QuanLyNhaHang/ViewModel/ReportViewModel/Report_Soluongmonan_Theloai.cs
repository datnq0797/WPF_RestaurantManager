using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf_QuanLyNhaHang.Model;

namespace Wpf_QuanLyNhaHang.ViewModel.ReportViewModel
{
	public class Report_Soluongmonan_Theloai : ObservableCollection<DataItem>
	{
		public Report_Soluongmonan_Theloai()
		{
			var query = DataProvider.Ins.DB.SOLUONGMON_THEOLOAI;
			foreach (var item in query)
			{
				Add(new DataItem { Label = "Item 1", Value = 5 });
			}

		}

	}
}
