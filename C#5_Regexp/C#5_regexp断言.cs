using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using HtmlAgilityPack;
using System.Text.RegularExpressions;  // regexp
using System.Drawing;
using System.Data;

public class Program
{
  public static void Main(string[] args)
  {
   
    Regexp.sub_reg1();

  }

}

public class Regexp
{
    public static void sub_reg1()
    {
        string RegexStr = string.Empty;
        string pattern = string.Empty;        

        RegexStr="7789Money1123RMB456pound88888abZW863";

        // ————————————————————————————————————————————————————————————————————————————————————【 零宽度正向先行断言 	(?=exp) 	匹配到exp则停止 】
        // pattern = @"\d+(?=[A-Z])";   // 匹配以 A-Z 【结尾】的结果：778，112
        // ————————————————————————————————————————————————————————————————————————————————————【 零宽度负向先行断言 	(?!exp) 	匹配不到exp则停止 】
        // pattern = @"\d+(?![A-Z])";   // 匹配不是以 A-Z 【结尾】的结果：778，112，456，88888，863
        // ————————————————————————————————————————————————————————————————————————————————————【 零宽度正向后发断言 	(?<=exp) 	匹配到exp则继续 】
        // pattern = @"(?<=[A-Z])\d+";   // 匹配以 A-Z 【开头】的结果：456，863
        // ————————————————————————————————————————————————————————————————————————————————————【 零宽度负后发断言 	(?<!exp) 	匹配不到exp则继续 】
        pattern = @"(?<![A-Z])\d+";   // 匹配不是以 A-Z 【开头】的结果：：7789,1123,56,88888,63
        // ————————————————————————————————————————————————————————————————————————————————————【  】
        MatchCollection moreMatch=Regex.Matches(RegexStr,pattern);
        foreach (Match m in moreMatch)
        {
          Console.WriteLine(m);
        }
   

    }

}

// 【C# 零宽断言】

// 1.零宽断言
// 名称	语法	说明
// 零宽度正向先行断言 	(?=exp) 	匹配到exp则停止
// 零宽度负向先行断言 	(?!exp) 	匹配不到exp则停止
// 零宽度正向后发断言 	(?<=exp) 	匹配到exp则继续
// 零宽度负后发断言 	(?<!exp) 	匹配不到exp则继续

// 2.贪婪模式和非贪婪模式
// *? 	重复任意次，但尽可能少重复
// +? 	重复1次或更多次，但尽可能少重复
// ?? 	重复0次或1次，但尽可能少重复
// {n,}? 	重复n次以上，但尽可能少重复
