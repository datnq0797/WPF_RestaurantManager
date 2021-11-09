using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using LiveCharts;
using LiveCharts.Wpf;
using Wpf_QuanLyNhaHang.Model;
namespace Wpf_QuanLyNhaHang.ViewModel.ReportViewModel
{
	public class ReportDoanhThu_MonAn : BaseViewModel
	{

		public ICommand SelectedThang { get; set; }

		private int _Thang;
		public int Thang
		{

			get
			{
				return _Thang;
			}
			set
			{
				_Thang = value;
				OnPropertyChanged();
			}
		}

		private string[] _TenMA;
		public string[] TenMA
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
		
		private ChartValues<int> _columnSeries;
		public ChartValues<int> columnSeries
		{
			get
			{
				return _columnSeries;
			}
			set
			{
				_columnSeries = value;
				OnPropertyChanged();
			}
		}

		private SeriesCollection _senderChart;
		public SeriesCollection senderChart
		{
			get
			{
				return _senderChart;
			}
			set
			{
				_senderChart = value;
				OnPropertyChanged(nameof(senderChart));
			}
		}

		public ReportDoanhThu_MonAn()
		{
			
			SelectedThang = new RelayCommand<object>(
				(p) =>
				{
					return true;
				},
				(p) =>
				{
					#region màu sắc các cột
					var doubleMapperWithMonthColors = new LiveCharts.Configurations.CartesianMapper<int>()
			.X((value, index) => index)
			.Y((value) => value)
			.Fill((v, i) =>
			{
				switch (i % 12)
				{
					case 0: return Brushes.LightBlue;
					case 1: return Brushes.LightCoral;
					case 2: return Brushes.PaleGoldenrod;
					case 3: return Brushes.OrangeRed;
					case 4: return Brushes.BlueViolet;
					case 5: return Brushes.Chocolate;
					case 6: return Brushes.PaleVioletRed;
					case 7: return Brushes.CornflowerBlue;
					case 8: return Brushes.Orchid;
					case 9: return Brushes.Thistle;
					case 10: return Brushes.BlanchedAlmond;
					case 11: return Brushes.YellowGreen;
					default: return Brushes.Red;
				}
			});
					LiveCharts.Charting.For<int>(doubleMapperWithMonthColors, SeriesOrientation.Horizontal);
					#endregion
					ObservableCollection<SOLUONG_MONAN_Result>
						List = new ObservableCollection<SOLUONG_MONAN_Result>(DataProvider.Ins.DB.SOLUONG_MONAN(Thang));

					senderChart = new SeriesCollection();

					var columnSeries = new ColumnSeries() { Values = new ChartValues<int>(), DataLabels = true, Title = "Số lượng" };

					foreach (var item in List)
					{
						columnSeries.Values.Add(item.SOLUONG);
					}
					TenMA = List.Select(c => c.TENMONAN).ToArray();
					senderChart.Add(columnSeries);


				});


		}
	}
}
