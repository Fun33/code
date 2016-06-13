using System;
using System.Collections.Generic;
using System.Text;

 //這裡放的,都要跟SAP_UI有關

//SBO_Application.Forms.GetForm("150", 1);
//SAPbouiCOM.Form _frm = SBO_Application.Forms.ActiveForm;
//SAPbouiCOM.Form _frm  =SBO_Application.Forms.GetFormByTypeAndCount(-150, Form150Count);
  public  class SAP_UI
    {
        public SAPbouiCOM.Application SBO_Application;
        public  SAPbobsCOM.Company oCompany;

      public Layout lay = new Layout(75,17 );

      int iRetCode;
      string sErrMsg;
      /// <summary>
      /// TADC_ExcelExNIm有在用.
      /// </summary>
      /// <param name="_appl"></param>
      /// <param name="_com"></param>
      public SAP_UI( )      
      { 
      }

      public SAP_UI(SAPbouiCOM.Application _appl,SAPbobsCOM.Company _com)
      {
          SBO_Application = _appl;
          oCompany = _com;
      }

        public void addUDF(string fldTable, string fldName, string fldDesc, SAPbobsCOM.BoFieldTypes sType, int sSize)
        {

            SAPbobsCOM.UserFieldsMD oUserFieldsMD = default(SAPbobsCOM.UserFieldsMD);
            try
            {
                oUserFieldsMD = (SAPbobsCOM.UserFieldsMD)oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oUserFields);

                oUserFieldsMD.TableName = fldTable;
                oUserFieldsMD.Name = fldName;
                oUserFieldsMD.Description = fldDesc;
                oUserFieldsMD.Type = sType;
                oUserFieldsMD.EditSize = sSize;

                iRetCode = oUserFieldsMD.Add();

                //// Check for errors
                if (iRetCode != 0)
                {
                    oCompany.GetLastError(out iRetCode, out sErrMsg);
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
        public SAPbouiCOM.Form SearchForm(string sType)
        {
            SAPbouiCOM.Form oForm;
            for (int i = 0; i <= SBO_Application.Forms.Count - 1; i++)
            {
                oForm = SBO_Application.Forms.Item(i);
                if (oForm.TypeEx == sType) return oForm;
            }
            return null;
        }
   

        #region add menu
      public  SAPbouiCOM.Menus AddMenu(string _UniID, string _text, string _location)
      {
          SBO_Application.StatusBar.SetText("Menu建立中....", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);

          SAPbouiCOM.MenuCreationParams oCreationPackage = null;
          oCreationPackage = ((SAPbouiCOM.MenuCreationParams)(SBO_Application.CreateObject(SAPbouiCOM.BoCreatableObjectType.cot_MenuCreationParams)));
          string sPath = null;

          //sPath = System.IO.Directory.GetParent(Application.StartupPath).ToString();
          //sPath = System.IO.Directory.GetParent(sPath).ToString() + "\\";

          oCreationPackage.Type = SAPbouiCOM.BoMenuType.mt_POPUP;
          oCreationPackage.UniqueID = _UniID;
          oCreationPackage.String = _text;
          oCreationPackage.Position = 0;
          try
          {
              SBO_Application.Menus.Item(_location).SubMenus.AddEx(oCreationPackage);
              SBO_Application.StatusBar.SetText("SDK:Menu建立完成....", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
          }
          catch (Exception ex)
          { //  Menu already exists
              SBO_Application.StatusBar.SetText("SDK:Menu已存在....", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
          }
          SAPbouiCOM.MenuItem oMenuItem = SBO_Application.Menus.Item(_UniID);
          SAPbouiCOM.Menus oMenus = oMenuItem.SubMenus;
          return oMenus;
      }

        //public void AddMenuItems(string _UniID, string _text, string sSubLocation )
        //{
        //    SBO_Application.StatusBar.SetText("Menu建立中....", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);

        //    SAPbouiCOM.MenuCreationParams oCreationPackage = null;
        //    oCreationPackage = ((SAPbouiCOM.MenuCreationParams)(SBO_Application.CreateObject(SAPbouiCOM.BoCreatableObjectType.cot_MenuCreationParams)));
        //    string sPath = null;

        //    //sPath = System.IO.Directory.GetParent(Application.StartupPath).ToString();
        //    //sPath = System.IO.Directory.GetParent(sPath).ToString() + "\\";

        //    oCreationPackage.Type = SAPbouiCOM.BoMenuType.mt_STRING;
        //    oCreationPackage.UniqueID = _UniID;
        //    oCreationPackage.String = _text;
        //    oCreationPackage.Position = 0;
        //    try
        //    {
        //        //SAPbouiCOM.MenuItem  oMenuItem = SBO_Application.Menus.Item(sSubLocation);

        //        SAPbouiCOM.MenuItem oMenuItem = SBO_Application.Menus.Item(sSubLocation);
        //        oMenuItem.SubMenus.AddEx(oCreationPackage);
        //        SBO_Application.StatusBar.SetText("SDK:Menu建立完成....", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
        //    }
        //    catch (Exception ex)
        //    { //  Menu already exists 
        //        SBO_Application.StatusBar.SetText("SDK:Menu已存在....", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
        //    }
        //}

        public void AddMenuItems(string _UniID, string _text, SAPbouiCOM.Menus oMenus )
        {
            SBO_Application.StatusBar.SetText("Menu建立中....", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);

            SAPbouiCOM.MenuCreationParams oCreationPackage = null;
            oCreationPackage = ((SAPbouiCOM.MenuCreationParams)(SBO_Application.CreateObject(SAPbouiCOM.BoCreatableObjectType.cot_MenuCreationParams)));
            string sPath = null;

            //sPath = System.IO.Directory.GetParent(Application.StartupPath).ToString();
            //sPath = System.IO.Directory.GetParent(sPath).ToString() + "\\";

            oCreationPackage.Type = SAPbouiCOM.BoMenuType.mt_STRING;
            oCreationPackage.UniqueID = _UniID;
            oCreationPackage.String = _text;
            oCreationPackage.Position = 0;
            try
            {
                oMenus.AddEx(oCreationPackage);
                SBO_Application.StatusBar.SetText("SDK:Menu建立完成....", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
            }
            catch (Exception ex)
            { //  Menu already exists
                SBO_Application.StatusBar.SetText("SDK:Menu已存在....", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
            }
        }
        #endregion 

        #region set item location in form
     

 
        public void setLocation(ref SAPbouiCOM.Item oItem, int x, int y)
        {
            oItem.Top = y * 20 + (y + 1) * 5;
            oItem.Left = x * 110 + (x + 1) * 5;
            oItem.Height = 20;
            oItem.Width = 110;
        }
        public void setLocation(ref SAPbouiCOM.Item oItem, int x, int y, int xPlus, int yPlus)
        {
            oItem.Top = y * 20 + (y + 1) * 5;
            oItem.Left = x * 110 + (x + 1) * 5;
            oItem.Height = 20 * yPlus;
            oItem.Width = 110 * xPlus;
        }
      public void setLocation(ref SAPbouiCOM.Item oItem, int x, int y, int width, int xPlus, int yPlus)
      {
          oItem.Top = y * 20 + (y + 1) * 5;
          oItem.Left = x * width + (x + 1) * 5;
          oItem.Height = 20 * yPlus;
          oItem.Width = width * xPlus;
      }
      public void setLocation(ref SAPbouiCOM.Item oItem, int x, int y,int width)
      {
          oItem.Top = y * 20 + (y + 1) * 5;
          oItem.Left = x * width + (x + 1) * 5;
          oItem.Height = 20;
          oItem.Width = width;
      }
        public void setLocation_Left(SAPbouiCOM.Form oForm, ref SAPbouiCOM.Item oItem, int x)
        {
            oItem.Top = oForm.Height - 25 - 50;
            oItem.Left = x * 100 + (x + 1) * 5;
            oItem.Height = 25;
            oItem.Width = 100;
        }

        public void setLocation_Right(SAPbouiCOM.Form oForm, ref SAPbouiCOM.Item oItem, int x)
        {
            oItem.Top = oForm.Height - 25 - 45;
            oItem.Left = oForm.Width - 100 - 30;
            oItem.Height = 25;
            oItem.Width = 100;
        }
        #endregion 

        #region set appl/com <2007
        public SAPbouiCOM.Application SetApplication()
        {
            SAPbouiCOM.SboGuiApi SboGuiApi = null;
            string sConnectionString = null;

            SboGuiApi = new SAPbouiCOM.SboGuiApi();

            sConnectionString = System.Convert.ToString(Environment.GetCommandLineArgs().GetValue(1));

            try
            {
                SboGuiApi.Connect(sConnectionString);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("SDK:No SAP Business One Application was found");
                System.Environment.Exit(0);
            }
            SBO_Application = SboGuiApi.GetApplication(-1); 

            return SBO_Application;
        }
        public SAPbobsCOM.Company SetCompany()
        {
            // //*************************************************************
            // // Set The Connection Context
            // //*************************************************************

            if (!(SetConnectionContext() == 0))
            {
                SBO_Application.MessageBox("SDK:Failed setting a connection to DI API", 1, "Ok", "", "");
                System.Environment.Exit(0); //  Terminating the Add-On Application
            }

            // //*************************************************************
            // // Connect To The Company Data Base
            // //*************************************************************

            if (!(ConnectToCompany() == 0))
            {
                SBO_Application.MessageBox("SDK:Failed connecting to the company's Data Base", 1, "Ok", "", "");
                System.Environment.Exit(0); //  Terminating the Add-On Application
            }
            return oCompany;
        }

        private int SetConnectionContext()
        {
            int setConnectionContextReturn = 0;

            string sCookie = null;
            string sConnectionContext = null;
            int lRetCode = 0;

            // // First initialize the Company object

            oCompany = new SAPbobsCOM.Company();

            // // Acquire the connection context cookie from the DI API.
            sCookie = oCompany.GetContextCookie();

            // // Retrieve the connection context string from the UI API using the
            // // acquired cookie.
            sConnectionContext = SBO_Application.Company.GetConnectionContext(sCookie);

            // // before setting the SBO Login Context make sure the company is not
            // // connected

            if (oCompany.Connected == true)
            {
                oCompany.Disconnect();
            }

            // // Set the connection context information to the DI API.
            setConnectionContextReturn = oCompany.SetSboLoginContext(sConnectionContext);

            return setConnectionContextReturn;
        }
        private int ConnectToCompany()
        {
            int connectToCompanyReturn = 0;

            // // Establish the connection to the company database.
            connectToCompanyReturn = oCompany.Connect();

            return connectToCompanyReturn;
        }
        #endregion 

        #region set appl/com >2007
        //private void SetApplication()
        //{
        //    try
        //    {
        //        SAPbouiCOM.SboGuiApi SboGuiApi = null;
        //        string sConnectionString = null;

        //        SboGuiApi = new SAPbouiCOM.SboGuiApi();

        //        //sConnectionString = Interaction.Command();
        //        sConnectionString = "0030002C0030002C00530041005000420044005F00440061007400650076002C0050004C006F006D0056004900490056";// Environment.GetCommandLineArgs().GetValue(1).ToString();
        //        SboGuiApi.Connect(sConnectionString);

        //        SBO_Application = SboGuiApi.GetApplication(-1);
        //        //oCompany = (SAPbobsCOM.Company)SBO_Application.Company.GetDICompany();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //}
        #endregion

        #region func 
        //grid readonly
        public void setGridReadonly(ref SAPbouiCOM.Grid _oGrid)
        {
            for (int j = 0; j <= _oGrid.Columns.Count - 1; j++)
            {
                _oGrid.Columns.Item(j).Editable = false;
            }
        }

      public void Message(string msg)
      {
          SBO_Application.MessageBox("SDK:" + msg, 1, "", "", "");
          func.log(msg);
      }
      //public void SetStatusBarMsg(string msg)
      //  {
      //      SBO_Application.SetStatusBarMessage("SDK:" + msg, SAPbouiCOM.BoMessageTime.bmt_Short, false);
      //      func.log(msg);
      //  }
        public void setStatusBar(string _msg)
        {
            SBO_Application.StatusBar.SetText("SDK : " + _msg, SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_None);
            func.log(_msg);
        }
        public void setStatusBar(string _msg, SAPbouiCOM.BoStatusBarMessageType _type)
        {
            SBO_Application.StatusBar.SetText("SDK : " + _msg, SAPbouiCOM.BoMessageTime.bmt_Short, _type);
            func.log(_msg);
        }
        public void setStatusBar(string _msg, SAPbouiCOM.BoMessageTime _time, SAPbouiCOM.BoStatusBarMessageType _type)
        {
            SBO_Application.StatusBar.SetText("SDK : " + _msg, _time, _type);
            func.log(_msg);
        }
        #endregion 

        #region cfl
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
        //                    AddChooseFromListFliter(ref _frm);
        //                    AddBtn(ref _frm);
        //                }
        //            }
        //        }
        //    }
        //}
        //private void AddChooseFromListFliter(ref SAPbouiCOM.Form oForm)
        //{
        //    try
        //    {

        //        SAPbouiCOM.ChooseFromListCollection oCFLs = null;
        //        SAPbouiCOM.Conditions oCons = null;
        //        SAPbouiCOM.Condition oCon = null;

        //        oCFLs = oForm.ChooseFromLists;

        //        SAPbouiCOM.ChooseFromList oCFL = null;
        //        SAPbouiCOM.ChooseFromListCreationParams oCFLCreationParams = null;
        //        oCFLCreationParams = ((SAPbouiCOM.ChooseFromListCreationParams)(SBO_Application.CreateObject(SAPbouiCOM.BoCreatableObjectType.cot_ChooseFromListCreationParams)));

        //        //  Adding 2 CFL, one for the button and one for the edit text.
        //        oCFLCreationParams.MultiSelection = false;
        //        oCFLCreationParams.ObjectType = "2";
        //        oCFLCreationParams.UniqueID = "CFL1";

        //        oCFL = oCFLs.Add(oCFLCreationParams);

        //        //  Adding Conditions to CFL1

        //        oCons = oCFL.GetConditions();

        //        oCon = oCons.Add();
        //        oCon.Alias = "CardType";
        //        oCon.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
        //        oCon.CondVal = "C";
        //        oCFL.SetConditions(oCons);
        //    }
        //    catch
        //    {
        //        Interaction.MsgBox(Information.Err().Description, (Microsoft.VisualBasic.MsgBoxStyle)(0), null);
        //    }
        //}
        //private void AddBtn(ref SAPbouiCOM.Form oForm)
        //{
        //    SAPbouiCOM.FormCreationParams oCP = null;
        //    SAPbouiCOM.Item oItem = null;
        //    SAPbouiCOM.StaticText oStatic = null;
        //    SAPbouiCOM.Button oButton = null;
        //    SAPbouiCOM.EditText oEdit = null;
        //    try
        //    {

        //        oItem = oForm.Items.Add("BtnUna", SAPbouiCOM.BoFormItemTypes.it_BUTTON);

        //        oItem.Left = oForm.Items.Item("4").Left + oForm.Items.Item("4").Width;
        //        oItem.Top = oForm.Items.Item("4").Top;
        //        oButton = ((SAPbouiCOM.Button)(oItem.Specific));
        //        oButton.Type = SAPbouiCOM.BoButtonTypes.bt_Image;
        //        oItem.Width = 20;
        //        oItem.Height = 20;
        //        oButton.Image = System.IO.Directory.GetParent(System.IO.Directory.GetParent(System.Windows.Forms.Application.StartupPath).ToString())) + @"\CFL.BMP";

        //        oButton.ChooseFromListUID = "CFL1";
        //    }
        //    catch (Exception ex)
        //    {
        //        Message(ex.ToString());
        //    }
        //}
        //private void btn_Click(string FormUID, SAPbouiCOM.ItemEvent pVal)
        //{
        //    if (pVal.FormTypeEx == "139")
        //    {
        //        if (pVal.EventType == SAPbouiCOM.BoEventTypes.et_CHOOSE_FROM_LIST)
        //        {
        //            SAPbouiCOM.IChooseFromListEvent oCFLEvento = ((SAPbouiCOM.IChooseFromListEvent)(pVal));
        //            string sCFL_ID = oCFLEvento.ChooseFromListUID;
        //            SAPbouiCOM.Form oForm = SBO_Application.Forms.Item(FormUID);
        //            SAPbouiCOM.ChooseFromList oCFL = oForm.ChooseFromLists.Item(sCFL_ID);

        //            if (oCFLEvento.BeforeAction == false)
        //            {
        //                SAPbouiCOM.DataTable oDataTable = oCFLEvento.SelectedObjects;
        //                string val = null;
        //                try
        //                {
        //                    val = System.Convert.ToString(oDataTable.GetValue(0, 0));
        //                }
        //                catch (Exception ex) { }
        //                if (pVal.ItemUID == "BtnUna")
        //                {
        //                    try
        //                    {
        //                        ((SAPbouiCOM.EditText)oForm.Items.Item("4").Specific).Value = val;
        //                    }
        //                    catch (Exception ex)
        //                    { }
        //                }
        //            }
        //        }
        //    }
        //}
        #endregion

        #region addon setup read me
        //ExtraFiles = New String() {"SDK_U_Helper.dll"}
        //  ExtraDirectories = New String() {""}
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


        #region myDeal Error bak
        /////<summary>
        /////處理例外錯誤。
        /////     </summary>
        /////<param name="ErrorMsg">錯誤訊息</param>
        //public void DealError(string ErrorMsg)
        //{
        //    DealError("C:\\\\Log\\\\" + this.SBO_Application.Company.UserName, ErrorMsg);
        //}

        /////<summary>
        /////處理例外錯誤。
        /////     </summary>
        /////<param name="StartupPath">儲存的目錄位置</param>
        /////<param name="ErrorMsg">錯誤訊息</param>
        //public void DealError(string StartupPath, string ErrorMsg)
        //{
        //    string FileName = DateTime.Now.ToString("yyyyMMdd");
        //    string sPath = null;

        //    sPath = StartupPath;

        //    System.IO.DirectoryInfo oDir = new System.IO.DirectoryInfo(sPath);
        //    if (!oDir.Exists)
        //    {
        //        oDir.Create();
        //    }

        //    System.IO.StreamWriter sw = new System.IO.StreamWriter(sPath + "\\\\" + FileName + "-Log.txt", true, System.Text.Encoding.GetEncoding("Big5"));

        //    sw.WriteLine(DateTime.Now.ToString() + " --" + ErrorMsg);

        //    //sw.WriteLine(DateTime.Now.ToString() + " -------------------");
        //    //sw.WriteLine("AddOn Path：" + System.Windows.Forms.Application.ExecutablePath);
        //    //sw.WriteLine(ErrorMsg);
        //    //sw.WriteLine("The End -------------------");
        //    sw.Close();
        //}
        #endregion


      //public  static void LoadCBOData(string cmd, ref SDK_HelperC.Controls.ComboBox CBO)
      //{
      //    oDT.Clear();
      //    while (CBO.ValidValues.Count > 0)
      //    {
      //        CBO.ValidValues.Remove(0, SAPbouiCOM.BoSearchKey.psk_Index);
      //    }
      //    func_DI.DoQueryDT(cmd, ref oDT);
      //    if (oDT.IsEmpty == false)
      //    {
      //        for (int i = 0; i < oDT.Rows.Count; i++)
      //        {
      //            CBO.ValidValues.Add(oDT.GetValue("Code", i).ToString(), oDT.GetValue("Name", i).ToString());
      //        }
      //    }
      //    CBO.Select(0, SAPbouiCOM.BoSearchKey.psk_Index);
      //}


      #region 共用.control.
      //private void LoadCBOData(string cmd, ref SDK_HelperC.Controls.ComboBox CBO)
      //{
      //    oDT.Clear();
      //    while (CBO.ValidValues.Count > 0)
      //    {
      //        CBO.ValidValues.Remove(0, SAPbouiCOM.BoSearchKey.psk_Index);
      //    }
      //    func_DI.DoQueryDT(cmd, ref oDT);
      //    if (oDT.IsEmpty == false)
      //    {
      //        for (int i = 0; i < oDT.Rows.Count; i++)
      //        {
      //            CBO.ValidValues.Add(oDT.GetValue("Code", i).ToString(), oDT.GetValue("Name", i).ToString());
      //        }
      //        CBO.Select(0, SAPbouiCOM.BoSearchKey.psk_Index);
      //    }
      //}
      #endregion
    }
 
