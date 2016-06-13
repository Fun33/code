using System;
using System.Data;
using System.IO;

namespace NPOI
{
    //ref http://einboch.pixnet.net/blog/post/274497938-%E4%BD%BF%E7%94%A8npoi%E7%94%A2%E7%94%9Fexcel%E6%AA%94%E6%A1%88

    public class NPOI
    {
        #region wrie
        //範例二，DataTable轉成Excel檔案的方法
        private void write(DataTable dt,string fileName)
        {
            try
            {
                //建立Excel 2003檔案
                SS.UserModel.IWorkbook wb = new HSSF.UserModel.HSSFWorkbook();
                SS.UserModel.ISheet sheet;

                ////建立Excel 2007檔案
                //IWorkbook wb = new XSSFWorkbook();
                //ISheet ws;

                if (dt.TableName != string.Empty)
                {
                    sheet = wb.CreateSheet(dt.TableName);
                }
                else
                {
                    sheet = wb.CreateSheet("Sheet1");
                }

                sheet.CreateRow(0);//第一行為欄位名稱
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    sheet.GetRow(0).CreateCell(i).SetCellValue(dt.Columns[i].ColumnName);
                }

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sheet.CreateRow(i + 1);
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        sheet.GetRow(i + 1).CreateCell(j).SetCellValue(dt.Rows[i][j].ToString());
                    }
                }

                System.IO.FileStream file = new System.IO.FileStream(fileName, System.IO.FileMode.Create);//1.產生檔案
                wb.Write(file);//2.put steam to file
                file.Close();//3.close file
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } 
        #endregion

        #region read
        /// <summary>
        ///  use me for 2003 and 2007
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public   DataTable ReadExcelAsTable(string fileName)
        {
            try
            {
                using (FileStream fs = new FileStream(fileName, FileMode.Open))
                {
                    //chk xls
                SS.UserModel.    ISheet sheet;
                    if (fileName.EndsWith("xlsx"))
                    {
                        XSSF.UserModel.XSSFWorkbook wb = new XSSF.UserModel.XSSFWorkbook(fs);//for 2007
                        sheet = wb.GetSheetAt(0);//read first sheet
                    }
                    else
                    {
                        SS.UserModel.IWorkbook            wb = new HSSF.UserModel. HSSFWorkbook(fs);//for 2003                    
                        sheet = wb.GetSheetAt(0);//read first sheet
                    }

                    return ReadSheet(sheet);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private   System.Data.DataTable ReadSheet(SS.UserModel.ISheet sheet)
        {
            //IRow row = sheet.GetRow(i);//get row
            DataTable oDT = new DataTable();
            //由第一列取標題做為欄位名稱
       SS.UserModel.    IRow headerRow = sheet.GetRow(0);//get head
            int cellCount = headerRow.LastCellNum;//get last col
            for (int i = headerRow.FirstCellNum; i < cellCount; i++)
                //以欄位文字為名新增欄位，此處全視為字串型別以求簡化
                oDT.Columns.Add(
                    new DataColumn(headerRow.GetCell(i).StringCellValue));

            //略過第零列(標題列)，一直處理至最後一列
            for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
            {
          SS.UserModel.      IRow row = sheet.GetRow(i);//get row
                if (row == null) continue;
                DataRow dataRow = oDT.NewRow();
                //依先前取得的欄位數逐一設定欄位內容
                for (int j = row.FirstCellNum; j < cellCount; j++)
                    if (row.GetCell(j) != null)
                        //如要針對不同型別做個別處理，可善用.CellType判斷型別
                        //再用.StringCellValue, .DateCellValue, .NumericCellValue...取值
                        //此處只簡單轉成字串
                        dataRow[j] = row.GetCell(j).ToString();
                oDT.Rows.Add(dataRow);
            }
            return oDT;

        }
        #endregion
    }
}
