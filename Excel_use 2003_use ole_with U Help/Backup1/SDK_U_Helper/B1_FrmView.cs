using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
public class Grid
{

    //private const string title = "";
    private SAPbouiCOM.Application SBO_Application;
    private SAPbobsCOM.Company oCompany;
    SAP_UI oSAP; 

    private bool Init = true;

    string UID;

    //only for 
    private SAPbouiCOM.Form oForm;
    private SAPbouiCOM.Grid oGrid; 
    private SAPbouiCOM.DataTable oDTGrid;

    //for everyone.tmp.
    SAPbouiCOM.EditTextColumn oEditCol;
    private SAPbouiCOM.Item oItem;
     
    /// <summary>
    /// 使用方法,new grid();show();
    /// </summary>
    /// <param name="_SBO_Application"></param>
    /// <param name="_oCompany"></param>
    /// <param name="_oSAP"></param>
    public Grid(ref SAPbouiCOM.Application _SBO_Application, ref SAPbobsCOM.Company _oCompany,SAP_UI _oSAP)
    {
        SBO_Application = _SBO_Application;
        oCompany = _oCompany;
        oSAP = _oSAP;

        SBO_Application.ItemEvent += new SAPbouiCOM._IApplicationEvents_ItemEventEventHandler(SBO_Application_ItemEvent);
          
    }
 
    public void Show(string uni,string _caption,string  cmd )
    {
        try
        {
            UID = uni;
            this.createForm(uni,_caption  );
            this.createGrid();
            CreateFormBottem();
            loadGrid(cmd );

            this.oForm.Visible = true;
            Init = false;
        }
        catch (Exception ex)
        {
            if (ex.Message.Contains("Form - already exists"))
              oSAP.Message ("表單已存在!!");
            else
              oSAP.Message(ex.ToString());
            
            if ((this.oForm != null))
            {
                this.oForm.Close();
            }
        }
    }

    private void createForm(string uni,string _title )
    {
        SAPbouiCOM.FormCreationParams creationPackage = default(SAPbouiCOM.FormCreationParams);
        creationPackage =(SAPbouiCOM.FormCreationParams )SBO_Application.CreateObject(SAPbouiCOM.BoCreatableObjectType.cot_FormCreationParams);
        creationPackage.UniqueID = uni;
        oForm = SBO_Application.Forms.AddEx(creationPackage);

        oForm.Title = _title;
        oForm.Top = 44;
        oForm.Left = 336;
        oForm.Width = 900;
        oForm.Height = 300;
    }
    private void createGrid()
    {
        oDTGrid = this.oForm.DataSources.DataTables.Add("oDTSub");
        oItem = oForm.Items.Add("subGrd", SAPbouiCOM.BoFormItemTypes.it_GRID);
        oItem.Height = 200;
        oItem.Width = this.oForm.Width - 30;
        oItem.Top = 5;
        oItem.Left = 5;
        oGrid = (SAPbouiCOM.Grid )oItem.Specific;
        oGrid.DataTable = oDTGrid;
    }
    private void CreateFormBottem()
    {
        SAPbouiCOM.Item oItem = default(SAPbouiCOM.Item);
        SAPbouiCOM.Button oButton = default(SAPbouiCOM.Button);

       
        oItem = oForm.Items.Add("2", SAPbouiCOM.BoFormItemTypes.it_BUTTON);
        oSAP.setLocation_Left(oForm, ref oItem, 0);
        oButton = (SAPbouiCOM.Button)oItem.Specific;
        oButton.Caption = "關閉";

    }
    private void loadGrid(string cmd )
    {
        //        Dim cmd As String = "SELECT  WOR1.LineNum+1 as 列號碼,  WOR1.ItemCode as 子階項目號碼 ,OITM.ItemName as 項目名稱,   cast(WOR1.PlannedQty as decimal(18,2))) as 應發數量,cast(WOR1.IssuedQty as decimal(18,2))) as 已發數量,  cast(OITW.OnHand as decimal(18,2))) as 庫存量, cast(OITW.OnHand -  OITW.IsCommited as decimal(18,2))) AS 可用量,WOR1.wareHouse  as 倉庫  " _
        //& " from  WOR1 LEFT OUTER JOIN OITM ON WOR1.ItemCode = OITM.ItemCode LEFT OUTER JOIN                OITW ON WOR1.ItemCode = OITW.ItemCode AND WOR1.wareHouse =OITW.WhsCode " _
        //        & " where WOR1.DocEntry = N'{0}'"
        //string cmd = "  SELECT top 50 * from OCRD";
        //cmd = string.Format(cmd, docNum);
        oDTGrid.ExecuteQuery(cmd);

        
        oSAP. setGridReadonly(ref oGrid);
        formatSubGridColumn();
    }
 
 
    #region sbo event
    private void btn_Click(string FormUID, SAPbouiCOM.ItemEvent pVal)
    {
        if (pVal.FormUID  == "Una1")
        {
            if (pVal.EventType == SAPbouiCOM.BoEventTypes.et_CLICK)
            {
                string val = null;
                if ((pVal.ItemUID == "Btn1") && (pVal.BeforeAction == false  ))
                {
                    try
                    {
                        SBO_Application.Forms.ActiveForm.Close();
                    }
                    catch (Exception ex)
                    {
                        throw (ex);
                    }
                }
            }
        }
    }
    private void SBO_Application_ItemEvent(string FormUID, ref SAPbouiCOM.ItemEvent pVal, out  bool BubbleEvent)
    {
        BubbleEvent = true;
        if (pVal.FormUID != this.UID)
            return;

        bool ret = true;

        try
        {
            FormClose(FormUID, pVal, ref BubbleEvent);
            btn_Click(FormUID, pVal);
 
        }
        catch (Exception ex)
        {
            oSAP.Message(ex.ToString());
            DealError(ex.Message);
        }
        BubbleEvent = ret;
    }

