//【Conditional特性】

//白话来说，该特性可以定义一个条件，必须在该条件下调用，否则不执行调用
//该特性标记了一个条件方法，其执行依赖于指定的预处理标识符。它会引起方法调用的条件编译。 
//————————————————————————————————————————————————————————————————————————————————

#define MyDo     // ————————————设置条件
using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace HelloWorld
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


// 【Attribute的使用方法：（四种方式完全等价）】
// //长记法
// [ConditionalAttribute("Li")]
// [ConditionalAttribute("NoBug")]
// public static void Func()
// {Console.WriteLine("Created by Li, NoBug"); }
// //短记法
// [Conditional("Li")]
// [Conditional("NoBug")]
// public static void Func()
// {Console.WriteLine("Created by Li, NoBug"); }
// //换序
// [Conditional("NoBug")]
// [Conditional("Li")]
// public static void Func()
// {Console.WriteLine("Created by Li, NoBug"); }
// //单括号叠加
// [Conditional("NoBug"),Conditional("Li")]
// public static void Func()
// {Console.WriteLine("Created by Li, NoBug"); } 
