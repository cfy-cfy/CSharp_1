using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Collections;

namespace WindowsForms_Excel_1
{
	class Collection_C1
	{

	}

	// 集合与数组比较类似，都用于存放一组值，但集合中提供了特定的方法能直接操作集合中的数据，
	// 并提供了不同的集合类来实现特定的功能。
	// 集合简单的说就是数组的升级版。他可以动态的对集合的长度（也就是集合内最大元素的个数）进行定义和维护！
	// 所有集合类或与集合相关的接口命名空间都是 System.Collection，在该命名空间中提供的常用接口如下表所示。

	// IEnumerable 用于迭代集合中的项，该接口是一种声明式的接口
	// IEnumerator 用于迭代集合中的项，该接口是一种实现式的接口
	// ICollection.NET 提供的标准集合接口，所有的集合类都会直接或间接地实现这个接口
	// IList   继承自 IEnumerable 和 ICollection 接口，用于提供集合的项列表，并允许访问、查找集合中的项
	// IDictionary 继承自 IEnumerable 和 ICollection 接口，与 IList 接口提供的功能类似，但集 合中的项是以键值对的形式存取的
	// IDictionaryEnumerator 用于迭代 IDictionary 接口类型的集合


	//类名称 实现接口    特点
	//ArrayList   ICollection、IList、IEnumerable、ICloneable 集合中元素的个数是可变的，提供添加、删除等方法
	//Queue   ICollection、IEnumerable、ICloneable 集合实现了先进先出的机制，即元素将在集合的尾部添加、在集合的头部移除
	//Stack   ICollection、IEnumerable、ICloneable 集合实现了先进后出的机制，即元素将在集合的尾部添加、在集合的尾部移除
	//Hashtable   IDictionary、ICollection、IEnumerable、 ICloneable 等接口 集合中的元素是以键值对的形式存放的，是 DictionaryEntry 类型的
	//SortedList  IDictionary、ICollection、IEnumerable、  ICloneable 等接口    与 Hashtable 集合类似，集合中的元素以键值对的形式存放，不同的是该集合会按照 key 值自动对集合中的元素排序



	//==================>>>>>>>>>>==================>>>>>>>>>> ==================>>>>>>>>>>  1【ArrayList类：动态数组】

		//C# ArrayList 类（动态数组）是一个最常用的集合类，与数组的操作方法也是最类似的。
		//ArrayList 代表了可被单独索引的对象的有序集合。它基本上可以替代一个数组。
		//但是，与数组不同的是，ArrayList 可以使用索引在指定的位置添加和移除项目，动态数组会自动重新调整它的大小。
		//同时 ArrayList 也允许在列表中进行动态内存分配、增加、搜索、排序各项。
		//创建 ArrayList 类的对象需要使用该类的构造方法，如下表所示。

		//构造方法 作用
		//ArrayList() 创建 ArrayList 的实例，集合的容量是默认初始容量
		//ArrayList(ICollection c)    创建 ArrayList 的实例，该实例包含从指定实例中复制的元素，并且初始容量与复制的元素个数相同
		//ArrayList(int capacity) 创建 ArrayList 的实例，并设置其初始容量


		//下面分别使用 ArrayList 类的构造器创建 ArrayList 实例，代码如下。
		//ArrayList listl=new ArrayList();
		//ArrayList list2 = new ArrayList(listl);
		//ArrayList list3 = new ArrayList(20);
		//在创建 ArrayList 类的实例后，集合中还未存放值。

		//在 C# 语言中提供了集合初始化器，允许在创建集合实例时向集合中添加元素，代码如下。
		//ArrayList list4 = new ArrayList() { l, 2, 3, 4 };

	// ——————【ArrayList 类中常用的属性和方法如下表所示】

