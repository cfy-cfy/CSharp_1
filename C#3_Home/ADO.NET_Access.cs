using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsForms_Excel_1
{
	public class ADO_Access
	{
		
		public static void SubADO_Access()
		{
			Form3 frm3 = new Form3();

			string strConnection = "Provider=Microsoft.ACE.OleDb.12.0;";
			strConnection += @"Data Source=C:\Users\hp\Desktop\AccessTest.accdb;";
			strConnection += @"Jet OLEDB:Database Password=123;";

			OleDbConnection objConnection = new OleDbConnection(strConnection);  // 建立连接  
			objConnection.Open();
			MessageBox.Show("连接成功");

			//——————————————————————————————————————————
			string sql = "select * from table1";
			OleDbCommand sqlcmd = new OleDbCommand(sql, objConnection);         // sql语句  

			OleDbDataReader reader = sqlcmd.ExecuteReader();                    // 执行查询  
			while (reader.Read())
			{
				Console.WriteLine(reader["name"]);

			}
			//——————————————————————————————————————————
			OleDbDataAdapter sda = new OleDbDataAdapter(sql, objConnection);
			DataSet ds = new DataSet();
			sda.Fill(ds);


			frm3.dataGridView1.DataSource = ds.Tables[0];

			// —————————————— 如果需要更改 DataGridView 控件的列标题，则需要在上面的代码中加入以下代码

			frm3.dataGridView1.Columns[0].HeaderText = "编号";     //设置第 1 列的列标题
			frm3.dataGridView1.Columns[1].HeaderText = "专业名称"; //设置第2列的列标题
							
			frm3.dataGridView1.ReadOnly = true;                    // 设置数据表格为只读
			frm3.dataGridView1.AllowUserToAddRows = false;         // 不允许添加行
			frm3.dataGridView1.BackgroundColor = Color.White;      // 背景为白色
			frm3.dataGridView1.MultiSelect = false;                // 只允许选中单行
			frm3.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect; //整行选中

			string res1 = frm3.dataGridView1.Rows[1].Cells[1].Value.ToString();   //获取DataGridView控件中的值
			//string res2 = frm3.dataGridView1.CurrentRow.Cells[1].Value.ToString();
			//string res2 = frm3.dataGridView1.SelectedRows[0].Cells[1].Value.ToString();

			frm3.Show();

			objConnection.Close();
			reader.Close();
			MessageBox.Show("关闭成功" + res1);

		}

		public static void SubADO_Acess_datatable()
		{
			Form3 frm3 = new Form3();

			string strConnection = "Provider=Microsoft.ACE.OleDb.12.0;";
			strConnection += @"Data Source=C:\Users\hp\Desktop\AccessTest.accdb;";
			strConnection += @"Jet OLEDB:Database Password=123;";

			OleDbConnection conn = new OleDbConnection(strConnection);  // 建立连接  
			conn.Open();
			OleDbCommand cmd = conn.CreateCommand();
			cmd.CommandText = "select * from [table1]";
			
			MessageBox.Show("连接成功");

			OleDbDataReader dr = cmd.ExecuteReader();
			DataTable dt = new DataTable();

			//—————————————————————————————————————— 每行每列添加
			//if (dr.HasRows)       // 向 dt 里面添加列
			//{
			//	Console.WriteLine(dr.FieldCount.ToString());
			//	for (int i = 0; i < dr.FieldCount; i++)
			//	{
			//		dt.Columns.Add(dr.GetName(i));
			//		Console.WriteLine(dr.GetName(i).ToString());
			//	}
			//	dt.Rows.Clear();
			//}
			//while (dr.Read())      // 向 dt 里面添加行
			//{
			//	DataRow row = dt.NewRow();
			//	for (int i = 0; i < dr.FieldCount; i++)
			//	{
			//		row[i] = dr[i];
			//	}
			//	dt.Rows.Add(row);
			//}
			//————————————————————————————————————— 通过 OleDbDataAdapter 添加
			OleDbDataAdapter sda = new OleDbDataAdapter("select * from [table1]",conn);  
							  
			sda.Fill(dt);
			//——————————————————————————————————————————

			frm3.Show();
			frm3.dataGridView1.DataSource = dt;

			cmd.Dispose();
			conn.Close();
			MessageBox.Show("关闭成功");


		}

		public static void SubADO_Excel()
		{
			Form3 frm3 = new Form3();

			string strConnection = "Provider=Microsoft.ACE.OleDb.12.0;";
			strConnection += @"Extended Properties=Excel 12.0;";
			strConnection += @"Data Source=C:\Users\hp\Desktop\股票收益计算_Cfy.xlsx;";

			string sql = "select * from [交易对账单$]";

			OleDbConnection objConnection = new OleDbConnection(strConnection);  // 建立连接  
			objConnection.Open();
			MessageBox.Show("连接成功");

			//——————————————————————————————————————————
			OleDbDataAdapter sda = new OleDbDataAdapter(sql, objConnection);
			DataSet ds = new DataSet();
			sda.Fill(ds);


			frm3.dataGridView1.DataSource = ds.Tables[0];

			//——————————————————————————————————————————

			// —————————————— 如果需要更改 DataGridView 控件的列标题，则需要在上面的代码中加入以下代码

			frm3.dataGridView1.Columns[0].HeaderText = "编号";     //设置第 1 列的列标题

			frm3.dataGridView1.Columns[1].HeaderText = "专业名称"; //设置第2列的列标题

			frm3.Show();

			objConnection.Close();
			MessageBox.Show("关闭成功");

		}

		



	}
}
