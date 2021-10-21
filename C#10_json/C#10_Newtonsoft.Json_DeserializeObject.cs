// 使用https://www.bejson.com/convert/json2csharp/ 网站将JSON 转为 C# 实体类代码

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Drawing;
using Newtonsoft.Json;
using System.ComponentModel;
// using System.Windows.Forms;

    public class Program
    {
        public static void Main(string[] args)
        {
          string url = "http://www.kuaidi100.com/query?type=shunfeng&postid=367847964498";
          string getJson = HttpUitls.Get(url);
          // Console.WriteLine(getJson);

            //这个需要引入Newtonsoft.Json这个DLL并using
            Root rt = JsonConvert.DeserializeObject<Root>(getJson);
            //这样就可以取出json数据里面的值
            Console.WriteLine("com=" + rt.com + "\r\n" + "condition=" + rt.condition + "\r\n" + "ischeck=" + rt.ischeck + "\r\n" + "state=" + rt.state + "\r\n" + "status=" + rt.status);
            //由于这个JSON字符串的 public List<DataItem> data 是一个集合，所以我们需要遍历集合里面的所有数据
            for (int i = 0; i < rt.data.Count; i++)
            {
                Console.WriteLine("Data=" + rt.data[i].context + "\r\n" + rt.data[i].location + "\r\n" + rt.data[i].time + "\r\n" + rt.data[i].ftime);

            }
        }
    }
    
    public class HttpUitls
    {
        public static string Get(string Url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            request.Proxy = null;
            request.KeepAlive = false;
            request.Method = "GET";
            request.ContentType = "application/json; charset=UTF-8";
            request.AutomaticDecompression = DecompressionMethods.GZip;

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.UTF8);
            string retString = myStreamReader.ReadToEnd();

            myStreamReader.Close();
            myResponseStream.Close();

            if (response != null)
            {
                response.Close();
            }
            if (request != null)
            {
                request.Abort();
            }

            return retString;
        }
    
    }

    public class DataItem
    {
        public string time { get; set; }
        public string ftime { get; set; }
        public string context { get; set; }
        public string location { get; set; }
    }
    
    public class Root
    {
        public string message { get; set; }
        public string nu { get; set; }
        public string ischeck { get; set; }
        public string condition { get; set; }
        public string com { get; set; }
        public string status { get; set; }
        public string state { get; set; }
        public List <DataItem > data { get; set; }
    }
