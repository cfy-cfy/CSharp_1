using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using HtmlAgilityPack;
using System.Text.RegularExpressions;  // regexp

public class Program
{
  public static void Main(string[] args)
  {
    string url=@"http://www.csrc.gov.cn/pub/zjhpublic/G00306212/202108/t20210831_404435.htm?keywords=%E6%B0%B8%E8%89%BA%E8%82%A1%E4%BB%BD";
    HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
    request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/89.0.4389.82 Safari/537.36";
		request.Timeout = 10000;
		request.Proxy = null;
    
    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
		Stream responseStream = response.GetResponseStream();

		StreamReader sr = new StreamReader(responseStream, Encoding.UTF8);
		string content = sr.ReadToEnd();
    // Console.WriteLine(content);

		HtmlDocument doc = new HtmlDocument();
		doc.LoadHtml(content);

    string gettxt="";

    HtmlNodeCollection spanNodes = doc.DocumentNode.SelectNodes("//font/font/font/span");
    Console.WriteLine(spanNodes.Count);
    for (int j = 0; j < spanNodes.Count; j++)
    {
      string title = spanNodes[j].InnerText;
      gettxt=gettxt + title;
    }

    Console.WriteLine(gettxt);
    sr.Close();
    response.Close();
    request.Abort();
    responseStream.Close();
    Console.WriteLine("OK!");

  }


}
