//  https://docs.microsoft.com/zh-cn/dotnet/csharp/programming-guide/concepts/linq/introduction-to-linq-queries

//——————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————

using System;
using System.Collections.Generic;
using System.Linq;

namespace HelloWorld
{
  class IntroToLINQ
  {
      static void Main()
      {
          // The Three Parts of a LINQ Query:
          // 1. Data source.
          int[] numbers = new int[7] { 0, 1, 2, 3, 4, 5, 6 };

          // 2. Query creation.
          // numQuery is an IEnumerable<int>
          var numQuery =
              from num in numbers
              where (num % 2) == 0
              select num;

          // 3. Query execution.
          foreach (int num in numQuery)
          {
              Console.WriteLine("{0,1} ", num);
          }

         int evenNumCount = numQuery.Count();
         Console.WriteLine("————————————————————————————————{0} ", evenNumCount);

         // 4. 要强制立即执行任何查询并缓存其结果，可调用 ToList 或 ToArray 方法。
          var arrList=numQuery.ToList();
          foreach (int arr in arrList)
          {
               Console.WriteLine(arr);
          }
          
          List<int> numQuery2 =
            (from num in numbers
            where (num % 2) == 0
            select num).ToList();
          Console.WriteLine($"————————————{numQuery2.Count}————————————————————");

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
}

