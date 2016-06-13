using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Thead 
{
    public partial class FrBackGroupWork : Form
    {
        public FrBackGroupWork()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BackgroundWorker bgwWorker = new BackgroundWorker();
            bgwWorker.DoWork +=new DoWorkEventHandler(bgwWorker_DoWork);
            bgwWorker.RunWorkerAsync();
        }
        public void bgwWorker_DoWork(object sender, DoWorkEventArgs e)
        { 
            int i=0;
            while (i < 100)
            {
                i++;
                System.Threading.Thread.Sleep(100);
            }
            MessageBox.Show("end"); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("OK"); 
        }
    }
}
