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
    Dict dict=new Dict("kc","girl",18);

    DataItem dt=new DataItem("China","Canton","FoShan");

    List<DataItem> data=new List<DataItem>();
    data.Add(dt);
    data.Add(dt);
    for (int i = 0; i < data.Count; i++)
    {
        Console.WriteLine("{0},{1},{2}",data[i].country,data[i].province,data[i].city);
    }

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
}
  public class Dict
  {
    public string name {get;set;}
    public string gender {get;set;}
    public int old {get;set;}
    public List <DataItem> address {get;set;}

    public Dict(string _name,string _gender,int _old)
    {
        this.name=_name;
        this.gender=_gender;
        this.old=_old;
    }
  }

  public class DataItem
  {
    public string country {get;set;}
    public string province {get;set;}
    public string city {get;set;}
    
    public DataItem(string _country,string _province,string _city)
    {
        this.country=_country;
        this.province=_province;
        this.city=_city;
    }
  }
