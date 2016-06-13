//http://blog.tonycube.com/2011/04/backgroundworker.html
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing; 
using System.Text;
using System.Windows.Forms;

namespace AP_C
{
    public partial class Form1 : Form
    {
        private BackgroundWorker bw;

        public Form1(Main parent)
        {
            InitializeComponent();
            this.MdiParent = parent;
            this.WindowState = FormWindowState.Maximized;
     
            initProgressBar();
            initBackgroundWorker();
        }

        private void initProgressBar()
        {
            progressBar1.Step = 1;
        }

        private void initBackgroundWorker()
        {
            bw = new BackgroundWorker();
            bw.WorkerReportsProgress = true;
            bw.WorkerSupportsCancellation = true;
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
        }

        //背景執行
        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 1; (i <= 10); i++)
            {
                if ((bw.CancellationPending == true))
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    // 使用sleep模擬運算時的停頓
                    System.Threading.Thread.Sleep(500);
                    bw.ReportProgress((i * 10));
                }
            }
        }

        //處理進度
        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            this.lblMsg.Text = e.ProgressPercentage.ToString();
        }

        //執行完成
        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            if ((e.Cancelled == true))
            {
                this.lblMsg.Text = "取消!";
            }

            else if (!(e.Error == null))
            {
                this.lblMsg.Text = ("Error: " + e.Error.Message);
            }

            else
            {
                this.lblMsg.Text = "完成!";
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (bw.IsBusy != true)
            {
                this.lblMsg.Text = "開始";
                this.progressBar1.Value = 0;
                bw.RunWorkerAsync();
            }
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            if (bw.WorkerSupportsCancellation == true)
            {
                bw.CancelAsync();
            }
        }

    }
}