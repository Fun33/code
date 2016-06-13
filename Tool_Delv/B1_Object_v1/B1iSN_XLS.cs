using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AP_C.v1
{
    public partial class FB1iSN_XLS : Form
    {
        public FB1iSN_XLS()
        {
            InitializeComponent();
        }
        public FB1iSN_XLS(Main parent)
        {
            InitializeComponent();
            this.MdiParent = parent;
            this.WindowState = FormWindowState.Maximized;
        }
        class colname2
        { 
      public static       string col_srcfld ="col_srcfld";
      public static string col_descfld = "col_descfld";
      public static string col_srctable = "col_srctable";
      public static string col_desctable = "col_desctable";

      public static string type = "col_type";
      public static string col_memo = "col_memo";
      public static string col_default = "col_default";


      public static string srcxml = "col_xmlsrcfld";
      public static string destxml = "col_xmldescfld";
        }
        private new void GetType()
        {
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                string src = dataGridView1.Rows[i].Cells[colname2. col_srcfld].Value.ToString();
                string desctable = dataGridView1.Rows[i].Cells[colname2.col_srctable].Value.ToString().ToUpper();
                string dest = dataGridView1.Rows[i].Cells[colname2.col_descfld].Value.ToString();
                switch (desctable )
                {
                    case "OITM":
                        dataGridView1.Rows[i].Cells[colname2.type].Value = new OITM(). gettype(dest);
                        break;
                    case "OCRD":
                        dataGridView1.Rows[i].Cells[colname2.type].Value = new OCRD(). gettype(dest);
                        break;
                    case "OCPR":
                        //dataGridView1.Rows[i].Cells[colname2.type].Value = OCPR. gettype_BP(dest);
                        break;
                    case "DOC":
                        dataGridView1.Rows[i].Cells[colname2.type].Value =new  doc(). gettype(dest);
                        break;
                }
            }
        }
        private void GetXMLFld_src()
        {
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                //如果不單純,這裡就要換成*
                string src = dataGridView1.Rows[i].Cells[colname2.col_srcfld].Value.ToString();
                string srctable = dataGridView1.Rows[i].Cells[colname2.col_srctable].Value.ToString().ToUpper();
                string desctable = dataGridView1.Rows[i].Cells[colname2.col_desctable].Value.ToString().ToUpper();
                string dest = dataGridView1.Rows[i].Cells[colname2.col_descfld].Value.ToString();

                switch (srctable)
                {
                    case "OITM":
                        dataGridView1.Rows[i].Cells[colname2.srcxml].Value = new OITM().GetXMLFld(src); 
                        break;
                    case "OCRD":
                        dataGridView1.Rows[i].Cells[colname2.srcxml].Value = new OCRD().GetXMLFld(src); 
                        break;
                    case "OCPR":
                        //dataGridView1.Rows[i].Cells[colname2.srcxml].Value = OCPR.GetXMLFld(src);
                        break;
                    case "DOC":
                        //dataGridView1.Rows[i].Cells[colname2.srcxml].Value = DOC.GetXMLFld_Item(src); 
                        break;
                }
            }
        }
        private void GetXMLFld_dest()
        {
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                //如果不單純,這裡就要換成*
                string src = dataGridView1.Rows[i].Cells[colname2.col_srcfld].Value.ToString();
                string srctable = dataGridView1.Rows[i].Cells[colname2.col_srctable].Value.ToString().ToUpper();
                string desctable = dataGridView1.Rows[i].Cells[colname2.col_desctable].Value.ToString().ToUpper();
                string dest = dataGridView1.Rows[i].Cells[colname2.col_descfld].Value.ToString();
                 
                switch (desctable)
                {
                    case "OITM":
                        dataGridView1.Rows[i].Cells[colname2.destxml].Value = new OITM().GetXMLFld(dest);
                        break;
                    case "OCRD":
                        dataGridView1.Rows[i].Cells[colname2.destxml].Value = new OCRD().GetXMLFld(dest);
                        break;
                    case "OCPR":
                        //dataGridView1.Rows[i].Cells[colname2.destxml].Value = OCPR.GetXMLFld(dest); 
                        break;
                    case "DOC":
                        //dataGridView1.Rows[i].Cells[colname2.destxml].Value = DOC.GetXMLFld_Item(dest);
                        break;
                }
            }
        }
        private void BtnExec_Click(object sender, EventArgs e)
        {
            //1.get type
            GetType();
            //bring memo


            //2.change xml
            if (rb_B12B1.Checked)
            {
                GetXMLFld_src();
                GetXMLFld_dest();
            }
            else if (rb_db2b1.Checked)
            {
                GetXMLFld_dest();
            }
            else if (rb_b12db.Checked)
            {
                GetXMLFld_src();
            }
            //3.trans
            string ret = "";
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                string src = dataGridView1.Rows[i].Cells[colname2.srcxml].Value.ToString();
                string dest = dataGridView1.Rows[i].Cells[colname2.destxml].Value.ToString();
                string type = dataGridView1.Rows[i].Cells[colname2.type].Value.ToString();
                string srctable = dataGridView1.Rows[i].Cells[colname2.col_srctable].Value.ToString().ToUpper();
                string desctable = dataGridView1.Rows[i].Cells[colname2.col_desctable].Value.ToString().ToUpper();
                //get path
                string path="";
                if (rb_db2b1.Checked)
                    path = father.GetPath("db");
                else
                path = father.GetPath(srctable) ;// "BO/Items/row/";// path_item_head;

                //start to trans
                if (type == "0")
                    ret += type0(path, src, dest);
                else if (type == "1")
                    ret += type1(src, path, dest, type0(path, src, dest));
                else if (type == "2")
                    ret += type2(src, path, dest, type0(path, src, dest));
                else if (type == "3")
                    ret += type3(src, path, dest, type0(path, src, dest));
                else if (type == "-1")
                    ret += typeNegative1(src, path, dest, type0(path, src, dest));
                else//default 0
                    ret += type0(path, src, dest);
            }
             
            Clipboard.SetData(DataFormats.Text, ret);
            string filename = @"d:\log" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
            System.IO.File.WriteAllText(filename, ret);
            System.Diagnostics.Process.Start(filename);
            return;        
        }



        private string type0(string path, string src, string dest)
        {
            string ret = @"<{1}><xsl:value-of select=""{0}{2}""/></{1}>";
            ret = string.Format(ret, path, dest, src);
            return ret;
        }

        private string type1(string src, string path, string dest, string type0)
        {
            string ret = @"<xsl:variable name=""{2}"" select=""{1}{0}""></xsl:variable>"
            + @"<xsl:if test=""${2}!=&apos;0&apos;"">"
            + @"{3}"
            + "</xsl:if>";
            ret = string.Format(ret, src, path, dest, type0);
            return ret;
        }
        private string type2(string src, string path, string dest, string type0)
        {
            string ret = @"<xsl:variable name=""{2}"" select=""{1}{0}""></xsl:variable>"
            + @"<xsl:if test=""${2}!=&apos;&apos;"">"
            + @"{3}"
            + "</xsl:if>";
            ret = string.Format(ret, src, path, dest, type0);
            return ret;
        }
        private string type3(string src, string path, string dest, string type0)
        {
            string ret = @"<{1}>{2}</{1}>";
            ret = string.Format(ret, path, dest, src);
            return ret;
        }
        private string typeNegative1(string src, string path, string dest, string type0)
        {
            string ret = @"<xsl:variable name=""{2}"" select=""{1}{0}""></xsl:variable>"
       + @"<xsl:if test=""${2}!=&apos;-1&apos;"">"
       + @"{3}"
       + "</xsl:if>";
            ret = string.Format(ret, path, dest, src);
            return ret;
        }

    }
}