		//属性或方法 作用
		//int Add(object value)   向集合中添加 object 类型的元素，返回元素在集合中的下标
		//void AddRange(ICollection c)    向集合中添加另一个集合 c
		//Capacity 属性，用于获取或设置集合中可以包含的元素个数
		//void Clear()    从集合中移除所有元素
		//bool Contains(object item)  判断集合中是否含有 item 元素，若含有该元素则返回 True, 否则返回 False
		//void CopyTo(Array array)    从目标数组 array 的第 0 个位置开始，将整个集合中的元素复制到类型兼容的数组 array 中
		//void CopyTo(Array array, int arraylndex) 从目标数组 array 的指定索引 arraylndex 处，将整个集合中的元素赋值到类型兼容的数组 array 中
		//void CopyTo(int index, Array array, int arrayIndex, int count) 从目标数组 array 的指定索引 arrayindex 处，将集合中从指定索引 index 开始的 count 个元素复制到类型兼容的数组 array 中
		//Count   属性，用于获取集合中实际含有的元素个数
		//int IndexOf(object value)   返回 value 值在集合中第一次出现的位置
		//int IndexOf(object value, int startIndex)    返回 value 值在集合的 startindex 位置开始第一次出现的位置
		//int IndexOf(object value, int startIndex, int count)  返回 value 值在集合的 startindex 位置开始 count 个元素中第一次出现的位置
		//int LastIndexOf(object value)   返回 value 值在集合中最后一次出现的位置
		//int LastIndexOf(object value, int startIndex)    返回 value 值在集合的 startindex 位置开始最后一次出现的位置
		//int LastIndexOf(object value, int startIndex, int count)  入元素 value值在集合的 startindex 位置开始 count 个元素中最后一次出现的位置
		//void Insert(int index, object value) 返回 value 向集合中的指定索引 index 处插
		//void InsertRange(int index, ICollection c)   向集合中的指定索引 index 处插入一个集合
		//void Remove(object obj) 将指定兀素 obj 从集合中移除
		//void RemoveAt(int index)    移除集合中指定位置 index 处的元素
		//void RemoveRange(int index, int count)   移除集合中从指定位置 index 处的 count 个元素
		//void Reverse()  将集合中的元素顺序反转
		//void Reverse(int index, int count)   将集合中从指定位置 index 处的 count 个元素反转
		//void Sort() 将集合中的元素排序，默认从小到大排序
		//void Sort(IComparer comparer)   将集合中的元素按照比较器 comparer 的方式排序
		//void Sort(int index, int count, IComparer comparer)   将集合中的元素从指定位置 index 处的 count 个元素按照比较器 comparer 的方式排序
		//void TrimToSize()   将集合的大小设置为集合中元素的实际个数

	public class ArrayListClass
	{
		public static void SubArrayList_indexof()
		{
			ArrayList list = new ArrayList() { "aaa", "bbb", "abc", 123, 456 };
			int index = list.IndexOf("abc");    // ————————————>>>>>>>>>>>>   IndexOf
			if (index != -1)
			{
				Console.WriteLine("集合中存在 abc 元素！");
			}
			else
			{
				Console.WriteLine("集合中不存在 abc 元素！");
			}
		}
		public static void SubArrayList_Add() // ————————————>>>>>>>>>>>>   add
		{
			ArrayList list = new ArrayList() { "aaa", "bbb", "abc", 123, 456 };
			ArrayList newList = new ArrayList();
			for (int i = 0; i < list.Count; i++)
			{
				newList.Add(list[i]);
			}

			//由于在集合中存放的值允许是任意类型，能使用 var 关键字来定义任意类型的变量。
			foreach (var v in newList)
			{
				Console.WriteLine(v);
			}

		}

		public static void SubArrayList_InsertRange() // ————————————>>>>>>>>>>>>   InsertRange
		{
			ArrayList list = new ArrayList() { "aaa", "bbb", "abc", 123, 456 };
			ArrayList insertList = new ArrayList() { "A", "B", "C" };
			list.InsertRange(3, insertList);
			foreach (var v in list)
			{
				Console.WriteLine(v);
			}
		}

