using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace WindowsForms_Excel_1
{
	class Study_Class2
	{

	}

	class Study_Student
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Sex { get; set; }
		public string Cardid { get; set; }
		public string Tel { get; set; }
		public string Major { get; set; }
		public string Grade { get; set; }
		public void Print()
		{
			Debug.WriteLine("编号：" + Id);
			Debug.WriteLine("姓名：" + Name);
			Debug.WriteLine("性别：" + Sex);
			Debug.WriteLine("身份证号：" + Cardid);
			Debug.WriteLine("联系方式：" + Tel);
			Debug.WriteLine("专业：" + Major);
			Debug.WriteLine("年级：" + Grade);
		}
	}

	class Study_Person
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Sex { get; set; }
		public string Cardid { get; set; }
		public string Tel { get; set; }
		public void Print()
		{
			Debug.WriteLine("编号：" + Id);
			Debug.WriteLine("姓名：" + Name);
			Debug.WriteLine("性别：" + Sex);
			Debug.WriteLine("身份证号：" + Cardid);
			Debug.WriteLine("联系方式：" + Tel);
		}
	}

	//——————————————————————————————— 1【 base】

	// 用户在程序中会遇到 this 和 base 关键字，this 关键字代表的是当前类的对象，而 base 关键字代表的是父类中的对象。
	// 在 C# 语言中子类中定义的同名方法相当于在子类中重新定义了一个方法，在子类中的对象是调用不到父类中的同名方法的，
	// 调用的是子类中的方法。因此也经常说成是将父类中的同名方法隐藏了。

	class Study_Student_1 : Study_Person        // 继承
	{
		public string Major { get; set; }
		public string Grade { get; set; }

		public void Print_1()
		{
			Debug.WriteLine("Study_Student_1专业：" + Major);
			Debug.WriteLine("年级：" + Grade);
		}
		public void Print()
		{
			base.Print();         // 通过 base 关键字调用 Print 方法即可调用在父类中定义的语句。
			Id = 1234;
			Debug.WriteLine("Study_Perseon 专业：" + Id);         // person 的属性

			Debug.WriteLine("Study_Student_2专业：" + Major);     // student 的属性
			Debug.WriteLine("年级：" + Grade);
		}
	}
	//——————————————————————————————— 2【virtual + override 关键字详解】

	public class Person
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Sex { get; set; }
		public string Cardid { get; set; }
		public string Tel { get; set; }
		public string Major { get; set; }
		public string Grade { get; set; }

		public virtual void Print()
		{
			Console.WriteLine("编号：" + Id);
			Console.WriteLine("姓名：" + Name);
			Console.WriteLine("性别：" + Sex);
			Console.WriteLine("身份证号：" + Cardid);
			Console.WriteLine("联系方式：" + Tel);
		}
	}

	public class Student : Person
	{
		public string Interest { get; }="哇哈哈";

		public override void Print()
		{
			Id = 4321;
			Console.WriteLine("编号：" + Id);        // person 的属性
			Console.WriteLine("姓名：" + Name);
			Console.WriteLine("性别：" + Sex);
			Console.WriteLine("身份证号：" + Cardid);
			Console.WriteLine("联系方式：" + Tel);
			Console.WriteLine("专业：" + Major);
			Console.WriteLine("年级：" + Grade);
			Console.WriteLine("年级：" + Interest);   // student 的属性

		}
	}
	//———————————————————————— ———————
	class Student_1 : Person
	{
		public override void Print()
		{
			base.Print();
			Console.WriteLine("专业：" + Major);
			Console.WriteLine("年级：" + Grade);
		}
	}

	//———————————————————————————————  子类、父类互转

	public class A
	{
		public virtual void Print()
		{
			Console.WriteLine("A");
		}
	}
	public class B : A
	{
		public new void Print()
		{
			Console.WriteLine("B");
		}
	}
	public class C : A
	{
		public override void Print()
		{
			Console.WriteLine("C");
		}
	}

	//———————————————————————————————3 【重写 ToString 方法】
	// 在类中也可以重写 Equals 方法、GetHashCode 方法。
	// Object 类中的 ToString 方法能被类重写，并返回所需的字符串，通常将其用到类中返回类中属性的值。
	// 在 Student 类中添加重写的 ToString 方法，代码如下。

	class Student_3
	{
		public string Major { get; set; }
		public string Grade { get; set; }
		public void Print()
		{

			Console.WriteLine("专业：" + Major);
			Console.WriteLine("年级：" + Grade);
		}
		public override string ToString()
		{
			return Major + "," + Grade;
		}
	}

	//———————————————————————————————4【 abstract + override】
	// 在 C# 语言中抽象方法是一种不带方法体的方法，仅包含方法的定义
	// 子类仅能重写父类中的虚方法virtual 或者抽象方法 abstract，当不需要使用父类中方法的内容时，将其定义成抽象方法，
	// 否则将方法定义成虚方法。

	abstract class ExamResult
	{
		//学号
		public int Id { get; set; }
		//数学成绩
		public double Math { get; set; }
		//英语成绩
		public double English { get; set; }
		//计算总成绩
		public abstract void Total();
	}
	class MathMajor : ExamResult
	{
		public override void Total()
		{
			double total = Math * 0.6 + English * 0.4;
			Console.WriteLine("学号为" + Id + "数学专业学生的成绩为：" + total);
		}
	}
	class EnglishMajor : ExamResult
	{
		public override void Total()
		{
			double total = Math * 0.4 + English * 0.6;
			Console.WriteLine("学号为" + Id + "英语专业学生的成绩为：" + total);
		}
	}
	//————————————————————//
	public class AbstractProgram
	{
		public static void SubAbstract()
		{ 
			Major major1 = new Undergraduate();
			major1.Id = 1;
			major1.Name = "张晓";
			Console.WriteLine("本科生信息：");
			Console.WriteLine("学号：" + major1.Id + "姓名：" + major1.Name);
			major1.Requirement();
			Major major2 = new Graduate();
			major2.Id = 2;
			major2.Name = "李明";
			Console.WriteLine("研究生信息：");
			Console.WriteLine("学号：" + major2.Id + "姓名：" + major2.Name);
			major2.Requirement();
		}
	}
	public abstract class Major
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public abstract void Requirement();
	}
	public class Undergraduate : Major
	{
		public override void Requirement()
		{
			Console.WriteLine("本科生学制4年，必须修满48学分");
		}
	}
	public class Graduate : Major
	{
		public override void Requirement()
		{
			Console.WriteLine("研究生学制3年，必须修满32学分");
		}
	}



	//————————————————————————————————5 【 sealed：声明密封类或密封方法】

	// C# sealed 关键字的含义是密封的，使用该关键字能修饰类或者类中的方法，修饰的类被称为密封类、修饰的方法被称为密封方法。
	//但是密封方法必须出现在子类中，并且是子类重写的父类方法，即 sealed 关键字必须与 override 关键字一起使用。
	//密封类不能被继承，密封方法不能被重写。在实际应用中，在发布的软件产品里有些类或方法不希望再被继承或重写，
	//可以将其定义为密封类或密封方法。

	// Circle 类不能被继承，Rectangle 类中的 Area 方法不能被重写
	abstract class AreaAbstract
	{
		public abstract void Area();
	}
	class Rectangle : AreaAbstract
	{
		public double Width { get; set; }
		public double Length { get; set; }
		public sealed override void Area()
		{
			Console.WriteLine("矩形的面积是：" + Width * Length);
		}
	}
	sealed class Circle : AreaAbstract
	{
		public double r { get; set; }
		public override void Area()
		{
			Console.WriteLine("圆的面积是：" + r * 3.14 * 3.14);
		}
	}

	//———————————————————————————————— 6 【继承关系中构造器之间的关系】
	// 在创建子类的实例时，先执行父类 A 中的无参构造器，再执行子类 B 中的无参构造器。

	public class AA
	{
		public AA()
		{
			Console.WriteLine("A类的构造器");
		}
	}
	public class BB : AA
	{
		public BB()
		{
			Console.WriteLine("B类的构造器");
		}

	}
	//——————————————————————————————
	// 尽管在子类中调用了带参数的构造器，也会先调用其父类中的无参构造器。
	public class AAA
	{
		public AAA()
		{
			Console.WriteLine("A类的构造器");
		}
	}
	public class BBB : AAA
	{
		public BBB()
		{
			Console.WriteLine("B类的构造器");
		}

		public BBB(string name)
		{
			Console.WriteLine("B类中带参数的构造器，传入的值为：" + name);
		}

	}
	//————————————————————————————————
	// 默认情况下，在子类的构造器中都会自动调用父类的无参构造器，
	// 如果需要调用父类中带参数的构造器才使用“:base(参数)”的形式。
	// 实际上这也是子类和父类中构造器的一种继承关系表示

	class AAAA
	{
		public AAAA()
		{
			Console.WriteLine("A类的构造器");
		}
		public AAAA(string name)
		{
			Console.WriteLine("A类的构造器，传入的值为：" + name);
		}
	}
	class BBBB : AAAA
	{
		public BBBB()
		{
			Console.WriteLine("B类的构造器");
		}
		public BBBB(string name) : base(name)    // 调用父类中带参数的构造器
		{
			Console.WriteLine("B类中带参数的构造器，传入的值为：" + name);
		}
	}
	

}
