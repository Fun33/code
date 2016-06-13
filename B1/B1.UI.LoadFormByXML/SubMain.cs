//  SAP MANAGE UI API 2007 SDK Sample
//****************************************************************************
//
//  File:      SubMain.cs
//
//  Copyright (c) SAP MANAGE
//
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
//****************************************************************************

using System;
using System.Windows.Forms;
using System.Xml;


public class SubMain 
{

    public static SAPbouiCOM.SboGuiApi SboGuiApi;
    public static SAPbouiCOM.Application SBO_Application;
    public static SAPbobsCOM.Company oCompany;

    static void Main()
    {

        Menu oMenu = null;

        oMenu = new Menu();
        System.Windows.Forms.Application.Run(); //如果沒有這行,程式做完會停掉.

    }

    public static void LoadXML(string fileName)
    {
        //@"e:\bp.srf"
        try
        {
            XmlDocument oDoc = new XmlDocument();

            string path = Application.StartupPath;
            path = System.IO.Path.Combine(path, "XML_Init");
            path = System.IO.Path.Combine(path, fileName);
            oDoc.Load(path);

            string tmp = oDoc.InnerXml;
            SubMain.SBO_Application.LoadBatchActions(ref tmp);
            path = SBO_Application.GetLastBatchResults();
          
        }
        catch (Exception ex)
        {
            SubMain.MessageBox(ex.Message );
        }
    }
    public static void  MessageBox (string msg)
    {
        SBO_Application.MessageBox(msg, 1, "", "", "");
    }

    public static SAPbouiCOM.EditTextColumn SetGridLinkCol(SAPbouiCOM.Grid oGrid, string FiledName, string LinkedObjectType)
    {
        SAPbouiCOM.EditTextColumn myCol;
        oGrid.Columns.Item(FiledName).Type = SAPbouiCOM.BoGridColumnType.gct_EditText;
        myCol = (SAPbouiCOM.EditTextColumn)oGrid.Columns.Item(FiledName);
        //myCol.ForeColor =  
        myCol.Editable = false;
        myCol.LinkedObjectType = System.Convert.ToInt32(LinkedObjectType).ToString();
        return myCol;
    }
     

    #region CFL
    public static void GetCFL_EDIT(string FormUID, ref SAPbouiCOM.ItemEvent pVal, out bool BubbleEvent  ,string  UDSID, string CFLID)
    {
        BubbleEvent = true;
        if (pVal.EventType == SAPbouiCOM.BoEventTypes.et_CHOOSE_FROM_LIST)
        {
            SAPbouiCOM.IChooseFromListEvent oCFLEvento = null;
            oCFLEvento = ((SAPbouiCOM.IChooseFromListEvent)(pVal));
            string sCFL_ID = null;
            sCFL_ID = oCFLEvento.ChooseFromListUID;
            SAPbouiCOM.Form oForm = null;
            oForm = SBO_Application.Forms.Item(FormUID);
            SAPbouiCOM.ChooseFromList oCFL = null;
            oCFL = oForm.ChooseFromLists.Item(sCFL_ID);
            if (oCFLEvento.BeforeAction == false)
            {
                SAPbouiCOM.DataTable oDataTable = null;
                oDataTable = oCFLEvento.SelectedObjects;
                string val = null;
                try
                {
                    val = System.Convert.ToString(oDataTable.GetValue(0, 0));
                }
                catch (Exception ex)
                {

                }
                try
                {
                    if (pVal.ItemUID == UDSID)
                    {
                        oForm.DataSources.UserDataSources.Item(UDSID).ValueEx = val;
                    }
                }
                catch (Exception ex)
                {
                    SubMain.MessageBox(ex.Message);
                }

            }
        }

        if ((FormUID == CFLID) & (pVal.EventType == SAPbouiCOM.BoEventTypes.et_FORM_UNLOAD))
        {
            System.Windows.Forms.Application.Exit();
        }

    }
    public static string  GetCFL_value(string FormUID, ref SAPbouiCOM.ItemEvent pVal, out bool BubbleEvent, string ItemUID,string CFLID)
    {
        string ret = "";
        BubbleEvent = true;
        if (pVal.EventType == SAPbouiCOM.BoEventTypes.et_CHOOSE_FROM_LIST)
        {
            SAPbouiCOM.IChooseFromListEvent oCFLEvento = null;
            oCFLEvento = ((SAPbouiCOM.IChooseFromListEvent)(pVal));
            string sCFL_ID = null;
            sCFL_ID = oCFLEvento.ChooseFromListUID;
            SAPbouiCOM.Form oForm = null;
            oForm = SBO_Application.Forms.Item(FormUID);
            SAPbouiCOM.ChooseFromList oCFL = null;
            oCFL = oForm.ChooseFromLists.Item(sCFL_ID);
            if (oCFLEvento.BeforeAction == false)
            {
                SAPbouiCOM.DataTable oDataTable = null;
                oDataTable = oCFLEvento.SelectedObjects;
                string val = null;
                try
                {
                    val = System.Convert.ToString(oDataTable.GetValue(0, 0));
                }
                catch (Exception ex)
                {

                }
                try
                {
                    if (pVal.ItemUID == ItemUID)
                    {
                       ret = val;
                    }
                }
                catch (Exception ex)
                {
                    SubMain.MessageBox(ex.Message);
                }

            }
        }

        if ((FormUID == CFLID) & (pVal.EventType == SAPbouiCOM.BoEventTypes.et_FORM_UNLOAD))
        {
            System.Windows.Forms.Application.Exit();
        }
        return ret;
    }
    public static void AddChooseFromList(SAPbouiCOM.Form frm, string ObjectType, string ParamsID, string ConAlias, string CondVal)
    {
        try
        {

            SAPbouiCOM.ChooseFromListCollection oCFLs = null;
            SAPbouiCOM.Conditions oCons = null;
            SAPbouiCOM.Condition oCon = null;

            oCFLs = frm.ChooseFromLists;

            SAPbouiCOM.ChooseFromList oCFL = null;
            SAPbouiCOM.ChooseFromListCreationParams oCFLCreationParams = null;
            oCFLCreationParams = ((SAPbouiCOM.ChooseFromListCreationParams)(SubMain.SBO_Application.CreateObject(SAPbouiCOM.BoCreatableObjectType.cot_ChooseFromListCreationParams)));

            //  Adding 2 CFL, one for the button and one for the edit text.
            oCFLCreationParams.MultiSelection = false;
            oCFLCreationParams.ObjectType = ObjectType;
            oCFLCreationParams.UniqueID = ParamsID;

            oCFL = oCFLs.Add(oCFLCreationParams);

            //  Adding Conditions to CFL1
            if (ConAlias != "")
            {
                oCons = oCFL.GetConditions();

                oCon = oCons.Add();
                oCon.Alias = ConAlias;
                oCon.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                oCon.CondVal = CondVal;
                oCFL.SetConditions(oCons);
            }
            //oCFLCreationParams.UniqueID = "CFL2";
            //oCust = oCFLs.Add(oCFLCreationParams);

        }
        catch (Exception ex)
        {

        }
    }
    #endregion 


    
} 
    
