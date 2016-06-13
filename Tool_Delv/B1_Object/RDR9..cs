using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AP_C 
{
    class RDR9 : B1iSN 
    {
        public string DocEntry = "DocEntry";
        public string DocNum = "DocNum";
        public string LineNum = "LineNum";
        public string BaseAbs = "DocEntry";
        public string BsDocDate = "AmountToDraw";
        public string BsDueDate = "AmountToDrawFC";
        public string BsCardName = "AmountToDrawSC";
        public string BsComments = "GrossAmountToDraw";
        public string DrawnSum = "GrossAmountToDrawFC";
        public string Posted = "GrossAmountToDrawSC";



        public override void Rlp(ref string tmp)
        {
            tmp = Trans(tmp, "DocEntry", DocEntry);
            tmp = Trans(tmp, "DocNum", DocNum);
            tmp = Trans(tmp, "LineNum", LineNum);
            tmp = Trans(tmp, "BaseAbs", BaseAbs);
            tmp = Trans(tmp, "BsDocDate", BsDocDate);
            tmp = Trans(tmp, "BsDueDate", BsDueDate);
            tmp = Trans(tmp, "BsCardName", BsCardName);
            tmp = Trans(tmp, "BsComments", BsComments);
            tmp = Trans(tmp, "DrawnSum", DrawnSum);
            tmp = Trans(tmp, "Posted", Posted);

        }
    }
}
