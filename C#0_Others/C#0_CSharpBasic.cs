using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VSTOBOOK
{
    class CSharpBasic
    {
        public string result;
        public void 变量的声明和赋值()
        {
            int i;
            i = 34;
            string s = @"e:\ab\cd.txt";
            result = i + s;
        }
        public void 遍历字符串中的字符()
        {
            char c;
            string s = "microsoft office";
            for (int i = 0; i < s.Length; i++)
            {   //遍历字符串中的每一个字符.
                c = s[i];
                result += "\n" + c;
            }
        }
        public void 格式化字符串()
        {
            string s0="format",s1="micro",s2="soft",s3 ="visual" ,s4="studio";
            result =String.Format("result is {0} {3} {4}",s0,s1,s2,s3,s4);
        }
        public void 字符串与数组()
        {   //字符串转数组;
            string source = "micro soft Visual studio";
            string[] arr = source.Split(' ');
            foreach (string v in arr)
            { result += v + "\n"; }
            //数组转字符串
            result += string.Join("+",arr);
        }
        public void 布尔型变量()
        {
            bool flag;
            flag = (1 > -1);
            result = flag.ToString();
        }
        public void 多条件的且或非运算()
        {
            bool flag;
            flag = !(true && false || true);
            result = flag.ToString();
        }
        public void 不同类型的强制转换()
        {
            int i = 30;
            string s = i.ToString();//整型转字符串
            s = "30.65";
            float f = float.Parse(s); //字符串转浮点型
            double d = (double)f; //浮点型转双精度
            int j = (int)d; //双精度转整型
            result = i + s + f + d + j + "";
        }
        public void 一维数组()
        {
            string[] arr = { "ab", "cd" };
            int[] a = new int[3];
            a[0] = 3; a[1] = 4; a[2] = 5;
            result = arr[0] + arr[1];
            foreach (var v in a)//遍历数组元素
            {
                result += v.ToString();
            }
        }
        public void 二维数组()
        {
            int[,] a = { { 1, 2, 3 }, { 4, 5, 6 } };
            result = a[0, 0] + "\t" + a[1, 2];
            string[,] arr = new string[2, 4];
            for (int i = 0; i < 2; i++)//二维数组赋值
            {
                for (int j = 0; j < 4; j++)
                {
                    arr[i, j] = (i * 10 + j).ToString();
                }
            }
            result += arr[1, 1];
        }
        public void if语句()
        {
            int i = -3;
            if (i > 0)
            { result = "正数"; }
            else if (i < 0)
            { result = "负数"; }
            else
            { result = "零"; }
        }
        public void switch语句()
        {
            int i = 3;
            switch (i)
            {
                case 1:
                case 3:
                case 5:
                    result = "奇数";
                    break;
                case 2:
                case 4:
                case 6:
                    result = "偶数";
                    break;
                default:
                    result = "不明确";
                    break;
            }
        }
        public void 简单选择语句()
        {   //逻辑表达式?结果1:结果2
            int i = 11;
            int j = 2;
            result = i % j == 0 ? "100" : "-100";
        }
        public void while循环()
        {
            int i = 10;
            while (i > 0)
            {
                result += i + "\n";
                i--;
            }
        }
        public void do循环()
        {   //至少执行一次循环体内容.
            int i = 10;
            do
            {
                result += i + "\n";
                i--;
            }
            while (i > 0);
        }
        public void for循环()
        {
            for (int i = 1; i < 5; i++)
            {
                result += i + "\n";
            }
        }
        public void foreach循环()
        {
            int[] arr = { 1, 3, 5, 7 };
            foreach (int i in arr)
            {
                result += i + "\n";
            }
        }
        public void break语句()
        {   //跳出循环
            for (int i = 1; i < 5; i++)
            {
                if (i > 3)
                { break; }
                else
                { result += i + "\n"; }
            }
        }
        public void continue语句()
        {   //越过本次循环
            for (int i = 1; i < 10; i++)
            {
                if (i == 3 || i == 7)
                { continue; }
                else
                { result += i + "\n"; }
            }
        }
        public void return语句()
        {   //return是跳出过程,break是跳出循环.
            for (int i = 1; i < 10; i++)
            {
                 if (i == 3 || i == 7)
                { return; }
                else
                { result += i + "\n"; }
            }
            result += "循环体外的语句;\n";
        }

        public void 过程的定义和调用()
        {
            proc();//无参数过程
            proc2(s: "hello", i: 123);//带参数过程
        }
        void proc()
        {
            result = "proc";
        }
        void proc2(int i, string s)
        {
            result = i + s;
        }
        public void 函数的定义和调用()
        {
            result = c(b: 4, a: 1).ToString();//可以颠倒参数顺序
        }
        int c(int a, int b)
        {   //返回2个参数的平方之差.
            return a * a - b * b;
        }
        public void 错误处理()
        {
            try
            {
                int[] i = { 1, 3, 5 };
                result = i[3].ToString(); //数组下标越界
            }
            catch (SystemException ex)
            {
                result = ex.Message;
            }
            finally
            {
                result += "\nfinally";
            }
        }
    }
}
