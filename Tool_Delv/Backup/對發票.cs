using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AP_C
{
    public partial class 對發票 : Form
    {
        int cnt = 0;
        public 對發票(Main parent)
        {
            InitializeComponent();
            this.MdiParent = parent;
            this.WindowState = FormWindowState.Maximized;
        }

        private void 對發票_Load(object sender, EventArgs e)
        {

        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                string tmp = textBox1.Text;
                listBox1.Items.Add(textBox1.Text);
                textBox1.Text = "";
            }
        }

        private void btnChk_Click(object sender, EventArgs e)
        {
            cnt += 1;
            string code = textBox2.Text;
            string gCode = "";
            bool got = false;
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                gCode = listBox1.Items[i].ToString();
                if (code == gCode)
                {
                    MessageBox.Show("中大獎了!!");
                    got = true;                    
                }                           
            }
            if (!got)
                textBox3.Text +=cnt.ToString()+">>"+ code + "没中"+Environment.NewLine;
            textBox2.Text = "";
        }
    }
}