#define debug   //定义条件
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ConsoleApp1
{
    class Program
    { 
        // DllImport Attribute用来标记非.NET的函数，表明该方法在一个外部的DLL中定义。 此例子：表明了MessageBox是User32.DLL中的函数，这样我们就可以像内部方法一样调用这个函数。
        // [DllImport("User32.dll")]
        // public static extern int MessageBox(int hParent, string Message, string Caption, int Type);

        [Conditional("debug")]
        private static void DisplayRunningMessage()
        {
            Console.WriteLine($"开始运行Main子程序。当前时间是{DateTime.Now}");
        }

        [Conditional("debug")]
        private static void DisplayDebugMessage()
        {
            Console.WriteLine("开始Main子程序");
        } 

        static void Main(string[] args)
        { 
            DisplayRunningMessage();
            DisplayDebugMessage();
            // MessageBox(0, "Hello", "Message", 0); 
        }
    }
}
