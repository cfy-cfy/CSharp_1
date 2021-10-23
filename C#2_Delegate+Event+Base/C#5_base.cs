// https://docs.microsoft.com/zh-cn/dotnet/csharp/language-reference/keywords/base
// 在本例中，基类 Person 和派生类 Employee 都有一个名为 Getinfo 的方法。 通过使用 base 关键字，可以从派生类中调用基类的 Getinfo 方法。

using System;
using System.Collections.Generic;
using System.Linq;

namespace HelloWorld
{
  public class Person
  {
      protected string ssn = "444-55-6666";
      protected string name = "John L. Malgraine";

      public virtual void GetInfo()
      {
          Console.WriteLine("Name: {0}", name);
          Console.WriteLine("SSN: {0}", ssn);
      }
  }
  class Employee : Person
  {
      public string id = "ABC567EFG";
      public override void GetInfo()
      {
          // Calling the base class GetInfo method:
          base.GetInfo();
          Console.WriteLine("Employee ID: {0}", id);
      }
  }

  class TestClass
  {
      static void Main()
      {
          Employee E = new Employee();
          E.GetInfo();
      }
  }
}
