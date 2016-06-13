
1.用執行緒.Main：thrd,xxx就交給你了.
thrd = new Thread(xxx);
thrd.Start();

2.在WinForm中，有個規定就是建立控制項的執行緒才能存取這個控制項，所以如果要更新主視窗的控制項的話，就要用主視窗的執行緒
(因為.NET規定不可跨執行緒控制UI的變化)

thrd：UpdateUI，回Main之後的事,就麻煩你了.
thrd：mi，請你帶它飛回Ｍain吧

MethodInvoker mi = new MethodInvoker(this.UpdateUI);//This delegate can be used when making calls to a control's Invoke method,
this.BeginInvoke(mi, null);
========================================獨立開一條執行緒去work
作法1
            sample = new Thread(_ThreadFunction);
            sample.Start(); 
作法2
            BackgroundWorker bgwWorker = new BackgroundWorker();
            bgwWorker.DoWork +=new DoWorkEventHandler(bgwWorker_DoWork);
            bgwWorker.RunWorkerAsync();

========================================thread：xxx你回去main那邊ooo吧
作法1
            MethodInvoker mi = new MethodInvoker(this.UpdateUI);
            this.BeginInvoke(mi, null);
作法2
	    bgwWorker.WorkerReportsProgress = true;//設為 True 才能回報進度, 是 BackgroundWorker 本身設計的規範
		bgwWorker.ProgressChanged += new ProgressChangedEventHandler(bgwWorker_ProgressChanged);
		
		bgwWorker.ReportProgress(i);//引發ProgressChanged

===============================================