		public static void SubArrayList_Sort() // ————————————>>>>>>>>>>>> sort + Reverse 方法将元素倒置。
		{
			//ArrayList list = new ArrayList() { "aaa", "bbb", "abc" };   // sort 只能 字符串之间排序
			ArrayList list = new ArrayList() { 4, 1, 6, 2 };              // sort 只能数值 字符串之间排序
			list.Sort();
			foreach (var v in list)
			{
				Console.WriteLine(v);
			}
		}
	}

	//————————————————————————————————>>>>>>>>>> 2【IComparer】 数值+字符串的排序

		// 字符串类型的值不能直接使用大于、小于的方式比较，要使用字符串的 CompareTo 方法，该方法的返回值是 int 类型
	class MyCompare : IComparer
	{
		public int Compare(object x, object y)
		{
			string str1 = x.ToString();
			string str2 = y.ToString();
			return str1.CompareTo(str2);
		}
	}

	public class MyCompareClass
	{
		public static void SubMyCompare()
		{
			ArrayList list = new ArrayList() { "a", 1, "b", "c", 2 };
			MyCompare myCompare = new MyCompare();  // 创建自定义比较器实例
			list.Sort(myCompare);
			foreach (var v in list)
			{
				Console.WriteLine(v);
			}
		}
	}

	//==================>>>>>>>>>>==================>>>>>>>>>> ==================>>>>>>>>>> 3 【Queue类：队列】

		//C# Queue (队列) 是常见的数据结构之一，队列是一种先进先出的结构，即元素从队列尾部插入，从队列的头部移除，类似于日常生活中的站队，先到先得的效果。

		//集合中的 Queue 类模拟了队列操作，提供了队列中常用的属性和方法。

		//Queue 类提供了 4 个构造方法，如下表所示。

		//构造方法 作用
		//Queue() 创建 Queue 的实例，集合的容量是默认初始容量 32 个元素，使用默认的增长因子
		//Queue(ICollection col)  创建 Queue 的实例，该实例包含从指定实例中复制的元素，并且初始容量与复制的元素个数、增长因子相同
		//Queue(int capacity)     创建 Queue 的实例，并设置其指定的元素个数，默认增长因子
		//Queue(int capacity, float growFactor)   创建 Queue 的实例，并设置其指定的元素个数和增长因子
		//增长因子是指当需要扩大容量时，以当前的容量（capacity）值乘以增长因子（growFactor）的值来自动增加容量。

		//下面使用上表中的构造方法来创建 Queue 的实例，代码如下。
		// 第 1 中构造器
		// Queue queueq1 = new Queue();
		//	//第 2 中构造器
		//	Queue queueq2 = new Queue(queue1);
		//	//第 3 中构造器
		//	Queue queueq3 = new Queue(30);
		//	//第 4 中构造器
		//	Queue queueq4 = new Queue(30, 2);
		//	与上一节《C# ArrayList》中介绍的 ArrayList 类不同，Queue 类不能在创建实例时直接添加值。

		//Queue类中常用的属性和方法如下表所示。

		//属性或方法 作用
		//Count 属性，获取 Queue 实例中包含的元素个数
		//void Clear()    清除 Queue 实例中的元素
		//bool Contains(object obj)   判断 Queue 实例中是否含有 obj 元素
		//void CopyTo(Array array, int index)     将 array 数组从指定索引处的元素开始复制到 Queue 实例中
		//object Dequeue()    移除并返回位于 Queue 实例开始处的对象
		//void Enqueue(object obj)    将对象添加到 Queue 实例的结尾处
		//object Peek()   返回位于 Queue 实例开始处的对象但不将其移除
		//object[] ToArray()  将 Queue 实例中的元素复制到新数组
		//void TrimToSize()   将容量设置为 Queue 实例中元素的实际数目
		//IEnumerator GetEnumerator()  返回循环访问 Queue 实例的枚举数

