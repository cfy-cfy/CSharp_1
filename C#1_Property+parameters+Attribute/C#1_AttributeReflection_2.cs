using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics; // 特性
using System.Reflection;  // 反射

namespace HelloWorld
{
  [AttributeUsage(AttributeTargets.All,AllowMultiple = true,Inherited=true)]
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
    private string myclasskw;
    [HelpAttribute("Information on the property Myclasskw 1")]
    [HelpAttribute("Information on the property Myclasskw 2")]
    public string Myclasskw
    {
      get{return myclasskw;}
      set{myclasskw=value;}
    }

    [HelpAttribute("Information on the Method PayToalWage 1")]
    [HelpAttribute("Information on the Method PayToalWage 2")]
    [HelpAttribute("Information on the Method PayToalWage 3")]
    public static void PayToalWage()
    {
      Console.WriteLine("{0} Company total pay wage:{1} RMB", "A","B");
    }

  }

  class MyClassJCZ:MyClass
  {

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
            HelpAttribute dbi = (HelpAttribute)attributes[i];
            Console.WriteLine(dbi.Url);

        }
          Console.WriteLine("\r\n-------------------- 指定 MyClass 【类】的特性 --------------------------------[1]\r\n");

          Type t=typeof(HelloWorld.MyClass);
          // HelpAttribute myAttribute = (HelpAttribute)Attribute.GetCustomAttribute(t, typeof(HelpAttribute));
          Attribute[] attrs = Attribute.GetCustomAttributes(t,typeof(HelpAttribute));  //反射获得用户自定义属性
          HelpAttribute myAttribute=attrs[0] as HelpAttribute;
          if(myAttribute == null)
          {
              Console.WriteLine(typeof(HelloWorld.MyClass).ToString() + "类中自定义特性不存在！");
          }
          else
          {
              Console.WriteLine($"{t.ToString()}类中的特性描述为：{myAttribute.Url},加入时间为：");
          }

          Console.WriteLine("\r\n----------------------- 遍历 MyClass 【类】的特性 -----------------------------[2]\r\n");

          Type t1 = typeof(MyClass);
          Attribute[] attrs1 = Attribute.GetCustomAttributes(t1,typeof(HelpAttribute));  //反射获得用户自定义属性
 
            foreach (Attribute attr in attrs1)
            {
                if (attr is HelpAttribute)
                {
                    HelpAttribute a = (HelpAttribute)attr;
                    System.Console.WriteLine("   名称：{0}, 版本： ", a.Url);
                }
            }

           Console.WriteLine("\r\n--------------------- 遍历 MyClass 【类】的特性 -------------------------------[3]\r\n");

          Type type = typeof(MyClass);
          foreach (Object attributess in type.GetCustomAttributes(false))
          {
              HelpAttribute dbi = (HelpAttribute)attributess;
              if (null != dbi)
              {
                  Console.WriteLine("Age: {0}", dbi.Url);
              }
          }

          Console.WriteLine("\r\n---------------------- 遍历 MyClass 类【方法】特性 ------------------------------[4]\r\n");

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

         Console.WriteLine("\r\n---------------------- 指定 MyClass 类【属性】特性 ------------------------------[5]\r\n");

            PropertyInfo[] propertys = typeof(MyClass).GetProperties(); 
            if (propertys != null && propertys.Length > 0)
            {
                foreach (PropertyInfo p in propertys)
                {              
                    object[] objAttrs = p.GetCustomAttributes(typeof(HelpAttribute), true);//获取自定义特性
                    //GetCustomAttributes(要搜索的特性类型，是否搜索该成员的继承链以查找这些特性)
                    if (objAttrs != null && objAttrs.Length > 0)
                    {
                        HelpAttribute attr = objAttrs[1] as HelpAttribute;
                        Console.WriteLine("自定义特性Name："+", 元数据："+attr.Url);
                    }
                };
            }
      
          Console.WriteLine("\r\n------------------------- 遍历 MyClassCJZ 【派生类】的特性 ---------------------------[6]\r\n");

          // 遍历 继承了MyClass 类方法特性 的 MyClassJCZ
          // 如果一个你有 A 类它本身没有任何的自定义属性，但是继承 B 类，而 B 类又有一个自定义属性 CAttribute，而且自定义属性的 AttributeUsage(Inherited=true)，
          // 那么当你在 A 类上使用 GetCustomAttributes(true) 你就可以获在 B 类上的自定义属性 CAttribute。如果你在 A 类上使用 GetCustomAttributes(false) 就不会返回任何的结果。

          Type typeJCZ = typeof(MyClassJCZ);
          foreach (Object attributess in typeJCZ.GetCustomAttributes(true))  // false时返回空；
          {
              HelpAttribute dbi = (HelpAttribute)attributess;
              if (null != dbi)
              {
                  Console.WriteLine("Age: {0}", dbi.Url);
              }
          }

          Console.WriteLine("\r\n------------------------- 搜索具有指定名称的公共属性 + 设置指定实例 属性 的值 ---------------------------[7]\r\n");

            MyClass fClass = new MyClass();
            PropertyInfo pInstance = typeof(MyClass).GetProperty("Myclasskw");// 搜索具有指定名称的公共属性
            pInstance.SetValue(fClass,"WHHXPP");                              // 设置指定实例 属性 的值
            Console.WriteLine("新闻ID:"+fClass.Myclasskw);

      }
  }
}
