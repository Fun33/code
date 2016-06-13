using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication_Thread
{

    class ThreadProc
    {
        private System.Threading.AutoResetEvent doneEvent;

        public int StartRecord { get; private set; }
        public int EndRecord { get; private set; }
        public bool EventFlag { get; private set; }

        public ThreadProc(System.Threading.AutoResetEvent doneEvent, int StartRecord, int EndRecord)
        {
            this.doneEvent = doneEvent;
            this.StartRecord = StartRecord;
            this.EndRecord = EndRecord;
            this.EventFlag = false;
        }

        public void DoWork(object thIndex)
        {
            //***
            //透過 System.Threading.ThreadPool.QueueUserWorkItem的方法，傳遞object thdt任意資訊

            //執行緒建立並取得執行續集區的位置
            System.Threading.Thread t = System.Threading.Thread.CurrentThread;
            t.Priority = System.Threading.ThreadPriority.Normal;

            int rowIndex, e, c, z, psco;
            double psval = 0;
            try
            {
                z = 0;
                c = 0;
                e = (this.EndRecord - this.StartRecord);
                psco = e / 10;

                Console.WriteLine(DateTime.Now.ToString() + "：執行緒(" + thIndex.ToString() + ") ThreadProc:" + t.ManagedThreadId.ToString() + " ... 0% (" + this.StartRecord.ToString() + " / " + this.EndRecord.ToString() + ")");
                for (rowIndex = this.StartRecord; rowIndex <= this.EndRecord - 1; rowIndex++)
                {
                    if (z == psco)
                    {
                        z = 0;
                        psval = (double)c / e * 100;
                        Console.WriteLine(DateTime.Now.ToString() + "：執行緒(" + thIndex.ToString() + ") ThreadProc:" + t.ManagedThreadId.ToString() + " ... " + psval.ToString("0.0") + "% (" + rowIndex.ToString() + " / " + this.EndRecord.ToString() + ")");
                    }

                    z += 1;
                    c += 1;
                }
                Console.WriteLine(DateTime.Now.ToString() + "：執行緒(" + thIndex.ToString() + ") ThreadProc:" + t.ManagedThreadId.ToString() + " ... 100% End");

                this.EventFlag = true;
                this.doneEvent.Set();//信號回饋
            }
            catch (Exception ex)
            {
                this.EventFlag = false;
                this.doneEvent.Set();//信號回饋

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(DateTime.Now.ToString() + "：ThreadProc:" + t.ManagedThreadId.ToString() + " ," + ex.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }

            this.doneEvent.Set();
        }

        public void Dispose()
        { 
        
        
        }
    }
}
