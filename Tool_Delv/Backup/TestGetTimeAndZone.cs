using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace AP_C
{
    public partial class TestGetTimeAndZone : Form
    {
        public TestGetTimeAndZone(Main parent)
        {
            InitializeComponent();
            this.MdiParent = parent;
            this.WindowState = FormWindowState.Maximized;
        }

        private void TestGetTimeAndZone_Load(object sender, EventArgs e)
        {
            String format = "D";
            DateTime date = System.DateTime.Now;
            MessageBox.Show( date.ToString(format, DateTimeFormatInfo.InvariantInfo));
        }
    }
}