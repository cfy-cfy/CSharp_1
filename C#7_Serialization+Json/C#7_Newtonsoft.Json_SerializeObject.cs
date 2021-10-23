using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Drawing;
using Newtonsoft.Json;
using System.ComponentModel;

    public class Program
    {
        public static void Main(string[] args)
        {
            //生成JSON字符串,其实就把我们刚刚写的实体实体赋值
            Root rt = new Root();
            rt.com="这个是我赋值的com";
            rt.condition="这个是我赋值的condition";
            rt.ischeck="这个是我赋值的ischeck";
            rt.message="这个是我赋值的message";
            rt.state="这个是我赋值的satate";
            rt.status="这个是我赋值的statcs";
            List<DataItem> data  =new List<DataItem>();
            DataItem dt = new DataItem();
            dt.context="这个是我赋值的内容";
            dt.time="这个是我赋值的时间";
            dt.ftime="这个是我赋值的时间";
            data.Add(dt);
            rt.data=data;
            //把我们初始化好的对象传入即可
            string json = JsonConvert.SerializeObject(rt);
            Console.WriteLine(json);
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

