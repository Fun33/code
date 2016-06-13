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
    public partial class FB1iSN : Form
    {
        //static string path_doc_head = "BOM/BO/Documents/row/";
        static string path_item_head = "BOM/BO/Items/row/";
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


        public FB1iSN(Main parent)
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
        private void btnB1isnItem_Click(object sender, EventArgs e)
        {
            string tmp = tx01.Text;
            //tmp = Regex.Replace(tmp, "", "", RegexOptions.IgnoreCase);

            tmp = Regex.Replace(tmp, "avgprice", FldToXLS(path_bp_head, "AvgStdPrice"), RegexOptions.IgnoreCase);

            //YFY default X0
            tmp = Regex.Replace(tmp, "VatGourpSa",FldToXLS(path_bp_head, "SalesVATGroup"), RegexOptions.IgnoreCase);
            //YFY default J0
            tmp = Regex.Replace(tmp, "VatGroupPu", "PurchaseVATGroup", RegexOptions.IgnoreCase);

            tmp = Regex.Replace(tmp, "CodeBars", "BarCode", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "ItemCode", "ItemCode", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "ItemName", "ItemName", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "FrgnName", "ForeignName", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "ItmsGrpCod", "ItemsGroupCode", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Spec", "GTSItemSpec", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "PicturName", "Picture", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "PrchseItem", "PurchaseItem", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "SellItem", "SalesItem", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "InvntItem", "InventoryItem", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "AssetItem", "AssetItem", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "DfltWH", "DefaultWarehouse", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "preferVendor", "Mainsupplier", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "SWW", "SWW ", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "SuppCatNum", "SupplierCatalogNo", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "BuyUnitMsr", "PurchaseUnit", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "NumInBuy", "PurchaseItemsPerUnit", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "MinLevel", "MinInventory", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "SalUnitMsr", "SalesUnit", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "NumInSale", "SalesItemsPerUnit", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "UserText", "User_Text", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "SHeight1", "SalesUnitHeight", RegexOptions.IgnoreCase);

            tmp = Regex.Replace(tmp, "SHght1Unit", "<--chk!=0-->" + Environment.NewLine + "SalesHeightUnit", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "SHeight2", "SalesUnitHeight1", RegexOptions.IgnoreCase);
            
            tmp = Regex.Replace(tmp, "SHght2Unit", "SalesHeightUnit1", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "SWidth1", "SalesUnitWidth", RegexOptions.IgnoreCase);

            tmp = Regex.Replace(tmp, "SWdth1Unit", "<--chk!=0-->" + Environment.NewLine + "SalesWidthUnit", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "SWidth2", "SalesUnitWidth1", RegexOptions.IgnoreCase);

            tmp = Regex.Replace(tmp, "SWdth2Unit", "<--chk!=0-->" + Environment.NewLine + "SalesWidthUnit1", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "SLength1", "SalesUnitLength", RegexOptions.IgnoreCase);

            tmp = Regex.Replace(tmp, "SLen1Unit", "<--chk!=0-->"+Environment.NewLine+"SalesLengthUnit", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Slength2", "SalesUnitLength1", RegexOptions.IgnoreCase);

            tmp = Regex.Replace(tmp, "SLen2Unit", "<--chk!=0-->" + Environment.NewLine + "SalesLengthUnit1", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "SVolume", "SalesUnitVolume", RegexOptions.IgnoreCase);

            tmp = Regex.Replace(tmp, "SVolUnit", "<--chk!=0-->" + Environment.NewLine + "SalesVolumeUnit", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "SWeight1", "SalesUnitWeight", RegexOptions.IgnoreCase);

            tmp = Regex.Replace(tmp, "SWght1Unit", "<--chk!=0-->" + Environment.NewLine + "SalesWeightUnit", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "SWeight2", "SalesUnitWeight1", RegexOptions.IgnoreCase);

            tmp = Regex.Replace(tmp, "SWght2Unit", "<--chk!=0-->" + Environment.NewLine + "SalesWeightUnit1", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "BHeight1", "PurchaseUnitHeight", RegexOptions.IgnoreCase);

            tmp = Regex.Replace(tmp, "BHght1Unit", "<--chk!=0-->" + Environment.NewLine + "PurchaseHeightUnit", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "BHeight2", "PurchaseUnitHeight1", RegexOptions.IgnoreCase);

            tmp = Regex.Replace(tmp, "BHght2Unit", "<--chk!=0-->" + Environment.NewLine + "PurchaseHeightUnit1", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "BWidth1", "PurchaseUnitWidth", RegexOptions.IgnoreCase);

            tmp = Regex.Replace(tmp, "BWdth1Unit", "<--chk!=0-->" + Environment.NewLine + "PurchaseWidthUnit", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "BWidth2", "PurchaseUnitWidth1", RegexOptions.IgnoreCase);

            tmp = Regex.Replace(tmp, "BWdth2Unit", "<--chk!=0-->" + Environment.NewLine + "PurchaseWidthUnit1", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "BLength1", "PurchaseUnitLength", RegexOptions.IgnoreCase);

            tmp = Regex.Replace(tmp, "BLen1Unit", "<--chk!=0-->" + Environment.NewLine + "PurchaseLengthUnit", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Blength2", "PurchaseUnitLength1", RegexOptions.IgnoreCase);

            tmp = Regex.Replace(tmp, "BLen2Unit", "<--chk!=0-->" + Environment.NewLine + "PurchaseLengthUnit1", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "BVolume", "PurchaseUnitVolume", RegexOptions.IgnoreCase);

            tmp = Regex.Replace(tmp, "BVolUnit", "<--chk!=0-->" + Environment.NewLine + "PurchaseVolumeUnit", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "BWeight1", "PurchaseUnitWeight", RegexOptions.IgnoreCase);

            tmp = Regex.Replace(tmp, "BWght1Unit", "<--chk!=0-->" + Environment.NewLine + "PurchaseWeightUnit", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "BWeight2", "PurchaseUnitWeight1", RegexOptions.IgnoreCase);

            tmp = Regex.Replace(tmp, "BWght2Unit", "<--chk!=0-->" + Environment.NewLine + "PurchaseWeightUnit1", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "PurPackMsr", "PurchaseQtyPerPackUnit", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "PurPackUn", "PurchasePackagingUnit", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "SalPackMsr", "SalesQtyPerPackUnit", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "SalPackUn", "SalesPackagingUnit", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "GLMethod", "GLMethod", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Phantom", "IsPhantom", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "IssueMthd", "IssueMethod", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "MngMethod", "ManageSerialNumbers", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "MngMethod", "ManageBatchNumbers", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "MngMethod", "SRIAndBatchManageMethod", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "InvntryUom", "InventoryUOM", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "EvalSystem", "CostAccountingMethod", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "ByWH", "ManageStockByWarehouse", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "PlaningSys", "PlanningSystem", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "PrcrmntMtd", "ProcurementMethod", RegexOptions.IgnoreCase);
            //2
            tmp = Regex.Replace(tmp, "OrdrIntrvl", "<--chk!=0-->" + Environment.NewLine + "OrderIntervals", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "OrdrMulti", "OrderMultiple", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "MinOrdrQty", "MinOrderQuantity", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "LeadTime", "LeadTime", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "validFor", "Valid", RegexOptions.IgnoreCase);
            //if space to space will no change.must be nil=true.
            tmp = Regex.Replace(tmp, "validFrom", "<--chk!=''->" + Environment.NewLine + "ValidFrom", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "validTo", "<--chk!='' -->" + Environment.NewLine + "ValidTo", RegexOptions.IgnoreCase);
        
            tmp = Regex.Replace(tmp, "ValidComm", "ValidRemarks", RegexOptions.IgnoreCase);
            
            tmp = Regex.Replace(tmp, "frozenFor", "Frozen", RegexOptions.IgnoreCase);

            //if space to space will no change.must be nil=true.
            tmp = Regex.Replace(tmp, "frozenFrom", "<--chk!=''-->" + Environment.NewLine + "FrozenFrom", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "frozenTo", "<--chk!=''-->" + Environment.NewLine + "FrozenTo", RegexOptions.IgnoreCase);
     

            tmp = Regex.Replace(tmp, "FrozenComm", "FrozenRemarks", RegexOptions.IgnoreCase);

            tmp = Regex.Replace(tmp, "ShipType", "<--chk!=0-->" + Environment.NewLine + "ShipType", RegexOptions.IgnoreCase);

            tx01.Text = tmp;
            Clipboard.SetData(DataFormats.Text,tx01.Text );
        }
        //case
        private string DateXML(string fld)
        { 
            string ret=@"<xsl:choose><xsl:when test=""BO/Items/row/ValidTo != &apos;&apos;""><ValidTo><xsl:value-of select=""BO/Items/row/ValidTo""/></ValidTo></xsl:when><xsl:otherwise><ValidTo nil=""true""/></xsl:otherwise></xsl:choose>";
            ret = ret.Replace("ValidTo",fld);
            return ret;
        }

        private void BtnB1isnBP_Click(object sender, EventArgs e)
        {
            string tmp = tx01.Text;
            //tmp = Regex.Replace(tmp, "", "", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "", "", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "CardCode", "CardCode", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "CardName", "CardName", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "CardType", "CardType", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "GroupCode", "GroupCode", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Phone1", "Phone1", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Phone2", "Phone2", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Fax", "Fax", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Notes", "Notes", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Currency", "Currency", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Cellular", "Cellular", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "LicTradNum", "FederalTaxID", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "AddID", "AdditionalID", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Properties1", "Properties1", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Properties2", "Properties2", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Properties3", "Properties3", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Properties4", "Properties4", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Properties5", "Properties5", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Properties6", "Properties6", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Properties7", "Properties7", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "AddID", "AdditionalID", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Name", "Name", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Position", "Position", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Address", "Address", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Tel1", "Phone1", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Tel2", "Phone2", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Cellolar", "MobilePhone", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Fax", "Fax", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "E_MailL", "E_Mail", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Notes1", "Remarks1", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Notes2", "Remarks2", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Password", "Password", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "BirthPlace", "PlaceOfBirth", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "BirthDate", "DateOfBirth", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Gender", "Gender", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Profession", "Profession", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Title", "Title", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "BirthCity", "CityOfBirth", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Active", "Active", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "FirstName", "FirstName", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "MiddleName", "MiddleName", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "LastName", "LastName", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "AddressType", "AddressType", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Address", "AddressName", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Street", "Street", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Block", "Block", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "ZipCode", "ZipCode", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "City", "City", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "County", "County", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Country", "Country", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "State", "State", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Address2", "AddressName2", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Address3", "AddressName3", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "StreetNo", "StreetNo", RegexOptions.IgnoreCase);
            //1
            tmp = Regex.Replace(tmp, "validFor", "Valid", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "validFrom", "<--chk!=''-->" + Environment.NewLine + "ValidFrom", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "validTo", "<--chk!=''-->" + Environment.NewLine + "ValidTo", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "ValidComm", "ValidRemarks", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "frozenFor", "Frozen", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "frozenFrom", "<--chk!=''-->" + Environment.NewLine + "FrozenFrom", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "frozenTo", "<--chk!=''-->" + Environment.NewLine + "FrozenTo", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "FrozenComm", "FrozenRemarks", RegexOptions.IgnoreCase);


            tmp = Regex.Replace(tmp, "ShippingType", "<--chk!=&apos;0&apos;-->" + Environment.NewLine + "ShippingType", RegexOptions.IgnoreCase);
            tx01.Text = tmp;
            Clipboard.SetData(DataFormats.Text, tx01.Text);
        }
            //       string tmp = tb01.Text;
            ////tmp = Regex.Replace(tmp, "", "", RegexOptions.IgnoreCase);
            //tb01.Text = tmp;
            //Clipboard.SetData(DataFormats.Text, tx01.Text);
        private void BtnB1iSNDoc_Click(object sender, EventArgs e)
        {

            string tmp = tx01.Text;

            //tmp = Regex.Replace(tmp, "", "", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "NumAtCard", "NumAtCard", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "CANCELED", "Cancelled", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "DocDate", "DocDate", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "DocDueDate", "DocDueDate", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "CardCode", "CardCode", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Address", "Address", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "DiscPrcnt", "DiscountPercent", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "DocCur", "DocCurrency", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "DocRate", "DocRate", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Comments", "Comments", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "JrnlMemo", "JournalMemo", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "TaxDate", "TaxDate", RegexOptions.IgnoreCase);

            tmp = Regex.Replace(tmp, "Address2", "<--chk!=&apos;&apos;-->" + Environment.NewLine + "Address2", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "ShipToCode", "ShipToCode", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Rounding", "Rounding", RegexOptions.IgnoreCase);

            tmp = Regex.Replace(tmp, "CancelDate", "<--chk!=&apos;&apos;-->" + Environment.NewLine + "CancelDate", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "VatDate", "VatDate", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "ItemCode", "ItemCode", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Dscription", "ItemDescription", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Quantity", "Quantity", RegexOptions.IgnoreCase);

            tmp = Regex.Replace(tmp, "ShipDate", "<--chk!=&apos;&apos;-->" + Environment.NewLine + "ShipDate", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Price", "Price", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "DiscPrcnt", "DiscountPercent", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "WhsCode", "WarehouseCode", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "BaseLineNumber", "BaseLineNumber", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "BatchNumber", "BatchNumber", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "LotNumber", "InternalSerialNumber", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Quantity", "Quantity", RegexOptions.IgnoreCase);

            tmp = Regex.Replace(tmp, "MnfSerial",
                "<--chk!=&apos;&apos;  ManufacturerSerialNumber-->" + Environment.NewLine +
                "<--chk=&apos;&apos;  InternalSerialNumber-->" + Environment.NewLine +                
                "ManufacturerSerialNumber", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "ExpDate", "ExpiryDate", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "MnfDate", "ManufacturingDate", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Location", "Location", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Notes", "Notes", RegexOptions.IgnoreCase);

            tmp = Regex.Replace(tmp, "Weight1Unit", "<--chk!=&apos;0&apos;-->" + Environment.NewLine + "Weight1Unit", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Hight1Unit", "<--chk!=&apos;0&apos;-->" + Environment.NewLine + "Hight1Unit", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Height1", "<--chk!=&apos;0&apos;-->" + Environment.NewLine + "Height1", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Lengh1Unit", "<--chk!=&apos;0&apos;-->" + Environment.NewLine + "Lengh1Unit", RegexOptions.IgnoreCase);

            tmp = Regex.Replace(tmp, "Lengh1", "<--chk!=&apos;0&apos;-->" + Environment.NewLine + "Lengh1", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "VolumeUnit", "<--chk!=&apos;0&apos;-->" + Environment.NewLine + "VolumeUnit", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Volume", "<--chk!=&apos;0&apos;-->" + Environment.NewLine + "Volume", RegexOptions.IgnoreCase);

            tmp = Regex.Replace(tmp, "PaymentGroupCode", "<--chk!=&apos;-1&apos;-->" + Environment.NewLine + "PaymentGroupCode", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "TransportationCode", "<--chk!=&apos;-1&apos;-->" + Environment.NewLine + "TransportationCode", RegexOptions.IgnoreCase);
          
            tmp = Regex.Replace(tmp, "Volume", "<--chk!=&apos;0&apos;-->" + Environment.NewLine + "Volume", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "VolumeUnit", "<--chk!=&apos;0&apos;-->" + Environment.NewLine + "VolumeUnit", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Volume", "<--chk!=&apos;0&apos;-->" + Environment.NewLine + "Volume", RegexOptions.IgnoreCase);
           

            tx01.Text = tmp;
            Clipboard.SetData(DataFormats.Text, tx01.Text);
        }

        private void BtnBOM_Click(object sender, EventArgs e)
        {
            //       string tmp = tb01.Text;
            ////tmp = Regex.Replace(tmp, "", "", RegexOptions.IgnoreCase);
            //tb01.Text = tmp;
      
            Clipboard.SetData(DataFormats.Text, txBOM.Text);
        }

        private void BtnOGLT_Click(object sender, EventArgs e)
        {
            Clipboard.SetData(DataFormats.Text, txOGLT.Text);
        }

        private void BtnGetItemXML_Click(object sender, EventArgs e)
        {
            string tmp = tx01.Text;
            tmp = Regex.Replace(tmp, "validFrom", DateXML("ValidFrom"), RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "validTo", DateXML("ValidTo"), RegexOptions.IgnoreCase);

            tmp = Regex.Replace(tmp, "frozenFrom", DateXML("FrozenFrom"), RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "frozenTo", DateXML("FrozenTo"), RegexOptions.IgnoreCase);
            tx01.Text = tmp;
            Clipboard.SetData(DataFormats.Text, tx01.Text);
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

        private void button3_Click(object sender, EventArgs e)
        {
          //如果不單純,這裡就要換成*

        }

        private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string src = dataGridView1.Rows[0].Cells[0].Value.ToString();
            string dest = dataGridView1.Rows[0].Cells[1].Value.ToString();
            string path = "Items";
            string ret = @"<{0}><xsl:value-of select=""BO/{2}/row/{1}""/></{0}>";
            ret = string.Format(ret, dest, src, path);

            Clipboard.SetData(DataFormats.Text, ret);
            string filename=@"d:\log" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
            System.IO.File.WriteAllText(filename , ret);
            System.Diagnostics.Process.Start(filename); 
            return;
            // System.IO.File.ReadAllText(@"d:\log"+DateTime.Now.ToString("yyyyMMdd")+".txt", System.Text.Encoding.Default);
            
            //System.Diagnostics.Process p = new System.Diagnostics.Process();
            //p.StartInfo.FileName = "notepad.exe";
            //p.StartInfo.WorkingDirectory = @"c:\windows\system32\"; //你的记事本的路径
            //p.StartInfo.CreateNoWindow = true;
            //p.StartInfo.UseShellExecute = false;
            //p.Start();
            //Clipboard.SetData(DataFormats.Text, ret);

            //MessageBox.Show(ret);
        }

        
         
          
  
         
        private void BtnClear_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
        }

        #region paste
        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.V && e.Control == true)
            {
                Paste();
            }
        }
        private void Paste()
        {
            string[] aryCol;

            int x = 0, y = 0;
            string[] aryRows = Clipboard.GetText().Split(new string[] { "\r\n" }, StringSplitOptions.None);
            foreach (string s in aryRows)
            {
                dataGridView1.Rows.Add();

                aryCol = s.Split(new string[] { "\t" }, StringSplitOptions.None);
                y = 0;
                foreach (string ss in aryCol)
                {
                    dataGridView1.Rows[x].Cells[y].Value = ss;
                    y++;
                }

                x++;
            }
            dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 2);
        }


        #endregion 

        private void BtnBPHead_Click(object sender, EventArgs e)
        {
            txPATH.Text = path_bp_head;
        }

        private void BtnItemHead_Click(object sender, EventArgs e)
        {
            txPATH.Text = path_item_head;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            txPATH .Text = @"jdbc:Row/jdbc:";
        }
 

        #region doc
        public static string gettype_doc(string tmp)
        {
            //string tmp = tx01.Text;
            //tmp = Regex.Replace(tmp, "", "", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "NumAtCard", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "CANCELED", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "DocDate", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "DocDueDate", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "CardCode", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Address", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "DiscPrcnt", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "DocCur", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "DocRate", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Comments", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "JrnlMemo", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "TaxDate", "0", RegexOptions.IgnoreCase);

            tmp = Regex.Replace(tmp, "Address2", "2", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "ShipToCode", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Rounding", "0", RegexOptions.IgnoreCase);

            tmp = Regex.Replace(tmp, "CancelDate", "2", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "VatDate", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "ItemCode", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Dscription", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Quantity", "0", RegexOptions.IgnoreCase);

            tmp = Regex.Replace(tmp, "ShipDate", "2", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Price", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "DiscPrcnt", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "WhsCode", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "BaseLineNumber", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "BatchNumber", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "LotNumber", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Quantity", "0", RegexOptions.IgnoreCase);

            tmp = Regex.Replace(tmp, "MnfSerial", "9", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "ExpDate", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "MnfDate", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Location", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Notes", "0", RegexOptions.IgnoreCase);

            tmp = Regex.Replace(tmp, "Weight1Unit", "1", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Hight1Unit", "1", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Height1", "1", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Lengh1Unit", "1", RegexOptions.IgnoreCase);

            tmp = Regex.Replace(tmp, "Lengh1", "1", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "VolumeUnit", "1", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Volume", "1", RegexOptions.IgnoreCase);

            tmp = Regex.Replace(tmp, "PaymentGroupCode", "-1", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "TransportationCode", "-1", RegexOptions.IgnoreCase);

            tmp = Regex.Replace(tmp, "Volume", "1", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "VolumeUnit", "1", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Volume", "1", RegexOptions.IgnoreCase);


            //tx01.Text = tmp;
            //Clipboard.SetData(DataFormats.Text, tx01.Text);
            return tmp;
        }
        public static string GetXMLFld_doc(string tmp)
        {
            //string tmp = tx01.Text;
            //tmp = Regex.Replace(tmp, "", "", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "NumAtCard", "NumAtCard", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "CANCELED", "Cancelled", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "DocDate", "DocDate", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "DocDueDate", "DocDueDate", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "CardCode", "CardCode", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Address", "Address", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "DiscPrcnt", "DiscountPercent", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "DocCur", "DocCurrency", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "DocRate", "DocRate", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Comments", "Comments", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "JrnlMemo", "JournalMemo", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "TaxDate", "TaxDate", RegexOptions.IgnoreCase);

            tmp = Regex.Replace(tmp, "Address2", "Address2", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "ShipToCode", "ShipToCode", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Rounding", "Rounding", RegexOptions.IgnoreCase);

            tmp = Regex.Replace(tmp, "CancelDate", "CancelDate", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "VatDate", "VatDate", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "ItemCode", "ItemCode", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Dscription", "ItemDescription", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Quantity", "Quantity", RegexOptions.IgnoreCase);

            tmp = Regex.Replace(tmp, "ShipDate", "ShipDate", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Price", "Price", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "DiscPrcnt", "DiscountPercent", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "WhsCode", "WarehouseCode", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "BaseLineNumber", "BaseLineNumber", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "BatchNumber", "BatchNumber", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "LotNumber", "InternalSerialNumber", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Quantity", "Quantity", RegexOptions.IgnoreCase);

            tmp = Regex.Replace(tmp, "MnfSerial",
                "<--chk!=&apos;&apos;  ManufacturerSerialNumber-->" + Environment.NewLine +
                "<--chk=&apos;&apos;  InternalSerialNumber-->" + Environment.NewLine +
                "ManufacturerSerialNumber", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "ExpDate", "ExpiryDate", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "MnfDate", "ManufacturingDate", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Location", "Location", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Notes", "Notes", RegexOptions.IgnoreCase);

            tmp = Regex.Replace(tmp, "Weight1Unit", "Weight1Unit", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Hight1Unit", "Hight1Unit", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Height1", "Height1", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Lengh1Unit", "Lengh1Unit", RegexOptions.IgnoreCase);

            tmp = Regex.Replace(tmp, "Lengh1", "Lengh1", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "VolumeUnit", "VolumeUnit", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Volume", "Volume", RegexOptions.IgnoreCase);

            tmp = Regex.Replace(tmp, "PaymentGroupCode", "PaymentGroupCode", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "TransportationCode", "TransportationCode", RegexOptions.IgnoreCase);

            tmp = Regex.Replace(tmp, "Volume", "Volume", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "VolumeUnit", "VolumeUnit", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Volume", "Volume", RegexOptions.IgnoreCase);


            //tx01.Text = tmp;
            //Clipboard.SetData(DataFormats.Text, tx01.Text);
            return tmp;
        }
        #endregion

        #region item

        //0-normal
        //1-if 0 no mapping.
        //2-if ''  no mapping
        //defalt
        //?
        //foreon if !-'' mapping else be max or be min
        //CA_XX
        public static string gettype_item(string tmp)
        {

            //tmp = Regex.Replace(tmp, "", "", RegexOptions.IgnoreCase);



            //YFY default X0
            tmp = Regex.Replace(tmp, "VatGoupSa", "0", RegexOptions.IgnoreCase);
            //YFY default J0
            tmp = Regex.Replace(tmp, "VatGroupPu", "0", RegexOptions.IgnoreCase);

            tmp = Regex.Replace(tmp, "AvgPrice", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Attachment", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "ItemType", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "CodeBars", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "ItemCode", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "ItemName", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "FrgnName", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "ItmsGrpCod", "1", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Spec", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "PicturName", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "PrchseItem", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "SellItem", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "InvntItem", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "AssetItem", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "DfltWH", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "preferVendor", "2", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "SWW", "0 ", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "SuppCatNum", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "BuyUnitMsr", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "NumInBuy", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "MinLevel", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "SalUnitMsr", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "NumInSale", "1", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "UserText", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "SHeight1", "0", RegexOptions.IgnoreCase);

            tmp = Regex.Replace(tmp, "SHght1Unit", "1", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "SHeight2", "0", RegexOptions.IgnoreCase);

            tmp = Regex.Replace(tmp, "SHght2Unit", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "SWidth1", "0", RegexOptions.IgnoreCase);

            tmp = Regex.Replace(tmp, "SWdth1Unit", "1", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "SWidth2", "0", RegexOptions.IgnoreCase);

            tmp = Regex.Replace(tmp, "SWdth2Unit", "1", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "SLength1", "0", RegexOptions.IgnoreCase);

            tmp = Regex.Replace(tmp, "SLen1Unit", "1", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Slength2", "0", RegexOptions.IgnoreCase);

            tmp = Regex.Replace(tmp, "SLen2Unit", "1", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "SVolume", "0", RegexOptions.IgnoreCase);

            tmp = Regex.Replace(tmp, "SVolUnit", "1", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "SWeight1", "0", RegexOptions.IgnoreCase);

            tmp = Regex.Replace(tmp, "SWght1Unit", "1", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "SWeight2", "0", RegexOptions.IgnoreCase);

            tmp = Regex.Replace(tmp, "SWght2Unit", "1", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "BHeight1", "0", RegexOptions.IgnoreCase);

            tmp = Regex.Replace(tmp, "BHght1Unit", "1", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "BHeight2", "0", RegexOptions.IgnoreCase);

            tmp = Regex.Replace(tmp, "BHght2Unit", "1", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "BWidth1", "0", RegexOptions.IgnoreCase);

            tmp = Regex.Replace(tmp, "BWdth1Unit", "1", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "BWidth2", "0", RegexOptions.IgnoreCase);

            tmp = Regex.Replace(tmp, "BWdth2Unit", "1", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "BLength1", "0", RegexOptions.IgnoreCase);

            tmp = Regex.Replace(tmp, "BLen1Unit", "1", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Blength2", "0", RegexOptions.IgnoreCase);

            tmp = Regex.Replace(tmp, "BLen2Unit", "1", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "BVolume", "0", RegexOptions.IgnoreCase);

            tmp = Regex.Replace(tmp, "BVolUnit", "1", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "BWeight1", "0", RegexOptions.IgnoreCase);

            tmp = Regex.Replace(tmp, "BWght1Unit", "1", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "BWeight2", "0", RegexOptions.IgnoreCase);

            tmp = Regex.Replace(tmp, "BWght2Unit", "1", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "PurPackMsr", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "PurPackUn", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "SalPackMsr", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "SalPackUn", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "GLMethod", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Phantom", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "IssueMthd", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "MngMethod", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "MngMethod", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "MngMethod", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "InvntryUom", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "EvalSystem", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "ByWH", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "PlaningSys", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "PrcrmntMtd", "0", RegexOptions.IgnoreCase);
            //2
            tmp = Regex.Replace(tmp, "OrdrIntrvl", "1", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "OrdrMulti", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "MinOrdrQty", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "LeadTime", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "validFor", "0", RegexOptions.IgnoreCase);
            //if space to space will no change.must be nil=true.
            tmp = Regex.Replace(tmp, "validFrom", "9", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "validTo", "9", RegexOptions.IgnoreCase);

            tmp = Regex.Replace(tmp, "ValidComm", "0", RegexOptions.IgnoreCase);

            tmp = Regex.Replace(tmp, "frozenFor", "0", RegexOptions.IgnoreCase);

            //if space to space will no change.must be nil=true.
            tmp = Regex.Replace(tmp, "frozenFrom", "9", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "frozenTo", "9", RegexOptions.IgnoreCase);

            tmp = Regex.Replace(tmp, "FrozenComm", "0", RegexOptions.IgnoreCase);

            tmp = Regex.Replace(tmp, "ShipType", "1", RegexOptions.IgnoreCase);
            if (tmp.Contains("QryGroup"))
                tmp = "0";

            if (tmp.Contains("U_"))
                tmp = "0";

            //tx01.Text = tmp;
            //Clipboard.SetData(DataFormats.Text,tx01.Text );
            return tmp;

        }



        public static string GetXMLFld_Item(string tmp)
        {
            //string tmp = tx01.Text;
            //tmp = Regex.Replace(tmp, "", "", RegexOptions.IgnoreCase);

            tmp = Regex.Replace(tmp, "avgprice", FldToXLS(path_bp_head, "AvgStdPrice"), RegexOptions.IgnoreCase);

            //YFY default X0
            tmp = Regex.Replace(tmp, "VatGoupSa", "SalesVATGroup", RegexOptions.IgnoreCase);
            //YFY default J0
            tmp = Regex.Replace(tmp, "VatGroupPu", "PurchaseVATGroup", RegexOptions.IgnoreCase);

            tmp = Regex.Replace(tmp, "CodeBars", "BarCode", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "ItemCode", "ItemCode", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "ItemName", "ItemName", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "FrgnName", "ForeignName", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "ItmsGrpCod", "ItemsGroupCode", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Spec", "GTSItemSpec", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "PicturName", "Picture", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "PrchseItem", "PurchaseItem", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "SellItem", "SalesItem", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "InvntItem", "InventoryItem", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "AssetItem", "AssetItem", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "DfltWH", "DefaultWarehouse", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "preferVendor", "Mainsupplier", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "SWW", "SWW ", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "SuppCatNum", "SupplierCatalogNo", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "BuyUnitMsr", "PurchaseUnit", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "NumInBuy", "PurchaseItemsPerUnit", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "MinLevel", "MinInventory", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "SalUnitMsr", "SalesUnit", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "NumInSale", "SalesItemsPerUnit", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "UserText", "User_Text", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "SHeight1", "SalesUnitHeight", RegexOptions.IgnoreCase);

            tmp = Regex.Replace(tmp, "SHght1Unit", "SalesHeightUnit", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "SHeight2", "SalesUnitHeight1", RegexOptions.IgnoreCase);

            tmp = Regex.Replace(tmp, "SHght2Unit", "SalesHeightUnit1", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "SWidth1", "SalesUnitWidth", RegexOptions.IgnoreCase);

            tmp = Regex.Replace(tmp, "SWdth1Unit", "SalesWidthUnit", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "SWidth2", "SalesUnitWidth1", RegexOptions.IgnoreCase);

            tmp = Regex.Replace(tmp, "SWdth2Unit", "SalesWidthUnit1", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "SLength1", "SalesUnitLength", RegexOptions.IgnoreCase);

            tmp = Regex.Replace(tmp, "SLen1Unit", "SalesLengthUnit", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Slength2", "SalesUnitLength1", RegexOptions.IgnoreCase);

            tmp = Regex.Replace(tmp, "SLen2Unit", "SalesLengthUnit1", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "SVolume", "SalesUnitVolume", RegexOptions.IgnoreCase);

            tmp = Regex.Replace(tmp, "SVolUnit", "SalesVolumeUnit", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "SWeight1", "SalesUnitWeight", RegexOptions.IgnoreCase);

            tmp = Regex.Replace(tmp, "SWght1Unit", "SalesWeightUnit", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "SWeight2", "SalesUnitWeight1", RegexOptions.IgnoreCase);

            tmp = Regex.Replace(tmp, "SWght2Unit", "SalesWeightUnit1", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "BHeight1", "PurchaseUnitHeight", RegexOptions.IgnoreCase);

            tmp = Regex.Replace(tmp, "BHght1Unit", "PurchaseHeightUnit", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "BHeight2", "PurchaseUnitHeight1", RegexOptions.IgnoreCase);

            tmp = Regex.Replace(tmp, "BHght2Unit", "PurchaseHeightUnit1", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "BWidth1", "PurchaseUnitWidth", RegexOptions.IgnoreCase);

            tmp = Regex.Replace(tmp, "BWdth1Unit", "PurchaseWidthUnit", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "BWidth2", "PurchaseUnitWidth1", RegexOptions.IgnoreCase);

            tmp = Regex.Replace(tmp, "BWdth2Unit", "PurchaseWidthUnit1", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "BLength1", "PurchaseUnitLength", RegexOptions.IgnoreCase);

            tmp = Regex.Replace(tmp, "BLen1Unit", "PurchaseLengthUnit", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Blength2", "PurchaseUnitLength1", RegexOptions.IgnoreCase);

            tmp = Regex.Replace(tmp, "BLen2Unit", "PurchaseLengthUnit1", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "BVolume", "PurchaseUnitVolume", RegexOptions.IgnoreCase);

            tmp = Regex.Replace(tmp, "BVolUnit", "PurchaseVolumeUnit", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "BWeight1", "PurchaseUnitWeight", RegexOptions.IgnoreCase);

            tmp = Regex.Replace(tmp, "BWght1Unit", "PurchaseWeightUnit", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "BWeight2", "PurchaseUnitWeight1", RegexOptions.IgnoreCase);

            tmp = Regex.Replace(tmp, "BWght2Unit", "PurchaseWeightUnit1", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "PurPackMsr", "PurchaseQtyPerPackUnit", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "PurPackUn", "PurchasePackagingUnit", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "SalPackMsr", "SalesQtyPerPackUnit", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "SalPackUn", "SalesPackagingUnit", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "GLMethod", "GLMethod", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Phantom", "IsPhantom", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "IssueMthd", "IssueMethod", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "MngMethod", "ManageSerialNumbers", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "MngMethod", "ManageBatchNumbers", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "MngMethod", "SRIAndBatchManageMethod", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "InvntryUom", "InventoryUOM", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "EvalSystem", "CostAccountingMethod", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "ByWH", "ManageStockByWarehouse", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "PlaningSys", "PlanningSystem", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "PrcrmntMtd", "ProcurementMethod", RegexOptions.IgnoreCase);
            //2
            tmp = Regex.Replace(tmp, "OrdrIntrvl", "OrderIntervals", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "OrdrMulti", "OrderMultiple", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "MinOrdrQty", "MinOrderQuantity", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "LeadTime", "LeadTime", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "validFor", "Valid", RegexOptions.IgnoreCase);
            //if space to space will no change.must be nil=true.
            tmp = Regex.Replace(tmp, "validFrom", "ValidFrom", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "validTo", "ValidTo", RegexOptions.IgnoreCase);

            tmp = Regex.Replace(tmp, "ValidComm", "ValidRemarks", RegexOptions.IgnoreCase);

            tmp = Regex.Replace(tmp, "frozenFor", "Frozen", RegexOptions.IgnoreCase);

            //if space to space will no change.must be nil=true.
            tmp = Regex.Replace(tmp, "frozenFrom", "FrozenFrom", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "frozenTo", "FrozenTo", RegexOptions.IgnoreCase);


            tmp = Regex.Replace(tmp, "FrozenComm", "FrozenRemarks", RegexOptions.IgnoreCase);

            tmp = Regex.Replace(tmp, "ShipType", "ShipType", RegexOptions.IgnoreCase);

            tmp = Regex.Replace(tmp, "QryGroup", "Properties", RegexOptions.IgnoreCase);


            return tmp;
        }

        #endregion

        #region bp
        //public static string path_bp_head = "BOM/BO/BusinessPartners/row/";

        public static string gettype_BP(string tmp)
        {
            //string tmp =  tx01.Text;
            //tmp = Regex.Replace(tmp, "", "", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "", "", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "CardCode", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "CardName", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "CardType", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "GroupCode", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Phone1", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Phone2", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Fax", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Notes", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Currency", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Cellular", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "LicTradNum", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "AddID", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Properties1", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Properties2", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Properties3", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Properties4", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Properties5", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Properties6", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Properties7", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "AddID", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Name", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Position", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Address", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Tel1", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Tel2", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Cellolar", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Fax", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "E_MailL", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Notes1", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Notes2", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Password", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "BirthPlace", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "BirthDate", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Gender", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Profession", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Title", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "BirthCity", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Active", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "FirstName", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "MiddleName", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "LastName", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "AddressType", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Address", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Street", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Block", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "ZipCode", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "City", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "County", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Country", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "State", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Address2", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Address3", "0", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "StreetNo", "0", RegexOptions.IgnoreCase);
            //1
            tmp = Regex.Replace(tmp, "validFor", "9", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "validFrom", "9", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "validTo", "9", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "ValidComm", "9", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "frozenFor", "9", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "frozenFrom", "9", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "frozenTo", "9", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "FrozenComm", "9", RegexOptions.IgnoreCase);


            tmp = Regex.Replace(tmp, "ShippingType", "1", RegexOptions.IgnoreCase);
            //tx01.Text = tmp;
            //Clipboard.SetData(DataFormats.Text, tx01.Text);
            return tmp;
        }
        public static string GetXMLFld_BP(string tmp)
        {
            //string tmp = tx01.Text;
            //tmp = Regex.Replace(tmp, "", "", RegexOptions.IgnoreCase); 

            //head
            tmp = Regex.Replace(tmp, "CardCode", "CardCode", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "CardName", "CardName", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "CardFName", "CardForeignName", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "E_Mail", "EmailAddress", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Building", "BillToBuildingFloorRoom", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "CardType", "CardType", RegexOptions.IgnoreCase);


            tmp = Regex.Replace(tmp, "GroupCode", "GroupCode", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Phone1", "Phone1", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Phone2", "Phone2", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Fax", "Fax", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Notes", "Notes", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Currency", "Currency", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Cellular", "Cellular", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "LicTradNum", "FederalTaxID", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "AddID", "AdditionalID", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Properties1", "Properties1", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Properties2", "Properties2", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Properties3", "Properties3", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Properties4", "Properties4", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Properties5", "Properties5", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Properties6", "Properties6", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Properties7", "Properties7", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "AddID", "AdditionalID", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Name", "Name", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Position", "Position", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Address", "Address", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Tel1", "Phone1", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Tel2", "Phone2", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Cellolar", "MobilePhone", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Fax", "Fax", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "E_MailL", "E_Mail", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Notes1", "Remarks1", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Notes2", "Remarks2", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Password", "Password", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "BirthPlace", "PlaceOfBirth", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "BirthDate", "DateOfBirth", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Gender", "Gender", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Profession", "Profession", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Title", "Title", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "BirthCity", "CityOfBirth", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Active", "Active", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "FirstName", "FirstName", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "MiddleName", "MiddleName", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "LastName", "LastName", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "AddressType", "AddressType", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Address", "AddressName", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Street", "Street", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Block", "Block", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "ZipCode", "ZipCode", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "City", "City", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "County", "County", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Country", "Country", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "State", "State", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Address2", "AddressName2", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "Address3", "AddressName3", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "StreetNo", "StreetNo", RegexOptions.IgnoreCase);
            //1
            tmp = Regex.Replace(tmp, "validFor", "Valid", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "validFrom", "ValidFrom", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "validTo", "ValidTo", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "ValidComm", "ValidRemarks", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "frozenFor", "Frozen", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "frozenFrom", "FrozenFrom", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "frozenTo", "FrozenTo", RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "FrozenComm", "FrozenRemarks", RegexOptions.IgnoreCase);


            tmp = Regex.Replace(tmp, "ShippingType", "ShippingType", RegexOptions.IgnoreCase);
            //tx01.Text = tmp;
            //Clipboard.SetData(DataFormats.Text, tx01.Text);
            return tmp;
        }
        public static string GetXMLFld_BP_OCPR(string tmp)
        {
            tmp = Regex.Replace(tmp, "Cellular", "MobilePhone", RegexOptions.IgnoreCase);
            return tmp;
        }
        #endregion

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
        private void button10_Click(object sender, EventArgs e)
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
        }
        //string tmp = tx01.Text;
        //    tx01.Text = tmp;
        private void button11_Click(object sender, EventArgs e)
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

        private void button13_Click(object sender, EventArgs e)
        {
            string tmp = tx01.Text;
            tmp = Regex.Replace(tmp, "CardCode", FldToXLS(path_bp_head, "ParentKey"), RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "LineNum", FldToXLS(path_bp_head, "LineNum"), RegexOptions.IgnoreCase);
            tmp = Regex.Replace(tmp, "PaymentMethodCode", FldToXLS(path_bp_head, "PaymentMethodCode"), RegexOptions.IgnoreCase);

            tx01.Text = tmp;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            string tmp = tx01.Text;
            tmp = Door(tmp, "CardCode", "ParentKey");
            tmp = Door(tmp, "LineNum", "LineNum");
            tmp = Door(tmp, "AccountCode", "AccountCode");
            tmp = Door(tmp, "AccountType", "AccountType");


            tx01.Text = tmp;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            string tmp = tx01.Text;
            tmp = Door(tmp, "CardCode", "ParentKey");
            tmp = Door(tmp, "LineNum", "LineNum");
            tmp = Door(tmp, "PaymentDate", "PaymentDate");

            tx01.Text = tmp;
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
        }

        private void button21_Click(object sender, EventArgs e)
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
        }

        private void button45_Click(object sender, EventArgs e)
        {
            string tmp = tx01.Text;
            tx01.Text = tmp;
        }

        private void button44_Click(object sender, EventArgs e)
        {
            string tmp = tx01.Text;
            tx01.Text = tmp;
        }

        private void button43_Click(object sender, EventArgs e)
        {
            string tmp = tx01.Text;
            tx01.Text = tmp;
        }

        private void button42_Click(object sender, EventArgs e)
        {
            string tmp = tx01.Text;
            tx01.Text = tmp;
        }

        private void button41_Click(object sender, EventArgs e)
        {
            string tmp = tx01.Text;
            tx01.Text = tmp;
        }
    }
}
class colname
{
    public static string src = "col_src";
    public static string dest = "col_dest";
    public static string srcxml = "col_src_xml";
    public static string destxml = "col_dest_xml";
    public static string type = "col_type";
    public static string path = "col_path";
}