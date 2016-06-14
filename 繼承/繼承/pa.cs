using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 繼承
{
    class pa
    {
        public string CardCode { get; set; }
        public string SubJob { get; set; }

        public pa()
        {
            CardCode = "t1";
        }

        public pa(string _cardCode)
        {
            CardCode = _cardCode;
        }
    }
}
