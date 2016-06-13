using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AP_C 
{
    class RDR11 : B1iSN 
    {
        //must be chk
        //public string DocEntry = "RowNum";
        public string DocEntry = "DocEntry";

        public string DocNum = "DocNum";
        public string LineNum = "LineNum";
        
        public string LineSeq = "VatGroupCode";
        public string BaseAbs = "AmountToDraw";
        public string VatGroup = "AmountToDrawFC";
        public string VatPrcnt = "AmountToDrawSC";
        public string LineTotal = "GrossAmountToDraw";
        public string TotalFrgn = "GrossAmountToDrawFC";
        public string TotalSumSy = "GrossAmountToDrawSC";

        public override void Rlp(ref string tmp)
        {
            tmp = Trans(tmp, "DocNum", DocNum);
            tmp = Trans(tmp, "LineNum", LineNum);
            tmp = Trans(tmp, "DocEntry", DocEntry);
            tmp = Trans(tmp, "LineSeq", LineSeq);
            tmp = Trans(tmp, "BaseAbs", BaseAbs);
            tmp = Trans(tmp, "VatGroup", VatGroup);
            tmp = Trans(tmp, "VatPrcnt", VatPrcnt);
            tmp = Trans(tmp, "LineTotal", LineTotal);
            tmp = Trans(tmp, "TotalFrgn", TotalFrgn);
            tmp = Trans(tmp, "TotalSumSy", TotalSumSy);

      
        }
    }
}
