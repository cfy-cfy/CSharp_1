//  https://docs.microsoft.com/zh-cn/dotnet/csharp/language-reference/operators/lambda-expressions

using System;

namespace HelloWorld
{
  class Program
  {
    delegate void SubDel(int x);         // ————————【0】

    public delegate int MyDel(int x);           // ————————【1】传入参数
    
    delegate void TestDel(string s); 
    
    public static int add(int a, int b)=>a+b;   // ————————【2】
    
    static void Main(string[] args)  
    {  

      int a=6;
      SubDel myD = delegate              // ————————【0】
      {
           Console.WriteLine(a);
       };
       myD(a);

        MyDel myDel = x => x++;                 // ————————【1】
        var j = myDel(5); 
        Console.WriteLine(j);
        
	      TestDel tDel = n => { var st = n + " Fanguzai!"; Console.WriteLine(st); };  
        tDel("Hi,"); 

        Console.WriteLine(add(1,2));            // ————————【2】
        
        Func<int , int ,bool> subequal = (a,b)=> a==b;  // ————————【3】
        Console.WriteLine(subequal(2,2));
        
        Func<int, int> square = y =>y * y;             
		    Console.WriteLine(square(5));
        
        Func<int, string, bool> isTooLong = (int x, string s) => s.Length > x;    
        Console.WriteLine(isTooLong(10,"WHHXPP"));
        
        Action<string> greet = name =>          // ————————【4】
        {
            string greeting = $"Hello {name}!";
            Console.WriteLine(greeting);
        };
        greet("World");
        
    }

  }
}
