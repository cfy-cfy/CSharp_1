
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
    // SubStrArr();
    // SubIntArr();
    // SubDictArr();
    SubClassArr();
  }

  public static void SubStrArr()
  {
    // string[] strarr = new string[8] { "Ha", "Hunter", "Tom", "Lily", "Jay", "Jim", "Kuku", "Locu" }; 
    // string[] strarr = new string[] { "Ha", "Hunter", "Tom", "Lily", "Jay", "Jim", "Kuku", "Locu" }; 
    string[] strarr = { "Ha", "Hunter", "Tom", "Lily", "Jay", "Jim", "Kuku", "Locu" }; 
    List<string> lst=new List<string>(strarr);
    lst.Add("WHH");
    foreach(string item in lst)
    {
      Console.WriteLine(item);
    }

  }

  public static void SubIntArr()
  {
    int[] intarr = new int[5];
    for(int i = 0; i < intarr.Length; i++)
    {
        intarr[i] = i;
    }
    List<int> lst1=new List<int>(intarr);
    foreach(var item in lst1)
    {
      Console.WriteLine(item);
    }
  }

  public static void SubDictArr()
  {
    List<DataItem> ldi=new List<DataItem>() ;
    DataItem di1= new DataItem("China","GuangDong","FoShan");
    DataItem di2= new DataItem("China","GuangDong","GuangZhou");
    ldi.Add(di1);
    ldi.Add(di2);

    for (int i=0;i<ldi.Count;i++)
    {
      Console.WriteLine(ldi[i].city);
    }
  }

  public static void SubClassArr()
  {
    Dict dict=new Dict("MC","Boy",28);
    List<DataItem> ldi=new List<DataItem>() ;
    DataItem di1= new DataItem("China","GuangDong","FoShan");
    DataItem di2= new DataItem("China","GuangDong","GuangZhou");
    ldi.Add(di1);
    ldi.Add(di2);
    dict.address=ldi;

    string json=JsonConvert.SerializeObject(dict);
    Console.WriteLine(json);

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
