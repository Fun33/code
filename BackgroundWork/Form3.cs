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
    public partial class Form3 : Form
    {
        private BackgroundWorker bw;

// RunWorkerAsync()方法：啟動背景執行時呼叫。
//CancelAsync()方法：取消背景執行。
//ReportProgress()方法：在DoWork事件處理函式中，送出進度報告，會被ProgressChanged事件接收。
//DoWork事件：要在背景作業的程式放在DoWork事件的處理函式裡。需注意的是，在DoWork事件的處理函式裡不能有任何和UI元件的互動。
//ProgressChanged事件：處理進度的顯示。可以和UI元件互動。
//RunWorkerCompleted事件：執行完成。可以和UI元件互動。
//WorkerReportsProgress屬性：設定是否可以接收進度報告。
//WorkerSupportsCancellation屬性：設定是否支援非同步取消。
//CancellationPending屬性：在DoWork事件處理函式裡，用來判斷是否有要求取消背景執行。
//IsBusy屬性：在啟動背景作業之前，用來檢查是否仍有在執行的背景作業。

        public Form3()
        {
            InitializeComponent();
            initProgressBar();
            initBackgroundWorker();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
   
        }

        private void initProgressBar()
        {
            progressBar1.Step = 1;
        }

        private void initBackgroundWorker()
        {
            bw = new BackgroundWorker();
            bw.WorkerReportsProgress = true;//若要允許傳送處理進度，則WorkerReportsProgress屬性要設為true
            bw.WorkerSupportsCancellation = true;//若要允許背景執行程式可以中途被中斷，則WorkerSupportsCancellation要設為true。
            //要在背景作業的程式放在DoWork事件的處理函式裡。
            //需注意的是，在DoWork事件的處理函式裡不能有任何和UI元件的互動。
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
        }

        //背景執行
        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            //for (int i = 1; (i <= 10); i++)
                for (int i = 0; (i <= 10); i--)
            {
                if ((bw.CancellationPending == true))
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    // 使用sleep模擬運算時的停頓
                    //System.Threading.Thread.Sleep(500);
                    bw.ReportProgress((i * -1));
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
                bw.RunWorkerAsync();//啟動背景執行時呼叫。
            }
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            if (bw.WorkerSupportsCancellation == true)
            {
                bw.CancelAsync();//取消背景執行。
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("hi");
        } 
    }
}
