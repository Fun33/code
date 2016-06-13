//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Text;
//using System.Windows.Forms;

//namespace Panbor_ImportWebSO
//{
//    public partial class ImportWebSO2
//    {
//        private bool allChk = false;//目前暫無使用.2011.11.15
//        private AP_Appliction appl;

//        System.Data.DataTable oDT;

//        //for init set
//        private string CardCode, SOColName, ItemNameColName;

//        int RetVal = 0;
//        int ErrCode = 0;
//        string ErrMsg = null;

//        private void InitSetting()
//        {
//            if (cbBPName.SelectedIndex == 0)
//            {
//                CardCode = PropertySetting.BigBuyer_CardCode;
//                SOColName = "訂單編號";
//                ItemNameColName = "商品名稱";
//                appl.SetSystemLog("設定客戶為大買家");
//            }
//            else if (cbBPName.SelectedIndex == 1)
//            {
//                CardCode = PropertySetting.Monday_CardCode;
//                SOColName = "訂單編號";
//                ItemNameColName = "商品名稱";
//                appl.SetSystemLog("設定客戶為興奇");
//            }
//            else if (cbBPName.SelectedIndex == 2)
//            {
//                CardCode = PropertySetting.LooCa_CardCode;
//                SOColName = "訂單代碼";
//                ItemNameColName = "商品全名";
//                appl.SetSystemLog("設定客戶為大晉");
//            }
//            else if (cbBPName.SelectedIndex == 3)
//            {
//                CardCode = PropertySetting.KIKY_CardCode;
//                SOColName = "訂單編號";
//                ItemNameColName = "產品貨號";
//                appl.SetSystemLog("設定客戶為驚奇");
//            }
//            else if (cbBPName.SelectedIndex == 4)
//            {
//                CardCode = PropertySetting.MOMO_CardCode;
//                SOColName = "訂單編號";
//                ItemNameColName = "產品貨號";
//                appl.SetSystemLog("設定客戶為富邦");
//            }
//        }

//        public ImportWebSO2(AP_Appliction _appl)
//        {
//            InitializeComponent();
//            appl = _appl;
//            cbBPName.SelectedIndex = 0;
//        }

//        //chk 

//        private bool ChkMain()
//        {
//            bool ret = false;
//            //chkfld
//            ret = chkFldMain();
//            if (ret == false)
//            {
//                this.appl.MessageBox(@"資料列有誤，請查閱記錄檔 : C:\Log\", MessageType.Warning);
//                return ret;
//            }
//            //chk no this item
//            ret = chkItemName();
//            if (ret == false) return ret;

//            //chk existed so
//            if (chkExistedSO())
//            { ret = false; return ret; }

//            return ret;
//        }

//        private bool chkExistedSO()
//        {
//            bool ret = false;
//            string soid = "";
//            for (int i = 0; i <= this.GV.Rows.Count - 1; i++)
//            {
//                soid = GV.Rows[i].Cells[SOColName].Value.ToString();
//                if (this.chkExistedSOSub(soid))
//                {
//                    GV.Rows[i].Cells[1].Value = "該訂單已存在";
//                    appl.SetSystemLog("第" + i + "行" + soid + "該訂單已存在", MessageType.Warning);
//                    ret = true;
//                }
//            }
//            return ret;
//        }
//        private bool chkExistedSOSub(string NumAtCard)
//        {
//            string cmd = "  select case when COUNT(*) >0 then 1 else 0 end as existed from ORDR where  NumAtCard=N'{0}'  and CardCode=N'{1}'";
//            cmd = string.Format(cmd, NumAtCard, CardCode);

//            return appl.oSQLServer.ExecuteScalar(cmd) == "1";
//        }
//        private bool chkItemName()
//        {
//            bool ret = true;
//            string soname = "";
//            for (int i = 0; i <= this.GV.Rows.Count - 1; i++)
//            {
//                soname = GV.Rows[i].Cells[ItemNameColName].Value.ToString();
//                if (isExistItemName(soname) == false)
//                {
//                    appl.SetSystemLog("無此商品名稱 : " + soname, MessageType.Warning);
//                    GV.Rows[i].Cells[1].Value = "無此商品名稱";
//                    ret = false;
//                }
//            }
//            return ret;
//        }
//        private bool chkFldMain()
//        {
//            bool ret = false;
//            if (CardCode == PropertySetting.BigBuyer_CardCode)
//            { ret = chkFld_BigBuyer(); }
//            else if (CardCode == PropertySetting.Monday_CardCode)
//            { ret = chkFld_Monday(); }
//            else if (CardCode == PropertySetting.LooCa_CardCode)
//            { ret = chkFld_LooCa(); }
//            else if (CardCode == PropertySetting.KIKY_CardCode)
//            { ret = chkFld_KIKY(); }
//            else if (CardCode == PropertySetting.MOMO_CardCode)
//            { ret = chkFld_MOMO(); }
//            return ret;
//        }

//        private bool chkFld_BigBuyer()
//        {
//            bool ret = true;

