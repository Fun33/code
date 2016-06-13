using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data.OleDb;//http://walker-lim.blogspot.tw/2011/08/c-access.html
using System.IO;

namespace AP_C.v1
{
    public partial class FB1iSN3 : Form
    {
        //static string path_doc_head = "BOM/BO/Documents/row/";
        //static string path_item_head = "BOM/BO/Items/row/";
        static string path_bp_head = "BOM/BO/BusinessPartners/row/";

        #region 
        //定義OLE======================================================
        //1.檔案位置
        private const string FileName = "Una.accdb";
        //2.提供者名稱
        private const string ProviderName = "Microsoft.ACE.OLEDB.12.0;";
        //3.帳號
        private const string UserId = ";";
        //4.密碼
        private const string Password = ";";
        //string cs =
        //  "Data Source=" + DataSource + ";" +
        //  "Provider=" + ProviderName ;
          //"User Id=" + UserId +
          //"Password=" + Password;
        #endregion 
        //string OleDbConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=c:\AccessDB\db.mdb;";


        public FB1iSN3(Main parent)
        {
            InitializeComponent();
                   this.MdiParent = parent;
                   this.WindowState = FormWindowState.Maximized;

  

        }
        private void readAccess()
        {
            string DataSource = Directory.GetCurrentDirectory() + "\\" + FileName;
            string cs =
   "Data Source=" + DataSource + ";" +
   "Provider=" + ProviderName;
            //"User Id=" + UserId +
            //"Password=" + Password;

            OleDbConnection thisConnection = new OleDbConnection(cs);
            thisConnection.Open();//開啟與access建立的連線

            OleDbCommand thisCommand=thisConnection.CreateCommand();
thisCommand.CommandText="SELECT * FROM notes";//SQL語法,其中notes為table name
OleDbDataReader thisReader=thisCommand.ExecuteReader();//建立OleDbDataReader用來存放從Access裡面讀取出來的資料
while(thisReader.Read())
{
Console.WriteLine("\t{0}\t{1}",thisReader["ID"],thisReader["TheName"]);
}//其中的"ID"是Access裡面的欄位名，"TheName同義"
thisReader.Close();//關閉OleDbDataReader
thisConnection.Close();//關閉OleDbConnection連線，即關閉與Access連線
        }
        private void writeAccess(string dbFld,string xmlFld,string type,string ObjType,string note)
        {
            string DataSource = Directory.GetCurrentDirectory() + "\\" + FileName;
            string cs =
   "Data Source=" + DataSource + ";" +
   "Provider=" + ProviderName;

            OleDbConnection conn = new OleDbConnection(cs);
            conn.Open();//開啟與access建立的連線

            string sqlstr="";
//本處是UPDATE語句，即是我們要用來Update的地方！

//Item為我建立的一個Class
           // sqlstr = "select dbFld,xmlFld,type,ObjType,note from B1iSN_FldMap";

            sqlstr = "INSERT into   B1iSN_FldMap  ([dbFld],[xmlFld],[type],[ObjType],[note]) VALUES('1','1','1','1','1')";
//            sqlstr = "INSERT INTO B1iSN_FldMap  (dbFld,xmlFld,type,ObjType,note) VALUES(";
//            sqlstr +="'"+ dbFld + "',";
//            sqlstr += "'" + xmlFld + "',";
//            sqlstr += "'" + type + "',";
//            sqlstr += "'" + ObjType + "',";
//            sqlstr += "'" + note+"'";
////sqlstr += " where Num=" + Item.Number;
//sqlstr += ")";

//定義command對象，並執行相應的SQL語句
OleDbCommand myCommand = new OleDbCommand(sqlstr, conn);
//執行SELECT的時候我們是用的ExecuteReader()
myCommand.ExecuteNonQuery();
conn.Close();
        }
       
