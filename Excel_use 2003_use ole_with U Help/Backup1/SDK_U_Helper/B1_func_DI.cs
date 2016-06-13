using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
public class func_DI
{
    int lRetCode;
    int lErrCode;

    string sErrMsg;

    #region func
    //    stuff(time, 2, 0, ':')
    //using System.Globalization;
    //DateTime parsed;
    //DateTime.TryParseExact("2012/01/01", "yyyy/MM/dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out parsed);


    //di.doquery
    public static string DoQuery(string cmd, SAPbobsCOM.Company oCompany)
    {
        string ret = "";
        try
        {
            SAPbobsCOM.Recordset recorder = (SAPbobsCOM.Recordset)oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

            recorder.DoQuery(cmd);

            if (recorder.Fields.Count != 0)
            {
                ret = recorder.Fields.Item(0).Value.ToString();

            }
        }
        catch (Exception ex)
        {
            throw (ex);
        }

        return ret;
    }
    /// <summary>    
    ///        ret = int.Parse(dt.Fields.Item(0).Value.ToString());
    ///        System.Runtime.InteropServices.Marshal.ReleaseComObject(dt);
    /// </summary>
    /// <param name="cmd"></param>
    /// <param name="oCompany"></param>
    /// <returns></returns>
    public static SAPbobsCOM.Recordset DoQueryRecordset(string cmd, SAPbobsCOM.Company oCompany)
    {
        SAPbobsCOM.Recordset recorder;
        try
        {
            recorder = (SAPbobsCOM.Recordset)oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

            recorder.DoQuery(cmd);
        }
        catch (Exception ex)
        {
            throw (ex);
        }

        return recorder;

    }
    public static void DoQueryDT(string cmd, ref SAPbouiCOM.DataTable oDT, ref SAPbouiCOM.Form oForm)
    {
        //SAPbouiCOM.DataTable oDT= oForm.DataSources.DataTables.Add("tmp");    
        //string cmd = "select cardcode from ocrd  where CardType<>'S'";
        oDT.ExecuteQuery(cmd);

    }
    //System.Runtime.InteropServices.Marshal.ReleaseComObject(oDT);
    public static void DoQueryDT(string cmd, ref SAPbouiCOM.DataTable oDT )
    {
        //SAPbouiCOM.DataTable oDT = null;
        //string sDocNum = ((SAPbouiCOM.EditText)SBO_Application.Forms.ActiveForm.Items.Item("18").Specific).Value;
        //try
        //{
        //    oDT = SBO_Application.Forms.ActiveForm.DataSources.DataTables.Add("tmp");
        //}
        //catch
        //{
        //    oDT = SBO_Application.Forms.ActiveForm.DataSources.DataTables.Item("tmp");
        //}

        //SAPbouiCOM.DataTable oDT= oForm.DataSources.DataTables.Add("tmp");    
        //string cmd = "select cardcode from ocrd  where CardType<>'S'";
        oDT.ExecuteQuery(cmd);
        //oDT.GetValue("ProfitCode", i).ToString();
        //this.cboBadItem.ValidValues.Add(oDT.GetValue("Code", i).ToString(), oDT.GetValue("Name", i).ToString());           
    }


    public void addUDF(SAPbobsCOM.Company oCompany, string fldTable, string fldName, string fldDesc, SAPbobsCOM.BoFieldTypes sType, int sSize)
    {

        SAPbobsCOM.UserFieldsMD oUserFieldsMD = default(SAPbobsCOM.UserFieldsMD);

        oUserFieldsMD = (SAPbobsCOM.UserFieldsMD)oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oUserFields);

        oUserFieldsMD.TableName = fldTable;
        oUserFieldsMD.Name = fldName;
        oUserFieldsMD.Description = fldDesc;
        oUserFieldsMD.Type = sType;
        oUserFieldsMD.EditSize = sSize;
        try
        {
            lRetCode = oUserFieldsMD.Add();

            //// Check for errors
            if (lRetCode != 0)
            {
                oCompany.GetLastError(out lErrCode, out  sErrMsg);
            }
            else
            {
                //log("Field: '" & oUserFieldsMD.Name & "' was added successfuly to " & oUserFieldsMD.TableName & " Table")
            }
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        oUserFieldsMD = null;
    }
    ///// <summary>
    ///// excel to grid.缺:有版本問題
    ///// </summary>
    ///// <param name="astrFileName"></param>
    ///// <param name="orderCmd"></param>
    ///// <returns></returns>
    //public System.Data.DataTable loadGridFromExcel(string astrFileName, string orderCmd)
    //{
    //    System.Data.DataTable ret;
    //    func_excel_read f = new func_excel_read();