//            if (oDT.Columns.Contains("收貨人") == false) { ret = false; appl.SetSystemLog("請確認資料來源 : 缺少資料列 - " + "收貨人"); }
//            if (oDT.Columns.Contains("聯絡電話") == false) { ret = false; appl.SetSystemLog("請確認資料來源 : 缺少資料列 - " + "聯絡電話"); }
//            if (oDT.Columns.Contains("(公)聯絡電話") == false) { ret = false; appl.SetSystemLog("請確認資料來源 : 缺少資料列 - " + "公聯絡電話"); }
//            if (oDT.Columns.Contains("行動電話") == false) { ret = false; appl.SetSystemLog("請確認資料來源 : 缺少資料列 - " + "行動電話"); }
//            if (oDT.Columns.Contains("地址") == false) { ret = false; appl.SetSystemLog("請確認資料來源 : 缺少資料列 - " + "地址"); }
//            if (oDT.Columns.Contains("訂購人") == false) { ret = false; appl.SetSystemLog("請確認資料來源 : 缺少資料列 - " + "訂購人"); }
//            if (oDT.Columns.Contains("訂購人電話") == false) { ret = false; appl.SetSystemLog("請確認資料來源 : 缺少資料列 - " + "訂購人電話"); }
//            if (oDT.Columns.Contains("訂購人行動電話") == false) { ret = false; appl.SetSystemLog("請確認資料來源 : 缺少資料列 - " + "訂購人行動電話"); }
//            if (oDT.Columns.Contains("接單時間") == false) { ret = false; appl.SetSystemLog("請確認資料來源 : 缺少資料列 - " + "接單時間"); }
//            if (oDT.Columns.Contains(SOColName) == false) { ret = false; appl.SetSystemLog("請確認資料來源 : 缺少資料列 - " + SOColName); }
//            if (oDT.Columns.Contains("出貨期限") == false) { ret = false; appl.SetSystemLog("請確認資料來源 : 缺少資料列 - " + "出貨期限"); }
//            if (oDT.Columns.Contains(ItemNameColName) == false) { ret = false; appl.SetSystemLog("請確認資料來源 : 缺少資料列 - " + ItemNameColName); }
//            if (oDT.Columns.Contains("商品數量") == false) { ret = false; appl.SetSystemLog("請確認資料來源 : 缺少資料列 - " + "商品數量"); }
//            if (oDT.Columns.Contains("供貨成本(未稅)") == false) { ret = false; appl.SetSystemLog("請確認資料來源 : 缺少資料列 - " + "供貨成本未稅"); }
//            if (oDT.Columns.Contains("訂單商品備註") == false) { ret = false; appl.SetSystemLog("請確認資料來源 : 缺少資料列 - " + "訂單商品備註"); }

//            return ret;
//        }
//        private bool chkFld_Monday()
//        {
//            bool ret = true;
//            if (oDT.Columns.Contains("收件人姓名") == false) { ret = false; appl.SetSystemLog("請確認資料來源 : 缺少資料列 - " + "收件人姓名"); }
//            if (oDT.Columns.Contains("收件人電話(日)") == false) { ret = false; appl.SetSystemLog("請確認資料來源 : 缺少資料列 - " + "收件人電話日"); }
//            if (oDT.Columns.Contains("收件人手機") == false) { ret = false; appl.SetSystemLog("請確認資料來源 : 缺少資料列 - " + "收件人手機"); }
//            if (oDT.Columns.Contains("收件人地址") == false) { ret = false; appl.SetSystemLog("請確認資料來源 : 缺少資料列 - " + "收件人地址"); }
//            if (oDT.Columns.Contains(SOColName) == false) { ret = false; appl.SetSystemLog("請確認資料來源 : 缺少資料列 - " + SOColName); }
//            if (oDT.Columns.Contains(ItemNameColName) == false) { ret = false; appl.SetSystemLog("請確認資料來源 : 缺少資料列 - " + ItemNameColName); }
//            if (oDT.Columns.Contains("數量") == false) { ret = false; appl.SetSystemLog("請確認資料來源 : 缺少資料列 - " + "數量"); }
//            if (oDT.Columns.Contains("購物車備註") == false) { ret = false; appl.SetSystemLog("請確認資料來源 : 缺少資料列 - " + "購物車備註"); }

//            //if (oDT.Columns.Contains("") == false) { ret = false; appl.SetSystemLog("請確認資料來源 : 缺少資料列 - " + ""); }

//            return ret;
//        }
//        private bool chkFld_LooCa()
//        {
//            bool ret = true;
//            if (oDT.Columns.Contains("收件人") == false) { ret = false; appl.SetSystemLog("請確認資料來源 : 缺少資料列 - " + "收件人"); }
//            if (oDT.Columns.Contains("住家電話號碼") == false) { ret = false; appl.SetSystemLog("請確認資料來源 : 缺少資料列 - " + "住家電話號碼"); }
//            if (oDT.Columns.Contains("行動電話號碼") == false) { ret = false; appl.SetSystemLog("請確認資料來源 : 缺少資料列 - " + "行動電話號碼"); }
//            if (oDT.Columns.Contains("配送地址") == false) { ret = false; appl.SetSystemLog("請確認資料來源 : 缺少資料列 - " + "配送地址"); }

//            if (oDT.Columns.Contains("訂單日期") == false) { ret = false; appl.SetSystemLog("請確認資料來源 : 缺少資料列 - " + "訂單日期"); }
//            if (oDT.Columns.Contains("訂單代碼") == false) { ret = false; appl.SetSystemLog("請確認資料來源 : 缺少資料列 - " + "訂單代碼"); }
//            if (oDT.Columns.Contains("商品全名") == false) { ret = false; appl.SetSystemLog("請確認資料來源 : 缺少資料列 - " + "商品全名"); }
//            if (oDT.Columns.Contains("配送單訊息") == false) { ret = false; appl.SetSystemLog("請確認資料來源 : 缺少資料列 - " + "配送單訊息"); }

//            //if (oDT.Columns.Contains("") == false) { ret = false; appl.SetSystemLog("請確認資料來源 : 缺少資料列 - " + ""); }

//            return ret;
//        }
//        private bool chkFld_KIKY()
//        {
//            bool ret = true;
//            if (oDT.Columns.Contains("收件人") == false) { ret = false; appl.SetSystemLog("請確認資料來源 : 缺少資料列 - " + "收件人"); }
//            if (oDT.Columns.Contains("收件人電話") == false) { ret = false; appl.SetSystemLog("請確認資料來源 : 缺少資料列 - " + "收件人電話"); }
//            if (oDT.Columns.Contains("收件人手機") == false) { ret = false; appl.SetSystemLog("請確認資料來源 : 缺少資料列 - " + "收件人手機"); }
//            if (oDT.Columns.Contains("收件人地址") == false) { ret = false; appl.SetSystemLog("請確認資料來源 : 缺少資料列 - " + "收件人地址"); }

