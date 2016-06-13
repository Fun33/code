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

namespace AP_C
{
    public partial class B1iSN : Form
    {
        string path_doc_head = "BOM/BO/Documents/row/";
        string path_item_head = "BOM/BO/Items/row/";
        string path_bp_head = "BOM/BO/BusinessPartners/row/";

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


        public B1iSN(Main parent)
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
        private string  FldToXLS(string path,string fld)
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
             System.IO.File.ReadAllText(@"d:\log"+DateTime.Now.ToString("yyyyMMdd")+".txt", System.Text.Encoding.Default);
            
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "notepad.exe";
            p.StartInfo.WorkingDirectory = @"c:\windows\system32\"; //你的记事本的路径
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.UseShellExecute = false;
            p.Start();
            Clipboard.SetData(DataFormats.Text, ret);

            MessageBox.Show(ret);
        }

        #region item

        //0-normal
        //1-if 0 no mapping.
        //2-if ''  no mapping
        //defalt
        //?
        //foreon if !-'' mapping else be max or be min
        //CA_XX
        private string gettype_item(string tmp)
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



        private string GetXMLFld_Item(string tmp)
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
        private string gettype_BP(string tmp)
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
        private string GetXMLFld_BP(string tmp)
        {
            //string tmp = tx01.Text;
            //tmp = Regex.Replace(tmp, "", "", RegexOptions.IgnoreCase); 
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

        #endregion

        #region doc
        private string gettype_doc(string tmp)
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
        private string GetXMLFld_doc(string tmp)
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
        private void GetType()
        {
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                string src = dataGridView1.Rows[i].Cells[colname.src].Value.ToString();
                string dest = dataGridView1.Rows[i].Cells[colname.dest].Value.ToString();
                switch (cb_Type.SelectedItem.ToString())
                {
                    case "Item":
                        dataGridView1.Rows[i].Cells[colname.type].Value = gettype_item(dest);
                        break;
                    case "BP":
                        dataGridView1.Rows[i].Cells[colname.type].Value = gettype_BP(dest);
                        break;
                    case "DOC":
                        dataGridView1.Rows[i].Cells[colname.type].Value = gettype_doc(dest);
                        break;
                }
            }
        }


        private void GetXMLFld()
        {
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                //如果不單純,這裡就要換成*
                string src = dataGridView1.Rows[i].Cells[colname.src].Value.ToString();
                string dest = dataGridView1.Rows[i].Cells[colname.dest].Value.ToString();
                switch (cb_Type.SelectedItem.ToString())
                {
                    case "Item":
                        dataGridView1.Rows[i].Cells[colname.srcxml].Value = GetXMLFld_Item(src);
                        dataGridView1.Rows[i].Cells[colname.destxml].Value = GetXMLFld_Item(dest);
                        break;
                    case "BP":
                        dataGridView1.Rows[i].Cells[colname.srcxml].Value = GetXMLFld_BP(src);
                        dataGridView1.Rows[i].Cells[colname.destxml].Value = GetXMLFld_BP(dest);
                        break;
                    case "DOC":
                        dataGridView1.Rows[i].Cells[colname.srcxml].Value = GetXMLFld_Item(src);
                        dataGridView1.Rows[i].Cells[colname.destxml].Value = GetXMLFld_Item(dest);
                        break;
                }
            }
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

        private void button4_Click_1(object sender, EventArgs e)
        {
            string ret = "";
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                string src = dataGridView1.Rows[i].Cells[colname.srcxml].Value.ToString();
                string dest = dataGridView1.Rows[i].Cells[colname.destxml].Value.ToString();
                string type = dataGridView1.Rows[i].Cells[colname.type].Value.ToString();
                string path = "BO/Items/row/";// path_item_head;
                if (type == "0")
                    ret += type0(path, src, dest);
                else if (type == "1")
                    ret += type1(src, path, dest, type0(path, src, dest));
                else if (type == "2")
                    ret += type2(src, path, dest, type0(path, src, dest));
                else if (type == "3")
                    ret += type3(src, path, dest, type0(path, src, dest));
                else if (type == "-1")
                    ret += typeNegative1(src, path, dest, type0(path, src, dest));
                else//default 0
                    ret += type0(path, src, dest);
            }

            Clipboard.SetData(DataFormats.Text, ret);
            string filename = @"d:\log" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
            System.IO.File.WriteAllText(filename, ret);
            System.Diagnostics.Process.Start(filename);
            return;
            System.IO.File.ReadAllText(@"d:\log" + DateTime.Now.ToString("yyyyMMdd") + ".txt", System.Text.Encoding.Default);

            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "notepad.exe";
            p.StartInfo.WorkingDirectory = @"c:\windows\system32\"; //你的记事本的路径
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.UseShellExecute = false;
            p.Start();
            Clipboard.SetData(DataFormats.Text, ret);

            MessageBox.Show(ret);
        }

        private void GetTypeNGetXMLFld_Click(object sender, EventArgs e)
        {
            if (cb_Type.SelectedItem == "")
            {
                MessageBox.Show("Choose Type,please!!");
                return;
            }
            GetType();
            GetXMLFld();
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