using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Drawing;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Collections;

public class Program
{
  static void Main(string[] args)
  {
    Hashtable ht=new Hashtable(); 
    ht.Add("E","e");
    ht.Add(3,"a");
    ht.Add("C","c");
    ht.Add(1,"b");

    foreach (DictionaryEntry de in ht)
    {
      Console.WriteLine($"key={de.Key} , value={de.Value}");
    }
    
    Console.WriteLine(ht[3]);

    if(ht.Contains("E"))
    Console.WriteLine("the E key exist");

    ht.Remove("C");
    Console.WriteLine(ht.Count);

    ht.Clear();

  }
}