        private void Form2_Load(object sender, EventArgs e)
        {
            //Clipboard.SetData(DataFormats.Text, tb01.Text);
            tx_desc.Text = "1.fld of table mapping fld of xml" + Environment.NewLine;
            tx_desc.Text += "2.alert chk !=0" + Environment.NewLine;
            tx_desc.Text += "3.alert chk !=-1" + Environment.NewLine;
            tx_desc.Text += "4.alert chk !=''" + Environment.NewLine;
            //tx_desc.Text += "5.alert chk mapping" + Environment.NewLine;
 
        }
        private static string  FldToXLS(string path,string fld)
        {
            string ret = @"<{1}><xsl:value-of select=""{0}{1}""/></{1}>";
            ret = string.Format(ret, path, fld);
            return ret;
        } 
 

  
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                writeAccess("1", "2", "3", "4", "5");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            ////string  tmp = Regex.Replace(tmp, "VatGourpSa", FldToXLS(path_bp_head, "SalesVATGroup"), RegexOptions.IgnoreCase);
            //string tmp = Regex.Replace(tmp, "VatGourpSa", FldToXLS(path_bp_head, "SalesVATGroup"), RegexOptions.IgnoreCase);


        }

 
 
 
         
 


      

        private string type0(string path, string src, string dest)
        {
            string ret = @"<{1}><xsl:value-of select=""{0}{2}""/></{1}>";
            ret = string.Format(ret, path, dest, src);
            return ret;
        }

        private string type1(string src, string path, string dest, string type0)
        {
            string ret = @"<xsl:variable name=""{2}"" select=""{1}{0}""></xsl:variable>"
            + @"<xsl:if test=""${2}!=&apos;0&apos;"">"
            + @"{3}"
            + "</xsl:if>";
            ret = string.Format(ret, src, path, dest, type0);
            return ret;
        }
        private string type2(string src, string path, string dest, string type0)
        {
            string ret = @"<xsl:variable name=""{2}"" select=""{1}{0}""></xsl:variable>"
            + @"<xsl:if test=""${2}!=&apos;&apos;"">"
            + @"{3}"
            + "</xsl:if>";
            ret = string.Format(ret, src, path, dest, type0);
            return ret;
        }
        private string type3(string src, string path, string dest, string type0)
        {
            string ret = @"<{1}>{2}</{1}>";
            ret = string.Format(ret, path, dest, src);
            return ret;
        }
        private string typeNegative1(string src, string path, string dest, string type0)
        {
            string ret = @"<xsl:variable name=""{2}"" select=""{1}{0}""></xsl:variable>"
       + @"<xsl:if test=""${2}!=&apos;-1&apos;"">"
       + @"{3}"
       + "</xsl:if>";
            ret = string.Format(ret, path, dest, src);
            return ret;
        }
   
 
  

