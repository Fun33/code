using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AP_C.v1
{
 
 
    public class OITM : B1_Object
    { 


        #region item
        public string XML_Path
        {
            get;
            set;
        }
        //0-normal
        //1-if 0 no mapping.
        //2-if ''  no mapping
        //defalt
        //?
        //foreon if !-'' mapping else be max or be min
        //CA_XX
        public   string gettype(string tmp)
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



        public   string GetXMLFld(string tmp)
        {
            //string tmp = tx01.Text;
            //tmp = Regex.Replace(tmp, "", "", RegexOptions.IgnoreCase);

            //??Item中怎麼會有BP的path
            //tmp = Regex.Replace(tmp, "avgprice", FldToXLS(path_bp_head, "AvgStdPrice"), RegexOptions.IgnoreCase);

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
    }
 
}
