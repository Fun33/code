using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AP_C 
{
    class RDR8 : B1iSN 
    {
        public string DocEntry = "DocEntry";
        public string DocNum = "DocNum";
        public string LineNum = "LineNum";
        public string PackageNum = "PackageNumber";
        public string ItemCode = "ItemCode";
        public string Quantity = "Quantity";

  
        public override  void Rlp(ref string tmp)
        {
            tmp = Trans(tmp, "DocEntry", DocEntry);
            tmp = Trans(tmp, "DocNum", DocNum);
            tmp = Trans(tmp, "LineNum", LineNum);
            tmp = Trans(tmp, "PackageNum", PackageNum);
            tmp = Trans(tmp, "ItemCode", ItemCode);
            tmp = Trans(tmp, "Quantity", Quantity);


        }
    }
}
