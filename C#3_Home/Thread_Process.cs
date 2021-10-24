using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Threading;

namespace WindowsForms_Excel_1
{
	class Thread_Process
	{
	}

	//————————————————————————————————— System.Diagnostics  1【Process：进程类】

	//Process 类主要提供对本地和远程进程的访问，并提供对本地进程的启动、停止等操作。

	//Process 类的常用属性和方法如下表所示。

	//属性或方法 说明
	//MachineName 属性，获取关联进程正在其上运行的计算机的名称
	//Id  属性，获取关联进程的唯一标识符
	//ExitTime    属性，获取关联进程退出的时间
	//ProcessName 属性，获取该进程的名称
	//StartTime   属性，获取关联进程启动的时间
	//Threads 属性，获取在关联进程中运行的一组线程
	//TotalProcessorTime  属性，获取此进程的总的处理器时间
	//UserProcessorTime   属性，获取此进程的用户处理器时间
	//Close() 方法，释放与此组件关联的所有资源
	//CloseMainWindow()   方法，通过向进程的主窗口发送关闭消息来关闭拥有用户界面的进程
	//Dispose()   方法，释放由 Component 使用的所有资源
	//GetCurrentProcess() 方法，获取新的 Process 组件，并将其与当前活动的进程关联
	//GetProcesses()  方法，为本地计算机上的每个进程资源创建一个新的 Process 组件
	//GetProcesses(String)    方法，为指定计算机上的每个进程资源创建一个新的 Process 组件
	//GetProcessesByName(String)  方法，创建新的 Process 组件的数组，并将它们与本地计算机上共享指定的进程名称的所有进程资源关联
	//Kill()  方法，立即停止关联的进程
	//Start() 方法，启动（或重用）此 Process 组件的 Startinfo 属性指定的进程资源， 并将其与该组件关联
	//Start(String)   方法，通过指定文档或应用程序文件的名称来启动进程资源，并将资源与新的 Process 组件关联

	public class ProcessClass
	{


		public static void SubProcess()
		{
			Process[] processes = Process.GetProcesses();
			foreach (Process p in processes)
			{
				Debug.WriteLine(p.ProcessName);     // ——————————【 查看所有进程 】
			}

		}

		public static void SubProcess_start()     // —————————— 【 启动进程 】
		{

			string ProcessName = "mspaint";
			//创建Process 类的对象
			Process p = new Process();
			//设置进程名称
			p.StartInfo.FileName = ProcessName;
			//启动进程
			p.Start();

		}

	}

	public class ProcessStop     // —————————— 关闭listbox选择的进程并刷新列表
	{
		Form2 frm2;
		public ProcessStop(Form2 f)
		{
			frm2 = f;
		}
		public void SubProcess_stop()
		{
			
			//获取进程名称
			string ProcessName = frm2.listBox1.SelectedItem.ToString();
			//根据进程名称获取进程
			Process[] processes = Process.GetProcessesByName(ProcessName);
			//判断是否存在指定进程名称的进程
			if (processes.Length > 0)
			{
				try
				{
					foreach (Process p in processes)
					{
						//判断进程是否处于运行状态
						if (!p.HasExited)
						{
							//关闭进程
							p.Kill();
							MessageBox.Show(p.ProcessName + "已关闭！");
							//获取所有进程信息
							processes = Process.GetProcesses();
							//清空ListBox中的项

							frm2.listBox1.Items.Clear();
							foreach (Process p1 in processes)
							{
								//将进程添加到ListBox中
								frm2.listBox1.Items.Add(p1.ProcessName);
							}
						}
					}
				}
				catch
				{
					MessageBox.Show("该进程无法关闭！");
				}
			}
		}

	}

	public class Class1  // ——————— 获取显示 form2 文本框的内容【要在form.designer将textbox设置为 public】
	{
		Form2 frm2;
		public Class1(Form2 f)
		{
			frm2 = f;
		}

		public string GetTextStr()
		{
			return frm2.textBox1.Text;
		}

	}

