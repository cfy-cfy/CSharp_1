using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using HtmlAgilityPack;
using System.Text.RegularExpressions;  // regexp

//.NET下各种可用的HTML解析组件，这其中包括：

//CsQuery
//AngleSharp
//Jumony
//HtmlAgilityPack
//Fizzler
//ScrapySharp
//NSoup


// ————————————【html解析器_Html Agility Pack】
//		Nuget包管理器>程序包管理器控制台 > 输入以下命令即可安装 : Install-Package HtmlAgilityPack -Version 1.8.1 

// <<<<———<<<<———<<<<  1、Html Agility Pack相关功能介绍: https://html-agility-pack.net/?z=codeplex
//		Html Agility Pack解析html有四种方式： HTML Parser 、 HTML Selectors、HTML Manipulation、HTML Traversing

//      (1) HTML Parser ：Load and parse HTML （From File ， From String ， From Web ， From Browser）
//// From File
// var doc = new HtmlDocument();
// doc.Load(filePath);

//	// From String
//	var doc = new HtmlDocument();
// doc.LoadHtml(html);

//	// From Web
//	var url = "http://html-agility-pack.net/";
// var web = new HtmlWeb();
// var doc = web.Load(url);

//   (2) HTML Selectors ： Select HtmlNode, Element, and Attributes（ XPATH，CSS Coming Soon，XDocument，LINQ）

//// With XPath 
//var value = doc.DocumentNode
// .SelectNodes("//td/input")
// .First()
// .Attributes["value"].Value;

//// With LINQ 
//var nodes = doc.DocumentNode.Descendants("input")
// .Select(y => y.Descendants()
// .Where(x => x.Attributes["class"].Value == "box"))
// .ToList();

//   (3) HTML Manipulation ：Manipulate HtmlNode, Element, and Attributes（AppendChild，CreateNode，InsertAfter，PrependChild）

//var doc = new HtmlDocument();
//doc.LoadHtml(html);

//// InnerHtml 
//var innerHtml = doc.DocumentNode.InnerHtml;

//// InnerText 
//var innerText = doc.DocumentNode.InnerText;

//   (4) HTML Traversing：Traverse HtmlNode, Element, and Attributes（ChildNodes，Descendants()，Elements()）

//var doc = new HtmlDocument();
//htmlDoc.LoadHtml(html);

//// Descendants 
//var nodes = doc.DocumentNode.Descendants("input");





namespace WindowsForms_Excel_1
{
	public class Spider_HttpWebRequest
	{

		public static void HttpDownloadImage()
		{

			//string path = Application.StartupPath + "\\download";
			string path = @"C:\Users\hp\Desktop\download";
			Console.WriteLine(path);
			if (!Directory.Exists(path))
			{
				Directory.CreateDirectory(path);
			}

			string url = "https://cn.bing.com/images/search?q=意境图片&qpvt=意境图片&form=IGRE&first=1&tsc=ImageBasicHover";

			HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
			request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/89.0.4389.82 Safari/537.36";
			request.Headers.Add("cookie", "ipv6=hit=1626270422786&t=4; MUID=39B55D71DA836F7D093552CFDBC06EBA; SRCHD=AF=APIOAS; SRCHUID=V=2&GUID=FD0861DE9AC94912A0AE490D13B62384&dmnchg=1; ANON=A=01A711384815CB843E76EAEEFFFFFFFF&E=19a5&W=1; NAP=V=1.9&E=194b&C=UGdngJ5V_Pazk1LIUQZ2XP45gIhB_QviyLW8Ma2tpnjCyikSSWXRnQ&W=1; MUIDB=39B55D71DA836F7D093552CFDBC06EBA; _EDGE_S=SID=0AA4CEE5CDF7630E021BDE91CCB46228; _SS=SID=0AA4CEE5CDF7630E021BDE91CCB46228; SRCHUSR=DOB=20210113&T=1626267023000&TPC=1626266818000; SRCHHPGUSR=SRCHLANG=zh-Hans&BRW=NOTP&BRH=S&CW=476&CH=608&DPR=1&UTC=480&DM=0&WTS=63761863823&HV=1626267119");
			request.Referer = "https://cn.bing.com/images/search?q=%e6%84%8f%e5%a2%83%e5%9b%be%e7%89%87&qpvt=%e6%84%8f%e5%a2%83%e5%9b%be%e7%89%87&form=IGRE&first=1&tsc=ImageBasicHover";
			request.Timeout = 10000;
			request.Proxy = null;

			HttpWebResponse response = (HttpWebResponse)request.GetResponse();
			Stream responseStream = response.GetResponseStream();

			StreamReader sr = new StreamReader(responseStream, Encoding.UTF8);
			string content = sr.ReadToEnd();

			HtmlDocument doc = new HtmlDocument();
			doc.LoadHtml(content);

			WebClient client = new WebClient();

			HtmlNodeCollection ulNodes = doc.DocumentNode.SelectSingleNode("//div[@id='mmComponent_images_1']").SelectNodes("ul");
			Console.WriteLine(ulNodes.Count + " 组图片");
			int n = 0;
			if (ulNodes != null && ulNodes.Count > 0)
			{
				for (int i = 0; i < ulNodes.Count; i++)
				{
					HtmlNodeCollection liNodes = ulNodes[i].SelectNodes("li");
					
					for (int j = 0; j < liNodes.Count; j++)
					{
						n++;
						Console.WriteLine("序号：" + liNodes[j].Attributes["data-idx"].Value);
						HtmlNode imgNode = liNodes[j].SelectSingleNode("div/div/a/div/img");
						string href = imgNode.Attributes["src"].Value;
						Console.WriteLine("链接：" + href);
						client.DownloadFile(href, path + "\\" + n + ".jpg");
					}
				}
			}
			Console.WriteLine(n + " 张图片");
			sr.Close();
			response.Close();
			request.Abort();
			responseStream.Close();
			Console.WriteLine("OK!");
		}


