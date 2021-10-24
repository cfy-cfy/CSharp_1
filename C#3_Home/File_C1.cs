using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

//在前面操作变量和常量时这些值都是存放到内存中的，当程序运行结束后使用的数据全部被删除。
//若需要长久保存应用程序中的数据，可以选用文件或数据库来存储。
//文件通常存放到计算机磁盘上的指定位置，可以是记事本、Word文档、图片等形式。
//在 C# 语言中提供了相应的类用于直接在程序中实现对文件的创建、移动、读写等操作。
//文件操作类在 System.IO 命名空间中，包括 Driveinfo 类、Directory 类、Directoryinfo 类、File 类、Filelnfo 类、Path 类等。

namespace WindowsForms_Excel_1
{
	class File_C1
	{
	}


	// =============================================================== 1【Driveinfo：获取计算机驱动器信息】

		//查看计算机驱动器信息主要包括查看磁盘的空间、磁盘的文件格式、磁盘的卷标等，在 C# 语言中这些操作可以通过 Driveinfo 类来实现。
		//Driveinfo 类是一个密封类，即不能被继承，其仅提供了一个构造方法，语法形式如下。
		//Driveinfo(string driveName)

		//其中，dirveName 参数是指有效驱动器路径或驱动器号，Null 值是无效的。

		//创建 Driveinfo 类的实例的代码如下。
		//Driveinfo driveInfo = new Driveinfo("C");
		//	上面的代码创建了磁盘的盘符是 C 的驱动器实例，通过该实例能获取该盘符下的信息， 包括磁盘的名称、磁盘的格式等。

		//Driveinfo 类中的常用属和方法如下表所示。

		//属性或方法 作用
		//AvailableFreeSpace 只读属性，获取驱动器上的可用空闲空间量(以字节为单位)
		//DriveFormat 只读属性，获取文件系统格式的名称，例如 NTFS 或 FAT32
		//DriveType 只读属性，获取驱动器的类型，例如 CD-ROM、可移动驱动器、网络驱动器或固定驱动器 , Fixed 值代表的本地磁盘
		//IsReady 只读属性，获取一个指示驱动器是否已准备好的值，True 为准备好了， False 为未准备好
		//Name 只读属性，获取驱动器的名称，例如 C:\
		//RootDirectory 只读属性，获取驱动器的根目录
		//TotalFreeSpace  只读属性，获取驱动器上的可用空闲空间总量(以字节为单位),1KB=1024B，1MB=1024KB，1GB=1024MB。
		//TotalSize 只读属性，获取驱动器上存储空间的总大小(以字节为单位),1KB=1024B，1MB=1024KB，1GB=1024MB。
		//VolumeLabel 属性， 获取或设置驱动器的卷标
		//Driveinfo[] GetDrives() 静态方法，检索计算机上所有逻辑驱动器的驱动器名称


	public class DriveInfoClass
	{
		public static void SubDriveInfo()
		{
			DriveInfo driveInfo = new DriveInfo("D");
			Console.WriteLine("驱动器的名称：" + driveInfo.Name);
			Console.WriteLine("驱动器类型：" + driveInfo.DriveType);
			Console.WriteLine("驱动器的文件格式：" + driveInfo.DriveFormat);
			Console.WriteLine("驱动器中可用空间大小：" + driveInfo.TotalFreeSpace);
			Console.WriteLine("驱动器总大小：" + driveInfo.TotalSize);
		}

		public static void SubGetDrives()
		{
			DriveInfo[] driveInfo = DriveInfo.GetDrives();
			foreach (DriveInfo d in driveInfo)
			{
				if (d.IsReady)
				{
					Console.WriteLine("驱动器名称：" + d.Name);
					Console.WriteLine("驱动器的文件格式" + d.DriveFormat);
				}
			}
		}
	}

	// =============================================================== 2【Directoryinfo类：文件夹操作】

		//	DirectoryInfo 类能创建该类的实例，通过类的实例访问类成员。

		//例如创建路径为 D 盘中的 test 文件夹的实例，代码如下。
		//DirectoryInfo directoryInfo = new DirectoryInfo("D:\\test");

		//	需要注意的是路径中如果使用 \，要使用转义字符来表示，即 \\；或者在路径中将 \ 字符换成 /。

