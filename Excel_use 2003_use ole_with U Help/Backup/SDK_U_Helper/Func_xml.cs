//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Xml;

// //ref
////http://www.dotblogs.com.tw/yc421206/archive/2010/08/10/17108.aspx
////XmlDocument

//    public class TXML
//    {
//        private string _FilePath = string.Empty;
//        public string FilePath
//        {
//            get
//            {
//                if (_FilePath == null)
//                    return string.Empty;
//                else
//                    return _FilePath;
//            }
//            set
//            {
//                if (_FilePath != value)
//                    _FilePath = value;
//            }
//        }


//        /// string context = "<info><db/></info>";
//            ///path = System.IO.Path.Combine(path, "option.xml");            
//            ///oXML = new TXML(path,context);     
//        public TXML(string path,string context)
//        {           
//            _FilePath = path;
//            ExistFile(context); //如果檔案不存在,新增檔案
//        }
     
//        //private void addxmlfile()
//        //{
//        //    XmlDocument XD = new XmlDocument();
//        //    XmlElement root = XD.CreateElement("info");
//        //    XmlElement nm = XD.CreateElement("db");

//        //    root.AppendChild(nm);
//        //    XD.AppendChild(root);

//        //    XD.Save(_FilePath);
//        //}
//        private  void ExistFile(string xml)
//    {
            
//          XmlDocument XD = new XmlDocument();
//          try
//          {
//              XD.Load(_FilePath);
//          }
//            catch (Exception ex )
//          {
//              XD.LoadXml(xml);
//              XD.Save(_FilePath );
//            }
//    }

//        ///oXML.getKeyValue("db", "srcServer"); 
//        public  string  getKeyValue(string father,string id)//GetXMLNodeInnerText
//        { 
//            string ret="";

//            father = "//" + father;
//            id = "//" + id;

//            XmlDocument XD = new XmlDocument();
//            XD.Load(_FilePath);

//            XmlNode node = XD.SelectSingleNode(id);
//            if (node != null)
//                ret = node.InnerText;

//            return ret;
//        }
 
//        /// SetXMLNodeInnerText("db","srcserver", "love u crazy crazy2");       
//        public void setKeyValue(string father, string id, string value)//SetXMLNodeInnerText
//        {
//            father = "//" + father;
//            id = "//" + id;

//            XmlElement elmt;
//            XmlNode node; 


//            XmlDocument XD = new XmlDocument();
//            XD.Load(_FilePath);

//            node = XD.SelectSingleNode(id);
//            if (node == null)
//            {
//                node = XD.SelectSingleNode(father);//get father

//                elmt = XD.CreateElement(id.Trim('/'));//add 
//                elmt.InnerText = value;

//                node.AppendChild(elmt);//link father.
                
//            }
//            else if     ( node.InnerText != value)
//            { 
//                node.InnerText = value;
//            }
//            try
//            {
//                XD.Save(_FilePath);
//            }
//            catch (Exception ex)
//            {
//   //不知是不是寫太快.有時侯,會有以下錯誤訊息
//   //System.IO.IOException: 參數錯誤。
//   //於 System.IO.__Error.WinIOError(Int32 errorCode, String maybeFullPath)
//   //於 System.IO.FileStream.Init(String path, FileMode mode, FileAccess access, Int32 rights, Boolean useRights, FileShare share, Int32 bufferSize, FileOptions options, SECURITY_ATTRIBUTES secAttrs, String msgPath, Boolean bFromProxy)
//   //於 System.IO.FileStream..ctor(String path, FileMode mode, FileAccess access, FileShare share)
//   //於 System.Xml.XmlTextWriter..ctor(String filename, Encoding encoding)
//   //於 System.Xml.XmlDocument.Save(String filename)
//   //於 TXML.setKeyValue(String father, String id, String value) 於 Z:\cadmen\una_work\TADC\SDK_U_Helper\Func_xml.cs: 行 112

//                func.log(ex.ToString() + Environment.NewLine +" value : " + value);
//            }
//        }
//    }
 
