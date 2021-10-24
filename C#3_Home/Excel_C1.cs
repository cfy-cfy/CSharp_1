using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Drawing;
using System.Diagnostics;

namespace WindowsForms_Excel_1
{
	class Excel_C1
	{
		Excel.Application app=(Excel.Application) System.Runtime.InteropServices.Marshal.GetActiveObject("Excel.Application");
		Excel.Workbook wbk;
		Excel.Worksheet wst;
		Excel.Range rg;
		Form2 frm2;

		public int i=36 ;
		public string s1 = "vsto";
		string s2 = "vba";

		public void SubTempt ()                    // 定义 过程
		{
			MessageBox.Show("Pretty girl!!!!");
		}

		public int FunSum(int a, int b, int c)    // 定义 函数
		{
			return a + b + c;
		}


		public void SubExcel()
		{
			//app = (Excel.Application)System.Runtime.InteropServices.Marshal.GetActiveObject("Excel.Application");

			//MessageBox.Show(app.UserName);            // 获取用户名

			//frm2 = new Form2();
			//frm2.Show();
			//frm2.Text = "哇哈哈哈";

			//foreach (Excel.Workbook wbk in app.Workbooks)        // 获取当前所有工作簿的名字
			//{
			//	MessageBox.Show(wbk.Name);
			//}

			//foreach (Excel.Worksheet wst in app.Worksheets)      // 获取当前所有工作簿的名字
			//{
			//	MessageBox.Show(wst.Name);
			//}

			
			//Excel.Worksheet new_wst;
			//new_wst = (Excel.Worksheet)app.Worksheets.Add();     // 新建worksheet
			//new_wst.Name = "New Sheet1";


		}

		public void SubRange()
		{
			wbk = app.Workbooks[1];
			wst = wbk.Worksheets[1];

			//MessageBox.Show(app.Range["A1"].Value.ToString());         // 获取指定单元格的值
			//wst.Range["D4:F6"].Value = 56;                             // 设置指定单元格的值

			//rg = wst.Range["D4:F6"];                                           // 设定单元格区域
			//rg.Select();                                                       // 选择指定单元格区域
			//Excel.Range range = (Excel.Range)wst.Rows[1, Type.Missing];        // 设定 行区域
			//range.Select();                                                    // 选择 行区域
			//range.EntireRow.Hidden = true;                             //隐藏 行区域

			//rg.Interior.Color = Color.Blue;                    // 设定指定单元格区域的颜色, using System.Drawing;
			//rg.Interior.Color = 0x0000ff;                      // 0x0000ff 红色  , 0x00ff00 绿色 ,0xff0000 蓝色

			//Excel.Range r = (Excel.Range)wst.Cells[1, 1];              // 获取选择的单元格
			//Excel.Range r = (Excel.Range)wst.Cells[5, "H"];
			//Excel.Range r = (Excel.Range)app.ActiveCell;  

			//使用范围的 CurrentRegion 属性取得一个代表当前区域的范围，这个当前区域由最近的空行和列限定,即连接在一起的单元格
			//ThisApplication.get_Range("C3", Type.Missing).CurrentRegion.Font.Bold = true;

			//Application 对象的 Selection 属性返回与选定单元格对应的范围
			//rng = (Excel.Range)ThisApplication.Selection;


			//使用范围的 Offset 属性取得相对于初始范围的一个偏移
			//rng = (Excel.Range)ws.Cells[1, 1];
			//for (int i = 1; i <= 5; i++)
			//{
			//	rng.get_Offset(i, 0).Value2 = i.ToString();
			//}

			//Excel.Range r = (Excel.Range)wst.Range["H5"];
			//Excel.Range r = wst.Range("A1", "C5")  //直接引用范围的 Cells、Rows 或 Columns 属性，作用相同
			//Excel.Range r = wst.Range("A1", "C5").Cells
			//Excel.Range r = wst.Range("A1", "C5").Rows
			//Excel.Range r = wst.Range("A1", "C5").Columns

			//Excel.Range r = wst.get_Range("A1", Type.Missing);//使用对象的 Range 属性指定一个区域
			//Excel.Range r = wst.get_Range("A1:B12", Type.Missing);//使用对象的 Range 属性指定一个区域

			//创建一个引用其他两个范围重叠部分的范围（在引号内指定两个范围，并不使用分隔符）
			//rng = ThisApplication.get_Range("A1:D16 B2:F14", Type.Missing);//与后三行效果相同
			//rng1 = ThisApplication.get_Range("A1", "D16");
			//rng2 = ThisApplication.get_Range("B2", "F14");
			//rng = ThisApplication.Intersect(rng1, rng2, Type.Missing, Type.Missing, Type.Missing, Type.Missing,……);

			//创建一个包含其他两个合并范围的范围（在引号内指定两个范围，并用逗号隔开）
			//rng = ThisApplication.get_Range("A1:D4, F2:G5", Type.Missing);//与后三行效果相同
			//rng1 = ThisApplication.get_Range("A1", "D4");
			//rng2 = ThisApplication.get_Range("F2", "G5");
			//rng = ThisApplication.Union(rng1, rng2, Type.Missing, Type.Missing, ……);

			//Excel.Range r = (Excel.Range)wst.Rows[1, Type.Missing];
			//Excel.Range sel_row_range = (Excel.Range)wst.Rows["2:2", Type.Missing];
			//Excel.Range rng = (Excel.Range)wst.Columns[3, Type.Missing];
			//MessageBox.Show(r.Address.ToString());                             // 获取区域的地址

			//Excel.Range sel_row_range = (Excel.Range)wst.Rows["2:2", Type.Missing];
			//sel_row_range.Delete(Excel.XlDeleteShiftDirection.xlShiftUp);      // 删除第二行

			//((Excel.Range)wst.Rows[2, Type.Missing]).Delete(Excel.XlDeleteShiftDirection.xlShiftToLeft);

			//((Excel.Range)wst.Cells[1, 2]).EntireColumn.Delete();



			//Excel.Range math_range = (Excel.Range)wst.Range["H5"];
			//math_range.FormulaR1C1 = "=sum(R[-2]C[-5]:R[-2]C)";        // 设置公式 H5 = SUM(C3:H3)
			//math_range.FormulaR1C1 = "=RC[-3]*RC[-1]";                 // 设置公式 E3 = B3 * D3

			//另存并加载到当前
			//wbk.SaveAs(@"C:\Users\hp\Desktop\test1.xlsx", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
			// 另存不加载到当前
			//wbk.SaveCopyAs(@"C:\Users\hp\Desktop\test1.xlsx");


		}

