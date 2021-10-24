using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Data;
using NPOI;
using NPOI.XSSF.UserModel;  // 把xlsx文件中的数据写入wk中
using NPOI.HSSF.UserModel;  // 把xls文件中的数据写入wk中
using NPOI.SS.UserModel;
using NPOI.XSSF.Util;
using NPOI.HSSF.Util;
using NPOI.SS.Util;

//性能比较结果:npoi > epplus > Myxls
// 【NPOI】 支持 xls / 支持 xlsx
// 【MyXls】 支持 xls / 不支持 xlsx
// 【EPPlus】 不支持 xls / 支持 xlsx
//程序包管理器控制台输入一下命令安装：Install-Package NPOI -Version 2.4.1

namespace WindowsForms_Excel_1
{
	public class Excel_NPOI
	{

		public void ReadFromExcel_1()
		{
			DataTable dt = new DataTable();
			using (FileStream file = new FileStream(@"C:\Users\hp\Desktop\test1.xlsx", FileMode.Open, FileAccess.Read))
			{
				XSSFWorkbook wb = new XSSFWorkbook(file);
				ISheet ws = wb.GetSheetAt(0);
				var row1 = ws.GetRow(0);      // 获取第一行即标头
				int cellCount = row1.LastCellNum;// 第一行的列数
												 // 把第一行的数据添加到datatable的列名
				for (int i = row1.FirstCellNum; i < cellCount; i++)
				{
					//DataColumn column = new DataColumn(row1.GetCell(i).StringCellValue);
					DataColumn column = new DataColumn(row1.GetCell(i).ToString());
					dt.Columns.Add(column);
				}
				int row = ws.LastRowNum;
				for (int i = ws.FirstRowNum + 1; i <= ws.LastRowNum; i++)
				{
					IRow row2 = ws.GetRow(i);
					DataRow datarow = dt.NewRow();
					for (int j = row2.FirstCellNum; j < cellCount; j++)
					{
						if (row2.GetCell(j) != null)
						{
							datarow[j] = row2.GetCell(j);
						}
					}
					dt.Rows.Add(datarow);
				}

				Form3 frm3 = new Form3();
				frm3.dataGridView1.DataSource = dt;

				frm3.Show();
				wb.Close();
			}
		}

		public void ReadFromExcel_2()
		{
			//XSSFWorkbook wb;
			IWorkbook wb = null;
			FileStream file;
			file = new FileStream(@"C:\Users\hp\Desktop\test1.xlsx", FileMode.Open, FileAccess.Read);
			wb = new XSSFWorkbook(file);
			//ISheet ws = wb.GetSheetAt(0);
			//ISheet ws =wb.GetSheet("Sheet1");
			XSSFSheet ws = (XSSFSheet)wb.GetSheet("Sheet1");
			var row1 = ws.GetRow(0);         // 获取第一行即表头
			int columnf = row1.FirstCellNum;
			int columne = row1.LastCellNum;  // 最后一列的列数
			int rowf = ws.FirstRowNum;
			int rowe = ws.LastRowNum;        // 最后一行的行数
			Console.WriteLine(columnf.ToString());
			Console.WriteLine(columne.ToString());
			Console.WriteLine(rowf.ToString());
			Console.WriteLine(rowe.ToString());
			Console.WriteLine(ws.GetRow(0).GetCell(0));   // 第1行第1列的数据

			file.Close();
			wb.Close();
		}

