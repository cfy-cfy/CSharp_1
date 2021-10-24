using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace WindowsForms_Excel_1
{
	class ArrayClass
	{
		public static void SubArray_0()
		{

			// ====== ======= ====== ======== ====== ======= ====== ======== ====== 1【创建数组】

			//double[] balance = new double[10];               // 初始化数组
			//balance[0] = 4500.0;
			//double[] balance = { 2340.0, 4523.69, 3421.0 };  // 在声明数组的同时给数组赋值

			//int[] intArr = new int[20];
			//int[] marks = new int[5] { 99, 98, 92, 97, 95 };  // 创建并初始化一个数组
			//int[] marks = new int[] { 99, 98, 92, 97, 95 };   // 也可以省略数组的大小
			//int[] score = marks;                              //  可以赋值一个数组变量到另一个目标数组变量中

			//int[,] a = new int[3, 4] {{0, 1, 2, 3} ,{4, 5, 6, 7} , {8, 9, 10, 11} };
			//int val = a[2, 3];
			//MessageBox.Show(val.ToString());

			// ====== ======= ====== ======== ====== ======= ====== ======== ====== 2【访问数组】

			//int[] marks = new int[5] { 99, 98, 92, 97, 95 };
			//int salary = marks[4];
			//MessageBox.Show(salary.ToString());


		}

		public static void SubArray_1()
		{

			// ——————————————————————— 3【一维数组】

			//int[] n = new int[10];             /* n 是一个带有 10 个整数的数组 */
			//int i, j;
			//for (i = 0; i < 10; i++)
			//{
			//	n[i] = i + 100;                /* 初始化数组 n 中的元素 */
			//}
			//for (j = 0; j < n.Length; j++)
			//{
			//	Debug.WriteLine("Element[{0}] = {1}", j, n[j]);   /* 输出每个数组元素的值 */
			//}


			double[] points = { 80, 88, 86, 90, 75.5 };
			double sum = 0;
			double avg = 0;
			foreach (double point in points)
			{
				sum = sum + point;
			}
			avg = sum / points.Length;
			Debug.WriteLine("总成绩为：" + sum);
			Debug.WriteLine("平均成绩为：" + avg);



		}

		public static void SubArray_2()
		{
			// ——————————————————————— 4【二维 or 多维 数组】

			////string[,] a = new string[5, 2] { { "A", "A1" }, { "B", "A2" }, { "C", "A3" }, { "D", "A4" }, { "E", "A5" } };
			//int[,] a = new int[5, 2] { { 0, 0 }, { 1, 2 }, { 2, 4 }, { 3, 6 }, { 4, 8 } };
			//int i, j;

			//for (i = 0; i < 5; i++)
			//{
			//	for (j = 0; j < 2; j++)
			//	{
			//		Debug.WriteLine("a[{0},{1}] = {2}", i, j, a[i, j]);
			//	}
			//}


			//double[,] points = { { 90, 80,75,123 }, { 100, 89,35,85 }, { 88.5, 86 ,105 ,23} };
			//Debug.WriteLine(points.GetLength(0));
			//Debug.WriteLine(points.GetLength(1));
			//for (int i = 0; i < points.GetLength(0); i++)
			//{
			//	Debug.WriteLine("第" + (i + 1) + "个学生成绩：");
			//	for (int j = 0; j < points.GetLength(1); j++)
			//	{
			//		Debug.WriteLine(points[i, j] + " ");
			//	}
			//}


		}

		public static void SubArray_3()
		{

			// ———————————————————————  5【交错数组】

			//int[][] a = new int[][] { new int[] { 0, 0 }, new int[] { 1, 2 }, new int[] { 2, 4 }, new int[] { 3, 6 }, new int[] { 4, 8 } };
			//int i, j;
			//for (i = 0; i < 5; i++)
			//{
			//	for (j = 0; j < 2; j++)
			//	{
			//		Debug.WriteLine("a[{0}][{1}] = {2}", i, j, a[i][j]);
			//	}
			//}


			//int[][] arrays = new int[3][];
			//arrays[0] = new int[] { 1, 2 };
			//arrays[1] = new int[] { 3, 4, 5 };
			//arrays[2] = new int[] { 6, 7, 8, 9 };
			//for (int i = 0; i < arrays.Length; i++)
			//{
			//	Debug.WriteLine("输出数组中第" + (i + 1) + "行的元素：");
			//	for (int j = 0; j < arrays[i].Length; j++)
			//	{
			//		Debug.Write(arrays[i][j] + " ");
			//	}
			//	Debug.WriteLine(" ");
			//}


			//int[][] arrays = new int[3][];
			//arrays[0] = new int[2];
			//arrays[1] = new int[3];
			//arrays[2] = new int[4];
			//for (int i = 0; i < arrays.Length; i++)
			//{
			//	Debug.WriteLine("输入数组中第" + (i + 1) + "行的元素：");
			//	for (int j = 0; j < arrays[i].Length; j++)
			//	{
			//		arrays[i][j] = int.Parse(Console.ReadLine());
			//	}
			//}




		}

		public static void SubArray_5()
		{
			// ———————————————————————  6【Split：将字符串拆分为数组】

			//string str = "a,b,c,d,e,f,g,h";
			//string[] condition = { "," };
			//string[] result = str.Split(condition, StringSplitOptions.None);
			//Debug.WriteLine("字符串中含有逗号的个数为：" + (result.Length - 1));

			string str = "a,b,c,d,e,f,g,";
			string[] condition = { "," };
			string[] result = str.Split(condition, StringSplitOptions.RemoveEmptyEntries);
			Console.WriteLine("字符串中含有逗号的个数为：" + (result.Length - 1));

		}

		public static void SubArray_6()
		{
			// ——————————————————————— 7冒泡排序
			//int[] a = { 5, 1, 7, 2, 3 };
			//for (int i = 0; i < a.Length; i++)
			//{
			//	for (int j = 0; j < a.Length - i - 1; j++)
			//	{
			//		if (a[j] > a[j + 1])
			//		{
			//			int temp = a[j];
			//			a[j] = a[j + 1];
			//			a[j + 1] = temp;
			//		}
			//	}
			//}
			//Debug.WriteLine("升序排序后的结果为：");
			//foreach (int b in a)
			//{
			//	Debug.Write(b + "");
			//}


			// ——————————————————————— 8（Sort方法）

			int[] a = { 5, 3, 2, 4, 1 };
			Array.Sort(a);
			Debug.WriteLine("排序后的结果为：");
			foreach (int b in a)
			{
				Debug.WriteLine(b + " ");
			}
			Debug.WriteLine(" ");



		}


		public static void SubArray_4()
		{
			// ———————————————————————  9【参数数组:数组作为参数】

			ParamArray getarr = new ParamArray();
			int sum = getarr.AddElements(512, 720, 250, 567, 889);
			Debug.WriteLine("总和是： {0}", sum);

		}


	}

	public partial class ParamArray        // 10【参数数组：数组作为参数】
	{
		public int AddElements(params int[] arr)
		{
			int sum = 0;
			foreach (int i in arr)
			{
				sum += i;
			}
			return sum;
		}
	}

	public partial class MyArray        // 11【传递数组给函数】
	{
		public double getAverage(int[] arr, int size)
		{
			int i;
			double avg;
			int sum = 0;

			for (i = 0; i < size; ++i)
			{
				sum += arr[i];
			}

			avg = (double)sum / size;
			return avg;
		}

		public static void SubMyArray()
		{
			MyArray app = new MyArray();
			int[] balance = new int[] { 1000, 2, 3, 17, 50 };
			double avg;

			avg = app.getAverage(balance, 5);
			Debug.WriteLine("平均值是： {0} ", avg);
		}
	}


}