	public class Class2  // ——————— 获取显示 form1 文本框的内容【要在form.designer将textbox设置为 public】
	{
		public static void GetTextStr()
		{
			Form1 frm1 = new Form1();
			frm1.Show();
			frm1.textBox1.Text="香飘飘";
			//frm1.Text="香飘飘";

		}

	}
	//—————————————————————————————————————— 2【System.Threading】 

	//与线程有关的类同样也都在 System.Threading 命名空间中，主要的类如下表所示。

	//类名 说明
	//Thread 在初始的应用程序中创建其他的线程
	//ThreadState 指定 Thread 的执行状态，包括开始、运行、挂起等
	//ThreadPriority  线程在调度时的优先级枚举值，包括 Highest、AboveNormal、Normal、BelowNormal、Lowest
	//ThreadPool  提供一个线程池，用于执行任务、发送工作项、处理异步I/O等操作
	//Monitor 提供同步访问对象的机制
	//Mutex   用于线程间同步的操作
	//ThreadAbortException    调用Thread类中的Abort方法时出现的异常
	//ThreadStateException    Thead处于对方法调用无效的ThreadState时出现的异常
	//Thread 类主要用于实现线程的创建以及执行，其常用的属性和方法如下表所示。

	//属性或方法 说明
	//Name 属性，获取或设置线程的名称
	//Priority    属性，获取或设置线程的优先级
	//ThreadState 属性，获取线程当前的状态
	//IsAlive     属性，获取当前线程是否处于启动状态
	//IsBackground    属性，获取或设置值，表示该线程是否为后台线程
	//CurrentThread   属性，获取当前正在运行的线程
	//Start() 方法，启动线程
	//Sleep(int millisecondsTimout) 方法，将当前线程暂停指定的毫秒数
	//Suspend() 方法，挂起当前线程（已经被弃用）
	//Join() 方法，阻塞调用线程，直到某个线程终止为止
	//Interrupt() 方法，中断当前线程
	//Resume() 方法，继续已经挂起的线程（已经被弃用）
	//Abort() 方法，终止线程

	//—————————————————————————————— 3 【 ThreadStart：创建线程 】
	public class ThreadStartClass1
	{
		public static void SubThreadStart()
		{
			ThreadStart ts = new ThreadStart(PrintEven);
			Thread t = new Thread(ts);
			t.Start();
		}
		//定义打印0~10中的偶数的方法
		private static void PrintEven()
		{
			for (int i = 0; i <= 10; i = i + 2)
			{
				Console.WriteLine(i);
			}
		}
	}

	//———————————————————————————————
	// 由于没有对线程的执行顺序和操作做控制，所以运行该程序每次打印的值的顺序是不一样的。
	public class ThreadStartClass2
	{
		public static void SubThreadStart() 
		{
			ThreadStart ts1 = new ThreadStart(PrintEven);
			Thread t1 = new Thread(ts1);
			ThreadStart ts2 = new ThreadStart(PrintOdd);
			Thread t2 = new Thread(ts2);
			t1.Start();
			t2.Start();
		}
		//定义打印0~10中的偶数的方法
		private static void PrintEven()
		{
			for (int i = 0; i <= 10; i = i + 2)
			{
				Console.WriteLine(i);
			}
		}
		//定义打印1~10 中的奇数的方法
		public static void PrintOdd()
		{
			for (int i = 1; i <= 10; i = i + 2)
			{
				Console.WriteLine(i);
			}
		}
	}

	//—————————————————————————————— 4 【 ParameterizedThreadStart：创建进程 】

	//在使用 ParameterizedThreadStart 委托调用带参数的方法时，方法中的参数只能是 object 类型并且只能含有一个参数。

	public class ParameterizedThreadStartClass1
	{
		public static void SubParameterizedThreadStart()
		{
			ParameterizedThreadStart pts = new ParameterizedThreadStart(PrintEven);
			Thread t = new Thread(pts);
			t.Start(10);
		}
		//打印0~n中的偶数
		private static void PrintEven(Object n)
		{
			for (int i = 0; i <= (int)n; i = i + 2)
			{
				Console.WriteLine(i);
			}
		}
	}

	//————————————————————————————————————
	//如果需要通过 ParameterizedThreadStart 委托引用多个参数的方法，由于委托方法中的参数是 object 类型的，
	//传递多个参数可以通过类的实例来实现。

