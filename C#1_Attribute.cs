//【Conditional特性】

//白话来说，该特性可以定义一个条件，必须在该条件下调用，否则不执行调用
//该特性标记了一个条件方法，其执行依赖于指定的预处理标识符。它会引起方法调用的条件编译。 
//————————————————————————————————————————————————————————————————————————————————

#define MyDo     // ————————————设置条件
using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace CAttribute
{
  class Test
  {
      [Conditional("MyDo")]
      static void TestMethod1(string msg)
      {
          Console.WriteLine(msg);
      }
  
      public static void Main()
      {
          //调用方法
          TestMethod1("我借用TestMethod1方法输出，第一次！");
          Console.WriteLine("我在Main方法里输出了！");
          TestMethod1("我借用TestMethod1方法输出，第二次！");
      }
  }
}