		//DirectoryInfo 类中常用的属性和方法如下表所示。

		//属性或方法 作用
		//Exists 只读属性，获取指示目录是否存在的值
		//Name    只读属性，获取 Directorylnfo 实例的目录名称
		//Parent  只读属性，获取指定的子目录的父目录
		//Root    只读属性，获取目录的根部分
		//void Create()   创建目录
		//DirectoryInfo CreateSubdirectory(string path)   在指定路径上创建一个或多个子目录
		//void Delete()   如果目录中为空，则将目录删除
		//void Delete(bool recursive) 指定是否删除子目录和文件，如果 recursive 参数的值为 True，则删除，否则不删除
		//IEnumerable<DirectoryInfo>  EnumerateDirectories() 返回当前目录中目录信息的可枚举集合
		//IEnumerable<DirectoryInfo> EnumerateDirectories(string searchPattern) 返回与指定的搜索模式匹配的目录信息的可枚举集合
		//IEnumerable<FileInfo> EnumerateFiles() 返回当前目录中的文件信息的可枚举集合
		//IEnumerable<FileInfo> EnumerateFiles(string searchPattern) 返回与搜索模式匹配的文件信息的可枚举集合
		//IEnumerable<FileSystemInfo> EnumerateFileSystemInfos() 返回当前目录中的文件系统信息的可枚举集合
		//IEnumerable<FileSystemInfo> EnumerateFileSystemInfos(string searchPattern) 返回与指定的搜索模式匹配的文件系统信息的可枚举集合
		//DirectoryInfo[] GetDirectories() 返回当前目录的子目录
		//DirectoryInfo[] GetDirectories(string searchPattern) 返回匹配给定的搜索条件的当前目录
		//FileInfo[] GetFiles() 返回当前目录的文件列表
		//FileInfo[] GetFiles(string searchPattern) 返回当前目录中与给定的搜索模式匹配的文件列表
		//FileSystemInfo[] GetFileSystemInfos() 返回所有文件和目录的子目录中的项
		//FileSystemInfo[] GetFileSystemInfos(string searchPattern) 返回与指定的搜索条件匹配的文件和目录的子目录中的项
		//void MoveTo(string destDirName) 移动 DirectoryInfo 实例中的目录到新的路径

	public class DirectoryInfoClass
	{
		public static void SubDirectoryInfo()
		{
			DirectoryInfo directoryInfo = new DirectoryInfo("C: \\Users\\hp\\Desktop\\code");
			//DirectoryInfo directoryInfo = new DirectoryInfo(@"C: \Users\hp\Desktop\code");

			directoryInfo.Create();  //————————————————————————————【创建文件夹】
			directoryInfo.CreateSubdirectory("code-1");
			directoryInfo.CreateSubdirectory("code-2");

		}

		public static void SubEnumerateDirectories() //—————EnumerateDirectories 方法只用于检索文件夹，不能检索文件
		{
			DirectoryInfo directoryInfo = new DirectoryInfo(@"C: \Users\hp\Desktop\code");
			IEnumerable<DirectoryInfo> dir = directoryInfo.EnumerateDirectories();
			foreach (var v in dir)
			{
				Console.WriteLine(v.Name);
			}
		}

		public static void SubDirectoryInfo_Delete() //————————————【将文件夹及其含有的子文件夹删除】
		{
			DirectoryInfo directoryInfo = new DirectoryInfo(@"C: \Users\hp\Desktop\code");
			directoryInfo.Delete(true);
		}

		// 如果要删除一个非空文件夹，则要使用 Delete(True) 方法将文件夹中的文件一并删除，否则会岀现“文件夹不为空”的异常

	}

	// =============================================================== 3【Directory类：文件夹操作】   静态类

	//C# 语言中 Directory 类与上一节《C# Directoryinfo》中介绍的 Directoryinfo 类的方法比较相似，这里不再详细列出其属性和方法的定义。
	//Directory 类是一个静态类， 不能创建该类的实例，直接通过“类名.类成员”的形式调用其属性和方法。
	//Directory 类省去了创建类实例的步骤，其他操作也与 Directoryinfo 类似。