	public class ParameterizedThreadStartClass2
	{
		public static void SubParameterizedThreadStart()
		{
			ParameterizedThreadStart pts = new ParameterizedThreadStart(PrintEven);
			Thread t = new Thread(pts);
			ParameterTest pt = new ParameterTest(3, 10);
			t.Start(pt);
		}
		private static void PrintEven(Object n)
		{
			//判断n是否为ParameterTest 类的对象
			if (n is ParameterTest)
			{
				int beginNum = ((ParameterTest)n).beginNum;
				int endNum = ((ParameterTest)n).endNum;
				for (int i = beginNum; i <= endNum; i++)
				{
					if (i % 2 == 0)
					{
						Console.WriteLine(i);
					}
				}
			}
		}
	}
	public class ParameterTest
	{
		public int beginNum;
		public int endNum;
		public ParameterTest(int a, int b)
		{
			this.beginNum = a;
			this.endNum = b;
		}
	}

	//——————————————————————————————》》》》》 5 【 Priority：多线程优先级设置 】

	public class PriorityClass
	{
		public static void SubPriority()
		{
			ThreadStart ts1 = new ThreadStart(PrintEven);
			Thread t1 = new Thread(ts1);
			t1.Priority = ThreadPriority.Lowest;    // 设置打印偶数线程的优先级

			ThreadStart ts2 = new ThreadStart(PrintOdd);
			Thread t2 = new Thread(ts2);
			t2.Priority = ThreadPriority.Highest;   // 设置打印奇数线程的优先级
			t1.Start();
			t2.Start();
		}
		//打印1~100中的奇数
		public static void PrintOdd()
		{
			for (int i = 1; i <= 20; i = i + 2)
			{
				Console.WriteLine(i);
			}
		}
		//打印0~100中的偶数
		public static void PrintEven()
		{
			for (int i = 0; i <= 20; i = i + 2)
			{
				Console.WriteLine(i);
			}
		}
	}

	//——————————————————————————————— 6 【 Priority + Sleep 】
	//通过 Sleep 方法能控制两个线程执行的先后顺序。
	//需要注意的是，两个线程虽然交替执行，但每次运行该程序的效果依然是不同的。

	public class SleepClass
	{
		public static void SubSleep()
		{
			ThreadStart ts1 = new ThreadStart(PrintOdd);
			Thread t1 = new Thread(ts1);
			ThreadStart ts2 = new ThreadStart(PrintEven);
			Thread t2 = new Thread(ts2);
			t1.Start();
			t2.Start();
		}
		//打印1~10中的奇数
		public static void PrintOdd()
		{
			for (int i = 1; i <= 10; i = i + 2)
			{
				//让线程休眠 1 秒
				Thread.Sleep(1000);
				Console.WriteLine(i);
			}
		}
		//打印0~10中的偶数
		public static void PrintEven()
		{
			for (int i = 0; i <= 10; i = i + 2)
			{
				Console.WriteLine(i);
				//让线程休眠 1 秒
				Thread.Sleep(1000);
			}
		}
	}

	//——————————————————————————————— 7 【 Abort 】
	// 模拟发放 10 个红包，当剩余 5 个红包时线程终止。

	public class AbortClass
	{
		private static int count = 10;
		private static void GiveRedEnvelop()
		{
			while (count > 0)
			{
				count--;
				if (count == 4)
				{
					//终止当前线程
					Console.WriteLine("红包暂停发放！");
					Thread.CurrentThread.Abort();
				}
				Console.WriteLine("剩余 {0} 个红包", count);
			}
		}
		public static void SubAbort()
		{
			ThreadStart ts = new ThreadStart(GiveRedEnvelop);
			Thread t = new Thread(ts);
			t.Start();

			if (t.IsBackground == false)
			{
				Console.WriteLine("该线程不是后台线程！");
				t.IsBackground = true;
			}
			else
			{
				Console.WriteLine("该线程是后台线程！");
			}

		}
	}

	//——————————————————————————————— 8 【 lock：给线程加锁，保证线程同步 】

	//创建控制台应用程序，使用 lock 关键字控制打印奇数和偶数的线程，要求先执行奇数线程，再执行偶数线程。
	//当打印奇数的线程结束后才执行打印偶数的线程，并且每次打印的效果是一样的。

