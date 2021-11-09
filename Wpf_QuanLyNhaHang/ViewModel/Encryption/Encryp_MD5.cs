using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_QuanLyNhaHang.ViewModel.Encryption
{
    public class Encryp_MD5
    {
		//---hàm mã hóa MD5
		public string Encryption(string pass)
		{
			byte[] temp = ASCIIEncoding.ASCII.GetBytes(pass);
			byte[] hasData = new MD5CryptoServiceProvider().ComputeHash(temp);

			string hasPass = "";

			foreach (Byte item in hasData)
			{
				hasPass += item;
			}

			string text = hasPass;

			return hasPass;
		}
	}
}
