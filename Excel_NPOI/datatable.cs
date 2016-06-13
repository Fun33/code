using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;

namespace NPOI
{
 public    class DT
    {
        public DataTable GetDataTable()
        {
            DataTable odt = new DataTable();
            DataRow row;
            odt.Columns.Add("t1");
            odt.Columns.Add("t2");
            odt.Columns.Add("t3");

            row = odt.NewRow();
            row[0] = "l";
            row[1] = "o";
            row[2] = "v";
            odt.Rows.Add(row);

            row = odt.NewRow();
            row[0] = "f";
            row[1] = "u";
            row[2] = "c";
            odt.Rows.Add(row);

            return odt;
        }
    }
}
