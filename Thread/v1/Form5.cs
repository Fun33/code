using System;
using System.Windows.Forms;
using System.Threading;

namespace Thead
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            new SharedStateDemo2().Run();
        }
 
    }

    public class SharedStateDemo2
    {
        private int itemCount = 0;   // 已加入購物車的商品數量。
          private object locker = new Object(); // 用於獨佔鎖定的物件

        public void Run()
        {
            var t1 = new Thread(AddToCart);
            var t2 = new Thread(AddToCart);

            t1.Start(300);
            t2.Start(100);
        }

        private void AddToCart(object simulateDelay)
        {
 System.Diagnostics.Debug.WriteLine ("Enter thread {0}", // 顯示目前所在的執行緒編號
            Thread.CurrentThread.ManagedThreadId); 
        lock (locker)  // 利用 locker 物件來鎖定程式區塊
        {
            itemCount++;
 
            Thread.Sleep((int)simulateDelay);
           System.Diagnostics.Debug.WriteLine("Items in cart: {0} on thread {1}",
                itemCount, Thread.CurrentThread.ManagedThreadId);
        }
            System.Diagnostics.Debug.WriteLine  ("Items in cart: {0}", itemCount);
        }
    }
}
