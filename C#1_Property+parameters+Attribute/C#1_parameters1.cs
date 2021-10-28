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
   DataItem di=new DataItem();
   di.name="kc";
   di.gender="girl";
   di.city="foshan";

   Console.WriteLine("{0},{1},{2}",di.name,di.gender,di.city);
   di.Test();
  }

}

public class DataItem
{
  public string name {get;set;}
  public string gender {get;set;}
  public string city {get;set;}
  
  public void Test()
  {
    Console.WriteLine("Test {0} OK!",Data.Sub(this));

  }
}

public class Data
{
  public static string Sub(DataItem D)
  {
    return D.name;
  }

}