    private void FormClose(string FormUID, SAPbouiCOM.ItemEvent pVal, ref  bool BubbleEvent)
    {
        BubbleEvent = true;
        if (pVal.EventType == SAPbouiCOM.BoEventTypes.et_FORM_CLOSE)
        {
            SBO_Application.ItemEvent -= new SAPbouiCOM._IApplicationEvents_ItemEventEventHandler(SBO_Application_ItemEvent);
           
            oForm = null;
            oCompany = null;
            SBO_Application = null;
            oSAP = null;

        }
    }




    #endregion

    #region Deal Error
    ///<summary>
    ///處理例外錯誤。
    ///     </summary>
    ///<param name="ErrorMsg">錯誤訊息</param>
    public void DealError(string ErrorMsg)
    {
        DealError("C:\\\\Log\\\\" + this.SBO_Application.Company.UserName, ErrorMsg);
    }

    ///<summary>
    ///處理例外錯誤。
    ///     </summary>
    ///<param name="StartupPath">儲存的目錄位置</param>
    ///<param name="ErrorMsg">錯誤訊息</param>
    public void DealError(string StartupPath, string ErrorMsg)
    {
        string FileName = DateTime.Now.ToString("yyyyMMdd");
        string sPath = null;

        sPath = StartupPath;

        System.IO.DirectoryInfo oDir = new System.IO.DirectoryInfo(sPath);
        if (!oDir.Exists)
        {
            oDir.Create();
        }

        System.IO.StreamWriter sw = new System.IO.StreamWriter(sPath + "\\\\" + FileName + "-Log.txt", true, System.Text.Encoding.GetEncoding("Big5"));

        sw.WriteLine(DateTime.Now.ToString() + " -------------------");
        sw.WriteLine("AddOn Path：" + System.Windows.Forms.Application.ExecutablePath);
        sw.WriteLine(ErrorMsg);
        sw.WriteLine("The End -------------------");
        sw.Close();
    }
    #endregion

    private void formatSubGridColumn()
    {
   
        //oSubGrid.Columns.Item("子階項目號碼").Editable = true;
        //oSubGrid.Columns.Item("子階項目號碼").Type = SAPbouiCOM.BoGridColumnType.gct_EditText;
        //oEditCol = oSubGrid.Columns.Item("子階項目號碼");
        ////出現不允許執行此動作的錯誤訊息
        //oEditCol.LinkedObjectType = SAPbouiCOM.BoLinkedObject.lf_Items;

        //oEditCol = oSubGrid.Columns.Item("應發數量");
        //oEditCol.RightJustified = true;
        //oEditCol = oSubGrid.Columns.Item("已發數量");
        //oEditCol.RightJustified = true;
        //oEditCol = oSubGrid.Columns.Item("庫存數量");
        //oEditCol.RightJustified = true;
        //oEditCol = oSubGrid.Columns.Item("欠料數量");
        //oEditCol.RightJustified = true;

        //oSubGrid.Columns.Item("倉庫").Type = SAPbouiCOM.BoGridColumnType.gct_EditText;
        //oEditCol = oSubGrid.Columns.Item("倉庫");
        //oEditCol.RightJustified = true;
        //oEditCol.LinkedObjectType = SAPbouiCOM.BoLinkedObject.lf_Warehouses;

    }
}
