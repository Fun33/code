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
        private bool allChk = false;
        private AP_Appliction appl;

        System.Data.DataTable oDT;

        //init set
        public string CardCode = "";
        public string SOColName = "";
        public string ItemNameColName = "";

        public ImportWebSO(AP_Appliction _appl)
        {
            InitializeComponent();
            appl = _appl;
        }
        #region chk
        //chk 
        private bool chkSetting()
        {
            bool ret = true;
            if ((PropertySetting.BigBuyer_CardCode == string.Empty) | (PropertySetting.Monday_CardCode == string.Empty))
                ret = false;

            return ret;
        }
        private bool Chk()
        {
            bool ret = false;
            //chkfld
            ret = chkFld();
            if (ret == false)
            {
                this.appl.MessageBox(@"資料列有誤，請查閱記錄檔 : C:\Log\", MessageType.Warning);
                return ret;
            }
            //chk no this item
            ret = chkItemName();
            if (ret == false) return ret;

            //chk existed so
            if (chkExistedSO())
            { ret = false; return ret; }

            return ret;
        }

        private bool chkExistedSO()
        {
            bool ret = false;
            string soid = "";
            for (int i = 0; i <= this.GV .Rows.Count - 1; i++)
            {
                soid = GV.Rows[i].Cells [SOColName].ToString();
                if (this.existedSO(soid))
                {
                    GV.Rows[i].Cells[i].Value = "該訂單已存在";
                    appl.SetSystemLog("第" +i +"行"+soid + "該訂單已存在",MessageType.Warning );
                    ret = true;
                }
            }
            return ret;
        }
        private bool chkItemName()
        {
            bool ret = true;
            string soname = "";
            for (int i = 0; i <= this.GV.Rows.Count - 1; i++)
            {
                soname = GV.Rows[i].Cells [ItemNameColName].Value .ToString();
                if (isExistItemName(soname) == false)
                {
                    appl.SetSystemLog ("無此商品名稱 : " + soname,MessageType.Warning );
                    GV.Rows[i].Cells[1].Value= "無此商品名稱";
                    ret = false;
                }
            }
            return ret;
        }
        private bool chkFld()
        {
            bool ret = false;
            if (CardCode == PropertySetting.BigBuyer_CardCode)
            { ret = chkFld_BigBuyer(); }
            else if (CardCode == PropertySetting.Monday_CardCode)
            { ret = chkFld_Monday(); }

            return ret;
        }

        private bool chkFld_BigBuyer()
        {
            bool ret = true;

            if (oDT.Columns.Contains("收貨人") == false) { ret = false; appl.SetSystemLog ("請確認資料來源 : 缺少資料列 - " + "收貨人"); }
            if (oDT.Columns.Contains("聯絡電話") == false) { ret = false; DealError("請確認資料來源 : 缺少資料列 - " + "聯絡電話"); }
            if (oDT.Columns.Contains("(公)聯絡電話") == false) { ret = false; DealError("請確認資料來源 : 缺少資料列 - " + "公聯絡電話"); }
            if (oDT.Columns.Contains("行動電話") == false) { ret = false; DealError("請確認資料來源 : 缺少資料列 - " + "行動電話"); }
            if (oDT.Columns.Contains("地址") == false) { ret = false; DealError("請確認資料來源 : 缺少資料列 - " + "地址"); }
            if (oDT.Columns.Contains("訂購人") == false) { ret = false; DealError("請確認資料來源 : 缺少資料列 - " + "訂購人"); }
            if (oDT.Columns.Contains("訂購人電話") == false) { ret = false; DealError("請確認資料來源 : 缺少資料列 - " + "訂購人電話"); }
            if (oDT.Columns.Contains("訂購人行動電話") == false) { ret = false; DealError("請確認資料來源 : 缺少資料列 - " + "訂購人行動電話"); }
            if (oDT.Columns.Contains("接單時間") == false) { ret = false; DealError("請確認資料來源 : 缺少資料列 - " + "接單時間"); }
            if (oDT.Columns.Contains("訂單編號") == false) { ret = false; DealError("請確認資料來源 : 缺少資料列 - " + "訂單編號"); }
            if (oDT.Columns.Contains("出貨期限") == false) { ret = false; DealError("請確認資料來源 : 缺少資料列 - " + "出貨期限"); }
            if (oDT.Columns.Contains("商品名稱") == false) { ret = false; DealError("請確認資料來源 : 缺少資料列 - " + "商品名稱"); }
            if (oDT.Columns.Contains("商品數量") == false) { ret = false; DealError("請確認資料來源 : 缺少資料列 - " + "商品數量"); }
            if (oDT.Columns.Contains("供貨成本(未稅)") == false) { ret = false; DealError("請確認資料來源 : 缺少資料列 - " + "供貨成本未稅"); }
            if (oDT.Columns.Contains("訂單商品備註") == false) { ret = false; DealError("請確認資料來源 : 缺少資料列 - " + "訂單商品備註"); }

            return ret;
        }
        private bool chkFld_Monday()
        {
            bool ret = true;
            if (oDT.Columns.Contains("收件人姓名") == false) { ret = false; DealError("請確認資料來源 : 缺少資料列 - " + "收件人姓名"); }
            if (oDT.Columns.Contains("收件人電話(日)") == false) { ret = false; DealError("請確認資料來源 : 缺少資料列 - " + "收件人電話日"); }
            if (oDT.Columns.Contains("收件人手機") == false) { ret = false; DealError("請確認資料來源 : 缺少資料列 - " + "收件人手機"); }
            if (oDT.Columns.Contains("收件人地址") == false) { ret = false; DealError("請確認資料來源 : 缺少資料列 - " + "收件人地址"); }
            if (oDT.Columns.Contains("訂單編號") == false) { ret = false; DealError("請確認資料來源 : 缺少資料列 - " + "訂單編號"); }
            if (oDT.Columns.Contains("商品名稱") == false) { ret = false; DealError("請確認資料來源 : 缺少資料列 - " + "商品名稱"); }
            if (oDT.Columns.Contains("數量") == false) { ret = false; DealError("請確認資料來源 : 缺少資料列 - " + "數量"); }
            if (oDT.Columns.Contains("購物車備註") == false) { ret = false; DealError("請確認資料來源 : 缺少資料列 - " + "購物車備註"); }

            //if (oDT.Columns.Contains("") == false) { ret = false; DealError("請確認資料來源 : 缺少資料列 - " + ""); }

            return ret;
        }

        private bool isExistItemName(string ItemName)
        {
            bool ret = true;
            if (string.IsNullOrEmpty(this.getItemCode(CardCode, ItemName)))
            {
                ret = false;
            }
            return ret;
        }
        #endregion
        #region event
        private void GV_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0)
                if (allChk)
                    for (int i = 0; i < GV.Rows.Count; i++)
                    {
                        GV.Rows[i].Cells[0].Value = false;
                    }
                else
                    for (int i = 0; i < GV.Rows.Count; i++)
                    {
                        GV.Rows[i].Cells[0].Value = true;
                    }
        }
        private void Search()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "xls Excel 檔案|*.xls|xlsx 2007 Excel 檔案|*.xlsx";
            openFileDialog1.Title = "Select a Excel File";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                TextFilePath.Text = openFileDialog1.FileName;
            }
        }
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            BtnSearch.Enabled = false;
            try
            {
                Search();

                appl.StatusBar("開始載入EXCEL檔案...", MessageType.None);

                //載入DGV
                string strOrderCmd = " order by " + SOColName;//getOrderCmd();
                func ff = new func();

                 oDT =  loadGridFromExcel(s, strOrderCmd);
                GV.DataSource = oDT;

                appl.StatusBar("EXCEL載入完成!!", MessageType.Success);

                if (Chk())
                { BtnOK.Enabled = true; }
                else
                { BtnOK.Enabled = false; }
                appl.StatusBar("檢查完成!!", MessageType.None);

            }
            catch(Exception ex)
            {
                appl.SetSystemLog(ex.ToString());
            }
            BtnSearch.Enabled=true ;
        }
        #endregion
        #region deal



        private System.Data.DataTable getCurrDT(System.Data.DataTable _oDT)
        {

            System.Data.DataTable ret = _oDT.Copy();
            //string SONO = ret.Rows[0]["訂單編號"].ToString();
            string SONO = ret.Rows[0][SOColName].ToString();

            int i = 1;
            while (i < ret.Rows.Count)
            {
                if (SONO != ret.Rows[i][SOColName].ToString())
                {
                    ret.Rows[i].Delete();
                    ret.AcceptChanges();
                }
                else
                {
                    i = i + 1;
                }
            }

            return ret;
        }

        private void delSRCDT(ref System.Data.DataTable oDT)
        {
            //string SONO = oDT.Rows[0]["訂單編號"].ToString();
            string SONO = oDT.Rows[0][SOColName].ToString();


            int i = 0;
            while (i < oDT.Rows.Count)
            {
                if (SONO == oDT.Rows[i][SOColName].ToString())
                {
                    oDT.Rows[i].Delete();
                    oDT.AcceptChanges();
                }
                else
                {
                    i = i + 1;
                }
            }

        }

        private string getItemCode(string cardcode, string custitemname)
        {
            string ret = "";
            string cmd = "      select ItemCode  from OSCN where CardCode=N'{0}' and U_CustItemName =N'{1}' ";
            cmd = string.Format(cmd, cardcode, custitemname);

            ret = func.DoQuery(cmd, oCompany);
            return ret;
        }
        private bool existedSO(string NumAtCard)
        {
            string cmd = "  select case when COUNT(*) >0 then 1 else 0 end as existed from ORDR where  NumAtCard=N'{0}'  and CardCode=N'{1}'";
            cmd = string.Format(cmd, NumAtCard, CardCode);

            return appl.oSQLServer.ExecuteScalar  == "1";
        }

        #endregion

    }
}