		public void CreatExcel_1()
		{
			XSSFWorkbook wb;
			wb = new XSSFWorkbook();
			XSSFSheet ws;
			ws = (XSSFSheet)wb.CreateSheet("sheet1");  // 创建一个新的工作表
			ws.CreateRow(0);              // 创建某个行：CreateRow(i)，从0开始计数
										  //ws.GetRow(0).Height = 20;     // 设置行高
			ws.GetRow(0).CreateCell(0);   // 创建某一列： 需要在定位到行的基础上，从0开始计数
			ws.GetRow(0).GetCell(0).SetCellValue("ABCD");
			ws.CreateRow(1).CreateCell(1).SetCellValue("ABAB");
			ICell cell1 = CellUtil.CreateCell(ws.CreateRow(2), 2, "BBB2");//添加A1到A1单元,并对Row0实例化
			Console.WriteLine(ws.GetRow(0).GetCell(0));
			Console.WriteLine(ws.GetRow(1).GetCell(1));
			Console.WriteLine(ws.GetRow(2).GetCell(2));
			//——————————————————————————
			ws.GetRow(0).CreateCell(1).SetCellValue(3);
			ws.GetRow(0).CreateCell(2).SetCellValue(4);
			XSSFCell cell2 = (XSSFCell)ws.GetRow(0).CreateCell(3);
			cell2.SetCellFormula("$B1+$C1");
			Console.WriteLine(cell2.NumericCellValue);  // ——————————要调用计算后才能获得正确的公式结果；
														//XSSFFormulaEvaluator e = new XSSFFormulaEvaluator(wb);
														//e.EvaluateFormulaCell(cell2);

			wb.GetCreationHelper().CreateFormulaEvaluator().EvaluateFormulaCell(cell2);

			Console.WriteLine(cell2.NumericCellValue); // ——————————要调用计算后才能获得正确的公式结果；
			Console.WriteLine(cell2.CellType);
			switch (cell2.CellType)
			{
				case CellType.Formula:
					Console.WriteLine("Formula");
					break;
				case CellType.Numeric:
					Console.WriteLine("Numeric");
					break;
				case CellType.Boolean:
					Console.WriteLine("Boolean");
					break;
				case CellType.String:
					Console.WriteLine("String");
					break;
				default:
					Console.WriteLine("哇哈哈");
					break;
			}
			//——————————————————————————
			//设置字体格式
			IFont font1 = wb.CreateFont();
			font1.FontName = "宋体";          //字体
			font1.FontHeightInPoints = 20;    //字号
			font1.Color = IndexedColors.Red.Index;
			font1.IsBold = true;              //粗体
			font1.IsItalic = true;            //斜体								 

			ICellStyle style1 = wb.CreateCellStyle();
			style1.SetFont(font1);
			cell1.CellStyle = style1;
			//——————————————————————————
			ICellStyle style2 = wb.CreateCellStyle();
			style2.BorderBottom = BorderStyle.Thin;        //添加边框
			style2.BorderLeft = BorderStyle.Thin;
			style2.BorderRight = BorderStyle.Thin;
			style2.BorderTop = BorderStyle.Thin;
			style2.WrapText = true;                        //自动换行
			style2.Alignment = HorizontalAlignment.Center; // 单元格水平居中,VerticalAlignment.Center（垂直居中）
			style2.VerticalAlignment = VerticalAlignment.Center;
			//style2.FillBackgroundColor = 47;
			style2.FillForegroundColor = IndexedColors.Blue.Index;
			style2.FillPattern = FillPattern.SolidForeground;

			ws.GetRow(0).GetCell(0).CellStyle = style2;
			//——————————————————————————
			ws.AddMergedRegion(new CellRangeAddress(2, 3, 0, 1));//合并A3-B4 CellRangeAddress(起始行,终止行,起始列,终止列);
																 //——————————————————————————
			FileStream file;
			file = new FileStream(@"C:\Users\hp\Desktop\test2.xlsx", FileMode.OpenOrCreate, FileAccess.Write);
			wb.Write(file);
			file.Close();

			//——————————————————————————————————————————————
			//MemoryStream ms = new MemoryStream();
			//wb.Write(ms);
			//FileStream fs = new FileStream(@"C:\Users\hp\Desktop\test3.xlsx", FileMode.Create, FileAccess.Write);
			//byte[] data = ms.ToArray();
			//fs.Write(data, 0, data.Length);
			//fs.Flush();
			//fs.Close();
			//——————————————————————————————————————————————

			MemoryStream ms = new MemoryStream();
			wb.Write(ms);
			byte[] data = ms.ToArray();
			using (FileStream fs = new FileStream(@"C:\Users\hp\Desktop\test4.xlsx", FileMode.Create, FileAccess.Write))
			{ 
				fs.Write(data, 0, data.Length);
				fs.Flush();
				fs.Close();
			}
			//——————————————————————————————————————————————

			wb.Close();
			Console.WriteLine("OK!!!");

		}
		public  void CreatExcel_2()
		{
			HSSFWorkbook workbook2003 = new HSSFWorkbook(); //新建工作簿
			workbook2003.CreateSheet("Sheet1");             // 新建1个Sheet工作表            
			HSSFSheet SheetOne = (HSSFSheet)workbook2003.GetSheet("Sheet1"); //获取名称为Sheet1的工作表
																			 //对工作表先添加行，下标从0开始
			for (int i = 0; i < 10; i++)
			{
				SheetOne.CreateRow(i);   //创建10行
			}
			//对每一行创建10个单元格
			HSSFRow SheetRow = (HSSFRow)SheetOne.GetRow(0);       //获取Sheet1工作表的首行
			HSSFCell[] SheetCell = new HSSFCell[10];
			for (int i = 0; i < 10; i++)
			{
				SheetCell[i] = (HSSFCell)SheetRow.CreateCell(i);  //为第一行创建10个单元格
			}
			//创建之后就可以赋值了
			SheetCell[0].SetCellValue(true);                //赋值为bool型         
			SheetCell[1].SetCellValue(0.000001);            //赋值为浮点型
			SheetCell[2].SetCellValue("Excel2003");         //赋值为字符串
			SheetCell[3].SetCellValue("123456789987654321");//赋值为长字符串
			for (int i = 4; i < 10; i++)
			{
				SheetCell[i].SetCellValue(i);               //循环赋值为整形
			}
			FileStream file2003 = new FileStream(@"C:\Users\hp\Desktop\Excel2003.xls", FileMode.Create);
			workbook2003.Write(file2003);
			file2003.Close();
			workbook2003.Close();

		}
	}
}