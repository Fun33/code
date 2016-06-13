using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Thread
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //按下去,就不停的run.until be close form
            for (int i = 0; i < 1; i--)
            { 

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            new Form2().Show();
        }
    }
}