	public class QueueClass
	{
		public static void SubQueueClass_Dequeue()  // Enqueue + Dequeue
		{
			Queue queue = new Queue();
			//向队列中加入3为购票人
			queue.Enqueue("小张");
			queue.Enqueue("小李");
			queue.Enqueue("小刘");
			Console.WriteLine("购票开始：");
			//当队列中没有人时购票结束
			while (queue.Count != 0)
			{
				Console.WriteLine(queue.Dequeue() + "已购票！");
			}
			Console.WriteLine("购票结束！");
		}

		public static void SubQueueClass_ToArray()  // ToArray
		{
			Queue queue = new Queue();
			queue.Enqueue("aaa");
			queue.Enqueue("bbb");
			queue.Enqueue("ccc");
			object[] obj = queue.ToArray();
			foreach (var v in obj)
			{
				Console.WriteLine(v);
			}
		}

		public static void SubQueueClass_GetEnumerator()  // GetEnumerator
		{
			Queue queue = new Queue();
			queue.Enqueue("AAA");
			queue.Enqueue("BBB");
			queue.Enqueue("CCC");
			IEnumerator enumerator = queue.GetEnumerator();
			while (enumerator.MoveNext())
			{
				Console.WriteLine(enumerator.Current);
			}
		}

	}

	//==================>>>>>>>>>>==================>>>>>>>>>> ==================>>>>>>>>>>  4【Stack类：堆栈】

		//C# Stack (栈)是常见的数据结构之一，栈是一种先进后出的结构，即元素从栈的尾部插入，从栈的尾部移除，类似于日常生活中搬家的时候装车，先装上车的东西要后拿下来。

		//集合中的 Stack 类模拟了栈操作，提供了栈中常用的属性和方法。

		//Stack 类提供了 3 种构造方法，如下表所示。

		//构造方法 作用
		//Stack() 使用初始容量创建 Stack 的对象
		//Stack(ICollection col)  创建 Stack 的实例，该实例包含从指定实例中复制的元素，并且初始容量与复制的元素个数、增长因子相同
		//Stack(int capacity) 创建 Stack 的实例，并设置其初始容量
		//Stack 类中的常用属性和方法如下表所示。

		//属性或方法 作用
		//Push(object obj)    向栈中添加元素，也称入栈
		//object Peek()   用于获取栈顶元素的值，但不移除栈顶元素的值
		//object Pop()    用于移除栈顶元素的值，并移除栈顶元素
		//Clear() 从 Stack 中移除所有的元素
		//Contains(object obj)    判断某个元素是否在 Stack 中
		//object[] ToArray()  复制 Stack 到一个新的数组中
		//下面通过实例来演示 Stack 类的使用。

	public class StackClass
	{
		public static void SubStackClass_pop() // push + pop
		{
			Stack stack = new Stack();
			//向栈中存放元素
			stack.Push("1 号盘子");
			stack.Push("2 号盘子");
			stack.Push("3 号盘子");
			stack.Push("4 号盘子");
			stack.Push("5 号盘子");
			Console.WriteLine("取出盘子：");
			//判断栈中是否有元素
			while (stack.Count != 0)
			{
				//取出栈中的元素
				Console.WriteLine(stack.Pop());
			}
		}
	}

	//==================>>>>>>>>>>==================>>>>>>>>>> ==========>>>>>>>>>> 5 【Hashtable类：哈希表（散列表）】

		//C# Hashtable 类实现了 IDictionary 接口，集合中的值都是以键值对的形式存取的。

		//C# 中的 Hashtable 称为哈希表，也称为散列表，在该集合中使用键值对（key/value）的形式存放值。

		//换句话说，在 Hashtable 中存放了两个数组，一个数组用于存放 key 值，一个数组用于存放 value 值。

		//此外，还提供了根据集合中元素的 key 值查找其对应的 value 值的方法。

		//Hashtable 类提供的构造方法有很多，最常用的是不含参数的构造方法，即通过如下代码来实例化 Hashtable 类。
		//Hashtable 对象名 = new Hashtable();

		//	Hashtable 类中常用的属性和方法如下表所示。

