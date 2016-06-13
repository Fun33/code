using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AP_C.v1
{
    interface B1_Object
    {
        string XML_Path
        {
            get;
            set;
        }
        string gettype(string tmp);
        string GetXMLFld(string tmp);
    }
    public class father
    {
        public static string FldToXLS(string path, string fld)
        {
            string ret = @"<{1}><xsl:value-of select=""{0}{1}""/></{1}>";
            ret = string.Format(ret, path, fld);
            return ret;
        }
        public static string GetPath(string tablename)
        {
            string ret = "";
            switch (tablename)
            {
                case "OITM":
                    ret = "BOM/BO/Items/row/";
                    break;
                case "OCRD":
                    ret = "BOM/BO/BusinessPartners/row/";
                    break;
                case "OCPR":
                    ret = "BOM/BO/ContactEmployees/row/";
                    break;
                case "doc":
                    ret = "BOM/BO/Documents/row/";
                    break;
                case "docline":
                    ret = "BOM/BO/Document_Lines/row/";
                    break;
                case "db":
                    ret = "BOM/BO/Document_Lines/row/";
                    break;
                default:
                    ret = "BOM/BO/Documents/row/";
                    break;
            }
            return ret;
        }
    }
    //public class doc : B1_Object
    //{
    //    #region doc
    //    public string XML_Path
    //    {
    //        get;
    //        set;
    //    }
    //    public string gettype(string tmp)
    //    {
    //        //string tmp = tx01.Text;
    //        //tmp = Regex.Replace(tmp, "", "", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "NumAtCard", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "CANCELED", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "DocDate", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "DocDueDate", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "CardCode", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "Address", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "DiscPrcnt", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "DocCur", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "DocRate", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "Comments", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "JrnlMemo", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "TaxDate", "0", RegexOptions.IgnoreCase);

    //        tmp = Regex.Replace(tmp, "Address2", "2", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "ShipToCode", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "Rounding", "0", RegexOptions.IgnoreCase);

    //        tmp = Regex.Replace(tmp, "CancelDate", "2", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "VatDate", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "ItemCode", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "Dscription", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "Quantity", "0", RegexOptions.IgnoreCase);

    //        tmp = Regex.Replace(tmp, "ShipDate", "2", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "Price", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "DiscPrcnt", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "WhsCode", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "BaseLineNumber", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "BatchNumber", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "LotNumber", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "Quantity", "0", RegexOptions.IgnoreCase);

    //        tmp = Regex.Replace(tmp, "MnfSerial", "9", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "ExpDate", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "MnfDate", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "Location", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "Notes", "0", RegexOptions.IgnoreCase);

    //        tmp = Regex.Replace(tmp, "Weight1Unit", "1", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "Hight1Unit", "1", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "Height1", "1", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "Lengh1Unit", "1", RegexOptions.IgnoreCase);

    //        tmp = Regex.Replace(tmp, "Lengh1", "1", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "VolumeUnit", "1", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "Volume", "1", RegexOptions.IgnoreCase);

    //        tmp = Regex.Replace(tmp, "PaymentGroupCode", "-1", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "TransportationCode", "-1", RegexOptions.IgnoreCase);

    //        tmp = Regex.Replace(tmp, "Volume", "1", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "VolumeUnit", "1", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "Volume", "1", RegexOptions.IgnoreCase);


    //        //tx01.Text = tmp;
    //        //Clipboard.SetData(DataFormats.Text, tx01.Text);
    //        return tmp;
    //    }
    //    public string GetXMLFld(string tmp)
    //    {
    //        //string tmp = tx01.Text;
    //        //tmp = Regex.Replace(tmp, "", "", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "NumAtCard", "NumAtCard", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "CANCELED", "Cancelled", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "DocDate", "DocDate", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "DocDueDate", "DocDueDate", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "CardCode", "CardCode", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "Address", "Address", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "DiscPrcnt", "DiscountPercent", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "DocCur", "DocCurrency", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "DocRate", "DocRate", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "Comments", "Comments", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "JrnlMemo", "JournalMemo", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "TaxDate", "TaxDate", RegexOptions.IgnoreCase);

    //        tmp = Regex.Replace(tmp, "Address2", "Address2", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "ShipToCode", "ShipToCode", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "Rounding", "Rounding", RegexOptions.IgnoreCase);

    //        tmp = Regex.Replace(tmp, "CancelDate", "CancelDate", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "VatDate", "VatDate", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "ItemCode", "ItemCode", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "Dscription", "ItemDescription", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "Quantity", "Quantity", RegexOptions.IgnoreCase);

    //        tmp = Regex.Replace(tmp, "ShipDate", "ShipDate", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "Price", "Price", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "DiscPrcnt", "DiscountPercent", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "WhsCode", "WarehouseCode", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "BaseLineNumber", "BaseLineNumber", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "BatchNumber", "BatchNumber", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "LotNumber", "InternalSerialNumber", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "Quantity", "Quantity", RegexOptions.IgnoreCase);

    //        tmp = Regex.Replace(tmp, "MnfSerial",
    //            "<--chk!=&apos;&apos;  ManufacturerSerialNumber-->" + Environment.NewLine +
    //            "<--chk=&apos;&apos;  InternalSerialNumber-->" + Environment.NewLine +
    //            "ManufacturerSerialNumber", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "ExpDate", "ExpiryDate", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "MnfDate", "ManufacturingDate", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "Location", "Location", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "Notes", "Notes", RegexOptions.IgnoreCase);

    //        tmp = Regex.Replace(tmp, "Weight1Unit", "Weight1Unit", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "Hight1Unit", "Hight1Unit", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "Height1", "Height1", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "Lengh1Unit", "Lengh1Unit", RegexOptions.IgnoreCase);

    //        tmp = Regex.Replace(tmp, "Lengh1", "Lengh1", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "VolumeUnit", "VolumeUnit", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "Volume", "Volume", RegexOptions.IgnoreCase);

    //        tmp = Regex.Replace(tmp, "PaymentGroupCode", "PaymentGroupCode", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "TransportationCode", "TransportationCode", RegexOptions.IgnoreCase);

    //        tmp = Regex.Replace(tmp, "Volume", "Volume", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "VolumeUnit", "VolumeUnit", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "Volume", "Volume", RegexOptions.IgnoreCase);


    //        //tx01.Text = tmp;
    //        //Clipboard.SetData(DataFormats.Text, tx01.Text);
    //        return tmp;
    //    }
    //    #endregion
    //}

    //public class OITM : B1_Object
    //{


    //    #region item
    //    public string XML_Path
    //    {
    //        get;
    //        set;
    //    }
    //    //0-normal
    //    //1-if 0 no mapping.
    //    //2-if ''  no mapping
    //    //defalt
    //    //?
    //    //foreon if !-'' mapping else be max or be min
    //    //CA_XX
    //    public string gettype(string tmp)
    //    {

    //        //tmp = Regex.Replace(tmp, "", "", RegexOptions.IgnoreCase);



    //        //YFY default X0
    //        tmp = Regex.Replace(tmp, "VatGoupSa", "0", RegexOptions.IgnoreCase);
    //        //YFY default J0
    //        tmp = Regex.Replace(tmp, "VatGroupPu", "0", RegexOptions.IgnoreCase);

    //        tmp = Regex.Replace(tmp, "AvgPrice", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "Attachment", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "ItemType", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "CodeBars", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "ItemCode", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "ItemName", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "FrgnName", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "ItmsGrpCod", "1", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "Spec", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "PicturName", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "PrchseItem", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "SellItem", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "InvntItem", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "AssetItem", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "DfltWH", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "preferVendor", "2", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "SWW", "0 ", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "SuppCatNum", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "BuyUnitMsr", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "NumInBuy", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "MinLevel", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "SalUnitMsr", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "NumInSale", "1", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "UserText", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "SHeight1", "0", RegexOptions.IgnoreCase);

    //        tmp = Regex.Replace(tmp, "SHght1Unit", "1", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "SHeight2", "0", RegexOptions.IgnoreCase);

    //        tmp = Regex.Replace(tmp, "SHght2Unit", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "SWidth1", "0", RegexOptions.IgnoreCase);

    //        tmp = Regex.Replace(tmp, "SWdth1Unit", "1", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "SWidth2", "0", RegexOptions.IgnoreCase);

    //        tmp = Regex.Replace(tmp, "SWdth2Unit", "1", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "SLength1", "0", RegexOptions.IgnoreCase);

    //        tmp = Regex.Replace(tmp, "SLen1Unit", "1", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "Slength2", "0", RegexOptions.IgnoreCase);

    //        tmp = Regex.Replace(tmp, "SLen2Unit", "1", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "SVolume", "0", RegexOptions.IgnoreCase);

    //        tmp = Regex.Replace(tmp, "SVolUnit", "1", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "SWeight1", "0", RegexOptions.IgnoreCase);

    //        tmp = Regex.Replace(tmp, "SWght1Unit", "1", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "SWeight2", "0", RegexOptions.IgnoreCase);

    //        tmp = Regex.Replace(tmp, "SWght2Unit", "1", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "BHeight1", "0", RegexOptions.IgnoreCase);

    //        tmp = Regex.Replace(tmp, "BHght1Unit", "1", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "BHeight2", "0", RegexOptions.IgnoreCase);

    //        tmp = Regex.Replace(tmp, "BHght2Unit", "1", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "BWidth1", "0", RegexOptions.IgnoreCase);

    //        tmp = Regex.Replace(tmp, "BWdth1Unit", "1", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "BWidth2", "0", RegexOptions.IgnoreCase);

    //        tmp = Regex.Replace(tmp, "BWdth2Unit", "1", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "BLength1", "0", RegexOptions.IgnoreCase);

    //        tmp = Regex.Replace(tmp, "BLen1Unit", "1", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "Blength2", "0", RegexOptions.IgnoreCase);

    //        tmp = Regex.Replace(tmp, "BLen2Unit", "1", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "BVolume", "0", RegexOptions.IgnoreCase);

    //        tmp = Regex.Replace(tmp, "BVolUnit", "1", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "BWeight1", "0", RegexOptions.IgnoreCase);

    //        tmp = Regex.Replace(tmp, "BWght1Unit", "1", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "BWeight2", "0", RegexOptions.IgnoreCase);

    //        tmp = Regex.Replace(tmp, "BWght2Unit", "1", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "PurPackMsr", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "PurPackUn", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "SalPackMsr", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "SalPackUn", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "GLMethod", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "Phantom", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "IssueMthd", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "MngMethod", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "MngMethod", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "MngMethod", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "InvntryUom", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "EvalSystem", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "ByWH", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "PlaningSys", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "PrcrmntMtd", "0", RegexOptions.IgnoreCase);
    //        //2
    //        tmp = Regex.Replace(tmp, "OrdrIntrvl", "1", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "OrdrMulti", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "MinOrdrQty", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "LeadTime", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "validFor", "0", RegexOptions.IgnoreCase);
    //        //if space to space will no change.must be nil=true.
    //        tmp = Regex.Replace(tmp, "validFrom", "9", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "validTo", "9", RegexOptions.IgnoreCase);

    //        tmp = Regex.Replace(tmp, "ValidComm", "0", RegexOptions.IgnoreCase);

    //        tmp = Regex.Replace(tmp, "frozenFor", "0", RegexOptions.IgnoreCase);

    //        //if space to space will no change.must be nil=true.
    //        tmp = Regex.Replace(tmp, "frozenFrom", "9", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "frozenTo", "9", RegexOptions.IgnoreCase);

    //        tmp = Regex.Replace(tmp, "FrozenComm", "0", RegexOptions.IgnoreCase);

    //        tmp = Regex.Replace(tmp, "ShipType", "1", RegexOptions.IgnoreCase);
    //        if (tmp.Contains("QryGroup"))
    //            tmp = "0";

    //        if (tmp.Contains("U_"))
    //            tmp = "0";

    //        //tx01.Text = tmp;
    //        //Clipboard.SetData(DataFormats.Text,tx01.Text );
    //        return tmp;

    //    }



    //    public string GetXMLFld(string tmp)
    //    {
    //        //string tmp = tx01.Text;
    //        //tmp = Regex.Replace(tmp, "", "", RegexOptions.IgnoreCase);

    //        //??Item中怎麼會有BP的path
    //        //tmp = Regex.Replace(tmp, "avgprice", FldToXLS(path_bp_head, "AvgStdPrice"), RegexOptions.IgnoreCase);

    //        //YFY default X0
    //        tmp = Regex.Replace(tmp, "VatGoupSa", "SalesVATGroup", RegexOptions.IgnoreCase);
    //        //YFY default J0
    //        tmp = Regex.Replace(tmp, "VatGroupPu", "PurchaseVATGroup", RegexOptions.IgnoreCase);

    //        tmp = Regex.Replace(tmp, "CodeBars", "BarCode", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "ItemCode", "ItemCode", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "ItemName", "ItemName", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "FrgnName", "ForeignName", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "ItmsGrpCod", "ItemsGroupCode", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "Spec", "GTSItemSpec", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "PicturName", "Picture", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "PrchseItem", "PurchaseItem", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "SellItem", "SalesItem", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "InvntItem", "InventoryItem", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "AssetItem", "AssetItem", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "DfltWH", "DefaultWarehouse", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "preferVendor", "Mainsupplier", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "SWW", "SWW ", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "SuppCatNum", "SupplierCatalogNo", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "BuyUnitMsr", "PurchaseUnit", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "NumInBuy", "PurchaseItemsPerUnit", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "MinLevel", "MinInventory", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "SalUnitMsr", "SalesUnit", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "NumInSale", "SalesItemsPerUnit", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "UserText", "User_Text", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "SHeight1", "SalesUnitHeight", RegexOptions.IgnoreCase);

    //        tmp = Regex.Replace(tmp, "SHght1Unit", "SalesHeightUnit", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "SHeight2", "SalesUnitHeight1", RegexOptions.IgnoreCase);

    //        tmp = Regex.Replace(tmp, "SHght2Unit", "SalesHeightUnit1", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "SWidth1", "SalesUnitWidth", RegexOptions.IgnoreCase);

    //        tmp = Regex.Replace(tmp, "SWdth1Unit", "SalesWidthUnit", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "SWidth2", "SalesUnitWidth1", RegexOptions.IgnoreCase);

    //        tmp = Regex.Replace(tmp, "SWdth2Unit", "SalesWidthUnit1", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "SLength1", "SalesUnitLength", RegexOptions.IgnoreCase);

    //        tmp = Regex.Replace(tmp, "SLen1Unit", "SalesLengthUnit", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "Slength2", "SalesUnitLength1", RegexOptions.IgnoreCase);

    //        tmp = Regex.Replace(tmp, "SLen2Unit", "SalesLengthUnit1", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "SVolume", "SalesUnitVolume", RegexOptions.IgnoreCase);

    //        tmp = Regex.Replace(tmp, "SVolUnit", "SalesVolumeUnit", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "SWeight1", "SalesUnitWeight", RegexOptions.IgnoreCase);

    //        tmp = Regex.Replace(tmp, "SWght1Unit", "SalesWeightUnit", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "SWeight2", "SalesUnitWeight1", RegexOptions.IgnoreCase);

    //        tmp = Regex.Replace(tmp, "SWght2Unit", "SalesWeightUnit1", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "BHeight1", "PurchaseUnitHeight", RegexOptions.IgnoreCase);

    //        tmp = Regex.Replace(tmp, "BHght1Unit", "PurchaseHeightUnit", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "BHeight2", "PurchaseUnitHeight1", RegexOptions.IgnoreCase);

    //        tmp = Regex.Replace(tmp, "BHght2Unit", "PurchaseHeightUnit1", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "BWidth1", "PurchaseUnitWidth", RegexOptions.IgnoreCase);

    //        tmp = Regex.Replace(tmp, "BWdth1Unit", "PurchaseWidthUnit", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "BWidth2", "PurchaseUnitWidth1", RegexOptions.IgnoreCase);

    //        tmp = Regex.Replace(tmp, "BWdth2Unit", "PurchaseWidthUnit1", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "BLength1", "PurchaseUnitLength", RegexOptions.IgnoreCase);

    //        tmp = Regex.Replace(tmp, "BLen1Unit", "PurchaseLengthUnit", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "Blength2", "PurchaseUnitLength1", RegexOptions.IgnoreCase);

    //        tmp = Regex.Replace(tmp, "BLen2Unit", "PurchaseLengthUnit1", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "BVolume", "PurchaseUnitVolume", RegexOptions.IgnoreCase);

    //        tmp = Regex.Replace(tmp, "BVolUnit", "PurchaseVolumeUnit", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "BWeight1", "PurchaseUnitWeight", RegexOptions.IgnoreCase);

    //        tmp = Regex.Replace(tmp, "BWght1Unit", "PurchaseWeightUnit", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "BWeight2", "PurchaseUnitWeight1", RegexOptions.IgnoreCase);

    //        tmp = Regex.Replace(tmp, "BWght2Unit", "PurchaseWeightUnit1", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "PurPackMsr", "PurchaseQtyPerPackUnit", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "PurPackUn", "PurchasePackagingUnit", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "SalPackMsr", "SalesQtyPerPackUnit", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "SalPackUn", "SalesPackagingUnit", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "GLMethod", "GLMethod", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "Phantom", "IsPhantom", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "IssueMthd", "IssueMethod", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "MngMethod", "ManageSerialNumbers", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "MngMethod", "ManageBatchNumbers", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "MngMethod", "SRIAndBatchManageMethod", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "InvntryUom", "InventoryUOM", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "EvalSystem", "CostAccountingMethod", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "ByWH", "ManageStockByWarehouse", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "PlaningSys", "PlanningSystem", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "PrcrmntMtd", "ProcurementMethod", RegexOptions.IgnoreCase);
    //        //2
    //        tmp = Regex.Replace(tmp, "OrdrIntrvl", "OrderIntervals", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "OrdrMulti", "OrderMultiple", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "MinOrdrQty", "MinOrderQuantity", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "LeadTime", "LeadTime", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "validFor", "Valid", RegexOptions.IgnoreCase);
    //        //if space to space will no change.must be nil=true.
    //        tmp = Regex.Replace(tmp, "validFrom", "ValidFrom", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "validTo", "ValidTo", RegexOptions.IgnoreCase);

    //        tmp = Regex.Replace(tmp, "ValidComm", "ValidRemarks", RegexOptions.IgnoreCase);

    //        tmp = Regex.Replace(tmp, "frozenFor", "Frozen", RegexOptions.IgnoreCase);

    //        //if space to space will no change.must be nil=true.
    //        tmp = Regex.Replace(tmp, "frozenFrom", "FrozenFrom", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "frozenTo", "FrozenTo", RegexOptions.IgnoreCase);


    //        tmp = Regex.Replace(tmp, "FrozenComm", "FrozenRemarks", RegexOptions.IgnoreCase);

    //        tmp = Regex.Replace(tmp, "ShipType", "ShipType", RegexOptions.IgnoreCase);

    //        tmp = Regex.Replace(tmp, "QryGroup", "Properties", RegexOptions.IgnoreCase);


    //        return tmp;
    //    }

    //    #endregion
    //}
    //public class OCPR : B1_Object
    //{
    //    public string XML_Path
    //    {
    //        get;
    //        set;
    //    }
    //    public string gettype(string tmp)
    //    {
    //        return "";
    //    }
    //    public string GetXMLFld(string tmp)
    //    {
    //        tmp = Regex.Replace(tmp, "Cellular", "MobilePhone", RegexOptions.IgnoreCase);

    //        tmp = Regex.Replace(tmp, "BirthPlace", "PlaceOfBirth", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "address", "Address", RegexOptions.IgnoreCase);

    //        tmp = Regex.Replace(tmp, "CardCode", "CardCode", RegexOptions.IgnoreCase);

    //        return tmp;
    //    }



    //}
    //public class OCRD : B1_Object
    //{
    //    #region bp
    //    string _XML_Path = "BOM/BO/BusinessPartners/row/";
    //    public string XML_Path
    //    {
    //        get { return _XML_Path; }
    //        set { _XML_Path = value; }
    //    }
    //    public string gettype(string tmp)
    //    {
    //        //string tmp =  tx01.Text;
    //        //tmp = Regex.Replace(tmp, "", "", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "", "", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "CardCode", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "CardName", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "CardType", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "GroupCode", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "Phone1", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "Phone2", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "Fax", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "Notes", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "Currency", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "Cellular", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "LicTradNum", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "AddID", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "Properties1", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "Properties2", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "Properties3", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "Properties4", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "Properties5", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "Properties6", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "Properties7", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "AddID", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "Name", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "Position", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "Address", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "Tel1", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "Tel2", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "Cellolar", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "Fax", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "E_MailL", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "Notes1", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "Notes2", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "Password", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "BirthPlace", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "BirthDate", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "Gender", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "Profession", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "Title", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "BirthCity", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "Active", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "FirstName", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "MiddleName", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "LastName", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "AddressType", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "Address", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "Street", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "Block", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "ZipCode", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "City", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "County", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "Country", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "State", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "Address2", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "Address3", "0", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "StreetNo", "0", RegexOptions.IgnoreCase);
    //        //1
    //        tmp = Regex.Replace(tmp, "validFor", "9", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "validFrom", "9", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "validTo", "9", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "ValidComm", "9", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "frozenFor", "9", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "frozenFrom", "9", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "frozenTo", "9", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "FrozenComm", "9", RegexOptions.IgnoreCase);


    //        tmp = Regex.Replace(tmp, "ShippingType", "1", RegexOptions.IgnoreCase);
    //        //tx01.Text = tmp;
    //        //Clipboard.SetData(DataFormats.Text, tx01.Text);
    //        return tmp;
    //    }
    //    public string GetXMLFld(string tmp)
    //    {
    //        //string tmp = tx01.Text;
    //        //tmp = Regex.Replace(tmp, "", "", RegexOptions.IgnoreCase); 

    //        //head
    //        tmp = Regex.Replace(tmp, "CardCode", "CardCode", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "CardName", "CardName", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "CardFName", "CardForeignName", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "E_Mail", "EmailAddress", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "Building", "BillToBuildingFloorRoom", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "CardType", "CardType", RegexOptions.IgnoreCase);


    //        tmp = Regex.Replace(tmp, "GroupCode", "GroupCode", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "Phone1", "Phone1", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "Phone2", "Phone2", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "Fax", "Fax", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "Notes", "Notes", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "Currency", "Currency", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "Cellular", "Cellular", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "LicTradNum", "FederalTaxID", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "AddID", "AdditionalID", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "Properties1", "Properties1", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "Properties2", "Properties2", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "Properties3", "Properties3", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "Properties4", "Properties4", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "Properties5", "Properties5", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "Properties6", "Properties6", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "Properties7", "Properties7", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "AddID", "AdditionalID", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "Name", "Name", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "Position", "Position", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "Address", "Address", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "Tel1", "Phone1", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "Tel2", "Phone2", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "Cellolar", "MobilePhone", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "Fax", "Fax", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "E_MailL", "E_Mail", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "Notes1", "Remarks1", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "Notes2", "Remarks2", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "Password", "Password", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "BirthPlace", "PlaceOfBirth", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "BirthDate", "DateOfBirth", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "Gender", "Gender", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "Profession", "Profession", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "Title", "Title", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "BirthCity", "CityOfBirth", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "Active", "Active", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "FirstName", "FirstName", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "MiddleName", "MiddleName", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "LastName", "LastName", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "AddressType", "AddressType", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "Address", "AddressName", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "Street", "Street", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "Block", "Block", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "ZipCode", "ZipCode", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "City", "City", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "County", "County", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "Country", "Country", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "State", "State", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "Address2", "AddressName2", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "Address3", "AddressName3", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "StreetNo", "StreetNo", RegexOptions.IgnoreCase);
    //        //1
    //        tmp = Regex.Replace(tmp, "validFor", "Valid", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "validFrom", "ValidFrom", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "validTo", "ValidTo", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "ValidComm", "ValidRemarks", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "frozenFor", "Frozen", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "frozenFrom", "FrozenFrom", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "frozenTo", "FrozenTo", RegexOptions.IgnoreCase);
    //        tmp = Regex.Replace(tmp, "FrozenComm", "FrozenRemarks", RegexOptions.IgnoreCase);


    //        tmp = Regex.Replace(tmp, "ShippingType", "ShippingType", RegexOptions.IgnoreCase);
    //        //tx01.Text = tmp;
    //        //Clipboard.SetData(DataFormats.Text, tx01.Text);
    //        return tmp;
    //    }

    //    #endregion
    //}
}
