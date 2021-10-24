using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

//接口与抽象类的区别入下表所示。

// 【接口】 在接口中仅能定义成员，但不能有具体的实现。
// 【抽象类】 抽象类除了抽象成员以外，其他成员允许有具体的实现。
// 【接口】 在接口中不能声明字段，并且不能声明任何私有成员，成员不能包含任何修饰符。
// 【抽象类】在抽象类中能声明任意成员，并能使用任何修饰符来修饰。
// 【接口】 接口能使用类或者结构体来继承。	
// 【抽象类】抽象类仅能使用类继承。
// 【接口】 在使用类来实现接口时，必须隐式或显式地实现接口中的所有成员，否则需要将实现类定义为抽象类，并将接口中未实现的成员以抽象的方式实现。	
// 【抽象类】在使用类来继承抽象 类时允许实现全部或部分成员，但仅实现其中的部分成员，其实现类必须也定义为抽象类。
// 【接口】 一个接口允许继承多个接口。	
// 【抽象类】一个类只能有一个父类。

namespace WindowsForms_Excel_1
{
	class Interface_C1
	{
	}
	// 1) 接口名称
	//	通常是以 I 开头，再加上其他的单词构成。例如创建一个计算的接口，可以命名为 ICompute。
	//2) 接口成员
	//接口中定义的成员与类中定义的成员类似。

	//接口中定义的成员必须满足以下要求。
	//接口中的成员不允许使用 public、private、protected、internal 访问修饰符。
	//接口中的成员不允许使用 static、virtual、abstract、sealed 修饰符。
	//在接口中不能定义字段。
	//在接口中定义的方法不能包含方法体。

//————————————————————————————————————————————————————
	interface ITest
	{
		string name { get; set; }
		void Print();
	}

	// 在实现类 Test 中将未实现的属性和方法分别定义为抽象属性和抽象方法，并将实现类定义为抽象类。

	abstract class Test : ITest     
	{
		public abstract string name { get; set; }
		public abstract void Print();
	}

	//——————————————————————————————————————— 【隐】式的实现接口中的属性/方法
	interface ICompute
	{
		int Id { get; set; }
		string Name { get; set; }
		void Total();
		void Avg();
	}

	// 所有接口中的成员在实现类 ComputerMajor 中都被 public 修饰符修饰。
	class ComputerMajor : ICompute
	{
		public int Id { get; set; }         // 隐式的实现接口中的属性
		public string Name { get; set; }    // 隐式实现接口中的属性
		public double English { get; set; }
		public double Programming { get; set; }
		public double Database { get; set; }
		public void Avg()       // 隐式实现接口中的方法
		{
			double avg = (English + Programming + Database) / 3;
			Console.WriteLine("平均分：" + avg);
		}
		public void Total()      // 隐式实现接口中的方法
		{
			double sum = English + Programming + Database;
			Console.WriteLine("总分为：" + sum);
		}
	}

	public class ComputerClass
	{
		public static void SubComputer()
		{
			ComputerMajor computerMajor = new ComputerMajor();
			computerMajor.Id = 1;
			computerMajor.Name = "李明";
			computerMajor.English = 80;
			computerMajor.Programming = 90;
			computerMajor.Database = 85;
			Console.WriteLine("学号：" + computerMajor.Id);
			Console.WriteLine("姓名：" + computerMajor.Name);
			Console.WriteLine("成绩信息如下：");
			computerMajor.Total();
			computerMajor.Avg();
		}
	}
	//——————————————————————————————————————— 【显】式的实现接口中的属性/方法

	// 在使用显式方式实现接口中的成员时，所有成员都会加上接口名称 ICompute 作为前缀，并且不加任何修饰符。
	class ComputerMajor_1 : ICompute
	{
		public double English { get; set; }
		public double Programming { get; set; }
		public double Database { get; set; }
		int ICompute.Id { get; set; }           // 显示实现接口中的属性
		string ICompute.Name { get; set; }      // 显示实现接口中的属性
		void ICompute.Total()                   // 显示实现接口中的方法
		{
			double sum = English + Programming + Database;
			Console.WriteLine("总分数：" + sum);
		}
		void ICompute.Avg()                     // 显示实现接口中的方法
		{
			double avg = (English + Programming + Database) / 3;
			Console.WriteLine("平均分为：" + avg);
		}
	}

	// 在调用显式方式实现接口的成员时，必须使用接口的实例来调用，而不能使用实现类的实例来调用。
	public class ComputerClass_1
	{
		public static void SubComputer_1()
		{
			ComputerMajor_1 computerMajor_1 = new ComputerMajor_1();
			ICompute compute = computerMajor_1;       //创建接口的实例
			compute.Id = 1;
			compute.Name = "李明";
			computerMajor_1.English = 80;
			computerMajor_1.Programming = 90;
			computerMajor_1.Database = 85;
			Console.WriteLine("学号：" + compute.Id);
			Console.WriteLine("姓名：" + compute.Name);
			Console.WriteLine("成绩信息如下：");
			compute.Total();
			compute.Avg();
		}
	}

	//———————————————————————————————————————  接口中多态的实现
	interface ITest_1
	{
		void methodA();
	}
	class Test1 : ITest_1
	{
		public void methodA()
		{
			Console.WriteLine("Test1 类中的 methodA 方法");
		}
	}
	class Test2 : ITest_1
	{
		public void methodA()
		{
			Console.WriteLine("Test2 类中的 methodA 方法");
		}
	}

	public class TestClass
	{
		public static void SubTest()
		{
			ITest_1 test1 = new Test1();  //创建接口的实例test1指向实现类Test1的对象
			test1.methodA();
			ITest_1 test2 = new Test2();  //创建接口的实例test2指向实现类Test2的对象
			test2.methodA();
		}
	}

	//———————————————————————————————
	interface IShape
	{
		double Area { get; }
		double X { get; set; }
		double Y { get; set; }
		string Color { get; set; }
		void Draw();
	}

	public class Rectangle_1 : IShape
	{
		//为矩形的长和宽赋值
		public Rectangle_1(double length, double width)
		{
			this.Length = length;
			this.Width = width;
		}
		public double Length { get; set; }//定义长方形的长度
		public double Width { get; set; }//定义长方形的宽度
		public double Area
		{
			get
			{
				return Length * Width;//计算长方形面积
			}
		}
		public string Color { get; set; }
		public double X { get; set; }
		public double Y { get; set; }
		public void Draw()
		{
			Console.WriteLine("绘制图形如下：");
			Console.WriteLine("在坐标 {0},{1} 的位置绘制面积为 {2} 颜色为 {3} 的矩形", X, Y, Area, Color);
		}
	}

	public class RectClass
	{
		public static void SubRect()
		{
			IShape shape1 = new Rectangle_1(10, 20);
			shape1.X = 100;
			shape1.Y = 200;
			shape1.Color = "红色";
			shape1.Draw();
		}
		public static void SubRect_1()
		{
			Rectangle_1 rectangle = new Rectangle_1(10,30);
			IShape shape1 = rectangle;        // 创建接口的实例
			shape1.X = 100;
			shape1.Y = 200;
			shape1.Color = "红色";
			shape1.Draw();
		}
	}



}
