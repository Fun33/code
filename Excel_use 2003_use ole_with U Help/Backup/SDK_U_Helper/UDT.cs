//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace SDK_U_Helper
//{
//    public class UDT
//    {
//        #region add udt
//        private bool AddRecord_ItemWOC(string s, SAPbobsCOM.Items oItm, Setting_ITEM_WOC oSet)
//        {
//            bool ret = false;

//            string sTable = "[@ITEM_WOC]";
//            DelUDT(oItm, sTable);

//            System.Data.DataTable oDT = getXLSDT(s, oSet.tTable);//@ITEM_WOC
//            for (int i = 0; i < oDT.Rows.Count; i++)
//            {
//                SAPbobsCOM.UserTable otable = oCompany.UserTables.Item(sTable);
//                otable.UserFields.Fields.Item("U_ItemCode").Value = oItm.ItemCode;
//                otable.UserFields.Fields.Item("U_LineNo").Value = (i + 1).ToString();

//                otable.UserFields.Fields.Item("U_Content").Value = oDT.Rows[i][oSet.U_Content];
//                otable.UserFields.Fields.Item("U_Weight").Value = oDT.Rows[i][oSet.U_Weight];
//                otable.UserFields.Fields.Item("U_Weight_Unit").Value = oDT.Rows[i][oSet.U_Weight_Unit];
//                iRetCode = otable.Add();
//                if (iRetCode != 0)
//                {
//                    if (oCompany.InTransaction)
//                        oCompany.EndTransaction(SAPbobsCOM.BoWfTransOpt.wf_RollBack);

//                    oCompany.GetLastError(out iRetCode, out sErrMsg);

//                    string msg = "{0}第{1}列，{2}匯入失敗!!{3}";
//                    msg = string.Format(msg, oItm.ItemCode.ToString(), i.ToString(), oSet.tTable, sErrMsg);
//                    MessageBox(msg);

//                    return false;
//                }
//                else
//                {
//                    string msg = "{0}第{1}列，{2}匯入成功!!";
//                    msg = string.Format(msg, oItm.ItemCode.ToString(), i.ToString(), oSet.tTable);
//                    setStatusBar(msg);
//                    ret = true;
//                }
//            }
//            return ret;
//        }

//        private bool AddRecord_ITEM_Packing(string s, SAPbobsCOM.Items oItm, Setting_ITEM_Packing oSet)
//        {
//            string sTable = "[@ITEM_Packing]";
//            bool ret = false;
//            DelUDT(oItm, sTable);
//            System.Data.DataTable oDT = getXLSDT(s, oSet.tTable);//@ITEM_Packing
//            for (int i = 0; i < oDT.Rows.Count; i++)
//            {
//                SAPbobsCOM.UserTable otable = oCompany.UserTables.Item(sTable);

//                otable.UserFields.Fields.Item("U_ItemCode").Value = oItm.ItemCode;
//                otable.UserFields.Fields.Item("U_LineNo").Value = (i + 1).ToString();

//                otable.UserFields.Fields.Item("U_Content").Value = oDT.Rows[i][oSet.U_Content];
//                otable.UserFields.Fields.Item("U_Spec").Value = oDT.Rows[i][oSet.U_SPEC];
//                iRetCode = otable.Add();
//                if (iRetCode != 0)
//                {
//                    if (oCompany.InTransaction)
//                        oCompany.EndTransaction(SAPbobsCOM.BoWfTransOpt.wf_RollBack);

//                    oCompany.GetLastError(out iRetCode, out sErrMsg);

//                    string msg = "{0}第{1}列，{2}匯入失敗!!{3}";
//                    msg = string.Format(msg, oItm.ItemCode.ToString(), i.ToString(), oSet.tTable, sErrMsg);
//                    MessageBox(msg);

//                    return false;
//                }
//                else
//                {
//                    string msg = "{0}第{1}列，{2}匯入成功!!";
//                    msg = string.Format(msg, oItm.ItemCode.ToString(), i.ToString(), oSet.tTable);
//                    setStatusBar(msg);
//                    ret = true;
//                }
//            }
//            return ret;
//        }

//        private bool AddRecord_ITEM_Detect(string s, SAPbobsCOM.Items oItm, Setting_ITEM_Detect oSet)
//        {
//            string sTable = "[@ITEM_Detect]";
//            bool ret = false;
//            DelUDT(oItm, sTable);

//            System.Data.DataTable oDT = getXLSDT(s, oSet.tTable);//@ITEM_Detect
//            for (int i = 0; i < oDT.Rows.Count; i++)
//            {
//                SAPbobsCOM.UserTable otable = oCompany.UserTables.Item(sTable);

//                otable.UserFields.Fields.Item("U_ItemCode").Value = oItm.ItemCode;
//                otable.UserFields.Fields.Item("U_LineNo").Value = (i + 1).ToString();

//                otable.UserFields.Fields.Item("U_Content").Value = oDT.Rows[i][oSet.U_Content];
//                otable.UserFields.Fields.Item("U_Standard").Value = oDT.Rows[i][oSet.U_Standard];
//                otable.UserFields.Fields.Item("U_Microbe").Value = oDT.Rows[i][oSet.U_Microbe];
//                otable.UserFields.Fields.Item("U_MicroStandard").Value = oDT.Rows[i][oSet.U_MicroStandard];
//                otable.UserFields.Fields.Item("U_Sense").Value = oDT.Rows[i][oSet.U_Sense];
//                otable.UserFields.Fields.Item("U_SenseStandard").Value = oDT.Rows[i][oSet.U_SenseStandard];
//                otable.UserFields.Fields.Item("U_Add").Value = oDT.Rows[i][oSet.U_Add];
//                otable.UserFields.Fields.Item("U_AddStandard").Value = oDT.Rows[i][oSet.U_AddStandard];

//                iRetCode = otable.Add();
//                if (iRetCode != 0)
//                {
//                    if (oCompany.InTransaction)
//                        oCompany.EndTransaction(SAPbobsCOM.BoWfTransOpt.wf_RollBack);

//                    oCompany.GetLastError(out iRetCode, out sErrMsg);

//                    string msg = "{0}第{1}列，{2}匯入失敗!!{3}";
//                    msg = string.Format(msg, oItm.ItemCode.ToString(), i.ToString(), oSet.tTable, sErrMsg);
//                    MessageBox(msg);

//                    return false;
//                }
//                else
//                {
//                    string msg = "{0}第{1}列，{2}匯入成功!!";
//                    msg = string.Format(msg, oItm.ItemCode.ToString(), i.ToString(), oSet.tTable);
//                    setStatusBar(msg);
//                    ret = true;
//                }
//            }
//            return ret;
//        }
//        #endregion
//    }
//}
