using System;
using System.Collections.Generic;
using System.Linq;

namespace HelloWorld
{
  [AttributeUsage(AttributeTargets.All)]
  public class HelpAttribute : Attribute
  {
    
    private string topic;
    public string Topic  // Topic 是一个命名（named）参数
    {
        get
        {
          return topic;
        }
        set
        {

          topic = value;
        }
    }

    public readonly string Url;
    public HelpAttribute(string url)  // url 是一个定位（positional）参数
    {
        this.Url = url;
    }

  }

  [HelpAttribute("Information on the class MyClass")]
  class MyClass
  {
  }

  public class Program
  {
      public static void Main(string[] args)
      {
        System.Reflection.MemberInfo info = typeof(MyClass);
        // Console.WriteLine(typeof(MyClass));

        var attributes = info.GetCustomAttributes(true);

        for (int i = 0; i < attributes.Length; i++)
        {
            Console.WriteLine(attributes[i]);
        }
      }
  }


}
