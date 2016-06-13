using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

 
	class s17
	{ 
        public s17()
        {
            try
            {
                SubMain.LoadXML("17.xml");
 
            }
            catch (Exception ex)
            {
                SubMain.MessageBox(ex.Message   );
            }
        }
         
    }
 