		public static void GetPageHtml_baidunews()
		{
			//WebProxy proxyObject = new WebProxy(IP, PORT); //这里是用的代理。

			
			HttpWebRequest HttpWReq = WebRequest.Create("http://news.baidu.com/") as HttpWebRequest;  //发起请求

			//HttpWReq.Proxy = proxyObject;
			HttpWReq.Timeout = 10000;
			HttpWebResponse HttpWResp = (HttpWebResponse)HttpWReq.GetResponse();    // 获得响应
			//StreamReader sr = new StreamReader(HttpWResp.GetResponseStream(), Encoding.GetEncoding("UTF-8"));

			//将响应用流保存，#httpWebResponse只能返回流
			Stream responseStream = HttpWResp.GetResponseStream();
			//将流文件进行编码
			StreamReader sr = new StreamReader(responseStream, Encoding.GetEncoding("UTF-8"));

			// 将网页源码输出到屏幕
			//Console.WriteLine(sr.ReadToEnd());
			//string content = sr.ReadToEnd();
			//Console.WriteLine(content);

			//——————————————————————————————————【xpath】 https://html-agility-pack.net/?z=codeplex

			//用HAP解析html
			HtmlDocument doc = new HtmlDocument();
			//doc.LoadHtml(sr.ReadToEnd());
			doc.Load(sr);
			//————————————————————————————————————————
			HtmlNodeCollection ulNodes = doc.DocumentNode.SelectSingleNode("//div[@id='pane-news']").SelectNodes("ul");
			if (ulNodes != null && ulNodes.Count > 0)
			{
				for (int i = 0; i < ulNodes.Count; i++)
				{
					HtmlNodeCollection liNodes = ulNodes[i].SelectNodes("li");
					for (int j = 0; j < liNodes.Count; j++)
					{
						//string title = liNodes[j].SelectSingleNode("a").InnerHtml.Trim();
						//string href = liNodes[j].SelectSingleNode("a").GetAttributeValue("href", "").Trim();
						//Console.WriteLine("新闻标题：" + title + ",链接：" + href);

						HtmlNode aNode = liNodes[j].SelectSingleNode("a");
						string title = aNode.InnerText;
						HtmlAttribute href = aNode.Attributes["href"];
						Console.WriteLine("新闻标题：" + title + ",链接：" + href.Value);
					}
				}
			}
			//————————————————————————————————————————

			HtmlNodeCollection newsListHot = doc.DocumentNode.SelectNodes("//div[@id = 'pane-news']/div/ul/li/strong/a");
			Console.WriteLine("百度热点");
			if (newsListHot != null)
			{
				foreach (HtmlNode news in newsListHot)
				{
					Console.WriteLine("  ");
					Console.WriteLine(news.InnerText);  //获取新闻标题
					HtmlAttribute htmlAttribute1 = news.Attributes["href"];  //获取新闻链接
					Console.WriteLine(htmlAttribute1.Value);
				}
			}
			else
			{
				Console.WriteLine("出错了，建议检查Xpath是否出错");
			}
			//————————————————————————————————————————

			sr.Close();
			HttpWResp.Close();
			HttpWReq.Abort();
		}

	}

	public class HttpWebRequest_post
	{
		public static void HttpWebRequest_example()
		{
			//发送Get请求
			string cookie = "PLAYAB_SESSION=fe17aa4f50e48921dcf6efc74a5a8d445a15356f-%00___AT%3A435b98d80fcd02f8dafced0ac1baf7ec2e8d5238%00%00role%3A5%00%00user%3Acfycfy%00; Path=/ocean/";

			//var request = (HttpWebRequest)WebRequest.Create("http://i1168.vicp.net:9050/ocean/eorders/search");
			var request = (HttpWebRequest)WebRequest.Create("http://news.baidu.com/");
			request.Method = "GET";
			request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/89.0.4389.82 Safari/537.36";
			//request.ContentType = "application/x-www-form-urlencoded";
			//request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9";
			//request.Headers.Add("Origin", "http://i1168.vicp.net:9050");
			//request.Referer = "http://i1168.vicp.net:9050/ocean/";
			//request.Host = "i1168.vicp.net:9050";
			//request.Headers.Add("cookie", cookie);
			var response = (HttpWebResponse)request.GetResponse();
			var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
			Console.WriteLine(responseString);

			////发送Post请求
			//string postData = "authenticityToken=435b98d80fcd02f8dafced0ac1baf7ec2e8d5238&username=cfycfy&password=122333";
			//byte[] data = Encoding.UTF8.GetBytes(postData);
			//HttpWebRequest postrequest = (HttpWebRequest)WebRequest.Create("http://i1168.vicp.net:9050/ocean/users/login");
			//postrequest.Method = "POST";
			//postrequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/89.0.4389.82 Safari/537.36";
			//postrequest.ContentType = "application/x-www-form-urlencoded";
			//postrequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9";

			//postrequest.ContentLength = data.Length;
			//using (Stream stream = postrequest.GetRequestStream())
			//{
			//	stream.Write(data, 0, data.Length);
			//	
			//}

			//	HttpWebResponse postresponse = (HttpWebResponse)postrequest.GetResponse();
			//using (StreamReader sr = new StreamReader(postresponse.GetResponseStream()))
			//{
			//	string responseContent = sr.ReadToEnd().ToString();
			//	Console.WriteLine(responseContent);
			//}

		}
	}
}
