using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AP_C.v1
{
 
 
    public class doc : B1_Object
    { 
        #region doc
    public    string XML_Path
        {
            get;
            set;
        }
        public    string gettype(string tmp)
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
        public   string GetXMLFld(string tmp)
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
    }

   
}
