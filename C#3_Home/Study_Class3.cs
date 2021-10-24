using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// https://www.cnblogs.com/sggggr/p/11847731.html
namespace WindowsForms_Excel_1
{
	class Study_Class3
	{
	}

	public class BaseClass
	{
		int num;
		public BaseClass()
		{
			Console.WriteLine("in BaseClass()");
		}
		public BaseClass(int i)
		{
			num = i;
			Console.WriteLine("in BaseClass(int {0})", num);
		}
	}
	public class DerivedClass : BaseClass
	{
		// 该构造器调用  BaseClass.BaseClass()
		public DerivedClass()
			: base()
		{
		}
		// 该构造器调用 BaseClass.BaseClass(int i)
		public DerivedClass(int i)
			: base(i)
		{
		}

	}
}
