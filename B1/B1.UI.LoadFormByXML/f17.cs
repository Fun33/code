using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

 
	class f17
	{

        SAPbouiCOM.Form f;
        SAPbouiCOM.Button BtnAddLine;
        SAPbouiCOM.Matrix m1;

        public f17()
        {
            try
            {
                SubMain.SBO_Application.ItemEvent += new SAPbouiCOM._IApplicationEvents_ItemEventEventHandler(SBO_ItemEvnt);
               SubMain.LoadXML("f17.xml");
 
            }
            catch (Exception ex)
            {
                SubMain.MessageBox(ex.Message   );
            }

            GetControl();
            Load();
        }
        public void GetControl()
        { 
            f = SubMain.SBO_Application.Forms.ActiveForm;
            BtnAddLine = (SAPbouiCOM.Button) f.Items.Item("add").Specific ;
            m1 = (SAPbouiCOM.Matrix) f.Items.Item("m1").Specific;
        }
        public void Load()
        {
            m1.SelectionMode = SAPbouiCOM.BoMatrixSelect.ms_Single;
        }
        private  void SBO_ItemEvnt(string FormUID, ref SAPbouiCOM. ItemEvent pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            try
            {
        
                GetCFL_EDIT(FormUID, ref pVal, out BubbleEvent, "CardCode", "2");//f.item(UID);;f.item.col.row
                GetCFL_M1_EDIT(FormUID, ref pVal, out BubbleEvent, "m1", "4");
                if (pVal.Before_Action == false)
                {
                    if (pVal.ItemUID == "del")
                    {
                        if (pVal.EventType == SAPbouiCOM.BoEventTypes.et_CLICK)
                        {
                            int i = m1.GetNextSelectedRow(0, SAPbouiCOM.BoOrderType.ot_RowOrder);
                            if (i > 0)
                            {
                                m1.DeleteRow(i);
                            }
                            else
                            {
                                SubMain.MessageBox("½Ð¿ï¨ú");
                            }
                        }
                    }
                    else if (pVal.ItemUID == "add")
                        if (pVal.EventType == SAPbouiCOM.BoEventTypes.et_CLICK)
                        {
                            //http://scn.sap.com/thread/23469
                            //f.DataSources.DataTables.Item("RDR1").Rows.Add(1);
                            //m1.AddRow(1,m1.RowCount);
                            //f.DataSources.DBDataSources.Item(1).Clear();
                            m1.AddRow(1, m1.RowCount);
                            //((SAPbouiCOM.EditText)m1.Columns.Item(1).Cells.Item(1).Specific).Value = "0003013021000";

                        }
                }
            }
            catch (Exception ex)
            {
                SubMain.MessageBox(ex.Message );
            }
        }
        public   void GetCFL_M1_EDIT(string FormUID, ref SAPbouiCOM.ItemEvent pVal, out bool BubbleEvent, string UDSID, string CFLID)
        {
            BubbleEvent = true;
            if (pVal.EventType == SAPbouiCOM.BoEventTypes.et_CHOOSE_FROM_LIST)
            {
                SAPbouiCOM.IChooseFromListEvent oCFLEvento = null;
                oCFLEvento = ((SAPbouiCOM.IChooseFromListEvent)(pVal));
                string sCFL_ID = null;
                sCFL_ID = oCFLEvento.ChooseFromListUID;
                SAPbouiCOM.Form oForm = null;
                oForm =  SubMain. SBO_Application.Forms.Item(FormUID);
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
                            if (CFLID == "4")
                            { 
                                
                                ((SAPbouiCOM.EditText)m1.Columns.Item(pVal.ColUID).Cells.Item(pVal.Row).Specific).String = val;
                            }
                          
                           
                        }
                    }
                    catch (Exception ex)
                    {
                        //SubMain.MessageBox(ex.Message);
                    }

                }
            }

            if ((FormUID == CFLID) & (pVal.EventType == SAPbouiCOM.BoEventTypes.et_FORM_UNLOAD))
            {
                System.Windows.Forms.Application.Exit();
            }

        }
        public void GetCFL_EDIT(string FormUID, ref SAPbouiCOM.ItemEvent pVal, out bool BubbleEvent, string UDSID, string CFLID)
        {
            BubbleEvent = true;
            if (pVal.EventType == SAPbouiCOM.BoEventTypes.et_CHOOSE_FROM_LIST)
            {
                SAPbouiCOM.IChooseFromListEvent oCFLEvento = null;
                oCFLEvento = ((SAPbouiCOM.IChooseFromListEvent)(pVal));
                string sCFL_ID = null;
                sCFL_ID = oCFLEvento.ChooseFromListUID;
                SAPbouiCOM.Form oForm = null;
                oForm = SubMain.SBO_Application.Forms.Item(FormUID);
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
                            if (CFLID == "2")
                            {

                                ((SAPbouiCOM.EditText)f.Items.Item("CardCode").Specific).Value = val;
                            }


                        }
                    }
                    catch (Exception ex)
                    {
                        //SubMain.MessageBox(ex.Message);
                    }

                }
            }

            if ((FormUID == CFLID) & (pVal.EventType == SAPbouiCOM.BoEventTypes.et_FORM_UNLOAD))
            {
                System.Windows.Forms.Application.Exit();
            }

        }
   
    }
 

