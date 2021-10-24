using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsForms_Excel_1
{
	class try_catch_finally
	{
	}

	//在 C# 语言中异常与异常处理语句包括三种形式，即 try catch、try finally、try catch finally。

	//在上述三种异常处理的形式中所用到关键字其含义如下：
	//try：用于检查发生的异常，并帮助发送任何可能的异常。 
	//catch：以控制权更大的方式处理错误，可以有多个 catch 子句。 
	//finally：无论是否引发了异常，finally 的代码块都将被执行。 


	//常用的系统异常类如下表所示。

	//异常类 说明
	//System.OutOfMemoryException 用 new 分配内存失败
	//System.StackOverflowException   递归过多、过深
	//System.NullReferenceException 对象为空
	//Syetem.IndexOutOfRangeException 数组越界
	//System.ArithmaticException 算术操作异常的基类
	//System.DivideByZeroException 除零错误

	public class ErrorClass        // ——————————  【try + exception】
	{
		public static void SubError_exception()
		{

			string str ="abc";
			try
			{
				int num = int.Parse(str);
				MessageBox.Show("您输入的数字是：" + num);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		public static void SubError_catch() // ——————————  【try + catch】
		{
			try
			{
				int a = int.Parse("abc");
				Console.Write(a + " ");
			}
			
			catch (FormatException f)
			{
				Console.WriteLine("输入的数字格式不正确！");
			}
			catch (OverflowException o)
			{
				Console.WriteLine("输入的值已经超出 int 类型的最大值！");
			}
			catch (IndexOutOfRangeException r)
			{
				Console.WriteLine("数组越界异常！");
			}
		}

		public static void SubError_finally()  // ——————————  【try + finally】
		{
			try
			{
				string a = "123";
				int num = int.Parse(a);
				MessageBox.Show("您输入的数字是：" + num);
			}
			finally
			{
				MessageBox.Show("finally 语句");
			}

		}

		public static void SubError_finally1() // ——————————  【try + catch + finally】
		{  
			string path = @"C:\Users\hp\Desktop\bbb.txt";
			FileStream fileStream = null;
			try
			{
			//创建fileSteam类的对象
			fileStream = new FileStream(path, FileMode.OpenOrCreate);
			//将字符串转换成字节数组
			byte[] bytes = Encoding.UTF8.GetBytes("烟火里的尘埃");
			//向文件中写入字节数组
			fileStream.Write(bytes, 1, bytes.Length);
				//刷新缓冲区
				fileStream.Flush();
				//弹出录入成功的消息框
				MessageBox.Show("录入成功！");
			}

			catch (Exception ex)
			{
				MessageBox.Show("出现错误！" + ex.Message);
			}

			finally
			{
				if (fileStream != null)
				{
					//关闭流
					MessageBox.Show("关闭流");
					fileStream.Close();
				}
			}


			if (File.Exists(path))   // 判断是否含有指定文件
			{
				FileStream fileStream_1 = new FileStream(path, FileMode.Open, FileAccess.Read);

				byte[] bytes_1 = new byte[fileStream_1.Length]; // 定义存放文件信息的字节数组

				fileStream_1.Read(bytes_1, 0, bytes_1.Length);  // 读取文件信息

				char[] c = Encoding.UTF8.GetChars(bytes_1);     // 将得到的字节型数组重写编码为字符型数组
				Console.WriteLine(c);
				fileStream_1.Close();
			}


		}

		public static void SubError_throw()     // ——————————  【throw 自定义异常类】
		{
			try
			{
				int age = int.Parse("50");
				if (age < 18 || age > 45)
				{
					throw new MyException("年龄必须在18~45岁之间！");
				}
				else
				{
					MessageBox.Show("输入的年龄正确！");
				}
			}
			catch (MyException myException)
			{
				MessageBox.Show(myException.Message);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

		}


	}

	class MyException : Exception             // 【自定义异常类】
	{
		public MyException(string message) : base(message)
		{
		}
	}


}