		public void SubRow()           // 获取已经使用的行 / 列数
		{
			wbk = app.Workbooks[1];
			wst = wbk.Worksheets["Sheet1"];
			//wst = wbk.Worksheets.get_Item(1);

			int rowsCount = wst.UsedRange.Rows.Count;  
			int colsCount = wst.UsedRange.Columns.Count;

			MessageBox.Show("行数是： " + rowsCount.ToString(),"列数是： " + colsCount.ToString());


		}

		public void SubPractice()     // 遍历数据区域
		{
			wbk = app.Workbooks[1];
			wst = wbk.Worksheets[1];

			foreach (Excel.Range e in wst.UsedRange.Rows)
			{
				Excel.Range cell = (Excel.Range)wst.Cells[e.Row, 3];
				Debug.WriteLine(e.Address.ToString());       // $A$1:$F$1, $A$8:$F$8
				if (cell.Value2 != null)
				{
					MessageBox.Show(cell.Value.ToString());
				}
			}

		}

		public void SubList()
		{
			wbk = app.Workbooks[1];
			wst = wbk.Worksheets[1];

			List<string> all_column = new List<string>();
			//List<int> all_col = new List<int>();
			foreach (Excel.Range all_c in wst.UsedRange.Columns)
			{
				//all_col.Add(all_c.Value2[1, 1]);
				all_column.Add(all_c.Address.ToString());

				//Debug.WriteLine(all_col.Address.ToString());    // $A$1:$A$8
			}

			//MessageBox.Show(all_column.Count().ToString());

			foreach (string arr in all_column)
			{
				MessageBox.Show(arr.ToString());
			}

			//foreach (int crr in all_col)
			//{
			//	MessageBox.Show(crr.ToString());
			//}

		}

		public void SubArray()
		{
			wbk = app.Workbooks[1];
			wst = wbk.Worksheets["Sheet1"];
			rg = wst.Range["A1:B10"];

			//string[,] arr = rg;
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
			wst.Range["a1"].get_Resize(5, 6).Value2 = arr;
			wst.Range["a10"].get_Resize(6, 5).Value2 = app.WorksheetFunction.Transpose(arr);
		}


		public void SubMergeCells(string col_name, int start_row, int end_row)   // 合并单元格
		{
			Excel.Worksheet wks = app.ActiveSheet as Excel.Worksheet;
			string str1 = col_name + start_row.ToString();
			string str2 = col_name + end_row.ToString();
			Excel.Range r1 = (Excel.Range)wks.get_Range(str1, str2);
			r1.Merge(Type.Missing);
		}