		//属性或方法 作用
		//Count 集合中存放的元素的实际个数
		//void Add(object key, object value)   向集合中添加元素
		//void Remove(object key) 根据指定的 key 值移除对应的集合元素
		//void Clear()    清空集合
		//ContainsKey(object key)    判断集合中是否包含指定 key 值的元素
		//ContainsValue(object value) 判断集合中是否包含指定 value 值的元素


	public class HashtableClass
	{
		public static void SubHashtableClass()
		{
			Hashtable ht = new Hashtable();
			ht.Add(1, "计算机基础");
			ht.Add(2, "C#高级编程");
			ht.Add(3, "数据库应用");
			Console.WriteLine("现在查询图书编号：2");
			int id = int.Parse("2");
			bool flag = ht.ContainsKey(id);
			if (flag)
			{
				Console.WriteLine("您查找的图书名称为：{0}", ht[id].ToString());
			}
			else
			{
				Console.WriteLine("您查找的图书编号不存在！");
			}
			Console.WriteLine("所有的图书信息如下：");
			foreach (DictionaryEntry d in ht)
			{
				int key = (int)d.Key;
				string value = d.Value.ToString();
				Console.WriteLine("图书编号：{0}，图书名称：{1}", key, value);
			}
		}
	}

	//==================>>>>>>>>>>==================>>>>>>>>>> ==========>>>>>>>>>>  6【SortedList类：有序列表】

		//C# SortedList 类实现了 IDictionary 接口 ,集合中的值都是以键值对的形式存取的。

		//C# SortedList 称为有序列表，按照 key 值对集合中的元素排序。

		//SortedList 集合中所使用的属性和方法与上一节《C# Hashtable》中介绍的 Hashtable 比较类似，这里不再赘述。


	public class SortedListClass
	{
		public static void SubSortedListClass()
		{
			SortedList sortList = new SortedList();
			sortList.Add(1, "小张");
			sortList.Add(2, "小李");
			sortList.Add(3, "小刘");
			Console.WriteLine("现在查询图书编号：2");
			int id = int.Parse("2");
			bool flag = sortList.ContainsKey(id);
			if (flag)
			{
				string name = sortList[id].ToString();
				Console.WriteLine("您查找的患者姓名为：{0}", name);
			}
			else
			{
				Console.WriteLine("您查找的挂号编号不存在！");
			}
			Console.WriteLine("所有的挂号信息如下：");
			foreach (DictionaryEntry d in sortList)
			{
				int key = (int)d.Key;
				string value = d.Value.ToString();
				Console.WriteLine("挂号编号：{0}，姓名：{1}", key, value);
			}
		}
	}

	//=============>>>>>>>>>>>>>--------------->>>>>>>>>>>>>>>>>>>>———— 7【泛型】

		// 泛型是在 System.Collections.Generic 命名空间中的，用于约束类或方法中的参数类型。

	public class CollectionClass
	{
		public static void SubArrayList_1()
		{
			ArrayList arrayList = new ArrayList();
			arrayList.Add(100);
			arrayList.Add("abc");
			arrayList.Add(85.5);

			//foreach (int d in arrayList)  // 由于在集合中存放的并不全是 double 类型的值，因此会出现 System.InvalidCastException 异常，即指定的转换无
			foreach (var d in arrayList)
			{
				Console.WriteLine(d);
			}

		}

		//————————————————————————————————— 8【可空类型 int? 等同于Nullable<int>】

		public static void SubNullable()    
		{
			Nullable<int> a = null;   // int? 等同于Nullable<int>
			int? i = null;
			double? d = 3.14;
			if (a.HasValue)          // 使用可空类型时也可以通过 HasValue 属性判断变量值是否为 Null 值。
			{
				Console.WriteLine("a 的值为{0}", a);
			}
			else
			{
				Console.WriteLine("a 的值为空！");
			}
			if (i.HasValue)
			{
				Console.WriteLine("i 的值为{0}", i);
			}
			else
			{
				Console.WriteLine("i 的值为空！");
			}
			if (d.HasValue)
			{
				Console.WriteLine("d 的值为{0}", d);
			}
			else
			{
				Console.WriteLine("d 的值为空！");
			}
		}

