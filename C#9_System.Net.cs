using System;
using System.IO;
using System.Web;
using System.Net;
using System.Text.RegularExpressions;

namespace HelloWorld
{
	public class Program
	{
		public static void Main(string[] args)
		{
			
			//string url_path ="https://www.baidu.com/";
			string url_path ="https://raw.githubusercontent.com/cfy-cfy/VBA_1/main/1_Download%20Llist.txt";
			Uri file_uri = new Uri(url_path);
			WebRequest request = WebRequest.Create(file_uri);  
			WebResponse response = request.GetResponse(); 
			StreamReader reader = new StreamReader(response.GetResponseStream()); //reader.ReadToEnd() 表示取得网页的源码
			Console.WriteLine(reader.ReadToEnd());			
			
		}
	}
}