//            if (oDT.Columns.Contains("代收款") == false) { ret = false; appl.SetSystemLog("請確認資料來源 : 缺少資料列 - " + "代收款"); }
//            if (oDT.Columns.Contains("收件人地址") == false) { ret = false; appl.SetSystemLog("請確認資料來源 : 缺少資料列 - " + "收件人地址"); }

//            if (oDT.Columns.Contains("訂單日期") == false) { ret = false; appl.SetSystemLog("請確認資料來源 : 缺少資料列 - " + "訂單日期"); }
//            if (oDT.Columns.Contains("訂單編號") == false) { ret = false; appl.SetSystemLog("請確認資料來源 : 缺少資料列 - " + "訂單編號"); }
//            if (oDT.Columns.Contains("數量") == false) { ret = false; appl.SetSystemLog("請確認資料來源 : 缺少資料列 - " + "數量"); }
//            if (oDT.Columns.Contains("單價") == false) { ret = false; appl.SetSystemLog("請確認資料來源 : 缺少資料列 - " + "單價"); }

//            if (oDT.Columns.Contains("產品貨號") == false) { ret = false; appl.SetSystemLog("請確認資料來源 : 缺少資料列 - " + "產品貨號"); }
//            if (oDT.Columns.Contains("規格") == false) { ret = false; appl.SetSystemLog("請確認資料來源 : 缺少資料列 - " + "規格"); }


//            return ret;
//        }
//        private bool chkFld_MOMO()
//        {
//            bool ret = true;
//            if (oDT.Columns.Contains("收件人") == false) { ret = false; appl.SetSystemLog("請確認資料來源 : 缺少資料列 - " + "收件人"); }
//            if (oDT.Columns.Contains("收件人電話") == false) { ret = false; appl.SetSystemLog("請確認資料來源 : 缺少資料列 - " + "收件人電話"); }
//            if (oDT.Columns.Contains("行動電話") == false) { ret = false; appl.SetSystemLog("請確認資料來源 : 缺少資料列 - " + "行動電話"); }
//            if (oDT.Columns.Contains("配送地址") == false) { ret = false; appl.SetSystemLog("請確認資料來源 : 缺少資料列 - " + "配送地址"); }

//            if (oDT.Columns.Contains("訂購人") == false) { ret = false; appl.SetSystemLog("請確認資料來源 : 缺少資料列 - " + "訂購人"); }
//            if (oDT.Columns.Contains("出貨指示日") == false) { ret = false; appl.SetSystemLog("請確認資料來源 : 缺少資料列 - " + "出貨指示日"); }

//            if (oDT.Columns.Contains("商品名稱") == false) { ret = false; appl.SetSystemLog("請確認資料來源 : 缺少資料列 - " + "商品名稱"); }
//            if (oDT.Columns.Contains("數量") == false) { ret = false; appl.SetSystemLog("請確認資料來源 : 缺少資料列 - " + "數量"); }


//            return ret;
//        }



//        #region event
//        /// <summary>
//        /// 全選或全部取消.目前暫無使用.2011.11.15
//        /// </summary>
//        /// <param name="sender"></param>
//        /// <param name="e"></param>
//        private void GV_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
//        {
//            if (e.ColumnIndex == 0)
//                if (allChk)
//                    GV_AllCheck(false);
//                else
//                    GV_AllCheck(true);

//        }
//        /// <summary>
//        /// 全選或全部取消.目前暫無使用.2011.11.15
//        /// </summary>
//        /// <param name="chk"></param>
//        private void GV_AllCheck(bool chk)
//        {
//            for (int i = 0; i < GV.Rows.Count; i++)
//            {
//                GV.Rows[i].Cells[0].Value = chk;
//            }
//        }
//        private void Search()
//        {
//            OpenFileDialog openFileDialog1 = new OpenFileDialog();
//            openFileDialog1.Filter = "xls Excel 檔案|*.xls|xlsx 2007 Excel 檔案|*.xlsx";
//            openFileDialog1.Title = "Select a Excel File";

//            if (openFileDialog1.ShowDialog() == DialogResult.OK)
//            {
//                TextFilePath.Text = openFileDialog1.FileName;
//            }
//        }
//        public System.Data.DataTable loadGridFromExcel(string sFileName, string orderCmd)
//        {
//            System.Data.DataTable ret;
//            func_excel_read_ole f = new func_excel_read_ole();
//            string sheetName = f.getFirstSheetName(sFileName);
//            ret = f.CreateDataSource(sFileName, sheetName);

//            return ret;
//        }

//        private void BtnSearch_Click(object sender, EventArgs e)
//        {
//            //載入EXCEL,檢查欄位名稱,檢查item存在否.檢查訂單是否存在.
//            BtnSearch.Enabled = false;
//            try
//            {
//                Search();
//                if (TextFilePath.Text == string.Empty)
//                {
//                    BtnSearch.Enabled = true;
//                    return;
//                }

//                appl.StatusBar("開始載入EXCEL檔案...", MessageType.None);

//                //載入DGV
//                string strOrderCmd = " order by " + SOColName;//getOrderCmd();


//                oDT = loadGridFromExcel(TextFilePath.Text, strOrderCmd);
//                GV.DataSource = oDT;
//                GV.AllowUserToAddRows = false;
//                GV.ReadOnly = true;

//                CloseDGVSort(ref GV);
//                appl.StatusBar("EXCEL載入完成!!", MessageType.Success);


