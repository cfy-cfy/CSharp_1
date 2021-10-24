using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace WindowsForms_Excel_1
{
	class String_1
	{


	}
	// ———————————————————————————————————————— 字符串及常用方法
	//1	Length 获取字符串的长度，即字符串中字符的个数
	//2	IndexOf 返回整数，得到指定的字符串在原字符串中第一次出现的位置
	//3	LastlndexOf 返回整数，得到指定的字符串在原字符串中最后一次出现的位置
	//4	Starts With 返回布尔型的值，判断某个字符串是否以指定的字符串开头
	//5	EndsWith 返回布尔型的值，判断某个字符串是否以指定的字符串结尾
	//6	ToLower 返回一个新的字符串，将字符串中的大写字母转换成小写字母
	//7	ToUpper 返回一个新的字符串，将字符串中的小写字母转换成大写字母
	//8	Trim 返回一个新的字符串，不带任何参数时表示将原字符串中前后的空格删除。 参数为字符数组时表示将原字符串中含有的字符数组中的字符删除
	//9	Remove 返回一个新的字符串，将字符串中指定位置的字符串移除
	//10	TrimStart 返回一个新的字符串，将字符串中左侧的空格删除
	//11	TrimEnd 返回一个新的字符串，将字符串中右侧的空格删除
	//12	PadLeft 返回一个新的字符串，从字符串的左侧填充空格达到指定的字符串长度
	//13	PadRight 返回一个新的字符串，从字符串的右侧填充空格达到指定的字符串长度
	//14	Split 返回一个字符串类型的数组，根据指定的字符数组或者字符串数组中的字符 或字符串作为条件拆分字符串
	//15	Replace 返回一个新的字符串，用于将指定字符串替换给原字符串中指定的字符串
	//16	Substring 返回一个新的字符串，用于截取指定的字符串
	//17	Insert 返回一个新的字符串，将一个字符串插入到另一个字符串中指定索引的位置
	//18	Concat 返回一个新的字符串，将多个字符串合并成一个字符串

	class StringClass
	{
		public static void SubString( )
		{
			string str ="<Yesterday once more !>";

			//Debug.WriteLine("字符串的长度为：" + str.Length);
			//Debug.WriteLine("字符串中第一个字符为：" + str[0]);
			//Debug.WriteLine("字符串中最后一个字符为：" + str[str.Length - 1]);

			//for (int i = str.Length - 1; i >= 0; i--)   // 遍历字符串
			//{
			//	Debug.WriteLine(str[i]);
			//}

			// ———————————————————————————————————— IndexOf , LastIndexOf

			//int firstIndex = str.IndexOf("o");
			//int lastIndex = str.LastIndexOf("o");
			//if (firstIndex != -1)
			//{
			//	if (firstIndex == lastIndex)
			//	{
			//		Debug.WriteLine("在该字符串中仅含有一个@");
			//	}
			//	else
			//	{
			//		Debug.WriteLine("在该字符串中含有多个@");
			//	}
			//}
			//else
			//{
			//	Debug.WriteLine("在该字符串中不含有@");
			//}

			// ———————————————————————————————————— replace 字符串替换

			//if (str.IndexOf("!") != -1)
			//{
			//	str = str.Replace("!", "!!!!!!");
			//}
			//Debug.WriteLine("替换后的字符串为：" + str);

			// ———————————————————————————————————— Substring

			//int firstIndex = str.IndexOf("!");
			//int lastIndex = str.LastIndexOf("!");
			//if (firstIndex != -1 && firstIndex == lastIndex)
			//{
			//	str = str.Substring(0, firstIndex);
			//}
			//Console.WriteLine( str);

			// ———————————————————————————————————— Insert

			//str = str.Insert(1, "@@@");
			//Console.WriteLine("新字符串为：" + str);


		}
	}

	// ———————————————————————————————————————— Parse

	class ParseClass
	{
		public static void SubParse()
		{
			//int num1 = int.Parse("6");
			//int num2 = int.Parse("9");
			//int num3 = int.Parse("1");
			//int maxvalue = num1;
			//if (num2 > maxvalue)
			//{
			//	maxvalue = num2;
			//}
			//if (num3 > maxvalue)
			//{
			//	maxvalue = num3;
			//}
			//Debug.WriteLine("三个数中最大的值是：" + maxvalue);


			int val = 100;
			object obj = val;
			Debug.WriteLine("对象的值 = {0}", obj);
			// 这是一个装箱的过程，是将值类型转换为引用类型的过程

			int va = 100;
			object ob = va;
			int num = (int)ob;
			Debug.WriteLine("num: {0}", num);
			// 这是一个拆箱的过程，是将值类型转换为引用类型，再由引用类型转换为值类型的过程

		}
	}

	// ———————————————————————————————————————— Convert

		//Convert.ToInt16() 转换为整型(short)
		//Convert.ToInt32() 转换为整型(int)
		//Convert.ToInt64() 转换为整型(long)
		//Convert.ToChar() 转换为字符型(char)
		//Convert.ToString() 转换为字符串型(string)
		//Convert.ToDateTime() 转换为日期型(datetime)
		//Convert.ToDouble() 转换为双精度浮点型(double)
		//Conert.ToSingle() 转换为单精度浮点型(float)

	class ConvertClass
	{
		public static void SubConvert()
		{
			float num1 = 82.26f;
			int integer;
			string str;
			integer = Convert.ToInt32(num1);
			str = Convert.ToString(num1);
			Debug.WriteLine("转换为整型数据的值{0}", integer);
			Debug.WriteLine("转换为字符串{0},{1},", str,"哇哈哈");
		}
	}

	// ———————————————————————————————————————— 强制转换与隐式转换

	//ToBoolean 如果可能的话，把类型转换为布尔型。
	//ToByte 把类型转换为字节类型。
	//ToChar 如果可能的话，把类型转换为单个 Unicode 字符类型。
	//ToDateTime 把类型（整数或字符串类型）转换为 日期-时间 结构。
	//ToDecimal 把浮点型或整数类型转换为十进制类型。
	//ToDouble 把类型转换为双精度浮点型。
	//ToInt16 把类型转换为 16 位整数类型。
	//ToInt32 把类型转换为 32 位整数类型。
	//ToInt64 把类型转换为 64 位整数类型。
	//ToSbyte 把类型转换为有符号字节类型。
	//ToSingle 把类型转换为小浮点数类型。
	//ToString 把类型转换为字符串类型。
	//ToType 把类型转换为指定类型。
	//ToUInt16 把类型转换为 16 位无符号整数类型。
	//ToUInt32 把类型转换为 32 位无符号整数类型。
	//ToUInt64 把类型转换为 64 位无符号整数类型。

	//	【1】在 C# 语言中隐式转换是指不需要其他方法数据类型直接即可转换。
	//隐式转换主要是在整型、浮点型之间的转换，将存储范围小的数据类型直接转换成存储范围大的数据类型。
	//例如将 int 类型的值转换成 double 类型的值，将 int 类型的值转换成 long 类型的值，或者将 float 类型的值转换成 double 类型的值。

	//示例代码如下。
	//int a = 100;
	//double d = a;  //将int类型转换为double类型
	//float f = 3.14f;
	//d = f;         //将float类型转换为double类型

	//隐式数值转换包括以下几种：
	//从 sbyte 类型到 short,int,long,float,double,或 decimal 类型。
	//从 byte 类型到 short,ushort,int,uint,long,ulong,float,double,或 decimal 类型。
	//从 short 类型到 int,long,float,double,或 decimal 类型。
	//从 ushort 类型到 int,uint,long,ulong,float,double,或 decimal 类型。
	//从 int 类型到 long,float,double,或 decimal 类型。
	//从 uint 类型到 long,ulong,float,double,或 decimal 类型。
	//从 long 类型到 float,double,或 decimal 类型。
	//从 ulong 类型到 float,double,或 decimal 类型。
	//从 char 类型到 ushort,int,uint,long,ulong,float,double,或 decimal 类型。
	//从 float 类型到 double 类型。

	//	【2】强制类型转换主要用于将存储范围大的数据类型转换成存储范围小的，但数据类型需要兼容。

	//例如 int 型转换成 float 型是可行的，但 float 型转换成 int 型则会造成数据精度丢失，而且字符串类型与整数类型之间是无法进行强制类型转换的。

	//强制类型转换的语法如下。
	//数据类型变量名 = (数据类型) 变量名或值;

	//	这里要求等号左、右两边的数据类型是一致的。例如将 double 类型转换成 int 类型，代码如下。

	//  double dbl_num = 12345678910.456;
	//	int k = (int)dbl_num;//此处运用了强制转换
	//	通过上面的语句即可将浮点型转换成整数。

	//这样虽然能将值进行类型的转换，但损失了数据的精度，造成了数据的不准确，因此在使用强制类型转换时还需要注意数据的准确性

	// ————————————————————————————————————————



}
