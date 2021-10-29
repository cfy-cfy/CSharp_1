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
        List<Student> list = new List<Student>();
        list.Add(new Student(1, "小明", 20));
        list.Add(new Student(2, "小李", 21));
        list.Add(new Student(3, "小赵", 22));

        Console.WriteLine("Hello Sunny : {0} ,{1} ,{2}",list[1].id,list[1].name,list[1].age);

        foreach(Student stu in list)
        {   Console.WriteLine(stu);
            Console.WriteLine("Hello World : {0} ,{1} ,{2}",stu.id,stu.name,stu.age);
        }

        for (int i=0;i<list.Count;i++)
        {
          Console.WriteLine("Hello Pretty : {0} ,{1} ,{2}",list[i].id,list[i].name,list[i].age);
        }
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
