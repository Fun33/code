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
    public partial class CR_view_conn_param_final : Form
    {
        public CR_view_conn_param_final()
        {
            InitializeComponent();
        }
        //ref
        //http://www.dotblogs.com.tw/jojo/archive/2010/01/06/12855.aspx
        private void crystalReportViewer1_Load(object sender, EventArgs e)
        { 
            ReportDocument cryRpt = new ReportDocument();//請引用CrystalDecisions.CrystalReports.Engine  
            string cmd = System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "CR_param.rpt");


            cryRpt.Load(cmd);   //看Rpt放在那裡,須讓它Load
            ChangeReportDataBase(cryRpt, "SERV16", "sa", "sapb1TADC");
            SetDocParameter(cryRpt, "param", "333");
            crystalReportViewer1.ReportSource = cryRpt;
            crystalReportViewer1.Refresh();
        }
 
    public void ChangeReportDataBase(ReportDocument myReport,string servername,string sa,string pwd)
    {
        CrystalDecisions.Shared.TableLogOnInfo myLoginInfo = new CrystalDecisions.Shared.TableLogOnInfo();
        foreach (CrystalDecisions.CrystalReports.Engine.Table myTable in myReport.Database.Tables)
        {
           myLoginInfo.ConnectionInfo.ServerName =servername ;
          myLoginInfo.ConnectionInfo.UserID = sa;
          myLoginInfo.ConnectionInfo.Password =pwd;
          myTable.ApplyLogOnInfo(myLoginInfo);
       }
    }
   ///rpt檔中若有參數時可用 
   public void SetDocParameter(ReportDocument prvDoc, string prvCRParName, string prvCRValue)
    {
        ParameterDiscreteValue DisParameter = new ParameterDiscreteValue();
        ParameterValues prvParameter = new ParameterValues();
        DisParameter.Value = prvCRValue;
        prvParameter.Add(DisParameter);
        prvDoc.DataDefinition.ParameterFields[prvCRParName].ApplyCurrentValues(prvParameter);
    }

    ///匯出pdf檔的做法，excel比照辦理
    //public string ExportPdf(ReportDocument prvReport, string prvPath, string prvFileName, string GetTimeToFileName)
    //{
    //    string GetFileName;
    //    DiskFileDestinationOptions dk = new DiskFileDestinationOptions();
    //   GetFileName = prvFileName + GetTimeToFileName + ".pdf";
    //   dk.DiskFileName = prvPath + GetFileName;
    //   prvReport.ExportOptions.DestinationOptions = dk;
    //   prvReport.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
    //   prvReport.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
    //   try
    //  {
    //      prvReport.Export();
    //      ExecFinal();
    //  }
    //  catch
    //  {
    //      ExecError(prvPath);
    //   }
    //   return GetFileName;
    //}
    }
}
