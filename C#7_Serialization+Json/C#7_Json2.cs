using System;
using System.Collections.Generic;
using System.Linq;https://github.com/cfy-cfy/CSharp_1/tree/main/C%237_Serialization%2BJson
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
    data.Add(dt);
    
    dict.address=data;

    string json=JsonConvert.SerializeObject(dict);
    Console.WriteLine(json);

    Dict dd = JsonConvert.DeserializeObject<Dict>(json);
    Console.WriteLine("{0}，{1}，{2}",dd.name,dd.gender,dd.old);
    Console.WriteLine(dd.address.Count);
    for (int i = 0; i < dd.address.Count; i++)
    {
        Console.WriteLine("{0},{1},{2}",dd.address[i].country,dd.address[i].province,dd.address[i].city);

    }

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
