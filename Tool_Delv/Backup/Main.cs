using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AP_C
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            IsMdiContainer = true;
            this.WindowState = FormWindowState.Maximized;
        }

    

        private void b1isnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            B1iSN f = new B1iSN(this);
            f.Show();
        }

        private void trimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Trim f = new Trim(this);
            f.Show();
        }

        private void 對發票ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            對發票 f = new 對發票(this);
            f.Show();
        }

        private void timeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TestGetTimeAndZone  f = new TestGetTimeAndZone (this);
            f.Show();
        }

        private void threadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1(this);
            f.Show();
        }
    }
}