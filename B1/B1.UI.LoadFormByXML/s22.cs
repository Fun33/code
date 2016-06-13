using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

 
	class s22
	{ 
        public s22()
        {
            try
            {
                SubMain.LoadXML("22.xml");
 
            }
            catch (Exception ex)
            {
                SubMain.MessageBox(ex.Message   );
            }
        }
         
    }
 