//                //if (Chk())
//                //{ BtnOK.Enabled = true; }
//                //else
//                //{ BtnOK.Enabled = false; }
//                ChkMain();
//                appl.StatusBar("檢查完成!!", MessageType.None);

//            }
//            catch (Exception ex)
//            {
//                if (ex.Message.Contains("外部資料表不是預期的格式"))
//                {
//                    appl.MessageBox("請將檔案另存為2003格式!!", MessageType.Error);
//                }
//                else if (ex.Message.Contains("無值提供給一或多個必要參數"))
//                {
//                    appl.MessageBox("檔案的欄位格式錯誤，請檢查檔案與營業夥伴是否相符!!", MessageType.Error);
//                }
//                else
//                {
//                    appl.MessageBox("匯入失敗!!" & ex.ToString(), MessageType.Error);

//                }
//            }
//            BtnSearch.Enabled = true;
//        }
//        private void CloseDGVSort(ref WinUI_Helper.XenDataGridView _GV)
//        {
//            for (int i = 0; i < GV.Columns.Count; i++)
//            {
//                _GV.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
//            }
//        }
//        private void cbBPName_SelectedIndexChanged(object sender, EventArgs e)
//        {
//            InitSetting();
//        }

//        private void BtnOK_Click(object sender, EventArgs e)
//        {
//            //檢查欄位存在否.檢查item存在否.檢查SO存在否.
//            if ((oDT == null) || (oDT.Rows.Count == 0))
//            { appl.MessageBox("請重新匯入訂單", MessageType.Warning); appl.SetSystemLog("請重新匯入訂單!!"); return; }

//            BtnOK.Enabled = false;
//            GV_AllCheck(true);

//            try
//            {
//                appl.StatusBar("開始檢查檔案...", MessageType.None);
//                appl.SetSystemLog("開始檢查檔案...");
//                if (ChkMain() == false)
//                {
//                    appl.MessageBox("請檢查檔案!!", MessageType.Warning);
//                    appl.SetSystemLog("檔案有誤,請檢查檔案...");
//                    return;
//                }
//                appl.StatusBar("開始匯入...", MessageType.None);
//                appl.SetSystemLog("開始匯入...");

//                if (addSOMain())
//                {
//                    appl.MessageBox("匯入結束!!", MessageType.Success);
//                    appl.SetSystemLog("匯入結束!!");
//                }
//                else
//                {
//                    appl.MessageBox("匯入結束，且有部分失敗!!", MessageType.Warning);
//                    appl.SetSystemLog("匯入結束，且有部分失敗!!");
//                }

//                appl.StatusBar("匯入結束!!", MessageType.Success);
//                appl.SetSystemLog("匯入結束!!");

//            }
//            catch (Exception ex)
//            {
//                appl.StatusBar(ex.ToString(), MessageType.Warning);

//            }
//            finally
//            {
//                GV_AllCheck(false);
//                BtnOK.Enabled = true;
//            }
//        }
//        private void BtnCancel_Click(object sender, EventArgs e)
//        {
//            Close();
//        }
//        #endregion


//        private bool addSOMain()
//        {

//            bool ret = true;
//            //oCompany.StartTransaction();

//            try
//            {
//                if (CardCode == PropertySetting.BigBuyer_CardCode)
//                { ret = addSO_BigBuyer(); }
//                else if (CardCode == PropertySetting.Monday_CardCode)
//                { ret = addSO_Monday(); }
//                else if (CardCode == PropertySetting.LooCa_CardCode)
//                { ret = addSO_LooCa(); }
//                else if (CardCode == PropertySetting.KIKY_CardCode)
//                { ret = addSO_KIKY(); }
//                else if (CardCode == PropertySetting.MOMO_CardCode)
//                { ret = addSO_MOMO(); }
//            }
//            catch (Exception ex)
//            {
//                ret = false;
//                appl.SetSystemLog("新增失敗，" + ex.ToString(), MessageType.Error);
//            }

//            return ret;
//            //oCompany.EndTransaction(SAPbobsCOM.BoWfTransOpt.wf_Commit);
//        }

//        private bool addSO_BigBuyer()
//        {
//            bool ret = true;
//            SAPbobsCOM.Documents SO;
//            SO = (SAPbobsCOM.Documents)appl.oSAP.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oOrders);
//            bool Ischk;
//            appl.SetSystemLog("開始讀EXCEL..");
//            for (int i = 0; i < GV.Rows.Count; i++)
//            {
//                appl.SetSystemLog("開始取得SONO");
//                string SONO = GV.Rows[i].Cells[SOColName].Value.ToString();
//                appl.SetSystemLog("已取得SONO");
//                try
//                {
//                    appl.SetSystemLog("開始取得chk");
//                    Ischk = ((bool)((DataGridViewCheckBoxCell)GV.Rows[i].Cells[0]).EditedFormattedValue);
//                    appl.SetSystemLog("已取得chk");
//                    if (Ischk == false)
//                    {
//                        GV.Rows[i].Cells[1].Value = "未選取";
//                        continue;
//                    }
//                    //else
//                    //{
//                    appl.SetSystemLog("開始檢查訂單存在否與");
//                    if (chkExistedSOSub(SONO))
//                    {
//                        appl.SetSystemLog(SONO + "訂單已存在!!");
//                        GV.Rows[i].Cells[1].Value = "訂單已存在";
//                        ret = false;
//                        continue;
//                    }

//                    appl.SetSystemLog("第" + i + "筆,表頭開始..");
//                    if ((i == 0) || (GV.Rows[i].Cells[SOColName].Value.ToString() != GV.Rows[i - 1].Cells[SOColName].Value.ToString()))
//                    {

//                        addSOHead_BigBuyer(i, ref  SO);
//                    }