	public class DirectoryClass
	{
		public static void SubDirectory()  // ———————————————————————— Exists + Delete + CreateDirectory
		{
			bool flag = Directory.Exists(@"C: \Users\hp\Desktop\code");
			if (flag)
			{
				Directory.Delete(@"C: \Users\hp\Desktop\code", true);
			}
			else
			{
				Directory.CreateDirectory(@"C: \Users\hp\Desktop\code");
			}
			Console.WriteLine("ok");
		}


	}

	// =============================================================== 4【FileInfo类：文件操作】

	//C# 语言中 File 类和 FileInfo 类都是用来操作文件的，并且作用相似，它们都能完成对文件的创建、更改文件的名称、删除文件、移动文件等操作。

	//File 类是静态类，其成员也是静态的，通过类名即可访问类的成员；FileInfo 类不是静态成员，其类的成员需要类的实例来访问。

	//FileInfo 类中常用的属性和方法如下表所示。

	//属性或方法 作用
	//Directory 只读属性，获取父目录的实例
	//DirectoryName   只读属性，获取表示目录的完整路径的字符串
	//Exists  只读属性，获取指定的文件是否存在，若存在返回 True，否则返回 False
	//IsReadOnly 属性，获取或设置指定的文件是否为只读的
	//Length  只读属性，获取文件的大小
	//Name    只读属性，获取文件的名称
	//Filelnfo CopyTo(string destFileName)    将现有文件复制到新文件，不允许覆盖现有文件
	//Filelnfo CopyTo(string destFileName, bool overwrite)    将现有文件复制到新文件，允许覆盖现有文件
	//FileStream Create() 创建文件
	//void Delete()   删除文件
	//void MoveTo(string destFileName)    将指定文件移到新位置，提供要指定新文件名的选项
	//Filelnfo Replace(string destinationFileName, string destinationBackupFileName)  使用当前文件对象替换指定文件的内容，先删除原始文件， 再创建被替换文件的备份

	public class FileInfoClass
	{
		public static void SubFileInfo()
		{
			
			Directory.CreateDirectory(@"C: \Users\hp\Desktop\code");     // 创建code文件夹
			FileInfo fileInfo = new FileInfo(@"C: \Users\hp\Desktop\code\test1.txt");
			if (!fileInfo.Exists)
			{
				fileInfo.Create().Close();                               // 创建文件
			}
			fileInfo.Attributes = FileAttributes.Normal;                 // 设置文件属性
			Console.WriteLine("文件路径：" + fileInfo.Directory);
			Console.WriteLine("文件名称：" + fileInfo.Name);
			Console.WriteLine("文件是否只读：" + fileInfo.IsReadOnly);
			Console.WriteLine("文件大小：" + fileInfo.Length);
			
			Directory.CreateDirectory(@"C: \Users\hp\Desktop\code-1");                       // 先创建code-1 文件夹

			FileInfo newFileInfo = new FileInfo(@"C: \Users\hp\Desktop\code-1\test1.txt");   // 判断目标文件夹中是否含有文件test1.txt
			if (!newFileInfo.Exists)
			{
				fileInfo.MoveTo(@"C: \Users\hp\Desktop\code-1\test1.txt");                   // 移动文件到指定路径
			}
			Console.WriteLine("OK");
		}
	}

	// =============================================================== 5【File类：文件操作 + FileStream】  静态类

	//C# 语言中 File 类同样可以完成与 FileInfo 类相似的功能，但 File 类中也提供了一些不同的方法。

	//File 类中获取或设置文件信息的常用方法如下表所示。

	//属性或方法 作用
	//DateTime GetCreationTime(string path)   返回指定文件或目录的创建日期和时间
	//DateTime GetLastAccessTime(string path)     返回上次访问指定文件或目录的日期和时间
	//DateTime GetLastWriteTime(string path)  返回上次写入指定文件或目录的日期和时间
	//void SetCreationTime(string path, DateTime creationTime)    设置创建该文件的日期和时间
	//void SetLastAccessTime(string path, DateTime lastAccessTime)    设置上次访问指定文件的日期和时间
	//void SetLastWriteTime(string path, DateTime lastWriteTime)  设置上次写入指定文件的日期和时间
	//File 类是静态类，所提供的类成员也是静态的，调用其类成员直接使用 File 类的名称调用即可。

