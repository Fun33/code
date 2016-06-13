using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

 //ref
//http://www.dotblogs.com.tw/yc421206/archive/2010/08/10/17108.aspx
//XmlDocument

//缺:XML沒有檔案lock.可能多人存取與修改,造成dirty select and dirty write.
//注意
//如果沒有save,會造成檔案沒有解鎖
//1.多人用一個AP時,若改設定,會相互覆蓋.
//2.方案裡,要注意,如果在寫,在讀,就不能再讀,再寫.
//在用之前,要注意以上問題


    public class TXML
    {
        private string _FilePath = string.Empty;

        FileStream xmlFile;
        public XmlDocument XD = new XmlDocument();

        public string FilePath
        {
            get
            {
                if (_FilePath == null)
                    return string.Empty;
                else
                    return _FilePath;
            }
            set
            {
                if (_FilePath != value)
                    _FilePath = value;
            }
        }


        /// string context = "<info><db/></info>";
            ///path = System.IO.Path.Combine(path, "option.xml");            
            ///try {oXML = new TXML(path,context);     }catch(Exception ex){messbox.show(ex.message;)}
        public TXML(string path,string context)
        {           
            //set path
            //chk file exist
            //load file and lock file
            _FilePath = path;

            AddFile(context); //如果檔案不存在,新增檔案

            //read xml way 1
            //缺:無法lock file
            //XD.Load(_FilePath);


            //read xml way 2
            //解決無法lock file,造成dirty select問題
              xmlFile = new FileStream(_FilePath , FileMode.Open,FileAccess.Read, FileShare.Read);//利用它達到lock file的效果
            XD.Load(xmlFile);
            //Save();
            XD.Save(_FilePath  );//如果有人讀了,就會跳錯誤訊息.所以new的時侯要try catch

            
        }

      
     
        //private void addxmlfile()
        //{
        //    XmlDocument XD = new XmlDocument();
        //    XmlElement root = XD.CreateElement("info");
        //    XmlElement nm = XD.CreateElement("db");

        //    root.AppendChild(nm);
        //    XD.AppendChild(root);

        //    XD.Save(_FilePath);
        //}
        private  void AddFile(string xml)
    {
          try
          {
              XD.Load(_FilePath);
          }
            catch (Exception ex )
          {
              XD.LoadXml(xml);
              XD.Save(_FilePath );
            }
    }

        ///oXML.getKeyValue("db", "srcServer"); 
        public  string  getKeyValue(string father,string id)//GetXMLNodeInnerText
        { 
            string ret="";

            father = "//" + father;
            id = "//" + id;

     

            XmlNode node = XD.SelectSingleNode(id);
            if (node != null)
                ret = node.InnerText;

            return ret;
        }
 
        /// SetXMLNodeInnerText("db","srcserver", "love u crazy crazy2");       
        public void setKeyValue(string father, string id, string value)//SetXMLNodeInnerText
        {
            father = "//" + father;
            id = "//" + id;

            XmlElement elmt;
            XmlNode node; 


 

            node = XD.SelectSingleNode(id);
            if (node == null)
            {
                node = XD.SelectSingleNode(father);//get father

                elmt = XD.CreateElement(id.Trim('/'));//add 
                elmt.InnerText = value;

                node.AppendChild(elmt);//link father.
                
            }
            else if     ( node.InnerText != value)
            { 
                node.InnerText = value;
            }
           
        }
        
        public void Save()
        {
            try
            {
                XD.Save(_FilePath);
                xmlFile.Close();
            }
            catch (Exception ex)
            {
                func.log(ex.ToString() + Environment.NewLine);
              
            }
        }

        //public bool IsOpen()
        //{
        //    bool ret = false;
        //    try
        //    {
        //        XD.Save(_FilePath);
        //    }
        //    catch (Exception ex)
        //    {
        //        ret = true;
        //    }
        //    return ret;
        //}
    }
 
