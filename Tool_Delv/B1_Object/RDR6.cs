using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AP_C 
{
    class RDR6 : B1iSN 
    {
        public string DocEntry = "DocEntry";
        public string DocNum = "DocNum";
        public string LineNum = "LineNum";
        public string DueDate = "DueDate";
        public string InstPrcnt = "Percentage";
        public string InsTotal = "Total";
        public string DunnLevel = "DunningLevel";
        public string InsTotalFC = "TotalFC";


        public override void Rlp(ref string tmp)
        {
            tmp = Trans(tmp, "DocEntry", DocEntry);
            tmp = Trans(tmp, "DocNum", DocNum);
            tmp = Trans(tmp, "LineNum", LineNum);
            tmp = Trans(tmp, "DueDate", DueDate);
            tmp = Trans(tmp, "InstPrcnt", InstPrcnt);
            tmp = Trans(tmp, "InsTotal", InsTotal);
            tmp = Trans(tmp, "DunnLevel", DunnLevel);
            tmp = Trans(tmp, "InsTotalFC", InsTotalFC);

        }
    }
}
