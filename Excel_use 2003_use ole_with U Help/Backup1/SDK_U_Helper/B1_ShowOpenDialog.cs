using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;
using System.Management;
using System.Threading;
using SAPbobsCOM;
using SAPbouiCOM;
using System.Security.Permissions;
//using System.Data.Objects;

                   //OpenDialog op = new OpenDialog(this.SBO_Application);
                   // op.Filter = "xls Excel 檔案|*.xls|xlsx 2007 Excel 檔案|*.xlsx";
                   // op.OnGetFile += GetFileExcelToGrid;
                   // op.CloseOpenDialog += TurnOnSearchBtn;
                   // op.Show();
                //private void GetFileExcelToGrid(string s)
                //{           
                //}
public class OpenDialog
{
    public event OnGetFileEventHandler OnGetFile;
    //public event FormClosedEventHandler  CloseOpenDialog;

    public delegate void OnGetFileEventHandler(string FileName);
    //public delegate void FormClosedEventHandler();

    private SAPbouiCOM.Application SBO_Application;
    private OpenFileDialog OpenFile = new OpenFileDialog();
    //Private FileName As String = String.Empty

    public string Filter
    {
        get { return OpenFile.Filter; }
        set { OpenFile.Filter = value; }
    }

    public void Show()
    {
        System.Threading.Thread ShowFolderBrowserThread = null;
        try
        {
            ShowFolderBrowserThread = new System.Threading.Thread(ShowBrowser);
            if (ShowFolderBrowserThread.ThreadState == System.Threading.ThreadState.Unstarted)
            {
                ShowFolderBrowserThread.SetApartmentState(System.Threading.ApartmentState.STA);
                ShowFolderBrowserThread.Start();
            }
            else if (ShowFolderBrowserThread.ThreadState == System.Threading.ThreadState.Stopped)
            {
                ShowFolderBrowserThread.Start();
                ShowFolderBrowserThread.Join();
            }

            while (ShowFolderBrowserThread.ThreadState == System.Threading.ThreadState.Running)
            {
                System.Windows.Forms.Application.DoEvents();
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }

    }


    private void ShowBrowser()
    {
        System.Diagnostics.Process[] MyProcs = null;
        string UserName = Environment.UserName;

        try
        {
            OpenFile.Multiselect = false;
            if (string.IsNullOrEmpty(OpenFile.Filter))
            {
                OpenFile.Filter = "All files(*.)|*.*";
            }
            OpenFile.FilterIndex = 0;

            OpenFile.RestoreDirectory = true;

            MyProcs = System.Diagnostics.Process.GetProcessesByName("SAP Business One");

            for (int i = 0; i <= Information.UBound(MyProcs,1); i++)
            {
                if (GetProcessUserName(MyProcs[i]) == UserName)
                {
                    goto NEXT_STEP;
                }
            }
            this.SBO_Application.MessageBox("Unable to determine Running processes by UserName!",0,"","","");
            OpenFile.Dispose();
            return;
        NEXT_STEP:


            if (MyProcs.Length == 1)
            {

                for (int i = 0; i <= MyProcs.Length - 1; i++)
                {
                    WindowWrapper MyWindow = new WindowWrapper(MyProcs[i].MainWindowHandle);
                    DialogResult ret = OpenFile.ShowDialog(MyWindow);

                    if (ret == DialogResult.OK)
                    {
                        if (OnGetFile != null)
                        {
                            OnGetFile(OpenFile.FileName);
                            //CloseOpenDialog();//test
                            System.Windows.Forms.Application.ExitThread();//test
                        }
                        OpenFile.Dispose();
                    }
                    else
                    {
                        //CloseOpenDialog( );
                        System.Windows.Forms.Application.ExitThread();
                    }
                }
            }
            else
            {
                this.SBO_Application.MessageBox("警告 : SAP Business One應用程式、僅允許一個執行環境", 1, "OK", "", "");
            }
        }
        catch (Exception ex)
        {
            this.SBO_Application.MessageBox(ex.Message,1,"OK","","");
        }
        finally
        {
            OpenFile.Dispose();
        }

    }

    private string GetProcessUserName(Process Process)
    {
        ObjectQuery sq = new ObjectQuery("Select * from Win32_Process Where ProcessID = '" + Process.Id + "'");
        ManagementObjectSearcher searcher = new ManagementObjectSearcher(sq);

        if (searcher.Get().Count == 0)
            return null;
        foreach (ManagementObject oReturn in searcher.Get())
        {
            string[] o = new string[2];

            //Invoke the method and populate the o var with the user name and domain                         
            oReturn.InvokeMethod("GetOwner", (object[])o);
            return o[0];
        }
        return "";
    }

    public OpenDialog(SAPbouiCOM.Application fSBO)
    {
        SBO_Application = fSBO;
    }
}
