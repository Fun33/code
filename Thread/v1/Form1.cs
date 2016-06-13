using System;
using System.Windows.Forms;
using System.Threading;

namespace Thead
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread t1 = new Thread(MyBackgroundTask);
            t1.Start();

            //main thread做了,就不能按[hi]了
            for (int i = 0; i < 100; i++)            
            {
                //richTextBox1.Text += "job1"+Environment.NewLine ;
                System.Diagnostics.Debug.WriteLine("main thread");
            }
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
    }
}
