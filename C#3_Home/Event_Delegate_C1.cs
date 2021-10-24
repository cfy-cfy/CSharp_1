using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace WindowsForms_Excel_1
{
	class Event_Delegate_C1
	{

	}

	//——————————————————————————————————————  1【命名方法委托】
	public class DelegateClass
	{
		public delegate void MyDelegate();

		public static void SubDelegate()
		{
			MyDelegate myDelegate = new MyDelegate(DelegateTest.SubSayHello);                // 委托中使用的是静态方法
			myDelegate();

		}
		public static void instanceDelegate()
		{ 
			MyDelegate myDelegate_1 = new MyDelegate(new DelegateTest().instanceSayHello);   // 委托中使用的是实例方法
			myDelegate_1();
		}
	}

	public class DelegateTest
	{
		public static void SubSayHello()
		{
			Console.WriteLine("Hello Delegate_1!");
		}
		public void instanceSayHello()
		{
			Console.WriteLine("Hello Delegate_22!");
		}
	}

	//—————————————————————————— 带参数
	public class DBook : IComparable<DBook>
	{
		//定义构造方法为图书名称和价格赋值
		public DBook(string name, double price)
		{
			Name = name;
			Price = price;
		}
		public string Name { get; set; }
		public double Price { get; set; }
		
		public int CompareTo(DBook other)      // 实现比较器中比较的方法
		{
			return (int)(this.Price - other.Price);   // 升序
			//return (int)(other.Price - this.Price); // 降序
		}
		
		public override string ToString()      // 重写ToString方法，返回图书名称和价格
		{
			return Name + ":" + Price;
		}
		
		public static void BookSort(DBook[] books)  // 图书信息排序
		{
			Array.Sort(books);
		}
	}

	public class DelegateBookClass
	{
		//定义对图书信息排序的委托
		public delegate void BookDelegate(DBook[] books);
		public static void SubBook()
		{
			BookDelegate bookDelegate = new BookDelegate(DBook.BookSort);
			DBook[] book = new DBook[3];
			book[0] = new DBook("计算机应用", 50);
			book[1] = new DBook("C# 教程", 59);
			book[2] = new DBook("VS2015应用", 49);
			bookDelegate(book);
			foreach (DBook bk in book)
			{
				Console.WriteLine(bk);
			}
		}
	}

	//——————————————————————————————————————  2【多播委托】

	//在 C# 语言中多播委托是指在一个委托中注册多个方法，在注册方法时可以在委托中使用加号运算符或者减号运算符来实现添加或撤销方法。
	//在现实生活中，多播委托的实例是随处可见的，例如某点餐的应用程序，既可以预定普通的餐饮也可以预定蛋糕、鲜花、水果等商品。
	//在这里委托相当于点餐平台，每一个类型的商品可以理解为在委托上注册的一个方法。

	public class OrderDelegateClass
	{
		//定义购买商品委托
		public delegate void OrderDelegate();
		public static void SubOrder()
		{
			//实例化委托
			OrderDelegate orderDelegate = new OrderDelegate(Order.BuyFood);
			//向委托中注册方法
			orderDelegate += Order.BuyCake;
			orderDelegate += Order.BuyFlower;

			//撤销购买鲜花操作
			orderDelegate -= Order.BuyFlower;
			//调用委托
			orderDelegate();
		}
	}

	public class Order
	{
		public static void BuyFood()
		{
			Console.WriteLine("购买快餐！");
		}
		public static void BuyCake()
		{
			Console.WriteLine("购买蛋糕！");
		}
		public static void BuyFlower()
		{
			Console.WriteLine("购买鲜花！");
		}
	}
	//——————————————————————————————————————  3【匿名委托】

	//	在 C# 语言中匿名委托是指使用匿名方法注册在委托上，实际上是在委托中通过定义代码块来实现委托的作用，具体的语法形式如下。
	////1. 定义委托
	//修饰符 delegate 返回值类型 委托名(参数列表 );

	//	//2. 定义匿名委托
	//	委托名 委托对象 = delegate
	//	{
	//		//代码块
	//	};

	//	//3. 调用匿名委托
	//	委托对象名(参数列表 );

	//	通过上面 3 个步骤即可完成匿名委托的定义和调用，需要注意的是，在定义匿名委托时代码块结束后要在 {}后加上分号。


	//在使用匿名委托时并没有定义方法，而是在实例化委托时直接实现了具体的操作。
	//由于匿名委托并不能很好地实现代码的重用，匿名委托通常适用于实现一些仅需要使用一次委托中代码的情况，并且代码比较少。
	public class LamDelegate
	{
		public delegate void AreaDelegate(double length, double width);
		public static void SubLamDelegate()
		{
			Console.WriteLine("请输入长方形的长：");
			double length = double.Parse("100");
			Console.WriteLine("请输入长方形的宽：");
			double width = double.Parse("200");

			AreaDelegate areaDelegate = delegate
			{
				Console.WriteLine("长方形的面积为：" + length * width);
			};
			areaDelegate(length, width);
		}
	}

	//——————————————————————————————————————  4【事件：Event】
	//在 C# 语言中，Windows 应用程序、 ASP.NET 网站程序等类型的程序都离不开事件的应用。

	//事件是一种引用类型，实际上也是一种特殊的委托。

	//通常，每一个事件的发生都会产生发送方和接收方，发送方是指引发事件的对象，接收方则是指获取、处理事件。事件要与委托一起使用。

	//事件定义的语法形式如下。
	//访问修饰符 event 委托名 事件名;

	//	在这里，由于在事件中使用了委托，因此需要在定义事件前先定义委托。

	//在定义事件后需要定义事件所使用的方法，并通过事件来调用委托。


	public class EventClass //———————————————————————— event 和 delegate 在同类
	{
		
		public delegate void SayDelegate(); //定义委托
											
		public event SayDelegate SayEvent;  //定义事件
										   
		public void SayHello()              //定义委托中调用的方法
		{
			Console.WriteLine("Hello Event！");
		}
		
		public void SayEventTrigger()       //创建触发事件的方法
		{
			SayEvent();                     //触发事件，必须与事件是同名方法

		}
		public static void SubEvent()
		{
			EventClass program = new EventClass();  //创建Program类的实例
											  
			program.SayEvent = new SayDelegate(program.SayHello);  //实例化事件，使用委托指向处理方法
																   
			program.SayEventTrigger();               //调用触发事件的方法
			
		}
	}

	//———————————————————————— event 和 delegate 在不同类
		//在使用事件时如果事件的定义和调用不在同一个类中，实例化的事件只能出现在+=或者-=操作符的左侧。
	public class EventDelegate
	{
		public static void SubEventDelegate()
		{
			
			MyEvent myEvent = new MyEvent();  //创建MyEvent类的实例
											  //实例化事件，使用委托指向处理方法
			myEvent.BuyEvent += new MyEvent.BuyDelegate(MyEvent.BuyFood);
			myEvent.BuyEvent += new MyEvent.BuyDelegate(MyEvent.BuyCake);
			myEvent.BuyEvent += new MyEvent.BuyDelegate(MyEvent.BuyFlower);
	
			myEvent.InvokeEvent();   //调用触发事件的方法
		}

	}
	public class MyEvent
	{
		
		public delegate void BuyDelegate();  // 定义委托
											
		public event BuyDelegate BuyEvent;   // 定义事件

		public static void BuyFood()        // 定义委托中使用的方法
		{
			Console.WriteLine("购买快餐！");
		}
		public static void BuyCake()
		{
			Console.WriteLine("购买蛋糕！");
		}
		public static void BuyFlower()
		{
			Console.WriteLine("购买鲜花！");
		}
		//创建触发事件的方法
		public void InvokeEvent()
		{
			//触发事件，必须和事件是同名方法
			BuyEvent();
		}
	}

}
