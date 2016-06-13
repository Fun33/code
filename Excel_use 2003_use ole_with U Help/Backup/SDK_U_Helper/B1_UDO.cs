using System;
using System.Collections.Generic;
using System.Text;

public class Pair
{
    public string key;
    public string value;

    public Pair(string _key,string _val)
    {
        key = _key;
        value = _val;
    }
}
 //使用的有:YFY_EXCEL匯入
   public  class UDO
    {
       SAPbobsCOM.Company oCompany;
       public UDO(SAPbobsCOM.Company  _oCompany)
       {
           oCompany = _oCompany;
       }
       /// <summary>
       /// add record to udo
       /// </summary>
       /// <param name="oCompany"></param>
       /// <param name="sUDOCode">udo key</param>
       /// <returns></returns>
       //private bool AddUDORecord(string sUDOKey)
       //{
       //    bool ret = false;

       //    SAPbobsCOM.GeneralService oGeneralService = null;
       //    SAPbobsCOM.GeneralData oGeneralData = null;
       //    SAPbobsCOM.GeneralDataParams oGeneralParams = null;
       //    SAPbobsCOM.CompanyService oCompanyService = null;
       //    int i = 0;
       //    try
       //    {
       //        oCompanyService = oCompany.GetCompanyService();
       //        oGeneralService = oCompanyService.GetGeneralService(sUDOKey);
       //        // Create data for new row in main UDO
       //        oGeneralData = ((SAPbobsCOM.GeneralData)(oGeneralService.GetDataInterface(SAPbobsCOM.GeneralServiceDataInterfaces.gsGeneralData)));
       //        oGeneralData.SetProperty("U_ItemCode", "");
       //        oGeneralData.SetProperty("U_Content", "");

       //        oGeneralParams = oGeneralService.Add(oGeneralData);
       //        string txtCode = System.Convert.ToString(oGeneralParams.GetProperty("DocEntry")); 

       //        ret = true;
       //    }
       //    catch (Exception ex)
       //    {
       //        throw (ex);
       //    }
       //    return ret;
       //}

       /// <summary>
       /// del record of udo by docentry
       /// </summary>
       /// <param name="sDocEntry"></param>
       /// <param name="sUDOKey">UDO的key</param>
        public  void DeleteUDORecord(string sDocEntry, string sUDOKey)
        {

            SAPbobsCOM.GeneralService oGeneralService = null;
            SAPbobsCOM.GeneralDataParams oGeneralParams = null;
            SAPbobsCOM.CompanyService sCmp = null;
            sCmp = oCompany.GetCompanyService();
            try
            { 
                oGeneralService = sCmp.GetGeneralService(sUDOKey);
                // Delete UDO record
                oGeneralParams = ((SAPbobsCOM.GeneralDataParams)(oGeneralService.GetDataInterface(SAPbobsCOM.GeneralServiceDataInterfaces.gsGeneralDataParams)));
                oGeneralParams.SetProperty("DocEntry", sDocEntry);
                oGeneralService.Delete(oGeneralParams);
            }
            catch (Exception ex)
            {
                throw (ex); 
            }
        }
 
       public string  AddUDORecord(Pair[] src,string sUDOCode)
       {
           string ret="";

           SAPbobsCOM.GeneralService oGeneralService = null;
           SAPbobsCOM.GeneralData oGeneralData = null;
           SAPbobsCOM.GeneralDataParams oGeneralParams = null;
           SAPbobsCOM.CompanyService oCompanyService = null;
           int i = 0;
           try
           {
               oCompanyService = oCompany.GetCompanyService();
               // Get GeneralService (oCmpSrv is the CompanyService)
               oGeneralService = oCompanyService.GetGeneralService(sUDOCode);
               // Create data for new row in main UDO
               oGeneralData = ((SAPbobsCOM.GeneralData)(oGeneralService.GetDataInterface(SAPbobsCOM.GeneralServiceDataInterfaces.gsGeneralData)));
               foreach (Pair p in src)
               {
                   //if (p.value.Length > 20)
                   //    oGeneralData.SetProperty(p.key, p.value.Substring(0, 20));
                   //else
                       oGeneralData.SetProperty(p.key, p.value);
               }

               oGeneralParams = oGeneralService.Add(oGeneralData);
               ret = System.Convert.ToString(oGeneralParams.GetProperty("DocEntry"));
           }
           catch (Exception ex)
           {
               throw (ex);
           }
           return ret;
       }

        #region "GetByParams以表頭資訊取得表身資訊或新增表身.(等要用時,要再研究怎麼用)"
        /// <summary>
        /// GetByParams以表頭資訊取得表身資訊或新增表身.(等要用時,要再研究怎麼用)
       /// </summary>
       /// <param name="sDocEntry"></param>
       /// <param name="sUDOKey"></param>
       //public void GetByParams(string sDocEntry, string sUDOKey)
       //{

       //    SAPbobsCOM.GeneralService oGeneralService = null;
       //    SAPbobsCOM.GeneralDataParams oGeneralParams = null;
       //    SAPbobsCOM.CompanyService oCompanyService = null; 
       //        SAPbobsCOM.GeneralData oGeneralData = null;  

       //    oCompanyService = oCompany.GetCompanyService();
       //    try
       //    {
       //        oGeneralService = oCompanyService.GetGeneralService(sUDOKey);
  
       //        oGeneralParams = ((SAPbobsCOM.GeneralDataParams)(oGeneralService.GetDataInterface(SAPbobsCOM.GeneralServiceDataInterfaces.gsGeneralDataParams)));
       //        oGeneralParams.SetProperty("DocEntry", sDocEntry);
       //      oGeneralData=  oGeneralService.GetByParams(oGeneralParams);               
       //    }
       //    catch (Exception ex)
       //    {
       //        throw (ex);
       //    }
        //}
        #endregion 

    }
 
