using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AP_C
{
    public partial class FrmGetAndCopy : Form
    {
        public FrmGetAndCopy()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void FrmGetAndCopy_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string src = txsrc.Text;
                string desc = txdest.Text;
                string point = src;
                //找下個資料夾
                //找next file
                //chk file amr and mp4
                //copy and paste to dest
                getAmrFile(src, desc);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.ToString());
            }
        }

        private void getAmrFile(string point, string dest)
        {
            string dest0;
            foreach (string doc in System.IO.Directory.GetDirectories(point))
            {
                Console.WriteLine("doc : " + doc);
                foreach (string fname in System.IO.Directory.GetFileSystemEntries(doc, "*.amr"))
                {
                    System.Threading.Thread.Sleep(100);
                    dest0 = dest + "\\" + DateTime.Now.ToString("yyyyMMdd.HHmmss.fff") + ".amr";
                    System.IO.File.Copy(fname, dest0);

                }
                foreach (string fname in System.IO.Directory.GetFileSystemEntries(doc, "*.mp4"))
                {
                    System.Threading.Thread.Sleep(100);
                    dest0 = dest + "\\" + DateTime.Now.ToString("yyyyMMdd.HHmmss.fff") + ".mp4";
                    System.IO.File.Copy(fname, dest0);
                }
                if (System.IO.Directory.Exists(doc))
                {
                    getAmrFile(doc, dest);
                }
            }
        }
        private void getStringForChkFileExist(string fname)
        { 
            string msg = "SubApp.chkFileExist(" + System.IO.Path.GetFileNameWithoutExtension(fname) + ");";
            textBox2.Text += msg + Environment.NewLine;
        }
        private void getStringForChkFileExist(string doc,string fname)
        { 
            string msg = "SubApp.chkFileExist(" +doc+"."+ System.IO.Path.GetFileNameWithoutExtension(fname) + ");";
            textBox2.Text += msg + Environment.NewLine;
        }
        private void BtnStep1ForYFYCN_Click(object sender, EventArgs e)
        {
            string doc2;
            string point = textBox1.Text;
            //SQLFunction開頭的資料夾
            //列出底下的sql檔案名
            foreach (string doc in System.IO.Directory.GetDirectories(point))
            {
                if (doc.Contains("SQLFunction"))
                {
                    textBox2.Text += Environment.NewLine;
                    textBox2.Text += "//" + doc + Environment.NewLine;
                    foreach (string fname in System.IO.Directory.GetFileSystemEntries(doc, "*.sql"))                    
                    {
                        step1ForYFYCN(doc, fname);
                   
                    }
                }
            }
        }

        private void step1ForYFYCN(string doc, string fname)
        {
            //textBox2.Text += System.IO.Path.GetFileNameWithoutExtension(fname)
            //+System.IO.Path.GetExtension(fname) + Environment.NewLine;

            string filename = doc + @"\"
                + System.IO.Path.GetFileNameWithoutExtension(fname)
                  + System.IO.Path.GetExtension(fname)
                  + Environment.NewLine;

            textBox2.Text += "public static string "
                + System.IO.Path.GetFileNameWithoutExtension(fname)
                + @" = dir + @""\"
              + System.IO.Path.GetFileNameWithoutExtension(fname)
                    + System.IO.Path.GetExtension(fname)
              + @"""; " + Environment.NewLine;

            if (System.IO.File.Exists(filename) == false)
            {
                textBox2.Text += "file not exist" + Environment.NewLine + Environment.NewLine;
            }
        }

        private void BtnStep2ForYFYCN_Click(object sender, EventArgs e)
        {
            string doc2;
            string point = textBox1.Text;
            //SQLFunction開頭的資料夾
            //列出底下的sql檔案名
            foreach (string doc in System.IO.Directory.GetDirectories(point))
            {
                if (doc.Contains("SQLFunction"))
                {
                    textBox2.Text += Environment.NewLine;
                    textBox2.Text += "//" + doc + Environment.NewLine;
                    foreach (string fname in System.IO.Directory.GetFileSystemEntries(doc, "*.sql"))
                    {
                        doc2 = doc.Replace(point + @"\", "");
                        getStringForChkFileExist(doc2, fname);
                    }
                }
            }
        }


    }
}
