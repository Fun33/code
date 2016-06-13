using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace WindowsService1
{
    /*
     * 做一個service.裡面什麼都沒有.
就只是個空.可供啟動.
要給它一個命名.叫做aTest.
然後要能安裝.

1.要用installutil.exe安裝

C:\WINDOWS\Microsoft.NET\Framework\v4.0.30319\InstallUtil.exe D:\9-other\Desktop\WindowsService1\WindowsService1\bin\Debug\aaaTest.exe

C:\WINDOWS\Microsoft.NET\Framework\v4.0.30319\InstallUtil.exe D:\9-other\Desktop\WindowsService1\WindowsService1\bin\Debug\aaaTest.exe /u

>裝上去,沒看見.

     * service自己關閉:   private void Off()
     */

    public partial class Service1 : ServiceBase
    {
        /// <summary>
        /// 要被重啟的service
        /// </summary>
        public string m_ServiceName = "aaaLog";
        public System.Timers.Timer timersTimer = new System.Timers.Timer();
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            timersTimer.Enabled = false;

            timersTimer.Interval = 6000;

            timersTimer.Elapsed += new System.Timers.ElapsedEventHandler(timersTimer_Elapsed);
            timersTimer.Start();
        }
        void timersTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            on();
        }
        private void log(string msg)
        {
            string sSource;
            string sLog;
            string sEvent;

            sSource = "ResartService";
            sLog = "Application";

            if (!EventLog.SourceExists(sSource))
                EventLog.CreateEventSource(sSource, sLog);

            EventLog.WriteEntry(sSource, msg,
                EventLogEntryType.Warning, 234);
        }
        private void Off()
        {
            try
            {
                ServiceController service = new ServiceController(m_ServiceName);

                // 設定一個 Timeout 時間，若超過 60 秒啟動不成功就宣告失敗!
                TimeSpan timeout = TimeSpan.FromMilliseconds(1000 * 60);

                // 若該服務不是「停用」的狀態，才將其停止運作，否則會引發 Exception
                if (service.Status != ServiceControllerStatus.Stopped &&
                    service.Status != ServiceControllerStatus.StopPending)
                {
                    log(DateTime.Now.ToString() + " stoping " + m_ServiceName);
                    service.Stop();
                    service.WaitForStatus(ServiceControllerStatus.Stopped, timeout);
                }
            }
            catch (Exception ex)
            {
                log("服務無法停用 ");
                // 如果無法停用服務會引發 Exception，也會讓反安裝自動中斷
                //throw new InstallException("服務無法停用，建議您可以先利用「工作管理員」將 Service1.exe 程序結束，再進行解除安裝。");
            }
        }
        private void on()
        {
            try
            {

                // 建立 ServiceController 物件實體
                ServiceController service = new ServiceController(m_ServiceName);

                // 設定一個 Timeout 時間，若超過 30 秒啟動不成功就宣告失敗!
                TimeSpan timeout = TimeSpan.FromMilliseconds(1000 * 30);

                if (service.Status != ServiceControllerStatus.StartPending &&
                      service.Status != ServiceControllerStatus.Running)
                {
                    log(DateTime.Now.ToString() + " restarting " + m_ServiceName);

                    // 啟動服務
                    service.Start();

                    // 設定該服務必須在等待 timeout 時間內將狀態改變至「已啟動(Running)」的狀態
                    service.WaitForStatus(ServiceControllerStatus.Running, timeout);
                }
            }
            catch
            {
                log("服務無法啟動，請檢查相關設定!");
                //System.Windows.Forms.MessageBox.Show("服務無法啟動，請檢查相關設定!");
            }
        }
        protected override void OnStop()
        {
            log("停止了");
        }
    }
}
