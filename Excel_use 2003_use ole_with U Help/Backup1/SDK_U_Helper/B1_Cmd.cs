using System;
using System.Collections.Generic;
using System.Text;

namespace SDK_U_Helper
{
    class B1_Cmd
    {
        public  string getCmd_OADMQtyDev()
        {            
            string cmd = "select QtyDec from OADM";
            return cmd;
        }
    }
}
