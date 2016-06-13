using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication_Thread
{
    class Program
    {
        static void Main(string[] args)
        {
            int x, DataRowCount, ThreadCount, s, e;
            ThreadCount = 16;//執行緒最大數量 16
            DataRowCount = 100000; //資料運算量

            Console.WriteLine(DateTime.Now.ToString() + "：執行緒集區建立。");

            //建立執行緒集區管理。意即執行緒將被平行運算
            System.Threading.ThreadPool.SetMaxThreads(ThreadCount, ThreadCount);
            System.Threading.AutoResetEvent[] doEvents = new System.Threading.AutoResetEvent[ThreadCount];

            ThreadProc[] TPArray = new ThreadProc[ThreadCount];

            //計算每個執行緒的運算分配量
            s = 0; e = 0;
            for (x = 1; x <= ThreadCount; x++)
            {
                e = DataRowCount / ThreadCount;
                if (x == 1)
                {
                    s = 0;
                }
                else
                {
                    s += e;
                    if (x == ThreadCount)
                    {
                        e = DataRowCount;
                    }
                    else
                    {
                        e += s;
                    }
                }
                Console.WriteLine(DateTime.Now.ToString() + "：執行緒(" + x.ToString() + ") 起始位置=" + s.ToString() + " , 結束位置=" + e.ToString());

                //採用AutoResetEvent方法，由個別建立之ThreadProc Class進行信號回饋
                doEvents[x - 1] = new System.Threading.AutoResetEvent(false);
                ThreadProc TP = new ThreadProc(doEvents[x - 1], s, e);
                TPArray[x - 1] = TP;

                System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(TP.DoWork), x);
            }

            //依序等待執行緒終止
            System.Threading.WaitHandle.WaitAll(doEvents);

            Console.WriteLine(DateTime.Now.ToString() + "：執行緒集區運算結果檢測。");

            for ( x = 1; x <= ThreadCount; x++)
            {
                ThreadProc TP = TPArray[x - 1];
                Console.WriteLine(DateTime.Now.ToString() + "：執行緒(" + x.ToString() + ") EventFlag:" + TP.EventFlag.ToString());
                TP.Dispose();
            }

            Console.WriteLine(DateTime.Now.ToString() + "：執行緒集區結束。");
            System.Threading.Thread.Sleep(50000);

        }
    }
}
