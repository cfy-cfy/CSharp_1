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
using System.Data;

public class Program
{
  static void Main(string[] args)
  {
		DataTable dt = new DataTable();
    dt.Columns.Add("Age", Type.GetType("System.Int32"));
    dt.Columns.Add("Name", Type.GetType("System.String"));
    dt.Columns.Add("Sex", Type.GetType("System.String"));
    dt.Columns.Add("IsMarry", Type.GetType("System.Boolean"));
    for (int i = 0; i < 4; i++)
    {
      DataRow dr = dt.NewRow();
      dr["Age"] = i + 1;
      dr["Name"] = "Name" + i;
      dr["Sex"] = i % 2 == 0 ? "男" : "女";
      dr["IsMarry"] = i % 2 > 0 ? true : false;
      dt.Rows.Add(dr);
    }

    Console.WriteLine(dt.Rows.Count);
    Console.WriteLine("{0}\t{1}\t{2}\t{3}\t", dt.Columns[0], dt.Columns[1], dt.Columns[2], dt.Columns[3]);

    foreach (DataRow dr in dt.Rows)
    {
      Console.WriteLine("{0}\t{1}\t{2}\t{3}\t", dr[0], dr[1], dr[2], dr[3]);
    }
// ————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————
      DataRow drOperate = dt.Rows[0];
      drOperate["Name"] = "AXzhz";
      drOperate[0] = 18;

      dt.Rows[1]["Name"] = "WHHXPP";
      dt.Rows[1][0] = 19;
      
      Console.WriteLine("{0}\t{1}\t{2}\t{3}\t", dt.Columns[0], dt.Columns[1], dt.Columns[2], dt.Columns[3]);
      string data="";
      for (int i = 0; i < dt.Rows.Count; i++)
      {
        for (int j=0;j < dt.Columns.Count;j++)
        {
           string str = dt.Rows[i][j].ToString();
           data=data + str + "\t";
        }
        Console.WriteLine("{0}",data);
        data="";
      }

  }
}

