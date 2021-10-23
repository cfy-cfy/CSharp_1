using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;
namespace VSTOBOOK
{
    class ExcelObject
    {
        Excel.Application ExcelApp;
        public string result;
        public void GetExcelApp()
        {
            try
            {
                ExcelApp = (Excel.Application)Marshal.GetActiveObject("Excel.Application");
                ExcelApp.Visible = true;
            }
            catch (System.SystemException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void 创建工具栏()
        {
            try
            {
                ExcelApp.CommandBars["cmb"].Delete();
            }
            catch (System.SystemException ex)
            {
                MessageBox.Show(ex.Message);
            }
            Office.CommandBar cmb = ExcelApp.CommandBars.Add("cmb", Office.MsoBarPosition.msoBarTop, Type.Missing, true);
            cmb.Visible = true;
            for (int i = 1; i < 10; i++)
            {
                Office.CommandBarButton btn = (Office.CommandBarButton)cmb.Controls.Add(Office.MsoControlType.msoControlButton, Type.Missing, Type.Missing, Type.Missing, true);
                btn.Caption = i.ToString();
                btn.FaceId = i;
                btn.Style = Office.MsoButtonStyle.msoButtonIconAndCaption;
                btn.Click += new Office._CommandBarButtonEvents_ClickEventHandler(btn_Click);
            }
            ExcelApp.CommandBars["Standard"].Controls[1].Visible = false;//隐藏标准工具栏第一个控件.
        }
        public void btn_Click(Microsoft.Office.Core.CommandBarButton Ctrl, ref bool CancelDefault)
        {
            switch (Ctrl.Caption)
            {
                case "1":

                    break;
                case "2":

                    break;
                default:
                    ExcelApp.ActiveCell.Value = Ctrl.Caption;
                    break;
            }
        }
        public void Office文件选择对话框()
        {
            Office.FileDialog fd = ExcelApp.get_FileDialog(Office.MsoFileDialogType.msoFileDialogOpen);
            fd.AllowMultiSelect = false;
            fd.Show();
            result = fd.SelectedItems.Item(1);
        }
        public void 获取Excel对象()
        {
            //获取正在运行的Excel
            Excel.Application CurrentApp = (Excel.Application)Marshal.GetActiveObject("Excel.Application");
            MessageBox.Show(CurrentApp.Version + "");
        }
        public void 创建Excel对象()
        {
            Excel.Application NewApp = new Excel.Application();
            NewApp.Visible = true;
            NewApp.Caption = "new app";
        }
        public void Application对象常用属性读写()
        {
            ((Excel.Worksheet)ExcelApp.ActiveSheet).Name = "MySheet";//重命名活动工作表.
            Excel.Range rng = (Excel.Range)ExcelApp.Selection;//Excel所选对象赋值给对象变量rng.
            ExcelApp.StatusBar = "My Excel Application"; //改变Excel状态栏文字.
            MessageBox.Show(ExcelApp.Workbooks.Count + "");//显示工作簿个数.
            MessageBox.Show(ExcelApp.UserName + "");//显示用户名.
            ExcelApp.DisplayFormulaBar = false;//隐藏公式编辑栏
        }
        public void Application对象常用方法()
        {
            ExcelApp.Undo();//Excel撤销,相当于按下了Ctrl+Z;	
            ExcelApp.Workbooks.Close();//关闭所有工作簿
            ExcelApp.Quit();//退出Excel.			
        }
        public void Application对象常用事件()
        {
            ExcelApp.WorkbookBeforeClose += new Excel.AppEvents_WorkbookBeforeCloseEventHandler(ExcelApp_WorkbookBeforeClose);//创建Excel应用程序级事件过程.
            ExcelApp.SheetSelectionChange += new Excel.AppEvents_SheetSelectionChangeEventHandler(ExcelApp_SheetSelectionChange);
        }
        public void ExcelApp_WorkbookBeforeClose(Excel.Workbook wbk, ref bool Cancel)
        {
            MessageBox.Show("即将关闭:" + wbk.FullName);
            Cancel = true;//取消关闭.
        }
        public void ExcelApp_SheetSelectionChange(object sh, Excel.Range Target)
        {
            Target.Interior.Color = System.Drawing.Color.Green;//改变鼠标所选区域底纹颜色.
        }
        public void even()
        {
            Excel.Worksheet wst;
            wst = (Excel.Worksheet)ExcelApp.ActiveSheet;
            wst.SelectionChange += new Excel.DocEvents_SelectionChangeEventHandler(wst_SelectionChange);
        }
        public void wst_SelectionChange(Excel.Range Target)
        {
            MessageBox.Show(Target.Count + "");
        }
        public void Application重要集合对象()
        {
            MessageBox.Show(ExcelApp.Dialogs.Count + "");//Excel所有内置对话框个数.
            foreach (Excel.AddIn adn in ExcelApp.AddIns)
            {
                result += (adn.Name + "\t" + adn.Installed + "\n");
                //遍历所有加载项信息.
            }
            MessageBox.Show(ExcelApp.CommandBars.Count + "");
            foreach (Office.CommandBar cmb in ExcelApp.CommandBars)
            {
                result += (cmb.Name + "\t" + cmb.Type + "\n");
                //遍历所有工具栏信息.
            }
        }
        public void Workbook对象常用属性读写()
        {
            Excel.Workbook wbk;
            wbk = ExcelApp.ActiveWorkbook;//wbk为活动工作簿
            wbk = ExcelApp.Workbooks[1];	//wbk为第1个工作簿	
            //wbk=ExcelApp.Workbooks["Hello.xls"];//使用名称确定工作簿

            //
            result = wbk.Worksheets.Count + ""; //给出工作簿中一般工作表的个数.
            result = wbk.Sheets.Count + "";//给出工作簿中所有类型的工作表个数.

            //遍历打开的工作簿
            foreach (Excel.Workbook wb in ExcelApp.Workbooks)
            {
                result += (wb.Name + "\n");
            }
            //常用属性:
            bool sv = wbk.Saved;//工作簿是否已保存
            string path = wbk.Path;//工作簿文件路径
            bool pwd = wbk.HasPassword;//是否有密码保护

        }
        public void Workbook对象常用方法()
        {
            Excel.Workbook wbk;
            //打开已存在的工作簿文件
            wbk = ExcelApp.Workbooks.Open(@"C:\Documents and Settings\Administrator\桌面\long2.xlsm");
            result = wbk.FileFormat.ToString();

            //新建工作簿
            wbk = ExcelApp.Workbooks.Add();

            //保存工作簿
            wbk.SaveAs(@"C:\Documents and Settings\Administrator\桌面\我的工作簿.xlsx");

            //关闭工作簿
            wbk.Close(false, Type.Missing, Type.Missing);
        }
        public void Workbook对象常用事件()
        {
            Excel.Workbook wbk;
            wbk = ExcelApp.ActiveWorkbook;
            wbk.BeforeSave += new Excel.WorkbookEvents_BeforeSaveEventHandler(wbk_BeforeSave);
        }
        public void wbk_BeforeSave(bool UI, ref bool Cancel)
        {
            MessageBox.Show("取消保存!");
            Cancel = true;//取消保存操作.
        }

        public void Workbook重要集合对象()
        {
            Excel.Workbook wbk = ExcelApp.ActiveWorkbook;
            //遍历所有工作表
            foreach (Excel.Worksheet wst in wbk.Worksheets)
            {
                result += (wst.Name + "\n");
            }
            //			foreach (Office.DocumentProperty dp in wbk.CustomDocumentProperties)
            //			{
            //				result += (dp.Name  +"\n");
            //			}
            foreach (Excel.Window w in wbk.Windows)
            {
                w.Caption = "Change Caption";
                //改变工作簿各窗口的标题文字
            }
        }

        public void Worksheet对象常用属性读写()
        {
            Excel.Worksheet wst;
            wst = (Excel.Worksheet)ExcelApp.ActiveSheet;
            ///wst.Name="NewSheetName";//更改工作表名称
            wst = (Excel.Worksheet)ExcelApp.ActiveWorkbook.Worksheets[1];//通过数字下标引用
            wst = (Excel.Worksheet)ExcelApp.ActiveWorkbook.Worksheets["Sheet3"];//通过名称引用	
            MessageBox.Show(wst.Shapes.Count + "");//给出工作表中图形个数.
            wst.UsedRange.Select();//选择使用区域
            long r = wst.Rows.Count;
            long c = wst.Columns.Count;
            MessageBox.Show(r + "/" + c + "");//给出工作表的行数和列数
            wst.Visible = Excel.XlSheetVisibility.xlSheetHidden;//隐藏当前工作表
        }
        public void Worksheet对象常用方法()
        {
            Excel.Worksheet wst;
            wst = (Excel.Worksheet)ExcelApp.ActiveSheet;
            //wst=(Excel.Worksheet)ExcelApp.ActiveWorkbook.Worksheets.Add();//增加工作表
            ///wst.Delete();//删除工作表
            wst.Select();//选择工作表
            ///wst.Activate();//激活工作表

            //遍历工作表
            foreach (Excel.Worksheet w in ExcelApp.ActiveWorkbook.Worksheets)
            {
                result += (w.Index + "\t" + w.Name + "\n");
            }
        }
        public void Worksheet对象常用事件()
        {
            Excel.Worksheet wst2;
            wst2 = (Excel.Worksheet)ExcelApp.ActiveSheet;
            wst2.SelectionChange += new Excel.DocEvents_SelectionChangeEventHandler(wst2_SelectionChange);
            Excel.Worksheet wst3;
            wst3 = (Excel.Worksheet)ExcelApp.ActiveWorkbook.Worksheets[3];
            ///wst3.Activate();
            ///wst3.BeforeDoubleClick+=new Excel.DocEvents_BeforeDoubleClickEventHandler(wst3_BeforeDoubleClick);
        }
        public void wst2_SelectionChange(Excel.Range Target)
        {
            Target.Interior.Color = System.Drawing.Color.Yellow;
        }
        public void wst3_BeforeDoubleClick(Excel.Range Target, bool Cancel)
        {
            MessageBox.Show("双击了工作表");
        }
        public void Range对象常用属性读写()
        {
            Excel.Worksheet wst;
            Excel.Range rg;
            wst = (Excel.Worksheet)ExcelApp.ActiveSheet;
            rg = wst.Range["A" + 1];
            rg.Formula = "=Sum(4,5,3)";

            rg = wst.Range["B2:D5"];
            result = rg.get_Address(false, false);//返回地址
            rg.ClearContents();

            rg = (Excel.Range)wst.Cells[4, 5];

            rg = wst.Range["C23:H30"];
            long r = rg.Row;
            long c = rg.Column;
            MessageBox.Show(r + "/" + c);//返回左上角单元格行列数
        }
        public void Range对象常用方法()
        {
            Excel.Worksheet wst;
            Excel.Range rg;
            wst = (Excel.Worksheet)ExcelApp.ActiveSheet;
            rg = wst.Range["B:D"];
            rg.Select();
            rg.Merge();//合并单元格
            rg = wst.Range["B2"];
            Excel.Range rg2 = rg.get_Resize(2, 2);//改变Range的尺寸.
            rg2.Select();
        }
        public void Range对象的遍历()
        {
            Excel.Worksheet wst;
            Excel.Range rg;
            wst = (Excel.Worksheet)ExcelApp.ActiveSheet;
            rg = wst.Range["B2:D10"];
            int i = 0;
            foreach (Excel.Range rg2 in rg.Cells)
            {
                i++;
                rg2.Value = i;
            }
        }
        public void 二维数组与Range数据交换()
        {
            int[,] arr = new int[3, 4];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    arr[i, j] = i * 10 + j;
                }
            }
            Excel.Range rg = ExcelApp.Range["B2:E4"];
            rg.Select();
            rg.Value2 = arr;//数组写入单元格区域;
            object[,] arr2;
            arr2 = (object[,])ExcelApp.Range["B2:E2"].Value2;//行向区域写入数组;
            arr2 = (object[,])ExcelApp.Range["B2:B4"].Value2;//列向区域写入数组;
            arr2 = (object[,])ExcelApp.Range["C3:E4"].Value2;//矩形区域写入数组;	
        }
        public void 一维数组与Range数据交换()
        {
            int[] arr = new int[4] { 3, 5, 7, 9 };
            Excel.Range rg = ExcelApp.Range["A1:D1"];
            rg.Value2 = arr;//行向区域接受一维数组的数据;

            int[,] arr2 = new int[4, 1];
            for (int i = 0; i < 4; i++)
            {
                arr2[i, 0] = arr[i];
            }
            Excel.Range rg2 = ExcelApp.Range["A1:A4"];
            rg2.Value2 = arr2;//先将一维数组数据传递给二维数组;列向区域接受二维数组的数据.

            object[,] arr3 = (object[,])ExcelApp.Range["A1:C1"].Value2; //用二维数组来接受单元格数据.
        }
        public void 操作VBE()
        {   //需要引用"Microsoft Visual Basic for Applications Extensibility 5.3"
            //必须在Excel中,勾选"对VBA工程模型访问的信任"
            Microsoft.Vbe.Interop.VBE vbe = ExcelApp.VBE;
            Microsoft.Vbe.Interop.VBComponent vbc = vbe.ActiveVBProject.VBComponents.Add(Microsoft.Vbe.Interop.vbext_ComponentType.vbext_ct_StdModule);
            vbc.Name = "newModule";
            //插入一个新的标准模块,并且重命名.
            vbc.CodeModule.InsertLines(1, "Sub Test()\n\tMsgBox 123\nEnd Sub");//自动插入代码.
        }
    }
}
