using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using Microsoft.Office.Interop.Excel;

//http://www.dotblogs.com.tw/yc421206/archive/2009/01/11/6727.aspx
//http://blog.csdn.net/hummy010/article/details/6222751

  class func_excel_write
{
    //用於存放Microsoft Excel 引用的變數。 
    public Application xlApp;
    public Workbook xlBook;
    public Worksheet xlSheet;

    public Range xlRange;
    public void connect()
	{
        try
        {
            xlApp = new Microsoft.Office.Interop.Excel.Application(); 
            System.Environment.Exit(0);
        }
        catch
        {
       
        }
	}


    public void writeRows(string Filename, string [] []ary)
    {
        //===================================================
        //打開已經存在的EXCEL工件簿文件
        if (!System.IO.File.Exists(Filename))
        {
            xlBook = xlApp.Workbooks.Add(true);
        }
        else
        {
            xlBook = xlApp.Workbooks.Open(Filename, null,   null, null, null, null, null, null, null, null, null, null, null, null, null);
        }

        //停用警告訊息
        xlApp.DisplayAlerts = false;
        xlApp.Visible = false;
        xlBook.Activate(); 
        xlSheet = (Worksheet )xlBook.Worksheets[1];
        xlSheet.Activate();

        //===================================================

        for (Int32 i = 0; i <= ary.Length - 1; i++)
        {
            for (Int32 k = 0; k <= ary[i].Length - 1; k++)
            {
                xlSheet.Cells[i, k] = ary[i][k].ToString();
            }
        }

        if (!System.IO.File.Exists(Filename))
        {
            xlBook.SaveAs(Filename ,XlFileFormat.xlExcel8,   Type.Missing, Type.Missing, Type.Missing, Type.Missing                            , XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing,Type.Missing,Type.Missing);
        }
        else
        {
            xlBook.Save();
        }

        xlBook.Close(false, Type.Missing, Type.Missing);
        xlApp.Quit();
        System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);
        xlApp = null;
        xlBook = null;
        xlSheet = null;
        xlRange = null;
        GC.Collect();
    }

    public void writeRow(string Filename, string [] ary)
    {
        //===================================================
        //打開已經存在的EXCEL工件簿文件
        if (!System.IO.File.Exists(Filename))
        {
            xlBook = xlApp.Workbooks.Add(true);
        }
        else
        {
            xlBook = xlApp.Workbooks.Open(Filename, null, null, null, null, null, null, null, null, null, null, null, null, null, null);
        }

        //停用警告訊息
        xlApp.DisplayAlerts = false;
        xlApp.Visible = false;
        xlBook.Activate(); 
        xlSheet =(Worksheet ) xlBook.Worksheets[1];
        xlSheet.Activate();

        //===================================================

        Range userRange = xlSheet.UsedRange;
        int rowCount = userRange.Rows.Count;
        for (Int32 i = 0; i <= ary.Length - 1; i++)
        {
            if (!System.IO.File.Exists(Filename))
            {
                xlSheet.Cells[rowCount, i + 1] = ary[i].ToString();
            }
            else
            {
                xlSheet.Cells[rowCount + 1, i + 1] = ary[i].ToString();
            }

        }

        if (!System.IO.File.Exists(Filename))
        {
            xlBook.SaveAs(Filename, XlFileFormat.xlExcel8, Type.Missing, Type.Missing, Type.Missing, Type.Missing, XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
        }
        else
        {
            xlBook.Save();
        }

        xlBook.Close(false, Type.Missing, Type.Missing);
        System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);
        xlApp = null;
        xlBook = null;
        xlSheet = null;
        xlRange = null;
        GC.Collect();
    }

    public void writeCell(string Filename, int icol, int irow, string val)
    {
        //===================================================
        //打開已經存在的EXCEL工件簿文件
        if (!System.IO.File.Exists(Filename))
        {
            xlBook = xlApp.Workbooks.Add(true);
        }
        else
        {
            xlBook = xlApp.Workbooks.Open(Filename, null, null, null, null, null, null, null, null, null, null, null, null, null, null);
        }

        //停用警告訊息
        xlApp.DisplayAlerts = false;
        xlApp.Visible = false;
        xlBook.Activate(); 
        xlSheet = (Worksheet )xlBook.Worksheets[1];
        xlSheet.Activate();

        //===================================================

        xlSheet.Cells[irow, icol] = val;
        if (!System.IO.File.Exists(Filename))
        {
            xlBook.SaveAs(Filename, XlFileFormat.xlExcel8, Type.Missing, Type.Missing, Type.Missing, Type.Missing, XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
        }
        else
        {
            xlBook.Save();
        }

        xlBook.Close(false, Type.Missing, Type.Missing);
        System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);
        xlApp = null;
        xlBook = null;
        xlSheet = null;
        xlRange = null;
        GC.Collect();
    }
    public void write(string PODocNum, string item, Int16 qty)
    {
        string Filename = "C:\\test\\" + PODocNum + ".xlt";
        string[] ary = new string[] {
			PODocNum,
			item,
			qty.ToString()
		};
        writeRow(Filename, ary);
    }

}
