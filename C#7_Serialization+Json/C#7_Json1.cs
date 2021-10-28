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
    Dict dict=new Dict();
    dict.name="kc";
    dict.gender="girl";
    dict.old=18;

    DataItem dt=new DataItem();
    dt.country="China";
    dt.province="Canton";
    dt.city="FoShan";

    List<DataItem> data=new List<DataItem>();
    data.Add(dt);

    dict.address=data;

    string json=JsonConvert.SerializeObject(dict);
    Console.WriteLine(json);

  }

  public class Dict
  {
    public string name {get;set;}
    public string gender {get;set;}
    public int old {get;set;}
    public List <DataItem> address {get;set;}

  }

  public class DataItem
  {
    public string country {get;set;}
    public string province {get;set;}
    public string city {get;set;}
  }


}