	public class FileClass
	{
		public static void SubFile()
		{
			
			Directory.CreateDirectory(@"C: \Users\hp\Desktop\code");              // 创建code文件夹
			Directory.CreateDirectory(@"C: \Users\hp\Desktop\code-1");
			string path = @"C: \Users\hp\Desktop\code\test1.txt";
			
			FileStream fs = File.Create(path);                                   // 创建文件

			Console.WriteLine("文件创建时间：" + File.GetCreationTime(path));    // 获取文件信息
			Console.WriteLine("文件最后被写入时间：" + File.GetLastWriteTime(path));
			
			fs.Close();                // 关闭文件流

			string newPath = @"C: \Users\hp\Desktop\code-1\test1.txt";           // 设置目标路径

			bool flag = File.Exists(newPath);                                    // 判断目标文件是否存在
			if (flag)
			{
				
				File.Delete(newPath);  // 删除文件
			}
			File.Move(path, newPath);

			Console.WriteLine("ok");
		}
	}

	// =============================================================== 6【Path类：文件路径操作】 静态类

	//	在 C# 语言中 Path 类主要用于文件路径的一些操作，它也是一个静态类。

	//Path 类中常用的属性和方法如下表所示。

	//属性或方法 作用
	//string ChangeExtension(string path, string extension)   更改路径字符串的扩展名
	//string Combine(params string[] paths)   将字符串数组组合成一个路径
	//string Combine(string path1, string path2)  将两个字符串组合成一个路径
	//string GetDirectoryName(string path)    返回指定路径字符串的目录信息
	//string GetExtension(string path)    返回指定路径字符串的扩展名
	//string GetFileName(string path) 返回指定路径字符串的文件名和扩展名
	//string GetFileNameWithoutExtension(string path) 返回不具有扩展名的指定路径字符串的文件名
	//string GetFullPath(string path) 返回指定路径字符串的绝对路径
	//char[] GetInvalidFileNameChars()    获取包含不允许在文件名中使用的字符的数组
	//char[] GetInvalidPathChars()    获取包含不允许在路径名中使用的字符的数组
	//string GetPathRoot(string path) 获取指定路径的根目录信息
	//string GetRandomFileName()  返回随机文件夹名或文件名
	//string GetTempPath()    返回当前用户的临时文件夹的路径
	//bool HasExtension(string path)  返回路径是否包含文件的扩展名
	//bool IsPathRooted(string path)  返回路径字符串是否包含根


	public class PathClass
	{
		public static void SubPath()
		{
			string path = @"C:\Users\hp\Desktop\test.xlsx";
			Console.WriteLine("不包含扩展名的文件名：" + Path.GetFileNameWithoutExtension(path));
			Console.WriteLine("文件扩展名：" + Path.GetExtension(path));
			Console.WriteLine("文件全名：" + Path.GetFileName(path));
			Console.WriteLine("文件路径：" + Path.GetDirectoryName(path));
			//更改文件扩展名
			string newPath = Path.ChangeExtension(path, "xls");
			Console.WriteLine("更改后的文件全名：" + Path.GetFileName(newPath));
		}
	}

	// =============================================================== 7【StreamReader类：读取文件】 

	//在 C# 语言中 StreamReader 类用于从流中读取字符串。它继承自 TextReader 类。

	//StreamReader 类的构造方法有很多，这里介绍一些常用的构造方法，如下表所示。

	//构造方法 说明
	//StreamReader(Stream stream) 为指定的流创建 StreamReader 类的实例
	//StreamReader(string path)   为指定路径的文件创建 StreamReader 类的实例
	//StreamReader(Stream stream, Encoding encoding)  用指定的字符编码为指定的流初始化 StreamReader 类的一个新实例
	//StreamReader(string path, Encoding encoding)    用指定的字符编码为指定的文件名初始化 StreamReader 类的一个新实例
	//使用该表中的构造方法即可创建 StreamReader 类的实例，通过实例调用其提供的类成 员能进行文件的读取操作。

	//StreamReader 类中的常用属性和方法如下表所示。

