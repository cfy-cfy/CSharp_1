using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using ADODB;
using System.Text.RegularExpressions;
using Scripting;
using System.Runtime.InteropServices;
namespace VSTOBOOK
{
    class CSharpAdvanced
    {
        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll")]
        private static extern bool SetWindowText(IntPtr hwnd, string lPstring);
        public string result;
        public void 文件与文件夹操作()
        {   //using System.IO            
            bool b = System.IO.File.Exists(@"F:\abc.ppt");
            if (b == true)
            {
                result = b.ToString();
                System.IO.File.Delete(@"F:\abc.ppt"); //删除文件
            }
            bool f = Directory.Exists(@"F:\VSTO");
            if (f == true)
            {
                result =f.ToString();
                string[] arr = Directory.GetFiles(@"F:\VSTO"); //列举文件夹中所有文件路径.
                for (int i = 0; i < arr.Length; i++)
                {
                    result += arr[i] + "\n";
                }
            }
        }
        public void 文本文件的读写()
        {   //using System.IO
            string path = @"F:\VSTO\a.txt";
            FileStream fs = new FileStream(path, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            //开始写入
            sw.WriteLine("Hello VSTO");
            sw.WriteLine("Second Line");
            sw.WriteLine("3th Line");
            //清空缓冲区
            sw.Flush();
            //关闭流
            sw.Close();
            fs.Close();
            //读入内容
            StreamReader sr = new StreamReader(path, Encoding.Default);
            String line;
            result = "";
            while ((line = sr.ReadLine()) != null)
            {
                result += line + "\n";
            }
        }
        public void 使用ADODB访问Access数据库()
        {
            //添加引用Microsoft ActiveX Data Objects 2.8 Library
            Recordset rs;
            Connection cn;
            cn = new Connection();
            rs = new Recordset();
            cn.Open(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\Private\ADOSQLwizard\示例数据源\Access2003数据库.mdb;Persist Security Info=False;");
            rs.Open(@"Select * from NewID", cn, CursorTypeEnum.adOpenKeyset, LockTypeEnum.adLockOptimistic, (int)CommandTypeEnum.adCmdText);
            foreach (Field fd in rs.Fields)
            {           
                result += fd.Name + "\n";
                //遍历字段名称.
            }
            while (rs.EOF == false)
            {
                //遍历记录中的"性别"字段.
                result += rs.Fields["性别"].Value+ "\n";
                rs.MoveNext();
            }
            rs.Close();
            cn.Close(); 
        }
        public void 使用资源文件()
        {   //为项目添加名为Resource1的资源文件
            result = Resource1.code.ToString();//使用资源字符串;
        }
        public void 使用正则表达式()
        {   //using System.Text.RegularExpressions;
            Regex exp = new Regex(@"^\d{6}$");
            bool b = exp.IsMatch("59684200");//匹配该字符串是不是恰好6个数字.
            result = b.ToString();
            exp = new Regex("[a-z]");
            result += exp.Replace("Visual Studio 2012", "*"); //替换每一个小写字母为*
            exp = new Regex("[a-z]", options: RegexOptions.IgnoreCase | RegexOptions.Multiline); //忽略大小写,多行.
            result += exp.Replace("Visual Studio 2012", "*"); //替换每一个字母为*
            //搜索符合模式的子字符串       
            MatchCollection Col=Regex.Matches("Address:No206,Email:32669315@qq.com,phone:136,etc.",@"\d+");        
            //匹配所有连续的数字
            for (int i = 0; i < Col.Count; i++)
            {
                result += Col[i].Value + "\n";
            }
        }
        public void 使用字典()
        {
            //添加引用Microsoft Scripting Runtime
            //using Scripting
            Dictionary<int, string> dic = new Dictionary<int, string>();
            dic.Add(1, "one");
            dic.Add(3, "three");
            dic.Add(5, "five");
            dic.Add(7, "seven");
            bool exist = dic.ContainsKey(4);
            result = exist.ToString();
            dic[7] = "Ten";
            result += dic[7];
            foreach (string v in dic.Values)
            {
                result += v+ "\n";
            }
            foreach (KeyValuePair<int, string> p in dic)
            {
                result += p.Key + "\t" + p.Value + "\n";
            }
        }
        public void 窗体的显示和卸载()
        {
            Form2 f2 = new Form2();
            f2.Show();//显示窗体
            //f2.Dispose();//关闭窗体            
        }
        public void 使用API函数()
        {
            //using System.Runtime.InteropServices;
            //类模块顶部增加[DllImport("User32.dll", EntryPoint = "FindWindow")]private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
            //运行本过程前,请事先打开 计算器.
            IntPtr hwnd = FindWindow(null, "计算器"); //计算器程序的类名一般为calc或calcFrame
            long h =(long)hwnd;
            result = h.ToString();//返回窗口的句柄
            bool flag = SetWindowText(hwnd,"New Title: Hello VSTO"); //改变计算器标题文字
        }
    }
}
