using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace AP_C
{
    public partial class FrmMove : Form
    {
        public FrmMove()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("start");
            try
            {
                string src = tx1.Text;
                string    ext2 = "";
                string dest;
                string filename;

                List<string> myList = new List<string>();


                string folderName = src;

                // 取得資料夾內所有檔案
                foreach (string fname in System.IO.Directory.GetFiles(folderName))
                {
                    ext2 = Path.GetExtension(fname);
                    System.Diagnostics.Debug.WriteLine(ext2);
                    dest = System.IO.Path.Combine(src, ext2.TrimStart('.'));
                        if (System.IO.Directory.Exists(dest) == false)
                        {
                            System.IO.Directory.CreateDirectory(dest);
                        }
                        filename = System.IO.Path.Combine(dest, Path.GetFileName (fname));
                        if (File.Exists(filename) == false)
                        {
                            System.IO.File.Move(fname, filename);
                        }
                     
                }
                MessageBox.Show("end");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message+ex.ToString());
            }
            

        }

        private void FrmMove_Load(object sender, EventArgs e)
        {
            tx1.Text = @"J:\";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("start");
            try
            {
                string src = tx4.Text;
                string ext = tx2.Text, ext2 = "";
                string dest = tx3.Text ;
                string filename;

                List<string> myList = new List<string>();


                string folderName = src;

                // 取得資料夾內所有檔案
                foreach (string fname in System.IO.Directory.GetFiles(folderName))
                {
                    ext2 = Path.GetExtension(fname);
                    
                    if (ext2 == ext)
                    {
                        dest = System.IO.Path.Combine(dest, Path.GetFileName(fname));
                        filename = System.IO.Path.Combine(dest, Path.GetFileName(fname));
                        //System.Diagnostics.Debug.WriteLine(ext2);
                     
                        //add dir
                        if (System.IO.Directory.Exists(dest) == false)
                        {
                            System.IO.Directory.CreateDirectory(dest);
                        }                        
                        //move
                        if (File.Exists(filename) == false)
                        {
                            System.IO.File.Move(fname, filename);
                        }
                    }
                }
                MessageBox.Show("end");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.ToString());
            }
            
        }
    }
}
