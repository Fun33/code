using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

 
	class f17c
	{
 private string        FUID ="f17";

        SAPbouiCOM.Form f17;
        SAPbouiCOM.Grid G1;
        SAPbouiCOM.EditText txCardCode, txEntry, txDate;
        SAPbouiCOM.ComboBox cbWH;
        SAPbouiCOM.Button btnSel;
        SAPbouiCOM.DataTable oDT;
        SAPbouiCOM.DataTable oDTtmp;
        SAPbouiCOM.ChooseFromList oCust;
        SAPbouiCOM.ChooseFromList o17DocEntry;


        public f17c()
        {
            try
            {
                SubMain.SBO_Application.ItemEvent += new SAPbouiCOM._IApplicationEvents_ItemEventEventHandler(SBO_ItemEvent);
                SubMain.LoadXML("f17.xml");

                GetControl();
                ItemLoad();
            }
            catch (Exception ex)
            {
                SubMain.MessageBox(ex.Message   );
            }
        }

        #region itemload
        private void GetControl()
        {
            f17 = SubMain.SBO_Application.Forms.ActiveForm;
            G1 = (SAPbouiCOM.Grid)f17.Items.Item("9").Specific;

            txCardCode = (SAPbouiCOM.EditText)f17.Items.Item("txCardCode").Specific;
            txEntry = (SAPbouiCOM.EditText)f17.Items.Item("txEntry").Specific;
            txDate = (SAPbouiCOM.EditText)f17.Items.Item("1000001").Specific;
           
            cbWH = (SAPbouiCOM.ComboBox)f17.Items.Item("6").Specific;
            btnSel = (SAPbouiCOM.Button)f17.Items.Item("10").Specific;
            oDT = G1.DataTable;
            oDTtmp = f17.DataSources.DataTables.Add("DT_TMP");
        }
        private void ItemLoad()
        {
            //1.¬Ýsample 
            SubMain.AddChooseFromList(f17, "2", "cfl2", "CardType", "C");
            SubMain.AddChooseFromList(f17, "17", "cfl17", "", "");

            //define ds
            f17.DataSources.UserDataSources.Add("txCardCode", SAPbouiCOM.BoDataType.dt_SHORT_TEXT, 254);
            f17.DataSources.UserDataSources.Add("txEntry", SAPbouiCOM.BoDataType.dt_SHORT_TEXT, 254);
            f17.DataSources.UserDataSources.Add("txDate", SAPbouiCOM.BoDataType.dt_DATE, 254); 
            
            //bind ds
            txCardCode.DataBind.SetBound(true, "", "txCardCode");
            txEntry.DataBind.SetBound(true, "", "txEntry");
            txDate.DataBind.SetBound(true, "", "txDate");

                        txCardCode.ChooseFromListUID = "cfl2";
                        txCardCode.ChooseFromListAlias = "CardCode";

                        txEntry.ChooseFromListUID = "cfl17";
                        txEntry.ChooseFromListAlias = "DocEntry";

                        oDTtmp.ExecuteQuery("select WhsCode,WhsName from owhs");
                        for (int i = 0; i < oDTtmp.Rows.Count; i++)
                        {
                            cbWH.ValidValues.Add(oDTtmp.GetValue(0,i).ToString(),oDTtmp.GetValue(1,i).ToString());
                        } 
           
                // 
                
    
        }
        private void InitGridCol()
        {
           SubMain.SetGridLinkCol  (G1, "DocEntry", "17");
           SubMain.SetGridLinkCol(G1, "ItemCode", "4");
        }
      
      #endregion 

        #region Event
        public void SBO_ItemEvent(string FormUID, ref SAPbouiCOM. ItemEvent pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            
            //cfl
            SubMain.GetCFL_EDIT(FormUID, ref pVal, out BubbleEvent, "txCardCode", "cfl2");
            SubMain.GetCFL_EDIT(FormUID, ref pVal, out BubbleEvent, "txEntry", "cfl17");


            if (pVal.Before_Action == false) return;
        
            try
            {
                if (FormUID == FUID)
                {
                    if (pVal.ItemUID == "10" )
                    {
                        if (pVal.EventType == SAPbouiCOM.BoEventTypes.et_CLICK)
                        {
                            try
                            {
                                f17.Freeze(true);
                                string cmd = GetCmd();                                
                                oDT.ExecuteQuery(cmd);
                                InitGridCol();
                            }
                            catch (Exception ex)
                            {

                            }
                            finally
                            {
                                f17.Freeze(false);
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                SubMain.SBO_Application.MessageBox(ex.Message , 1, "Ok", "", "");
            }

        }
        #endregion
        private string GetCmd()
        {
            string cmd = "select top 10 * from rdr1 inner join ORDR on ORDR.Docentry=RDR1.DocEntry where 1=1 ";
            string where ="";
            if (txCardCode.Value != "")
            {
                where += "and CardCode='{0}'";
                where = string.Format(where,txCardCode.Value);
            }
            if (txEntry.Value != "")
            {
                where += "and  RDR1.DocEntry='{0}'";
                where = string.Format(where, txEntry.Value);
            }
            if (cbWH.Selected  != null)
            {
                where += "and RDR1.WhsCode='{0}'";
                where = string.Format(where, cbWH.Selected. Value);
            }
            cmd = cmd + where;
            System.Diagnostics.Debug.WriteLine(cmd);
            return cmd;
            
        }
    }
 