		//————————————————————————————————————— 9【泛型方法的定义及使用】

			//在 C# 语言中泛型方法是指通过泛型来约束方法中的参数类型，也可以理解为对数据类型设置了参数。
			//如果没有泛型，每次方法中的参数类型都是固定的，不能随意更改。
			//在使用泛型后，方法中的数据类型则有指定的泛型来约束，即可以根据提供的泛型来传递不同类型的参数。
			//定义泛型方法需要在方法名和参数列表之间加上<>，并在其中使用 T 来代表参数类型。
			//当然，也可以使用其他的标识符来代替参数类型， 但通常都使用 T 来表示。下面通过实例来演示泛型方法的使用

		public static void Add<T>(T a, T b)
		{
			double sum = double.Parse(a.ToString()) + double.Parse(b.ToString());
			Console.WriteLine(sum);
		}

	}

	//————————————————————————————————————————— 10【泛型类的定义及使用】

		//泛型类的定义与泛型方法类似，是在泛型类的名称后面加上<T>，当然,也可以定义多个类型，即“<T1,T2,・・・>”。

		// 根据泛型类中指定的数据类型创建数组，并实现了对数组元素的添加和显示。
	public class CollectionTest<T>
	{
		private T[] items = new T[3];
		private int index = 0;
		//向数组中添加项
		public void Add(T t)
		{
			if (index < 3)
			{
				items[index] = t;
				index++;
			}
			else
			{
				Console.WriteLine("数组已满！");
			}
		}
		//读取数组中的全部项
		public void Show()
		{
			foreach (T t in items)
			{
				Console.WriteLine(t);
			}
		}
	}

	//—————————————————————————————————————— 11【泛型集合定义及使用】

		//C# 语言中泛型集合是泛型中最常见的应用，主要用于约束集合中存放的元素。
		//由于在集合中能存放任意类型的值，在取值时经常会遇到数据类型转换异常的情况，因此推荐在定义集合时使用泛型集合。
		//前面《C# ArrayList》与《C# Hashtable》中已经介绍了非泛型集合中的 ArrayList、Hashtable。
		//非泛型集合中的 ArrayList、Hashtable 在泛型集合中分别使用 List<T> 和 Dictionary<K, V> 来表示，其他泛型集合均与非泛型集合一致。



	//在该泛型集合中存放的是 Student 类的对象，当从集合中取岀元素时并不需要将集合中元素的类型转换为 Student 类的类型，
	//而是直接遍历集合中的元素即可，这也是泛型集合的一个特点。
	public class CollectionList      //———————————————————————— 12【List】
	{
		public static void SubCollectionList()
		{
			List<StudentAH> list = new List<StudentAH>();  // 定义泛型集合
													   
			list.Add(new StudentAH(1, "小明", 20));        // 向集合中存入3名学员
			list.Add(new StudentAH(2, "小李", 21));
			list.Add(new StudentAH(3, "小赵", 22));
			
			foreach (StudentAH stu in list)                // 遍历集合中的元素
			{
				Console.WriteLine(stu);
			}
		}
	}
	public class StudentAH
	{
		public StudentAH(int id, string name, int age)  //提供有参构造方法，为属性赋值
		{
			this.id = id;
			this.name = name;
			this.age = age;
		}
		
		public int id { get; set; }         //学号
		public string name { get; set; }    //姓名
		public int age { get; set; }        //年龄
		public override string ToString()   //重写ToString 方法
		{
			return id + "：:" + name + "：:" + age;
		}

	}

