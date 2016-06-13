using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
namespace Thead
{
    public partial class Form7_傳2個參數到thread : Form
    { 

        public Form7_傳2個參數到thread()
        {
            InitializeComponent();            
        }
         

       

        private void Form7_t2_Load(object sender, EventArgs e)
        {
            List<Thread> _Threads = new List<Thread>();
            for (int i = 0; i < 3; i++)
            {
                ExecByDB obj = new ExecByDB();
                Thread t1 = new Thread(obj.Exec);
                obj.db = i.ToString();
                obj.PriceList = "2";
                _Threads.Add(t1);
                t1.Start();
                
            }
            foreach (Thread item in _Threads)
            {
                item.Join();//使用若要主執行緒等待其他執行緒完成，可以使用Thread.Join方法，來確保所有執行緒已完成工作。
            }
            System.Diagnostics.Debug.Write("The End");
        }
    }
    class ExecByDB
    {
        public string  db;
        public string PriceList;
        public void Exec()
        {
            long i = 99   ;
           while (i>0)
            {
                i = i - 1;
                // Calculate the area of a triangle.
                string msg = "[{0}]";
                msg = string.Format(msg, db);
                System.Diagnostics.Debug.Write(msg);
            }
        }
    }
}
