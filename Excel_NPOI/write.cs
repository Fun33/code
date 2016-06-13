using System;
using System.Data;
using System.Windows.Forms;

//ref http://no2don.blogspot.com/2013/02/c-nopi-excel-xls.html
namespace NPOI
{
    public partial class write : Form
    {
        public write()
        {
            InitializeComponent();
        }



        private HSSF.UserModel.HSSFWorkbook V1()
        {

            HSSF.UserModel.HSSFWorkbook wb = new HSSF.UserModel.HSSFWorkbook();
            SS.UserModel.ISheet sheet = wb.CreateSheet("Sheet1");
            SS.UserModel.IRow row = sheet.CreateRow(0);
            row.CreateCell(0);
            row.CreateCell(1);
            row.Cells[0].SetCellValue("t");
            row.Cells[1].SetCellValue("p");
            //row.CreateCell(0).SetCellValue("t");也可以這樣寫

            row = sheet.CreateRow(1);
            row.CreateCell(0);
            row.CreateCell(1);
            row.Cells[0].SetCellValue("1");
            row.Cells[1].SetCellValue("0");
            //不用再add回sheet.

            row = sheet.CreateRow(2);
            row.CreateCell(0);
            row.CreateCell(1);
            row.Cells[0].SetCellValue("b");
            row.Cells[1].SetCellValue("w");
            //不用再add回sheet.

            return wb;
        }

        //範例二，DataTable轉成Excel檔案的方法
        private SS.UserModel.IWorkbook V2()
        {
            DataTable dt = new DT().GetDataTable();
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
            return wb;

        }
        private void BtnV1_Click(object sender, EventArgs e)
        {
            HSSF.UserModel.HSSFWorkbook wb = V1();
            System.IO.FileStream file = new System.IO.FileStream(@"D:\cadmen\una_work\sample\NPOI\0_v1.xls", System.IO.FileMode.Create);//1.產生檔案
            wb.Write(file);//2.put steam to file
            file.Close();//3.close file
        }
        private void BtnV2_Click(object sender, EventArgs e)
        {
            SS.UserModel.IWorkbook wb = V2();
            System.IO.FileStream file = new System.IO.FileStream(@"D:\cadmen\una_work\sample\NPOI\0_v2.xls", System.IO.FileMode.Create);//1.產生檔案
            wb.Write(file);//2.put steam to file
            file.Close();//3.close file
        }

        private void write_Load(object sender, EventArgs e)
        {

        }
    }
}
