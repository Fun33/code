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
    public partial class FrProgress : Form
    {
        private BackgroundWorker bgwWorker;
        public FrProgress()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bgwWorker = new BackgroundWorker();
            bgwWorker.WorkerReportsProgress = true;//設為 True 才能回報進度, 是 BackgroundWorker 本身設計的規範
            bgwWorker.DoWork += new DoWorkEventHandler(bgwWorker_DoWork);
            bgwWorker.ProgressChanged += new ProgressChangedEventHandler(bgwWorker_ProgressChanged);
            bgwWorker.RunWorkerAsync(); 
        }
        public void bgwWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            tx.Text = e.ProgressPercentage.ToString();
        }

        public void bgwWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            int i = 0;
            while (i < 100)
            {
                i++;
                bgwWorker.ReportProgress(i);//引發ProgressChanged
                System.Threading.Thread.Sleep(100);
                //e.Result = i;
            }
            MessageBox.Show("end");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("OK");
        }
    }
}
