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

// https://www.cnblogs.com/cang12138/p/6085525.html#_label0

public class Program
{
  static void Main(string[] args)
  {
		// CreateDt();
    SortCopyDt();

  }

  public static void SortCopyDt()
  {
    DataTable dt = new DataTable();     //创建表
    dt.Columns.Add("ID", typeof(Int32));//添加列
    dt.Columns.Add("Name", typeof(String));
    dt.Columns.Add("Age", typeof(Int32));
    dt.Rows.Add(new object[] { 1, "张三" ,20}); //添加行
    dt.Rows.Add(new object[] { 2, "李四" ,25});
    dt.Rows.Add(new object[] { 3, "王五" ,30});
    DataView dv = dt.DefaultView;      // 获取表视图
    dv.Sort = "ID DESC";               // 按照ID倒序排序 DESC , 顺序 ASC
    DataTable dvt=dv.ToTable();        // 转为表

    Console.WriteLine("{0}\t{1}\t{2}\t", dvt.Columns[0], dvt.Columns[1], dvt.Columns[2]);
    foreach (DataRow dr in dvt.Rows)
    {
      Console.WriteLine("{0}\t{1}\t{2}\t", dr[0], dr[1], dr[2]);
    }

    // ——————————————————————————————————————————————————————————————————————————————————————————————————— 【复制表】
    
    // DataTable dtNew = new DataTable();  // 复制表，同时复制了表结构和表中的数据
    // dtNew = dt.Copy();

    DataTable dtNew = dt.Copy(); // 复制dt表数据结构
    dtNew.Clear();                // 清空数据
    for (int i = 0; i < dt.Rows.Count; i++)
    {
      dtNew.Rows.Add(dt.Rows[i].ItemArray); // 添加数据行
    }

    Console.WriteLine("{0}\t{1}\t{2}\t", dtNew.Columns[0], dtNew.Columns[1], dtNew.Columns[2]);
    foreach (DataRow dr in dtNew.Rows)
    {
      Console.WriteLine("{0}\t{1}\t{2}\t", dr[0], dr[1], dr[2]);
    } 
    // ——————————————————————————————————————————————————————————————————————————————————————————————————— 【克隆表】
    // DataTable dtNewC = new DataTable();  // 克隆表，只是复制了表结构，不包括数据
    // dtNewC = dt.Clone();
    
    // ——————————————————————————————————————————————————————————————————————————————————————————————————— 【复制行】
    DataTable dtNewR = new DataTable(); // 如果只需要复制某个表中的某一行
    dtNewR = dt.Copy();
    dtNewR.Rows.Clear();         // 清空表数据
    dtNewR.ImportRow(dt.Rows[0]);// 这是加入的是第一行

    Console.WriteLine("{0}\t{1}\t{2}\t", dtNewR.Columns[0], dtNewR.Columns[1], dtNewR.Columns[2]);
    foreach (DataRow dr in dtNewR.Rows)
    {
      Console.WriteLine("{0}\t{1}\t{2}\t", dr[0], dr[1], dr[2]);
    } 


  }

  public static void CreateDt()
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
// ——————————————————————————————————————————————————————————————————————————————————————————————————— 【遍历】
    Console.WriteLine("{0}\t{1}\t{2}\t{3}\t", dt.Columns[0], dt.Columns[1], dt.Columns[2], dt.Columns[3]);
    foreach (DataRow dr in dt.Rows)
    {
      Console.WriteLine("{0}\t{1}\t{2}\t{3}\t", dr[0], dr[1], dr[2], dr[3]);
    }
// ——————————————————————————————————————————————————————————————————————————————————————————————————— 【赋值、取值、遍历】
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
// ———————————————————————————————————————————————————————————————————————————————————————————————————【筛选】

      // DataRow[] drs = dt.Select("Age is null");      // 选择 Age 列值为空的行的集合
      // DataRow[] drs = dt.Select("Name = 'WHHXPP'");  // 选择 Name 列值为"WHHXPP"的行的集合
      // DataRow[] drs = dt.Select("Name like 'Name%'");// 如果的多条件筛选，可以加 and 或 or / 筛选 Name 列值中有"Name"的行的集合(模糊查询)
      DataRow[] drs = dt.Select("Name like 'Name%'", "Age DESC"); // 筛选 Name 列值中有"Name"的行的集合(模糊查询)并按 Age 降序排序

      Console.WriteLine("{0}\t{1}\t{2}\t{3}\t", dt.Columns[0], dt.Columns[1], dt.Columns[2], dt.Columns[3]);
      foreach (DataRow dr in drs)
      {
        Console.WriteLine("{0}\t{1}\t{2}\t{3}\t", dr[0], dr[1], dr[2], dr[3]);
      }
// ———————————————————————————————————————————————————————————————————————————————————————————————————【删除行】

      // dt.Rows.Remove(dt.Rows[0]); // 使用DataTable.Rows.Remove(DataRow)方法 删除行
      // dt.Rows.RemoveAt(0);        // 使用DataTable.Rows.RemoveAt(index)方法 删除行
      // dt.Row[0].Delete();         // 使用DataRow.Delete()方法  删除行
      // dt.AcceptChanges();
      
      // //-----区别和注意点-----
      // //Remove()和RemoveAt()方法是直接删除
      // //Delete()方法只是将该行标记为deleted，但是还存在，还可DataTable.RejectChanges()回滚，使该行取消删除。
      // //用Rows.Count来获取行数时，还是删除之前的行数，需要使用DataTable.AcceptChanges()方法来提交修改。
      // //如果要删除DataTable中的多行，应该采用倒序循环DataTable.Rows，而且不能用foreach进行循环删除，因为正序删除时索引会发生变化，程式发生异常，很难预料后果。

      // for (int i = dt.Rows.Count - 1; i >= 0; i--)
      // {
      // 　　dt.Rows.RemoveAt(i);
      // }
// ———————————————————————————————————————————————————————————————————————————————————————————————————


  }
}

