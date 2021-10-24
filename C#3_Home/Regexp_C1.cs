using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms_Excel_1
{
	public class Regexp_C1
	{
		public static void Sub_Regexp()
		{
			string email = "cfy122333@163.com";
			Regex regex = new Regex(@"^(\w)+(\.\w)*@(\w)+((\.\w+)+)$");
			if (regex.IsMatch(email))
			{
				MessageBox.Show("邮箱格式正确。");
			}
			else
			{
				MessageBox.Show("邮箱格式不正确。");
			}
		}
	}
}
