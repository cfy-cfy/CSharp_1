using System;

namespace HelloWorld
{
  class Program
  {
  	
    
    public delegate void Mydelegate();  // ———————————————————— 【1】
    public static void Sayhello()
    {
    	Console.WriteLine("SayHello 1");
    }
    
    public delegate void AreaDelegate(double length, double width); // ———————————————————— 【2】

    public delegate void Area();         // ———————————————————— 【3】
    
    public delegate void SubDelegate();  // ———————————————————— 【4】
    public event SubDelegate SubEvent;
    public void InvokeEvent()
    {
    	SubEvent();
    }
    

    static void Main(string[] args)  
    {  
		    Mydelegate myd= new Mydelegate(Program.Sayhello);   // ———————————————————— 【1】
        myd();
        
        double length=3; 
        double width =2;
        AreaDelegate ard=delegate                             // ———————————————————— 【2】
        {
        	Console.WriteLine("长方形的面积为：" + length * width);
        };
        ard(length,width);
        
        
         Area area=delegate                           // ———————————————————— 【3】
        {
        	Console.WriteLine("长方形的面积为：area ");
        };
        area();
        
        Program pg = new Program();                  // ———————————————————— 【4】
        pg.SubEvent = new SubDelegate(Program.Sayhello); 
        pg.InvokeEvent();
        
    }

  }
}
