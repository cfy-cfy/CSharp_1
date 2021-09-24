// 本示例显示如何指定在创建派生类实例时调用的基类构造函数。

using System;
using System.Collections.Generic;
using System.Linq;

namespace TestClass
{
  public class BaseClass
  {
      int num;

      public BaseClass()
      {
          Console.WriteLine("in BaseClass()");
      }

      public BaseClass(int i)
      {
          num = i;
          Console.WriteLine("in BaseClass(int i)");
      }

      public int GetNum()
      {
          return num;
      }
  }

  public class DerivedClass : BaseClass
  {
      // This constructor will call BaseClass.BaseClass()
      public DerivedClass() : base()
      {
      }

      // This constructor will call BaseClass.BaseClass(int i)
      public DerivedClass(int i) : base(i)
      {
      }

      static void Main()
      {
          DerivedClass md = new DerivedClass();
          DerivedClass md1 = new DerivedClass(1);
      }
  }
}
