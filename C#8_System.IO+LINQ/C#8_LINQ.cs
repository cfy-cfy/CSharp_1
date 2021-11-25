//  https://docs.microsoft.com/zh-cn/dotnet/csharp/programming-guide/concepts/linq/introduction-to-linq-queries

//——————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using HtmlAgilityPack;
using System.Text.RegularExpressions;  // regexp
using System.Drawing;
using System.Data;

public class Program
{
  public static void Main(string[] args)
  {
   
    Linq.sub_Linq1();

  }

}

public class Linq
{
    public static void sub_Linq1()
    {
          int[] numbers = new int[7] { 0, 1, 2, 3, 4, 5, 6 };
    
          var numQuery =
              from num in numbers
              where (num % 2) == 0
              select num;

          foreach (int num in numQuery)
          {
              Console.WriteLine("{0,1} ", num);
          }

         int evenNumCount = numQuery.Count();
         Console.WriteLine("————————————————————————————————{0} ", evenNumCount);

         // 【要强制立即执行任何查询并缓存其结果，可调用 ToList 或 ToArray 方法】

         // ————————————————————————————————————————————    【 ToList 】
          var arrList=numQuery.ToList();
          foreach (int arr in arrList)
          {
               Console.WriteLine(arr);
          }
          
         // ————————————————————————————————————————————    【 ToList 】

          List<int> numQuery2 =
            (from num in numbers
            where (num % 2) == 0
            select num).ToList();
          Console.WriteLine($"————————————{numQuery2.Count}————————————————————");

         // ————————————————————————————————————————————    【 ToArray 】
          var numQuery3 =
              (from num in numbers
              where (num % 2) == 0
              select num).ToArray();
          
          foreach (var arr in numQuery3)
          {
               Console.WriteLine(arr);
          }  


    }

}



