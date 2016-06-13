using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Panbor_ImportWebSO
{
    public partial class MainForm : Form
    {
        private AP_Appliction appl;
        //private      read      rd = new read();

        

        public MainForm()
        {
            InitializeComponent();
        }

        private void InitializeFomShow()
        {
            this.appl = new AP_Appliction(this);

            string Msg = string.Empty;
            string SystemRoot = System.Environment.GetEnvironmentVariable("SystemRoot");
            SystemRoot = SystemRoot.Substring(0, 2) + "\\Log";

            //SystemRoot = System.Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
            

            DTsConfig sC = new DTsConfig();
            sC.LoadDecryptFile();
            if (string.IsNullOrEmpty(sC.LogPath))
            {
                if (Msg != "") { Msg += "\n"; }
                Msg += "尚未設定「歷程紀錄位置」\n系統預設路徑為：" + SystemRoot;
            }
            //if (string.IsNullOrEmpty(sC.SetingPath))
            //{
            //    if (Msg != "") { Msg += "\n\n"; }
            //    Msg += "尚未設定「設定檔紀錄位置」\n系統預設路徑為：" + SystemRoot;
            //}

            if (Msg != "")
            {
                sC.LogPath = SystemRoot;
                sC.SetingPath = SystemRoot;
                sC.CreateEncrypt();

                this.appl.ResetDTsConfig();

                if (Msg != "") { Msg += "\n\n"; }
                Msg += "若要變更路徑，由工具列「設定」「一般設定」進行變更";
                this.appl.SetSystemLog(Msg, MessageType.Warning);
                this.appl.MessageBox(Msg, MessageType.Warning);
            }
            try
            {
                SAP _sap = new SAP();
                appl.setDBLink();
            }
            catch
            {
                appl.oVar.isSetDB = false;
                Menu_2_Seting_Click(null, null);
                return;
            }

            if (!appl.oVar.isLogin)
            {
                Menu_1_Login_Click(null, null);
                return;
            }
        } 

        #region Form Events
   
        private void MainForm_Shown(object sender, EventArgs e)
        {
            Logout();
            InitializeFomShow();
        }
        #endregion

        #region Menu 1 Events
        //登入
        public void Menu_1_Login_Click(object sender, EventArgs e)
        {
            if (appl.oVar.isOpenFrmLogin)
                return;

            if (!appl.oVar.isSetDB)
            {
                appl.MessageBox("請先設定資料庫!!", MessageType.Success);
                return;
            } 
           
            sForm.Login Login = new sForm.Login(this.appl); 
            Login.ShowInTaskbar = false ;

            appl.oVar.isOpenFrmLogin = true;
      
            DialogResult ret =  Login.ShowDialog();

            if ((ret == DialogResult.OK) && (appl.oVar.isLogin))
            {
                InitLogined();                                        //Login.Close(); 

                while (this.MdiChildren.Length > 0)
                {
                    this.MdiChildren[0].Close();
                } 
            }
            else
            {
                Logout();
            }
            appl.oVar .isOpenFrmLogin = false;
        }
        private   void Menu_1_Logout_Click(object sender, EventArgs e)
        {
            Logout();            
        }
  
        //離開
        private void Menu_1_Exit_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
        #endregion
        #region Menu 2 Events
        //一般設定
        private void Menu_2_Config_Click(object sender, EventArgs e)
        {
            sForm.Config Config = new sForm.Config(this.appl);
            Config.ShowInTaskbar = false;
            Config.ShowDialog();
            //Config.MdiParent = this;
            //Config.Show();
        }
        //連線設定
        private void Menu_2_Seting_Click(object sender, EventArgs e)
        {
            sForm.SAP_Connection SAP_Connection = new sForm.SAP_Connection(this.appl);
            SAP_Connection.ShowInTaskbar = false;
            SAP_Connection.ShowDialog();
            //SAP_Connection.MdiParent = this;
            //SAP_Connection.Show();
        }
        #endregion
        #region Menu 3 Events
        //重疊顯示
        private void Menu_3_Cascade_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }
        //垂直並排
        private void Menu_3_TileVertical_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }
        //水平並排
        private void Menu_3_TileHorizontal_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }
        //排列圖示
        private void Menu_3_ArrangeIcons_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.ArrangeIcons);
        }
        //全部關閉
        private void Menu_3_CloseAll_Click(object sender, EventArgs e)
        {
            foreach (Form ChildForm in this.MdiChildren)
            {
                ChildForm.Close();
            }

        }
        #endregion
        #region Menu 4 Events
        private void Menu_4_Click(object sender, EventArgs e)
        {
            sForm.About About = new sForm.About();
            About.ShowInTaskbar = false;
            About.ShowDialog();
        }
        #endregion
        #region Menu 5 Events
        private void Menu_5_One_Click(object sender, EventArgs e)
        {
          
        }
      
        #endregion 

        private  void InitLogined()
        {
            this.Menu_5.Enabled = true;
            tipDataBase.Text = "[資料庫 - "  ;
            tipUserName.Text = "[人員 - " ; 
            string msg = "登入 - [{0}] [{1}] [{2}]  ";
            msg = string.Format(msg, appl.oVar.LogDataBase, appl.oVar.LoginName, appl.oVar.StationName);
        } 
        public   void Logout()
        { 
            this.Menu_5.Enabled = false ;
            tipDataBase.Text = "[資料庫]";
            tipUserName.Text = "[回報人員]";
            tipStation.Text = "[站別]";
            
            if (appl != null)
            {
                appl.oVar.isLogin = false; 
                string msg = "登出 - [{0}] [{1}] [{2}]  ";
                msg = string.Format(msg, appl.oVar.LogDataBase, appl.oVar.LoginName, appl.oVar.StationName);           
                appl.SetSystemLog(msg, MessageType.Success);
            }
        }

 

    

 


 




    }
}