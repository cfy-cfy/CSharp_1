using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Drawing;
using Newtonsoft.Json;
using System.ComponentModel;

public class Program
{
  static void Main(string[] args)
  {
    Dictionary<int,Student> dict = new Dictionary<int,Student>();
    Student stu1=new Student(1, "小明", 20);
    Student stu2=new Student(2, "小李", 21);
    Student stu3=new Student(3, "小赵", 22);
    dict.Add(stu1.id,stu1);
    dict.Add(stu2.id,stu2);
    dict.Add(stu3.id,stu3);
    
    Console.WriteLine(dict.ContainsKey(1));
    Console.WriteLine("dict = {0},id = {1},name = {2},age = {3}",dict[1],dict[1].id,dict[1].name,dict[1].age);

    foreach(var d in dict)
    {
        int key = (int)d.Key;
        string value = d.Value.ToString();
        Console.WriteLine("K = {0}，V = {1}", key, value);
    }

    for (int i=1;i <= dict.Count;i++)
    {
      Console.WriteLine("dict = {0},id = {1},name = {2},age = {3}",dict[i],dict[i].id,dict[i].name,dict[i].age);
    }
    
    string json=JsonConvert.SerializeObject(dict);
    Console.WriteLine(json);

  }
}
public class Student
{
  public Student(int id,string name,int age)
  {
    this.id = id;
    this.name = name;
    this.age = age;
  }
  public int id { get; set; }
  public string name { get; set; }
  public int age { get; set; }

  public override string ToString()
  {
    return id + "：" + name + "：" + age;
  }
}