	//根据输入的学号直接从 Dictionary<int, Student> 泛型集合中查询出所对应的学生信息，并且在输出学生信息时
	//不需要进行类型转换，直接输出其对应的 Student 类的对象值即可。
	public class CollectionDict    //———————————————————————— 13【Dictionary】
	{
		public static void SubCollectionDict()
		{
			Dictionary<int, StudentAH> dictionary = new Dictionary<int, StudentAH>();
			StudentAH stu1 = new StudentAH(1, "小明", 20);
			StudentAH stu2 = new StudentAH(2, "小李", 21);
			StudentAH stu3 = new StudentAH(3, "小赵", 22);
			dictionary.Add(stu1.id, stu1);
			dictionary.Add(stu2.id, stu2);
			dictionary.Add(stu3.id, stu3);
			Console.WriteLine("现查找的学生学号是：2");
			int id = int.Parse("2");
			if (dictionary.ContainsKey(id))
			{
				Console.WriteLine("学生信息为：{0}", dictionary[id]);
			}
			else
			{
				Console.WriteLine("您查找的学号不存在！");
			}
		}
	}

	//————————————————————————————— 14【IComparable、IComparer接口：比较两个对象的值】

	//	在 C# 语言中提供了 IComparer 和 IComparable 接口比较集合中的对象值，主要用于对集合中的元素排序。
	//IComparer 接口用于在一个单独的类中实现，用于比较任意两个对象。
	//IComparable 接口用于在要比较的对象的类中实现，可以比较任意两个对象。
	//在比较器中还提供了泛型接口的表示形式，即 IComparer<T> 和 IComparable<T> 的形式。
	//对于 IComparer<T> 接口，方法如下表所示。

	//方法 作用
	//CompareTo(T obj) 比较两个对象值
	//如果需要对集合中的元素排序，通常使用 CompareTo 方法实现

	
	public class StudentICa : IComparable<StudentICa> //============================= 【IComparable + CompareTo】
	{
		//提供有参构造方法，为属性赋值
		public StudentICa(int id, string name, int age)
		{
			this.id = id;
			this.name = name;
			this.age = age;
		}
		public int id { get; set; }
		public string name { get; set; }
		public int age { get; set; }
		
		public override string ToString()      // 重写ToString 方法
		{
			return id + "：" + name + "：" + age;
		}

		public int CompareTo(StudentICa other)  // 定义比较方法，按照学生的年龄比较  【Compareto】
		{
			if (this.age < other.age)
			{
				return -1;
			}
			return 1;
		}
	}

	//在默认情况下，Sort 方法是将集合中的元素从小到大输出的， 由于在 Student 类中重写了 CompareTo 方法，
	//因此会按照预先定义好的排序规则对学生信息排序。

	//需要说明的是，在 CompareTo 方法中返回值大于 0 则表示第一个对象的值大于第二个对象的值，
	//返回值小于 0 则表示第一个对象的值小于第二个对象的值，返回值等于 0 则表示两个对象的值相等。

	public class CollectionCompare : IComparer<StudentICa>   // ============================= 【IComparer + Comparer】
	{
		public int Compare(StudentICa x, StudentICa y)  //比较方法
		{
			if (x.age > y.age)
			{
				return -1;
			}
			return 1;
		}
	}
//——————————————————————————————————

	public class CollectionICa
		{
			public static void SubCollecionICa()
			{
				List<StudentICa> list = new List<StudentICa>();
				list.Add(new StudentICa(1, "小明", 20));
				list.Add(new StudentICa(2, "小李", 21));
				list.Add(new StudentICa(3, "小赵", 22));
				list.Sort();                       // —————————————————— 【IComparable + CompareTo】

			foreach (StudentICa stu in list)
				{
					Console.WriteLine(stu);
				}
			}

		public static void SubStudentIC()
		{
			List<StudentICa> list = new List<StudentICa>();
			list.Add(new StudentICa(1, "小明", 20));
			list.Add(new StudentICa(2, "小李", 21));
			list.Add(new StudentICa(3, "小赵", 22));
			//在Sort方法中传递自定义比较器作为参数
			list.Sort(new CollectionCompare());    // ———————————————————【IComparer + Comparer】
			foreach (StudentICa stu in list)
			{
				Console.WriteLine(stu);
			}
		}

	}






}

