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
    Dictionary<string,string> dict=new Dictionary<string,string>();
    dict.Add("A0","AB");
    dict.Add("A1","CD");
    dict.Add("A2","EF");
    dict["A3"]="IJ";
    Console.WriteLine($"ContainsKey()方法来判断键是否存在： {dict.ContainsKey("A1")}");
    
    // 而使用【索引器】来赋值时，如果建已经存在，就会修改已有的键的键值，而不会抛出异常
    dict["A2"]="GH"; 

    // 如果添加已经存在的键，【Add】方法会抛出异常
    try
    {
      dict.Add("A0","ddd");
    }
    catch (ArgumentException ex)
    {
      Console.WriteLine("A0 此键已经存在：" + ex.Message);
    }

    // 使用【索引器】来取值时，如果键不存在就会引发异常; 解决的异常的方法是使用【ContarnsKey()】 来判断时候存在键
    try
    {
       Console.WriteLine("不存在的键'fff'的键值为：" + dict["fff"]);
    }
    catch (KeyNotFoundException ex)
    {
      Console.WriteLine("没有找到键'fff'引发异常：" + ex.Message);
    }

    // 如果经常要取健值得化最好用 【TryGetValue】方法来获取集合中的对应键值
    string value = "";
    if (dict.TryGetValue("A2", out value))
    {
      Console.WriteLine("'A2'的键值为：" + value );
    }
    else
    {     
      Console.WriteLine("没有找到对应键的键值"); 
    }

    // 泛型结构体 用来存 key,value 值对
    foreach (KeyValuePair<string, string> kvp in dict)
    {
      Console.WriteLine("取值 key,value 方式1： key={0},value={1}", kvp.Key, kvp.Value);
    }

    //获取 value 值得集合
    foreach (string s in dict.Values)
    {
      Console.WriteLine("取 value 方式2： value={0}", s);
    }

    //获取 key 得集合
    foreach (string k in dict.Keys)
    {
      Console.WriteLine("取 key 方式3： key={0}", k);
    }

   // 获取 value 值得另一种方式
    Dictionary<string, string>.ValueCollection values = dict.Values;
    foreach (string s in values)
    {
      Console.WriteLine("取 value 方式4： value={0}", s);
    }


  }
}