	public class LockClass
	{
		public void PrintEven()
		{
			lock (this)
			{
				for (int i = 0; i <= 10; i = i + 2)
				{
					Console.WriteLine(Thread.CurrentThread.Name + "--" + i);
				}
			}
		}
		public void PrintOdd()
		{
			lock (this)
			{
				for (int i = 1; i <= 10; i = i + 2)
				{
					Console.WriteLine(Thread.CurrentThread.Name + "--" + i);
				}
			}
		}
		public static void SubLockC()
		{
			LockClass program = new LockClass();
			ThreadStart ts1 = new ThreadStart(program.PrintOdd);
			Thread t1 = new Thread(ts1);
			t1.Name = "打印奇数的线程";
			t1.Start();

			ThreadStart ts2 = new ThreadStart(program.PrintEven);
			Thread t2 = new Thread(ts2);
			t2.Name = "打印偶数的线程";
			t2.Start();
		}
	}

	//——————————————————————————————— 9 【 Monitor：锁定资源 】

	//Monitor 类的用法虽然比 lock 关键字复杂，但其能添加等待获得锁定的超时值，这样就不会无限期等待获得对象锁。

	//使用 TryEnter() 方法可以给它传送一个超时值，决定等待获得对象锁的最长时间。

	//使用 TryEnter() 方法设置获得对象锁的时间的代码如下。
	//Monitor.TryEnter(object, 毫秒数);

	//该方法能在指定的毫秒数内结束线程，这样能避免线程之间的死锁现象。

	//此外，还能使用 Monitor 类中的 Wait() 方法让线程等待一定的时间，使用 Pulse() 方法通知处于等待状态的线程。

	public class MonitorClass
	{
		public void PrintEven()
		{
			Monitor.Enter(this);
			try
			{
				for (int i = 0; i <= 10; i = i + 2)
				{
					Console.WriteLine(Thread.CurrentThread.Name + "--" + i);
				}
			}
			finally
			{
				Monitor.Exit(this);
			}
		}
		public void PrintOdd()
		{
			Monitor.Enter(this);
			try
			{
				for (int i = 1; i <= 10; i = i + 2)
				{
					Console.WriteLine(Thread.CurrentThread.Name + "--" + i);
				}
			}
			finally
			{
				Monitor.Exit(this);
			}
		}
		public static void SubMonitor()
		{
			MonitorClass program = new MonitorClass();
			ThreadStart ts1 = new ThreadStart(program.PrintOdd);
			Thread t1 = new Thread(ts1);
			t1.Name = "打印奇数的线程";
			t1.Start();

			ThreadStart ts2 = new ThreadStart(program.PrintEven);
			Thread t2 = new Thread(ts2);
			t2.Name = "打印偶数的线程";
			t2.Start();
		}
	}

	//———————————————————————— 10 【 Mutex：（互斥锁）线程同步 + ParameterizedThreadStart 】

	//C# 中 Mutex 类也是用于线程同步操作的类，例如，当多个线程同时访问一个资源时保证一次只能有一个线程访问资源。

	//在 Mutex 类中，WaitOne() 方法用于等待资源被释放， ReleaseMutex() 方法用于释放资源。

	//WaitOne() 方法在等待 ReleaseMutex() 方法执行后才会结束。

	public class MutexClass   //————————————————使用线程互斥实现每个车位每次只能停一辆车的功能。
	{
		private static Mutex mutex = new Mutex();
		public static void PakingSpace(object num)
		{
			if (mutex.WaitOne())
			{
				try
				{
					Console.WriteLine("车牌号{0}的车驶入！", num);
					Thread.Sleep(1000);
				}
				finally
				{
					Console.WriteLine("车牌号{0}的车离开！", num);
					mutex.ReleaseMutex();
				}
			}
		}
		public static void SubMutex()
		{
			ParameterizedThreadStart ts = new ParameterizedThreadStart(PakingSpace);
			Thread t1 = new Thread(ts);
			t1.Start("冀A12345");
			Thread t2 = new Thread(ts);
			t2.Start("京A00000");
		}
	}

}
