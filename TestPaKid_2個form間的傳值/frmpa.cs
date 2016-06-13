using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AP_C
{
    public partial class frmpa : Form
    {
        public string ma = "pa";
        public frmpa()
        {
            InitializeComponent();
        }

        private void frmpa_Load(object sender, EventArgs e)
        {
            
        }
        public void hi()
        {
            MessageBox.Show(ma);
        }
    }
}
