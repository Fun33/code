using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        Thread sample; 
        public Form1()
        {
            InitializeComponent();
        }
      
        private void _ThreadFunction()
        {
            int count = 0;

            while (count < 100)
            {
                count++;
                Thread.Sleep(100);
            } 
            MessageBox.Show("end");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            sample = new Thread(_ThreadFunction);
            sample.Start(); 
        }
     
        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("OK");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (sample.IsAlive)
            {
                sample.Abort();
            }
        }

    
    }
}
