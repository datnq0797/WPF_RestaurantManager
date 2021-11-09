using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Wpf_QuanLyNhaHang.View
{
	/// <summary>
	/// Interaction logic for ThanhToanWindow.xaml
	/// </summary>
	public partial class ThanhToanWindow : UserControl
	{
		public ThanhToanWindow()
		{
			InitializeComponent();
			btnhuy.IsEnabled = false;
		}

		private void Btn_ThanhToan_Click(object sender, RoutedEventArgs e)
		{
			var converter = new GridLengthConverter();
			rowlist.Height = (GridLength)converter.ConvertFromString("0");
			rowinvoice.Height = (GridLength)converter.ConvertFromString("900");
			btnhuy.IsEnabled = true;
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			try {
				this.IsEnabled = false;
				PrintDialog printDialog = new PrintDialog();
				if(printDialog.ShowDialog() == true)
				{
					printDialog.PrintVisual(print, "Invoice");
					
				}
			}
			finally
			{
				this.IsEnabled = true;
			}
		}

		private void Btn_Huy_Click(object sender, RoutedEventArgs e)
		{
			var converter = new GridLengthConverter();
			rowlist.Height = (GridLength)converter.ConvertFromString("500");
			rowinvoice.Height = (GridLength)converter.ConvertFromString("0");
			btnhuy.IsEnabled = false;

		}
	}
}