	//属性或方法 作用
	//Encoding CurrentEncoding    只读属性，获取当前流中使用的编码方式
	//bool EndOfStream    只读属性，获取当前的流位置是否在流结尾
	//void Close()    关闭流
	//int Peek()  获取流中的下一个字符的整数，如果没有获取到字符， 则返回 -1
	//int Read()  获取流中的下一个字符的整数
	//int Read(char[] buffer, int index, int count)   从指定的索引位置开始将来自当前流的指定的最多字符读到缓冲区
	//string ReadLine()   从当前流中读取一行字符并将数据作为字符串返回
	//string ReadToEnd()  读取来自流的当前位置到结尾的所有字符

	public class StreamReaderClass
	{
		public static void SubStreamReader()
		{
			string path = @"C:\Users\hp\Desktop\code-1\test1.txt";                  // 定义文件路径
			StreamReader streamReader = new StreamReader(path);   // 创建 StreamReader 类的实例
																 
			while (streamReader.Peek() != -1)                     // 判断文件中是否有字符
			{
				string str = streamReader.ReadLine();             // 读取文件中的一行字符
				Console.WriteLine(str);
			}
			streamReader.Close();
		}
	}

	// =============================================================== 8【StreamWriter类：写入文件】 

	//在 C# 语言中与上一节《C# StreamReader 》中介绍的 StreamReader 类对应的是 StreamWriter 类，StreamWriter 类主要用于向流中写入数据。

	//StreamWriter 类的构造方法也有很多，这里只列出一些常用的构造方法，如下表所示。

	//构造方法 说明
	//StreamWriter(Stream stream)     为指定的流创建 StreamWriter 类的实例
	//StreamWriter(string path)   为指定路径的文件创建 StreamWriter 类的实例
	//StreamWriter(Stream stream, Encoding encoding)  用指定的字符编码为指定的流初始化 StreamWriter 类的一个新实例
	//StreamWriter(string path, Encoding encoding)    用指定的字符编码为指定的文件名初始化 StreamWriter 类的一个新实例
	//在创建了 StreamWriter 类的实例后即可调用其类成员，完成向文件中写入信息的操作。

	//StreamWriter 类中常用的属性和方法如下表所示。

	//属性或方法 作用
	//bool AutoFlush  属性，获取或设置是否自动刷新缓冲区
	//Encoding Encoding 只读属性，获取当前流中的编码方式
	//void Close()    关闭流
	//void Flush()    刷新缓冲区
	//void Write(char value)  将字符写入流中
	//void WriteLine(char value)  将字符换行写入流中
	//Task WriteAsync(char value) 将字符异步写入流中
	//Task WriteLineAsync(char value)     将字符异步换行写入流中
	//在上表中给出的方法中，Write、WriteAsync、WriteLineAsync 方法还有很多不同类型写入的重载方法，这里没有一一列出。

	public class StreamWriterClass
	{
		public static void SubStreamWriter()
		{
			string path = @"C:\Users\hp\Desktop\code-1\test1.txt";
			
			StreamWriter streamWriter = new StreamWriter(path); // 创建StreamWriter 类的实例
																
			streamWriter.WriteLine("小张");                     // 向文件中写入姓名

			streamWriter.WriteLine("13112345678");              // 向文件中写入手机号

			streamWriter.Flush();                               // 刷新缓存

			streamWriter.Close();                               // 关闭流

			Console.WriteLine("ok");
		}

	}

	// =============================================================== 9【FileStream类：文件读写】 


		//	在 C# 语言中文件读写流使用 FileStream 类来表示，FileStream 类主要用于文件的读写，不仅能读写普通的文本文件，还可以读取图像文件、声音文件等不同格式的文件。

		//在创建 FileStream 类的实例时还会涉及多个枚举类型的值， 包括 FileAccess、FileMode、FileShare、FileOptions 等。

		//FileAccess 枚举类型主要用于设置文件的访问方式，具体的枚举值如下。
		//Read：以只读方式打开文件。
		//Write：以写方式打开文件。
		//ReadWrite：以读写方式打开文件。

		//FileMode 枚举类型主要用于设置文件打开或创建的方式，具体的枚举值如下。
		//CreateNew：创建新文件，如果文件已经存在，则会抛出异常。
		//Create：创建文件，如果文件不存在，则删除原来的文件，重新创建文件。
		//Open：打开已经存在的文件，如果文件不存在，则会抛出异常。
		//OpenOrCreate：打开已经存在的文件，如果文件不存在，则创建文件。
		//Truncate：打开已经存在的文件，并清除文件中的内容，保留文件的创建日期。如果文件不存在，则会抛出异常。
		//Append：打开文件，用于向文件中追加内容，如果文件不存在，则创建一个新文件。

