//Rextester.Program.Main 是代码入口函数，不要改变它.
//编译版本 4.0.30319.17929 for Microsoft (R) .NET Framework 4.5

using System;
using System.IO;
using System.Web;
using System.Net;
using System.Text.RegularExpressions;

namespace Rextester
{
	public class Program
	{
		public static void Main(string[] args)
		{
			
			//string url_path ="https://www.baidu.com/";
			string url_path ="https://raw.githubusercontent.com/cfy-cfy/VBA_1/main/1_Download%20Llist.txt";
			//string url_path ="https://raw.githubusercontent.com/hunkim/DeepLearningZeroToAll/master/data-03-diabetes.csv";
			Uri file_uri = new Uri(url_path);
			WebRequest request = WebRequest.Create(file_uri);  
			WebResponse response = request.GetResponse(); 
			StreamReader reader = new StreamReader(response.GetResponseStream()); //reader.ReadToEnd() 表示取得网页的源码
			Console.WriteLine(reader.ReadToEnd());			
			
		}
	}
}
