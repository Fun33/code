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
    public partial class B1iSN2 : Form
    {
        string path_doc_head = "BOM/BO/Documents/row/";
        string path_item_head = "BOM/BO/Items/row/";
        string path_bp_head = "BOM/BO/BusinessPartners/row/";

        #region access
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


        public B1iSN2(Main parent)
        {
            InitializeComponent();
                   this.MdiParent = parent;
                   this.WindowState = FormWindowState.Maximized;

  

        }

#region access
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
#endregion 
   
  
#region event
        
        private void Form2_Load(object sender, EventArgs e)
        {
            //Clipboard.SetData(DataFormats.Text, tb01.Text);
            tx_desc.Text = "1.fld of table mapping fld of xml" + Environment.NewLine;
            tx_desc.Text += "2.alert chk !=0" + Environment.NewLine;
            tx_desc.Text += "3.alert chk !=-1" + Environment.NewLine;
            tx_desc.Text += "4.alert chk !=''" + Environment.NewLine;
            //tx_desc.Text += "5.alert chk mapping" + Environment.NewLine;
 
        }
   
         
      
 

 

 

   
#endregion 




        #region bak

        private void BtnB1isnBP_Click(object sender, EventArgs e)
        {
            string tmp = "";// tx01.Text;
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
            //tx01.Text = tmp;
            //Clipboard.SetData(DataFormats.Text, tx01.Text);
        }
            //       string tmp = tb01.Text;
            ////tmp = Regex.Replace(tmp, "", "", RegexOptions.IgnoreCase);
            //tb01.Text = tmp;
            //Clipboard.SetData(DataFormats.Text, tx01.Text);
        private void BtnB1iSNDoc_Click(object sender, EventArgs e)
        {
            string tmp = "";// tx01.Text;
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
           

            //tx01.Text = tmp;
            //Clipboard.SetData(DataFormats.Text, tx01.Text);
        }

#endregion

      

      

       
    }
     
    } 