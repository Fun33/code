using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace CallCR
{
    public partial class CR_view_conn  : Form
    {
        public CR_view_conn()
        {
            InitializeComponent();
        }
        //ref
        //http://www.dotblogs.com.tw/jojo/archive/2010/01/06/12855.aspx
        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            ReportDocument cryRpt = new ReportDocument();//請引用CrystalDecisions.CrystalReports.Engine  
            string cmd = System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "CR.rpt");
            

            cryRpt.Load(cmd);
            //set db
            CrystalDecisions.Shared.TableLogOnInfo myLoginInfo = new CrystalDecisions.Shared.TableLogOnInfo();
            foreach (CrystalDecisions.CrystalReports.Engine.Table myTable in cryRpt.Database.Tables)
            {
                myLoginInfo.ConnectionInfo.ServerName = "SERV16";
                myLoginInfo.ConnectionInfo.UserID = "sa";
                myLoginInfo.ConnectionInfo.Password = "sapb1TADC";
                myTable.ApplyLogOnInfo(myLoginInfo);
            }
      
            //
            crystalReportViewer1.ReportSource = cryRpt;
            crystalReportViewer1.Refresh();
        }
    }
}
