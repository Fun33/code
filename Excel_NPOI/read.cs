using System;
using System.Data;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System.Windows.Forms;
//首先，參考NPOI的元件進來，NPOI元件很多，若是針對EXCEL的話，就可以只要參考HSSF這個就可以
using System.IO;

//ref http://www.dotblogs.com.tw/jaigi/archive/2013/09/20/119097.aspx
//ref  http://einboch.pixnet.net/blog/post/274497938-%E4%BD%BF%E7%94%A8npoi%E7%94%A2%E7%94%9Fexcel%E6%AA%94%E6%A1%88
namespace NPOI
{
    public partial class read : Form
    {
        public read()
        {
            InitializeComponent();
        }

        private void read_Load(object sender, EventArgs e)
        {
            try
            {
                //dataGridView1.DataSource = ReadExcelAsTableNPOI(@"D:\cadmen\una_work\sample\NPOI\2003.xls");
                //dataGridView1.DataSource = ReadExcelAsTableNPOI2007(@"D:\cadmen\una_work\sample\NPOI\2007.xlsx");
                dataGridView1.DataSource = ReadExcelAsTableNPOI(@"D:\cadmen\una_work\sample\NPOI\2003.xls");
                dataGridView2.DataSource = ReadExcelAsTableNPOI(@"D:\cadmen\una_work\sample\NPOI\2007.xlsx");
               
                //dataGridView2.DataSource = ReadExcelAsTableNPOI(@"D:\333.xls");//b1匯出的,npoi也不能讀. 
             
            }   
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public void show(string sfile )
        {
            
            FileStream file = new FileStream(sfile , FileMode.Open, FileAccess.Read); // 開啟讀取樣版檔 
            HSSFWorkbook HssfWorkbook = new HSSFWorkbook(file);
            //.先取得Excel檔案的所有Stream資料，這邊取得Stream資料是包含EXCEL檔案中所有Sheet的資料流。
            //透過HSSFWorkbook類別抓取整份Excel檔案抓取Stream 物件，其中fs為stream 物件
        SS.UserModel.ISheet     Sheet = HssfWorkbook.GetSheetAt(0); // 取得Index為0的Sheet//在NPOI每個Sheet都是一個陣列中的物件，故可以用Index去取            得相關Sheet
     SS.UserModel.ICellStyle        CellStyle = HssfWorkbook.CreateCellStyle(); // 產生欄位樣式設定
  SS.UserModel.IFont           Font = HssfWorkbook.CreateFont();   // 產生字體樣式設定
        }

        /// <summary>
        /// test v1
        /// </summary>
        /// <param name="filename"></param>
        public void ReadExcelNPOI_v1(string filename)
        {
            try
            {
                using (FileStream fs = new FileStream(filename, FileMode.Open))
                {
                    HSSFWorkbook wb = new HSSFWorkbook(fs);
                    ISheet sheet = wb.GetSheetAt(0);
                    IRow row =  sheet.GetRow(0);

                    System.Diagnostics.Debug.WriteLine("");//換行   
                    System.Diagnostics.Debug.Write(row.GetCell (0)+"    ");
                    System.Diagnostics.Debug.Write(row.GetCell(1) + "    ");
                    System.Diagnostics.Debug.Write(row.GetCell(2) + "    ");
                    
                    row = sheet.GetRow(1);

                    System.Diagnostics.Debug.WriteLine("");//換行                    
                    System.Diagnostics.Debug.Write(row.GetCell(0) + "    ");
                    System.Diagnostics.Debug.Write(row.GetCell(1) + "    ");
                    System.Diagnostics.Debug.Write(row.GetCell(2) + "    ");               
                }
            }
            catch (Exception ex)
            { 

            }
        }
        /// <summary>
        /// test v2
        /// </summary>
        /// <param name="filename"></param>
        public void ReadExcelNPOI_v2(string filename)
        {
            try
            {
                using (FileStream fs = new FileStream(filename, FileMode.Open))//1.read file to stream.
                {
                    HSSFWorkbook wb = new HSSFWorkbook(fs);//2.將stream轉成wb
                    ISheet sheet = wb.GetSheetAt(0);//3.read wb.firstsheet.
                    IRow row = sheet.GetRow(0);//4.read sheet.row (wb.sheet.row)
                    //row.GetCell(0);5.read row.cell (wb.sheet.row.cell)

                    System.Diagnostics.Debug.WriteLine("");
                    System.Diagnostics.Debug.WriteLine("first row : "+sheet.FirstRowNum.ToString());
                    System.Diagnostics.Debug.WriteLine("last row : "+sheet.LastRowNum .ToString());

                    System.Diagnostics.Debug.WriteLine("first col : " + row.FirstCellNum .ToString());
                    System.Diagnostics.Debug.WriteLine("last col : " + row.LastCellNum .ToString());
                    
                    System.Diagnostics.Debug.WriteLine("");//換行
                    System.Diagnostics.Debug.Write(row.GetCell(0) + "    ");
                    System.Diagnostics.Debug.Write(row.GetCell(1) + "    ");
                    System.Diagnostics.Debug.Write(row.GetCell(2) + "    ");
                    if (row.GetCell(4) != null)//雖然最後一個col是3,但它不會out range.只會拿到null
                    System.Diagnostics.Debug.Write(row.GetCell(4) + "    ");
                    System.Diagnostics.Debug.WriteLine(row.GetCell(5) == null ? "0" : row.GetCell(5).ToString());//if null就給0


                    row = sheet.GetRow(1);
                    System.Diagnostics.Debug.WriteLine("");//換行
                    System.Diagnostics.Debug.Write(row.GetCell(0) + "    ");
                    System.Diagnostics.Debug.Write(row.GetCell(1) + "    ");
                    System.Diagnostics.Debug.Write(row.GetCell(2) + "    ");
                    if (row .GetCell(4)!=null)
                    System.Diagnostics.Debug.Write(row.GetCell(3) + "    ");
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void BtnV1_Click(object sender, EventArgs e)
        {
            ReadExcelNPOI_v1(@"D:\cadmen\una_work\sample\NPOI\2003.xls");
        }

        private void BtnV2_Click(object sender, EventArgs e)
        {
            ReadExcelNPOI_v2(@"D:\cadmen\una_work\sample\NPOI\2003.xls");
        }

        private void BtnDT_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = new DT().GetDataTable();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            write obj = new write();
            obj.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ReadExcelAsTableNPOI(@"D:\cadmen\una_work\sample\NPOI\2007.xlsx");
        }
    }
} 