        private string Door(string sStrings, string sOld, string sNew)
        {
            string ret = "";

            if (1 == 1)
                ret = Door1(sStrings, sOld, sNew);
            //else if (1==2)
            //    ret = Door2(sStrings, sOld, sNew);

            return ret;
        }
        private string Door1(string sStrings, string sOld, string sNew)
        {
            string ret = "";
            ret = Regex.Replace(sStrings, sOld, sNew, RegexOptions.IgnoreCase);
            return ret;
        }
        private string  Door2(string sStrings,string sOld,string sNew)
        {
            string ret="";
            ret = Regex.Replace(sStrings, sOld, FldToXLS(path_bp_head, sNew), RegexOptions.IgnoreCase);
            return ret;
        }
        private void BtnOCRD_Click(object sender, EventArgs e)
        {
            string tmp = tx01.Text;
            tmp = Door(tmp, "CardCode", "CardCode");
            tmp = Door(tmp, "CardName", "CardName");
            tmp = Door(tmp, "CardType", "CardType");
            tmp = Door(tmp, "GroupCode", "GroupCode");
            tmp = Door(tmp, "Address", "Address");
            tmp = Door(tmp, "ZipCode", "ZipCode");
            tmp = Door(tmp, "MailAddres", "MailAddress");
            tmp = Door(tmp, "MailZipCod", "MailZipCode");
            tmp = Door(tmp, "Phone1", "Phone1");
            tmp = Door(tmp, "Phone2", "Phone2");
            tmp = Door(tmp, "Fax", "Fax");
            tmp = Door(tmp, "CntctPrsn", "ContactPerson");
            tmp = Door(tmp, "Notes", "Notes");
            tmp = Door(tmp, "GroupNum", "PayTermsGrpCode");
            tmp = Door(tmp, "CreditLine", "CreditLimit");
            tmp = Door(tmp, "DebtLine", "MaxCommitment");
            tmp = Door(tmp, "Discount", "DiscountPercent");
            tmp = Door(tmp, "VatStatus", "VatLiable");
            tmp = Door(tmp, "LicTradNum", "FederalTaxID");
            tmp = Door(tmp, "DdctStatus", "DeductibleAtSource");
            tmp = Door(tmp, "DdctPrcnt", "DeductionPercent");
            tmp = Door(tmp, "ValidUntil", "DeductionValidUntil");
            tmp = Door(tmp, "ListNum", "PriceListNum");
            tmp = Door(tmp, "IntrstRate", "IntrestRatePercent");
            tmp = Door(tmp, "Commission", "CommissionPercent");
            tmp = Door(tmp, "CommGrCode", "CommissionGroupCode");
            tmp = Door(tmp, "Free_Text", "FreeText");
            tmp = Door(tmp, "SlpCode", "SalesPersonCode");
            tmp = Door(tmp, "Currency", "Currency");
            tmp = Door(tmp, "RateDifAct", "RateDiffAccount");
            tmp = Door(tmp, "Cellular", "Cellular");
            tmp = Door(tmp, "AvrageLate", "AvarageLate");
            tmp = Door(tmp, "City", "City");
            tmp = Door(tmp, "County", "County");
            tmp = Door(tmp, "Country", "Country");
            tmp = Door(tmp, "MailCity", "MailCity");
            tmp = Door(tmp, "MailCounty", "MailCounty");
            tmp = Door(tmp, "MailCountr", "MailCountry");
            tmp = Door(tmp, "E_Mail", "EmailAddress");
            tmp = Door(tmp, "Picture", "Picture");
            tmp = Door(tmp, "DflAccount", "DefaultAccount");
            tmp = Door(tmp, "DflBranch", "DefaultBranch");
            tmp = Door(tmp, "BankCode", "DefaultBankCode");
            tmp = Door(tmp, "AddID", "AdditionalID");
            tmp = Door(tmp, "Pager", "Pager");
            tmp = Door(tmp, "FatherCard", "FatherCard");
            tmp = Door(tmp, "CardFName", "CardForeignName");
            tmp = Door(tmp, "FatherType", "FatherType");
            tmp = Door(tmp, "DdctOffice", "DeductionOffice");
            tmp = Door(tmp, "ExportCode", "ExportCode");
            tmp = Door(tmp, "MinIntrst", "MinIntrest");
            tmp = Door(tmp, "ECVatGroup", "VatGroup");
            tmp = Door(tmp, "ShipType", "ShippingType");
            tmp = Door(tmp, "Password", "Password");
            tmp = Door(tmp, "Indicator", "Indicator");
            tmp = Door(tmp, "IBAN", "IBAN");
            tmp = Door(tmp, "CreditCard", "CreditCardCode");
            tmp = Door(tmp, "CrCardNum", "CreditCardNum");
            tmp = Door(tmp, "CardValid", "CreditCardExpiration");
            tmp = Door(tmp, "DebPayAcct", "DebitorAccount");
            tmp = Door(tmp, "validFor", "Valid");
            tmp = Door(tmp, "validFrom", "ValidFrom");
            tmp = Door(tmp, "validTo", "ValidTo");
            tmp = Door(tmp, "ValidComm", "ValidRemarks");
            tmp = Door(tmp, "frozenFor", "Frozen");
            tmp = Door(tmp, "frozenFrom", "FrozenFrom");
            tmp = Door(tmp, "frozenTo", "FrozenTo");
            tmp = Door(tmp, "FrozenComm", "FrozenRemarks");
            tmp = Door(tmp, "Block", "Block");
            tmp = Door(tmp, "State1", "BillToState");
            tmp = Door(tmp, "ExemptNo", "ExemptNum");
            tmp = Door(tmp, "Priority", "Priority");
            tmp = Door(tmp, "FormCode", "FormCode1099");
            tmp = Door(tmp, "Box1099", "Box1099");
            tmp = Door(tmp, "PymCode", "PeymentMethodCode");
            tmp = Door(tmp, "BackOrder", "BackOrder");
            tmp = Door(tmp, "PartDelivr", "PartialDelivery");
            tmp = Door(tmp, "BlockDunn", "BlockDunning");
            tmp = Door(tmp, "BankCountr", "BankCountry");
            tmp = Door(tmp, "HouseBank", "HouseBank");
            tmp = Door(tmp, "HousBnkCry", "HouseBankCountry");
            tmp = Door(tmp, "HousBnkAct", "HouseBankAccount");
            tmp = Door(tmp, "ShipToDef", "ShipToDefault");
            tmp = Door(tmp, "CollecAuth", "CollectionAuthorization");
            tmp = Door(tmp, "DME", "DME");
            tmp = Door(tmp, "InstrucKey", "InstructionKey");
            tmp = Door(tmp, "SinglePaym", "SinglePayment");
            tmp = Door(tmp, "ISRBillId", "ISRBillerID");
            tmp = Door(tmp, "PaymBlock", "PaymentBlock");
            tmp = Door(tmp, "RefDetails", "ReferenceDetails");
            tmp = Door(tmp, "HousBnkBrn", "HouseBankBranch");
            tmp = Door(tmp, "OwnerIdNum", "OwnerIDNumber");
            tmp = Door(tmp, "PyBlckDesc", "PaymentBlockDescription");
            tmp = Door(tmp, "LetterNum", "TaxExemptionLetterNum");
            tmp = Door(tmp, "MaxAmount", "MaxAmountOfExemption");
            tmp = Door(tmp, "FromDate", "ExemptionValidityDateFrom");
            tmp = Door(tmp, "ToDate", "ExemptionValidityDateTo");
            tmp = Door(tmp, "ConnBP", "LinkedBusinessPartner");
            tmp = Door(tmp, "MltMthNum", "LastMultiReconciliationNum");
            tmp = Door(tmp, "DeferrTax", "DeferredTax");
            tmp = Door(tmp, "Equ", "Equalization");
            tmp = Door(tmp, "WTLiable", "SubjectToWithholdingTax");
            tmp = Door(tmp, "CrtfcateNO", "CertificateNumber");
            tmp = Door(tmp, "ExpireDate", "ExpirationDate");
            tmp = Door(tmp, "NINum", "NationalInsuranceNum");
            tmp = Door(tmp, "AccCritria", "AccrualCriteria");
            tmp = Door(tmp, "WTCode", "WTCode");
            tmp = Door(tmp, "Building", "BillToBuildingFloorRoom");
            tmp = Door(tmp, "DpmClear", "DownPaymentClearAct");
            tmp = Door(tmp, "ChannlBP", "ChannelBP");
            tmp = Door(tmp, "DfTcnician", "DefaultTechnician");
            tmp = Door(tmp, "BillToDef", "BilltoDefault");
            tmp = Door(tmp, "BoEDiscnt", "CustomerBillofExchangDisc");
            tmp = Door(tmp, "Territory", "Territory");
            tmp = Door(tmp, "MailBuildi", "ShipToBuildingFloorRoom");
            tmp = Door(tmp, "BoEPrsnt", "CustomerBillofExchangPres");
            tmp = Door(tmp, "ProjectCod", "ProjectCode");
            tmp = Door(tmp, "VatGroup", "VatGroupLatinAmerica");
            tmp = Door(tmp, "DunTerm", "DunningTerm");
            tmp = Door(tmp, "IntrntSite", "Website");
            tmp = Door(tmp, "OtrCtlAcct", "OtherReceivablePayable");
            tmp = Door(tmp, "BoEOnClct", "BillofExchangeonCollection");
            tmp = Door(tmp, "CmpPrivate", "CompanyPrivate");
            tmp = Door(tmp, "LangCode", "LanguageCode");
            tmp = Door(tmp, "UnpaidBoE", "UnpaidBillofExchange");
            tmp = Door(tmp, "DdgKey", "WithholdingTaxDeductionGroup");
            tmp = Door(tmp, "CDPNum", "ClosingDateProcedureNumber");
            tmp = Door(tmp, "Profession", "Profession");
            tmp = Door(tmp, "BCACode", "BankChargesAllocationCode");
            tmp = Door(tmp, "TaxRndRule", "TaxRoundingRule");
            tmp = Door(tmp, "QryGroup1", "Properties1");
            tmp = Door(tmp, "QryGroup2", "Properties2");
            tmp = Door(tmp, "QryGroup3", "Properties3");
            tmp = Door(tmp, "QryGroup4", "Properties4");
            tmp = Door(tmp, "QryGroup5", "Properties5");
            tmp = Door(tmp, "QryGroup6", "Properties6");
            tmp = Door(tmp, "QryGroup7", "Properties7");
            tmp = Door(tmp, "QryGroup8", "Properties8");
            tmp = Door(tmp, "QryGroup9", "Properties9");
            tmp = Door(tmp, "QryGroup10", "Properties10");
            tmp = Door(tmp, "QryGroup11", "Properties11");
            tmp = Door(tmp, "QryGroup12", "Properties12");
            tmp = Door(tmp, "QryGroup13", "Properties13");
            tmp = Door(tmp, "QryGroup14", "Properties14");
            tmp = Door(tmp, "QryGroup15", "Properties15");
            tmp = Door(tmp, "QryGroup16", "Properties16");
            tmp = Door(tmp, "QryGroup17", "Properties17");
            tmp = Door(tmp, "QryGroup18", "Properties18");
            tmp = Door(tmp, "QryGroup19", "Properties19");
            tmp = Door(tmp, "QryGroup20", "Properties20");
            tmp = Door(tmp, "QryGroup21", "Properties21");
            tmp = Door(tmp, "QryGroup22", "Properties22");
            tmp = Door(tmp, "QryGroup23", "Properties23");
            tmp = Door(tmp, "QryGroup24", "Properties24");
            tmp = Door(tmp, "QryGroup25", "Properties25");
            tmp = Door(tmp, "QryGroup26", "Properties26");
            tmp = Door(tmp, "QryGroup27", "Properties27");
            tmp = Door(tmp, "QryGroup28", "Properties28");
            tmp = Door(tmp, "QryGroup29", "Properties29");
            tmp = Door(tmp, "QryGroup30", "Properties30");
            tmp = Door(tmp, "QryGroup31", "Properties31");
            tmp = Door(tmp, "QryGroup32", "Properties32");
            tmp = Door(tmp, "QryGroup33", "Properties33");
            tmp = Door(tmp, "QryGroup34", "Properties34");
            tmp = Door(tmp, "QryGroup35", "Properties35");
            tmp = Door(tmp, "QryGroup36", "Properties36");
            tmp = Door(tmp, "QryGroup37", "Properties37");
            tmp = Door(tmp, "QryGroup38", "Properties38");
            tmp = Door(tmp, "QryGroup39", "Properties39");
            tmp = Door(tmp, "QryGroup40", "Properties40");
            tmp = Door(tmp, "QryGroup41", "Properties41");
            tmp = Door(tmp, "QryGroup42", "Properties42");
            tmp = Door(tmp, "QryGroup43", "Properties43");
            tmp = Door(tmp, "QryGroup44", "Properties44");
            tmp = Door(tmp, "QryGroup45", "Properties45");
            tmp = Door(tmp, "QryGroup46", "Properties46");
            tmp = Door(tmp, "QryGroup47", "Properties47");
            tmp = Door(tmp, "QryGroup48", "Properties48");
            tmp = Door(tmp, "QryGroup49", "Properties49");
            tmp = Door(tmp, "QryGroup50", "Properties50");
            tmp = Door(tmp, "QryGroup51", "Properties51");
            tmp = Door(tmp, "QryGroup52", "Properties52");
            tmp = Door(tmp, "QryGroup53", "Properties53");
            tmp = Door(tmp, "QryGroup54", "Properties54");
            tmp = Door(tmp, "QryGroup55", "Properties55");
            tmp = Door(tmp, "QryGroup56", "Properties56");
            tmp = Door(tmp, "QryGroup57", "Properties57");
            tmp = Door(tmp, "QryGroup58", "Properties58");
            tmp = Door(tmp, "QryGroup59", "Properties59");
            tmp = Door(tmp, "QryGroup60", "Properties60");
            tmp = Door(tmp, "QryGroup61", "Properties61");
            tmp = Door(tmp, "QryGroup62", "Properties62");
            tmp = Door(tmp, "QryGroup63", "Properties63");
            tmp = Door(tmp, "QryGroup64", "Properties64");
            tmp = Door(tmp, "RegNum", "CompanyRegistrationNumber");
            tmp = Door(tmp, "VerifNum", "VerificationNumber");
            tmp = Door(tmp, "DscntObjct", "DiscountBaseObject");
            tmp = Door(tmp, "DscntRel", "DiscountRelations");
            tmp = Door(tmp, "TypWTReprt", "TypeReport");
            tmp = Door(tmp, "ThreshOver", "ThresholdOverlook");
            tmp = Door(tmp, "SurOver", "SurchargeOverlook");
            tmp = Door(tmp, "DpmIntAct", "DownPaymentInterimAccount");
            tmp = Door(tmp, "OpCode347", "OperationCode347");
            tmp = Door(tmp, "InsurOp347", "InsuranceOperation347");
            tmp = Door(tmp, "HierchDdct", "HierarchicalDeduction");
            tmp = Door(tmp, "WHShaamGrp", "ShaamGroup");
            tmp = Door(tmp, "CertWHT", "WithholdingTaxCertified");
            tmp = Door(tmp, "CertBKeep", "BookkeepingCertified");
            tmp = Door(tmp, "PlngGroup", "PlanningGroup");
            tmp = Door(tmp, "Affiliate", "Affiliate");
            tmp = Door(tmp, "IndustryC", "Industry");

            tx01.Text = tmp;
            Clipboard.SetData(DataFormats.Text, tx01.Text);
        }
        //string tmp = tx01.Text;
        //    tx01.Text = tmp;
        private void BtnCRD1_Click(object sender, EventArgs e)
        {
            string tmp = tx01.Text;
            tmp = Door(tmp, "CardCode", "ParentKey");
            tmp = Door(tmp, "LineNum", "LineNum");
            tmp = Door(tmp, "AddressName", "AddressName");
            tmp = Door(tmp, "AddressName2", "AddressName2");
            tmp = Door(tmp, "AddressName3", "AddressName3");
            tmp = Door(tmp, "AddressType", "AddressType");
            tmp = Door(tmp, "AddrType", "AddrType");
            tmp = Door(tmp, "Block", "Block");
            tmp = Door(tmp, "BuildingFloorRoom", "BuildingFloorRoom");
            tmp = Door(tmp, "City", "City");
            tmp = Door(tmp, "Country", "Country");
            tmp = Door(tmp, "County", "County");
            tmp = Door(tmp, "FederalTaxID", "FederalTaxID");
            tmp = Door(tmp, "State", "State");
            tmp = Door(tmp, "Street", "Street");
            tmp = Door(tmp, "StreetNo", "StreetNo");
            tmp = Door(tmp, "TaxCode", "TaxCode");
            tmp = Door(tmp, "ZipCode", "ZipCode");

            tx01.Text = tmp;
        }

