//一、运用范围

//程序集，模块，类型（类，结构，枚举，接口，委托），字段，方法（含构造），方法，参数，方法返回值，属性（property)，Attribute
//这里我们给出了除了程序集和模块以外的常用的Atrribute的定义。 

using System;
using System.Collections.Generic;
using System.Linq;

namespace HelloWorld
{
    [AttributeUsage(AttributeTargets.All)]
    public class TestAttribute : Attribute
    {
    }
    
    [TestAttribute] //结构
    public struct TestStruct { }

    [TestAttribute] //枚举
    public enum TestEnum { }


    [TestAttribute] //类上
    public class TestClass
    {
      [TestAttribute] //构造
      public TestClass() { }

      [TestAttribute] //字段
      private string _testField;

      [TestAttribute] //属性
      public string TestProperty { get; set; }

      [TestAttribute] //方法上
      [return: TestAttribute] //定义返回值的写法
      public string TestMethod([TestAttribute] string testParam) //参数上
      {
        throw new NotImplementedException();
      }
    }
}