    //    // "D:\cadmen\服務部\客戶提供的文件\panbor\_test\大買家_test.xls"
    //    string strSheetName = f.GetExcelWorkSheets(astrFileName)[0].ToString().Trim();
    //    string cmd = "Select * from [{0}$] {1}";
    //    cmd = string.Format(cmd, strSheetName, orderCmd);
    //    ret = f.GetExcelData(astrFileName, cmd);// order by 訂單編號");

    //    return ret;
    //}
    //public void ToDIDT(DataTable _dt, ref SAPbouiCOM.DataTable ret)
    //{
    //    try
    //    {
    //        if (ret != null)
    //        {
    //            while (ret.Rows.Count > 0)
    //            {
    //                ret.Rows.Remove(0);
    //            }
    //        }
    //        //add col for dt to di.dt
    //        string col = "";
    //        try
    //        {

    //            for (int j1 = 0; j1 <= _dt.Columns.Count - 1; j1++)
    //            {
    //                ret.Columns.Add(_dt.Columns[j1].ColumnName,SAPbouiCOM.BoFieldsType.ft_Text,500);
    //                col = col + _dt.Columns[j1].ColumnName + ",";

    //            }
    //            ret.Columns.Add("備註", SAPbouiCOM.BoFieldsType.ft_Text,500);
    //        }
    //        catch (Exception ex)
    //        {
    //        }

    //        //將EXCEL讀出的DT,丟到DI的DT中
    //        int i = 0;
    //        int j = 0;

    //        for (i = 0; i <= _dt.Rows.Count - 1; i++)
    //        {
    //            for (j = 0; j <= _dt.Columns.Count - 1; j++)
    //            {
    //                ret.Rows.Add(1);
    //                ret.SetValue(j, i, _dt.Rows[i][j].ToString().Replace("'",""));
    //            }
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        throw (ex);
    //    }
    //}



    #endregion


    #region insert row to udt
    //private void addControl(SAPbouiCOM.ItemEvent pVal)
    //{
    //    if (((pVal.FormType == 139 & pVal.EventType != SAPbouiCOM.BoEventTypes.et_FORM_UNLOAD) & (pVal.Before_Action == true)))
    //    {
    //        SAPbouiCOM.Form _frm = SBO_Application.Forms.GetFormByTypeAndCount(pVal.FormType, pVal.FormTypeCount);

    //        if (((pVal.EventType == SAPbouiCOM.BoEventTypes.et_FORM_LOAD) & (pVal.Before_Action == true)))
    //        {
    //            if (_frm != null)
    //            {
    //                if (pVal.Before_Action == true)
    //                {
    //                    addBtnTest1(ref _frm);
    //                    //AddChooseFromListFliter(ref _frm);
    //                    //AddBtn(ref _frm);
    //                }
    //            }
    //        }
    //    }
    //}
    ////function.getcodebyudt限制為code需為流水號數字.不可為字串.
    //private void getCodeByUDT(SAPbobsCOM.Company _oCompany, string _tableName)
    //{
    //    int code = 1;
    //    try
    //    {
    //        string cmd = "select max(code) from {0}";
    //        cmd = string.Format(cmd, _tableName);
    //        code = int.Parse(func.DoQuery(cmd, _oCompany))) + 1;
    //    }
    //    catch (Exception ex)
    //    {
    //    }
    //}
    ////set1
    //private void addBtnTest1(ref SAPbouiCOM.Form oForm)
    //{
    //    SAPbouiCOM.FormCreationParams oCP = null;
    //    SAPbouiCOM.Item oItem = null;
    //    SAPbouiCOM.StaticText oStatic = null;
    //    SAPbouiCOM.Button oButton = null;
    //    SAPbouiCOM.EditText oEdit = null;
    //    try
    //    {
    //        oItem = oForm.Items.Add("BtnTest1", SAPbouiCOM.BoFormItemTypes.it_BUTTON);