//                    appl.SetSystemLog("第" + i + "筆,表身開始..");
//                    string CustItemName = GV.Rows[i].Cells[ItemNameColName].Value.ToString();

//                    SO.Lines.ItemCode = getItemCode(CardCode, CustItemName);
//                    // SO.Lines.SupplierCatNum = dt.Rows.Item(0).Item("商品貨號").ToString()使用者要維護,如果未相同,就會出錯.

//                    //SO.Lines.ItemDescription = GV.Rows[i].Cells["商品名稱"].Value.ToString();
//                    SO.Lines.Quantity = int.Parse(GV.Rows[i].Cells["商品數量"].Value.ToString());
//                    SO.Lines.Price = double.Parse(GV.Rows[i].Cells["供貨成本(未稅)"].Value.ToString());
//                    SO.Lines.Add();
//                    //SO.Lines.UserFields.Fields.Item("").Value = ""
//                    if ((i == GV.Rows.Count - 1) || (GV.Rows[i].Cells[SOColName].Value.ToString()) != GV.Rows[i + 1].Cells[SOColName].Value.ToString())
//                    {
//                        appl.SetSystemLog("第" + i + "筆,新增..");
//                        RetVal = SO.Add();
//                        if (RetVal != 0)
//                        {
//                            appl.oSAP.oCompany.GetLastError(out ErrCode, out ErrMsg);
//                            appl.SetSystemLog("訂單編號 " + SONO + "新增失敗，" + ErrMsg);
//                            GV.Rows[i].Cells[1].Value = ErrMsg;
//                            ret = false;
//                        }
//                        if (i != GV.RowCount - 1)
//                            SO = (SAPbobsCOM.Documents)appl.oSAP.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oOrders);
//                    }
//                }
//                //    }
//                //}
//                catch (Exception ex)
//                {
//                    appl.SetSystemLog(SONO + ex.ToString());
//                    GV.Rows[i].Cells[1].Value = "訂單編號 : " + SONO + ex.Message;
//                    ret = false;
//                }

//            }
//            return ret;
//        }

//        private void addSOHead_BigBuyer(int i, ref  SAPbobsCOM.Documents SO)
//        {
//            SO.Confirmed = SAPbobsCOM.BoYesNoEnum.tNO;
//            SO.CardCode = CardCode;
//            SO.DocDate = System.DateTime.Now;
//            SO.TaxDate = DateTime.Parse(GV.Rows[i].Cells["接單時間"].Value.ToString());
//            SO.NumAtCard = GV.Rows[i].Cells[SOColName].Value.ToString();
//            SO.DocDueDate = System.DateTime.Now.AddDays(2);
//            SO.RequriedDate = Convert.ToDateTime(GV.Rows[i].Cells["出貨期限"].Value);

//            //SO.Comments = GV.Rows[i].Cells["訂單商品備註"].Value.ToString();
//            SO.UserFields.Fields.Item("U_OrderNote").Value = GV.Rows[i].Cells["訂單商品備註"].Value.ToString();//2012.3.3.

//            SO.UserFields.Fields.Item("U_ReciName").Value = GV.Rows[i].Cells["收貨人"].Value.ToString();
//            SO.UserFields.Fields.Item("U_ReciTel1").Value = GV.Rows[i].Cells["聯絡電話"].Value.ToString();
//            SO.UserFields.Fields.Item("U_ReciTel2").Value = GV.Rows[i].Cells["(公)聯絡電話"].Value.ToString();
//            SO.UserFields.Fields.Item("U_ReciMobile").Value = GV.Rows[i].Cells["行動電話"].Value.ToString();
//            SO.UserFields.Fields.Item("U_ReciAddr").Value = GV.Rows[i].Cells["地址"].Value.ToString();

//            SO.UserFields.Fields.Item("U_DelMethod").Value = "1";
//            SO.UserFields.Fields.Item("U_DelTimeBgn").Value = "14:00";
//            SO.UserFields.Fields.Item("U_DelTimeEnd").Value = "18:00";
//            SO.UserFields.Fields.Item("U_OrderName").Value = GV.Rows[i].Cells["訂購人"].Value.ToString();
//            SO.UserFields.Fields.Item("U_OrderTel").Value = GV.Rows[i].Cells["訂購人電話"].Value.ToString();
//            SO.UserFields.Fields.Item("U_OrderMobile").Value = GV.Rows[i].Cells["訂購人行動電話"].Value.ToString();
//        }

//        private bool addSO_Monday()
//        {
//            bool ret = true;
//            SAPbobsCOM.Documents SO;
//            SO = (SAPbobsCOM.Documents)appl.oSAP.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oOrders);
//            bool Ischk;
//            for (int i = 0; i < GV.Rows.Count; i++)
//            {
//                Ischk = ((bool)((DataGridViewCheckBoxCell)GV.Rows[i].Cells[0]).EditedFormattedValue);
//                if (Ischk == false)
//                {
//                    GV.Rows[i].Cells[1].Value = "未選取";
//                    continue;
//                }
//                string SONO = GV.Rows[i].Cells[SOColName].Value.ToString();
//                if (chkExistedSOSub(SONO))
//                {
//                    appl.SetSystemLog(SONO + "訂單已存在!!");
//                    GV.Rows[i].Cells[1].Value = "訂單已存在";
//                    ret = false;
//                    continue;
//                }

//                if ((i == 0) || (GV.Rows[i].Cells[SOColName].Value.ToString() != GV.Rows[i - 1].Cells[SOColName].Value.ToString()))
//                {
//                    addSOHead_Monday(ref SO, i);



//                    string CustItemName = GV.Rows[i].Cells[ItemNameColName].Value.ToString();

//                    SO.Lines.ItemCode = getItemCode(CardCode, CustItemName);

