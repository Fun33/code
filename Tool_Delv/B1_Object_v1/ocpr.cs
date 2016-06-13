//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Text.RegularExpressions;

//namespace AP_C
//{
  
//    public class OCPR : B1_Object
//    {
//        public string XML_Path
//        {
//            get;
//            set;
//        }
//        public string gettype(string tmp)
//        {
//            return "";
//        }
//        public   string GetXMLFld(string tmp)
//        {
//            tmp = Regex.Replace(tmp, "Cellular", "MobilePhone", RegexOptions.IgnoreCase);

//            tmp = Regex.Replace(tmp, "BirthPlace", "PlaceOfBirth", RegexOptions.IgnoreCase);
//            tmp = Regex.Replace(tmp, "address", "Address", RegexOptions.IgnoreCase);

//            tmp = Regex.Replace(tmp, "CardCode", "CardCode", RegexOptions.IgnoreCase);
            
//            return tmp;
//        }
        
      
   
//    }
   
//}