        private void BtnCRD2_Click(object sender, EventArgs e)
        {
            string tmp = tx01.Text;
            tmp = Regex.Replace(tmp, "CardCode", FldToXLS(path_bp_head, "ParentKey"), RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "LineNum", FldToXLS(path_bp_head, "LineNum"), RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "PaymentMethodCode", FldToXLS(path_bp_head, "PaymentMethodCode"), RegexOptions.IgnoreCase);

            tx01.Text = tmp;
            Clipboard.SetData(DataFormats.Text, tx01.Text);
        }

        private void BtnCRD3_Click(object sender, EventArgs e)
        {
            string tmp = tx01.Text;
            tmp = Door(tmp, "CardCode", "ParentKey");
            tmp = Door(tmp, "LineNum", "LineNum");
            tmp = Door(tmp, "AccountCode", "AccountCode");
            tmp = Door(tmp, "AccountType", "AccountType");
            
            tx01.Text = tmp;
            Clipboard.SetData(DataFormats.Text, tx01.Text);
        }

        private void BtnCRD5_Click(object sender, EventArgs e)
        {
            string tmp = tx01.Text;
            tmp = Door(tmp, "CardCode", "ParentKey");
            tmp = Door(tmp, "LineNum", "LineNum");
            tmp = Door(tmp, "PaymentDate", "PaymentDate");

            tx01.Text = tmp;
            Clipboard.SetData(DataFormats.Text, tx01.Text);
        }

