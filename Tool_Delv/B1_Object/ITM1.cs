using System;
using System.Collections.Generic;
using System.Text;

namespace AP_C 
{
    class ITM1:B1iSN 
    {
        public string ItemCode = "ItemCode";
        public string LineNum = "LineNum";
        public string PriceList = "PriceList";
        public string Price = "Price";
        public string Currency = "Currency";

        public override void Rlp(ref string tmp)
        { 
            tmp = Trans(tmp, "ItemCode", ItemCode);
            tmp = Trans(tmp, "LineNum", LineNum);
            tmp = Trans(tmp, "PriceList", PriceList);
            tmp = Trans(tmp, "Price", Price);
            tmp = Trans(tmp, "Currency", Currency);

        }
    }
}
