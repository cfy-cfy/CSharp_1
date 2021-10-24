using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
using System.Data.OleDb;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data;

namespace WindowsForms_Excel_1
{
	public class Excel_C2
	{
		Excel.Application app = (Excel.Application)System.Runtime.InteropServices.Marshal.GetActiveObject("Excel.Application");
		Excel.Workbook wb;
		Excel.Worksheet ws;
		Excel.Range rg;

		public void SubExcel2_Arrayto()
		{
			wb = app.Workbooks[1];
			ws = wb.Worksheets["Sheet1"];
			rg = ws.Range["A1:B10"];

			int[,] arr = new int[5, 6];
			int count = 0;
			for (int i = 0; i < 5; i++)
			{
				for (int j = 0; j < 6; j++)
				{
					arr[i, j] = count;
					count++;
				}
			}
			ws.Range["a1"].get_Resize(5, 6).Value2 = arr;
			ws.Range["a10"].get_Resize(6, 5).Value2 = app.WorksheetFunction.Transpose(arr);
		}

		public void SubExcel2_largerow()
		{
			wb = app.Workbooks[1];
			ws = wb.Worksheets.get_Item(1);

			//Excel.Range rngLeft, rngRight, rngUp, rngDown;

			Excel.Range rng = (Excel.Range)ws.Range["A1"];
			Excel.Range rngRight = rng.get_End(Excel.XlDirection.xlToRight);
			Console.WriteLine(rngRight.Address.ToString());

			Excel.Range rngDown = rng.get_End(Excel.XlDirection.xlDown);
			Console.WriteLine(rngDown.Address.ToString());

			Excel.Range rng1 = (Excel.Range)ws.Range["M1"];
			Excel.Range rngLeft = rng1.get_End(Excel.XlDirection.xlToLeft);
			Console.WriteLine(rngLeft.Address.ToString());

			Excel.Range rng2 = (Excel.Range)ws.Range["A65536"];
			Excel.Range rngUp = rng2.get_End(Excel.XlDirection.xlUp);
			Console.WriteLine(rngUp.Address.ToString());

		}

		public void SubExcel2_OLEDB()
		{
			Form3 frm3 = new Form3();

			string strCon = @" Provider = Microsoft.ACE.OLEDB.12.0 ; Data Source =C:\Users\hp\Desktop\test1.xlsx;Extended Properties=Excel 12.0";
			OleDbConnection conn = new OleDbConnection(strCon);
			string sql = "select * from [Sheet1$]";
			conn.Open();
			OleDbDataAdapter myCommand = new OleDbDataAdapter(sql, strCon);
			//————————————————————————————————————————————DataSet
			//DataSet ds = new DataSet();
			//myCommand.Fill(ds, "[Sheet1$]");
			//【方法1】
			//frm3.dataGridView1.DataMember = "[Sheet1$]";
			//frm3.dataGridView1.DataSource = ds;
			//【方法2】
			//frm3.dataGridView1.DataSource = ds.Tables[0];

			//————————————————————————————————————————————DataTable
			DataTable dt = new DataTable();
			myCommand.Fill(dt);
			frm3.dataGridView1.DataSource = dt;

			//————————————————————————————————————————————

			//frm3.Show();

			wb = app.Workbooks[1];
			ws = wb.Worksheets["Sheet1"];
			int[] arr = new int[5];
			for (int i=0; i < arr.Length ; i++)
			{
				arr[i] = i * 10;
				Console.WriteLine(arr[i]);
			}
			ws.Range["G1"].get_Resize(5,1).Value2 = app.WorksheetFunction.Transpose(arr);
			ws.Range["H1"].get_Resize(1, 5).Value2 = arr;

			conn.Close();

		}

	}



}

