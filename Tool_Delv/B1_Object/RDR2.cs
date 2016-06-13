using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AP_C 
{
    class RDR2 : B1iSN 
    {
        public string DocEntry = "DocEntry";
        public string DocNum = "DocNum";
        public string LineNum = "LineNum";
        public string GroupNum = "GroupCode";
        public string ExpnsCode = "ExpenseCode";
        public string LineTotal = "LineTotal";
        public string TaxStatus = "TaxLiable";
        public string VatGroup = "VatGroup";
        public string VatPrcnt = "TaxPercent";
        public string VatSum = "TaxSum";
        public string DedVatSum = "DeductibleTaxSum";
        public string TaxCode = "TaxCode";
        public string TaxType = "TaxType";
        public string EquVatPer = "EqualizationTaxPercent";
        public string EquVatSum = "EqualizationTaxSum";
        public string WtLiable = "WTLiable";
        public string BaseGroup = "BaseGroup";
        public string OcrCode = "DistributionRule";

        public override void Rlp(ref string tmp)
        {
            tmp = Trans(tmp, "DocEntry", DocEntry);
            tmp = Trans(tmp, "DocNum", DocNum);
            tmp = Trans(tmp, "LineNum", LineNum);
            tmp = Trans(tmp, "GroupNum", GroupNum);
            tmp = Trans(tmp, "ExpnsCode", ExpnsCode);
            tmp = Trans(tmp, "LineTotal", LineTotal);
            tmp = Trans(tmp, "TaxStatus", TaxStatus);
            tmp = Trans(tmp, "VatGroup", VatGroup);
            tmp = Trans(tmp, "VatPrcnt", VatPrcnt);
            tmp = Trans(tmp, "VatSum", VatSum);
            tmp = Trans(tmp, "DedVatSum", DedVatSum);
            tmp = Trans(tmp, "TaxCode", TaxCode);
            tmp = Trans(tmp, "TaxType", TaxType);
            tmp = Trans(tmp, "EquVatPer", EquVatPer);
            tmp = Trans(tmp, "EquVatSum", EquVatSum);
            tmp = Trans(tmp, "WtLiable", WtLiable);
            tmp = Trans(tmp, "BaseGroup", BaseGroup);
            tmp = Trans(tmp, "OcrCode", OcrCode);
        }
    }
}