//                    //SO.Lines.ItemDescription = GV.Rows[i].Cells["商品名稱"].Value.ToString();
//                    SO.Lines.Quantity = int.Parse(GV.Rows[i].Cells["數量"].Value.ToString());
//                    SO.Lines.Price = double.Parse(GV.Rows[i].Cells["單價"].Value.ToString());

//                    //SO.Lines.UserFields.Fields.Item("").Value = ""
//                    SO.Lines.Add();

//                    if ((i == GV.Rows.Count - 1) || (GV.Rows[i].Cells[SOColName].Value.ToString() != GV.Rows[i + 1].Cells[SOColName].Value.ToString()))
//                    {
//                        RetVal = SO.Add();
//                        if (RetVal != 0)
//                        {
//                            appl.oSAP.oCompany.GetLastError(out ErrCode, out ErrMsg);
//                            appl.SetSystemLog(SONO + "新增失敗，" + ErrMsg);
//                            GV.Rows[i].Cells[1].Value = ErrMsg;
//                            ret = false;

//                        }
//                        if (i != GV.RowCount - 1)
//                            SO = (SAPbobsCOM.Documents)appl.oSAP.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oOrders);
//                    }
//                }
//            }


//            return ret;
//        }

//        private void addSOHead_Monday(ref SAPbobsCOM.Documents SO, int i)
//        {
//            SO.Confirmed = SAPbobsCOM.BoYesNoEnum.tNO;
//            SO.CardCode = CardCode;
//            SO.DocDate = System.DateTime.Now;
//            SO.NumAtCard = GV.Rows[i].Cells[SOColName].Value.ToString();
//            SO.DocDueDate = System.DateTime.Now.AddDays(2);
//            SO.RequriedDate = System.DateTime.Now.AddDays(7);

//            //SO.Comments = GV.Rows[i].Cells["購物車備註"].Value.ToString(); 
//            SO.UserFields.Fields.Item("U_OrderNote").Value = GV.Rows[i].Cells["購物車備註"].Value.ToString();//2012.3.3.


//            SO.UserFields.Fields.Item("U_ReciName").Value = GV.Rows[i].Cells["收件人姓名"].Value.ToString();
//            SO.UserFields.Fields.Item("U_ReciTel1").Value = GV.Rows[i].Cells["收件人電話(日)"].Value.ToString();
//            SO.UserFields.Fields.Item("U_ReciMobile").Value = GV.Rows[i].Cells["收件人手機"].Value.ToString();
//            SO.UserFields.Fields.Item("U_ReciAddr").Value = GV.Rows[i].Cells["收件人地址"].Value.ToString();

//            SO.UserFields.Fields.Item("U_DelMethod").Value = "1";
//            SO.UserFields.Fields.Item("U_DelTimeBgn").Value = "14:00";
//            SO.UserFields.Fields.Item("U_DelTimeEnd").Value = "18:00";
//        }

//        private bool addSO_LooCa()
//        {
//            bool ret = true;
//            SAPbobsCOM.Documents SO;
//            SO = (SAPbobsCOM.Documents)appl.oSAP.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oOrders);
//            bool Ischk;
//            for (int i = 0; i < GV.Rows.Count; i++)
//            {
//                string SONO = GV.Rows[i].Cells[SOColName].Value.ToString();
//                try
//                {
//                    Ischk = ((bool)((DataGridViewCheckBoxCell)GV.Rows[i].Cells[0]).EditedFormattedValue);
//                    if (Ischk == false)
//                    {
//                        GV.Rows[i].Cells[1].Value = "未選取";
//                        continue;
//                    }

//                    if (chkExistedSOSub(SONO))
//                    {
//                        appl.SetSystemLog(SONO + "訂單已存在!!");
//                        GV.Rows[i].Cells[1].Value = "訂單已存在";
//                        ret = false;
//                        continue;
//                    }

//                    if ((i == 0) || (GV.Rows[i].Cells[SOColName].Value.ToString() != GV.Rows[i - 1].Cells[SOColName].Value.ToString()))
//                    {

//                        this.addSOHead_LooCa(i, ref  SO);
//                    }


//                    string CustItemName = GV.Rows[i].Cells[ItemNameColName].Value.ToString();

//                    SO.Lines.ItemCode = getItemCode(CardCode, CustItemName);
//                    // SO.Lines.SupplierCatNum = dt.Rows.Item(0).Item("商品貨號").ToString()使用者要維護,如果未相同,就會出錯.

//                    SO.Lines.Quantity = 1;
//                    SO.Lines.Add();
//                    //SO.Lines.UserFields.Fields.Item("").Value = ""
//                    if ((i == GV.Rows.Count - 1) || (GV.Rows[i].Cells[SOColName].Value.ToString() != GV.Rows[i + 1].Cells[SOColName].Value.ToString()))
//                    {
//                        RetVal = SO.Add();
//                        if (RetVal != 0)
//                        {
//                            appl.oSAP.oCompany.GetLastError(out ErrCode, out ErrMsg);
//                            appl.SetSystemLog(SONO + "新增失敗，" + ErrMsg);
//                            GV.Rows[i].Cells[1].Value = "ErrMsg";
//                            ret = false;
//                        }
//                        if (i != GV.RowCount - 1)
//                            SO = (SAPbobsCOM.Documents)appl.oSAP.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oOrders);
//                    }
//                }
//                catch (Exception ex)
//                {
//                    appl.SetSystemLog(SONO + ex.ToString());
//                    GV.Rows[i].Cells[1].Value = ex.Message;
//                    ret = false;
//                }
//            }
//            return ret;
//        }

