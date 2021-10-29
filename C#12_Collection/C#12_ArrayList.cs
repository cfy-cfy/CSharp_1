using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Drawing;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Collections;

public class Program
{
  static void Main(string[] args)
  {
    ArrayList list = new ArrayList();
    list.Add("我");  // Add 添加 向数组中赋值索引为最末尾
    list.Add("今年");
    list.Add("18");
    list.Add("岁了");
    list.Add("19");
    list.Add("岁了O");
    list.Add("19");
    list.Add("岁了OO");

    bool result = list.Contains("我");  // 返回bool 查询数组中元素是否存在 
    Console.WriteLine(result);

    string[] list1 = new String[15];
    list.CopyTo(list1); // 赋值数组中的全部数据   赋值的集合的数据类型要一致

    object[] list2 = new object[15];
    list.CopyTo(list2); // 赋值数组中的全部数据   赋值的集合的数据类型可以不一致

    list.RemoveAt(6); //把第七个元素移除
    list.Remove("我"); //移除的是元素

    string json=JsonConvert.SerializeObject(list);
    Console.WriteLine(json);

    Console.WriteLine(list.Count);  //数组元素的个数
    Console.WriteLine(list[5]);

    foreach (object val in list)
    {
      Console.WriteLine(val);
    }
    Console.ReadKey();

    list.Clear();//清空数组


  }
}

