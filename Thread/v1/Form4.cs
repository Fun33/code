using System;
using System.Windows.Forms;
using System.Threading;

namespace Thead
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            new SharedStateDemo().Run();
        }
 
    }

    public class SharedStateDemo
    {
        private int itemCount = 0;   // 已加入購物車的商品數量。

        public void Run()
        {
            var t1 = new Thread(AddToCart);
            var t2 = new Thread(AddToCart);

            t1.Start(300);
            t2.Start(100);
        }

        private void AddToCart(object simulateDelay)
        {
            itemCount++;

            /*
             * 用 Thread.Sleep 來模擬這項工作所花的時間，時間長短
             * 由呼叫端傳入的 simulateDelay 參數指定，以便藉由改變
             * 此參數來觀察共享變數值的變化。
             */
            Thread.Sleep((int)simulateDelay);
            System.Diagnostics.Debug.WriteLine  ("Items in cart: {0}", itemCount);
        }
    }
}