		//FileShare 枚举类型主要用于设置多个对象同时访问同一个文件时的访问控制，具体的枚举值如下。
		//None：谢绝共享当前的文件。
		//Read：允许随后打开文件读取信息。
		//ReadWrite：允许随后打开文件读写信息。
		//Write：允许随后打开文件写入信息。
		//Delete：允许随后删除文件。
		//Inheritable：使文件句柄可由子进程继承。

		//FileOptions 枚举类型用于设置文件的高级选项，包括文件是否加密、访问后是否删除等，具体的枚举值如下。
		//WriteThrough：指示系统应通过任何中间缓存、直接写入磁盘。
		//None：指示在生成 System.IO.FileStream 对象时不应使用其他选项。
		//Encrypted：指示文件是加密的，只能通过用于加密的同一用户账户来解密。
		//DeleteOnClose：指示当不再使用某个文件时自动删除该文件。
		//SequentialScan：指示按从头到尾的顺序访问文件。
		//RandomAccess：指示随机访问文件。
		//Asynchronous：指示文件可用于异步读取和写入。

		//FileStream 类的构造方法有很多，这里介绍一些常用的构造方法，如下表所示。

		//构造方法 说明
		//FileStream(string path, FileMode mode) 使用指定路径的文件、文件模式创建 FileStream 类的实例
		//FileStream(string path, FileMode mode, FileAccess access) 使用指定路径的文件、文件打开模式、文件访问模式创建 FileStream 类的实例
		//FileStream(string path, FileMode mode, FileAccess access, FileShare share) 使用指定的路径、创建模式、读写权限和共享权限创建 FileStream 类的一个新实例
		//FileStream(string path, FileMode mode, FileAccess access, FileShare share, int bufferSize, FileOptions options) 使用指定的路径、创建模式、读写权限和共享权限、其他 文件选项创建 FileStream 类的实例
		//下面使用 FileStream 类的构造方法创建 FileStream 类的实例，语法形式如下。
		//string path = "D:\\test.txt";
		//	FileStream fileStream1 = new FileStream(path, FileMode.Open);
		//	FileStream fileStream2 = new FileStream(path, FileMode.Open, FileAccess.Read);
		//	FileStream fileStream3 = new FileStream(path, FileMode.Open, FileAccess.ReadWrite, FileShare.Read);
		//	FileStream fileStream4 = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read, 10, FileOptions.None);
		//	在创建好 FileStream 类的实例后，即可调用该类中的成员完成读写数据的操作。

		//FileStream 类中常用的属性和方法如下图所示。

		//属性或方法 作用
		//bool CanRead    只读属性，获取一个值，该值指示当前流是否支持读取
		//bool CanSeek    只读属性，获取一个值，该值指示当前流是否支持查找
		//bool CanWrite   只读属性，获取一个值，该值指示当前流是否支持写入
		//bool IsAsync    只读属性，获取一个值，该值指示 FileStream 是异步还 是同步打开的
		//long Length 只读属性，获取用字节表示的流长度
		//string Name 只读属性，获取传递给构造方法的 FileStream 的名称
		//long Position   属性，获取或设置此流的当前位置
		//int Read(byte[] array, int offset, int count)   从流中读取字节块并将该数据写入给定缓冲区中
		//int ReadByte()  从文件中读取一个字节，并将读取位置提升一个字节
		//long Seek(lorig offset, SeekOrigin origin)  将该流的当前位置设置为给定值
		//void Lock(long position, long length)   防止其他进程读取或写入 System.IO.FileStream
		//void Unlock(long position, long length) 允许其他进程访问以前锁定的某个文件的全部或部分
		//void Write(byte[] array, int offset, int count) 将字节块写入文件流
		//void WriteByte(byte value) 将一个字节写入文件流中的当前位置