        private void BtnOCPR_Click(object sender, EventArgs e)
        {
            string tmp = tx01.Text;
            tmp = Door(tmp, "CardCode", "ParentKey");
            tmp = Door(tmp, "LineNum", "LineNum");
            tmp = Door(tmp, "Address", "Address");
            tmp = Door(tmp, "DateOfBirth", "DateOfBirth");
            tmp = Door(tmp, "E_Mail", "E_Mail");
            tmp = Door(tmp, "Fax", "Fax");
            tmp = Door(tmp, "Gender", "Gender");
            tmp = Door(tmp, "MobilePhone", "MobilePhone");
            tmp = Door(tmp, "Name", "Name");
            tmp = Door(tmp, "Pager", "Pager");
            tmp = Door(tmp, "Password", "Password");
            tmp = Door(tmp, "Phone1", "Phone1");
            tmp = Door(tmp, "Phone2", "Phone2");
            tmp = Door(tmp, "PlaceOfBirth", "PlaceOfBirth");
            tmp = Door(tmp, "Position", "Position");
            tmp = Door(tmp, "Profession", "Profession");
            tmp = Door(tmp, "Remarks1", "Remarks1");
            tmp = Door(tmp, "Remarks2", "Remarks2");
            tmp = Door(tmp, "Title", "Title");

            tx01.Text = tmp;
            Clipboard.SetData(DataFormats.Text, tx01.Text);
        }

