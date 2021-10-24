using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace WindowsForms_Excel_1
{
	class enum_struct_C1
	{

	}
	//=============================================================================== 1【enum】
	public class EnumTest_1
	{
		public enum Title : int   // 由于没有给枚举值设置初始的整数值，初始的整数值是从 0 开始的，并且依次递增 1。
		{
			助教,
			讲师,
			副教授,
			教授
		}

		public enum Title_1 : int  // 当助教的值为 1 时，讲师的值为 2，而由于副教授的值被设置为 4，则教授的值为 5。
		{
			助教 = 1,
			讲师,
			副教授 = 4,
			教授
		}
	}
	//————————————————————————————————————————————
	public enum Title : int   // 由于没有给枚举值设置初始的整数值，初始的整数值是从 0 开始的，并且依次递增 1。
	{
		助教=1,
		讲师,
		副教授=2,
		教授
	}

	//=============================================================================== 2【struct】
		//	结构体与类有些类似，但其定义却有很大区别，具体如下表所示。

		//结构体                      类
		//允许不使用new对其实例化  必须使用new实例化
		//没有默认构造方法         有默认构造方法
		//不能继承类               能继承类
		//没有析构方法             有析构方法
		//不允许使用abstract、protected以及sealed修饰    允许使用abstract、protected以及sealed修饰

	public class StructClass
	{
		public static void SubStruct_1()
		{
			student stu = new student();
			stu.Name = "张三";
			stu.Age = 100;
			Debug.WriteLine("学生的信息为：");
			Debug.WriteLine(stu.Name + "：" + stu.Age);
		}

		public struct student
		{
			private string name;
			private int age;
			public string Name
			{
				get
				{
					return name;
				}
				set
				{
					name = value;
				}
			}
			public int Age
			{
				get
				{
					return age;
				}
				set
				{
					if (value < 0)
					{
						value = 0;
					}
					else
					{
						age = value;
					}
				}
			}

		}
	}
	//————————————————————————————————————————————
	public struct student
	{
		private string name;
		private int age;
		public string Name
		{
			get
			{
				return name;
			}
			set
			{
				name = value;
			}
		}
		public int Age
		{
			get
			{
				return age;
			}
			set
			{
				if (value < 0)
				{
					value = 0;
				}
				else
				{
					age = value;
				}
			}
		}

	}
	//————————————————————————————————————————————

	public struct student_1
	{
		public student_1(string name, int age)
		{
			this.name = name;
			this.age = age;
		}
		private string name;
		private int age;
		public void PrintStudent()
		{
			Debug.WriteLine("姓名：" + name);
			Debug.WriteLine("年龄：" + age);
		}
	}


	//————————————————————————————————————————————

}