//        private void addSOHead_LooCa(int i, ref  SAPbobsCOM.Documents SO)
//        {
//            SO.Confirmed = SAPbobsCOM.BoYesNoEnum.tNO;
//            SO.CardCode = CardCode;
//            SO.DocDate = System.DateTime.Now;
//            SO.TaxDate = DateTime.Parse(GV.Rows[i].Cells["訂單日期"].Value.ToString());
//            SO.NumAtCard = GV.Rows[i].Cells["訂單代碼"].Value.ToString();
//            SO.DocDueDate = System.DateTime.Now.AddDays(5);
//            SO.RequriedDate = System.DateTime.Now.AddDays(10);

//            //SO.Comments = GV.Rows[i].Cells["配送單訊息"].Value.ToString();
//            SO.UserFields.Fields.Item("U_OrderNote").Value = GV.Rows[i].Cells["配送單訊息"].Value.ToString();//2012.3.3.



//            SO.UserFields.Fields.Item("U_ReciName").Value = GV.Rows[i].Cells["收件人"].Value.ToString();
//            SO.UserFields.Fields.Item("U_ReciTel1").Value = GV.Rows[i].Cells["住家電話號碼"].Value.ToString();
//            SO.UserFields.Fields.Item("U_ReciMobile").Value = GV.Rows[i].Cells["行動電話號碼"].Value.ToString();
//            SO.UserFields.Fields.Item("U_ReciAddr").Value = GV.Rows[i].Cells["配送地址"].Value.ToString();

//            SO.UserFields.Fields.Item("U_DelMethod").Value = "1";
//            SO.UserFields.Fields.Item("U_DelTimeBgn").Value = "14:00";
//            SO.UserFields.Fields.Item("U_DelTimeEnd").Value = "18:00";
//        }


//        private bool addSO_KIKY()
//        {
//            bool ret = true;
//            SAPbobsCOM.Documents SO;
//            SO = (SAPbobsCOM.Documents)appl.oSAP.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oOrders);
//            bool Ischk;
//            for (int i = 0; i < GV.Rows.Count; i++)
//            {
//                string SONO = GV.Rows[i].Cells[SOColName].Value.ToString();
//                try
//                {
//                    Ischk = ((bool)((DataGridViewCheckBoxCell)GV.Rows[i].Cells[0]).EditedFormattedValue);
//                    if (Ischk == false)
//                    {
//                        GV.Rows[i].Cells[1].Value = "未選取";
//                        continue;
//                    }

//                    if (chkExistedSOSub(SONO))
//                    {
//                        appl.SetSystemLog(SONO + "訂單已存在!!");
//                        GV.Rows[i].Cells[1].Value = "訂單已存在";
//                        ret = false;
//                        continue;
//                    }

//                    if ((i == 0) || (GV.Rows[i].Cells[SOColName].Value.ToString() != GV.Rows[i - 1].Cells[SOColName].Value.ToString()))
//                    {

//                        this.addSOHead_KIKY(i, ref  SO);
//                    }


//                    string CustItemName = GV.Rows[i].Cells[ItemNameColName].Value.ToString();

//                    SO.Lines.ItemCode = getItemCode(CardCode, CustItemName);
//                    // SO.Lines.SupplierCatNum = dt.Rows.Item(0).Item("商品貨號").ToString()使用者要維護,如果未相同,就會出錯.

//                    SO.Lines.Quantity = int.Parse(GV.Rows[i].Cells["數量"].Value.ToString());


//                    SO.Lines.Add();
//                    //SO.Lines.UserFields.Fields.Item("").Value = ""
//                    if ((i == GV.Rows.Count - 1) || (GV.Rows[i].Cells[SOColName].Value.ToString() != GV.Rows[i + 1].Cells[SOColName].Value.ToString()))
//                    {
//                        RetVal = SO.Add();
//                        if (RetVal != 0)
//                        {
//                            appl.oSAP.oCompany.GetLastError(out ErrCode, out ErrMsg);
//                            appl.SetSystemLog(SONO + "新增失敗，" + ErrMsg);
//                            GV.Rows[i].Cells[1].Value = "ErrMsg";
//                            ret = false;
//                        }
//                        if (i != GV.RowCount - 1)
//                            SO = (SAPbobsCOM.Documents)appl.oSAP.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oOrders);
//                    }
//                }
//                catch (Exception ex)
//                {
//                    appl.SetSystemLog(SONO + ex.ToString());
//                    GV.Rows[i].Cells[1].Value = ex.Message;
//                    ret = false;
//                }
//            }
//            return ret;
//        }

//        private void addSOHead_KIKY(int i, ref  SAPbobsCOM.Documents SO)
//        {
//            SO.Confirmed = SAPbobsCOM.BoYesNoEnum.tNO;
//            SO.CardCode = CardCode;
//            SO.DocDate = System.DateTime.Now;
//            SO.TaxDate = DateTime.Parse(GV.Rows[i].Cells["訂單日期"].Value.ToString());
//            SO.NumAtCard = GV.Rows[i].Cells[SOColName].Value.ToString();
//            SO.DocDueDate = System.DateTime.Now.AddDays(3);
//            SO.RequriedDate = System.DateTime.Now.AddDays(7);

//            SO.UserFields.Fields.Item("U_ReciName").Value = GV.Rows[i].Cells["收件人"].Value.ToString();
//            SO.UserFields.Fields.Item("U_ReciTel1").Value = GV.Rows[i].Cells["收件人電話"].Value.ToString();
//            SO.UserFields.Fields.Item("U_ReciMobile").Value = GV.Rows[i].Cells["收件人手機"].Value.ToString();
//            SO.UserFields.Fields.Item("U_ReciAddr").Value = GV.Rows[i].Cells["收件人地址"].Value.ToString();

//            SO.UserFields.Fields.Item("U_DelMethod").Value = "1";
//            SO.UserFields.Fields.Item("U_DelTimeBgn").Value = "14:00";
//            SO.UserFields.Fields.Item("U_DelTimeEnd").Value = "18:00";

