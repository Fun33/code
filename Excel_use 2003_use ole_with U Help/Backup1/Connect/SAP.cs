using System;
using System.Collections.Generic;
using System.Text;

namespace Panbor_ImportWebSO
{
   public  class SAP
    {

      public   SAPbobsCOM.Company oCompany;
        public SAP()
        { 

            string sErrMsg = string.Empty;
            int iErrCode = 0;
            try
            {
                oCompany = new SAPbobsCOM.Company();
                DTsMsSQLInfo DTsSBOInfo = new DTsMsSQLInfo();
                DTsSBOInfo.LoadDecryptFile();
                DTsSBOInfo DTsSBOInfo2 = new DTsSBOInfo();
                DTsSBOInfo2.LoadDecryptFile();

                oCompany.Server = DTsSBOInfo.Server;
                oCompany.language = SAPbobsCOM.BoSuppLangs.ln_English;
                oCompany.CompanyDB = DTsSBOInfo.DataBase;
                oCompany.DbUserName = DTsSBOInfo.Sa;
                oCompany.DbPassword = DTsSBOInfo.Password;

                oCompany.UseTrusted = DTsSBOInfo2.UseTrusted;
                oCompany.DbServerType = (SAPbobsCOM.BoDataServerTypes)DTsSBOInfo2.DataBaseType;
                oCompany.UserName = DTsSBOInfo2.UserName;
                oCompany.Password = DTsSBOInfo2.Password;
                oCompany.LicenseServer = DTsSBOInfo2.LicenseServer + ":30000";
               

                iErrCode = oCompany.Connect();
                if (iErrCode != 0)
                {
                    oCompany.GetLastError(out iErrCode, out sErrMsg);
                    throw new Exception(sErrMsg);
                }
 
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void DI_Close()
        {
            if ((this.oCompany != null))
            {
                if (this.oCompany.Connected)
                {
                    this.oCompany.Disconnect();
                }
                oCompany = null;
            }
        }



    }
}
