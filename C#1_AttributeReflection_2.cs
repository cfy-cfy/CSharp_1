using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics; // 特性
using System.Reflection;  // 反射

namespace HelloWorld
{
  [AttributeUsage(AttributeTargets.All,AllowMultiple = true)]
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

  [HelpAttribute("Information on the class MyClass 1")]
  [HelpAttribute("Information on the class MyClass 2")]
  class MyClass
  {
    [HelpAttribute("Information on the Method PayToalWage 1")]
    [HelpAttribute("Information on the Method PayToalWage 2")]
    [HelpAttribute("Information on the Method PayToalWage 3")]
    public void PayToalWage()
    {
      Console.WriteLine("{0} Company total pay wage:{1} RMB", "A","B");
    }
  }

  public class Program
  {
      public static void Main(string[] args)
      {
        System.Reflection.MemberInfo info = typeof(HelloWorld.MyClass);

        var attributes = info.GetCustomAttributes(true);
        for (int i = 0; i < attributes.Length; i++)
        {
            Console.WriteLine(attributes[i]);
        }
        // ————————————————————————————————————————————————————————————
          // Type t=typeof(HelloWorld.MyClass);
          // HelpAttribute myAttribute = (HelpAttribute)Attribute.GetCustomAttribute(t, typeof(HelpAttribute));
          // if(myAttribute == null)
          // {
          //     Console.WriteLine(typeof(HelloWorld.MyClass).ToString() + "类中自定义特性不存在！");
          // }
          // else
          // {
          //     Console.WriteLine($"{t.ToString()}类中的特性描述为：{myAttribute.Url},加入时间为：");
          // }

          Console.WriteLine("\r\n----------------------------------------------------");
 
          // 遍历 MyClass 类的特性
          Type type = typeof(MyClass);
          foreach (Object attributess in type.GetCustomAttributes(false))
          {
              HelpAttribute dbi = (HelpAttribute)attributess;
              if (null != dbi)
              {
                  Console.WriteLine("Age: {0}", dbi.Url);
              }
          }

          Console.WriteLine("\r\n----------------------------------------------------");

           // 遍历 MyClass 类方法特性
          Type typee = typeof(MyClass);
          foreach (MethodInfo m in typee.GetMethods())
          {
              foreach (Attribute a in m.GetCustomAttributes(true))
              {
                  HelpAttribute dbii = (HelpAttribute)a;
                  if (null != dbii)
                  {
                      Console.WriteLine("Age: {0}", dbii.Url);
                  }
              }
          }

      }
  }
}
