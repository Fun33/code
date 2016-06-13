using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Panbor_ImportWebSO
{
    public partial class ChangePwd : Form
    {
        private AP_Appliction appl;
        public ChangePwd(AP_Appliction _appl)
        {
            InitializeComponent();
            appl = _appl;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool  chkPwd()
        {
            bool ret = true;
            if (TextPwd1.Text == TextPwd2.Text)
            {
                ret = TextPwd1.Text.Trim().Length >= 4;
                if (!ret)
                    appl.MessageBox("至少長度為4，請重新輸入!!", MessageType.Warning);
            }
            else
            {
                appl.MessageBox("兩次密碼不一致，請重新輸入!!", MessageType.Warning);
            }
            return ret;
        }
        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (!(chkPwd()))
            {
                return;
            }

                string pwd =appl. SQLTrim( TextPwd1.Text);

                string cmd = "update OUSR set U_LOGINPWD='{0}'";
                cmd = string.Format(cmd, pwd);
                try
                {
                    appl.oSQLServer.ExecuteQuery(cmd);
                }
                catch (Exception ex)
                {
                    appl.SetSystemLog("修改密碼異常 : " + cmd + ex.ToString(),MessageType.Error );
                }
        }
    }
}