	public void SubRangeStyle(Excel.Range range)
		{
			//range.NumberFormatLocal = "@";                             // 设置单元格类型为文本

			
			//range.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;   // 设置居中，靠左
			//range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

			//Excel.Font target_font = range.Font;                       // 设置区域字体
			//target_font.Name = "黑体";
			//target_font.Size = 25;
			//target_font.Strikethrough = false;
			//target_font.Superscript = false;
			//target_font.Subscript = false;
			//target_font.OutlineFont = false;
			//target_font.Shadow = false;
			//target_font.Underline = Excel.XlUnderlineStyle.xlUnderlineStyleNone;
			//target_font.ThemeColor = Excel.XlThemeColor.xlThemeColorLight1;
			//target_font.TintAndShade = 0;
			//target_font.ThemeFont = Excel.XlThemeFont.xlThemeFontNone;


			// 设置Range的详细属性，包括颜色，是否边框为黑色实线等

			//range.Interior.Pattern = Excel.XlPattern.xlPatternSolid;
			//range.Interior.PatternColorIndex = Excel.XlPattern.xlPatternAutomatic;
			//range.Interior.ThemeColor = Color.Blue; 
			//range.Interior.TintAndShade = 0.89999;
			//range.Interior.PatternTintAndShade = 0;
			//range.Borders[Excel.XlBordersIndex.xlDiagonalDown].LineStyle = Excel.XlLineStyle.xlLineStyleNone;
			//range.Borders[Excel.XlBordersIndex.xlDiagonalUp].LineStyle = Excel.XlLineStyle.xlLineStyleNone;
			//range.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlLineStyleNone;
			//range.Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlLineStyleNone;
			//range.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
			//range.Borders[Excel.XlBordersIndex.xlEdgeBottom].ColorIndex = 0;
			//range.Borders[Excel.XlBordersIndex.xlEdgeBottom].TintAndShade = 0;
			//range.Borders[Excel.XlBordersIndex.xlEdgeBottom].Weight = Excel.XlBorderWeight.xlThin;
			//range.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlLineStyleNone;
			//range.Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlLineStyleNone;
			//range.Borders[Excel.XlBordersIndex.xlInsideHorizontal].LineStyle = Excel.XlLineStyle.xlLineStyleNone;
			//range.Borders[Excel.XlBordersIndex.xlDiagonalDown].LineStyle = Excel.XlLineStyle.xlLineStyleNone;
			//range.Borders[Excel.XlBordersIndex.xlDiagonalUp].LineStyle = Excel.XlLineStyle.xlLineStyleNone;
			//range.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlContinuous;
			//range.Borders[Excel.XlBordersIndex.xlEdgeLeft].ColorIndex = 0;
			//range.Borders[Excel.XlBordersIndex.xlEdgeLeft].TintAndShade = 0;
			//range.Borders[Excel.XlBordersIndex.xlEdgeLeft].Weight = Excel.XlBorderWeight.xlThin;
			//range.Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlContinuous;
			//range.Borders[Excel.XlBordersIndex.xlEdgeTop].ColorIndex = 0;
			//range.Borders[Excel.XlBordersIndex.xlEdgeTop].TintAndShade = 0;
			//range.Borders[Excel.XlBordersIndex.xlEdgeTop].Weight = Excel.XlBorderWeight.xlThin;
			//range.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
			//range.Borders[Excel.XlBordersIndex.xlEdgeBottom].ColorIndex = 0;
			//range.Borders[Excel.XlBordersIndex.xlEdgeBottom].TintAndShade = 0;
			//range.Borders[Excel.XlBordersIndex.xlEdgeBottom].Weight = Excel.XlBorderWeight.xlThin;
			//range.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlContinuous;
			//range.Borders[Excel.XlBordersIndex.xlEdgeRight].ColorIndex = 0;
			//range.Borders[Excel.XlBordersIndex.xlEdgeRight].TintAndShade = 0;
			//range.Borders[Excel.XlBordersIndex.xlEdgeRight].Weight = Excel.XlBorderWeight.xlThin;
			//range.Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlContinuous;
			//range.Borders[Excel.XlBordersIndex.xlInsideVertical].ColorIndex = 0;
			//range.Borders[Excel.XlBordersIndex.xlInsideVertical].TintAndShade = 0;
			//range.Borders[Excel.XlBordersIndex.xlInsideVertical].Weight = Excel.XlBorderWeight.xlThin;
			//range.Borders[Excel.XlBordersIndex.xlInsideHorizontal].LineStyle = Excel.XlLineStyle.xlContinuous;
			//range.Borders[Excel.XlBordersIndex.xlInsideHorizontal].ColorIndex = 0;
			//range.Borders[Excel.XlBordersIndex.xlInsideHorizontal].TintAndShade = 0;
			//range.Borders[Excel.XlBordersIndex.xlInsideHorizontal].Weight = Excel.XlBorderWeight.xlThin;

		}

	}
}
