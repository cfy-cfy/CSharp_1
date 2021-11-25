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
        string replacement = string.Empty;  

        // pattern = "^[0-9]+$";   // 匹配：整组的数字字符串
        // pattern = "[0-9]+"; 
        pattern = "[^0-9]+"; 
        RegexStr="7789Money1123RMB456pound";
        // ————————————————————————————————————————————————————————————————————————————————————【 IsMatch 】
        Console.WriteLine("判断'RegexStr'是否含数字:{0}", Regex.IsMatch(RegexStr, pattern, RegexOptions.IgnoreCase));
        // ————————————————————————————————————————————————————————————————————————————————————【 Match 】
        Match oneMatch=Regex.Match(RegexStr,pattern, RegexOptions.IgnoreCase);
        Console.WriteLine(oneMatch.Value);
        // ————————————————————————————————————————————————————————————————————————————————————【 Matches 】
        MatchCollection moreMatch=Regex.Matches(RegexStr,pattern);
        foreach (Match m in moreMatch)
        {
          Console.WriteLine(m);
        }
        // ————————————————————————————
        for (int i=0;i< moreMatch.Count;i++)
        {
          Console.WriteLine(moreMatch[i].Value);
        }       
         // ————————————————————————————————————————————————————————————————————————————————————【 Replace 】     

        Regex reg = new Regex(pattern);
        replacement="Dollor";
        string result = reg.Replace(RegexStr, replacement);
        Console.WriteLine(result);


    }

}
