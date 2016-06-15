using System;
using System.Windows.Forms;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System.IO;
using System.Data;

namespace NPOI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            HSSFWorkbook hssfwb;
            using (FileStream file = new FileStream(@"c:\test.xls", FileMode.Open, FileAccess.Read))
            {
                hssfwb = new HSSFWorkbook(file);
            }

            ISheet sheet = hssfwb.GetSheet("");
            for (int row = 0; row <= sheet.LastRowNum; row++)
            {
                if (sheet.GetRow(row) != null) //null is when the row only contains empty cells 
                {
                    MessageBox.Show(string.Format("Row {0} = {1}", row, sheet.GetRow(row).GetCell(0).StringCellValue));
                }
            }


        }
        private void Read(FileStream fs)
        {
            HSSFWorkbook workbook = new HSSFWorkbook(fs);
            HSSFSheet sheet = (HSSFSheet)workbook.GetSheetAt(0);

            DataTable table = new DataTable();

            HSSFRow headerRow = (HSSFRow)sheet.GetRow(0);
            int cellCount = headerRow.LastCellNum;

            for (int i = headerRow.FirstCellNum; i < cellCount; i++)
            {
                DataColumn column = new DataColumn(headerRow.GetCell(i).StringCellValue);
                table.Columns.Add(column);
            }

            int rowCount = sheet.LastRowNum;

            for (int i = (sheet.FirstRowNum + 1); i < sheet.LastRowNum; i++)
            {
                HSSFRow row = (HSSFRow)sheet.GetRow(i);
                DataRow dataRow = table.NewRow();

                for (int j = row.FirstCellNum; j < cellCount; j++)
                {
                    if (row.GetCell(j) != null)
                        dataRow[j] = row.GetCell(j).ToString();
                }

                table.Rows.Add(dataRow);
            }

            workbook = null;
            sheet = null;

            dataGridView1.DataSource = table;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            //string sheetName = new func_excel_read_NPOI_2003().getFirstSheetName(@"D:\銷售訂單_服務.xls");
            //dataGridView1.DataSource = new func_excel_read_NPOI_2003().GetDataSource(@"D:\銷售訂單_服務.xls", sheetName);
            //return;
            //using (FileStream file = new FileStream(@"D:\銷售訂單_服務.xls", FileMode.Open, FileAccess.Read))
            //{                
            //    Read(file);
            //}

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //ref http://no2don.blogspot.com/2013/02/c-nopi-excel-xls.html
            var workbook = new HSSFWorkbook();
            var sheetReportResult = workbook.CreateSheet("報表結果");

            //產生第一個要用CreateRow 
            sheetReportResult.CreateRow(0).CreateCell(0).SetCellValue("姓名");

            //之後的用GetRow 取得在CreateCell
            sheetReportResult.GetRow(0).CreateCell(1).SetCellValue("電話");
            sheetReportResult.GetRow(0).CreateCell(2).SetCellValue("備註");

            //第一Row 已經被Title用掉了 所以從1開始
            for (var i = 1; i <= 20; i++)
            {
                sheetReportResult.CreateRow(i).CreateCell(0).SetCellValue("用戶" + i);
                sheetReportResult.GetRow(i).CreateCell(1).SetCellValue("091234567" + i);
                sheetReportResult.GetRow(i).CreateCell(2).SetCellValue("我是備註" + i);
            }

            //sheetReportResult.SetColumnWidth(0, 20 * 256);
            //sheetReportResult.SetColumnWidth(1, 40 * 256);
            //sheetReportResult.SetColumnWidth(2, 40 * 256);

            //save
            var file = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "sample.xls", FileMode.Create);

            workbook.Write(file);
            workbook = null;
            file.Close();
            file.Dispose();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.Data.DataTable oDT = (System.Data.DataTable)dataGridView1.DataSource;
            new func_excel_write_NPOI().ExportExcel(true,oDT, @"D:\sample.xlt");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //string sheetName = new func_excel_read_NPOI_2007().getFirstSheetName(@"D:\123.xlsx");
            //dataGridView1.DataSource = new func_excel_read_NPOI_2007().GetDataSource(@"D:\123.xlsx", sheetName);

        }

        private void button6_Click(object sender, EventArgs e)
        {
            string sFile, sheetName;

          

            sFile = @"D:\銷售訂單_服務.xls";
            sheetName = new func_excel_read_NPOI().getFirstSheetName(sFile);
            dataGridView1.DataSource = new func_excel_read_NPOI().GetDataSource(sFile, sheetName);

            sFile = @"D:\123.xlsx";
              sheetName = new func_excel_read_NPOI().getFirstSheetName(sFile);
            dataGridView2.DataSource = new func_excel_read_NPOI().GetDataSource(sFile, sheetName);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            System.Data.DataTable oDT = (System.Data.DataTable)dataGridView1.DataSource;
            new func_excel_write_NPOI().ExportExcel(false , oDT, @"D:\sample.xlsx");
        }

    }
}

//HSSFWorkbook workbook = new HSSFWorkbook( sPathFile.FileContent);
//    HSSFSheet sheet = workbook.GetSheetAt(0);

//    DataTable table = new DataTable();

//    HSSFRow headerRow = sheet.GetRow(0);
//    int cellCount = headerRow.LastCellNum;

//    for (int i = headerRow.FirstCellNum; i < cellCount; i++)
//    {
//        DataColumn column = new DataColumn(headerRow.GetCell(i).StringCellValue);
//        table.Columns.Add(column);
//    }

//    int rowCount = sheet.LastRowNum;

//    for (int i = (sheet.FirstRowNum + 1); i < sheet.LastRowNum; i++)
//    {
//        HSSFRow row = sheet.GetRow(i);
//        DataRow dataRow = table.NewRow();

//        for (int j = row.FirstCellNum; j < cellCount; j++)
//        {
//            if (row.GetCell(j) != null)
//                dataRow[j] = row.GetCell(j).ToString();
//        }

//        table.Rows.Add(dataRow);
//    }

//    workbook = null;
//    sheet = null;

//    this.gvExcel.DataSource = table;
//    this.gvExcel.DataBind();