    //        oItem.Left = oForm.Items.Item("2").Left + oForm.Items.Item("2").Width + 5;
    //        oItem.Top = oForm.Items.Item("2").Top;
    //        oButton = ((SAPbouiCOM.Button)(oItem.Specific));
    //        oButton.Type = SAPbouiCOM.BoButtonTypes.bt_Caption;
    //        oButton.Caption = "test";
    //        oItem.Width = 50;
    //        oItem.Height = 50;
    //    }
    //    catch (Exception ex)
    //    { Message(ex.ToString()); }
    //}
    //private void BtnTest1Click(string FormUID, SAPbouiCOM.ItemEvent pVal)
    //{
    //    if (pVal.FormTypeEx == "139")
    //    {
    //        if (pVal.EventType == SAPbouiCOM.BoEventTypes.et_CLICK)
    //        {
    //            if (pVal.ItemUID == "BtnTest1")
    //            {
    //                try
    //                {
    //                    addDataToUDTTest(oCompany, "[@test]", "2_from addon");
    //                }
    //                catch (Exception ex)
    //                { Message(ex.ToString()); }
    //            }
    //        }
    //    }
    //}
    ////針對table做的.
    //private void addDataToUDTTest(SAPbobsCOM.Company _oCompany, string _code, string _name, string U_test)
    //{
    //    int iRet;
    //    string sErrMsg;
    //    try
    //    {
    //        //colname,val
    //        SAPbobsCOM.UserTable oUDT = _oCompany.UserTables.Item(0);
    //        oUDT.GetByKey("test");
    //        oUDT.Code = _code;
    //        oUDT.Name = _name;
    //        oUDT.UserFields.Fields.Item("U_test").Value = U_test;
    //        iRet = oUDT.Add();
    //        if (iRet != 0)
    //        {
    //            _oCompany.GetLastError(out iRet, out sErrMsg);
    //            throw (new Exception(iRet.ToString() + sErrMsg));
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        throw (ex);
    //    }
    //}
    //private void addDataToUDTTest(SAPbobsCOM.Company _oCompany, string _name, string U_test)
    //{
    //    int iRet;
    //    string sErrMsg;

    //    string _tableName = "test";
    //    try
    //    {
    //        //colname,val
    //        SAPbobsCOM.UserTable oUDT = _oCompany.UserTables.Item(0);
    //        oUDT.GetByKey(_tableName);
    //        oUDT.Code = getCodeByUDT(_oCompany, _tableName);
    //        oUDT.Name = _name;
    //        oUDT.UserFields.Fields.Item("U_test").Value = U_test;
    //        iRet = oUDT.Add();
    //        if (iRet != 0)
    //        {
    //            _oCompany.GetLastError(out iRet, out sErrMsg);
    //            throw (new Exception(iRet.ToString() + sErrMsg));
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        throw (ex);
    //    }
    //}
    ////for evey udt
    //private void addDataToUDT(SAPbobsCOM.Company _oCompany, string _tableName, string _code, string _name)
    //{
    //    int iRet;
    //    string sErrMsg;
    //    try
    //    {
    //        SAPbobsCOM.UserTable oUDT = _oCompany.UserTables.Item(0);
    //        oUDT.GetByKey(_tableName);
    //        oUDT.Code = _code;
    //        oUDT.Name = _name;
    //        iRet = oUDT.Add();
    //        if (iRet != 0)
    //        {
    //            _oCompany.GetLastError(out iRet, out sErrMsg);
    //            throw (new Exception(iRet.ToString() + sErrMsg));
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        throw (ex);
    //    }
    //}
    //private void addDataToUDT(SAPbobsCOM.Company _oCompany, string _tableName, string _name)
    //{
    //    int iRet;
    //    string sErrMsg;
    //    try
    //    {
    //        SAPbobsCOM.UserTable oUDT = _oCompany.UserTables.Item(0);
    //        oUDT.GetByKey(_tableName);
    //        oUDT.Code = getCodeByUDT(_oCompany, _tableName);
    //        oUDT.Name = _name;
    //        iRet = oUDT.Add();
    //        if (iRet != 0)
    //        {
    //            _oCompany.GetLastError(out iRet, out sErrMsg);
    //            throw (new Exception(iRet.ToString() + sErrMsg));
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        throw (ex);
    //    }
    //}

    #endregion

    #region  event 
    //private void SBO_Application_MenuEvent(ref SAPbouiCOM.MenuEvent pVal, out bool BubbleEvent)
    //{
    //    BubbleEvent = true;
    //    int fType, fCount;
    //    try
    //    {
    //        if (pVal.BeforeAction)
    //        {
    //            return;
    //        }

