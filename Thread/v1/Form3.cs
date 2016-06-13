using System;
using System.Windows.Forms;
using System.Threading;

namespace Thead
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread t1 = new Thread(MyBackgroundTask);
            Thread t2 = new Thread(MyBackgroundTask);
            Thread t3 = new Thread(MyBackgroundTask);

            t1.Start("X");
            t2.Start("Y");
            t3.Start("Z");

            //這會令主執行緒依序等待 t1、t2、t3 執行完畢之後才繼續跑底下的迴圈
            t1.Join();
            t2.Join();
            t3.Join();

            for (int i = 0; i < 500; i++)
            {
                 System.Diagnostics.Debug.WriteLine ("main job");
            }
        }
        static void MyBackgroundTask(object param)
        {
            for (int i = 0; i < 500; i++)
            {
                System.Diagnostics.Debug.WriteLine(param);
            }
        }
    }
}
