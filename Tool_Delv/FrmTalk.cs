using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AP_C
{
    public partial class FrmTalk : Form
    {
        public FrmTalk()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tx2.Text += tx1.Text + Environment.NewLine;
            func_txt.chat (tx1.Text);
            tx1.Text = "";
        }

     

        
    }
}
