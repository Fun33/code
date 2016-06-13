using System;
using System.Windows.Forms;
using System.Threading;

namespace Thead
{
    public partial class Form0 : Form
    {
        Thread t1;
        NotifyIcon icn = new NotifyIcon();

        public Form0()
        {
            InitializeComponent();

            //ref http://www.dotblogs.com.tw/chou/archive/2009/02/25/7284.aspx
            icn.Visible = true;
            //icn.Icon = new System.Drawing.Icon(@"D:\cadmen\una_work\sample\Thead\favicon.ico");
            icn.BalloonTipText = "fun test";
            icn.MouseMove +=new MouseEventHandler(icn_MouseMove);
            icn.Click +=new EventHandler(icn_Click);
        }
        #region icn event http://www.dotblogs.com.tw/chou/archive/2009/02/25/7284.aspx


        public void icn_MouseMove(object sender, MouseEventArgs e)
        {           
            icn.ShowBalloonTip(500);
        }

        public void icn_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }
        #endregion icn event
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
        t1 = new Thread(MyBackgroundTask);
            t1.Start();

       
        }
          void MyBackgroundTask()
        {
            while (true)
            //for (int i = 0; i < 100; i++)
            {
                //richTextBox1.Text += "job.t1.[" + Thread.CurrentThread.ManagedThreadId + "]" + Environment.NewLine;//Cross-thread operation not valid: Control 'richTextBox1' accessed from a thread other than the thread it was created on.
                 System.Diagnostics.Debug.WriteLine ("sub thread.t1.[" + Thread.CurrentThread.ManagedThreadId + "]");
            }
        }

          private void button2_Click(object sender, EventArgs e)
          {
              MessageBox.Show("hi");
          }

          private void Form0_FormClosing(object sender, FormClosingEventArgs e)
          {
              try
              { 
                  if (t1 != null && t1.IsAlive)
                      e.Cancel = true;         
              }
              catch (Exception ex)
              { 

              }
          }

          private void Form0_Resize(object sender, EventArgs e)
          {
              if (this.WindowState == FormWindowState.Minimized)
              {
                  this.icn.Visible = true;
                  this.Hide();
              }
              else
              {
                  this.icn.Visible = false;
              } 
          }
 
    }
}
