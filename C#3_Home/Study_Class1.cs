using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace WindowsForms_Excel_1
{
	class Study_Class1
	{

	}
	//————————————————————————————————————————————————————1
	public class Book_0
	{
		private int id;
		private string name="哇哈哈";
		private double price;
		
		public int Id        //设置图书编号属性
		{
			get
			{
				return id;
			}
			set
			{
				id = value;
			}
		}
		
		public string Name   //设置图书名称属性
		{
			get
			{
				return name;
			}
		}
		
		public double Price  //设置图书价格属性 _ 需要判断
		{
			get
			{
				return price;
			}
			set
			{
				if (value >= 0)
				{
					price = value;
				}
				else
				{
					price = 0;
				}
			}
		}
	}

	//————————————————————————————————————————————————————2

	class Book
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public double Price { get; set; }

		public void SetBook(int id, string name, double price)
		{
			Id = id;
			Name = name;
			Price = price;
		}
		public void PrintMsg()
		{
			Debug.WriteLine("图书编号：" + Id);
			Debug.WriteLine("图书名称：" + Name);
			Debug.WriteLine("图书价格：" + Price);
		}
	}
	//————————————————————————————————————————————————————3
	//	这种方式也被称为自动属性设置。简化后图书类中的属性设置的代码如下。
	//        public int Id { get; set; }
	//	      public string Name { get; set; }
	//	      public double Price { get; set; }
	//	如果使用上面的方法来设置属性，则不需要先指定字段。如果要使用自动属性的方式来设置属性表示只读属性，直接省略 set 访问器即可。只读属性可以写成如下形式。
	//	      public int Id { get; } = 1;
	//	这里相当于将 Id 属性的值设置成 1，并且要以分号结束。但是，在使用自动生成属性的方法时不能省略 get 访问器，如果不允许其他类访问属性值，则可以在 get 访问器前面加上访问修饰符 private，代码如下。
	//	      public int Id { private get; set; }
	//	这样，Id 属性的 get 访问器只能在当前类中使用。

	class BookStatic     // 将类中的成员使用修饰符 static 声明，则在访问类成员时直接使用“类名.类成员”的方式即可。
	{
		public static int Id { get; set; }
		public static string Name { get; set; }
		public static double Price { get; set; }

		public static void SetBook(int id, string name, double price)
		{
			Id = id;
			Name = name;
			Price = price;
		}
		public static void PrintMsg()
		{
			Debug.WriteLine("图书编号：" + Id);
			Debug.WriteLine("图书名称：" + Name);
			Debug.WriteLine("图书价格：" + Price);
		}
	}

	//————————————————————————————————————————————————————4



	class User          // 在创建类的对象 user 时就调用了带参数的构造方法为属性赋值。
	{
		public User(string name, string password, string tel)
		{
			this.Name = name;
			this.Password = password;
			this.Tel = tel;
		}
		public string Name { get; set; }
		public string Password { get; set; }
		public string Tel { get; set; }

		public void PrintMsg()
		{
			Debug.WriteLine("用户名：" + this.Name);
			Debug.WriteLine("密  码：" + this.Password);
			Debug.WriteLine("手机号：" + Tel);
		}
	}

	//————————————————————————————————————————————————————5

	class SayHello   // 方法重载（函数重载）传递的参数不同，系统会自动识别参数来调用正确的方法。
	{
		public SayHello()
		{
			Console.WriteLine("Hello");
		}
		public SayHello(string name)
		{
			Debug.WriteLine("Hello " + name);
		}
		public SayHello(string name, int age)
		{
			Debug.WriteLine("Hello " + name + "，" + age);
		}
	}

	//—————————————————————————————————————————————— 6 【 return】

	class RefClass            // 返回结果 return
	{
		public bool Judge(ref int num)
		{
			if (num % 5 == 0)
			{
				return true;
			}
			return false;
		}
	}

	//————————————————————————————————————————————————7 【out】

	class OutClass           // 返回结果 out 
	{
		public void Judge(int num, out bool result)
		{
			if (num % 5 == 0)
			{
				result = true;
			}
			else
			{
				result = false;
			}
		}
	}

	//————————————————————————————————————————————————8 【匿名函数】

	class LambdaClass    // 匿名函数
	{
		public static int Add(int a, int b) => a + b;
		public static void ShowAdd(int a, int b) => Debug.WriteLine(a + b);
	}

	class LambdaClass_1    // 匿名函数
	{
		public  int Add(int a, int b) => a + b;
		public  void ShowAdd(int a, int b) => Debug.WriteLine(a + b);
	}

	//———————————————————————————————————————————————— 9 【递归】

	class FactorialClass  // 递归
	{
		public static int Factorial(int n)
		{
			if (n == 0)
			{
				return 1;
			}
			return n * Factorial(n - 1);
		}
	}

	//————————————————————————————————————————————————10 【嵌套类】
	class OuterClass     // 嵌套类
	{
		public class InnerClass
		{
			public string CardId { get; set; }
			public string Password { get; set; }
			public void PrintMsg()
			{
				Debug.WriteLine("卡号为：" + CardId);
				Debug.WriteLine("密码为：" + Password);
			}
		}
	}


	//——————————————————————————————————————————————11 【partial 部分类+方法】


	public partial class Course
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public double Points { get; set; }
		partial void PrintCourse();   // 部分方法是私有的，因此在 Course 类中添加一个打印方法 PrintMsg 来调用 PrintCourse 方法，以方便在其他类中调用。
		public void PrintMsg()        // 调用PrintCourse方法
		{
			PrintCourse();
		}
	}
	public partial class Course
	{
		public void PrintCoures()
		{
			Console.WriteLine("课程编号：" + Id);
			Console.WriteLine("课程名称：" + Name);
			Console.WriteLine("课程学分：" + Points);
		}
	}

	//——————————————————————————————————————————————12 【math 类】

	//Abs 取绝对值
	//Ceiling 返回大于或等于指定的双精度浮点数的最小整数值
	//Floor 返回小于或等于指定的双精度浮点数的最大整数值
	//Equals 返回指定的对象实例是否相等
	//Max 返回两个数中较大数的值
	//Min 返回两个数中较小数的值
	//Sqrt 返回指定数字的平方根
	//Round 返回四舍五入后的值

	public class MathClass            // math 类
	{
		public static void SubMath()
		{
			int num1 = 10, num2 = 20;
			
			Debug.WriteLine("两个数中较大的数为{0}", Math.Max(num1, num2));
			Debug.WriteLine("两个数中较小的数为{0}", Math.Min(num1, num2));
		}
	}

	//—————————————————————————————————————————————————13 【Random 类】

	//Next()  每次产生一个不同的随机正整数
	//Next(int max Value) 产生一个比 max Value 小的正整数
	//Next(int min Value, int max Value)   产生一个 minValue~maxValue 的正整数，但不包含 maxValue
	//NextDouble()    产生一个0.0~1.0的浮点数
	//NextBytes(byte[] buffer)    用随机数填充指定字节数的数组

	class RandomClass                // Random 类
	{
		public static void SubRandom()
		{
			Random rd = new Random();
			Debug.WriteLine("产生一个10以内的数：{0}", rd.Next(0, 10));
			Debug.WriteLine("产生一个0到1之间的浮点数：{0}", rd.NextDouble());
			byte[] b = new byte[5];
			rd.NextBytes(b);
			Debug.WriteLine("产生的byte类型的值为：");
			foreach (byte i in b)
			{
				Debug.WriteLine(i + " ");
			}
		}
	}

	//——————————————————————————————————————————————————14【DateTime】
	//DateTime.Now
	//Date 获取实例的日期部分
	//Day 获取该实例所表示的日期是一个月的第几天
	//DayOfWeek 获取该实例所表示的日期是一周的星期几
	//DayOfYear 获取该实例所表示的日期是一年的第几天
	//Add(Timespan value) 在指定的日期实例上添加时间间隔值 value
	//AddDays(double value)   在指定的日期实例上添加指定天数 value
	//AddHours(double value)  在指定的日期实例上添加指定的小时数 value
	//AddMinutes(double value)    在指定的日期实例上添加指定的分钟数 value
	//AddSeconds(double value)    在指定的日期实例上添加指定的秒数 value
	//AddMonths(int value)    在指定的日期实例上添加指定的月份 value
	//AddYears(int value)    在指定的日期实例上添加指定的年份 value


	public class DateTimeClass   // DateTime 类用于表示时间，所表示的范围是从 0001 年 1 月 1 日 0 点到 9999 年 12 月 31 日 24 点。

	{
		public static void SubDateTime()
		{
			DateTime dt = DateTime.Now;
			Debug.WriteLine("当前日期为：{0}", dt);
			Debug.WriteLine("当前时本月的第{0}天", dt.Day);
			Debug.WriteLine("当前是：{0}", dt.DayOfWeek);
			Debug.WriteLine("当前是本年度第{0}天", dt.DayOfYear);
			Debug.WriteLine("30 天后的日期是{0}", dt.AddDays(30));
		}
	}

	//————————————————————————————————————————————————————

}
