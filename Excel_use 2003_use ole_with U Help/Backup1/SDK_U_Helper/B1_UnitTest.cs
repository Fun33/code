using System;
using System.Collections.Generic;
using System.Text;

  
  public   class UnitTest
    {
        private SAPbouiCOM.Application SBO_Application;
        private SAPbobsCOM.Company oCompany;

        private int iRetCode;
        private string sErrMsg;

        public UnitTest(SAPbouiCOM.Application _app, SAPbobsCOM.Company _com)
        {
            SBO_Application = _app;
            oCompany = _com;
        }
      public void editPrice(string sItemCode, string sPriceListName, int iPrice)
      {
          try
          {
              SAPbobsCOM.Items oItm = (SAPbobsCOM.Items)oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oItems);
              if (oItm.GetByKey(sItemCode))
              {
                  for (int i = 0; i < oItm.PriceList.Count - 1; i++)
                  {
                      oItm.PriceList.SetCurrentLine(i);
                      if (oItm.PriceList.PriceListName == sPriceListName)//"基础价格"
                      {
                          oItm.PriceList.Price = iPrice;
                          if (oItm.Update() != 0)
                          {
                              oCompany.GetLastError(out this.iRetCode, out sErrMsg);
                              throw new Exception(iRetCode.ToString() + sErrMsg);
                          }
                          else
                          MessageBox("OK");
                          return;
                      }
                  }
              }
          }
          catch (Exception ex)
          {
              MessageBox(ex.ToString());
              DealError(ex.ToString());
          }
      }
      //public void editPrice(string sItemCode, int iPriceListNum, int iPrice)
      //{
      //    SAPbobsCOM.Items oItm = (SAPbobsCOM.Items)oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oItems);
      //    if (oItm.GetByKey(sItemCode))
      //    {
      //        SAPbobsCOM.Items_Prices oItemPrice = oItm.PriceList;
      //        oItemPrice.SetCurrentLine(iPriceListNum);
              
      //        oItemPrice.Price = iPrice;
      //        if (oItm.Update() != 0)
      //        {
      //            oCompany.GetLastError(out this.iRetCode, out sErrMsg);
      //            throw new Exception(iRetCode.ToString() + sErrMsg);
      //        }
      //    }
      //    else
      //        throw new Exception("無此item");
      //    //catch (Exception ex)
      //    //{
      //    //    MessageBox(ex.ToString());
      //    //    DealError(ex.ToString());
      //    //}
      //}
        public int   getPriceListCode(  string sPriceListName)
        {
            int ret = 0;//0表示沒拿到
            try
            {
                string cmd = "select ListNum  from opln where ListName=N'{0}'";
                cmd = string.Format(cmd,sPriceListName );
                ret = int.Parse( func_DI.DoQuery(cmd, oCompany));
            }
            catch (Exception ex)
            {
                ret = 0;
            }
            return ret;
        }

      private void DelUDORecord(string Code, string sTable)
      {
          string sErrMsg;
          SAPbobsCOM.UserTable otable = oCompany.UserTables.Item(sTable);
          otable.GetByKey(Code);
          int ret = otable.Remove();
          if (ret != 0)
          {
              oCompany.GetLastError(out ret, out sErrMsg);
              string msg = "{0} - {1}移除失敗!!{2}";
              msg = string.Format(msg, sTable, Code, sErrMsg);
              throw new Exception(msg);
          }
      }
        #region func
        private void addUDF(string fldTable, string fldName, string fldDesc, SAPbobsCOM.BoFieldTypes sType, int sSize)
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
        private void AddMenuItems(string _UniID, string _text, SAPbouiCOM.Menus oMenus)
        {
            setStatusBar("Menu建立中....", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);

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
                setStatusBar("Menu建立完成....", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
            }
            catch (Exception ex)
            { //  Menu already exists
                setStatusBar("Menu已存在....", SAPbouiCOM.BoStatusBarMessageType.smt_None);
            }
        }


        private SAPbouiCOM.Form SearchForm(string sType)
        {
            SAPbouiCOM.Form oForm;
            for (int i = 0; i <= SBO_Application.Forms.Count - 1; i++)
            {
                oForm = SBO_Application.Forms.Item(i);
                if (oForm.TypeEx == sType) return oForm;
            }
            return null;
        }
        private void setStatusBar(string _msg, SAPbouiCOM.BoStatusBarMessageType _type)
        {
            SBO_Application.StatusBar.SetText("SDK : " + _msg, SAPbouiCOM.BoMessageTime.bmt_Short, _type);
            DealError(_msg);
        }
        private void setStatusBar(string _msg, SAPbouiCOM.BoMessageTime _time, SAPbouiCOM.BoStatusBarMessageType _type)
        {
            SBO_Application.StatusBar.SetText("SDK : " + _msg, _time, _type);
            DealError(_msg);
        }
        private void MessageBox(string msg)
        {
            SBO_Application.MessageBox("SDK : " + msg, 0, "確定", "", "");
        }
        #endregion 
        #region  deal log


        public void DealError(string ErrorMsg)
        {
            DealError("C:\\\\Log\\\\" + Convert.ToString(this.SBO_Application.Company.UserName), ErrorMsg);
        }

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
    }
 
 