        private void BtnOCRB_Click(object sender, EventArgs e)
        {
            string tmp = tx01.Text;
            tmp = Door(tmp, "CardCode", "ParentKey");
            tmp = Door(tmp, "LineNum", "LineNum");
            tmp = Door(tmp, "AccountNo", "AccountNo");
            tmp = Door(tmp, "BPCode", "BPCode");
            tmp = Door(tmp, "BankCode", "BankCode");
            tmp = Door(tmp, "Block", "Block");
            tmp = Door(tmp, "Branch", "Branch");
            tmp = Door(tmp, "BuildingFloorRoom", "BuildingFloorRoom");
            tmp = Door(tmp, "City", "City");
            tmp = Door(tmp, "ControlKey", "ControlKey");
            tmp = Door(tmp, "Country", "Country");
            tmp = Door(tmp, "County", "County");
            tmp = Door(tmp, "IBAN", "IBAN");
            tmp = Door(tmp, "InternalKey", "InternalKey");
            tmp = Door(tmp, "LogInstance", "LogInstance");
            tmp = Door(tmp, "State", "State");
            tmp = Door(tmp, "Street", "Street");
            tmp = Door(tmp, "UserNo1", "UserNo1");
            tmp = Door(tmp, "UserNo2", "UserNo2");
            tmp = Door(tmp, "UserNo3", "UserNo3");
            tmp = Door(tmp, "UserNo4", "UserNo4");
            tmp = Door(tmp, "ZipCode", "ZipCode");

            tx01.Text = tmp;
            Clipboard.SetData(DataFormats.Text, tx01.Text);
        }

        private void button45_Click(object sender, EventArgs e)
        {
            string tmp = tx01.Text;
            tx01.Text = tmp;
            Clipboard.SetData(DataFormats.Text, tx01.Text);
        }

        private void button44_Click(object sender, EventArgs e)
        {
            string tmp = tx01.Text;
            tx01.Text = tmp;
            Clipboard.SetData(DataFormats.Text, tx01.Text);
        }

        private void button43_Click(object sender, EventArgs e)
        {
            string tmp = tx01.Text;
            tx01.Text = tmp;
            Clipboard.SetData(DataFormats.Text, tx01.Text);
        }

        private void button42_Click(object sender, EventArgs e)
        {
            string tmp = tx01.Text;
            tx01.Text = tmp;
            Clipboard.SetData(DataFormats.Text, tx01.Text);
        }

        private void button41_Click(object sender, EventArgs e)
        {
            string tmp = tx01.Text;
            tx01.Text = tmp;
            Clipboard.SetData(DataFormats.Text, tx01.Text);
        }
    }
}
 