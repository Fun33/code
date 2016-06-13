using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CallCR
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CR_view obj = new CR_view();
            obj.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CR_view_param obj = new CR_view_param();
            obj.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            CR_view_conn_param obj = new CR_view_conn_param();
            obj.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            CR_view_conn  obj = new CR_view_conn ();
            obj.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            CR_view_conn_param_final obj = new CR_view_conn_param_final();
            obj.Show();
        }
    }
}
