using System;
using System.IO;

namespace HelloWorld
{
	public class Program
	{
		public static void Main()
		{
			File.WriteAllText(@".\StarWars.txt", "Han shot first");
			string path = @".\StarWars.txt";
			StreamReader streamReader = new StreamReader(path);
			while (streamReader.Peek() != -1)
			{
				//读取文件中的一行字符
				string str = streamReader.ReadLine();
				Console.WriteLine(str);
			}
			streamReader.Close();
			Console.WriteLine("不包含扩展名的文件名：" + Path.GetFileNameWithoutExtension(path));
			Console.WriteLine("文件扩展名：" + Path.GetExtension(path));
			Console.WriteLine("文件全名：" + Path.GetFileName(path));
			Console.WriteLine("文件路径：" + Path.GetDirectoryName(path));
		}
	}
}