    //        if (
    //            pVal.MenuUID == "qc_stes" |
    //            pVal.MenuUID == "qc_tool" |
    //            pVal.MenuUID == "qc_plan" |
    //            pVal.MenuUID == "qc_iqc_trans"
    //            )
    //        {
    //            //if (!this.CheckLRPtb())
    //            //{
    //            //    return;
    //            //}

    //        }

    //        switch (pVal.MenuUID)
    //        {
    //            case "qc_sets":
    //                if (this.boApp.Companys.UserName.ToLower() != "manager")
    //                {
    //                    this.boApp.StatusBarText("SDK:限定manager帳戶執行。", SAPbouiCOM.BoStatusBarMessageType.smt_Error);
    //                    return;
    //                }
    //                //SDK_Setting lrp_sets = new SDK_Setting(this.boApp);
    //                //lrp_sets.Show();
    //                break;
    //            case "qc_tool":
    //                SDK_QC_Tool_List QC_Tool = new SDK_QC_Tool_List(this.boApp);
    //                QC_Tool.Show();
    //                break;
    //            case "qc_plan":
    //                SDK_QC_Plan QC_Plan = new SDK_QC_Plan(this.boApp);
    //                QC_Plan.Show();
    //                break;
    //            case "qc_iqc_trans":
    //                SDK_QC_IQC_Trans IQC_Trans = new SDK_QC_IQC_Trans(this.boApp);
    //                IQC_Trans.Show();
    //                break;
    //            case "1281":// Search
    //            case "1282":// ADD
    //            case "1291":// last data record
    //            case "1288":// next record
    //            case "1289":// previous record
    //            case "1290":// first data record
    //                if (this.SBO_Application.Forms.ActiveForm == null)
    //                {
    //                    return;
    //                }
    //                //this.boApp.StatusBarText(this.SBO_Application.Forms.ActiveForm.TypeEx, SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
    //                fType = this.SBO_Application.Forms.ActiveForm.Type;
    //                fCount = this.SBO_Application.Forms.ActiveForm.TypeCount;

    //                if (this.SBO_Application.Forms.ActiveForm.TypeEx == "150")
    //                {
    //                    this.SBO_Item_MenuEvent(fType, fCount, pVal.MenuUID, pVal.BeforeAction, ref BubbleEvent);
    //                }
    //                break;

    //        }


    //    }
    //    catch (Exception ex)
    //    {
    //        this.boApp.DealError(ex.ToString());
    //        this.SBO_Application.MessageBox(ex.ToString(), 1, "", "", "");
    //    }

    //}


    #endregion 

    //public class Pair
    //{
    //    public string key;
    //    public string value;
    //}
    //       Pair [] oPairs= new Pair[ oDTFrmXLS.Rows.Count];
    //           for (i = 0; i < oDTFrmXLS.Rows.Count; i++)
    //           {
    //               oPairs[i].key = "";
    //               oPairs[i].value = "";

    //private void AddPreferVendor(ref SAPbobsCOM.Items oItm, string ItemCode, string PreferredVendors)
    //{
    //    int exist, lines;
    //    string cmd;
    //    cmd = " declare @ItemCode nvarchar(50); " +
    //        " declare @VendorCode nvarchar(50); " +
    //        " set @ItemCode='" + ItemCode + "'; " +
    //        " set @VendorCode='" + PreferredVendors + "'; " +
    //        " declare @exist int; " +
    //        " declare @current int; " +
    //        " select @exist = COUNT(*) from ITM2 where ItemCode=@ItemCode and VendorCode=@VendorCode; " +
    //        " select @current = COUNT(*) from ITM2 where ItemCode=@ItemCode; " +
    //        " select @exist exist,@current Lines; ";
    //    SAPbobsCOM.Recordset dt;
    //    dt = func_DI.DoQueryRecordset(cmd, oCompany);
    //    exist = (int)dt.Fields.Item(0).Value;
    //    if (exist == 0)
    //    {
    //        oItm.PreferredVendors.Add();
    //        lines = (int)dt.Fields.Item(1).Value;
    //        oItm.PreferredVendors.SetCurrentLine(lines);
    //        oItm.PreferredVendors.BPCode = PreferredVendors;
    //        oItm.PreferredVendors.Add();

    //    }
    //    System.Runtime.InteropServices.Marshal.ReleaseComObject(dt);
    //}


}