	public class FileStreamClass
	{
		public static void SubFileStream_Write()
		{
			
			string path = @"C:\Users\hp\Desktop\code-1\test1.txt";   // 定义文件路径
																	 //创建 FileStream 类的实例
			FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
			
			string msg = "1710026";                       // 定义学号

			byte[] bytes = Encoding.UTF8.GetBytes(msg);   // 将字符串转换为字节数组

			fileStream.Write(bytes, 0, bytes.Length);     // 向文件中写入字节数组
														
			fileStream.Flush();    // 刷新缓冲区

			fileStream.Close();    // 关闭流

			Console.WriteLine("ok");
		}

		public static void SubFileStream_Read()
		{
			string path = @"C:\Users\hp\Desktop\code-1\test1.txt";

			if (File.Exists(path))   // 判断是否含有指定文件
			{
				FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
				
				byte[] bytes = new byte[fileStream.Length]; // 定义存放文件信息的字节数组
															
				fileStream.Read(bytes, 0, bytes.Length);    // 读取文件信息
														   
				char[] c = Encoding.UTF8.GetChars(bytes);   // 将得到的字节型数组重写编码为字符型数组
				Console.WriteLine("学生的学号为：");

				Console.WriteLine(c);
				fileStream.Close();
			}
			else
			{
				Console.WriteLine("您查看的文件不存在！");
			}

		}

	}
	// =============================================================== 10【BinaryReader类：读取二进制文件】 

		//	在 C# 以二进制形式读取数据时使用的是 BinaryReader 类。

		//BinaryReader 类中提供的构造方法有 3 种，具体的语法形式如下。

		//第1种形式：
		//BinaryReader(Stream input)   //其中，input 参数是输入流。

		//第2种形式：
		//BinaryReader(Stream input, Encoding encoding)   //其中，input 是指输入流，encoding 是指编码方式。

		//第3种形式：
		//BinaryReader(Stream input, Encoding encoding, bool leaveOpen)  //其中，input 是指输入流，encoding 是指编码方式，leaveOpen 是指在流读取后是否包括流的打开状态。

		//下面分别使用不同的构造方法创建 BinaryReader 类的实例，代码如下。
		////创建文件流的实例
		//FileStream fileStream = new FileStream("D:\\code\\test.txt", FileMode.Open);
		//	BinaryReader binaryReader1 = new BinaryReader(fileStream);
		//	BinaryReader binaryReader2 = new BinaryReader(fileStream, Encoding.UTF8);
		//	BinaryReader binaryReader3 = new BinaryReader(fileStream, Encoding.UTF8, true);
		//	在完成 BinaryReader 类的实例的创建后，即可完成对文件以二进制形式的读取。

		//BinaryReader 类中的常用属性和方法如下表所示。

		//属性或方法 作用
		//int Read()  从指定的流中读取字符
		//int Read(byte[] buffer, int index, int count)   以 index 为字节数组中的起始点，从流中读取 count 个字节
		//int Read(char[] buffer, int index, int count)   以 index 为字符数组的起始点，从流中读取 count 个字符
		//bool ReadBoolean()  从当前流中读取 Boolean 值，并使该流的当前位置提升 1 个字节
		//byte ReadByte() 从当前流中读取下一个字节，并使流的当前位置提升 1 个字节
		//byte[] ReadBytes(int count) 从当前流中读取指定的字节数写入字节数组中，并将当前 位置前移相应的字节数
		//char ReadChar() 从当前流中读取下一个字符，并根据所使用的 Encoding 和从流中读取的特定字符提升流的当前位置
		//char[] ReadChars(int count) 从当前流中读取指定的字符数，并以字符数组的形式返回 数据，然后根据所使用的 Encoding 和从流中读取的特定字符将当前位置前移
		//decimal ReadDecimal()   从当前流中读取十进制数值，并将该流的当前位置提升 16 个字节
		//double ReadDouble() 从当前流中读取 8 字节浮点值，并使流的当前位置提升 8 个字节
		//short ReadInt16()   从当前流中读取 2 字节有符号整数，并使流的当前位置提升 2 个字节
		//int ReadInt32() 从当前流中读取 4 字节有符号整数，并使流的当前位置提升 4 个字节
		//long ReadInt64()    从当前流中读取 8 字节有符号整数，并使流的当前位置提升 8 个字节
		//sbyte ReadSByte()   从该流中读取 1 个有符号字节，并使流的当前位置提升 1 个字节
		//float ReadSingle()  从当前流中读取 4 字节浮点值，并使流的当前位置提升 4 个字节
		//string ReadString() 从当前流中读取一个字符串。字符串有长度前缀，一次 7 位地被编码为整数
		//ushort ReadUInt16() 从该流中读取的 2 字节无符号整数
		//uint ReadUInt32()   从该流中读取的 4 字节无符号整数
		//ulong ReadUInt64()  从该流中读取的 8 字节无符号整数
		//void FillBuffer(int numBytes)   用从流中读取的指定字节数填充内部缓冲区
		//在 BinaryReader 类中提供的方法并不是直接读取文件中指定数据类型的值，而是读取由 BinaryWriter 类写入到文件中的。

