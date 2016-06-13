using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AP_C.v1
{
 
 
    public class OCRD : B1_Object
    {
        #region bp 
        string _XML_Path = "BOM/BO/BusinessPartners/row/";
        public string XML_Path
        {
            get { return _XML_Path; }
            set{_XML_Path=value ;}
        }
        public   string gettype(string tmp)
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
        public   string GetXMLFld(string tmp)
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
   
        #endregion
    }
}
