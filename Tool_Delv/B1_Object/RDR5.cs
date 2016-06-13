using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AP_C 
{
    class RDR5 : B1iSN 
    {
        public string DocEntry = "DocEntry";
        public string DocNum = "DocNum";
        public string LineNum = "LineNum";
        public string WTCode = "WTCode";
        public string WTAmntSC = "WTAmountSys";
        public string WTAmntFC = "WTAmountFC";
        public string WTAmnt = "WTAmount";
        public string TxblAmntSC = "TaxableAmountinSys";
        public string TxblAmntFC = "TaxableAmountFC";
        public string TaxbleAmnt = "TaxableAmount";
        public string ApplAmntSC = "AppliedWTAmountSys";
        public string ApplAmntFC = "AppliedWTAmountFC";
        public string ApplAmnt = "AppliedWTAmount";
        public string BaseAbsEnt = "BaseDocEntry";
        public string BaseLine = "BaseDocLine";
        public string BaseRef = "BaseDocType";





        public override void Rlp(ref string tmp)
        {
            tmp = Trans(tmp, "DocEntry", DocEntry);
            tmp = Trans(tmp, "DocNum", DocNum);
            tmp = Trans(tmp, "LineNum", LineNum);
            tmp = Trans(tmp, "WTCode", WTCode);
            tmp = Trans(tmp, "WTAmntSC", WTAmntSC);
            tmp = Trans(tmp, "WTAmntFC", WTAmntFC);
            tmp = Trans(tmp, "WTAmnt", WTAmnt);
            tmp = Trans(tmp, "TxblAmntSC", TxblAmntSC);
            tmp = Trans(tmp, "TxblAmntFC", TxblAmntFC);
            tmp = Trans(tmp, "TaxbleAmnt", TaxbleAmnt);
            tmp = Trans(tmp, "ApplAmntSC", ApplAmntSC);
            tmp = Trans(tmp, "ApplAmntFC", ApplAmntFC);
            tmp = Trans(tmp, "ApplAmnt", ApplAmnt);
            tmp = Trans(tmp, "BaseAbsEnt", BaseAbsEnt);
            tmp = Trans(tmp, "BaseLine", BaseLine);
            tmp = Trans(tmp, "BaseRef", BaseRef);

        }
    }
}
