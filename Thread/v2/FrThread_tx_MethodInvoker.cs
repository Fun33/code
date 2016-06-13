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
    public partial class Form2 : Form
    {
        Thread sample; 
        public Form2()
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
                //tx.Text = count.ToString();//跨執行緒作業無效: 存取控制項 'tx' 時所使用的執行緒與建立控制項的執行緒不同。
            }
            //tx.Text = "333";//跨執行緒作業無效: 存取控制項 'tx' 時所使用的執行緒與建立控制項的執行緒不同。
            //所以需要用以下方法
            MethodInvoker mi = new MethodInvoker(this.UpdateUI);
            this.BeginInvoke(mi, null);

            MessageBox.Show("end");
          

            //1.在這裡
            //2.結束通知我
        }
        private void UpdateUI()
        {
            tx.Text = "end";
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