		//在上述方法中只有 Read 方法不要求读取的值必须由 BinaryWriter 类写入到文件中。


	public class BinaryReaderClass
	{
		public static void SubBinaryReader() // —————————————————— 每个字符读取输出
		{
			FileStream fileStream = new FileStream(@"C:\Users\hp\Desktop\code-1\test1.txt", FileMode.Open);
			BinaryReader binaryReader = new BinaryReader(fileStream);
			
			int a = binaryReader.Read();         // 读取文件的一个字符
											 
			while (a != -1)                      // 判断文件中是否含有字符，若不含字符，a 的值为 -1
			{
				Console.WriteLine((char)a);          // 输出读取到的字符
				a = binaryReader.Read();
			}

			Console.WriteLine("ok");
		}

		public static void SubBinaryReader_byte() // —————————Read 方法的其他重载方法将字符读取到一个字节数组或字符数组中
		{
			FileStream fileStream = new FileStream(@"C:\Users\hp\Desktop\code-1\test1.txt", FileMode.Open, FileAccess.Read);
			BinaryReader binaryReader = new BinaryReader(fileStream);
			
			long length = fileStream.Length;      // 获取文件长度
			byte[] bytes = new byte[length];      // 读取文件中的内容并保存到字节数组中

			binaryReader.Read(bytes, 0, bytes.Length);
			
			string str = Encoding.Default.GetString(bytes);  //将字节数组转换为字符串
			Console.WriteLine(str);
		}

	}
	// =============================================================== 11【BinaryWriter类：写入二进制数据】 

		//C# 中 BinaryWriter 类用于向流中写入内容，其构造方法与上一节《C# BinaryReader》中介绍的 BinaryReader 类中的类似，具体的语法形式如下。

		//第1种形式：
		//BinaryWriter(Stream output)

		//第2种形式：
		//BinaryWriter(Stream output, Encoding encoding)

		//第3种形式：
		//BinaryWriter(Stream output, Encoding encoding, bool leaveOpen)

		//BinaryWriter 类中常用的属性和方法如下表所示。

		//属性或方法 作用
		//void Close()    关闭流
		//void Flush()    清理当前编写器的所有缓冲区，使所有缓冲数据写入基础设备
		//long Seek(int offset, SeekOrigin origin)    返回查找的当前流的位置
		//void Write(char[] chars)    将字符数组写入当前流
		//Write7BitEncodedInt(int value)  以压缩格式写出 32 位整数
		//除了上面的方法以外，Write 方法还提供了多种类型的重载方法。


	public class BinaryWriterClass
	{
		public static void SubBinaryWriter()
		{
			FileStream fileStream = new FileStream(@"C:\Users\hp\Desktop\code-1\test1.txt", FileMode.Open, FileAccess.Write);
			BinaryWriter binaryWriter = new BinaryWriter(fileStream); //创建二进制写入流的实例
			binaryWriter.Write("C#基础教程");
			binaryWriter.Write(49.5);
			
			binaryWriter.Flush(); // 清除缓冲区的内容，将缓冲区中的内容写入到文件中
			binaryWriter.Close(); // 关闭二进制流		  
			fileStream.Close();   // 关闭文件流

			fileStream = new FileStream(@"C:\Users\hp\Desktop\code-1\test1.txt", FileMode.Open, FileAccess.Read);
			//创建二进制读取流的实例
			BinaryReader binaryReader = new BinaryReader(fileStream);
			Console.WriteLine(binaryReader.ReadString());
			Console.WriteLine(binaryReader.ReadDouble());
			binaryReader.Close();
			fileStream.Close();

		}
	}






}
