using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AP_C
{
    //讓ordr做papa
    public class B1iSN : IB1iSN
    {
      public virtual   void Rlp(ref string tmp)
      {
          //tmp = Trans(tmp, "DocEntry", DocEntry);
      }

        public   string Trans(string sStrings, string sSqlFld, string sXmlFld)
        {
            string ret = "";
            ret =   GetSqlFldPlusAlias(sStrings, sSqlFld, sXmlFld);
            return ret;
        }
      /// <summary>
      /// put select itemcode ;return select itemcode ItemCode
      /// </summary>
      /// <param name="sStrings">sqlcmd</param>
      /// <param name="sSqlFld">sqlfld</param>
      /// <param name="sXmlFld">xmlfld</param>
      /// <returns></returns>
        private  string GetSqlFldPlusAlias(string sStrings, string sSqlFld, string sXmlFld)
        {
            string ret = "";
            ret = Regex.Replace(sStrings, sSqlFld, sSqlFld + " " + sXmlFld, RegexOptions.IgnoreCase);
            return ret;
        }
    }
}
