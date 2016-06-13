using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace AP_C
{
    public partial class FB1iSN2 : Form
    {
        public FB1iSN2()
        {
            InitializeComponent();
        }

        private void Btn_ordr_Click(object sender, EventArgs e)
        {
            IB1iSN rdr = (IB1iSN)new ORDR();
            string tmp = tx01. Text;
            rdr.Rlp(ref tmp);
            tx01.Text = tmp;
            Clipboard.SetData(DataFormats.Text, tx01.Text);
        }

        private void Btn_rdr1_Click(object sender, EventArgs e)
        {
            IB1iSN rdr = (IB1iSN)new RDR1();
            string tmp = tx01.Text;
            rdr.Rlp(ref tmp);
            tx01.Text = tmp;
            Clipboard.SetData(DataFormats.Text, tx01.Text);
        }



        private void Btn_rdr2_Click(object sender, EventArgs e)
        {
            IB1iSN rdr = (IB1iSN)new RDR2();
            string tmp = tx01.Text;
            rdr.Rlp(ref tmp);
            tx01.Text = tmp;
            Clipboard.SetData(DataFormats.Text, tx01.Text);

        }
        private void Btn_rdr3_Click(object sender, EventArgs e)
        {
            IB1iSN rdr = (IB1iSN)new RDR3();
            string tmp = tx01.Text;
            rdr.Rlp(ref tmp);
            tx01.Text = tmp;
            Clipboard.SetData(DataFormats.Text, tx01.Text);
        }

        private void BtnRDR5_Click(object sender, EventArgs e)
        {
            IB1iSN rdr = (IB1iSN)new RDR5();
            string tmp = tx01.Text;
            rdr .Rlp(ref tmp);

            tx01.Text = tmp;
            Clipboard.SetData(DataFormats.Text, tx01.Text);

        }

        private void BtnRDR6_Click(object sender, EventArgs e)
        {
            IB1iSN rdr = (IB1iSN)new RDR6();
            string tmp = tx01.Text;
            rdr .Rlp(ref tmp);

            tx01.Text = tmp;
            Clipboard.SetData(DataFormats.Text, tx01.Text);
        }

        private void BtnRDR7_Click(object sender, EventArgs e)
        {
            IB1iSN rdr = (IB1iSN)new RDR7();
            string tmp = tx01.Text;
            rdr.Rlp(ref tmp);

            tx01.Text = tmp;
            Clipboard.SetData(DataFormats.Text, tx01.Text);
        }

        private void BtnRDR8_Click(object sender, EventArgs e)
        {
            IB1iSN rdr = (IB1iSN)new RDR8();
            string tmp = tx01.Text;
            rdr.Rlp(ref tmp);


            tx01.Text = tmp;
            Clipboard.SetData(DataFormats.Text, tx01.Text);
        }

        private void BtnRDR9_Click(object sender, EventArgs e)
        {
            IB1iSN rdr = (IB1iSN)new RDR9();
            string tmp = tx01.Text;
            rdr.Rlp(ref tmp);
            
            tx01.Text = tmp;
            Clipboard.SetData(DataFormats.Text, tx01.Text);
        }

        private void BtnRDR11_Click(object sender, EventArgs e)
        {
            IB1iSN rdr = (IB1iSN)new RDR11();
            string tmp = tx01.Text;
            rdr.Rlp(ref tmp);



            tx01.Text = tmp;
            Clipboard.SetData(DataFormats.Text, tx01.Text);
        }

        private void BtnRDR12_Click(object sender, EventArgs e)
        {
            IB1iSN rdr = (IB1iSN)new RDR12();
            string tmp = tx01.Text;
            rdr.Rlp(ref tmp);



            tx01.Text = tmp;
            Clipboard.SetData(DataFormats.Text, tx01.Text);
        }

        private void BtnOCRD_Click(object sender, EventArgs e)
        {
            IB1iSN rdr = (IB1iSN)new OCRD();
            string tmp = tx01.Text;
            rdr.Rlp(ref tmp);
            
            tx01.Text = tmp;
            Clipboard.SetData(DataFormats.Text, tx01.Text);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            IB1iSN  rdr = (IB1iSN )  new CRD1();
            string tmp = tx01.Text;
            rdr.Rlp(ref tmp);

            tx01.Text = tmp;
            Clipboard.SetData(DataFormats.Text, tx01.Text);
        }

        private void BtnOITM_Click(object sender, EventArgs e)
        {
            IB1iSN rdr = (IB1iSN) new OITM();
            string tmp = tx01.Text;
            rdr.Rlp(ref tmp);

            tx01.Text = tmp;
            Clipboard.SetData(DataFormats.Text, tx01.Text);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            IB1iSN rdr = (IB1iSN)new ITM1();
            string tmp = tx01.Text;
            rdr.Rlp(ref tmp);

            tx01.Text = tmp;
            Clipboard.SetData(DataFormats.Text, tx01.Text);
        }
    }
}