//            SO.UserFields.Fields.Item("U_CollectAmt").Value = GV.Rows[i].Cells["代收款"].Value.ToString();
//            SO.UserFields.Fields.Item("U_OrderNote").Value = GV.Rows[i].Cells["收件人地址"].Value.ToString();//2012.3.3. 
//        }

//        private bool addSO_MOMO()
//        {
//            bool ret = true;
//            SAPbobsCOM.Documents SO;
//            SO = (SAPbobsCOM.Documents)appl.oSAP.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oOrders);
//            bool Ischk;
//            for (int i = 0; i < GV.Rows.Count; i++)
//            {
//                string SONO = GV.Rows[i].Cells[SOColName].Value.ToString();
//                try
//                {
//                    Ischk = ((bool)((DataGridViewCheckBoxCell)GV.Rows[i].Cells[0]).EditedFormattedValue);
//                    if (Ischk == false)
//                    {
//                        GV.Rows[i].Cells[1].Value = "未選取";
//                        continue;
//                    }

//                    if (chkExistedSOSub(SONO))
//                    {
//                        appl.SetSystemLog(SONO + "訂單已存在!!");
//                        GV.Rows[i].Cells[1].Value = "訂單已存在";
//                        ret = false;
//                        continue;
//                    }

//                    if ((i == 0) || (GV.Rows[i].Cells[SOColName].Value.ToString() != GV.Rows[i - 1].Cells[SOColName].Value.ToString()))
//                    {

//                        this.addSOHead_MOMO(i, ref  SO);
//                    }


//                    string CustItemName = GV.Rows[i].Cells[ItemNameColName].Value.ToString();

//                    SO.Lines.ItemCode = getItemCode(CardCode, CustItemName);
//                    // SO.Lines.SupplierCatNum = dt.Rows.Item(0).Item("商品貨號").ToString()使用者要維護,如果未相同,就會出錯.

//                    SO.Lines.ItemDescription = GV.Rows[i].Cells["商品名稱"].Value.ToString();
//                    SO.Lines.Quantity = int.Parse(GV.Rows[i].Cells["數量"].Value.ToString());


//                    SO.Lines.Add();
//                    //SO.Lines.UserFields.Fields.Item("").Value = ""
//                    if ((i == GV.Rows.Count - 1) || (GV.Rows[i].Cells[SOColName].Value.ToString() != GV.Rows[i + 1].Cells[SOColName].Value.ToString()))
//                    {
//                        RetVal = SO.Add();
//                        if (RetVal != 0)
//                        {
//                            appl.oSAP.oCompany.GetLastError(out ErrCode, out ErrMsg);
//                            appl.SetSystemLog(SONO + "新增失敗，" + ErrMsg);
//                            GV.Rows[i].Cells[1].Value = "ErrMsg";
//                            ret = false;
//                        }
//                        if (i != GV.RowCount - 1)
//                            SO = (SAPbobsCOM.Documents)appl.oSAP.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oOrders);
//                    }
//                }
//                catch (Exception ex)
//                {
//                    appl.SetSystemLog(SONO + ex.ToString());
//                    GV.Rows[i].Cells[1].Value = ex.Message;
//                    ret = false;
//                }
//            }
//            return ret;
//        }

//        private void addSOHead_MOMO(int i, ref  SAPbobsCOM.Documents SO)
//        {
//            SO.Confirmed = SAPbobsCOM.BoYesNoEnum.tNO;
//            SO.CardCode = CardCode;
//            SO.DocDate = System.DateTime.Now;
//            //SO.TaxDate = DateTime.Parse(GV.Rows[i].Cells["訂單日期"].Value.ToString());
//            //SO.NumAtCard = GV.Rows[i].Cells[SOColName].Value.ToString();
//            SO.DocDueDate = DateTime.Parse(GV.Rows[i].Cells["出貨指示日"].Value.ToString());
//            //SO.RequriedDate = System.DateTime.Now.AddDays(7);

//            SO.UserFields.Fields.Item("U_ReciName").Value = GV.Rows[i].Cells["收件人"].Value.ToString();
//            SO.UserFields.Fields.Item("U_ReciTel1").Value = GV.Rows[i].Cells["收件人電話"].Value.ToString();
//            SO.UserFields.Fields.Item("U_ReciMobile").Value = GV.Rows[i].Cells["行動電話"].Value.ToString();
//            SO.UserFields.Fields.Item("U_ReciAddr").Value = GV.Rows[i].Cells["配送地址"].Value.ToString();

//            SO.UserFields.Fields.Item("U_DelMethod").Value = "1";
//            SO.UserFields.Fields.Item("U_DelTimeBgn").Value = "14:00";
//            SO.UserFields.Fields.Item("U_DelTimeEnd").Value = "18:00";

//            SO.UserFields.Fields.Item("U_OrderName").Value = GV.Rows[i].Cells["訂購人"].Value.ToString();//2012.3.3. 
//        }




//        private string getItemCode(string cardcode, string custitemname)
//        {
//            string ret = "";
//            string cmd = "      select ItemCode  from OSCN where CardCode=N'{0}' and U_CustItemName =N'{1}' ";
//            cmd = string.Format(cmd, cardcode, custitemname);

//            ret = appl.oSQLServer.ExecuteScalar(cmd);
//            return ret;
//        }


//        private bool isExistItemName(string ItemName)
//        {
//            bool ret = true;
//            if (string.IsNullOrEmpty(this.getItemCode(CardCode, ItemName)))
//            {
//                ret = false;
//            }
//            return ret;
//        }

//        private void ImportWebSO_Load(object sender, EventArgs e)
//        {
//            this.WindowState = FormWindowState.Maximized;
//        }







//    }
//}