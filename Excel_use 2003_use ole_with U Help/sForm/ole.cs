using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Panbor_ImportWebSO
{
    public partial class ImportWebSO : Form
    {
        private bool allChk = false;//目前暫無使用.2011.11.15
 

        System.Data.DataTable oDT;
      
        //for init set 

        int RetVal = 0;
        int ErrCode = 0;
        string ErrMsg = null;
 

        public ImportWebSO( )
        {
            InitializeComponent();
          
            cbBPName.SelectedIndex = 0;
        }
 
        #region event  
        private void Search()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "all|*.*|xls Excel 檔案|*.xls|xlsx 2007 Excel 檔案|*.xlsx";
            openFileDialog1.Title = "Select a Excel File";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                TextFilePath.Text = openFileDialog1.FileName;
            }
        }
        public System.Data.DataTable loadGridFromExcel(string sFileName, string orderCmd)
        {
            System.Data.DataTable ret;
            func_excel_read_ole f = new func_excel_read_ole();
            string sheetName = f.getFirstSheetName(sFileName);
            ret = f.CreateDataSource(sFileName, sheetName);

            return ret;
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            //載入EXCEL,檢查欄位名稱,檢查item存在否.檢查訂單是否存在.
            BtnSearch.Enabled = false;
            try
            {
                Search();
                if (TextFilePath.Text == string.Empty)
                {
                    BtnSearch.Enabled = true;
                    return;
                }
 
 


                oDT = loadGridFromExcel(TextFilePath.Text, "");
                GV.DataSource = oDT;
                GV.AllowUserToAddRows = false;
                GV.ReadOnly = true;

                CloseDGVSort(ref GV); 

 

            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("外部資料表不是預期的格式"))
                {
                    //appl.MessageBox("請將檔案另存為2003格式!!", MessageType.Error);
                }
                else if (ex.Message.Contains("無值提供給一或多個必要參數"))
                {
                    //appl.MessageBox("檔案的欄位格式錯誤，請檢查檔案與營業夥伴是否相符!!", MessageType.Error);
                }
                else
                {
                    //appl.MessageBox("匯入失敗!!" + ex.ToString(), MessageType.Error);

                }
            }
            BtnSearch.Enabled = true;
        }
        private void CloseDGVSort(ref  DataGridView _GV)
        {
            for (int i = 0; i < GV.Columns.Count; i++)
            {
                _GV.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
 
 
      
        private void ImportWebSO_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
        #endregion


      　
 


   
 


 




    }
}