using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics; // 特性
using System.Reflection;  // 反射
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Data;

namespace HelloWorld
{
    
  [Serializable]
  // 如果要想保存某个class中的字段,必须在class前面加个这样attribute(C#里面用中括号括起来的标志符)
  public class Person
  {
    public int age;
    public string name;
    [NonSerialized] // 如果某个字段不想被保存,则加个这样的标志
    public string secret;
  }



  class Program
  {
    static void Main( string [] args)
    {
      Person person = new Person();
      person.age = 18;
      person.name = "tom" ;
      person.secret = "i will not tell you" ;
      FileStream stream =new FileStream( @"C:\Users\Administrator\Desktop\person.dat" ,FileMode.Create);
      BinaryFormatter bFormat =new BinaryFormatter();
      bFormat.Serialize(stream, person);
      stream.Close();
      Console.WriteLine("OK !!!!!");

      Person deperson = new Person();
      FileStream destream =new FileStream( @"C:\Users\Administrator\Desktop\person.dat" ,FileMode.Open);
      BinaryFormatter debFormat =new BinaryFormatter();
      deperson = (Person)debFormat.Deserialize(destream);    // 反序列化得到的是一个object对象.必须做下类型转换
      destream.Close();
      Console.WriteLine(deperson.age + deperson.name + deperson.secret);    // 结果为18tom.因为secret没有有被序列化. 
      
    }
  }

}
