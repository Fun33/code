using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Timers;
using System.Threading;

namespace Timer_S
{
    
    public partial class Form2 : Form
    {
        private System.Timers.Timer t ;
        private bool IsReWork = false;
        public Form2()
        {
            InitializeComponent();
            t = new System.Timers.Timer(10000);
            t.Elapsed += new System.Timers.ElapsedEventHandler(clock_Tick);
            t.AutoReset = true;//設置是執行一次（false）還是一直執行(true)； 
            t.Enabled = true;//是否執行System.Timers.Timer.Elapsed事件；
            t.SynchronizingObject = this;
        }
        private void clock_Tick(object source, System.Timers.ElapsedEventArgs e) 
        {
            try
            {
                IsReWork = true;
                txLog.Text += DateTime.Now.ToString() + Environment.NewLine;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            txLog.Text += IsReWork.ToString();
            while (DateTime.Now < DateTime.Parse("2014/12/12 13:38"))
            {
                string a = "";
            }
        }
    }
}
