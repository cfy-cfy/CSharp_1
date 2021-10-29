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
  static void Main(string[] args)
  {
    Student stu=new Student(1,"VC",18);

    Dictionary<string,DataItem> dict = new Dictionary<string,DataItem>();

    DataItem di1= new DataItem("China","GuangDong","FoShan");
    DataItem di2= new DataItem("China","HuBei","WuHan");
    dict.Add("A0",di1);
    dict.Add("A1",di2);
    dict["A1"]= new DataItem("China","HuNan","ChangSha");

    Console.WriteLine("索引取值= {0}",dict["A1"].province);

    string json=JsonConvert.SerializeObject(dict);
    Console.WriteLine(json);

    stu.address=dict;
    string json1=JsonConvert.SerializeObject(stu);
    Console.WriteLine(json1);

    Student dd = JsonConvert.DeserializeObject<Student>(json1);
    Console.WriteLine("{0}，{1}，{2}",dd.id,dd.name,dd.age);
    Console.WriteLine(dd.address.Count);
    Console.WriteLine("{0}，{1}，{2}",dd.address["A0"].country,dd.address["A0"].province,dd.address["A0"].city);


  }
}

public class Student
{
  public int id { get; set; }
  public string name { get; set; }
  public int age { get; set; }
  public Dictionary<string,DataItem> address {get;set;}

  public Student(int id,string name,int age)
  {
    this.id = id;
    this.name = name;
    this.age = age;
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
