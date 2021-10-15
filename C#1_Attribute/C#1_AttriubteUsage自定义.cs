//自定义特性

// 使用自定义特性就要说到Attribute类，所有自定义Attribute必须从Attribute派生
//    protected Attribute()：保护构造器，只能被Attribute的派生类调用。 
//———————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————


using System;
using System.Collections.Generic;
using System.Linq;

namespace HelloWorld
{
  [AttributeUsage(AttributeTargets.Class, Inherited = false)] //设置了使用范围为Class，特性不可被使用者的派生类继承
  public class OldAttribute : Attribute
  {
      private string discription;
  
      public string Discription
      {
          get { return discription; }
          set { discription = value; }
      }
  
      public DateTime date;
      
      public OldAttribute(string discription)
      {
          this.discription = discription;
          date = DateTime.Now;
      }
  }
  [OldAttribute("这个类太old了，要过期了哦")]
  public class OldTestClass
  {
    public void OldTestClassMothod1()
    {
          Console.WriteLine("我是OldClass的测试方法");
    }
  }
  
  class NewTestClass : OldTestClass
  {
    public void NewTestClassMothod1()
    {
          Console.WriteLine("我是NewClass的测试方法");
    }
  }
  
  public class Test
  {
      public static void GetAttributeInfo(Type t)
      {
          OldAttribute myAttribute = (OldAttribute)Attribute.GetCustomAttribute(t, typeof(OldAttribute));
          Console.WriteLine(typeof(OldAttribute));
          if(myAttribute == null)
          {
              Console.WriteLine(t.ToString() + "类中自定义特性不存在！");
          }
          else
          {
              Console.WriteLine($"{t.ToString()}类中的特性描述为：{myAttribute.Discription},加入时间为：{myAttribute.date}");
          }
      }
  
      public static void Main()
      {
          GetAttributeInfo(typeof(OldTestClass));

          GetAttributeInfo(typeof(NewTestClass));
      }
  }

}
