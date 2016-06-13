using System;
using System.Windows.Forms;
using System.Threading;

namespace Thead
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            new SharedStateDemo3().Run();
        }
 
    }

    public class SharedStateDemo3
    {
        private int itemCount = 0;   // 已加入購物車的商品數量。
          private object locker = new Object(); // 用於獨佔鎖定的物件

        public void Run()
        {
            var t1 = new Thread(AddToCart); 
            
            t1.IsBackground = false; 

            t1.Start(300); 
        }

        private void AddToCart(object simulateDelay)
        {
            while (true)
            {
                System.Diagnostics.Debug.WriteLine("Enter thread {0}-{1}", // 顯示目前所在的執行緒編號
                       Thread.CurrentThread.ManagedThreadId,DateTime.Now.ToString()
                       )
                       ;
            }
        }
    }
}
