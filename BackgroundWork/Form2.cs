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
    public partial class Form2 : Form
    {
        private BackgroundWorker bw,bw2;

        public Form2()
        {
            InitializeComponent();


       
        }

        public void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < 1; i--)
            {
                if ((bw.CancellationPending == true))//如果沒寫這個,就算  bw.CancelAsync();了,還是會一直做下去
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    //work
                    System.Diagnostics.Debug.WriteLine(i.ToString());
                    //report
                    if (i % 5 == 0)
                    {
                        System.Threading.Thread.Sleep(1000);
                        bw.ReportProgress(i * -1);
                        //bw.ReportProgress(0);
                    }
                }
            }
        }
        public void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //也可以不告訴你做到哪.但這樣的話,無從得知它有沒有在做.或是它發生什麼事情.            
            label1.Text = DateTime.Now.ToString();
            label2.Text = e.ProgressPercentage.ToString();
        }
    
        public void bw_DoWork2(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                if ((bw2.CancellationPending == true))//如果沒寫這個,就算  bw.CancelAsync();了,還是會一直做下去
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    //work
                    System.Diagnostics.Debug.WriteLine(i.ToString());
                    //report
                    if (i % 5 == 0)
                    {
                        System.Threading.Thread.Sleep(1000);
                        bw2.ReportProgress(i * -1);
                        //bw.ReportProgress(0);
                    }
                }
            }
      
        }
        public void bw_ProgressChanged2(object sender, ProgressChangedEventArgs e)
        {
            //也可以不告訴你做到哪.但這樣的話,無從得知它有沒有在做.或是它發生什麼事情.            
            label1.Text = DateTime.Now.ToString();
            label2.Text = e.ProgressPercentage.ToString();
        }
        //執行完成
        private void bw_RunWorkerCompleted2(object sender, RunWorkerCompletedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("end");
            if ((e.Cancelled == true))
            {
                this.label2 .Text = "取消!";
            }

            else if (!(e.Error == null))
            {
                this.label2.Text = ("Error: " + e.Error.Message);
            }

            else
            {
                this.label2.Text = "完成!";
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            bw = new BackgroundWorker();
            bw.WorkerReportsProgress = true;//若要允許傳送處理進度，則WorkerReportsProgress屬性要設為true
            bw.WorkerSupportsCancellation = true;//若要允許背景執行程式可以中途被中斷，則WorkerSupportsCancellation要設為true。
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);

            if (bw.IsBusy != true)
            {
                bw.RunWorkerAsync();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bw.CancelAsync();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("hi");
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bw2 = new BackgroundWorker();
            bw2.WorkerReportsProgress = true;//若要允許傳送處理進度，則WorkerReportsProgress屬性要設為true
            bw2.WorkerSupportsCancellation = true;//若要允許背景執行程式可以中途被中斷，則WorkerSupportsCancellation要設為true。
            bw2.DoWork += new DoWorkEventHandler(bw_DoWork2);
            bw2.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged2);
            bw2.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted2);
  

            if (bw2.IsBusy != true)
            {
                bw2.RunWorkerAsync();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            bw2.CancelAsync();
        }
    }
}
