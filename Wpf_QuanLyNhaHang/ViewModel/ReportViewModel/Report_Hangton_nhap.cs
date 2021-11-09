using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf_QuanLyNhaHang.Model;
namespace Wpf_QuanLyNhaHang.ViewModel.ReportViewModel
{
    public class Report_Hangton_nhap
    {
		public List<Product> Data { get; set; }
		public Report_Hangton_nhap()
		{
			//----lấy dữ liệu cho chart 
			var query = (
				from mh in DataProvider.Ins.DB.MATHANGs
				join ct in DataProvider.Ins.DB.CTPHIEUNHAPs on mh.MAMH equals ct.MAMH
				select new { mh.TENMH, ct.SLNHAP, mh.SOLUONG }

				);
			Data = new List<Product>();
			foreach (var item in query)
			{
				Data.Add(new Product { tenmh = item.TENMH, slnhap = item.SLNHAP, slton = item.SOLUONG });
			}
		}
	}
}
